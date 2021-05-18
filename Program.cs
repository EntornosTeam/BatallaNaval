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
            Inicio inicio = new Inicio();
            inicio.ShowDialog();
            Juego juego = new Juego(inicio.tableLayoutPanel1, inicio.tablero, inicio.barcos);
            juego.ShowDialog();

        }
    }
}
