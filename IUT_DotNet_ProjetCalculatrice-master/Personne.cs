using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_ListBox
{
    public class Personne : BaseNotifyPropertyChanged
    {
        public string Nom
        {
            get { return (string) GetProperty(); }
            set { SetProperty(value); }
        }
        public string Prenom
        {
            get { return (string) GetProperty(); }
            set { SetProperty(value); }
        }
        public string Adresse
        {
            get { return (string) GetProperty(); }
            set { SetProperty(value); }
        }
        public string CodePostal
        {
            get { return (string) GetProperty(); }
            set { SetProperty(value); }
        }
        public string Ville
        {
            get { return (string) GetProperty(); }
            set { SetProperty(value); }
        }

        public override string ToString()
        {
            return Nom + " " + Prenom;
        }
    }
}
