using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ce205_2022_2023_hw3_haluk_kurtulus;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// HASHINGWITHCHAINING
        /// </summary>
        [TestMethod]
        public void HashingwithChainingInsert()
        {
            
            HashingChaining hash = new HashingChaining(100);
            hash.HashingChainingInsert(1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            hash.HashingChainingInsert(2, "Aenean nec metus porta, feugiat quam ac, aliquet diam.");
            hash.HashingChainingInsert(3, "Vivamus eu odio sed lacus tincidunt mattis quis sed urna.");
            hash.HashingChainingInsert(4, "Duis sit amet odio et enim blandit mollis in vel dui.");

            Assert.AreEqual("Lorem ipsum dolor sit amet, consectetur adipiscing elit.", hash.table[1].First.Value.data);
        }
        /// <summary>
        /// OPENADDRESSING 
        /// </summary>
        [TestMethod]
        public void HashingwithOpenAddressingLinearProbingTest()
        {
            OpenAddressing hash = new OpenAddressing(100);
            int n = 15;
            hash.OpenAddressingLinearProbingInsert(44, "Ndolor sit amet, consectetur adipiscing elit.", n);
            hash.OpenAddressingLinearProbingInsert(17, "Quisque nec leo at nisl mollis pulvinar sed eu lacus.", n);
            hash.OpenAddressingLinearProbingInsert(52, "Nullam non dui nibh.", n);
            hash.OpenAddressingLinearProbingInsert(69, "Pellentesque habitant morbi tristique senectus et netus et malesuada", n);
            Assert.AreEqual("Quisque nec leo at nisl mollis pulvinar sed eu lacus.", hash.table[2].data);
        }
        [TestMethod]
        public void HashingwithOpenAddressingQuadraticProbingTest()
        {
            OpenAddressing hash = new OpenAddressing(100);
            int n = 31;
            hash.OpenAddressingQuadraticProbingInsert(94, "fames ac turpis egestas. Integer in fermentum turpis.", n);
            hash.OpenAddressingQuadraticProbingInsert(67, "id blandit odio.", n);
            hash.OpenAddressingQuadraticProbingInsert(39, "Nullam lobortis lacus vel purus pellentesque.", n);
            hash.OpenAddressingQuadraticProbingInsert(45, "vel ultricies ex tempor. Curabitur convallis.", n);
            hash.OpenAddressingQuadraticProbingInsert(31, "est in ligula maximus, sit amet dictum orci.", n);
            Assert.AreEqual("est in ligula maximus, sit amet dictum orci.", hash.table[0].data);
        }
        [TestMethod]
        public void HashingwithOpenAddressingDoubleProbingTest()
        {
            OpenAddressing hash = new OpenAddressing(100);
            int n = 8;
            hash.OpenAddressingDoubleProbingInsert(91, "hendrerit. Ut vitae libero convallis.", n);
            hash.OpenAddressingDoubleProbingInsert(74, "sollicitudin elit in, semper lorem.", n);
            hash.OpenAddressingDoubleProbingInsert(69, "Cras ultrices et ante consequat ultrices.", n);
            hash.OpenAddressingDoubleProbingInsert(41, "Suspendisse potenti.", n);
            hash.OpenAddressingDoubleProbingInsert(68, "Suspendisse iaculis orci nec dolor vulputate.", n);
            hash.OpenAddressingDoubleProbingInsert(86, "at accumsan ipsum egestas.", n);
            Assert.AreEqual("at accumsan ipsum egestas.", hash.table[6].data);
        }
        /////////////////////////////AVLTREEE///////////////////////////
        [TestMethod]
        public void AVLTreeInsertion()
        {
            AVLTree tree = new AVLTree();
            tree.insert(8, "Proin semper fermentum lorem. Vivamus vulputate auctor.");
            tree.insert(31, "Donec pharetra eros sagittis, mattis eros quis.");
            tree.insert(5, "Pellentesque dignissim tincidunt quam ut pulvinar. Aliquam.");

            Assert.AreEqual("Proin semper fermentum lorem. Vivamus vulputate auctor.", tree.root.data);
        }
        [TestMethod]
        public void AVLTreeDeletion()
        {
            AVLTree tree = new AVLTree();
            tree.insert(5, "Proin semper fermentum lorem. Vivamus vulputate auctor.");
            tree.insert(7, "Donec pharetra eros sagittis, mattis eros quis.");
            tree.insert(9, "Pellentesque dignissim tincidunt quam ut pulvinar. Aliquam.");
            tree.delete(5);

            Assert.AreEqual(0, tree.search(5));
        }
        [TestMethod]
        public void AVLTreeSearch()
        {
            AVLTree tree = new AVLTree();
            tree.insert(54, "Proin semper fermentum lorem. Vivamus vulputate auctor.");
            tree.insert(42, "Donec pharetra eros sagittis, mattis eros quis.");
            tree.insert(74, "Pellentesque dignissim tincidunt quam ut pulvinar. Aliquam.");

            Assert.AreEqual(1, tree.search(74));
        }
        //////////////////////////////////RED BLACK TREE//////////////////////////
        [TestMethod]
        public void RedBlackTreeInsertion()
        {
            RedBlackTree tree = new RedBlackTree();
            tree.Insert(7, "Proin semper fermentum lorem. Vivamus vulputate auctor.");
            tree.Insert(6, "Donec pharetra eros sagittis, mattis eros quis.");
            tree.Insert(31, "Pellentesque dignissim tincidunt quam ut pulvinar. Aliquam.");

            Assert.AreEqual("Proin semper fermentum lorem. Vivamus vulputate auctor.", tree.root.data);
        }
        [TestMethod]
        public void RedBlackTreeDeletion()
        {
            RedBlackTree tree = new RedBlackTree();
            tree.Insert(89, "Proin semper fermentum lorem. Vivamus vulputate auctor.");
            tree.Insert(61, "Donec pharetra eros sagittis, mattis eros quis.");
            tree.Insert(45, "Pellentesque dignissim tincidunt quam ut pulvinar. Aliquam.");
            tree.Delete(61);

            Assert.AreEqual("Pellentesque dignissim tincidunt quam ut pulvinar. Aliquam.", tree.root.left.data);
        }
        [TestMethod]
        public void RedBlackTreeSearch()
        {
            RedBlackTree tree = new RedBlackTree();
            tree.Insert(61, "Proin semper fermentum lorem. Vivamus vulputate auctor.");
            tree.Insert(74, "Donec pharetra eros sagittis, mattis eros quis.");
            tree.Insert(8, "Pellentesque dignissim tincidunt quam ut pulvinar. Aliquam.");

            Assert.AreEqual(0, tree.Search(61));
        }
        //////////////////////////////////B + TREE//////////////////////////
    }
}