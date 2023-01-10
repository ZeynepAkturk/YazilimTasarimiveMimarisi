using System;

namespace ChainOfResponsibilityDeseni_Ornek0
{
    class Program
    {
        /*  bir video oynatıcısı uygulaması yapıyor olalım. Kullanıcı avi,mpg,flv uzantılı
        video dosyası seçip oynat düğmesine bastığında oluşturacağımız desene istek
        gönderilsin ve dosyanın uzantısına göre ilgili sınıflar tarafından oynatılsın.*/

        static void Main(string[] args)
        {
            VideoDosyasi avi = new Avi();
            VideoDosyasi mpg= new Mpg();
            VideoDosyasi flv = new Flv();

            avi.setVideoDosyasi(mpg);
            mpg.setVideoDosyasi(flv);

            avi.videoOynat("mezuniyet.flv");

        }
    }

    public abstract class VideoDosyasi
    {
        private VideoDosyasi sonrakiVideoDosyasi;
        public VideoDosyasi getVideoDosyasi() { return sonrakiVideoDosyasi; }
        public void setVideoDosyasi(VideoDosyasi videoDosyasi) { sonrakiVideoDosyasi = videoDosyasi; }

        public abstract void videoOynat(string videoUzantisi);
        
    }
    public class Avi : VideoDosyasi
    {
     

        public override void videoOynat(string videoUzantisi)
        {
            if(videoUzantisi.EndsWith(".avi"))
            {
                Console.WriteLine("Dosya avi uzantisi olarak oynatılıyor.");
            }
            else
            {
              if(getVideoDosyasi()!=null)
                {
                    getVideoDosyasi().videoOynat(videoUzantisi);
                }
            }
        }
    }
    public class Mpg : VideoDosyasi
    {
        public override void videoOynat(string videoUzantisi)
        {
            if (videoUzantisi.EndsWith(".mpg"))
            {
                Console.WriteLine("Dosya mpg uzantisi olarak oynatılıyor.");
            }
            else
            {
                if (getVideoDosyasi() != null)
                {
                    getVideoDosyasi().videoOynat(videoUzantisi);
                }
            }
        }
    }
    public class Flv : VideoDosyasi
    {
        public override void videoOynat(string videoUzantisi)
        {
            if (videoUzantisi.EndsWith(".flv"))
            {
                Console.WriteLine("Dosya flv uzantisi olarak oynatılıyor.");
            }
            else
            {
                if (getVideoDosyasi() != null)
                {
                    getVideoDosyasi().videoOynat(videoUzantisi);
                }
            }
        }
    }

}
