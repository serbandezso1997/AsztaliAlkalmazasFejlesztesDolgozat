using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkandinavLotto
{

    internal class LottoSzamok:CheckBox
    {
        public EventHandler pf;
        int max = 35;
        int min = 1;
        static int szam = 1;
        static int peldany = 1;
        static int x = 45;
        static int y = 30;
        Label nev;

        static Point helyezkedes = new Point(x, y);
        
        public LottoSzamok()
        {

        }

        public void Megjelenes()
        {

            this.Text = $"{szam++}";
            this.Width = 15 ;
            this.Height = 15 ;
            this.Location = helyezkedes;
            
            if (peldany %5 == 0)
            {
                helyezkedes.X = 45;
                helyezkedes.Y += 25;
            }
            else
            {
                helyezkedes.X += 80;
            }
            peldany++;
            //helyezkedes .Y = y;
            
        }

        public void Start()
        {
            if (pf != null)
            {
                pf(this, new EventArgs());
            }
        }

      
    }

    public class Felirat : Label
    {
        
        static int szam = 1;
        static int peldany = 1;
        static int x = 23;
        static int y = 30;
        Label nev;

        static Point helyezkedes = new Point(x, y);

        public void Megjelenes()
        {

            this.Text = $"{szam++}";
            this.Width = 25;
            this.Height = 15;
            this.Location = helyezkedes;
            if (peldany % 5 == 0)
            {
                helyezkedes.X = 23;
                helyezkedes.Y += 25;
                //this.Text = $"{szam++}";

            }
            else
            {
                helyezkedes.X += 80;
                //this.Text = $"{szam++}";

            }
            peldany++;
            //helyezkedes .Y = y;

        }
    }
}
