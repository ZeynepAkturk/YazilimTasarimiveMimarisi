using System;

namespace BridgeDeseni_Ornek0
{
    class Program
    {
        /* Uygulamamız belirli bir şablonda rapor hazırlayan (satış ve çalışan 
           performans raporları gibi) ve bu raporları da farklı formatlarda (Web 
           Formatı ya da masaüstü formatı gibi) sisteme kaydeden bir işleve 
           sahip olsun. Böyle bir durumda sınıf diyagramı nasıl tasarlanır? */
        static void Main(string[] args)
        {
            IRapor rapor = new CalisanRaporu();
            rapor.raporOlustur(new Web());
        }
    }

    public interface IRapor
    {
       
        public void raporOlustur(IFormat format);
    }

    public class CalisanRaporu : IRapor
    {
        public void raporOlustur(IFormat format)
        {
            Console.WriteLine("Çalışan raporu oluşturuldu.");
            format.Kaydet();
        }
    }
    public class SatisRaporu : IRapor
    {
        public void raporOlustur(IFormat format)
        {
            Console.WriteLine("Satış raporu oluşturuldu.");
            format.Kaydet();
        }
    }
    public class PerformansRaporu : IRapor
    {
        public void raporOlustur(IFormat format)
        {
            Console.WriteLine("Performans raporu oluşturuldu.");
            format.Kaydet();
        }
    }

    public interface IFormat
    {
        public void Kaydet();
    }

    public class Masaustu : IFormat
    {
        public void Kaydet()
        {
            Console.WriteLine("Masaüstü formatında kaydedildi.");
        }
    }
    public class Web : IFormat
    {
        public void Kaydet()
        {
            Console.WriteLine("Web formatında kaydedildi.");
        }
    }
}
