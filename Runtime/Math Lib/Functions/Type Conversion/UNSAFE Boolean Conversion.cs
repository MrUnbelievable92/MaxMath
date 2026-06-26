using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using DevTools;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Converts a <see cref="bool"/> to its <see cref="UInt128"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 touint128(bool a)
        {
            return tobyte(a);
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="Int128"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 toint128(bool a)
        {
            return tobyte(a);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="byte"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [return: AssumeRange(0ul, 1ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobyte(bool a)
        {
Assert.IsSafeBoolean(a);

            byte result = *(byte*)&a;
            constexpr.ASSUME(result == 0 || result == 1 && result <= 1);
            return result;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.byte2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobyte(bool2 x)
        {
VectorAssert.IsNotGreater<byte2, byte>(*(byte2*)&x, 1, 2);

            byte2 result = *(byte2*)&x;
            if (BurstArchitecture.IsSIMDSupported)
            {
                constexpr.ASSUME_LE_EPU8(result, 1, 2);
            }
            return result;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.byte3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobyte(bool3 x)
        {
VectorAssert.IsNotGreater<byte3, byte>(*(byte3*)&x, 1, 3);

            byte3 result = *(byte3*)&x;
            if (BurstArchitecture.IsSIMDSupported)
            {
                constexpr.ASSUME_LE_EPU8(result, 1, 3);
            }
            return result;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.byte4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobyte(bool4 x)
        {
VectorAssert.IsNotGreater<byte4, byte>(*(byte4*)&x, 1, 4);

            byte4 result = *(byte4*)&x;
            if (BurstArchitecture.IsSIMDSupported)
            {
                constexpr.ASSUME_LE_EPU8(result, 1, 4);
            }
            return result;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.byte8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobyte(bool8 x)
        {
VectorAssert.IsNotGreater<byte8, byte>(*(byte8*)&x, 1, 8);

            byte8 result;
            if (BurstArchitecture.IsSIMDSupported)
            {
                result = (v128)x;
                constexpr.ASSUME_LE_EPU8(result, 1, 8);
            }
            else
            {
                result = *(byte8*)&x;
            }
            return result;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.byte16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobyte(bool16 x)
        {
VectorAssert.IsNotGreater<byte16, byte>(*(byte16*)&x, 1, 16);

            byte16 result;
            if (BurstArchitecture.IsSIMDSupported)
            {
                result = (v128)x;
                constexpr.ASSUME_LE_EPU8(result, 1, 16);
            }
            else
            {
                result = *(byte16*)&x;
            }
            return result;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool32"/> to its integer representation as a <see cref="MaxMath.byte32"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobyte(bool32 x)
        {
VectorAssert.IsNotGreater<byte32, byte>(*(byte32*)&x, 1, 32);

            if (Avx2.IsAvx2Supported)
            {
                constexpr.ASSUME_LE_EPU8(x, 1);
                return (v256)x;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                constexpr.ASSUME_LE_EPU8(x.__x0, 1);
                constexpr.ASSUME_LE_EPU8(x.__x16, 1);
                return new byte32 { __x0 = (v128)x.__x0, __x16 = (v128)x.__x16 };
            }
            else
            {
                byte32 result = *(byte32*)&x;
                return result;
            }
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="sbyte"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [return: AssumeRange(0L, 1L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbyte(bool x)
        {
            return (sbyte)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.sbyte2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbyte(bool2 x)
        {
            return (sbyte2)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.sbyte3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbyte(bool3 x)
        {
            return (sbyte3)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.sbyte4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbyte(bool4 x)
        {
            return (sbyte4)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.sbyte8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbyte(bool8 x)
        {
            return (sbyte8)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as an <see cref="MaxMath.sbyte16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbyte(bool16 x)
        {
            return (sbyte16)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool32"/> to its integer representation as an <see cref="MaxMath.sbyte32"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbyte(bool32 x)
        {
            return (sbyte32)tobyte(x);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="ushort"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [return: AssumeRange(0ul, 1ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushort(bool a)
        {
            return tobyte(a);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ushort2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushort(bool2 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ushort3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushort(bool3 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ushort4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushort(bool4 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.ushort8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushort(bool8 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.ushort16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushort(bool16 x)
        {
            return tobyte(x);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="short"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [return: AssumeRange(0L, 1L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshort(bool a)
        {
            return tobyte(a);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.short2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshort(bool2 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.short3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshort(bool3 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.short4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshort(bool4 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.short8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshort(bool8 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.short16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshort(bool16 x)
        {
            return tobyte(x);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="uint"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [return: AssumeRange(0ul, 1ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touint(bool a)
        {
            return tobyte(a);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.uint2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touint(bool2 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.uint3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touint(bool3 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.uint4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touint(bool4 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.uint8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touint(bool8 x)
        {
            return tobyte(x);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="int"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [return: AssumeRange(0L, 1L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int toint(bool a)
        {
            return tobyte(a);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.int2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 toint(bool2 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.int3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 toint(bool3 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.int4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 toint(bool4 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.int8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 toint(bool8 x)
        {
            return tobyte(x);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="ulong"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [return: AssumeRange(0ul, 1ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong toulong(bool a)
        {
            return tobyte(a);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ulong2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulong(bool2 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ulong3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulong(bool3 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ulong4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulong(bool4 x)
        {
            return tobyte(x);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="long"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [return: AssumeRange(0L, 1L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long tolong(bool a)
        {
            return tobyte(a);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.long2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolong(bool2 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.long3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolong(bool3 x)
        {
            return tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.long4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolong(bool4 x)
        {
            return tobyte(x);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="MaxMath.quarter"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquarter(bool a)
        {
            return asquarter((byte)(-tosbyte(a) & ((quarter)1f).value));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.quarter2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarter(bool2 x)
        {
            return asquarter(select(default(byte2), ((quarter)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.quarter3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarter(bool3 x)
        {
            return asquarter(select(default(byte3), ((quarter)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.quarter4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarter(bool4 x)
        {
            return asquarter(select(default(byte4), ((quarter)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.quarter8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquarter(bool8 x)
        {
            return asquarter(select(default(byte8), ((quarter)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its floating point representation as a <see cref="MaxMath.quarter16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 toquarter(bool16 x)
        {
            return asquarter(select(default(byte16), ((quarter)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool32"/> to its floating point representation as a <see cref="MaxMath.quarter32"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 toquarter(bool32 x)
        {
            return asquarter(select(default(byte32), ((quarter)1f).value, x));
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="MaxMath.half"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalf(bool a)
        {
            return new half { value = (ushort)(-tosbyte(a) & ((half)1f).value) };
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.half2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalf(bool2 x)
        {
            return ashalf(select(default(ushort2), ((half)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.half3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalf(bool3 x)
        {
            return ashalf(select(default(ushort3), ((half)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.half4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalf(bool4 x)
        {
            return ashalf(select(default(ushort4), ((half)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.half8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalf(bool8 x)
        {
            return ashalf(select(default(ushort8), ((half)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its floating point representation as a <see cref="MaxMath.half16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 tohalf(bool16 x)
        {
            return ashalf(select(default(ushort16), ((half)1f).value, x));
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="float"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float tofloat(bool a)
        {
            return asfloat(-tosbyte(a) & asint(1f));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.float2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tofloat(bool2 x)
        {
            return select(default(float2), new float2(1f), x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.float3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tofloat(bool3 x)
        {
            return select(default(float3), new float3(1f), x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.float4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tofloat(bool4 x)
        {
            return select(default(float4), new float4(1f), x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.float8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tofloat(bool8 x)
        {
            return select(default(float8), new float8(1f), x);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="double"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double todouble(bool a)
        {
            return asdouble(-(long)toulong(a) & aslong(1d));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.double2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todouble(bool2 x)
        {
            return select(default(double2), new double2(1d), x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.double3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todouble(bool3 x)
        {
            return select(default(double3), new double3(1d), x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.double4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todouble(bool4 x)
        {
            return select(default(double4), new double4(1d), x);
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.byte2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobyte(Unity.Mathematics.bool2 x) => tobyte((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.byte3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobyte(Unity.Mathematics.bool3 x) => tobyte((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.byte4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobyte(Unity.Mathematics.bool4 x) => tobyte((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.sbyte2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbyte(Unity.Mathematics.bool2 x) => tosbyte((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.sbyte3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbyte(Unity.Mathematics.bool3 x) => tosbyte((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.sbyte4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbyte(Unity.Mathematics.bool4 x) => tosbyte((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ushort2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushort(Unity.Mathematics.bool2 x) => toushort((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ushort3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushort(Unity.Mathematics.bool3 x) => toushort((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ushort4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushort(Unity.Mathematics.bool4 x) => toushort((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.short2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshort(Unity.Mathematics.bool2 x) => toshort((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.short3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshort(Unity.Mathematics.bool3 x) => toshort((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.short4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshort(Unity.Mathematics.bool4 x) => toshort((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.uint2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touint(Unity.Mathematics.bool2 x) => touint((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.uint3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touint(Unity.Mathematics.bool3 x) => touint((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.uint4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touint(Unity.Mathematics.bool4 x) => touint((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.int2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 toint(Unity.Mathematics.bool2 x) => toint((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.int3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 toint(Unity.Mathematics.bool3 x) => toint((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.int4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 toint(Unity.Mathematics.bool4 x) => toint((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ulong2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulong(Unity.Mathematics.bool2 x) => toulong((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ulong3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulong(Unity.Mathematics.bool3 x) => toulong((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ulong4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulong(Unity.Mathematics.bool4 x) => toulong((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.long2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolong(Unity.Mathematics.bool2 x) => tolong((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.long3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolong(Unity.Mathematics.bool3 x) => tolong((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.long4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolong(Unity.Mathematics.bool4 x) => tolong((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.quarter2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarter(Unity.Mathematics.bool2 x) => toquarter((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.quarter3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarter(Unity.Mathematics.bool3 x) => toquarter((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.quarter4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarter(Unity.Mathematics.bool4 x) => toquarter((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.half2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalf(Unity.Mathematics.bool2 x) => tohalf((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.half3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalf(Unity.Mathematics.bool3 x) => tohalf((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.half4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalf(Unity.Mathematics.bool4 x) => tohalf((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.float2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tofloat(Unity.Mathematics.bool2 x) => tofloat((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.float3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tofloat(Unity.Mathematics.bool3 x) => tofloat((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.float4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tofloat(Unity.Mathematics.bool4 x) => tofloat((bool4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.double2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todouble(Unity.Mathematics.bool2 x) => todouble((bool2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.double3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todouble(Unity.Mathematics.bool3 x) => todouble((bool3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.double4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todouble(Unity.Mathematics.bool4 x) => todouble((bool4)x);
        

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.byte2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobyte(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return tobyte((bool2)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.byte3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobyte(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return tobyte((bool3)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.byte4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobyte(mask8x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return tobyte((bool4)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.byte8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobyte(mask8x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return tobyte((bool8)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.byte16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobyte(mask8x16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return tobyte((bool16)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool32"/> to its integer representation as a <see cref="MaxMath.byte32"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobyte(mask8x32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi8(x);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new byte32(Xse.neg_epi8(x.v16_0), Xse.neg_epi8(x.v16_16));
            }
            else
            {
                return tobyte((bool32)x);
            }
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.sbyte2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbyte(mask8x2 x)
        {
            return (sbyte2)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.sbyte3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbyte(mask8x3 x)
        {
            return (sbyte3)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.sbyte4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbyte(mask8x4 x)
        {
            return (sbyte4)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.sbyte8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbyte(mask8x8 x)
        {
            return (sbyte8)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as an <see cref="MaxMath.sbyte16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbyte(mask8x16 x)
        {
            return (sbyte16)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool32"/> to its integer representation as an <see cref="MaxMath.sbyte32"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbyte(mask8x32 x)
        {
            return (sbyte32)tobyte(x);
        }
        

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.byte2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobyte(mask16x2 x) => tobyte((mask8x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.byte3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobyte(mask16x3 x) => tobyte((mask8x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.byte4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobyte(mask16x4 x) => tobyte((mask8x4)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.byte8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobyte(mask16x8 x) => tobyte((mask8x8)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.byte16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobyte(mask16x16 x) => tobyte((mask8x16)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.sbyte2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbyte(mask16x2 x)
        {
            return (sbyte2)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.sbyte3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbyte(mask16x3 x)
        {
            return (sbyte3)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.sbyte4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbyte(mask16x4 x)
        {
            return (sbyte4)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.sbyte8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbyte(mask16x8 x)
        {
            return (sbyte8)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as an <see cref="MaxMath.sbyte16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbyte(mask16x16 x)
        {
            return (sbyte16)tobyte(x);
        }
        

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.byte2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobyte(mask32x2 x) => tobyte((mask8x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.byte3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobyte(mask32x3 x) => tobyte((mask8x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.byte4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobyte(mask32x4 x) => tobyte((mask8x4)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.byte8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobyte(mask32x8 x) => tobyte((mask8x8)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.sbyte2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbyte(mask32x2 x)
        {
            return (sbyte2)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.sbyte3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbyte(mask32x3 x)
        {
            return (sbyte3)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.sbyte4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbyte(mask32x4 x)
        {
            return (sbyte4)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.sbyte8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbyte(mask32x8 x)
        {
            return (sbyte8)tobyte(x);
        }
        

        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.byte2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobyte(mask64x2 x) => tobyte((mask8x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.byte3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobyte(mask64x3 x) => tobyte((mask8x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.byte4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobyte(mask64x4 x) => tobyte((mask8x4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.sbyte2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbyte(mask64x2 x)
        {
            return (sbyte2)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.sbyte3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbyte(mask64x3 x)
        {
            return (sbyte3)tobyte(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.sbyte4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbyte(mask64x4 x)
        {
            return (sbyte4)tobyte(x);
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ushort2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushort(mask8x2 x) => toushort((mask16x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ushort3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushort(mask8x3 x) => toushort((mask16x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ushort4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushort(mask8x4 x) => toushort((mask16x4)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.ushort8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushort(mask8x8 x) => toushort((mask16x8)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.ushort16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushort(mask8x16 x) => toushort((mask16x16)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.short2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshort(mask8x2 x)
        {
            return (short2)toushort(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.short3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshort(mask8x3 x)
        {
            return (short3)toushort(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.short4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshort(mask8x4 x)
        {
            return (short4)toushort(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.short8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshort(mask8x8 x)
        {
            return (short8)toushort(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.short16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshort(mask8x16 x)
        {
            return (short16)toushort(x);
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ushort2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushort(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return tobyte((bool2)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ushort3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushort(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return tobyte((bool3)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ushort4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushort(mask16x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return tobyte((bool4)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.ushort8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushort(mask16x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return tobyte((bool8)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.ushort16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushort(mask16x16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi16(x);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new ushort16(Xse.neg_epi16(x.v8_0), Xse.neg_epi16(x.v8_8));
            }
            else
            {
                return tobyte((bool16)x);
            }
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.short2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshort(mask16x2 x)
        {
            return (short2)toushort(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.short3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshort(mask16x3 x)
        {
            return (short3)toushort(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.short4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshort(mask16x4 x)
        {
            return (short4)toushort(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.short8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshort(mask16x8 x)
        {
            return (short8)toushort(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.short16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshort(mask16x16 x)
        {
            return (short16)toushort(x);
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ushort2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushort(mask32x2 x) => toushort((mask16x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ushort3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushort(mask32x3 x) => toushort((mask16x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ushort4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushort(mask32x4 x) => toushort((mask16x4)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.ushort8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushort(mask32x8 x) => toushort((mask16x8)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.short2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshort(mask32x2 x)
        {
            return (short2)toushort(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.short3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshort(mask32x3 x)
        {
            return (short3)toushort(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.short4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshort(mask32x4 x)
        {
            return (short4)toushort(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.short8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshort(mask32x8 x)
        {
            return (short8)toushort(x);
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ushort2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushort(mask64x2 x) => toushort((mask16x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ushort3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushort(mask64x3 x) => toushort((mask16x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ushort4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushort(mask64x4 x) => toushort((mask16x4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.short2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshort(mask64x2 x)
        {
            return (short2)toushort(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.short3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshort(mask64x3 x)
        {
            return (short3)toushort(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.short4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshort(mask64x4 x)
        {
            return (short4)toushort(x);
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.uint2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touint(mask8x2 x) => touint((mask32x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.uint3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touint(mask8x3 x) => touint((mask32x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.uint4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touint(mask8x4 x) => touint((mask32x4)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.uint8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touint(mask8x8 x) => touint((mask32x8)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.int2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 toint(mask8x2 x)
        {
            return (int2)touint(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.int3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 toint(mask8x3 x)
        {
            return (int3)touint(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.int4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 toint(mask8x4 x)
        {
            return (int4)touint(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.int8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 toint(mask8x8 x)
        {
            return (int8)touint(x);
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.uint2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touint(mask16x2 x) => touint((mask32x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.uint3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touint(mask16x3 x) => touint((mask32x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.uint4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touint(mask16x4 x) => touint((mask32x4)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.uint8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touint(mask16x8 x) => touint((mask32x8)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.int2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 toint(mask16x2 x)
        {
            return (int2)touint(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.int3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 toint(mask16x3 x)
        {
            return (int3)touint(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.int4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 toint(mask16x4 x)
        {
            return (int4)touint(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.int8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 toint(mask16x8 x)
        {
            return (int8)touint(x);
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.uint2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touint(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi32(x);
            }
            else
            {
                return tobyte((bool2)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.uint3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touint(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi32(x);
            }
            else
            {
                return tobyte((bool3)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.uint4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touint(mask32x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi32(x);
            }
            else
            {
                return tobyte((bool4)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.uint8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touint(mask32x8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi32(x);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new uint8(Xse.neg_epi32(x.v4_0), Xse.neg_epi32(x.v4_4));
            }
            else
            {
                return tobyte((bool8)x);
            }
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.int2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 toint(mask32x2 x)
        {
            return (int2)touint(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.int3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 toint(mask32x3 x)
        {
            return (int3)touint(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.int4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 toint(mask32x4 x)
        {
            return (int4)touint(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.int8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 toint(mask32x8 x)
        {
            return (int8)touint(x);
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.uint2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touint(mask64x2 x) => touint((mask32x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.uint3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touint(mask64x3 x) => touint((mask32x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.uint4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touint(mask64x4 x) => touint((mask32x4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as an <see cref="MaxMath.int2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 toint(mask64x2 x)
        {
            return (int2)touint(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as an <see cref="MaxMath.int3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 toint(mask64x3 x)
        {
            return (int3)touint(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as an <see cref="MaxMath.int4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 toint(mask64x4 x)
        {
            return (int4)touint(x);
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ulong2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulong(mask8x2 x) => toulong((mask64x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ulong3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulong(mask8x3 x) => toulong((mask64x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ulong4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulong(mask8x4 x) => toulong((mask64x4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.long2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolong(mask8x2 x)
        {
            return (long2)toulong(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.long3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolong(mask8x3 x)
        {
            return (long3)toulong(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.long4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolong(mask8x4 x)
        {
            return (long4)toulong(x);
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ulong2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulong(mask16x2 x) => toulong((mask64x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ulong3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulong(mask16x3 x) => toulong((mask64x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ulong4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulong(mask16x4 x) => toulong((mask64x4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.long2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolong(mask16x2 x)
        {
            return (long2)toulong(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.long3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolong(mask16x3 x)
        {
            return (long3)toulong(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.long4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolong(mask16x4 x)
        {
            return (long4)toulong(x);
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ulong2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulong(mask32x2 x) => toulong((mask64x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ulong3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulong(mask32x3 x) => toulong((mask64x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ulong4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulong(mask32x4 x) => toulong((mask64x4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.long2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolong(mask32x2 x)
        {
            return (long2)toulong(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.long3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolong(mask32x3 x)
        {
            return (long3)toulong(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.long4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolong(mask32x4 x)
        {
            return (long4)toulong(x);
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.ulong2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulong(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi64(x);
            }
            else
            {
                return tobyte((bool2)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.ulong3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulong(mask64x3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi64(x);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new ulong3(Xse.neg_epi64(x.xy), math.tobyte(x.z));
            }
            else
            {
                return tobyte((bool3)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.ulong4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulong(mask64x4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi64(x);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new ulong4(Xse.neg_epi64(x.xy), Xse.neg_epi64(x.zw));
            }
            else
            {
                return tobyte((bool4)x);
            }
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its integer representation as a <see cref="MaxMath.long2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolong(mask64x2 x)
        {
            return (long2)toulong(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its integer representation as a <see cref="MaxMath.long3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolong(mask64x3 x)
        {
            return (long3)toulong(x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its integer representation as a <see cref="MaxMath.long4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolong(mask64x4 x)
        {
            return (long4)toulong(x);
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.quarter2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarter(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(x, Xse.set1_pq((quarter)1f));
            }
            else
            {
                return toquarter((bool2)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.quarter3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarter(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(x, Xse.set1_pq((quarter)1f));
            }
            else
            {
                return toquarter((bool3)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.quarter4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarter(mask8x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(x, Xse.set1_pq((quarter)1f));
            }
            else
            {
                return toquarter((bool4)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.quarter8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquarter(mask8x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(x, Xse.set1_pq((quarter)1f));
            }
            else
            {
                return toquarter((bool8)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its floating point representation as a <see cref="MaxMath.quarter16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 toquarter(mask8x16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(x, Xse.set1_pq((quarter)1f));
            }
            else
            {
                return toquarter((bool16)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool32"/> to its floating point representation as a <see cref="MaxMath.quarter32"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 toquarter(mask8x32 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_and_ps(x, Xse.mm256_set1_pq((quarter)1f));
            }
            if (BurstArchitecture.IsSIMDSupported)
            {
                return new quarter32(Xse.and_si128(x.v16_0, Xse.set1_pq((quarter)1f)), Xse.and_si128(x.v16_16, Xse.set1_pq((quarter)1f)));
            }
            else
            {
                return toquarter((bool32)x);
            }
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.quarter2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarter(mask16x2 x) => toquarter((mask8x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.quarter3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarter(mask16x3 x) => toquarter((mask8x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.quarter4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarter(mask16x4 x) => toquarter((mask8x4)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.quarter8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquarter(mask16x8 x) => toquarter((mask8x8)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its floating point representation as a <see cref="MaxMath.quarter16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 toquarter(mask16x16 x) => toquarter((mask8x16)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.quarter2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarter(mask32x2 x) => toquarter((mask8x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.quarter3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarter(mask32x3 x) => toquarter((mask8x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.quarter4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarter(mask32x4 x) => toquarter((mask8x4)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.quarter8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquarter(mask32x8 x) => toquarter((mask8x8)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.quarter2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarter(mask64x2 x) => toquarter((mask8x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.quarter3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarter(mask64x3 x) => toquarter((mask8x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.quarter4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarter(mask64x4 x) => toquarter((mask8x4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.half2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalf(mask8x2 x) => tohalf((mask16x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.half3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalf(mask8x3 x) => tohalf((mask16x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.half4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalf(mask8x4 x) => tohalf((mask16x4)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.half8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalf(mask8x8 x) => tohalf((mask16x8)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its floating point representation as a <see cref="MaxMath.half16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 tohalf(mask8x16 x) => tohalf((mask16x16)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.half2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalf(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(x, Xse.set1_ph((half)1f));
            }
            else
            {
                return toquarter((bool2)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.half3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalf(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(x, Xse.set1_ph((half)1f));
            }
            else
            {
                return toquarter((bool3)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.half4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalf(mask16x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(x, Xse.set1_ph((half)1f));
            }
            else
            {
                return toquarter((bool4)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.half8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalf(mask16x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(x, Xse.set1_ph((half)1f));
            }
            else
            {
                return toquarter((bool8)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its floating point representation as a <see cref="MaxMath.half16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 tohalf(mask16x16 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_and_ps(x, Xse.mm256_set1_ph((half)1f));
            }
            if (BurstArchitecture.IsSIMDSupported)
            {
                return new half16(Xse.and_si128(x.v8_0, Xse.set1_ph((half)1f)), Xse.and_si128(x.v8_8, Xse.set1_ph((half)1f)));
            }
            else
            {
                return toquarter((bool16)x);
            }
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.half2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalf(mask32x2 x) => tohalf((mask16x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.half3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalf(mask32x3 x) => tohalf((mask16x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.half4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalf(mask32x4 x) => tohalf((mask16x4)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.half8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalf(mask32x8 x) => tohalf((mask16x8)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.half2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalf(mask64x2 x) => tohalf((mask16x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.half3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalf(mask64x3 x) => tohalf((mask16x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.half4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalf(mask64x4 x) => tohalf((mask16x4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.float2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tofloat(mask8x2 x) => tofloat((mask32x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.float3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tofloat(mask8x3 x) => tofloat((mask32x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.float4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tofloat(mask8x4 x) => tofloat((mask32x4)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.float8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tofloat(mask8x8 x) => tofloat((mask32x8)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.float2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tofloat(mask16x2 x) => tofloat((mask32x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.float3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tofloat(mask16x3 x) => tofloat((mask32x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.float4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tofloat(mask16x4 x) => tofloat((mask32x4)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.float8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tofloat(mask16x8 x) => tofloat((mask32x8)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.float2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tofloat(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_ps(x, Xse.set1_ps(1f));
            }
            else
            {
                return toquarter((bool2)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.float3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tofloat(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_ps(x, Xse.set1_ps(1f));
            }
            else
            {
                return toquarter((bool3)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.float4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tofloat(mask32x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_ps(x, Xse.set1_ps(1f));
            }
            else
            {
                return toquarter((bool4)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.float8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tofloat(mask32x8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_and_ps(x, Xse.mm256_set1_ps(1f));
            }
            if (BurstArchitecture.IsSIMDSupported)
            {
                return new float8(Xse.and_ps(x.v4_0, Xse.set1_ps(1f)), Xse.and_ps(x.v4_4, Xse.set1_ps(1f)));
            }
            else
            {
                return toquarter((bool8)x);
            }
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.float2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tofloat(mask64x2 x) => tofloat((mask32x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.float3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tofloat(mask64x3 x) => tofloat((mask32x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.float4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tofloat(mask64x4 x) => tofloat((mask32x4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.double2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todouble(mask8x2 x) => todouble((mask64x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.double3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todouble(mask8x3 x) => todouble((mask64x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.double4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todouble(mask8x4 x) => todouble((mask64x4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.double2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todouble(mask16x2 x) => todouble((mask64x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.double3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todouble(mask16x3 x) => todouble((mask64x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.double4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todouble(mask16x4 x) => todouble((mask64x4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.double2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todouble(mask32x2 x) => todouble((mask64x2)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.double3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todouble(mask32x3 x) => todouble((mask64x3)x);

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.double4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todouble(mask32x4 x) => todouble((mask64x4)x);


        /// <summary>       Converts each value in a <see cref="MaxMath.bool2"/> to its floating point representation as a <see cref="MaxMath.double2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todouble(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_pd(x, Xse.set1_pd(1d));
            }
            else
            {
                return toquarter((bool2)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool3"/> to its floating point representation as a <see cref="MaxMath.double3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todouble(mask64x3 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_and_pd(x, Xse.mm256_set1_pd(1d));
            }
            if (BurstArchitecture.IsSIMDSupported)
            {
                return new double3(Xse.and_pd(x.xy, Xse.set1_pd(1d)), select(0d, 1d, x.z));
            }
            else
            {
                return toquarter((bool3)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool4"/> to its floating point representation as a <see cref="MaxMath.double4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todouble(mask64x4 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_and_pd(x, Xse.mm256_set1_pd(1d));
            }
            if (BurstArchitecture.IsSIMDSupported)
            {
                return new double4(Xse.and_pd(x.xy, Xse.set1_pd(1d)), Xse.and_pd(x.zw, Xse.set1_pd(1d)));
            }
            else
            {
                return toquarter((bool4)x);
            }
        }


        /// <summary>       Converts a <see cref="byte"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(byte a)
        {
Assert.IsBetween(a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 tobool(byte2 x)
        {
VectorAssert.IsNotGreater<byte2, byte>(x, 1, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return *(bool2*)&x;
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 tobool(byte3 x)
        {
VectorAssert.IsNotGreater<byte3, byte>(x, 1, 3);
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return *(bool3*)&x;
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 tobool(byte4 x)
        {
VectorAssert.IsNotGreater<byte4, byte>(x, 1, 4);
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return *(bool4*)&x;
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 tobool(byte8 x)
        {
VectorAssert.IsNotGreater<byte8, byte>(x, 1, 8);
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return *(bool8*)&x;
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 tobool(byte16 x)
        {
VectorAssert.IsNotGreater<byte16, byte>(x, 1, 16);
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return *(bool16*)&x;
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte32"/> to its boolean representation as a <see cref="MaxMath.bool32"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 tobool(byte32 x)
        {
VectorAssert.IsNotGreater<byte32, byte>(x, 1, 32);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi8(x);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new mask8x32(Xse.neg_epi8(x.v16_0), Xse.neg_epi8(x.v16_16));
            }
            else
            {
                return *(bool32*)&x;
            }
        }


        /// <summary>       Converts an <see cref="sbyte"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(sbyte a)
        {
            return tobool((byte)a);
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 tobool(sbyte2 x)
        {
            return tobool((byte2)x);
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 tobool(sbyte3 x)
        {
            return tobool((byte3)x);
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 tobool(sbyte4 x)
        {
            return tobool((byte4)x);
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 tobool(sbyte8 x)
        {
            return tobool((byte8)x);
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 tobool(sbyte16 x)
        {
            return tobool((byte16)x);
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte32"/> to its boolean representation as a <see cref="MaxMath.bool32"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 tobool(sbyte32 x)
        {
            return tobool((byte32)x);
        }


        /// <summary>       Converts a <see cref="short"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(short a)
        {
            return tobool((ushort)a);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 tobool(short2 x)
        {
            return tobool((ushort2)x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 tobool(short3 x)
        {
            return tobool((ushort3)x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 tobool(short4 x)
        {
            return tobool((ushort4)x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 tobool(short8 x)
        {
            return tobool((ushort8)x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 tobool(short16 x)
        {
            return tobool((ushort16)x);
        }


        /// <summary>       Converts a <see cref="short"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(ushort a)
        {
Assert.IsBetween((byte)a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 tobool(ushort2 x)
        {
VectorAssert.IsNotGreater<ushort2, ushort>(x, 1, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return tobool((byte2)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 tobool(ushort3 x)
        {
VectorAssert.IsNotGreater<ushort3, ushort>(x, 1, 3);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return tobool((byte3)x);
            }
        }

        /// <summary>       Converts each value in a ushor4 vector to its boolean representation as a <see cref="MaxMath.bool4"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 tobool(ushort4 x)
        {
VectorAssert.IsNotGreater<ushort4, ushort>(x, 1, 4);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return tobool((byte4)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 tobool(ushort8 x)
        {
VectorAssert.IsNotGreater<ushort8, ushort>(x, 1, 8);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return tobool((byte8)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 tobool(ushort16 x)
        {
VectorAssert.IsNotGreater<ushort16, ushort>(x, 1, 16);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi16(x);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new mask16x16(Xse.neg_epi16(x.v8_0), Xse.neg_epi16(x.v8_8));
            }
            else
            {
                return tobool((byte16)x);
            }
        }


        /// <summary>       Converts an <see cref="int"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(int a)
        {
            return tobool((uint)a);
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.int2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 tobool(int2 x)
        {
            return tobool((uint2)x);
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.int3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 tobool(int3 x)
        {
            return tobool((uint3)x);
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.int4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 tobool(int4 x)
        {
            return tobool((uint4)x);
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.int8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 tobool(int8 x)
        {
            return tobool((uint8)x);
        }


        /// <summary>       Converts a <see cref="uint"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(uint a)
        {
Assert.IsBetween((byte)a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.uint2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 tobool(uint2 x)
        {
VectorAssert.IsNotGreater<uint2, uint>(x, 1, 2);

            if (BurstArchitecture.IsTableLookupSupported)
            {
                return Xse.neg_epi32(x);
            }
            else
            {
                return tobool((byte2)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.uint3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 tobool(uint3 x)
        {
VectorAssert.IsNotGreater<uint3, uint>(x, 1, 3);

            if (BurstArchitecture.IsTableLookupSupported)
            {
                return Xse.neg_epi32(x);
            }
            else
            {
                return tobool((byte3)x);
            }
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.uint4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 tobool(uint4 x)
        {
VectorAssert.IsNotGreater<uint4, uint>(x, 1, 4);

            if (BurstArchitecture.IsTableLookupSupported)
            {
                return Xse.neg_epi32(x);
            }
            else
            {
                return tobool((byte4)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.uint8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 tobool(uint8 x)
        {
VectorAssert.IsNotGreater<uint8, uint>(x, 1, 8);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi32(x);
            }
            else if (BurstArchitecture.IsTableLookupSupported)
            {
                return new mask32x8(Xse.neg_epi32(x.v4_0), Xse.neg_epi32(x.v4_4));
            }
            else
            {
                return tobool((byte8)x);
            }
        }


        /// <summary>       Converts a <see cref="long"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(long a)
        {
Assert.IsBetween((sbyte)a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.long2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 tobool(long2 x)
        {
            return tobool((ulong2)x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.long3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 tobool(long3 x)
        {
            return tobool((ulong3)x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.long4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 tobool(long4 x)
        {
            return tobool((ulong4)x);
        }


        /// <summary>       Converts a <see cref="ulong"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(ulong a)
        {
Assert.IsBetween((byte)a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 tobool(ulong2 x)
        {
VectorAssert.IsNotGreater<ulong2, ulong>(x, 1, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi64(x);
            }
            else
            {
                return tobool((byte2)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 tobool(ulong3 x)
        {
VectorAssert.IsNotGreater<ulong3, ulong>(x, 1, 3);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi64(x);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new mask64x3(Xse.neg_epi64(x.xy), tobool(x.z));
            }
            else
            {
                return tobool((byte3)x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 tobool(ulong4 x)
        {
VectorAssert.IsNotGreater<ulong4, ulong>(x, 1, 4);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi64(x);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new mask64x4(Xse.neg_epi64(x.xy), Xse.neg_epi64(x.zw));
            }
            else
            {
                return tobool((byte4)x);
            }
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(quarter a)
        {
Assert.IsTrue(a.value == ((quarter)1f).value || a.value == 0 || a.value == 1 << 7);

            return a.value == ((quarter)1f).value;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 tobool(quarter2 x)
        {
Assert.IsTrue(x.x == (quarter)0f || x.x == (quarter)1f);
Assert.IsTrue(x.y == (quarter)0f || x.y == (quarter)1f);

            return asbyte(x) == ((quarter)1f).value;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 tobool(quarter3 x)
        {
Assert.IsTrue(x.x == (quarter)0f || x.x == (quarter)1f);
Assert.IsTrue(x.y == (quarter)0f || x.y == (quarter)1f);
Assert.IsTrue(x.z == (quarter)0f || x.z == (quarter)1f);

            return asbyte(x) == ((quarter)1f).value;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 tobool(quarter4 x)
        {
Assert.IsTrue(x.x == (quarter)0f || x.x == (quarter)1f);
Assert.IsTrue(x.y == (quarter)0f || x.y == (quarter)1f);
Assert.IsTrue(x.z == (quarter)0f || x.z == (quarter)1f);
Assert.IsTrue(x.w == (quarter)0f || x.w == (quarter)1f);

            return asbyte(x) == ((quarter)1f).value;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 tobool(quarter8 x)
        {
Assert.IsTrue(x.x0 == (quarter)0f || x.x0 == (quarter)1f);
Assert.IsTrue(x.x1 == (quarter)0f || x.x1 == (quarter)1f);
Assert.IsTrue(x.x2 == (quarter)0f || x.x2 == (quarter)1f);
Assert.IsTrue(x.x3 == (quarter)0f || x.x3 == (quarter)1f);
Assert.IsTrue(x.x4 == (quarter)0f || x.x4 == (quarter)1f);
Assert.IsTrue(x.x5 == (quarter)0f || x.x5 == (quarter)1f);
Assert.IsTrue(x.x6 == (quarter)0f || x.x6 == (quarter)1f);
Assert.IsTrue(x.x7 == (quarter)0f || x.x7 == (quarter)1f);

            return asbyte(x) == ((quarter)1f).value;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 tobool(quarter16 x)
        {
Assert.IsTrue(x.x0  == (quarter)0f || x.x0  == (quarter)1f);
Assert.IsTrue(x.x1  == (quarter)0f || x.x1  == (quarter)1f);
Assert.IsTrue(x.x2  == (quarter)0f || x.x2  == (quarter)1f);
Assert.IsTrue(x.x3  == (quarter)0f || x.x3  == (quarter)1f);
Assert.IsTrue(x.x4  == (quarter)0f || x.x4  == (quarter)1f);
Assert.IsTrue(x.x5  == (quarter)0f || x.x5  == (quarter)1f);
Assert.IsTrue(x.x6  == (quarter)0f || x.x6  == (quarter)1f);
Assert.IsTrue(x.x7  == (quarter)0f || x.x7  == (quarter)1f);
Assert.IsTrue(x.x8  == (quarter)0f || x.x8  == (quarter)1f);
Assert.IsTrue(x.x9  == (quarter)0f || x.x9  == (quarter)1f);
Assert.IsTrue(x.x10 == (quarter)0f || x.x10 == (quarter)1f);
Assert.IsTrue(x.x11 == (quarter)0f || x.x11 == (quarter)1f);
Assert.IsTrue(x.x12 == (quarter)0f || x.x12 == (quarter)1f);
Assert.IsTrue(x.x13 == (quarter)0f || x.x13 == (quarter)1f);
Assert.IsTrue(x.x14 == (quarter)0f || x.x14 == (quarter)1f);
Assert.IsTrue(x.x15 == (quarter)0f || x.x15 == (quarter)1f);

            return asbyte(x) == ((quarter)1f).value;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter32"/> to its boolean representation as a <see cref="MaxMath.bool32"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 tobool(quarter32 x)
        {
Assert.IsTrue(x.x0  == (quarter)0f || x.x0  == (quarter)1f);
Assert.IsTrue(x.x1  == (quarter)0f || x.x1  == (quarter)1f);
Assert.IsTrue(x.x2  == (quarter)0f || x.x2  == (quarter)1f);
Assert.IsTrue(x.x3  == (quarter)0f || x.x3  == (quarter)1f);
Assert.IsTrue(x.x4  == (quarter)0f || x.x4  == (quarter)1f);
Assert.IsTrue(x.x5  == (quarter)0f || x.x5  == (quarter)1f);
Assert.IsTrue(x.x6  == (quarter)0f || x.x6  == (quarter)1f);
Assert.IsTrue(x.x7  == (quarter)0f || x.x7  == (quarter)1f);
Assert.IsTrue(x.x8  == (quarter)0f || x.x8  == (quarter)1f);
Assert.IsTrue(x.x9  == (quarter)0f || x.x9  == (quarter)1f);
Assert.IsTrue(x.x10 == (quarter)0f || x.x10 == (quarter)1f);
Assert.IsTrue(x.x11 == (quarter)0f || x.x11 == (quarter)1f);
Assert.IsTrue(x.x12 == (quarter)0f || x.x12 == (quarter)1f);
Assert.IsTrue(x.x13 == (quarter)0f || x.x13 == (quarter)1f);
Assert.IsTrue(x.x14 == (quarter)0f || x.x14 == (quarter)1f);
Assert.IsTrue(x.x15 == (quarter)0f || x.x15 == (quarter)1f);
Assert.IsTrue(x.x16 == (quarter)0f || x.x16 == (quarter)1f);
Assert.IsTrue(x.x17 == (quarter)0f || x.x17 == (quarter)1f);
Assert.IsTrue(x.x18 == (quarter)0f || x.x18 == (quarter)1f);
Assert.IsTrue(x.x19 == (quarter)0f || x.x19 == (quarter)1f);
Assert.IsTrue(x.x20 == (quarter)0f || x.x20 == (quarter)1f);
Assert.IsTrue(x.x21 == (quarter)0f || x.x21 == (quarter)1f);
Assert.IsTrue(x.x22 == (quarter)0f || x.x22 == (quarter)1f);
Assert.IsTrue(x.x23 == (quarter)0f || x.x23 == (quarter)1f);
Assert.IsTrue(x.x24 == (quarter)0f || x.x24 == (quarter)1f);
Assert.IsTrue(x.x25 == (quarter)0f || x.x25 == (quarter)1f);
Assert.IsTrue(x.x26 == (quarter)0f || x.x26 == (quarter)1f);
Assert.IsTrue(x.x27 == (quarter)0f || x.x27 == (quarter)1f);
Assert.IsTrue(x.x28 == (quarter)0f || x.x28 == (quarter)1f);
Assert.IsTrue(x.x29 == (quarter)0f || x.x29 == (quarter)1f);
Assert.IsTrue(x.x30 == (quarter)0f || x.x30 == (quarter)1f);
Assert.IsTrue(x.x31 == (quarter)0f || x.x31 == (quarter)1f);

            return asbyte(x) == ((quarter)1f).value;
        }


        /// <summary>       Converts a <see cref="MaxMath.half"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(half a)
        {
Assert.IsTrue(a.value == ((half)1f).value || a.value == 0 || a.value == 1 << 15);

            return a.value == ((half)1f).value;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.half2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 tobool(half2 x)
        {
Assert.IsTrue(x.x == 0f || x.x == (half)1f);
Assert.IsTrue(x.y == 0f || x.y == (half)1f);

            return asushort(x) == ((half)1f).value;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.half3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 tobool(half3 x)
        {
Assert.IsTrue(x.x == 0f || x.x == (half)1f);
Assert.IsTrue(x.y == 0f || x.y == (half)1f);
Assert.IsTrue(x.z == 0f || x.z == (half)1f);

            return asushort(x) == ((half)1f).value;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.half4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 tobool(half4 x)
        {
Assert.IsTrue(x.x == 0f || x.x == (half)1f);
Assert.IsTrue(x.y == 0f || x.y == (half)1f);
Assert.IsTrue(x.z == 0f || x.z == (half)1f);
Assert.IsTrue(x.w == 0f || x.w == (half)1f);

            return asushort(x) == ((half)1f).value;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.half8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 tobool(half8 x)
        {
Assert.IsTrue(x.x0 == 0f || x.x0 == (half)1f);
Assert.IsTrue(x.x1 == 0f || x.x1 == (half)1f);
Assert.IsTrue(x.x2 == 0f || x.x2 == (half)1f);
Assert.IsTrue(x.x3 == 0f || x.x3 == (half)1f);
Assert.IsTrue(x.x4 == 0f || x.x4 == (half)1f);
Assert.IsTrue(x.x5 == 0f || x.x5 == (half)1f);
Assert.IsTrue(x.x6 == 0f || x.x6 == (half)1f);
Assert.IsTrue(x.x7 == 0f || x.x7 == (half)1f);

            return asushort(x) == ((half)1f).value;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.half16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 tobool(half16 x)
        {
Assert.IsTrue(x.x0  == (half)0f || x.x0  == (half)1f);
Assert.IsTrue(x.x1  == (half)0f || x.x1  == (half)1f);
Assert.IsTrue(x.x2  == (half)0f || x.x2  == (half)1f);
Assert.IsTrue(x.x3  == (half)0f || x.x3  == (half)1f);
Assert.IsTrue(x.x4  == (half)0f || x.x4  == (half)1f);
Assert.IsTrue(x.x5  == (half)0f || x.x5  == (half)1f);
Assert.IsTrue(x.x6  == (half)0f || x.x6  == (half)1f);
Assert.IsTrue(x.x7  == (half)0f || x.x7  == (half)1f);
Assert.IsTrue(x.x8  == (half)0f || x.x8  == (half)1f);
Assert.IsTrue(x.x9  == (half)0f || x.x9  == (half)1f);
Assert.IsTrue(x.x10 == (half)0f || x.x10 == (half)1f);
Assert.IsTrue(x.x11 == (half)0f || x.x11 == (half)1f);
Assert.IsTrue(x.x12 == (half)0f || x.x12 == (half)1f);
Assert.IsTrue(x.x13 == (half)0f || x.x13 == (half)1f);
Assert.IsTrue(x.x14 == (half)0f || x.x14 == (half)1f);
Assert.IsTrue(x.x15 == (half)0f || x.x15 == (half)1f);

            return asushort(x) == ((half)1f).value;
        }


        /// <summary>       Converts a <see cref="float"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(float a)
        {
Assert.IsTrue(a == 1f || a == 0f);

            return asint(a) == asint(1f);
        }

        /// <summary> Converts each value in a <see cref="MaxMath.float2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 tobool(float2 x)
        {
Assert.IsTrue(x.x == 0f || x.x == 1f);
Assert.IsTrue(x.y == 0f || x.y == 1f);

            return asint(x) == asint(1f);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.float3"/> to its boolean representation as a <see cref="MaxMath.bool3"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 tobool(float3 x)
        {
Assert.IsTrue(x.x == 0f || x.x == 1f);
Assert.IsTrue(x.y == 0f || x.y == 1f);
Assert.IsTrue(x.z == 0f || x.z == 1f);

            return asint(x) == asint(1f);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.float4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 tobool(float4 x)
        {
Assert.IsTrue(x.x == 0f || x.x == 1f);
Assert.IsTrue(x.y == 0f || x.y == 1f);
Assert.IsTrue(x.z == 0f || x.z == 1f);
Assert.IsTrue(x.w == 0f || x.w == 1f);

            return asint(x) == asint(1f);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.float8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 tobool(float8 x)
        {
Assert.IsTrue(x.x0 == 0f || x.x0 == 1f);
Assert.IsTrue(x.x1 == 0f || x.x1 == 1f);
Assert.IsTrue(x.x2 == 0f || x.x2 == 1f);
Assert.IsTrue(x.x3 == 0f || x.x3 == 1f);
Assert.IsTrue(x.x4 == 0f || x.x4 == 1f);
Assert.IsTrue(x.x5 == 0f || x.x5 == 1f);
Assert.IsTrue(x.x6 == 0f || x.x6 == 1f);
Assert.IsTrue(x.x7 == 0f || x.x7 == 1f);

            return asint(x) == asint(1f);
        }


        /// <summary>       Converts a <see cref="double"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(double a)
        {
Assert.IsTrue(a == 1d || a == 0d);

            return aslong(a) == aslong(1d);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.double2"/> to its boolean representation as a <see cref="MaxMath.bool2"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 tobool(double2 x)
        {
Assert.IsTrue(x.x == 0d || x.x == 1d);
Assert.IsTrue(x.y == 0d || x.y == 1d);

            return aslong(x) == aslong(1d);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.double3"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 tobool(double3 x)
        {
Assert.IsTrue(x.x == 0d || x.x == 1d);
Assert.IsTrue(x.y == 0d || x.y == 1d);
Assert.IsTrue(x.z == 0d || x.z == 1d);

            return aslong(x) == aslong(1d);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.double4"/> to its boolean representation as a <see cref="MaxMath.bool4"/>. The corresponding value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 tobool(double4 x)
        {
Assert.IsTrue(x.x == 0d || x.x == 1d);
Assert.IsTrue(x.y == 0d || x.y == 1d);
Assert.IsTrue(x.z == 0d || x.z == 1d);
Assert.IsTrue(x.w == 0d || x.w == 1d);

            return aslong(x) == aslong(1d);
        }
    }
}