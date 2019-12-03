﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Creator c = new Creator();
            IProduct product;

            for (int i = 1; i <= 12; i++)
            {
                product = c.FactoryMethod(i);
                Console.WriteLine("Coffee beans : " +product.ShipFrom());
            }
            Console.ReadKey();
        }
    }

    interface IProduct
    {
        string ShipFrom();
    }

    class ProductA : IProduct
    {
        public string ShipFrom()
        {
            return "from Columbia";
        }
    }
    class ProductB : IProduct
    {
        public string ShipFrom()
        {
            return "from South Africa";
        }
    }
    class DefaultProduct : IProduct
    {
        public string ShipFrom()
        {
            return "Not Available";
        }
    }

    class Creator
    {
        public IProduct FactoryMethod(int month)
        {
            if (month >= 4 && month <= 11)
            {
                return new ProductA();
            }
            else
            {
                if (month == 1 || month == 2 || month == 12)
                {
                    return new ProductB();
                }
                else
                {
                    return new DefaultProduct();
                }
            }
        }
    }
}
