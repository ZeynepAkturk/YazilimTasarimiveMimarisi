using System;

namespace FacadeDeseni_Ornek2
{
    class Program
    {
        static void Main(string[] args)
        {
            AkilliEv akilliev = new AkilliEv();
            akilliev.EvdenAyrıl();
        }
    }

    public class AkilliEv
    {
        Klima klima = new Klima();
        IsikSistemi isik = new IsikSistemi();

        public void EvdenAyrıl()
        {
            klima.klimaKapa();
            isik.isikKapa();
        }
        public void EveGir()
        {
            klima.klimaAc();
            isik.isikAc();
        }
    }
    public class Klima
    {
       
        public void klimaAc()
        {
            Console.WriteLine("Klima açıldı.");
        }
        public void klimaKapa()
        {
            Console.WriteLine("Klima kapatıldı.");
        }
    }

    public class IsikSistemi
    {
        public void isikAc()
        {
            Console.WriteLine("Işık sistemi açıldı.");
        }
        public void isikKapa()
        { Console.WriteLine("Işık sistemi kapatıldı.");

        }
    }
}
