using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Examen1pro3.Clsempleado;
using static Examen1pro3.Clsmenu;

namespace Examen1pro3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            menu menu = new menu(10);
            menu.MostrarMenu();
        }

    }
}
