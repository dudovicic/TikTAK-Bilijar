using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IronPython.Hosting; //Pristup IronPython 
using Microsoft.Scripting.Hosting; 
using System.IO;

namespace TikTAK
{
    public partial class Form1 : Form
    {
        Image pozadina = Image.FromFile("C:/Users/ACER7/Desktop/TikTAK/Pozadina/tiktak.png");
        bool pocetakIgre = false;
        static int brojac = 61;
        System.Timers.Timer aTimer;

        ScriptEngine m_pyEngine = null;
        ScriptScope m_pyScope = null;

        int vrijednost1, vrijednost2, vrijednost3, vrijednost4, vrijednost5;
        int zbrojKonackiRez = 0;
        string spojeniString;


        //odredjivanje granica stola
        float sirina = 1000;
        float visina = 700;
        float lijevaGranica = 22; 
        float gornjaGranica = 45;   
        int desnaGranica = 30, donjaGranica = 80; 
        float promjer = 30;

        smjer lokacijaMisa = new smjer(), bijelaLoptaCentar = new smjer(300, 350, 0);
        smjer brzina = new smjer(), polumjer;
        smjer brzinaCrvene = new smjer(0, 0, 0), crvenaLoptaCentar = new smjer(300, 350, 0);
        smjer brzinaPlave = new smjer(0, 0, 0), plavaLoptaCentar = new smjer(500, 350, 0);
        smjer brzinaZute = new smjer(0, 0, 0), zutaLoptaCentar = new smjer(300, 350, 0);
        smjer brzinaZelene = new smjer(0, 0, 0), zelenaLoptaCentar = new smjer(500, 350, 0);
        smjer brzinaRoze = new smjer(0, 0, 0), rozaLoptaCentar = new smjer(300, 350, 0);
        smjer pogodak1 = new smjer(500, 350, 0);
        smjer pogodak2 = new smjer(500, 350, 0);
        smjer pogodak3 = new smjer(500, 350, 0);
        smjer pogodak4 = new smjer(500, 350, 0);
        smjer pogodak5 = new smjer(500, 350, 0);
        smjer pogodak6 = new smjer(500, 350, 0);

        bool tak; // crtanje stapa iz bijele lopte
        bool kretanjeBijeleLopte;
        bool kretanjeZuteLopte;
        bool kretanjeCrveneLopte;
        bool kretanjePlaveLopte;
        bool kretanjeZeleneLopte;
        bool kretanjeRozeLopte;
        bool crvenaPogodak;
        bool plavaPogodak;
        bool zutaPogodak;
        bool zelenaPogodak;
        bool rozaPogodak;

        float brzinaBijeleLopte;  
        float brzinaCrveneLopte;
        float brzinaPlaveLopte;
        float brzinaZuteLopte;
        float brzinaZeleneLopte;
        float brzinaRozeLopte;


        public Form1()
        {
            InitializeComponent();

            //Py 
            m_pyEngine = Python.CreateEngine();
            m_pyScope = m_pyEngine.CreateScope();
            ScriptSource ss = m_pyEngine.CreateScriptSourceFromFile(@"C:\Users\ACER7\Desktop\TikTAK\Kalkulator\Kalkulator.py");
            ss.Execute(m_pyScope);
            dynamic modifyFunc = m_pyScope.GetVariable("Dodaj");
            modifyFunc(this);

            aTimer = new System.Timers.Timer();
            aTimer.Interval = 1000;
            aTimer.Elapsed += OnTimeEvent;
            //postavljanje lopti u pocetni polozaj
            bijelaLoptaCentar.X = 161;
            bijelaLoptaCentar.Y = 232;
            crvenaLoptaCentar.X = 326;
            crvenaLoptaCentar.Y = 284;
            plavaLoptaCentar.X = 326;
            plavaLoptaCentar.Y = 200;
            zutaLoptaCentar.X = 432;
            zutaLoptaCentar.Y = 137;
            zelenaLoptaCentar.X = 432;
            zelenaLoptaCentar.Y = 335;
            rozaLoptaCentar.X = 432;
            rozaLoptaCentar.Y = 228;

    }
    private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                brojac -= 1;
                labelaVrijeme.Text = brojac.ToString();
                if (brojac == 0)
                {
                    aTimer.Stop();
                    string a = zbrojKonackiRez.ToString();
                    Form2 frm = new Form2();
                    frm.ispis(a.ToString());
                    frm.Show();
                    //kada vrijeme istekne ova forma se skriva, a prikazuje se forma2
                    if (frm != null)
                    {
                        this.Hide();
                    }

                }
            }));

        }
        public void onNewGame(object sender, EventArgs e)
        {
            //ponovno postavljanje pocetkog polozaja
            bijelaLoptaCentar.X = 161;
            bijelaLoptaCentar.Y = 232;
            crvenaLoptaCentar.X = 326;
            crvenaLoptaCentar.Y = 284;
            plavaLoptaCentar.X = 326;
            plavaLoptaCentar.Y = 200;
            zutaLoptaCentar.X = 432;
            zutaLoptaCentar.Y = 137;
            zelenaLoptaCentar.X = 432;
            zelenaLoptaCentar.Y = 335;
            rozaLoptaCentar.X = 432;
            rozaLoptaCentar.Y = 228;
            sirina = this.Width - 30;
            visina = this.Height - 50;
            polumjer = new smjer(promjer / 2, promjer / 2, 0);

            pogodak1.X = 21; 
            pogodak1.Y = 46;

            pogodak2.X = 327; 
            pogodak2.Y = 42;

            pogodak3.X = 633;  
            pogodak3.Y = 42;

            pogodak4.X = 21;  
            pogodak4.Y = 406;

            pogodak5.X = 327;  
            pogodak5.Y = 406;

            pogodak6.X = 633;  
            pogodak6.Y = 406;

            //vrijednosti se vracaju na nulu
            vrijednost1 = 0;
            vrijednost2 = 0;
            vrijednost3 = 0;
            vrijednost4 = 0;
            vrijednost5 = 0;

            crvenaPogodak = false;
            plavaPogodak = false;
            zutaPogodak = false;
            zelenaPogodak = false;
            rozaPogodak = false;
            tak = false;
            kretanjeBijeleLopte = false;
            kretanjeZuteLopte = true;
            kretanjeCrveneLopte = true;
            kretanjePlaveLopte = true;
            kretanjeZeleneLopte = true;
            kretanjeRozeLopte = true;
            pocetakIgre = true;
            brojac = 61;
            aTimer.Start();

            DateTime trenutnoVrijemeAzuriranja;
            DateTime posljednjeVrijemeAzuriranja;
            TimeSpan frameTime;

            trenutnoVrijemeAzuriranja = DateTime.Now;
            posljednjeVrijemeAzuriranja = DateTime.Now;

            this.Show();
            while (this.Created == true)
            {
                trenutnoVrijemeAzuriranja = DateTime.Now;
                frameTime = trenutnoVrijemeAzuriranja - posljednjeVrijemeAzuriranja;
                if (frameTime.TotalMilliseconds > 20)
                {
                    //pokretanje igre
                    this.Refresh();
                    Application.DoEvents();
                    this.Pokretanje();

                    posljednjeVrijemeAzuriranja = DateTime.Now;
                }

            }


        }

        //klasa Line u kojoj int vrijednost broja prezlazi u string vrijednost, a prvo se usporedjuje vrijednost brojeva 
        public class Line : IComparable<Line>
        {
            int broj;
            string stringBroj;
            string linija;

            public Line(string line)
            {
                //dohvaca integer
                int firstSpace = line.IndexOf(' ');
                string integer = line.Substring(0, firstSpace);
                this.broj = int.Parse(integer);

                //sprema string
                this.stringBroj = line.Substring(firstSpace);
                this.linija = line;
            }

            public int CompareTo(Line other)
            {
                //prvo usporedjuje brojeve
                int usporedbaBrojeva = broj.CompareTo(other.broj);
                if (usporedbaBrojeva != 0)
                {
                    return usporedbaBrojeva;
                }
                return stringBroj.CompareTo(other.stringBroj);
            }

            public override string ToString()
            {
                return this.linija;
            }
        }

        public void onOpen(object sender, EventArgs e)
        {
            aTimer.Stop();

            List<Line> list = new List<Line>();
            using (StreamReader reader = new StreamReader(@"C:/Users/ACER7/Desktop/TikTAK/rezultat.txt"))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    list.Add(new Line(line));
                }
            }
            //sortira vrijednosti po veličini prvo najlosiji rezultat
            list.Sort();
            foreach (Line value in list)
            {
                //prikazuje dva spojena stringa
                spojeniString = string.Join("\r\n", list.Select(c => c.ToString()).ToArray<string>());

            }
            if (MessageBox.Show(spojeniString.ToString(), "Rezultati") == DialogResult.OK && pocetakIgre == true)
            {
                aTimer.Start();

            }



        }

        public void onExit(object sender, EventArgs e)
        {
            aTimer.Stop();

            if (MessageBox.Show("Želiš li izaći iz igre?", "Izlaz", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Application.Exit();
            }
            if (MessageBox.Show("Želiš li izaći iz igre?", "Izlaz", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.No && pocetakIgre == true)
            {
                aTimer.Start();
                
            }
           
        }
        public void onOpenAbout(object sender, EventArgs e)
        {

            aTimer.Stop();

            string text = System.IO.File.ReadAllText(@"C:/Users/ACER7/Desktop/TikTAK/About.txt");

            if (MessageBox.Show(text.ToString(), "O igri") == DialogResult.OK && pocetakIgre == true)
            {
                aTimer.Start();
            }


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          
            Pen blackPen = new Pen(Color.Black, 4f);
            e.Graphics.DrawImage(pozadina, 0, 25, this.ClientRectangle.Width, this.ClientRectangle.Height - 50);

            if (tak)
            {
                e.Graphics.DrawLine(blackPen, (int)lokacijaMisa.X, (int)lokacijaMisa.Y, (int)bijelaLoptaCentar.X, (int)bijelaLoptaCentar.Y);
            }
            //poziva funkciju koja crta lopte
            CrtanjeLopti(e);

        }
        private void CrtanjeLopti(PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            float bijelaX = (float)bijelaLoptaCentar.X - promjer / 2;
            float bijelaY = (float)bijelaLoptaCentar.Y - promjer / 2;
            RectangleF obrub = new RectangleF(bijelaX, bijelaY, promjer, promjer);
            e.Graphics.DrawEllipse(blackPen, obrub);
            SolidBrush bijelaBrush = new SolidBrush(Color.White);
            e.Graphics.FillEllipse(bijelaBrush, obrub);

            float crvenaX = (float)crvenaLoptaCentar.X - promjer / 2;
            float crvenaY = (float)crvenaLoptaCentar.Y - promjer / 2;
            RectangleF obrubCrvene = new RectangleF(crvenaX, crvenaY, promjer, promjer);
            e.Graphics.DrawEllipse(blackPen, obrubCrvene);
            SolidBrush crvenaBrush = new SolidBrush(Color.Red);
            e.Graphics.FillEllipse(crvenaBrush, obrubCrvene);

            float plavaX = (float)plavaLoptaCentar.X - promjer / 2;
            float plavaY = (float)plavaLoptaCentar.Y - promjer / 2;
            RectangleF obrubPlave = new RectangleF(plavaX, plavaY, promjer, promjer);
            e.Graphics.DrawEllipse(blackPen, obrubPlave);
            SolidBrush plavaBrush = new SolidBrush(Color.Blue);
            e.Graphics.FillEllipse(plavaBrush, obrubPlave);

            float zutaX = (float)zutaLoptaCentar.X - promjer / 2;
            float zutaY = (float)zutaLoptaCentar.Y - promjer / 2;
            RectangleF obrubZute = new RectangleF(zutaX, zutaY, promjer, promjer);
            e.Graphics.DrawEllipse(blackPen, obrubZute);
            SolidBrush zutaBrush = new SolidBrush(Color.Yellow);
            e.Graphics.FillEllipse(zutaBrush, obrubZute);

            float zelenaX = (float)zelenaLoptaCentar.X - promjer / 2;
            float zelenaY = (float)zelenaLoptaCentar.Y - promjer / 2;
            RectangleF obrubZelena = new RectangleF(zelenaX, zelenaY, promjer, promjer);
            e.Graphics.DrawEllipse(blackPen, obrubZelena);
            SolidBrush zelenaBrush = new SolidBrush(Color.Green);
            e.Graphics.FillEllipse(zelenaBrush, obrubZelena);

            float rozaX = (float)rozaLoptaCentar.X - promjer / 2;
            float rozaY = (float)rozaLoptaCentar.Y - promjer / 2;
            RectangleF obrubRoza = new RectangleF(rozaX, rozaY, promjer, promjer);
            e.Graphics.DrawEllipse(blackPen, obrubRoza);
            SolidBrush rozaBrush = new SolidBrush(Color.LightPink);
            e.Graphics.FillEllipse(rozaBrush, obrubRoza);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //x i y pozicija misa i crta tak
            lokacijaMisa.X = e.X;
            lokacijaMisa.Y = e.Y;
            tak = true;

            kretanjeBijeleLopte = false;
            kretanjeZuteLopte = false;
            kretanjeCrveneLopte = false;
            kretanjePlaveLopte = false;
            kretanjeZeleneLopte = false;
            kretanjeRozeLopte = false;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            labelakoordinate.Text = "X=" + e.X + "; Y=" + e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            tak = false;
            brzina.X = bijelaLoptaCentar.X - lokacijaMisa.X;
            brzina.Y = bijelaLoptaCentar.Y - lokacijaMisa.Y;
            float duzina = (float)brzina.Duljina();
            if (duzina > 40)
                duzina = 40;
            brzinaBijeleLopte = duzina / 10; // mjenja brzinu lopte s obzirom koliko je dug tak

            if (duzina != 0) //jedin.vektor
            {
                brzina.X /= duzina;  
                brzina.Y /= duzina;
            }

            kretanjeBijeleLopte = true;
            kretanjeCrveneLopte = true;
            kretanjePlaveLopte = true;
            kretanjeZuteLopte = true;
            kretanjeZeleneLopte = true;
            kretanjeRozeLopte = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            lokacijaMisa.X = e.X;
            lokacijaMisa.Y = e.Y;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        internal void Pokretanje()
        {
            KretanjeLopte(brzina, bijelaLoptaCentar, brzinaBijeleLopte, kretanjeBijeleLopte); 
            KretanjeLopte(brzinaCrvene, crvenaLoptaCentar, brzinaCrveneLopte, kretanjeCrveneLopte); 
            KretanjeLopte(brzinaPlave, plavaLoptaCentar, brzinaPlaveLopte, kretanjePlaveLopte); 
            KretanjeLopte(brzinaZute, zutaLoptaCentar, brzinaZuteLopte, kretanjeZuteLopte); 
            KretanjeLopte(brzinaZelene, zelenaLoptaCentar, brzinaZeleneLopte, kretanjeZeleneLopte); 
            KretanjeLopte(brzinaRoze, rozaLoptaCentar, brzinaRozeLopte, kretanjeRozeLopte); 
            this.ProvjeraSudara();

        }
        private void KretanjeLopte(smjer brzina, smjer bijelaLoptaCentar, float speed, bool kretanjeLopte)
        {
            if (kretanjeLopte == true)
            {
                bijelaLoptaCentar.X += brzina.X * speed;
                bijelaLoptaCentar.Y += brzina.Y * speed;

                brzina.X *= 0.97; //polako smanjuje brzinu
                brzina.Y *= 0.97;
                if ((brzina.X < 0.01 && brzina.X > -0.01) && (brzina.Y < 0.01 && brzina.Y > -0.01))
                {
                    brzina.X = 0; //lopta staje kad je brzina mala
                    brzina.Y = 0;
                }

                if (bijelaLoptaCentar.X <= lijevaGranica + promjer / 2)
                //udarom u lijevu stranu mjenja x smjer
                {
                    brzina.X = -brzina.X;
                    bijelaLoptaCentar.X = lijevaGranica + promjer / 2;
                }
                if (bijelaLoptaCentar.X >= lijevaGranica + sirina - desnaGranica - promjer / 2)
                //udarom u desnu stranu mjenja x smjer
                {
                    brzina.X = -brzina.X;
                    bijelaLoptaCentar.X = lijevaGranica + sirina - desnaGranica - promjer / 2;
                }
                if (bijelaLoptaCentar.Y <= gornjaGranica + promjer / 2)
                //udarom u gornju stranu, mjenja samo y smjer
                {
                    brzina.Y = -brzina.Y;
                    bijelaLoptaCentar.Y = gornjaGranica + promjer / 2;
                }
                if (bijelaLoptaCentar.Y >= gornjaGranica + visina - donjaGranica - promjer / 2)
                //udarom u donju stranu, mjenja y smjer
                {
                    brzina.Y = -brzina.Y;
                    bijelaLoptaCentar.Y = gornjaGranica + visina - donjaGranica - promjer / 2;
                }


            }
        }

        private bool OtkrivanjeSudara(smjer centarPrve, smjer centarDruge)
        //otkriva je li doslo do sudara izmedju dvi lopte
        {
            smjer udaljenostDviLopte = centarDruge - centarPrve; 
            float udaljenost = (float)udaljenostDviLopte.Duljina(); 
            if (udaljenost < promjer + 2) //zaustavlja lopte da ne prelaze preko druge
            {
                return true; //ako je doslo do sudara
            }
            else
            {
                return false;
            }
        }

        public void ProvjeraSudara()
        //provjera je li doslo do sudara lopti ili je doslo do pogodtka
        {

            smjer odgBrzina = new smjer();
            bool sudarBijeleCrvene = OtkrivanjeSudara(bijelaLoptaCentar, crvenaLoptaCentar);
            bool sudarBijelePlave = OtkrivanjeSudara(bijelaLoptaCentar, plavaLoptaCentar);
            bool sudarBijeleZute = OtkrivanjeSudara(bijelaLoptaCentar, zutaLoptaCentar);

            bool sudarBijeleZelene = OtkrivanjeSudara(bijelaLoptaCentar, zelenaLoptaCentar);
            bool sudarBijeleRoze = OtkrivanjeSudara(bijelaLoptaCentar, rozaLoptaCentar);
            bool sudarCrveneZute = OtkrivanjeSudara(crvenaLoptaCentar, zutaLoptaCentar);
            bool sudarPlaveZute = OtkrivanjeSudara(plavaLoptaCentar, zutaLoptaCentar);
            bool sudarPlaveCrvene = OtkrivanjeSudara(plavaLoptaCentar, crvenaLoptaCentar);
            bool sudarPlaveZelene = OtkrivanjeSudara(plavaLoptaCentar, zelenaLoptaCentar);
            bool sudarPlaveRoze = OtkrivanjeSudara(plavaLoptaCentar, rozaLoptaCentar);
            bool sudarCrveneZelene = OtkrivanjeSudara(crvenaLoptaCentar, zelenaLoptaCentar);
            bool sudarCrveneRoze = OtkrivanjeSudara(crvenaLoptaCentar, rozaLoptaCentar);
            bool sudarZeleneRoze = OtkrivanjeSudara(zelenaLoptaCentar, rozaLoptaCentar);
            bool sudarZeleneZute = OtkrivanjeSudara(zelenaLoptaCentar, zutaLoptaCentar);
            bool sudarRozeZute = OtkrivanjeSudara(rozaLoptaCentar, zutaLoptaCentar);


            bool crvenaPogodak1 = OtkrivanjeSudara(crvenaLoptaCentar, pogodak1);
            bool zutaPogodak1 = OtkrivanjeSudara(zutaLoptaCentar, pogodak1);
            bool plavaPogodak1 = OtkrivanjeSudara(plavaLoptaCentar, pogodak1);
            bool zelenaPogodak1 = OtkrivanjeSudara(zelenaLoptaCentar, pogodak1);
            bool rozaPogodak1 = OtkrivanjeSudara(rozaLoptaCentar, pogodak1);


            bool crvenaPogodak2 = OtkrivanjeSudara(crvenaLoptaCentar, pogodak2);
            bool zutaPogodak2 = OtkrivanjeSudara(zutaLoptaCentar, pogodak2);
            bool plavaPogodak2 = OtkrivanjeSudara(plavaLoptaCentar, pogodak2);
            bool zelenaPogodak2 = OtkrivanjeSudara(zelenaLoptaCentar, pogodak2);
            bool rozaPogodak2 = OtkrivanjeSudara(rozaLoptaCentar, pogodak2);


            bool crvenaPogodak3 = OtkrivanjeSudara(crvenaLoptaCentar, pogodak3);
            bool zutaPogodak3 = OtkrivanjeSudara(zutaLoptaCentar, pogodak3);
            bool plavaPogodak3 = OtkrivanjeSudara(plavaLoptaCentar, pogodak3);
            bool zelenaPogodak3 = OtkrivanjeSudara(zelenaLoptaCentar, pogodak3);
            bool rozaPogodak3 = OtkrivanjeSudara(rozaLoptaCentar, pogodak3);


            bool crvenaPogodak4 = OtkrivanjeSudara(crvenaLoptaCentar, pogodak4);
            bool zutaPogodak4 = OtkrivanjeSudara(zutaLoptaCentar, pogodak4);
            bool plavaPogodak4 = OtkrivanjeSudara(plavaLoptaCentar, pogodak4);
            bool zelenaPogodak4 = OtkrivanjeSudara(zelenaLoptaCentar, pogodak4);
            bool rozaPogodak4 = OtkrivanjeSudara(rozaLoptaCentar, pogodak4);


            bool crvenaPogodak5 = OtkrivanjeSudara(crvenaLoptaCentar, pogodak5);
            bool zutaPogodak5 = OtkrivanjeSudara(zutaLoptaCentar, pogodak5);
            bool plavaPogodak5 = OtkrivanjeSudara(plavaLoptaCentar, pogodak5);
            bool zelenaPogodak5 = OtkrivanjeSudara(zelenaLoptaCentar, pogodak5);
            bool rozaPogodak5 = OtkrivanjeSudara(rozaLoptaCentar, pogodak5);



            bool crvenaPogodak6 = OtkrivanjeSudara(crvenaLoptaCentar, pogodak6);
            bool zutaPogodak6 = OtkrivanjeSudara(zutaLoptaCentar, pogodak6);
            bool plavaPogodak6 = OtkrivanjeSudara(plavaLoptaCentar, pogodak6);
            bool zelenaPogodak6 = OtkrivanjeSudara(zelenaLoptaCentar, pogodak6);
            bool rozaPogodak6 = OtkrivanjeSudara(rozaLoptaCentar, pogodak6);



            if (crvenaPogodak1)  //je li crvena lopta pogodila u prvu  rupu, ako jest onda se zaustavlja njeno kretanje 
            {
                kretanjeCrveneLopte = false;
                brzinaCrveneLopte = 0;
                crvenaPogodak = true;

            }
            if (zutaPogodak1)  
            {
                kretanjeZuteLopte = false;
                brzinaZuteLopte = 0;
                zutaPogodak = true;

            }
            if (plavaPogodak1)  
            {
                kretanjePlaveLopte = false;
                brzinaPlaveLopte = 0;
                plavaPogodak = true;

            }
            if (zelenaPogodak1)  
            {
                kretanjeZeleneLopte = false;
                brzinaZeleneLopte = 0;
                zelenaPogodak = true;

            }
            if (rozaPogodak1)  
            {
                kretanjeRozeLopte = false;
                brzinaRozeLopte = 0;
                rozaPogodak = true;

            }

            if (crvenaPogodak2)  
            {
                kretanjeCrveneLopte = false;
                brzinaCrveneLopte = 0;
                crvenaPogodak = true;

            }
            if (zutaPogodak2)  
            {
                kretanjeZuteLopte = false;
                brzinaZuteLopte = 0;
                zutaPogodak = true;

            }
            if (plavaPogodak2)  
            {
                kretanjePlaveLopte = false;
                brzinaPlaveLopte = 0;
                plavaPogodak = true;

            }
            if (zelenaPogodak2)  
            {
                kretanjeZeleneLopte = false;
                brzinaZeleneLopte = 0;
                zelenaPogodak = true;

            }
            if (rozaPogodak2)  
            {
                kretanjeRozeLopte = false;
                brzinaRozeLopte = 0;
                rozaPogodak = true;

            }
            if (crvenaPogodak3)  
            {
                kretanjeCrveneLopte = false;
                brzinaCrveneLopte = 0;
                crvenaPogodak = true;

            }
            if (zutaPogodak3)  
            {
                kretanjeZuteLopte = false;
                brzinaZuteLopte = 0;
                zutaPogodak = true;
            }
            if (plavaPogodak3)  
            {
                kretanjePlaveLopte = false;
                brzinaPlaveLopte = 0;
                plavaPogodak = true;

            }
            if (zelenaPogodak3)  
            {
                kretanjeZeleneLopte = false;
                brzinaZeleneLopte = 0;
                zelenaPogodak = true;

            }
            if (rozaPogodak3)  
            {
                kretanjeRozeLopte = false;
                brzinaRozeLopte = 0;
                rozaPogodak = true;

            }
            if (crvenaPogodak4)  
            {
                kretanjeCrveneLopte = false;
                brzinaCrveneLopte = 0;
                crvenaPogodak = true;

            }
            if (zutaPogodak4)  
            {
                kretanjeZuteLopte = false;
                brzinaZuteLopte = 0;
                zutaPogodak = true;

            }
            if (plavaPogodak4)  
            {
                kretanjePlaveLopte = false;
                brzinaPlaveLopte = 0;
                plavaPogodak = true;
            }
            if (zelenaPogodak4)  
            {
                kretanjeZeleneLopte = false;
                brzinaZeleneLopte = 0;
                zelenaPogodak = true;

            }
            if (rozaPogodak4)  
            {
                kretanjeRozeLopte = false;
                brzinaRozeLopte = 0;
                rozaPogodak = true;

            }
            if (crvenaPogodak5)  
            {
                kretanjeCrveneLopte = false;
                brzinaCrveneLopte = 0;
                crvenaPogodak = true;
            }
            if (zutaPogodak5) 
            {
                kretanjeZuteLopte = false;
                brzinaZuteLopte = 0;
                zutaPogodak = true;
            }
            if (plavaPogodak5)  
            {
                kretanjePlaveLopte = false;
                brzinaPlaveLopte = 0;
                plavaPogodak = true;
            }
            if (zelenaPogodak5)  
            {
                kretanjeZeleneLopte = false;
                brzinaZeleneLopte = 0;
                zelenaPogodak = true;

            }
            if (rozaPogodak5)  
            {
                kretanjeRozeLopte = false;
                brzinaRozeLopte = 0;
                rozaPogodak = true;

            }
            if (crvenaPogodak6)  
            {
                kretanjeCrveneLopte = false;
                brzinaCrveneLopte = 0;
                crvenaPogodak = true;

            }
            if (zutaPogodak6)  
            {
                kretanjeZuteLopte = false;
                brzinaZuteLopte = 0;
                zutaPogodak = true;

            }
            if (plavaPogodak6)  
            {
                kretanjePlaveLopte = false;
                brzinaPlaveLopte = 0;
                plavaPogodak = true;

            }
            if (zelenaPogodak6)  
            {
                kretanjeZeleneLopte = false;
                brzinaZeleneLopte = 0;
                zelenaPogodak = true;

            }
            if (rozaPogodak6)  
            {
                kretanjeRozeLopte = false;
                brzinaRozeLopte = 0;
                rozaPogodak = true;

            }


            if (sudarBijeleCrvene)  //ako su se sudarile bijela i crvena lopta, zamjenjuju im se vrijednosti brzina, nova brzina prve je sacuvana odgBrzina
            {   
                odgBrzina = PromjenaBrzine(brzina, bijelaLoptaCentar, brzinaCrvene, crvenaLoptaCentar); 
                brzinaCrvene = PromjenaBrzine(brzinaCrvene, crvenaLoptaCentar, brzina, bijelaLoptaCentar);
                brzina = odgBrzina;
                brzinaCrveneLopte = brzinaBijeleLopte;
            }

            if (sudarBijelePlave)  
            {   
                odgBrzina = PromjenaBrzine(brzina, bijelaLoptaCentar, brzinaPlave, plavaLoptaCentar); 
                brzinaPlave = PromjenaBrzine(brzinaPlave, plavaLoptaCentar, brzina, bijelaLoptaCentar);
                brzina = odgBrzina;
                brzinaPlaveLopte = brzinaBijeleLopte;
            }
            if (sudarBijeleZute)
            {
                odgBrzina = PromjenaBrzine(brzina, bijelaLoptaCentar, brzinaZute, zutaLoptaCentar);
                brzinaZute = PromjenaBrzine(brzinaZute, zutaLoptaCentar, brzina, bijelaLoptaCentar);
                brzina = odgBrzina;
                brzinaZuteLopte = brzinaBijeleLopte;
            }
            if (sudarBijeleZelene)  
            {   
                odgBrzina = PromjenaBrzine(brzina, bijelaLoptaCentar, brzinaZelene, zelenaLoptaCentar); 
                brzinaZelene = PromjenaBrzine(brzinaZelene, zelenaLoptaCentar, brzina, bijelaLoptaCentar);
                brzina = odgBrzina;
                brzinaZeleneLopte = brzinaBijeleLopte;
            }
            if (sudarBijeleRoze)
            {
                odgBrzina = PromjenaBrzine(brzina, bijelaLoptaCentar, brzinaRoze, rozaLoptaCentar);
                brzinaRoze = PromjenaBrzine(brzinaRoze, rozaLoptaCentar, brzina, bijelaLoptaCentar);
                brzina = odgBrzina;
                brzinaRozeLopte = brzinaBijeleLopte;
            }

            if (sudarCrveneZute)
            {
                odgBrzina = PromjenaBrzine(brzinaCrvene, crvenaLoptaCentar, brzinaZute, zutaLoptaCentar);
                brzinaZute = PromjenaBrzine(brzinaZute, zutaLoptaCentar, brzinaCrvene, crvenaLoptaCentar);
                brzinaCrvene = odgBrzina;
                brzinaCrveneLopte = brzinaZuteLopte;
            }
            if (sudarPlaveZute)
            {
                odgBrzina = PromjenaBrzine(brzinaPlave, plavaLoptaCentar, brzinaZute, zutaLoptaCentar);
                brzinaZute = PromjenaBrzine(brzinaZute, zutaLoptaCentar, brzinaPlave, plavaLoptaCentar);
                brzinaPlave = odgBrzina;
                brzinaPlaveLopte = brzinaZuteLopte;
            }
            if (sudarPlaveCrvene)
            {
                odgBrzina = PromjenaBrzine(brzinaPlave, plavaLoptaCentar, brzinaCrvene, crvenaLoptaCentar);
                brzinaCrvene = PromjenaBrzine(brzinaCrvene, crvenaLoptaCentar, brzinaPlave, plavaLoptaCentar);
                brzinaPlave = odgBrzina;
                brzinaPlaveLopte = brzinaCrveneLopte;
            }
            if (sudarPlaveZelene)
            {
                odgBrzina = PromjenaBrzine(brzinaPlave, plavaLoptaCentar, brzinaZelene, zelenaLoptaCentar);
                brzinaZelene = PromjenaBrzine(brzinaZelene, zelenaLoptaCentar, brzinaPlave, plavaLoptaCentar);
                brzinaPlave = odgBrzina;
                brzinaPlaveLopte = brzinaZeleneLopte;
            }
            if (sudarPlaveRoze)
            {
                odgBrzina = PromjenaBrzine(brzinaPlave, plavaLoptaCentar, brzinaRoze, rozaLoptaCentar);
                brzinaRoze = PromjenaBrzine(brzinaRoze, rozaLoptaCentar, brzinaPlave, plavaLoptaCentar);
                brzinaPlave = odgBrzina;
                brzinaPlaveLopte = brzinaRozeLopte;
            }
            if (sudarCrveneZelene)
            {
                odgBrzina = PromjenaBrzine(brzinaCrvene, crvenaLoptaCentar, brzinaZelene, zelenaLoptaCentar);
                brzinaZelene = PromjenaBrzine(brzinaZelene, zelenaLoptaCentar, brzinaCrvene, crvenaLoptaCentar);
                brzinaCrvene = odgBrzina;
                brzinaCrveneLopte = brzinaZeleneLopte;
            }
            if (sudarCrveneRoze)
            {
                odgBrzina = PromjenaBrzine(brzinaCrvene, crvenaLoptaCentar, brzinaRoze, rozaLoptaCentar);
                brzinaRoze = PromjenaBrzine(brzinaRoze, rozaLoptaCentar, brzinaCrvene, crvenaLoptaCentar);
                brzinaCrvene = odgBrzina;
                brzinaCrveneLopte = brzinaRozeLopte;
            }
            if (sudarZeleneRoze)
            {
                odgBrzina = PromjenaBrzine(brzinaZelene, zelenaLoptaCentar, brzinaRoze, rozaLoptaCentar);
                brzinaRoze = PromjenaBrzine(brzinaRoze, rozaLoptaCentar, brzinaZelene, zelenaLoptaCentar);
                brzinaZelene = odgBrzina;
                brzinaZeleneLopte = brzinaRozeLopte;
            }
            if (sudarZeleneZute)
            {
                odgBrzina = PromjenaBrzine(brzinaZelene, zelenaLoptaCentar, brzinaZute, zutaLoptaCentar);
                brzinaZute = PromjenaBrzine(brzinaZute, zutaLoptaCentar, brzinaZelene, zelenaLoptaCentar);
                brzinaZelene = odgBrzina;
                brzinaZeleneLopte = brzinaZuteLopte;
            }
            if (sudarRozeZute)
            {
                odgBrzina = PromjenaBrzine(brzinaRoze, rozaLoptaCentar, brzinaZute, zutaLoptaCentar);
                brzinaZute = PromjenaBrzine(brzinaZute, zutaLoptaCentar, brzinaRoze, rozaLoptaCentar);
                brzinaRoze = odgBrzina;
                brzinaRozeLopte = brzinaZuteLopte;
            }

            //ako je doslo do pogodtka dodjeljuju se razlicite vrijednosti za razlicitu boju lopte 
            if (crvenaPogodak == true)
            {
                vrijednost1 = 1;
            }

            if (plavaPogodak == true)
            {
                vrijednost2 = 2;
            }

            if (zutaPogodak == true)
            {
                vrijednost3 = 3;

            }
            if (zelenaPogodak == true)
            {
                vrijednost4 = 4;

            }
            if (rozaPogodak == true)
            {
                vrijednost5 = 5;

            }

            //salju se vrijednosti u py i dobiva se njihov zbroj
            Func<int, int, int, int, int, int> Rezultat = m_pyScope.GetVariable<Func<int, int, int, int, int, int>>("Rezultat");
            zbrojKonackiRez = Rezultat(vrijednost1, vrijednost2, vrijednost3, vrijednost4, vrijednost5);
            labelaBodovi.Text = zbrojKonackiRez.ToString();


        }

        private smjer PromjenaBrzine(smjer brzinaPrve, smjer centarPrve, smjer brzinaDruge, smjer centarDruge)
        //vraca novu brzinu prve lopte
        {
            smjer centarVektora = centarDruge - centarPrve;
            smjer okomicaPrve = centarVektora.OkomitoKretanje(brzinaPrve);
            smjer paralelaDruge = centarVektora.ParalelnoKretanje(brzinaDruge);
            smjer novaBrzinaPrve = paralelaDruge + okomicaPrve; 


            return novaBrzinaPrve; 
        }

       
    }
}
