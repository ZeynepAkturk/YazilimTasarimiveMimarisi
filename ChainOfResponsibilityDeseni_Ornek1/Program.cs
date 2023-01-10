using System;

namespace ChainOfResponsibilityDeseni_Ornek1
{
    class Program
    {
        static void Main(string[] args)
        {
            KBBSkoru kbbskor = new KBBSkoru(10000);
            KrediKarti kredikarti = new KrediKarti(true);
            Kefil kefil = new Kefil(true);
            Gelir gelir = new Gelir(5000);
            Firma firma = new Firma(true);

            kbbskor.set_SonrakiKrediSarti(kredikarti);
            kredikarti.set_SonrakiKrediSarti(kefil);
            kefil.set_SonrakiKrediSarti(gelir);
            gelir.set_SonrakiKrediSarti(firma);

            kbbskor.KrediVer(5000);
        }
        /*bir bankacılık uygulaması gerçekleştirdiğinizi ve kredi modülünde
        çalıştığınızı düşünün. Herhangi bir müşteri kredi başvurusunda bulunduğu zaman
        kredinin verilip verilmeyeceğine karar verirken aşağıdaki maddelere dikkat etmeniz
        söylendi. 
        Müşterinin KBB skoruna bak. Skor 1000’den düşükse direk ret ver. Burada hiç kayıt
        olmaması durumunu dikkate almıyoruz.
        Daha önceden kredi kartı var mı, varsa kredi kartına ait borçları ne kadar süreyle
        geciktirmiş? Bu geciktirme süresi 3 aydan fazla ise direk ret ver.
        Müşterinin kefili iyi mi? Değilse ret ver. Kefilin her türlü olduğunu varsayıyoruz.
        Müşterinin aylık geliri istenen krediyi ödemeye yeterli mi? Değilse direk ret ver.
        Müşterinin çalıştığı firma, kurumsal bir firma mıdır? Değilse direk ret ver.*/
    }

    public abstract class KrediSartlari
    {
        private KrediSartlari _sonrakiKrediSarti;
        public KrediSartlari get_SonrakiKrediSarti() { return _sonrakiKrediSarti; }
        public void  set_SonrakiKrediSarti(KrediSartlari _sonrakiKrediSarti) { this._sonrakiKrediSarti = _sonrakiKrediSarti; }

        public abstract void KrediVer(double krediMiktari);
    }

    public class KBBSkoru : KrediSartlari
    {
        private int kbbSkoru;
        public int getKbbSkoru() { return kbbSkoru; }
        public void setKbbSkoru(int kbbSkoru) { this.kbbSkoru = kbbSkoru; }
        public KBBSkoru(int kbbSkoru)
        {
            setKbbSkoru(kbbSkoru);
        }
        public override void KrediVer(double krediMiktari)
        {
            if (getKbbSkoru() < 1000)

            { Console.WriteLine("Kredi kartı başvurunuz Kbb skorunuz nedeniyle reddedildi."); }
            else
            {
                if (get_SonrakiKrediSarti() != null)
                {
                    get_SonrakiKrediSarti().KrediVer(krediMiktari);
                }
            }
            
        }
    }
    public class KrediKarti : KrediSartlari
    {   
        private bool krediBorcu;
        public bool getKrediBorcu() { return krediBorcu; }
        public void setKrediBorcu(bool krediborc) { this.krediBorcu = krediborc; }

        public KrediKarti(bool borcVarmi)
        {
            setKrediBorcu(borcVarmi);
        }
        public override void KrediVer(double krediMiktari)
        {
            if(getKrediBorcu()==false)
            {
                Console.WriteLine("Kredi karı başvurunuz, kredi kartı borcunuz nedeniyle reddedildi.");

            }
            else
            {
                if(get_SonrakiKrediSarti()!=null)
                {
                    get_SonrakiKrediSarti().KrediVer(krediMiktari);
                }
            }
           
        }
    }

    public class Kefil : KrediSartlari
    {

        private bool kefil;
        public bool getKefil() { return kefil; }
        public void setKefil(bool kefil) { this.kefil = kefil; }

        public Kefil(bool kefilIyiMi)
        {
            setKefil(kefilIyiMi);
        }
        public override void KrediVer(double krediMiktari)
        {
            if(getKefil()==false)
            {
                Console.WriteLine("Kredi kartı başvurunuz, kefiliniz dolayısıyla reddedilmiştir.");
            }
            else if(get_SonrakiKrediSarti()!=null)
                {
                    get_SonrakiKrediSarti().KrediVer(krediMiktari);
                }
            else
            {
                Console.WriteLine("Kredi kartı başvurunuz onaylanmıştır.");
            }
            
        }
    }
    public class Gelir : KrediSartlari
    {
        private int gelir;
        public int getGelir() { return gelir; }
        public void setGelir(int gelir) { this.gelir = gelir; }

        public Gelir(int gelir)
        {
            setGelir(gelir);
        }
        public override void KrediVer(double krediMiktari)
        {
          if(gelir<krediMiktari)
            {
                Console.WriteLine("Kredi kartı başvurunuz geliriniz uygun olmadığı için reddeilmiştir.");
            }
           else if (get_SonrakiKrediSarti() != null)
            {
                get_SonrakiKrediSarti().KrediVer(krediMiktari);
            }
            else
            {
                Console.WriteLine("Kredi kartı başvurunuz onaylanmıştır.");
            }
        }
    }
    public class Firma : KrediSartlari
    {
        private bool firmaKurumsal;
        public bool getFirmaKurumsal() { return firmaKurumsal; }
        public void setFirmaKurumsal(bool firmaKurumsal) { this.firmaKurumsal = firmaKurumsal; }
        public Firma(bool firmaKurumsalMi)
        {
            setFirmaKurumsal(firmaKurumsalMi);
        }
        public override void KrediVer(double krediMiktari)
        {
            if (firmaKurumsal==false)
            {
                Console.WriteLine("Kredi kartı başvurunuz şirketiniz uygun olmadığı için reddeilmiştir.");
            }
            else if (get_SonrakiKrediSarti() != null)
            {
                get_SonrakiKrediSarti().KrediVer(krediMiktari);
            }
            else
            {
                Console.WriteLine("Kredi kartı başvurunuz onaylanmıştır.");
            }

        }
    }

}
