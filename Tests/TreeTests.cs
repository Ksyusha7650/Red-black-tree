using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1;

namespace Tests
{
    public enum Nodes_data { FIRST = 5, SECOND = 3, THIRD = 7 }
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void Main()
        {
            Tree tree_known = new Tree();
            tree_known.root = new TreeNode((int)Nodes_data.FIRST);
            tree_known.root.left = new TreeNode((int)Nodes_data.SECOND);
            tree_known.root.right = new TreeNode((int)Nodes_data.THIRD);
            Tree tree_test = new Tree();
            check_insert(tree_known, ref tree_test);
            check_delete(tree_test);

        }
        public void check_insert(Tree tree_known, ref Tree tree_test)
        {
            tree_test.insert_node(ref tree_test.root, (int)Nodes_data.FIRST);
            tree_test.insert_node(ref tree_test.root, (int)Nodes_data.SECOND);
            tree_test.insert_node(ref tree_test.root, (int)Nodes_data.THIRD);
            Assert.AreEqual(tree_test.root.data, tree_known.root.data);
            Assert.AreEqual(tree_test.root.left.data, tree_known.root.left.data);
            Assert.AreEqual(tree_test.root.right.data, tree_known.root.right.data);
        }

        public void check_delete(Tree tree_test)
        {
            tree_test.delete_node(tree_test, (int)Nodes_data.SECOND);
            Assert.IsTrue(tree_test.root.left.is_leaf);
        }

        public void check_min(Tree tree_known)
        {
            Assert.AreEqual(tree_known.tree_minimum(tree_known.root).data, (int)Nodes_data.SECOND);
        }
    }
}
