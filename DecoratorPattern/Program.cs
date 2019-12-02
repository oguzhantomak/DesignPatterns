using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IBilesen component = new Bilesen();

            Client.Display("1.Basit Bileşen : ", component);
            Client.Display("2.A Decorated Bileşen : ", new DecoratorA(component));
            Client.Display("3.B Decorated Bileşen : ", new DecoratorB(component));
            Client.Display("4.B-A Decorated Bileşen : ", new DecoratorB(new DecoratorA(component)));

            DecoratorB b = new DecoratorB(new Bilesen());
            Client.Display("5.A-B Decorated", new DecoratorA(b));

            Console.WriteLine("\t\t\t"+ b.EklenenDavranis());

            Console.ReadKey();
        }
    }
    interface IBilesen //Decore edilecek olan nesne sınıflarını tanımlayan arayüz
    {
        string Operasyon();
    }
    class Bilesen : IBilesen // Operasyonların eklenmiş veya değiştirilmiş olabilecek orjinal bir nesne sınıfı
    {
        public string Operasyon()
        {
            return "Çalıştığım firma için";
        }
    }

    class DecoratorA : IBilesen
    {
        IBilesen _bilesen;
        public DecoratorA(IBilesen bilesen)
        {
            _bilesen = bilesen;
        }
        public string Operasyon()
        {
            string result = _bilesen.Operasyon();
            result += " Yazılım Tanımlı ağlar İle";
            return result;
        }
    }

    class DecoratorB : IBilesen
    {
        IBilesen _bilesen;

        public DecoratorB(IBilesen bilesen)
        {
            this._bilesen = bilesen;
        }

        public string Operasyon()
        {
            string result = _bilesen.Operasyon();
            result += " ve bazı robotik süreçler geliştiriyorum";
            return result;
        }
        public string EklenenDavranis()
        {
            return "Ayrıca kaldırım mühendisliği yapıyorum";
        }
    }
    class Client
    {
        public static void Display(string result, IBilesen bilesen)
        {
            Console.WriteLine(result+bilesen.Operasyon());
        }
    }
}
