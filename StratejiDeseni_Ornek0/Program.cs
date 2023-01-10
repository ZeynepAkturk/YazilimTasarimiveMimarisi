using System;

namespace StratejiDeseni_Ornek0
{
    class Program
    {
        static void Main(string[] args)
        {
            Personel personel = new Person1( new DepartmanA(),new MuhendisMaasHesapla());
            personel.izinHesapla();
            personel.maasHesapla();
        }
    }


        public interface Izin
        {
            public void izinHesapla();
        }

    public class DepartmanA : Izin
    {
        public void izinHesapla()
        {
            Console.WriteLine("A departmanına göre izin hesaplanmıştır.");
        }
    }
            public class DepartmanB : Izin
            {
                public void izinHesapla()
                {
                    Console.WriteLine("B departmanına göre izin hesaplanmıştır.");
                }
            }
            public interface Maas
            {
                public void maasHesapla();
            }
            public class MuhendisMaasHesapla : Maas
            {
                public void maasHesapla()
                {
                    Console.WriteLine("Mühendis maaşı hesaplanmıştır.");
                }
            }
            public class YoneticiMaasHesapla : Maas
            {
                public void maasHesapla()
                {
                    Console.WriteLine("Yönetici maaşı hesaplanmıştır.");
                }
            }
    public class TeknisyenMaasHesapla : Maas
    {
        public void maasHesapla()
        {
            Console.WriteLine("Teknisyen maaşı hesaplanmıştır.");
        }
    }
    public abstract class Personel
    {
        private Izin izin;
        private Maas maas;
        public Izin getIzin() { return izin; }
        public void setIzin(Izin izin) { this.izin = izin; }
        public Maas getMaas() { return maas; }
        public void setMaas(Maas maas) { this.maas = maas; }

        public Personel(Izin izin, Maas maas)
        {
            setIzin(izin);
            setMaas(maas);
        }
    

                    public abstract void maasHesapla();
                    public abstract void izinHesapla();
                   

                }

                public class Person1 : Personel
                {
                    public Person1(Izin izin, Maas maas) : base(izin,maas) { }
                    public override void izinHesapla()
                    {
                        getMaas().maasHesapla();
                    }

                    public override void maasHesapla()
                    {
                        getIzin().izinHesapla();
                    }
                }

            }
        
    


