using Calculadora_Proyecto.model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Calculadora_Proyecto.view
{
    public partial class Calculadora_Window : Window
    {
        datos d; private int p;decimal part1=0, part2=0;string resp;bool ver;
        public Calculadora_Window()
        {
            d = new datos();
            InitializeComponent();
        }
        // escribe cada uno de los numero sl textbox
        public void Clicked(object sender, RoutedEventArgs e) {
            Button bt = (Button)sender;
            result.Text += (String)bt.Content;
        }
        //los botones de borrar segun CE,C,← y solo agregar un punto
        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            Button bb = (Button)sender;
            switch (bb.Name)
            {
                case "borrarBox":
                    {
                        result.Text = "";
                        funcion.Content = "";
                        break;
                    }
                case " borrarAll":
                    {
                        result.Text = "";
                        break;
                    }
                case "borrarChar":
                    {
                        if (!result.Text.Equals(""))
                        {
                            string j = Convert.ToString(result.Text);
                            result.Text = j.Substring(0, j.Length - 1);
                        }
                        else
                        {
                            MessageBox.Show("No hay numeros que borrar");
                        }
                        break;
                    }
                case "punto":
                    {

                        if (result.Text.Contains("."))
                        {
                            result.Text += ".";
                            result.Undo();
                        }
                        else 
                        {
                            result.Text += ".";   
                        }
                        break;
                    }
            }
        }
        //Problemas matematicas de cada uno de los botones n!,nf,p y 112...
        private void ProblmMath (object sender, RoutedEventArgs e)
        {
            try
            {
                int f = Convert.ToInt32(result.Text); bool l = Convert.ToBoolean(f); Button bb = (Button)sender;
                switch (bb.Name)
                {
                    case "factorial":
                        {
                            if (l && f <= 12)
                            {
                                p = d.factorial(f);
                                MessageBox.Show("El factorial de " + f + " es : " + p);
                                result.Text = "";
                            }
                            else if (!l && f > 12)
                            {
                                MessageBox.Show("El dato ingresado no es valido,o el dato\nentero excede los limite mayor a 12");
                                result.Text = "";
                            }
                            break;

                        }
                    case "primo":
                        {
                            l = d.primos(f);
                            if (l)
                            {
                                MessageBox.Show("El numero " + f + " es primo");
                                result.Text = "";
                            }
                            else if (!l && f > 0)
                            {
                                MessageBox.Show("El numero " + f + " no es primo");
                                result.Text = "";
                            }
                            else if (f <= 0)
                            {
                                MessageBox.Show("El dato ingresado no es valido");
                                result.Text = "";
                            }
                            break;
                        }
                    case "fibonaci":
                        {
                            if (l && f > 0 && f <= 100)
                            {
                                MessageBox.Show("El n-esimo termino de " + f + " en la serie de fibonacci  es : " + d.fibonacci(f));
                                result.Text = "";
                            }
                            else if (!l && f <= 0 && f > 100)
                            {
                                MessageBox.Show("Error la serie de fibonacci solo toma numeros enteros positivos mayores a 0");
                                result.Text = "";
                            }
                            break;
                        }
                    case "fibonaciS":
                        {
                            MessageBox.Show("No supe como hacer correr toda la serie lo siento....");
                            result.Text="";
                            break;
                        }
                }
            }      
            catch (Exception x)   
            {
                MessageBox.Show(x.Message);
            }
        }
        //concatena los numeros del texbox con los operadores seleccionados y los pasa al label 
        private void Allcase (object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            if (funcion.Content.Equals(""))
            {
                try
                {
                    funcion.Content += result.Text + (string)bt.Content;
                    part1 = Convert.ToDecimal(result.Text);
                    result.Text = "";
                    resp = Convert.ToString(bt.Content);
                }
                catch (Exception x) 
                {
                    MessageBox.Show(x.Message);
                    funcion.Content="";
                }
            }
            else {
                switch (resp) {
                    case "-":
                        {
                            try
                            {

                                funcion.Content += result.Text + (string)bt.Content;
                                part2 = Convert.ToDecimal(result.Text);
                                part1 -= part2; ver = Convert.ToBoolean(part1);
                                error(ver, part1);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show(x.Message);
                                funcion.Content = "";
                            }
                            break;        
                        }
                    case "+":
                        {

                            try
                            {
                                funcion.Content += result.Text + (string)bt.Content;
                                part2 = Convert.ToDecimal(result.Text);
                                part1 += part2; ver = Convert.ToBoolean(part1);
                                error(ver, part1);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show(x.Message);
                                funcion.Content = "";
                            }
                            
                            break;
                        }
                    case "*":
                        {
                            try
                            {
                                funcion.Content += result.Text + (string)bt.Content;
                                part2 = Convert.ToDecimal(result.Text);
                                part1 *= part2; ver = Convert.ToBoolean(part1);
                                error(ver, part1);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show(x.Message);
                                funcion.Content = "";
                            }
                            break;
                        }
                    case "/":
                        {
                            try
                            {
                                funcion.Content += result.Text + (string)bt.Content;
                                part2 = Convert.ToDecimal(result.Text);
                                part1 /= part2; ver = Convert.ToBoolean(part1);
                                error(ver,part1);    
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show(x.Message);
                                result.Text = "";
                                funcion.Content = "";
                            }
                            break;
                        }
                }
                resp = Convert.ToString(bt.Content);
            }
        }
        //metodo por si me dan errores las operaciones de la calculadora
        public void error(bool g, decimal u) 
        {
            if (g || u==0)
            {
                result.Text = Convert.ToString(u);
            }
            else
            {
                MessageBox.Show("El dato no es valido");
                result.Text = "";
                funcion.Content = "";
            }

        }
        //el boton igual
        private void Igual_Click(object sender, RoutedEventArgs e)
        {
            switch (resp) 
            {
                case ("-"): 
                {
                        try
                        {
                            part2 = Convert.ToDecimal(result.Text);
                            funcion.Content += Convert.ToString(part2);
                            part1 -= part2; ver = Convert.ToBoolean(part1);
                            result.Text = Convert.ToString(part1);
                            error(ver,part1);

                        }
                        catch(Exception x)
                        {
                            MessageBox.Show(x.Message);
                            result.Text = "";
                            funcion.Content = "";

                        }

                        break;
                }
                case ("+"):
                {
                        try
                        {
                            part2 = Convert.ToDecimal(result.Text);
                            funcion.Content += Convert.ToString(part2);
                            part1 += part2; ver = Convert.ToBoolean(part1);
                            result.Text = Convert.ToString(part1);
                            error(ver, part1);

                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                            result.Text = "";
                            funcion.Content = "";

                        }
                        break;
                }
                case ("*"):
                {
                        try
                        {
                            part2 = Convert.ToDecimal(result.Text);
                            funcion.Content += Convert.ToString(part2);
                            part1 *= part2; ver = Convert.ToBoolean(part1);
                            result.Text = Convert.ToString(part1);
                            error(ver, part1);

                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                            result.Text = "";
                            funcion.Content = "";

                        }

                        break;
                }
                case ("/"):
                {
                        try
                        {
                            part2 = Convert.ToDecimal(result.Text);
                            funcion.Content += Convert.ToString(part2);
                            part1 -= part2; ver = Convert.ToBoolean(part1);
                            result.Text = Convert.ToString(part1);
                            error(ver, part1);

                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                            result.Text = "";
                            funcion.Content = "";

                        }

                        break;
                }
            
            }

        }
    }
}
