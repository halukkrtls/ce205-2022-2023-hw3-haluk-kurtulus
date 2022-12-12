using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ce205_hw3_gui
{
    public partial class Form1 : Form

    {
        AVLTree tree;
        RedBlackTree rbt;
        Brush temp;
        public Form1()
        {
            InitializeComponent();
            this.Text = "AVL Visualization";
            tree = new AVLTree(this);
            ///* Constructing tree given in the above figure */
            //tree.root = tree.InsertHelper(tree.root, 9);
            //tree.root = tree.InsertHelper(tree.root, 5);
            //tree.root = tree.InsertHelper(tree.root, 10);
            //tree.root = tree.InsertHelper(tree.root, 0);
            //tree.root = tree.InsertHelper(tree.root, 6);
            //tree.root = tree.InsertHelper(tree.root, 11);
            //tree.root = tree.InsertHelper(tree.root, -1);
            //tree.root = tree.InsertHelper(tree.root, 1);
            tree.preOrder(tree.root);
            foreach (var item in tree.lingkaran)
            {
                Console.WriteLine("X : " + item.Value.x + " Y: " + item.Value.y);

            }
            this.WindowState = FormWindowState.Maximized;
            rbt = new RedBlackTree(this);
            temp = new SolidBrush(Color.White);
            pictureBox1.Width = this.Width;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tree.root = tree.InsertHelper(tree.root, Convert.ToString(valueBox.Text));
            tree.inOrderHelper();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tree.root = tree.deleteNode(tree.root, Convert.ToString(valueBox.Text));
            tree.inOrderHelper();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            tree.find(Convert.ToString(valueBox.Text));
        }

        private void İnorder_Click(object sender, EventArgs e)
        {
            tree.inOrder(tree.root);
            MessageBox.Show("InOrder : " + tree.inOrderResult);
            tree.inOrderResult = "";
            tree.inOrderHelper();
        }

        private void Random_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            int rand_num = rd.Next(0, 200);
            string keys = "Lorem Ipsum simply dummy text printing typesetting industry. Lorem Ipsum been industry's standard dummy text ever since 1500s, when unknown printer took galley type scrambled make type specimen book. survived only five centuries, also leap into electronic typesetting, remaining essentially unchanged. popularised 1960s with release Letraset sheets containing Lorem Ipsum passages, more recently with desktop publishing software like Aldus PageMaker including versions Lorem Ipsum." +
                "long established fact that reader will distracted readable content page when looking layout. point using Lorem Ipsum that normal distribution letters, opposed using 'Content here, content here', making look like readable English. Many desktop publishing packages page editors Lorem Ipsum their default model text, search 'lorem ipsum' will uncover many sites still their infancy. Various versions have evolved over years, sometimes accident, sometimes purpose (injected humour and the like)." +
                "Contrary popular belief, Lorem Ipsum simply random text. roots piece classical Latin literature from, making over years. Richard McClintock, Latin professor Hampden-Sydney College Virginia, looked more obscure Latin words, consectetur, from Lorem Ipsum passage, going through cites word classical literature, discovered undoubtable source. Lorem Ipsum comes from sections Finibus Bonorum Malorum (The Extremes Good Evil) Cicero, written This book treatise theory ethics, very popular during Renaissance. first line Lorem Ipsum," +
                "There many variations passages Lorem Ipsum available, majority have suffered alteration " +
                "some form, injected humour, randomised words which don't look even slightly believable. " +
                "going passage Lorem Ipsum, need sure there isn't anything embarrassing hidden " +
                "middle text. Lorem Ipsum generators Internet tend repeat predefined chunks " +
                "necessary, making this first true generator Internet. uses dictionary over 200 Latin words," +
                " combined with handful model sentence structures, generate Lorem Ipsum which looks reasonable. " +
                " generated Lorem Ipsum therefore always free from repetition, injected humour, non-characteristic words.";

            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string[] arrkeys = keys.Split(delimiterChars);

            valueBox.Text = arrkeys[rand_num];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Status.Text = "";
            timer1.Stop();
        }
        public void mbox(String text)
        {
            MessageBox.Show(text);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in tree.garis.Values)
            {
                e.Graphics.DrawLine(new Pen(Color.Black), item.x1, item.y1, item.x2, item.y2);
            }
            foreach (var item in tree.lingkaran.Values)
            {
                e.Graphics.FillEllipse(item.brush, item.x, item.y, 50, 50);
                e.Graphics.DrawString(item.value, new Font("Arial", 16), new SolidBrush(Color.White), new Point(item.x + 8, item.y + 10));
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            foreach (line x in rbt.garis)
            {
                Pen p = new Pen(x.warna);
                e.Graphics.DrawLine(p, x.x1, x.y1, x.x2, x.y2);
            }
            foreach (var item in rbt.lingkaran)
            {
                e.Graphics.FillEllipse(item.brush, item.x, item.y, 30, 30);
                e.Graphics.DrawString(item.value, new Font("Arial", 14), temp, new Point(item.x, item.y + 5));
            }
        }

        private void InsertBtnRB_Click(object sender, EventArgs e)
        {
            rbt.insertion(ref rbt.root, Convert.ToString(valueBox1.Text.ToString()), this.Width / 2, 50);
            valueBox.Text = "";
        }

        private void deleteBtnRB_Click(object sender, EventArgs e)
        {
            rbt.delete(ref rbt.root, Convert.ToString(valueBox1.Text.ToString()));
        }

        private void FindRB_Click(object sender, EventArgs e)
        {
            rbt.search(ref rbt.root, Convert.ToString(valueBox1.Text.ToString()));

        }

        private void RandomRB_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            int rand_num = rd.Next(0, 200);
            string keys = "Lorem Ipsum simply dummy text printing typesetting industry. Lorem Ipsum been industry's standard dummy text ever since 1500s, when unknown printer took galley type scrambled make type specimen book. survived only five centuries, also leap into electronic typesetting, remaining essentially unchanged. popularised 1960s with release Letraset sheets containing Lorem Ipsum passages, more recently with desktop publishing software like Aldus PageMaker including versions Lorem Ipsum." +
                "long established fact that reader will distracted readable content page when looking layout. point using Lorem Ipsum that normal distribution letters, opposed using 'Content here, content here', making look like readable English. Many desktop publishing packages page editors Lorem Ipsum their default model text, search 'lorem ipsum' will uncover many sites still their infancy. Various versions have evolved over years, sometimes accident, sometimes purpose (injected humour and the like)." +
                "Contrary popular belief, Lorem Ipsum simply random text. roots piece classical Latin literature from, making over years. Richard McClintock, Latin professor Hampden-Sydney College Virginia, looked more obscure Latin words, consectetur, from Lorem Ipsum passage, going through cites word classical literature, discovered undoubtable source. Lorem Ipsum comes from sections Finibus Bonorum Malorum (The Extremes Good Evil) Cicero, written This book treatise theory ethics, very popular during Renaissance. first line Lorem Ipsum," +
                "There many variations passages Lorem Ipsum available, majority have suffered alteration " +
                "some form, injected humour, randomised words which don't look even slightly believable. " +
                "going passage Lorem Ipsum, need sure there isn't anything embarrassing hidden " +
                "middle text. Lorem Ipsum generators Internet tend repeat predefined chunks " +
                "necessary, making this first true generator Internet. uses dictionary over 200 Latin words," +
                " combined with handful model sentence structures, generate Lorem Ipsum which looks reasonable. " +
                " generated Lorem Ipsum therefore always free from repetition, injected humour, non-characteristic words.";

            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string[] arrkeys = keys.Split(delimiterChars);

            valueBox1.Text = arrkeys[rand_num];
        }
    }
}
