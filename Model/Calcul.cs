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
        /* ===== ===== ===== Model.Calcul -  Attributs & Propriétés ===== ===== ===== */
        public string Input
        {
            get { return (string) GetProperty(); }
            set { SetProperty(value); }
        }

        public double? Result
        {
            get { return (double?)GetProperty(); }
            set { SetProperty(value); }
        }

        public string Displayable
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }

        /* ===== ===== ===== Model.Calcul - Constructeurs ===== ===== ===== */
        public Calcul()
        {
            this.Input = "";
            this.Result = null;
            this.Displayable = null;

            System.Console.Write("[+] Calcul - Empty");

        }

        public Calcul(string input)
        {
            this.Input = input;
            this.Result = null;
            this.Displayable = null;

            System.Console.Write("[+] Calcul - Input");
        }

        public Calcul(string input, double? result)
        {
            this.Input = input;
            this.Result = result;

            System.Console.Write("[+] Calcul - Input/Result");
        }

        public Calcul(string input, double? result, string displayable)
        {
            this.Input = input;
            this.Result = result;
            this.Displayable = displayable;

            System.Console.Write("[+] Calcul - Input/Result/Displayable");
        }

        /* ===== ===== ===== Model.Calcul - Méthodes ===== ===== ===== */

        private bool CheckInput()
        {

            // Si la chaîne est vide ou null
            if (this.Input == null || this.Input == "")
            {
                return false;
            }

            // Si la chaîne contient des (chaînes de) caractères non supportés, retourner false (ce qui va déclencher une erreur)
            // this.Input.Contains("%") || this.Input.Contains("!") || this.Input.Contains("$") || => plus possible de les insérer
            else if (this.Input.Contains("*/") || this.Input.Contains("/*") || this.Input.Contains(".."))
            {
                return false;
            }

            else
            {

                // Remplacer les virgules par des points (si l'utilisateur a réussi à en insérer)
                if (this.Input.Contains(","))
                {
                    this.Input = this.Input.Replace(',', '.');
                }

                // Supprimer les combinaisons qui sont en fin de chaîne (pour éviter l'erreur -> plantage)
                if ( this.Input.EndsWith("/.") || this.Input.EndsWith("./") ||
                    this.Input.EndsWith("*.") || this.Input.EndsWith(".*") ||
                    this.Input.EndsWith("+.") || this.Input.EndsWith(".+") ||
                    this.Input.EndsWith("-.") || this.Input.EndsWith(".-")  )
                {
                    this.Input = this.Input.Remove(this.Input.Length - 2);
                }

                // Supprimer les opérateurs qui sont en fin de chaîne (pour éviter l'erreur -> plantage)
                if (this.Input.Last().Equals('+') || this.Input.Last().Equals('-') || this.Input.Last().Equals('*') || this.Input.Last().Equals('/'))
                {
                    this.Input = this.Input.TrimEnd('+', '-', '/', '*');
                }

                // Retourner true (le calcul va s'effectuer normalement)
                return true;
            }

        }

        public bool Calculate()
        {

            // Fonction de remplacement des racines carrées (de symbole à ^0.5)
            this.ReplaceSqrt();

            if(CheckInput())
            {
                MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
                sc.Language = "VBScript";

                try // Le try-catch ici permet de d'éviter que la calculatrice plante en cas de calcul incorrect non corrigé par CheckInput()
                {
                    this.Result = sc.Eval(this.Input); // Effectuer le calcul et le placer dans Result
                }

                catch
                {
                    this.Result = null;
                    //MessageBox.Show("Calcul invalide ! Veuillez corriger votre entrée !");
                    return false;
                }

                return true;
            }

            else
            {
                this.Result = null;
                //MessageBox.Show("Calcul invalide ! Veuillez corriger votre entrée !");
                return false;
            }

        }

        public bool ReplaceSqrt()
        {
            bool state = false;
            Regex rgx = new Regex(@"√\((\d|[+\-*/^().]|cos|sin)+\)");
            while (rgx.IsMatch(this.Input))
            {
                Match m = rgx.Match(this.Input);
                string start = this.Input.Substring(0, m.Index);
                string end = this.Input.Substring(m.Index + m.Length - 1);
                string replace = m.Value.Substring(1) + "^(0.5";
                this.Input = start + replace + end;
                state = true;
            }
            return state;
        }
        
    }
}
