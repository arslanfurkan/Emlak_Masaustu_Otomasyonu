using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;

namespace EmlakOtomasyonu_163301012
{
    public partial class FormEkle : Form
    {
        private static MDIAnaMenu mdiAna;
        private static FormEkle formEkle;
        private static string [] yüklenenResimler;
        protected FormEkle(MDIAnaMenu MdiAna)
        {
            InitializeComponent();
            comboBoxİller.SelectedIndex = 0;
            comboBoxTürü.SelectedIndex = 0;
            mdiAna = MdiAna;
            MdiParent = mdiAna;
            yüklenenResimler = null;
        }
        public static FormEkle FormEkleOlustur(MDIAnaMenu mDIAna)
        {
            if (formEkle == null)
            {
                formEkle = new FormEkle(mDIAna);
               
            }
            else
            {
                formEkle.Location = new Point(0, 0);
                formEkle.Activate();
            }
            return formEkle;
        }





        private void buttonEkle_Click(object sender, EventArgs e)
        {
            if (GirişKontrol())
            {
                int emNo = Dosyaİslemleri.IDPicker();
                DateTime dtY = dateTimePickerYapımTarihi.Value;
                DateTime dtLog = DateTime.Now;
                int odaS = (int)numericUpDownOdaSayısı.Value;
                int katNo = (int)numericUpDownKatNo.Value;
                string il = comboBoxİller.SelectedItem.ToString();
                string ilce = comboBoxİlçeler.SelectedItem.ToString();
                int alan = (int)numericUpDownAlan.Value;
                Tür tür = TürDondur(comboBoxTürü.SelectedItem.ToString());
                bool aktif = checkBoxAktif.Checked;

             

            
                if (radioButtonKiralık.Checked)
                {                 
                    decimal deposito = numericUpDownDeposito.Value;
                    decimal kira = numericUpDownKira.Value;
                 
                    KiralıkEv yeniKiralıkEv = new KiralıkEv(dtY, odaS, katNo, il, ilce, alan, tür, aktif, emNo, dtLog, deposito, kira);

                    if (yüklenenResimler != null)
                    {          
                         Dosyaİslemleri.ResmiKaydet(yüklenenResimler, yeniKiralıkEv.EmlakNumarası);

                    }

                   
          
                    Dosyaİslemleri.EvEkle(yeniKiralıkEv);
                }
                else
                {
                    decimal fiyat = numericUpDownFiyat.Value;
                    SatılıkEv yeniSatılıkEv = new SatılıkEv(dtY, odaS, katNo, il, ilce, alan, tür, aktif, emNo, dtLog, fiyat);
                    if (yüklenenResimler != null)
                    {
                        Dosyaİslemleri.ResmiKaydet(yüklenenResimler, yeniSatılıkEv.EmlakNumarası);
                    }
                 
                    Dosyaİslemleri.EvEkle(yeniSatılıkEv);
                }

                Uyarılar.EvEklemeBaşarılı();
                
            }
        }
        private void buttonİdealFiyat_Click(object sender, EventArgs e)
        {
            numericUpDownKira.Value =Dosyaİslemleri.Fiyatİste((int)numericUpDownOdaSayısı.Value);
        }







        private void FormEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            formEkle = null;
            mdiAna = null;
        }

        private void radioButtonKiralık_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                panelKiralık.Enabled = true;
                panelSatılık.Enabled = false;
            }               
            else
            {
                panelKiralık.Enabled = false;
                panelSatılık.Enabled = true;
            }
                


        }

        private void comboBoxİller_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxİlçeler.Items.Clear();
            List<String> ilçeler = Dosyaİslemleri.İlçelerDondur(comboBoxİller.SelectedItem.ToString());
            try
            {
                for (int i = 1; i < ilçeler.Count; i++)
                {
                    comboBoxİlçeler.Items.Add(ilçeler[i]);
                }
                comboBoxİlçeler.SelectedIndex = 0;

            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void onlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text.Trim()!="")
            {
                if (tb.Text[0] == '0')
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            
        }

        private void buttonResimEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"; ;
            ofd.InitialDirectory = @"C:\";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
              
                yüklenenResimler = ofd.FileNames;          
                  
                ofd = null;
            }
            else
                Uyarılar.ResimSecilmedi();

        }


        public bool GirişKontrol()
        {
            if (radioButtonKiralık.Checked)
            {
                if (numericUpDownKira.Value <1)
                {
                    Uyarılar.EklemeYanlısGiriş("Kira");
                    return false;
                }
                else if(numericUpDownKira.Value < 0)
                {
                    Uyarılar.EklemeYanlısGiriş("Deposito");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (numericUpDownKira.Value < 1)
                {
                    Uyarılar.EklemeYanlısGiriş("Fiyat");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public  Tür TürDondur(string türAdı)
        {
            if (türAdı == "Daire")
            {
                return Tür.Daire;
            }
            else if(türAdı =="Bahçeli")
            {
                return Tür.Bahçeli;
            }
            else if (türAdı == "Dubleks")
            {
                return Tür.Dubleks;
            }
            else if (türAdı == "Müstakil")
            {
                return Tür.Müstakil;
            }
            else
            {
                throw new Exception("Tür uyuşmazlığı oldu");
            }
        }

        private Image ResmiKopyala(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }

       
    }


}
