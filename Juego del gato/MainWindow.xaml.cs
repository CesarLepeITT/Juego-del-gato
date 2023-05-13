using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

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

        string[,] _gato = new string[3, 3];
        int _ganadosJ1 = 0;
        int _ganadosJ2 = 0;
        int _empatados = 1;
        int _turnos = 0;
        private string QuienSigue()
        {
            if (_turnos % 2 == 0) return "x";
            else return "o";
        }
        private void AgregarMovimiento(int posicionX, int posicionY, string tipo)
        {
            _gato[posicionX, posicionY] = tipo;
            _turnos++;
        }
        private void ReiniciarBotones()
        {
            btn00.IsEnabled = true;
            btn00.Content = "";
            btn10.IsEnabled = true;
            btn10.Content = "";
            btn20.IsEnabled = true;
            btn20.Content = "";

            btn01.IsEnabled = true;
            btn01.Content = "";
            btn11.IsEnabled = true;
            btn11.Content = "";
            btn21.IsEnabled = true;
            btn21.Content = "";

            btn02.IsEnabled = true;
            btn02.Content = "";
            btn12.IsEnabled = true;
            btn12.Content = "";
            btn22.IsEnabled = true;
            btn22.Content = "";
        }
        private void BloquearBotones()
        {
            btn00.IsEnabled = false;
            btn10.IsEnabled = false;
            btn20.IsEnabled = false;

            btn01.IsEnabled = false;
            btn11.IsEnabled = false;
            btn21.IsEnabled = false;

            btn02.IsEnabled = false;
            btn12.IsEnabled = false;
            btn22.IsEnabled = false;
        }
        private void ReiniciarGato()
        {
            string[,] aux = new string[3, 3];
            _gato = aux;
            _turnos = 0;
            ReiniciarBotones();
        }

        private void RevisarLinea(string patron)
        {
            string patronGanadorX = "xxx"; //J1
            string patronGanadorO = "ooo"; //J2
            if (Regex.IsMatch(patron,patronGanadorX))
            {
                _ganadosJ1++;
                txtCantidadGanadosJ1.Text = _ganadosJ1.ToString();
                BloquearBotones();
            }
            if (Regex.IsMatch(patron,patronGanadorO))
            {
                _ganadosJ2++;
                txtCantidadGanadosJ2.Text = _ganadosJ2.ToString();
                BloquearBotones();
            }
            if (_turnos == 9)
            {
                txtCantidadEmpatados.Text = _empatados.ToString();
                _empatados++;
            }
        }

        private void RevisarGanador()
        {

            for (int i = 0; i < 3; i++)
            {
                //Revisa de manera horizontal
                RevisarLinea(_gato[0, i] + _gato[1, i] + _gato[2, i]);
                //Revisa demanera vertical
                RevisarLinea(_gato[i, 0] + _gato[i, 1] + _gato[i, 2]);
            }

            //Revisa de manera diagonal izq arrba derecha abajo
            RevisarLinea(_gato[0, 0] + _gato[1, 1] + _gato[2, 2]);
            //Revisa de manera diagonal izq abajo derecha arriba
            RevisarLinea(_gato[0, 2] + _gato[1, 1] + _gato[2, 0]);

        }

        private void CambiarContenidoBoton(Button myBoton)
        {
            myBoton.Content = QuienSigue();
        }

        private Button RevisarSender(object sender)
        {
            //Fila 1
            if (sender == btn00)
                return btn00;
            else if (sender == btn10)
                return btn10;
            else if (sender == btn20)
                return btn20;
            //Fila 2
            else if (sender == btn01)
                return btn01;
            else if (sender == btn11)
                return btn11;
            else if (sender == btn21)
                return btn21;
            //Fila 3
            else if (sender == btn02)
                return btn02;
            else if (sender == btn12)
                return btn12;
            else // if (sender == btn22)
                return btn22;
        }

        private int RevisarNombreX(string nombre)
        {
            //btn[x][y]
            char posX = nombre[3];
            return int.Parse(posX.ToString());

        }
        private int RevisarNombreY(string nombre)
        {
            //btn[x][y]
            char posY = nombre[4];
            return int.Parse(posY.ToString());

        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Button myBoton = RevisarSender(sender);
            myBoton.IsEnabled = false;
            CambiarContenidoBoton(myBoton);
            AgregarMovimiento(RevisarNombreX(myBoton.Name), RevisarNombreY(myBoton.Name), QuienSigue());
            RevisarGanador();
        }

        private void txtTextChanged(object sender, TextChangedEventArgs e)
        {

            if (sender == txbNombreJ1)
                txtNombreJ1.Text = txbNombreJ1.Text;
            if (sender == txbNombreJ2)
                txtNombreJ2.Text = txbNombreJ2.Text;

        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            ReiniciarGato();
        }
    }
}
