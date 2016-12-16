using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Linq;
using System.Security;

namespace Misho.Utils
{
    public enum Endian
    {
        Little,
        Big
    }

    public class MemoryHelper
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

        public static readonly Endian CurrentEndian =
            (BitConverter.IsLittleEndian) ? Endian.Little : Endian.Big;

        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(void* dest, void* src, long bytesCount)
        {
            long i, count;
            long offset = 0;

            long block = bytesCount >> 3;

            if (block > 0)
            {
                long* pDest = (long*)dest;
                long* pSrc = (long*)src;

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
        internal static unsafe void Copy(char[] dest, byte[] src, long bytesCount)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, bytesCount);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static unsafe void Copy(char[] dest, long destIndex, byte[] src, long srcIndex, long bytesCount)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, bytesCount);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static unsafe void Copy(byte[] dest, char[] src, long bytesCount)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, bytesCount);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static unsafe void Copy(byte[] dest, long destIndex, char[] src, long srcIndex, long bytesCount)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, bytesCount);
            }
        }

        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Copy(Array dest, long destIndex, Array src, long srcIndex, long srcCount)
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

            long count = srcCount * srcElementByteSize;

            long srcLength = src.LongLength * srcElementByteSize;
            long srcOffset = srcIndex * srcElementByteSize;

            long destLength = dest.LongLength * destElementByteSize;
            long destOffset = destIndex * destElementByteSize;

            if ((srcOffset < 0) || (srcOffset > srcLength))
            {
                throw new ArgumentOutOfRangeException(nameof(srcIndex));
            }

            if ((destOffset < 0) || (destOffset > destLength))
            {
                throw new ArgumentOutOfRangeException(nameof(destIndex));
            }

            long maxSrcCount = srcLength - srcOffset;
            long maxDestCount = destLength - destOffset;

            long bytesCount = (new long[] { count, maxSrcCount, maxDestCount }).Min();

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
        public static long Copy(Array dest, long destIndex, Array src, long srcIndex)
        {
            return Copy(dest, destIndex, src, srcIndex, src.LongLength);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Copy(Array dest, Array src)
        {
            return Copy(dest, 0, src, 0, src.LongLength);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(bool[] dest, bool[] src, long count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(bool[] dest, long destIndex, bool[] src, long srcIndex, long count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(char[] dest, char[] src, long count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * CharSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(char[] dest, long destIndex, char[] src, long srcIndex, long count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * CharSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(sbyte[] dest, sbyte[] src, long count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(sbyte[] dest, long destIndex, sbyte[] src, long srcIndex, long count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(byte[] dest, byte[] src, long count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(byte[] dest, long destIndex, byte[] src, long srcIndex, long count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(short[] dest, short[] src, long count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * ShortSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(short[] dest, long destIndex, short[] src, long srcIndex, long count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * ShortSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(ushort[] dest, ushort[] src, long count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * UShortSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(ushort[] dest, long destIndex, ushort[] src, long srcIndex, long count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * UShortSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(int[] dest, int[] src, long count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * IntSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(int[] dest, long destIndex, int[] src, long srcIndex, long count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * IntSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(uint[] dest, uint[] src, long count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * UIntSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(uint[] dest, long destIndex, uint[] src, long srcIndex, long count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * UIntSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(long[] dest, long[] src, long count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * LongSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(long[] dest, long destIndex, long[] src, long srcIndex, long count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * LongSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(ulong[] dest, ulong[] src, long count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * ULongSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(ulong[] dest, long destIndex, ulong[] src, long srcIndex, long count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * ULongSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(decimal[] dest, decimal[] src, long count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * DecimalSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(decimal[] dest, long destIndex, decimal[] src, long srcIndex, long count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * DecimalSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(float[] dest, float[] src, long count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * FloatSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(float[] dest, long destIndex, float[] src, long srcIndex, long count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * FloatSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(double[] dest, double[] src, long count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * DoubleSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(double[] dest, long destIndex, double[] src, long srcIndex, long count)
        {
            fixed (void* sptr = &src[srcIndex])
            fixed (void* dptr = &dest[destIndex])
            {
                Copy(dptr, sptr, count * DoubleSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(string dest, string src, long count)
        {
            fixed (void* sptr = src)
            fixed (void* dptr = dest)
            {
                Copy(dptr, sptr, count * CharSizeInBytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy(string dest, long destIndex, string src, long srcIndex, long count)
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