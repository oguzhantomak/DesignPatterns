using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton1
{
    /*
         Singleton desen, design pattern'lar arasında cerationlar grubuna ait en popüler yapılardan biridir. Uluslar arası standartlara göre %80 kullanım oranına sahiptir. Esas amaç her daim nesnenin kullanım süresi boyunca bir nesnenin bir kez oluşturulup defalarca farklı konumlarda kullanılmasını sağlamaktadır.
         */
    public class SingletonClass1
    {
        private SingletonClass1() //Başka formlarda instance oluşturulamasını istemiyorsak "private" olarak işaretliyoruz.
        {

        }

        private static SingletonClass1 _singleton = new SingletonClass1();

        public static SingletonClass1 Singleton
        {
            get
            {
                return _singleton;
            }
        }
        public static SingletonClass1 SingletonInstance()
        {
            return _singleton;
        }

        //Bu sınıf içerisinde yer alacak olan özellikler belirtilir.
        public int Hesapla(int s1, int s2)
        {
            return s1 + s2;
        }

        
    }
}
