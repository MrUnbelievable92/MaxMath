using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Converts a <see cref="bool"/> to its <see cref="UInt128"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 touint128safe(bool a)
        {
            return tobytesafe(a);
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="Int128"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 toint128safe(bool a)
        {
            return tobytesafe(a);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="byte"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobytesafe(bool a)
        {
            a = *(byte*)&a != 0;

            return *(byte*)&a;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.byte2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesafe(bool2 x) => (byte2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.byte3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesafe(bool3 x) => (byte3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.byte4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesafe(bool4 x) => (byte4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a byte6 vector. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesafe(bool8 x) => (byte8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.byte16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesafe(bool16 x) => (byte16)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool32"/> to its integer representation as a <see cref="MaxMath.byte32"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobytesafe(bool32 x) => (byte32)x;


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="sbyte"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbytesafe(bool a)
        {
            return (sbyte)tobytesafe(a);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.sbyte2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesafe(bool2 x) => (sbyte2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.sbyte3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesafe(bool3 x) => (sbyte3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.sbyte4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesafe(bool4 x) => (sbyte4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.sbyte8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesafe(bool8 x) => (sbyte8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as an <see cref="MaxMath.sbyte16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesafe(bool16 x) => (sbyte16)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool32"/> to its integer representation as an <see cref="MaxMath.sbyte32"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbytesafe(bool32 x) => (sbyte32)x;


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="ushort"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushortsafe(bool a)
        {
            return tobytesafe(a);
        }
        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ushort2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushortsafe(bool2 x) => (ushort2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ushort3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushortsafe(bool3 x) => (ushort3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ushort4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushortsafe(bool4 x) => (ushort4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.ushort8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsafe(bool8 x) => (ushort8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.ushort16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushortsafe(bool16 x) => (ushort16)x;


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="short"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshortsafe(bool a)
        {
            return tobytesafe(a);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.short2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshortsafe(bool2 x) => (short2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.short3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshortsafe(bool3 x) => (short3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.short4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshortsafe(bool4 x) => (short4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.short8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsafe(bool8 x) => (short8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.short16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshortsafe(bool16 x) => (short16)x;


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="uint"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touintsafe(bool a)
        {
            return tobytesafe(a);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.uint2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touintsafe(bool2 x) => (uint2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.uint3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touintsafe(bool3 x) => (uint3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.uint4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touintsafe(bool4 x) => (uint4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.uint8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touintsafe(bool8 x) => (uint8)x;


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="int"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int tointsafe(bool a)
        {
            return tobytesafe(a);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.int2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tointsafe(bool2 x) => (int2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.int3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tointsafe(bool3 x) => (int3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.int4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tointsafe(bool4 x) => (int4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.int8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tointsafe(bool8 x) => (int8)x;


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="ulong"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong toulongsafe(bool a)
        {
            return tobytesafe(a);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ulong2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulongsafe(bool2 x) => (ulong2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ulong3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulongsafe(bool3 x) => (ulong3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ulong4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulongsafe(bool4 x) => (ulong4)x;


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="long"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long tolongsafe(bool a)
        {
            return tobytesafe(a);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.long2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolongsafe(bool2 x) => (long2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.long3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolongsafe(bool3 x) => (long3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.long4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolongsafe(bool4 x) => (long4)x;


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="MaxMath.quarter"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquartersafe(bool a)
        {
            return asquarter((byte)(-tosbytesafe(a) & ((quarter)1f).value));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.quarter2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersafe(bool2 x) => (quarter2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.quarter3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersafe(bool3 x) => (quarter3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.quarter4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersafe(bool4 x) => (quarter4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.quarter8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquartersafe(bool8 x) => (quarter8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its floating point representation as a <see cref="MaxMath.quarter16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 toquartersafe(bool16 x) => (quarter16)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool32"/> to its floating point representation as a <see cref="MaxMath.quarter32"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 toquartersafe(bool32 x) => (quarter32)x;


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="MaxMath.half"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfsafe(bool a)
        {
            return new half { value = (ushort)(-tosbytesafe(a) & ((half)1f).value) };
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.half2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfsafe(bool2 x) => (half2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.half3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfsafe(bool3 x) => (half3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.half4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfsafe(bool4 x) => (half4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.half8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfsafe(bool8 x) => (half8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its floating point representation as a <see cref="MaxMath.half16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 tohalfsafe(bool16 x) => (half16)x;


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="float"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float tofloatsafe(bool a)
        {
            return asfloat(-tosbytesafe(a) & asint(1f));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.float2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tofloatsafe(bool2 x) => (float2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.float3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tofloatsafe(bool3 x) => (float3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.float4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tofloatsafe(bool4 x) => (float4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.float8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tofloatsafe(bool8 x) => (float8)x;


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="double"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double todoublesafe(bool a)
        {
            return asdouble(-(long)toulongsafe(a) & aslong(1d));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.double2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todoublesafe(bool2 x) => (double2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.double3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todoublesafe(bool3 x) => (double3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.double4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todoublesafe(bool4 x) => (double4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.byte2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesafe(mask8x2 x) => (byte2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.byte3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesafe(mask8x3 x) => (byte3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.byte4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesafe(mask8x4 x) => (byte4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a byte6 vector. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesafe(mask8x8 x) => (byte8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.byte16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesafe(mask8x16 x) => (byte16)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool32"/> to its integer representation as a <see cref="MaxMath.byte32"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobytesafe(mask8x32 x) => (byte32)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.sbyte2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesafe(mask8x2 x) => (sbyte2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.sbyte3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesafe(mask8x3 x) => (sbyte3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.sbyte4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesafe(mask8x4 x) => (sbyte4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.sbyte8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesafe(mask8x8 x) => (sbyte8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as an <see cref="MaxMath.sbyte16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesafe(mask8x16 x) => (sbyte16)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool32"/> to its integer representation as an <see cref="MaxMath.sbyte32"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbytesafe(mask8x32 x) => (sbyte32)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ushort2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushortsafe(mask8x2 x) => (ushort2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ushort3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushortsafe(mask8x3 x) => (ushort3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ushort4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushortsafe(mask8x4 x) => (ushort4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.ushort8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsafe(mask8x8 x) => (ushort8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.ushort16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushortsafe(mask8x16 x) => (ushort16)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.short2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshortsafe(mask8x2 x) => (short2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.short3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshortsafe(mask8x3 x) => (short3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.short4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshortsafe(mask8x4 x) => (short4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.short8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsafe(mask8x8 x) => (short8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.short16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshortsafe(mask8x16 x) => (short16)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.uint2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touintsafe(mask8x2 x) => (uint2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.uint3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touintsafe(mask8x3 x) => (uint3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.uint4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touintsafe(mask8x4 x) => (uint4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.uint8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touintsafe(mask8x8 x) => (uint8)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.int2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tointsafe(mask8x2 x) => (int2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.int3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tointsafe(mask8x3 x) => (int3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.int4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tointsafe(mask8x4 x) => (int4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.int8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tointsafe(mask8x8 x) => (int8)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ulong2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulongsafe(mask8x2 x) => (ulong2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ulong3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulongsafe(mask8x3 x) => (ulong3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ulong4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulongsafe(mask8x4 x) => (ulong4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.long2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolongsafe(mask8x2 x) => (long2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.long3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolongsafe(mask8x3 x) => (long3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.long4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolongsafe(mask8x4 x) => (long4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.quarter2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersafe(mask8x2 x) => (quarter2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.quarter3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersafe(mask8x3 x) => (quarter3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.quarter4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersafe(mask8x4 x) => (quarter4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.quarter8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquartersafe(mask8x8 x) => (quarter8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its floating point representation as a <see cref="MaxMath.quarter16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 toquartersafe(mask8x16 x) => (quarter16)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool32"/> to its floating point representation as a <see cref="MaxMath.quarter32"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 toquartersafe(mask8x32 x) => (quarter32)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.half2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfsafe(mask8x2 x) => (half2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.half3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfsafe(mask8x3 x) => (half3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.half4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfsafe(mask8x4 x) => (half4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.half8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfsafe(mask8x8 x) => (half8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its floating point representation as a <see cref="MaxMath.half16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 tohalfsafe(mask8x16 x) => (half16)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.float2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tofloatsafe(mask8x2 x) => (float2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.float3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tofloatsafe(mask8x3 x) => (float3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.float4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tofloatsafe(mask8x4 x) => (float4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.float8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tofloatsafe(mask8x8 x) => (float8)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.double2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todoublesafe(mask8x2 x) => (double2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.double3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todoublesafe(mask8x3 x) => (double3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.double4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todoublesafe(mask8x4 x) => (double4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.byte2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesafe(mask16x2 x) => (byte2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.byte3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesafe(mask16x3 x) => (byte3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.byte4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesafe(mask16x4 x) => (byte4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a byte6 vector. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesafe(mask16x8 x) => (byte8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.byte16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesafe(mask16x16 x) => (byte16)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.sbyte2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesafe(mask16x2 x) => (sbyte2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.sbyte3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesafe(mask16x3 x) => (sbyte3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.sbyte4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesafe(mask16x4 x) => (sbyte4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.sbyte8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesafe(mask16x8 x) => (sbyte8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as an <see cref="MaxMath.sbyte16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesafe(mask16x16 x) => (sbyte16)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ushort2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushortsafe(mask16x2 x) => (ushort2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ushort3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushortsafe(mask16x3 x) => (ushort3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ushort4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushortsafe(mask16x4 x) => (ushort4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.ushort8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsafe(mask16x8 x) => (ushort8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.ushort16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushortsafe(mask16x16 x) => (ushort16)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.short2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshortsafe(mask16x2 x) => (short2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.short3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshortsafe(mask16x3 x) => (short3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.short4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshortsafe(mask16x4 x) => (short4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.short8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsafe(mask16x8 x) => (short8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.short16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshortsafe(mask16x16 x) => (short16)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.uint2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touintsafe(mask16x2 x) => (uint2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.uint3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touintsafe(mask16x3 x) => (uint3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.uint4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touintsafe(mask16x4 x) => (uint4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.uint8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touintsafe(mask16x8 x) => (uint8)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.int2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tointsafe(mask16x2 x) => (int2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.int3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tointsafe(mask16x3 x) => (int3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.int4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tointsafe(mask16x4 x) => (int4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.int8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tointsafe(mask16x8 x) => (int8)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ulong2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulongsafe(mask16x2 x) => (ulong2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ulong3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulongsafe(mask16x3 x) => (ulong3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ulong4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulongsafe(mask16x4 x) => (ulong4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.long2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolongsafe(mask16x2 x) => (long2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.long3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolongsafe(mask16x3 x) => (long3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.long4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolongsafe(mask16x4 x) => (long4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.quarter2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersafe(mask16x2 x) => (quarter2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.quarter3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersafe(mask16x3 x) => (quarter3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.quarter4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersafe(mask16x4 x) => (quarter4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.quarter8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquartersafe(mask16x8 x) => (quarter8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its floating point representation as a <see cref="MaxMath.quarter16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 toquartersafe(mask16x16 x) => (quarter16)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.half2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfsafe(mask16x2 x) => (half2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.half3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfsafe(mask16x3 x) => (half3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.half4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfsafe(mask16x4 x) => (half4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.half8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfsafe(mask16x8 x) => (half8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its floating point representation as a <see cref="MaxMath.half16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 tohalfsafe(mask16x16 x) => (half16)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.float2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tofloatsafe(mask16x2 x) => (float2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.float3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tofloatsafe(mask16x3 x) => (float3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.float4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tofloatsafe(mask16x4 x) => (float4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.float8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tofloatsafe(mask16x8 x) => (float8)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.double2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todoublesafe(mask16x2 x) => (double2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.double3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todoublesafe(mask16x3 x) => (double3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.double4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todoublesafe(mask16x4 x) => (double4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.byte2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesafe(mask32x2 x) => (byte2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.byte3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesafe(mask32x3 x) => (byte3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.byte4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesafe(mask32x4 x) => (byte4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a byte6 vector. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesafe(mask32x8 x) => (byte8)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.sbyte2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesafe(mask32x2 x) => (sbyte2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.sbyte3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesafe(mask32x3 x) => (sbyte3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.sbyte4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesafe(mask32x4 x) => (sbyte4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.sbyte8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesafe(mask32x8 x) => (sbyte8)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ushort2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushortsafe(mask32x2 x) => (ushort2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ushort3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushortsafe(mask32x3 x) => (ushort3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ushort4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushortsafe(mask32x4 x) => (ushort4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.ushort8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsafe(mask32x8 x) => (ushort8)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.short2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshortsafe(mask32x2 x) => (short2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.short3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshortsafe(mask32x3 x) => (short3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.short4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshortsafe(mask32x4 x) => (short4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.short8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsafe(mask32x8 x) => (short8)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.uint2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touintsafe(mask32x2 x) => (uint2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.uint3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touintsafe(mask32x3 x) => (uint3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.uint4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touintsafe(mask32x4 x) => (uint4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.uint8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touintsafe(mask32x8 x) => (uint8)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.int2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tointsafe(mask32x2 x) => (int2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.int3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tointsafe(mask32x3 x) => (int3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.int4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tointsafe(mask32x4 x) => (int4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.int8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tointsafe(mask32x8 x) => (int8)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ulong2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulongsafe(mask32x2 x) => (ulong2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ulong3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulongsafe(mask32x3 x) => (ulong3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ulong4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulongsafe(mask32x4 x) => (ulong4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.long2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolongsafe(mask32x2 x) => (long2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.long3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolongsafe(mask32x3 x) => (long3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.long4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolongsafe(mask32x4 x) => (long4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.quarter2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersafe(mask32x2 x) => (quarter2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.quarter3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersafe(mask32x3 x) => (quarter3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.quarter4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersafe(mask32x4 x) => (quarter4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.quarter8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquartersafe(mask32x8 x) => (quarter8)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.half2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfsafe(mask32x2 x) => (half2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.half3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfsafe(mask32x3 x) => (half3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.half4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfsafe(mask32x4 x) => (half4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.half8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfsafe(mask32x8 x) => (half8)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.float2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tofloatsafe(mask32x2 x) => (float2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.float3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tofloatsafe(mask32x3 x) => (float3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.float4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tofloatsafe(mask32x4 x) => (float4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.float8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tofloatsafe(mask32x8 x) => (float8)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.double2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todoublesafe(mask32x2 x) => (double2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.double3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todoublesafe(mask32x3 x) => (double3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.double4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todoublesafe(mask32x4 x) => (double4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.byte2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesafe(mask64x2 x) => (byte2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.byte3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesafe(mask64x3 x) => (byte3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.byte4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesafe(mask64x4 x) => (byte4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.sbyte2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesafe(mask64x2 x) => (sbyte2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.sbyte3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesafe(mask64x3 x) => (sbyte3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.sbyte4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesafe(mask64x4 x) => (sbyte4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ushort2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushortsafe(mask64x2 x) => (ushort2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ushort3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushortsafe(mask64x3 x) => (ushort3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ushort4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushortsafe(mask64x4 x) => (ushort4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.short2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshortsafe(mask64x2 x) => (short2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.short3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshortsafe(mask64x3 x) => (short3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.short4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshortsafe(mask64x4 x) => (short4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.uint2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touintsafe(mask64x2 x) => (uint2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.uint3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touintsafe(mask64x3 x) => (uint3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.uint4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touintsafe(mask64x4 x) => (uint4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.int2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tointsafe(mask64x2 x) => (int2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.int3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tointsafe(mask64x3 x) => (int3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.int4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tointsafe(mask64x4 x) => (int4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ulong2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulongsafe(mask64x2 x) => (ulong2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ulong3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulongsafe(mask64x3 x) => (ulong3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ulong4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulongsafe(mask64x4 x) => (ulong4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.long2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolongsafe(mask64x2 x) => (long2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.long3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolongsafe(mask64x3 x) => (long3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.long4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolongsafe(mask64x4 x) => (long4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.quarter2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersafe(mask64x2 x) => (quarter2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.quarter3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersafe(mask64x3 x) => (quarter3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.quarter4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersafe(mask64x4 x) => (quarter4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.half2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfsafe(mask64x2 x) => (half2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.half3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfsafe(mask64x3 x) => (half3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.half4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfsafe(mask64x4 x) => (half4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.float2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tofloatsafe(mask64x2 x) => (float2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.float3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tofloatsafe(mask64x3 x) => (float3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.float4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tofloatsafe(mask64x4 x) => (float4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.double2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todoublesafe(mask64x2 x) => (double2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.double3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todoublesafe(mask64x3 x) => (double3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.double4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todoublesafe(mask64x4 x) => (double4)x;


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.byte2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesafe(Unity.Mathematics.bool2 x) => tobytesafe((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.byte3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesafe(Unity.Mathematics.bool3 x) => tobytesafe((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.byte4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesafe(Unity.Mathematics.bool4 x) => tobytesafe((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.sbyte2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesafe(Unity.Mathematics.bool2 x) => tosbytesafe((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.sbyte3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesafe(Unity.Mathematics.bool3 x) => tosbytesafe((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.sbyte4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesafe(Unity.Mathematics.bool4 x) => tosbytesafe((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ushort2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushortsafe(Unity.Mathematics.bool2 x) => toushortsafe((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ushort3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushortsafe(Unity.Mathematics.bool3 x) => toushortsafe((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ushort4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushortsafe(Unity.Mathematics.bool4 x) => toushortsafe((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.short2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshortsafe(Unity.Mathematics.bool2 x) => toshortsafe((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.short3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshortsafe(Unity.Mathematics.bool3 x) => toshortsafe((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.short4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshortsafe(Unity.Mathematics.bool4 x) => toshortsafe((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.uint2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touintsafe(Unity.Mathematics.bool2 x) => touintsafe((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.uint3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touintsafe(Unity.Mathematics.bool3 x) => touintsafe((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.uint4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touintsafe(Unity.Mathematics.bool4 x) => touintsafe((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.int2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tointsafe(Unity.Mathematics.bool2 x) => tointsafe((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.int3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tointsafe(Unity.Mathematics.bool3 x) => tointsafe((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.int4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tointsafe(Unity.Mathematics.bool4 x) => tointsafe((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ulong2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulongsafe(Unity.Mathematics.bool2 x) => toulongsafe((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ulong3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulongsafe(Unity.Mathematics.bool3 x) => toulongsafe((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ulong4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulongsafe(Unity.Mathematics.bool4 x) => toulongsafe((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.long2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolongsafe(Unity.Mathematics.bool2 x) => tolongsafe((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.long3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolongsafe(Unity.Mathematics.bool3 x) => tolongsafe((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.long4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolongsafe(Unity.Mathematics.bool4 x) => tolongsafe((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.quarter2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersafe(Unity.Mathematics.bool2 x) => toquartersafe((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.quarter3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersafe(Unity.Mathematics.bool3 x) => toquartersafe((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.quarter4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersafe(Unity.Mathematics.bool4 x) => toquartersafe((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.half2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfsafe(Unity.Mathematics.bool2 x) => tohalfsafe((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.half3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfsafe(Unity.Mathematics.bool3 x) => tohalfsafe((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.half4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfsafe(Unity.Mathematics.bool4 x) => tohalfsafe((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.float2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tofloatsafe(Unity.Mathematics.bool2 x) => tofloatsafe((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.float3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tofloatsafe(Unity.Mathematics.bool3 x) => tofloatsafe((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.float4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tofloatsafe(Unity.Mathematics.bool4 x) => tofloatsafe((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.double2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todoublesafe(Unity.Mathematics.bool2 x) => todoublesafe((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.double3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todoublesafe(Unity.Mathematics.bool3 x) => todoublesafe((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.double4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todoublesafe(Unity.Mathematics.bool4 x) => todoublesafe((bool4)x);


        /// <summary>       Converts a <see cref="byte"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(byte a)
        {
            return a != 0;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 toboolsafe(byte2 x) => (mask8x2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.byte3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 toboolsafe(byte3 x) => (mask8x3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.byte4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 toboolsafe(byte4 x) => (mask8x4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.byte8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 toboolsafe(byte8 x) => (mask8x8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.byte16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 toboolsafe(byte16 x) => (mask8x16)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.byte32"/> to its boolean representation as a <see cref="MaxMath.bool32"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 toboolsafe(byte32 x) => (mask8x32)x;


        /// <summary>       Converts an <see cref="sbyte"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(sbyte a)
        {
            return a != 0;
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 toboolsafe(sbyte2 x) => (mask8x2)x;

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 toboolsafe(sbyte3 x) => (mask8x3)x;

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 toboolsafe(sbyte4 x) => (mask8x4)x;

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 toboolsafe(sbyte8 x) => (mask8x8)x;

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 toboolsafe(sbyte16 x) => (mask8x16)x;

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte32"/> to its boolean representation as a <see cref="MaxMath.bool32"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 toboolsafe(sbyte32 x) => (mask8x32)x;


        /// <summary>       Converts a <see cref="short"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(ushort a)
        {
            return a != 0;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 toboolsafe(ushort2 x) => (mask16x2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 toboolsafe(ushort3 x) => (mask16x3)x;

        /// <summary>       Converts each value in a ushor4 vector to its boolean representation as a <see cref="MaxMath.bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 toboolsafe(ushort4 x) => (mask16x4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 toboolsafe(ushort8 x) => (mask16x8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 toboolsafe(ushort16 x) => (mask16x16)x;


        /// <summary>       Converts a <see cref="short"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(short a)
        {
            return a != 0;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 toboolsafe(short2 x) => (mask16x2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.short3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 toboolsafe(short3 x) => (mask16x3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.short4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 toboolsafe(short4 x) => (mask16x4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.short8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 toboolsafe(short8 x) => (mask16x8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.short16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 toboolsafe(short16 x) => (mask16x16)x;


        /// <summary>       Converts a <see cref="uint"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(uint a)
        {
            return a != 0;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.uint2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 toboolsafe(uint2 x) => (mask32x2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.uint3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 toboolsafe(uint3 x) => (mask32x3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.uint4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 toboolsafe(uint4 x) => (mask32x4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.uint8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 toboolsafe(uint8 x) => (mask32x8)x;


        /// <summary>       Converts an <see cref="int"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(int a)
        {
            return a != 0;
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.int2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 toboolsafe(int2 x) => (mask32x2)x;

        /// <summary>       Converts each value in an <see cref="MaxMath.int3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 toboolsafe(int3 x) => (mask32x3)x;

        /// <summary>       Converts each value in an <see cref="MaxMath.int4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 toboolsafe(int4 x) => (mask32x4)x;

        /// <summary>       Converts each value in an <see cref="MaxMath.int8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 toboolsafe(int8 x) => (mask32x8)x;


        /// <summary>       Converts a <see cref="ulong"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(ulong a)
        {
            return a != 0;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 toboolsafe(ulong2 x) => (mask64x2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 toboolsafe(ulong3 x) => (mask64x3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 toboolsafe(ulong4 x) => (mask64x4)x;


        /// <summary>       Converts a <see cref="long"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(long a)
        {
            return a != 0;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.long2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 toboolsafe(long2 x) => (mask64x2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.long3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 toboolsafe(long3 x) => (mask64x3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.long4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 toboolsafe(long4 x) => (mask64x4)x;


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(quarter a)
        {
            return andnot(a != 0f, isnan(a));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 toboolsafe(quarter2 x) => (mask8x2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 toboolsafe(quarter3 x) => (mask8x3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 toboolsafe(quarter4 x) => (mask8x4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 toboolsafe(quarter8 x) => (mask8x8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 toboolsafe(quarter16 x) => (mask8x16)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter32"/> to its boolean representation as a <see cref="MaxMath.bool32"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 toboolsafe(quarter32 x) => (mask8x32)x;


        /// <summary>       Converts a <see cref="MaxMath.half"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(half a)
        {
            return andnot(a != 0f, isnan(a));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.half2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 toboolsafe(half2 x) => (mask16x2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.half3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 toboolsafe(half3 x) => (mask16x3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.half4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 toboolsafe(half4 x) => (mask16x4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.half8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 toboolsafe(half8 x) => (mask16x8)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.half16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 toboolsafe(half16 x) => (mask16x16)x;


        /// <summary>       Converts a <see cref="float"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(float a)
        {
            return andnot(a != 0f, isnan(a));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.float2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 toboolsafe(float2 x) => (mask32x2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.float3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 toboolsafe(float3 x) => (mask32x3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.float4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 toboolsafe(float4 x) => (mask32x4)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.float8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 toboolsafe(float8 x) => (mask32x8)x;


        /// <summary>       Converts a <see cref="double"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(double a)
        {
            return andnot(a != 0d, isnan(a));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.double2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 toboolsafe(double2 x) => (mask64x2)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.double3"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 toboolsafe(double3 x) => (mask64x3)x;

        /// <summary>       Converts each value in a <see cref="MaxMath.double4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 toboolsafe(double4 x) => (mask64x4)x;
    }
}