using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectionAppS.Settings;

namespace ConnectionAppS.Froms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {

            InitializeComponent();
            // Добавление ком портов.
            for (int i = 1; i <= 9; i++)
            {
                Name = "COM" + i;
                PortComboBox.Items.Add(Name);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Добавить обработчик ошибок
            ConnectionSettings.port = PortComboBox.SelectedIndex;
            ConnectionSettings.portName = PortComboBox.Text;
            ConnectionSettings.bitePerSecond = Convert.ToInt32(BPSComboBox.Text);
            ConnectionSettings.parity = (Parity)Enum.Parse(typeof(Parity), ParityComboBox.Text, true);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // PortComboBox.Items.Clear();
            foreach (var port in SerialPort.GetPortNames())
            {
                PortComboBox.Items.Add(port.ToString());
            }
        }

        private void ParityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
