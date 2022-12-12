using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ce205_2022_2023_hw3_haluk_kurtulus
{
    public class RedBlackTree
    {
        public class Node
        {
            public int key;
            public Node left;
            public Node right;
            public Node parent;
            public bool isRed;
            public string data;
            public Node(int key, string data)
            {
                this.key = key;
                this.left = null;
                this.right = null;
                this.parent = null;
                this.isRed = true;
                this.data = data;
            }
        }

        public Node root;

        public RedBlackTree()
        {
            root = null;
        }
        /// <summary>
        /// The code is trying to insert a new node into the tree.
        ///The code starts by creating an empty Node object and initializing it with the key and data of the new node.
        ///If there is no root, then create a new root for this node.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Insert(int key, string data)
        {
            Node newNode = new Node(key, data);
            if (root == null)
            {
                root = newNode;
                root.isRed = false;
                return 0;
            }
            else
            {
                Node current = root;
                Node parent = null;
                while (true)
                {
                    parent = current;
                    if (key < current.key)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            newNode.parent = parent;
                            break;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newNode;
                            newNode.parent = parent;
                            break;
                        }
                    }
                }
            }
            if (newNode.parent.isRed)
            {
                BalanceTree(newNode);
            }
            return 0;
        }
        /// <summary>
        /// The code is trying to balance the tree by rotating left or right.
       /// It starts with the grandparent of the new node and then moves down until it finds a parent that is not null.
 ///If there is no parent, it goes up one level and tries again.
        /// </summary>
        /// <param name="newNode"></param>
        public void BalanceTree(Node newNode)
        {
            Node parent = newNode.parent;
            Node grandParent = parent.parent;
            Node uncle = null;
            if (grandParent != null)
            {
                if (grandParent.left == parent)
                {
                    uncle = grandParent.right;
                }
                else
                {
                    uncle = grandParent.left;
                }
            }
            if (uncle != null && uncle.isRed)
            {
                parent.isRed = false;
                uncle.isRed = false;
                grandParent.isRed = true;
                BalanceTree(grandParent);
            }
            else
            {
                if (grandParent.left == parent)
                {
                    if (parent.right == newNode)
                    {
                        RotateLeft(parent);
                        newNode = parent;
                        parent = newNode.parent;
                    }
                    RotateRight(grandParent);
                    parent.isRed = false;
                    grandParent.isRed = true;
                }
                else
                {
                    if (parent.left == newNode)
                    {
                        RotateRight(parent);
                        newNode = parent;
                        parent = newNode.parent;
                    }
                    RotateLeft(grandParent);
                    parent.isRed = false;
                    grandParent.isRed = true;
                }
            }
        }
        /// <summary>
        /// The code rotates the node to its left.
        ///If there is no right, then it will create a new Node and place it in the parent's position.
 ///The code creates a new Node and places it in the parent's position if that is where the current node would be placed by rotating to its left.
        /// </summary>
        /// <param name="node"></param>
        public void RotateLeft(Node node)
        {
            Node newNode = node.right;
            node.right = newNode.left;
            if (newNode.left != null)
            {
                newNode.left.parent = node;
            }
            newNode.parent = node.parent;
            if (node.parent == null)
            {
                root = newNode;
            }
            else
            {
                if (node == node.parent.left)
                {
                    node.parent.left = newNode;
                }
                else
                {
                    node.parent.right = newNode;
                }
            }
            newNode.left = node;
            node.parent = newNode;
        }
        /// <summary>
        /// The code rotates the node to its right.
        ///The newNode is set as the left of the current node, and then it sets the newNode's parent as itself.
 ///If this is not done, a null pointer exception will occur when trying to access an element that does not exist in the tree structure.
        /// </summary>
        /// <param name="node"></param>
        public void RotateRight(Node node)
        {
            Node newNode = node.left;
            node.left = newNode.right;
            if (newNode.right != null)
            {
                newNode.right.parent = node;
            }
            newNode.parent = node.parent;
            if (node.parent == null)
            {
                root = newNode;
            }
            else
            {
                if (node == node.parent.right)
                {
                    node.parent.right = newNode;
                }
                else
                {
                    node.parent.left = newNode;
                }
            }
            newNode.right = node;
            node.parent = newNode;
        }
        /// <summary>
        /// The code starts by declaring a variable called current.
        ///The code then declares two variables, parent and isLeftChild.
        //The first while loop starts with the line "current = root."
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Delete(int key)
        {
            Node current = root;
            Node parent = root;
            bool isLeftChild = false;
            while (current.key != key)
            {
                parent = current;
                if (key < current.key)
                {
                    isLeftChild = true;
                    current = current.left;
                }
                else
                {
                    isLeftChild = false;
                    current = current.right;
                }
                if (current == null)
                {
                    return -1;
                }
            }
            if (current.left == null && current.right == null)
            {
                if (current == root)
                {
                    root = null;
                }
                else if (isLeftChild)
                {
                    parent.left = null;
                }
                else
                {
                    parent.right = null;
                }
            }
            else if (current.right == null)
            {
                if (current == root)
                {
                    root = current.left;
                }
                else if (isLeftChild)
                {
                    parent.left = current.left;
                }
                else
                {
                    parent.right = current.left;
                }
            }
            else if (current.left == null)
            {
                if (current == root)
                {
                    root = current.right;
                }
                else if (isLeftChild)
                {
                    parent.left = current.right;
                }
                else
                {
                    parent.right = current.right;
                }
            }
            else
            {
                Node successor = GetSuccessor(current);
                if (current == root)
                {
                    root = successor;
                }
                else if (isLeftChild)
                {
                    parent.left = successor;
                }
                else
                {
                    parent.right = successor;
                }
                successor.left = current.left;
            }
            return 0;
        }
        /// <summary>
        /// The code is trying to find the successor of a node.
        ///The code starts by finding the parent and then goes through each child until it finds one that is not null.
 ///It then sets the parent as the successor and sets its left child as its right child.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node GetSuccessor(Node node)
        {
            Node parent = node;
            Node successor = node;
            Node current = node.right;
            while (current != null)
            {
                parent = successor;
                successor = current;
                current = current.left;
            }
            if (successor != node.right)
            {
                parent.left = successor.right;
                successor.right = node.right;
            }
            return successor;
        }
        /// <summary>
        /// The code starts by declaring a variable called current.
        ///The code then declares the root node, which is the first node in the tree.
        ///It then goes on to declare two while loops that will iterate over every node in the tree and check if it has found what they are looking for yet.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Search(int key)
        {
            Node current = root;
            while (current.key != key)
            {
                if (key < current.key)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
                if (current == null)
                {
                    return -1;
                }
            }
            return 0;
        }
    }

}