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

            int num_casillas = 4;

            int fila = int.Parse(pb.Tag.ToString().Split(',')[0]);

            int columna = int.Parse(pb.Tag.ToString().Split(',')[1]);

            MessageBox.Show("Fila " + fila + " Columna " + columna);

            if(cb_posicion.SelectedIndex == 0) //Indice 0 = a Horizontal, Indice 1 = Vertical.
            {
                int y = 1; // si es 1, va a la derecha, si es -1, va a la izquierda
                if ((columna - 1) + num_casillas > 9)
                {
                    y = -1;
                    // MessageBox.Show("No se puede poner el barco");
                }
                for (int x = 0; x < num_casillas; x++)
                {
                    int filaActual = fila;
                    int columnaActual = columna + (x * y);
                    string tag = filaActual.ToString() + "," + columnaActual.ToString();
                    PictureBox pbPintar = ObtenerPictureBox(tag);
                    pbPintar.BackColor = Color.Red;
                    Barco barco = new Barco(size);
                    tablero.CambiarValorCasilla(tag, new int[] { barco.id, -1 });
                }
            } else
            {
                int x = 1;
                if ((fila - 1) + num_casillas > 9) {
                    x = -1;
                }
                for (int y = 0; y < num_casillas; y++)
                {

                    PictureBox pbPintar = ObtenerPictureBox((fila+(y*x)).ToString() + "," + columna.ToString());
                    pbPintar.BackColor = Color.Red;
                }

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
    }
}
