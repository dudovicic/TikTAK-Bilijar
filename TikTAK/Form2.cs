using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TikTAK
{

    public partial class Form2 : Form
    {
        string b;
        private HashSet<Control> errorControls = new HashSet<Control>();

        public Form2()
        {
            InitializeComponent();

        }
        public void ispis(String a)
        {
            b = a.ToString();
            label3.Text = b.ToString();

        }
        private void spremiRezultatBtn_Click(object sender, EventArgs e)
        {
            string fileName = "C:/Users/ACER7/Desktop/TikTAK/rezultat.txt";


            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.Write("\r\n" + label3.Text);
            }
            MessageBox.Show("Uspjesno ste sacuvali rezultat.", "Rezultat sacuvan");
        }

        private void nazaduIgruBtn_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();

            if (frm != null)
            {
                this.Close();
            }
        }

        private void unosImena_TextChanged(object sender, EventArgs e)
        {
            //bez unosa imena nije moguce sacuvati rezultat
            var unosImena = sender as TextBox;
            if (unosImena.Text == "")
            {
                errorProvider1.SetError(unosImena, (string)unosImena.Tag);
                errorControls.Add(unosImena);
            }
            else
            {
                errorProvider1.SetError(unosImena, null);
                errorControls.Remove(unosImena);
            }
            spremiRezultatBtn.Enabled = errorControls.Count == 0;

            label3.Text = b.ToString() + " " + unosImena.Text;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            unosImena_TextChanged(unosImena, EventArgs.Empty);
        }
    }
}
