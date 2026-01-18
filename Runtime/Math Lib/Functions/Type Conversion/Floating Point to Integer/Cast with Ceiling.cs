using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to an <see cref="sbyte"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ceiltosbyte(quarter x)
        {
            return select((sbyte)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter2"/> to an <see cref="MaxMath.sbyte2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ceiltosbyte(quarter2 x)
        {
            return select((sbyte2)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter3"/> to an <see cref="MaxMath.sbyte3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ceiltosbyte(quarter3 x)
        {
            return select((sbyte3)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter4"/> to an <see cref="MaxMath.sbyte4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ceiltosbyte(quarter4 x)
        {
            return select((sbyte4)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter8"/> to an <see cref="MaxMath.sbyte8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ceiltosbyte(quarter8 x)
        {
            return select((sbyte8)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter16"/> to an <see cref="MaxMath.sbyte16"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ceiltosbyte(quarter16 x)
        {
            return select((sbyte16)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter32"/> to an <see cref="MaxMath.sbyte32"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 ceiltosbyte(quarter32 x)
        {
            return select((sbyte32)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="byte"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ceiltobyte(quarter x)
        {
            return select((byte)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.byte2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ceiltobyte(quarter2 x)
        {
            return select((byte2)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.byte3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ceiltobyte(quarter3 x)
        {
            return select((byte3)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.byte4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ceiltobyte(quarter4 x)
        {
            return select((byte4)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter8"/> to a <see cref="MaxMath.byte8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ceiltobyte(quarter8 x)
        {
            return select((byte8)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter16"/> to a <see cref="MaxMath.byte16"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ceiltobyte(quarter16 x)
        {
            return select((byte16)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter32"/> to a <see cref="MaxMath.byte32"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 ceiltobyte(quarter32 x)
        {
            return select((byte32)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="short"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ceiltoshort(quarter x)
        {
            return select((short)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.short2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ceiltoshort(quarter2 x)
        {
            return select((short2)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.short3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ceiltoshort(quarter3 x)
        {
            return select((short3)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.short4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ceiltoshort(quarter4 x)
        {
            return select((short4)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter8"/> to a <see cref="MaxMath.short8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ceiltoshort(quarter8 x)
        {
            return select((short8)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter16"/> to a <see cref="MaxMath.short16"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ceiltoshort(quarter16 x)
        {
            return select((short16)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="ushort"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ceiltoushort(quarter x)
        {
            return select((ushort)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.ushort2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ceiltoushort(quarter2 x)
        {
            return select((ushort2)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.ushort3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ceiltoushort(quarter3 x)
        {
            return select((ushort3)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.ushort4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ceiltoushort(quarter4 x)
        {
            return select((ushort4)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter8"/> to a <see cref="MaxMath.ushort8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ceiltoushort(quarter8 x)
        {
            return select((ushort8)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter16"/> to a <see cref="MaxMath.ushort16"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 ceiltoushort(quarter16 x)
        {
            return select((ushort16)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to an <see cref="int"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ceiltoint(quarter x)
        {
            return math.select((int)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter2"/> to an <see cref="int2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ceiltoint(quarter2 x)
        {
            return math.select((int2)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter3"/> to an <see cref="int3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ceiltoint(quarter3 x)
        {
            return math.select((int3)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter4"/> to an <see cref="int4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ceiltoint(quarter4 x)
        {
            return math.select((int4)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter8"/> to an <see cref="MaxMath.int8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ceiltoint(quarter8 x)
        {
            return select((int8)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="uint"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ceiltouint(quarter x)
        {
            return math.select((uint)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter2"/> to a <see cref="uint2"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ceiltouint(quarter2 x)
        {
            return math.select((uint2)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter3"/> to a <see cref="uint3"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ceiltouint(quarter3 x)
        {
            return math.select((uint3)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter4"/> to a <see cref="uint4"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ceiltouint(quarter4 x)
        {
            return math.select((uint4)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter8"/> to a <see cref="MaxMath.uint8"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ceiltouint(quarter8 x)
        {
            return select((uint8)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="long"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ceiltolong(quarter x)
        {
            return math.select((long)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.long2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ceiltolong(quarter2 x)
        {
            return select((long2)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.long3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ceiltolong(quarter3 x)
        {
            return select((long3)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.long4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ceiltolong(quarter4 x)
        {
            return select((long4)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="ulong"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ceiltoulong(quarter x)
        {
            return math.select((ulong)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.ulong2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ceiltoulong(quarter2 x)
        {
            return select((ulong2)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.ulong3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ceiltoulong(quarter3 x)
        {
            return select((ulong3)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.ulong4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ceiltoulong(quarter4 x)
        {
            return select((ulong4)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to an <see cref="Int128"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 ceiltoint128(quarter x)
        {
            return select((Int128)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="UInt128"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 ceiltouint128(quarter x)
        {
            return select((UInt128)ceil(x), 16, asbyte(x) == quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="half"/> to an <see cref="sbyte"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ceiltosbyte(half x)
        {
            return (sbyte)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to an <see cref="MaxMath.sbyte2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ceiltosbyte(half2 x)
        {
            return (sbyte2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to an <see cref="MaxMath.sbyte3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ceiltosbyte(half3 x)
        {
            return (sbyte3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to an <see cref="MaxMath.sbyte4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ceiltosbyte(half4 x)
        {
            return (sbyte4)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half8"/> to an <see cref="MaxMath.sbyte8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ceiltosbyte(half8 x)
        {
            return (sbyte8)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half16"/> to an <see cref="MaxMath.sbyte16"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ceiltosbyte(half16 x)
        {
            return (sbyte16)ceil(x);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="byte"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ceiltobyte(half x)
        {
            return (byte)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="MaxMath.byte2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ceiltobyte(half2 x)
        {
            return (byte2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="MaxMath.byte3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ceiltobyte(half3 x)
        {
            return (byte3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="MaxMath.byte4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ceiltobyte(half4 x)
        {
            return (byte4)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half8"/> to a <see cref="MaxMath.byte8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ceiltobyte(half8 x)
        {
            return (byte8)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half16"/> to a <see cref="MaxMath.byte16"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ceiltobyte(half16 x)
        {
            return (byte16)ceil(x);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="short"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ceiltoshort(half x)
        {
            return (short)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="MaxMath.short2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ceiltoshort(half2 x)
        {
            return (short2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="MaxMath.short3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ceiltoshort(half3 x)
        {
            return (short3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="MaxMath.short4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ceiltoshort(half4 x)
        {
            return (short4)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half8"/> to a <see cref="MaxMath.short8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ceiltoshort(half8 x)
        {
            return (short8)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half16"/> to a <see cref="MaxMath.short16"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ceiltoshort(half16 x)
        {
            return (short16)ceil(x);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="ushort"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ceiltoushort(half x)
        {
            return (ushort)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="MaxMath.ushort2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ceiltoushort(half2 x)
        {
            return (ushort2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="MaxMath.ushort3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ceiltoushort(half3 x)
        {
            return (ushort3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="MaxMath.ushort4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ceiltoushort(half4 x)
        {
            return (ushort4)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half8"/> to a <see cref="MaxMath.ushort8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ceiltoushort(half8 x)
        {
            return (ushort8)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half16"/> to a <see cref="MaxMath.ushort16"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 ceiltoushort(half16 x)
        {
            return (ushort16)ceil(x);
        }


        /// <summary>       Converts a <see cref="half"/> to an <see cref="int"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ceiltoint(half x)
        {
            return (int)(float)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to an <see cref="int2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ceiltoint(half2 x)
        {
            return (int2)(float2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to an <see cref="int3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ceiltoint(half3 x)
        {
            return (int3)(float3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to an <see cref="int4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ceiltoint(half4 x)
        {
            return (int4)(float4)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half8"/> to an <see cref="MaxMath.int8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ceiltoint(half8 x)
        {
            return (int8)ceil(x);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="uint"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ceiltouint(half x)
        {
            return (uint)(float)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="uint2"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ceiltouint(half2 x)
        {
            return (uint2)(float2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="uint3"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ceiltouint(half3 x)
        {
            return (uint3)(float3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="uint4"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ceiltouint(half4 x)
        {
            return (uint4)(float4)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.half8"/> to a <see cref="MaxMath.uint8"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ceiltouint(half8 x)
        {
            return (uint8)ceil(x);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="long"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ceiltolong(half x)
        {
            return (long)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="MaxMath.long2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ceiltolong(half2 x)
        {
            return (long2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="MaxMath.long3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ceiltolong(half3 x)
        {
            return (long3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="MaxMath.long4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ceiltolong(half4 x)
        {
            return (long4)ceil(x);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="ulong"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ceiltoulong(half x)
        {
            return (ulong)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="MaxMath.ulong2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ceiltoulong(half2 x)
        {
            return (ulong2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="MaxMath.ulong3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ceiltoulong(half3 x)
        {
            return (ulong3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="MaxMath.ulong4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ceiltoulong(half4 x)
        {
            return (ulong4)ceil(x);
        }


        /// <summary>       Converts a <see cref="half"/> to an <see cref="Int128"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 ceiltoint128(half x)
        {
            return (Int128)ceil(x);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="UInt128"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 ceiltouint128(half x)
        {
            return (UInt128)ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to an <see cref="sbyte"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ceiltosbyte(float x)
        {
            return (sbyte)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to an <see cref="MaxMath.sbyte2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ceiltosbyte(float2 x)
        {
            return (sbyte2)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to an <see cref="MaxMath.sbyte3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ceiltosbyte(float3 x)
        {
            return (sbyte3)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to an <see cref="MaxMath.sbyte4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ceiltosbyte(float4 x)
        {
            return (sbyte4)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.float8"/> to an <see cref="MaxMath.sbyte8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ceiltosbyte(float8 x)
        {
            return (sbyte8)ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="byte"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ceiltobyte(float x)
        {
            return (byte)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="MaxMath.byte2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ceiltobyte(float2 x)
        {
            return (byte2)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="MaxMath.byte3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ceiltobyte(float3 x)
        {
            return (byte3)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="MaxMath.byte4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ceiltobyte(float4 x)
        {
            return (byte4)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.float8"/> to a <see cref="MaxMath.byte8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ceiltobyte(float8 x)
        {
            return (byte8)ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="short"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ceiltoshort(float x)
        {
            return (short)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="MaxMath.short2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ceiltoshort(float2 x)
        {
            return (short2)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="MaxMath.short3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ceiltoshort(float3 x)
        {
            return (short3)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="MaxMath.short4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ceiltoshort(float4 x)
        {
            return (short4)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.float8"/> to a <see cref="MaxMath.short8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ceiltoshort(float8 x)
        {
            return (short8)ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="ushort"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ceiltoushort(float x)
        {
            return (ushort)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="MaxMath.ushort2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ceiltoushort(float2 x)
        {
            return (ushort2)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="MaxMath.ushort3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ceiltoushort(float3 x)
        {
            return (ushort3)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="MaxMath.ushort4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ceiltoushort(float4 x)
        {
            return (ushort4)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.float8"/> to a <see cref="MaxMath.ushort8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ceiltoushort(float8 x)
        {
            return (ushort8)ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to an <see cref="int"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ceiltoint(float x)
        {
            return (int)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to an <see cref="int2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ceiltoint(float2 x)
        {
            return (int2)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to an <see cref="int3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ceiltoint(float3 x)
        {
            return (int3)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to an <see cref="int4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ceiltoint(float4 x)
        {
            return (int4)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.float8"/> to an <see cref="MaxMath.int8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ceiltoint(float8 x)
        {
            return (int8)ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="uint"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ceiltouint(float x)
        {
            return (uint)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="uint2"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ceiltouint(float2 x)
        {
            return (uint2)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="uint3"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ceiltouint(float3 x)
        {
            return (uint3)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="uint4"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ceiltouint(float4 x)
        {
            return (uint4)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="MaxMath.float8"/> to a <see cref="MaxMath.uint8"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ceiltouint(float8 x)
        {
            return (uint8)ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="long"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ceiltolong(float x)
        {
            return (long)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="MaxMath.long2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ceiltolong(float2 x)
        {
            return (long2)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="MaxMath.long3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ceiltolong(float3 x)
        {
            return (long3)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="MaxMath.long4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ceiltolong(float4 x)
        {
            return (long4)math.ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="ulong"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ceiltoulong(float x)
        {
            return (ulong)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="MaxMath.ulong2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ceiltoulong(float2 x)
        {
            return (ulong2)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="MaxMath.ulong3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ceiltoulong(float3 x)
        {
            return (ulong3)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="MaxMath.ulong4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ceiltoulong(float4 x)
        {
            return (ulong4)math.ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to an <see cref="Int128"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 ceiltoint128(float x)
        {
            return (Int128)math.ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="UInt128"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 ceiltouint128(float x)
        {
            return (UInt128)math.ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to an <see cref="sbyte"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ceiltosbyte(double x)
        {
            return (sbyte)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to an <see cref="MaxMath.sbyte2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ceiltosbyte(double2 x)
        {
            return (sbyte2)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to an <see cref="MaxMath.sbyte3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ceiltosbyte(double3 x)
        {
            return (sbyte3)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to an <see cref="MaxMath.sbyte4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ceiltosbyte(double4 x)
        {
            return (sbyte4)math.ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="byte"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ceiltobyte(double x)
        {
            return (byte)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="MaxMath.byte2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ceiltobyte(double2 x)
        {
            return (byte2)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="MaxMath.byte3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ceiltobyte(double3 x)
        {
            return (byte3)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="MaxMath.byte4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ceiltobyte(double4 x)
        {
            return (byte4)math.ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="short"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ceiltoshort(double x)
        {
            return (short)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="MaxMath.short2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ceiltoshort(double2 x)
        {
            return (short2)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="MaxMath.short3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ceiltoshort(double3 x)
        {
            return (short3)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="MaxMath.short4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ceiltoshort(double4 x)
        {
            return (short4)math.ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="ushort"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ceiltoushort(double x)
        {
            return (ushort)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="MaxMath.ushort2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ceiltoushort(double2 x)
        {
            return (ushort2)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="MaxMath.ushort3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ceiltoushort(double3 x)
        {
            return (ushort3)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="MaxMath.ushort4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ceiltoushort(double4 x)
        {
            return (ushort4)math.ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to an <see cref="int"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ceiltoint(double x)
        {
            return (int)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to an <see cref="int2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ceiltoint(double2 x)
        {
            return (int2)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to an <see cref="int3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ceiltoint(double3 x)
        {
            return (int3)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to an <see cref="int4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ceiltoint(double4 x)
        {
            return (int4)math.ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="uint"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ceiltouint(double x)
        {
            return (uint)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="uint2"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ceiltouint(double2 x)
        {
            return (uint2)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="uint3"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ceiltouint(double3 x)
        {
            return (uint3)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="uint4"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ceiltouint(double4 x)
        {
            return (uint4)math.ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="long"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ceiltolong(double x)
        {
            return (long)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="MaxMath.long2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ceiltolong(double2 x)
        {
            return (long2)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="MaxMath.long3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ceiltolong(double3 x)
        {
            return (long3)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="MaxMath.long4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ceiltolong(double4 x)
        {
            return (long4)math.ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="ulong"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ceiltoulong(double x)
        {
            return (ulong)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="MaxMath.ulong2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ceiltoulong(double2 x)
        {
            return (ulong2)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="MaxMath.ulong3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ceiltoulong(double3 x)
        {
            return (ulong3)math.ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="MaxMath.ulong4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ceiltoulong(double4 x)
        {
            return (ulong4)math.ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to an <see cref="Int128"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 ceiltoint128(double x)
        {
            return (Int128)math.ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="UInt128"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 ceiltouint128(double x)
        {
            return (UInt128)math.ceil(x);
        }
    }
}
