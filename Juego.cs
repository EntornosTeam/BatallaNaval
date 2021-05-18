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

        public Juego(TableLayoutPanel tabla, Tablero tablero, List<Barco> barcos)
        {
            Controls.Add(tabla);
            foreach (Control c in tabla.Controls)
            {
                PictureBox pb = c as PictureBox;
                if (pb != null)
                {
                    RemoveClickEvent(pb);
                    pb.Click += new System.EventHandler(pictureBox1_Click);
                }
            }


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
            MessageBox.Show("Funciona jeje");
        }
    }
}
