namespace ce205_hw3_gui
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Status = new System.Windows.Forms.Label();
            this.valueBox = new System.Windows.Forms.TextBox();
            this.Random = new System.Windows.Forms.Button();
            this.İnorder = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.İnsert = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RandomRB = new System.Windows.Forms.Button();
            this.FindRB = new System.Windows.Forms.Button();
            this.deleteBtnRB = new System.Windows.Forms.Button();
            this.InsertBtnRB = new System.Windows.Forms.Button();
            this.valueBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 1);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1779, 786);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Salmon;
            this.tabPage1.Controls.Add(this.Status);
            this.tabPage1.Controls.Add(this.valueBox);
            this.tabPage1.Controls.Add(this.Random);
            this.tabPage1.Controls.Add(this.İnorder);
            this.tabPage1.Controls.Add(this.Search);
            this.tabPage1.Controls.Add(this.Delete);
            this.tabPage1.Controls.Add(this.İnsert);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1771, 757);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "AVLTree";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(801, 699);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(44, 16);
            this.Status.TabIndex = 7;
            this.Status.Text = "Status";
            this.Status.Click += new System.EventHandler(this.label1_Click);
            // 
            // valueBox
            // 
            this.valueBox.Location = new System.Drawing.Point(226, 47);
            this.valueBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.valueBox.Name = "valueBox";
            this.valueBox.Size = new System.Drawing.Size(166, 22);
            this.valueBox.TabIndex = 6;
            this.valueBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Random
            // 
            this.Random.Location = new System.Drawing.Point(1022, 39);
            this.Random.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Random.Name = "Random";
            this.Random.Size = new System.Drawing.Size(120, 39);
            this.Random.TabIndex = 5;
            this.Random.Text = "Random";
            this.Random.UseVisualStyleBackColor = true;
            this.Random.Click += new System.EventHandler(this.Random_Click);
            // 
            // İnorder
            // 
            this.İnorder.Location = new System.Drawing.Point(870, 38);
            this.İnorder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.İnorder.Name = "İnorder";
            this.İnorder.Size = new System.Drawing.Size(116, 40);
            this.İnorder.TabIndex = 4;
            this.İnorder.Text = "İnorder";
            this.İnorder.UseVisualStyleBackColor = true;
            this.İnorder.Click += new System.EventHandler(this.İnorder_Click);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(718, 38);
            this.Search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(127, 40);
            this.Search.TabIndex = 3;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(577, 39);
            this.Delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(115, 39);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.button2_Click);
            // 
            // İnsert
            // 
            this.İnsert.Location = new System.Drawing.Point(418, 39);
            this.İnsert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.İnsert.Name = "İnsert";
            this.İnsert.Size = new System.Drawing.Size(128, 39);
            this.İnsert.TabIndex = 1;
            this.İnsert.Text = "İnsert";
            this.İnsert.UseVisualStyleBackColor = true;
            this.İnsert.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 94);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1763, 656);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tabPage2.Controls.Add(this.RandomRB);
            this.tabPage2.Controls.Add(this.FindRB);
            this.tabPage2.Controls.Add(this.deleteBtnRB);
            this.tabPage2.Controls.Add(this.InsertBtnRB);
            this.tabPage2.Controls.Add(this.valueBox1);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1771, 757);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "RedBlackTree";
            // 
            // RandomRB
            // 
            this.RandomRB.Location = new System.Drawing.Point(1167, 30);
            this.RandomRB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RandomRB.Name = "RandomRB";
            this.RandomRB.Size = new System.Drawing.Size(136, 41);
            this.RandomRB.TabIndex = 5;
            this.RandomRB.Text = "Random";
            this.RandomRB.UseVisualStyleBackColor = true;
            this.RandomRB.Click += new System.EventHandler(this.RandomRB_Click);
            // 
            // FindRB
            // 
            this.FindRB.Location = new System.Drawing.Point(1001, 30);
            this.FindRB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FindRB.Name = "FindRB";
            this.FindRB.Size = new System.Drawing.Size(136, 41);
            this.FindRB.TabIndex = 4;
            this.FindRB.Text = "Search";
            this.FindRB.UseVisualStyleBackColor = true;
            this.FindRB.Click += new System.EventHandler(this.FindRB_Click);
            // 
            // deleteBtnRB
            // 
            this.deleteBtnRB.Location = new System.Drawing.Point(840, 30);
            this.deleteBtnRB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteBtnRB.Name = "deleteBtnRB";
            this.deleteBtnRB.Size = new System.Drawing.Size(136, 41);
            this.deleteBtnRB.TabIndex = 3;
            this.deleteBtnRB.Text = "Delete";
            this.deleteBtnRB.UseVisualStyleBackColor = true;
            this.deleteBtnRB.Click += new System.EventHandler(this.deleteBtnRB_Click);
            // 
            // InsertBtnRB
            // 
            this.InsertBtnRB.Location = new System.Drawing.Point(679, 30);
            this.InsertBtnRB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.InsertBtnRB.Name = "InsertBtnRB";
            this.InsertBtnRB.Size = new System.Drawing.Size(136, 41);
            this.InsertBtnRB.TabIndex = 2;
            this.InsertBtnRB.Text = "Insert";
            this.InsertBtnRB.UseVisualStyleBackColor = true;
            this.InsertBtnRB.Click += new System.EventHandler(this.InsertBtnRB_Click);
            // 
            // valueBox1
            // 
            this.valueBox1.Location = new System.Drawing.Point(407, 30);
            this.valueBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.valueBox1.Name = "valueBox1";
            this.valueBox1.Size = new System.Drawing.Size(220, 22);
            this.valueBox1.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pictureBox2.Location = new System.Drawing.Point(5, 91);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1768, 668);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1783, 788);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.Label Status;
        public System.Windows.Forms.TextBox valueBox;
        public System.Windows.Forms.Button Random;
        public System.Windows.Forms.Button İnorder;
        public System.Windows.Forms.Button Search;
        public System.Windows.Forms.Button Delete;
        public System.Windows.Forms.Button İnsert;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Button RandomRB;
        public System.Windows.Forms.Button FindRB;
        public System.Windows.Forms.Button deleteBtnRB;
        public System.Windows.Forms.Button InsertBtnRB;
        public System.Windows.Forms.TextBox valueBox1;
        public System.Windows.Forms.PictureBox pictureBox2;
    }
}

