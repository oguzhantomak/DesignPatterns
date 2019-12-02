using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton1
{
    public class SingletonClass2
    {
        private static SingletonClass2 _singleton;

        private SingletonClass2()
        {

        }

        public static SingletonClass2 Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    // daha önce biri bu sınıfı ram üzerine çıkartmadıysa, yeni bir örneğini oluşturuyoruz.
                    _singleton = new SingletonClass2();
                }
                //kullanıcıya elimizdeki var olan nesneyi teslim ediyoruz.
                return _singleton;
            }
        }
    }
}
