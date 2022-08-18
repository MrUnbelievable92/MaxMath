using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="UInt128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 msub(UInt128 a, UInt128 b, UInt128 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="Int128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 msub(Int128 a, Int128 b, Int128 c)
        {
            return (a * b) - c;
        }


        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.float8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 msub(float8 a, float8 b, float8 c)
        {
            // fmsub operations will be chosen if Burst.FloatMode.Fast is selected.

            return (a * b) - c;
        }


        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.uint8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 msub(uint8 a, uint8 b, uint8 c)
        {
            return (a * b) - c;
        }


        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.int8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 msub(int8 a, int8 b, int8 c)
        {
            return (a * b) - c;
        }


        /// <summary>       Returns the result of a multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="byte"/>s.    </summary>
        [return: AssumeRange(0ul, (ulong)byte.MaxValue * byte.MaxValue - byte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static uint msub(byte a, byte b, byte c)
        {
            return ((uint)a * (uint)b) - (uint)c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.byte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 msub(byte2 a, byte2 b, byte2 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.byte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 msub(byte3 a, byte3 b, byte3 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.byte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 msub(byte4 a, byte4 b, byte4 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.byte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 msub(byte8 a, byte8 b, byte8 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.byte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 msub(byte16 a, byte16 b, byte16 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.byte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 msub(byte32 a, byte32 b, byte32 c)
        {
            return (a * b) - c;
        }


        /// <summary>       Returns the result of a multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="sbyte"/>s.    </summary>
        [return: AssumeRange((long)sbyte.MinValue * sbyte.MaxValue - sbyte.MinValue, (long)sbyte.MinValue * sbyte.MinValue - sbyte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static int msub(sbyte a, sbyte b, sbyte c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.sbyte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 msub(sbyte2 a, sbyte2 b, sbyte2 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.sbyte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 msub(sbyte3 a, sbyte3 b, sbyte3 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.sbyte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 msub(sbyte4 a, sbyte4 b, sbyte4 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.sbyte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 msub(sbyte8 a, sbyte8 b, sbyte8 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.sbyte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 msub(sbyte16 a, sbyte16 b, sbyte16 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.sbyte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 msub(sbyte32 a, sbyte32 b, sbyte32 c)
        {
            return (a * b) - c;
        }


        /// <summary>       Returns the result of a multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="ushort"/>s.    </summary>
        [return: AssumeRange(0ul, (ulong)ushort.MaxValue * ushort.MaxValue - ushort.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static uint msub(ushort a, ushort b, ushort c)
        {
            return ((uint)a * (uint)b) - (uint)c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.ushort2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 msub(ushort2 a, ushort2 b, ushort2 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.ushort3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 msub(ushort3 a, ushort3 b, ushort3 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.ushort4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 msub(ushort4 a, ushort4 b, ushort4 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.ushort8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 msub(ushort8 a, ushort8 b, ushort8 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.ushort16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 msub(ushort16 a, ushort16 b, ushort16 c)
        {
            return (a * b) - c;
        }


        /// <summary>       Returns the result of a multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="short"/>s.    </summary>
        [return: AssumeRange((long)short.MinValue * short.MaxValue - short.MinValue, (long)short.MinValue * short.MinValue - short.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static int msub(short a, short b, short c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.short2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 msub(short2 a, short2 b, short2 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.short3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 msub(short3 a, short3 b, short3 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.short4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 msub(short4 a, short4 b, short4 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.short8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 msub(short8 a, short8 b, short8 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.short16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 msub(short16 a, short16 b, short16 c)
        {
            return (a * b) - c;
        }


        /// <summary>       Returns the result of a multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="int"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int msub(int a, int b, int c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="int2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 msub(int2 a, int2 b, int2 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="int3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 msub(int3 a, int3 b, int3 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="int4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 msub(int4 a, int4 b, int4 c)
        {
            return (a * b) - c;
        }


        /// <summary>       Returns the result of a multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="uint"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint msub(uint a, uint b, uint c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="uint2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 msub(uint2 a, uint2 b, uint2 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="uint3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 msub(uint3 a, uint3 b, uint3 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="uint4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 msub(uint4 a, uint4 b, uint4 c)
        {
            return (a * b) - c;
        }


        /// <summary>       Returns the result of a multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="ulong"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong msub(ulong a, ulong b, ulong c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.ulong2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 msub(ulong2 a, ulong2 b, ulong2 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.ulong3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 msub(ulong3 a, ulong3 b, ulong3 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.ulong4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 msub(ulong4 a, ulong4 b, ulong4 c)
        {
            return (a * b) - c;
        }


        /// <summary>       Returns the result of a multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="long"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long msub(long a, long b, long c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.long2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 msub(long2 a, long2 b, long2 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.long3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 msub(long3 a, long3 b, long3 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.long4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 msub(long4 a, long4 b, long4 c)
        {
            return (a * b) - c;
        }


        /// <summary>       Returns the result of a multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="float"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float msub(float a, float b, float c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="float2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 msub(float2 a, float2 b, float2 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="float3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 msub(float3 a, float3 b, float3 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="float4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 msub(float4 a, float4 b, float4 c)
        {
            return (a * b) - c;
        }


        /// <summary>       Returns the result of a multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="double"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double msub(double a, double b, double c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="double2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 msub(double2 a, double2 b, double2 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="double3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 msub(double3 a, double3 b, double3 c)
        {
            return (a * b) - c;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (<paramref name="a"/> <see langword="*" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="double4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 msub(double4 a, double4 b, double4 c)
        {
            return (a * b) - c;
        }
    }
}