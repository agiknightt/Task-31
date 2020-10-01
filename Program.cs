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
    class Player
    {
        private int _money;
        private string _productName;
        private List<Player> _inventory = new List<Player>();

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
        public void GetMoney(int money)
        {
            _money = money;
        }
        public void ShowItems()
        {
            for (int i = 0; i < _inventory.Count; i++)
            {
                Console.WriteLine("\n" + _inventory[i]._productName + "\n");
            }            
        }
        public void AddItem(string productName, int price)
        {
            Player player = new Player(productName);
            _inventory.Add(player);
            _money = price;
        }
    }    
    class Seller 
    {
        private int _price;
        private string _productName;
        private List<Seller> _inventory = new List<Seller>();
        
        public Seller(string productName = "", int price = 0)
        {
            _productName = productName;
            _price = price;
        }
        public void AddItem(string productName, int price )
        {
            Seller seller = new Seller(productName, price);
            _inventory.Add(seller);
        }
        public void ShowItems()
        {
            for (int i = 0; i < _inventory.Count; i++)
            {
                Console.WriteLine($"\n{_inventory[i]._productName} - стоимость {_inventory[i]._price} рублей.\n");
            }            
        }
        public void BuyItem(Player player)
        {
            Console.WriteLine("Введите название товара : ");
            string productName = Console.ReadLine();

            for (int i = 0; i < _inventory.Count; i++)
            {
                if (productName == _inventory[i]._productName)                
                {
                    if (player.Money >= _inventory[i]._price)
                    {
                        player.AddItem(_inventory[i]._productName, _inventory[i]._price);

                        _inventory.RemoveAt(i);
                    }                    
                }
            }
        }        
    }    
}
