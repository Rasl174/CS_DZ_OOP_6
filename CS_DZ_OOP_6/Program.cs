using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DZ_OOP_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> salesman = new List<Product>() { new Product("Мыло", 20), new Product("Печенье", 30), new Product("Сахар", 100), new Product("Чипсы", 80) };
            Magazine magazine = new Magazine(salesman);
            Console.WriteLine("Добро пожаловать в магазин!");

            magazine.Work();
        }
    }

    class Magazine
    {
        private List<Product> _salesmanProducts;
        private List<Product> _playerProducts = new List<Product>();

        Player player = new Player(300);

        public Magazine(List<Product> salesman)
        {
            _salesmanProducts = salesman;
        }
        public void Work()
        {
            bool shoping = true;

            while (shoping)
            {
                Console.WriteLine("Для того что бы показать продукты продовца введите 1");
                Console.WriteLine("Для того что бы купить продукты введите 2");
                Console.WriteLine("Для того что бы показать купленые продукты введите 3");
                Console.WriteLine("Для выхода введите 4");
                Console.SetCursorPosition(0, 6);
                Console.WriteLine("В кошельке - " + player.Money + " денег");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowSalesmanProducts();
                        break;
                    case "2":
                        Buy();
                        break;
                    case "3":
                        ShowPlayerProducts();
                        break;
                    case "4":
                        shoping = false;
                        break;
                }
            }
        }

        private void ShowSalesmanProducts()
        {
            Console.Clear();
            if(_playerProducts.Count > 0)
            {
                Console.WriteLine("В магазине есть - ");
                foreach (var product in _salesmanProducts)
                {
                    Console.WriteLine(product.ProductName + " по стоимости - " + product.ProductPrice);
                }
            }
            else
            {
                Console.WriteLine("У меня не осталось больше продуктов!");
            }
            Console.ReadKey();
            Console.Clear();
        }

        private void Buy()
        {
            Console.Clear();
            Console.WriteLine("Введите что хотите купить");
            string userInput = Console.ReadLine();

            if(_salesmanProducts.Count > 0)
            {
                foreach (var product in _salesmanProducts)
                {
                    if(userInput == product.ProductName && player.Money >= product.ProductPrice)
                    {
                        _playerProducts.Add(product);
                        player.Pay(product.ProductPrice);
                        Console.WriteLine(product.ProductName + " куплен!");
                        _salesmanProducts.Remove(product);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Вы все купили приходите завтра!");
            }
            Console.ReadKey();
            Console.Clear();
        }

        private void ShowPlayerProducts()
        {
            Console.Clear();
            if(_playerProducts.Count > 0)
            {
                Console.WriteLine("Мы купили - ");
                foreach (var product in _playerProducts)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
    }

    class Player
    {
        public int Money { get; private set; }

        public Player(int money)
        {
            Money = money;
        }

        public void Pay(int productPrice)
        {
            Money -= productPrice;
        }
    }

    class Product
    {
        public string ProductName { get; private set; }

        public int ProductPrice { get; private set; }

        public Product(string productName, int productPrice)
        {
            ProductName = productName;
            ProductPrice = productPrice;
        }
    }
}
