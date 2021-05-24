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
    public partial class Win : Form
    {
        public bool replay = false;
        PrivateFontCollection pFonts = new PrivateFontCollection();
        WindowsMediaPlayer music = new WindowsMediaPlayer();
        SoundPlayer sonidoMouse = new SoundPlayer("Sounds/mouse_over.wav");
        public Win()
        {
            InitializeComponent();
            pFonts.AddFontFile("../../Fonts/Pirate Ship.ttf");
            pFonts.AddFontFile("../../Fonts/ARMY RUST.ttf");
            btn_salir.Font = new Font(pFonts.Families[1], 12, FontStyle.Regular);
            btn_reintentar.Font = new Font(pFonts.Families[1], 12, FontStyle.Regular);
            lbl_victoria.Font = new Font(pFonts.Families[0], 70, FontStyle.Regular);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_reintentar_Click(object sender, EventArgs e)
        {
            replay = true;
            this.Close();
        }

        private void Win_Paint(object sender, PaintEventArgs e)
        {
            btn_salir.Font = new Font(pFonts.Families[1], 12, FontStyle.Regular);
            btn_reintentar.Font = new Font(pFonts.Families[1], 12, FontStyle.Regular);
            lbl_victoria.Font = new Font(pFonts.Families[0], 70, FontStyle.Regular);
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            sonidoMouse.Play();
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

        private void Win_Load(object sender, EventArgs e)
        {
            music.URL = "Sounds/victory.mp3";
            music.settings.volume = Volume.volumen;
        }

        private void Win_FormClosing(object sender, FormClosingEventArgs e)
        {
            music.controls.stop();
        }
    }
}
