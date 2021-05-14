using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatallaNaval
{
    class Tablero
    {
        List<List<int>> filas;

        public Tablero()
        {
            filas = new List<List <int>>() { };

            for (int i = 0; i < 10; i++)
            {

                List<int> columnas = new List<int>();
                columnas.Add(-1);
                filas.Add(columnas);
            }
            //ComprobarCasilla("2,3");
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="casillaTocada"></param>
        /// <returns>Devuelve el valor de la casilla solicitada. Indice 0 = id del barco, o -1 si es agua. Indice 1 = estado de la casilla</returns>
        public int ComprobarCasilla(String casillaTocada) // "2,5" -> tag
        {
            int[] tocada = Array.ConvertAll(casillaTocada.Split(','), s => Int32.Parse(s));
            return filas[tocada[0]][tocada[1]];
        }


        public void RecorrerTablero()
        {
            int valor = ComprobarCasilla("2, 5");
            foreach (List<int> fila in filas)
            {
                foreach (int casilla in fila)
                {
                    // fila.IndexOf(casilla);
                }
            }
        }
    }
}
