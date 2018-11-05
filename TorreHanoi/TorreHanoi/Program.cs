using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorreHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Utilice la tecla enter siempre!"+ "\n¿Con cuantos discos desea jugar?: ");
            Hanoi empezar = new Hanoi(Convert.ToInt32(Console.ReadLine()));
            Console.ReadKey();
        }
    }
}
