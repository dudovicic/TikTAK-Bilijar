namespace TikTAK
{
    partial class Form1
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
            this.labelaVrijeme = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelaBodovi = new System.Windows.Forms.Label();
            this.labelakoordinate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelaVrijeme
            // 
            this.labelaVrijeme.AutoSize = true;
            this.labelaVrijeme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelaVrijeme.Location = new System.Drawing.Point(177, 437);
            this.labelaVrijeme.Name = "labelaVrijeme";
            this.labelaVrijeme.Size = new System.Drawing.Size(24, 16);
            this.labelaVrijeme.TabIndex = 8;
            this.labelaVrijeme.Text = "60";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(106, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Vrijeme:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bodovi:";
            // 
            // labelaBodovi
            // 
            this.labelaBodovi.AutoSize = true;
            this.labelaBodovi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelaBodovi.Location = new System.Drawing.Point(72, 437);
            this.labelaBodovi.Name = "labelaBodovi";
            this.labelaBodovi.Size = new System.Drawing.Size(16, 16);
            this.labelaBodovi.TabIndex = 9;
            this.labelaBodovi.Text = "0";
            // 
            // labelakoordinate
            // 
            this.labelakoordinate.AutoSize = true;
            this.labelakoordinate.Location = new System.Drawing.Point(599, 440);
            this.labelakoordinate.Name = "labelakoordinate";
            this.labelakoordinate.Size = new System.Drawing.Size(26, 13);
            this.labelakoordinate.TabIndex = 10;
            this.labelakoordinate.Text = "x ; y";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(662, 461);
            this.Controls.Add(this.labelakoordinate);
            this.Controls.Add(this.labelaBodovi);
            this.Controls.Add(this.labelaVrijeme);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Tik TAK";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelaVrijeme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelaBodovi;
        private System.Windows.Forms.Label labelakoordinate;
    }
}

