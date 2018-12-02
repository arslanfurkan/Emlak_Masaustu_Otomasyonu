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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonGiriş_Click(object sender, EventArgs e)
        {

            //Dosyadan gelen şifre eşlesmesi ile aşağıdakı 3 kod parçacığı çalışacaktır.
            if (InputKontrol())
            {
                if (Dosyaİslemleri.KullanıcıVarMı(textBoxKullaniciAdi.Text, textBoxParola.Text))
                {
                    MDIAnaMenu mdiAnaMenu = new MDIAnaMenu(this);
                    mdiAnaMenu.Show();
                    Hide();
                }
                else
                {
                    Uyarılar.LoginBaşarısız();
                }
            }
            else
            {
                FormuTemizle();
                Uyarılar.LoginInputEksik();               
            }
          
        }

        public void FormuTemizle()
        {
            textBoxKullaniciAdi.Clear();
            textBoxParola.Clear();
        }
        public bool InputKontrol()
        {
            if (textBoxKullaniciAdi.Text.Trim() != "" && textBoxParola.Text.Trim() != "")
            {
                return true;
            }
            return false;
            
        }



        private void SadeceSayıVeHarfler_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void buttonGiriş_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonGiriş_Click(sender, e);
        }

       
        private void textBoxKullaniciAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();

                }
            }
        }

        private void checkBoxParolaGoster_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            textBoxParola.PasswordChar = cb.Checked ? '\0' : '*';
        }
    }
}
