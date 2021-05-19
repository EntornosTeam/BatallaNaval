using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatallaNaval
{
    public class Barco
    {
        //Variables generales

        private int size;
        private int id = 0;  //ID del barco.
        public static int lastId = -1;
        public static int numFragatas = 0;
        public static int numDestructores = 0;
        public static int numSubmarinos = 0;
        public static int numPortaaviones = 0;

        //Constantes

        //public const int MAXID = 9;  //Variable Final, Numero Final ID.
        public const int MAXFRAGATAS = 4;
        public const int MAXDESTRUCTORES = 3;
        public const int MAXSUBMARINOS = 2;
        public const int MAXPORTAAVIONES = 1;


        public int Size { get => size; set => size = value; }
        public int Id { get => id; set => id = value; }

        //private string orientacion;

        public Barco(int s)
        {
            //Gestión de Excepciones

            //if (lastId + 1 > MAXID) throw new Exception("Se ha excedido el número máximo de barcos");
            this.Size = s;
            switch (s)
            {
                case 1:
                    if(numFragatas + 1 > MAXFRAGATAS) throw new Exception("Se ha excedido el número máximo de fragatas.");
                    numFragatas++;
                    break;
                case 2:
                    if (numDestructores + 1 > MAXDESTRUCTORES) throw new Exception("Se ha excedido el número máximo de destructores.");
                    numDestructores++;
                    break;
                case 3:
                    if (numSubmarinos + 1 > MAXSUBMARINOS) throw new Exception("Se ha excedido el número máximo de submarinos.");
                    numSubmarinos++;
                    break;
                case 4:
                    if (numPortaaviones + 1 > MAXPORTAAVIONES) throw new Exception("Se ha excedido el número máximo de portaaviones.");
                    numPortaaviones++;
                    break;
                default:
                    throw new Exception("El tamaño es incorrecto.");
            }
            this.Id = ++lastId;
        }

        public static void ResetearNumeroBarcos()
        {
            numFragatas = 0;
            numDestructores = 0;
            numSubmarinos = 0;
            numPortaaviones = 0;
        }
    }
}
