namespace WinFormClient
{
    partial class ChatForm
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
            this.address = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.TextBox();
            this.messagesList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(103, 52);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(166, 20);
            this.address.TabIndex = 0;
            this.address.Text = "https://localhost:44317/chatHub";
            this.address.Enter += new System.EventHandler(this.address_Enter);
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(103, 105);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 23);
            this.connect.TabIndex = 1;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // disconnect
            // 
            this.disconnect.Location = new System.Drawing.Point(33, 245);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(75, 23);
            this.disconnect.TabIndex = 2;
            this.disconnect.Text = "Disconnect";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(103, 153);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(166, 20);
            this.message.TabIndex = 3;
            this.message.Enter += new System.EventHandler(this.message_Enter);
            // 
            // messagesList
            // 
            this.messagesList.FormattingEnabled = true;
            this.messagesList.Location = new System.Drawing.Point(12, 327);
            this.messagesList.Name = "messagesList";
            this.messagesList.Size = new System.Drawing.Size(389, 173);
            this.messagesList.TabIndex = 4;
            this.messagesList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.messagesList_DrawItem);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Address :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Message :";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(103, 197);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 7;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(144, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(197, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(33, 298);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "choose file";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "File name :";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(197, 97);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 38);
            this.button4.TabIndex = 12;
            this.button4.Text = "infos wasapi";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(518, 48);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(116, 38);
            this.button5.TabIndex = 13;
            this.button5.Text = "Connect Websockets";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(650, 48);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(108, 38);
            this.button6.TabIndex = 14;
            this.button6.Text = "Disconnect Websockets";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(518, 105);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(240, 20);
            this.textBox1.TabIndex = 15;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(518, 153);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(116, 38);
            this.button7.TabIndex = 16;
            this.button7.Text = "Send Message Websockets";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(518, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Status :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(567, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 18;
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 556);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messagesList);
            this.Controls.Add(this.message);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.address);
            this.Name = "ChatForm";
            this.Text = "ChatForm";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.ListBox messagesList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}