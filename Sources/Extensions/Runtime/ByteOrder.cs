using System.Runtime.CompilerServices;

namespace System
{
    using Runtime.InteropServices;
#if !NETCORE && !SILVERLIGHT
    using INT = Int64;
#else
    using INT = Int32;
#endif

#pragma warning disable 1591

    public enum Endianness
    {
        LittleEndian,
        BigEndian
    }

    public static class ByteOrder
    {
        public static readonly Endianness CurrentByteOrder =
            (BitConverter.IsLittleEndian) ? Endianness.LittleEndian : Endianness.BigEndian;

        /// <summary>
        /// reverse byte order (16-bit) 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort SwapBytes(ushort value)
        {
            return (ushort)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }

        /// <summary>
        /// reverse byte order (16-bit) 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short SwapBytes(short value)
        {
            return (short)SwapBytes((ushort)value);
        }

        /// <summary>
        /// reverse byte order (32-bit)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SwapBytes(uint value)
        {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }

        /// <summary>
        /// reverse byte order (32-bit)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SwapBytes(int value)
        {
            return (int)SwapBytes((uint)value);
        }

        /// <summary>
        /// reverse byte order (64-bit)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong SwapBytes(ulong value)
        {
            return (value & 0x00000000000000FFUL) << 56 | (value & 0x000000000000FF00UL) << 40 |
                   (value & 0x0000000000FF0000UL) << 24 | (value & 0x00000000FF000000UL) << 8 |
                   (value & 0x000000FF00000000UL) >> 8 | (value & 0x0000FF0000000000UL) >> 24 |
                   (value & 0x00FF000000000000UL) >> 40 | (value & 0xFF00000000000000UL) >> 56;
        }

        /// <summary>
        /// reverse byte order (64-bit)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long SwapBytes(long value)
        {
            return (long)SwapBytes((ulong)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static char SwapBytes(char value)
        {
            char tmp = value;
            ushort* ptr = (ushort*)&tmp;

            ptr[0] = SwapBytes(ptr[0]);
            return tmp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static float SwapBytes(float value)
        {
            float tmp = value;
            uint* ptr = (uint*)&tmp;

            ptr[0] = SwapBytes(ptr[0]);
            return tmp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static double SwapBytes(double value)
        {
            double tmp = value;
            ulong* ptr = (ulong*)&tmp;

            ptr[0] = SwapBytes(ptr[0]);
            return tmp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static decimal SwapBytes(decimal value)
        {
            decimal tmp = value;
            ulong* ptr = (ulong*)&tmp;

            ulong v = ptr[0];
            ptr[0] = SwapBytes(ptr[1]);
            ptr[1] = SwapBytes(v);

            return tmp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void ReverseBytes(void* value, INT count)
        {
            byte* ptr = (byte*)value;
            byte tmp;
            INT lo, hi;

            for (lo = 0, hi = count - 1; hi > lo; lo++, hi--)
            {
                tmp = ptr[lo];
                ptr[lo] = ptr[hi];
                ptr[hi] = tmp;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ReverseBytes(Array value, INT count)
        {
            var srcHdl = GCHandle.Alloc(value, GCHandleType.Pinned);

            try
            {
                unsafe
                {
                    IntPtr srcIntPtr = srcHdl.AddrOfPinnedObject();
                    ReverseBytes(srcIntPtr.ToPointer(), count * value.ElementByteSize());
                }
            }
            finally
            {
                if (srcHdl.IsAllocated) srcHdl.Free();
            }
        }

        /// <summary>
        /// Change byte order of byte array 
        /// </summary>
        /// <param name="value"></param> 
        /// <param name="order"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] GetBytes(this byte[] value, Endianness order)
        {
            if (order != CurrentByteOrder)
                Array.Reverse(value);

            return value;
        }

        /// <summary>
        /// Change byte order of char array 
        /// </summary>
        /// <param name="value"></param> 
        /// <param name="order"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char[] GetChars(this char[] value, Endianness order)
        {
            if (order != CurrentByteOrder)
                Array.Reverse(value);

            return value;
        }

        /// <summary>
        /// Change byte order of string 
        /// </summary>
        /// <param name="value"></param> 
        /// <param name="order"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetString(this string value, Endianness order)
        {
            char[] buf = value.GetChars();

            if (order != CurrentByteOrder)
                Array.Reverse(buf);

            return buf.GetString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char GetChar(this char value, Endianness order)
        {
            return SwapBytes(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short GetShort(this short value, Endianness order)
        {
            return SwapBytes(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort GetUShort(this ushort value, Endianness order)
        {
            return SwapBytes(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetInt(this int value, Endianness order)
        {
            return SwapBytes(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetUInt(this uint value, Endianness order)
        {
            return SwapBytes(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GetLong(this long value, Endianness order)
        {
            return SwapBytes(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong GetULong(this ulong value, Endianness order)
        {
            return SwapBytes(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal GetDecimal(this decimal value, Endianness order)
        {
            return SwapBytes(value);
        }

    }

#pragma warning restore 1591
}