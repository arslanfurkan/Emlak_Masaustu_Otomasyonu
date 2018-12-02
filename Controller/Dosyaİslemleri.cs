using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Controller
{
    public static class Dosyaİslemleri
    {
        

        public static bool KullanıcıVarMı(string kulAdi,string parola)
        {
            List<Kullanıcı> kullanicilar = KullanicilariOku();
            try
            {
                for (int i = 0; i < kullanicilar.Count; i++)
                {
                    if (kulAdi == kullanicilar[i].KullanıcıAdı && parola == kullanicilar[i].Parola)
                    {
                        return true;
                    }                                                     
                }
                return false;
            }
            catch(NullReferenceException e1)
            {
                Console.WriteLine("Hata Mesajı:" + e1.Message);
                
            }
            catch(IndexOutOfRangeException e2)
            {
                Console.WriteLine("Hata Mesajı:" + e2.Message);
            }
            return false;


        }
        private static List<Kullanıcı> KullanicilariOku()
        {
            if (File.Exists(@"users.txt"))
            {                
                FileStream dosya = new FileStream(@"users.txt", FileMode.Open, FileAccess.Read);
                StreamReader oku = new StreamReader(dosya, Encoding.GetEncoding("iso-8859-9"));

                var pos = dosya.Position;
                List<Kullanıcı> kullanicilar=new List<Kullanıcı>();
               

                while (!oku.EndOfStream)
                {
                    String[] tut = oku.ReadLine().Split('-');
                    Kullanıcı yeniKullanıcı = new Kullanıcı(tut[0], tut[1]);

                    kullanicilar.Add(yeniKullanıcı);                 
                }
                dosya.Close();
                oku.Close();
                return kullanicilar;
            }
            else
            {               
                return null;
            }
        }




        public static void EvEkle(Ev ev)
        {
            FileStream file = new FileStream(@ev.DosyaAdı, FileMode.Append, FileAccess.Write);
            StreamWriter yaz = new StreamWriter(file, Encoding.GetEncoding("iso-8859-9"));

            if (ev.HizmetTipi == "satılık")
            {
                SatılıkEv se = (SatılıkEv)ev;
                yaz.WriteLine(se.EmlakNumarası + "-" + se.YapımTarihi + "-" + se.LogTarihi + "-" + se.OdaSayısı + "-" + se.KatNumarası + "-" + se.Il + "-" + se.Ilçe + "-" + se.Alanı + "-" + se.Türü + "-" + se.Aktif + "-" + se.Fiyatı );
            }
            else
            {
                KiralıkEv ke = (KiralıkEv)ev;
                yaz.WriteLine(ke.EmlakNumarası + "-" + ke.YapımTarihi + "-" + ke.LogTarihi + "-" + ke.OdaSayısı + "-" + ke.KatNumarası + "-" + ke.Il + "-" + ke.Ilçe + "-" + ke.Alanı + "-" + ke.Türü + "-" + ke.Aktif + "-" + ke.Depositosu + "-" + ke.Kirası );
            }
            yaz.Close();
            file.Close();

        }





        
        public static List<KiralıkEv> KiralıkEvleriOku()
        {
            if (File.Exists(@"kiralık.txt"))
            {
                FileStream dosya = new FileStream(@"kiralık.txt", FileMode.Open, FileAccess.Read);
                StreamReader oku = new StreamReader(dosya, Encoding.GetEncoding("iso-8859-9"));

                var pos = dosya.Position;
                List<KiralıkEv> evlerKiralık = new List<KiralıkEv>();

                while (!oku.EndOfStream)
                {
                  
                    String[] tut = oku.ReadLine().Split('-');

                    int emNo = int.Parse(tut[0]);
                    DateTime dtY = DateTime.Parse(tut[1]);
                    DateTime dtLog = DateTime.Parse(tut[2]);
                    /*
                    DateTime dtY = DateTime.ParseExact(, "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                    DateTime dtLog = DateTime.ParseExact(tut[2], "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                    */
                    int odaS = int.Parse(tut[3]);
                    int katNo = int.Parse(tut[4]);
                    string il = tut[5];
                    string ilce = tut[6];
                    int alan = int.Parse( tut[7]);
                    Tür tür = TürDondur(tut[8]);
                    bool aktif = Convert.ToBoolean(tut[9]);
                    decimal deposito = decimal.Parse(tut[10]);
                    decimal kira = decimal.Parse(tut[11]);
                   

                    KiralıkEv okunanKiralıkEv = new KiralıkEv(dtY, odaS, katNo, il, ilce, alan, tür, aktif, emNo, dtLog, deposito, kira);
                   
                    evlerKiralık.Add(okunanKiralıkEv);
               
                }
                dosya.Close();
                oku.Close();
                return evlerKiralık;
            }
            else
            {
                return new List<KiralıkEv>(); ;
            }
        }
        public static List<SatılıkEv> SatılıkEvleriOku()
        {
            if (File.Exists(@"satılık.txt"))
            {
                FileStream dosya = new FileStream(@"satılık.txt", FileMode.Open, FileAccess.Read);
                StreamReader oku = new StreamReader(dosya, Encoding.GetEncoding("iso-8859-9"));

                var pos = dosya.Position;
                List<SatılıkEv> evlerSatılık = new List<SatılıkEv>();

                while (!oku.EndOfStream)
                {

                    String[] tut = oku.ReadLine().Split('-');

                    int emNo = int.Parse(tut[0]);
                    DateTime dtY = DateTime.Parse(tut[1]);
                    DateTime dtLog = DateTime.Parse(tut[2]);
                    /*
                    DateTime dtY = DateTime.ParseExact(, "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                    DateTime dtLog = DateTime.ParseExact(tut[2], "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                    */
                    int odaS = int.Parse(tut[3]);
                    int katNo = int.Parse(tut[4]);
                    string il = tut[5];
                    string ilce = tut[6];
                    int alan = int.Parse(tut[7]);
                    Tür tür = TürDondur(tut[8]);
                    bool aktif = Convert.ToBoolean(tut[9]);
                    decimal fiyat = decimal.Parse(tut[10]);
                   


                    SatılıkEv okunanSatılıkEv = new SatılıkEv(dtY, odaS, katNo, il, ilce, alan, tür, aktif, emNo, dtLog, fiyat);
                   
                    evlerSatılık.Add(okunanSatılıkEv);

                }
                dosya.Close();
                oku.Close();
                return evlerSatılık;
            }
            else
            {
                return new List<SatılıkEv>(); ;
            }
        }
        public static List<Ev> TümEvlerDondur()
        {
            List<SatılıkEv> satılıkEv = SatılıkEvleriOku();
            List<KiralıkEv> kiralıkEv = KiralıkEvleriOku();
            List<Ev> ortakEvler = new List<Ev>();

            for (int i = 0; i < satılıkEv.Count; i++)
            {
                ortakEvler.Add(satılıkEv[i]);
            }
            for (int i = 0; i < kiralıkEv.Count; i++)
            {
                ortakEvler.Add(kiralıkEv[i]);
            }
            return ortakEvler;
        }
        public static void Degistir(KiralıkEv kiralıkEv)
        {
            List<KiralıkEv> kiralıkEvler = KiralıkEvleriOku();
            File.Delete(@"kiralık.txt");
            for (int i = 0; i < kiralıkEvler.Count; i++)
            {
                if (kiralıkEvler[i].EmlakNumarası == kiralıkEv.EmlakNumarası)
                {
                    kiralıkEvler[i] = kiralıkEv;                 
                }
                EvEkle(kiralıkEvler[i]);
            }
               
        }
        public static void Degistir(SatılıkEv satılıkEv)
        {
            List<SatılıkEv> satılıkEvler = SatılıkEvleriOku();
            File.Delete(@"satılık.txt");
            for (int i = 0; i < satılıkEvler.Count; i++)
            {
                if (satılıkEvler[i].EmlakNumarası == satılıkEv.EmlakNumarası)
                {
                    satılıkEvler[i] = satılıkEv;
                }
                EvEkle(satılıkEvler[i]);
            }
        }
        public static void Sil(KiralıkEv kiralıkEv)
        {
            List<KiralıkEv> kiralıkEvler = KiralıkEvleriOku();
            File.Delete(@"kiralık.txt");
            Directory.Delete(@"resimler\" + kiralıkEv.EmlakNumarası + "/",true);
            for (int i = 0; i < kiralıkEvler.Count; i++)
            {
                if (kiralıkEvler[i].EmlakNumarası == kiralıkEv.EmlakNumarası)
                {
                    kiralıkEvler.RemoveAt(i);
                }
              
            }

            for (int i = 0; i < kiralıkEvler.Count; i++)
            {
                EvEkle(kiralıkEvler[i]);
            }

        }

        public static void Sil(SatılıkEv satılıkEv)
        {
            List<SatılıkEv> satılıkEvler = SatılıkEvleriOku();
            File.Delete(@"satılık.txt");
            Directory.Delete(@"resimler\" + satılıkEv.EmlakNumarası + "/",true);
            for (int i = 0; i < satılıkEvler.Count; i++)
            {
                if (satılıkEvler[i].EmlakNumarası == satılıkEv.EmlakNumarası)
                {
                    satılıkEvler.RemoveAt(i);
                }              
            }

            for (int i = 0; i < satılıkEvler.Count; i++)
            {
                EvEkle(satılıkEvler[i]);
            }
        }

        public static int IDPicker()
        {
            if (TümEvlerDondur().Count == 0)
            {
                return 1;
            }
            else
            {
                List<Ev> tümevler = TümEvlerDondur();
                tümevler = tümevler.OrderByDescending(x => x.EmlakNumarası).ToList();
                return tümevler[0].EmlakNumarası+1;
            }
        }
        
        public static List<String> İlçelerDondur(String il)
        {

            if (File.Exists(@"iller\"+il+".txt"))
            {
                FileStream dosya = new FileStream(@"iller\" + il + ".txt", FileMode.Open, FileAccess.Read);
                StreamReader oku = new StreamReader(dosya, Encoding.GetEncoding("iso-8859-9"));

                List<String> listİlceler = new List<string>();

                while (!oku.EndOfStream)
                {
                    String tut = oku.ReadLine();


                    listİlceler.Add(tut);
                }
                dosya.Close();
                oku.Close();
                return listİlceler;
            }
            else
            {
                return null;
            }
         
        }

        public static void ResmiKaydet(string[] paths,int name)
        {


            int i = 0;
            if (Directory.Exists(@"resimler\"+name))
            {
                foreach(string path in paths)
                {
                    int index = path.IndexOf('.');

                    string uzantı = path.Substring(index,path.Length-index );
                   
                    File.Move(path, "resimler/"+name+"/"+i+uzantı);
                    i++;
                }
              
            }
            else
            {
                Directory.CreateDirectory(@"resimler\" + name);
                foreach (string path in paths)
                {
                    int index = path.IndexOf('.');
                    string uzantı = path.Substring(index, path.Length - index);
                    File.Move(path, "resimler/" + name + "/" + i + uzantı);
                    i++;
                }
            }

        }

        public static int Fiyatİste(int odaSayısı)
        {
            if (File.Exists(@"room_cost.txt"))
            {
                FileStream dosya = new FileStream(@"room_cost.txt", FileMode.Open, FileAccess.Read);
                StreamReader oku = new StreamReader(dosya, Encoding.GetEncoding("iso-8859-9"));
                int okunanKatsayı = int.Parse(oku.ReadLine());


                dosya.Close();
                oku.Close();
                return odaSayısı * okunanKatsayı;
                
            }
            else
            {
                return 0;
            }
        }


        public static Tür TürDondur(string türAdı)
        {
            if (türAdı == "Daire")
            {
                return Tür.Daire;
            }
            else if (türAdı == "Bahçeli")
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
                return Tür.Hepsi;
            }
        }

        


    }
}
