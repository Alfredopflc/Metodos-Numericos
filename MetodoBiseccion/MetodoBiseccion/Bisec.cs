using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodoBiseccion
{
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
            int cont = 1, cont2 = 1, iteraciones = 1;
            string signo = "";
            double ea = 0, fxi = 0.000, fxu = 0.000, fxr = 0.000, xiTemp = 0, xrTemp = 0, xuTemp = 0, capturaSigno = 0, remanenteXr = 0;

            double[] Valores = pedirValores();
            double[] xi = new double[30];
            double[] xu = new double[30];
            double[] xr = new double[30];

            Console.Write("\nIngrese valor de Xi: ");
            xi[0] = double.Parse(Console.ReadLine());

            Console.Write("\nIngrese valor de Xu: ");
            xu[0] = double.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Iteración| xi    | xu    | f(xi)    | f(xu)   | xr   | f(xr)   | Ea   | Signo"); //Linea de base

            do
            {
                remanenteXr = xr[0];

                xr[0] = (xi[0] + xu[0]) / 2;

                xrTemp = xr[0];
                xiTemp = xi[0];
                xuTemp = xu[0];

                Console.Write(Convert.ToString(iteraciones) + "        | " + Convert.ToString(String.Format("{0:0.0000}", xi[0])) +
                    "| " + Convert.ToString(String.Format("{0:0.0000}", xu[0])) + "| ");  //0.0000 es para formato de fix 4

                while (cont <= exp)
                {
                    xi[cont] = xi[0];
                    xu[cont] = xu[0];
                    xr[cont] = xr[0];

                    while (cont2 < ((exp - cont) + 1))
                    {
                        xi[cont] = xi[cont] * xiTemp;
                        xu[cont] = xu[cont] * xuTemp;
                        xr[cont] = xr[cont] * xrTemp;

                        cont2++;
                    }
                    cont2 = 1;
                    cont++;
                }

                cont = 1;
                cont2 = 1;

                switch (exp)
                {
                    case 1:
                        fxi = (xi[0] * Valores[0]) + Valores[1];
                        fxu = (xu[0] * Valores[0]) + Valores[1];
                        fxr = (xr[0] * Valores[0]) + Valores[1];
                        break;
                    case 2:
                        fxi = (xi[1] * Valores[0]) + (xi[2] * Valores[1]) + Valores[2];
                        fxu = (xu[1] * Valores[0]) + (xu[2] * Valores[1]) + Valores[2];
                        fxr = (xr[1] * Valores[0]) + (xr[2] * Valores[1]) + Valores[2];
                        break;
                    case 3:
                        fxi = (xi[1] * Valores[0]) + (xi[2] * Valores[1]) + (xi[3] * Valores[1]) + Valores[3];
                        fxu = (xu[1] * Valores[0]) + (xu[2] * Valores[1]) + (xu[3] * Valores[1]) + Valores[3];
                        fxr = (xr[1] * Valores[0]) + (xr[2] * Valores[1]) + (xr[3] * Valores[1]) + Valores[3];
                        break;
                }

                Console.Write(Convert.ToString(String.Format("{0:0.0000}", fxi)) + "| " + Convert.ToString(String.Format("{0:0.0000}", fxu)) +
                    "| " + Convert.ToString(String.Format("{0:0.0000}", xr[0])) + "| " + Convert.ToString(String.Format("{0:0.0000}", fxr)) + "| ");

                capturaSigno = fxi * fxr;

                if (capturaSigno > 0)
                    signo = "+";

                else if (capturaSigno < 0)
                    signo = "-";

                else
                    signo = "";

                if (signo == "+")
                    xi[0] = xr[0];

                else if (signo == "-")
                    xu[0] = xr[0];

                if (iteraciones == 1)
                    ea = 100;

                else
                {
                    ea = (((xr[0] - remanenteXr) / xr[0]) * (100)); //Calcular error

                    if (ea < 0)
                        ea = ea * -1;
                }

                Console.Write(Convert.ToString(String.Format("{0:0.0000}", ea)) + "| " + signo + " \n\n");
                iteraciones++;

            } while (ea > error);

            Console.WriteLine("\n\n La raíz aproximada es: {0} con un error de: {1}", String.Format("{0:0.0000}", xr[0]), String.Format("{0:0.0000}", ea));
        }

        public void metodoIteraciones()
        {
            int cont = 1, cont2 = 1, iteraciones = 1;
            double fxi = 0.000, fxu = 0.000, fxr = 0.000, xiTemp = 0, xrTemp = 0, xuTemp = 0, capturaSigno = 0, remanenteXr = 0, ea = 0;
            string signo = "";

            double[] Valores = pedirValores();
            double[] xi = new double[30];
            double[] xu = new double[30];
            double[] xr = new double[30];

            Console.Write("\nIngrese valor de Xi: ");
            xi[0] = double.Parse(Console.ReadLine());

            Console.Write("\nIngrese valor de Xu: ");
            xu[0] = double.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Iteración| xi    | xu    | f(xi)    | f(xu)   | xr   | f(xr)   | Ea   | Signo"); //Base

            do
            {
                remanenteXr = xr[0];

                xr[0] = (xi[0] + xu[0]) / 2;

                xrTemp = xr[0];
                xiTemp = xi[0];
                xuTemp = xu[0];

                Console.Write(Convert.ToString(iteraciones) + "        | " + Convert.ToString(String.Format("{0:0.0000}", xi[0])) +
                    "| " + Convert.ToString(String.Format("{0:0.0000}", xu[0])) + "| ");

                while (cont <= exp)
                {
                    xi[cont] = xi[0];
                    xu[cont] = xu[0];
                    xr[cont] = xr[0];

                    while (cont2 < ((exp - cont) + 1))
                    {
                        xi[cont] = xi[cont] * xiTemp;
                        xu[cont] = xu[cont] * xuTemp;
                        xr[cont] = xr[cont] * xrTemp;

                        cont2++;
                    }
                    cont2 = 1;
                    cont++;
                }

                cont = 1;
                cont2 = 1;

                switch (exp)
                {
                    case 1:
                        fxi = (xi[0] * Valores[0]) + Valores[1];
                        fxu = (xu[0] * Valores[0]) + Valores[1];
                        fxr = (xr[0] * Valores[0]) + Valores[1];
                        break;
                    case 2:
                        fxi = (xi[1] * Valores[0]) + (xi[2] * Valores[1]) + Valores[2];
                        fxu = (xu[1] * Valores[0]) + (xu[2] * Valores[1]) + Valores[2];
                        fxr = (xr[1] * Valores[0]) + (xr[2] * Valores[1]) + Valores[2];
                        break;
                    case 3:
                        fxi = (xi[1] * Valores[0]) + (xi[2] * Valores[1]) + (xi[3] * Valores[2]) + Valores[3];
                        fxu = (xu[1] * Valores[0]) + (xu[2] * Valores[1]) + (xu[3] * Valores[2]) + Valores[3];
                        fxr = (xr[1] * Valores[0]) + (xr[2] * Valores[1]) + (xr[3] * Valores[2]) + Valores[3];
                        break;
                }

                Console.Write(Convert.ToString(String.Format("{0:0.0000}", fxi)) + "| " + Convert.ToString(String.Format("{0:0.0000}", fxu)) +
                    "| " + Convert.ToString(String.Format("{0:0.0000}", xr[0])) + "| " + Convert.ToString(String.Format("{0:0.0000}", fxr)) + "| ");
                capturaSigno = fxi * fxr;

                if (capturaSigno > 0)
                    signo = "+";

                else if (capturaSigno < 0)
                    signo = "-";

                else
                    signo = "";

                if (signo == "+")
                    xi[0] = xr[0];

                else if (signo == "-")
                    xu[0] = xr[0];

                if (iteraciones == 1)
                    ea = 100;

                else
                {
                    ea = (((xr[0] - remanenteXr) / xr[0]) * (100)); //Error

                    if (ea < 0)
                        ea = ea * -1;
                }

                Console.Write(Convert.ToString(String.Format("{0:0.0000}", ea)) + "| " + signo + " \n\n");
                iteraciones++;

                if (ea == 0)
                    iteraciones = numIter;
            } while ((numIter + 1) > iteraciones);

            Console.WriteLine("\n\n La raíz aproximada es: {0} con un error de: {1}", String.Format("{0:0.0000}", xr[0]), String.Format("{0:0.0000}", ea));
        }
    }
}
