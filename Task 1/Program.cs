using System;
using Task_1;

class Program
{
    public static void Main()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        int amount = 0;
        List<Int32> elements = new List<Int32>();
        Interface.greetings();
        Interface.input_amount(ref amount);
        Interface.choose_input(amount, ref elements);
        Tree tree = new Tree();
        Tree.make_tree(elements, ref tree);
        Console.WriteLine("Корень дерева = " + tree.root.data);
        tree.inorder_tree_walk(tree.root);
        tree.print(tree);
        Interface.menu_tree(tree);
    }
}

