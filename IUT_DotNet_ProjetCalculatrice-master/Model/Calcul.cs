using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool Done
        {
            get { return (bool) GetProperty(); }
            set { SetProperty(value); }
        }

        /* ===== ===== ===== Model.Calcul - Constructor ===== ===== ===== */
        public Calcul()
        {
            this.Input = "";
            this.Done = false;
            this.Result = null;

            System.Console.Write("[+] Calcul - Empty");

        }

        public Calcul(string input)
        {
            this.Input = input;
            this.Done = false;
            this.Result = null;

            System.Console.Write("[+] Calcul - Input");
        }

        /* ===== ===== ===== Model.Calcul - Methods ===== ===== ===== */

        private bool CheckInput()
        {
            // TODO : Vérifier Points, Virgules, Lettres, Charactères spéciaux/non supportés, etc...
            return true;
        }

        public void Calculate()
        {

            if(CheckInput())
            {
                MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
                sc.Language = "VBScript";
                //string expression = "(1 + 2) * 7";
                //object result = sc.Eval(expression);
                //MessageBox.Show(result.ToString());
                this.Result = sc.Eval(this.Input);
                this.Done = true;
            }

            else
            {
                this.Result = null;
                this.Done = false;
            }

        }

        /*
        public override string ToString()
        {
            return Nom + " " + Prenom;
        }
        */
    }
}
