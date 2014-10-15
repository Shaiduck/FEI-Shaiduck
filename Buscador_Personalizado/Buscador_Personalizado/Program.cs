using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Net;

namespace Buscador_Personalizado
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Model.EstudiantesEntities db = new Model.EstudiantesEntities();
            //foreach (Model.Tbl_Estudiantes t in db.Tbl_Estudiantes)
            //{
            //    Console.WriteLine(t.Nombre);
            //    Console.WriteLine(t.ApellidoPaterno);
            //}

            ////var q = from e in db.Tbl_Estudiantes where e.Nombre.StartsWith("L") select e;
            ////Model.Tbl_Estudiantes tbl = new Model.Tbl_Estudiantes();
            ////tbl.Nombre = "Pablo";
            ////tbl.ApellidoPaterno = "Picapiedra";
            ////tbl.ApellidoMaterno = "S";
            ////tbl.Matricula = "S1245";

            ////db.AddToTbl_Estudiantes(tbl);
            ////db.SaveChanges();

            //var q = (from e in db.Tbl_Estudiantes
            //         where e.Nombre.StartsWith("C")
            //         select e);

            //foreach (Model.Tbl_Estudiantes e in q)
            //{
            //    Console.WriteLine(e.Nombre);
            //}


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
