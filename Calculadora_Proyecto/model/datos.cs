using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Calculadora_Proyecto.model
{
    public class datos
    {
        public bool primos(int p)
        {
            int v = 0, respuesta = 0;
            if (p > 1)
            {
                for (int i = 1; i <= 500; i++)
                {
                    respuesta = p % i;
                    if (respuesta == 0)
                    {
                        v++;
                    }
                }
            }
            if (v > 2 || respuesta == 0)
            {
                return false;
                
            }
            else
            {
                return true;
            }
        }
        public int factorial(int f)
        {
            int acumulado = 1;
            if (f == 0)
            {

            }
            else
            {
                for (int i = 1; i <= f; i++)
                {
                    acumulado *= i;

                }
            }
            return acumulado;
        }

        public decimal fibonacci(int x)
        {
            decimal d = 1, c = 0;
            for (int j = 1; j <= x; j++)
            {
                c = c + d;
                d = c - d;
            }
            return c;
        }
    }


}
