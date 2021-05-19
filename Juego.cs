using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatallaNaval
{
    public partial class Juego : Form
    {
        public TableLayoutPanel tabla;
        public Tablero tablero;
        List<Barco> barcos;
        Jugador jug = new Jugador();
        public bool replay = false;

        public Juego(TableLayoutPanel tabla, Tablero tablero, List<Barco> barcos)
        {
            Controls.Add(tabla);
            foreach (Control c in tabla.Controls)
            {
                PictureBox pb = c as PictureBox;
                if (pb != null)
                {
                    pb.BackColor = default;
                    RemoveClickEvent(pb);
                    pb.Click += new System.EventHandler(pictureBox1_Click);
                }
            }

            this.tabla = tabla;
            this.tablero = tablero;
            this.barcos = barcos;
            InitializeComponent();
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


        private void pictureBox1_Click(Object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            int [] casilla = tablero.ComprobarCasilla(pb.Tag.ToString());

            MessageBox.Show((casilla[0] + "," + casilla[1]).ToString());

            if(casilla[1] == -1) // No ha sido tocado
            {
                int estado = -1;
                if(casilla[0] == -1) // Ha tocado agua
                {
                    estado = 0;
                    tablero.CambiarEstado(pb.Tag.ToString(), estado);
                    MessageBox.Show("Ha tocado agua");
                    //Restar número de disparos del jugador
                    jug.RestarNumDisparos();
                    MessageBox.Show(jug.NumeroDisparos.ToString());
                    pb.BackColor = Color.Blue;
                    if (jug.NumeroDisparos == 0) Perder();
                }
                else // Ha tocado barco
                {
                    estado = 1;
                    tablero.CambiarEstado(pb.Tag.ToString(), estado);
                    estado = tablero.ComprobarTocadoHundido(casilla[0])?2:1;
                    if(estado == 2)
                    {
                        MessageBox.Show("Tocado y Hundido");
                    }
                    else
                    {
                        MessageBox.Show("Ha tocado un barco");
                    }
                    pb.BackColor = Color.Red;
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

        }

        public void Perder()
        {
            GameOver gameOver = new GameOver();
            gameOver.ShowDialog();
            replay = gameOver.replay;
            this.Close();
        }
        public void Ganar()
        {
            MessageBox.Show("Has ganado bro");
            foreach (Control c in tabla.Controls)
            {
                PictureBox pb = c as PictureBox;
                if (pb != null)
                {
                    RemoveClickEvent(pb);
                }
            }
            Win win = new Win();
            win.ShowDialog();
            replay = win.replay;
            this.Close();
        }
    }
}
