using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCalculatrice.Model
{
    public class Calculatrice : BaseNotifyPropertyChanged
    {

        /* ===== ===== ===== Model.Calculatrice - Attributs & Propriétés ===== ===== ===== */

        public Calcul CurrentCalcul
        {
            get { return (Calcul)GetProperty(); }
            set { SetProperty(value); }
        }
        public ObservableCollection<Calcul> Calculs
        {
            get { return (ObservableCollection<Calcul>)GetProperty(); }
            set { SetProperty(value); }
        }

        /* ===== ===== ===== Model.Calculatrice - Constructeur ===== ===== ===== */

        public Calculatrice()
        {

            Calculs = new ObservableCollection<Calcul>();
            CurrentCalcul = new Calcul();

            System.Console.Write("[+] Calculatrice - Empty");

        }

        /* ===== ===== ===== Model.Calculatrice - Méthodess ===== ===== ===== */

        public void Calculate()
        {

            this.CurrentCalcul = new Calcul(this.CurrentCalcul.Input);

            if (this.CurrentCalcul.Calculate())
            {

                Calculs.Add(this.CurrentCalcul); // Ajouter le calcul courant à l'Historique

                // Créer un nouveau calcul (une copie de CurrentCalcul) pour éviter de fausser l'historique
                // (sans ça, l'input n-1 est remplacé par l'input n dans l'historique (mais les résultats ne bougent pas))
                // Ce calcul est simplement présent pour palier à ce problème, et est destiné à être affiché sur la calculatrice
                Calcul temp = this.CurrentCalcul;
                temp.Displayable = temp.Input + " = " + temp.Result;
                this.CurrentCalcul = new Calcul("", temp.Result, temp.Displayable);

            }

            else
            {
                // Si le calcul a échoué, on ne l'ajoute pas dans l'historique (Result = null, Displayable = ERR)
                Calcul temp = this.CurrentCalcul;
                this.CurrentCalcul = new Calcul(temp.Input, null, "ERR");

            }

        }

    }

}