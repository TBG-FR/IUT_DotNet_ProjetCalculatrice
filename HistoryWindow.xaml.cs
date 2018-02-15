using System;
using System.Collections.Generic;
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
        public HistoryWindow(Calculatrice calculatrice)
        {
            this.DataContext = calculatrice;
            InitializeComponent();
        }
        private void Button_ResetHistory_Click(object sender, RoutedEventArgs e)
        {
            // 
        }
        private void Button_ExportHistory_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
