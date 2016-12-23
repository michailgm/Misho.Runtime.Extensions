using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Linq;
using System.Security;

namespace Misho.Utils
{
#if !NETCORE && !SILVERLIGHT
    using INT = Int64;
#else
    using INT = Int32;
#endif

    public sealed class MemoryHelper
    {
        public const int BoolSizeInBytes = sizeof(bool);
        public const int CharSizeInBytes = sizeof(char);
        public const int SByteSizeInBytes = sizeof(sbyte);
        public const int ByteSizeInBytes = sizeof(byte);
        public const int ShortSizeInBytes = sizeof(short);
        public const int UShortSizeInBytes = sizeof(ushort);
        public const int IntSizeInBytes = sizeof(int);
        public const int UIntSizeInBytes = sizeof(uint);
        public const int LongSizeInBytes = sizeof(long);
        public const int ULongSizeInBytes = sizeof(ulong);
        public const int DecimalSizeInBytes = sizeof(decimal);
        public const int FloatSizeInBytes = sizeof(float);
        public const int DoubleSizeInBytes = sizeof(double);

        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(void* dest, void* src, INT bytesCount)
        {
            INT i, count;
            INT offset = 0;

            INT block = bytesCount >> 3;

            if (block > 0)
            {
                ulong* pDest = (ulong*)dest;
                ulong* pSrc = (ulong*)src;

                count = block;
                while (count-- > 0)
                {
                    *pDest++ = *pSrc++;
                }

                i = block << 3;
                offset += i;
                bytesCount -= i;
            }

            block = bytesCount >> 2;

            if (block > 0)
            {
                uint* pDest = (uint*)((byte*)dest + offset);
                uint* pSrc = (uint*)((byte*)src + offset);

                count = block;
                while (count-- > 0)
                {
                    *pDest++ = *pSrc++;
                }

                i = block << 2;
                offset += i;
                bytesCount -= i;
            }

            block = bytesCount >> 1;

            if (block > 0)
            {
                ushort* pDest = (ushort*)((byte*)dest + offset);
                ushort* pSrc = (ushort*)((byte*)src + offset);

                count = block;
                while (count-- > 0)
                {
                    *pDest++ = *pSrc++;
                }

                i = block << 1;
                offset += i;
                bytesCount -= i;
            }

            if (bytesCount > 0)
            {

                byte* pDest = (byte*)dest + offset;
                byte* pSrc = (byte*)src + offset;

                while (bytesCount-- > 0)
                {
                    *pDest++ = *pSrc++;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static unsafe void Copy(char[] dest, byte[] src, INT bytesCount)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, bytesCount);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static unsafe void Copy(char[] dest, INT destIndex, byte[] src, INT srcIndex, INT bytesCount)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, bytesCount);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static unsafe void Copy(byte[] dest, char[] src, INT bytesCount)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, bytesCount);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static unsafe void Copy(byte[] dest, INT destIndex, char[] src, INT srcIndex, INT bytesCount)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, bytesCount);
            }
        }

        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static INT Copy(Array dest, INT destIndex, Array src, INT srcIndex, INT srcCount)
        {
            if (src == null)
            {
                throw new ArgumentNullException(nameof(src));
            }

            if (dest == null)
            {
                throw new ArgumentNullException(nameof(dest));
            }

            if (srcCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(srcCount));
            }

            int srcElementByteSize = src.ElementByteSize();
            int destElementByteSize = dest.ElementByteSize();

            INT count = srcCount * srcElementByteSize;

#if !NETCORE && !SILVERLIGHT
            INT srcLength = src.LongLength * srcElementByteSize;
#else
            INT srcLength = src.Length * srcElementByteSize;
#endif

            INT srcOffset = srcIndex * srcElementByteSize;

#if !NETCORE && !SILVERLIGHT
            INT destLength = dest.LongLength * destElementByteSize;
#else
            INT destLength = dest.Length * destElementByteSize;
#endif

            INT destOffset = destIndex * destElementByteSize;

            if ((srcOffset < 0) || (srcOffset > srcLength))
            {
                throw new ArgumentOutOfRangeException(nameof(srcIndex));
            }

            if ((destOffset < 0) || (destOffset > destLength))
            {
                throw new ArgumentOutOfRangeException(nameof(destIndex));
            }

            INT maxSrcCount = srcLength - srcOffset;
            INT maxDestCount = destLength - destOffset;

            INT bytesCount = (new INT[] { count, maxSrcCount, maxDestCount }).Min();

            var srcHdl = GCHandle.Alloc(src, GCHandleType.Pinned);
            var destHdl = GCHandle.Alloc(dest, GCHandleType.Pinned);

            try
            {
                IntPtr srcIntPtr = srcHdl.AddrOfPinnedObject();
                IntPtr destIntPtr = destHdl.AddrOfPinnedObject();

                unsafe
                {
                    byte* srcPtr = ((byte*)srcIntPtr.ToPointer()) + srcOffset;
                    byte* destPtr = ((byte*)destIntPtr.ToPointer()) + destOffset;

                    Copy(destPtr, srcPtr, bytesCount);
                }
            }
            catch
            {
                bytesCount = -1;
            }
            finally
            {
                if (srcHdl.IsAllocated) srcHdl.Free();
                if (destHdl.IsAllocated) destHdl.Free();
            }

            return bytesCount;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static INT Copy(Array dest, INT destIndex, Array src, INT srcIndex)
        {
#if !NETCORE && !SILVERLIGHT
            return Copy(dest, destIndex, src, srcIndex, src.LongLength);
#else
            return Copy(dest, destIndex, src, srcIndex, src.Length);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static INT Copy(Array dest, Array src)
        {
#if !NETCORE && !SILVERLIGHT
            return Copy(dest, 0, src, 0, src.LongLength);
#else
            return Copy(dest, 0, src, 0, src.Length);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(bool[] dest, bool[] src, INT count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(bool[] dest, INT destIndex, bool[] src, INT srcIndex, INT count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(char[] dest, char[] src, INT count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * CharSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(char[] dest, INT destIndex, char[] src, INT srcIndex, INT count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * CharSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(sbyte[] dest, sbyte[] src, INT count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(sbyte[] dest, INT destIndex, sbyte[] src, INT srcIndex, INT count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(byte[] dest, byte[] src, INT count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(byte[] dest, INT destIndex, byte[] src, INT srcIndex, INT count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(short[] dest, short[] src, INT count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * ShortSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(short[] dest, INT destIndex, short[] src, INT srcIndex, INT count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * ShortSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(ushort[] dest, ushort[] src, INT count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * UShortSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(ushort[] dest, INT destIndex, ushort[] src, INT srcIndex, INT count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * UShortSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(int[] dest, int[] src, INT count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * IntSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(int[] dest, INT destIndex, int[] src, INT srcIndex, INT count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * IntSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(uint[] dest, uint[] src, INT count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * UIntSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(uint[] dest, INT destIndex, uint[] src, INT srcIndex, INT count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * UIntSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(long[] dest, long[] src, INT count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * LongSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(long[] dest, INT destIndex, long[] src, INT srcIndex, INT count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * LongSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(ulong[] dest, ulong[] src, INT count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * ULongSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(ulong[] dest, INT destIndex, ulong[] src, INT srcIndex, INT count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * ULongSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(decimal[] dest, decimal[] src, INT count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * DecimalSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(decimal[] dest, INT destIndex, decimal[] src, INT srcIndex, INT count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * DecimalSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(float[] dest, float[] src, INT count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * FloatSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(float[] dest, INT destIndex, float[] src, INT srcIndex, INT count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * FloatSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(double[] dest, double[] src, INT count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * DoubleSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(double[] dest, INT destIndex, double[] src, INT srcIndex, INT count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * DoubleSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(string dest, string src, INT count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * CharSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(string dest, INT destIndex, string src, INT srcIndex, INT count)
        {
            fixed (char* sptr = src)
            fixed (char* dptr = dest)
            {
                void* srcPtr = sptr + (srcIndex * CharSizeInBytes);
                void* destPtr = dptr + (destIndex * CharSizeInBytes);

                Copy(dptr, sptr, count * CharSizeInBytes);
            }
        }
    }
}