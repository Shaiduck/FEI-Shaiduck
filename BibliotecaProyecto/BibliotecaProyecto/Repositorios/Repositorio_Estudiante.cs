using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//CREADO POR @SHAIDUCK
namespace BibliotecaProyecto.Repositorios
{
    public class Repositorio_Estudiante : Interfaz_Repositorios<Estudiante>
    {
        public static List<Estudiante> estudiantes = new List<Estudiante>();

        public int Prueba()
        {
            return 0;
        }
        public bool Add(Estudiante e)
        {
            bool result = true;
            try
            {
                estudiantes.Add(e);
                Console.WriteLine("Se agregó el estudiante " + e.nombre);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool Delete(Estudiante e)
        {
            bool result = true;
            try
            {
                estudiantes.Remove(e);
                Console.WriteLine("Se ha eliminado al estudiante " + e.nombre);
            }
            catch
            {
                Console.WriteLine("El estudiante no se encontró en la lista y no pudo ser eliminado");
                result = false;
            }
            return result;
        }

        public void MostrarTodo()
        {
            int contador = 0;
            foreach (Estudiante x in estudiantes)
            {
                //string matricula, string materias, string promedio, string nombre, string edad, string sexo
                Console.WriteLine("Estudiante # " + contador);
                Console.WriteLine("Nombre: " + x.nombre);
                Console.WriteLine("Edad: " + x.edad);
                Console.WriteLine("Sexo: " + x.sexo);
                Console.WriteLine("Promedio: " + x.promedio);
                Console.WriteLine("Materias: " + x.materias);
                Console.WriteLine("Matricula: " + x.matricula);
                contador++;
            }
        }

        public List<Estudiante> GetAll()
        {
            return estudiantes;
        }
    }
}
