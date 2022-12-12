using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ce205_2022_2023_hw3_haluk_kurtulus
{
    public class AVLTree
    {
        public class Node
        {
            public int ID, height;
            public string data;

            public Node left, right;

            public Node(int ID, string data)
            {
                this.ID = ID;
                this.data = data;
                this.height = 1;
            }
        }
        public Node root;

        /// <summary>
        ///  The code is trying to find the height of a node.
        /// If the node is null, it will return 0.
        /// Otherwise, it will return the height of that node.
        ///The code will return the height of the node N if it is not null.
       /// </summary>
       /// <param name="N"></param>
       /// <returns></returns>
        public int Height(Node N)
        {
            if (N == null)
                return 0;
            return N.height;
        }

        /// <summary>
        ///The code will return the larger of a and b. int Max(int a, int b) { if (a > b) return a; else return b; }
        ///The input code is too short to provide a detailed and accurate answer.To gain deeper insight, try again using a longer piece of code.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        /// <summary>
        ///The code is trying to rotate the node on the right by one step.
        ///The code starts with a variable x which is set to y's left and then it sets T2 as x's right.
        ///Then, it sets x's right as y and sets y's left as T2.
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public Node RightRotate(Node y)
        {
            Node x = y.left;
            Node T2 = x.right;

            x.right = y;
            y.left = T2;

            y.height = Max(Height(y.left), Height(y.right)) + 1;
            x.height = Max(Height(x.left), Height(x.right)) + 1;

            return x;
        }

        /// <summary>
        ///The code is a function that rotates the node to the left.
       ///The first line creates a new node and sets its height to be 1.
       ///This is done so that it will not overlap with any other nodes on the screen.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Node LeftRotate(Node x)
        {
            Node y = x.right;
            Node T2 = y.left;

            y.left = x;
            x.right = T2;

            x.height = Max(Height(x.left), Height(x.right)) + 1;
            y.height = Max(Height(y.left), Height(y.right)) + 1;

            return y;
        }

        /// <summary>
        /// The code is trying to get the balance of a node.
       /// If the node is null, then it returns 0.
       ///Otherwise, it gets the height difference between its left and right nodes.
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int GetBalance(Node N)
        {
            if (N == null)
                return 0;
            return Height(N.left) - Height(N.right);
        }
        /// <summary>
        /// The code starts by checking if the node is null.
       ///If it is, then a new Node object with an ID of 1 and data of "data" will be created.
        ///If not, then the code checks to see if the node's ID is less than or equal to that of its left child.
       ///If so, then the left child will be inserted into this position and its height increased by one unit.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="ID"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node Insert(Node node, int ID, string data)
        {
            if (node == null)
                return (new Node(ID, data));

            if (ID < node.ID)
                node.left = Insert(node.left, ID, data);
            else if (ID > node.ID)
                node.right = Insert(node.right, ID, data);
            else
                return node;

            node.height = 1 + Max(Height(node.left), Height(node.right));

            int balance = GetBalance(node);

            if (balance > 1 && ID < node.left.ID)
                return RightRotate(node);

            if (balance < -1 && ID > node.right.ID)
                return LeftRotate(node);

            if (balance > 1 && ID > node.left.ID)
            {
                node.left = LeftRotate(node.left);
                return RightRotate(node);
            }

            if (balance < -1 && ID < node.right.ID)
            {
                node.right = RightRotate(node.right);
                return LeftRotate(node);
            }

            return node;
        }
        /// <summary>
        /// The code is trying to delete the node with ID=1.
         /// If that node is null, then it will be deleted from the left side of the tree and if it's not null, then it will be deleted from the right side of the tree.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Node Delete(Node root, int ID)
        {
            if (root == null)
                return root;

            if (ID < root.ID)
                root.left = Delete(root.left, ID);
            else if (ID > root.ID)
                root.right = Delete(root.right, ID);
            else
            {
                if ((root.left == null) || (root.right == null))
                {
                    Node temp = null;
                    if (temp == root.left)
                        temp = root.right;
                    else
                        temp = root.left;

                    if (temp == null)
                    {
                        temp = root;
                        root = null;
                    }
                    else
                        root = temp;
                }
                else
                {
                    Node temp = minValueNode(root.right);

                    root.ID = temp.ID;
                    root.right = Delete(root.right, temp.ID);
                }
            }

            if (root == null)
                return root;

            root.height = Max(Height(root.left), Height(root.right)) + 1;

            int balance = GetBalance(root);

            if (balance > 1 && GetBalance(root.left) >= 0)
                return RightRotate(root);

            if (balance > 1 && GetBalance(root.left) < 0)
            {
                root.left = LeftRotate(root.left);
                return RightRotate(root);
            }

            if (balance < -1 && GetBalance(root.right) <= 0)
                return LeftRotate(root);

            if (balance < -1 && GetBalance(root.right) > 0)
            {
                root.right = RightRotate(root.right);
                return LeftRotate(root);
            }

            return root;
        }
        /// <summary>
        /// The code is a recursive function that will find the minimum value of an array.
        ///The code starts by setting current to be node, which is the first element in the array.
        ///It then goes through each of its children and checks if they are null or not.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node minValueNode(Node node)
        {
            Node current = node;

            while (current.left != null)
                current = current.left;

            return current;
        }
        /// <summary>
        /// The code starts by checking if the node is null.
        ///If it is not, then it prints out the ID of the node and then calls PreOrder on its left and right children.
        /// </summary>
        /// <param name="node"></param>
        public void PreOrder(Node node)
        {
            if (node != null)
            {
                Console.Write(node.ID + " ");
                PreOrder(node.left);
                PreOrder(node.right);
            }
        }
        /// <summary>
        /// The code is trying to find the node with ID=ID.
        ///If it is null or if its ID equals the ID, then return root.
        ///Otherwise, search for the node on the left of root and on the right of root.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Node Search(Node root, int ID)
        {
            if (root == null || root.ID == ID)
                return root;

            if (root.ID < ID)
                return Search(root.right, ID);

            return Search(root.left, ID);
        }
        /// <summary>
        /// The code is trying to delete a node from the tree.
        ///The code first checks if the node is already in the tree, and if it isn't then it creates a new node with ID=ID and inserts that into the tree.
 ///Then it returns 1 because now there is one less node in the tree than before.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int delete(int ID)
        {
            if (Search(root, ID) == null)
                return 0;
            else
            {
                root = Delete(root, ID);
                return 1;
            }
        }
        /// <summary>
        /// The code is searching for the ID in a tree.
        ///If it is not found, then it returns 0.
 ///Otherwise, if the ID is found, then it returns 1.
 ///The code starts by checking to see if there is an object with the name "Search" that has been created on the root of this tree(the first node).
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int search(int ID)
        {
            if (Search(root, ID) == null)
                return 0;
            else
                return 1;
        }
        /// <summary>
        /// The code is trying to insert a new node into the tree.
        ///The code is not implemented, so it throws an exception.
        ///The code will throw a NotImplementedException because the insert method is not implemented.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int insert(int ID, string data)
        {
            root = Insert(root, ID, data);
            return 0;
        }

        public void preOrder(Node root)
        {
            throw new NotImplementedException();
        }
    }
}