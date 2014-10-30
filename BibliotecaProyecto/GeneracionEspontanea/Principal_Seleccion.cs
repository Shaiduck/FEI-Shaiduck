using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Reflection.Emit;
//CREADO POR @SHAIDUCK
namespace BibliotecaProyecto
{
    public partial class Principal_Seleccion : Form
    {
        //VARIABLES PARA LA UBICACIÓN DE LOS ELEMENTOS EN LA VENTANA
        static int x = 100;
        static int x_lbl = 0;
        static int y = 3;
        int contador = 0;
        
        
        //AQUÍ VAN LOS REPOSITORIOS ENCONTRADOS SIN INICIALIZAR. NOS SERVIRÁ A LA HORA DE LLAMAR LOS MÉTODOS
        public static List<Type> repositorios = new List<Type>();
        //AQUÍ VAN LOS REPOSITORIOS YA INICIALIZADOS, PARA PODER GUARDAR LO QUE NOS PLAZCA
        public static List<Object> instancias = new List<object>();
        public static List<Type> interfaz = new List<Type>();
        // SI LE MUEVES ES BAJO TU PROPIO RIESGO

        public Principal_Seleccion()
        {
            InitializeComponent();
        }

        private void Principal_Seleccion_Load(object sender, EventArgs e)
        {
            //SE CARGA LA DLL. CREO QUE DEBE HACERSE EN TODAS. BUSCARÉ UN MÉTODO MÁS ELEGANTE DESPUÉS
            var DLL = Assembly.LoadFile(@"C:\Users\Shaiduck\Documents\visual studio 2010\Projects\BibliotecaProyecto\BibliotecaProyecto\bin\Debug\BibliotecaProyecto.dll");
            //ESTA VARIABLE NOS DICE CUÁNTAS VARIABLES TIENE LA CLASE, PARA LA GENERACIÓN DE TEXTOS Y ETIQUETAS
            int largo = 0;
            foreach (Type type in DLL.GetExportedTypes())
            {
                //ESTE ME HARÁ SABER EN QUÉ ESPACIO DE NOMBRES SE ENCUENTRA LA CLASE. LAS CLASES NUEVAS SIEMPRE DEBERÁN ESTAR EN LA RAÍZ
                string[] palabras = type.ToString().Split('.');
                //ESTE ME AYUDARÁ PARA SABER SI LO QUE SE ESTÁ ANALIZANDO ACTUALMENTE ES UN REPOSITORIO
                string[] repo = palabras.Last().Split('_');
                interfaz.Add(type);
                
                //ESTAS CONDICIONES SÓLO FUNCIONAN SI SE MANTIENE LA FORMA DE NOMBRAR LAS CLASES QUE HE ESTADO UTILIZANDO.

                //SE ENCUENTRA REPOSITORIO. SE GUARDA REPOSITORIO. TODAVÍA NO SE INICIALIZA.
                if (palabras.Length > 2 && repo.First() == "Repositorio")
                {
                    repositorios.Add(type);
                }
                //SE ENCUENTRA CLASE. SE CREA BOTÓN PARA LA CREACIÓN DE VENTANA PERSONALIZADA POR CLASE.
                else if (palabras.Length <= 2)
                {
                    //SE CREA UN BOTÓN POR CADA CLASE QUE SE ENCUENTRA
                    Button btn = new Button();
                    Point ubica = new Point(x, 20 * y);
                    btn.Location = ubica;
                    btn.Text = palabras.Last();
                    btn.Size = new Size(100, 20);
                    
                    //SE LE ANEXA EL EVENTO DE CREAR LA CLASE. AUNQUE SE USA EL MISMO PARA TODOS, DIFIERE EN FUNCIONAMIENTO
                    btn.Click += new EventHandler(crearVentana_Clase);
                    this.Controls.Add(btn);
                    x = x + 150;
                    largo++;
                }
            }
            //MAGIA NEGRA PARA CALCULAR LAS PROPORCIONES. NO LE MUEVAS. O SÍ. AHÍ TÚ VE.
            this.Size = new Size(((largo *100)+200) + (50 * (largo - 1)), 140);
            
            //SE ENCUENTRAN REPOSITORIOS. SE INICIALIZAN REPOSITORIOS. SE GUARDAN LOS REPOSITORIOS EN LA LISTA.
            foreach (Type type in repositorios)
            {
                Object o = Activator.CreateInstance(type);
                instancias.Add(o);
            }
            this.Text = "Constructor de Clases";
        }

        //MÉTODO PARA LA CREACIÓN DE VENTANA SEGÚN LA CLASE
        private void crearVentana_Clase(object sender, EventArgs e)
        {
            //ESTO ES MAGIA NEGRA Y PERMITE PONER EL TÍTULO DE LA VENTANA PERSONALIZADO. NO LE MUEVAS.
            var nombre = sender as Button;
            Ventana x = new Ventana(nombre.Text);
            x.StartPosition = FormStartPosition.CenterScreen;
            //NO SABÍA QUE CUANDO YA ESTÁ CORRIENDO UNA VENTANA, LAS QUE LE SIGAN DEBEN APARECER CON UN SHOWDIALOG
            //TIL
            x.ShowDialog();

            //EL RESTO CONTINUA EN LA CLASE VENTANA
            
        }
    }
}
