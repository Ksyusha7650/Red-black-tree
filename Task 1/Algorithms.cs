using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public static class Algorithms
    {

        public static int get_int(ref bool check_input)
        {
            string str = Console.ReadLine();
            int res = 0;
            if (int.TryParse(str, out res))
            {
                res = Int32.Parse(str);
                check_input = true;
            }
            else
            {
                Console.WriteLine("Ожидалось число, повторите ввод:");
                check_input = false;
            }
            return res;
        }

        public static void input_manually(int amount, ref List<Int32> elements)
        {
            Console.WriteLine("Вы выбрали ввод вручную.");
            for (int i = 0; i < amount; i++)
            {
                input_node(i, ref elements);
            }
        }

        public static void input_node(int index, ref List<Int32> elements)
        {
            bool check_input = false;
            while (!check_input)
            {
                Console.WriteLine("Введите " + (index + 1) + " элемент:");
                elements.Add(get_int(ref check_input));
            }
        }

        public static void input_randomally(int amount, ref List<Int32> elements)
        {
            Console.WriteLine("Вы выбрали ввод случайным образом.");
            bool refer = true;
            int from = 0, to = 0;
            Random rand = new Random();
            Console.WriteLine("Введите диапазон генерации чисел: ");
            Console.Write("От: ");
            from = get_int(ref refer);
            while (to < from)
            {
                Console.Write("До: ");
                to = get_int(ref refer);
                if (to < from)
                    Console.WriteLine("Введите число больше начала диапозона");
            }
            for (int i = 0; i < amount; i++)
            {
                elements.Add(rand.Next(from, to));
            }
        }

        public static void file_input(int amount, ref List<Int32> elements)
        {
            bool check_input = false;
            bool f_time = true;
            while (!check_input)
            {
                if (f_time)
                    Console.WriteLine("Укажите путь, где хранится файл с данными: ");
                f_time = false;
                String path = Console.ReadLine();
                //var path = @"c:\home\2.txt";
                /*   using (StreamWriter sw = File.CreateText(path))
                   {
                       sw.WriteLine("ПРИВЕТ!!");
                   }*/
                if (File.Exists(path))
                {
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string line = "";
                        while ((line = sr.ReadLine()) != null)
                        {
                            int res = 0;
                            string[] nums = line.Split(' ');
                            foreach (string num in nums)
                            {
                                if (int.TryParse(num, out res))
                                {
                                    res = Int32.Parse(num);
                                    if (elements.Count < amount)
                                        elements.Add(res);
                                }
                            }
                        }
                    }
                    if (elements.Count == amount)
                        check_input = true;
                    Console.WriteLine("Файл некорректен. Повторите ввод: ");
                }
                else Console.WriteLine("Файл не найден. Повторите ввод: ");
            }
        }

        public static void rewrite_file()
        {

        }

        public static void create_file()
        {

        }

        public static void file_save(int amount, ref List<Int32> elements)
        {
            bool check_input = false;
            bool f_time = true;
            while (!check_input)
            {
                if (f_time)
                    Console.WriteLine("Укажите путь, куда записать файл с деревом: ");
                f_time = false;
                String path = Console.ReadLine();
                //var path = @"c:\home\2.txt";
                if (File.Exists(path))
                {
                    Console.WriteLine("Перезаписать файл?" + Environment.NewLine + "[1] -  Да" + Environment.NewLine + "[2] - Нет");
                    int choice = 0;
                    check_input = false;
                    while (!check_input)
                    {
                        choice = get_int(ref check_input);
                    }
                    switch (choice)
                    {
                        case 1:
                            rewrite_file();
                            break;
                        case 2:
                            break;
                        default:
                            Console.WriteLine("Зачтем за нет");
                            break;
                    }

                }
                else
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("ПРИВЕТ!!");
                    }
                    Console.WriteLine("Файл не найден. Повторите ввод: ");
                }
            }
        }
    }
}
