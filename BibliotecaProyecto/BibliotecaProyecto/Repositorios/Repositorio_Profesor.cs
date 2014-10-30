using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//CREADO POR @SHAIDUCK
namespace BibliotecaProyecto.Repositorios
{
    public class Repositorio_Profesor : Interfaz_Repositorios<Profesor>
    {
        public static List<Profesor> profesores = new List<Profesor>();

        public int Prueba()
        {
            return 0;
        }

        public bool Add(Profesor e)
        {
            bool result = true;
            try
            {
                profesores.Add(e);
                Console.WriteLine("Se agregó el profesor " + e.nombre);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool Delete(Profesor e)
        {
            bool result = true;
            try
            {
                profesores.Remove(e);
                Console.WriteLine("Se eliminó al profesor "+e.nombre);
            }
            catch
            {
                Console.WriteLine("El profesor no se encuentra en la lista y no se ha podido eliminar");
                result = false;
            }
            return result;
        }

        public void MostrarTodo()
        {
            int contador = 0;
            foreach (Profesor x in profesores)
            {
                //string escuela, string materia, string numeros, string nombre, string edad, string sexo
                Console.WriteLine("Profesor # " + contador);
                Console.WriteLine("Nombre: " + x.nombre);
                Console.WriteLine("Edad: " + x.edad);
                Console.WriteLine("Sexo: " + x.sexo);
                Console.WriteLine("Escuela: " + x.escuela);
                Console.WriteLine("Materia: " + x.materia);
                Console.WriteLine("Numeros: " + x.numeros);
                contador++;
            }
        }

        public List<Profesor> GetAll()
        {
            return profesores;
        }
    }
}
