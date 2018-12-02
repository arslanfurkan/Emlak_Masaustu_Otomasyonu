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
using Controller;

namespace EmlakOtomasyonu_163301012
{
    public partial class FormSorgula : Form
    {
        private static MDIAnaMenu mdiAna;
        private static FormSorgula formSorgula;
        private static KiralıkEv secilenKiralıkEv;
        private static SatılıkEv secilenSatılıkEv; 
        protected FormSorgula(MDIAnaMenu MdiAna)
        {
            InitializeComponent();
            mdiAna = MdiAna;
            MdiParent = mdiAna;
            comboBoxSecilenİl.SelectedIndex = 0;
            comboBoxTür.SelectedIndex = 0;
            secilenKiralıkEv = null;
            secilenSatılıkEv = null;
        }
        public static FormSorgula FormSorgulaOlustur(MDIAnaMenu mDIAna)
        {
            if (formSorgula == null)
            {
                formSorgula = new FormSorgula(mDIAna);

            }
            else
            {
                formSorgula.Location = new Point(0, 0);
                formSorgula.Activate();
            }
            return formSorgula;
        }

        

        private void buttonAra_Click(object sender, EventArgs e)
        {
            secilenKiralıkEv = null;
            secilenSatılıkEv = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            panelGoruntulenen.Hide();

            int minYas = (int)numericUpDownMinYaş.Value;
            int maxYas = (int)numericUpDownMaxYaş.Value;
            int minOda = (int)numericUpDownMinOda.Value;
            int maxOda = (int)numericUpDownMaxOda.Value;
            int minKat = (int)numericUpDownMinKat.Value;
            int maxKat = (int)numericUpDownMaxKat.Value;
            int minAlan = (int)numericUpDownMinAlan.Value;
            int maxAlan = (int)numericUpDownMaxAlan.Value;

            decimal minKira = numericUpDownMinKira.Value;
            decimal maxKira = numericUpDownMaxKira.Value;
            decimal minDeposito = numericUpDownMinDeposito.Value;
            decimal maxDeposito = numericUpDownMaxDeposito.Value;

            decimal minFiyat = numericUpDownMinFiyat.Value;
            decimal maxFiyat = numericUpDownMaxFiyat.Value;

            string il = comboBoxSecilenİl.SelectedItem.ToString();
            string ilce = (il == "Hepsi" ? "Hepsi" : comboBoxSecilenİlce.SelectedItem.ToString());

            Tür tür = Dosyaİslemleri.TürDondur(comboBoxTür.SelectedItem.ToString());

            bool aktiflik = checkBoxAktiflik.Checked;
            List<KiralıkEv> kevler = null;
            List<SatılıkEv> sevler = null;

            if (radioButtonKiralık.Checked)
            {
                kevler = Dosyaİslemleri.KiralıkEvleriOku();
                if (kevler == null)
                {
                    Uyarılar.NullEvDonusu("Kiralık");
                }             
                else
                {
                    kevler = kevler.Where(x => x.Yas >= minYas && x.Yas <=maxYas).ToList();
                    kevler = kevler.Where(x => x.OdaSayısı >= minOda && x.OdaSayısı <= maxOda).ToList();
                    kevler = kevler.Where(x => x.KatNumarası >= minKat && x.KatNumarası <= maxKat).ToList();
                    kevler = kevler.Where(x => x.Alanı >= minAlan && x.Alanı <= maxAlan).ToList();
                    kevler = kevler.Where(x => x.Kirası >= minKira && x.Kirası <= maxKira).ToList();
                    kevler = kevler.Where(x => x.Depositosu >= minDeposito && x.Depositosu <= maxDeposito).ToList();
                    if (il != "Hepsi")
                    {
                        kevler = kevler.Where(x => x.Il ==il ).ToList();
                        if(ilce !="Hepsi")
                            kevler = kevler.Where(x => x.Ilçe == ilce).ToList();
                    }
                    if (tür != Tür.Hepsi)
                    {
                        kevler = kevler.Where(x => x.Türü == tür).ToList();
                       
                    }

                    kevler = kevler.Where(x => x.Aktif == aktiflik).ToList();

                    if (kevler.Count == 0)
                    {
                        Uyarılar.KritereUygunEvYok("Kiralık");
                    }
                    else
                    {
                        DataGridAyarla(kevler);
                    }
                   
                }

            }
            else
            {
                sevler = Dosyaİslemleri.SatılıkEvleriOku();
                if (sevler == null)
                {
                    Uyarılar.NullEvDonusu("Satılık");
                }        
                else
                {
                    sevler = sevler.Where(x => x.Yas >= minYas && x.Yas <= maxYas).ToList();
                    sevler = sevler.Where(x => x.OdaSayısı >= minOda && x.OdaSayısı <= maxOda).ToList();
                    sevler = sevler.Where(x => x.KatNumarası >= minKat && x.KatNumarası <= maxKat).ToList();
                    sevler = sevler.Where(x => x.Alanı >= minAlan && x.Alanı <= maxAlan).ToList();
                    sevler = sevler.Where(x => x.Fiyatı >= minFiyat && x.Fiyatı <= maxFiyat).ToList();

                    if (il != "Hepsi")
                    {
                        sevler = sevler.Where(x => x.Il == il).ToList();
                        if (ilce != "Hepsi")
                            sevler = sevler.Where(x => x.Ilçe == ilce).ToList();
                    }
                    if (tür != Tür.Hepsi)
                    {
                        sevler = sevler.Where(x => x.Türü == tür).ToList();

                    }

                    sevler = sevler.Where(x => x.Aktif == aktiflik).ToList();
                    if (sevler.Count == 0)
                    {
                        Uyarılar.KritereUygunEvYok("Satılık");
                    }
                    else
                    {
                        DataGridAyarla(sevler);
                    }

                }
                
            }
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = false;
            }
           
        }

        private void DataGridAyarla(List<KiralıkEv> kiralıkEvler)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Add("IDsütun", "Emlak Numarası");
            dataGridView1.Columns.Add("ALIMTÜRÜsütun", "ALIM TÜRÜ");
            dataGridView1.Columns.Add("ODAsütun", "Oda Sayısı");
            dataGridView1.Columns.Add("KATsütun", "Kat Numarası");
            dataGridView1.Columns.Add("ILsütun", "İl");
            dataGridView1.Columns.Add("ILCEsütun", "İlçe");
            dataGridView1.Columns.Add("ALANsütun", "Alan");
            dataGridView1.Columns.Add("AKTİFLİKsütun", "Aktiflik");
            dataGridView1.Columns.Add("TÜRÜsütun", "Türü");         
            dataGridView1.Columns.Add("YTsütun", "Yapım Tarihi");
            dataGridView1.Columns.Add("LOGtarihi", "Log Tarihi");
            dataGridView1.Columns.Add("KİRAsütun", "Kira");
            dataGridView1.Columns.Add("DEPOSsütun", "Deposito");

            for (int i = 0; i < kiralıkEvler.Count; i++)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = kiralıkEvler[i].EmlakNumarası;
                dataGridView1.Rows[n].Cells[1].Value = kiralıkEvler[i].HizmetTipi;

                dataGridView1.Rows[n].Cells[2].Value = kiralıkEvler[i].OdaSayısı;
                dataGridView1.Rows[n].Cells[3].Value = kiralıkEvler[i].KatNumarası;
                dataGridView1.Rows[n].Cells[4].Value = kiralıkEvler[i].Il;
                dataGridView1.Rows[n].Cells[5].Value = kiralıkEvler[i].Ilçe;
                dataGridView1.Rows[n].Cells[6].Value = kiralıkEvler[i].Alanı;
                dataGridView1.Rows[n].Cells[7].Value = kiralıkEvler[i].Aktif;
                dataGridView1.Rows[n].Cells[8].Value = kiralıkEvler[i].Türü;
                dataGridView1.Rows[n].Cells[9].Value = kiralıkEvler[i].YapımTarihi;
                dataGridView1.Rows[n].Cells[10].Value = kiralıkEvler[i].LogTarihi;
                dataGridView1.Rows[n].Cells[11].Value = kiralıkEvler[i].Kirası;
                dataGridView1.Rows[n].Cells[12].Value = kiralıkEvler[i].Depositosu;
                for (int j = 0; j < dataGridView1.Rows[n].Cells.Count; j++)
                {
                    dataGridView1.Rows[n].Cells[j].ReadOnly = true;
                }

            }
            


        }


        private void DataGridAyarla(List<SatılıkEv> satılıkEvler)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Add("IDsütun", "Emlak Numarası");
            dataGridView1.Columns.Add("ALIMTÜRÜsütun", "ALIM TÜRÜ");
            dataGridView1.Columns.Add("ODAsütun", "Oda Sayısı");
            dataGridView1.Columns.Add("KATsütun", "Kat Numarası");
            dataGridView1.Columns.Add("ILsütun", "İl");
            dataGridView1.Columns.Add("ILCEsütun", "İlçe");
            dataGridView1.Columns.Add("ALANsütun", "Alan");
            dataGridView1.Columns.Add("AKTİFLİKsütun", "Aktiflik");
            dataGridView1.Columns.Add("TÜRÜsütun", "Türü");       
            dataGridView1.Columns.Add("YTsütun", "Yapım Tarihi");
            dataGridView1.Columns.Add("LOGsütun", "Log Tarihi");
            dataGridView1.Columns.Add("FİYATsütun", "Fiyat");

            for (int i = 0; i < satılıkEvler.Count; i++)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = satılıkEvler[i].EmlakNumarası;
                dataGridView1.Rows[n].Cells[1].Value = satılıkEvler[i].HizmetTipi;
                dataGridView1.Rows[n].Cells[2].Value = satılıkEvler[i].OdaSayısı;
                dataGridView1.Rows[n].Cells[3].Value = satılıkEvler[i].KatNumarası;
                dataGridView1.Rows[n].Cells[4].Value = satılıkEvler[i].Il;
                dataGridView1.Rows[n].Cells[5].Value = satılıkEvler[i].Ilçe;
                dataGridView1.Rows[n].Cells[6].Value = satılıkEvler[i].Alanı;
                dataGridView1.Rows[n].Cells[7].Value = satılıkEvler[i].Aktif;
                dataGridView1.Rows[n].Cells[8].Value = satılıkEvler[i].Türü;
                dataGridView1.Rows[n].Cells[9].Value = satılıkEvler[i].YapımTarihi;
                dataGridView1.Rows[n].Cells[10].Value = satılıkEvler[i].LogTarihi;
                dataGridView1.Rows[n].Cells[11].Value = satılıkEvler[i].Fiyatı;
                for (int j = 0; j < dataGridView1.Rows[n].Cells.Count; j++)
                {
                    dataGridView1.Rows[n].Cells[j].ReadOnly = true;
                }

            }


        }














        private void FormGoruntule_FormClosing(object sender, FormClosingEventArgs e)
        {
            formSorgula = null;
            mdiAna = null;
            secilenKiralıkEv = null;
            secilenSatılıkEv = null;
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSecilenİlce.Items.Clear();
            List<String> ilçeler = Dosyaİslemleri.İlçelerDondur(comboBoxSecilenİl.SelectedItem.ToString());
            if (comboBoxSecilenİl.SelectedItem.ToString() != "Hepsi")
            {
                comboBoxSecilenİlce.Enabled = true;
                try
                {
                    for (int i = 0; i < ilçeler.Count; i++)
                    {
                        comboBoxSecilenİlce.Items.Add(ilçeler[i]);
                    }
                    comboBoxSecilenİlce.SelectedIndex = 0;

                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                comboBoxSecilenİlce.Enabled = false;
            }
            
        }

        private void numericUpDownMinYaş_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown minYas = sender as NumericUpDown;
            if(minYas.Value > numericUpDownMaxYaş.Value)
            {
                minYas.Value = numericUpDownMaxYaş.Value-1;
            }
              
        }

        private void numericUpDownMaxYaş_ValueChanged(object sender, EventArgs e)
        {

            NumericUpDown maxYas = sender as NumericUpDown;
            if ( maxYas.Value < numericUpDownMinYaş.Value)
            {
                maxYas.Value = numericUpDownMinYaş.Value+1;
            }
        }

        private void numericUpDownMinOda_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown minOda = sender as NumericUpDown;
            if (minOda.Value > numericUpDownMaxOda.Value)
            {
                minOda.Value = numericUpDownMaxOda.Value - 1;
            }
        }

        private void numericUpDownMaxOda_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown maxOda = sender as NumericUpDown;
            if (maxOda.Value < numericUpDownMinOda.Value)
            {
                maxOda.Value = numericUpDownMinOda.Value + 1;
            }
        }

        private void numericUpDownMinKat_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown minKat = sender as NumericUpDown;
            if (minKat.Value > numericUpDownMaxKat.Value)
            {
                minKat.Value = numericUpDownMaxKat.Value - 1;
            }
        }

        private void numericUpDownMaxKat_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown maxKat = sender as NumericUpDown;
            if (maxKat.Value < numericUpDownMinKat.Value)
            {
                maxKat.Value = numericUpDownMinKat.Value + 1;
            }
        }

        private void numericUpDownMinAlan_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown minAlan = sender as NumericUpDown;
            if (minAlan.Value > numericUpDownMaxAlan.Value)
            {
                minAlan.Value = numericUpDownMaxAlan.Value - 1;
            }
        }

        private void numericUpDownMaxAlan_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown maxAlan = sender as NumericUpDown;
            if (maxAlan.Value < numericUpDownMinAlan.Value)
            {
                maxAlan.Value = numericUpDownMinAlan.Value + 1;
            }
        }

        private void numericUpDownMinKira_ValueChanged(object sender, EventArgs e)
        {

            NumericUpDown minKira = sender as NumericUpDown;
            if (minKira.Value > numericUpDownMaxKira.Value)
            {
                minKira.Value = numericUpDownMaxKira.Value - 1;
            }
        }

        private void numericUpDownMaxKira_ValueChanged(object sender, EventArgs e)
        {

            NumericUpDown maxKira = sender as NumericUpDown;
            if (maxKira.Value < numericUpDownMinKira.Value)
            {
                maxKira.Value = numericUpDownMinKira.Value + 1;
            }
        }

        private void numericUpDownMinDeposito_ValueChanged(object sender, EventArgs e)
        {

            NumericUpDown minDeposito = sender as NumericUpDown;
            if (minDeposito.Value > numericUpDownMaxDeposito.Value)
            {
                minDeposito.Value = numericUpDownMaxDeposito.Value - 1;
            }
        }

        private void numericUpDownMaxDeposito_ValueChanged(object sender, EventArgs e)
        {

            NumericUpDown maxDeposito = sender as NumericUpDown;
            if (maxDeposito.Value < numericUpDownMinDeposito.Value)
            {
                maxDeposito.Value = numericUpDownMinDeposito.Value + 1;
            }
        }

        private void numericUpDownMinFiyat_ValueChanged(object sender, EventArgs e)
        {

            NumericUpDown minFiyat = sender as NumericUpDown;
            if (minFiyat.Value > numericUpDownMaxFiyat.Value)
            {
                minFiyat.Value = numericUpDownMaxFiyat.Value - 1;
            }
        }

        private void numericUpDownMaxFiyat_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown maxFiyat = sender as NumericUpDown;
            if (maxFiyat.Value < numericUpDownMinFiyat.Value)
            {
                maxFiyat.Value = numericUpDownMinFiyat.Value + 1;
            }
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int index = e.RowIndex;
            if(index > -1)
            {
                panelGoruntulenen.Show();
                DataGridViewRow secilenRow = dataGridView1.Rows[index];

                int id = (int)secilenRow.Cells[0].Value;
                string alımTürü = secilenRow.Cells[1].Value.ToString();
                int oda = (int)secilenRow.Cells[2].Value;
                int kat = (int)secilenRow.Cells[3].Value;
                string il = secilenRow.Cells[4].Value.ToString();
                string ilce = secilenRow.Cells[5].Value.ToString();
                int alan = (int)secilenRow.Cells[6].Value;
                bool aktiflik = Boolean.Parse(secilenRow.Cells[7].Value.ToString());
                Tür tür = Dosyaİslemleri.TürDondur(secilenRow.Cells[8].Value.ToString());
                DateTime yapımTarihi = DateTime.Parse(secilenRow.Cells[9].Value.ToString());
                DateTime logTarihi = DateTime.Parse(secilenRow.Cells[10].Value.ToString());



                if (secilenRow.Cells[1].Value.ToString() == "kiralık")
                {
                    decimal kira = (decimal)secilenRow.Cells[11].Value;
                    decimal deposito = (decimal)secilenRow.Cells[12].Value;
                    secilenKiralıkEv = new KiralıkEv(yapımTarihi, oda, kat, il, ilce, alan, tür, aktiflik, id, logTarihi, deposito, kira);
                    GoruntulenenPanelDüzenle(secilenKiralıkEv);
                }
                else
                {
                    decimal fiyat = (decimal)secilenRow.Cells[11].Value;
                    secilenSatılıkEv = new SatılıkEv(yapımTarihi, oda, kat, il, ilce, alan, tür, aktiflik, id, logTarihi, fiyat);
                    GoruntulenenPanelDüzenle(secilenSatılıkEv);
                }
            }
           



        }


        


        private void GoruntulenenPanelDüzenle(KiralıkEv kiralıkEv)
        {
            panelGkiralık.Visible = true;
            panelGkiralık.Enabled = true;          
            panelGsatılık.Visible = false;
            labelGEvNo.Text = "Ev No:";
            labelGAktiflik.Text = "Aktiflik :";

            labelGEvNo.Text = labelGEvNo.Text + kiralıkEv.EmlakNumarası;
            dateTimePickerGyapımTarihi.Value = kiralıkEv.YapımTarihi;
            numericUpDownGodaSayısı.Value = kiralıkEv.OdaSayısı;
            numericUpDownGkatNo.Value = kiralıkEv.KatNumarası;
            comboBoxGil.SelectedItem = kiralıkEv.Il;
            comboBoxGİlçe.SelectedItem = kiralıkEv.Ilçe;
            numericUpDownGalan.Value = kiralıkEv.Alanı;
            comboBoxGtürü.SelectedItem = kiralıkEv.Türü.ToString();
            labelGAktiflik.Text = labelGAktiflik.Text + kiralıkEv.Aktif;
            numericUpDowngKira.Value = kiralıkEv.Kirası;
            numericUpDowngGdeposito.Value = kiralıkEv.Depositosu;
            


        }
        private void GoruntulenenPanelDüzenle(SatılıkEv satılıkEv)
        {
            panelGkiralık.Visible = false;
            panelGsatılık.Visible = true;
            panelGsatılık.Enabled = true;
            labelGEvNo.Text = "Ev No:";
            labelGAktiflik.Text = "Aktiflik :";

            labelGEvNo.Text = labelGEvNo.Text + satılıkEv.EmlakNumarası;
            dateTimePickerGyapımTarihi.Value = satılıkEv.YapımTarihi;
            numericUpDownGodaSayısı.Value = satılıkEv.OdaSayısı;
            numericUpDownGkatNo.Value = satılıkEv.KatNumarası;
            comboBoxGil.SelectedItem = satılıkEv.Il;
            comboBoxGİlçe.SelectedItem = satılıkEv.Ilçe;
            numericUpDownGalan.Value = satılıkEv.Alanı;
            comboBoxGtürü.SelectedItem = satılıkEv.Türü.ToString();
            labelGAktiflik.Text = labelGAktiflik.Text + satılıkEv.Aktif;
            numericUpDownGfiyat.Value = satılıkEv.Fiyatı;
           
        }

        private void buttonGresmiGörüntüle_Click(object sender, EventArgs e)
        {
            if (panelGkiralık.Visible)
            {
                if (!Directory.Exists(@"resimler/" + secilenKiralıkEv.EmlakNumarası))
                {
                    Directory.CreateDirectory(@"resimler/" + secilenKiralıkEv.EmlakNumarası);

                }
                System.Diagnostics.Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\resimler\" + secilenKiralıkEv.EmlakNumarası);

            }          
            else
            {
                if (!Directory.Exists(@"resimler/" + secilenSatılıkEv.EmlakNumarası))
                {
                    Directory.CreateDirectory(@"resimler/" + secilenSatılıkEv.EmlakNumarası);
                }       
                System.Diagnostics.Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\resimler\" + secilenSatılıkEv.EmlakNumarası);

            }
               
        }

        private void buttonGDüzenle_Click(object sender, EventArgs e)
        {
            if (panelGkiralık.Visible)
            {
                secilenKiralıkEv.YapımTarihi = dateTimePickerGyapımTarihi.Value;
                secilenKiralıkEv.OdaSayısı = (int)numericUpDownGodaSayısı.Value;
                secilenKiralıkEv.KatNumarası = (int)numericUpDownGkatNo.Value;
                secilenKiralıkEv.Il = comboBoxGil.SelectedItem.ToString();
                secilenKiralıkEv.Ilçe = comboBoxGİlçe.SelectedItem.ToString();
                secilenKiralıkEv.Alanı =(int) numericUpDownGalan.Value;
                secilenKiralıkEv.Kirası = numericUpDowngKira.Value;
                secilenKiralıkEv.Depositosu = numericUpDowngGdeposito.Value;
                Dosyaİslemleri.Degistir(secilenKiralıkEv);
            }
            else
            {
                secilenSatılıkEv.YapımTarihi = dateTimePickerGyapımTarihi.Value;
                secilenSatılıkEv.OdaSayısı = (int)numericUpDownGodaSayısı.Value;
                secilenSatılıkEv.KatNumarası = (int)numericUpDownGkatNo.Value;
                secilenSatılıkEv.Il = comboBoxGil.SelectedItem.ToString();
                secilenSatılıkEv.Ilçe = comboBoxGİlçe.SelectedItem.ToString();
                secilenSatılıkEv.Alanı = (int)numericUpDownGalan.Value;
                secilenSatılıkEv.Fiyatı = numericUpDownGfiyat.Value;
                Dosyaİslemleri.Degistir(secilenSatılıkEv);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            Uyarılar.DegistirmeBasarılı();
        }

        private void buttonGArsivle_Click(object sender, EventArgs e)
        {
            if (panelGkiralık.Visible)
            {
                secilenKiralıkEv.Aktif = !secilenKiralıkEv.Aktif;
                labelGAktiflik.Text = " Aktiflik : " + secilenKiralıkEv.Aktif;
                Dosyaİslemleri.Degistir(secilenKiralıkEv);
            }
            else
            {
                secilenSatılıkEv.Aktif = !secilenSatılıkEv.Aktif;
                labelGAktiflik.Text = " Aktiflik : " + secilenSatılıkEv.Aktif;
                Dosyaİslemleri.Degistir(secilenSatılıkEv);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            Uyarılar.ArsivlemeBasarılı();

        }

        private void buttonGsil_Click(object sender, EventArgs e)
        {
            if (panelGkiralık.Visible)
            {
                Dosyaİslemleri.Sil(secilenKiralıkEv);
                
            }
            else
            {
                Dosyaİslemleri.Sil(secilenSatılıkEv);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            panelGoruntulenen.Visible = false;

            Uyarılar.SilmeBasarılı();
        }

        private void comboBoxGil_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                
                comboBoxGİlçe.Items.Clear();
                List<String> ilçeler = Dosyaİslemleri.İlçelerDondur(comboBoxGil.SelectedItem.ToString());
                try
                {
                    for (int i = 1; i < ilçeler.Count; i++)
                    {
                    comboBoxGİlçe.Items.Add(ilçeler[i]);
                    }
                comboBoxGİlçe.SelectedIndex = 0;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            

        }

        private void buttonEvYaşı_Click(object sender, EventArgs e)
        {
            if (panelGkiralık.Visible)
            {
                textBoxEvYas.Text = secilenKiralıkEv.Yas.ToString();
            }
            else
            {
                textBoxEvYas.Text = secilenSatılıkEv.Yas.ToString();
            }
        }
    }
}
