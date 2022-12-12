using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce205_hw3_gui
{
    public class RedBlackTree
    {
        public NodeAVL root;
        public List<line> garis = new List<line>();
        public List<LingkaranRB> lingkaran = new List<LingkaranRB>();


        int ctrGaris = 1;
        int ctrLingkaran = 1;
        Form1 parent;
        public RedBlackTree(Form1 parent)
        {
            root = null;
            this.parent = parent;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void insertion(ref NodeAVL root, string key, int x, int y)
        {
            NodeAVL newnode = new NodeAVL(key);
            if (root == null)
            {
                root = newnode;
                root.x = x;
                root.y = y;
                root.color = Color.Black;
                parent.pictureBox2.Invalidate();
            }
            else
            {
                NodeAVL current = root;
                while (true)
                {
                    if (string.Compare(key, current.value) < 0)
                    {
                        if (current.left == null)
                        {
                            current.left = newnode;
                            newnode.parent = current;
                            retraceafterinsertion(ref root, newnode);
                            break;
                        }
                        current = current.left;
                    }
                    else
                    {
                        if (current.right == null)
                        {
                            current.right = newnode;
                            newnode.parent = current;
                            retraceafterinsertion(ref root, newnode);
                            break;
                        }
                        current = current.right;
                    }
                }
            }
            resetheight(ref root);
            lingkaran.Clear();
            updatelingkaran(ref root);
            garis.Clear();
            addgaris(ref root);
            parent.pictureBox2.Invalidate();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int min(int a, int b)
        {
            return (a < b) ? a : b;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void swapcolor(NodeAVL p, NodeAVL q)
        {
            if (p.color != q.color)
            {
                Color temp = p.color;
                p.color = q.color;
                q.color = temp;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public NodeAVL singleLeftRotate(ref NodeAVL root, NodeAVL p)
        {
            if (p.right != null)
            {
                NodeAVL q = p.right;
                p.right = q.left;
                if (q.left != null)
                {
                    q.left.parent = p;
                }
                q.left = p;
                replacenodeinparent(ref root, p, q);
                p.parent = q;
                swapcolor(p, q);
                return q;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public NodeAVL singleRightRotate(ref NodeAVL root, NodeAVL q)
        {
            if (q.left != null)
            {
                NodeAVL p = q.left;
                q.left = p.right;
                if (p.right != null)
                {
                    p.right.parent = q;
                }
                p.right = q;
                replacenodeinparent(ref root, q, p);
                q.parent = p;
                swapcolor(p, q);
                return q;
            }
            else
            {
                return null;
            }
        }
        public Color color(NodeAVL n)
        {
            if (n == null)
            {
                return Color.Black;
            }
            else
            {
                return n.color;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="current"></param>
        public void retraceafterinsertion(ref NodeAVL root, NodeAVL current)
        {
            garis.Clear();
            addgaris(ref root);
            while (true)
            {
                if (current == root)
                {
                    current.color = Color.Black;
                    break;
                }
                if (current.parent.color == Color.Red)
                {
                    NodeAVL p = current.parent;
                    NodeAVL g = p.parent;
                    NodeAVL u = p == g.left ? g.right : g.left;
                    if (color(u) == Color.Red)
                    {
                        p.color = Color.Black;
                        u.color = Color.Black;
                        g.color = Color.Red;
                        current = g;
                    }
                    else
                    {
                        rotate(ref root, current, p, g);
                        break;
                    }
                }
                else break;
            }
            lingkaran.Clear();
            updatelingkaran(ref root);
            parent.pictureBox2.Invalidate();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="r"></param>
        /// <param name="p"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        public NodeAVL rotate(ref NodeAVL root, NodeAVL r, NodeAVL p, NodeAVL g)
        {
            if (p == g.left && (r == null || r == p.left))
            {
                singleRightRotate(ref root, g);
                return r;
            }
            else if (p == g.left && r == p.right)
            {
                singleLeftRotate(ref root, g.left);
                singleRightRotate(ref root, g);
                return p;
            }
            else if (p == g.right && (r == p.right || r == null))
            {
                singleLeftRotate(ref root, g);
                return r;
            }
            else if (p == g.right && r == p.left)
            {
                singleRightRotate(ref root, g.right);
                singleLeftRotate(ref root, g);
                return p;
            }
            return null;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="q"></param>
        public void doubleLeftRotate(ref NodeAVL root, NodeAVL q)
        {
            singleRightRotate(ref root, q.right);
            singleLeftRotate(ref root, q);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="q"></param>
        public void doubleRightRotate(ref NodeAVL root, NodeAVL q)
        {
            singleLeftRotate(ref root, q.left);
            singleRightRotate(ref root, q);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        public void resetheight(ref NodeAVL root)
        {
            if (root != null)
            {
                resetheight(ref root.left);
                root.height = 1;
                resetheight(ref root.right);
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        public void addlingkaran(ref NodeAVL root)
        {
            if (root.parent != null)
            {
                if (!root.isRight)
                {
                    root.x = root.parent.x - 300 / root.height;
                    root.y = root.parent.y + 50;
                }
                else
                {
                    root.x = root.parent.x + 300 / root.height;
                    root.y = root.parent.y + 50;
                }
            }
            if (this.root == root)
            {
                this.root.x = root.x;
                this.root.y = root.y;
            }
            if (root.passed)
            {
                lingkaran.Add(new LingkaranRB(root.x, root.y, root.value.ToString(), Color.Yellow));
            }
            else
            {
                lingkaran.Add(new LingkaranRB(root.x, root.y, root.value.ToString(), root.color));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        public void updatelingkaran(ref NodeAVL root)
        {
            if (root != null)
            {
                Console.WriteLine(root.value + "_" + root.height);
                if (root.left != null)
                {
                    root.left.parent = root;
                    root.left.isRight = false;
                    root.left.height = (root.height + 1);
                }
                updatelingkaran(ref root.left);
                addlingkaran(ref root);
                if (root.right != null)
                {
                    root.right.parent = root;
                    root.right.isRight = true;
                    root.right.height = (root.height + 1);
                }
                updatelingkaran(ref root.right);
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        public void addgaris(ref NodeAVL root)
        {

            if (root != null)
            {
                if (root.left != null)
                {
                    if (root.left.passed && root.passed)
                    {
                        garis.Add(new line(root.x + 15, root.y + 15, root.left.x + 15, root.left.y + 15, Color.Yellow));
                    }
                    else
                    {
                        garis.Add(new line(root.x + 15, root.y + 15, root.left.x + 15, root.left.y + 15, Color.Black));
                    }
                }
                addgaris(ref root.left);
                if (root.right != null)
                {
                    if (root.right.passed && root.passed)
                    {
                        garis.Add(new line(root.x + 15, root.y + 15, root.right.x + 15, root.right.y + 15, Color.Yellow));
                    }
                    else
                    {
                        garis.Add(new line(root.x + 15, root.y + 15, root.right.x + 15, root.right.y + 15, Color.Black));
                    }
                }
                addgaris(ref root.right);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Color nodecolor(NodeAVL node)
        {
            return node.color == Color.Black ? Color.Black : node.color;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="node"></param>
        /// <param name="child"></param>
        public void replacenodeinparent(ref NodeAVL root, NodeAVL node, NodeAVL child)
        {
            if (node.parent == null)
            {
                root = child;
            }
            else if (node.parent.left == node)
            {
                node.parent.left = child;
            }
            else
            {
                node.parent.right = child;
            }
            if (child != null)
            {
                child.parent = node.parent;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public NodeAVL find(NodeAVL root, string value)
        {
            NodeAVL current = root;
            while (current != null && value != current.value)
            {
                if (string.Compare(value, current.value) < 0)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }
            return current;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        public void delete(ref NodeAVL root, string value)
        {
            NodeAVL current = find(root, value);
            if (current != null)
            {
                if (current.left == null || current.right == null)
                {
                    replaceNodeInParentAndBalancing(ref root, current, current.left == null ? current.right : current.left);
                }
                else
                {
                    NodeAVL predecessor = current.left;
                    while (predecessor.right != null)
                    {
                        predecessor = predecessor.right;
                    }
                    current.value = predecessor.value;
                    replaceNodeInParentAndBalancing(ref root, predecessor, predecessor.left);
                }
                garis.Clear();
                addgaris(ref root);
                lingkaran.Clear();
                updatelingkaran(ref root);
                parent.pictureBox2.Invalidate();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        public void search(ref NodeAVL root, string value)
        {
            searching(ref root, value);
            lingkaran.Clear();
            updatelingkaran(ref root);
            garis.Clear();
            addgaris(ref root);
            parent.pictureBox2.Invalidate();
            resetsearch(ref root, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public NodeAVL searching(ref NodeAVL root, string value)
        {
            NodeAVL current = root;
            while (current != null && value != current.value)
            {
                if (string.Compare(value, current.value) < 0)
                {
                    current.passed = true;
                    current = current.left;
                }
                else
                {
                    current.passed = true;
                    current = current.right;
                }
            }
            current.passed = true;
            return current;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        public void resetsearch(ref NodeAVL root, string value)
        {
            NodeAVL current = root;
            while (current != null && value != current.value)
            {
                if (string.Compare(value, current.value) < 0)
                {
                    current.passed = false;
                    current = current.left;
                }
                else
                {
                    current.passed = false;
                    current = current.right;
                }
            }
            current.passed = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="node"></param>
        /// <param name="child"></param>
        public void replaceNodeInParentAndBalancing(ref NodeAVL root, NodeAVL node, NodeAVL child)
        {
            if (node.color == Color.Red || color(child) == Color.Red)
            {
                if (child != null)
                {
                    child.color = Color.Black;
                }
            }
            else if (node.color == Color.Black && color(child) == Color.Black)
            {
                if (child == null)
                {
                    child = new NodeAVL();
                }
                else
                {
                    child.color = Color.Gray;
                }
            }
            replacenodeinparent(ref root, node, child);
            if (child != null)
            {
                retraceafterdeletion(ref root, child);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="node"></param>
        public void decreaseColor(ref NodeAVL root, NodeAVL node)
        {
            if (node.color == Color.Gray)
            {
                if (node.sentinel)
                {
                    if (node.parent == null) root = null;
                    else if (node.parent.left == node) node.parent.left = null;
                    else node.parent.right = null;
                }
                else node.color = Color.Black;
            }
            else if (node.color == Color.Black) node.color = Color.Red;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="node"></param>
        public void increaseColor(ref NodeAVL root, NodeAVL node)
        {
            if (node.color == Color.Red) node.color = Color.Black;
            else if (node.color == Color.Black) node.color = Color.Gray;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="u"></param>
        public void retraceafterdeletion(ref NodeAVL root, NodeAVL u)
        {
            while (u.color == Color.Gray)
            {
                if (u == root)
                {
                    decreaseColor(ref root, u);
                    break;
                }
                NodeAVL p = u.parent;
                NodeAVL s;
                if (u == p.left)
                {
                    s = p.right;
                }
                else
                {
                    s = p.left;
                }
                if (color(s) == Color.Red)
                {
                    rotate(ref root, null, s, p);
                }
                else
                {
                    NodeAVL r = null;
                    if (s == p.left)
                    {
                        if (color(s.left) == Color.Red) r = s.left;
                        else if (color(s.right) == Color.Red) r = s.right;
                    }
                    else
                    {
                        if (color(s.right) == Color.Red) r = s.right;
                        else if (color(s.left) == Color.Red) r = s.left;
                    }
                    if (r != null)
                    {
                        r = rotate(ref root, r, s, p);
                        increaseColor(ref root, r);
                        decreaseColor(ref root, u);
                        break;
                    }
                    else
                    {
                        decreaseColor(ref root, u);
                        decreaseColor(ref root, s);
                        increaseColor(ref root, p);
                        u = p;
                    }
                }
            }
        }
    }
}
