using System;
using System.Collections.Generic;

namespace Task_31
{
    class Program
    {
        static void Main(string[] args)
        {
            Product products = new Product();
            products.AddItemSeller("Колбаса", 10);
            products.AddItemSeller("Пельмени", 30);
            products.AddItemSeller("Сыр", 15);
            products.AddItemSeller("Ветчина", 17);
            products.AddItemSeller("Сосиски", 12);            

            bool enterOrExit = true;

            while (enterOrExit)
            {
                RendererMoney(products);

                Console.WriteLine("Выберите нужный пункт меню\n\n1 - посмотреть товары продавца\n\n2 - посмотреть свои вещи\n\n3 - купить товар продавца\n\n4 - выйти\n");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        products.ShowItemsSeller();
                        break;
                    case 2:
                        products.ShowItemsPlayer();
                        break;
                    case 3:
                        Console.WriteLine("Введите название товара : ");
                        products.BuyItem(Console.ReadLine());
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

        private static void RendererMoney(Product products)
        {
            Console.SetCursorPosition(100, 0);
            Console.Write("У вас " + products.MoneyPlayer + " рублей");
            Console.SetCursorPosition(0, 0);
        }
    }
    class Player
    {
        private string _productName;
        private Player _inventarPlayer;
        
        public string ProductName
        {
            get
            {
                return _productName;
            }
        }
        public Player(string productName)
        {
            _productName = productName;
        }        
    }
    class Product
    {
        private string _productName;
        private int _productCost;
        private int _moneyPlayer = 100;
        private List<Seller> _inventarSeller = new List<Seller>();
        private List<Player> _inventarPlayer = new List<Player>();
        
        public int MoneyPlayer
        {
            get
            {
                return _moneyPlayer;
            }
        }
        public void AddItemSeller(string productName, int productCost)
        {
            _productName = productName;
            _productCost = productCost;
            _inventarSeller.Add(new Seller(_productName, _productCost));
        }        
        public void ShowItemsSeller()
        {
            Console.WriteLine("У меня есть : ");
            for (int i = 0; i < _inventarSeller.Count; i++)
            {
                Console.WriteLine($"\n{_inventarSeller[i].ProductName} - стоимость {_inventarSeller[i].Price} рублей.\n");
            }
        }
        public void ShowItemsPlayer()
        {
            Console.WriteLine("В вашем инвентаре : ");
            if(_inventarPlayer.Count > 0)
            {
                for (int i = 0; i < _inventarPlayer.Count; i++)
                {
                    Console.WriteLine($"{_inventarPlayer[i].ProductName}\n");
                }
            }
            else
            {
                Console.WriteLine("Нет предметов");
            }
        }
        public void BuyItem(string productName)
        {
            for (int i = 0; i < _inventarSeller.Count; i++)
            {                
                if (productName == _inventarSeller[i].ProductName)
                {
                    if(_moneyPlayer >= _inventarSeller[i].Price)
                    {
                        _inventarPlayer.Add(new Player(_inventarSeller[i].ProductName));

                        _inventarSeller.RemoveAt(i);

                        _moneyPlayer -= _inventarSeller[i].Price;
                    }
                    else
                    {
                        Console.WriteLine("Не достаточно денег для покупки.");
                    }
                }                
            }
        }
    }
    class Seller
    {
        private string _productName;
        private int _price;
        private Seller _inventarSeller;

        public string ProductName
        {
            get
            {
                return _productName;
            }
        }
        public int Price
        {
            get
            {
                return _price;
            }
        }
        public Seller(string productName, int price)
        {
            _productName = productName;
            _price = price;
        }        
    }
}
