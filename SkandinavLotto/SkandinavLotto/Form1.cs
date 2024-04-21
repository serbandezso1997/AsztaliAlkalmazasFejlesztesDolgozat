/*
 * Készítette: Serbán Dezső Dávid
 * Szoftverfejlesztő-tesztelő technikum I/2/E
 * 2024-04-20
 * 
 * */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkandinavLotto
{
    public partial class Form1 : Form
    {
         public static Form1 Instance;
        public SoundPlayer sound = new SoundPlayer(@"HatterZene.wav");
        public Form1()
        {
            InitializeComponent();
            
            sound.PlayLooping();

            //ezt az objektumot elmentem egy "Instance" nevű változóba
            Instance = this;
            

            

            //button1.Enabled = true;
            //List<LottoSzamok>lista = new List<LottoSzamok>();
            //List<Felirat> lista2 = new List<Felirat>();

            //int[] ertekek = new int[7];

            /*
             * for (int i = 0; i < 35; i++) 
             {

                 lista.Add(new LottoSzamok());
                 lista[i].Megjelenes();
                 lista[i].Name = $"{i + 1}" ;

                 this.Controls.Add(lista[i]);
                 if (i > 0)
                 {

                 }



             }

             for (int i = 0; i < 35; i++)
             {

                 lista2.Add(new Felirat());
                 lista2[i].Megjelenes();
                 lista2[i].Name = $"{i + 1}";
                 lista2[i].Text = $"{i + 1}"; 

                 this.Controls.Add(lista2[i]);
                 if (i > 0)
                 {

                 }



             }

             foreach (Control e in this.Controls)
             {
                 if (e is LottoSzamok)
                 {
                     CheckBox a = e as CheckBox;
                     //MessageBox.Show(e.Name.ToString());
                     if (a.Name == "1")
                     {

                         if (a.Checked== true)
                         {
                             MessageBox.Show("csekkolva");
                         }
                         else
                         {
                             MessageBox.Show("Nincs csekkolva.");
                         }
                     }
                 }

             }
 */
            /*
                        foreach (var i in lista)
                        {
                            this.Controls.Add(i);
                        }
            */


        }

        /*
        private void Kuldes(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Megnyomtam");

           // foreach(var i in )
           // listBox1.Items.Add();
        }
         */

        // ez az a metódus, mely során a felhasználó kiválasztja, hogy mit szeretne játszani.
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                RadioButton radio = c as RadioButton;
                if (radio is RadioButton)
                {
                    if (radio.Checked == true)
                    {
                        if (radio.Name == "radioButton1")
                        {
                            SkandinavLotto skandinavLotto = new SkandinavLotto();
                            skandinavLotto.Show();
                            Instance.Hide();
                        }

                        if (radio.Name == "radioButton2")
                        {
                            OtosLotto otosLotto = new OtosLotto();
                            otosLotto.Show();
                            Instance.Hide();
                        }

                        if (radio.Name == "radioButton3")
                        {
                            HatosLotto hatosLotto = new HatosLotto();
                            hatosLotto.Show();
                            Instance.Hide();
                        }
                    }
                }
            }
            

            //MessageBox.Show("Megnyomtam");

        }

        //Ha a felhasználó kiszeretne lépni a programból
        private void Kilepes(object sender, EventArgs e)
        {
        
            Environment.Exit(0);
        }

        private void ZeneNemitasa(object sender, EventArgs e)
        {
            foreach(Control c in this.Controls)
            {
                if(c is CheckBox)
                {
                    CheckBox checkBox = c as CheckBox;
                    if (checkBox.Checked == true)
                    {
                        sound.Stop();
                    }
                    else
                    {
                        sound.PlayLooping();
                    }
                }
            }
        }

        /*
        private void ValasztSkandi(object sender, EventArgs e)
        {
            //MessageBox.Show("SkandinávLottó");
            foreach(Control c in this.Controls)
            {
                RadioButton radio = c as RadioButton;
                if (radio is RadioButton)
                {
                    if (radio.Checked == true)
                    {
                       // MessageBox.Show(radio.Name);
                    }
                }
            }
        }

        private void ValasztOtos(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                RadioButton radio = c as RadioButton;
                if (radio is RadioButton)
                {
                    if (radio.Checked == true)
                    {
                       // MessageBox.Show(radio.Name);
                    }
                }
            }
        }

        private void ValasztHatos(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                RadioButton radio = c as RadioButton;
                if (radio is RadioButton)
                {
                    if (radio.Checked == true)
                    {
                       // MessageBox.Show(radio.Name);
                    }
                }
            }
        }
        */
    }
}
