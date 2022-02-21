using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task_1.Algorithms;

namespace Task_1
{
    public enum Menu { ADD = 1, DELETE, SEARCH, ORDER, HEIGHT, SHOW, MIN, MAX, SAVE, EXIT };

    public enum Type_input { MANUALLY = 1, RANDOMLY, FILE }
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
            Type_input type_input = Type_input.MANUALLY;
            while (!check_input)
            {
                choice = get_int(ref check_input);
                type_input = (Type_input)choice;
                if ((type_input < Type_input.MANUALLY) || (type_input > Type_input.FILE))
                {
                    Console.WriteLine("Введите либо 1, либо 2, либо 3.");
                    check_input = false;
                }
            }
            switch (type_input)
            {
                case Type_input.MANUALLY:
                    input_manually(amount, ref elements);
                    break;
                case Type_input.RANDOMLY:
                    input_randomally(amount, ref elements);
                    break;
                case Type_input.FILE:
                    file_input(amount, ref elements);
                    break;
            }
            Console.WriteLine("Введенные элементы: ");
            foreach (Int32 element in elements)
                Console.Write(element + " ");
        }

        public static void menu_tree(Tree tree, ref List<Int32> elements)
        {
            bool check_input = false;
            int choice = 0;
            int key = 0;
            Menu menu_choice = Menu.ADD;
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
                menu_choice = (Menu)choice;
                if ((menu_choice < Menu.ADD) || (menu_choice > Menu.EXIT))
                {
                    Console.WriteLine("Такого пункта в меню нет. Повторите ввод: ");
                    check_input = false;
                }
            }
            switch (menu_choice)
            {
                case Menu.ADD:
                    check_input = false;
                    Console.WriteLine("Введите значение элемента, который хотите вставить: ");
                    while (!check_input)
                    {
                        key = get_int(ref check_input);
                    }
                    tree.insert_node(ref tree.root, key);
                    break;
                case Menu.DELETE:
                    check_input = false;
                    Console.WriteLine("Введите значение элемента, который хотите удалить: ");
                    while (!check_input)
                    {
                        key = get_int(ref check_input);
                    }
                    tree.delete_node(tree, key);
                    menu_tree(tree, ref elements);
                    break;
                case Menu.SEARCH:
                    check_input = false;
                    Console.WriteLine("Введите значение элемента, которого хотите найти: ");
                    while (!check_input)
                    {
                        key = get_int(ref check_input);
                    }
                    TreeNode searched = tree.tree_search(key, tree.root);
                    if (searched != null)
                        Console.WriteLine(searched.data);
                    break;
                case Menu.ORDER:
                    Console.WriteLine("Прямой обход дерева: ");
                    tree.preorder_tree_walk(tree.root);
                    Console.WriteLine();
                    Console.WriteLine("Центрированный обход дерева: ");
                    tree.inorder_tree_walk(tree.root);
                    Console.WriteLine();
                    Console.WriteLine("Обратный обход дерева: ");
                    tree.postorder_tree_walk(tree.root);
                    break;

                case Menu.HEIGHT:
                    Console.WriteLine("Высота дерева = " + tree.height(tree).ToString());
                    break;
                case Menu.SHOW:
                    tree.display_tree(tree);
                    break;
                case Menu.MIN:
                    if (tree.root != null)
                        Console.WriteLine("Минимальный элемент = " + tree.tree_minimum(tree.root).data);
                    else Console.WriteLine("Минимального элемента нет");
                    break;
                case Menu.MAX:
                    if (tree.root != null)
                        Console.WriteLine("Максимальный элемент = " + tree.tree_maximum(tree.root).data);
                    else Console.WriteLine("Минимального элемента нет");
                    break;
                case Menu.SAVE:
                    Algorithms.file_save(ref elements);
                    break;
                case Menu.EXIT:
                    Console.WriteLine("Вы уверены?" + Environment.NewLine + "[1] - Да" + Environment.NewLine + "[2] - Нет");
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
                            break;
                        default:
                            Console.WriteLine("Зачтем за нет");
                            break;
                    }
                    break;
            }
            menu_tree(tree, ref elements);
        }
    }
}
