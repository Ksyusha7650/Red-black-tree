using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task_1.Algorithms;

namespace Task_1
{
    public enum Menu { ADD = 1, DELETE, SEARCH, ORDER, HEIGHT, SHOW, MIN, MAX, SAVE, EXIT };

    public enum TypeInput { MANUALLY = 1, RANDOMLY, FILE }
    public class Interface
    {
        public static void Greetings()
        {
            Console.WriteLine("Программу выполнила Рухлова Ксения Алексеевна."
            + Environment.NewLine + "Группа: 404." + Environment.NewLine + "Вариант: 6." + Environment.NewLine + "Задача номер 2:"
            + Environment.NewLine + "Необходимо реализовать заданную структуру данных, продемонстрировать характерные особенности,"
            + Environment.NewLine + "реализовать возможность добавления и удаления элементов, визуализировать красно-черное дерево."
            + Environment.NewLine + "В программе должны быть предусмотрены три варианта заполнения: пользователем с клавиатуры,"
            + "из файла и случайными числами.");
        }

        public static void InputAmount(ref int amount)
        {
            bool checkInput = false;
            Console.WriteLine("Введите количество элементов: ");
            while (!checkInput)
            {
                amount = GetInt(ref checkInput);
                if (amount <= 0)
                {
                    Console.WriteLine("Количество элементов не может быть неположительным, повторите ввод: ");
                    checkInput = false;
                }
            }
        }
        public static void ChooseInput(ref List<Int32> elements)
        {
            bool checkInput = false;
            int choice = 0;
            int amount = 0;
            Console.WriteLine("Выберите способ заполнения дерева: "
            + Environment.NewLine + "[1] - Ввод вручную" + Environment.NewLine + "[2] - Ввод случайным образом"
            + Environment.NewLine + "[3] - Взять данные из файла");
            TypeInput type_input = TypeInput.MANUALLY;
            while (!checkInput)
            {
                choice = GetInt(ref checkInput);
                type_input = (TypeInput)choice;
                if ((type_input < TypeInput.MANUALLY) || (type_input > TypeInput.FILE))
                {
                    Console.WriteLine("Введите либо 1, либо 2, либо 3.");
                    checkInput = false;
                }
            }
            switch (type_input)
            {
                case TypeInput.MANUALLY:
                    Interface.InputAmount(ref amount);
                    InputManually(amount, ref elements);
                    break;
                case TypeInput.RANDOMLY:
                    Interface.InputAmount(ref amount);
                    InputRandomally(amount, ref elements);
                    break;
                case TypeInput.FILE:
                    FileInput(ref elements);
                    break;
            }
            Console.WriteLine("Введенные элементы: ");
            foreach (Int32 element in elements)
                Console.Write(element + " ");
        }

        public static void MenuTree(Tree tree, ref List<Int32> elements)
        {
            bool checkInput = false;
            int choice = 0;
            int key = 0;
            Menu menuChoice = Menu.ADD;
            Console.WriteLine(Environment.NewLine + "..............................");
            Console.WriteLine("Выберите пункт меню: "
            + Environment.NewLine + "[1] - Добавить элемент в дерево" + Environment.NewLine + "[2] - Удалить элемент из дерева"
            + Environment.NewLine + "[3] - Поиск элемента в дереве" + Environment.NewLine + "[4] - Показать обход дерева"
            + Environment.NewLine + "[5] - Высота дерева" + Environment.NewLine + "[6] - Показать дерево"
            + Environment.NewLine + "[7] - Минимальный элемент дерева" + Environment.NewLine + "[8] - Максимальный элемент дерева"
            + Environment.NewLine + "[9] - Сохранить дерево в файл" + Environment.NewLine + "[10] - Выйти");
            while (!checkInput)
            {
                choice = GetInt(ref checkInput);
                menuChoice = (Menu)choice;
                if ((menuChoice < Menu.ADD) || (menuChoice > Menu.EXIT))
                {
                    Console.WriteLine("Такого пункта в меню нет. Повторите ввод: ");
                    checkInput = false;
                }
            }
            switch (menuChoice)
            {
                case Menu.ADD:
                    checkInput = false;
                    Console.WriteLine("Введите значение элемента, который хотите вставить: ");
                    while (!checkInput)
                    {
                        key = GetInt(ref checkInput);
                    }
                    tree.InsertNode(ref tree.root, key);
                    break;
                case Menu.DELETE:
                    checkInput = false;
                    Console.WriteLine("Введите значение элемента, который хотите удалить: ");
                    while (!checkInput)
                    {
                        key = GetInt(ref checkInput);
                    }
                    tree.DeleteNode(tree, key);
                    break;
                case Menu.SEARCH:
                    checkInput = false;
                    Console.WriteLine("Введите значение элемента, которого хотите найти: ");
                    while (!checkInput)
                    {
                        key = GetInt(ref checkInput);
                    }
                    TreeNode searched = tree.TreeSearch(key, tree.root);
                    if (searched != null)
                        Console.WriteLine(searched.data);
                    break;
                case Menu.ORDER:
                    Console.WriteLine("Прямой обход дерева: ");
                    tree.PreorderTreeWalk(tree.root);
                    Console.WriteLine();
                    Console.WriteLine("Центрированный обход дерева: ");
                    tree.InorderTreeWalk(tree.root);
                    Console.WriteLine();
                    Console.WriteLine("Обратный обход дерева: ");
                    tree.PostorderTreeWalk(tree.root);
                    break;

                case Menu.HEIGHT:
                    Console.WriteLine("Высота дерева = " + tree.Height(tree).ToString());
                    break;
                case Menu.SHOW:
                    tree.DisplayTree(tree);
                    break;
                case Menu.MIN:
                    if (tree.root != null)
                        Console.WriteLine("Минимальный элемент = " + tree.TreeMinimum(tree.root).data);
                    else Console.WriteLine("Минимального элемента нет");
                    break;
                case Menu.MAX:
                    if (tree.root != null)
                        Console.WriteLine("Максимальный элемент = " + tree.TreeMaximum(tree.root).data);
                    else Console.WriteLine("Минимального элемента нет");
                    break;
                case Menu.SAVE:
                    Algorithms.FileSave(ref elements);
                    break;
                case Menu.EXIT:
                    Console.WriteLine("Вы уверены?" + Environment.NewLine + "[1] - Да" + Environment.NewLine + "[2] - Нет");
                    checkInput = false;
                    while (!checkInput)
                    {
                        choice = GetInt(ref checkInput);
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
            MenuTree(tree, ref elements);
        }
    }
}
