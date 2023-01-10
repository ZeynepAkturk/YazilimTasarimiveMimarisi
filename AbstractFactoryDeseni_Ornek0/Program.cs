using System;

namespace AbstractFactoryDeseni_Ornek0
{
    class Program
    { /*İki farklı bilgisayar firması bilgisayarları için RAM ve HDD üretmektedir. Bu süreci
modelleyen yazılım sınıflarını ve UML sınıf diyagramlarını abstract factory tasarım
deseni ile gerçekleştiriniz.*/
        static void Main(string[] args)
        {
            Istemci istemci = new Istemci(new Lenovo());
            istemci.Birlestir();
        }
    }
    public class Istemci
    {
        IBilgisayar bilgisayar;
        IRam ram;
        IHdd hdd;
        public Istemci(IBilgisayar bilgisayar)
        {
            this.bilgisayar = bilgisayar;
            this.ram = bilgisayar.RamSec();
            this.hdd = bilgisayar.HddSec();
        }
        public void Birlestir()
        {
            ram.RamIslem();
            hdd.HddIslem();
        }
    }
    public interface IBilgisayar
    {
        public IRam RamSec();
        public IHdd HddSec();
    }
    public class Lenovo : IBilgisayar
    {
        public IHdd HddSec()
        {
            return new HddB();
        }

        public IRam RamSec()
        {
            return new RamB();
        }
    }
    public class Casper : IBilgisayar
    {
        public IHdd HddSec()
        {
            return new HddA();
        }

        public IRam RamSec()
        {
            return new RamB();
        }
    }
    public interface IRam
    {
        public void RamIslem();
    }

    public class RamA : IRam
    {
        public void RamIslem()
        {
            Console.WriteLine("RamA kullanılıyor.");
        }
    }
    public class RamB : IRam
    {
        public void RamIslem()
        {
            Console.WriteLine("RamB kullanılıyor.");
        }
    }

    public interface IHdd
    {
        public void HddIslem();
    }
    public class HddA : IHdd
    {
        public void HddIslem()
        {
            Console.WriteLine("HddA kullanılıyor.");
        }
    }
    public class HddB : IHdd
    {
        public void HddIslem()
        {
            Console.WriteLine("HddB kullanılıyor.");
        }
    }
}
