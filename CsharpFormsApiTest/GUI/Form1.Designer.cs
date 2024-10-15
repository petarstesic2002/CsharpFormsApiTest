namespace GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox4 = new TextBox();
            checkedListBox1 = new CheckedListBox();
            label6 = new Label();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(167, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(633, 370);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(17, 388);
            button1.Name = "button1";
            button1.Size = new Size(137, 50);
            button1.TabIndex = 1;
            button1.Text = "Get Products";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(17, 359);
            button2.Name = "button2";
            button2.Size = new Size(46, 23);
            button2.TabIndex = 2;
            button2.Text = "<";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(108, 359);
            button3.Name = "button3";
            button3.Size = new Size(46, 23);
            button3.TabIndex = 3;
            button3.Text = ">";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 341);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 4;
            label1.Text = "Page: 0 / 0";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(17, 227);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(137, 23);
            textBox1.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(17, 271);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(137, 23);
            textBox3.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(17, 315);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(137, 23);
            textBox2.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 208);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 9;
            label2.Text = "Keyword";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(58, 252);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 10;
            label3.Text = "MinPrice";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(58, 297);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 11;
            label4.Text = "MaxPrice";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(76, 165);
            label5.Name = "label5";
            label5.Size = new Size(17, 15);
            label5.TabIndex = 12;
            label5.Text = "Id";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(17, 183);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(137, 23);
            textBox4.TabIndex = 13;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(17, 40);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.ScrollAlwaysVisible = true;
            checkedListBox1.Size = new Size(137, 94);
            checkedListBox1.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(52, 21);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 15;
            label6.Text = "Categories";
            // 
            // button4
            // 
            button4.Location = new Point(320, 388);
            button4.Name = "button4";
            button4.Size = new Size(156, 50);
            button4.TabIndex = 16;
            button4.Text = "Add New Product";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(482, 388);
            button5.Name = "button5";
            button5.Size = new Size(156, 50);
            button5.TabIndex = 17;
            button5.Text = "Update Selected Product";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(644, 388);
            button6.Name = "button6";
            button6.Size = new Size(156, 50);
            button6.TabIndex = 18;
            button6.Text = "Delete Selected Product";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(169, 390);
            label7.Name = "label7";
            label7.Size = new Size(144, 15);
            label7.TabIndex = 19;
            label7.Text = "Per Page: 0, Total Count: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 458);
            Controls.Add(label7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label6);
            Controls.Add(checkedListBox1);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox4;
        private CheckedListBox checkedListBox1;
        private Label label6;
        private Button button4;
        private Button button5;
        private Button button6;
        private Label label7;
    }
}
