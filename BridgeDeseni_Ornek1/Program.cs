using System;

namespace BridgeDeseni_Ornek1
{
    class Program
    {

        /*  Uygulamada veri tabanı yapısı ele alınsın.
            Uygulama birden fazla veri tabanı desteği veriyor 
            olsun ve execute, connection açma gibi operasyonlar 
            her veri tabanı için farklı olsun
        */
        static void Main(string[] args)
        {
            Veritabani veritabani = new Veritabani1(new Oracle());
            veritabani.Baglan();
            veritabani.Uygula();
        }
    }

    public interface IVeriTabani
    {
        public void uygula();
        public void baglantiAc();

    }
    public class Oracle : IVeriTabani
    {
        public void baglantiAc()
        {
            Console.WriteLine("Oracle ile bağlantı gerçekleştirildi.");
        }

        public void uygula()
        {
            Console.WriteLine("Oracle veritabanı uygulandı.");
        }
    }

    public class MySql:IVeriTabani
    {
        public void baglantiAc()
        {
            Console.WriteLine("MySql ile bağlantı gerçekleştirildi.");
        }

        public void uygula()
        {
            Console.WriteLine("MySql veritabanı uygulandı.");
        }

    }

    public abstract class Veritabani
    {
        IVeriTabani veritabani;

        public Veritabani(IVeriTabani veritab)
        {
            veritabani = veritab;
        }
        public IVeriTabani GetVeriTabani() { return veritabani; }
        
        public abstract void Baglan();
        public abstract void Uygula();
    }
    public class Veritabani1 : Veritabani
    {
        public Veritabani1(IVeriTabani veritab) : base(veritab) { }
        public override void Baglan()
        {
            GetVeriTabani().baglantiAc();
        }

        public override void Uygula()
        {
            GetVeriTabani().uygula();
        }
    }

}
