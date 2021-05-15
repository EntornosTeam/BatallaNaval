using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatallaNaval
{
    public partial class Form1 : Form
    {
        Tablero tablero;
        List<Barco> barcos;
  
        public Form1()
        {
            InitializeComponent();
            AssignTag();
            CreateTablero();
            cb_posicion.SelectedIndex = 0;
            barcos = new List<Barco>();
        }

        private void AssignTag()
        {
            int fila = 9;
            int columna = 9;
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                PictureBox pb = c as PictureBox;
                if (pb != null)
                {
                    pb.Tag = fila + "," + columna;
                    // fila++;
                    if (columna == 0)
                    {
                        columna = 9;
                        fila--;
                    }
                    else
                    {
                        columna--;
                    }
                }
            }
            
        }

        private void CreateTablero()
        {
            tablero = new Tablero();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;

            int numCasillas = int.Parse(listView1.SelectedItems[0].SubItems[1].Text.ToString());//4; //Número de casillas que ocupa el Barco.

            int fila = int.Parse(pb.Tag.ToString().Split(',')[0]);

            int columna = int.Parse(pb.Tag.ToString().Split(',')[1]);

            //MessageBox.Show("Fila " + fila + " Columna " + columna);

            if(cb_posicion.SelectedIndex == 0) //Indice 0 = a Horizontal, Indice 1 = Vertical.
            {
                int y = 1; // si es 1, va a la derecha, si es -1, va a la izquierda
                if ((columna - 1) + numCasillas > 9)
                {
                    y = -1;
                    // MessageBox.Show("No se puede poner el barco");
                }
                int id = Barco.lastId + 1;
                if (!ComprobarBarco(numCasillas)) return;
                
                for (int x = 0; x < numCasillas; x++) // bucle comprobación casillas
                {
                    int filaActual = fila;
                    int columnaActual = columna + (x * y);
                    string tag = filaActual.ToString() + "," + columnaActual.ToString();
                    if (tablero.ComprobarCasilla(tag)[0] != -1)
                    {
                        MessageBox.Show("Ya hay un barco en esa casilla");
                        return;
                    }
                    PictureBox pbPintar = ObtenerPictureBox(tag);
                    pbPintar.BackColor = Color.Red;
                    tablero.CambiarValorCasilla(tag, new int[] {id, -1 });
                }

                for (int x = 0; x < numCasillas; x++) // bucle pintar
                {
                    int filaActual = fila;
                    int columnaActual = columna + (x * y);
                    string tag = filaActual.ToString() + "," + columnaActual.ToString();
                    PictureBox pbPintar = ObtenerPictureBox(tag);
                    if (numCasillas == 1)
                    {
                        // imagenFragata
                    }
                    else if (x == 0)
                    {
                        // imagenDelante
                    }
                    else if (x + 1 == numCasillas)
                    {
                        // imagenFin
                    }
                    else if (x > 1)
                    {
                        // imagenMedio
                    }
                    pbPintar.BackColor = Color.Red;
                    tablero.CambiarValorCasilla(tag, new int[] { id, -1 });
                }
                Barco barco = new Barco(numCasillas);
                barcos.Add(barco);
            } 
            else
            {
                int x = 1;
                if ((fila - 1) + numCasillas > 9) {
                    x = -1;
                }
                int id = Barco.lastId + 1;
                if (!ComprobarBarco(numCasillas)) return;
                for (int y = 0; y < numCasillas; y++) // bucle comprobación casillas
                {
                    int filaActual = fila+(y * x);
                    int columnaActual = columna;
                    string tag = filaActual.ToString() + "," + columnaActual.ToString();
                    if (tablero.ComprobarCasilla(tag)[0] != -1)
                    {
                        MessageBox.Show("Ya hay un barco en esa casilla");
                        return;
                    }
                }
                // [imagenDelante, imagenMedio, imagenFin], [imagenFragata]
                for (int y = 0; y < numCasillas; y++) // bucle pintar
                {
                    int filaActual = fila + (y * x);
                    int columnaActual = columna;
                    string tag = filaActual.ToString() + "," + columnaActual.ToString();
                    PictureBox pbPintar = ObtenerPictureBox(tag);

                    if (numCasillas == 1)
                    {
                        // imagenFragata
                    } 
                    else if (y == 0)
                    {
                        // imagenDelante
                    }
                    else if (y + 1 == numCasillas)
                    {
                        // imagenFin
                    } 
                    else if (y > 1)
                    {
                        // imagenMedio
                    }
                    pbPintar.BackColor = Color.Red;
                    tablero.CambiarValorCasilla(tag, new int[] { id, -1 });
                }
                Barco barco = new Barco(numCasillas);
                barcos.Add(barco);
            }
        }



        private PictureBox ObtenerPictureBox(String coordenadas)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                PictureBox pb = c as PictureBox;
                if (pb != null)
                {
                    if (pb.Tag.Equals(coordenadas)) return pb;
                }
            }
            //mes
            MessageBox.Show("No pilla coordenada");
            return null;
        }
        private void listView1_ColumnWidthChanging_1(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.listView1.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private bool ComprobarBarco(int size)
        {
            if (Barco.lastId + 1 > Barco.MAXID)
            {
                MessageBox.Show("Se ha excedido el número máximo de barcos");
                return false;
            }
            else 
            {
                switch (size)
                {
                    case 1:
                        if (Barco.numFragatas + 1 > Barco.MAXFRAGATAS)
                        {
                            MessageBox.Show("Se ha excedido el número máximo de fragatas.");
                            return false;
                        }
                        break;
                    case 2:
                        if (Barco.numDestructores + 1 > Barco.MAXDESTRUCTORES)
                        {
                            MessageBox.Show("Se ha excedido el número máximo de destructores.");
                            return false;
                        }

                        break;
                    case 3:
                        if (Barco.numSubmarinos + 1 > Barco.MAXSUBMARINOS)
                        {
                            MessageBox.Show("Se ha excedido el número máximo de submarinos.");
                            return false;
                        }

                        break;
                    case 4:
                        if (Barco.numPortaaviones + 1 > Barco.MAXPORTAAVIONES)
                        {
                            MessageBox.Show("Se ha excedido el número máximo de portaaviones.");
                            return false;
                        }

                        break;
                    default:
                        MessageBox.Show("El tamaño es incorrecto.");
                        return false;
                }
                return true;
            }
        }
    }
}
