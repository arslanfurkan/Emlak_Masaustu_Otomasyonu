using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class SatılıkEv:Ev
    {
        private decimal fiyatı;
        public SatılıkEv(DateTime yapımTarihi, int odaSayısı, int katNumarası, string il, string ilçe, int alanı, Tür türü, bool aktif, int emlakNumarası, DateTime logTarihi, decimal fiyatı) :
        base(yapımTarihi, odaSayısı, katNumarası, il, ilçe, alanı, türü, aktif, emlakNumarası, logTarihi)
        {
            DosyaAdı = "satılık.txt";
            HizmetTipi = "satılık";
            Fiyatı = fiyatı;
        }

        public override decimal FiyatHesapla()
        {
            throw new NotImplementedException();
        }
        public override string EvBilgileri()
        {
            return string.Format("Ev ID : {0}\nEvin Yaşı: {1} \nOda Sayısı: {2} \nKat Numarası: {3} \nSemt : {4} \nEmlak Türü:{5}\nSemti: {5}/Fiyat: {6} \nAktiflik : {7} ", EmlakNumarası, Yas, OdaSayısı, KatNumarası, Türü, Semt, Fiyatı,Aktif);
        }

        public decimal Fiyatı { get => fiyatı; set => fiyatı = value; }
    }
}
