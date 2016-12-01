namespace SimpleCommunicator {
    partial class ComWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.textToSend = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textReceived = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textToSend
            // 
            this.textToSend.Location = new System.Drawing.Point(21, 264);
            this.textToSend.Name = "textToSend";
            this.textToSend.Size = new System.Drawing.Size(426, 20);
            this.textToSend.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(466, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.DragDrop += new System.Windows.Forms.DragEventHandler(this.mydrag);
            // 
            // textReceived
            // 
            this.textReceived.Location = new System.Drawing.Point(21, 12);
            this.textReceived.Name = "textReceived";
            this.textReceived.Size = new System.Drawing.Size(426, 230);
            this.textReceived.TabIndex = 2;
            this.textReceived.Text = "";
            // 
            // ComWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 310);
            this.Controls.Add(this.textReceived);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textToSend);
            this.Name = "ComWindow";
            this.Text = "ComWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.TextBox textToSend;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox textReceived;
        }
    }