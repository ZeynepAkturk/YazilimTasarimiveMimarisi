using System;

namespace AbstractFactoryDeseni_Ornek2
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client(new Fabrika2());
            client.YapiyiOlustur();
        }
    }
    
    public class Client
    {

        IRenk renk;
        IYapi yapi;
        public Client(IFabrika fabrika)
        {
            renk = fabrika.renkSec();
            yapi = fabrika.yapiSec();
        }

        public void YapiyiOlustur()
        {
           
            renk.renkBoya();
            yapi.yapiOlustur();

        }
    }
    public interface IFabrika
    {
        public IRenk renkSec();
        public IYapi yapiSec();
    }
    public class Fabrika1 : IFabrika
    {
        public IRenk renkSec()
        {
            return new Renk1();
        }

        public IYapi yapiSec()
        {
          return new Yapi1();
        }
    }

    public class Fabrika2 : IFabrika
    {
        public IRenk renkSec()
        {
            return new Renk2();     
        }

        public IYapi yapiSec()
        {
            return new Yapi2();
        }
    }

    public interface IRenk
    {
        public void renkBoya();

    }
    public class Renk1 :IRenk
    {
        public void renkBoya()
        {
            Console.WriteLine("Yapi renk1 e boyandı.");
        }
    }
    public class Renk2 : IRenk
    {
        public void renkBoya()
        {
            Console.WriteLine("Yapi renk2 e boyandı.");
        }
    }
    public interface IYapi
    {
        public void yapiOlustur();
    }
    public class Yapi1 : IYapi
    {
        public void yapiOlustur()
        {
            Console.WriteLine("Yapi1 tercih edildi.");
        }
    }
    public class Yapi2:IYapi
    {
        public void yapiOlustur()
        {
            Console.WriteLine("Yapi2 tercih edildi.");
        }
    }
}
