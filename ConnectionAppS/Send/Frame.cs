using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionAppS.Send
{
    public enum FrameNames
    {
        Information,
        ACK,
        NAK,
        UPLINK,
        DOWNLINK,
        UNDEFINED,
        FILEHEADER,
        SIZE,
        TEXT
    }
    /// <summary>
    /// Класс отвечает за передаваемые кадры 
    /// </summary>
    public class Frame
    {
        static byte start = 0xFF;
        static byte end = 0xFF;
        public FrameNames frameName;
        byte[] informationBytes;

        public byte[] GetIformationBytes()
        {
            return informationBytes;
        }
        public byte[] GetFrame()
        {
            byte[] result = new byte[2 + informationBytes.Length];
            result[0] = start;
            for (int i = 0; i < informationBytes.Length; i++)
            {
                result[i + 1] = (byte)informationBytes[i];
            }
            result[1 + informationBytes.Length] = end;
            return result;
        }
        /// <summary>
        /// Используется для формирования кадров из принимаемых байтов
        /// </summary>
        /// <param name="bytes"></param>
        public Frame(byte[] bytes)
        {
            if (bytes.Count() == 4) // Информационный байт 
            {
                informationBytes = new byte[2];
                informationBytes[0] = bytes[1];
                informationBytes[1] = bytes[2];
                frameName = FrameNames.Information;
            }
            if (bytes.Count() == 3) // Служебный кадр
            {
                informationBytes = new byte[1];
                informationBytes[0] = bytes[1];
                int code = bytes[1];
                switch (code)
                {
                    case 1:
                        {
                            frameName = FrameNames.ACK;
                            break;
                        }
                    case 2:
                        {
                            frameName = FrameNames.NAK;
                            break;
                        }
                    case 3:
                        {
                            frameName = FrameNames.UPLINK;
                            break;
                        }
                    case 4:
                        {
                            frameName = FrameNames.DOWNLINK;
                            break;
                        }
                    default:
                        {
                            frameName = FrameNames.UNDEFINED;
                            break;
                        }
                }
            }

            if (bytes.Count() == 8) // Байт типа
            {
                informationBytes = new byte[6];
                for (int i = 0; i < 6; i++)
                {
                    informationBytes[i] = bytes[i + 1];
                }
                frameName = FrameNames.FILEHEADER;
            }
            if (bytes.Count() == 6) // Байт размера
            {
                informationBytes = new byte[4];
                for (int i = 0; i < 4; i++)
                {
                    informationBytes[i] = bytes[i + 1];
                }
                frameName = FrameNames.SIZE;
            }
            if (bytes.Count() == 12) // Текстовый байт
            {
                informationBytes = new byte[10];
                for (int i = 0; i < 4; i++)
                {
                    informationBytes[i] = bytes[i + 1];
                }
                frameName = FrameNames.TEXT;
            }
        }
        /// <summary>
        /// Используется для заполнения кадров информацией
        /// </summary>
        /// <param name="info"></param>
        /// <param name="type">size - размерный байт, name - тип расширения, info - информационный</param>
        public Frame(byte[] info , string type="")
        {
            // Если информационный кадр
            if (type == "size")
            {
                informationBytes = new byte[4];
                frameName = FrameNames.SIZE;
            }
            if (type == "name")
            {
                informationBytes = new byte[6];
                frameName = FrameNames.FILEHEADER;
            }
            if (type =="info")
            {
                informationBytes = new byte[2];
                frameName = FrameNames.Information;
            }
            if (type == "text")
            {
                informationBytes = new byte[10];
                frameName = FrameNames.TEXT;
            }
            for (int i = 0; i < info.Length; i++)
            {
                informationBytes[i] = info[i];
            }
            if (info.Length < informationBytes.Length)
            {
                // Заполняем нулями, если размер поданного массива меньше необходимого
                for (int i = informationBytes.Length - 1; i <= info.Length; i--)
                {
                    informationBytes[i] = 0x00;
                }
            }
        }
        /// <summary>
        /// Используется для формирования кадров настроек
        /// </summary>
        /// <param name="frameNames"></param>
        public Frame(FrameNames frameNames)
        {
            informationBytes = new byte[1];
            if (frameNames == FrameNames.ACK)
            {
                informationBytes[0] = 0x01;
                this.frameName = frameNames;
            }
            if (frameNames == FrameNames.NAK)
            {
                informationBytes[0] = 0x02;
                this.frameName = frameNames;
            }
            if (frameNames == FrameNames.UPLINK)
            {
                informationBytes[0] = 0x03;
                this.frameName = frameNames;
            }
            if (frameNames == FrameNames.DOWNLINK)
            {
                informationBytes[0] = 0x04;
                this.frameName = frameNames;
            }
        }
    }
}
