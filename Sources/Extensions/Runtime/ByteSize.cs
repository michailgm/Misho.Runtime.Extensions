using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Misho.Utils;

namespace System
{
    public static partial class Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                    return MemoryHelper.ByteSizeInBytes;
                case TypeCode.SByte:
                    return MemoryHelper.SByteSizeInBytes;
                case TypeCode.UInt16:
                    return MemoryHelper.UShortSizeInBytes;
                case TypeCode.UInt32:
                    return MemoryHelper.UIntSizeInBytes;
                case TypeCode.UInt64:
                    return MemoryHelper.ULongSizeInBytes;
                case TypeCode.Int16:
                    return MemoryHelper.ShortSizeInBytes;
                case TypeCode.Int32:
                    return MemoryHelper.IntSizeInBytes;
                case TypeCode.Int64:
                    return MemoryHelper.LongSizeInBytes;
                case TypeCode.Decimal:
                    return MemoryHelper.DecimalSizeInBytes;
                case TypeCode.Double:
                    return MemoryHelper.DoubleSizeInBytes;
                case TypeCode.Single:
                    return MemoryHelper.FloatSizeInBytes;
                case TypeCode.Boolean:
                    return MemoryHelper.BoolSizeInBytes;
                case TypeCode.Char:
                    return MemoryHelper.CharSizeInBytes;
                default:
                    return Marshal.SizeOf(type);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this object value)
        {
            Type type = value.GetType();

            if (TypeCode.String == Type.GetTypeCode(type))
                return (value == null) ? 0 : (value as string).Length * MemoryHelper.CharSizeInBytes;
            else
                return type.ByteSize();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this bool value)
        {
            return MemoryHelper.BoolSizeInBytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this char value)
        {
            return MemoryHelper.CharSizeInBytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this sbyte value)
        {
            return MemoryHelper.SByteSizeInBytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this byte value)
        {
            return MemoryHelper.ByteSizeInBytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this short value)
        {
            return MemoryHelper.ShortSizeInBytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this ushort value)
        {
            return MemoryHelper.UShortSizeInBytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this int value)
        {
            return MemoryHelper.IntSizeInBytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this uint value)
        {
            return MemoryHelper.UIntSizeInBytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this long value)
        {
            return MemoryHelper.LongSizeInBytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this ulong value)
        {
            return MemoryHelper.ULongSizeInBytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this decimal value)
        {
            return MemoryHelper.DecimalSizeInBytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this float value)
        {
            return MemoryHelper.FloatSizeInBytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this double value)
        {
            return MemoryHelper.DoubleSizeInBytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this string value)
        {
            return (value == null) ? 0 : value.Length * MemoryHelper.CharSizeInBytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this char[] value)
        {
            return (value == null) ? 0 : value.Length * MemoryHelper.CharSizeInBytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteSize(this Array array)
        {
            return (array == null) ? 0 : array.Length * array.ElementByteSize();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ElementByteSize(this Array array)
        {
            return (array == null) ? 0 : array.GetType().GetElementType().ByteSize();
        }
    }
}