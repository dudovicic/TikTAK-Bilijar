using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTAK
{
    class smjer
    {
        private double x, y, z;
     
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public double Z
        {
            get { return z; }
            set { z = value; }
        }
      
         // konstruktor, null vektor
        public smjer()
        {
            x = 0.0;
            y = 0.0;
            z = 0.0;
        }
     
        //konstruktor prima vrijednosti x,y,z
        public smjer(double x1, double y1, double z1)
        {
            x = x1;
            y = y1;
            z = z1;
        }
      
        public smjer(smjer v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
    
        // override ToString i kreira tri vrijednosti
        public override string ToString()
        {
            return "(" + x.ToString("g3") + "," + y.ToString("g3") + "," + z.ToString("g3") + ")";
        }

        public double Duljina()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public bool ProvjeraSmjera(smjer v2)
        {
            if (x == v2.X && y == v2.Y && z == v2.Z) //ako su sve vrijednosti jednake onda je true
                return true;
            else
                return false;
        }
        public double TockaVektora(smjer v2)
        {
            return (x * v2.X + y * v2.Y + z * v2.Z);
        }

        public smjer VektorskiProdukt(smjer v2)
        {
            return new smjer(y * v2.Z - z * v2.Y, z * v2.X - x * v2.Z, x * v2.Y - y * v2.X);
        }
        public double velicinaKut(smjer v2)
        {
            double velicina = 0;
            double gornjaVrijednost = this.TockaVektora(v2);
            double donjaVrijednost = this.Duljina() * v2.Duljina();
            double kut;
            //ne ispod nule
            if (donjaVrijednost != 0)
                velicina = gornjaVrijednost / donjaVrijednost;
            else
                return 0;
            //cos ne moze se racunati veci od jedan
            if (velicina > 1) velicina = 1;
            if (velicina < -1) velicina = -1;
            kut = Math.Acos(velicina);
            return (kut * 180 / Math.PI);
        }
        public smjer JedVektor()
        {
            double duljina = Math.Sqrt(x * x + y * y + z * z);
            return new smjer(x / duljina, y / duljina, z / duljina);
        }

        public smjer ParalelnoKretanje(smjer v2)
        {
            double pkvadrat, tockaVektora, jacina;
            pkvadrat = Duljina() * Duljina();
            tockaVektora= TockaVektora(v2);
            if (pkvadrat != 0)
                jacina = tockaVektora / pkvadrat;
            else
                return new smjer();
            return new smjer(this.Jacina(jacina));
        }
        //oduzimanje paralelne komponente od originalnog smjera kako bi se dobio  okomiti smjer
        public smjer OkomitoKretanje(smjer v2)
        {
            return new smjer(v2 - this.ParalelnoKretanje(v2)); 
        }
        //mnozenje s vrijednosti
        public smjer Jacina(double jacina)
        {
            return new smjer(jacina * x, jacina * y, jacina * z); 
        }

        public static smjer operator *(double a, smjer v1)
        {
            return new smjer(a * v1.x, a * v1.y, a * v1.z);
        }

        public static smjer operator *(smjer v1, double a)
        {
            return new smjer(a * v1.x, a * v1.y, a * v1.z);
        }

        public static smjer operator +(smjer v1, smjer v2)
        {
            return new smjer(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z); 
        }

        public static smjer operator -(smjer v1, smjer v2)
        {
            return new smjer(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }
       
        public static smjer operator -(smjer v1)
        {
            return new smjer(-v1.x, -v1.y, -v1.z);
        }
    }
}
