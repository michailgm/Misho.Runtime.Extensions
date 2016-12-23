using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace System
{
    public static partial class Extensions
    {
        /// <summary>
        /// Returns the size of an unmanaged type in bytes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SizeOf<T>(this T type)
        {
#if SILVERLIGHT
            return Marshal.SizeOf(type);
#else
            return Marshal.SizeOf<T>();
#endif
        }

        /// <summary>
        /// Returns the unmanaged size of an object of a specified type in bytes
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SizeOf(this object value)
        {
#if SILVERLIGHT
            return Marshal.SizeOf(value);
#else
            Type type = value.GetType();
            return type.SizeOf();
#endif
        }

        /// <summary>
        /// Returns a boolean value indicating whether a type can be evaluated as a number
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNumeric(this Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns a boolean value indicating whether an object can be evaluated as a number
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNumeric(this object obj)
        {
            return (obj == null) ? false : obj.GetType().IsNumeric();
        }
    }
}