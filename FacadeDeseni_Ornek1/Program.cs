using System;

namespace FacadeDeseni_Ornek1
{
    class Program
    {
        static void Main(string[] args)
        {
            Banka banka = new Banka();
            banka.EftYap();
            banka.krediKullan();
        }
    }
    public class EFT
    {
        public void EftYap()
        {
            Console.WriteLine("Eft işlemi gerçekleştirildi.");
        }
    }
    public class Kredi
    {
        public void KrediKullan()
        {
            Console.WriteLine("Kredi işlemi gerçekleştirildi.");
        }
    }
    public class Bakiye
    {
        public bool BakiyeKontrol()
        {
            return false;
        }

    }
    public class Bloke
    {
        public bool BlokeKontrol()
        {
            return false;
        }

    }
    public class Banka
    {
        Kredi kredi = new Kredi();
        EFT eft = new EFT();
        Bloke bloke = new Bloke();
        Bakiye bakiye = new Bakiye();


        public void krediKullan()
        {
            if (bakiye.BakiyeKontrol() && (!bloke.BlokeKontrol()))
            {
                kredi.KrediKullan();
            }
            else
                Console.WriteLine("Kredi kullanımı onaylanmamıştır.");
        }

        public void EftYap()
        {
            if (bakiye.BakiyeKontrol() && (!bloke.BlokeKontrol()))
            {
                eft.EftYap();
            }
            else
                Console.WriteLine("Eft kullanımı onaylanmamıştır.");
        }
    }
}
