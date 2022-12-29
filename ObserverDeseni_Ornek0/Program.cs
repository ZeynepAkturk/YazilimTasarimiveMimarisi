using System;
using System.Collections.Generic;

namespace ObserverDeseni_Ornek0
{
    class Program
    {
        /* Uygulamamızda ürünler ve üyeler olsun. Ürünün fiyatı değiştiğinde 
        o ürünü takip listesine ekleyen üyelere haber versin */
        static void Main(string[] args)
        {
            Urun urun = new Urun("Lenovo Bilgisayar", 4000);
            Uye uye = new Uye1("Zeynep");
            Uye uye1 = new Uye1("Sevgi");
            urun.uyeEkle(uye);
            urun.uyeEkle(uye1);
            urun.fiyatGuncelle(1000);
            
            
        }

        //takip edilen sınıf -> ürün takipçi, observer sınıf -> üye

        public abstract class Uye
        {
            private string isim;
         
            public string getIsim() { return isim; }
            public void setIsim(string isim) { this.isim = isim; }

            public Uye(string isim)
            {
            
                setIsim(isim);
            }
            public  abstract void takipListesineEkle();
        }

        public class Uye1 : Uye
        {
            public Uye1(string isim) : base(isim) { }
            public override void takipListesineEkle()
            {
                Console.WriteLine( "Urun "+ getIsim()+ " üyesinin takip listesine eklendi.");
            }
        }

        public class Urun
        {
            private string ad;
            private float fiyat;
            private List<Uye> liste;

            public Urun(string ad, float fiyat)
            {
                liste = new List<Uye>();
                setAd(ad);
                setFiyat(fiyat); }
            public string getAd() { return ad; }
            public void setAd(string ad) { this.ad = ad; }

            public float getFiyat() { return fiyat; }
            public void setFiyat(float fiyat) { this.fiyat = fiyat; }

            public void uyeEkle(Uye uye)
            {
                liste.Add(uye);

            }
            public void uyeSil(Uye uye)
            {
                liste.Remove(uye);
            }

            public void  fiyatGuncelle (float fiyat)
            {
                if (this.fiyat >= fiyat)
                {
                    uyelereHaberVer();
                }
            }
            public void uyelereHaberVer()
            {
                foreach(Uye uye in liste)
                {

                    { uye.takipListesineEkle(); }
                    
                }
            }
            
           


        }
    }
}
