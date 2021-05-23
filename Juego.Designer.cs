
namespace BatallaNaval
{
    partial class Juego
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Juego));
            this.pb_music = new System.Windows.Forms.PictureBox();
            this.tb_volume = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pb_music)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_volume)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_music
            // 
            this.pb_music.Image = global::BatallaNaval.Properties.Resources.note2;
            this.pb_music.Location = new System.Drawing.Point(11, 544);
            this.pb_music.Name = "pb_music";
            this.pb_music.Size = new System.Drawing.Size(28, 50);
            this.pb_music.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_music.TabIndex = 10;
            this.pb_music.TabStop = false;
            this.pb_music.Click += new System.EventHandler(this.pb_music_Click);
            // 
            // tb_volume
            // 
            this.tb_volume.Location = new System.Drawing.Point(45, 558);
            this.tb_volume.Name = "tb_volume";
            this.tb_volume.Size = new System.Drawing.Size(104, 45);
            this.tb_volume.TabIndex = 9;
            this.tb_volume.ValueChanged += new System.EventHandler(this.tb_volume_ValueChanged);
            // 
            // Juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(231)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(998, 645);
            this.Controls.Add(this.pb_music);
            this.Controls.Add(this.tb_volume);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Juego";
            this.Text = "Juego";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Juego_FormClosing);
            this.Load += new System.EventHandler(this.Juego_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_music)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_volume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_music;
        private System.Windows.Forms.TrackBar tb_volume;
    }
}