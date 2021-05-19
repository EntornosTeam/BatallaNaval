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
    public partial class Inicio : Form
    {
        public Tablero tablero;
        public List<Barco> barcos;
        public List<Bitmap> images = new List<Bitmap>();
        
        public Inicio()
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
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Debes seleccionar un barco.");
            }
            else
            {
                
                PictureBox pb = sender as PictureBox;

                int numCasillas = int.Parse(listView1.SelectedItems[0].SubItems[1].Text.ToString());//4; //Número de casillas que ocupa el Barco.

                int fila = int.Parse(pb.Tag.ToString().Split(',')[0]);

                int columna = int.Parse(pb.Tag.ToString().Split(',')[1]);

               if (tablero.ComprobarCasilla(fila + "," + columna)[0] != -1/* && tablero.ComprobarCasilla(fila + "," + columna)[0] == listView1.SelectedItems[0]*/)
                {
                    int idBarco = tablero.ComprobarCasilla(fila + "," + columna)[0];
                    EliminaBarco(idBarco);
                }
                else
                {

                    //Aqui se abre el else de quitar los barcos.

                    //MessageBox.Show("Fila " + fila + " Columna " + columna);

                    if (cb_posicion.SelectedIndex == 0) //Indice 0 = a Horizontal, Indice 1 = Vertical.
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
                            pbPintar.BackColor = ObtenerColor(numCasillas);
                            tablero.CambiarValorCasilla(tag, new int[] { id, -1 });

                        }
                        Barco barco = new Barco(numCasillas);
                        RestarNumeroBarcos();
                        barcos.Add(barco);
                        PoderEmpezar();
                        
                    }
                    else
                    {
                        int x = 1;
                        if ((fila - 1) + numCasillas > 9)
                        {
                            x = -1;
                        }
                        int id = Barco.lastId + 1;
                        if (!ComprobarBarco(numCasillas)) return;
                        for (int y = 0; y < numCasillas; y++) // bucle comprobación casillas
                        {
                            int filaActual = fila + (y * x);
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
                            pbPintar.BackColor = ObtenerColor(numCasillas);
                            tablero.CambiarValorCasilla(tag, new int[] { id, -1 });
                        }
                        Barco barco = new Barco(numCasillas);
                        RestarNumeroBarcos();
                        barcos.Add(barco);          
                        PoderEmpezar();
                    }

                }
                //Aquí se cierra el else de borrar los barcos.
            }
        }

        private void RestarNumeroBarcos()
        {
            //Obtenemos el número de barcos actuales del ListView.

            int numFragatas = Barco.MAXFRAGATAS - Barco.numFragatas;
            int numDestructores = Barco.MAXDESTRUCTORES - Barco.numDestructores;
            int numSubmarinos = Barco.MAXSUBMARINOS - Barco.numSubmarinos;
            int numPortaaviones = Barco.MAXPORTAAVIONES - Barco.numPortaaviones;
           
            //Asignamos las variables al texto de cada Item del ListView

            listView1.Items[0].SubItems[2].Text = numFragatas.ToString();
            listView1.Items[1].SubItems[2].Text = numDestructores.ToString();
            listView1.Items[2].SubItems[2].Text = numSubmarinos.ToString();
            listView1.Items[3].SubItems[2].Text = numPortaaviones.ToString();

            //Si la cantidad de algún barco es igual a 0 el Forecolor se cambiará a rojo si no el Forecolor cambiará a negro.

            if (numFragatas == 0)
            {
                listView1.Items[0].SubItems[2].ForeColor = Color.Red;
            }
            else
            {
                listView1.Items[0].SubItems[2].ForeColor = Color.Black;
            }
            if (numDestructores == 0) 
            {
                listView1.Items[1].SubItems[2].ForeColor = Color.Red;
            } 
            else
            {
                listView1.Items[1].SubItems[2].ForeColor = Color.Black;
            }
            if (numSubmarinos == 0)
            {
                listView1.Items[2].SubItems[2].ForeColor = Color.Red;
            }
            else
            {
                listView1.Items[2].SubItems[2].ForeColor = Color.Black;
            }
            if (numPortaaviones == 0)
            {
                listView1.Items[3].SubItems[2].ForeColor = Color.Red;
            }
            else
            {
                listView1.Items[3].SubItems[2].ForeColor = Color.Black;
            }
        }
        private Color ObtenerColor(int num_casillas)
        {
            Color color = default;

            //Hacemos un switch de ese número de casillas, dependiendo de el número de casillas retornará un color u otro.
            switch(num_casillas)
            {
                case 1:
                    color = Color.Blue;
                    break;
                case 2:
                    color = Color.Green;
                    break;
                case 3:
                    color = Color.Yellow;
                    break;
                case 4:
                    color = Color.Red;
                    break;
                default:
                    throw new Exception("Número de casillas no válidas");
            }

            return color;
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
           /* if (Barco.lastId + 1 > Barco.MAXID)
            {
                MessageBox.Show("Se ha excedido el número máximo de barcos");
                return false;
            }*/
            /*else 
            {*/
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
            //}
        }

        private void EliminaBarco(int id)
        {
            //Creamos un Array List que contendrá los picturebox que tengan el id del barco que se le pasa al método.
            List<PictureBox> casillas = new List<PictureBox>();
            foreach (Control c in tableLayoutPanel1.Controls)
            {

                PictureBox picture = c as PictureBox;

                if(picture != null)
                {
                    int idPicture = tablero.ComprobarCasilla(picture.Tag.ToString())[0];

                    if (idPicture == id)
                    {
                        casillas.Add(picture);
                        tablero.CambiarValorCasilla(picture.Tag.ToString(), new int[] { -1, -1 });
                    }
                }
            }

            foreach(PictureBox casilla in casillas)
            {
                casilla.BackColor = DefaultBackColor;
            }

            int barcoSize = casillas.Count();

            switch(barcoSize)
            {
                case 1:
                    Barco.numFragatas--;
                    break;
                case 2:
                    Barco.numDestructores--;
                    break;
                case 3:
                    Barco.numSubmarinos--;
                    break;
                case 4:
                    Barco.numPortaaviones--;
                    break;
                default:
                    throw new Exception("Número de casillas inválido");
            }
            RestarNumeroBarcos();
            Barco barco = null;
            foreach (Barco b in barcos)
            {
                if(b.Id == id)
                {
                    barco = b;
                }

            }
            barcos.Remove(barco);
            PoderEmpezar();
        }

        private void btn_comenzar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PoderEmpezar()
        {
            bool listo = true;
            foreach (ListViewItem item in listView1.Items)
            {
                if (int.Parse(item.SubItems[2].Text) != 0) listo = false;
            }
            btn_comenzar.Enabled = listo;
        }
    }
}
