using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork
{
    public class MainUser : Register
    {
        List<Accounts> accounts = new List<Accounts>();

        public int Money { set; get; }

        public int UsedIndex { get; set; }

        public int Size { set; get; }

        public MainUser()
        {
            Money = 0;
            Size = 0;
        }

        public bool LogIn(string name, string password)
        {
            for (int i = 0;i < Size;i++)
            {
                if (accounts[i].Name == name)
                {
                    if (accounts[i].Password == password)
                    {
                        UsedIndex = i;
                        return true;
                    }                    
                }
            }

            return false;
        }

        public string SingUp(string name, string password, string mail, string phone)
        {
            string massage = "";
            int code = 0;
            int codeTwo = 0;
            Random random = new Random();

            for (int i = 0; i < Size + 1; i++)
            {
                if (accounts.Capacity != 0? accounts[i].Phone != phone : true)
                {
                    if (accounts.Capacity != 0 ? accounts[i].Name != name : true)
                    {
                        Accounts bufAccounts = new Accounts();

                        code = random.Next(1000, 9999);

                        string bufPhone = "7" + phone;

                        Code(bufPhone, code.ToString());

                        Console.WriteLine("Введите код");

                        int.TryParse(Console.ReadLine(),out codeTwo);

                        if (code == codeTwo)
                        {
                            bufAccounts.FastFillingIn(name, password, mail, phone);

                            accounts.Add(bufAccounts);

                            Size++;

                            return "Вы зарегистрировались";
                        }
                        else
                        {
                            massage = "Код не верен";
                        }
                    }
                    massage =  "Это имя занято";
                }
                massage =  "Этот телефон используется";
            }            

            return massage;
        }

        public void Code(string phone, string Text)
        {
            string resultPage = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.mobizon.kz/service/Message/SendSmsMessage?recipient=" + phone + "&text=" + Text + "&apiKey=kz75419aa9de9506cb026958d6bf22d3e8b5310ba580b157055bb982d4b4e70dd74d74");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8, true))
            {
                resultPage = sr.ReadToEnd();
                sr.Close();
            }

        }

    }
}
