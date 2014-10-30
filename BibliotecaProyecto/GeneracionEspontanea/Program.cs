using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotecaProyecto;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Drawing;
//CREADO POR @SHAIDUCK
namespace BibliotecaProyecto
{
    class Program
    {
        static void Main(string[] args)
        {

            //Cargar DLL con Reflexión
            //EN TEORÍA, ESTO DEBE JALAR CON CUALQUIER LIBRERÍA QUE LE MANDEN.
            var DLL = Assembly.LoadFile(@"C:\Users\Shaiduck\Documents\visual studio 2010\Projects\BibliotecaProyecto\BibliotecaProyecto\bin\Debug\BibliotecaProyecto.dll");


            //Explorar espacios de nombre con Reflexión
            Type[] types = DLL.GetExportedTypes();
            List<Type> myTypes = new List<Type>();

            //AQUÍ COMIENZAN LAS PRUEBAS PARA LOS MÉTODOS DE REFLEXIÓN. ANALIZAR SI SE DESEA
            //foreach (Type t in types)
            //{
            //   // if (t.Namespace == "BibliotecaProyecto")
            //    //{
            //        myTypes.Add(t);
            //    //}
            //}

            //foreach (Type t in myTypes)
            //{
            //    Console.WriteLine(t);
            //}
            //Console.ReadLine();
            
            ////Explorar las clases

            //MemberInfo[] myMemberInfo;
            //PropertyInfo[] myPropertyInfo;
            //foreach (Type type in DLL.GetExportedTypes())
            //{
            //    myMemberInfo = type.GetMembers(BindingFlags.Public | BindingFlags.Instance);
            //    myPropertyInfo = type.GetProperties();
            //    try
            //    {
            //        Console.WriteLine("La interfaz se llama " + type.GetInterfaces().First());
            //    }
            //    catch
            //    {
            //    }
            //    for (int i = 0; i < myMemberInfo.Length; i++)
            //    {
            //        Console.WriteLine("EL METODO SE LLAMA " + myMemberInfo[i].Name + " Y ES DEL TIPO " + myMemberInfo[i].MemberType);

            //    }
            //    Console.ReadLine();
            //    for (int i = 0; i < myPropertyInfo.Length; i++)
            //    {
            //        Console.WriteLine("LA PROPIEDAD SE LLAMA " + myPropertyInfo[i].Name + "Y ES DEL TIPO " + myPropertyInfo[i].PropertyType);
            //    }
            //    Console.ReadLine();
            //    Console.WriteLine("EL NAMESPACE DE LA LIBRERÍA ES " + type.Namespace);
            //    Console.ReadLine();
            //    try
            //    {
            //    var c = Activator.CreateInstance(type);
            //        type.InvokeMember("xxx", BindingFlags.InvokeMethod, null, c, new object[] { "Holii" });
            //    }
            //    catch
            //    {
            //        Console.WriteLine("Ups, El método xxx no existe en esta clase");
            //    }
            //}
            //AQUÍ TERMINAN LAS PRUEBAS DE LOS MÉTODOS DE REFLEXIÓN.

            
            //Generar ventana Principal
            Principal_Seleccion y = new Principal_Seleccion();
            y.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(y);
            //EL RESTO DE LA APLICACIÓN CONTINÚA EN PRINCIPAL_SELECCIÓN
        }
    }
}
