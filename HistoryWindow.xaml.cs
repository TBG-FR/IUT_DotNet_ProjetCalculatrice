using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Shapes;
using ProjetCalculatrice.Model;

namespace ProjetCalculatrice
{
    /// <summary>
    /// Logique d'interaction pour HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {

        Calculatrice calculatrice;

        public HistoryWindow(Calculatrice calculatrice)
        {
            this.calculatrice = calculatrice;
            this.DataContext = calculatrice;
            InitializeComponent();
        }
        private void Button_ResetHistory_Click(object sender, RoutedEventArgs e)
        {

            if (this.calculatrice.Calculs.Count == 0)
            {
                MessageBox.Show("Votre historique est déjà vide !" + "\r\n\r\n" + "« Quand on veut être sûr de son coup, Seigneur Dagonet… on plante des navets. On ne pratique pas le putsch. »");
            }

            else
            {
                this.calculatrice.Calculs.Clear();
            }
        }
        private void Button_ExportHistory_Click(object sender, RoutedEventArgs e)
        {

            if (this.calculatrice.Calculs.Count == 0)
            {
                MessageBox.Show("Votre historique est vide !" + "\r\n\r\n" + "« Selon Karadoc, un lit n’est pas un lit s'il n’y a pas de quoi manger une semaine dedans sans en sortir. »");
            }

            else
            {
            
                String history = "===== Kaalculattrice : Historique ===== [C:\\temp\\kaal_history.txt] =====\r\n\r\n";

                foreach (Calcul c in this.calculatrice.Calculs)
                {
                    history += c.Displayable + "\r\n";
                }

                File.WriteAllText(@"C:\temp\kaal_history.txt", history);
                Process.Start(@"C:\temp\kaal_history.txt");

            }
        }
    }
}
