using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatallaNaval
{
    public class Tablero
    {
        List<List<int[]>> filas;

        public Tablero()
        {
            filas = new List<List <int[]>>() { };

            for (int i = 0; i < 10; i++)
            {
                List<int[]> columnas = new List<int[]>();
                for (int j = 0; j< 10; j++)
                {
                    columnas.Add(new int[] { -1, -1 });
                }
                filas.Add(columnas);
            }
            ComprobarCasilla("2,3");
            
        }

        /*///////////////////////////////////////////////////////////////////////////////
        / Notas: los valores de las casillas funcionan de la siguiente manera:          /
        /           En el índice 0: ->  0 a 9 idBarco                                   /
        /                           -> -1 agua                                          /
        /           En el índice 1: el estado de la casilla -> -1 no tocado             /
        /                                                       0 disparo a agua        /
        /                                                       1 tocado                /
        /                                                       2 hundido               /
        *////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Comprueba una casilla mediante un string ej."2,5"
        /// </summary>
        /// <param name="casillaTocada"></param>
        /// <returns>Devuelve el valor de la casilla solicitada. Indice 0 = id del barco, o -1 si es agua. Indice 1 = estado de la casilla</returns>
        public int[] ComprobarCasilla(String casillaTocada) // "2,5" -> tag
        {
            int[] tocada = Array.ConvertAll(casillaTocada.Split(','), s => Int32.Parse(s));
            return filas[tocada[0]][tocada[1]];
        }


        /// <summary>
        /// Cambia el valor de una casilla mediante un string ej."2,5" y su nuevo valor int[]
        /// </summary>
        /// <param name="casillaTocada"></param>
        /// <returns>Devuelve el valor de la casilla solicitada. Indice 0 = id del barco, o -1 si es agua. Indice 1 = estado de la casilla</returns>
        public void CambiarValorCasilla(String casilla, int[] nuevoValor) // "2,5" -> tag
        {
            int[] cas = Array.ConvertAll(casilla.Split(','), s => Int32.Parse(s));
            filas[cas[0]][cas[1]] = nuevoValor;
            return;
        }

        public void CambiarEstado(String casilla, int estado)
        {
            int[] cas = Array.ConvertAll(casilla.Split(','), s => Int32.Parse(s));
            int[] casRef = filas[cas[0]][cas[1]];
            casRef[1] = estado;
            return;
        }
        /// <summary>
        /// Recorre el arraylist de barcos y comprueba si los barcos del id indicado están tocados. Si todos han sido tocados los marca como hundido.
        /// </summary>
        /// <param name="id">Id del barco</param>
        /// <returns>True si está hundido</returns>
        public bool ComprobarTocadoHundido(int id) 
        {
            bool hundido = true;
            foreach (List<int[]> fila in filas)
            {
                foreach (int[] casilla in fila)
                {
                    if (casilla[0] == id)
                    {
                        if (casilla[1] == -1) hundido = false;
                    }

                }
            }
            if (hundido)
            {
                foreach (List<int[]> fila in filas)
                {
                    foreach (int[] casilla in fila)
                    {
                        if (casilla[0] == id)
                        {
                            casilla[1] = 2;
                        }

                    }
                }
            }
            
            return hundido;
        }

    }
}
