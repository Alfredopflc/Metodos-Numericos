using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauss_Seidel
{
    class Matriz
    {
        public void Matriz2x2()
        {
            double X1 = 0, X2 = 0;
            int opc = 0;

            do
            {
                int iteraciones = 0;
                double valorerror = 0;
                bool error = true;
                bool ciclo = false;
                double[,] valores;
                valores = new double[2, 3];
                double[] arreglo1 = new double[3];
                double[] arreglo2 = new double[3];

                do
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Console.Clear();                        

                        Console.WriteLine("Ecuacion {0} \n Formato: \n aX1 + bX2 = c ", (i+1));

                        if (i == 0)
                        {
                            Console.Write("\nIngrese valor de a: ");
                            arreglo1[0] = double.Parse(Console.ReadLine());

                            Console.Write("\nIngrese valor de b: ");
                            arreglo1[1] = double.Parse(Console.ReadLine());

                            Console.Write("\nIngrese valor de igualdad (valor de c) : ");
                            arreglo1[2] = double.Parse(Console.ReadLine()); 
                        }

                        if (i == 1)
                        {
                            Console.Write("\nIngrese valor de a: ");
                            arreglo2[0] = double.Parse(Console.ReadLine());

                            Console.Write("\nIngrese valor de b: ");
                            arreglo2[1] = double.Parse(Console.ReadLine());

                            Console.Write("\nIngrese valor de igualdad (valor de c) : ");
                            arreglo2[2] = double.Parse(Console.ReadLine());
                        }                                             
                    }

                    if (arreglo1[0] > arreglo1[1])
                    {
                        valores[0, 0] = arreglo1[0];
                        valores[0, 1] = arreglo1[1];
                        valores[0, 2] = arreglo1[2];
                    }

                    if (arreglo1[0] < arreglo1[1])
                    {
                        valores[1, 0] = arreglo1[0];
                        valores[1, 1] = arreglo1[1];
                        valores[1, 2] = arreglo1[2];
                    }

                    if (arreglo2[0] > arreglo2[1])
                    {
                        valores[0, 0] = arreglo2[0];
                        valores[0, 1] = arreglo2[1];
                        valores[0, 2] = arreglo2[2];
                    }

                    if (arreglo2[0] < arreglo2[1])
                    {
                        valores[1, 0] = arreglo2[0];
                        valores[1, 1] = arreglo2[1];
                        valores[1, 2] = arreglo2[2];
                    }

                    if ((valores[0, 0] == 0 && valores[0, 1] == 0) || (valores[1, 0] == 0 && valores[1, 1] == 0))
                    {
                        Console.WriteLine("ECUACIONES NO VALIDAS");
                        Console.ReadKey();
                        error = false;
                    }

                } while (error == false);

                Console.Clear();

                Console.Write("Ingrese valor inicial de X1: ");
                X1 = double.Parse(Console.ReadLine());
                Console.Write("Ingrese valor inicial de X2: ");
                X2 = double.Parse(Console.ReadLine());

                int eleccion = 0;

                Console.Write("\nDesea detener el proceso por Iteraciones o Error aproximado? \n1 = Iteraciones \n2 = Error \nR = ");
                eleccion = int.Parse(Console.ReadLine());

                if (eleccion == 1)
                {
                    Console.Clear();
                    Console.Write("\nIngrese Numero de Iteraciones: ");
                    iteraciones = int.Parse(Console.ReadLine());

                    Console.Clear();

                    Console.WriteLine("\nECUACIONES: ");

                    for (int i = 0; i < 2; i++)
                    {

                        Console.WriteLine("{0}X1 {1}X2 = {2} ", valores[i, 0], valores[i, 1], valores[i,2]);

                    }

                    Console.WriteLine();

                    int iter = 0;

                    Console.WriteLine("  Iteracion  ||    X1     ||    X2    ||    EX1    ||    EX2     ||");

                    do
                    {

                        double Xr1, Xr2;

                        Xr1 = X1;
                        Xr2 = X2;
                        

                        X1 = ((valores[0, 2] + (-1 * valores[0, 1] * X2)) / valores[0, 0]);

                        X2 = ((valores[1, 2] + (-1 * valores[1, 0] * X1)) / valores[1, 1]);


                        double EX1 = 0, EX2 = 0;

                        if (Xr1 == 0)
                            EX1 = 100;

                        else
                        {
                            EX1 = ((X1 - Xr1) / X1) * 100;

                            if (EX1 < 0)
                                EX1 = EX1 * -1;
                        }

                        if (Xr2 == 0)
                            EX2 = 100;

                        else
                        {
                            EX2 = ((X2 - Xr2) / X2) * 100;

                            if (EX2 < 0)
                                EX2 = EX2 * -1;
                        }

                        

                        Console.WriteLine("    " + (iter + 1) + "        ||  {0:0.0000}  ||  {1:0.0000}  ||  {2:0.0000}  ||  {3:0.0000}  ||", X1, X2, EX1, EX2);


                        iter++;

                        if (iter == iteraciones)
                        {
                            double comp = 0;
                            Console.WriteLine("\nEl valor de X1 = {0:0.0000} con un Error de: {1:0.0000} \nEl valor de X2 = {2:0.0000} con un Error de: {3:0.0000}", X1, EX1, X2, EX2);
                            Console.WriteLine("\n\nCOMPROBACION:");

                            for (int i = 0; i < 2; i++)
                            {
                                comp = ((valores[i, 0] * X1) + (valores[i, 1] * X2));
                                Console.WriteLine("{0}({1:0.0000}) {2}({3:0.000}) = {4:0.0000} ", valores[i, 0], X1, valores[i, 1], X2, comp);
                            }
                        }

                    } while (iter < iteraciones);

                }

                if (eleccion == 2)
                {
                    Console.Write("Ingrese Error: ");
                    valorerror = double.Parse(Console.ReadLine());

                    Console.Clear();

                    Console.WriteLine("\nECUACIONES: ");

                    for (int i = 0; i < 2; i++)
                    {

                        Console.WriteLine("{0}X1 {1}X2 = {2} ", valores[i, 0], valores[i, 1], valores[i, 2]);

                    }

                    Console.WriteLine();

                    int iter = 0;

                    Console.WriteLine("  Iteracion  ||    X1     ||    X2    ||    EX1    ||    EX2     ||");

                    do
                    {

                        double Xr1, Xr2;

                        Xr1 = X1;
                        Xr2 = X2;



                        X1 = ((valores[0, 2] + (-1 * valores[0, 1] * X2)) / valores[0, 0]);

                        X2 = ((valores[1, 2] + (-1 * valores[1, 0] * X1)) / valores[1, 1]);


                        double EX1 = 0, EX2 = 0;

                        if (Xr1 == 0)
                            EX1 = 100;

                        else
                        {
                            EX1 = ((X1 - Xr1) / X1) * 100;

                            if (EX1 < 0)
                                EX1 = EX1 * -1;
                        }

                        if (Xr2 == 0)
                            EX2 = 100;

                        else
                        {
                            EX2 = ((X2 - Xr2) / X2) * 100;

                            if (EX2 < 0)
                                EX2 = EX2 * -1;
                        }



                        Console.WriteLine("    " + (iter + 1) + "        ||  {0:0.0000}  ||  {1:0.0000}  ||  {2:0.0000}  ||  {3:0.0000}  ||", X1, X2, EX1, EX2);


                        iter++;


                        if (EX1 <= valorerror && EX2 <= valorerror)
                        {
                            double comp = 0;
                            Console.WriteLine("\nEl valor de X1 = {0:0.0000} con un Error de: {1:0.0000} \nEl valor de X2 = {2:0.0000} con un Error de: {3:0.0000}", X1, EX1, X2, EX2);
                            Console.WriteLine("\n\nCOMPROBACION:");

                            for (int i = 0; i < 2; i++)
                            {
                                comp = ((valores[i, 0] * X1) + (valores[i, 1] * X2));
                                Console.WriteLine("{0}({1:0.0000}) {2}({3:0.000}) = {4:0.0000} ", valores[i, 0], X1, valores[i, 1], X2, comp);
                            }

                            ciclo = true;
                        }

                    } while (ciclo == false);
                }

                else
                {
                    Console.WriteLine("ERROR ");
                }

                Console.Write("\nDesea volver a empezar? \n1 = Si \n2 = No \nR= ");
                opc = int.Parse(Console.ReadLine());

            } while (opc == 1);
        }

        public void Matriz3x3()
        {
            double X1 = 0, X2 = 0, X3 = 0;
            int opc = 0;

            do
            {
                int iteraciones = 0;
                double valorerror = 0;
                bool error = true;
                bool ciclo = false;
                double[,] valores;
                valores = new double[3, 4];
                double[] arreglo1 = new double[4];
                double[] arreglo2 = new double[4];
                double[] arreglo3 = new double[4];

                do
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Clear();

                        Console.WriteLine("Ecuacion {0} \n Formato: \n aX1 + bX2 + cX3 = d ", (i + 1));

                        if (i == 0)
                        {
                            Console.Write("\nIngrese valor de a: ");
                            arreglo1[0] = double.Parse(Console.ReadLine());

                            Console.Write("\nIngrese valor de b: ");
                            arreglo1[1] = double.Parse(Console.ReadLine());

                            Console.Write("\nIngrese valor de c: ");
                            arreglo1[2] = double.Parse(Console.ReadLine());

                            Console.Write("\nIngrese valor de igualdad (valor de d) : ");
                            arreglo1[3] = double.Parse(Console.ReadLine());
                        }

                        if (i == 1)
                        {
                            Console.Write("\nIngrese valor de a: ");
                            arreglo2[0] = double.Parse(Console.ReadLine());

                            Console.Write("\nIngrese valor de b: ");
                            arreglo2[1] = double.Parse(Console.ReadLine());

                            Console.Write("\nIngrese valor de c: ");
                            arreglo2[2] = double.Parse(Console.ReadLine());

                            Console.Write("\nIngrese valor de igualdad (valor de d) : ");
                            arreglo2[3] = double.Parse(Console.ReadLine());
                        }

                        if (i == 2)
                        {
                            Console.Write("\nIngrese valor de a: ");
                            arreglo3[0] = double.Parse(Console.ReadLine());

                            Console.Write("\nIngrese valor de b: ");
                            arreglo3[1] = double.Parse(Console.ReadLine());

                            Console.Write("\nIngrese valor de c: ");
                            arreglo3[2] = double.Parse(Console.ReadLine());

                            Console.Write("\nIngrese valor de igualdad (valor de d) : ");
                            arreglo3[3] = double.Parse(Console.ReadLine());
                        }
                    }
                     // 1
                    if ((arreglo1[0] > arreglo1[1]) && (arreglo1[0] > arreglo1[2]))
                    {
                        valores[0, 0] = arreglo1[0];
                        valores[0, 1] = arreglo1[1];
                        valores[0, 2] = arreglo1[2];
                        valores[0, 3] = arreglo1[3];
                    }

                    if ((arreglo1[1] > arreglo1[0]) && (arreglo1[1] > arreglo1[2]))
                    {
                        valores[1, 0] = arreglo1[0];
                        valores[1, 1] = arreglo1[1];
                        valores[1, 2] = arreglo1[2];
                        valores[1, 3] = arreglo1[3];
                    }

                    if ((arreglo1[2] > arreglo1[0]) && (arreglo1[2] > arreglo1[1]))
                    {
                        valores[2, 0] = arreglo1[0];
                        valores[2, 1] = arreglo1[1];
                        valores[2, 2] = arreglo1[2];
                        valores[2, 3] = arreglo1[3];
                    }

                    //2

                    if ((arreglo2[0] > arreglo2[1]) && (arreglo2[0] > arreglo2[2]))
                    {
                        valores[0, 0] = arreglo2[0];
                        valores[0, 1] = arreglo2[1];
                        valores[0, 2] = arreglo2[2];
                        valores[0, 3] = arreglo2[3];
                    }

                    if ((arreglo2[1] > arreglo2[0]) && (arreglo2[1] > arreglo2[2]))
                    {
                        valores[1, 0] = arreglo2[0];
                        valores[1, 1] = arreglo2[1];
                        valores[1, 2] = arreglo2[2];
                        valores[1, 3] = arreglo2[3];
                    }

                    if ((arreglo2[2] > arreglo2[0]) && (arreglo2[2] > arreglo2[1]))
                    {
                        valores[2, 0] = arreglo2[0];
                        valores[2, 1] = arreglo2[1];
                        valores[2, 2] = arreglo2[2];
                        valores[2, 3] = arreglo2[3];
                    }

                    //3
                    if ((arreglo3[0] > arreglo3[1]) && (arreglo3[0] > arreglo3[2]))
                    {
                        valores[0, 0] = arreglo3[0];
                        valores[0, 1] = arreglo3[1];
                        valores[0, 2] = arreglo3[2];
                        valores[0, 3] = arreglo3[3];
                    }

                    if ((arreglo3[1] > arreglo3[0]) && (arreglo3[1] > arreglo3[2]))
                    {
                        valores[1, 0] = arreglo3[0];
                        valores[1, 1] = arreglo3[1];
                        valores[1, 2] = arreglo3[2];
                        valores[1, 3] = arreglo3[3];
                    }

                    if ((arreglo3[2] > arreglo3[0]) && (arreglo3[2] > arreglo3[1]))
                    {
                        valores[2, 0] = arreglo3[0];
                        valores[2, 1] = arreglo3[1];
                        valores[2, 2] = arreglo3[2];
                        valores[2, 3] = arreglo3[3];
                    }

                    if ((valores[0, 0] == 0 && valores[0, 1] == 0 && valores[0,2] == 0) || (valores[1, 0] == 0 && valores[1, 1] == 0 && valores[1, 2] == 0) || (valores[2, 0] == 0 && valores[2, 1] == 0 && valores[2, 2] == 0))
                    {
                        Console.WriteLine("ECUACIONES NO VALIDAS");
                        Console.ReadKey();
                        error = false;
                    }

                } while (error == false);

                Console.Clear();

                Console.Write("Ingrese valor inicial de X1: ");
                X1 = double.Parse(Console.ReadLine());
                Console.Write("Ingrese valor inicial de X2: ");
                X2 = double.Parse(Console.ReadLine());
                Console.Write("Ingrese valor inicial de X3: ");
                X3 = double.Parse(Console.ReadLine());

                int eleccion = 0;
                Console.Write("\nDesea detener el proceso por Iteraciones o Error aproximado? \n1 = Iteraciones \n2 = Error \nR = ");
                eleccion = int.Parse(Console.ReadLine());

                if (eleccion == 1)
                {
                    Console.Clear();
                    Console.Write("\nIngrese Numero de Iteraciones: ");
                    iteraciones = int.Parse(Console.ReadLine());

                    Console.Clear();

                    Console.WriteLine("\nECUACIONES: ");

                    for (int i = 0; i < 3; i++)
                    {

                        Console.WriteLine("{0}X1 {1}X2 {2}X3 = {3} ", valores[i, 0], valores[i, 1], valores[i, 2], valores[i, 3]);

                    }

                    Console.WriteLine();

                    int iter = 0;

                    Console.WriteLine("  Iteracion  ||    X1     ||    X2    ||    X3    ||    EX1    ||    EX2     ||    EX3     ||");

                    do
                    {

                        double Xr1, Xr2, Xr3;

                        Xr1 = X1;
                        Xr2 = X2;
                        Xr3 = X3;

                        X1 = ((valores[0, 3] + (-1 * valores[0, 1] * X2) + (-1 * valores[0, 2] * X3)) / valores[0, 0]);

                        X2 = ((valores[1, 3] + (-1 * valores[1, 0] * X1) + (-1 * valores[1, 2] * X3)) / valores[1, 1]);

                        X3 = ((valores[2, 3] + (-1 * valores[2, 0] * X1) + (-1 * valores[2, 1] * X2)) / valores[2, 2]);

                        double EX1 = 0, EX2 = 0, EX3 = 0;

                        if (Xr1 == 0)
                            EX1 = 100;

                        else
                        {
                            EX1 = ((X1 - Xr1) / X1) * 100;

                            if (EX1 < 0)
                                EX1 = EX1 * -1;
                        }

                        if (Xr2 == 0)
                            EX2 = 100;

                        else
                        {
                            EX2 = ((X2 - Xr2) / X2) * 100;

                            if (EX2 < 0)
                                EX2 = EX2 * -1;
                        }

                        if (Xr3 == 0)
                            EX3 = 100;

                        else
                        {
                            EX3 = ((X3 - Xr3) / X3) * 100;

                            if (EX3 < 0)
                                EX3 = EX3 * -1;
                        }

                        Console.WriteLine("    " + (iter + 1) + "        ||  {0:0.0000}  ||  {1:0.0000}  ||  {2:0.0000}  ||  {3:0.0000}  ||  {4:0.0000}  " +
                            "||  {5:0.0000}  ||  ", X1, X2, X3, EX1, EX2, EX3);


                        iter++;

                        if (iter == iteraciones)
                        {
                            double comp = 0;
                            Console.WriteLine("\nEl valor de X1 = {0:0.0000} con un Error de: {1:0.0000} \nEl valor de X2 = {2:0.0000} con un Error de: {3:0.0000} \nEl valor de X3 = {4:0.0000} con un Error de: {5:0.0000} ", X1, EX1, X2, EX2, X3, EX3);
                            Console.WriteLine("\n\nCOMPROBACION:");

                            for (int i = 0; i < 3; i++)
                            {
                                comp = ((valores[i, 0] * X1) + (valores[i, 1] * X2) + (valores[i, 2] * X3));
                                Console.WriteLine("{0}({1:0.0000}) {2}({3:0.000}) {4}({5:0.000}) = {6:0.0000} ", valores[i, 0], X1, valores[i, 1], X2, valores[i, 2], X3, comp);
                            }
                        }

                    } while (iter < iteraciones);

                }

                

                if ( eleccion == 2)
                {
                    Console.Write("Ingrese Error: ");
                    valorerror = double.Parse(Console.ReadLine());

                    Console.Clear();

                    Console.WriteLine("\nECUACIONES: ");

                    for (int i = 0; i < 3; i++)
                    {

                        Console.WriteLine("{0}X1 {1}X2 {2}X3 = {3} ", valores[i, 0], valores[i, 1], valores[i, 2], valores[i, 3]);

                    }

                    Console.WriteLine();

                    int iter = 0;

                    Console.WriteLine("  Iteracion  ||    X1     ||    X2    ||    X3    ||    EX1    ||    EX2     ||    EX3     ||");

                    do
                    {

                        double Xr1, Xr2, Xr3;

                        Xr1 = X1;
                        Xr2 = X2;
                        Xr3 = X3;

                        X1 = ((valores[0, 3] + (-1 * valores[0, 1] * X2) + (-1 * valores[0, 2] * X3)) / valores[0, 0]);

                        X2 = ((valores[1, 3] + (-1 * valores[1, 0] * X1) + (-1 * valores[1, 2] * X3)) / valores[1, 1]);

                        X3 = ((valores[2, 3] + (-1 * valores[2, 0] * X1) + (-1 * valores[2, 1] * X2)) / valores[2, 2]);

                        double EX1 = 0, EX2 = 0, EX3 = 0;

                        if (Xr1 == 0)
                            EX1 = 100;

                        else
                        {
                            EX1 = ((X1 - Xr1) / X1) * 100;

                            if (EX1 < 0)
                                EX1 = EX1 * -1;
                        }

                        if (Xr2 == 0)
                            EX2 = 100;

                        else
                        {
                            EX2 = ((X2 - Xr2) / X2) * 100;

                            if (EX2 < 0)
                                EX2 = EX2 * -1;
                        }

                        if (Xr3 == 0)
                            EX3 = 100;

                        else
                        {
                            EX3 = ((X3 - Xr3) / X3) * 100;

                            if (EX3 < 0)
                                EX3 = EX3 * -1;
                        }

                        Console.WriteLine("    " + (iter + 1) + "        ||  {0:0.0000}  ||  {1:0.0000}  ||  {2:0.0000}  ||  {3:0.0000}  ||  {4:0.0000}  " +
                            "||  {5:0.0000}  ||  ", X1, X2, X3, EX1, EX2, EX3);

                        iter++;
                        
                        if (EX1 <= valorerror && EX2 <=valorerror && EX3 <= valorerror)
                        {
                            double comp = 0;
                            Console.WriteLine("\nEl valor de X1 = {0:0.0000} con un Error de: {1:0.0000} \nEl valor de X2 = {2:0.0000} con un Error de: {3:0.0000} \nEl valor de X3 = {4:0.0000} con un Error de: {5:0.0000} ", X1, EX1, X2, EX2, X3, EX3);
                            Console.WriteLine("\n\nCOMPROBACION:");

                            for (int i = 0; i < 3; i++)
                            {
                                comp = ((valores[i, 0] * X1) + (valores[i, 1] * X2) + (valores[i, 2] * X3));
                                Console.WriteLine("{0}({1:0.0000}) {2}({3:0.000}) {4}({5:0.000}) = {6:0.0000} ", valores[i, 0], X1, valores[i, 1], X2, valores[i, 2], X3, comp);
                            }

                            ciclo = true;
                        }

                    } while (ciclo == false);
                }

                else
                {
                    Console.WriteLine("ERROR ");
                }


                Console.Write("\nDesea volver a empezar? \n1 = Si \n2 = No \nR= ");
                opc = int.Parse(Console.ReadLine());

            } while (opc == 1);

        }

    }
}

