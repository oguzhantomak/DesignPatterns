using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton1
{
    class Program
    {
        static void Main(string[] args)
        {

            // SingletonClass1 class1 = new SingletonClass1();          //SingletonClass1.cs deki yapıcı metod, "public" olunca dışardan instance alamıyoruz.

            var s1 = SingletonClass1.Singleton;
            int sonuc = s1.Hesapla(12,12);
            Console.WriteLine(sonuc);

            int s2 = SingletonClass1.SingletonInstance().Hesapla(10, 10);
            Console.WriteLine(s2);
            Console.ReadKey();
        }
    }
}
