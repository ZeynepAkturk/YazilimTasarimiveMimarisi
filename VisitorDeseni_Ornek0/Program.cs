using System;

namespace VisitorDeseni_Ornek0
{
    class Program
    {
        /* Mesela bir tablet sınıfı olsun.
          Bu sınıftan türeyen bazı tabletlerin wifi özelliği var bazılarının yok aynı
          şekilde bir kısmının 5G özelliği var bir kısmının yok.
         */
        static void Main(string[] args)
        {
            IPad ipad = new IPad();
            ipad.Accept(new Wi_fi());
        }


        public interface Tablet
        {
            public void Accept(IVisitor visitor);
        }
        public class IPad : Tablet
        {
            public void Accept(IVisitor visitor)
            {
                visitor.visit(this);
            }
        }

        public class GalaxyTab : Tablet
        {
            public void Accept(IVisitor visitor)
            {
                visitor.visit(this);
            }
        }

        public interface IVisitor
        {
            public void visit(Tablet tablet);
        }
        public class Wi_fi : IVisitor
        {
            public void visit(Tablet tablet)
            {
                baglan_Wifi();
            }
            public void baglan_Wifi()
            {
                Console.WriteLine("Wi-fi özelliğiyle bağlanıldı.");
            }
        }
        public class _5G : IVisitor
        {
            public void visit(Tablet tablet)
            {
                baglan_5G();
            }
            public void baglan_5G()
            {
                Console.WriteLine("5G özelliğiyle bağlanıldı.");
            }
        }

    }

    
    
}
