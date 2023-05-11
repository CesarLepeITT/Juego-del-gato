using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Juego_del_gato
{
    internal class JuegoGato
    {
        JuegoGato(string nombreJ1 = "Player1", string nombreJ2= "Player2") 
        { 
            _nombreJ1= nombreJ1;
            _nombreJ2= nombreJ2;
            _ganadosJ1 = 0;
            _ganadosJ2 = 0;
            _ganador = "";
            _turnos= 0;
            _empatados= 0;
        }
        public void AgregarMovimiento(int posicionX, int posicionY, string tipo)
        {
            _gato[posicionX,posicionY] = tipo;
        }        
        public void ReiniciarGato()
        {
            string [,] aux = new string[3, 3];
            _gato = aux;
            _turnos= 0;
        }

        public void RevisarLinea(string patron)
        {
            string patronGanadorX = "xxx"; //J1
            string patronGanadorO = "ooo"; //J2
            if (Regex.IsMatch(patronGanadorX, patron)) 
                _ganador = _nombreJ1;
            else if (Regex.IsMatch(patronGanadorO, patron))
                _ganador = _nombreJ2;
        }

        public void RevisarGanador()
        {

            for (int i = 0; i< 3; i++) 
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

            _turnos++;
            if (_turnos == 9);
                _empatados++;
        }
        public int Empatados
        {

            get { return _empatados; }

        }
        public string Ganador
        {
            get { return _ganador; }
        }

        public int JuegosGanadosJ1
        {
            get { return _ganadosJ1; }
            set { _ganadosJ1 = value;}
        }        
        public int JuegosGanadosJ2
        {
            get { return _ganadosJ2; }
            set { _ganadosJ2 = value;}
        }


        private string[,] _gato = new string [3,3];
        private string _ganador;
        private string _nombreJ1;
        private string _nombreJ2;
        private int _ganadosJ1;
        private int _ganadosJ2;
        private int _empatados;
        private int _turnos;

    }

}
