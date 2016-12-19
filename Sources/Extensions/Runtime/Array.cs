using System.Runtime.CompilerServices;
using Misho.Utils;

namespace System
{
#pragma warning disable 1591

    public static partial class Extensions
    {
        #region ToBytes functions

        /// <summary>
        /// Convert bool value to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this bool value)
        {
            byte[] buf = new byte[MemoryHelper.BoolSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(bool*)ptr = *(bool*)&value;
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert char value to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this char value)
        {
            byte[] buf = new byte[MemoryHelper.CharSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(char*)ptr = *(char*)&value;
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert sbyte value to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this sbyte value)
        {
            byte[] buf = new byte[MemoryHelper.SByteSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(sbyte*)ptr = *(sbyte*)&value;
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert byte value to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this byte value)
        {
            byte[] buf = new byte[MemoryHelper.ByteSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(byte*)ptr = *(byte*)&value;
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert short value to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this short value)
        {
            byte[] buf = new byte[MemoryHelper.ShortSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(short*)ptr = *(short*)&value;
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert ushort value to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this ushort value)
        {
            byte[] buf = new byte[MemoryHelper.UShortSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(ushort*)ptr = *(ushort*)&value;
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert int value to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this int value)
        {
            byte[] buf = new byte[MemoryHelper.IntSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(int*)ptr = *(int*)&value;
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert int value to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this uint value)
        {
            byte[] buf = new byte[MemoryHelper.UIntSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(uint*)ptr = *(uint*)&value;
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert long value to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this long value)
        {
            byte[] buf = new byte[MemoryHelper.LongSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(long*)ptr = *(long*)&value;
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert ulong value to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this ulong value)
        {
            byte[] buf = new byte[MemoryHelper.ULongSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(ulong*)ptr = *(ulong*)&value;
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert decimal value to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this decimal value)
        {
            byte[] buf = new byte[MemoryHelper.DecimalSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(decimal*)ptr = *(decimal*)&value;
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert float value to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this float value)
        {
            byte[] buf = new byte[MemoryHelper.FloatSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(float*)ptr = *(float*)&value;
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert double value to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this double value)
        {
            byte[] buf = new byte[MemoryHelper.DoubleSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(double*)ptr = *(double*)&value;
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert string value to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this string value)
        {
            if (value == null) return null;

            int length = value.Length;
            byte[] buf = new byte[length * MemoryHelper.CharSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                fixed (char* sptr = value)
                {
                    char* dst = (char*)ptr;
                    char* src = sptr;

                    MemoryHelper.Copy(dst, src, buf.Length);
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert string value from startIndex with lenght to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this string value, int startIndex, int length)
        {
            if (value == null) return null;

            if ((startIndex < 0) || (startIndex > value.Length))
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if ((length < 0) || (length > (value.Length - startIndex)))
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            byte[] buf = new byte[length * MemoryHelper.CharSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                fixed (char* sptr = value)
                {
                    char* dst = (char*)ptr;
                    char* src = sptr + startIndex;

                    MemoryHelper.Copy(dst, src, buf.Length);
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert string value from startIndex to end of string into bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this string value, int startIndex)
        {
            return ToBytes(value, startIndex, value.Length - startIndex);
        }

        /// <summary>
        /// Convert chars array value to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this char[] value)
        {
            if (value == null) return null;

            int length = value.Length;
            byte[] buf = new byte[length * MemoryHelper.CharSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                fixed (char* sptr = value)
                {
                    char* dst = (char*)ptr;
                    char* src = sptr;

                    MemoryHelper.Copy(dst, src, buf.Length);
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert chars array value from startIndex with lenght to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this char[] value, int startIndex, int length)
        {
            if (value == null) return null;

            if ((startIndex < 0) || (startIndex > value.Length))
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if ((length < 0) || (length > (value.Length - startIndex)))
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            byte[] buf = new byte[length * MemoryHelper.CharSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                fixed (char* sptr = value)
                {
                    char* dst = (char*)ptr;
                    char* src = sptr + startIndex;

                    MemoryHelper.Copy(dst, src, buf.Length);
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert chars array value from startIndex to end of source array into bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this char[] value, int startIndex)
        {
            return ToBytes(value, startIndex, value.Length - startIndex);
        }

        #endregion
    }

#pragma warning restore 1591
}