using System;

namespace VisitorDeseni_Ornek1
{
    class Program
    {
        /* Bir doküman oluşturmak için yapı kurulması gerektiği düşünülsün. Dokümandaki yapıda yazının bold
        olan kısmı, link olan kısmı ve normal içerik olan kısmı bulunmaktadır. Kuracağınız bu yapıda iki farklı
        doküman tipine destek vermesi gerekmektedir. Bunlardan biri html formatı, diğeri ise latext
        formatıdır.
        */
        static void Main(string[] args)
        {
            LinkDokuman dokuman = new LinkDokuman();
            dokuman.accept(new LatexFormat());

            NormalDokuman dokuman1 = new NormalDokuman();
            dokuman1.accept(new HtmlFormat());        }

        public  interface Dokuman
        {
            public void accept(IVisitor visitor);
        }
        public class BoldDokuman : Dokuman
        {
            public void accept(IVisitor visitor)
            {
                visitor.visit(this);
            }
        }
        public class LinkDokuman : Dokuman
        {
            public void accept(IVisitor visitor)
            {
                visitor.visit(this);
            }
        }
        public class NormalDokuman : Dokuman
        {
            public void accept(IVisitor visitor)
            {
                visitor.visit(this);
            }
        }

        public interface IVisitor
        {
            public void visit(Dokuman dokuman);
        }

        public class HtmlFormat : IVisitor
        {
            public void visit(Dokuman dokuman)
            {
                if(dokuman is BoldDokuman)
                { Console.WriteLine("Bold doküman Html formatına dönüştürüldü."); }
                else if (dokuman is NormalDokuman)
                { Console.WriteLine("Normal doküman Html formatına dönüştürüldü."); }
                else
                { Console.WriteLine("Bu doküman tipi html formatını desteklemiyor."); }
            }
        }
        public class LatexFormat : IVisitor
        {
            public void visit(Dokuman dokuman)
            {
                if (dokuman is LinkDokuman)
                { Console.WriteLine("Link doküman Html formatına dönüştürüldü."); }
              
                else
                { Console.WriteLine("Bu doküman tipi html formatını desteklemiyor."); }
            }
        }
        }
    }

