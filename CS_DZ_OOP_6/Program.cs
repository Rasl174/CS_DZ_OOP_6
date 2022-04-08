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
            List<Product> salesmanProducts = new List<Product>() { new Product("Мыло", 20), new Product("Печенье", 30), new Product("Сахар", 100), new Product("Чипсы", 80) };
            Magazine magazine = new Magazine(salesmanProducts);
            Player playerMoney = new Player(300);

            Console.WriteLine("Добро пожаловать в магазин!");

            magazine.Work(playerMoney);
        }
    }

    class Magazine
    {
        private List<Product> _salesmanProducts;

        public Magazine(List<Product> salesman)
        {
            _salesmanProducts = salesman;
        }

        public void Work(Player player)
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
                        Buy(player);
                        break;
                    case "3":
                        ShowPlayerProducts(player);
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

            if(_salesmanProducts.Count > 0)
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

        private void Buy(Player player)
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
                        player.PlayerBuy(product);
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

        private void ShowPlayerProducts(Player playerProducts)
        {
            playerProducts.ShowProducts();
        }
    }

    class Player
    {
        private List<Product> _playerProducts = new List<Product>();

        public int Money { get; private set; }

        public Player(int money)
        {
            Money = money;
        }

        public void Pay(int productPrice)
        {
            Money -= productPrice;
        }

        public void PlayerBuy(Product newProduct)
        {
            _playerProducts.Add(newProduct);
        }

        public void ShowProducts()
        {
            Console.Clear();
            Console.WriteLine("Мы купили");
            foreach (var item in _playerProducts)
            {
                Console.WriteLine(item.ProductName);
            }
            Console.ReadLine();
            Console.Clear();
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
