using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Juego_del_gato
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RevisarInput(TextBox textBox)
        {
            if (Regex.IsMatch(textBox.Text, "x", RegexOptions.IgnoreCase) || Regex.IsMatch(textBox.Text, "o", RegexOptions.IgnoreCase))
            {

                textBox.Text = "";

            }
        }


    }
}
