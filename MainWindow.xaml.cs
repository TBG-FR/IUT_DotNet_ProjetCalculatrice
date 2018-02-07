using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjetCalculatrice.Model;

namespace ProjetCalculatrice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /* ===== ===== ===== MainWindow - Attributes/Properties ===== ===== ===== */

        private Calculatrice calculatrice;

        public MainWindow()
        {
            this.calculatrice = new Calculatrice();
            this.DataContext = this.calculatrice;
            InitializeComponent();

            /*
            MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
            sc.Language = "VBScript";
            string expression = "(1 + 2) * 7";
            object result = sc.Eval(expression);
            MessageBox.Show("A1" + result.ToString());

            expression = "(1 + 2) * 7 + 78 / 12";
            result = sc.Eval(expression);
            MessageBox.Show("A2" + result.ToString());

            expression = "exp(2)";
            result = sc.Eval(expression);
            MessageBox.Show("E2" + result.ToString());
            /*
            expression = "Math.Sqrt(84) + 100";
            result = sc.Eval(expression);
            MessageBox.Show("SQ" + result.ToString());
            *//*
            expression = "0.3 + 0.2";
            result = sc.Eval(expression);
            MessageBox.Show("POI" + result.ToString());
            /*
            expression = "0,3 + 0,2";
            result = sc.Eval(expression);
            MessageBox.Show("VIR" + result.ToString());
            */
        }

        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            this.calculatrice.Calculate(this.calculatrice.CurrentCalcul.Input);
        }
        private void Button_History_Click(object sender, RoutedEventArgs e)
        {
            // Ouvrir Window + ListBox : Historique
            //new HistoryWindow(this.calculatrice);
        }

        /*
        MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
        sc.Language = "VBScript";
        string expression = "(1 + 2) * 7";
        object result = sc.Eval(expression);
        MessageBox.Show(result.ToString());        
        */

    }
}
