namespace EmlakOtomasyonu_163301012
{
    partial class MDIAnaMenu
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIAnaMenu));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.EvEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EvEkleToolStripMenuItem,
            this.evGörüntüleToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(948, 43);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "Ev Çıkar";
            // 
            // EvEkleToolStripMenuItem
            // 
            this.EvEkleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.EvEkleToolStripMenuItem.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.EvEkleToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.EvEkleToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.EvEkleToolStripMenuItem.Name = "EvEkleToolStripMenuItem";
            this.EvEkleToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 10, 5);
            this.EvEkleToolStripMenuItem.Size = new System.Drawing.Size(80, 39);
            this.EvEkleToolStripMenuItem.Tag = "Ekle";
            this.EvEkleToolStripMenuItem.Text = "Ev Ekle";
            this.EvEkleToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // evGörüntüleToolStripMenuItem
            // 
            this.evGörüntüleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.evGörüntüleToolStripMenuItem.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.evGörüntüleToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.evGörüntüleToolStripMenuItem.Name = "evGörüntüleToolStripMenuItem";
            this.evGörüntüleToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 10, 0);
            this.evGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(124, 39);
            this.evGörüntüleToolStripMenuItem.Tag = "Sorgula";
            this.evGörüntüleToolStripMenuItem.Text = "EV SORGULA";
            this.evGörüntüleToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // MDIAnaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 558);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MDIAnaMenu";
            this.Text = "Emlakçı";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIAnaMenu_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem EvEkleToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem evGörüntüleToolStripMenuItem;
    }
}



