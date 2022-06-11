using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionAppS.Connect;
using ConnectionAppS.Send;

namespace ConnectionAppS.Send
{
    public static class FrameCoder
    {
        public static bool ConnectionStart = false, nextFrame = false; // Начало соединения и определение следующего фрейма
        public static Frame lastAcceptFrame, lastSendFrame;
        public static List<Frame> acceptFrames = new List<Frame>();
        public static string fileExtension;
        public static List<Frame> acceptText = new List<Frame>();
        public static List<byte> DecodeFile(List<Frame> frameList)
        {
            List<byte> result = new List<byte>();
            List<bool> toBytes = new List<bool>();
            foreach (Frame frame in frameList)
            {
                List<bool> toDecode = new List<bool>();
                var infoBytes = new byte[] { frame.GetFrame()[1], frame.GetFrame()[2] };
                foreach (var bits in ConvertHelper.ConvertByteToBool(infoBytes[0]))
                {
                    toDecode.Add(bits);
                }
                var infbyte1 = ConvertHelper.ConvertByteToBool(infoBytes[1]);
                for (int i = 0; i < 7; i++)
                {
                    toDecode.Add(infbyte1[i]);
                }
                var onDec = CoderDecoder.Decode(toDecode,new List<bool>{ true, false, false, true, true});
                foreach (var bit in onDec)
                {
                    toBytes.Add(bit);
                }
            }
            for (int i = 0; i < toBytes.Count; i += 8)
            {
                var boolMas = new bool[8];
                for (int j = 0; j < 8; j++)
                {
                    boolMas[j] = toBytes[i + j];
                }
                result.Add(ConvertHelper.ConvertBoolToByte(new BitArray(boolMas)));
            }
            return result;
        }
        public static List<Frame> CodeFile(byte[] file)
        {
            List<Frame> result = new List<Frame>();
            List<byte> toFrame = new List<byte>();
            List<bool> toCode = new List<bool>();

            foreach (var b in file) // Переводим файл в массив бит
            {
                var oneByte = ConvertHelper.ConvertByteToBool(b);
                foreach (bool bit in oneByte)
                {
                    toCode.Add(bit);
                }
            }
            int count11Ost = toCode.Count % 11; // Остаток от деления на 11, добавляется в конце для корректной сборки
            for (int i = 0; i < 11 - count11Ost; i++)
            {
                toCode.Add(false);
            }
            var inCode = new bool[11];
            //Кодируем и переводим код обратно в байты.
            for (int i = 0; i < toCode.Count; i++)
            {
                if (i % 11 != 0)
                {
                    inCode[i % 11] = toCode[i];
                }
                else
                {
                    if (i != 0)
                    {
                        var afterCodeBits = CoderDecoder.Endcode(inCode.ToList(), new List<bool> { true, false, false, true, true });
                        afterCodeBits.Add(false); // Добавляем незначащий ноль в конце.
                        var toByte = new bool[8];
                        for (int j = 0; j < afterCodeBits.Count; j++)
                        {
                            if (j % 8 != 0)
                            {
                                toByte[j % 8] = afterCodeBits[j];
                            }
                            else
                            {
                                if (j != 0)
                                {
                                    toFrame.Add(ConvertHelper.ConvertBoolToByte(new BitArray(toByte)));
                                    toByte[0] = afterCodeBits[j];
                                }
                                else
                                {
                                    toByte[0] = afterCodeBits[j];
                                }
                            }
                        }
                        inCode[i % 11] = toCode[i];
                    }
                    else
                    {
                        inCode[0] = toCode[i];
                    }

                }
            }

            //Если не делится на 2 выделяем пустой байт
            if (toFrame.Count % 2 != 0)
            {
                toFrame.Add(0x00);
            }
            var inFrame = new byte[2];
            for (int i = 0; i < toFrame.Count; i += 2)
            {
                result.Add(new Frame(new byte[] { toFrame[i], toFrame[i + 1] }));
            }
            return result;
        }
    }
}
