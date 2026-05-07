namespace WinFormUI
{
    partial class CrossThreadUI
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
            label1 = new Label();
            buttonAsyncAwait = new Button();
            buttonInvoke = new Button();
            dataGridView1 = new DataGridView();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Location = new Point(168, 574);
            label1.Name = "label1";
            label1.Size = new Size(57, 24);
            label1.TabIndex = 37;
            label1.Text = "信息2";
            // 
            // buttonAsyncAwait
            // 
            buttonAsyncAwait.Location = new Point(428, 365);
            buttonAsyncAwait.Name = "buttonAsyncAwait";
            buttonAsyncAwait.Size = new Size(205, 66);
            buttonAsyncAwait.TabIndex = 36;
            buttonAsyncAwait.Text = "async/await更新UI";
            buttonAsyncAwait.UseVisualStyleBackColor = true;
            buttonAsyncAwait.Click += buttonAsyncAwait_Click;
            // 
            // buttonInvoke
            // 
            buttonInvoke.Location = new Point(168, 365);
            buttonInvoke.Name = "buttonInvoke";
            buttonInvoke.Size = new Size(205, 66);
            buttonInvoke.TabIndex = 35;
            buttonInvoke.Text = "Invoke更新UI";
            buttonInvoke.UseVisualStyleBackColor = true;
            buttonInvoke.Click += buttonInvoke_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeight = 34;
            dataGridView1.Location = new Point(168, 43);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 32;
            dataGridView1.Size = new Size(465, 275);
            dataGridView1.TabIndex = 34;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Location = new Point(168, 496);
            label7.Name = "label7";
            label7.Size = new Size(57, 24);
            label7.TabIndex = 33;
            label7.Text = "信息1";
            // 
            // CrossThreadUI
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 641);
            Controls.Add(label1);
            Controls.Add(buttonAsyncAwait);
            Controls.Add(buttonInvoke);
            Controls.Add(dataGridView1);
            Controls.Add(label7);
            Name = "CrossThreadUI";
            Text = "跨线程更新UI";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button buttonAsyncAwait;
        private Button buttonInvoke;
        private DataGridView dataGridView1;
        private Label label7;
    }
}
