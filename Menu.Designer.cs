
namespace BatallaNaval
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btn_jugar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.tb_volume = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pb_music = new System.Windows.Forms.PictureBox();
            this.lbl_hundir = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tb_volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_music)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_jugar
            // 
            this.btn_jugar.BackColor = System.Drawing.Color.White;
            this.btn_jugar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_jugar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_jugar.FlatAppearance.BorderSize = 0;
            this.btn_jugar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_jugar.Location = new System.Drawing.Point(66, 310);
            this.btn_jugar.Name = "btn_jugar";
            this.btn_jugar.Size = new System.Drawing.Size(132, 64);
            this.btn_jugar.TabIndex = 0;
            this.btn_jugar.Text = "Jugar";
            this.btn_jugar.UseVisualStyleBackColor = false;
            this.btn_jugar.Click += new System.EventHandler(this.btn_jugar_Click);
            this.btn_jugar.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btn_jugar.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.White;
            this.btn_salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_salir.FlatAppearance.BorderSize = 0;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Location = new System.Drawing.Point(262, 310);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(132, 64);
            this.btn_salir.TabIndex = 1;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            this.btn_salir.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btn_salir.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // tb_volume
            // 
            this.tb_volume.BackColor = System.Drawing.Color.White;
            this.tb_volume.Location = new System.Drawing.Point(94, 412);
            this.tb_volume.Name = "tb_volume";
            this.tb_volume.Size = new System.Drawing.Size(104, 45);
            this.tb_volume.TabIndex = 3;
            this.tb_volume.ValueChanged += new System.EventHandler(this.tb_volume_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::BatallaNaval.Properties.Resources.BarcoMenu;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(400, -145);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(552, 698);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pb_music
            // 
            this.pb_music.BackColor = System.Drawing.Color.Transparent;
            this.pb_music.Image = global::BatallaNaval.Properties.Resources.note2;
            this.pb_music.Location = new System.Drawing.Point(32, 412);
            this.pb_music.Name = "pb_music";
            this.pb_music.Size = new System.Drawing.Size(56, 45);
            this.pb_music.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_music.TabIndex = 4;
            this.pb_music.TabStop = false;
            this.pb_music.Click += new System.EventHandler(this.pb_music_Click);
            // 
            // lbl_hundir
            // 
            this.lbl_hundir.BackColor = System.Drawing.Color.Transparent;
            this.lbl_hundir.Font = new System.Drawing.Font("Microsoft Sans Serif", 69.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hundir.ForeColor = System.Drawing.Color.Black;
            this.lbl_hundir.Location = new System.Drawing.Point(12, 9);
            this.lbl_hundir.Name = "lbl_hundir";
            this.lbl_hundir.Size = new System.Drawing.Size(463, 298);
            this.lbl_hundir.TabIndex = 6;
            this.lbl_hundir.Text = "Hundir la flota";
            this.lbl_hundir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(221)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::BatallaNaval.Properties.Resources.fondomenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(913, 478);
            this.Controls.Add(this.lbl_hundir);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pb_music);
            this.Controls.Add(this.tb_volume);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_jugar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hundir la flota | Menú";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_music)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_jugar;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.TrackBar tb_volume;
        private System.Windows.Forms.PictureBox pb_music;
        private System.Windows.Forms.Label lbl_hundir;
    }
}