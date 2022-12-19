using System;
using System.Collections.Generic;

namespace FacadeDeseni_Ornek0
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            facade.KaraListeUyeEkle("Zeynep");
            facade.KaraListeUyeEkle("Ayşe");
            facade.KaraListeUyeEkle("Ali");
            facade.Sistem2UyeEkle("Beyza");
        }
    }
    public class Sistem1
    {
        private string uye;
        private List<string> karaListe;

        public string getUye() { return uye; }
        public void setUye(string uye) { this.uye = uye; }

        public List<string> getKaraListe() { return karaListe; }
        public void setKaraListe(string uye) { karaListe.Add(uye); }



        public Sistem1(string uye)
        {
            setUye(uye);
            karaListe = new List<string>();
        }

        public void KaraListeUyeEkle(string uye)
        {
            setKaraListe(uye);
        }

        public bool KaraListeKontrol(string uye)
        {
            bool onay = true;
            if (karaListe != null)
                foreach (string uyeler in karaListe)
                {
                    if (uye == uyeler)
                    {
                        onay = false;

                    }

                }
            return onay;
        }

    }
    public class Sistem2
    {
        private string uye;

        public string getUye() { return uye; }
        public void setUye(string uye) { this.uye = uye; }


        public void uyeOl(string uye)
        {
            setUye(uye);
        }
    }

    public class Kimlik
    {
        public bool KimlikDogrulama(string uye)
        {
            return true;
        }
    }

    public class Facade
    {
        Sistem1 sistem1 = new Sistem1("Voldemort");
        Sistem2 sistem2 = new Sistem2();
        Kimlik kimlik = new Kimlik();

        public void KaraListeUyeEkle(string uye)
        {
            sistem1.KaraListeUyeEkle(uye);
        }


        public void Sistem2UyeEkle(string uye)
        {
            if (sistem1.KaraListeKontrol(uye) && kimlik.KimlikDogrulama(uye))
            {
                sistem2.uyeOl(uye);
                Console.WriteLine("Sistem2 ye üye eklenmiştir.");
            }
            else
                Console.WriteLine("Sisteme üye eklenememiştir.");
        }
    }
}
