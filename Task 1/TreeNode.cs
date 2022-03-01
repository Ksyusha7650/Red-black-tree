using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{

    public enum ColorNode { BLACK, RED };


    public class TreeNode
    {
        public int data;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode? parent;
        public ColorNode color = ColorNode.BLACK;
        public bool isLeaf = false;
        public TreeNode(int value) => data = value;
        public TreeNode(bool isLeafM) => isLeaf = isLeafM;
    }

    public class Tree
    {
        public TreeNode? root;
        private const int SPACE_ELEMENTS = 5;
        public void InorderTreeWalk(TreeNode node)
        {
            if (node != null)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                if (!node.isLeaf)
                {
                    InorderTreeWalk(node.left);
                    if (node.color == ColorNode.RED)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" ( " + node.data + " ) ");
                    InorderTreeWalk(node.right);
                }
                else Console.Write(" NIL ");
            }
        }

        public void PreorderTreeWalk(TreeNode node)
        {
            if (node != null)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                if (!node.isLeaf)
                {
                    if (node.color == ColorNode.RED)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" ( " + node.data + " ) ");
                    PreorderTreeWalk(node.left);
                    PreorderTreeWalk(node.right);
                }
                else Console.Write(" NIL ");
            }
        }

        public void PostorderTreeWalk(TreeNode node)
        {
            if (node != null)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                if (!node.isLeaf)
                {
                    PreorderTreeWalk(node.left);
                    PreorderTreeWalk(node.right);
                    if (node.color == ColorNode.RED)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" ( " + node.data + " ) ");


                }
                else Console.Write(" NIL ");
            }
        }

        public void OutputNode(TreeNode node, int space)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            if (node is null)
            {
                return;
            }
            space += SPACE_ELEMENTS;
            OutputNode(node.right, space);
            Console.WriteLine();
            for (int i = SPACE_ELEMENTS; i < space; i++)
                Console.Write(" ");
            if (node.isLeaf) Console.WriteLine("NIL");
            else
            {
                if (node.color == ColorNode.RED) Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(node.data);
            }
            OutputNode(node.left, space);
        }

        public void DisplayTree(Tree tree)
        {
            OutputNode(tree.root, 0);
        }

        public void LeftRotate(ref TreeNode head, TreeNode node1)
        {
            TreeNode node2 = node1.right;
            node1.right = node2.left;
            if (node2.left != null)
                node2.left.parent = node1;
            if (node2 != null)
                node2.parent = node1.parent;
            if (node1.parent == null)
                head = node2;
            else if (node1 == node1.parent.left)
                node1.parent.left = node2;
            else node1.parent.right = node2;
            node2.left = node1;
            node1.parent = node2;
        }

        public void RightRotate(ref TreeNode head, TreeNode node2)
        {
            TreeNode node1 = node2.left;
            node2.left = node1.right;
            if (node1.right != null)
                node1.right.parent = node2;
            if (node1 != null)
                node1.parent = node2.parent;
            if (node2.parent == null)
                head = node1;
            else if (node2 == node2.parent.left)
                node2.parent.left = node1;
            else node2.parent.right = node1;
            node1.right = node2;
            node2.parent = node1;
        }

        public int Height(Tree tree)
        {
            int heightTemp = 0;
            TreeNode node = tree.root;
            while (node != null)
            {
                if ((node.color == ColorNode.BLACK) && (node != tree.root))
                    heightTemp++;
                if (node.left != null)
                    node = node.left;
                else if (node.right != null)
                    node = node.right;
                else break;
            }
            return heightTemp;
        }
        public void InsertNode(ref TreeNode head, int value)
        {
            TreeNode newNode = new TreeNode(value);
            if (head == null)
            {
                head = newNode;
                head.color = ColorNode.BLACK;
                head.left = new TreeNode(true);
                head.right = new TreeNode(true);
                return;
            }
            TreeNode node1 = head;
            TreeNode node2 = new TreeNode(true);
            while (node1.isLeaf == false)
            {
                node2 = node1;
                if (newNode.data < node1.data)
                    node1 = node1.left;
                else node1 = node1.right;
                if (node1 == null) break;
            }
            newNode.parent = node2;
            if ((node2.isLeaf) || (node2 == null))
                head = newNode;
            else if (newNode.data < node2.data)
                node2.left = newNode;
            else node2.right = newNode;
            newNode.left = new TreeNode(true);
            newNode.right = new TreeNode(true);
            newNode.color = ColorNode.RED;
            InsertFixUp(ref head, ref newNode);
        }

        public void InsertFixUp(ref TreeNode head, ref TreeNode newNode)
        {
            while (newNode != head && newNode.parent.color == ColorNode.RED)
            {
                if (newNode.parent == newNode.parent.parent.left)
                {
                    TreeNode node = newNode.parent.parent.right;
                    if ((node != null) && (node.color == ColorNode.RED))
                    {
                        newNode.parent.color = ColorNode.BLACK;
                        node.color = ColorNode.BLACK;
                        newNode.parent.parent.color = ColorNode.RED;
                        newNode = newNode.parent.parent;
                    }
                    else if (newNode != head)
                    {
                        if (newNode == newNode.parent.right)
                        {
                            newNode = newNode.parent;
                            LeftRotate(ref head, newNode);
                        }
                        newNode.parent.color = ColorNode.BLACK;
                        newNode.parent.parent.color = ColorNode.RED;
                        RightRotate(ref head, newNode.parent.parent);
                    }
                }
                else
                {
                    TreeNode node = newNode.parent.parent.left;
                    if ((node != null) && (node.color == ColorNode.RED))
                    {
                        newNode.parent.color = ColorNode.BLACK;
                        node.color = ColorNode.BLACK;
                        newNode.parent.parent.color = ColorNode.RED;
                        newNode = newNode.parent.parent;
                    }
                    else if (newNode != head)
                    {
                        if (newNode == newNode.parent.left)
                        {
                            newNode = newNode.parent;
                            RightRotate(ref head, newNode);
                        }
                        newNode.parent.color = ColorNode.BLACK;
                        newNode.parent.parent.color = ColorNode.RED;
                        LeftRotate(ref head, newNode.parent.parent);
                    }
                }
                head.color = ColorNode.BLACK;
            }
        }

        public static void MakeTree(List<Int32> elements, ref Tree tree)
        {
            if (elements.Count != 0)
            {
                elements.Sort();
                int mid = elements.Count / 2;
                tree.InsertNode(ref tree.root, elements[mid]);
                for (int index = mid - 1; index >= 0; index--)
                {
                    tree.InsertNode(ref tree.root, elements[index]);
                }
                for (int index = mid + 1; index < elements.Count; index++)
                {
                    tree.InsertNode(ref tree.root, elements[index]);
                }
            }
        }

        public TreeNode TreeSearch(int key, TreeNode node)
        {
            if (!node.isLeaf)
            {

                if (key == node.data)
                    return node;

                if (key < node.data)
                    return TreeSearch(key, node.left);
                else return TreeSearch(key, node.right);
            }
            else
            {
                Console.WriteLine("Такой элемент не найден!");
                return null;
            }
        }

        public TreeNode TreeMinimum(TreeNode node)
        {
            while (!node.left.isLeaf) node = node.left;
            return node;
        }

        public TreeNode TreeMaximum(TreeNode node)
        {
            while (!node.right.isLeaf) node = node.right;
            return node;
        }

        public void Transplant(Tree tree, TreeNode node1, TreeNode node2)
        {
            if ((node1.parent == null) || (node1.parent.isLeaf))
                tree.root = node2;
            else if (node1 == node1.parent.left)
                node1.parent.left = node2;
            else node1.parent.right = node2;
            node2.parent = node1.parent;
        }

        public void DeleteNode(Tree tree, int value)
        {
            TreeNode deletingNode = TreeSearch(value, tree.root);
            if (deletingNode == null) return;
            else
            {
                TreeNode node2 = deletingNode;
                ColorNode node2ColorOriginal = node2.color;
                TreeNode node1 = new TreeNode(false);
                if ((deletingNode.left.isLeaf) || (deletingNode.left == null) && (deletingNode.right != null))
                {
                    node1 = deletingNode.right;
                    Transplant(tree, deletingNode, deletingNode.right);
                }
                else if ((deletingNode.right.isLeaf) || (deletingNode.right == null))
                {
                    node1 = deletingNode.left;
                    Transplant(tree, deletingNode, deletingNode.left);
                }
                else
                {
                    node2 = TreeMinimum(deletingNode.right);
                    node2ColorOriginal = node2.color;
                    node1 = node2.right;
                    if (node2.parent == deletingNode)
                        node1.parent = node2;
                    else
                    {
                        Transplant(tree, node2, node2.right);
                        node2.right = deletingNode.right;
                        node2.right.parent = node2;
                    }
                    Transplant(tree, deletingNode, node2);
                    node2.left = deletingNode.left;
                    node2.left.parent = node2;
                    node2.color = deletingNode.color;
                }
                if (node2ColorOriginal == ColorNode.BLACK)
                    DeleteFixUp(tree, node1);
            }

        }

        public void DeleteFixUp(Tree tree, TreeNode node)
        {
            while ((node != tree.root) && (node.color == ColorNode.BLACK))
            {
                if (node == node.parent.left)
                {
                    TreeNode node1 = node.parent.right;
                    if (node1.color == ColorNode.RED)
                    {
                        node1.color = ColorNode.BLACK;
                        node.parent.color = ColorNode.RED;
                        LeftRotate(ref tree.root, node.parent);
                        node1 = node.parent.right;
                    }
                    if ((node1.left.color == ColorNode.BLACK) && (node1.right.color == ColorNode.BLACK))
                    {
                        node1.color = ColorNode.RED;
                        node = node.parent;
                    }
                    else
                    {
                        if (node1.right.color == ColorNode.BLACK)
                        {
                            node1.left.color = ColorNode.BLACK;
                            node1.color |= ColorNode.RED;
                            RightRotate(ref tree.root, node1);
                            node1 = node.parent.right;
                        }
                        node1.color = node.parent.color;
                        node.parent.color = ColorNode.BLACK;
                        node1.right.color = ColorNode.BLACK;
                        LeftRotate(ref tree.root, node.parent);
                        node = tree.root;
                    }
                }
                else
                {
                    TreeNode node1 = node.parent.left;
                    if (node1.color == ColorNode.RED)
                    {
                        node1.color = ColorNode.BLACK;
                        node.parent.color = ColorNode.RED;
                        RightRotate(ref tree.root, node.parent);
                        node1 = node.parent.left;
                    }
                    if ((node1.right.color == ColorNode.BLACK) && (node1.right.color == ColorNode.BLACK))
                    {
                        node1.color = ColorNode.RED;
                        node = node.parent;
                    }
                    else
                    {
                        if (node1.left.color == ColorNode.BLACK)
                        {
                            node1.right.color = ColorNode.BLACK;
                            node1.color = ColorNode.RED;
                            LeftRotate(ref tree.root, node1);
                            node1 = node.parent.left;
                        }
                        node1.color = node.parent.color;
                        node.parent.color = ColorNode.BLACK;
                        node1.left.color = ColorNode.BLACK;
                        RightRotate(ref tree.root, node.parent);
                        node = tree.root;
                    }
                }
            }
            node.color = ColorNode.BLACK;
        }
    }
}
