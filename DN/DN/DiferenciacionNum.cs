using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN
{
    class DiferenciacionNum
    {
        public double Sumai (double[] valor, int num, double Xi)
        {
            double sumai = 0;

            for (int i = 0; i <= num; i++)
            {
                sumai = sumai + (valor[i] * (Math.Pow(Xi, i)));
            }

            return sumai;
        }

        public void Imprimir(double[] valor, int num)
        {
            Console.WriteLine("\nFuncion: ");

            for (int j = num; j >= 0; j--)
            {
                Console.Write(" + ( {0}X^{1} )", valor[j], j);
            }
        }

        public void DelantePriDer1(double[] valor,double Xi, double h, double XiMs1, int num)
        {
            double resultado = 0;

            resultado = (Sumai(valor, num, XiMs1) - Sumai(valor, num, Xi)) / h;
            Imprimir(valor, num);
            
            Console.WriteLine("\nTu resultado es: {0:0.00000} ", resultado);
        }

        public void DelantePriDer2(double[] valor, double Xi, double h, double XiMs1, double XiMs2, int num)
        {
            double resultado = 0;

            resultado = ((-1 * Sumai(valor,num,XiMs2)) + (4 * Sumai(valor, num, XiMs1)) - (3 * Sumai(valor, num, Xi))) / (2 * h);

            Imprimir(valor, num);

            Console.WriteLine("\nTu resultado es: {0:0.00000} ", resultado);

        }

        public void DelanteSegDer1(double[] valor, double Xi, double h, double XiMs1, double XiMs2, int num)
        {
            double resultado = 0;
           
            resultado = ((Sumai(valor, num, XiMs2)) - (2 * Sumai(valor, num, XiMs1)) + (Sumai(valor, num, Xi))) / (Math.Pow(h,2));

            Imprimir(valor, num);

            Console.WriteLine("\nTu resultado es: {0:0.00000} ", resultado);
        }

        public void DelanteSegDer2(double[] valor, double Xi, double h, double XiMs1, double XiMs2, double XiMs3, int num)
        {
            double resultado = 0;           

            resultado = ((-1 * Sumai(valor, num, XiMs3)) + (4 * Sumai(valor, num, XiMs2)) - (5 * Sumai(valor, num, XiMs1)) + (2 * Sumai(valor, num, Xi))) / (Math.Pow(h, 2));

            Imprimir(valor, num);

            Console.WriteLine("\nTu resultado es: {0:0.00000} ", resultado);
        }

        public void AtrasPriDer1(double[] valor, double Xi, double h, double XiMn1, int num)
        {
            double resultado = 0;

            resultado = (Sumai(valor, num, Xi) - Sumai(valor, num, XiMn1)) / h;

            Imprimir(valor, num);

            Console.WriteLine("\nTu resultado es: {0:0.00000} ", resultado);
        }

        public void AtrasPriDer2(double[] valor, double Xi, double h, double XiMn1, double XiMn2, int num)
        {
            double resultado = 0;

            resultado = ((3 * Sumai(valor, num, Xi)) - (4 * Sumai(valor, num, XiMn1)) + Sumai(valor, num, XiMn2)) / (2 * h);

            Imprimir(valor, num);

            Console.WriteLine("\nTu resultado es: {0:0.00000} ", resultado);
        }

        public void AtrasSegDer1(double[] valor, double Xi, double h, double XiMn1, double XiMn2, int num)
        {
            double resultado = 0;    

            resultado = ((Sumai(valor, num, Xi)) - (2 * Sumai(valor, num, XiMn1)) + (Sumai(valor, num, XiMn2))) / (Math.Pow(h, 2));

            Imprimir(valor, num);

            Console.WriteLine("\nTu resultado es: {0:0.00000} ", resultado);
        }

        public void AtrasSegDer2(double[] valor, double Xi, double h, double XiMn1, double XiMn2, double XiMn3, int num)
        {
            double resultado = 0;

            resultado = ((2 * Sumai(valor, num, Xi)) - (5 * Sumai(valor, num, XiMn1)) + (4 * Sumai(valor, num, XiMn2)) - (Sumai(valor, num, XiMn3))) / Math.Pow(h, 2);

            Imprimir(valor, num);

            Console.WriteLine("\nTu resultado es: {0:0.00000} ", resultado);
        }

        public void CentradaPriDer1(double[] valor,double h, double XiMs1, double XiMn1, int num)
        {
            double resultado = 0;

            resultado = ((Sumai(valor, num, XiMs1) - Sumai(valor, num, XiMn1))) / (2 * h);

            Imprimir(valor, num);

            Console.WriteLine("\nTu resultado es: {0:0.00000} ", resultado);
        }

        public void CentradaPriDer2(double[] valor, double h,double XiMs2, double XiMs1, double XiMn1, double XiMn2, int num)
        {
            double resultado = 0;

            resultado = ((-1 * Sumai(valor, num, XiMs2)) + (8 * Sumai(valor, num, XiMs1)) - (8 * Sumai(valor, num, XiMn1)) + (Sumai(valor, num, XiMn2))) / (12 * h);

            Imprimir(valor, num);

            Console.WriteLine("\nTu resultado es: {0:0.00000} ", resultado);
        }

        public void CentradaSegDer1(double[] valor, double h, double XiMs1, double Xi, double XiMn1, int num)
        {
            double resultado = 0;

            resultado = ((Sumai(valor, num, XiMs1)) - (2 * Sumai(valor, num, Xi)) + (Sumai(valor, num, XiMn1))) / (Math.Pow(h, 2));

            Imprimir(valor, num);

            Console.WriteLine("\nTu resultado es: {0:0.00000} ", resultado);
        }

        public void CentradaSegDer2(double[] valor, double h, double XiMs2, double XiMs1, double Xi, double XiMn1, double XiMn2, int num)
        {
            double resultado = 0;

            resultado = ((-1 * Sumai(valor, num, XiMs2)) + (16 * Sumai(valor, num, XiMs1)) - (30 * Sumai(valor, num, Xi)) + (16 * Sumai(valor, num, XiMn1)) - (Sumai(valor, num, XiMn2))) / (12 * Math.Pow(h, 2));

            Imprimir(valor, num);

            Console.WriteLine("\nTu resultado es: {0:0.00000} ", resultado);
        }


    }
}
