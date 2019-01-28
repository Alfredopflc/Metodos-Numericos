using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN
{
    class Program
    {
        static void Main(string[] args)
        {
            DiferenciacionNum Dif = new DiferenciacionNum();

            int num = 0, tipodif = 0, tipoderivada = 0, error = 0, opc = 0;
            double Xi = 0, h = 0, XiMn3 = 0, XiMn2 = 0, XiMn1 = 0, XiMs1 = 0, XiMs2 = 0, XiMs3;

            do
            {

                Console.Write("Ingrese el exponente mas grande de la funcion: ");
                num = int.Parse(Console.ReadLine());

                double[] Valores = new double[num + 1];

                for (int i = num; i >= 0; i--)
                {
                    Console.Write("Ingrese constante del exponente {0}: ", i);
                    Valores[i] = double.Parse(Console.ReadLine());
                }

                Console.Write("\nIngrese valor de Xi: ");
                Xi = double.Parse(Console.ReadLine());

                Console.Write("\nIngrese valor de h: ");
                h = double.Parse(Console.ReadLine());

                XiMn3 = Xi - (3 * h);
                XiMn2 = Xi - (2 * h);
                XiMn1 = Xi - h;
                XiMs1 = Xi + h;
                XiMs2 = Xi + (2 * h);
                XiMs3 = Xi + (3 * h);

                Console.Write("\nSeleccione que derivada desea: \n1 = Primera derivada \n2 = Segunda Derivada \nR = ");
                tipoderivada = int.Parse(Console.ReadLine());

                Console.Write("\nSeleccione Tipo de diferenciacion: \n1 = Hacia Delante \n2 = Hacia Atras \n3 = Centrada \nR = ");
                tipodif = int.Parse(Console.ReadLine());


                // Hacia Delante
                if (tipodif == 1 && tipoderivada == 1)
                {
                    Console.Write("\nIngrese Error deseado: \n1 = O(h) \n2 = O(h^2) \nR = ");
                    error = int.Parse(Console.ReadLine());

                    if (error == 1)
                        Dif.DelantePriDer1(Valores, Xi, h, XiMs1, num);

                    else if (error == 2)
                        Dif.DelantePriDer2(Valores, Xi, h, XiMs1, XiMs2, num);

                    else
                        Console.WriteLine("ERROR ");

                }

                else if (tipodif == 1 && tipoderivada == 2)
                {
                    Console.Write("\nIngrese Error deseado: \n1 = O(h) \n2 = O(h^2) \nR =");
                    error = int.Parse(Console.ReadLine());

                    if (error == 1)
                        Dif.DelanteSegDer1(Valores, Xi, h, XiMs1, XiMs2, num);

                    else if (error == 2)
                        Dif.DelanteSegDer2(Valores, Xi, h, XiMs1, XiMs2, XiMs3, num);

                    else
                        Console.WriteLine("ERROR ");
                }

                //HaciaAtras
                else if (tipodif == 2 && tipoderivada == 1)
                {
                    Console.Write("\nIngrese Error deseado: \n1 = O(h) \n2 = O(h^2) \nR =");
                    error = int.Parse(Console.ReadLine());

                    if (error == 1)
                        Dif.AtrasPriDer1(Valores, Xi, h, XiMn1, num);

                    else if (error == 2)
                        Dif.AtrasPriDer2(Valores, Xi, h, XiMn1, XiMn2, num);

                    else
                        Console.WriteLine("ERROR ");

                }

                else if (tipodif == 2 && tipoderivada == 2)
                {
                    Console.Write("\nIngrese Error deseado: \n1 = O(h) \n2 = O(h^2) \nR =");
                    error = int.Parse(Console.ReadLine());

                    if (error == 1)
                        Dif.AtrasSegDer1(Valores, Xi, h, XiMn1, XiMn2, num);

                    else if (error == 2)
                        Dif.AtrasSegDer2(Valores, Xi, h, XiMn1, XiMn2, XiMn3, num);

                    else
                        Console.WriteLine("ERROR ");
                }

                //Centrada
                else if (tipodif == 3 && tipoderivada == 1)
                {
                    Console.Write("\nIngrese Error deseado: \n1 = O(h^2) \n2 = O(h^4) \nR =");
                    error = int.Parse(Console.ReadLine());

                    if (error == 1)
                        Dif.CentradaPriDer1(Valores, h, XiMs1, XiMn1, num);

                    else if (error == 2)
                        Dif.CentradaPriDer2(Valores, h, XiMs2, XiMs1, XiMn1, XiMn2, num);

                    else
                        Console.WriteLine("ERROR ");

                }

                else if (tipodif == 3 && tipoderivada == 2)
                {
                    Console.Write("\nIngrese Error deseado: \n1 = O(h^2) \n2 = O(h^4) \nR =");
                    error = int.Parse(Console.ReadLine());

                    if (error == 1)
                        Dif.CentradaSegDer1(Valores, h, XiMs1, Xi, XiMn1, num);

                    else if (error == 2)
                        Dif.CentradaSegDer2(Valores, h, XiMs2, XiMs1, Xi, XiMn1, XiMn2, num);

                    else
                        Console.WriteLine("ERROR ");
                }

                else
                    Console.WriteLine("ERROR ");

                Console.WriteLine("\nDesea volver a iniciar el programa? \n1 = Si \n2 = No");
                opc = int.Parse(Console.ReadLine());

            } while (opc == 1);

            Console.ReadKey();
        }
    }
}
