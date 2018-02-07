using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCalculatrice.Model
{
    class Calculatrice : BaseNotifyPropertyChanged
    {

        /* ===== ===== ===== Model.Calculatrice - Attributes & Properties ===== ===== ===== */

        public Calcul CurrentCalcul
        {
            get { return (Calcul) GetProperty(); }
            set { SetProperty(value); }
        }
        public ObservableCollection<Calcul> Calculs
        {
            get { return (ObservableCollection<Calcul>)GetProperty(); }
            set { SetProperty(value); }
        }

        /* ===== ===== ===== Model.Calculatrice - Constructor ===== ===== ===== */

        public Calculatrice()
        {

            Calculs = new ObservableCollection<Calcul>();
            CurrentCalcul = null;

            System.Console.Write("[+] Calculatrice - Empty");

        }

        /* ===== ===== ===== Model.Calculatrice - Methods ===== ===== ===== */

        public void Calculate(string input)
        {

            // Ajouter le Calcul précédent à l'historique, si il existe et si il a été calculé avec succès
            if (this.CurrentCalcul != null && this.CurrentCalcul.Done == true) { Calculs.Add(this.CurrentCalcul); }

            // Créer un nouveau Calcul avec l'input, puis effectuer le calcul
            this.CurrentCalcul = new Calcul(input);
            this.CurrentCalcul.Calculate();

            // TODO - LA SUITE

        }

    }
}
