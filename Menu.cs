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
            music.settings.volume = 30;
            
        }
    }
}
