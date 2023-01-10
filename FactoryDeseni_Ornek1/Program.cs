using System;

namespace FactoryDeseni_Ornek1
{
    class Program
    {
        static void Main(string[] args)
        {
            IFabrika fabrika = new Fabrika();
            Dosya dosya = fabrika.dosyaOlustur("excel");
            dosya.dosyaIslem();
        }
    }

    public interface Dosya
    {
        public void dosyaIslem();
    }

    public class Excel : Dosya
    {
        public void dosyaIslem()
        {
            Console.WriteLine("Dosya excel formatında oluşturuldu.");
        }
    }
    public class Pdf : Dosya
    {
        public void dosyaIslem()
        {
            Console.WriteLine("Dosya Pdf formatında oluşturuldu.");
        }
    }
    public interface IFabrika
    {
        public Dosya dosyaOlustur(string format);
    }

    public class Fabrika : IFabrika
    {
        public Dosya dosyaOlustur(string format)
        {
            if (format == "pdf")
            {
                return new Pdf();
            }

            else
            {
                return new Excel();
            }
        }
    }
    
     
    }

