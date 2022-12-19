using System;

namespace AdapterDeseni_Ornek0
{
    /*Önceden yazılmış iskontolu tutarı hesaplayan bir tane sınıfımız olsun.Bu sınıfımızı tutar hesaplama
    uygulamamıza entegre etmeye çalışalım*/
    class Program
    {
        static void Main(string[] args)
        {
    
            ITutar adapter = new Adapter(1000, 20);

            Console.WriteLine("Tutar: " + adapter.TutarHesapla());
           
        }
    }


    public class IskontoluTutar
    {
        private float normalFiyat;
        private float indirimOrani;

        public float getNormalFiyat() { return normalFiyat; }
        public void setNormalFiyat(float fiyat) { normalFiyat = fiyat; }

        public float getİndirimOrani() { return indirimOrani; }

        public void setİndirimOrani(float indirim) { if ((indirimOrani >= 0) && (indirimOrani <= 100))
                                                   { indirimOrani = indirim; } 
                                                   else
                                                   { Console.WriteLine("Geçerli bir değer giriniz!");
                                                      
                                                   } 
                                                 }

        public IskontoluTutar(float fiyat, float indirim)
        {
            setNormalFiyat(fiyat);
            setİndirimOrani(indirim);
        }

        public float İskontoluTutarHesapla()
        {
            float iskontoluFiyat = (getNormalFiyat() * ((100 - getİndirimOrani()) / 100));
            return iskontoluFiyat;
        }

    }

    public interface ITutar
    {
       float TutarHesapla();
    }

    public class Tutar : ITutar
    {
        private float fiyat;
        public float getFiyat() { return fiyat; }
        public void setFiyat(float fiyat) { this.fiyat = fiyat; }


        
        public float TutarHesapla()
        {
            return getFiyat();
        }
    }

    public class Adapter : ITutar
    {
        IskontoluTutar iskontoluTutar;
        
        public Adapter(float fiyat, int indirim)
        {
            iskontoluTutar = new IskontoluTutar(fiyat, indirim);
        }
        public float TutarHesapla()
        {
           return iskontoluTutar.İskontoluTutarHesapla();
        }
    }


}
