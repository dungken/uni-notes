namespace Source.Views.Custommer
{
    partial class Support
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
            txtUserInput = new TextBox();
            btnSend = new MyCustomControl.RJButton();
            listViewChat = new ListView();
            SuspendLayout();
            // 
            // txtUserInput
            // 
            txtUserInput.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUserInput.Location = new Point(87, 483);
            txtUserInput.Name = "txtUserInput";
            txtUserInput.Size = new Size(778, 30);
            txtUserInput.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.CornflowerBlue;
            btnSend.BackgroundColor = Color.CornflowerBlue;
            btnSend.BorderColor = Color.PaleVioletRed;
            btnSend.BorderRadius = 20;
            btnSend.BorderSize = 0;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.ForeColor = Color.Transparent;
            btnSend.Location = new Point(871, 479);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(70, 34);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.TextColor = Color.Transparent;
            btnSend.UseVisualStyleBackColor = false;
            // 
            // listViewChat
            // 
            listViewChat.Location = new Point(87, 56);
            listViewChat.Name = "listViewChat";
            listViewChat.Size = new Size(778, 398);
            listViewChat.TabIndex = 2;
            listViewChat.UseCompatibleStateImageBehavior = false;
            listViewChat.View = View.SmallIcon;
            // 
            // Support
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 538);
            Controls.Add(listViewChat);
            Controls.Add(btnSend);
            Controls.Add(txtUserInput);
            Name = "Support";
            Text = "Support";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUserInput;
        private MyCustomControl.RJButton btnSend;
        private ListView listViewChat;
    }
}