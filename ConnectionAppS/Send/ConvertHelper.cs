using ConnectionAppS.Connect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectionAppS.Send
{
    public static class ConvertHelper
    {
        /// <summary>
        /// Переводит массив из 8 бит в байт
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static byte ConvertBoolToByte(BitArray bits)
        {
            if (bits.Count > 8)
                throw new ArgumentException("ConvertToByte can only work with a BitArray containing a maximum of 8 values");

            byte result = 0;

            for (byte i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                    result |= (byte)(1 << i);
            }
            return result;
        }
        /// <summary>
        /// Переводит байт в массив бит
        /// </summary>
        /// <param name="nbyte">Байт для перевода в биты</param>
        /// <returns>Возвращает массив из 8 бит</returns>
        public static bool[] ConvertByteToBool(byte nbyte)
        {
            bool[] bits = new bool[8];
            for (int i = 0; i < 8; i++)
                bits[i] = (nbyte & (1 << i)) != 0;
            return bits;
        }
            public  static void SendFrame(Frame frame)
        {
            ConnectHelper.WriteBytesToPort(frame.GetFrame(), frame.GetFrame().Length);
        }
        public static void SendFrames(List<Frame> frames)
        {
            foreach (Frame frame in frames)
            {
                SendFrame(frame);
            }
        }
        public static Frame ReceiveFrame()
        {
            List<byte> data = new List<byte>();
            bool startStop = false;
            while (true) // Считываем кадр
            {
                var nbyte = ConnectHelper.ReadByteFromPort();
                if (nbyte == null)
                {
                    continue;
                }
                if (nbyte == 0xFF) //  Если это старт/Стоп, то мы или помечаем или добавляем и останавливаем считывание.
                {
                    if (!startStop)
                    {
                        startStop = true;
                    }
                    else
                    {
                        data.Add(nbyte);
                        break;
                    }
                }
                data.Add(nbyte);
            }
            return new Frame(data.ToArray());
        }
    }
}
