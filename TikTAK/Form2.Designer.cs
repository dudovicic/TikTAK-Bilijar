﻿namespace TikTAK
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.spremiRezultatBtn = new System.Windows.Forms.Button();
            this.nazaduIgruBtn = new System.Windows.Forms.Button();
            this.unosImena = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(151, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "IGRA JE GOTOVA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Spremi rezultat kao:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(298, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // spremiRezultatBtn
            // 
            this.spremiRezultatBtn.Location = new System.Drawing.Point(47, 132);
            this.spremiRezultatBtn.Name = "spremiRezultatBtn";
            this.spremiRezultatBtn.Size = new System.Drawing.Size(173, 23);
            this.spremiRezultatBtn.TabIndex = 5;
            this.spremiRezultatBtn.Text = "SPREMI REZULTAT";
            this.spremiRezultatBtn.UseVisualStyleBackColor = true;
            this.spremiRezultatBtn.Click += new System.EventHandler(this.spremiRezultatBtn_Click);
            // 
            // nazaduIgruBtn
            // 
            this.nazaduIgruBtn.Location = new System.Drawing.Point(249, 132);
            this.nazaduIgruBtn.Name = "nazaduIgruBtn";
            this.nazaduIgruBtn.Size = new System.Drawing.Size(172, 23);
            this.nazaduIgruBtn.TabIndex = 6;
            this.nazaduIgruBtn.Text = "VRATI SE NAZAD U IGRU";
            this.nazaduIgruBtn.UseVisualStyleBackColor = true;
            this.nazaduIgruBtn.Click += new System.EventHandler(this.nazaduIgruBtn_Click);
            // 
            // unosImena
            // 
            this.unosImena.Location = new System.Drawing.Point(180, 71);
            this.unosImena.Name = "unosImena";
            this.unosImena.Size = new System.Drawing.Size(100, 20);
            this.unosImena.TabIndex = 7;
            this.unosImena.TextChanged += new System.EventHandler(this.unosImena_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 188);
            this.Controls.Add(this.unosImena);
            this.Controls.Add(this.nazaduIgruBtn);
            this.Controls.Add(this.spremiRezultatBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button spremiRezultatBtn;
        private System.Windows.Forms.Button nazaduIgruBtn;
        private System.Windows.Forms.TextBox unosImena;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}