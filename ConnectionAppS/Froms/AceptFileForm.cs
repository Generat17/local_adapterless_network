using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectionAppS.Froms
{
    /// <summary>
    /// Форма приёма файла
    /// </summary>
    public partial class AceptFileForm : Form
    {
        private List<byte> file = new List<byte>();
        string filePath;
        public AceptFileForm(List<byte>file)
        {
            this.file=file;
            InitializeComponent();
        }

        private void AceptFileForm_Load(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "t.txt";
          
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FileWayBox.Text))
            {
                var fileName = "file.txt";
                File.WriteAllBytes(FileWayBox.Text, file.ToArray());
            }
            else
            {
                MessageBox.Show("Не указан путь для сохранения файла");
            }
        }

        private void PathButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.filePath = saveFileDialog.FileName;
                FileWayBox.Text = saveFileDialog.FileName;
            }
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
           
        }
    }
}
