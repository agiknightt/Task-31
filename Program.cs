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
                        seller.ShowInventory(null, seller);
                        break;
                    case 2:
                        player.ShowInventory(player, null);
                        break;
                    case 3:
                        seller.BuyItem(player);
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
    class Player : Inventar
    {
        private int _money;
        public int Money
        {
            get
            {
                return _money;
            }
        }        
        public Player(string productName = "")
        {
            _productName = productName;            
        }
        public override void AddItem(string productName, int price)
        {
            Player player = new Player(productName);
            
            _inventarPlayer.Add(player);
            _money -= price;
        }                       
        public void GetMoney(int money)
        {
            _money = money;
        }        
    }    
    class Seller : Inventar
    {
        private int _price;  
        
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
        public override void AddItem(string productName, int price )
        {
            Seller seller = new Seller(productName, price);

            _inventarSeller.Add(seller);
        }        
        public void BuyItem(Player player)
        {
            Console.WriteLine("Введите название товара : ");
            string productName = Console.ReadLine();

            for (int i = 0; i < _inventarSeller.Count; i++)
            {
                if (productName == _inventarSeller[i]._productName)                
                {
                    if (player.Money >= _inventarSeller[i]._price)
                    {
                        player.AddItem(_inventarSeller[i]._productName, _inventarSeller[i]._price);

                        _inventarSeller.RemoveAt(i);
                    }                    
                }
            }
        }
    }
    abstract class Inventar
    {
        protected string _productName;
        protected List<Seller> _inventarSeller = new List<Seller>();
        protected List<Player> _inventarPlayer = new List<Player>();
        public void ShowInventory(Player player = null, Seller seller = null)
        {  
            Console.WriteLine("\nУ меня есть : ");

            if (player != null)
            {
                for (int i = 0; i < _inventarPlayer.Count; i++)
                {
                    Console.WriteLine("\n" + _inventarPlayer[i]._productName + "\n");
                }
            }
            if (seller != null)
            {
                for (int i = 0; i < _inventarSeller.Count; i++)
                {
                    Console.WriteLine($"\n{_inventarSeller[i]._productName} - стоимость {_inventarSeller[i].Price} рублей.\n");
                }
            }
        }
        public abstract void AddItem(string productName, int price);
    }
}
