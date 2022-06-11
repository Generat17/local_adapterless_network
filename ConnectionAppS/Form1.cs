using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectionAppS.Froms;
using ConnectionAppS.Connect;
using ConnectionAppS.Send;
/*
* Вариант 43:
Разработать протоколы взаимодействия объектов до прикладного уровня локальной сети, состоящей из 2-х ПК, 
соединенных через интерфейс RS232C нульмодемным кабелем, 
и реализующей функцию передачи коротких сообщений и  файлов. 
Скорость обмена и параметры СОМ-порта заданы по умолчанию. 
Имя передаваемого файла выбирается из каталога источника ведущей станцией. 
При передаче файла защитить передаваемую информацию циклическим [15,11]-кодом.
*/
namespace ConnectionAppS
{
    /// <summary>
    /// Основная форма 
    /// </summary>
    public partial class Form1 : Form
    {
        private bool isPortOpen = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChatTextBox.Visible = false;
            SendMessengeButon.Visible = false;
            ConnectHelper.CreatePort();
        }

        private void ChatTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SendMessengeButon_Click(object sender, EventArgs e)
        {
            var text = ChatTextBox.Text;
            ChatRichTextBox.Text = ChatRichTextBox.Text + "\nЯ:"+text;
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void SendFileButton_Click(object sender, EventArgs e)
        {
            var sendFileForm = new SendFileForm();
            sendFileForm.ShowDialog();
        }

        private void OpenPort_Click(object sender, EventArgs e)
        {
            // Для создания скринов поменять тут  ConnectHelper.IsPortOpened() на любую локальную переменную тут и получить скрин с чатом
            if (!ConnectHelper.IsPortOpened())
            {
                if (ConnectHelper.OpenPort())
                {
                    isPortOpen = true;
                    OpenPort.ForeColor = Color.Red;
                    OpenPort.Text = "Закрыть порт";
                    ChatRichTextBox.Text = ChatRichTextBox.Text + "\n" + "Порт открыт";
                    ChatTextBox.Visible = true;
                    SendMessengeButon.Visible = true;
                }
                else
                {
                    MessageBox.Show("Не удалось открыть порт");
                }
            }
           else
            {
                if (ConnectHelper.ClosePort())
                {
                    isPortOpen = false;
                    OpenPort.ForeColor = Color.Black;
                    OpenPort.Text = "Открыть порт";
                    ChatRichTextBox.Text = ChatRichTextBox.Text + "\n" + "Порт закрыт" + "\n";
                    ChatTextBox.Visible = false;
                    SendMessengeButon.Visible = false;
                }
                else
                {
                    MessageBox.Show("Не удалось закрыть порт");
                }
            }
        }

        private void b_ace_Click(object sender, EventArgs e)
        {
            var af = new Froms.AceptFileForm(null);
            af.ShowDialog();
        }
        private void backgroundWorker_Listener_DoWork(object sender, DoWorkEventArgs e)
        {
            if (ConnectHelper.GetCountBytesToRead() > 0)
            {
                var frame = ConvertHelper.ReceiveFrame();
                if (frame.frameName == FrameNames.Information)
                {
                    FrameCoder.acceptFrames.Add(frame);
                    FrameCoder.lastAcceptFrame = frame;
                    ConvertHelper.SendFrame(new Frame(FrameNames.ACK));
                    FrameCoder.lastSendFrame = new Frame(FrameNames.ACK);
                    FrameCoder.nextFrame = true;
                }
                if (frame.frameName == FrameNames.ACK)
                {
                    FrameCoder.lastAcceptFrame = frame;
                    FrameCoder.nextFrame = true;
                }
                if (frame.frameName == FrameNames.NAK)
                {
                    FrameCoder.lastAcceptFrame = frame;
                    ConvertHelper.SendFrame( FrameCoder.lastSendFrame);
                    FrameCoder.nextFrame = false;
                }
                if (frame.frameName == FrameNames.UPLINK)
                {
                    FrameCoder.lastAcceptFrame = frame;
                    FrameCoder.ConnectionStart = true;
                    // Отправляем  сообщение об успешном получении 
                    ConvertHelper.SendFrame( new Frame(FrameNames.ACK));
                    FrameCoder.lastSendFrame = new Frame(FrameNames.ACK);
                }
                if (frame.frameName == FrameNames.DOWNLINK)
                {
                    FrameCoder.lastAcceptFrame = frame;
                    FrameCoder.ConnectionStart = false;
                }
                if (frame.frameName == FrameNames.UNDEFINED)
                {
                    FrameCoder.lastAcceptFrame = frame;
                    MessageBox.Show("Кадр передан некорректно");
                    ConvertHelper.SendFrame( new Frame(FrameNames.NAK));
                    FrameCoder.lastSendFrame = new Frame(FrameNames.NAK);
                }
                if(frame.frameName == FrameNames.TEXT)
                {
                    FrameCoder.lastAcceptFrame = frame;
                    MessageBox.Show("Получено сообщение");
                    ConvertHelper.SendFrame( new Frame(FrameNames.ACK));
                    FrameCoder.lastSendFrame = new Frame(FrameNames.ACK);
                    FrameCoder.acceptText.Add( frame);
                    var byteText = FrameCoder.DecodeFile(FrameCoder.acceptText);
                   // Получение в виде текста
                    ChatRichTextBox.Text=ChatRichTextBox.Text + "\nСобеседник"+ System.Text.Encoding.UTF8.GetString(byteText.ToArray());
                }
                if (frame.frameName == FrameNames.FILEHEADER)
                {
                    FrameCoder.lastAcceptFrame = frame;
                    //Переносим расширение
                    FrameCoder.fileExtension = System.Text.Encoding.GetEncoding(1251).GetString((frame.GetIformationBytes()));
                    if (!String.IsNullOrWhiteSpace(FrameCoder.fileExtension))
                    {
                        ConvertHelper.SendFrame(new Frame(FrameNames.ACK));
                        FrameCoder.lastSendFrame = new Frame(FrameNames.ACK);
                    }
                    else
                    {
                        ConvertHelper.SendFrame(new Frame(FrameNames.NAK));
                        FrameCoder.lastSendFrame = new Frame(FrameNames.NAK);
                    }
                }

            }
        }
    }
}
