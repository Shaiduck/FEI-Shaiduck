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
    public partial class Ventana : Form
    {
        //EL ESPACIO DE NOMBRE QUE SE UTILIZA. ES MÁGICO Y NOS AYUDA EN LA IDENTIFICACIÓN DE MUCHAS COSAS. AUNQUE NO RECUERDO CUÁLES
        public string nombre_espacio;
        //NO RECUERDO SI ESTO HACÍA ALGO. PENSÉ MUCHAS LOCURAS PARA HACER ESTO FUNCIONAR
        //static List<Object> instanciasClases = new List<object>();
        static List<Type> tiposClases = new List<Type>();

        //ESTO ES ALGO LOCO. EL STRING QUE LE MANDO ES PARA QUE SEPA EL ESPACIO DE NOMBRE CON EL CUAL FUE INVOCADO
        //NO SÉ CÓMO SE ME OCURREN ESTAS COSAS
        //YA QUE ME PASEN CON 10
        public Ventana(String x)
        {
            this.nombre_espacio = x;
            InitializeComponent();
        }

        private void Ventana_Load(object sender, EventArgs e)
        {
            //VARIABLES PARA LA LOCALIZACIÓN DE LOS COMPONENTES. MUÉVELE SI QUIERES. PERO NO.
            int x = 200;
            int x_lbl = 100;
            int y = 1;
            int elementos = 1;

            //SE VUELVE A CARGAR LA LIBRERÍA. EN SERIO DEBE HABER UNA FORMA MÁS FÁCIL, PERO ESTOY DEMASIADO CANSADO PARA BUSCARLA
            var DLL = Assembly.LoadFile(@"C:\Users\Shaiduck\Documents\visual studio 2010\Projects\BibliotecaProyecto\BibliotecaProyecto\bin\Debug\BibliotecaProyecto.dll");
            //CREO QUE ESTE NO SE USA
            //var enviado = sender as Button;
            PropertyInfo[] myPropertyInfo;
            foreach (Type type in DLL.GetExportedTypes())
            {
                //AUNQUE CARGAMOS TOOOOODAS LAS CLASES DE LA DLL, ESTA CONDICIÓN NOS PERMITE DISCERNIR CUÁL BOTÓN FUE PRESIONADO
                //PARA ESO SE UTILIZA EL NOMBRE_ESPACIO QUE NOS ENVIAMOS PREVIAMENTE
                //Y EL NAMESPACE PROPIO DE LA BIBLIOTECA
                //ESTO ES MÁGICO
                if (type.ToString() == type.Namespace+"."+nombre_espacio)
                {
                    //SE ENCUENTRA CLASE, SE AGREGA CLASE. NO RECUERDO PARA QUÉ, PERO SEGURO ES IMPORTANTE
                    tiposClases.Add(type);
                    //LAS VARIABLES DE LA CLASE SE CONSIGUEN AQUÍ
                    myPropertyInfo = type.GetProperties();
                    for (int i = 0; i < myPropertyInfo.Length; i++)
                    {
                        //SE CREA LA ETIQUETA DE LA VARIABLE
                        System.Windows.Forms.Label nombre = new System.Windows.Forms.Label();
                        nombre.Text = myPropertyInfo[i].Name;
                        Point punto_nombre = new Point(x_lbl, 30 * y);
                        nombre.Location = punto_nombre;
                        nombre.Size = new Size(100, 20);
                        this.Controls.Add(nombre);

                        //SE CREA EL TEXTBOX DE LA VARIABL
                        TextBox tb = new TextBox();
                        Point p = new Point(x, 30 * y);
                        tb.Location = p;
                        this.Controls.Add(tb);
                        y++;
                        string[] palabras = type.ToString().Split('.');
                        //ESTO SE UTILIZA PARA DARLE TITULO A LA VENTANA. SEGURO HAY UNA FORMA MEJOR
                        this.Text = palabras.Last();
                    }
                    //BRUJERÍA PARA QUE TODO SE ACOMODE
                    x_lbl = x_lbl + 300;
                    x = x + 300;
                }
            }
            //CREACIÓN DE BOTÓN PARA AGREGAR ELEMENTO AL REPOSITORIO
            Button agregar = new Button();
            agregar.Text = "Agregar "+ this.Text;
            agregar.Size = new Size(150, 20);
            agregar.Location = new Point(x_lbl-300, 30 * y);
            agregar.Click += new EventHandler(agregar_Repositorio);
            this.Controls.Add(agregar);
            y++;
            //CREACIÓN DE BOTÓN PARA MOSTRAR LOS ELEMENTOS DEL REPOSITORIO
            Button mostrar = new Button();
            mostrar.Text = "Mostrar";
            mostrar.Size = new Size(150, 20);
            mostrar.Location = new Point(x_lbl - 300, 30 * y);
            mostrar.Click += new EventHandler(mostrar_Repositorio);
            this.Controls.Add(mostrar);
            y++;
            y = y + 2;
            //TAMAÑO DE LA VENTANA. DEPENDE DE LA CANTIDAD DE ELEMENTOS EN ELLA
            //QUÉ LOCO
            this.Size = new Size(x -100, 30*y);
        }

        //ESTA MADRE ME COSTÓ 12 HORAS DE TRABAJO
        //NO LE MUEVAS
        //NOOOOO 
        //LEEEEEE
        //MUEEEEEEEEEEVAS
        //ALSO, SOY UN ESTÚPIDO PORQUE EL ERROR ERA BÁSICO COMO EL CARAJO
        private void agregar_Repositorio(object sender, EventArgs e)
        {
            //SE CREA LA LISTA DONDE SE GUARDARÁN LOS ARGUMENTOS PARA LA CREACIÓN DE LA CLASE
            List<Object> listaArgumentos = new List<object>();
            //EL BOTÓN QUE SE ENVIÓ TIENE POR NOMBRE "AGREGAR + CLASE"
            Button boton = sender as Button;
            //AQUÍ SE DIVIDE EL NOMBRE DEL BOTÓN. ES COSA DE LOCOS
            //SI PUEDES HACERLO MEJOR, AVÍSAME CÓMO. ME SABE MAL HACERLO ASÍ
            string[] seleccion = boton.Text.Split(' ');
            
            foreach (Control c in this.Controls)
            {
                //SE EXAMINAN TODAS LAS CAJAS DE TEXTO DE LA VENTANA
                if (c is TextBox)
                {
                    Object objeto = c.Text;
                    //SE AGREGA EL CONTENIDO DE LAS CAJAS DE TEXTO EN LA LISTA DE ARGUMENTOS
                    listaArgumentos.Add(objeto);
                }
            }
            //LA LISTA SE CONVIERTE EN ARREGLO, PORQUE SÓLO ACEPTAN ESO LOS MÉTODOS. QUÉ LOCO.
            Object[] argumentos = listaArgumentos.ToArray();
            int cuenta = 0;
            //BUSCAMOS LA CLASE QUE CORRESPONDE A LO QUE QUEREMOS CREAR. DEBE HABER UNA FORMA MÁS ELEGANTE
            foreach (Type t in tiposClases)
            {
                if (t.Name == seleccion.Last())
                {

                }
                else
                {
                    //ESTE CONTADOR NOS MARCA EL LUGAR DE LA LISTA DONDE SE UBICA LA CLASE QUE QUEREMOS
                    cuenta++;
                }
            }

            //ESTA PARTE ES MUUUUUUUUUUUY IMPORTANTE
            //SE CREA UNA INSTANCIA DE LA CLASE A UTILIZAR Y SE LE PASAN LOS ARGUMENTOS QUE TIENE LA VENTANA
            //NO MOVER
            Object o = Activator.CreateInstance(tiposClases.ElementAt(cuenta), argumentos);

            //SE BUSCA EL REPOSITORIO PERTENECIENTE A LA INSTANCIA QUE ACABAMOS DE CREAR EN LOS REPOSITORIOS DE LA LISTA EN
            //PRINCIPAL_SELECCIÓN
            //SIENTO QUE ES HACER TRAMPA, PERO NO SÉ
            for (int i = 0; i < Principal_Seleccion.repositorios.Count; i++)
            {
                //LA ESTRUCTURA DE NOMBRE DEL REPOSITORIO SIEMPRE ES "REPOSITORIO + _ + CLASE"
                //AQUÍ NOS APROVECHAMOS DE ESO PARA ENCONTRAR EL REPOSITORIO DE NUESTRA CLASE
                //SÓLO FUNCIONA SI LAS REPOS SIGUEN EL ESQUEMA DE NOMBRES QUE AQUÍ SE UTILIZA
                string[] nombre = Principal_Seleccion.repositorios.ElementAt(i).ToString().Split('_');
                //SI SE ENCUENTRA LA REPO, SE HACE LO SIGUIENTE
                if (nombre.Last() == nombre_espacio)
                {
                    //SE CARGA LA INSTANCIA DEL REPOSITORIO A UTILIZAR. SE USA UNA INSTANCIA EN LA INVOCACIÓN DEL MÉTODO
                    Object instancia = Principal_Seleccion.instancias.ElementAt(i);
                    //SE CARGA EL REPOSITORIO SIN INSTANCIAR. DESDE ESTE SE INVOCA EL MÉTODO
                    Type repo = Principal_Seleccion.repositorios.ElementAt(i);
                    
                    //PARA INVOCAR UN MÉTODO NECESITAS:
                        //CLASE SIN INSTANCIAR (TYPE)
                        //NOMBRE DEL MÉTODO (NUESTRO ESQUEMA DE NOMBRES EXIGE QUE EL MÉTODO AGREGAR SE LLAME "ADD" SIEMPRE)
                        //BINDINGFLAGS = LOS MÉTODOS QUE SE INCLUIRÁN EN LA BÚSQUEDA
                        //BINDER = NO HE ENCONTRADO UN MÉTODO DONDE SE NECESITE ESPECIFICAR, ASÍ QUE LO DEJO EN "NULL"
                        //UNA INSTANCIA DE LA CLASE QUE ESTAMOS UTILIZANDO PARA INVOCAR EL MÉTODO
                        //LOS PARÁMETROS QUE ESTE MÉTODO NECESITA, EN CASO DE QUE ASÍ SE REQUIERA. SI NO, SE PONE "NULL"
                    repo.InvokeMember("Add", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Default, null, instancia, new Object[]{ o });
                }
            }
        }

        private void mostrar_Repositorio(object sender, EventArgs e)
        {
            for (int i = 0; i < Principal_Seleccion.repositorios.Count; i++)
            {
                string[] nombre = Principal_Seleccion.repositorios.ElementAt(i).ToString().Split('_');
                if (nombre.Last() == nombre_espacio)
                {
                    //PARA EXPLICAR ESTE CÓDIGO, VEA ALLÁ ARRIBA.
                    Object instancia = Principal_Seleccion.instancias.ElementAt(i);
                    Type repo = Principal_Seleccion.repositorios.ElementAt(i);
                    Type[] inter = Principal_Seleccion.repositorios.ElementAt(i).GetInterfaces();
                    string[] interfac = inter.First().FullName.Split('[');
                    repo.InvokeMember("MostrarTodo", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Default, null, instancia, null);
                }
            }

        }
    }
}
