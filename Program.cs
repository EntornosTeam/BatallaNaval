using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatallaNaval
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool close = true;
            do
            {
                close = true;
                Menu menu = new Menu();
                menu.ShowDialog();
                bool startGame = menu.startGame;
                if (startGame)
                {
                    bool play = false;
                    Inicio inicio = new Inicio();
                    inicio.ShowDialog();
                    play = inicio.play;
                    if (play)
                    {
                        Juego juego = new Juego(inicio.tableLayoutPanel1, inicio.tablero, inicio.barcos);
                        juego.ShowDialog();
                        close = !juego.replay;
                    }
                }
            } while (!close);
            


        }
    }
}

