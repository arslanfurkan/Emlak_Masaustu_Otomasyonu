using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmlakOtomasyonu_163301012
{
    public partial class MDIAnaMenu : Form
    {
        private FormLogin loginFormRef;
        public MDIAnaMenu(FormLogin loginFormRef)
        {
            InitializeComponent();
            this.loginFormRef = loginFormRef;

        }


        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
              ToolStripMenuItem clickedOn = sender as ToolStripMenuItem;
           
              Form form = null;

                if (clickedOn.Tag.ToString() == "Ekle")              
                    form = FormEkle.FormEkleOlustur(this);              
                else                 
                    form = FormSorgula.FormSorgulaOlustur(this);
                
              
              form.Show();
        }

        private void MDIAnaMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginFormRef.Close();
        }
    }
}
