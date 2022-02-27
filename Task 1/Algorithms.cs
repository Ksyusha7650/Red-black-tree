using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{

    public enum Choice { YES = 1, NO }
    public static class Algorithms
    {

        public static int GetInt(ref bool checkInput)
        {
            string str = Console.ReadLine();
            int res = 0;
            if (int.TryParse(str, out res))
            {
                res = Int32.Parse(str);
                checkInput = true;
            }
            else
            {
                Console.WriteLine("Ожидалось число, повторите ввод:");
                checkInput = false;
            }
            return res;
        }

        public static void InputManually(int amount, ref List<Int32> elements)
        {
            for (int i = 0; i < amount; i++)
            {
                InputNode(i, ref elements);
            }
        }

        public static void InputNode(int index, ref List<Int32> elements)
        {
            bool checkInput = false;
            while (!checkInput)
            {
                Console.WriteLine("Введите " + (index + 1) + " элемент:");
                elements.Add(GetInt(ref checkInput));
            }
        }

        public static void InputRandomally(int amount, ref List<Int32> elements)
        {
            bool refer = true;
            int from = 0, to = 0;
            Random rand = new Random();
            Console.WriteLine("Введите диапазон генерации чисел: ");
            Console.Write("От: ");
            from = GetInt(ref refer);
            while (to < from)
            {
                Console.Write("До: ");
                to = GetInt(ref refer);
                if (to < from)
                    Console.WriteLine("Введите число больше начала диапозона");
            }
            for (int i = 0; i < amount; i++)
            {
                elements.Add(rand.Next(from, to));
            }
        }

        public static void FileInput(ref List<Int32> elements)
        {
            bool checkInput = false;
            bool fTime = true;
            while (!checkInput)
            {
                if (fTime)
                    Console.WriteLine("Укажите путь, где хранится файл с данными: ");
                fTime = false;
                String path = Console.ReadLine();
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
                                    elements.Add(res);
                                }
                            }
                        }
                    }
                    checkInput = true;
                }
                else Console.WriteLine("Файл не найден. Повторите ввод: ");
            }
        }

        public static void CreateFile(String path, List<Int32> elements)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (Int32 element in elements)
                {
                    sw.Write(element + " ");
                }
            }
        }

        public static void FileSave(ref List<Int32> elements)
        {
            bool checkInput = false;
            bool fTime = true;

            while (!checkInput)
            {
                if (fTime)
                    Console.WriteLine("Укажите путь, куда записать файл с деревом: ");
                fTime = false;
                String path = Console.ReadLine();
                //var path = @"c:\home\2.txt";
                if (File.Exists(path))
                {
                    Console.WriteLine("Перезаписать файл?" + Environment.NewLine + "[1] -  Да" + Environment.NewLine + "[2] - Нет");
                    int choice = 0;
                    checkInput = false;
                    Choice choiceEnum;
                    while (!checkInput)
                    {
                        choice = GetInt(ref checkInput);
                    }
                    choiceEnum = (Choice)choice;
                    bool choiceInput = false;
                    while (!choiceInput)
                    {
                        switch (choiceEnum)
                        {
                            case Choice.YES:
                                CreateFile(path, elements);
                                choiceInput = true;
                                break;
                            case Choice.NO:
                                Console.WriteLine("Введите путь заново: ");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Файл не найден. Документ будет создан по данному пути: " + Environment.NewLine + path);
                    CreateFile(path, elements);
                    checkInput = true;
                }
            }
        }
    }
}
