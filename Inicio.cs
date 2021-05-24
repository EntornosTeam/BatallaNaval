using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace BatallaNaval
{
    public partial class Inicio : Form
    {
        public Tablero tablero;
        public List<Barco> barcos;
        public List<Bitmap> images = new List<Bitmap>() {
            Properties.Resources.Fragata,
            Properties.Resources.Crucero1, Properties.Resources.Crucero2,
            Properties.Resources.Submarino1, Properties.Resources.Submarino2, Properties.Resources.Submarino3,
            Properties.Resources.portaaviones1, Properties.Resources.portaaviones2, Properties.Resources.portaaviones3, Properties.Resources.portaaviones4};
        public List<Bitmap> imagesv = new List<Bitmap>() {
            Properties.Resources.Fragata,
            Properties.Resources.Crucero1, Properties.Resources.Crucero2,
            Properties.Resources.Submarino1, Properties.Resources.Submarino2, Properties.Resources.Submarino3,
            Properties.Resources.portaaviones1, Properties.Resources.portaaviones2, Properties.Resources.portaaviones3, Properties.Resources.portaaviones4};
        public bool play = false;
        WindowsMediaPlayer music = new WindowsMediaPlayer();
        SoundPlayer cambioTipo = new SoundPlayer("Sounds/mouse_over.wav");
        SoundPlayer ponerBarco = new SoundPlayer("Sounds/poner_barco.wav");
        SoundPlayer quitarBarco = new SoundPlayer("Sounds/quitar_barco.wav");
        SoundPlayer error = new SoundPlayer("Sounds/error.wav");

        public Inicio()
        {
            InitializeComponent();
            AssignTag();
            CreateTablero();
            cb_posicion.SelectedIndex = 0;
            barcos = new List<Barco>();
            foreach (Bitmap img in imagesv)
            {
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
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
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.BackgroundImageLayout = ImageLayout.Stretch;
                    pb.Tag = fila + "," + columna;
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
            music.URL = "Sounds\\Piratas del caribe BSO.mp3";
            tb_volume.Value = (int)Math.Sqrt(Volume.volumen);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 0)
            {
                error.Play();
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
                    // area trabajo
                    if (cb_posicion.SelectedIndex == 0) //Indice 0 = a Horizontal, Indice 1 = Vertical.
                    {
                        int y = 1; // si es 1, va a la derecha, si es -1, va a la izquierda
                        if ((columna - 1) + numCasillas > 9)
                        {
                            y = -1;
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
                                error.Play();
                                MessageBox.Show("Ya hay un barco en esa casilla");
                                return;
                            }
                            
                        }
                        int imagenBarco = 0;
                        
                        if (numCasillas == 2)
                        {
                            imagenBarco = 1;

                        }
                        else if (numCasillas == 3)
                        {
                            imagenBarco = 3;
                        }
                        else if (numCasillas == 4)
                        {
                            imagenBarco = 6;
                        }
                        if (y == -1) 
                        {
                            imagenBarco = imagenBarco + (numCasillas - 1);
                        }
                        
                        for (int x = 0; x < numCasillas; x++) // bucle pintar
                        {
                            
                            int filaActual = fila;
                            int columnaActual = columna + (x * y);
                            string tag = filaActual.ToString() + "," + columnaActual.ToString();
                            PictureBox pbPintar = ObtenerPictureBox(tag);
                            pbPintar.BackgroundImage = images[imagenBarco];
                            //pbPintar.BackColor = ObtenerColor(numCasillas);
                            tablero.CambiarValorCasilla(tag, new int[] { id, -1 });
                            imagenBarco = (y == -1)?imagenBarco-1:imagenBarco+1;
                            
                        }
                        Barco barco = new Barco(numCasillas);
                        RestarNumeroBarcos();
                        barcos.Add(barco);
                        ponerBarco.Play();
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
                        
                        int imagenBarco = 0;

                        if (numCasillas == 2)
                        {
                            imagenBarco = 1;

                        }
                        else if (numCasillas == 3)
                        {
                            imagenBarco = 3;
                        }
                        else if (numCasillas == 4)
                        {
                            imagenBarco = 6;
                        }
                        if (x == -1)
                        {
                            imagenBarco = imagenBarco + (numCasillas - 1);
                        }
                        for (int y = 0; y < numCasillas; y++) // bucle pintar
                        {
                            int filaActual = fila + (y * x);
                            int columnaActual = columna;
                            string tag = filaActual.ToString() + "," + columnaActual.ToString();
                            PictureBox pbPintar = ObtenerPictureBox(tag);
                            pbPintar.BackgroundImage = imagesv[imagenBarco];
                            //pbPintar.BackColor = ObtenerColor(numCasillas);
                            tablero.CambiarValorCasilla(tag, new int[] { id, -1 });
                            imagenBarco = (x == -1) ? imagenBarco - 1 : imagenBarco + 1;
                        }
                        Barco barco = new Barco(numCasillas);
                        RestarNumeroBarcos();
                        barcos.Add(barco);
                        ponerBarco.Play();
                        PoderEmpezar();
                    }
                    // area trabajo
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
            MessageBox.Show("No pilla coordenada");
            return null;
        }
        private void listView1_ColumnWidthChanging_1(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = listView1.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private bool ComprobarBarco(int size)
        {
            error.Play();
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
                casilla.BackgroundImage = null;
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
            quitarBarco.Play();
            PoderEmpezar();
        }

        private void btn_comenzar_Click(object sender, EventArgs e)
        {
            play = true;
            Barco.ResetearNumeroBarcos();
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

        // Music

        private void tb_volume_ValueChanged(object sender, EventArgs e)
        {
            Volume.volumen = (int)Math.Pow(tb_volume.Value, 2);
            music.settings.volume = Volume.volumen;
            if (music.settings.volume == 0)
            {
                pb_music.Image = Properties.Resources.note4;
            }
            else
            {
                pb_music.Image = Properties.Resources.note2;
            }
        }

        private void pb_music_Click(object sender, EventArgs e)
        {
            if (tb_volume.Value != 0)
            {
                Volume.lastVolumen = tb_volume.Value * 10;
                tb_volume.Value = 0;
            }
            else
            {
                if (Volume.lastVolumen != 0)
                {
                    tb_volume.Value = Volume.lastVolumen / 10;
                }
                else
                {
                    tb_volume.Value = 5;
                }
            }
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            music.controls.stop();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambioTipo.Play();
        }
    }
}
