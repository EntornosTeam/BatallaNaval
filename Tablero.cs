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
            filas.Add(new List<int>() { -1, -1, -1, -1, -1, -1, 2, 2, -1, -1, -1 });
            filas.Add(new List<int>() { -1, -1, -1, -1, -1, -1, 3, 3, -1, -1, -1 });
            filas.Add(new List<int>() { -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1 });


        }

        public int comprobarCasilla(String casillaTocada) // "2, 5" -> tag
        {
            int[] tocada = Array.ConvertAll(casillaTocada.Split(','), s => Int32.Parse(s));
            return filas[tocada[0]][tocada[1]];
        }


        public void recorrerTablero()
        {
            int valor = comprobarCasilla("2, 5");
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
