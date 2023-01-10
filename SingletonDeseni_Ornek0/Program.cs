using System;

namespace SingletonDeseni_Ornek0
{
    class Program
    {
        //Panel örneği
        static void Main(string[] args)
        {
            Panel panel = Panel.getPanel();
            panel.PanelTikla();
            
        }
    }

    public class Panel
    {
        private static Panel panel;
        private static Object kanalKontrol = new Object();

        private Panel()
        { }

        public static Panel getPanel()
        {
            if(panel==null)
            {
            lock(kanalKontrol)
            {
                    if(panel==null)
                    { panel = new Panel(); }
            }
            }
            return panel;
        }
        public void PanelTikla()
        {
            Console.WriteLine("Panele tıklandı.");
        }
    }
}
