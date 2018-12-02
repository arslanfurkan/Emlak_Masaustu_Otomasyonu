using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public enum Tür
    {
        Daire,
        Bahçeli,
        Dubleks,
        Müstakil,
        Hepsi
    }
    public abstract class Ev
    {
        
        //yazmak icin
        protected Ev (DateTime yapımTarihi,int odaSayısı,int katNumarası,string il,string ilçe ,int alanı,Tür türü,bool aktif, int emlakNumarası, DateTime logTarihi)
        {
            YapımTarihi = yapımTarihi;
            GirilenOdaSayısı = girilenOdaSayısı;
            OdaSayısı = odaSayısı;
            KatNumarası = katNumarası;
            Il = il;
            Ilçe = ilçe;
            Alanı = alanı;
            Türü = türü;
            Aktif = aktif;
            EmlakNumarası = emlakNumarası;
            LogTarihi = logTarihi;
           
        }

        //kurucu overload
        protected Ev(int odaSayısı, int katNumarası, string il, string ilçe, int alanı)
        {
            OdaSayısı = odaSayısı;
            KatNumarası = katNumarası;
            Il = il;
            Ilçe = ilçe;
            Alanı = alanı;
        }


        private int girilenOdaSayısı;
        private int odaSayısı;
        private int katNumarası;
        private string il;
        private string ilçe;
        private int alanı;
        private DateTime yapımTarihi;
        private DateTime logTarihi;
        private Tür türü;
        private bool aktif;
        private int emlakNumarası;//UNİC
        private string dosyaAdı;
        private string hizmetTipi;


        public int MyProperty { get; set; }
        public int OdaSayısı
        {
            get
            {
                return odaSayısı;
            }
            set
            {
                if (value > 0)
                    odaSayısı = value;
                else
                    odaSayısı = 0;
            }
        }
        public int KatNumarası
        {
            get
            {
                return katNumarası;
            }
            set
            {
                if (value > 0)
                    katNumarası = value;
                else
                    katNumarası = 0;
            }
        }
        public int GirilenOdaSayısı { get => girilenOdaSayısı; set => girilenOdaSayısı = value; }
        public int Alanı { get => alanı; set => alanı = value; }
        public Tür Türü { get => türü; set => türü = value; }
        public bool Aktif { get => aktif; set => aktif = value; }
        public int EmlakNumarası { get => emlakNumarası; set => emlakNumarası = value; }
        public DateTime YapımTarihi { get => yapımTarihi; set => yapımTarihi = value; }
        public DateTime LogTarihi { get => logTarihi; set => logTarihi = value; }
        public string Il { get => il; set => il = value; }
        public string Ilçe { get => ilçe; set => ilçe = value; }

        public int Yas
        {
            get
            {
                return (DateTime.Now.Year - yapımTarihi.Year);
            }
        }

        public string Semt
        {
            get
            {
                return string.Format("{0}/{1}", Ilçe, Il);
            }
        }

        public string DosyaAdı { get => dosyaAdı; set => dosyaAdı = value; }
        public string HizmetTipi { get => hizmetTipi; set => hizmetTipi = value; }


        public abstract string EvBilgileri();
        public abstract decimal FiyatHesapla();


    }
}
