
namespace BatallaNaval
{
    partial class GameOver
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_reintentar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.lbl_derrota = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lbl_derrota);
            this.panel1.Controls.Add(this.btn_reintentar);
            this.panel1.Controls.Add(this.btn_salir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 482);
            this.panel1.TabIndex = 0;
            // 
            // btn_reintentar
            // 
            this.btn_reintentar.BackColor = System.Drawing.Color.White;
            this.btn_reintentar.FlatAppearance.BorderSize = 0;
            this.btn_reintentar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reintentar.Font = new System.Drawing.Font("Pirate Ship", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reintentar.Location = new System.Drawing.Point(402, 367);
            this.btn_reintentar.Name = "btn_reintentar";
            this.btn_reintentar.Size = new System.Drawing.Size(236, 61);
            this.btn_reintentar.TabIndex = 1;
            this.btn_reintentar.Text = "Volver al menu";
            this.btn_reintentar.UseVisualStyleBackColor = false;
            this.btn_reintentar.Click += new System.EventHandler(this.btn_reintentar_Click);
            this.btn_reintentar.MouseEnter += new System.EventHandler(this.btn_salir_MouseEnter);
            this.btn_reintentar.MouseLeave += new System.EventHandler(this.btn_salir_MouseLeave);
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.White;
            this.btn_salir.FlatAppearance.BorderSize = 0;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Font = new System.Drawing.Font("Pirate Ship", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.Location = new System.Drawing.Point(102, 367);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(236, 61);
            this.btn_salir.TabIndex = 0;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.button1_Click);
            this.btn_salir.MouseEnter += new System.EventHandler(this.btn_salir_MouseEnter);
            this.btn_salir.MouseLeave += new System.EventHandler(this.btn_salir_MouseLeave);
            // 
            // lbl_derrota
            // 
            this.lbl_derrota.Font = new System.Drawing.Font("Microsoft Sans Serif", 70F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_derrota.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_derrota.Location = new System.Drawing.Point(12, 109);
            this.lbl_derrota.Name = "lbl_derrota";
            this.lbl_derrota.Size = new System.Drawing.Size(751, 135);
            this.lbl_derrota.TabIndex = 2;
            this.lbl_derrota.Text = "Has Perdido";
            this.lbl_derrota.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BatallaNaval.Properties.Resources.mar;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(775, 482);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameOver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Has perdido";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameOver_Paint);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_reintentar;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Label lbl_derrota;
    }
}