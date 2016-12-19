using System.Runtime.CompilerServices;
using Misho.Utils;

namespace System
{
    public static partial class Extensions
    {
        /// <summary>
        /// Return size in bits of type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this Type type)
        {
            if (Type.GetTypeCode(type) == TypeCode.Boolean)
                return 1;
            else
                return type.SizeOf() << 3;
        }

        /// <summary>
        /// Return size in bits of bool
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this bool value)
        {
            return MemoryHelper.BoolSizeInBytes << 0;
        }

        /// <summary>
        /// Return size in bits of char
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this char value)
        {
            return MemoryHelper.CharSizeInBytes << 3;
        }

        /// <summary>
        /// Return size in bits of sbyte
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this sbyte value)
        {
            return MemoryHelper.SByteSizeInBytes << 3;
        }

        /// <summary>
        /// Return size in bits of byte
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this byte value)
        {
            return MemoryHelper.ByteSizeInBytes << 3;
        }

        /// <summary>
        /// Return size in bits of short
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this short value)
        {
            return MemoryHelper.ShortSizeInBytes << 3;
        }

        /// <summary>
        /// Return size in bits of ushort
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this ushort value)
        {
            return MemoryHelper.UShortSizeInBytes << 3;
        }

        /// <summary>
        /// Return size in bits of int
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this int value)
        {
            return MemoryHelper.IntSizeInBytes << 3;
        }

        /// <summary>
        /// Return size in bits of uint
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this uint value)
        {
            return MemoryHelper.UIntSizeInBytes << 3;
        }

        /// <summary>
        /// Return size in bits of long
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this long value)
        {
            return MemoryHelper.LongSizeInBytes << 3;
        }

        /// <summary>
        /// Return size in bits of ulong
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this ulong value)
        {
            return MemoryHelper.ULongSizeInBytes << 3;
        }

        /// <summary>
        /// Return size in bits of decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this decimal value)
        {
            return MemoryHelper.DecimalSizeInBytes << 3;
        }

        /// <summary>
        /// Return size in bits of float
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this float value)
        {
            return MemoryHelper.FloatSizeInBytes << 3;
        }

        /// <summary>
        /// Return size in bits of double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this double value)
        {
            return MemoryHelper.DoubleSizeInBytes << 3;
        }
    }
}