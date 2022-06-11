using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionAppS.Connect
{
    public static class ConnectHelper
    {
        // Непосредственно порт из стандартной библиотеки
        private static SerialPort _serialPort;
        /// <summary>
        /// Создаёт экземпляр COM-порта
        /// </summary>
        /// <returns>Вернет true если экземпляр успешно создан, иначе false</returns>
        public static bool CreatePort()
        {
            if (_serialPort != null)
            {
                _serialPort = new SerialPort();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Возвращает значение DSR (сигнал готовности данных), нужно для проверки соединения
        /// </summary>
        /// <returns>Вернет true, если DSR отправлен в порт, иначе false</returns>
        public static bool GetDsr()
        {
            return _serialPort.DsrHolding;
        }

        /// <summary>
        /// Устанавливает параметры COM-порта, используя данных из класса ConnectionSettings
        /// </summary>
        public static void SetPortSettings()
        {
            if (_serialPort == null)
            {
                _serialPort = new SerialPort();
            }
            _serialPort.PortName = ConnectionAppS.Settings.ConnectionSettings.portName;
            _serialPort.BaudRate = ConnectionAppS.Settings.ConnectionSettings.bitePerSecond;
            _serialPort.DataBits = ConnectionAppS.Settings.ConnectionSettings.dataBite;
            _serialPort.Parity = ConnectionAppS.Settings.ConnectionSettings.parity;
            if (ConnectionAppS.Settings.ConnectionSettings.stopBite != StopBits.None)
            {
                _serialPort.StopBits = ConnectionAppS.Settings.ConnectionSettings.stopBite;
            }
            _serialPort.Handshake = Handshake.None;
            _serialPort.DtrEnable = true;
            _serialPort.RtsEnable = false;
            _serialPort.WriteTimeout = 500;
            _serialPort.ReadTimeout = 500;
        }

        /// <summary>
        /// Чтение байта из COM-порта
        /// </summary>
        /// <returns>Вернет либо прочитанный байт, либо null</returns>
        public static dynamic ReadByteFromPort()
        {
            int result = _serialPort.ReadByte();
            if (result != -1)
            {
                return Convert.ToByte(result);
            }
            return null;
        }

        /// <summary>
        /// Функция устанавливает флаг RtsEnable в нужное положение. При false COM-порт не принимает данные,
        /// при true наоборот.
        /// </summary>
        /// <param name="status">Значение, которое будет установлено в флаг RtsEnable</param>
        public static void SetRtsStatus(bool status)
        {
            _serialPort.RtsEnable = status;
        }
        /// <summary>
        /// Функция возвращает количество байт, доступных для чтения.
        /// </summary>
        /// <returns>Значение, равное количеству байт, доступных для чтения</returns>
        public static int GetCountBytesToRead()
        {
            if (_serialPort.IsOpen)
            {
                return _serialPort.BytesToRead;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Функция отправляет массив байтов через COM-порт
        /// </summary>
        /// <param name="bytes">Массив байтов, которые нужно передать</param>
        /// <param name="count">Количество байтов (размер массива bytes)</param>
        public static void WriteBytesToPort(byte[] bytes, int count)
        {
            _serialPort.Write(bytes, 0, count);
        }

        /// <summary>
        /// Функция возвращает значение, указывающее открытое или закрытое состояние порта
        /// </summary>
        /// <returns>Вернет true, если порт создан и открыт, иначе false</returns>
        public static bool IsPortOpened()
        {
            if (_serialPort != null)
            {
                return _serialPort.IsOpen;
            }
            return false;
        }

        /// <summary>
        /// Функция открывает порт, если он создан и не открыт
        /// </summary>
        /// <returns>Вернет true при успешном открытии порта, иначе false</returns>
        public static bool OpenPort()
        {
            if (_serialPort == null || _serialPort.IsOpen)
            {
                return false;
            }
            _serialPort.Open();
            return true;

        }

        /// <summary>
        /// Функция закрывает порт, если он создан и открыт
        /// </summary>
        /// <returns>Вернет true при успешном закрытии порта, иначе false</returns>
        public static bool ClosePort()
        {
            if (_serialPort == null || !_serialPort.IsOpen)
            {
                return false;
            }
            _serialPort.Close();
            return true;
        }
    }
}

