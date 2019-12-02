using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern1
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = "", password = "";
            double total = 0;
            bool loginResult = false;
            do
            {
                if (!loginResult)
                {
                    Console.WriteLine("Lütfen kullanıcı adınızı giriniz: ");
                    username = Console.ReadLine();

                    Console.WriteLine("Lütfen şifrenizi giriniz");
                    password = Console.ReadLine();
                }

                Console.WriteLine("Lütfen ödenecek olan tutarı giriniz");
                total = Convert.ToDouble(Console.ReadLine());

                IBanka banka = new ProxyBanka(username, password);

                bool result = banka.OdemeYap(total);
                loginResult = banka.LoginStatus;

                Console.WriteLine("*****************************");
                if (result)
                {
                    break;
                }

            } while (true);

            Console.ReadKey();
        }
    }
    public interface IBanka
    {
        bool OdemeYap(double tutar);
        bool LoginStatus { get; set; }
    }

    //Real subject class
    public class Banka : IBanka
    {
        public bool LoginStatus { get; set; }
        public bool OdemeYap(double tutar)
        {
            if (tutar < 100)
            {
                Console.WriteLine($"Ödeyeceğiniz tutar 100 tl den az olamaz ! => {100 - tutar}");
            }
            else if (tutar > 100)
            {
                Console.WriteLine($"Ödeyeceğiniz tutar 100 tl den fazla olamaz ! => {tutar - 100}");
            }
            else
            {
                Console.WriteLine($"Ödeme başarıyla gerçekleştirildi. => {tutar}");
                return true;
            }
            return false;
        }
    }

    public class ProxyBanka : IBanka
    {
        Banka _banka;
        bool _login;
        string _userName, _password;

        public bool LoginStatus { get => _login; set { } } // kullanıcı dışarıdan değer set edemez.


        public ProxyBanka(string username, string password)
        {
            this._userName = username;
            this._password = password;
        }

        bool Login()
        {
            if (_userName.Equals("bilgeadam") && _password.Equals("123456"))
            {
                _banka = new Banka();
                _login = true;
                _banka.LoginStatus = _login;
                Console.WriteLine("Hesaba giriş yapıldı");
            }
            else
            {
                Console.WriteLine("Lütfen kullanıcı bilgilerinizi düzgün girin !");
                _login = false;
            }
            return _login;

        }
        public bool OdemeYap(double tutar)
        {
            bool result = Login();
            if (!result)
            {
                Console.WriteLine("Hesaba giriş yapılmadığından dolayı işleme devam edemiyoruz.");
                return false;
            }
            return _banka.OdemeYap(tutar); ;
        }


    }
}
