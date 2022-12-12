using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ce205_2022_2023_hw3_haluk_kurtulus
{
    public class BPlusTree
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
        /// <summary>
        /// The code starts by creating a new node with the ID of "1" and the string "Hello World".
       /// If there is no root node, then it creates one.
        ///The code then checks if this newly created node is red or not.
        //If it's not red, then it returns 0.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Insert(int ID, string data)
        {
            Node newNode = new Node(ID, data);
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
                    if (ID < current.key)
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
            return 0;
        }
        /// <summary>
        /// The code starts by declaring a variable called current.
        ///The variable is declared as an integer and initialized to the root node of the tree.
        ///The code then declares two variables, parent and isLeftChild.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int Delete(int ID)
        {
            Node current = root;
            Node parent = root;
            bool isLeftChild = true;
            while (current.key != ID)
            {
                parent = current;
                if (ID < current.key)
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
        ///The code starts by finding the predecessor of the node, then it finds its successor.
        ///If there is no successor, then it will go back to the predecessor and continue from there.
        /// </summary>
        /// <param name="delNode"></param>
        /// <returns></returns>
        public Node GetSuccessor(Node delNode)
        {
            Node successorParent = delNode;
            Node successor = delNode;
            Node current = delNode.right;
            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.left;
            }
            if (successor != delNode.right)
            {
                successorParent.left = successor.right;
                successor.right = delNode.right;
            }
            return successor;
        }

        public Node Find(int ID)
        {
            Node current = root;
            while (current.key != ID)
            {
                if (ID < current.key)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
                if (current == null)
                {
                    return null;
                }
            }
            return current;
        }

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