using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
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

        /// <summary>       Converts each value in a <see cref="bool2"/> to its integer representation as a <see cref="MaxMath.byte2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesafe(bool2 x)
        {
            return min(*(byte2*)&x, 1);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its integer representation as a <see cref="MaxMath.byte3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesafe(bool3 x)
        {
            return min(*(byte3*)&x, 1);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its integer representation as a <see cref="MaxMath.byte4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesafe(bool4 x)
        {
            return min(*(byte4*)&x, 1);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a byte6 vector. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesafe(bool8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return min((byte8)(v128)x, 1);
            }
            else
            {
                return min(*(byte8*)&x, 1);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.byte16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesafe(bool16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return min((byte16)(v128)x, 1);
            }
            else
            {
                return min(*(byte16*)&x, 1);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool32"/> to its integer representation as a <see cref="MaxMath.byte32"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobytesafe(bool32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return min((byte32)(v256)x, 1);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return min(new byte32((v128)x.v16_0, (v128)x.v16_16), 1);
            }
            else
            {
                return min(*(byte32*)&x, 1);
            }
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="sbyte"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbytesafe(bool a)
        {
            return (sbyte)tobytesafe(a);
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its integer representation as an <see cref="MaxMath.sbyte2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesafe(bool2 x)
        {
            return (sbyte2)tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its integer representation as an <see cref="MaxMath.sbyte3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesafe(bool3 x)
        {
            return (sbyte3)tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its integer representation as an <see cref="MaxMath.sbyte4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesafe(bool4 x)
        {
            return (sbyte4)tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.sbyte8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesafe(bool8 x)
        {
            return (sbyte8)tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as an <see cref="MaxMath.sbyte16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesafe(bool16 x)
        {
            return (sbyte16)tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool32"/> to its integer representation as an <see cref="MaxMath.sbyte32"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbytesafe(bool32 x)
        {
            return (sbyte32)tobytesafe(x);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="ushort"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushortsafe(bool a)
        {
            return tobytesafe(a);
        }
        /// <summary>       Converts each value in a <see cref="bool2"/> to its integer representation as a <see cref="MaxMath.ushort2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushortsafe(bool2 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its integer representation as a <see cref="MaxMath.ushort3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushortsafe(bool3 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its integer representation as a <see cref="MaxMath.ushort4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushortsafe(bool4 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.ushort8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsafe(bool8 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.ushort16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushortsafe(bool16 x)
        {
            return tobytesafe(x);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="short"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshortsafe(bool a)
        {
            return tobytesafe(a);
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its integer representation as a <see cref="MaxMath.short2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshortsafe(bool2 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its integer representation as a <see cref="MaxMath.short3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshortsafe(bool3 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its integer representation as a <see cref="MaxMath.short4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshortsafe(bool4 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.short8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsafe(bool8 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.short16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshortsafe(bool16 x)
        {
            return tobytesafe(x);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="uint"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touintsafe(bool a)
        {
            return tobytesafe(a);
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its integer representation as a <see cref="uint2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touintsafe(bool2 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its integer representation as a <see cref="uint3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touintsafe(bool3 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its integer representation as a <see cref="uint4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touintsafe(bool4 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.uint8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touintsafe(bool8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                ;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new uint8((uint4)min((byte4)(v128)x, 1), (uint4)min(vshr((byte4)(v128)x, 4), 1));
            }

            return tobytesafe(x);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="int"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int tointsafe(bool a)
        {
            return tobytesafe(a);
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its integer representation as an <see cref="int2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tointsafe(bool2 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its integer representation as an <see cref="int3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tointsafe(bool3 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its integer representation as an <see cref="int4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tointsafe(bool4 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.int8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tointsafe(bool8 x)
        {
            return (int8)touintsafe(x);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="ulong"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong toulongsafe(bool a)
        {
            return tobytesafe(a);
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its integer representation as a <see cref="MaxMath.ulong2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulongsafe(bool2 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its integer representation as a <see cref="MaxMath.ulong3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulongsafe(bool3 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its integer representation as a <see cref="MaxMath.ulong4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulongsafe(bool4 x)
        {
            return tobytesafe(x);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="long"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long tolongsafe(bool a)
        {
            return tobytesafe(a);
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its integer representation as a <see cref="MaxMath.long2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolongsafe(bool2 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its integer representation as a <see cref="MaxMath.long3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolongsafe(bool3 x)
        {
            return tobytesafe(x);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its integer representation as a <see cref="MaxMath.long4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolongsafe(bool4 x)
        {
            return tobytesafe(x);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="MaxMath.quarter"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquartersafe(bool a)
        {
            return asquarter((byte)(-tosbytesafe(a) & ((quarter)1f).value));
        }
        /// <summary>       Converts each value in a <see cref="bool2"/> to its floating point representation as a <see cref="MaxMath.quarter2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersafe(bool2 x)
        {
            return asquarter(select(default(byte2), ((quarter)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its floating point representation as a <see cref="MaxMath.quarter3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersafe(bool3 x)
        {
            return asquarter(select(default(byte3), ((quarter)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its floating point representation as a <see cref="MaxMath.quarter4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersafe(bool4 x)
        {
            return asquarter(select(default(byte4), ((quarter)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.quarter8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquartersafe(bool8 x)
        {
            return asquarter(select(default(byte8), ((quarter)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its floating point representation as a <see cref="MaxMath.quarter16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 toquartersafe(bool16 x)
        {
            return asquarter(select(default(byte16), ((quarter)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool32"/> to its floating point representation as a <see cref="MaxMath.quarter32"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 toquartersafe(bool32 x)
        {
            return asquarter(select(default(byte32), ((quarter)1f).value, x));
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="half"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfsafe(bool a)
        {
            return new half { value = (ushort)(-tosbytesafe(a) & ((half)1f).value) };
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its floating point representation as a <see cref="half2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfsafe(bool2 x)
        {
            return ashalf(select(default(ushort2), ((half)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its floating point representation as a <see cref="half3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfsafe(bool3 x)
        {
            return ashalf(select(default(ushort3), ((half)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its floating point representation as a <see cref="half4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfsafe(bool4 x)
        {
            return ashalf(select(default(ushort4), ((half)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.half8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfsafe(bool8 x)
        {
            return ashalf(select(default(ushort8), ((half)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its floating point representation as a <see cref="MaxMath.half16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 tohalfsafe(bool16 x)
        {
            return ashalf(select(default(ushort16), ((half)1f).value, x));
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="float"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float tofloatsafe(bool a)
        {
            return math.asfloat(-tosbytesafe(a) & math.asint(1f));
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its floating point representation as a <see cref="float2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tofloatsafe(bool2 x)
        {
            return math.select(default(float2), new float2(1f), x);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its floating point representation as a <see cref="float3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tofloatsafe(bool3 x)
        {
            return math.select(default(float3), new float3(1f), x);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its floating point representation as a <see cref="float4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tofloatsafe(bool4 x)
        {
            return math.select(default(float4), new float4(1f), x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.float8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tofloatsafe(bool8 x)
        {
            return select(default(float8), new float8(1f), x);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="double"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double todoublesafe(bool a)
        {
            return math.asdouble(-(long)toulongsafe(a) & math.aslong(1d));
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its floating point representation as a <see cref="double2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todoublesafe(bool2 x)
        {
            return math.select(default(double2), new double2(1d), x);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its floating point representation as a <see cref="double3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todoublesafe(bool3 x)
        {
            return math.select(default(double3), new double3(1d), x);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its floating point representation as a <see cref="double4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todoublesafe(bool4 x)
        {
            return math.select(default(double4), new double4(1d), x);
        }


        /// <summary>       Converts a <see cref="byte"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(byte a)
        {
            return a != 0;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte2"/> to its boolean representation as a <see cref="bool2"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(byte2 x)
        {
            byte2 clamped = min(x, 1);

            return *(bool2*)&clamped;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte3"/> to its boolean representation as a <see cref="bool3"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(byte3 x)
        {
            byte3 clamped = min(x, 1);

            return *(bool3*)&clamped;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte4"/> to its boolean representation as a <see cref="bool4"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(byte4 x)
        {
            byte4 clamped = min(x, 1);

            return *(bool4*)&clamped;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 toboolsafe(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)min(x, 1);
            }
            else
            {
                byte8 temp = min(x, 1);

                return *(bool8*)&temp;
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 toboolsafe(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)min(x, 1);
            }
            else
            {
                byte16 temp = min(x, 1);

                return *(bool16*)&temp;
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte32"/> to its boolean representation as a <see cref="MaxMath.bool32"/>. The underlying value is being clamped to the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 toboolsafe(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return (v256)min(x, 1);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new bool32((v128)min(x.v16_0, 1), (v128)min(x.v16_16, 1));
            }
            else
            {
                byte32 temp = min(x, 1);

                return *(bool32*)&temp;
            }
        }


        /// <summary>       Converts an <see cref="sbyte"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(sbyte a)
        {
            return a != 0;
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte2"/> to its boolean representation as a <see cref="bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(sbyte2 x)
        {
            return toboolsafe((byte2)x);
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte3"/> to its boolean representation as a <see cref="bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(sbyte3 x)
        {
            return toboolsafe((byte3)x);
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte4"/> to its boolean representation as a <see cref="bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(sbyte4 x)
        {
            return toboolsafe((byte4)x);
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 toboolsafe(sbyte8 x)
        {
            return toboolsafe((byte8)x);
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 toboolsafe(sbyte16 x)
        {
            return toboolsafe((byte16)x);
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte32"/> to its boolean representation as a <see cref="MaxMath.bool32"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 toboolsafe(sbyte32 x)
        {
            return toboolsafe((byte32)x);
        }


        /// <summary>       Converts a <see cref="short"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(ushort a)
        {
            return a != 0;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort2"/> to its boolean representation as a <see cref="bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(ushort2 x)
        {
            byte2 clamped = (byte2)min(x, 1);

            return *(bool2*)&clamped;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort3"/> to its boolean representation as a <see cref="bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(ushort3 x)
        {
            byte3 clamped = (byte3)min(x, 1);

            return *(bool3*)&clamped;
        }

        /// <summary>       Converts each value in a ushor4 vector to its boolean representation as a <see cref="bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(ushort4 x)
        {
            byte4 clamped = (byte4)min(x, 1);

            return *(bool4*)&clamped;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 toboolsafe(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)(byte8)min(x, 1);
            }
            else
            {
                byte8 temp = (byte8)min(x, 1);

                return *(bool8*)&temp;
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 toboolsafe(ushort16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)(byte16)min(x, 1);
            }
            else
            {
                byte16 temp = (byte16)min(x, 1);

                return *(bool16*)&temp;
            }
        }


        /// <summary>       Converts a <see cref="short"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(short a)
        {
            return a != 0;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short2"/> to its boolean representation as a <see cref="bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(short2 x)
        {
            return toboolsafe((ushort2)x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short3"/> to its boolean representation as a <see cref="bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(short3 x)
        {
            return toboolsafe((ushort3)x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short4"/> to its boolean representation as a <see cref="bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(short4 x)
        {
            return toboolsafe((ushort4)x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 toboolsafe(short8 x)
        {
            return toboolsafe((ushort8)x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 toboolsafe(short16 x)
        {
            return toboolsafe((ushort16)x);
        }


        /// <summary>       Converts a <see cref="uint"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(uint a)
        {
            return a != 0;
        }

        /// <summary>       Converts each value in a <see cref="uint2"/> to its boolean representation as a <see cref="bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(uint2 x)
        {
            byte2 clamped = (byte2)math.min(x, 1);

            return *(bool2*)&clamped;
        }

        /// <summary>       Converts each value in a <see cref="uint3"/> to its boolean representation as a <see cref="bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(uint3 x)
        {
            byte3 clamped = (byte3)math.min(x, 1);

            return *(bool3*)&clamped;
        }

        /// <summary>       Converts each value in a <see cref="uint4"/> to its boolean representation as a <see cref="bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(uint4 x)
        {
            byte4 clamped = (byte4)math.min(x, 1);

            return *(bool4*)&clamped;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.uint8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 toboolsafe(uint8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)(byte8)min(x, 1);
            }
            else
            {
                byte8 temp = (byte8)min(x, 1);

                return *(bool8*)&temp;
            }
        }


        /// <summary>       Converts an <see cref="int"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(int a)
        {
            return a != 0;
        }

        /// <summary>       Converts each value in an <see cref="int2"/> to its boolean representation as a <see cref="bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(int2 x)
        {
            return toboolsafe((uint2)x);
        }

        /// <summary>       Converts each value in an <see cref="int3"/> to its boolean representation as a <see cref="bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(int3 x)
        {
            return toboolsafe((uint3)x);
        }

        /// <summary>       Converts each value in an <see cref="int4"/> to its boolean representation as a <see cref="bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(int4 x)
        {
            return toboolsafe((uint4)x);
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.int8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 toboolsafe(int8 x)
        {
            return toboolsafe((uint8)x);
        }


        /// <summary>       Converts a <see cref="ulong"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(ulong a)
        {
            return a != 0;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong2"/> to its boolean representation as a <see cref="bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(ulong2 x)
        {
            byte2 clamped = (byte2)min(x, 1);

            return *(bool2*)&clamped;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong3"/> to its boolean representation as a <see cref="bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(ulong3 x)
        {
            byte3 clamped = (byte3)min(x, 1);

            return *(bool3*)&clamped;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong4"/> to its boolean representation as a <see cref="bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(ulong4 x)
        {
            byte4 clamped = (byte4)min(x, 1);

            return *(bool4*)&clamped;
        }


        /// <summary>       Converts a <see cref="long"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(long a)
        {
            return a != 0;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.long2"/> to its boolean representation as a <see cref="bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(long2 x)
        {
            return toboolsafe((ulong2)x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.long3"/> to its boolean representation as a <see cref="bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(long3 x)
        {
            return toboolsafe((ulong3)x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.long4"/> to its boolean representation as a <see cref="bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(long4 x)
        {
            return toboolsafe((ulong4)x);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(quarter a)
        {
            return a != (quarter)0f;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter2"/> to its boolean representation as a <see cref="bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(quarter2 x)
        {
            return x != (quarter)0f;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter3"/> to its boolean representation as a <see cref="bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(quarter3 x)
        {
            return x != (quarter)0f;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter4"/> to its boolean representation as a <see cref="bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(quarter4 x)
        {
            return x != (quarter)0f;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 toboolsafe(quarter8 x)
        {
            return x != (quarter)0f;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 toboolsafe(quarter16 x)
        {
            return x != (quarter)0f;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter32"/> to its boolean representation as a <see cref="MaxMath.bool32"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 toboolsafe(quarter32 x)
        {
            return x != (quarter)0f;
        }


        /// <summary>       Converts a <see cref="half"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(half a)
        {
            return (float)a != 0f;
        }

        /// <summary>       Converts each value in a <see cref="half2"/> to its boolean representation as a <see cref="bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(half2 x)
        {
            return (float2)x != 0f;
        }

        /// <summary>       Converts each value in a <see cref="half3"/> to its boolean representation as a <see cref="bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(half3 x)
        {
            return (float3)x != 0f;
        }

        /// <summary>       Converts each value in a <see cref="half4"/> to its boolean representation as a <see cref="bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(half4 x)
        {
            return (float4)x != 0f;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.half8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 toboolsafe(half8 x)
        {
            return (float8)x != 0f;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.half16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 toboolsafe(half16 x)
        {
            return new bool16((float8)x.v8_0 != 0f, (float8)x.v8_8 != 0f);
        }


        /// <summary>       Converts a <see cref="float"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(float a)
        {
            return a != 0f;
        }

        /// <summary>       Converts each value in a <see cref="float2"/> to its boolean representation as a <see cref="bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(float2 x)
        {
            return x != 0f;
        }

        /// <summary>       Converts each value in a <see cref="float3"/> to its boolean representation as a <see cref="bool3"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(float3 x)
        {
            return x != 0f;
        }

        /// <summary>       Converts each value in a <see cref="float4"/> to its boolean representation as a <see cref="bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(float4 x)
        {
            return x != 0f;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.float8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 toboolsafe(float8 x)
        {
            return x != 0f;
        }


        /// <summary>       Converts a <see cref="double"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(double a)
        {
            return a != 0d;
        }

        /// <summary>       Converts each value in a <see cref="double2"/> to its boolean representation as a <see cref="bool2"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(double2 x)
        {
            return x != 0d;
        }

        /// <summary>       Converts each value in a <see cref="double3"/> to its boolean representation as a <see cref="bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(double3 x)
        {
            return x != 0d;
        }

        /// <summary>       Converts each value in a <see cref="double4"/> to its boolean representation as a <see cref="bool4"/>. The underlying value is being clamped to the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(double4 x)
        {
            return x != 0d;
        }
    }
}