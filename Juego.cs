using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace BatallaNaval
{
    public partial class Juego : Form
    {
        public TableLayoutPanel tabla;
        public Tablero tablero;
        List<Barco> barcos;
        Jugador jug = new Jugador();
        public bool replay = false;
        WindowsMediaPlayer music = new WindowsMediaPlayer();
        SoundPlayer disparo_agua = new SoundPlayer("Sounds/disparo_agua.wav");
        SoundPlayer sonidoTocado = new SoundPlayer("Sounds/explosion1.wav");
        SoundPlayer sonidoHundido = new SoundPlayer("Sounds/explosion2.wav");

        public Juego(TableLayoutPanel tabla, Tablero tablero, List<Barco> barcos)
        {
            InitializeComponent();
            Controls.Add(tabla);
            foreach (Control c in tabla.Controls)
            {
                PictureBox pb = c as PictureBox;
                if (pb != null)
                {

                    pb.Image = Properties.Resources.fondo;
                    RemoveClickEvent(pb);
                    pb.Click += new System.EventHandler(pictureBox1_Click);
                }
            }

            this.tabla = tabla;
            this.tablero = tablero;
            this.barcos = barcos;
            ActualizarIntentos();
        }

        /// <summary>
        /// Crea una lista con los eventos clicks del Picturebox enviado, y los elimina.
        /// </summary>
        /// <param name="pb">El PictureBox del que queremos que se eliminen los eventos click</param>
        private void RemoveClickEvent(PictureBox pb)
        {
            FieldInfo f1 = typeof(Control).GetField("EventClick",
                BindingFlags.Static | BindingFlags.NonPublic);

            object obj = f1.GetValue(pb);
            PropertyInfo pi = pb.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);

            EventHandlerList list = (EventHandlerList)pi.GetValue(pb, null);
            list.RemoveHandler(obj, list[obj]);
        }


        private void ActualizarIntentos()
        {
            int i = 0;
            foreach (Control c in flp_intentos.Controls)
            {
                PictureBox pb = c as PictureBox;
                if (pb != null)
                {
                    if (i < jug.NumeroDisparos)
                    {
                        pb.Image = Properties.Resources.cannonball;
                    }
                    else
                    {
                        pb.Image = null;
                    }
                    i++;
                }
            }
        }

        private void pictureBox1_Click(Object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            int[] casilla = tablero.ComprobarCasilla(pb.Tag.ToString());

            //MessageBox.Show((casilla[0] + "," + casilla[1]).ToString());

            if(casilla[1] == -1) // No ha sido tocado
            {
                int estado = -1;
                if(casilla[0] == -1) // Ha tocado agua
                {
                    estado = 0;
                    tablero.CambiarEstado(pb.Tag.ToString(), estado);
                    disparo_agua.Play();
                    jug.RestarNumDisparos();
                    pb.Image = Properties.Resources.water;
                    if (jug.NumeroDisparos == 0) Perder();
                }
                else // Ha tocado barco
                {
                    estado = 1;
                    tablero.CambiarEstado(pb.Tag.ToString(), estado);
                    estado = tablero.ComprobarTocadoHundido(casilla[0])?2:1;
                    if(estado == 2) //Barco Hundido
                    {
                        int barcoId = tablero.ComprobarCasilla(pb.Tag.ToString())[0];
                        foreach (Control c in tabla.Controls)
                        {
                            PictureBox pbComprobar = c as PictureBox;
                            if (pbComprobar != null)
                            {
                                if (tablero.ComprobarCasilla(pbComprobar.Tag.ToString())[0] == barcoId)
                                {
                                    pbComprobar.Image = null;
                                }
                            }
                        }
                        sonidoHundido.Play();
                        jug.RecuperarDisparos();
                        pb.Image = null;
                    }
                    else //Barco tocado
                    {
                        sonidoTocado.Play();
                        pb.Image = Properties.Resources.cross;

                    }
                    if (tablero.ComprobarVictoria())
                    {
                        Ganar();
                    }
                }
                
                
            }
            else // Ya ha sido tocado
            {
                MessageBox.Show("Esta casilla ya ha sido tocada");
            }
            ActualizarIntentos();
        }

        public void Perder()
        {
            music.controls.stop();
            ActualizarIntentos();
            GameOver gameOver = new GameOver();
            gameOver.ShowDialog();
            replay = gameOver.replay;
            this.Close();
        }
        public void Ganar()
        {
            ActualizarIntentos();
            foreach (Control c in tabla.Controls)
            {
                PictureBox pb = c as PictureBox;
                if (pb != null)
                {
                    RemoveClickEvent(pb);
                }
            }
            music.controls.stop();
            Win win = new Win();
            win.ShowDialog();
            replay = win.replay;
            this.Close();
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

        private void Juego_Load(object sender, EventArgs e)
        {
            music.URL = "Sounds/Sword of Destiny.mp3";
            tb_volume.Value = (int)Math.Sqrt(Volume.volumen);
        }
    }
}
