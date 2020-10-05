using System;
using System.Collections.Generic;

namespace Task_31
{
    class Program
    {
        static void Main(string[] args)
        {  
            Product[] products = { new Product("Колбаса", 10), new Product("Пельмени", 30), new Product("Сыр", 15), new Product("Ветчина", 17), new Product("Сосиски", 12) };

            Seller seller = new Seller(products);                      

            bool enterOrExit = true;

            Console.Write("Сколько у вас рублей ? : ");
            Player player = new Player(Convert.ToInt32(Console.ReadLine()));
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
                        Console.WriteLine("Введите название товара : ");
                        Product product = seller.SellItem(Console.ReadLine());
                        player.BuyItem(product);
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
    class Npc
    {
        protected List<Product> Products = new List<Product>();

        protected void AddItem(Product product)
        {
            Products.Add(product);
        }
        public void ShowItems()
        {
            for (int i = 0; i < Products.Count; i++)
            {
                Products[i].ShowInfo();
            }
        }
    }
    class Product
    {
        private string _name;
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
            _name = productName;
            _price = price;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"\n{_name} - стоимость {_price} рублей.\n");
        }        
        public bool SearshItem(string productName)
        {
            return productName == _name;       
        }
    }
    class Player : Npc
    {
        private int _money;
        public Player(int money)
        {
            _money = money;
        }
        public int Money
        {
            get
            {
                return _money;
            }
        }       
        public void BuyItem(Product product)
        {
            if(product != null)
            {
                if (_money >= product.Price)
                {
                    _money -= product.Price;
                    AddItem(product);                    
                }
            }
        }
    }    
    class Seller : Npc
    {
        public Seller(Product[] product)
        {
            for (int i = 0; i < product.Length; i++)
            {
                AddItem(product[i]);
            }
            
        }
        public Product SellItem(string productName)
        {
            Product product = null;
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].SearshItem(productName))
                {
                    product = Products[i];                    
                }
            }
            return product;
        }        
    }    
}
