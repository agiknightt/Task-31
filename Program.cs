using System;
using System.Collections.Generic;

namespace Task_31
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Seller seller = new Seller();

            seller.AddItem("Колбаса", 10);
            seller.AddItem("Пельмени", 30);
            seller.AddItem("Сыр", 15);
            seller.AddItem("Ветчина", 17);
            seller.AddItem("Сосиски", 12);            

            bool enterOrExit = true;

            Console.Write("Сколько у вас рублей ? : ");
            player.GetMoney(Convert.ToInt32(Console.ReadLine()));
            Console.Clear();

            while (enterOrExit)
            {
                Console.SetCursorPosition(100, 0);
                Console.Write("У вас " + player.Money + " рублей");
                Console.SetCursorPosition(0, 0);

                Console.WriteLine("Выберите нужный пункт меню\n\n1 - посмотреть товары продавца\n\n2 - посмотреть свои вещи\n\n3 - купить товар продавца\n\n4 - выйти\n");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        seller.ShowItems();
                        break;
                    case 2:
                        player.ShowItems();
                        break;
                    case 3:
                        player.BuyItem(seller);
                        break;
                    case 4:
                        enterOrExit = false;
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    class Product
    {
        private string _productName;
        private int _price;

        public int Price
        {
            get
            {
                return _price;
            }
        }
        public Product(string productName, int price)
        {
            _productName = productName;
            _price = price;
        }
        public void ShowItem()
        {
            Console.WriteLine($"\n{_productName} - стоимость {_price} рублей.\n");
        }        
        public bool SearshItem(string productName)
        {
            return productName == _productName;       
        }
    }
    class Player
    {
        private int _money;
        private List<Product> _products = new List<Product>();

        public int Money
        {
            get
            {
                return _money;
            }
        }
        public void GetMoney(int money)
        {
            _money = money;
        }
        public void ShowItems()
        {
            for (int i = 0; i < _products.Count; i++)
            {
                _products[i].ShowItem();
            }            
        }
        public void AddItem(string productName, int price)
        {
            Product player = new Product(productName, price);
            _products.Add(player);
            _money -= price;
        }
        public void BuyItem(Seller seller)
        {
            Console.WriteLine("Введите название товара : ");
            string productName = Console.ReadLine();

            Product product = seller.SearchItem(productName);

            if(product != null)
            {
                if (_money >= product.Price)
                {
                    AddItem(productName, product.Price);
                }
            }
        }
    }    
    class Seller 
    {
        private List<Product> _products = new List<Product>();        
        
        public void AddItem(string productName, int price )
        {
            Product product = new Product(productName, price);
            _products.Add(product);
        }
        public void ShowItems()
        {
            for (int i = 0; i < _products.Count; i++)
            {
                _products[i].ShowItem();
            }            
        }
        public Product SearchItem(string productName)
        {
            Product product = null;
            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].SearshItem(productName))
                {
                    product = _products[i];                    
                }
            }
            return product;
        }        
    }    
}
