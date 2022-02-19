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
        public TreeNode? node { get; set; }
        public TreeNode(int value) => data = value;
        public TreeNode(bool is_leaf) => isLeaf = is_leaf;
    }

    public class Tree
    {
        public TreeNode? root;
        private const int COLUMN_WIDTH = 10;
        public void inorder_tree_walk(TreeNode node)
        {
            if (node != null)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                if (!node.isLeaf)
                {
                    inorder_tree_walk(node.left);
                    if (node.color == ColorNode.RED)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" ( " + node.data + " ) ");
                    inorder_tree_walk(node.right);
                }
                else Console.Write(" NIL ");
            }
        }

        public void print(Tree tree)
        {
            print(tree.root, 0);
        }

        private void print(TreeNode node, int space)
        {

            if (node is null)
            {
                return;
            }

            space += COLUMN_WIDTH;

            print(node.right, space);

            System.Console.WriteLine();
            for (int i = COLUMN_WIDTH; i < space; i++)
                Console.Write(" ");
            if (node.isLeaf) Console.WriteLine("NIL");
            else Console.WriteLine(node.data);

            print(node.left, space);
        }

        public void left_rotate(ref TreeNode head, TreeNode node1)
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

        public void right_rotate(ref TreeNode head, TreeNode node2)
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

        public int height(Tree tree)
        {
            int height_t = 0;
            TreeNode node = tree.root;
            while (node != null)
            {
                if ((node.color == ColorNode.BLACK) && (node != tree.root))
                    height_t++;
                if (node.left != null)
                    node = node.left;
                else if (node.right != null)
                    node = node.right;
                else break;
            }
            return height_t;
        }
        public void insert_node(ref TreeNode head, int value)
        {
            TreeNode new_node = new TreeNode(value);
            if (head == null)
            {
                head = new_node;
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
                if (new_node.data < node1.data)
                    node1 = node1.left;
                else node1 = node1.right;
                if (node1 == null) break;
            }
            new_node.parent = node2;
            if ((node2.isLeaf) || (node2 == null))
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
                    else if (new_node != head)
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
                    if ((node != null) && (node.color == ColorNode.BLACK))
                    {
                        new_node.parent.color = ColorNode.RED;
                        node.color = ColorNode.RED;
                        new_node.parent.parent.color = ColorNode.BLACK;
                        new_node = new_node.parent.parent;
                    }
                    else if (new_node != head)
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
                elements.Sort();
                int mid = elements.Count / 2;
                tree.insert_node(ref tree.root, elements[mid]);
                for (int index = mid - 1; index >= 0; index--)
                {
                    tree.insert_node(ref tree.root, elements[index]);
                }
                for (int index = mid + 1; index < elements.Count; index++)
                {
                    tree.insert_node(ref tree.root, elements[index]);
                }
            }
        }

        public TreeNode tree_search(int key, TreeNode node)
        {
            if (!node.isLeaf)
            {
                Console.Write(node.data + " -> ");
                if (key == node.data)
                    return node;

                if (key < node.data)
                    return tree_search(key, node.left);
                else return tree_search(key, node.right);
            }
            else
            {
                Console.WriteLine("Такой элемент не найден!");
                return null;
            }
        }

        public TreeNode tree_minimum(TreeNode node)
        {
            while (!node.left.isLeaf) node = node.left;
            return node;
        }

        public TreeNode tree_maximum(TreeNode node)
        {
            while (!node.right.isLeaf) node = node.right;
            return node;
        }

        public void transplant(Tree tree, TreeNode node1, TreeNode node2)
        {
            if (node1.parent.isLeaf)
                tree.root = node2;
            else if (node1 == node1.parent.left)
                node1.parent.left = node2;
            else node1.parent.right = node2;
            node2.parent = node1.parent;
        }

        public void delete_node(Tree tree, int value)
        {
            TreeNode deleting_node = tree_search(value, tree.root);
            if (deleting_node == null) return;
            else
            {
                TreeNode node2 = deleting_node;
                ColorNode node2_color = node2.color;
                TreeNode node1 = new TreeNode(false);
                if (deleting_node.left.isLeaf)
                {
                    node1 = deleting_node.left;
                    transplant(tree, deleting_node, deleting_node.right);
                }
                else if (deleting_node.right.isLeaf)
                {
                    node1 = deleting_node.left;
                    transplant(tree, deleting_node, deleting_node.left);
                }
                else
                {
                    node2 = tree_minimum(deleting_node.right);
                    node2_color = node2.color;
                    node1 = node2.right;
                    if (node2.parent == deleting_node)
                        node1.parent = node2;
                    else
                    {
                        transplant(tree, node2, node2.right);
                        node2.right = deleting_node.right;
                        node2.right.parent = node2;
                    }
                    transplant(tree, deleting_node, node2);
                    node2.left = deleting_node.left;
                    node2.left.parent = node2;
                    node2.color = deleting_node.color;
                }
                if (node2_color == ColorNode.BLACK)
                    delete_fixup(tree, node1);
            }

        }

        public void delete_fixup(Tree tree, TreeNode node)
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
                        left_rotate(ref tree.root, node.parent);
                        node1 = node.parent.left;
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
                            right_rotate(ref tree.root, node1);
                            node1 = node.parent.right;
                        }
                        node1.color = node.parent.color;
                        node.parent.color = ColorNode.BLACK;
                        node1.right.color = ColorNode.BLACK;
                        left_rotate(ref tree.root, node.parent);
                        node = tree.root;
                    }
                }
                else
                {
                    //Наоборот...
                }
            }
            node.color = ColorNode.BLACK;
        }
    }
}
