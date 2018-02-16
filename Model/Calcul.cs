using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;


namespace ProjetCalculatrice.Model
{
    public class Calcul : BaseNotifyPropertyChanged
    {
        /* ===== ===== ===== Model.Calcul - Attributes/Properties ===== ===== ===== */
        public string Input
        {
            get { return (string) GetProperty(); }
            set { SetProperty(value); }
        }

        public double? Result
        {
            get { return (double?) GetProperty(); }
            set { SetProperty(value); }
        }

        /* ===== ===== ===== Model.Calcul - Constructor ===== ===== ===== */
        public Calcul()
        {
            this.Input = "";
            this.Result = null;

            System.Console.Write("[+] Calcul - Empty");

        }

        public Calcul(string input)
        {
            this.Input = input;
            this.Result = null;

            System.Console.Write("[+] Calcul - Input");
        }

        public Calcul(string input, double? result)
        {
            this.Input = input;
            this.Result = result;

            System.Console.Write("[+] Calcul - Input/Result");
        }

        /* ===== ===== ===== Model.Calcul - Methods ===== ===== ===== */

        private bool CheckInput()
        {

            // TODO ? : Vérifier Points, Virgules, Lettres, Charactères spéciaux/non supportés, etc...
            if (this.Input.Contains(",") || this.Input.Contains("%") || this.Input.Contains("!") || this.Input.Contains("*/") || this.Input.Contains("/*") || this.Input.Contains("$"))
                return false;

            else
                return true;

        }

        public bool Calculate()
        {

            if(CheckInput())
            {
                MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
                sc.Language = "VBScript";
                //string expression = "(1 + 2) * 7";
                //object result = sc.Eval(expression);
                //MessageBox.Show(result.ToString());
                this.Result = sc.Eval(this.Input);
                return true;
            }

            else
            {
                this.Result = null;
                MessageBox.Show("Calcul invalide !");
                return false;
            }

        }

        public string ReplaceSqrt(String s)
        {
            Regex rgx = new Regex(@"√\((\d|[+\-*/^().]|cos|sin)+\)");
            while (rgx.IsMatch(s))
            {
                Match m = rgx.Match(s);
                string start = s.Substring(0, m.Index);
                string end = s.Substring(m.Index + m.Length - 1);
                string replace = m.Value.Substring(1) + "^(0.5";
                s = start + replace + end;
            }
            return s;
        }

        /*
        public override string ToString()
        {
            return Nom + " " + Prenom;
        }
        */
    }
}
