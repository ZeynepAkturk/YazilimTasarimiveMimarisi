using System;

namespace FactoryDeseni_Ornek0
{
    class Program
    {
        /*Bir kapı ürünümüz mevcut ve ürünün ahşap, çelik, plastik olmak üzere çeşitleri var ve bu ürünü kullanan bir fabrika sınıfımız olacak.*/
        static void Main(string[] args)
        {
            KapiFabrikasi kf = new KapiFabrikasi();
            IKapi kapi = kf.dondur("celik");
            kapi.setle(100,"celik" );
        }
    }

    public interface IKapi
    {
        void setle(int boyut, string malzeme);
    }
    public class AhsapKapi : IKapi
    {
        private int boyut;
        private string malzeme;
        public void setle(int boyut, string malzeme)
        {
            this.boyut = boyut;
            this.malzeme = malzeme;
        }
    }

    public class CelikKapi : IKapi
    {
        private int boyut;
        private string malzeme;
        public void setle(int boyut, string malzeme)
        {
            this.boyut = boyut;
            this.malzeme = malzeme;
        }
    }
    public class PlastikKapi : IKapi
    {
        private int boyut;
        private string malzeme;
        public void setle(int boyut, string malzeme)
        {
            this.boyut = boyut;
            this.malzeme = malzeme;
        }
    }
    public interface IFabrika
    {
        IKapi dondur(string kapiMalzemesi);
    }

    public class KapiFabrikasi : IFabrika
    {
        public IKapi dondur(string kapiMalzemesi)
        {
            if(kapiMalzemesi=="ahsap")
            { return new AhsapKapi(); }
            else if(kapiMalzemesi=="celik")
            { return new CelikKapi(); }
            else
            {
                return new PlastikKapi();
            }
        }
    }
}
