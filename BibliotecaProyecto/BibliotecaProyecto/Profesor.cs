using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotecaProyecto.Interfaces;
//CREADO POR @SHAIDUCK
namespace BibliotecaProyecto
{
    public class Profesor : Persona
    {
        public string escuela { get; set; }
        public string materia { get; set; }
        public string numeros { get; set; }

        public Profesor()
        {
        }

        public Profesor(string escuela, string materia, string numeros, string nombre, string edad, string sexo)
            : base(nombre, edad, sexo)
        {
            this.escuela = escuela;
            this.materia = materia;
            this.numeros = numeros;
        }

        public void xxx(string s)
        {
            Console.WriteLine("Yo soy un profesor " + s);
        }
    }

}
