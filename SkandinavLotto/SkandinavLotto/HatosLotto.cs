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
    public partial class HatosLotto : Form
    {
        HashSet<string> szamok = new HashSet<string>();
        HashSet <int> generaltSzamok = new HashSet<int>();
        string[] SzamokTomb = new string[6];
        int[] SzamokTombInt = new int[6];
        int talaltokSzama = 0;
        public static HatosLotto Instance;
        
        public HatosLotto()
        {
            InitializeComponent();
            Instance = this;
            Kuldes.Enabled = false;
            TorlesGomb.Enabled = false;
            
        }

        private void Vissza(object sender, EventArgs e)
        {
            Form1 form1 = Form1.Instance;
            form1.Show();
            Instance.Close();
        }

        private void Valaszt(object sender, EventArgs e)
        {
            //MessageBox.Show("kattintva");


            foreach (Control c in this.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox ch = (CheckBox)c;
                    if (ch.Checked)
                    {
                        szamok.Add(ch.Text);
                    }

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
                    if (szamok.Count == 6)
                    {
                        Kuldes.Enabled = true;
                    }
                    else
                    {
                        Kuldes.Enabled = false;
                    }
                }
                SzamokTomb = szamok.ToArray();
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
                if (listBox is ListBox)
                {
                    listBox.BackColor = Color.White;
                }
            }

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
            for (int i = 0; i < 6; i++)
            {
                int szam = rand.Next(1,46);
                if (generaltSzamok.Contains(szam))
                {
                    i--;
                }
                else
                {
                    generaltSzamok.Add(szam);
                }

            }

            //Generált számok sorrendbe állítása
            List<int> GeneraltSzamokSorrendben = generaltSzamok.ToList();
            generaltSzamok.Clear();
            GeneraltSzamokSorrendben.Sort();
            int[] GeneraltSzamokTomb = GeneraltSzamokSorrendben.ToArray();

            ValasztottElso.Items.Clear();
            ValasztottMasodik.Items.Clear();
            ValasztottHarmadik.Items.Clear();
            ValasztottNegyedik.Items.Clear();
            ValasztottOtodik.Items.Clear();
            ValasztottHatodik.Items.Clear();

            ValasztottElso.Items.Add(SzamokTombInt[0]);
            ValasztottMasodik.Items.Add(SzamokTombInt[1]);
            ValasztottHarmadik.Items.Add(SzamokTombInt[2]);
            ValasztottNegyedik.Items.Add(SzamokTombInt[3]);
            ValasztottOtodik.Items.Add(SzamokTombInt[4]);
            ValasztottHatodik.Items.Add(SzamokTombInt[5]);

            //gép által generált számok törlése a grafikus felületről.
            GepSzam1.Items.Clear();
            GepSzam2.Items.Clear();
            GepSzam3.Items.Clear();
            GepSzam4.Items.Clear();
            GepSzam5.Items.Clear();
            GepSzam6.Items.Clear();

            //gép által generált számok megjelenítése a grafikus felületen.
            GepSzam1.Items.Add(GeneraltSzamokTomb[0]);
            GepSzam2.Items.Add(GeneraltSzamokTomb[1]);
            GepSzam3.Items.Add(GeneraltSzamokTomb[2]);
            GepSzam4.Items.Add(GeneraltSzamokTomb[3]);
            GepSzam5.Items.Add(GeneraltSzamokTomb[4]);
            GepSzam6.Items.Add(GeneraltSzamokTomb[5]);

            //Találatok számának megállapítása
            for (int i = 0; i < GeneraltSzamokTomb.Length; i++)
            {
                for (int j = 0; j < SzamokTomb.Length; j++)
                {
                    if (GeneraltSzamokTomb[i] == SzamokTombInt[j])
                    {
                        talaltokSzama++;
                    }
                }
            }



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

            //találatok megállapítása
            foreach (Control c in this.Controls)
            {
                if (c.Name == "ValasztottElso" || c.Name == "ValasztottMasodik" ||
                    c.Name == "ValasztottHarmadik" || c.Name == "ValasztottNegyedik" ||
                    c.Name == "ValasztottOtodik" || c.Name == "ValasztottHatodik")
                {
                    
                    ListBox listbox = c as ListBox;
                    foreach (int szam in listbox.Items)
                    {
                        //MessageBox.Show(szam.ToString());
                        for (int i = 0; i < GeneraltSzamokSorrendben.Count; i++)
                        {
                            if (szam == GeneraltSzamokSorrendben[i])
                            {
                                listbox.BackColor = Color.LightGreen;
                            }
                        }
                    }
                }
            }

            TalalatokSzamaListBox.Items.Clear();
            TalalatokSzamaListBox.Items.Add(talaltokSzama.ToString());
            talaltokSzama = 0;
            Kuldes.Enabled = false;
            TorlesGomb.Enabled = false;
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
    }
}
