using System.Runtime.CompilerServices;
using Misho.Utils;

namespace System
{
#pragma warning disable 1591

    public static partial class Extensions
    {

        /// <summary>
        /// Change byte order of byte array 
        /// </summary>
        /// <param name="value"></param> 
        /// <param name="order"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ByteOrder(this byte[] value, ByteOrder order)
        {
            if (order != MemoryHelper.CurrentByteOrder)
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
        public static char[] ByteOrder(this char[] value, ByteOrder order)
        {
            if (order != MemoryHelper.CurrentByteOrder)
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
        public static string ByteOrder(this string value, ByteOrder order)
        {
            char[] buf = value.GetChars();

            if (order != MemoryHelper.CurrentByteOrder)
                Array.Reverse(buf);

            return buf.GetString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ByteOrder(this char value, ByteOrder order)
        {
            return (char)ReverseBytes.ByteSwap(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ByteOrder(this short value, ByteOrder order)
        {
            return ReverseBytes.ByteSwap(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ByteOrder(this ushort value, ByteOrder order)
        {
            return ReverseBytes.ByteSwap(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteOrder(this int value, ByteOrder order)
        {
            return ReverseBytes.ByteSwap(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ByteOrder(this uint value, ByteOrder order)
        {
            return ReverseBytes.ByteSwap(value);
        }

    }

#pragma warning restore 1591
}