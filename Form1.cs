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
        Boolean isDragging = false;
        int currentX = 0;
        int currentY = 0;
        public Form1()
        {
            InitializeComponent();
        }


        private void pictureBox5_DragEnter(object sender, DragEventArgs e)
        {
            pictureBox5.BackColor = Color.Black;

        }

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;

            currentX = e.X;
            currentY = e.Y;
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                
                pictureBox5.Top = pictureBox5.Top + (e.Y - currentY);
                pictureBox5.Left = pictureBox5.Left + (e.X - currentX);
                label1.Text = e.Y + " " + currentY;
            }
        }

        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void tableLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void tableLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pb = e.Data as PictureBox;
            pb.Location = new Point(e.X, e.Y);
            tableLayoutPanel1.Controls.Add(pictureBox5);
        }
    }
}
