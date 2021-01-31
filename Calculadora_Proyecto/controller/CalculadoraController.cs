using Calculadora_Proyecto.model;
using Calculadora_Proyecto.view;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Calculadora_Proyecto.controller
{
    public class CalculadoraController
    {
        datos d= new datos(); private int p; decimal part1 = 0, part2 = 0; string resp; bool ver;
        private Calculadora_Window calP;

        public CalculadoraController(Calculadora_Window calw)
        {
            calP = calw;
            
        }

        public void Clicked(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            calP.setResultB((string)bt.Content);
        }

        public void Borrar_Click(object sender, RoutedEventArgs e)
        {
            Button bb = (Button)sender;
            switch (bb.Name)
            {
                case "borrarBox":
                    {
                        calP.setResultA("");
                        calP.setFuncionA("");
                        break;
                    }
                case "borrarAll":
                    {
                        calP.setResultA("");
                        break;
                    }
                case "borrarChar":
                    {
                        if (!calP.getResult().Equals(""))
                        {
                            string j = Convert.ToString(calP.getResult());
                            calP.setResultA(j.Substring(0, j.Length - 1));
                        }
                        else
                        {
                            MessageBox.Show("No hay numeros que borrar");
                        }
                        break;
                    }
                case "punto":
                    {

                        String x = calP.getResult();

                        if (x.IndexOf('.') == -1)
                        {
                            calP.setResultB(".");
                        }
                        break;
                    }
            }
        }
        public void ProblmMath(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            try
            {
                int f = Convert.ToInt32(calP.getResult()); bool l = Convert.ToBoolean(f); Button bb = (Button)sender;
                switch (bb.Name)
                {
                    case "factorial":
                        {

                            if (l && f <= 12)
                            {
                                p = d.factorial(f);
                                MessageBox.Show("El factorial de " + f + " es : " + p);
                                calP.setResultA("");
                            }
                            else if (!l && f > 12)
                            {
                                MessageBox.Show("El dato ingresado no es valido,o el dato\nentero excede los limite mayor a 12");
                                calP.setResultA("");
                            }
                            break;

                        }
                    case "primo":
                        {
                            l = d.primos(f);
                            if (l)
                            {
                                MessageBox.Show("El numero " + f + " es primo");
                                calP.setResultA("");
                            }
                            else if (!l && f > 0)
                            {
                                MessageBox.Show("El numero " + f + " no es primo");
                                calP.setResultA("");
                            }
                            else if (f <= 0)
                            {
                                MessageBox.Show("El dato ingresado no es valido");
                                calP.setResultA("");
                            }
                            break;
                        }
                    case "fibonaci":
                        {
                            if (l && f > 0 && f <= 100)
                            {
                                MessageBox.Show("El n-esimo termino de " + f + " en la serie de fibonacci  es : " + d.fibonacci(f));
                                calP.setResultA("");
                            }
                            else if (!l && f <= 0 && f > 100)
                            {
                                MessageBox.Show("Error la serie de fibonacci solo toma numeros enteros positivos mayores a 0");
                                calP.setResultA("");
                            }
                            break;
                        }
                    case "fibonaciS":
                        {
                            MessageBox.Show("No supe como hacer correr toda la serie lo siento....");
                            calP.setResultA("");
                            break;
                        }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        public void Allcase(object sender, RoutedEventArgs e)
        {

            Button bt = (Button)sender;
            if (calP.getFuncion().Equals(""))
            {
                try
                {
                    calP.setFuncionB(calP.getResult()+ (string)bt.Content);// += result.Text + (string)bt.Content;
                    part1 = Convert.ToDecimal(calP.getResult());
                    calP.setResultA("");
                    resp = Convert.ToString(bt.Content);
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                    calP.setFuncionA("");
                }
            }
            else
            {
                switch (resp)
                {
                    case "-":
                        {
                            try
                            {

                                calP.setFuncionB(calP.getResult() + (string)bt.Content);
                                part2 = Convert.ToDecimal(calP.getResult());
                                part1 -= part2; ver = Convert.ToBoolean(part1);
                                error(ver, part1);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show(x.Message);
                                calP.setFuncionA("");
                            }
                            break;
                        }
                    case "+":
                        {

                            try
                            {
                                calP.setFuncionB(calP.getResult() + (string)bt.Content);
                                part2 = Convert.ToDecimal(calP.getResult());
                                part1 += part2; ver = Convert.ToBoolean(part1);
                                error(ver, part1);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show(x.Message);
                                calP.setFuncionA("");
                            }

                            break;
                        }
                    case "*":
                        {
                            try
                            {
                                calP.setFuncionB(calP.getResult() + (string)bt.Content);
                                part2 = Convert.ToDecimal(calP.getResult());
                                part1 *= part2; ver = Convert.ToBoolean(part1);
                                error(ver, part1);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show(x.Message);
                                calP.setFuncionA("");
                            }
                            break;
                        }
                    case "/":
                        {
                            try
                            {
                                calP.setFuncionB(calP.getResult() + (string)bt.Content);
                                part2 = Convert.ToDecimal(calP.getResult());
                                part1 /= part2; ver = Convert.ToBoolean(part1);
                                error(ver, part1);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show(x.Message);
                                calP.setFuncionA("");
                            }
                            break;
                        }
                }
                resp = Convert.ToString(bt.Content);
            }
        }
        public void error(bool g, decimal u)
        {
            if (g || u == 0)
            {
                calP.setResultA(Convert.ToString(u));
            }
            else
            {
                MessageBox.Show("El dato no es valido");
                calP.setResultA("");
                calP.setFuncionA("");
            }

        }

        public void Igual_Click(object sender, RoutedEventArgs e)
        {

            switch (resp)
            {
                case ("-"):
                    {
                        try
                        {                        
                            part2 = Convert.ToDecimal(calP.getResult());
                            calP.setFuncionB(Convert.ToString(part2));
                            part1 -= part2; ver = Convert.ToBoolean(part1);
                            calP.setResultA(Convert.ToString(part1));
                            error(ver, part1);

                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                            calP.setFuncionA("");
                            calP.setResultA("");

                        }
                        break;
                    }
                case ("+"):
                    {
                        try
                        {
                            part2 = Convert.ToDecimal(calP.getResult());
                            calP.setFuncionB(Convert.ToString(part2));
                            part1 += part2; ver = Convert.ToBoolean(part1);
                            calP.setResultA(Convert.ToString(part1));
                            error(ver, part1);

                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                            calP.setFuncionA("");
                            calP.setResultA("");

                        }
                        break;
                    }
                case ("*"):
                    {
                        try
                        {
                            part2 = Convert.ToDecimal(calP.getResult());
                            calP.setFuncionB(Convert.ToString(part2));
                            part1 *= part2; ver = Convert.ToBoolean(part1);
                            calP.setResultA(Convert.ToString(part1));
                            error(ver, part1);

                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                            calP.setFuncionA("");
                            calP.setResultA("");

                        }

                        break;
                    }
                case ("/"):
                    {
                        try
                        {
                            part2 = Convert.ToDecimal(calP.getResult());
                            calP.setFuncionB(Convert.ToString(part2));
                            part1 /= part2; ver = Convert.ToBoolean(part1);
                            calP.setResultA(Convert.ToString(part1));
                            error(ver, part1);

                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                            calP.setFuncionA("");
                            calP.setResultA("");
                        }

                        break;
                    }

            }

        }
    }
}
