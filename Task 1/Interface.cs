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

        public static void input_amount(ref int amount)
        {
            bool check_input = false;
            Console.WriteLine("Введите количество элементов: ");
            while (!check_input)
            {
                amount = get_int(ref check_input);
                if (amount <= 0)
                {
                    Console.WriteLine("Количество элементов не может быть неположительным, повторите ввод: ");
                    check_input = false;
                }
            }
        }
        public static void choose_input(int amount, ref List<Int32> elements)
        {
            bool check_input = false;
            int choice = 0;
            Console.WriteLine("Выберите способ заполнения дерева: "
            + Environment.NewLine + "[1] - Ввод вручную" + Environment.NewLine + "[2] - Ввод случайным образом"
            + Environment.NewLine + "[3] - Взять данные из файла");
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
                    file_input(amount, ref elements, true);
                    break;
            }
            Console.WriteLine("Введенные элементы: ");
            foreach (Int32 element in elements)
                Console.Write(element + " ");
        }

        public static void menu_tree(Tree tree)
        {
            bool check_input = false;
            int choice = 0;
            int key = 0;
            Console.WriteLine(Environment.NewLine + "..............................");
            Console.WriteLine("Выберите пункт меню: "
            + Environment.NewLine + "[1] - Добавить элемент в дерево" + Environment.NewLine + "[2] - Удалить элемент из дерева"
            + Environment.NewLine + "[3] - Поиск элемента в дереве" + Environment.NewLine + "[4] - Показать обход дерева"
            + Environment.NewLine + "[5] - Высота дерева" + Environment.NewLine + "[6] - Показать дерево"
            + Environment.NewLine + "[7] - Минимальный элемент дерева" + Environment.NewLine + "[8] - Максимальный элемент дерева"
            + Environment.NewLine + "[9] - Сохранить дерево в файл" + Environment.NewLine + "[10] - Выйти");
            while (!check_input)
            {
                choice = get_int(ref check_input);
                if ((choice < 1) || (choice > 10))
                {
                    Console.WriteLine("Такого пункта в меню нет. Повторите ввод: ");
                    check_input = false;
                }
            }
            switch (choice)
            {
                case 1:

                    break;
                case 2:
                    check_input = false;
                    Console.WriteLine("Введите значение элемента, который хотите удалить: ");
                    while (!check_input)
                    {
                        key = get_int(ref check_input);
                    }
                    tree.delete_node(tree, key);
                    menu_tree(tree);
                    break;
                case 3:
                    check_input = false;
                    Console.WriteLine("Введите значение элемента, которого хотите найти: ");
                    while (!check_input)
                    {
                        key = get_int(ref check_input);
                    }
                    TreeNode searched = tree.tree_search(key, tree.root);
                    if (searched != null)
                        Console.WriteLine(searched.data);
                    menu_tree(tree);
                    break;
                case 4:
                    tree.inorder_tree_walk(tree.root);
                    menu_tree(tree);
                    break;

                case 5:
                    Console.WriteLine("Размер дерева = " + tree.height(tree).ToString());
                    menu_tree(tree);
                    break;
                case 6:
                    tree.print(tree);
                    menu_tree(tree);
                    break;

                case 7:
                    Console.WriteLine("Минимальный элемент = " + tree.tree_minimum(tree.root).data);
                    menu_tree(tree);
                    break;
                case 8:
                    Console.WriteLine("Максимальный элемент = " + tree.tree_maximum(tree.root).data);
                    menu_tree(tree);
                    break;

                case 10:
                    Console.WriteLine("Вы уверены?"
                     + Environment.NewLine + "[1] - Да" + Environment.NewLine + "[2] - Нет");
                    check_input = false;
                    while (!check_input)
                    {
                        choice = get_int(ref check_input);
                    }
                    switch (choice)
                    {
                        case 1:
                            Environment.Exit(1);
                            break;
                        case 2:
                            menu_tree(tree);
                            break;
                        default:
                            Console.WriteLine("Зачтем за нет");
                            menu_tree(tree);
                            break;
                    }
                    break;
            }
        }
    }
}

