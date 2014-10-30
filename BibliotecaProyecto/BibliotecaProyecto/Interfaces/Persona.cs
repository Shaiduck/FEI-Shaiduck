using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//CREADO POR @SHAIDUCK
namespace BibliotecaProyecto.Interfaces
{
    public class Persona
    {
        public string nombre { get; set; }
        public string edad { get; set; }
        public string sexo { get; set; }

        public Persona()
        {
        }

        public Persona(string nombre, string edad, string sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = sexo;
        }

        public void xxx(string s)
        {
            Console.WriteLine("Soy una persona "+s);
        }
    }
}
