using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    class Kullanıcı
    {
        private string kullanıcıAdı;
        private string parola;
        public Kullanıcı(string kullanıcıAdı,string parola)
        {
            this.kullanıcıAdı = kullanıcıAdı;
            this.parola = parola;
        }
        public string KullanıcıAdı
        {
            get { return kullanıcıAdı; }
        }
        public string Parola
        {
            get { return parola; }
        }

    }
}
