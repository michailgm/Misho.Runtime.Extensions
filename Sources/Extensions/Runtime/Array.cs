using System.Runtime.CompilerServices;
using Misho.Utils;
using System.Text;

namespace System
{
    public static partial class Extensions
    {
        #region GetBytes functions

        /// <summary>
        /// Convert bool value to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] GetBytes(this bool value)
        {
            byte[] buf = new byte[MemoryHelper.BoolSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(bool*)ptr = *(&value);
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
        public static byte[] GetBytes(this char value)
        {
            byte[] buf = new byte[MemoryHelper.CharSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(char*)ptr = *(&value);
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
        public static byte[] GetBytes(this sbyte value)
        {
            byte[] buf = new byte[MemoryHelper.SByteSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(sbyte*)ptr = *(&value);
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
        public static byte[] GetBytes(this byte value)
        {
            byte[] buf = new byte[MemoryHelper.ByteSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *ptr = *(&value);
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
        public static byte[] GetBytes(this short value)
        {
            byte[] buf = new byte[MemoryHelper.ShortSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(short*)ptr = *(&value);
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
        public static byte[] GetBytes(this ushort value)
        {
            byte[] buf = new byte[MemoryHelper.UShortSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(ushort*)ptr = *(&value);
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
        public static byte[] GetBytes(this int value)
        {
            byte[] buf = new byte[MemoryHelper.IntSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(int*)ptr = *(&value);
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
        public static byte[] GetBytes(this uint value)
        {
            byte[] buf = new byte[MemoryHelper.UIntSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(uint*)ptr = *(&value);
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
        public static byte[] GetBytes(this long value)
        {
            byte[] buf = new byte[MemoryHelper.LongSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(long*)ptr = *(&value);
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
        public static byte[] GetBytes(this ulong value)
        {
            byte[] buf = new byte[MemoryHelper.ULongSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(ulong*)ptr = *(&value);
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
        public static byte[] GetBytes(this decimal value)
        {
            byte[] buf = new byte[MemoryHelper.DecimalSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(decimal*)ptr = *(&value);
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
        public static byte[] GetBytes(this float value)
        {
            byte[] buf = new byte[MemoryHelper.FloatSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(float*)ptr = *(&value);
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
        public static byte[] GetBytes(this double value)
        {
            byte[] buf = new byte[MemoryHelper.DoubleSizeInBytes];

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(double*)ptr = *(&value);
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
        public static byte[] GetBytes(this string value)
        {
            if (value == null) return null;

            int length = value.Length;
            byte[] buf = new byte[length * MemoryHelper.CharSizeInBytes];

            unsafe
            {
                fixed (char* src = value)
                fixed (byte* dst = buf)
                {
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
        public static byte[] GetBytes(this string value, int startIndex, int length)
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
                fixed (char* src = value)
                fixed (byte* dst = buf)
                {
                    MemoryHelper.Copy(dst, src + startIndex, buf.Length);
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
        public static byte[] GetBytes(this string value, int startIndex)
        {
            if (value == null)
                return null;
            else
                return GetBytes(value, startIndex, value.Length - startIndex);
        }

        /// <summary>
        /// Convert chars array value to bytes array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] GetBytes(this char[] value)
        {
            if (value == null) return null;

            int length = value.Length;
            byte[] buf = new byte[length * MemoryHelper.CharSizeInBytes];

            unsafe
            {
                fixed (char* src = value)
                fixed (byte* dst = buf)
                {
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
        public static byte[] GetBytes(this char[] value, int startIndex, int length)
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
                fixed (char* src = value)
                fixed (byte* dst = buf)
                {
                    MemoryHelper.Copy(dst, src + startIndex, buf.Length);
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
        public static byte[] GetBytes(this char[] value, int startIndex)
        {
            if (value == null)
                return null;
            else
                return GetBytes(value, startIndex, value.Length - startIndex);
        }

        #endregion

        #region GetBytes functions with Encoding

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] GetBytes(this string value, Encoding encoding)
        {
            if (value == null)
                return null;
            else
                return encoding.GetBytes(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] GetBytes(this string value, int startIndex, Encoding encoding)
        {
            if (value == null)
                return null;
            else
                return encoding.GetBytes(value.GetChars(startIndex, value.Length - startIndex));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] GetBytes(this char[] value, Encoding encoding)
        {
            if (value == null)
                return null;
            else
                return encoding.GetBytes(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] GetBytes(this char[] value, int startIndex, int length, Encoding encoding)
        {
            if (value == null)
                return null;
            else
                return encoding.GetBytes(value, startIndex, length);
        }

        public static byte[] GetBytes(this char[] value, int startIndex, Encoding encoding)
        {
            if (value == null)
                return null;
            else
                return encoding.GetBytes(value, startIndex, value.Length - startIndex);
        }

        #endregion

        #region functions GetChars

        /// <summary>
        /// Convert string value to chars array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char[] GetChars(this string value)
        {
            if (value == null) return null;
            
            int length = value.Length;
            char[] buf = new char[length];

            unsafe
            {
                fixed (char* src = value)
                fixed (char* dst = buf)
                {
                    MemoryHelper.Copy(dst, src, length * MemoryHelper.CharSizeInBytes);
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert string value from startIndex with lenght to chars array
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char[] GetChars(this string value, int startIndex, int length)
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

            char[] buf = new char[length];

            unsafe
            {
                fixed (char* src = value)
                fixed (char* dst = buf)
                {
                    MemoryHelper.Copy(dst, src + startIndex, length * MemoryHelper.CharSizeInBytes);
                }
            }

            return buf;
        }

        /// <summary>
        /// Convert string value from startIndex to end of string into chars array
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char[] GetChars(this string value, int startIndex)
        {
            if (value == null)
                return null;
            else
                return GetChars(value, startIndex, value.Length - startIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char[] GetChars(this byte[] value)
        {
            if (value == null) return null;

            int length = value.Length;
            char[] buf = new char[length / MemoryHelper.CharSizeInBytes];

            unsafe
            {
                fixed (byte* src = value)
                fixed (char* dst = buf)
                {
                    MemoryHelper.Copy(dst, src, length);
                }
            }

            return buf;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char[] GetChars(this byte[] value, int startByteIndex, int byteLength)
        {
            if (value == null) return null;

            if ((startByteIndex < 0) || (startByteIndex > value.Length))
            {
                throw new ArgumentOutOfRangeException(nameof(startByteIndex));
            }

            if ((byteLength < 0) || (byteLength > (value.Length - startByteIndex)))
            {
                throw new ArgumentOutOfRangeException(nameof(byteLength));
            }

            char[] buf = new char[byteLength / MemoryHelper.CharSizeInBytes];

            unsafe
            {
                fixed (byte* src = value)
                fixed (char* dst = buf)
                {
                    MemoryHelper.Copy(dst, src + startByteIndex, buf.Length * MemoryHelper.CharSizeInBytes);
                }
            }

            return buf;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char[] GetChars(this byte[] value, int startIndex)
        {
            if (value == null)
                return null;
            else
                return GetChars(value, startIndex, value.Length - startIndex);
        }

        #endregion

        #region GetChars functions with Encoding

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char[] GetChars(this string value, Encoding encoding)
        {
            if (value == null)
                return null;
            else
                return encoding.GetChars(value.GetBytes());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char[] GetChars(this string value, int startIndex, int length, Encoding encoding)
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

            var index = startIndex * MemoryHelper.CharSizeInBytes;

            return encoding.GetChars(value.GetBytes(index, (length * MemoryHelper.CharSizeInBytes) - index));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char[] GetChars(this string value, int startIndex, Encoding encoding)
        {
            if (value == null) return null;

            var index = startIndex * MemoryHelper.CharSizeInBytes;

            return encoding.GetChars(value.GetBytes(index, (value.Length * MemoryHelper.CharSizeInBytes) - index));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char[] GetChars(this byte[] value, Encoding encoding)
        {
            if (value == null)
                return null;
            else
                return encoding.GetChars(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char[] GetChars(this byte[] value, int startByteIndex, int byteLength, Encoding encoding)
        {
            if (value == null)
                return null;
            else
                return encoding.GetChars(value, startByteIndex, byteLength);
        }

        public static char[] GetChars(this byte[] value, int startByteIndex, Encoding encoding)
        {
            if (value == null)
                return null;
            else
                return encoding.GetChars(value, startByteIndex, value.Length - startByteIndex);
        }
        
        #endregion

        #region functions GetString

        /// <summary>
        /// Convert chars array to string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetString(this char[] value)
        {
            if (value == null)
                return null;
            else
                return new string(value);
        }

        /// <summary>
        /// Convert char array from startIndex with lenght into string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetString(this char[] value, int startIndex, int length)
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

            return new string(value, startIndex, length);
        }

        /// <summary>
        /// Convert char array from startIndex to end of string into string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetString(this char[] value, int startIndex)
        {
            if (value == null)
                return null;
            else
                return new string(value, startIndex, value.Length - startIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetString(this byte[] value)
        {
            if (value == null) return null;

            int length = value.Length;
            char[] buf = new char[length / MemoryHelper.CharSizeInBytes];

            unsafe
            {
                fixed (byte* src = value)
                fixed (char* dst = buf)
                {
                    MemoryHelper.Copy(dst, src, length);
                }
            }

            return new string(buf);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetString(this byte[] value, int startIndex, int length)
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

            char[] buf = new char[length / MemoryHelper.CharSizeInBytes];

            unsafe
            {
                fixed (byte* src = value)
                fixed (char* dst = buf)
                {
                    MemoryHelper.Copy(dst, src + startIndex, buf.Length * MemoryHelper.CharSizeInBytes);
                }
            }

            return new string(buf);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetString(this byte[] value, int startIndex)
        {
            if (value == null)
                return null;
            else
                return GetString(value, startIndex, value.Length - startIndex);
        }

        #endregion

        #region Convert byte array to typed value functions

        /// <summary>
        /// Convert byte array to bool
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetBoolean(this byte[] buf)
        {
            if (buf == null)
                throw new NullReferenceException(nameof(buf));

            bool value;

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(&value) = *(bool*)ptr;
                }
            }

            return value;
        }

        /// <summary>
        /// Convert byte array to sbyte
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte GetSByte(this byte[] buf)
        {
            if (buf == null)
                throw new NullReferenceException(nameof(buf));

            sbyte value;

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(&value) = *(sbyte*)ptr;
                }
            }

            return value;
        }

        /// <summary>
        /// Convert byte array to byte
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte GetByte(this byte[] buf)
        {
            if (buf == null)
                throw new NullReferenceException(nameof(buf));

            byte value;

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(&value) = *ptr;
                }
            }

            return value;
        }

        /// <summary>
        /// Convert byte array to char
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char GetChar(this byte[] buf)
        {
            if (buf == null)
                throw new NullReferenceException(nameof(buf));

            char value;

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(&value) = *(char*)ptr;
                }
            }

            return value;
        }

        /// <summary>
        /// Convert byte array to short
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short GetShort(this byte[] buf)
        {
            if (buf == null)
                throw new NullReferenceException(nameof(buf));

            short value;

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(&value) = *(short*)ptr;
                }
            }

            return value;
        }

        /// <summary>
        /// Convert byte array to ushort
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort GetUShort(this byte[] buf)
        {
            if (buf == null)
                throw new NullReferenceException(nameof(buf));

            ushort value;

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(&value) = *(ushort*)ptr;
                }
            }

            return value;
        }

        /// <summary>
        /// Convert byte array to int
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetInt(this byte[] buf)
        {
            if (buf == null)
                throw new NullReferenceException(nameof(buf));

            int value;

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(&value) = *(int*)ptr;
                }
            }

            return value;
        }

        /// <summary>
        /// Convert byte array to uint
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetUInt(this byte[] buf)
        {
            if (buf == null)
                throw new NullReferenceException(nameof(buf));

            uint value;

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(&value) = *(uint*)ptr;
                }
            }

            return value;
        }

        /// <summary>
        /// Convert byte array to long
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GetLong(this byte[] buf)
        {
            if (buf == null)
                throw new NullReferenceException(nameof(buf));

            long value;

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(&value) = *(long*)ptr;
                }
            }

            return value;
        }

        /// <summary>
        /// Convert byte array to ulong
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong GetULong(this byte[] buf)
        {
            if (buf == null)
                throw new NullReferenceException(nameof(buf));

            ulong value;

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(&value) = *(ulong*)ptr;
                }
            }

            return value;
        }

        /// <summary>
        /// Convert byte array to decimal
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal GetDecimal(this byte[] buf)
        {
            if (buf == null)
                throw new NullReferenceException(nameof(buf));

            decimal value;

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(&value) = *(decimal*)ptr;
                }
            }

            return value;
        }

        /// <summary>
        /// Convert byte array to float 
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetFloat(this byte[] buf)
        {
            if (buf == null)
                throw new NullReferenceException(nameof(buf));

            float value;

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(&value) = *(float*)ptr;
                }
            }

            return value;
        }

        /// <summary>
        /// Convert byte array to double
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetDouble(this byte[] buf)
        {
            if (buf == null)
                throw new NullReferenceException(nameof(buf));

            double value;

            unsafe
            {
                fixed (byte* ptr = buf)
                {
                    *(&value) = *(double*)ptr;
                }
            }

            return value;
        }

        #endregion

    }
}