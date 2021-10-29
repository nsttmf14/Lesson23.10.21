using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        private const string PathToNewList = @"..\..\files\Exit.txt";//итоговый файл для задания 8.3
        private enum TypeAcc//8.1
        {
            currentAccount = 1,
            savingAccount
        }

        private static int number;
        private static double balance1st;
        private static double balance2nd;
        private static TypeAcc type;
        static string Create()//создаем счет
        {
            Random rnd = new Random();
            int coincidences;
            List<int> randomList = new List<int>();
            Console.Write("1. Текущий счёт (current account)\n2. Сберегательный счёт (saving account) \nВыберите тип счёта: ");
            type = (TypeAcc)Convert.ToByte(Console.ReadLine());
        random:
            coincidences = rnd.Next(1, 999999);
            if (randomList.Contains(coincidences))//проверяем, чтобы рандомный номер не совпадал
            {
                goto random;
            }
            else
            {
                randomList.Add(coincidences);
                number = Convert.ToInt32(coincidences);
            }
            Console.WriteLine("Номер сгенерирован случайно, без повторений.");
            Console.Write("Введите баланс: ");
            string input = Console.ReadLine();
            double.TryParse(input, out balance1st);
            string account = type + " " + number + " " + balance1st;
            return account;
        }
        static void Print(string account)//печатаем счет
        {
            string[] acc = account.Split();
            Console.WriteLine($"\n1.Тип счёта: {acc[0]}\n2.Номер счёта {acc[1]}\n3.Баланс счёта: {acc[2]}");
        }
        static string Transaction(string account, double balance2nd)
        {
            string[] acc = account.Split();
            Console.WriteLine("1.C этого счёта на 2ой.\n2.Со 2ого счёта на этот.");
        transaction:
            if (!byte.TryParse(Console.ReadLine(), out byte choise) | choise > 2)
            {
                Console.WriteLine("Ошибка: введено некорректное значение. Повторите ввод:");
                goto transaction;
            }
            Console.Write("Введите сумму транзакции: ");
        transfer:
            double.TryParse(Console.ReadLine(), out double transfer);
            double Buffer = Convert.ToDouble(acc[2]);
            if (choise.Equals(1))
            {
                Console.WriteLine("Деньги переведены...");
                Buffer -= transfer;
                balance2nd += transfer;
            }
            else
            {
                if (balance2nd >= transfer)
                {
                    Console.WriteLine("Деньги зачислены...");
                    Buffer += transfer;
                    balance2nd -= transfer;
                }
                else
                {
                    Console.Write("Ошибка: баланс на 2ом счёте меньше введёного значения. Повторите ввод: ");
                    goto transfer;
                }
            }
            acc[2] = Convert.ToString(Buffer);
            return account = acc[0] + " " + acc[1] + " " + acc[2] + " " + balance2nd; //сохранение нового баланса счёта
        }
        static string Swap(string swipe)//8.2
        {
            char[] arr = swipe.ToCharArray();//разбиваем строчку на массив символов и переворачиваем
            Array.Reverse(arr);
            return new string(arr);
        }
        static bool CheckIsIFormattable(object obj)//8.4
        {
            /*
            _______________as_________________
            object obj2 = obj as IFormattable;
            if (obj2 == null)
            {
                return false;
            }
            return true;
             */
            return obj is IFormattable;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Task 8.1");
            Console.WriteLine("Создание счёта.");
            string account = Create();
        start:
            Console.WriteLine("* * * Меню * * *");
            Console.WriteLine("1.Напечатать информацию о счёте");
            Console.WriteLine("2.Транзакция");
            Console.Write("Выберите. ");
        restart:
            if (!byte.TryParse(Console.ReadLine(), out byte choice) | choice > 2)
            {
                Console.WriteLine("Ошибка: введено некорректное значение. Повторите ввод: ");
                goto restart;
            }
            else
            {
                switch (choice)
                {
                    case 1:
                        {
                            Print(account); goto start; //печать данных о счёте
                        }
                    case 2:
                        {
                            Console.WriteLine("Чему равняется баланс 2ого счётa: ");
                            double.TryParse(Console.ReadLine(), out balance2nd);
                            account = Transaction(account, balance2nd); //транзакция
                            string[] acc = account.Split();
                            Console.WriteLine("Баланс 1ого аккаунта: " + acc[2] + "\nБаланс 2ого аккаунта: " + acc[3]);
                            break;
                        }
                }
            }

            Console.WriteLine("Task 8.2");
            Console.Write("Введите строку: ");
            string swipe = Console.ReadLine();
            string swaped = Swap(swipe);
            Console.Write("Перевёрнутая строка: " + swaped);

            Console.WriteLine("Task 8.3");
            Console.Write("Введите имя файла для чтения: ");
        ReadFilename:
            string filename = Console.ReadLine();
            try
            {
                string PathToList = $@"..\\..\\files\\{filename}.txt";
                StreamReader sr = new StreamReader(PathToList);
                string words = sr.ReadLine();
                File.WriteAllText(PathToNewList, words.ToUpper()); //создание и заполнение файла
            }
            catch (FileNotFoundException)
            {
                Console.Write("Ошибка: файла с таким названием не существует.\nПовторите ввод:");
                goto ReadFilename;
            }

            Console.WriteLine("Task 8.4");
            Console.WriteLine(CheckIsIFormattable(true));//выведет false, так как не поддерживает bool
            Console.WriteLine(CheckIsIFormattable(2));//выведет true, так как поддерживает int



            Console.ReadKey();

        }

    }
}
