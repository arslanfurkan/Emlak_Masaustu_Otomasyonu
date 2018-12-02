using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmlakOtomasyonu_163301012
{
    class Uyarılar
    {
        public static void UsersDosyaBulunamadi()
        {
            MessageBox.Show("Kullanıcı kayıtlarının bulunduğu dosya bulunamadı!", "Dosya bulunamadı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void LoginInputEksik()
        {
            MessageBox.Show("Lütfen kullanıcı adı ve parolanızı eksiksiz giriniz!", "Değer giriniz!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void LoginBaşarısız()
        {
            MessageBox.Show("Kullanıcı adı ve parolanız sistemle uyuşmuyor!", "Giriş Başarısız!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ResimKaldırıldı()
        {
            MessageBox.Show("Resim kaldırıldı.");
        }
        public static void ResimSecilmedi()
        {
            MessageBox.Show("Lütfen bir resim seçiniz!");
        }
        public static void EklemeYanlısGiriş(string eksiklik)
        {
            MessageBox.Show("'" + eksiklik + "' Kısmını tekrar kontrol ediniz!","Eksiklik var!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
        public static void NullEvDonusu(string tür)
        {
            MessageBox.Show("Hiç bir '"+tür+"' ev kaydı mevcut değil!", "Dosya boş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void KritereUygunEvYok(string tür)
        {
            MessageBox.Show("Girdiğiniz kriterde '" + tür + "' ev kaydı bulunamadı!", "Başka kriterde arayın!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void DegistirmeBasarılı()
        {
            MessageBox.Show("Ev özellikleri değiştirildi!", "Değiştirme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ArsivlemeBasarılı()
        {
            MessageBox.Show("Ev başarıyla arşivlendi!", "Arşivleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void SilmeBasarılı()
        {
            MessageBox.Show("Ev başarıyla silindi!", "Silme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void EvEklemeBaşarılı()
        {
            MessageBox.Show("Ev başarıyla eklendi!", "Ekleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}