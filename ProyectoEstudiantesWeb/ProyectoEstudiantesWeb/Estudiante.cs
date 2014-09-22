using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoEstudiantesWeb
{
    public class Estudiante
    {
        public String Id { get; set; }
        public String Nombre { get; set; }
        public String ApellidoMaterno { get; set; }
        public String ApellidoPaterno { get; set; }
        public String Matricula { get; set; }
        public String PromedioGeneral { get; set; }
    }
}