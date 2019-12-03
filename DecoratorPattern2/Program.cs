using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern2
{
    class Program
    {
        static void Main(string[] args)
        {
            FreshSalad sezarSalata = new FreshSalad("Maydanoz, pırasa, yeşil, soğan, ıspanak", "tulum, kaşar, parmesan, beyaz peynir", "salça, ezme, nar ekşisi");
            sezarSalata.Display();


            Pasta pasta = new Pasta("ölüm pastası", "nar ekşisi, çikolata sosu, turşu suyu, parmesan peyniri");
            pasta.Display();


            Available sezarSalataAvailable = new Available(sezarSalata, 3);
            Available pastaAvailable = new Available(pasta, 4);

            sezarSalataAvailable.OrderItem("murat");
            sezarSalataAvailable.OrderItem("ahmet");
            sezarSalataAvailable.OrderItem("mehmet");

            pastaAvailable.OrderItem("ahmet");
            pastaAvailable.OrderItem("mehmet");
            pastaAvailable.OrderItem("hasan");
            pastaAvailable.OrderItem("hüseyin");
            pastaAvailable.OrderItem("burak");

            sezarSalataAvailable.Display();
            pastaAvailable.Display();

            Console.ReadKey();
        }
    }

    abstract class RestaurantDish
    {
        public abstract void Display();
    }
    class FreshSalad : RestaurantDish
    {
        private string _greens;
        private string _cheese;
        private string _dressing; //Soslar

        public FreshSalad(string greens, string cheese, string dressing)
        {
            this._greens = greens;
            this._cheese = cheese;
            this._dressing = dressing;
        }
        public override void Display()
        {
            Console.WriteLine("\nFresh: ");
            Console.WriteLine("\nCheese: {0}", this._cheese);
            Console.WriteLine("\nGreens: {0}", this._greens);
            Console.WriteLine("\nDressing: {0}", this._dressing);
        }
    }
    class Pasta : RestaurantDish
    {
        private string _pastaType;
        private string _sauce;

        public Pasta(string pastaType, string sauce)
        {
            this._pastaType = pastaType;
            this._sauce = sauce;
        }
        public override void Display()
        {
            Console.WriteLine("\nClassic Pasta: ");
            Console.WriteLine("\nPasta: {0}", this._pastaType);
            Console.WriteLine("\nSauce: {0}", this._sauce);
        }
    }
    abstract class Decorator : RestaurantDish
    {
        protected RestaurantDish _dish;
        public Decorator(RestaurantDish dish)
        {
            _dish = dish;
        }
        public override void Display()
        {
            _dish.Display();
        }
    }

    class Available : Decorator
    {
        public int NumAvailable { get; set; }
        protected List<string> customers = new List<string>();
        public Available(RestaurantDish dish, int numAvailable) : base(dish)
        {
            this.NumAvailable = numAvailable;
        }
        public void OrderItem(string name)
        {
            if (NumAvailable > 0)
            {
                customers.Add(name);
                NumAvailable--;
            }
            else
            {
                Console.WriteLine("\nNot enough ingredients for " + name + "'s order!");
            }
        }
        public override void Display()
        {
            base.Display();
            foreach (string customer in customers)
            {
                Console.WriteLine("Ordered by " + customer);
            }
        }
    }

}
