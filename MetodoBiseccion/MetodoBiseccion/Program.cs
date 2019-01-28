using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodoBiseccion
{
    class Program
    {
        static void Main(string[] args)
        {
            int op = 0;
            do
            {
                try
                {
                    Console.Clear();
                    int exp = 0, opc = 0, iter = 0;
                    double error = 0;

                    Console.Write("\n1= Ecuación lineal \n2= Ecuación de segundo grado \n3= Ecuación de tercer grado \nIngrese el valor del exponente maximo de la funcion: ");
                    exp = int.Parse(Console.ReadLine());

                    Console.Write("\nPor que forma deseas detener el proceso? \n1= Por Error \n2= Por iteraciones \nR= ");
                    opc = int.Parse(Console.ReadLine());

                    if (opc == 1)
                    {
                        Console.Write("\nIngrese porcentaje de Error: ");
                        error = double.Parse(Console.ReadLine());

                        Bisec C = new Bisec(exp, error);
                        C.Metodo();
                    }
                    else
                    {
                        Console.Write("\nIngrese numero de Iteraciones: ");
                        iter = int.Parse(Console.ReadLine());

                        Bisec C = new Bisec(exp, iter);
                        C.metodoIteraciones();
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.Write("\nDesea iniciar de nuevo? \n1= Si \n2= No \nR= ");
                op = int.Parse(Console.ReadLine());
            } while (op == 1);

            Console.ReadKey();
        }
    }
}
