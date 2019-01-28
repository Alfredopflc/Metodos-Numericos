using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauss_Seidel
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Matriz M = new Matriz();
                int op = 0;

                Console.Write("Ingrese tamaño de la matriz: \n1 = 2x2 \n2 = 3x3 \nR = ");
                op = int.Parse(Console.ReadLine());

                if (op == 1)
                    M.Matriz2x2();

                if (op == 2)
                    M.Matriz3x3();

                else
                {
                    Console.WriteLine("ERROR");
                }
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();

        }
    }
}
