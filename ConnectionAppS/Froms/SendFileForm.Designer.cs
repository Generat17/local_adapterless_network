namespace ConnectionAppS.Froms
{
    partial class SendFileForm
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
            this.LoadButton = new System.Windows.Forms.Button();
            this.AdditionalFilebutton = new System.Windows.Forms.Button();
            this.FileWayBox = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(628, 64);
            this.LoadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(160, 50);
            this.LoadButton.TabIndex = 5;
            this.LoadButton.Text = "Загрузить файл";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // AdditionalFilebutton
            // 
            this.AdditionalFilebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AdditionalFilebutton.Location = new System.Drawing.Point(723, 26);
            this.AdditionalFilebutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AdditionalFilebutton.Name = "AdditionalFilebutton";
            this.AdditionalFilebutton.Size = new System.Drawing.Size(65, 31);
            this.AdditionalFilebutton.TabIndex = 4;
            this.AdditionalFilebutton.Text = "...";
            this.AdditionalFilebutton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AdditionalFilebutton.UseVisualStyleBackColor = true;
            this.AdditionalFilebutton.Click += new System.EventHandler(this.AdditionalFilebutton_Click);
            // 
            // FileWayBox
            // 
            this.FileWayBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.FileWayBox.Location = new System.Drawing.Point(12, 26);
            this.FileWayBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FileWayBox.Name = "FileWayBox";
            this.FileWayBox.ReadOnly = true;
            this.FileWayBox.Size = new System.Drawing.Size(705, 34);
            this.FileWayBox.TabIndex = 3;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // SendFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 146);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.AdditionalFilebutton);
            this.Controls.Add(this.FileWayBox);
            this.Name = "SendFileForm";
            this.Text = "SendFileForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button AdditionalFilebutton;
        private System.Windows.Forms.TextBox FileWayBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}