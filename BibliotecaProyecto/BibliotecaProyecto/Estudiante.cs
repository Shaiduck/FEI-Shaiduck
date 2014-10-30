using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotecaProyecto.Interfaces;
//CREADO POR @SHAIDUCK
namespace BibliotecaProyecto
{
    public class Estudiante : Persona
    {
        public string matricula { get; set; }
        public string materias { get; set; }
        public string promedio { get; set; }

        public Estudiante()
        {
        }

        public Estudiante(string matricula, string materias, string promedio, string nombre, string edad, string sexo)
            : base(nombre, edad, sexo)
        {
            this.matricula = matricula;
            this.materias = materias;
            this.promedio = promedio;
        }

        public void xxx(string s)
        {
            Console.WriteLine("Yo soy un Estudiante " + s);
        }
    }
}
