using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1;

namespace Tests
{
    public enum NodesData { FIRST = 5, SECOND = 3, THIRD = 7 }
    [TestClass]
    public class TreeTests
    {
        [TestMethod]

        public void checkInsert()
        {
            Tree treeKnown = new Tree();
            treeKnown.root = new TreeNode((int)NodesData.FIRST);
            treeKnown.root.left = new TreeNode((int)NodesData.SECOND);
            treeKnown.root.right = new TreeNode((int)NodesData.THIRD);
            Tree treeTest = new Tree();
            treeTest.InsertNode(ref treeTest.root, (int)NodesData.FIRST);
            treeTest.InsertNode(ref treeTest.root, (int)NodesData.SECOND);
            treeTest.InsertNode(ref treeTest.root, (int)NodesData.THIRD);
            Assert.AreEqual(treeTest.root.data, treeKnown.root.data);
            Assert.AreEqual(treeTest.root.left.data, treeKnown.root.left.data);
            Assert.AreEqual(treeTest.root.right.data, treeKnown.root.right.data);
        }

        [TestMethod]
        public void checkDelete()
        {
            Tree treeTest = new Tree();
            treeTest.InsertNode(ref treeTest.root, (int)NodesData.FIRST);
            treeTest.InsertNode(ref treeTest.root, (int)NodesData.SECOND);
            treeTest.InsertNode(ref treeTest.root, (int)NodesData.THIRD);
            treeTest.DeleteNode(treeTest, (int)NodesData.SECOND);
            Assert.IsTrue(treeTest.root.left.isLeaf);
        }

        [TestMethod]
        public void checkMin()
        {
            Tree treeTest = new Tree();
            treeTest.InsertNode(ref treeTest.root, (int)NodesData.FIRST);
            treeTest.InsertNode(ref treeTest.root, (int)NodesData.SECOND);
            treeTest.InsertNode(ref treeTest.root, (int)NodesData.THIRD);
            TreeNode minNode = treeTest.TreeMinimum(treeTest.root);
            Assert.AreEqual(minNode.data, (int)NodesData.SECOND);
        }

        [TestMethod]
        public void checkMax()
        {
            Tree treeTest = new Tree();
            treeTest.InsertNode(ref treeTest.root, (int)NodesData.FIRST);
            treeTest.InsertNode(ref treeTest.root, (int)NodesData.SECOND);
            treeTest.InsertNode(ref treeTest.root, (int)NodesData.THIRD);
            TreeNode maxNode = treeTest.TreeMaximum(treeTest.root);
            Assert.AreEqual(maxNode.data, (int)NodesData.THIRD);
        }

        [TestMethod]
        public void checkHeight()
        {
            Tree treeTest = new Tree();
            treeTest.InsertNode(ref treeTest.root, (int)NodesData.FIRST);
            treeTest.InsertNode(ref treeTest.root, (int)NodesData.SECOND);
            treeTest.InsertNode(ref treeTest.root, (int)NodesData.THIRD);
            int height = treeTest.Height(treeTest);
            Assert.AreEqual(height, 1);
        }
    }
}
