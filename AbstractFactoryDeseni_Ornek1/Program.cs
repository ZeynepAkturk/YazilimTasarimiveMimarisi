using System;

namespace AbstractFactoryDeseni_Ornek1
{
    class Program
    {
        /*örnekte araba kasası ve araba lastiği
        üreten farklı iki firmanın üretimi modellenmektedir.*/

        static void Main(string[] args)
        {
            Istemci istemci = new Istemci(new Mercedes());
            istemci.ArabaUret();
        }
    }
    public class Istemci
    {
        ArabaLastigi lastik;
        ArabaKasasi kasa;
        ArabaFabrikasi fabrika;
        public Istemci(ArabaFabrikasi fabrika)
        {
            this.fabrika = fabrika;
            kasa = fabrika.kasaUret();
            lastik = fabrika.lastikUret();
        }
        public void ArabaUret()
        {
            kasa.KasaTak();
            lastik.LastikTak();
            
        }

    }
    public interface ArabaFabrikasi
    {
        public ArabaKasasi kasaUret();
        public ArabaLastigi lastikUret();
    }
    public class Mercedes : ArabaFabrikasi
    {
        public ArabaKasasi kasaUret()
        {
            return new KasaMercedes();
        }

        public ArabaLastigi lastikUret()
        {
            return new LastikMercedes();
        }
    }
    public class Ford : ArabaFabrikasi
    {
        public ArabaKasasi kasaUret()
        {
            return new KasaFord();
        }

        public ArabaLastigi lastikUret()
        {
            return new LastikFord();
        }
    }
    public interface ArabaLastigi
    {
        public void LastikTak();
    }
    public class LastikMercedes :ArabaLastigi
    {
        public void LastikTak()
        {
            Console.WriteLine("Mercedes lastiği takıldı.");
        }
    }
    public class LastikFord:ArabaLastigi
    {
        public void LastikTak()
        {
            Console.WriteLine("Ford lastiği takıldı.");
        }
    }
    public interface ArabaKasasi
    {
        public void KasaTak();
    }
    public class KasaMercedes : ArabaKasasi
    {
        public void KasaTak()
        {
            Console.WriteLine("Mercedes Kasası takıldı.");
        }
    }
    public class KasaFord : ArabaKasasi
    {
        public void KasaTak()
        {
            Console.WriteLine("Ford Kasası takıldı.");
        }
    }
}
