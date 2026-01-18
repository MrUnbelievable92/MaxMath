using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to an <see cref="sbyte"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte floortosbyte(quarter x)
        {
            return select((sbyte)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter2"/> to an <see cref="MaxMath.sbyte2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 floortosbyte(quarter2 x)
        {
            return select((sbyte2)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter3"/> to an <see cref="MaxMath.sbyte3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 floortosbyte(quarter3 x)
        {
            return select((sbyte3)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter4"/> to an <see cref="MaxMath.sbyte4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 floortosbyte(quarter4 x)
        {
            return select((sbyte4)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter8"/> to an <see cref="MaxMath.sbyte8"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 floortosbyte(quarter8 x)
        {
            return select((sbyte8)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter16"/> to an <see cref="MaxMath.sbyte16"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 floortosbyte(quarter16 x)
        {
            return select((sbyte16)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter32"/> to an <see cref="MaxMath.sbyte32"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 floortosbyte(quarter32 x)
        {
            return select((sbyte32)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="byte"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte floortobyte(quarter x)
        {
            return (byte)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.byte2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 floortobyte(quarter2 x)
        {
            return (byte2)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.byte3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 floortobyte(quarter3 x)
        {
            return (byte3)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.byte4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 floortobyte(quarter4 x)
        {
            return (byte4)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter8"/> to a <see cref="MaxMath.byte8"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 floortobyte(quarter8 x)
        {
            return (byte8)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter16"/> to a <see cref="MaxMath.byte16"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 floortobyte(quarter16 x)
        {
            return (byte16)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter32"/> to a <see cref="MaxMath.byte32"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 floortobyte(quarter32 x)
        {
            return (byte32)floor(x);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="short"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short floortoshort(quarter x)
        {
            return select((short)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.short2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 floortoshort(quarter2 x)
        {
            return select((short2)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.short3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 floortoshort(quarter3 x)
        {
            return select((short3)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.short4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 floortoshort(quarter4 x)
        {
            return select((short4)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter8"/> to a <see cref="MaxMath.short8"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 floortoshort(quarter8 x)
        {
            return select((short8)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter16"/> to a <see cref="MaxMath.short16"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 floortoshort(quarter16 x)
        {
            return select((short16)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="ushort"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort floortoushort(quarter x)
        {
            return (ushort)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.ushort2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 floortoushort(quarter2 x)
        {
            return (ushort2)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.ushort3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 floortoushort(quarter3 x)
        {
            return (ushort3)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.ushort4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 floortoushort(quarter4 x)
        {
            return (ushort4)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter8"/> to a <see cref="MaxMath.ushort8"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 floortoushort(quarter8 x)
        {
            return (ushort8)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter16"/> to a <see cref="MaxMath.ushort16"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 floortoushort(quarter16 x)
        {
            return (ushort16)floor(x);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to an <see cref="int"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int floortoint(quarter x)
        {
            return math.select((int)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter2"/> to an <see cref="int2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 floortoint(quarter2 x)
        {
            return math.select((int2)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter3"/> to an <see cref="int3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 floortoint(quarter3 x)
        {
            return math.select((int3)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter4"/> to an <see cref="int4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 floortoint(quarter4 x)
        {
            return math.select((int4)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter8"/> to an <see cref="MaxMath.int8"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 floortoint(quarter8 x)
        {
            return select((int8)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="uint"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint floortouint(quarter x)
        {
            return (uint)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter2"/> to a <see cref="uint2"/> component rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 floortouint(quarter2 x)
        {
            return (uint2)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter3"/> to a <see cref="uint3"/> component rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 floortouint(quarter3 x)
        {
            return (uint3)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter4"/> to a <see cref="uint4"/> component rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 floortouint(quarter4 x)
        {
            return (uint4)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter8"/> to a <see cref="MaxMath.uint8"/> component rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 floortouint(quarter8 x)
        {
            return (uint8)floor(x);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="long"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long floortolong(quarter x)
        {
            return math.select((long)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.long2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 floortolong(quarter2 x)
        {
            return select((long2)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.long3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 floortolong(quarter3 x)
        {
            return select((long3)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.long4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 floortolong(quarter4 x)
        {
            return select((long4)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="ulong"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong floortoulong(quarter x)
        {
            return (ulong)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.ulong2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 floortoulong(quarter2 x)
        {
            return (ulong2)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.ulong3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 floortoulong(quarter3 x)
        {
            return (ulong3)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.ulong4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 floortoulong(quarter4 x)
        {
            return (ulong4)floor(x);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to an <see cref="Int128"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 floortoint128(quarter x)
        {
            return select((Int128)floor(x), -16, asbyte(x) == quarter.MinValue.value);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="UInt128"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 floortouint128(quarter x)
        {
            return (UInt128)floor(x);
        }


        /// <summary>       Converts a <see cref="half"/> to an <see cref="sbyte"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte floortosbyte(half x)
        {
            return (sbyte)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to an <see cref="MaxMath.sbyte2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 floortosbyte(half2 x)
        {
            return (sbyte2)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to an <see cref="MaxMath.sbyte3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 floortosbyte(half3 x)
        {
            return (sbyte3)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to an <see cref="MaxMath.sbyte4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 floortosbyte(half4 x)
        {
            return (sbyte4)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half8"/> to an <see cref="MaxMath.sbyte8"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 floortosbyte(half8 x)
        {
            return (sbyte8)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half16"/> to an <see cref="MaxMath.sbyte16"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 floortosbyte(half16 x)
        {
            return (sbyte16)floor(x);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="byte"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte floortobyte(half x)
        {
            return (byte)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="MaxMath.byte2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 floortobyte(half2 x)
        {
            return (byte2)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="MaxMath.byte3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 floortobyte(half3 x)
        {
            return (byte3)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="MaxMath.byte4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 floortobyte(half4 x)
        {
            return (byte4)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half8"/> to a <see cref="MaxMath.byte8"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 floortobyte(half8 x)
        {
            return (byte8)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half16"/> to a <see cref="MaxMath.byte16"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 floortobyte(half16 x)
        {
            return (byte16)floor(x);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="short"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short floortoshort(half x)
        {
            return (short)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="MaxMath.short2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 floortoshort(half2 x)
        {
            return (short2)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="MaxMath.short3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 floortoshort(half3 x)
        {
            return (short3)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="MaxMath.short4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 floortoshort(half4 x)
        {
            return (short4)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half8"/> to a <see cref="MaxMath.short8"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 floortoshort(half8 x)
        {
            return (short8)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half16"/> to a <see cref="MaxMath.short16"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 floortoshort(half16 x)
        {
            return (short16)floor(x);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="ushort"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort floortoushort(half x)
        {
            return (ushort)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="MaxMath.ushort2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 floortoushort(half2 x)
        {
            return (ushort2)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="MaxMath.ushort3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 floortoushort(half3 x)
        {
            return (ushort3)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="MaxMath.ushort4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 floortoushort(half4 x)
        {
            return (ushort4)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half8"/> to a <see cref="MaxMath.ushort8"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 floortoushort(half8 x)
        {
            return (ushort8)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half16"/> to a <see cref="MaxMath.ushort16"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 floortoushort(half16 x)
        {
            return (ushort16)floor(x);
        }


        /// <summary>       Converts a <see cref="half"/> to an <see cref="int"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int floortoint(half x)
        {
            return (int)(float)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to an <see cref="int2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 floortoint(half2 x)
        {
            return (int2)(float2)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to an <see cref="int3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 floortoint(half3 x)
        {
            return (int3)(float3)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to an <see cref="int4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 floortoint(half4 x)
        {
            return (int4)(float4)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half8"/> to an <see cref="MaxMath.int8"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 floortoint(half8 x)
        {
            return (int8)floor(x);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="uint"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint floortouint(half x)
        {
            return (uint)(float)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="uint2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 floortouint(half2 x)
        {
            return (uint2)(float2)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="uint3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 floortouint(half3 x)
        {
            return (uint3)(float3)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="uint4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 floortouint(half4 x)
        {
            return (uint4)(float4)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half8"/> to a <see cref="MaxMath.uint8"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 floortouint(half8 x)
        {
            return (uint8)floor(x);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="long"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long floortolong(half x)
        {
            return (long)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="MaxMath.long2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 floortolong(half2 x)
        {
            return (long2)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="MaxMath.long3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 floortolong(half3 x)
        {
            return (long3)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="MaxMath.long4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 floortolong(half4 x)
        {
            return (long4)floor(x);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="ulong"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong floortoulong(half x)
        {
            return (ulong)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="MaxMath.ulong2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 floortoulong(half2 x)
        {
            return (ulong2)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="MaxMath.ulong3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 floortoulong(half3 x)
        {
            return (ulong3)floor(x);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="MaxMath.ulong4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 floortoulong(half4 x)
        {
            return (ulong4)floor(x);
        }


        /// <summary>       Converts a <see cref="half"/> to an <see cref="Int128"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 floortoint128(half x)
        {
            return (Int128)floor(x);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="UInt128"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 floortouint128(half x)
        {
            return (UInt128)floor(x);
        }


        /// <summary>       Converts a <see cref="float"/> to an <see cref="sbyte"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte floortosbyte(float x)
        {
            return (sbyte)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to an <see cref="MaxMath.sbyte2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 floortosbyte(float2 x)
        {
            return (sbyte2)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to an <see cref="MaxMath.sbyte3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 floortosbyte(float3 x)
        {
            return (sbyte3)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to an <see cref="MaxMath.sbyte4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 floortosbyte(float4 x)
        {
            return (sbyte4)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.float8"/> to an <see cref="MaxMath.sbyte8"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 floortosbyte(float8 x)
        {
            return (sbyte8)floor(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="byte"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte floortobyte(float x)
        {
            return (byte)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="MaxMath.byte2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 floortobyte(float2 x)
        {
            return (byte2)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="MaxMath.byte3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 floortobyte(float3 x)
        {
            return (byte3)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="MaxMath.byte4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 floortobyte(float4 x)
        {
            return (byte4)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.float8"/> to a <see cref="MaxMath.byte8"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 floortobyte(float8 x)
        {
            return (byte8)floor(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="short"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short floortoshort(float x)
        {
            return (short)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="MaxMath.short2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 floortoshort(float2 x)
        {
            return (short2)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="MaxMath.short3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 floortoshort(float3 x)
        {
            return (short3)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="MaxMath.short4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 floortoshort(float4 x)
        {
            return (short4)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.float8"/> to a <see cref="MaxMath.short8"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 floortoshort(float8 x)
        {
            return (short8)floor(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="ushort"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort floortoushort(float x)
        {
            return (ushort)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="MaxMath.ushort2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 floortoushort(float2 x)
        {
            return (ushort2)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="MaxMath.ushort3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 floortoushort(float3 x)
        {
            return (ushort3)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="MaxMath.ushort4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 floortoushort(float4 x)
        {
            return (ushort4)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.float8"/> to a <see cref="MaxMath.ushort8"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 floortoushort(float8 x)
        {
            return (ushort8)floor(x);
        }


        /// <summary>       Converts a <see cref="float"/> to an <see cref="int"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int floortoint(float x)
        {
            return (int)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to an <see cref="int2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 floortoint(float2 x)
        {
            return (int2)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to an <see cref="int3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 floortoint(float3 x)
        {
            return (int3)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to an <see cref="int4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 floortoint(float4 x)
        {
            return (int4)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.float8"/> to an <see cref="MaxMath.int8"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 floortoint(float8 x)
        {
            return (int8)floor(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="uint"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint floortouint(float x)
        {
            return (uint)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="uint2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 floortouint(float2 x)
        {
            return (uint2)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="uint3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 floortouint(float3 x)
        {
            return (uint3)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="uint4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 floortouint(float4 x)
        {
            return (uint4)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.float8"/> to a <see cref="MaxMath.uint8"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 floortouint(float8 x)
        {
            return (uint8)floor(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="long"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long floortolong(float x)
        {
            return (long)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="MaxMath.long2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 floortolong(float2 x)
        {
            return (long2)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="MaxMath.long3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 floortolong(float3 x)
        {
            return (long3)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="MaxMath.long4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 floortolong(float4 x)
        {
            return (long4)math.floor(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="ulong"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong floortoulong(float x)
        {
            return (ulong)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="MaxMath.ulong2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 floortoulong(float2 x)
        {
            return (ulong2)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="MaxMath.ulong3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 floortoulong(float3 x)
        {
            return (ulong3)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="MaxMath.ulong4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 floortoulong(float4 x)
        {
            return (ulong4)math.floor(x);
        }


        /// <summary>       Converts a <see cref="float"/> to an <see cref="Int128"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 floortoint128(float x)
        {
            return (Int128)math.floor(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="UInt128"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 floortouint128(float x)
        {
            return (UInt128)math.floor(x);
        }


        /// <summary>       Converts a <see cref="double"/> to an <see cref="sbyte"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte floortosbyte(double x)
        {
            return (sbyte)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to an <see cref="MaxMath.sbyte2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 floortosbyte(double2 x)
        {
            return (sbyte2)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to an <see cref="MaxMath.sbyte3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 floortosbyte(double3 x)
        {
            return (sbyte3)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to an <see cref="MaxMath.sbyte4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 floortosbyte(double4 x)
        {
            return (sbyte4)math.floor(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="byte"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte floortobyte(double x)
        {
            return (byte)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="MaxMath.byte2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 floortobyte(double2 x)
        {
            return (byte2)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="MaxMath.byte3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 floortobyte(double3 x)
        {
            return (byte3)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="MaxMath.byte4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 floortobyte(double4 x)
        {
            return (byte4)math.floor(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="short"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short floortoshort(double x)
        {
            return (short)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="MaxMath.short2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 floortoshort(double2 x)
        {
            return (short2)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="MaxMath.short3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 floortoshort(double3 x)
        {
            return (short3)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="MaxMath.short4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 floortoshort(double4 x)
        {
            return (short4)math.floor(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="ushort"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort floortoushort(double x)
        {
            return (ushort)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="MaxMath.ushort2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 floortoushort(double2 x)
        {
            return (ushort2)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="MaxMath.ushort3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 floortoushort(double3 x)
        {
            return (ushort3)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="MaxMath.ushort4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 floortoushort(double4 x)
        {
            return (ushort4)math.floor(x);
        }


        /// <summary>       Converts a <see cref="double"/> to an <see cref="int"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int floortoint(double x)
        {
            return (int)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to an <see cref="int2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 floortoint(double2 x)
        {
            return (int2)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to an <see cref="int3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 floortoint(double3 x)
        {
            return (int3)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to an <see cref="int4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 floortoint(double4 x)
        {
            return (int4)math.floor(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="uint"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint floortouint(double x)
        {
            return (uint)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="uint2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 floortouint(double2 x)
        {
            return (uint2)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="uint3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 floortouint(double3 x)
        {
            return (uint3)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="uint4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 floortouint(double4 x)
        {
            return (uint4)math.floor(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="long"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long floortolong(double x)
        {
            return (long)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="MaxMath.long2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 floortolong(double2 x)
        {
            return (long2)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="MaxMath.long3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 floortolong(double3 x)
        {
            return (long3)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="MaxMath.long4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 floortolong(double4 x)
        {
            return (long4)math.floor(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="ulong"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong floortoulong(double x)
        {
            return (ulong)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="MaxMath.ulong2"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 floortoulong(double2 x)
        {
            return (ulong2)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="MaxMath.ulong3"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 floortoulong(double3 x)
        {
            return (ulong3)math.floor(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="MaxMath.ulong4"/> component while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 floortoulong(double4 x)
        {
            return (ulong4)math.floor(x);
        }


        /// <summary>       Converts a <see cref="double"/> to an <see cref="Int128"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 floortoint128(double x)
        {
            return (Int128)math.floor(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="UInt128"/> while rounding towards negative infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 floortouint128(double x)
        {
            return (UInt128)math.floor(x);
        }
    }
}
