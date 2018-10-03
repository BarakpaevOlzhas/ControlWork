using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork
{
    class Program
    {
        static void Filling(List<Category> categories)
        {
            int zero = 0;
            int one = 1;
            int two = 2;
            int three = 3;
            
            categories.Add(new Category("еда для животных"));
            
            categories.Add(new Category("Отдых"));
                        
            categories.Add(new Category("Техника"));
            
            categories.Add(new Category("Природа"));
                        
            categories[zero].Products.Add(new Product("Wiscas", 200, ""));
            
            categories[zero].Products.Add(new Product("Felix", 230, ""));

            categories[one].Products.Add(new Product("палатка", 20000, ""));
                       
            categories[one].Products.Add(new Product("Гриль", 30000, ""));
            
            categories[two].Products.Add(new Product("Iphone XS", 400000, ""));

            categories[two].Products.Add(new Product("Iphone 8", 200000, ""));

            categories[three].Products.Add(new Product("Лопата", 200000, ""));

            categories[three].Products.Add(new Product("Топор", 200000, ""));
        }

       static void Menu(List<Category> categories, Cart cart)
        {
            int choise = 0;

            do
            {

                Console.WriteLine("0)Корзина");

                Console.WriteLine("1)Каталог");

                Console.WriteLine("2)Все товары");

                Console.WriteLine("3)Выход");

                Console.WriteLine("4)Купить");

                int.TryParse(Console.ReadLine(), out choise);

                if (choise == 0)
                {
                    ShowCart(cart);
                }

                else if (choise == 1)
                {
                    AllСatalogs(categories, cart);
                }

                else if (choise == 2)
                {
                    AllGoods(categories, cart);
                }

                else if (choise == 3)
                {
                    break;
                }

                else if (choise == 4)
                {
                    Console.WriteLine("Спасибо за покупку");
                    cart.Products.Clear();
                }
            }
            while (true);
        }

        static void ShowCart(Cart cart)
        {
            for (int i = 0; i < cart.Products.Count; i++) 
            {
                Console.WriteLine(cart.Products[i].Name);
            }
            Console.WriteLine($"Сумма: {cart.FullPrice()}");

        }

        static void AllGoods(List<Category> categories, Cart cart)
        {
            int countOne = 0;
            int CountTwo = 0;
            int choise = 0;
            int breakOne = 0;

            for (int i = 0;i < categories.Capacity;i++)
            {
                for (int j = 0; j < categories[i].Products.Count; j++) 
                {
                    Console.WriteLine($"{countOne}){categories[i].Products[j].Name}   {categories[i].Products[j].Price}");

                    countOne++;
                }
            }

            Console.WriteLine("Выберите продукт");

            int.TryParse(Console.ReadLine(), out choise);

            for (int i = 0; i < categories.Capacity; i++)
            {
                for (int j = 0; j < categories[i].Products.Count; j++)
                {                    
                    if(CountTwo == choise)
                    {
                        cart.Products.Add(categories[i].Products[j]);
                        breakOne++;
                        break;
                    }
                    CountTwo++;
                }
                if (breakOne != 0)
                {
                    break;
                }
            }

        }

        static void AllСatalogs(List<Category> categories, Cart cart)
        {
            int choise = 0;
            int buf;

            for (int i = 0; i < categories.Capacity; i++)
            {
                Console.WriteLine($"{i}){categories[i].Name}");
            }

            Console.WriteLine();

            Console.WriteLine("выберите каталог");

            int.TryParse(Console.ReadLine(),out choise);

            buf = choise;

            for (int i = 0; i < categories[choise].Products.Count; i++) 
            {
                Console.WriteLine($"{i}){categories[choise].Products[i].Name}   {categories[choise].Products[i].Price}");
            }

            Console.WriteLine("выберите товар");

            int.TryParse(Console.ReadLine(), out choise);

            cart.Products.Add(categories[buf].Products[choise]);
        }

        static void Main(string[] args)
        {
            MainUser user = new MainUser();

            List<Category> categories = new List<Category>();

            Cart cart = new Cart();

            Filling(categories);

            int choise = 0;

            do
            {
                Console.WriteLine("1)Зарегистрироваться");

                Console.WriteLine("2)Войти");

                int.TryParse(Console.ReadLine(), out choise);

                if (choise == 1)
                {
                    string name, password, mail, phone;

                    Console.WriteLine("Введите Имя: ");
                    name = Console.ReadLine();

                    Console.WriteLine("Введите пароль: ");
                    password = Console.ReadLine();

                    Console.WriteLine("Введите почту: ");
                    mail = Console.ReadLine();

                    Console.WriteLine("Введите номер телефона: ");
                    Console.Write("+7 ");
                    phone = Console.ReadLine();

                    Console.WriteLine(user.SingUp(name, password, mail, phone));

                    if (user.LogIn(name, password))
                    {
                        Menu(categories, cart);
                    }

                }
                else if (choise == 2)
                {
                    string name, password;

                    Console.WriteLine("Введите Имя: ");
                    name = Console.ReadLine();

                    Console.WriteLine("Введите пароль: ");
                    password = Console.ReadLine();

                    if (user.LogIn(name, password))
                    {
                        Menu(categories, cart);
                    }
                }
            }
            while (true);
        }
    }
}
