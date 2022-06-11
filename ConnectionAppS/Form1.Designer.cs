namespace ConnectionAppS
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenPort = new System.Windows.Forms.Button();
            this.SendFileButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.ChatTextBox = new System.Windows.Forms.TextBox();
            this.ChatRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SendMessengeButon = new System.Windows.Forms.Button();
            this.b_ace = new System.Windows.Forms.Button();
            this.backgroundWorker_Listener = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // OpenPort
            // 
            this.OpenPort.Location = new System.Drawing.Point(21, 12);
            this.OpenPort.Name = "OpenPort";
            this.OpenPort.Size = new System.Drawing.Size(131, 42);
            this.OpenPort.TabIndex = 0;
            this.OpenPort.Text = "Открыть порт";
            this.OpenPort.UseVisualStyleBackColor = true;
            this.OpenPort.Click += new System.EventHandler(this.OpenPort_Click);
            // 
            // SendFileButton
            // 
            this.SendFileButton.Location = new System.Drawing.Point(21, 75);
            this.SendFileButton.Name = "SendFileButton";
            this.SendFileButton.Size = new System.Drawing.Size(131, 42);
            this.SendFileButton.TabIndex = 1;
            this.SendFileButton.Text = "Отправка файла";
            this.SendFileButton.UseVisualStyleBackColor = true;
            this.SendFileButton.Click += new System.EventHandler(this.SendFileButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(21, 135);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(131, 42);
            this.SettingsButton.TabIndex = 2;
            this.SettingsButton.Text = "Настройки";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // ChatTextBox
            // 
            this.ChatTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChatTextBox.Location = new System.Drawing.Point(158, 183);
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.Size = new System.Drawing.Size(630, 34);
            this.ChatTextBox.TabIndex = 3;
            this.ChatTextBox.TextChanged += new System.EventHandler(this.ChatTextBox_TextChanged);
            // 
            // ChatRichTextBox
            // 
            this.ChatRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChatRichTextBox.Location = new System.Drawing.Point(158, 13);
            this.ChatRichTextBox.Name = "ChatRichTextBox";
            this.ChatRichTextBox.Size = new System.Drawing.Size(630, 164);
            this.ChatRichTextBox.TabIndex = 4;
            this.ChatRichTextBox.Text = "";
            // 
            // SendMessengeButon
            // 
            this.SendMessengeButon.Location = new System.Drawing.Point(684, 223);
            this.SendMessengeButon.Name = "SendMessengeButon";
            this.SendMessengeButon.Size = new System.Drawing.Size(104, 40);
            this.SendMessengeButon.TabIndex = 5;
            this.SendMessengeButon.Text = "Отправить";
            this.SendMessengeButon.UseVisualStyleBackColor = true;
            this.SendMessengeButon.Click += new System.EventHandler(this.SendMessengeButon_Click);
            // 
            // b_ace
            // 
            this.b_ace.Location = new System.Drawing.Point(771, 415);
            this.b_ace.Name = "b_ace";
            this.b_ace.Size = new System.Drawing.Size(17, 23);
            this.b_ace.TabIndex = 6;
            this.b_ace.UseVisualStyleBackColor = true;
            this.b_ace.Click += new System.EventHandler(this.b_ace_Click);
            // 
            // backgroundWorker_Listener
            // 
            this.backgroundWorker_Listener.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Listener_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.b_ace);
            this.Controls.Add(this.SendMessengeButon);
            this.Controls.Add(this.ChatRichTextBox);
            this.Controls.Add(this.ChatTextBox);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.SendFileButton);
            this.Controls.Add(this.OpenPort);
            this.Name = "Form1";
            this.Text = "Основная форма";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenPort;
        private System.Windows.Forms.Button SendFileButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.TextBox ChatTextBox;
        private System.Windows.Forms.RichTextBox ChatRichTextBox;
        private System.Windows.Forms.Button SendMessengeButon;
        private System.Windows.Forms.Button b_ace;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Listener;
    }
}

