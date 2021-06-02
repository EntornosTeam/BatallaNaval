using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
        public List<Bitmap> imagest = new List<Bitmap>() {
            Properties.Resources.Fragatat,
            Properties.Resources.Crucero1t, Properties.Resources.Crucero2t,
            Properties.Resources.Submarino1t, Properties.Resources.Submarino2t, Properties.Resources.Submarino3t,
            Properties.Resources.portaaviones1t, Properties.Resources.portaaviones2t, Properties.Resources.portaaviones3t, Properties.Resources.portaaviones4t};
        public List<Bitmap> imagesvt = new List<Bitmap>() {
            Properties.Resources.Fragatat,
            Properties.Resources.Crucero1t, Properties.Resources.Crucero2t,
            Properties.Resources.Submarino1t, Properties.Resources.Submarino2t, Properties.Resources.Submarino3t,
            Properties.Resources.portaaviones1t, Properties.Resources.portaaviones2t, Properties.Resources.portaaviones3t, Properties.Resources.portaaviones4t};
        public bool play = false;
        public bool prePintado = false;
        public List<PictureBox> barcoPrePintado = new List<PictureBox>();
        WindowsMediaPlayer music = new WindowsMediaPlayer();
        SoundPlayer cambioTipo = new SoundPlayer("Sounds/mouse_over.wav");
        SoundPlayer ponerBarco = new SoundPlayer("Sounds/poner_barco.wav");
        SoundPlayer quitarBarco = new SoundPlayer("Sounds/quitar_barco.wav");
        SoundPlayer error = new SoundPlayer("Sounds/error.wav");
        PrivateFontCollection pFonts = new PrivateFontCollection();

        public Inicio()
        {
            InitializeComponent();
            pFonts.AddFontFile("../../Fonts/Pirate Ship.ttf");
            AssignTag();
            CreateTablero();
            cb_posicion.SelectedIndex = 0;
            barcos = new List<Barco>();
            foreach (Bitmap img in imagesv)
            {
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            foreach (Bitmap img in imagesvt)
            {
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            btn_comenzar.Font = new Font(pFonts.Families[0], 12, FontStyle.Regular);
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

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                this.Cursor = Cursors.No;
                return;
            }
            else
            {

                PictureBox pb = sender as PictureBox;

                int numCasillas = int.Parse(listView1.SelectedItems[0].SubItems[1].Text.ToString()); //Número de casillas que ocupa el Barco.


                int fila = int.Parse(pb.Tag.ToString().Split(',')[0]);

                int columna = int.Parse(pb.Tag.ToString().Split(',')[1]);

                if (tablero.ComprobarCasilla(fila + "," + columna)[0] != -1) // Hover en barco
                {
                    this.Cursor = new Cursor(Properties.Resources.trash.Handle); ;
                    return;
                }
                else // Click en casilla vacía
                {
                    bool horizontal = cb_posicion.SelectedIndex == 0;
                    int d = ((horizontal && (columna - 1) + numCasillas > 9) || (!horizontal && (fila - 1) + numCasillas > 9)) ? -1 : 1; // si es 1, va a la derecha, si es -1, va a la izquierda
                    bool otroLadoProbado = false;
                    if (!ComprobarBarco(numCasillas, false))
                    {
                        this.Cursor = Cursors.No;
                        return;
                    }
                    this.Cursor = Cursors.Hand;
                    for (int x = 0; x < numCasillas; x++) // bucle comprobación casillas
                    {
                        int filaActual = (horizontal) ? fila : fila + (x * d); // desplazamiento vertical
                        int columnaActual = (horizontal) ? columna + (x * d) : columna; // desplazamiento horizontal
                        string tag = filaActual.ToString() + "," + columnaActual.ToString();
                        if (filaActual < 0 || columnaActual < 0) // Se sale por la izquierda o arriba
                        {
                            this.Cursor = Cursors.No;
                            return;
                        }
                        if (tablero.ComprobarCasilla(tag)[0] != -1) // Se encuentra un barco
                        {
                            if (!otroLadoProbado && d != -1) // primer barco
                            {
                                otroLadoProbado = true;
                                x = 0;
                                d = -1;
                            }
                            else
                            {
                                this.Cursor = Cursors.No;
                                return;
                            }
                        }

                    }

                    int imagenBarco = 0;

                    switch (numCasillas) // Obtener el primer índice de las imágenes del barco seleccionado
                    {
                        case 2:
                            imagenBarco = 1;
                            break;
                        case 3:
                            imagenBarco = 3;
                            break;
                        case 4:
                            imagenBarco = 6;
                            break;
                    }
                    if (d == -1) imagenBarco = imagenBarco + (numCasillas - 1);

                    for (int x = 0; x < numCasillas; x++) // bucle pintar
                    {
                        int filaActual = (horizontal) ? fila : fila + (x * d); // desplazamiento vertical
                        int columnaActual = (horizontal) ? columna + (x * d) : columna; // desplazamiento horizontal
                        string tag = filaActual.ToString() + "," + columnaActual.ToString();
                        PictureBox pbPintar = ObtenerPictureBox(tag);
                        pbPintar.BackgroundImage = (horizontal) ? imagest[imagenBarco] : imagesvt[imagenBarco];
                        //pbPintar.BackColor = ObtenerColor(numCasillas);
                        imagenBarco = (d == -1) ? imagenBarco - 1 : imagenBarco + 1;
                        barcoPrePintado.Add(pbPintar);
                    }
                    prePintado = true;
                }
            }
        }


        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

            this.Cursor = Cursors.Default;
            if (!prePintado) return;
            foreach (PictureBox pbPintar in barcoPrePintado)
            {
                pbPintar.BackgroundImage = null;
            }
            barcoPrePintado.Clear();
            prePintado = false;
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

                int numCasillas = int.Parse(listView1.SelectedItems[0].SubItems[1].Text.ToString()); //Número de casillas que ocupa el Barco.


                int fila = int.Parse(pb.Tag.ToString().Split(',')[0]);

                int columna = int.Parse(pb.Tag.ToString().Split(',')[1]);

                if (tablero.ComprobarCasilla(fila + "," + columna)[0] != -1) // Click en barco
                {
                    int idBarco = tablero.ComprobarCasilla(fila + "," + columna)[0];
                    EliminaBarco(idBarco);
                    this.Cursor = Cursors.Hand;
                }
                else // Click en casilla vacía
                {
                    bool horizontal = cb_posicion.SelectedIndex == 0;
                    int d = ((horizontal && (columna - 1) + numCasillas > 9) || (!horizontal && (fila - 1) + numCasillas > 9)) ? -1 : 1; // si es 1, va a la derecha, si es -1, va a la izquierda
                    bool otroLadoProbado = false;
                    int id = Barco.lastId + 1;
                    if (!ComprobarBarco(numCasillas, true)) return;

                    for (int x = 0; x < numCasillas; x++) // bucle comprobación casillas
                    {
                        int filaActual = (horizontal) ? fila : fila + (x * d); // desplazamiento vertical
                        int columnaActual = (horizontal) ? columna + (x * d) : columna; // desplazamiento horizontal
                        string tag = filaActual.ToString() + "," + columnaActual.ToString();
                        if (filaActual < 0 || columnaActual < 0) // Se sale por la izquierda
                        {
                            error.Play();
                            MessageBox.Show("No cabe el barco en la casilla seleccionada!");
                            return;
                        }
                        if (tablero.ComprobarCasilla(tag)[0] != -1) // Se encuentra un barco
                        {
                            if (!otroLadoProbado && d != -1) // primer barco
                            {
                                otroLadoProbado = true;
                                x = 0;
                                d = -1;
                            } 
                            else
                            {
                                error.Play();
                                MessageBox.Show("No cabe el barco en la casilla seleccionada!");
                                return;
                            }
                        }
                            
                    }
                    int imagenBarco = 0;

                    switch (numCasillas) // Obtener el primer índice de las imágenes del barco seleccionado
                    {
                        case 2:
                            imagenBarco = 1;
                            break;
                        case 3:
                            imagenBarco = 3;
                            break;
                        case 4:
                            imagenBarco = 6;
                            break;
                    }
                    if (d == -1) imagenBarco = imagenBarco + (numCasillas - 1);
                        
                    for (int x = 0; x < numCasillas; x++) // bucle pintar
                    {
                        int filaActual = (horizontal) ? fila : fila + (x * d); // desplazamiento vertical
                        int columnaActual = (horizontal) ? columna + (x * d) : columna; // desplazamiento horizontal
                        string tag = filaActual.ToString() + "," + columnaActual.ToString();
                        PictureBox pbPintar = ObtenerPictureBox(tag);
                        pbPintar.BackgroundImage = (horizontal)?images[imagenBarco]:imagesv[imagenBarco];
                        //pbPintar.BackColor = ObtenerColor(numCasillas);
                        tablero.CambiarValorCasilla(tag, new int[] { id, -1 });
                        imagenBarco = (d == -1) ? imagenBarco-1 : imagenBarco+1;
                            
                    }
                    Barco barco = new Barco(numCasillas);
                    RestarNumeroBarcos();
                    barcos.Add(barco);
                    ponerBarco.Play();
                    PoderEmpezar();
                    prePintado = false;
                    barcoPrePintado.Clear();
                    this.Cursor = new Cursor(Properties.Resources.trash.Handle);
                }
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

            listView1.Items[0].SubItems[2].ForeColor = (numFragatas == 0) ? Color.Red : Color.Black;
            listView1.Items[1].SubItems[2].ForeColor = (numDestructores == 0) ? Color.Red : Color.Black;
            listView1.Items[2].SubItems[2].ForeColor = (numSubmarinos == 0) ? Color.Red : Color.Black;
            listView1.Items[3].SubItems[2].ForeColor = (numPortaaviones == 0) ? Color.Red : Color.Black;
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

        private bool ComprobarBarco(int size, bool showError)
        {
            switch (size)
            {
                case 1:
                    if (Barco.numFragatas + 1 > Barco.MAXFRAGATAS)
                    {
                        if (showError)
                        {
                            error.Play();
                            MessageBox.Show("Se ha excedido el número máximo de fragatas.");
                        }
                        return false;
                    }
                    break;
                case 2:
                    if (Barco.numDestructores + 1 > Barco.MAXDESTRUCTORES)
                    {
                        if (showError)
                        {
                            error.Play();
                            MessageBox.Show("Se ha excedido el número máximo de destructores.");
                        }
                        return false;
                    }
                    break;
                case 3:
                    if (Barco.numSubmarinos + 1 > Barco.MAXSUBMARINOS)
                    {
                        if (showError)
                        {
                            error.Play();
                            MessageBox.Show("Se ha excedido el número máximo de submarinos.");
                        }
                        return false;
                    }

                    break;
                case 4:
                    if (Barco.numPortaaviones + 1 > Barco.MAXPORTAAVIONES)
                    {
                        if (showError)
                        {
                            error.Play();
                            MessageBox.Show("Se ha excedido el número máximo de portaaviones.");
                        }
                        return false;
                    }

                    break;
                default:
                    throw new Exception("El tamaño es incorrecto");
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

        private void btn_comenzar_MouseEnter(object sender, EventArgs e)
        {
            cambioTipo.Play();
            btn_comenzar.BackColor = Color.Black;
            btn_comenzar.ForeColor = Color.White;
        }

        private void btn_comenzar_MouseLeave(object sender, EventArgs e)
        {
            btn_comenzar.BackColor = Color.White;
            btn_comenzar.ForeColor = Color.Black;
        }

        private void cb_posicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambioTipo.Play();
        }

       
    }
}
