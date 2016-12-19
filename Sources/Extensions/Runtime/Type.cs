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
    }
}