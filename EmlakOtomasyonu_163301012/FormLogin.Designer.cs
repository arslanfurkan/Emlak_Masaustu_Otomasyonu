namespace EmlakOtomasyonu_163301012
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxKullaniciAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxParola = new System.Windows.Forms.TextBox();
            this.buttonGiriş = new System.Windows.Forms.Button();
            this.checkBoxParolaGoster = new System.Windows.Forms.CheckBox();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // textBoxKullaniciAdi
            // 
            this.textBoxKullaniciAdi.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBoxKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxKullaniciAdi.Location = new System.Drawing.Point(156, 15);
            this.textBoxKullaniciAdi.MaxLength = 13;
            this.textBoxKullaniciAdi.Name = "textBoxKullaniciAdi";
            this.textBoxKullaniciAdi.Size = new System.Drawing.Size(171, 30);
            this.textBoxKullaniciAdi.TabIndex = 1;
            this.textBoxKullaniciAdi.Text = "furkan";
            this.textBoxKullaniciAdi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxKullaniciAdi_KeyDown);
            this.textBoxKullaniciAdi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SadeceSayıVeHarfler_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(23, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Parola :";
            // 
            // textBoxParola
            // 
            this.textBoxParola.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBoxParola.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxParola.Location = new System.Drawing.Point(156, 55);
            this.textBoxParola.MaxLength = 13;
            this.textBoxParola.Name = "textBoxParola";
            this.textBoxParola.PasswordChar = '*';
            this.textBoxParola.Size = new System.Drawing.Size(171, 30);
            this.textBoxParola.TabIndex = 2;
            this.textBoxParola.Text = "123";
            this.textBoxParola.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxKullaniciAdi_KeyDown);
            this.textBoxParola.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SadeceSayıVeHarfler_KeyPress);
            // 
            // buttonGiriş
            // 
            this.buttonGiriş.BackColor = System.Drawing.Color.Green;
            this.buttonGiriş.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGiriş.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonGiriş.Location = new System.Drawing.Point(154, 116);
            this.buttonGiriş.Name = "buttonGiriş";
            this.buttonGiriş.Size = new System.Drawing.Size(171, 40);
            this.buttonGiriş.TabIndex = 3;
            this.buttonGiriş.Text = "GİRİŞ ";
            this.buttonGiriş.UseVisualStyleBackColor = false;
            this.buttonGiriş.Click += new System.EventHandler(this.buttonGiriş_Click);
            this.buttonGiriş.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonGiriş_KeyDown);
            // 
            // checkBoxParolaGoster
            // 
            this.checkBoxParolaGoster.AutoSize = true;
            this.checkBoxParolaGoster.Location = new System.Drawing.Point(156, 91);
            this.checkBoxParolaGoster.Name = "checkBoxParolaGoster";
            this.checkBoxParolaGoster.Size = new System.Drawing.Size(128, 21);
            this.checkBoxParolaGoster.TabIndex = 6;
            this.checkBoxParolaGoster.Text = "Parolayı Göster";
            this.checkBoxParolaGoster.UseVisualStyleBackColor = true;
            this.checkBoxParolaGoster.CheckedChanged += new System.EventHandler(this.checkBoxParolaGoster_CheckedChanged);
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.textBoxParola);
            this.panelLogin.Controls.Add(this.checkBoxParolaGoster);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Controls.Add(this.buttonGiriş);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.textBoxKullaniciAdi);
            this.panelLogin.Location = new System.Drawing.Point(12, 12);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(367, 175);
            this.panelLogin.TabIndex = 7;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(389, 197);
            this.Controls.Add(this.panelLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(407, 244);
            this.MinimumSize = new System.Drawing.Size(407, 244);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Yapın!";
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxKullaniciAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxParola;
        private System.Windows.Forms.Button buttonGiriş;
        private System.Windows.Forms.CheckBox checkBoxParolaGoster;
        private System.Windows.Forms.Panel panelLogin;
    }
}