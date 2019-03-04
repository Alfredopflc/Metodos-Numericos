using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bisecciones
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

    class Bisec
    {
        int exp = 0, numIter = 0;
        double error = 0;

        public Bisec(int Exponente, double Error)
        {
            exp = Exponente;
            error = Error;
        }
        public Bisec(int Exponente, int NumIter)
        {
            exp = Exponente;
            numIter = NumIter;
        }

        private double[] pedirValores()
        {
            double[] Valor = new double[exp + 1];

            switch (exp)
            {
                case 1:
                    Console.WriteLine("\n f(x) = ax + b");
                    Console.Write("Ingrese valor de a: ");
                    Valor[0] = double.Parse(Console.ReadLine());

                    Console.Write("Ingrese valor de b: ");
                    Valor[1] = double.Parse(Console.ReadLine());
                    break;

                case 2:
                    Console.WriteLine("f(x) = ax² + bx + c");
                    Console.Write("Ingrese valor de a: ");
                    Valor[0] = double.Parse(Console.ReadLine());

                    Console.Write("Ingrese valor de b: ");
                    Valor[1] = double.Parse(Console.ReadLine());

                    Console.Write("Ingrese valor de c: ");
                    Valor[2] = double.Parse(Console.ReadLine());
                    break;

                case 3:
                    Console.WriteLine("f(x) = ax³ + bx² + cx + d");
                    Console.Write("Ingrese valor de a: ");
                    Valor[0] = double.Parse(Console.ReadLine());

                    Console.Write("Ingrese valor de b: ");
                    Valor[1] = double.Parse(Console.ReadLine());

                    Console.Write("Ingrese valor de c: ");
                    Valor[2] = double.Parse(Console.ReadLine());

                    Console.Write("Ingrese valor de d: ");
                    Valor[3] = double.Parse(Console.ReadLine());
                    break;
            }
            return Valor;
        }

        public void Metodo()
        {
            int  iteraciones = 1;
            string signo = "";
            double ea = 0, fxi = 0.000, fxu = 0.000, fxr = 0.000, capturaSigno = 0, remanenteXr = 0;
            double xi = 0, xu = 0, xr = 0;

            double[] Valores = pedirValores();            

            Console.Write("\nIngrese valor de Xi: ");
            xi = double.Parse(Console.ReadLine());

            Console.Write("\nIngrese valor de Xu: ");
            xu = double.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Iteración| xi    | xu    | f(xi)    | f(xu)   | xr   | f(xr)   | Ea   | Signo"); //Linea de base

            do
            {
                remanenteXr = xr;
    

                Console.Write(Convert.ToString(iteraciones) + "        | " + Convert.ToString(String.Format("{0:0.0000}", xi)) +
                    "| " + Convert.ToString(String.Format("{0:0.0000}", xu)) + "| ");  //0.0000 es para formato de fix 4
             
                switch (exp)
                {
                    case 1:
                        fxi = (xi * Valores[0] + Valores[1]);
                        fxu = (xu * Valores[0]) + Valores[1];

                        xr = xu - ((fxu * (xi - xu)) / (fxi - fxu));

                        fxr = (xr * Valores[0]) + Valores[1];
                        break;

                    case 2:
                        fxi = (Math.Pow(xi, 2) * Valores[0]) + (xi * Valores[1]) + Valores[2];
                        fxu = (Math.Pow(xu, 2) * Valores[0]) + (xu * Valores[1]) + Valores[2];

                        xr = xu - ((fxu * (xi - xu)) / (fxi - fxu));

                        fxr = (Math.Pow(xr, 2) * Valores[0]) + (xr * Valores[1]) + Valores[2];
                        break;

                    case 3:
                        fxi = (Math.Pow(xi, 3) * Valores[0]) + (Math.Pow(xi, 2) * Valores[1]) + (xi * Valores[2]) + Valores[3];
                        fxu = (Math.Pow(xu, 3) * Valores[0]) + (Math.Pow(xu, 2) * Valores[1]) + (xu * Valores[2]) + Valores[3];

                        xr = xu - ((fxu * (xi - xu)) / (fxi - fxu));

                        fxr = (Math.Pow(xr, 3) * Valores[0]) + (Math.Pow(xr, 2) * Valores[1]) + (xr * Valores[2]) + Valores[3];
                        break;
                }

                Console.Write(Convert.ToString(String.Format("{0:0.0000}", fxi)) + "| " + Convert.ToString(String.Format("{0:0.0000}", fxu)) +
                    "| " + Convert.ToString(String.Format("{0:0.0000}", xr)) + "| " + Convert.ToString(String.Format("{0:0.0000}", fxr)) + "| ");

                capturaSigno = fxi * fxr;

                if (capturaSigno > 0)
                    signo = "+";

                else if (capturaSigno < 0)
                    signo = "-";

                else
                    signo = "";

                if (signo == "+")
                    xi = xr;

                else if (signo == "-")
                    xu = xr;

                if (iteraciones == 1)
                    ea = 100;

                else
                {
                    ea = (((xi - remanenteXr) / xr) * (100)); //Calcular error

                    if (ea < 0)
                        ea = ea * -1;
                }

                Console.Write(Convert.ToString(String.Format("{0:0.0000}", ea)) + "| " + signo + " \n\n");
                iteraciones++;

            } while (ea > error);

            Console.WriteLine("\n\n La raíz aproximada es: {0} con un error de: {1}", String.Format("{0:0.0000}", xr), String.Format("{0:0.0000}", ea));
        }

        public void metodoIteraciones()
        {
            int iteraciones = 1;
            double fxi = 0.000, fxu = 0.000, fxr = 0.000, capturaSigno = 0, remanenteXr = 0, ea = 0;
            string signo = "";

            double[] Valores = pedirValores();
           
            double xi = 0, xu = 0, xr = 0;

            Console.Write("\nIngrese valor de Xi: ");
            xi = double.Parse(Console.ReadLine());

            Console.Write("\nIngrese valor de Xu: ");
            xu = double.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Iteración| xi    | xu    | f(xi)    | f(xu)   | xr   | f(xr)   | Ea   | Signo"); //Base

            do
            {
                remanenteXr = xr;

                Console.Write(Convert.ToString(iteraciones) + "        | " + Convert.ToString(String.Format("{0:0.0000}", xi)) +
                    "| " + Convert.ToString(String.Format("{0:0.0000}", xu)) + "| ");


                switch (exp)
                {
                    case 1:
                        fxi = (xi * Valores[0] + Valores[1]);
                        fxu = (xu * Valores[0]) + Valores[1];

                        xr = xu - ((fxu * (xi - xu)) / (fxi - fxu));

                        fxr = (xr * Valores[0]) + Valores[1];
                        break;

                    case 2:
                        fxi = (Math.Pow(xi,2) * Valores[0]) + (xi * Valores[1]) + Valores[2];
                        fxu = (Math.Pow(xu, 2) * Valores[0]) + (xu * Valores[1]) + Valores[2];                      

                        xr = xu - ((fxu * (xi - xu)) / (fxi - fxu));

                        fxr = (Math.Pow(xr, 2) * Valores[0]) + (xr * Valores[1]) + Valores[2];
                        break;

                    case 3:
                        fxi = (Math.Pow(xi,3) * Valores[0]) + (Math.Pow(xi, 2) * Valores[1]) + (xi * Valores[2]) + Valores[3];
                        fxu = (Math.Pow(xu,3) * Valores[0]) + (Math.Pow(xu, 2) * Valores[1]) + (xu * Valores[2]) + Valores[3];                      

                        xr = xu - ((fxu * (xi - xu)) / (fxi - fxu));

                        fxr = (Math.Pow(xr, 3) * Valores[0]) + (Math.Pow(xr, 2) * Valores[1]) + (xr * Valores[2]) + Valores[3];
                        break;
                }

                

                Console.Write(Convert.ToString(String.Format("{0:0.0000}", fxi)) + "| " + Convert.ToString(String.Format("{0:0.0000}", fxu)) +
                    "| " + Convert.ToString(String.Format("{0:0.0000}", xr)) + "| " + Convert.ToString(String.Format("{0:0.0000}", fxr)) + "| ");

                capturaSigno = fxi * fxr;

                if (capturaSigno > 0)
                    signo = "+";

                else if (capturaSigno < 0)
                    signo = "-";

                else
                    signo = "";

                if (signo == "+")
                    xi = xr;

                else if (signo == "-")
                    xu = xr;

                if (iteraciones == 1)
                    ea = 100;

                else
                {
                    ea = (((xi - remanenteXr) / xr) * (100)); //Error

                    if (ea < 0)
                        ea = ea * -1;
                }

                Console.Write(Convert.ToString(String.Format("{0:0.0000}", ea)) + "| " + signo + " \n\n");
                iteraciones++;

                if (ea == 0)
                    iteraciones = numIter;

                
            } while ((numIter + 1) > iteraciones);

            Console.WriteLine("\n\n La raíz aproximada es: {0} con un error de: {1}", String.Format("{0:0.0000}", xr), String.Format("{0:0.0000}", ea));
        }
    }
}
