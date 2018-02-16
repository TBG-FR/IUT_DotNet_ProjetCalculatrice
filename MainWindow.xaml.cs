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

        private Collection<Window> subWindows;

        public MainWindow()
        {
            this.calculatrice = new Calculatrice();
            this.DataContext = this.calculatrice;
            this.subWindows = new Collection<Window>();
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
            this.calculatrice.Calculate();
        }

        private void Button_History_Click(object sender, RoutedEventArgs e)
        {
            HistoryWindow subW_History = new HistoryWindow(this.calculatrice);
            subWindows.Add(subW_History);
            subW_History.Show();
        }

        private void Button_NewCalc_Click(object sender, RoutedEventArgs e)
        {
            MainWindow subW_Calc = new MainWindow();
            subWindows.Add(subW_Calc);
            subW_Calc.Show();
        }

        private void Button_CloseCalc_Click(object sender, RoutedEventArgs e)
        {

            Button_CloseSub_Click(sender, e);

            this.Close();
        }

        private void Button_CloseSub_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window w in subWindows)
            {
                w.Close();
            }
        }

        private void Button_Insert_Self(object sender, RoutedEventArgs e)
        {
            this.calculatrice.CurrentCalcul.Input += ((Button) e.Source).Content.ToString();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            if (this.calculatrice.CurrentCalcul.Input.Length > 0)
                this.calculatrice.CurrentCalcul.Input = this.calculatrice.CurrentCalcul.Input.Substring(0, this.calculatrice.CurrentCalcul.Input.Length - 1);
        }

        private void Button_Del(object sender, RoutedEventArgs e)
        {
            this.calculatrice.CurrentCalcul.Input = "";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.NumPad0 || e.Key == Key.NumPad1 || e.Key == Key.NumPad2 || e.Key == Key.NumPad3 || e.Key == Key.NumPad4 || e.Key == Key.NumPad5 || e.Key == Key.NumPad6 || e.Key == Key.NumPad7 || e.Key == Key.NumPad8 || e.Key == Key.NumPad9)
            {
                this.calculatrice.CurrentCalcul.Input += e.Key.ToString().Substring(6);
            }

            if (e.Key == Key.D0 || e.Key == Key.D1 || e.Key == Key.D2 || e.Key == Key.D3 || e.Key == Key.D4 || e.Key == Key.D5 || e.Key == Key.D6 || e.Key == Key.D7 || e.Key == Key.D8 || e.Key == Key.D9)
            {
                this.calculatrice.CurrentCalcul.Input += e.Key.ToString().Substring(1);
            }

            if (e.Key == Key.Add)
            {
                this.calculatrice.CurrentCalcul.Input += "+";
            }

            if (e.Key == Key.Subtract)
            {
                this.calculatrice.CurrentCalcul.Input += "-";
            }
            if (e.Key == Key.Multiply)
            {
                this.calculatrice.CurrentCalcul.Input += "*";
            }

            if (e.Key == Key.Divide)
            {
                this.calculatrice.CurrentCalcul.Input += "/";
            }

            if (e.Key == Key.Decimal || e.Key == Key.OemComma || e.Key == Key.OemPeriod)
            {
                this.calculatrice.CurrentCalcul.Input += ".";
            }

            if (e.Key == Key.Back && this.calculatrice.CurrentCalcul.Input.Length > 0)
            {
                this.calculatrice.CurrentCalcul.Input = this.calculatrice.CurrentCalcul.Input.Substring(0, this.calculatrice.CurrentCalcul.Input.Length - 1);
            }

            if (e.Key == Key.Delete)
            {
                this.calculatrice.CurrentCalcul.Input = "";
            }

            if (e.Key == Key.Prior)
            {
                this.calculatrice.CurrentCalcul.Input += "^";
            }
        }
    }
}

    /*
    MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
    sc.Language = "VBScript";
    string expression = "(1 + 2) * 7";
    object result = sc.Eval(expression);
    MessageBox.Show(result.ToString());        
    */
