using System;

namespace BuilderDeseni_Ornek0
{
    class Program
    {
        /*
         • Üç farklı otomobilin üretimini sağlayan builder
         deseninin UML diyagramını çiziniz ve kodlayınız.
         • Otomobil özellik ve işlevleri: Marka, Model, 
          Koltuk*/

        static void Main(string[] args)
        {
            IOtomobilBuilder otomobil = new MercedesBuilder();
            Director director = new Director();
            director.otomobillUret(otomobil);
        }
    }

    public class Director
    {
        public void otomobillUret(IOtomobilBuilder otomobil)
        { 
            otomobil.koltukUret();
            otomobil.markaOlustur();
            otomobil.modelOlustur();
        }

    }
    public abstract class IOtomobilBuilder
    {
        protected Otomobil otomobil;
        public Otomobil getOtomobil()
        { return otomobil; }
        public abstract  void markaOlustur();
        public abstract void modelOlustur();
        public abstract void koltukUret();

    }
    public class MercedesBuilder : IOtomobilBuilder
    {
        public MercedesBuilder()
        {
            otomobil = new Otomobil();
        }
        public override void koltukUret()
        {
            otomobil.setKoltuk("kırmızı koltuk");        }

        public override void markaOlustur()
        {
            otomobil.setMarka("Mercedes");
        }

           
        public override void modelOlustur()
        {
            otomobil.setModel("s200");
        }
    }


    public class Otomobil
    {
        private string marka;
        private string model;
        private string koltuk;
        public string getMarka() { return marka; }
        public void setMarka(string marka) { this.marka = marka; }
        public string getModel() { return model; }
        public void setModel(string model) { this.model = model; }
        public string getKoltuk() { return koltuk; }
        public void setKoltuk(string koltuk) { this.koltuk = koltuk; }

    }
}
