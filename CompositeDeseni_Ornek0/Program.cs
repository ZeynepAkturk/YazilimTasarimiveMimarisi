using System;
using System.Collections.Generic;

namespace CompositeDeseni_Ornek0
{
    class Program
    {
        static void Main(string[] args)
        {
            Sirket kisi1 = new Kisi("Zeynep", "Yazilim");
            Sirket kisi2 = new Kisi("Ali", "Mekanik");
            Sirket yazilim = new YazilimBolumu("Yazilim","Yazilim");
            yazilim.Ekle(kisi1);
            yazilim.Ekle(kisi2);
            yazilim.Yazdir();
        }
    }


    public abstract class Sirket
    {
        private string isim;
        private string departman;

        public string getIsim() { return isim; }
        public void setIsim(string isim) { this.isim = isim; }
        
        public string getDepartman() { return departman; }
        public void setDepartman(string departman) { this.departman= departman; }

        public Sirket(string isim, string departman)
        {
            setDepartman(departman);
            setIsim(isim);
        }

        public abstract void Ekle(Sirket sirket);
        public abstract void Sil(Sirket sirket);
        public abstract void Yazdir();
    }

    public class Kisi : Sirket
    {
        public Kisi(string isim, string departman):base(isim, departman) { }
      

        public override void Ekle(Sirket sirket)
        {
            
        }

       

        public override void Sil(Sirket sirket)
        {
           
        }

       

        public override void Yazdir()
        {
           
        }
    }
    public class YazilimBolumu : Sirket
    {
        List<Sirket> liste;

        public YazilimBolumu(string isim,string departman):base(isim,departman)
        {
            liste = new List<Sirket>() ;

        }
       
       

        public override void Ekle(Sirket sirket)
        {
            liste.Add(sirket);
        }



        public override void Sil(Sirket sirket)
        {
            liste.Remove(sirket);
        }
       

        public override void Yazdir()
        {   foreach( Sirket liste in liste)
            Console.WriteLine("kisi adi: " + liste.getIsim() + " departman: " + liste.getDepartman());
        }
    }
}
