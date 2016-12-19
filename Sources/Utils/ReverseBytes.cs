using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Misho.Utils
{
    public sealed class ReverseBytes
    {
        /// <summary>
        /// reverse byte order (16-bit) 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ByteSwap(ushort value)
        {
            return (ushort)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }

        /// <summary>
        /// reverse byte order (16-bit) 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ByteSwap(short value)
        {
            return (short)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }

        /// <summary>
        /// reverse byte order (32-bit)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ByteSwap(uint value)
        {
            return (uint)((value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24);
        }

        /// <summary>
        /// reverse byte order (32-bit)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSwap(int value)
        {
            return (int)((value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24);
        }

        /// <summary>
        /// reverse byte order (64-bit)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ByteSwap(ulong value)
        {
            return (ulong)((value & 0x00000000000000FFUL) << 56 | (value & 0x000000000000FF00UL) << 40 |
                   (value & 0x0000000000FF0000UL) << 24 | (value & 0x00000000FF000000UL) << 8 |
                   (value & 0x000000FF00000000UL) >> 8 | (value & 0x0000FF0000000000UL) >> 24 |
                   (value & 0x00FF000000000000UL) >> 40 | (value & 0xFF00000000000000UL) >> 56);
        }

        /// <summary>
        /// reverse byte order (64-bit)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ByteSwap(long value)
        {
            return (long)(((ulong)value & 0x00000000000000FFUL) << 56 | ((ulong)value & 0x000000000000FF00UL) << 40 |
                   ((ulong)value & 0x0000000000FF0000UL) << 24 | ((ulong)value & 0x00000000FF000000UL) << 8 |
                   ((ulong)value & 0x000000FF00000000UL) >> 8 | ((ulong)value & 0x0000FF0000000000UL) >> 24 |
                   ((ulong)value & 0x00FF000000000000UL) >> 40 | ((ulong)value & 0xFF00000000000000UL) >> 56);
        }
    }
}