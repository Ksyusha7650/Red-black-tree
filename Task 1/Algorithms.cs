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
                bool check_input = false;
                while (!check_input)
                {
                    Console.WriteLine("Введите " + (i + 1) + " элемент:");
                    elements.Add(get_int(ref check_input));
                }
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

    }
}
