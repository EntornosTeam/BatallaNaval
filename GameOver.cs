﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatallaNaval
{
    public partial class GameOver : Form
    {

        PrivateFontCollection pFonts = new PrivateFontCollection();
        public bool replay = false;

        public GameOver()
        {
            InitializeComponent();
            pFonts.AddFontFile("../../Fonts/Pirate Ship.ttf");
            pFonts.AddFontFile("../../Fonts/ARMY RUST.ttf");
            btn_salir.Font = new Font(pFonts.Families[0], 15, FontStyle.Regular);
            btn_reintentar.Font = new Font(pFonts.Families[0], 15, FontStyle.Regular);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            lbl_derrota.Font = new Font(pFonts.Families[1], 70, FontStyle.Regular);
        }

        private void btn_reintentar_Click(object sender, EventArgs e)
        {
            replay = true;
            this.Close();
        }

        private void GameOver_Paint(object sender, PaintEventArgs e)
        {
            btn_salir.Font = new Font(pFonts.Families[0], 15, FontStyle.Regular);
            lbl_derrota.Font = new Font(pFonts.Families[1], 70, FontStyle.Regular);
            btn_reintentar.Font = new Font(pFonts.Families[0], 15, FontStyle.Regular);
        }

        private void btn_salir_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Black;
            btn.ForeColor = Color.White;
        }

        private void btn_salir_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
        }
    }
}
