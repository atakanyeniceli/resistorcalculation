using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElektronikUygulama
{
    public partial class Form1 : Form
    {
        RenkKodları Rnk = new RenkKodları();
        public Form1()
        {
            InitializeComponent();
            Cmb_RenkSecim.Items.Add("4 Renkli Direnç");
            Cmb_RenkSecim.Items.Add("5 Renkli Direnç");
            Control();
            foreach (Control item in this.Controls)
            {
                if (item is Label)
                {
                    Label Lbl = (Label)item;
                    if (Lbl.Text!="Direnç Değeri")
                    {
                        Lbl.ForeColor = Color.White;
                    }
                }
            }
            foreach (Control item in groupBox1.Controls)
            {
                if (item is ComboBox)
                {
                    ComboBox Cmb = (ComboBox)item;
                    for (int i = 0; i < Rnk.RenkKodListesi.Length; i++)
                    {
                        Cmb.Items.Add(Rnk.RenkKodListesi[i]);
                    }
                }
            }
        }
        void Control()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is ComboBox || item is Button)
                {
                    item.Enabled = false;
                }
            }
        }
        private void Cmb_RenkSecim_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control();
            int Sayac = 1;
            ComboBox Cmb = (ComboBox)sender;
            if (Cmb_RenkSecim.SelectedIndex==0)
            {
                foreach (Control item in groupBox1.Controls)
                {                  
                    if (item is ComboBox || item is Button)
                    {
                        
                        if (item is ComboBox &&Sayac<5)
                        {
                            Sayac++;
                            item.Enabled = true;
                        }
                        else if (item is Button)
                        {
                            item.Enabled = true;
                        }
                    }
                }
            }
            else if(Cmb_RenkSecim.SelectedIndex==1)
            {
               foreach (Control item in groupBox1.Controls)
               {
                  if (item is ComboBox || item is Button)
                  {
                        item.Enabled = true;
                  }
               }   
            }
        }

        private void Cmb_Renk1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ComboBox Cmb = (ComboBox)sender;
            switch (Cmb.Name)
            {
                case "Cmb_Renk1":
                    Lbl_Renk1.BackColor = Color.FromName(Rnk.RenkKodListesiIng[Array.IndexOf(Rnk.RenkKodListesi,Cmb.Text)]);
                    Lbl_Renk1.ForeColor= Color.FromName(Rnk.RenkKodListesiIng[Array.IndexOf(Rnk.RenkKodListesi, Cmb.Text)]);
                    break;
                case "Cmb_Renk2":
                    Lbl_Renk2.BackColor = Color.FromName(Rnk.RenkKodListesiIng[Array.IndexOf(Rnk.RenkKodListesi, Cmb.Text)]);
                    Lbl_Renk2.ForeColor = Color.FromName(Rnk.RenkKodListesiIng[Array.IndexOf(Rnk.RenkKodListesi, Cmb.Text)]);
                    break;
                case "Cmb_Renk3":
                    Lbl_Renk3.BackColor = Color.FromName(Rnk.RenkKodListesiIng[Array.IndexOf(Rnk.RenkKodListesi, Cmb.Text)]);
                    Lbl_Renk3.ForeColor = Color.FromName(Rnk.RenkKodListesiIng[Array.IndexOf(Rnk.RenkKodListesi, Cmb.Text)]);
                    break;
                case "Cmb_Renk4":
                    Lbl_Renk4.BackColor = Color.FromName(Rnk.RenkKodListesiIng[Array.IndexOf(Rnk.RenkKodListesi, Cmb.Text)]);
                    Lbl_Renk4.ForeColor = Color.FromName(Rnk.RenkKodListesiIng[Array.IndexOf(Rnk.RenkKodListesi, Cmb.Text)]);
                    break;
                case "Cmb_Renk5":
                    Lbl_Renk5.BackColor = Color.FromName(Rnk.RenkKodListesiIng[Array.IndexOf(Rnk.RenkKodListesi, Cmb.Text)]);
                    Lbl_Renk5.ForeColor = Color.FromName(Rnk.RenkKodListesiIng[Array.IndexOf(Rnk.RenkKodListesi, Cmb.Text)]);
                    break;
                default:
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Tolerans = string.Empty;
            //string Deger = string.Empty;
            //double Toplam = 0;
            if (Cmb_RenkSecim.SelectedIndex == 0)
            {
                //Deger = $"{Cmb_Renk1.SelectedIndex}{Cmb_Renk2.SelectedIndex}";
                //Toplam = (Convert.ToUInt32(Deger) * Math.Pow(10, Cmb_Renk3.SelectedIndex))/1000;
                //Txt_Deger.Text = Toplam.ToString() + "kΩ";
                if (Cmb_Renk4.Text=="Altın")
                {
                    Tolerans = "%5";
                }
                else if (Cmb_Renk4.Text=="Gümüş")
                {
                    Tolerans = "%10";
                }
                Txt_Deger.Text = Convert.ToString((Convert.ToInt32($"{Cmb_Renk1.SelectedIndex}{Cmb_Renk2.SelectedIndex}") * Math.Pow(10, Cmb_Renk3.SelectedIndex)) / 1000) + "kΩ"+Tolerans;
            }
            else if (Cmb_RenkSecim.SelectedIndex == 1)
            {
                if (Cmb_Renk5.Text == "Altın")
                {
                    Tolerans = "%5";
                }
                else if (Cmb_Renk5.Text == "Gümüş")
                {
                    Tolerans = "%10";
                }
                //Deger = $"{Cmb_Renk1.SelectedIndex}{Cmb_Renk2.SelectedIndex}{Cmb_Renk3.SelectedIndex}";
                //Toplam = (Convert.ToUInt32(Deger) * Math.Pow(10, Cmb_Renk4.SelectedIndex)) / 1000;
                //Txt_Deger.Text = Toplam.ToString() + "kΩ";
                Txt_Deger.Text = Convert.ToString((Convert.ToInt32($"{Cmb_Renk1.SelectedIndex}{Cmb_Renk2.SelectedIndex}{Cmb_Renk3.SelectedIndex}") * Math.Pow(10, Cmb_Renk4.SelectedIndex)) / 1000)+ "kΩ"+Tolerans;
            }
        }
    }
}
