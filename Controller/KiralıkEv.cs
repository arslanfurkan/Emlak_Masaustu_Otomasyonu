using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class KiralıkEv :    Ev
    {
        private decimal depositosu;
        private decimal kirası;

        public decimal Depositosu { get => depositosu; set => depositosu = value; }
        public decimal Kirası { get => kirası; set => kirası = value; }

       public KiralıkEv(DateTime yapımTarihi, int odaSayısı, int katNumarası, string il,string ilçe, int alanı, Tür türü, bool aktif, int emlakNumarası, DateTime logTarihi,decimal depositosu,decimal kirası) :
       base(yapımTarihi,odaSayısı, katNumarası, il,  ilçe, alanı, türü, aktif, emlakNumarası, logTarihi)
        {
            DosyaAdı = "kiralık.txt";
            HizmetTipi = "kiralık";


            Depositosu = depositosu;
            Kirası = kirası;
        }
        

        public override decimal FiyatHesapla()
        {
            return Dosyaİslemleri.Fiyatİste(OdaSayısı);
        }
        public override string EvBilgileri()
        {
            return string.Format("Ev ID : {0}\nEvin Yaşı: {1} \nOda Sayısı: {2} \nKat Numarası: {3} \nSemt : {4} \nEmlak Türü:{5}\nSemti: {5}/nKira: {6}\nDeposito : {7}\nAktiflik : {8} ", EmlakNumarası, Yas, OdaSayısı, KatNumarası, Türü, Semt, Kirası, Depositosu,Aktif);
        }
    }
}
