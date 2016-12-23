using System.Runtime.CompilerServices;
using System.Security;

namespace System
{
    public static partial class Extensions
    {
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