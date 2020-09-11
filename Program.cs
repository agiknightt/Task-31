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
                        seller.ShowInventar();
                        break;
                    case 2:
                        player.ShowInventar();
                        break;
                    case 3:
                        BuyItem(player, seller);
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

        private static void BuyItem(Player player, Seller seller)
        {
            Console.WriteLine("Введите название товара : ");
            string productName = Console.ReadLine();

            for (int i = 0; i < seller.InventarSeller.Count; i++)
            {
                if (productName == seller.InventarSeller[i].ProductName)
                {
                    if (player.Money >= seller.InventarSeller[i].Price)
                    {
                        player.AddItem(seller.InventarSeller[i].ProductName);

                        player.BuyItem(seller.InventarSeller[i].Price);

                        seller.InventarSeller.RemoveAt(i);
                    }
                    else
                    {
                        Console.WriteLine("Не достаточно денег для покупки.");
                    }
                }
            }
        }
    }
    class Player
    {
        private string _productName;
        private List<Player> _inventarPlayer = new List<Player>();
        private int _money;
        public int Money
        {
            get
            {
                return _money;
            }
        }
        public string ProductName
        {
            get
            {
                return _productName;
            }
        }
        public Player(string productName = "")
        {
            _productName = productName;            
        }
        public void AddItem(string productName)
        {
            Player player = new Player(productName);

            _inventarPlayer.Add(player);
            Console.WriteLine(_inventarPlayer.Count);
        }
        public void ShowInventar()
        {
            Player player = new Player();

            for (int i = 0; i < _inventarPlayer.Count; i++)
            {
                Console.WriteLine(_inventarPlayer[i].ProductName);
            }
        }        
        public void BuyItem(int price)
        {
            _money -= price;
        }
        public void GetMoney(int money)
        {
            _money = money;
        }
    }    
    class Seller
    {
        private string _productName;
        private int _price;
        private List<Seller> _inventarSeller = new List<Seller>();
        Player player = new Player();
        public List<Seller> InventarSeller
        {
            get
            {
                return _inventarSeller;
            }
        }
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
        public Seller(string productName = "", int price = 0)
        {
            _productName = productName;
            _price = price;
        }
        public void AddItem( string productName, int price)
        {
            Seller seller = new Seller(productName, price);

            _inventarSeller.Add(seller);
        }
        public void ShowInventar()
        {
            Console.WriteLine("У меня есть : ");

            for (int i = 0; i < _inventarSeller.Count; i++)
            {
                Console.WriteLine($"\n{_inventarSeller[i]._productName} - стоимость {_inventarSeller[i]._price} рублей.\n");
            }
        }        
    }
}
