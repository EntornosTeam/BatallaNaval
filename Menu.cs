using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace BatallaNaval
{
    public partial class Menu : Form
    {
        WindowsMediaPlayer music = new WindowsMediaPlayer();

        public bool startGame = false;
        public Menu()
        {
            InitializeComponent();
        }

        private void btn_jugar_Click(object sender, EventArgs e)
        {
            startGame = true;
            this.Close();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            music.URL = @"Sounds/One Piece Music.mp3";
            tb_volume.Value = 4;
        }

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

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            music.controls.stop();
        }
    }
}
