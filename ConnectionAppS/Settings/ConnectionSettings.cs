using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionAppS.Settings
{
    /// <summary>
    /// Содержит настройки приложения
    /// </summary>
    public static class ConnectionSettings
    {
        public static int port = -1;
        public static string portName = "COM1";
        public static int bitePerSecond = 9600;
        public static int dataBite = 8;
        public static Parity parity = Parity.None;
        public static StopBits stopBite = StopBits.None;
    }
}
