using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//CREADO POR @SHAIDUCK
namespace BibliotecaProyecto.Repositorios
{
    interface Interfaz_Repositorios<E>
    {
        int Prueba();
        bool Add(E e);
        bool Delete(E e);
        List<E> GetAll();
        void MostrarTodo();
    }
}
