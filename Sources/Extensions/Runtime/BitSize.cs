using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Misho.Utils;

namespace System
{
    public static partial class Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this Type type)
        {
            if (Type.GetTypeCode(type) == TypeCode.Boolean)
                return 1;
            else
                return Marshal.SizeOf(type) << 3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this bool value)
        {
            return MemoryHelper.BoolSizeInBytes << 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this char value)
        {
            return MemoryHelper.CharSizeInBytes << 3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this sbyte value)
        {
            return MemoryHelper.SByteSizeInBytes << 3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this byte value)
        {
            return MemoryHelper.ByteSizeInBytes << 3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this short value)
        {
            return MemoryHelper.ShortSizeInBytes << 3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this ushort value)
        {
            return MemoryHelper.UShortSizeInBytes << 3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this int value)
        {
            return MemoryHelper.IntSizeInBytes << 3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this uint value)
        {
            return MemoryHelper.UIntSizeInBytes << 3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this long value)
        {
            return MemoryHelper.LongSizeInBytes << 3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this ulong value)
        {
            return MemoryHelper.ULongSizeInBytes << 3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this decimal value)
        {
            return MemoryHelper.DecimalSizeInBytes << 3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this float value)
        {
            return MemoryHelper.FloatSizeInBytes << 3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitSize(this double value)
        {
            return MemoryHelper.DoubleSizeInBytes << 3;
        }
    }
}