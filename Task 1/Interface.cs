using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task_1.Algorithms;

namespace Task_1
{
    public class Interface
    {
        public static void greetings()
        {
            Console.WriteLine("Программу выполнила Рухлова Ксения Алексеевна."
            + Environment.NewLine + "Группа: 404." + Environment.NewLine + "Вариант: 6." + Environment.NewLine + "Задача номер 2:"
            + Environment.NewLine + "Необходимо реализовать заданную структуру данных, продемонстрировать характерные особенности,"
            + Environment.NewLine + "реализовать возможность добавления и удаления элементов, визуализировать красно-черное дерево."
            + Environment.NewLine + "В программе должны быть предусмотрены три варианта заполнения: пользователем с клавиатуры,"
            + "из файла и случайными числами.");
        }

        public static void input_amount(ref int amount){
            bool check_input = false;
            Console.WriteLine("Введите количество элементов: ");
            while (!check_input)
            {
                amount = get_int(ref check_input);
                if (amount < 0)
                {
                    Console.WriteLine("Количество элементов не может быть отрицательным, повторите ввод: ");
                    check_input = false;
                }
            }
        }
        public static void choose_input(int amount, ref List<Int32> elements)
        {
            bool check_input = false;
            int choice = 0;
            Console.WriteLine("Выберите способ заполнения дерева: "
            + Environment.NewLine + "[1] - ввод вручную" + Environment.NewLine + "[2] - ввод случайным образом" 
            + Environment.NewLine + "[3] - взять данные из файла" );
            while (!check_input) 
            {
                choice = get_int(ref check_input);
                if ((choice < 1) || (choice > 3))
                {
                    Console.WriteLine("Введите либо 1, либо 2, либо 3.");
                    check_input = false;
                }
            }
            switch (choice)
            {
                case 1:
                    input_manually(amount, ref elements);
                    break;
                case 2:
                    input_randomally(amount, ref elements);
                    break;
                case 3:
                    Console.WriteLine("Вы выбрали ввод из файла."); 
                    break;
            }
            Console.WriteLine("Введенные элементы: ");
            foreach (Int32 element in elements)
                Console.Write(element + " ");
        }
    }
}
