using Calculadora_Proyecto.controller;
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
        private CalculadoraController CalC;
        private string xc;
        public Calculadora_Window()
        {

            InitializeComponent();
            SetupController();
        }

        public void SetupController() 
        {
            CalC = new CalculadoraController(this);
            this.cero.Click += new System.Windows.RoutedEventHandler(CalC.Clicked);
            this.uno.Click += new System.Windows.RoutedEventHandler(CalC.Clicked);
            this.dos.Click += new System.Windows.RoutedEventHandler(CalC.Clicked);
            this.tres.Click += new System.Windows.RoutedEventHandler(CalC.Clicked);
            this.cuatro.Click += new System.Windows.RoutedEventHandler(CalC.Clicked);
            this.cinco.Click += new System.Windows.RoutedEventHandler(CalC.Clicked);
            this.seis.Click += new System.Windows.RoutedEventHandler(CalC.Clicked);
            this.siete.Click += new System.Windows.RoutedEventHandler(CalC.Clicked);
            this.ocho.Click += new System.Windows.RoutedEventHandler(CalC.Clicked);
            this.nueve.Click += new System.Windows.RoutedEventHandler(CalC.Clicked);
            this.borrarAll.Click += new System.Windows.RoutedEventHandler(CalC.Borrar_Click);
            this.borrarChar.Click += new System.Windows.RoutedEventHandler(CalC.Borrar_Click);
            this.borrarBox.Click += new System.Windows.RoutedEventHandler(CalC.Borrar_Click);
            this.punto.Click += new System.Windows.RoutedEventHandler(CalC.Borrar_Click);
            this.factorial.Click += new System.Windows.RoutedEventHandler(CalC.ProblmMath);
            this.primo.Click += new System.Windows.RoutedEventHandler(CalC.ProblmMath);
            this.fibonaci.Click += new System.Windows.RoutedEventHandler(CalC.ProblmMath);
            this.fibonaciS.Click += new System.Windows.RoutedEventHandler(CalC.ProblmMath);
            this.suma.Click += new System.Windows.RoutedEventHandler(CalC.Allcase);
            this.resta.Click += new System.Windows.RoutedEventHandler(CalC.Allcase);
            this.multi.Click += new System.Windows.RoutedEventHandler(CalC.Allcase);
            this.div.Click += new System.Windows.RoutedEventHandler(CalC.Allcase);
            this.igual.Click += new System.Windows.RoutedEventHandler(CalC.Igual_Click);
        }

        public string getFuncion() 
        {
            return (string)funcion.Content;
        }

        public string getResult()
        {
            return (string)result.Text;
        }

        public void setFuncionA(string u) 
        {
            xc = u;  
             funcion.Content = xc; 
        }

        public void setResultA(string u)
        {
            xc = u;
            result.Text = xc;
        }

        public void setFuncionB(string u)
        {
            xc = u;
            funcion.Content += xc;
        }

        public void setResultB(string u)
        {
            xc = u;
            result.Text += xc;
        }
    }
}
