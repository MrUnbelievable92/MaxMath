using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>		Returns the long2x2 transposition of a long2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 transpose(long2x2 v)
        {
            return new long2x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y);
        }

        /// <summary>		Returns the long3x2 transposition of a long2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 transpose(long2x3 v)
        {
            return new long3x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y,
                v.c2.x, v.c2.y);
        }

        /// <summary>		Returns the long4x2 transposition of a long2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 transpose(long2x4 v)
        {
            return new long4x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y,
                v.c2.x, v.c2.y,
                v.c3.x, v.c3.y);
        }

        /// <summary>		Returns the long2x3 transposition of a long3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 transpose(long3x2 v)
        {
            return new long2x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z);
        }

        /// <summary>		Returns the long3x3 transposition of a long3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x3 transpose(long3x3 v)
        {
            return new long3x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z,
                v.c2.x, v.c2.y, v.c2.z);
        }

        /// <summary>		Returns the long4x3 transposition of a long3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 transpose(long3x4 v)
        {
            return new long4x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z,
                v.c2.x, v.c2.y, v.c2.z,
                v.c3.x, v.c3.y, v.c3.z);
        }

        /// <summary>		Returns the long2x4 transposition of a long4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 transpose(long4x2 v)
        {
            return new long2x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w);
        }

        /// <summary>		Returns the long3x4 transposition of a long4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x4 transpose(long4x3 v)
        {
            return new long3x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                v.c2.x, v.c2.y, v.c2.z, v.c2.w);
        }

        /// <summary>		Returns the long4x4 transposition of a long4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x4 transpose(long4x4 v)
        {
            return new long4x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                v.c2.x, v.c2.y, v.c2.z, v.c2.w,
                v.c3.x, v.c3.y, v.c3.z, v.c3.w);
        }


        /// <summary>		Returns the ulong2x2 transposition of a ulong2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 transpose(ulong2x2 v)
        {
            return new ulong2x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y);
        }

        /// <summary>		Returns the ulong3x2 transposition of a ulong2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 transpose(ulong2x3 v)
        {
            return new ulong3x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y,
                v.c2.x, v.c2.y);
        }

        /// <summary>		Returns the ulong4x2 transposition of a ulong2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 transpose(ulong2x4 v)
        {
            return new ulong4x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y,
                v.c2.x, v.c2.y,
                v.c3.x, v.c3.y);
        }

        /// <summary>		Returns the ulong2x3 transposition of a ulong3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 transpose(ulong3x2 v)
        {
            return new ulong2x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z);
        }

        /// <summary>		Returns the ulong3x3 transposition of a ulong3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 transpose(ulong3x3 v)
        {
            return new ulong3x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z,
                v.c2.x, v.c2.y, v.c2.z);
        }

        /// <summary>		Returns the ulong4x3 transposition of a ulong3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 transpose(ulong3x4 v)
        {
            return new ulong4x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z,
                v.c2.x, v.c2.y, v.c2.z,
                v.c3.x, v.c3.y, v.c3.z);
        }

        /// <summary>		Returns the ulong2x4 transposition of a ulong4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x4 transpose(ulong4x2 v)
        {
            return new ulong2x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w);
        }

        /// <summary>		Returns the ulong3x4 transposition of a ulong4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 transpose(ulong4x3 v)
        {
            return new ulong3x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                v.c2.x, v.c2.y, v.c2.z, v.c2.w);
        }

        /// <summary>		Returns the ulong4x4 transposition of a ulong4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 transpose(ulong4x4 v)
        {
            return new ulong4x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                v.c2.x, v.c2.y, v.c2.z, v.c2.w,
                v.c3.x, v.c3.y, v.c3.z, v.c3.w);
        }


        /// <summary>		Returns the short2x2 transposition of a short2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 transpose(short2x2 v)
        {
            return new short2x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y);
        }

        /// <summary>		Returns the short3x2 transposition of a short2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x2 transpose(short2x3 v)
        {
            return new short3x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y,
                v.c2.x, v.c2.y);
        }

        /// <summary>		Returns the short4x2 transposition of a short2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 transpose(short2x4 v)
        {
            return new short4x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y,
                v.c2.x, v.c2.y,
                v.c3.x, v.c3.y);
        }

        /// <summary>		Returns the short2x3 transposition of a short3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 transpose(short3x2 v)
        {
            return new short2x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z);
        }

        /// <summary>		Returns the short3x3 transposition of a short3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 transpose(short3x3 v)
        {
            return new short3x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z,
                v.c2.x, v.c2.y, v.c2.z);
        }

        /// <summary>		Returns the short4x3 transposition of a short3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 transpose(short3x4 v)
        {
            return new short4x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z,
                v.c2.x, v.c2.y, v.c2.z,
                v.c3.x, v.c3.y, v.c3.z);
        }

        /// <summary>		Returns the short2x4 transposition of a short4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 transpose(short4x2 v)
        {
            return new short2x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w);
        }

        /// <summary>		Returns the short3x4 transposition of a short4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x4 transpose(short4x3 v)
        {
            return new short3x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                v.c2.x, v.c2.y, v.c2.z, v.c2.w);
        }

        /// <summary>		Returns the short4x4 transposition of a short4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x4 transpose(short4x4 v)
        {
            return new short4x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                v.c2.x, v.c2.y, v.c2.z, v.c2.w,
                v.c3.x, v.c3.y, v.c3.z, v.c3.w);
        }


        /// <summary>		Returns the ushort2x2 transposition of a ushort2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x2 transpose(ushort2x2 v)
        {
            return new ushort2x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y);
        }

        /// <summary>		Returns the ushort3x2 transposition of a ushort2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 transpose(ushort2x3 v)
        {
            return new ushort3x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y,
                v.c2.x, v.c2.y);
        }

        /// <summary>		Returns the ushort4x2 transposition of a ushort2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 transpose(ushort2x4 v)
        {
            return new ushort4x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y,
                v.c2.x, v.c2.y,
                v.c3.x, v.c3.y);
        }

        /// <summary>		Returns the ushort2x3 transposition of a ushort3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 transpose(ushort3x2 v)
        {
            return new ushort2x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z);
        }

        /// <summary>		Returns the ushort3x3 transposition of a ushort3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 transpose(ushort3x3 v)
        {
            return new ushort3x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z,
                v.c2.x, v.c2.y, v.c2.z);
        }

        /// <summary>		Returns the ushort4x3 transposition of a ushort3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 transpose(ushort3x4 v)
        {
            return new ushort4x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z,
                v.c2.x, v.c2.y, v.c2.z,
                v.c3.x, v.c3.y, v.c3.z);
        }

        /// <summary>		Returns the ushort2x4 transposition of a ushort4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 transpose(ushort4x2 v)
        {
            return new ushort2x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w);
        }

        /// <summary>		Returns the ushort3x4 transposition of a ushort4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x4 transpose(ushort4x3 v)
        {
            return new ushort3x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                v.c2.x, v.c2.y, v.c2.z, v.c2.w);
        }

        /// <summary>		Returns the ushort4x4 transposition of a ushort4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x4 transpose(ushort4x4 v)
        {
            return new ushort4x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                v.c2.x, v.c2.y, v.c2.z, v.c2.w,
                v.c3.x, v.c3.y, v.c3.z, v.c3.w);
        }


        /// <summary>		Returns the sbyte2x2 transposition of an sbyte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 transpose(sbyte2x2 v)
        {
            return new sbyte2x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y);
        }

        /// <summary>		Returns the sbyte3x2 transposition of an sbyte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x2 transpose(sbyte2x3 v)
        {
            return new sbyte3x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y,
                v.c2.x, v.c2.y);
        }

        /// <summary>		Returns the sbyte4x2 transposition of an sbyte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 transpose(sbyte2x4 v)
        {
            return new sbyte4x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y,
                v.c2.x, v.c2.y,
                v.c3.x, v.c3.y);
        }

        /// <summary>		Returns the sbyte2x3 transposition of an sbyte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x3 transpose(sbyte3x2 v)
        {
            return new sbyte2x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z);
        }

        /// <summary>		Returns the sbyte3x3 transposition of an sbyte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x3 transpose(sbyte3x3 v)
        {
            return new sbyte3x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z,
                v.c2.x, v.c2.y, v.c2.z);
        }

        /// <summary>		Returns the sbyte4x3 transposition of an sbyte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x3 transpose(sbyte3x4 v)
        {
            return new sbyte4x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z,
                v.c2.x, v.c2.y, v.c2.z,
                v.c3.x, v.c3.y, v.c3.z);
        }

        /// <summary>		Returns the sbyte2x4 transposition of an sbyte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x4 transpose(sbyte4x2 v)
        {
            return new sbyte2x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w);
        }

        /// <summary>		Returns the sbyte3x4 transposition of an sbyte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 transpose(sbyte4x3 v)
        {
            return new sbyte3x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                v.c2.x, v.c2.y, v.c2.z, v.c2.w);
        }

        /// <summary>		Returns the sbyte4x4 transposition of an sbyte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 transpose(sbyte4x4 v)
        {
            return new sbyte4x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                v.c2.x, v.c2.y, v.c2.z, v.c2.w,
                v.c3.x, v.c3.y, v.c3.z, v.c3.w);
        }


        /// <summary>		Returns the byte2x2 transposition of a byte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x2 transpose(byte2x2 v)
        {
            return new byte2x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y);
        }

        /// <summary>		Returns the byte3x2 transposition of a byte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x2 transpose(byte2x3 v)
        {
            return new byte3x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y,
                v.c2.x, v.c2.y);
        }

        /// <summary>		Returns the byte4x2 transposition of a byte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 transpose(byte2x4 v)
        {
            return new byte4x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y,
                v.c2.x, v.c2.y,
                v.c3.x, v.c3.y);
        }

        /// <summary>		Returns the byte2x3 transposition of a byte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x3 transpose(byte3x2 v)
        {
            return new byte2x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z);
        }

        /// <summary>		Returns the byte3x3 transposition of a byte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 transpose(byte3x3 v)
        {
            return new byte3x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z,
                v.c2.x, v.c2.y, v.c2.z);
        }

        /// <summary>		Returns the byte4x3 transposition of a byte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 transpose(byte3x4 v)
        {
            return new byte4x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z,
                v.c2.x, v.c2.y, v.c2.z,
                v.c3.x, v.c3.y, v.c3.z);
        }

        /// <summary>		Returns the byte2x4 transposition of a byte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 transpose(byte4x2 v)
        {
            return new byte2x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w);
        }

        /// <summary>		Returns the byte3x4 transposition of a byte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x4 transpose(byte4x3 v)
        {
            return new byte3x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                v.c2.x, v.c2.y, v.c2.z, v.c2.w);
        }

        /// <summary>		Returns the byte4x4 transposition of a byte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x4 transpose(byte4x4 v)
        {
            return new byte4x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                v.c2.x, v.c2.y, v.c2.z, v.c2.w,
                v.c3.x, v.c3.y, v.c3.z, v.c3.w);
        }
    }
}