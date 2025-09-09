using System;
using System.Windows.Forms;

namespace Guan
{
    internal class ClassCalc
    {
        public static void BufferSingleRote90(byte[] buff)
        {
            byte[] array = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (((int)buff[j] & (128 >> i)) != 0)
                    {
                        byte[] array2 = array;
                        int num = 7 - i;
                        array2[num] |= (byte)(128 >> j);
                    }
                    else
                    {
                        byte[] array3 = array;
                        int num2 = 7 - i;
                        array3[num2] &= (byte)(~(byte)(128 >> j));
                    }
                }
            }
            for (int k = 0; k < 8; k++)
            {
                buff[k] = array[k];
            }
        }

        public static void BufferSingleRote180(byte[] buff)
        {
            byte[] array = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (((int)buff[j] & (128 >> i)) != 0)
                    {
                        byte[] array2 = array;
                        int num = 7 - j;
                        array2[num] |= (byte)(128 >> 7 - i);
                    }
                    else
                    {
                        byte[] array3 = array;
                        int num2 = 7 - j;
                        array3[num2] &= (byte)(~(byte)(128 >> 7 - i));
                    }
                }
            }
            for (int k = 0; k < 8; k++)
            {
                buff[k] = array[k];
            }
        }

        public static void BufferSingleRote270(byte[] buff)
        {
            byte[] array = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (((int)buff[j] & (128 >> i)) != 0)
                    {
                        byte[] array2 = array;
                        int num = i;
                        array2[num] |= (byte)(128 >> 7 - j);
                    }
                    else
                    {
                        byte[] array3 = array;
                        int num2 = i;
                        array3[num2] &= (byte)(~(byte)(128 >> 7 - j));
                    }
                }
            }
            for (int k = 0; k < 8; k++)
            {
                buff[k] = array[k];
            }
        }

        public static void BufferLeftRightMirror(byte[] buff)
        {
            byte[] array = new byte[8];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
            for (int j = 0; j < 8; j++)
            {
                for (int k = 0; k < 8; k++)
                {
                    if (((int)buff[j] & (128 >> k)) != 0)
                    {
                        byte[] array2 = array;
                        int num = j;
                        array2[num] |= (byte)(1 << k);
                    }
                }
            }
            for (int l = 0; l < array.Length; l++)
            {
                buff[l] = array[l];
            }
        }

        public static void BufferUpDownMirror(byte[] buff)
        {
            byte[] array = new byte[8];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = buff[array.Length - i - 1];
            }
            for (int j = 0; j < array.Length; j++)
            {
                buff[j] = array[j];
            }
        }

        public static void BufferSolidRote90(byte[] buff)
        {
            byte[] array = new byte[64];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        if (((int)buff[i + (k << 3)] & (128 >> j)) != 0)
                        {
                            byte[] array2 = array;
                            int num = i + (7 - j) * 8;
                            array2[num] |= (byte)(128 >> k);
                        }
                        else
                        {
                            byte[] array3 = array;
                            int num2 = i + (7 - j) * 8;
                            array3[num2] &= (byte)(~(byte)(128 >> k));
                        }
                    }
                }
            }
            for (int l = 0; l < array.Length; l++)
            {
                buff[l] = array[l];
            }
        }

        public static void BufferSolidRote180(byte[] buff)
        {
            byte[] array = new byte[64];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        if (((int)buff[i + (k << 3)] & (128 >> j)) != 0)
                        {
                            byte[] array2 = array;
                            int num = i + (7 - k) * 8;
                            array2[num] |= (byte)(128 >> 7 - j);
                        }
                        else
                        {
                            byte[] array3 = array;
                            int num2 = i + (7 - k) * 8;
                            array3[num2] &= (byte)(~(byte)(128 >> 7 - j));
                        }
                    }
                }
            }
            for (int l = 0; l < array.Length; l++)
            {
                buff[l] = array[l];
            }
        }

        public static void BufferSolidRote270(byte[] buff)
        {
            byte[] array = new byte[64];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        if (((int)buff[i + (k << 3)] & (128 >> j)) != 0)
                        {
                            byte[] array2 = array;
                            int num = i + (j << 3);
                            array2[num] |= (byte)(128 >> 7 - k);
                        }
                        else
                        {
                            byte[] array3 = array;
                            int num2 = i + (j << 3);
                            array3[num2] &= (byte)(~(byte)(128 >> 7 - k));
                        }
                    }
                }
            }
            for (int l = 0; l < array.Length; l++)
            {
                buff[l] = array[l];
            }
        }

        public static void BufferSolidLeftRightMirror(byte[] buff)
        {
            byte[] array = new byte[64];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
            for (int j = 0; j < 8; j++)
            {
                for (int k = 0; k < 8; k++)
                {
                    for (int l = 0; l < 8; l++)
                    {
                        if (((int)buff[(k << 3) + j] & (128 >> l)) != 0)
                        {
                            byte[] array2 = array;
                            int num = (k << 3) + j;
                            array2[num] |= (byte)(1 << l);
                        }
                    }
                }
            }
            for (int m = 0; m < array.Length; m++)
            {
                buff[m] = array[m];
            }
        }

        public static void BufferSolidUpdownMirror(byte[] buff)
        {
            byte[] array = new byte[64];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    array[(j << 3) + i] = buff[(7 - j << 3) + i];
                }
            }
            for (int k = 0; k < array.Length; k++)
            {
                buff[k] = array[k];
            }
        }

        public static void Buffer3DToBufferSingle(byte[] buff3D, byte[] buffSingle, int index, FrameView view)
        {
            for (int i = 0; i < buffSingle.Length; i++)
            {
                buffSingle[i] = 0;
            }
            switch (view)
            {
            case FrameView.front:
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        if (((int)buff3D[(k << 3) + index] & (128 >> j)) != 0)
                        {
                            int num = k;
                            buffSingle[num] |= (byte)(128 >> j);
                        }
                    }
                }
                return;
            }
            case FrameView.top:
            {
                for (int l = 0; l < 8; l++)
                {
                    for (int m = 0; m < 8; m++)
                    {
                        if (((int)buff3D[(7 - index << 3) + m] & (128 >> l)) != 0)
                        {
                            int num2 = m;
                            buffSingle[num2] |= (byte)(128 >> l);
                        }
                    }
                }
                return;
            }
            case FrameView.left:
            {
                for (int n = 0; n < 8; n++)
                {
                    for (int num3 = 0; num3 < 8; num3++)
                    {
                        if (((int)buff3D[(num3 << 3) + (7 - n)] & (128 >> index)) != 0)
                        {
                            int num4 = num3;
                            buffSingle[num4] |= (byte)(128 >> n);
                        }
                    }
                }
                return;
            }
            default:
                return;
            }
        }

        public static void BufferSingleToBuffer3D(byte[] buff3D, byte[] buffSingle, int index, FrameView view)
        {
            switch (view)
            {
            case FrameView.front:
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (((int)buffSingle[j] & (128 >> i)) != 0)
                        {
                            int num = (j << 3) + index;
                            buff3D[num] |= (byte)(128 >> i);
                        }
                        else
                        {
                            int num2 = (j << 3) + index;
                            buff3D[num2] &= (byte)(~(byte)(128 >> i));
                        }
                    }
                }
                return;
            }
            case FrameView.top:
            {
                for (int k = 0; k < 8; k++)
                {
                    for (int l = 0; l < 8; l++)
                    {
                        if (((int)buffSingle[l] & (128 >> k)) != 0)
                        {
                            int num3 = (7 - index << 3) + l;
                            buff3D[num3] |= (byte)(128 >> k);
                        }
                        else
                        {
                            int num4 = (7 - index << 3) + l;
                            buff3D[num4] &= (byte)(~(byte)(128 >> k));
                        }
                    }
                }
                return;
            }
            case FrameView.left:
            {
                for (int m = 0; m < 8; m++)
                {
                    for (int n = 0; n < 8; n++)
                    {
                        if (((int)buffSingle[n] & (128 >> m)) != 0)
                        {
                            int num5 = (n << 3) + (7 - m);
                            buff3D[num5] |= (byte)(128 >> index);
                        }
                        else
                        {
                            int num6 = (n << 3) + (7 - m);
                            buff3D[num6] &= (byte)(~(byte)(128 >> index));
                        }
                    }
                }
                return;
            }
            default:
                return;
            }
        }

        public static void Buffer3DToDX(byte[] buffSingle, DX9 dx, bool mono)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        if (((int)buffSingle[(j << 3) + k] & (128 >> i)) != 0)
                        {
                            dx.SetPoint(i, j, k, true, mono);
                        }
                        else
                        {
                            dx.SetPoint(i, j, k, false, mono);
                        }
                    }
                }
            }
        }

        public static void BufferSingleToDX(byte[] buff, DX9 dx, bool mono, int index, FrameView view, PaintMode mode)
        {
            switch (view)
            {
            case FrameView.front:
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (((int)buff[j] & (128 >> i)) != 0)
                        {
                            if (mode == PaintMode.Copy || mode == PaintMode.OnlySet)
                            {
                                dx.SetPoint(i, j, index, true, mono);
                            }
                        }
                        else if (mode == PaintMode.Copy || mode == PaintMode.OnlyClr)
                        {
                            dx.SetPoint(i, j, index, false, mono);
                        }
                    }
                }
                return;
            }
            case FrameView.top:
            {
                for (int k = 0; k < 8; k++)
                {
                    for (int l = 0; l < 8; l++)
                    {
                        if (((int)buff[l] & (128 >> k)) != 0)
                        {
                            if (mode == PaintMode.Copy || mode == PaintMode.OnlySet)
                            {
                                dx.SetPoint(k, 7 - index, l, true, mono);
                            }
                        }
                        else if (mode == PaintMode.Copy || mode == PaintMode.OnlyClr)
                        {
                            dx.SetPoint(k, 7 - index, l, false, mono);
                        }
                    }
                }
                return;
            }
            case FrameView.left:
            {
                for (int m = 0; m < 8; m++)
                {
                    for (int n = 0; n < 8; n++)
                    {
                        if (((int)buff[n] & (128 >> m)) != 0)
                        {
                            if (mode == PaintMode.Copy || mode == PaintMode.OnlySet)
                            {
                                dx.SetPoint(index, n, 7 - m, true, mono);
                            }
                        }
                        else if (mode == PaintMode.Copy || mode == PaintMode.OnlyClr)
                        {
                            dx.SetPoint(index, n, 7 - m, false, mono);
                        }
                    }
                }
                return;
            }
            default:
                return;
            }
        }

        public static void PointToBuffer3D(byte[] buff3D, int x, int y, int z, FrameView view, PaintMode mode)
        {
            if (x >= 0 && x < 8 && y >= 0 && y < 8 && z >= 0 && z < 8)
            {
                if (view == FrameView.front)
                {
                    if (mode == PaintMode.OnlySet)
                    {
                        int num = (y << 3) + z;
                        buff3D[num] |= (byte)(128 >> x);
                        return;
                    }
                    if (mode == PaintMode.OnlyClr)
                    {
                        int num2 = (y << 3) + z;
                        buff3D[num2] &= (byte)(~(byte)(128 >> x));
                        return;
                    }
                    if (mode == PaintMode.Xor)
                    {
                        int num3 = (y << 3) + z;
                        buff3D[num3] ^= (byte)(128 >> x);
                        return;
                    }
                }
                else if (view == FrameView.top)
                {
                    if (mode == PaintMode.OnlySet)
                    {
                        int num4 = (7 - z << 3) + y;
                        buff3D[num4] |= (byte)(128 >> x);
                        return;
                    }
                    if (mode == PaintMode.OnlyClr)
                    {
                        int num5 = (7 - z << 3) + y;
                        buff3D[num5] &= (byte)(~(byte)(128 >> x));
                        return;
                    }
                    if (mode == PaintMode.Xor)
                    {
                        int num6 = (7 - z << 3) + y;
                        buff3D[num6] ^= (byte)(128 >> x);
                        return;
                    }
                }
                else if (view == FrameView.left)
                {
                    if (mode == PaintMode.OnlySet)
                    {
                        int num7 = (y << 3) + (7 - x);
                        buff3D[num7] |= (byte)(128 >> z);
                        return;
                    }
                    if (mode == PaintMode.OnlyClr)
                    {
                        int num8 = (y << 3) + (7 - x);
                        buff3D[num8] &= (byte)(~(byte)(128 >> z));
                        return;
                    }
                    if (mode == PaintMode.Xor)
                    {
                        int num9 = (y << 3) + (7 - x);
                        buff3D[num9] ^= (byte)(128 >> z);
                    }
                }
            }
        }

        public static void LineToBuffer3D(byte[] buff3D, int x1, int y1, int z1, int x2, int y2, int z2, FrameView view, PaintMode mode)
        {
            try
            {
                int num = x2 - x1;
                int num2 = y2 - y1;
                int num3 = z2 - z1;
                int num4 = ((num > 0) ? 1 : (-1));
                int num5 = ((num2 > 0) ? 1 : (-1));
                int num6 = ((num3 > 0) ? 1 : (-1));
                int num7 = x1;
                int num8 = y1;
                int num9 = z1;
                int num10 = 0;
                int num11 = 0;
                num = Math.Abs(num) + 1;
                num2 = Math.Abs(num2) + 1;
                num3 = Math.Abs(num3) + 1;
                if (num >= num2 && num >= num3)
                {
                    for (num7 = x1; num7 != x2; num7 += num4)
                    {
                        ClassCalc.PointToBuffer3D(buff3D, num7, num8, num9, view, mode);
                        num10 += num2;
                        if (num10 >= num)
                        {
                            num8 += num5;
                            num10 -= num;
                        }
                        num11 += num3;
                        if (num11 >= num)
                        {
                            num9 += num6;
                            num11 -= num;
                        }
                    }
                    ClassCalc.PointToBuffer3D(buff3D, x2, y2, z2, view, mode);
                }
                else if (num >= num2 && num <= num3)
                {
                    for (num9 = z1; num9 != z2; num9 += num6)
                    {
                        ClassCalc.PointToBuffer3D(buff3D, num7, num8, num9, view, mode);
                        num10 += num2;
                        if (num10 >= num3)
                        {
                            num8 += num5;
                            num10 -= num3;
                        }
                        num11 += num;
                        if (num11 >= num3)
                        {
                            num7 += num4;
                            num11 -= num3;
                        }
                    }
                    ClassCalc.PointToBuffer3D(buff3D, x2, y2, z2, view, mode);
                }
                else
                {
                    for (num8 = y1; num8 != y2; num8 += num5)
                    {
                        ClassCalc.PointToBuffer3D(buff3D, num7, num8, num9, view, mode);
                        num10 += num;
                        if (num10 >= num2)
                        {
                            num7 += num4;
                            num10 -= num2;
                        }
                        num11 += num3;
                        if (num11 >= num2)
                        {
                            num9 += num6;
                            num11 -= num2;
                        }
                    }
                    ClassCalc.PointToBuffer3D(buff3D, x2, y2, z2, view, mode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void PanelToBuffer3D(byte[] buff3D, byte[] buffSingle, int x, int y, int z, FrameView view, PaintFun fun, PaintMode mode)
        {
            try
            {
                int num = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 8;
                int num5 = 0;
                int num6 = 8;
                if (x > -8 && x < 8 && y > -8 && y < 8 && z >= 0 && z < 8)
                {
                    byte[] array = (byte[])buffSingle.Clone();
                    if (fun == PaintFun.Rotate90)
                    {
                        ClassCalc.BufferSingleRote90(array);
                    }
                    else if (fun == PaintFun.Rotate180)
                    {
                        ClassCalc.BufferSingleRote180(array);
                    }
                    else if (fun == PaintFun.Rotate270)
                    {
                        ClassCalc.BufferSingleRote270(array);
                    }
                    else if (fun == PaintFun.LeftRightMirror)
                    {
                        ClassCalc.BufferLeftRightMirror(array);
                    }
                    else if (fun == PaintFun.UpDownMirror)
                    {
                        ClassCalc.BufferUpDownMirror(array);
                    }
                    if (x < 0)
                    {
                        num3 = -x;
                    }
                    else
                    {
                        num = x;
                        num4 = 8 - num3;
                    }
                    if (y < 0)
                    {
                        num5 = -y;
                    }
                    else
                    {
                        num2 = y;
                        num6 = 8 - num5;
                    }
                    int num7 = num;
                    for (int i = num3; i < num4; i++)
                    {
                        int num8 = num2;
                        for (int j = num5; j < num6; j++)
                        {
                            if (mode == PaintMode.Copy)
                            {
                                if (((int)array[j] & (128 >> i)) != 0)
                                {
                                    ClassCalc.PointToBuffer3D(buff3D, num7, num8, z, view, PaintMode.OnlySet);
                                }
                                else
                                {
                                    ClassCalc.PointToBuffer3D(buff3D, num7, num8, z, view, PaintMode.OnlyClr);
                                }
                            }
                            else if (mode == PaintMode.OnlySet)
                            {
                                if (((int)array[j] & (128 >> i)) != 0)
                                {
                                    ClassCalc.PointToBuffer3D(buff3D, num7, num8, z, view, PaintMode.OnlySet);
                                }
                            }
                            else if (mode == PaintMode.OnlyClr)
                            {
                                if (((int)array[j] & (128 >> i)) == 0)
                                {
                                    ClassCalc.PointToBuffer3D(buff3D, num7, num8, z, view, PaintMode.OnlyClr);
                                }
                            }
                            else if (mode == PaintMode.Xor && ((int)array[j] & (128 >> i)) != 0)
                            {
                                ClassCalc.PointToBuffer3D(buff3D, num7, num8, z, view, PaintMode.Xor);
                            }
                            num8++;
                        }
                        num7++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void SolidToBuffer3D(byte[] buff3D, byte[] buffSolid, int x, int y, int z, FrameView view, PaintFun fun, PaintMode mode)
        {
            try
            {
                int num = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                int num5 = 8;
                int num6 = 0;
                int num7 = 8;
                int num8 = 0;
                int num9 = 8;
                if (x > -8 && x < 8 && y > -8 && y < 8 && z > -8 && z < 8)
                {
                    byte[] array = (byte[])buffSolid.Clone();
                    if (fun == PaintFun.Rotate90)
                    {
                        ClassCalc.BufferSolidRote90(array);
                    }
                    else if (fun == PaintFun.Rotate180)
                    {
                        ClassCalc.BufferSolidRote180(array);
                    }
                    else if (fun == PaintFun.Rotate270)
                    {
                        ClassCalc.BufferSolidRote270(array);
                    }
                    else if (fun == PaintFun.LeftRightMirror)
                    {
                        ClassCalc.BufferSolidLeftRightMirror(array);
                    }
                    else if (fun == PaintFun.UpDownMirror)
                    {
                        ClassCalc.BufferSolidUpdownMirror(array);
                    }
                    if (x < 0)
                    {
                        num4 = -x;
                    }
                    else
                    {
                        num = x;
                        num5 = 8 - num4;
                    }
                    if (y < 0)
                    {
                        num6 = -y;
                    }
                    else
                    {
                        num2 = y;
                        num7 = 8 - num6;
                    }
                    if (z < 0)
                    {
                        num8 = -z;
                    }
                    else
                    {
                        num3 = z;
                        num9 = 8 - num8;
                    }
                    int num10 = num3;
                    for (int i = num8; i < num9; i++)
                    {
                        int num11 = num;
                        for (int j = num4; j < num5; j++)
                        {
                            int num12 = num2;
                            for (int k = num6; k < num7; k++)
                            {
                                if (mode == PaintMode.Copy)
                                {
                                    if (((int)array[(k << 3) + i] & (128 >> j)) != 0)
                                    {
                                        ClassCalc.PointToBuffer3D(buff3D, num11, num12, num10, view, PaintMode.OnlySet);
                                    }
                                    else
                                    {
                                        ClassCalc.PointToBuffer3D(buff3D, num11, num12, num10, view, PaintMode.OnlyClr);
                                    }
                                }
                                else if (mode == PaintMode.OnlySet)
                                {
                                    if (((int)array[(k << 3) + i] & (128 >> j)) != 0)
                                    {
                                        ClassCalc.PointToBuffer3D(buff3D, num11, num12, num10, view, PaintMode.OnlySet);
                                    }
                                }
                                else if (mode == PaintMode.OnlyClr)
                                {
                                    if (((int)array[(k << 3) + i] & (128 >> j)) == 0)
                                    {
                                        ClassCalc.PointToBuffer3D(buff3D, num11, num12, num10, view, PaintMode.OnlyClr);
                                    }
                                }
                                else if (mode == PaintMode.Xor && ((int)array[(k << 3) + i] & (128 >> j)) != 0)
                                {
                                    ClassCalc.PointToBuffer3D(buff3D, num11, num12, num10, view, PaintMode.Xor);
                                }
                                num12++;
                            }
                            num11++;
                        }
                        num10++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static bool GetDotPosition(FrameIndex m_index, int start, int end, int len, int valueIndex, int frameIndex, ref int value)
        {
            try
            {
                if (len == 1)
                {
                    value = start;
                    if (valueIndex != 0)
                    {
                        value = m_index.m_indexNumber[valueIndex - 1].m_element[value - 1].index;
                    }
                }
                else
                {
                    value = (end - start) * frameIndex / (len - 1) + start;
                    if (valueIndex != 0)
                    {
                        value = m_index.m_indexNumber[valueIndex - 1].m_element[value - 1].index;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }

        public static bool GetResBuff(FrameIndex m_index, ResourceType type, int start, int end, int len, int valueIndex, int frameIndex, ref int value)
        {
            try
            {
                if (len == 1)
                {
                    value = start;
                    if (valueIndex == 0)
                    {
                        return false;
                    }
                    if (type == ResourceType.singleGraph)
                    {
                        value = m_index.m_indexSingle[valueIndex - 1].m_element[value - 1].index;
                    }
                    else if (type == ResourceType.solidGraph)
                    {
                        value = m_index.m_indexSolid[valueIndex - 1].m_element[value - 1].index;
                    }
                }
                else
                {
                    value = (end - start) * frameIndex / (len - 1) + start;
                    if (valueIndex == 0)
                    {
                        return false;
                    }
                    if (type == ResourceType.singleGraph)
                    {
                        value = m_index.m_indexSingle[valueIndex - 1].m_element[value - 1].index;
                    }
                    else if (type == ResourceType.solidGraph)
                    {
                        value = m_index.m_indexSolid[valueIndex - 1].m_element[value - 1].index;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }

        public static bool GetBright(PropertyElementBright m_bright, int frameIndex, ref int value)
        {
            try
            {
                if (m_bright.length == 1)
                {
                    value = m_bright.startBright;
                }
                else
                {
                    int startBright = m_bright.startBright;
                    int endBright = m_bright.endBright;
                    value = (endBright - startBright) * frameIndex / (m_bright.length - 1) + startBright;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }

        public static void SingleFrameToDX(FrameCartoonGroup m_group, FrameResource m_res, FrameIndex m_index, int frameIndex, DX9 dx, bool mono)
        {
            byte[] array = new byte[64];
            ClassCalc.SingleFrameToDX(array, m_group, m_res, m_index, frameIndex, dx, mono);
        }

        public static void SingleFrameToDX(byte[] disBuff, FrameCartoonGroup m_group, FrameResource m_res, FrameIndex m_index, int frameIndex, DX9 dx, bool mono)
        {
            if ((long)frameIndex < (long)((ulong)m_group.frameCount))
            {
                if (m_group.cleanDisplay)
                {
                    for (int i = 0; i < disBuff.Length; i++)
                    {
                        disBuff[i] = 0;
                    }
                }
                foreach (FrameCartoonElement frameCartoonElement in m_group.ele)
                {
                    FrameCartoonType type = frameCartoonElement.m_type;
                    int count = frameCartoonElement.property.Count;
                    for (int j = 0; j < count; j++)
                    {
                        FrameCartoonProperty frameCartoonProperty = frameCartoonElement.property[j];
                        int num = frameIndex - frameCartoonProperty.startIndex;
                        if (frameCartoonProperty.length > 0 && frameCartoonProperty.startIndex <= frameIndex && frameCartoonProperty.startIndex + frameCartoonProperty.length > frameIndex)
                        {
                            if (type == FrameCartoonType.dot)
                            {
                                PropertyElementDot propertyElementDot = (PropertyElementDot)frameCartoonProperty;
                                int num2 = 0;
                                int num3 = 0;
                                int num4 = 0;
                                if (ClassCalc.GetDotPosition(m_index, propertyElementDot.startX, propertyElementDot.endX, propertyElementDot.length, propertyElementDot.indexX, num, ref num2) && ClassCalc.GetDotPosition(m_index, propertyElementDot.startY, propertyElementDot.endY, propertyElementDot.length, propertyElementDot.indexY, num, ref num3) && ClassCalc.GetDotPosition(m_index, propertyElementDot.startZ, propertyElementDot.endZ, propertyElementDot.length, propertyElementDot.indexZ, num, ref num4))
                                {
                                    ClassCalc.PointToBuffer3D(disBuff, num2, num3, num4, propertyElementDot.view, propertyElementDot.fun2);
                                }
                            }
                            else if (type == FrameCartoonType.line)
                            {
                                PropertyElementLine propertyElementLine = (PropertyElementLine)frameCartoonProperty;
                                int num5 = 0;
                                int num6 = 0;
                                int num7 = 0;
                                int num8 = 0;
                                int num9 = 0;
                                int num10 = 0;
                                if (ClassCalc.GetDotPosition(m_index, propertyElementLine.startX1, propertyElementLine.endX1, propertyElementLine.length, propertyElementLine.indexX, num, ref num5) && ClassCalc.GetDotPosition(m_index, propertyElementLine.startY1, propertyElementLine.endY1, propertyElementLine.length, propertyElementLine.indexY, num, ref num6) && ClassCalc.GetDotPosition(m_index, propertyElementLine.startZ1, propertyElementLine.endZ1, propertyElementLine.length, propertyElementLine.indexZ, num, ref num7) && ClassCalc.GetDotPosition(m_index, propertyElementLine.startX2, propertyElementLine.endX2, propertyElementLine.length, propertyElementLine.indexX, num, ref num8) && ClassCalc.GetDotPosition(m_index, propertyElementLine.startY2, propertyElementLine.endY2, propertyElementLine.length, propertyElementLine.indexY, num, ref num9) && ClassCalc.GetDotPosition(m_index, propertyElementLine.startZ2, propertyElementLine.endZ2, propertyElementLine.length, propertyElementLine.indexZ, num, ref num10))
                                {
                                    ClassCalc.LineToBuffer3D(disBuff, num5, num6, num7, num8, num9, num10, propertyElementLine.view, propertyElementLine.fun2);
                                }
                            }
                            else if (type == FrameCartoonType.panel)
                            {
                                PropertyElementPanel propertyElementPanel = (PropertyElementPanel)frameCartoonProperty;
                                int num11 = 0;
                                int num12 = 0;
                                int num13 = 0;
                                int num14 = 0;
                                if (ClassCalc.GetDotPosition(m_index, propertyElementPanel.startX, propertyElementPanel.endX, propertyElementPanel.length, propertyElementPanel.indexX, num, ref num11) && ClassCalc.GetDotPosition(m_index, propertyElementPanel.startY, propertyElementPanel.endY, propertyElementPanel.length, propertyElementPanel.indexY, num, ref num12) && ClassCalc.GetDotPosition(m_index, propertyElementPanel.startZ, propertyElementPanel.endZ, propertyElementPanel.length, propertyElementPanel.indexZ, num, ref num13))
                                {
                                    if (propertyElementPanel.useIndex)
                                    {
                                        if (!ClassCalc.GetResBuff(m_index, ResourceType.singleGraph, propertyElementPanel.resIndexStart, propertyElementPanel.resIndexEnd, propertyElementPanel.length, propertyElementPanel.res, num, ref num14))
                                        {
                                            num14 = 0;
                                        }
                                    }
                                    else
                                    {
                                        num14 = propertyElementPanel.res;
                                    }
                                    if (num14 != 0)
                                    {
                                        ClassCalc.PanelToBuffer3D(disBuff, m_res.m_resSingle[num14 - 1].buff, num11, num12, num13, propertyElementPanel.view, propertyElementPanel.fun1, propertyElementPanel.fun2);
                                    }
                                }
                            }
                            else if (type == FrameCartoonType.solid)
                            {
                                PropertyElementSolid propertyElementSolid = (PropertyElementSolid)frameCartoonProperty;
                                int num15 = 0;
                                int num16 = 0;
                                int num17 = 0;
                                int num18 = 0;
                                if (ClassCalc.GetDotPosition(m_index, propertyElementSolid.startX, propertyElementSolid.endX, propertyElementSolid.length, propertyElementSolid.indexX, num, ref num15) && ClassCalc.GetDotPosition(m_index, propertyElementSolid.startY, propertyElementSolid.endY, propertyElementSolid.length, propertyElementSolid.indexY, num, ref num16) && ClassCalc.GetDotPosition(m_index, propertyElementSolid.startZ, propertyElementSolid.endZ, propertyElementSolid.length, propertyElementSolid.indexZ, num, ref num17))
                                {
                                    if (propertyElementSolid.useIndex)
                                    {
                                        if (!ClassCalc.GetResBuff(m_index, ResourceType.solidGraph, propertyElementSolid.resIndexStart, propertyElementSolid.resIndexEnd, propertyElementSolid.length, propertyElementSolid.res, num, ref num18))
                                        {
                                            num18 = 0;
                                        }
                                    }
                                    else
                                    {
                                        num18 = propertyElementSolid.res;
                                    }
                                    if (num18 != 0)
                                    {
                                        ClassCalc.SolidToBuffer3D(disBuff, m_res.m_resSolid[num18 - 1].buff, num15, num16, num17, propertyElementSolid.view, propertyElementSolid.fun1, propertyElementSolid.fun2);
                                    }
                                }
                            }
                            else if (type == FrameCartoonType.bright)
                            {
                                PropertyElementBright propertyElementBright = (PropertyElementBright)frameCartoonProperty;
                                int num19 = 0;
                                if (ClassCalc.GetBright(propertyElementBright, num, ref num19))
                                {
                                    dx.SetBright((byte)num19);
                                }
                            }
                        }
                    }
                }
                ClassCalc.Buffer3DToDX(disBuff, dx, mono);
                dx.OnPaint();
            }
        }

        public static bool TextBoxKeyPress(int MinNum, int MaxNum, TextBox box, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                return true;
            }
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '-' || e.KeyChar == '\u0016')
            {
                string text = box.Text;
                string text2;
                if (e.KeyChar == '\u0016')
                {
                    text2 = Clipboard.GetText();
                }
                else
                {
                    text2 = e.KeyChar.ToString();
                }
                int selectionStart = box.SelectionStart;
                int selectionLength = box.SelectionLength;
                string text3 = text.Remove(selectionStart, selectionLength);
                text3 = text3.Insert(selectionStart, text2);
                if (text3 != "-")
                {
                    try
                    {
                        int num = int.Parse(text3);
                        if (num < MinNum || num > MaxNum)
                        {
                            e.Handled = true;
                        }
                        return false;
                    }
                    catch
                    {
                        e.Handled = true;
                        return false;
                    }
                }
                if (MinNum >= 0)
                {
                    e.Handled = true;
                }
            }
            else if (e.KeyChar != '\b' && e.KeyChar != '\u0003')
            {
                e.Handled = true;
            }
            return false;
        }
    }
}
