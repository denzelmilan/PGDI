namespace WinFormsApp1
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            panel1 = new Panel();
            button1 = new Button();
            passwordbox = new TextBox();
            label3 = new Label();
            userBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.75F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.75F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Controls.Add(panel2, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(799, 424);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(143, 418);
            panel3.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(passwordbox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(userBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(152, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(493, 418);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(199, 301);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            button1.MouseHover += button1_MouseHover;
            button1.MouseMove += button1_MouseMove;
            // 
            // passwordbox
            // 
            passwordbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            passwordbox.ForeColor = SystemColors.InactiveCaption;
            passwordbox.Location = new Point(68, 236);
            passwordbox.Name = "passwordbox";
            passwordbox.Size = new Size(356, 27);
            passwordbox.TabIndex = 4;
            passwordbox.Text = "Password";
            passwordbox.Enter += passwordbox_Enter;
            passwordbox.Leave += passwordbox_Leave;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(68, 202);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 3;
            label3.Text = "Password";
            // 
            // userBox
            // 
            userBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            userBox.ForeColor = SystemColors.InactiveCaption;
            userBox.Location = new Point(68, 158);
            userBox.Name = "userBox";
            userBox.Size = new Size(356, 27);
            userBox.TabIndex = 2;
            userBox.Text = "Username";
            userBox.TextChanged += textBox1_TextChanged;
            userBox.Enter += textBox1_Enter;
            userBox.Leave += textBox1_Leave;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(68, 124);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(217, 52);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 0;
            label1.Text = "ResAPP";
            label1.Click += label1_Click_1;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(651, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(145, 418);
            panel2.TabIndex = 1;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 424);
            Controls.Add(tableLayoutPanel1);
            Name = "LoginForm";
            Text = "pa";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label label1;
        private TextBox userBox;
        private Label label2;
        private Button button1;
        private TextBox passwordbox;
        private Label label3;
        private Panel panel3;
        private Panel panel2;
    }
}