using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{

    public enum ColorNode {BLACK, RED};


    public class TreeNode
    {
        public int data;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode? parent;
        public ColorNode color = ColorNode.BLACK;
        public bool isLeaf = false;
        public TreeNode? node { get; set; }
        public TreeNode(int value) => data = value;
        public TreeNode(bool is_leaf)=> isLeaf = is_leaf;
    }


    public class Tree
    {
        public TreeNode? root;


        public void left_rotate(ref TreeNode head,TreeNode node1)
        {
            TreeNode node2 = node1.right;
            node1.right = node2.left;
            if (node2.left != null)
                node2.left.parent = node1;
            node2.parent = node1.parent;
            if (node1.parent == null)
                head = node2;
            else if (node1 == node1.parent.left)
                node1.parent.left = node2;
            else node1.parent.right = node2;
            node2.left = node1;
            node1.parent = node2;
        }

        public void right_rotate(ref TreeNode head, TreeNode node1) 
        {
            TreeNode node2 = node1.parent;
            node2.left = node1.right;
            if (node1.right != null)   //check
                node1.right.parent = node2;
            node1.parent = node2.parent;
            if (node2.parent == null)
                head = node1;
            else if (node2 == node2.parent.left)
                node2.parent.left = node1;
            else node2.parent.right = node1;
            node1.right = node2;
            node2.parent = node1;
        }

        public void output_node(TreeNode node, int width, int height)
        {
            if (node != null)
            {
                if (!node.isLeaf)
                {
                    if (node.color == ColorNode.BLACK)
                        Console.ForegroundColor = ConsoleColor.Black;
                    else Console.ForegroundColor = ConsoleColor.Red;
                    for (int i = 0; i < height; i++) Console.WriteLine("");
                    for (int j = 0; j < width+1; j++) Console.Write(" ");
                    Console.Write("( " + node.data + ") ");
                    Console.WriteLine();
                    for (int j = 0; j < width - 2; j++) Console.Write(" ");
                    if (node.left.isLeaf) Console.Write("NIL");
                    Console.Write("( " + node.left.data + ") ");
                    for (int j = 0; j < 2; j++) Console.Write(" ");
                    if (node.right.isLeaf) Console.Write("NIL");
                    Console.Write("( " + node.left.data + ") ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("NIL");
                }
            }
        }

        public void dis(Tree tree, int height)
        {
            TreeNode node = tree.root;
            p(node);
            while (node != null)
            {
                Console.WriteLine();
                if ((node.left != null) && (node.right != null))
                {
                    Console.WriteLine();
                    p(node.left);
                    Console.Write("   ");
                    p(node.right);
                    if (!node.left.isLeaf) node = node.left;
                }
               
            }
        }

        public void p(TreeNode node)
        {
            Console.Write(node.data);
        }

        public void outp(Tree tree, int height)
        {
            TreeNode node = tree.root;
            if (node != null)
            {
                int temporary_height = 0;
                output_node(node, height - temporary_height, temporary_height);
                while (node != null)
                {
                    if (node.left.isLeaf == false)
                    {
                        node = node.left;
                        temporary_height++;
                        if (node.parent.right.isLeaf == false)
                        {
                            output_node(node, height - temporary_height, temporary_height);
                            node = node.parent;
                        }
                    }
                    if (node.right.isLeaf == false)
                    {
                        node = node.right;
                        temporary_height++;
                    }
                    else if (node.parent.left.isLeaf) break;
                }
            }
            else Console.WriteLine("Дерево пустое!");
        }


        public int height(Tree tree)
        {
            int height_t = 0;
            TreeNode node = tree.root;
            while (node != null)
            {
                height_t++;
                if (node.left != null) 
                    node = node.left;
                else if (node.right != null)
                    node = node.right;
                else break;
            }
            return height_t;
        }
        public void display_tree(Tree tree)
        {
          /*  if (tree != null)
                output_node(tree.root, 1);
            else Console.WriteLine("Дерево пустое!");*/
        }


        public void insert_node(ref TreeNode head, int value)
        {
            TreeNode new_node = new TreeNode(value);
            TreeNode node1 = head;
            TreeNode node2 = new TreeNode(true);
          
            while(node1.isLeaf == false)
            {
                node2 = node1;
                if (new_node.data < node1.data)
                    node1 = node1.left;
                else node1 = node1.right;
                if (node1 == null) break;
            }
            new_node.parent = node2;
            if (node2.isLeaf)
                head = new_node;
            else if (new_node.data < node2.data)
                node2.left = new_node;
            else node2.right = new_node;
            new_node.left = new TreeNode(true);
            new_node.right = new TreeNode(true);
            new_node.color = ColorNode.RED;
            insert_fix_up(ref head, ref new_node);
           
        }

        public void insert_fix_up(ref TreeNode head, ref TreeNode new_node)
        {
            while (new_node != head && new_node.parent.color == ColorNode.RED)
            {
                if (new_node.parent == new_node.parent.parent.left)
                {
                    TreeNode node = new_node.parent.parent.right;
                    if ((node != null) && (node.color == ColorNode.RED))
                    {
                        new_node.parent.color = ColorNode.BLACK;
                        node.color = ColorNode.BLACK;
                        new_node.parent.parent.color = ColorNode.RED;
                        new_node = new_node.parent.parent;
                    }
                    else
                    {
                        if (new_node == new_node.parent.right)
                        {
                            new_node = new_node.parent;
                            left_rotate(ref head, new_node);
                        }

                        new_node.parent.color = ColorNode.BLACK;
                        new_node.parent.parent.color = ColorNode.RED;
                        right_rotate(ref head, new_node.parent.parent);
                    }
                }
                else
                {
                    TreeNode node = new_node.parent.parent.left;
                    if ((node != null) && (node.color == ColorNode.RED))
                        {
                            new_node.parent.color = ColorNode.BLACK;
                            node.color = ColorNode.BLACK;
                            new_node.parent.parent.color = ColorNode.RED;
                            new_node = new_node.parent.parent;
                        }
                        else 
                        { 
                            if (new_node == new_node.parent.left)
                             {
                            new_node = new_node.parent;
                            right_rotate(ref head, new_node);
                             }
                        new_node.parent.color = ColorNode.BLACK;
                        new_node.parent.parent.color = ColorNode.RED;
                        left_rotate(ref head, new_node.parent.parent);
                        }
                }
                head.color = ColorNode.BLACK;
            }
        }

        public static void make_tree(List<Int32> elements, ref Tree tree)
        {
            if (elements.Count != 0)
            {
                tree.root = new TreeNode(elements[0]);
                for(int i = 1; i < elements.Count; i++)
                    tree.insert_node(ref tree.root, elements[i]);
            }
        }
 
    }
    
}
