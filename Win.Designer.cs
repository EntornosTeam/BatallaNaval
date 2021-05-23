
namespace BatallaNaval
{
    partial class Win
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Win));
            this.btn_reintentar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_victoria = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_reintentar
            // 
            this.btn_reintentar.BackColor = System.Drawing.Color.White;
            this.btn_reintentar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_reintentar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reintentar.Font = new System.Drawing.Font("Pirate Ship", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reintentar.Location = new System.Drawing.Point(363, 360);
            this.btn_reintentar.Name = "btn_reintentar";
            this.btn_reintentar.Size = new System.Drawing.Size(186, 61);
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
            this.btn_salir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Font = new System.Drawing.Font("Pirate Ship", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.Location = new System.Drawing.Point(98, 360);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(186, 61);
            this.btn_salir.TabIndex = 0;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            this.btn_salir.MouseEnter += new System.EventHandler(this.btn_salir_MouseEnter);
            this.btn_salir.MouseLeave += new System.EventHandler(this.btn_salir_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::BatallaNaval.Properties.Resources.barco;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.lbl_victoria);
            this.panel1.Controls.Add(this.btn_reintentar);
            this.panel1.Controls.Add(this.btn_salir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 482);
            this.panel1.TabIndex = 1;
            // 
            // lbl_victoria
            // 
            this.lbl_victoria.AutoSize = true;
            this.lbl_victoria.Font = new System.Drawing.Font("ARMY RUST", 70F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_victoria.Location = new System.Drawing.Point(144, 158);
            this.lbl_victoria.Name = "lbl_victoria";
            this.lbl_victoria.Size = new System.Drawing.Size(340, 74);
            this.lbl_victoria.TabIndex = 2;
            this.lbl_victoria.Text = "Victoria";
            // 
            // Win
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(641, 482);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Win";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Victoria!!!";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Win_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_reintentar;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_victoria;
    }
}