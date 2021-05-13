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
        public Form1()
        {
            InitializeComponent();
            AssignTag();
            CreateTablero();
        }

        private void AssignTag()
        {
            int fila = 0;
            int columna = 0;
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                PictureBox pb = c as PictureBox;
                if (pb != null)
                {
                    pb.Tag = fila + "," + columna;
                    // fila++;
                    if (columna == 9)
                    {
                        columna = 1;
                        fila++;
                    }
                    else
                    {
                        columna++;
                    }
                    listBox1.Items.Add(pb.Tag);
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

        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
            {
                
            }

        }
    }
}
