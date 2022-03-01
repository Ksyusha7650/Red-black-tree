using System;
using Task_1;

class Program
{
    public static void Main()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        List<Int32> elements = new List<Int32>();
        Interface.Greetings();
        Interface.ChooseInput(ref elements);
        Tree tree = new Tree();
        Tree.MakeTree(elements, ref tree);
        tree.DisplayTree(tree);
        Interface.MenuTree(tree, ref elements);
    }
}
