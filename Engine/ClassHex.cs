using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Guan.Properties;

namespace Guan
{
    internal class ClassHex
    {
        public ClassHex(AllResourceHead head, AllResource res)
        {
            this.m_head = head;
            this.m_res = res;
        }

        public bool IsChangeOK(bool outputCFile, out string info)
        {
            info = "";
            ClassHex.listByte listByte = new ClassHex.listByte();
            listByte.GetData(2769809749U);
            listByte.GetData(this.m_res.m_head.version);
            listByte.GetData(1029);
            uint num = this.m_head.config;
            num = ((num - 1U) & 255U) | ((num - 256U) & 65280U) | ((num - 65536U) & 16711680U) | ((num - 16777216U) & 4278190080U);
            listByte.GetData(num);
            listByte.GetData(this.m_res.m_head.defaultSpeed);
            if (Config.EnableEnhanced)
            {
                listByte.GetData(this.m_res.m_head.configWord);
            }
            else
            {
                listByte.GetData(0U);
            }
            listByte.GetData(0U);
            ClassHex.listByte listByte2 = new ClassHex.listByte();
            foreach (ResourceSingle resourceSingle in this.m_res.m_res.m_resSingle)
            {
                listByte2.GetData(resourceSingle.buff);
            }
            ClassHex.listByte listByte3 = new ClassHex.listByte();
            foreach (ResourceSolid resourceSolid in this.m_res.m_res.m_resSolid)
            {
                listByte3.GetData(resourceSolid.buff);
            }
            ClassHex.listByte listByte4 = new ClassHex.listByte();
            if (this.m_res.m_index.m_indexSingle.Count > 0)
            {
                foreach (ResourceIndex resourceIndex in this.m_res.m_index.m_indexSingle)
                {
                    if (resourceIndex.m_element.Count > 0)
                    {
                        listByte4.GetData((uint)resourceIndex.m_element.Count);
                        foreach (FrameIndexElement frameIndexElement in resourceIndex.m_element)
                        {
                            listByte4.GetData((ushort)frameIndexElement.index);
                        }
                        if (listByte4.GetLength() % 4 != 0)
                        {
                            listByte4.GetData(0);
                        }
                    }
                }
            }
            ClassHex.listByte listByte5 = new ClassHex.listByte();
            if (this.m_res.m_index.m_indexSolid.Count > 0)
            {
                foreach (ResourceIndex resourceIndex2 in this.m_res.m_index.m_indexSolid)
                {
                    if (resourceIndex2.m_element.Count > 0)
                    {
                        listByte5.GetData((uint)resourceIndex2.m_element.Count);
                        foreach (FrameIndexElement frameIndexElement2 in resourceIndex2.m_element)
                        {
                            listByte5.GetData((ushort)frameIndexElement2.index);
                        }
                        if (listByte5.GetLength() % 4 != 0)
                        {
                            listByte5.GetData(0);
                        }
                    }
                }
            }
            ClassHex.listByte listByte6 = new ClassHex.listByte();
            if (this.m_res.m_index.m_indexNumber.Count > 0)
            {
                foreach (ResourceIndex resourceIndex3 in this.m_res.m_index.m_indexNumber)
                {
                    if (resourceIndex3.m_element.Count > 0)
                    {
                        listByte6.GetData((uint)resourceIndex3.m_element.Count);
                        foreach (FrameIndexElement frameIndexElement3 in resourceIndex3.m_element)
                        {
                            listByte6.GetData((ushort)frameIndexElement3.index);
                        }
                        if (listByte6.GetLength() % 4 != 0)
                        {
                            listByte6.GetData(0);
                        }
                    }
                }
            }
            ClassHex.listByte listByte7 = new ClassHex.listByte();
            ClassHex.listByte listByte8 = new ClassHex.listByte();
            ClassHex.listByte listByte9 = new ClassHex.listByte();
            ClassHex.listByte listByte10 = new ClassHex.listByte();
            if (this.m_res.m_control.m_cartoon.Count > 0)
            {
                foreach (FrameCartoonControl frameCartoonControl in this.m_res.m_control.m_cartoon)
                {
                    listByte8.Clear();
                    if (frameCartoonControl.groups.Count > 0)
                    {
                        foreach (FrameCartoonGroup frameCartoonGroup in frameCartoonControl.groups)
                        {
                            listByte9.Clear();
                            listByte9.GetData((ushort)frameCartoonGroup.frameCount);
                            listByte9.GetData((ushort)frameCartoonGroup.delay);
                            listByte9.GetData((ushort)frameCartoonGroup.loopCount);
                            listByte9.GetData(frameCartoonGroup.cleanDisplay);
                            listByte9.GetData(0);
                            listByte9.GetData((ushort)frameCartoonGroup.ele.Count);
                            listByte9.GetData(0);
                            if (frameCartoonGroup.ele.Count > 0)
                            {
                                foreach (FrameCartoonElement frameCartoonElement in frameCartoonGroup.ele)
                                {
                                    listByte10.Clear();
                                    listByte10.GetData((ushort)frameCartoonElement.m_type);
                                    listByte10.GetData((ushort)frameCartoonElement.property.Count);
                                    foreach (FrameCartoonProperty frameCartoonProperty in frameCartoonElement.property)
                                    {
                                        listByte10.GetData((ushort)frameCartoonProperty.startIndex);
                                        listByte10.GetData((ushort)frameCartoonProperty.length);
                                        if (frameCartoonElement.m_type == FrameCartoonType.dot)
                                        {
                                            PropertyElementDot propertyElementDot = (PropertyElementDot)frameCartoonProperty;
                                            listByte10.GetData((byte)propertyElementDot.indexX);
                                            listByte10.GetData((byte)propertyElementDot.startX);
                                            listByte10.GetData((byte)propertyElementDot.endX);
                                            listByte10.GetData((byte)propertyElementDot.indexY);
                                            listByte10.GetData((byte)propertyElementDot.startY);
                                            listByte10.GetData((byte)propertyElementDot.endY);
                                            listByte10.GetData((byte)propertyElementDot.indexZ);
                                            listByte10.GetData((byte)propertyElementDot.startZ);
                                            listByte10.GetData((byte)propertyElementDot.endZ);
                                            listByte10.GetData((byte)propertyElementDot.view);
                                            listByte10.GetData((byte)propertyElementDot.fun2);
                                            listByte10.GetData(0);
                                        }
                                        else if (frameCartoonElement.m_type == FrameCartoonType.line)
                                        {
                                            PropertyElementLine propertyElementLine = (PropertyElementLine)frameCartoonProperty;
                                            listByte10.GetData((byte)propertyElementLine.indexX);
                                            listByte10.GetData((byte)propertyElementLine.startX1);
                                            listByte10.GetData((byte)propertyElementLine.startX2);
                                            listByte10.GetData((byte)propertyElementLine.endX1);
                                            listByte10.GetData((byte)propertyElementLine.endX2);
                                            listByte10.GetData((byte)propertyElementLine.indexY);
                                            listByte10.GetData((byte)propertyElementLine.startY1);
                                            listByte10.GetData((byte)propertyElementLine.startY2);
                                            listByte10.GetData((byte)propertyElementLine.endY1);
                                            listByte10.GetData((byte)propertyElementLine.endY2);
                                            listByte10.GetData((byte)propertyElementLine.indexZ);
                                            listByte10.GetData((byte)propertyElementLine.startZ1);
                                            listByte10.GetData((byte)propertyElementLine.startZ2);
                                            listByte10.GetData((byte)propertyElementLine.endZ1);
                                            listByte10.GetData((byte)propertyElementLine.endZ2);
                                            listByte10.GetData((byte)propertyElementLine.view);
                                            listByte10.GetData((byte)propertyElementLine.fun2);
                                            listByte10.GetData(0);
                                            listByte10.GetData(0);
                                            listByte10.GetData(0);
                                        }
                                        else if (frameCartoonElement.m_type == FrameCartoonType.panel)
                                        {
                                            PropertyElementPanel propertyElementPanel = (PropertyElementPanel)frameCartoonProperty;
                                            listByte10.GetData((byte)propertyElementPanel.indexX);
                                            listByte10.GetData((byte)propertyElementPanel.startX);
                                            listByte10.GetData((byte)propertyElementPanel.endX);
                                            listByte10.GetData((byte)propertyElementPanel.indexY);
                                            listByte10.GetData((byte)propertyElementPanel.startY);
                                            listByte10.GetData((byte)propertyElementPanel.endY);
                                            listByte10.GetData((byte)propertyElementPanel.indexZ);
                                            listByte10.GetData((byte)propertyElementPanel.startZ);
                                            listByte10.GetData((byte)propertyElementPanel.endZ);
                                            listByte10.GetData((byte)propertyElementPanel.resIndexStart);
                                            if (propertyElementPanel.useIndex)
                                            {
                                                listByte10.GetData((ushort)(propertyElementPanel.res | 32768));
                                            }
                                            else
                                            {
                                                listByte10.GetData((ushort)(propertyElementPanel.res & 32767));
                                            }
                                            listByte10.GetData((byte)propertyElementPanel.resIndexEnd);
                                            listByte10.GetData((byte)propertyElementPanel.view);
                                            listByte10.GetData((byte)propertyElementPanel.fun2);
                                            listByte10.GetData((byte)propertyElementPanel.fun1);
                                        }
                                        else if (frameCartoonElement.m_type == FrameCartoonType.solid)
                                        {
                                            PropertyElementSolid propertyElementSolid = (PropertyElementSolid)frameCartoonProperty;
                                            listByte10.GetData((byte)propertyElementSolid.indexX);
                                            listByte10.GetData((byte)propertyElementSolid.startX);
                                            listByte10.GetData((byte)propertyElementSolid.endX);
                                            listByte10.GetData((byte)propertyElementSolid.indexY);
                                            listByte10.GetData((byte)propertyElementSolid.startY);
                                            listByte10.GetData((byte)propertyElementSolid.endY);
                                            listByte10.GetData((byte)propertyElementSolid.indexZ);
                                            listByte10.GetData((byte)propertyElementSolid.startZ);
                                            listByte10.GetData((byte)propertyElementSolid.endZ);
                                            listByte10.GetData((byte)propertyElementSolid.resIndexStart);
                                            if (propertyElementSolid.useIndex)
                                            {
                                                listByte10.GetData((ushort)(propertyElementSolid.res | 32768));
                                            }
                                            else
                                            {
                                                listByte10.GetData((ushort)(propertyElementSolid.res & 32767));
                                            }
                                            listByte10.GetData((byte)propertyElementSolid.resIndexEnd);
                                            listByte10.GetData((byte)propertyElementSolid.view);
                                            listByte10.GetData((byte)propertyElementSolid.fun2);
                                            listByte10.GetData((byte)propertyElementSolid.fun1);
                                        }
                                        else if (frameCartoonElement.m_type == FrameCartoonType.bright)
                                        {
                                            PropertyElementBright propertyElementBright = (PropertyElementBright)frameCartoonProperty;
                                            listByte10.GetData((ushort)propertyElementBright.startBright);
                                            listByte10.GetData((ushort)propertyElementBright.endBright);
                                        }
                                    }
                                    listByte9.GetData((uint)(listByte10.GetLength() + 4));
                                    listByte9.GetData(listByte10);
                                }
                            }
                            listByte8.GetData((uint)(listByte9.GetLength() + 4));
                            listByte8.GetData(listByte9);
                        }
                    }
                    listByte7.GetData((uint)(listByte8.GetLength() + 8));
                    listByte7.GetData((ushort)frameCartoonControl.groups.Count);
                    listByte7.GetData((ushort)frameCartoonControl.loopCount);
                    listByte7.GetData(listByte8);
                }
            }
            if (listByte7.GetLength() == 0)
            {
                info = "No Cartoon!";
                return false;
            }
            int num2 = listByte.GetLength() + 24;
            listByte.GetData((ushort)num2);
            listByte.GetData((ushort)this.m_res.m_res.m_resSingle.Count);
            num2 += listByte2.GetLength();
            listByte.GetData((ushort)num2);
            listByte.GetData((ushort)this.m_res.m_res.m_resSolid.Count);
            num2 += listByte3.GetLength();
            listByte.GetData((ushort)num2);
            listByte.GetData((ushort)this.m_res.m_index.m_indexSingle.Count);
            num2 += listByte4.GetLength();
            listByte.GetData((ushort)num2);
            listByte.GetData((ushort)this.m_res.m_index.m_indexSolid.Count);
            num2 += listByte5.GetLength();
            listByte.GetData((ushort)num2);
            listByte.GetData((ushort)this.m_res.m_index.m_indexNumber.Count);
            num2 += listByte6.GetLength();
            listByte.GetData((ushort)num2);
            listByte.GetData((ushort)this.m_res.m_control.m_cartoon.Count);
            ClassHex.listByte listByte11 = new ClassHex.listByte();
            listByte11.GetData(listByte);
            listByte11.GetData(listByte2);
            listByte11.GetData(listByte3);
            listByte11.GetData(listByte4);
            listByte11.GetData(listByte5);
            listByte11.GetData(listByte6);
            listByte11.GetData(listByte7);
            int length = listByte11.GetLength();
            if ((long)length > (long)((ulong)Config.outputLenLimit))
            {
                info = "Data length mismatch!";
                return false;
            }
            if (outputCFile && !this.OutputCFile(listByte, listByte2, listByte3, listByte4, listByte5, listByte6, listByte7))
            {
                info = "C file generation failed!";
                return false;
            }
            if (!this.OutputHexFile(listByte11))
            {
                info = "HEX file generation failed!";
                return false;
            }
            float num3 = (float)length * 100f / Config.outputLenLimit;
            info = string.Format("Generation succeeded\r\nUsed memory:{0:F2}% ", num3);
            return true;
        }

        private bool OutputCFile(ClassHex.listByte head, ClassHex.listByte singleRes, ClassHex.listByte solidRes, ClassHex.listByte singleIndex, ClassHex.listByte solidIndex, ClassHex.listByte numberIndex, ClassHex.listByte control)
        {
            try
            {
                string text = "#include \"system.h\"\r\n#include \"data.h\"\r\n code u8 displayData[";
                text += Config.outputLenMax.ToString();
                text += "]";
                text += " = \r\n{\r\n";
                text += "//Head:\r\n";
                int num = 0;
                int num2 = 10;
                foreach (byte b in head.m_list)
                {
                    text += string.Format("0x{0:X2}, ", b);
                    if (++num >= num2)
                    {
                        num = 0;
                        text += "\r\n";
                    }
                }
                text += "\r\n";
                text += "//SingleRes:\r\n";
                num = 0;
                foreach (byte b2 in singleRes.m_list)
                {
                    text += string.Format("0x{0:X2}, ", b2);
                    if (++num >= num2)
                    {
                        num = 0;
                        text += "\r\n";
                    }
                }
                text += "\r\n";
                text += "//SolidRes\r\n";
                num = 0;
                foreach (byte b3 in solidRes.m_list)
                {
                    text += string.Format("0x{0:X2}, ", b3);
                    if (++num >= num2)
                    {
                        num = 0;
                        text += "\r\n";
                    }
                }
                text += "\r\n";
                text += "//SingleIndex:\r\n";
                num = 0;
                foreach (byte b4 in singleIndex.m_list)
                {
                    text += string.Format("0x{0:X2}, ", b4);
                    if (++num >= num2)
                    {
                        num = 0;
                        text += "\r\n";
                    }
                }
                text += "\r\n";
                text += "//SolidIndex:\r\n";
                num = 0;
                foreach (byte b5 in solidIndex.m_list)
                {
                    text += string.Format("0x{0:X2}, ", b5);
                    if (++num >= num2)
                    {
                        num = 0;
                        text += "\r\n";
                    }
                }
                text += "\r\n";
                text += "//NumberIndex:\r\n";
                num = 0;
                foreach (byte b6 in numberIndex.m_list)
                {
                    text += string.Format("0x{0:X2}, ", b6);
                    if (++num >= num2)
                    {
                        num = 0;
                        text += "\r\n";
                    }
                }
                text += "\r\n";
                text += "//Control:\r\n";
                num = 0;
                foreach (byte b7 in control.m_list)
                {
                    text += string.Format("0x{0:X2}, ", b7);
                    if (++num >= num2)
                    {
                        num = 0;
                        text += "\r\n";
                    }
                }
                text += "\r\n";
                text += "};";
                try
                {
                    FileStream fileStream = new FileStream(Environment.CurrentDirectory + "\\data.c", FileMode.OpenOrCreate);
                    StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
                    fileStream.SetLength(0L);
                    streamWriter.Write(text);
                    streamWriter.Close();
                    fileStream.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
        }

        private string WriteBlack(uint dat)
        {
            ushort num = (ushort)(dat >> 16);
            string text = ":02000004";
            byte b = (byte)(6 + (byte)(num >> 8) + (byte)num);
            b = (byte)(1 + ~b);
            return text + string.Format("{0:X4}{1:X2}\r\n", num, b);
        }

        private bool OutputHexFile(ClassHex.listByte dat)
        {
            uint outputLenMax = Config.outputLenMax;
            uint num = Config.outputStartVale;
            Random random = new Random();
            while ((long)dat.GetLength() < (long)((ulong)outputLenMax))
            {
                dat.GetData((byte)random.Next(0, 255));
            }
            string text = "";
            string text2 = "";
            byte b = 0;
            for (uint num2 = 0U; num2 < outputLenMax; num2 += 1U)
            {
                if (num2 % 16U == 0U)
                {
                    ushort num3 = (ushort)num;
                    text2 = "";
                    if (num3 == 65535)
                    {
                        ushort num4 = 0;
                        num3 += num4;
                    }
                    if (num3 == 0)
                    {
                        text2 += this.WriteBlack(num);
                    }
                    text2 = text2 + ":10" + string.Format("{0:X4}", num3);
                    text2 += "00";
                    b = (byte)(16 + (byte)(num3 >> 8) + (byte)num3);
                }
                text2 += string.Format("{0:X2}", dat.m_list[(int)num2]);
                b += dat.m_list[(int)num2];
                if (num2 % 16U == 15U)
                {
                    b = (byte)(1 + ~b);
                    text2 += string.Format("{0:X2}\r\n", b);
                    text += text2;
                }
                num += 1U;
            }
            try
            {
                FileStream fileStream = new FileStream(Environment.CurrentDirectory + "\\output.hex", FileMode.OpenOrCreate);
                StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
                fileStream.SetLength(0L);
                streamWriter.Write(Resources.Head);
                streamWriter.Write(text);
                streamWriter.Write(Resources.Tail);
                streamWriter.Close();
                fileStream.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        private AllResource m_res;

        private AllResourceHead m_head;

        private class listByte
        {
            public listByte()
            {
                this.Clear();
            }

            public void Clear()
            {
                this.m_list.Clear();
            }

            public int GetLength()
            {
                return this.m_list.Count;
            }

            public void GetData(ClassHex.listByte buff)
            {
                foreach (byte b in buff.m_list)
                {
                    this.GetData(b);
                }
            }

            public void GetData(byte[] buff)
            {
                foreach (byte b in buff)
                {
                    this.GetData(b);
                }
            }

            public void GetData(byte buff)
            {
                this.m_list.Add(buff);
            }

            public void GetData(ushort buff)
            {
                this.m_list.Add((byte)(buff >> 8));
                this.m_list.Add((byte)buff);
            }

            public void GetData(uint buff)
            {
                this.m_list.Add((byte)(buff >> 24));
                this.m_list.Add((byte)(buff >> 16));
                this.m_list.Add((byte)(buff >> 8));
                this.m_list.Add((byte)buff);
            }

            public void GetData(bool flag)
            {
                this.m_list.Add((byte)(flag ? 1 : 0));
            }

            private const bool IsBigEnding = true;

            public List<byte> m_list = new List<byte>();
        }
    }
}
