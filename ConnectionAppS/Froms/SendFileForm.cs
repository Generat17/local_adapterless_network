using ConnectionAppS.Send;
using ConnectionAppS.Settings;
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
    ///  Форма отправки 
    /// </summary>
    public partial class SendFileForm : Form
    {
        public SendFileForm()
        {
            InitializeComponent();
            FileWayBox.AppendText("");
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FileWayBox.Text))
            {
                string fileExtension = Path.GetExtension(openFileDialog.SafeFileName);
                // Имя файла
                List<byte> fileExtensionBytes = Encoding.ASCII.GetBytes(fileExtension).ToList();
                // Файл
                List<byte> sendFile = File.ReadAllBytes(openFileDialog.FileName).ToList();
                // количество байт в файле в байтовом выражении
                var byteSize = BitConverter.GetBytes(sendFile.Count);
                // Отправляем файл
                Send.ConvertHelper.SendFrame(new Frame(fileExtensionBytes.ToArray(), "name"));
                Send.ConvertHelper.SendFrame(new Frame(byteSize, "size"));
                Send.ConvertHelper.SendFrames (FrameCoder.CodeFile(sendFile.ToArray()));
                MessageBox.Show("Файл отправлен");
            }
            else
            {
                MessageBox.Show("Файл не выбран");
            }
        }

        private void AdditionalFilebutton_Click(object sender, EventArgs e)
        {
            // В случае нажатия на кнопку выбора файла
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Выбран файл: " + openFileDialog.SafeFileName);
                var fileWay = openFileDialog.FileName;
                FileWayBox.AppendText(openFileDialog.FileName);
            }
            else if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Файл не выбран");
            }
        }
    }
}
