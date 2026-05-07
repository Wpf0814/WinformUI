namespace WinFormUI
{
    partial class DataGridView_ComboBox
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
            button1 = new Button();
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(252, 452);
            button1.Name = "button1";
            button1.Size = new Size(178, 66);
            button1.TabIndex = 33;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeight = 34;
            dataGridView1.Location = new Point(157, 122);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 32;
            dataGridView1.Size = new Size(459, 275);
            dataGridView1.TabIndex = 32;
            // 
            // comboBox1
            // 
            comboBox1.DisplayMember = "A661_TRUE";
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "A661_True", "A661_False" });
            comboBox1.Location = new Point(283, 51);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(333, 32);
            comboBox1.TabIndex = 31;
            comboBox1.Text = "A661_True";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Location = new Point(160, 53);
            label7.Name = "label7";
            label7.Size = new Size(68, 24);
            label7.TabIndex = 30;
            label7.Text = "Enable";
            // 
            // DataGridView_ComboBox
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 576);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Controls.Add(label7);
            Name = "DataGridView_ComboBox";
            Text = "数据绑定";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Label label7;
    }
}
