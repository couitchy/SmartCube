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
            ListByte listByte = new ListByte();
            listByte.AppendData((uint)2769809749);
            listByte.AppendData(this.m_res.m_head.version);
            listByte.AppendData((ushort)1029);
            uint config = m_head.config;
            config = ((config - 1) & 0x00FF) | ((config - 0x0100) & 0xFF00) | ((config - 0x010000) & 0xFF0000) | ((config - 0x01000000) & 0xFF000000);
            listByte.AppendData(config);
            listByte.AppendData(this.m_res.m_head.defaultSpeed);
            if (Config.EnableEnhanced)
            {
                listByte.AppendData(this.m_res.m_head.configWord);
            }
            else
            {
                listByte.AppendData((uint)0);
            }
            listByte.AppendData((uint)0);
            ListByte listByte2 = new ListByte();
            foreach (ResourceSingle resourceSingle in this.m_res.m_res.m_resSingle)
            {
                listByte2.AppendData(resourceSingle.buff);
            }
            ListByte listByte3 = new ListByte();
            foreach (ResourceSolid resourceSolid in this.m_res.m_res.m_resSolid)
            {
                listByte3.AppendData(resourceSolid.buff);
            }
            ListByte listByte4 = new ListByte();
            if (this.m_res.m_index.m_indexSingle.Count > 0)
            {
                foreach (ResourceIndex resourceIndex in this.m_res.m_index.m_indexSingle)
                {
                    if (resourceIndex.m_element.Count > 0)
                    {
                        listByte4.AppendData((uint)resourceIndex.m_element.Count);
                        foreach (FrameIndexElement frameIndexElement in resourceIndex.m_element)
                        {
                            listByte4.AppendData((ushort)frameIndexElement.index);
                        }
                        if (listByte4.GetLength() % 4 != 0)
                        {
                            listByte4.AppendData((ushort)0);
                        }
                    }
                }
            }
            ListByte listByte5 = new ListByte();
            if (this.m_res.m_index.m_indexSolid.Count > 0)
            {
                foreach (ResourceIndex resourceIndex2 in this.m_res.m_index.m_indexSolid)
                {
                    if (resourceIndex2.m_element.Count > 0)
                    {
                        listByte5.AppendData((uint)resourceIndex2.m_element.Count);
                        foreach (FrameIndexElement frameIndexElement2 in resourceIndex2.m_element)
                        {
                            listByte5.AppendData((ushort)frameIndexElement2.index);
                        }
                        if (listByte5.GetLength() % 4 != 0)
                        {
                            listByte5.AppendData((ushort)0);
                        }
                    }
                }
            }
            ListByte listByte6 = new ListByte();
            if (this.m_res.m_index.m_indexNumber.Count > 0)
            {
                foreach (ResourceIndex resourceIndex3 in this.m_res.m_index.m_indexNumber)
                {
                    if (resourceIndex3.m_element.Count > 0)
                    {
                        listByte6.AppendData((uint)resourceIndex3.m_element.Count);
                        foreach (FrameIndexElement frameIndexElement3 in resourceIndex3.m_element)
                        {
                            listByte6.AppendData((ushort)frameIndexElement3.index);
                        }
                        if (listByte6.GetLength() % 4 != 0)
                        {
                            listByte6.AppendData((ushort)0);
                        }
                    }
                }
            }
            ListByte listByte7 = new ListByte();
            ListByte listByte8 = new ListByte();
            ListByte listByte9 = new ListByte();
            ListByte listByte10 = new ListByte();
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
                            listByte9.AppendData((ushort)frameCartoonGroup.frameCount);
                            listByte9.AppendData((ushort)frameCartoonGroup.delay);
                            listByte9.AppendData((ushort)frameCartoonGroup.loopCount);
                            listByte9.AppendData(frameCartoonGroup.cleanDisplay);
                            listByte9.AppendData((byte)0);
                            listByte9.AppendData((ushort)frameCartoonGroup.ele.Count);
                            listByte9.AppendData((ushort)0);
                            if (frameCartoonGroup.ele.Count > 0)
                            {
                                foreach (FrameCartoonElement frameCartoonElement in frameCartoonGroup.ele)
                                {
                                    listByte10.Clear();
                                    listByte10.AppendData((ushort)frameCartoonElement.m_type);
                                    listByte10.AppendData((ushort)frameCartoonElement.property.Count);
                                    foreach (FrameCartoonProperty frameCartoonProperty in frameCartoonElement.property)
                                    {
                                        listByte10.AppendData((ushort)frameCartoonProperty.startIndex);
                                        listByte10.AppendData((ushort)frameCartoonProperty.length);
                                        if (frameCartoonElement.m_type == FrameCartoonType.dot)
                                        {
                                            PropertyElementDot propertyElementDot = (PropertyElementDot)frameCartoonProperty;
                                            listByte10.AppendData((byte)propertyElementDot.indexX);
                                            listByte10.AppendData((byte)propertyElementDot.startX);
                                            listByte10.AppendData((byte)propertyElementDot.endX);
                                            listByte10.AppendData((byte)propertyElementDot.indexY);
                                            listByte10.AppendData((byte)propertyElementDot.startY);
                                            listByte10.AppendData((byte)propertyElementDot.endY);
                                            listByte10.AppendData((byte)propertyElementDot.indexZ);
                                            listByte10.AppendData((byte)propertyElementDot.startZ);
                                            listByte10.AppendData((byte)propertyElementDot.endZ);
                                            listByte10.AppendData((byte)propertyElementDot.view);
                                            listByte10.AppendData((byte)propertyElementDot.fun2);
                                            listByte10.AppendData((byte)0);
                                        }
                                        else if (frameCartoonElement.m_type == FrameCartoonType.line)
                                        {
                                            PropertyElementLine propertyElementLine = (PropertyElementLine)frameCartoonProperty;
                                            listByte10.AppendData((byte)propertyElementLine.indexX);
                                            listByte10.AppendData((byte)propertyElementLine.startX1);
                                            listByte10.AppendData((byte)propertyElementLine.startX2);
                                            listByte10.AppendData((byte)propertyElementLine.endX1);
                                            listByte10.AppendData((byte)propertyElementLine.endX2);
                                            listByte10.AppendData((byte)propertyElementLine.indexY);
                                            listByte10.AppendData((byte)propertyElementLine.startY1);
                                            listByte10.AppendData((byte)propertyElementLine.startY2);
                                            listByte10.AppendData((byte)propertyElementLine.endY1);
                                            listByte10.AppendData((byte)propertyElementLine.endY2);
                                            listByte10.AppendData((byte)propertyElementLine.indexZ);
                                            listByte10.AppendData((byte)propertyElementLine.startZ1);
                                            listByte10.AppendData((byte)propertyElementLine.startZ2);
                                            listByte10.AppendData((byte)propertyElementLine.endZ1);
                                            listByte10.AppendData((byte)propertyElementLine.endZ2);
                                            listByte10.AppendData((byte)propertyElementLine.view);
                                            listByte10.AppendData((byte)propertyElementLine.fun2);
                                            listByte10.AppendData((byte)0);
                                            listByte10.AppendData((byte)0);
                                            listByte10.AppendData((byte)0);
                                        }
                                        else if (frameCartoonElement.m_type == FrameCartoonType.panel)
                                        {
                                            PropertyElementPanel propertyElementPanel = (PropertyElementPanel)frameCartoonProperty;
                                            listByte10.AppendData((byte)propertyElementPanel.indexX);
                                            listByte10.AppendData((byte)propertyElementPanel.startX);
                                            listByte10.AppendData((byte)propertyElementPanel.endX);
                                            listByte10.AppendData((byte)propertyElementPanel.indexY);
                                            listByte10.AppendData((byte)propertyElementPanel.startY);
                                            listByte10.AppendData((byte)propertyElementPanel.endY);
                                            listByte10.AppendData((byte)propertyElementPanel.indexZ);
                                            listByte10.AppendData((byte)propertyElementPanel.startZ);
                                            listByte10.AppendData((byte)propertyElementPanel.endZ);
                                            listByte10.AppendData((byte)propertyElementPanel.resIndexStart);
                                            if (propertyElementPanel.useIndex)
                                            {
                                                listByte10.AppendData((ushort)(propertyElementPanel.res | 0x8000));
                                            }
                                            else
                                            {
                                                listByte10.AppendData((ushort)(propertyElementPanel.res & 0x7FFF));
                                            }
                                            listByte10.AppendData((byte)propertyElementPanel.resIndexEnd);
                                            listByte10.AppendData((byte)propertyElementPanel.view);
                                            listByte10.AppendData((byte)propertyElementPanel.fun2);
                                            listByte10.AppendData((byte)propertyElementPanel.fun1);
                                        }
                                        else if (frameCartoonElement.m_type == FrameCartoonType.solid)
                                        {
                                            PropertyElementSolid propertyElementSolid = (PropertyElementSolid)frameCartoonProperty;
                                            listByte10.AppendData((byte)propertyElementSolid.indexX);
                                            listByte10.AppendData((byte)propertyElementSolid.startX);
                                            listByte10.AppendData((byte)propertyElementSolid.endX);
                                            listByte10.AppendData((byte)propertyElementSolid.indexY);
                                            listByte10.AppendData((byte)propertyElementSolid.startY);
                                            listByte10.AppendData((byte)propertyElementSolid.endY);
                                            listByte10.AppendData((byte)propertyElementSolid.indexZ);
                                            listByte10.AppendData((byte)propertyElementSolid.startZ);
                                            listByte10.AppendData((byte)propertyElementSolid.endZ);
                                            listByte10.AppendData((byte)propertyElementSolid.resIndexStart);
                                            if (propertyElementSolid.useIndex)
                                            {
                                                listByte10.AppendData((ushort)(propertyElementSolid.res | 0x8000));
                                            }
                                            else
                                            {
                                                listByte10.AppendData((ushort)(propertyElementSolid.res & 0x7FFF));
                                            }
                                            listByte10.AppendData((byte)propertyElementSolid.resIndexEnd);
                                            listByte10.AppendData((byte)propertyElementSolid.view);
                                            listByte10.AppendData((byte)propertyElementSolid.fun2);
                                            listByte10.AppendData((byte)propertyElementSolid.fun1);
                                        }
                                        else if (frameCartoonElement.m_type == FrameCartoonType.bright)
                                        {
                                            PropertyElementBright propertyElementBright = (PropertyElementBright)frameCartoonProperty;
                                            listByte10.AppendData((ushort)propertyElementBright.startBright);
                                            listByte10.AppendData((ushort)propertyElementBright.endBright);
                                        }
                                    }
                                    listByte9.AppendData((uint)(listByte10.GetLength() + 4));
                                    listByte9.AppendData(listByte10);
                                }
                            }
                            listByte8.AppendData((uint)(listByte9.GetLength() + 4));
                            listByte8.AppendData(listByte9);
                        }
                    }
                    listByte7.AppendData((uint)(listByte8.GetLength() + 8));
                    listByte7.AppendData((ushort)frameCartoonControl.groups.Count);
                    listByte7.AppendData((ushort)frameCartoonControl.loopCount);
                    listByte7.AppendData(listByte8);
                }
            }
            if (listByte7.GetLength() == 0)
            {
                info = "No Cartoon!";
                return false;
            }
            int num = listByte.GetLength() + 24;
            listByte.AppendData((ushort)num);
            listByte.AppendData((ushort)this.m_res.m_res.m_resSingle.Count);
            num += listByte2.GetLength();
            listByte.AppendData((ushort)num);
            listByte.AppendData((ushort)this.m_res.m_res.m_resSolid.Count);
            num += listByte3.GetLength();
            listByte.AppendData((ushort)num);
            listByte.AppendData((ushort)this.m_res.m_index.m_indexSingle.Count);
            num += listByte4.GetLength();
            listByte.AppendData((ushort)num);
            listByte.AppendData((ushort)this.m_res.m_index.m_indexSolid.Count);
            num += listByte5.GetLength();
            listByte.AppendData((ushort)num);
            listByte.AppendData((ushort)this.m_res.m_index.m_indexNumber.Count);
            num += listByte6.GetLength();
            listByte.AppendData((ushort)num);
            listByte.AppendData((ushort)this.m_res.m_control.m_cartoon.Count);
            ListByte listByte11 = new ListByte();
            listByte11.AppendData(listByte);
            listByte11.AppendData(listByte2);
            listByte11.AppendData(listByte3);
            listByte11.AppendData(listByte4);
            listByte11.AppendData(listByte5);
            listByte11.AppendData(listByte6);
            listByte11.AppendData(listByte7);
            int length = listByte11.GetLength();
            if (length > Config.outputLenLimit)
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
            float num2 = (float)length * 100f / (float)Config.outputLenLimit;
            info = string.Format("Generation succeeded\r\nUsed memory: {0:F2}% ", num2);
            return true;
        }

        private bool OutputCFile(ListByte head, ListByte singleRes, ListByte solidRes, ListByte singleIndex, ListByte solidIndex, ListByte numberIndex, ListByte control)
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
                    FileStream fileStream = new FileStream(Environment.CurrentDirectory + "\\data.c", FileMode.Create);
                    StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
                    fileStream.SetLength(0);
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

        private string WriteBlock(uint dat)
        {
            ushort num = (ushort)(dat >> 16);
            string text = ":02000004";
            byte b = (byte)(6 + (byte)(num >> 8) + (byte)num);
            b = (byte)(1 + ~b);
            return text + string.Format("{0:X4}{1:X2}\r\n", num, b);
        }

        private bool OutputHexFile(ListByte dat)
        {
            uint outputLenMax = Config.outputLenMax;
            uint num = Config.outputStartVale;
            Random random = new Random(42);
            while (dat.GetLength() < outputLenMax)
            {
                dat.AppendData((byte)random.Next(0, 255));
            }
            string text = "";
            string text2 = "";
            byte b = 0;
            for (uint num2 = 0; num2 < outputLenMax; num2++)
            {
                if (num2 % 16 == 0)
                {
                    ushort num3 = (ushort)num;
                    text2 = "";
                    if (num3 == ushort.MaxValue)
                    {
                        ushort num4 = 0;
                        num3 += num4;
                    }
                    if (num3 == 0)
                    {
                        text2 += this.WriteBlock(num);
                    }
                    text2 = text2 + ":10" + string.Format("{0:X4}", num3);
                    text2 += "00";
                    b = (byte)(16 + (byte)(num3 >> 8) + (byte)num3);
                }
                text2 += string.Format("{0:X2}", dat.m_list[(int)num2]);
                b += dat.m_list[(int)num2];
                if (num2 % 16 == 15)
                {
                    b = (byte)(1 + ~b);
                    text2 += string.Format("{0:X2}\r\n", b);
                    text += text2;
                }
                num++;
            }
            try
            {
                FileStream fileStream = new FileStream(Environment.CurrentDirectory + "\\output.hex", FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
                fileStream.SetLength(0);
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

        private class ListByte
        {
            public ListByte()
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

            public void AppendData(ListByte buff)
            {
                foreach (byte b in buff.m_list)
                {
                    this.AppendData(b);
                }
            }

            public void AppendData(byte[] buff)
            {
                foreach (byte b in buff)
                {
                    this.AppendData(b);
                }
            }

            public void AppendData(byte buff)
            {
                this.m_list.Add(buff);
            }

            public void AppendData(ushort buff)
            {
                this.m_list.Add((byte)(buff >> 8));
                this.m_list.Add((byte)buff);
            }

            public void AppendData(uint buff)
            {
                this.m_list.Add((byte)(buff >> 24));
                this.m_list.Add((byte)(buff >> 16));
                this.m_list.Add((byte)(buff >> 8));
                this.m_list.Add((byte)buff);
            }

            public void AppendData(bool flag)
            {
                this.m_list.Add((byte)(flag ? 1 : 0));
            }

            public List<byte> m_list = new List<byte>();
        }
    }
}
