using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace BatallaNaval
{
    public partial class GameOver : Form
    {

        PrivateFontCollection pFonts = new PrivateFontCollection();
        public bool replay = false;
        WindowsMediaPlayer music = new WindowsMediaPlayer();

        public GameOver()
        {
            InitializeComponent();
            pFonts.AddFontFile("../../Fonts/Pirate Ship.ttf");
            pFonts.AddFontFile("../../Fonts/ARMY RUST.ttf");
            btn_salir.Font = new Font(pFonts.Families[1], 12, FontStyle.Regular);
            btn_reintentar.Font = new Font(pFonts.Families[1], 12, FontStyle.Regular);
            lbl_derrota.Font = new Font(pFonts.Families[0], 79, FontStyle.Regular);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_reintentar_Click(object sender, EventArgs e)
        {
            replay = true;
            this.Close();
        }

        private void GameOver_Paint(object sender, PaintEventArgs e)
        {
            btn_salir.Font = new Font(pFonts.Families[1], 12, FontStyle.Regular);
            lbl_derrota.Font = new Font(pFonts.Families[0], 79, FontStyle.Regular);
            btn_reintentar.Font = new Font(pFonts.Families[1], 12, FontStyle.Regular);
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Black;
            btn.ForeColor = Color.White;
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            music.URL = "Sounds/defeat.mp3";
            music.settings.volume = Volume.volumen;
        }

        private void GameOver_FormClosing(object sender, FormClosingEventArgs e)
        {
            music.controls.stop();
        }
    }
}
