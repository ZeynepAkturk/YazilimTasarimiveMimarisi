using System;
using System.Collections.Generic;

namespace ObserverDeseni_Ornek1
{
    class Program
    {    /*
         2. Örnek olarak bir gsm operatöründe çalışıldığı ve iş kuralı olarak
            şirket tarafından şöyle bir şey istendiği düşülsün:
            Beş ay hiç kontör yüklemeyen kullanıcılarımıza kampanya yapın.
            Çünkü yapılan veri ambarı analiz sonuçlarına göre bu kadar süre
            kontör yüklemeyen kullanıcılar operatörünü değiştirmeye meyillidir.
            Ne yapıp edip onları kaçırmamız lazım. Hatta bununla da kalmayıp
            bedava kontör de verelim dedikleri varsayılsın.

            Takip edilen sınıf-> Musteriler  takip eden, gözlemci sınıf-> Operator
        */
        static void Main(string[] args)
        {
            IOperator gsm = new GsmOperator();
            Musteri musteri = new Musteri1();
            musteri.operatorEkle(gsm);
            musteri.musteriKontrol();

        }

        public abstract class Musteri
        {
            private string isim;
            private List<IOperator> liste = new List<IOperator>();
            public string getIsim() { return isim; }
            public void setIsim(string isim) { this.isim = isim; }

            public void operatorEkle(IOperator op)
            {
                liste.Add(op);
            }
            public void operatorSil(IOperator op)
            {
                liste.Remove(op);
            }
            public void operatorHaberVer()
            {
                foreach(IOperator operatorler in liste)
                {
                    operatorler.kampanyaYap(this);
                }
            }
            public void musteriKontrol()
            {
                operatorHaberVer();
            }


        }

        public class Musteri1:Musteri
        {

        }

        public interface IOperator
        {
            public void kampanyaYap(Musteri musteri);
        }
        public class GsmOperator : IOperator
        {
            public void kampanyaYap(Musteri musteri)
            {
                Console.WriteLine("Gsm operatorü olarak %20 indirim yapılmıştır.");
            }
        }
    }
}
