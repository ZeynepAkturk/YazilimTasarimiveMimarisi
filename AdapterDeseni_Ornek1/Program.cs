using System;

namespace AdapterDeseni_Ornek1
{
    class Program
    {
        /*Varsayalım ki bir Müzik mağazamız var ve sadece enstruman olarak gitar satışı yapıyoruz.
          Ancak sonradan mağazamızda yeni bir enstrüman satmaya karar verdik.
          İşte bu noktada sadece gitar siparişi verebildiğimiz class’ımıza Kemence siparişimizi de adapte ediyoruz.*/
        static void Main(string[] args)
        {
            IMuzikMagazasi muzikMagazasi = new KemenceAdapter();
            muzikMagazasi.SiparisVer("yayli");
            
        }
    }

    public interface IMuzikMagazasi
    {
        public void SiparisVer(string tur);
    }

    public class GitarSiparis : IMuzikMagazasi
    {
        private string gitarTuru;
        public string getGitarTuru() { return gitarTuru; }
        public void setGitarTuru(string gitarTuru) { this.gitarTuru = gitarTuru; }
        
        public void SiparisVer(string tur)
        {
            setGitarTuru(tur);
            Console.WriteLine(getGitarTuru() + "siparis verilmiştir.");
        }
    }

    public class KemenceSiparis
    {

        private string kemenceTuru;
        public string getKemenceTuru() { return kemenceTuru; }
        public void setKemenceTuru(string kemenceTuru) { this.kemenceTuru = kemenceTuru; }
      
        public void KemenceSiparisVer(string KemenceTuru)

        {
            setKemenceTuru(KemenceTuru);
            Console.WriteLine(getKemenceTuru() + " siparis verilmiştir.");
        }
    }

    public class KemenceAdapter : IMuzikMagazasi
    {
        KemenceSiparis kemenceSiparis;

        public KemenceAdapter()
        {
            kemenceSiparis = new KemenceSiparis();
        }
        public void SiparisVer(string tur)
        {
            
            kemenceSiparis.KemenceSiparisVer(tur);

        }
    }

   

}
