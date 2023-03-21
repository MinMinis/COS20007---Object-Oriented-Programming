namespace FormApp
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
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Label");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Button");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Checkbox");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstCity = new System.Windows.Forms.ListBox();
            this.rdMale = new System.Windows.Forms.RadioButton();
            this.rdFemale = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkC = new System.Windows.Forms.CheckBox();
            this.chkasp = new System.Windows.Forms.CheckBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hello World";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(144, 111);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(219, 94);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Details";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 17);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 23);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(77, 52);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(110, 23);
            this.textBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lstCity
            // 
            this.lstCity.FormattingEnabled = true;
            this.lstCity.ItemHeight = 15;
            this.lstCity.Items.AddRange(new object[] {
            "Mumbai",
            "Bangalore",
            "Hyderabad"});
            this.lstCity.Location = new System.Drawing.Point(144, 226);
            this.lstCity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstCity.Name = "lstCity";
            this.lstCity.Size = new System.Drawing.Size(132, 79);
            this.lstCity.TabIndex = 2;
            this.lstCity.SelectedIndexChanged += new System.EventHandler(this.lstCity_SelectedIndexChanged);
            // 
            // rdMale
            // 
            this.rdMale.AutoSize = true;
            this.rdMale.Location = new System.Drawing.Point(430, 131);
            this.rdMale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdMale.Name = "rdMale";
            this.rdMale.Size = new System.Drawing.Size(51, 19);
            this.rdMale.TabIndex = 4;
            this.rdMale.TabStop = true;
            this.rdMale.Text = "Male";
            this.rdMale.UseVisualStyleBackColor = true;
            this.rdMale.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // rdFemale
            // 
            this.rdFemale.AutoSize = true;
            this.rdFemale.Location = new System.Drawing.Point(430, 154);
            this.rdFemale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdFemale.Name = "rdFemale";
            this.rdFemale.Size = new System.Drawing.Size(63, 19);
            this.rdFemale.TabIndex = 5;
            this.rdFemale.TabStop = true;
            this.rdFemale.Text = "Female";
            this.rdFemale.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(0, 0);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(83, 19);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chkC
            // 
            this.chkC.AutoSize = true;
            this.chkC.Location = new System.Drawing.Point(430, 201);
            this.chkC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkC.Name = "chkC";
            this.chkC.Size = new System.Drawing.Size(41, 19);
            this.chkC.TabIndex = 7;
            this.chkC.Text = "C#";
            this.chkC.UseVisualStyleBackColor = true;
            // 
            // chkasp
            // 
            this.chkasp.AutoSize = true;
            this.chkasp.Location = new System.Drawing.Point(430, 224);
            this.chkasp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkasp.Name = "chkasp";
            this.chkasp.Size = new System.Drawing.Size(47, 19);
            this.chkasp.TabIndex = 8;
            this.chkasp.Text = "ASP";
            this.chkasp.UseVisualStyleBackColor = true;
            this.chkasp.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(300, 319);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(82, 22);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(144, 319);
            this.treeView1.Name = "treeView1";
            treeNode5.Name = "Node1";
            treeNode5.Text = "Label";
            treeNode6.Name = "Node2";
            treeNode6.Text = "Button";
            treeNode7.Name = "Node3";
            treeNode7.Text = "Checkbox";
            treeNode8.Name = "Node0";
            treeNode8.Text = "Node";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(121, 97);
            this.treeView1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(89, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 622);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.chkasp);
            this.Controls.Add(this.chkC);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.rdFemale);
            this.Controls.Add(this.rdMale);
            this.Controls.Add(this.lstCity);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Label label2;
        private ListBox lstCity;
        private RadioButton rdMale;
        private RadioButton rdFemale;
        private CheckBox checkBox1;
        private CheckBox chkC;
        private CheckBox chkasp;
        private Button btnSubmit;
        private TreeView treeView1;
        private PictureBox pictureBox1;
    }
}