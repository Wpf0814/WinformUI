namespace WinFormUI
{
    partial class ParentForm
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
            labelChildMessage = new Label();
            buttonSendToChild = new Button();
            buttonOpenChild = new Button();
            SuspendLayout();
            // 
            // labelChildMessage
            // 
            labelChildMessage.AutoSize = true;
            labelChildMessage.Location = new Point(63, 205);
            labelChildMessage.Name = "labelChildMessage";
            labelChildMessage.Size = new Size(136, 24);
            labelChildMessage.TabIndex = 40;
            labelChildMessage.Text = "等待子窗体回传";
            // 
            // buttonSendToChild
            // 
            buttonSendToChild.Location = new Point(46, 129);
            buttonSendToChild.Name = "buttonSendToChild";
            buttonSendToChild.Size = new Size(180, 40);
            buttonSendToChild.TabIndex = 39;
            buttonSendToChild.Text = "父窗体传给子窗体";
            buttonSendToChild.UseVisualStyleBackColor = true;
            buttonSendToChild.Click += buttonSendToChild_Click;
            // 
            // buttonOpenChild
            // 
            buttonOpenChild.Location = new Point(46, 61);
            buttonOpenChild.Name = "buttonOpenChild";
            buttonOpenChild.Size = new Size(180, 40);
            buttonOpenChild.TabIndex = 38;
            buttonOpenChild.Text = "打开子窗体";
            buttonOpenChild.UseVisualStyleBackColor = true;
            buttonOpenChild.Click += buttonOpenChild_Click;
            // 
            // ParentForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 360);
            Controls.Add(labelChildMessage);
            Controls.Add(buttonSendToChild);
            Controls.Add(buttonOpenChild);
            Name = "ParentForm";
            Text = "父窗体";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelChildMessage;
        private Button buttonSendToChild;
        private Button buttonOpenChild;
    }
}
