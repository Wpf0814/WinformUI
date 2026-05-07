namespace WinFormUI
{
    partial class ChildrenForm
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
            GetParentInfo = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // GetParentInfo
            // 
            GetParentInfo.AutoSize = true;
            GetParentInfo.Location = new Point(65, 175);
            GetParentInfo.Name = "GetParentInfo";
            GetParentInfo.Size = new Size(63, 24);
            GetParentInfo.TabIndex = 3;
            GetParentInfo.Text = "label1";
            // 
            // button1
            // 
            button1.Location = new Point(65, 81);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 2;
            button1.Text = "返回给父窗体";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ChildRenForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(657, 339);
            Controls.Add(GetParentInfo);
            Controls.Add(button1);
            Name = "ChildRenForm";
            Text = "子窗体";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label GetParentInfo;
        private Button button1;
    }
}