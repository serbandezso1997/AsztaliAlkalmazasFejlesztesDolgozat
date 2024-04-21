using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkandinavLotto
{
    public partial class OtosLotto : Form
    {
        public static OtosLotto Instance;
        //A felhasználó által kihúzott számokat gyűjtöm ide.
        HashSet<string> szamok = new HashSet<string>();
        string[] SzamokTomb = new string[5];
        int[] SzamokTombInt = new int[5];

        //List<int> SzamokTomb = new List<int>();
        public int talaltokSzama = 0;
        HashSet<int> generaltSzamok = new HashSet<int>();
        public OtosLotto()
        {

            InitializeComponent();
            Instance = this;
            Kuldes.Enabled = false;
            TorlesGomb.Enabled = false;
            SzamKiIras1.BackColor = Color.WhiteSmoke;
            SzamKiIras2.BackColor = Color.WhiteSmoke;
            SzamKiIras3.BackColor = Color.WhiteSmoke;
            SzamKiIras4.BackColor = Color.WhiteSmoke;
            SzamKiIras5.BackColor = Color.WhiteSmoke;



        }

        //Visszalépés a főmenübe
        private void Vissza(object sender, EventArgs e)
        {
            Form1 form1 = Form1.Instance;
            form1.Show();
            Instance.Close();
        }

        private void Valaszt(object sender, EventArgs e)
        {


            foreach (Control c in this.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox ch = (CheckBox)c;
                    if (ch.Checked)
                    {
                        szamok.Add(ch.Text);
                        
                        
                        
                    }
                    //Ha a felhasználó kicsekkolja a választott számot, akkor a hashset-ből is kiveszem a számot
                    if (ch.Checked == false && szamok.Contains(ch.Text))
                    {
                        szamok.Remove(ch.Text);
                    }

                    if (szamok.Count > 1)
                    {
                        TorlesGomb.Enabled = true;
                    }
                    else
                    {
                        TorlesGomb.Enabled = false;
                    }

                    //Ha öt számot kiválasztott a felhasználó, akkor a "Küldés" gomb megjelenik
                    if (szamok.Count == 5)
                    {
                        Kuldes.Enabled = true;
                    }
                    // ha még nincs kiválasztva öt szám vagy több van kiválasztva, akkor a "Küldés" gomb inaktív.
                    else
                    {
                        Kuldes.Enabled = false;
                    }

                    //a hashsat áttöltése tömbbe.
                    SzamokTomb = szamok.ToArray();
                    
                    

                    /*List<int> valasztottSzamokSorrendbe = new List<int>();
                    for (int i = 0; i < SzamokTomb.Length; i++)
                    {
                        int atmeneti = int.Parse(SzamokTomb[i]);
                        valasztottSzamokSorrendbe.Add(atmeneti);
                    }
                    
                    valasztottSzamokSorrendbe.Sort();
                    SzamokTombInt = valasztottSzamokSorrendbe.ToArray();*/
                    
                    

                    
                    //SzamokTomb = szamok.ToArray();
                }
            }
            foreach (var szam in szamok)
            {
                //MessageBox.Show($"kiválasztva:{szam}");
            }
        }

        private void LottoSzamokBekuldese(object sender, EventArgs e)
        {
            //a listák háttérszíneinek visszaállítása
            foreach (Control c in this.Controls)
            {
                ListBox listBox = c as ListBox;
                if(listBox is ListBox)
                {
                    listBox.BackColor = Color.White;
                }
            }

            HashSet<string> eltalaltSzamokListaja = new HashSet<string>();
            HashSet<int> talalatIndexeLista = new HashSet<int>();
            //TalalatokSzama.Items.Clear();
            //TalalatokSzama.Items.Add(talaltokSzama.ToString());
            List<int> valasztottSzamokSorrendbe = new List<int>();
            for (int i = 0; i < SzamokTomb.Length; i++)
            {
                int atmeneti = int.Parse(SzamokTomb[i]);
                valasztottSzamokSorrendbe.Add(atmeneti);
            }

            valasztottSzamokSorrendbe.Sort();
            SzamokTombInt = valasztottSzamokSorrendbe.ToArray();

            Random rand = new Random();
            //Lottószámok generálása
            for (int i = 0; i < 5; i++)
            {
                int szam = rand.Next(1, 91);
                //ha olyan számot generál véletlenül a random osztálya, akkor az i érték csökkenjen 1-gyel.
                if (generaltSzamok.Contains(szam))
                {
                    i--;
                }
                else
                {
                    generaltSzamok.Add(szam);
                }

            }
            //generaltSzamok.OrderBy(szam => szam);
            List<int>GeneraltSzamokSorrendben = generaltSzamok.ToList();
            generaltSzamok.Clear();
            GeneraltSzamokSorrendben.Sort();
            int[] GeneraltSzamokTomb = GeneraltSzamokSorrendben.ToArray();

            // a grafikus felületen a listBox-ból kitőrlöm a tartalmat.
            KihuzottList1.Items.Clear();
            KihuzottList2.Items.Clear();
            KihuzottList3.Items.Clear();
            KihuzottList4.Items.Clear();
            KihuzottList5.Items.Clear();

            //számok betöltése a listboxokba
            KihuzottList1.Items.Add(GeneraltSzamokTomb[0]);
            KihuzottList2.Items.Add(GeneraltSzamokTomb[1]);
            KihuzottList3.Items.Add(GeneraltSzamokTomb[2]);
            KihuzottList4.Items.Add(GeneraltSzamokTomb[3]);
            KihuzottList5.Items.Add(GeneraltSzamokTomb[4]);

            //a felhasználó által választott számok törlése a grafikus felületen
            SzamKiIras1.Items.Clear();
            SzamKiIras2.Items.Clear();
            SzamKiIras3.Items.Clear();
            SzamKiIras4.Items.Clear();
            SzamKiIras5.Items.Clear();

            //A felhasználó által választott számok kiírása a grafikus felületen.
            SzamKiIras1.Items.Add (SzamokTombInt[0]);
            SzamKiIras2.Items.Add(SzamokTombInt[1]);
            SzamKiIras3.Items.Add(SzamokTombInt[2]);
            SzamKiIras4.Items.Add(SzamokTombInt[3]);
            SzamKiIras5.Items.Add(SzamokTombInt[4]);

            //A becsekkolt checkBox-ok inaktívvá tétele, miután beküldte a felhasználó a tippeit.
            foreach (Control c in this.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox ch = (CheckBox)c;

                    if (ch.Checked == true)
                    {
                        ch.Checked = false;
                    }
                }
            }
            
            //találatok számának megállapítása
            
            for (int i = 0; i < GeneraltSzamokTomb.Length; i++)
            {
                for (int j = 0; j < SzamokTombInt.Length; j++)
                {
                    if (GeneraltSzamokTomb[i] == SzamokTombInt[j])
                    {
                        talaltokSzama++;
                        talalatIndexeLista.Add(j);
                        eltalaltSzamokListaja.Add(GeneraltSzamokTomb[i].ToString());
                        

                    }
                }
            }
            


           //találatok megállapítása
            foreach(Control c in this.Controls)
            {
                if (c.Name == "SzamKiIras1" || c.Name == "SzamKiIras2" ||
                    c.Name == "SzamKiIras3" || c.Name == "SzamKiIras4" ||
                    c.Name == "SzamKiIras5")
                {
                    ListBox listbox = c as ListBox;
                    foreach (int szam in listbox.Items)
                    {
                        for(int i = 0; i < GeneraltSzamokSorrendben.Count; i++)
                        {
                            if(szam == GeneraltSzamokSorrendben[i])
                            {
                                listbox.BackColor = Color.LightGreen;
                            }
                        }
                    }
                    
                    

                }
                /*
                ListBox listbox = c as ListBox;
                if(listbox is ListBox)
                {
                    MessageBox.Show(listbox.Text);
                    foreach (string szam in eltalaltSzamokListaja)
                    {
                        
                    }
                }
                */
            }

            TalalatokSzama.Items.Clear();
            TalalatokSzama.Items.Add(talaltokSzama.ToString());
            talaltokSzama = 0;
            Kuldes.Enabled = false;
            TorlesGomb.Enabled = false;
/*
            foreach (var szam in SzamokTomb) MessageBox.Show("az általad választott számok: " + szam);
            foreach (var szam in GeneraltSzamokTomb) MessageBox.Show("a gép által generált számok: " + szam);
*/
        }

        private void Torles(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox ch = (CheckBox)c;
                    if (ch.Checked)
                    {
                        ch.Checked = false;
                    }
                }
            }
            TorlesGomb.Enabled = false;
            Kuldes.Enabled = false;
        }

        /*  private void checkBox30_CheckedChanged(object sender, EventArgs e)
          {

          }*/
    }
}
