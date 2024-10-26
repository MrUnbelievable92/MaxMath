using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        #region To byte
        /// <summary>       Casts the <see cref="sbyte"/> <paramref name="x"/> to a <see cref="byte"/> and returns the result, which is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobytesaturated(sbyte x)
        {
            return (byte)math.max(x, byte.MinValue);
        }

        /// <summary>       Casts the <see cref="short"/> <paramref name="x"/> to a <see cref="byte"/> and returns the result, which is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobytesaturated(short x)
        {
            return (byte)math.clamp(x, byte.MinValue, byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="int"/> <paramref name="x"/> to a <see cref="byte"/> and returns the result, which is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobytesaturated(int x)
        {
            return (byte)math.clamp(x, byte.MinValue, byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="long"/> <paramref name="x"/> to a <see cref="byte"/> and returns the result, which is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobytesaturated(long x)
        {
            return (byte)math.clamp(x, byte.MinValue, byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="Int128"/> <paramref name="x"/> to a <see cref="byte"/> and returns the result, which is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobytesaturated(Int128 x)
        {
            return (byte)clamp(x, byte.MinValue, byte.MaxValue);
        }


        /// <summary>       Casts the <see cref="ushort"/> <paramref name="x"/> to a <see cref="byte"/> and returns the result, which is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobytesaturated(ushort x)
        {
            return (byte)math.min(byte.MaxValue, (uint)x);
        }

        /// <summary>       Casts the <see cref="uint"/> <paramref name="x"/> to a <see cref="byte"/> and returns the result, which is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobytesaturated(uint x)
        {
            return (byte)math.min(byte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="ulong"/> <paramref name="x"/> to a <see cref="byte"/> and returns the result, which is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobytesaturated(ulong x)
        {
            return (byte)math.min(byte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="UInt128"/> <paramref name="x"/> to a <see cref="byte"/> and returns the result, which is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobytesaturated(UInt128 x)
        {
            return (byte)min(byte.MaxValue, x);
        }


        /// <summary>       Casts the <see cref="quarter"/> <paramref name="x"/> to a <see cref="byte"/> and returns the result, which is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobytesaturated(quarter x)
        {
            return tobytesaturated((float)x);
        }

        /// <summary>       Casts the <see cref="half"/> <paramref name="x"/> to a <see cref="byte"/> and returns the result, which is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobytesaturated(half x)
        {
            return tobytesaturated((float)x);
        }

        /// <summary>       Casts the <see cref="float"/> <paramref name="x"/> to a <see cref="byte"/> and returns the result, which is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobytesaturated(float x)
        {
            return (byte)math.clamp(x, byte.MinValue, byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="double"/> <paramref name="x"/> to a <see cref="byte"/> and returns the result, which is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobytesaturated(double x)
        {
            return (byte)math.clamp(x, byte.MinValue, byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte2"/> <paramref name="x"/> to a <see cref="MaxMath.byte2"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesaturated(sbyte2 x)
        {
            return (byte2)max((sbyte)byte.MinValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte3"/> <paramref name="x"/> to a <see cref="MaxMath.byte3"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesaturated(sbyte3 x)
        {
            return (byte3)max((sbyte)byte.MinValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte4"/> <paramref name="x"/> to a <see cref="MaxMath.byte4"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesaturated(sbyte4 x)
        {
            return (byte4)max((sbyte)byte.MinValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte8"/> <paramref name="x"/> to a <see cref="MaxMath.byte8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesaturated(sbyte8 x)
        {
            return (byte8)max((sbyte)byte.MinValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte16"/> <paramref name="x"/> to a <see cref="MaxMath.byte16"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesaturated(sbyte16 x)
        {
            return (byte16)max((sbyte)byte.MinValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte32"/> <paramref name="x"/> to a <see cref="MaxMath.byte32"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobytesaturated(sbyte32 x)
        {
            return (byte32)max((sbyte)byte.MinValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort2"/> <paramref name="x"/> to a <see cref="MaxMath.byte2"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesaturated(ushort2 x)
        {
            return (byte2)min((ushort)byte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort3"/> <paramref name="x"/> to a <see cref="MaxMath.byte3"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesaturated(ushort3 x)
        {
            return (byte3)min((ushort)byte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort4"/> <paramref name="x"/> to a <see cref="MaxMath.byte4"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesaturated(ushort4 x)
        {
            return (byte4)min((ushort)byte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort8"/> <paramref name="x"/> to a <see cref="MaxMath.byte8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesaturated(ushort8 x)
        {
            return (byte8)min((ushort)byte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort16"/> <paramref name="x"/> to a <see cref="MaxMath.byte16"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesaturated(ushort16 x)
        {
            return (byte16)min((ushort)byte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort8"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.byte16"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesaturated(ushort8 lo, ushort8 hi)
        {
            ushort8 MAX_VALUE = (ushort)byte.MaxValue;

            return new byte16((byte8)min(MAX_VALUE, lo),
                              (byte8)min(MAX_VALUE, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort16"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.byte32"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobytesaturated(ushort16 lo, ushort16 hi)
        {
            ushort16 MAX_VALUE = (ushort)byte.MaxValue;

            return new byte32((byte16)min(MAX_VALUE, lo),
                              (byte16)min(MAX_VALUE, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.short2"/> <paramref name="x"/> to a <see cref="MaxMath.byte2"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesaturated(short2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.packus_epi16(x, x);
            }
            else
            {
                return new byte2(tobytesaturated(x.x), tobytesaturated(x.y));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short3"/> <paramref name="x"/> to a <see cref="MaxMath.byte3"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesaturated(short3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.packus_epi16(x, x);
            }
            else
            {
                return new byte3(tobytesaturated(x.x), tobytesaturated(x.y), tobytesaturated(x.z));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short4"/> <paramref name="x"/> to a <see cref="MaxMath.byte4"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesaturated(short4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.packus_epi16(x, x);
            }
            else
            {
                return new byte4(tobytesaturated(x.x), tobytesaturated(x.y), tobytesaturated(x.z), tobytesaturated(x.w));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short8"/> <paramref name="x"/> to a <see cref="MaxMath.byte8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesaturated(short8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.packus_epi16(x, x);
            }
            else
            {
                return new byte8(tobytesaturated(x.x0), tobytesaturated(x.x1), tobytesaturated(x.x2), tobytesaturated(x.x3), tobytesaturated(x.x4), tobytesaturated(x.x5), tobytesaturated(x.x6), tobytesaturated(x.x7));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short16"/> <paramref name="x"/> to a <see cref="MaxMath.byte16"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesaturated(short16 x)
        {
            return tobytesaturated(x.v8_0, x.v8_8);
        }

        /// <summary>       Casts the <see cref="MaxMath.short8"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.byte16"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesaturated(short8 lo, short8 hi)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.packus_epi16(lo, hi);
            }
            else
            {
                return new byte16(tobytesaturated(lo.x0), tobytesaturated(lo.x1), tobytesaturated(lo.x2), tobytesaturated(lo.x3), tobytesaturated(lo.x4), tobytesaturated(lo.x5), tobytesaturated(lo.x6), tobytesaturated(lo.x7),
                                  tobytesaturated(hi.x0), tobytesaturated(hi.x1), tobytesaturated(hi.x2), tobytesaturated(hi.x3), tobytesaturated(hi.x4), tobytesaturated(hi.x5), tobytesaturated(hi.x6), tobytesaturated(hi.x7));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short16"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.byte32"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobytesaturated(short16 lo, short16 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 packed = Avx2.mm256_packus_epi16(lo, hi);

                return Avx2.mm256_permute4x64_epi64(packed, Sse.SHUFFLE(3, 1, 2, 0));
            }
            else
            {
                return new byte32(tobytesaturated(lo), tobytesaturated(hi));
            }
        }

        /// <summary>       Casts the <see cref="uint2"/> <paramref name="x"/> to a <see cref="MaxMath.byte2"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesaturated(uint2 x)
        {
            return (byte2)math.min((uint)byte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="uint3"/> <paramref name="x"/> to a <see cref="MaxMath.byte3"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesaturated(uint3 x)
        {
            return (byte3)math.min((uint)byte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="uint4"/> <paramref name="x"/> to a <see cref="MaxMath.byte4"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesaturated(uint4 x)
        {
            return (byte4)math.min((uint)byte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="uint4"/>s <paramref name="x"/> and <paramref name="y"/> to a <see cref="MaxMath.byte8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesaturated(uint4 x, uint4 y)
        {
            return (byte8)min(new uint8(x, y), byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.uint8"/> <paramref name="x"/> to a <see cref="MaxMath.byte8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesaturated(uint8 x)
        {
            return (byte8)min((uint)byte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.uint8"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.byte16"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesaturated(uint8 lo, uint8 hi)
        {
            uint8 MAX_VALUE = (uint)byte.MaxValue;

            return new byte16((byte8)min(MAX_VALUE, lo),
                              (byte8)min(MAX_VALUE, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.uint8"/>s <paramref name="x0_7"/>, <paramref name="x8_15"/>, <paramref name="x16_23"/> and <paramref name="x24_31"/> to a <see cref="MaxMath.byte32"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobytesaturated(uint8 x0_7, uint8 x8_15, uint8 x16_23, uint8 x24_31)
        {
            uint8 MAX_VALUE = (uint)byte.MaxValue;

            return new byte32((byte8)min(MAX_VALUE, x0_7),
                              (byte8)min(MAX_VALUE, x8_15),
                              (byte8)min(MAX_VALUE, x16_23),
                              (byte8)min(MAX_VALUE, x24_31));
        }

        /// <summary>       Casts the <see cref="int2"/> <paramref name="x"/> to a <see cref="MaxMath.byte2"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesaturated(int2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                v128 shorts = Xse.packs_epi32(_x, _x);

                return Xse.packus_epi16(shorts, shorts);
            }
            else
            {
                return (byte2)math.clamp(x, byte.MinValue, byte.MaxValue);
            }
        }

        /// <summary>       Casts the <see cref="int3"/> <paramref name="x"/> to a <see cref="MaxMath.byte3"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesaturated(int3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                v128 shorts = Xse.packs_epi32(_x, _x);

                return Xse.packus_epi16(shorts, shorts);
            }
            else
            {
                return (byte3)math.clamp(x, byte.MinValue, byte.MaxValue);
            }
        }

        /// <summary>       Casts the <see cref="int4"/> <paramref name="x"/> to a <see cref="MaxMath.byte4"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesaturated(int4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                v128 shorts = Xse.packs_epi32(_x, _x);

                return Xse.packus_epi16(shorts, shorts);
            }
            else
            {
                return (byte4)math.clamp(x, byte.MinValue, byte.MaxValue);
            }
        }

        /// <summary>       Casts the <see cref="int4"/>s <paramref name="x"/> and <paramref name="y"/> to a <see cref="MaxMath.byte8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesaturated(int4 x, int4 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x = RegisterConversion.ToV128(x);
                v128 _y = RegisterConversion.ToV128(y);

                v128 shorts = Xse.packs_epi32(_x, _y);

                return Xse.packus_epi16(shorts, shorts);
            }
            else
            {
                return (byte8)clamp(new int8(x, y), byte.MinValue, byte.MaxValue);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.int8"/> <paramref name="x"/> to a <see cref="MaxMath.byte8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesaturated(int8 x)
        {
            return tobytesaturated(x.v4_0, x.v4_4);
        }

        /// <summary>       Casts the <see cref="MaxMath.int8"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.byte16"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesaturated(int8 lo, int8 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 shorts = Avx2.mm256_packs_epi32(lo, hi);
                v256 bytes  = Avx2.mm256_packus_epi16(shorts, shorts);

                v128 ordered = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(bytes, Sse.SHUFFLE(0, 0, 2, 0)));
                ordered = Xse.shuffle_epi32(ordered, Sse.SHUFFLE(3, 1, 2, 0));

                return ordered;
            }
            else
            {
                return new byte16(tobytesaturated(lo),
                                  tobytesaturated(hi));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.int8"/>s <paramref name="x0_7"/>, <paramref name="x8_15"/>, <paramref name="x16_23"/> and <paramref name="x24_31"/> to a <see cref="MaxMath.byte32"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobytesaturated(int8 x0_7, int8 x8_15, int8 x16_23, int8 x24_31)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 shorts_lo = Avx2.mm256_packus_epi32(x0_7,   x8_15);
                v256 shorts_hi = Avx2.mm256_packus_epi32(x16_23, x24_31);

                v256 bytes = Avx2.mm256_packs_epi16(shorts_lo, shorts_hi);
                bytes = Avx2.mm256_permute4x64_epi64(bytes, Sse.SHUFFLE(3, 1, 2, 0));
                bytes = Avx2.mm256_shuffle_epi32(bytes, Sse.SHUFFLE(3, 1, 2, 0));

                return bytes;
            }
            else
            {
                return new byte32(tobytesaturated(x0_7),
                                  tobytesaturated(x8_15),
                                  tobytesaturated(x16_23),
                                  tobytesaturated(x24_31));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong2"/> <paramref name="x"/> to a <see cref="MaxMath.byte2"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesaturated(ulong2 x)
        {
            return (byte2)min(x, byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong3"/> <paramref name="x"/> to a <see cref="MaxMath.byte3"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesaturated(ulong3 x)
        {
            return (byte3)min(x, byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/> <paramref name="x"/> to a <see cref="MaxMath.byte4"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesaturated(ulong4 x)
        {
            return (byte4)min(x, byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/>s <paramref name="x"/> and <paramref name="y"/> to a <see cref="MaxMath.byte8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesaturated(ulong4 x, ulong4 y)
        {
            ulong4 MAX_VALUE = byte.MaxValue;

            return new byte8((byte4)min(x, MAX_VALUE),
                             (byte4)min(y, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/> to a <see cref="MaxMath.byte16"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesaturated(ulong4 x0_3, ulong4 x4_7, ulong4 x8_11, ulong4 x12_15)
        {
            ulong4 MAX_VALUE = byte.MaxValue;

            return new byte16((byte4)min(x0_3,   MAX_VALUE),
                              (byte4)min(x4_7,   MAX_VALUE),
                              (byte4)min(x8_11,  MAX_VALUE),
                              (byte4)min(x12_15, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/>, <paramref name="x16_19"/>, <paramref name="x20_23"/>, <paramref name="x24_27"/> and <paramref name="x28_31"/> to a <see cref="MaxMath.byte32"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobytesaturated(ulong4 x0_3, ulong4 x4_7, ulong4 x8_11, ulong4 x12_15, ulong4 x16_19, ulong4 x20_23, ulong4 x24_27, ulong4 x28_31)
        {
            ulong4 MAX_VALUE = byte.MaxValue;

            return new byte32((byte4)min(x0_3,   MAX_VALUE),
                              (byte4)min(x4_7,   MAX_VALUE),
                              (byte4)min(x8_11,  MAX_VALUE),
                              (byte4)min(x12_15, MAX_VALUE),
                              (byte4)min(x16_19, MAX_VALUE),
                              (byte4)min(x20_23, MAX_VALUE),
                              (byte4)min(x24_27, MAX_VALUE),
                              (byte4)min(x28_31, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.long2"/> <paramref name="x"/> to a <see cref="MaxMath.byte2"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesaturated(long2 x)
        {
            return (byte2)clamp(x, byte.MinValue, byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long3"/> <paramref name="x"/> to a <see cref="MaxMath.byte3"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesaturated(long3 x)
        {
            return (byte3)clamp(x, byte.MinValue, byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/> <paramref name="x"/> to a <see cref="MaxMath.byte4"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesaturated(long4 x)
        {
            return (byte4)clamp(x, byte.MinValue, byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/>s <paramref name="x"/> and <paramref name="y"/> to a <see cref="MaxMath.byte8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesaturated(long4 x, long4 y)
        {
            long4 MIN_VALUE = byte.MinValue;
            long4 MAX_VALUE = byte.MaxValue;

            return new byte8((byte4)clamp(x, MIN_VALUE, MAX_VALUE),
                             (byte4)clamp(y, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/> to a <see cref="MaxMath.byte16"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesaturated(long4 x0_3, long4 x4_7, long4 x8_11, long4 x12_15)
        {
            long4 MIN_VALUE = byte.MinValue;
            long4 MAX_VALUE = byte.MaxValue;

            return new byte16((byte4)clamp(x0_3,   MIN_VALUE, MAX_VALUE),
                              (byte4)clamp(x4_7,   MIN_VALUE, MAX_VALUE),
                              (byte4)clamp(x8_11,  MIN_VALUE, MAX_VALUE),
                              (byte4)clamp(x12_15, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/>, <paramref name="x16_19"/>, <paramref name="x20_23"/>, <paramref name="x24_27"/> and <paramref name="x28_31"/> to a <see cref="MaxMath.byte32"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobytesaturated(long4 x0_3, long4 x4_7, long4 x8_11, long4 x12_15, long4 x16_19, long4 x20_23, long4 x24_27, long4 x28_31)
        {
            long4 MIN_VALUE = byte.MinValue;
            long4 MAX_VALUE = byte.MaxValue;

            return new byte32((byte4)clamp(x0_3,   MIN_VALUE, MAX_VALUE),
                              (byte4)clamp(x4_7,   MIN_VALUE, MAX_VALUE),
                              (byte4)clamp(x8_11,  MIN_VALUE, MAX_VALUE),
                              (byte4)clamp(x12_15, MIN_VALUE, MAX_VALUE),
                              (byte4)clamp(x16_19, MIN_VALUE, MAX_VALUE),
                              (byte4)clamp(x20_23, MIN_VALUE, MAX_VALUE),
                              (byte4)clamp(x24_27, MIN_VALUE, MAX_VALUE),
                              (byte4)clamp(x28_31, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter2"/> <paramref name="x"/> to a <see cref="MaxMath.byte2"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesaturated(quarter2 x)
        {
            return tobytesaturated((float2)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter3"/> <paramref name="x"/> to a <see cref="MaxMath.byte3"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesaturated(quarter3 x)
        {
            return tobytesaturated((float3)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/> <paramref name="x"/> to a <see cref="MaxMath.byte4"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesaturated(quarter4 x)
        {
            return tobytesaturated((float4)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.byte8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesaturated(quarter4 lo, quarter4 hi)
        {
            return tobytesaturated((float4)lo, (float4)hi);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/> to an <see cref="MaxMath.byte16"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesaturated(quarter4 x0_3, quarter4 x4_7, quarter4 x8_11, quarter4 x12_15)
        {
            return tobytesaturated(new quarter8(x0_3, x4_7), new quarter8(x8_11, x12_15));
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/>, <paramref name="x16_19"/>, <paramref name="x20_23"/>, <paramref name="x24_27"/> and <paramref name="x28_31"/> to an <see cref="MaxMath.byte32"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobytesaturated(quarter4 x0_3, quarter4 x4_7, quarter4 x8_11, quarter4 x12_15, quarter4 x16_19, quarter4 x20_23, quarter4 x24_27, quarter4 x28_31)
        {
            return tobytesaturated(new quarter8(x0_3, x4_7), new quarter8(x8_11, x12_15), new quarter8(x16_19, x20_23), new quarter8(x24_27, x28_31));
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter8"/> <paramref name="x"/> to a <see cref="MaxMath.byte8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesaturated(quarter8 x)
        {
            return tobytesaturated((float8)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter8"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.byte16"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesaturated(quarter8 lo, quarter8 hi)
        {
            return tobytesaturated((float8)lo, (float8)hi);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter8"/>s <paramref name="x0_7"/>, <paramref name="x8_15"/>, <paramref name="x16_23"/> and <paramref name="x24_31"/> to a <see cref="MaxMath.byte32"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobytesaturated(quarter8 x0_7, quarter8 x8_15, quarter8 x16_23, quarter8 x24_31)
        {
            return tobytesaturated((float8)x0_7, (float8)x8_15, (float8)x16_23, (float8)x24_31);
        }

        /// <summary>       Casts the <see cref="half2"/> <paramref name="x"/> to a <see cref="MaxMath.byte2"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesaturated(half2 x)
        {
            return tobytesaturated((float2)x);
        }

        /// <summary>       Casts the <see cref="half3"/> <paramref name="x"/> to a <see cref="MaxMath.byte3"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesaturated(half3 x)
        {
            return tobytesaturated((float3)x);
        }

        /// <summary>       Casts the <see cref="half4"/> <paramref name="x"/> to a <see cref="MaxMath.byte4"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesaturated(half4 x)
        {
            return tobytesaturated((float4)x);
        }

        /// <summary>       Casts the <see cref="half4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.byte8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesaturated(half4 lo, half4 hi)
        {
            return tobytesaturated((float4)lo, (float4)hi);
        }

        /// <summary>       Casts the <see cref="half4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/> to an <see cref="MaxMath.byte16"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesaturated(half4 x0_3, half4 x4_7, half4 x8_11, half4 x12_15)
        {
            return tobytesaturated(new half8(x0_3, x4_7), new half8(x8_11, x12_15));
        }

        /// <summary>       Casts the <see cref="half4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/>, <paramref name="x16_19"/>, <paramref name="x20_23"/>, <paramref name="x24_27"/> and <paramref name="x28_31"/> to an <see cref="MaxMath.byte32"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobytesaturated(half4 x0_3, half4 x4_7, half4 x8_11, half4 x12_15, half4 x16_19, half4 x20_23, half4 x24_27, half4 x28_31)
        {
            return tobytesaturated(new half8(x0_3, x4_7), new half8(x8_11, x12_15), new half8(x16_19, x20_23), new half8(x24_27, x28_31));
        }

        /// <summary>       Casts the <see cref="MaxMath.half8"/> <paramref name="x"/> to a <see cref="MaxMath.byte8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesaturated(half8 x)
        {
            return tobytesaturated((float8)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.half8"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.byte16"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesaturated(half8 lo, half8 hi)
        {
            return tobytesaturated((float8)lo, (float8)hi);
        }

        /// <summary>       Casts the <see cref="MaxMath.half8"/>s <paramref name="x0_7"/>, <paramref name="x8_15"/>, <paramref name="x16_23"/> and <paramref name="x24_31"/> to a <see cref="MaxMath.byte32"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobytesaturated(half8 x0_7, half8 x8_15, half8 x16_23, half8 x24_31)
        {
            return tobytesaturated((float8)x0_7, (float8)x8_15, (float8)x16_23, (float8)x24_31);
        }

         /// <summary>       Casts the <see cref="float2"/> <paramref name="x"/> to a <see cref="MaxMath.byte2"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesaturated(float2 x)
        {
            return (byte2)math.clamp(x, (float)byte.MinValue, (float)byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="float3"/> <paramref name="x"/> to a <see cref="MaxMath.byte3"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesaturated(float3 x)
        {
            return (byte3)math.clamp(x, (float)byte.MinValue, (float)byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="float4"/> <paramref name="x"/> to a <see cref="MaxMath.byte4"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesaturated(float4 x)
        {
            return (byte4)math.clamp(x, (float)byte.MinValue, (float)byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="float4"/>s <paramref name="x"/> and <paramref name="y"/> to a <see cref="MaxMath.byte8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesaturated(float4 x, float4 y)
        {
            return (byte8)clamp(new float8(x, y), (float)byte.MinValue, (float)byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="float4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/> to an <see cref="MaxMath.byte16"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesaturated(float4 x0_3, float4 x4_7, float4 x8_11, float4 x12_15)
        {
            return tobytesaturated(new float8(x0_3, x4_7), new float8(x8_11, x12_15));
        }

        /// <summary>       Casts the <see cref="float4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/>, <paramref name="x16_19"/>, <paramref name="x20_23"/>, <paramref name="x24_27"/> and <paramref name="x28_31"/> to an <see cref="MaxMath.byte32"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobytesaturated(float4 x0_3, float4 x4_7, float4 x8_11, float4 x12_15, float4 x16_19, float4 x20_23, float4 x24_27, float4 x28_31)
        {
            return tobytesaturated(new float8(x0_3, x4_7), new float8(x8_11, x12_15), new float8(x16_19, x20_23), new float8(x24_27, x28_31));
        }

        /// <summary>       Casts the <see cref="MaxMath.float8"/> <paramref name="x"/> to a <see cref="MaxMath.byte8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesaturated(float8 x)
        {
            return (byte8)clamp(x, byte.MinValue, byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.float8"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.byte16"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesaturated(float8 lo, float8 hi)
        {
            float8 MIN_VALUE = (float)byte.MinValue;
            float8 MAX_VALUE = (float)byte.MaxValue;

            return new byte16((byte8)clamp(lo, MIN_VALUE, MAX_VALUE),
                              (byte8)clamp(hi, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.float8"/>s <paramref name="x0_7"/>, <paramref name="x8_15"/>, <paramref name="x16_23"/> and <paramref name="x24_31"/> to a <see cref="MaxMath.byte32"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobytesaturated(float8 x0_7, float8 x8_15, float8 x16_23, float8 x24_31)
        {
            float8 MIN_VALUE = (float)byte.MinValue;
            float8 MAX_VALUE = (float)byte.MaxValue;

            return new byte32((byte8)clamp(x0_7,   MIN_VALUE, MAX_VALUE),
                              (byte8)clamp(x8_15,  MIN_VALUE, MAX_VALUE),
                              (byte8)clamp(x16_23, MIN_VALUE, MAX_VALUE),
                              (byte8)clamp(x24_31, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="double2"/> <paramref name="x"/> to a <see cref="MaxMath.byte2"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobytesaturated(double2 x)
        {
            return (byte2)math.clamp(x, (double)byte.MinValue, (double)byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="double3"/> <paramref name="x"/> to a <see cref="MaxMath.byte3"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobytesaturated(double3 x)
        {
            return (byte3)math.clamp(x, (double)byte.MinValue, (double)byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/> <paramref name="x"/> to a <see cref="MaxMath.byte4"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobytesaturated(double4 x)
        {
            return (byte4)math.clamp(x, (double)byte.MinValue, (double)byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/>s <paramref name="x"/> and <paramref name="y"/> to a <see cref="MaxMath.byte8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobytesaturated(double4 x, double4 y)
        {
            double4 MIN_VALUE = (double)byte.MinValue;
            double4 MAX_VALUE = (double)byte.MaxValue;

            return new byte8((byte4)math.clamp(x, MIN_VALUE, MAX_VALUE),
                             (byte4)math.clamp(y, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="double4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/> to a <see cref="MaxMath.byte16"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobytesaturated(double4 x0_3, double4 x4_7, double4 x8_11, double4 x12_15)
        {
            double4 MIN_VALUE = (double)byte.MinValue;
            double4 MAX_VALUE = (double)byte.MaxValue;

            return new byte16((byte4)math.clamp(x0_3,   MIN_VALUE, MAX_VALUE),
                              (byte4)math.clamp(x4_7,   MIN_VALUE, MAX_VALUE),
                              (byte4)math.clamp(x8_11,  MIN_VALUE, MAX_VALUE),
                              (byte4)math.clamp(x12_15, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="double4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/>, <paramref name="x16_19"/>, <paramref name="x20_23"/>, <paramref name="x24_27"/> and <paramref name="x28_31"/> to a <see cref="MaxMath.byte32"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobytesaturated(double4 x0_3, double4 x4_7, double4 x8_11, double4 x12_15, double4 x16_19, double4 x20_23, double4 x24_27, double4 x28_31)
        {
            double4 MIN_VALUE = (double)byte.MinValue;
            double4 MAX_VALUE = (double)byte.MaxValue;

            return new byte32((byte4)math.clamp(x0_3,   MIN_VALUE, MAX_VALUE),
                              (byte4)math.clamp(x4_7,   MIN_VALUE, MAX_VALUE),
                              (byte4)math.clamp(x8_11,  MIN_VALUE, MAX_VALUE),
                              (byte4)math.clamp(x12_15, MIN_VALUE, MAX_VALUE),
                              (byte4)math.clamp(x16_19, MIN_VALUE, MAX_VALUE),
                              (byte4)math.clamp(x20_23, MIN_VALUE, MAX_VALUE),
                              (byte4)math.clamp(x24_27, MIN_VALUE, MAX_VALUE),
                              (byte4)math.clamp(x28_31, MIN_VALUE, MAX_VALUE));
        }
        #endregion

        #region To sbyte
        /// <summary>       Casts the <see cref="byte"/> <paramref name="x"/> to an <see cref="sbyte"/> and returns the result, which is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbytesaturated(byte x)
        {
            return (sbyte)math.min(x, sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="short"/> <paramref name="x"/> to an <see cref="sbyte"/> and returns the result, which is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbytesaturated(short x)
        {
            return (sbyte)math.clamp(x, sbyte.MinValue, sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="int"/> <paramref name="x"/> to an <see cref="sbyte"/> and returns the result, which is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbytesaturated(int x)
        {
            return (sbyte)math.clamp(x, sbyte.MinValue, sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="long"/> <paramref name="x"/> to an <see cref="sbyte"/> and returns the result, which is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbytesaturated(long x)
        {
            return (sbyte)math.clamp(x, sbyte.MinValue, sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="Int128"/> <paramref name="x"/> to a <see cref="sbyte"/> and returns the result, which is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbytesaturated(Int128 x)
        {
            return (sbyte)clamp(x, sbyte.MinValue, sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="ushort"/> <paramref name="x"/> to an <see cref="sbyte"/> and returns the result, which is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbytesaturated(ushort x)
        {
            return (sbyte)math.min(sbyte.MaxValue, (uint)x);
        }

        /// <summary>       Casts the <see cref="uint"/> <paramref name="x"/> to an <see cref="sbyte"/> and returns the result, which is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbytesaturated(uint x)
        {
            return (sbyte)math.min(sbyte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="ulong"/> <paramref name="x"/> to an <see cref="sbyte"/> and returns the result, which is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbytesaturated(ulong x)
        {
            return (sbyte)math.min(sbyte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="UInt128"/> <paramref name="x"/> to a <see cref="sbyte"/> and returns the result, which is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbytesaturated(UInt128 x)
        {
            return (sbyte)min((byte)sbyte.MaxValue, x);
        }


        /// <summary>       Casts the <see cref="quarter"/> <paramref name="x"/> to an <see cref="sbyte"/> and returns the result, which is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbytesaturated(quarter x)
        {
            return tosbytesaturated((float)x);
        }

        /// <summary>       Casts the <see cref="half"/> <paramref name="x"/> to an <see cref="sbyte"/> and returns the result, which is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbytesaturated(half x)
        {
            return tosbytesaturated((float)x);
        }

        /// <summary>       Casts the <see cref="float"/> <paramref name="x"/> to an <see cref="sbyte"/> and returns the result, which is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbytesaturated(float x)
        {
            return (sbyte)math.clamp(x, sbyte.MinValue, sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="double"/> <paramref name="x"/> to an <see cref="sbyte"/> and returns the result, which is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbytesaturated(double x)
        {
            return (sbyte)math.clamp(x, sbyte.MinValue, sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.byte2"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte2"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesaturated(byte2 x)
        {
            return (sbyte2)min((byte)sbyte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.byte3"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte3"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesaturated(byte3 x)
        {
            return (sbyte3)min((byte)sbyte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.byte4"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte4"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesaturated(byte4 x)
        {
            return (sbyte4)min((byte)sbyte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.byte8"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte8"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesaturated(byte8 x)
        {
            return (sbyte8)min((byte)sbyte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.byte16"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte16"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesaturated(byte16 x)
        {
            return (sbyte16)min((byte)sbyte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.byte32"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte32"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbytesaturated(byte32 x)
        {
            return (sbyte32)min((byte)sbyte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort2"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte2"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesaturated(ushort2 x)
        {
            return (sbyte2)min((ushort)sbyte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort3"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte3"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesaturated(ushort3 x)
        {
            return (sbyte3)min((ushort)sbyte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort4"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte4"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesaturated(ushort4 x)
        {
            return (sbyte4)min((ushort)sbyte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort8"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte8"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesaturated(ushort8 x)
        {
            return (sbyte8)min((ushort)sbyte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort16"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte16"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesaturated(ushort16 x)
        {
            return (sbyte16)min((ushort)sbyte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort8"/>s <paramref name="lo"/> and <paramref name="hi"/> to an <see cref="MaxMath.sbyte16"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesaturated(ushort8 lo, ushort8 hi)
        {
            ushort8 MAX_VALUE = (ushort)sbyte.MaxValue;

            return new sbyte16((sbyte8)min(MAX_VALUE, lo),
                               (sbyte8)min(MAX_VALUE, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort16"/>s <paramref name="lo"/> and <paramref name="hi"/> to an <see cref="MaxMath.sbyte32"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbytesaturated(ushort16 lo, ushort16 hi)
        {
            ushort16 MAX_VALUE = (ushort)sbyte.MaxValue;

            return new sbyte32((sbyte16)min(MAX_VALUE, lo),
                               (sbyte16)min(MAX_VALUE, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.short2"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte2"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesaturated(short2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.packs_epi16(x, x);
            }
            else
            {
                return new sbyte2(tosbytesaturated(x.x), tosbytesaturated(x.y));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short3"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte3"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesaturated(short3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.packs_epi16(x, x);
            }
            else
            {
                return new sbyte3(tosbytesaturated(x.x), tosbytesaturated(x.y), tosbytesaturated(x.z));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short4"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte4"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesaturated(short4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.packs_epi16(x, x);
            }
            else
            {
                return new sbyte4(tosbytesaturated(x.x), tosbytesaturated(x.y), tosbytesaturated(x.z), tosbytesaturated(x.w));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short8"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte8"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesaturated(short8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.packs_epi16(x, x);
            }
            else
            {
                return new sbyte8(tosbytesaturated(x.x0), tosbytesaturated(x.x1), tosbytesaturated(x.x2), tosbytesaturated(x.x3), tosbytesaturated(x.x4), tosbytesaturated(x.x5), tosbytesaturated(x.x6), tosbytesaturated(x.x7));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short16"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte16"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesaturated(short16 x)
        {
            return tosbytesaturated(x.v8_0, x.v8_8);
        }

        /// <summary>       Casts the <see cref="MaxMath.short8"/>s <paramref name="lo"/> and <paramref name="hi"/> to an <see cref="MaxMath.sbyte16"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesaturated(short8 lo, short8 hi)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.packs_epi16(lo, hi);
            }
            else
            {
                return new sbyte16(tosbytesaturated(lo.x0), tosbytesaturated(lo.x1), tosbytesaturated(lo.x2), tosbytesaturated(lo.x3), tosbytesaturated(lo.x4), tosbytesaturated(lo.x5), tosbytesaturated(lo.x6), tosbytesaturated(lo.x7),
                                   tosbytesaturated(hi.x0), tosbytesaturated(hi.x1), tosbytesaturated(hi.x2), tosbytesaturated(hi.x3), tosbytesaturated(hi.x4), tosbytesaturated(hi.x5), tosbytesaturated(hi.x6), tosbytesaturated(hi.x7));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short16"/>s <paramref name="lo"/> and <paramref name="hi"/> to an <see cref="MaxMath.sbyte32"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbytesaturated(short16 lo, short16 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 packed = Avx2.mm256_packs_epi16(lo, hi);

                return Avx2.mm256_permute4x64_epi64(packed, Sse.SHUFFLE(3, 1, 2, 0));
            }
            else
            {
                return new sbyte32(tosbytesaturated(lo), tosbytesaturated(hi));
            }
        }

        /// <summary>       Casts the <see cref="uint2"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte2"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesaturated(uint2 x)
        {
            return (sbyte2)math.min((uint)sbyte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="uint3"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte3"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesaturated(uint3 x)
        {
            return (sbyte3)math.min((uint)sbyte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="uint4"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte4"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesaturated(uint4 x)
        {
            return (sbyte4)math.min((uint)sbyte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="uint4"/>s <paramref name="x"/> and <paramref name="y"/> to an <see cref="MaxMath.sbyte8"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesaturated(uint4 x, uint4 y)
        {
            return (sbyte8)min(new uint8(x, y), sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.uint8"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte8"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesaturated(uint8 x)
        {
            return (sbyte8)min((uint)sbyte.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.uint8"/>s <paramref name="lo"/> and <paramref name="hi"/> to an <see cref="MaxMath.sbyte16"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesaturated(uint8 lo, uint8 hi)
        {
            uint8 MAX_VALUE = (uint)sbyte.MaxValue;

            return new sbyte16((sbyte8)min(MAX_VALUE, lo),
                               (sbyte8)min(MAX_VALUE, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.uint8"/>s <paramref name="x0_7"/>, <paramref name="x8_15"/>, <paramref name="x16_23"/> and <paramref name="x24_31"/> to an <see cref="MaxMath.sbyte32"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbytesaturated(uint8 x0_7, uint8 x8_15, uint8 x16_23, uint8 x24_31)
        {
            uint8 MAX_VALUE = (uint)sbyte.MaxValue;

            return new sbyte32((sbyte8)min(MAX_VALUE, x0_7),
                               (sbyte8)min(MAX_VALUE, x8_15),
                               (sbyte8)min(MAX_VALUE, x16_23),
                               (sbyte8)min(MAX_VALUE, x24_31));
        }

        /// <summary>       Casts the <see cref="int2"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte2"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesaturated(int2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                v128 shorts = Xse.packs_epi32(_x, _x);

                return Xse.packs_epi16(shorts, shorts);
            }
            else
            {
                return (sbyte2)math.clamp(x, sbyte.MinValue, sbyte.MaxValue);
            }
        }

        /// <summary>       Casts the <see cref="int3"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte3"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesaturated(int3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                v128 shorts = Xse.packs_epi32(_x, _x);

                return Xse.packs_epi16(shorts, shorts);
            }
            else
            {
                return (sbyte3)math.clamp(x, sbyte.MinValue, sbyte.MaxValue);
            }
        }

        /// <summary>       Casts the <see cref="int4"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte4"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesaturated(int4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                v128 shorts = Xse.packs_epi32(_x, _x);

                return Xse.packs_epi16(shorts, shorts);
            }
            else
            {
                return (sbyte4)math.clamp(x, sbyte.MinValue, sbyte.MaxValue);
            }
        }

        /// <summary>       Casts the <see cref="int4"/>s <paramref name="x"/> and <paramref name="y"/> to an <see cref="MaxMath.sbyte8"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesaturated(int4 x, int4 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x = RegisterConversion.ToV128(x);
                v128 _y = RegisterConversion.ToV128(y);

                v128 shorts = Xse.packs_epi32(_x, _y);

                return Xse.packs_epi16(shorts, shorts);
            }
            else
            {
                return (sbyte8)clamp(new int8(x, y), sbyte.MinValue, sbyte.MaxValue);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.int8"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte8"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesaturated(int8 x)
        {
            return tosbytesaturated(x.v4_0, x.v4_4);
        }

        /// <summary>       Casts the <see cref="MaxMath.int8"/>s <paramref name="lo"/> and <paramref name="hi"/> to an <see cref="MaxMath.sbyte16"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesaturated(int8 lo, int8 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 shorts = Avx2.mm256_packs_epi32(lo, hi);
                v256 bytes  = Avx2.mm256_packs_epi16(shorts, shorts);

                v128 ordered = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(bytes, Sse.SHUFFLE(0, 0, 2, 0)));
                ordered = Xse.shuffle_epi32(ordered, Sse.SHUFFLE(3, 1, 2, 0));

                return ordered;
            }
            else
            {
                return new sbyte16(tosbytesaturated(lo),
                                   tosbytesaturated(hi));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.int8"/>s <paramref name="x0_7"/>, <paramref name="x8_15"/>, <paramref name="x16_23"/> and <paramref name="x24_31"/> to an <see cref="MaxMath.sbyte32"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbytesaturated(int8 x0_7, int8 x8_15, int8 x16_23, int8 x24_31)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 shorts_lo = Avx2.mm256_packs_epi32(x0_7,   x8_15);
                v256 shorts_hi = Avx2.mm256_packs_epi32(x16_23, x24_31);

                v256 bytes = Avx2.mm256_packs_epi16(shorts_lo, shorts_hi);
                bytes = Avx2.mm256_permute4x64_epi64(bytes, Sse.SHUFFLE(3, 1, 2, 0));
                bytes = Avx2.mm256_shuffle_epi32(bytes, Sse.SHUFFLE(3, 1, 2, 0));

                return bytes;
            }
            else
            {
                return new sbyte32(tosbytesaturated(x0_7),
                                   tosbytesaturated(x8_15),
                                   tosbytesaturated(x16_23),
                                   tosbytesaturated(x24_31));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong2"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte2"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesaturated(ulong2 x)
        {
            return (sbyte2)min(x, (ulong)sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong3"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte3"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesaturated(ulong3 x)
        {
            return (sbyte3)min(x, (ulong)sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte4"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesaturated(ulong4 x)
        {
            return (sbyte4)min(x, (ulong)sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/>s <paramref name="x"/> and <paramref name="y"/> to an <see cref="MaxMath.sbyte8"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesaturated(ulong4 x, ulong4 y)
        {
            ulong4 MAX_VALUE = (ulong)sbyte.MaxValue;

            return new sbyte8((sbyte4)min(x, MAX_VALUE),
                              (sbyte4)min(y, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/> to an <see cref="MaxMath.sbyte16"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesaturated(ulong4 x0_3, ulong4 x4_7, ulong4 x8_11, ulong4 x12_15)
        {
            ulong4 MAX_VALUE = (ulong)sbyte.MaxValue;

            return new sbyte16((sbyte4)min(x0_3,   MAX_VALUE),
                               (sbyte4)min(x4_7,   MAX_VALUE),
                               (sbyte4)min(x8_11,  MAX_VALUE),
                               (sbyte4)min(x12_15, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/>, <paramref name="x16_19"/>, <paramref name="x20_23"/>, <paramref name="x24_27"/> and <paramref name="x28_31"/> to an <see cref="MaxMath.sbyte32"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbytesaturated(ulong4 x0_3, ulong4 x4_7, ulong4 x8_11, ulong4 x12_15, ulong4 x16_19, ulong4 x20_23, ulong4 x24_27, ulong4 x28_31)
        {
            ulong4 MAX_VALUE = (ulong)sbyte.MaxValue;

            return new sbyte32((sbyte4)min(x0_3,   MAX_VALUE),
                               (sbyte4)min(x4_7,   MAX_VALUE),
                               (sbyte4)min(x8_11,  MAX_VALUE),
                               (sbyte4)min(x12_15, MAX_VALUE),
                               (sbyte4)min(x16_19, MAX_VALUE),
                               (sbyte4)min(x20_23, MAX_VALUE),
                               (sbyte4)min(x24_27, MAX_VALUE),
                               (sbyte4)min(x28_31, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.long2"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte2"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesaturated(long2 x)
        {
            return (sbyte2)clamp(x, sbyte.MinValue, sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long3"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte3"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesaturated(long3 x)
        {
            return (sbyte3)clamp(x, sbyte.MinValue, sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte4"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesaturated(long4 x)
        {
            return (sbyte4)clamp(x, sbyte.MinValue, sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/>s <paramref name="x"/> and <paramref name="y"/> to an <see cref="MaxMath.sbyte8"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesaturated(long4 x, long4 y)
        {
            long4 MIN_VALUE = sbyte.MinValue;
            long4 MAX_VALUE = sbyte.MaxValue;

            return new sbyte8((sbyte4)clamp(x, MIN_VALUE, MAX_VALUE),
                              (sbyte4)clamp(y, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/> to an <see cref="MaxMath.sbyte16"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesaturated(long4 x0_3, long4 x4_7, long4 x8_11, long4 x12_15)
        {
            long4 MIN_VALUE = sbyte.MinValue;
            long4 MAX_VALUE = sbyte.MaxValue;

            return new sbyte16((sbyte4)clamp(x0_3,   MIN_VALUE, MAX_VALUE),
                               (sbyte4)clamp(x4_7,   MIN_VALUE, MAX_VALUE),
                               (sbyte4)clamp(x8_11,  MIN_VALUE, MAX_VALUE),
                               (sbyte4)clamp(x12_15, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/>, <paramref name="x16_19"/>, <paramref name="x20_23"/>, <paramref name="x24_27"/> and <paramref name="x28_31"/> to an <see cref="MaxMath.sbyte32"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbytesaturated(long4 x0_3, long4 x4_7, long4 x8_11, long4 x12_15, long4 x16_19, long4 x20_23, long4 x24_27, long4 x28_31)
        {
            long4 MIN_VALUE = sbyte.MinValue;
            long4 MAX_VALUE = sbyte.MaxValue;

            return new sbyte32((sbyte4)clamp(x0_3,   MIN_VALUE, MAX_VALUE),
                               (sbyte4)clamp(x4_7,   MIN_VALUE, MAX_VALUE),
                               (sbyte4)clamp(x8_11,  MIN_VALUE, MAX_VALUE),
                               (sbyte4)clamp(x12_15, MIN_VALUE, MAX_VALUE),
                               (sbyte4)clamp(x16_19, MIN_VALUE, MAX_VALUE),
                               (sbyte4)clamp(x20_23, MIN_VALUE, MAX_VALUE),
                               (sbyte4)clamp(x24_27, MIN_VALUE, MAX_VALUE),
                               (sbyte4)clamp(x28_31, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter2"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte2"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesaturated(quarter2 x)
        {
            return tosbytesaturated((float2)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter3"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte3"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesaturated(quarter3 x)
        {
            return tosbytesaturated((float3)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte4"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesaturated(quarter4 x)
        {
            return tosbytesaturated((float4)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/>s <paramref name="x"/> and <paramref name="y"/> to an <see cref="MaxMath.sbyte8"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesaturated(quarter4 x, quarter4 y)
        {
            return tosbytesaturated((float4)x, (float4)y);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/> to an <see cref="MaxMath.sbyte16"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesaturated(quarter4 x0_3, quarter4 x4_7, quarter4 x8_11, quarter4 x12_15)
        {
            return tosbytesaturated(new quarter8(x0_3, x4_7), new quarter8(x8_11, x12_15));
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/>, <paramref name="x16_19"/>, <paramref name="x20_23"/>, <paramref name="x24_27"/> and <paramref name="x28_31"/> to an <see cref="MaxMath.sbyte32"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbytesaturated(quarter4 x0_3, quarter4 x4_7, quarter4 x8_11, quarter4 x12_15, quarter4 x16_19, quarter4 x20_23, quarter4 x24_27, quarter4 x28_31)
        {
            return tosbytesaturated(new quarter8(x0_3, x4_7), new quarter8(x8_11, x12_15), new quarter8(x16_19, x20_23), new quarter8(x24_27, x28_31));
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter8"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte8"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesaturated(quarter8 x)
        {
            return tosbytesaturated((float8)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter8"/>s <paramref name="lo"/> and <paramref name="hi"/> to an <see cref="MaxMath.sbyte16"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesaturated(quarter8 lo, quarter8 hi)
        {
            return tosbytesaturated((float8)lo, (float8)hi);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter8"/>s <paramref name="x0_7"/>, <paramref name="x8_15"/>, <paramref name="x16_23"/> and <paramref name="x24_31"/> to an <see cref="MaxMath.sbyte32"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbytesaturated(quarter8 x0_7, quarter8 x8_15, quarter8 x16_23, quarter8 x24_31)
        {
            return tosbytesaturated((float8)x0_7, (float8)x8_15, (float8)x16_23, (float8)x24_31);
        }

        /// <summary>       Casts the <see cref="half2"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte2"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesaturated(half2 x)
        {
            return tosbytesaturated((float2)x);
        }

        /// <summary>       Casts the <see cref="half3"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte3"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesaturated(half3 x)
        {
            return tosbytesaturated((float3)x);
        }

        /// <summary>       Casts the <see cref="half4"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte4"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesaturated(half4 x)
        {
            return tosbytesaturated((float4)x);
        }

        /// <summary>       Casts the <see cref="half4"/>s <paramref name="x"/> and <paramref name="y"/> to an <see cref="MaxMath.sbyte8"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesaturated(half4 x, half4 y)
        {
            return tosbytesaturated((float4)x, (float4)y);
        }

        /// <summary>       Casts the <see cref="half4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/> to an <see cref="MaxMath.sbyte16"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesaturated(half4 x0_3, half4 x4_7, half4 x8_11, half4 x12_15)
        {
            return tosbytesaturated(new half8(x0_3, x4_7), new half8(x8_11, x12_15));
        }

        /// <summary>       Casts the <see cref="half4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/>, <paramref name="x16_19"/>, <paramref name="x20_23"/>, <paramref name="x24_27"/> and <paramref name="x28_31"/> to an <see cref="MaxMath.sbyte32"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbytesaturated(half4 x0_3, half4 x4_7, half4 x8_11, half4 x12_15, half4 x16_19, half4 x20_23, half4 x24_27, half4 x28_31)
        {
            return tosbytesaturated(new half8(x0_3, x4_7), new half8(x8_11, x12_15), new half8(x16_19, x20_23), new half8(x24_27, x28_31));
        }

        /// <summary>       Casts the <see cref="MaxMath.half8"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte8"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesaturated(half8 x)
        {
            return tosbytesaturated((float8)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.half8"/>s <paramref name="lo"/> and <paramref name="hi"/> to an <see cref="MaxMath.sbyte16"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesaturated(half8 lo, half8 hi)
        {
            return tosbytesaturated((float8)lo, (float8)hi);
        }

        /// <summary>       Casts the <see cref="MaxMath.half8"/>s <paramref name="x0_7"/>, <paramref name="x8_15"/>, <paramref name="x16_23"/> and <paramref name="x24_31"/> to an <see cref="MaxMath.sbyte32"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbytesaturated(half8 x0_7, half8 x8_15, half8 x16_23, half8 x24_31)
        {
            return tosbytesaturated((float8)x0_7, (float8)x8_15, (float8)x16_23, (float8)x24_31);
        }

        /// <summary>       Casts the <see cref="float2"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte2"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesaturated(float2 x)
        {
            return (sbyte2)math.clamp(x, sbyte.MinValue, sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="float3"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte3"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesaturated(float3 x)
        {
            return (sbyte3)math.clamp(x, sbyte.MinValue, sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="float4"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte4"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesaturated(float4 x)
        {
            return (sbyte4)math.clamp(x, sbyte.MinValue, sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="float4"/>s <paramref name="x"/> and <paramref name="y"/> to an <see cref="MaxMath.sbyte8"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesaturated(float4 x, float4 y)
        {
            return (sbyte8)clamp(new float8(x, y), sbyte.MinValue, sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="float4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/> to an <see cref="MaxMath.sbyte16"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesaturated(float4 x0_3, float4 x4_7, float4 x8_11, float4 x12_15)
        {
            return tosbytesaturated(new float8(x0_3, x4_7), new float8(x8_11, x12_15));
        }

        /// <summary>       Casts the <see cref="float4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/>, <paramref name="x16_19"/>, <paramref name="x20_23"/>, <paramref name="x24_27"/> and <paramref name="x28_31"/> to an <see cref="MaxMath.sbyte32"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbytesaturated(float4 x0_3, float4 x4_7, float4 x8_11, float4 x12_15, float4 x16_19, float4 x20_23, float4 x24_27, float4 x28_31)
        {
            return tosbytesaturated(new float8(x0_3, x4_7), new float8(x8_11, x12_15), new float8(x16_19, x20_23), new float8(x24_27, x28_31));
        }

        /// <summary>       Casts the <see cref="MaxMath.float8"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte8"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesaturated(float8 x)
        {
            return (sbyte8)clamp(x, sbyte.MinValue, sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.float8"/>s <paramref name="lo"/> and <paramref name="hi"/> to an <see cref="MaxMath.sbyte16"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesaturated(float8 lo, float8 hi)
        {
            float8 MIN_VALUE = sbyte.MinValue;
            float8 MAX_VALUE = sbyte.MaxValue;

            return new sbyte16((sbyte8)clamp(lo, MIN_VALUE, MAX_VALUE),
                               (sbyte8)clamp(hi, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.float8"/>s <paramref name="x0_7"/>, <paramref name="x8_15"/>, <paramref name="x16_23"/> and <paramref name="x24_31"/> to an <see cref="MaxMath.sbyte32"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbytesaturated(float8 x0_7, float8 x8_15, float8 x16_23, float8 x24_31)
        {
            float8 MIN_VALUE = sbyte.MinValue;
            float8 MAX_VALUE = sbyte.MaxValue;

            return new sbyte32((sbyte8)clamp(x0_7,   MIN_VALUE, MAX_VALUE),
                               (sbyte8)clamp(x8_15,  MIN_VALUE, MAX_VALUE),
                               (sbyte8)clamp(x16_23, MIN_VALUE, MAX_VALUE),
                               (sbyte8)clamp(x24_31, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="double2"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte2"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbytesaturated(double2 x)
        {
            return (sbyte2)math.clamp(x, (double)sbyte.MinValue, (double)sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="double3"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte3"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbytesaturated(double3 x)
        {
            return (sbyte3)math.clamp(x, (double)sbyte.MinValue, (double)sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/> <paramref name="x"/> to an <see cref="MaxMath.sbyte4"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbytesaturated(double4 x)
        {
            return (sbyte4)math.clamp(x, (double)sbyte.MinValue, (double)sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/>s <paramref name="x"/> and <paramref name="y"/> to an <see cref="MaxMath.sbyte8"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbytesaturated(double4 x, double4 y)
        {
            double4 MIN_VALUE = (double)sbyte.MinValue;
            double4 MAX_VALUE = (double)sbyte.MaxValue;

            return new sbyte8((sbyte4)math.clamp(x, MIN_VALUE, MAX_VALUE),
                              (sbyte4)math.clamp(y, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="double4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/> to an <see cref="MaxMath.sbyte16"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbytesaturated(double4 x0_3, double4 x4_7, double4 x8_11, double4 x12_15)
        {
            double4 MIN_VALUE = (double)sbyte.MinValue;
            double4 MAX_VALUE = (double)sbyte.MaxValue;

            return new sbyte16((sbyte4)math.clamp(x0_3,   MIN_VALUE, MAX_VALUE),
                               (sbyte4)math.clamp(x4_7,   MIN_VALUE, MAX_VALUE),
                               (sbyte4)math.clamp(x8_11,  MIN_VALUE, MAX_VALUE),
                               (sbyte4)math.clamp(x12_15, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="double4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/>, <paramref name="x12_15"/>, <paramref name="x16_19"/>, <paramref name="x20_23"/>, <paramref name="x24_27"/> and <paramref name="x28_31"/> to an <see cref="MaxMath.sbyte32"/> and returns the result, where each component is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbytesaturated(double4 x0_3, double4 x4_7, double4 x8_11, double4 x12_15, double4 x16_19, double4 x20_23, double4 x24_27, double4 x28_31)
        {
            double4 MIN_VALUE = (double)sbyte.MinValue;
            double4 MAX_VALUE = (double)sbyte.MaxValue;

            return new sbyte32((sbyte4)math.clamp(x0_3,   MIN_VALUE, MAX_VALUE),
                               (sbyte4)math.clamp(x4_7,   MIN_VALUE, MAX_VALUE),
                               (sbyte4)math.clamp(x8_11,  MIN_VALUE, MAX_VALUE),
                               (sbyte4)math.clamp(x12_15, MIN_VALUE, MAX_VALUE),
                               (sbyte4)math.clamp(x16_19, MIN_VALUE, MAX_VALUE),
                               (sbyte4)math.clamp(x20_23, MIN_VALUE, MAX_VALUE),
                               (sbyte4)math.clamp(x24_27, MIN_VALUE, MAX_VALUE),
                               (sbyte4)math.clamp(x28_31, MIN_VALUE, MAX_VALUE));
        }
        #endregion

        #region To ushort
        /// <summary>       Casts the <see cref="sbyte"/> <paramref name="x"/> to a <see cref="ushort"/> and returns the result, which is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushortsaturated(sbyte x)
        {
            return (ushort)math.max(x, ushort.MinValue);
        }

        /// <summary>       Casts the <see cref="short"/> <paramref name="x"/> to a <see cref="ushort"/> and returns the result, which is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushortsaturated(short x)
        {
            return (ushort)math.max(x, ushort.MinValue);
        }

        /// <summary>       Casts the <see cref="int"/> <paramref name="x"/> to a <see cref="ushort"/> and returns the result, which is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushortsaturated(int x)
        {
            return (ushort)math.clamp(x, ushort.MinValue, ushort.MaxValue);
        }

        /// <summary>       Casts the <see cref="long"/> <paramref name="x"/> to a <see cref="ushort"/> and returns the result, which is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushortsaturated(long x)
        {
            return (ushort)math.clamp(x, ushort.MinValue, ushort.MaxValue);
        }

        /// <summary>       Casts the <see cref="Int128"/> <paramref name="x"/> to a <see cref="ushort"/> and returns the result, which is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushortsaturated(Int128 x)
        {
            return (ushort)clamp(x, ushort.MinValue, ushort.MaxValue);
        }


        /// <summary>       Casts the <see cref="ushort"/> <paramref name="x"/> to a <see cref="ushort"/> and returns the result, which is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushortsaturated(ushort x)
        {
            return (ushort)math.min(ushort.MaxValue, (uint)x);
        }

        /// <summary>       Casts the <see cref="uint"/> <paramref name="x"/> to a <see cref="ushort"/> and returns the result, which is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushortsaturated(uint x)
        {
            return (ushort)math.min(ushort.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="ulong"/> <paramref name="x"/> to a <see cref="ushort"/> and returns the result, which is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushortsaturated(ulong x)
        {
            return (ushort)math.min(ushort.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="UInt128"/> <paramref name="x"/> to a <see cref="ushort"/> and returns the result, which is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushortsaturated(UInt128 x)
        {
            return (ushort)min(ushort.MaxValue, x);
        }


        /// <summary>       Casts the <see cref="quarter"/> <paramref name="x"/> to a <see cref="ushort"/> and returns the result, which is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushortsaturated(quarter x)
        {
            return toushortsaturated((float)x);
        }
        /// <summary>       Casts the <see cref="half"/> <paramref name="x"/> to a <see cref="ushort"/> and returns the result, which is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushortsaturated(half x)
        {
            return toushortsaturated((float)x);
        }

        /// <summary>       Casts the <see cref="float"/> <paramref name="x"/> to a <see cref="ushort"/> and returns the result, which is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushortsaturated(float x)
        {
            return (ushort)math.clamp(x, ushort.MinValue, ushort.MaxValue);
        }

        /// <summary>       Casts the <see cref="double"/> <paramref name="x"/> to a <see cref="ushort"/> and returns the result, which is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushortsaturated(double x)
        {
            return (ushort)math.clamp(x, ushort.MinValue, ushort.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte2"/> <paramref name="x"/> to a <see cref="MaxMath.ushort2"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushortsaturated(sbyte2 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return (ushort2)max((sbyte)ushort.MinValue, x);
            }
            else
            {
                return (ushort2)(byte2)max((sbyte)ushort.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte3"/> <paramref name="x"/> to a <see cref="MaxMath.ushort3"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushortsaturated(sbyte3 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return (ushort3)max((sbyte)ushort.MinValue, x);
            }
            else
            {
                return (ushort3)(byte3)max((sbyte)ushort.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte4"/> <paramref name="x"/> to a <see cref="MaxMath.ushort4"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushortsaturated(sbyte4 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return (ushort4)max((sbyte)ushort.MinValue, x);
            }
            else
            {
                return (ushort4)(byte4)max((sbyte)ushort.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte8"/> <paramref name="x"/> to a <see cref="MaxMath.ushort8"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsaturated(sbyte8 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return (ushort8)max((sbyte)ushort.MinValue, x);
            }
            else
            {
                return (ushort8)(byte8)max((sbyte)ushort.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short16"/> <paramref name="x"/> to a <see cref="MaxMath.ushort16"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushortsaturated(sbyte16 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return (ushort16)max((sbyte)ushort.MinValue, x);
            }
            else
            {
                return (ushort16)(byte16)max((sbyte)ushort.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short2"/> <paramref name="x"/> to a <see cref="MaxMath.ushort2"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushortsaturated(short2 x)
        {
            return (ushort2)max((short)ushort.MinValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.short3"/> <paramref name="x"/> to a <see cref="MaxMath.ushort3"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushortsaturated(short3 x)
        {
            return (ushort3)max((short)ushort.MinValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.short4"/> <paramref name="x"/> to a <see cref="MaxMath.ushort4"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushortsaturated(short4 x)
        {
            return (ushort4)max((short)ushort.MinValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.short8"/> <paramref name="x"/> to a <see cref="MaxMath.ushort8"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsaturated(short8 x)
        {
            return (ushort8)max((short)ushort.MinValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.short16"/> <paramref name="x"/> to a <see cref="MaxMath.ushort16"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushortsaturated(short16 x)
        {
            return (ushort16)max((short)ushort.MinValue, x);
        }

        /// <summary>       Casts the <see cref="int2"/> <paramref name="x"/> to a <see cref="MaxMath.ushort2"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushortsaturated(int2 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                return Xse.packus_epi32(_x, _x);
            }
            else
            {
                return (ushort2)math.clamp(x, ushort.MinValue, ushort.MaxValue);
            }
        }

        /// <summary>       Casts the <see cref="int3"/> <paramref name="x"/> to a <see cref="MaxMath.ushort3"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushortsaturated(int3 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                return Xse.packus_epi32(_x, _x);
            }
            else
            {
                return (ushort3)math.clamp(x, ushort.MinValue, ushort.MaxValue);
            }
        }

        /// <summary>       Casts the <see cref="int4"/> <paramref name="x"/> to a <see cref="MaxMath.ushort4"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushortsaturated(int4 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                return Xse.packus_epi32(_x, _x);
            }
            else
            {
                return (ushort4)math.clamp(x, ushort.MinValue, ushort.MaxValue);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.int8"/> <paramref name="x"/> to a <see cref="MaxMath.ushort8"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsaturated(int8 x)
        {
            return toushortsaturated(x.v4_0, x.v4_4);
        }

        /// <summary>       Casts the <see cref="int4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.ushort8"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsaturated(int4 lo, int4 hi)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 _lo = RegisterConversion.ToV128(lo);
                v128 _hi = RegisterConversion.ToV128(hi);

                return Xse.packus_epi32(_lo, _hi);
            }
            else
            {
                return new ushort8((ushort4)math.clamp(lo, ushort.MinValue, ushort.MaxValue),
                                   (ushort4)math.clamp(hi, ushort.MinValue, ushort.MaxValue));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.int8"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.ushort16"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushortsaturated(int8 lo, int8 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 packed = Avx2.mm256_packus_epi32(lo, hi);

                return Avx2.mm256_permute4x64_epi64(packed, Sse.SHUFFLE(3, 1, 2, 0));
            }
            else
            {
                return new ushort16(toushortsaturated(lo), toushortsaturated(hi));
            }
        }

        /// <summary>       Casts the <see cref="uint2"/> <paramref name="x"/> to a <see cref="MaxMath.ushort2"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushortsaturated(uint2 x)
        {
            return (ushort2)math.min((uint)ushort.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="uint3"/> <paramref name="x"/> to a <see cref="MaxMath.ushort3"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushortsaturated(uint3 x)
        {
            return (ushort3)math.min((uint)ushort.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="uint4"/> <paramref name="x"/> to a <see cref="MaxMath.ushort4"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushortsaturated(uint4 x)
        {
            return (ushort4)math.min((uint)ushort.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.uint8"/> <paramref name="x"/> to a <see cref="MaxMath.ushort8"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsaturated(uint8 x)
        {
            return (ushort8)min((uint)ushort.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="uint4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.ushort8"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsaturated(uint4 lo, uint4 hi)
        {
            return (ushort8)min((uint)ushort.MaxValue, new uint8(lo, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.uint8"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.ushort16"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushortsaturated(uint8 lo, uint8 hi)
        {
            uint8 MAX_VALUE = (uint)ushort.MaxValue;

            return new ushort16((ushort8)min(MAX_VALUE, lo), (ushort8)min(MAX_VALUE, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.long2"/> <paramref name="x"/> to a <see cref="MaxMath.ushort2"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushortsaturated(long2 x)
        {
            return (ushort2)clamp(x, ushort.MinValue, ushort.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long3"/> <paramref name="x"/> to a <see cref="MaxMath.ushort3"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushortsaturated(long3 x)
        {
            return (ushort3)clamp(x, ushort.MinValue, ushort.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/> <paramref name="x"/> to a <see cref="MaxMath.ushort4"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushortsaturated(long4 x)
        {
            return (ushort4)clamp(x, ushort.MinValue, ushort.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.ushort8"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsaturated(long4 lo, long4 hi)
        {
            long4 MIN_VALUE = ushort.MinValue;
            long4 MAX_VALUE = ushort.MaxValue;

            return new ushort8((ushort4)clamp(lo, MIN_VALUE, MAX_VALUE),
                               (ushort4)clamp(hi, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/> and <paramref name="x12_15"/> to a <see cref="MaxMath.ushort16"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushortsaturated(long4 x0_3, long4 x4_7, long4 x8_11, long4 x12_15)
        {
            long4 MIN_VALUE = ushort.MinValue;
            long4 MAX_VALUE = ushort.MaxValue;

            return new ushort16((ushort4)clamp(x0_3,   MIN_VALUE, MAX_VALUE),
                                (ushort4)clamp(x4_7,   MIN_VALUE, MAX_VALUE),
                                (ushort4)clamp(x8_11,  MIN_VALUE, MAX_VALUE),
                                (ushort4)clamp(x12_15, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong2"/> <paramref name="x"/> to a <see cref="MaxMath.ushort2"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushortsaturated(ulong2 x)
        {
            return (ushort2)min((ulong)ushort.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong3"/> <paramref name="x"/> to a <see cref="MaxMath.ushort3"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushortsaturated(ulong3 x)
        {
            return (ushort3)min((ulong)ushort.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/> <paramref name="x"/> to a <see cref="MaxMath.ushort4"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushortsaturated(ulong4 x)
        {
            return (ushort4)min((ulong)ushort.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.ushort8"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsaturated(ulong4 lo, ulong4 hi)
        {
            ulong4 MAX_VALUE = (ulong)ushort.MaxValue;

            return new ushort8((ushort4)min(MAX_VALUE, lo),
                               (ushort4)min(MAX_VALUE, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/> and <paramref name="x12_15"/> to a <see cref="MaxMath.ushort16"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushortsaturated(ulong4 x0_3, ulong4 x4_7, ulong4 x8_11, ulong4 x12_15)
        {
            ulong4 MAX_VALUE = (ulong)ushort.MaxValue;

            return new ushort16((ushort4)min(x0_3,   MAX_VALUE),
                                (ushort4)min(x4_7,   MAX_VALUE),
                                (ushort4)min(x8_11,  MAX_VALUE),
                                (ushort4)min(x12_15, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter2"/> <paramref name="x"/> to a <see cref="MaxMath.ushort2"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushortsaturated(quarter2 x)
        {
            return toushortsaturated((float2)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter3"/> <paramref name="x"/> to a <see cref="MaxMath.ushort3"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushortsaturated(quarter3 x)
        {
            return toushortsaturated((float3)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/> <paramref name="x"/> to a <see cref="MaxMath.ushort4"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushortsaturated(quarter4 x)
        {
            return toushortsaturated((float4)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/> and <paramref name="x12_15"/> to a <see cref="MaxMath.ushort16"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushortsaturated(quarter4 x0_3, quarter4 x4_7, quarter4 x8_11, quarter4 x12_15)
        {
            return toushortsaturated(new quarter8(x0_3, x4_7), new quarter8(x8_11, x12_15));
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.ushort8"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsaturated(quarter4 lo, quarter4 hi)
        {
            return toushortsaturated(new float8(lo, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter8"/> <paramref name="x"/> to a <see cref="MaxMath.ushort8"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsaturated(quarter8 x)
        {
            return toushortsaturated((float8)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter8"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.ushort16"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushortsaturated(quarter8 lo, quarter8 hi)
        {
            return toushortsaturated((float8)lo, (float8)hi);
        }

        /// <summary>       Casts the <see cref="half2"/> <paramref name="x"/> to a <see cref="MaxMath.ushort2"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushortsaturated(half2 x)
        {
            return toushortsaturated((float2)x);
        }

        /// <summary>       Casts the <see cref="half3"/> <paramref name="x"/> to a <see cref="MaxMath.ushort3"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushortsaturated(half3 x)
        {
            return toushortsaturated((float3)x);
        }

        /// <summary>       Casts the <see cref="half4"/> <paramref name="x"/> to a <see cref="MaxMath.ushort4"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushortsaturated(half4 x)
        {
            return toushortsaturated((float4)x);
        }

        /// <summary>       Casts the <see cref="half4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.ushort8"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsaturated(half4 lo, half4 hi)
        {
            return toushortsaturated(new float8(lo, hi));
        }

        /// <summary>       Casts the <see cref="half4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/> and <paramref name="x12_15"/> to a <see cref="MaxMath.ushort16"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushortsaturated(half4 x0_3, half4 x4_7, half4 x8_11, half4 x12_15)
        {
            return toushortsaturated(new half8(x0_3, x4_7), new half8(x8_11, x12_15));
        }

        /// <summary>       Casts the <see cref="MaxMath.half8"/> <paramref name="x"/> to a <see cref="MaxMath.ushort8"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsaturated(half8 x)
        {
            return toushortsaturated((float8)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.half8"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.ushort16"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushortsaturated(half8 lo, half8 hi)
        {
            return toushortsaturated((float8)lo, (float8)hi);
        }

        /// <summary>       Casts the <see cref="float2"/> <paramref name="x"/> to a <see cref="MaxMath.ushort2"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushortsaturated(float2 x)
        {
            return (ushort2)math.clamp(x, (float)ushort.MinValue, (float)ushort.MaxValue);
        }

        /// <summary>       Casts the <see cref="float3"/> <paramref name="x"/> to a <see cref="MaxMath.ushort3"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushortsaturated(float3 x)
        {
            return (ushort3)math.clamp(x, (float)ushort.MinValue, (float)ushort.MaxValue);
        }

        /// <summary>       Casts the <see cref="float4"/> <paramref name="x"/> to a <see cref="MaxMath.ushort4"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushortsaturated(float4 x)
        {
            return (ushort4)math.clamp(x, (float)ushort.MinValue, (float)ushort.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.float8"/> <paramref name="x"/> to a <see cref="MaxMath.ushort8"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsaturated(float8 x)
        {
            return (ushort8)clamp(x, (float)ushort.MinValue, (float)ushort.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.float8"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.ushort16"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushortsaturated(float8 lo, float8 hi)
        {
            float8 MIN_VALUE = ushort.MinValue;
            float8 MAX_VALUE = ushort.MaxValue;

            return new ushort16((ushort8)clamp(lo, MIN_VALUE, MAX_VALUE),
                                (ushort8)clamp(hi, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="double2"/> <paramref name="x"/> to a <see cref="MaxMath.ushort2"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushortsaturated(double2 x)
        {
            return (ushort2)math.clamp(x, (float)ushort.MinValue, (float)ushort.MaxValue);
        }

        /// <summary>       Casts the <see cref="double3"/> <paramref name="x"/> to a <see cref="MaxMath.ushort3"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushortsaturated(double3 x)
        {
            return (ushort3)math.clamp(x, (float)ushort.MinValue, (float)ushort.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/> <paramref name="x"/> to a <see cref="MaxMath.ushort4"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushortsaturated(double4 x)
        {
            return (ushort4)math.clamp(x, (float)ushort.MinValue, (float)ushort.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.ushort8"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushortsaturated(double4 lo, double4 hi)
        {
            double4 MIN_VALUE = (double)ushort.MinValue;
            double4 MAX_VALUE = (double)ushort.MaxValue;

            return new ushort8((ushort4)math.clamp(lo, MIN_VALUE, MAX_VALUE),
                               (ushort4)math.clamp(hi, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="double4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/> and <paramref name="x12_15"/> to a <see cref="MaxMath.ushort16"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushortsaturated(double4 x0_3, double4 x4_7, double4 x8_11, double4 x12_15)
        {
            double4 MIN_VALUE = (double)ushort.MinValue;
            double4 MAX_VALUE = (double)ushort.MaxValue;

            return new ushort16((ushort4)math.clamp(x0_3,   MIN_VALUE, MAX_VALUE),
                                (ushort4)math.clamp(x4_7,   MIN_VALUE, MAX_VALUE),
                                (ushort4)math.clamp(x8_11,  MIN_VALUE, MAX_VALUE),
                                (ushort4)math.clamp(x12_15, MIN_VALUE, MAX_VALUE));
        }
        #endregion

        #region To short
        /// <summary>       Casts the <see cref="ushort"/> <paramref name="x"/> to a <see cref="short"/> and returns the result, which is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshortsaturated(ushort x)
        {
            return (short)math.min(x, short.MaxValue);
        }

        /// <summary>       Casts the <see cref="int"/> <paramref name="x"/> to a <see cref="short"/> and returns the result, which is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshortsaturated(int x)
        {
            return (short)math.clamp(x, short.MinValue, short.MaxValue);
        }

        /// <summary>       Casts the <see cref="long"/> <paramref name="x"/> to a <see cref="short"/> and returns the result, which is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshortsaturated(long x)
        {
            return (short)math.clamp(x, short.MinValue, short.MaxValue);
        }

        /// <summary>       Casts the <see cref="Int128"/> <paramref name="x"/> to a <see cref="short"/> and returns the result, which is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshortsaturated(Int128 x)
        {
            return (short)clamp(x, short.MinValue, short.MaxValue);
        }


        /// <summary>       Casts the <see cref="uint"/> <paramref name="x"/> to a <see cref="short"/> and returns the result, which is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshortsaturated(uint x)
        {
            return (short)math.min(short.MaxValue, (uint)x);
        }

        /// <summary>       Casts the <see cref="ulong"/> <paramref name="x"/> to a <see cref="short"/> and returns the result, which is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshortsaturated(ulong x)
        {
            return (short)math.min(short.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="UInt128"/> <paramref name="x"/> to a <see cref="short"/> and returns the result, which is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshortsaturated(UInt128 x)
        {
            return (short)min((ushort)short.MaxValue, x);
        }


        /// <summary>       Casts the <see cref="quarter"/> <paramref name="x"/> to a <see cref="short"/> and returns the result, which is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshortsaturated(quarter x)
        {
            return toshortsaturated((float)x);
        }

        /// <summary>       Casts the <see cref="half"/> <paramref name="x"/> to a <see cref="short"/> and returns the result, which is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshortsaturated(half x)
        {
            return toshortsaturated((float)x);
        }

        /// <summary>       Casts the <see cref="float"/> <paramref name="x"/> to a <see cref="short"/> and returns the result, which is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshortsaturated(float x)
        {
            return (short)math.clamp(x, short.MinValue, short.MaxValue);
        }

        /// <summary>       Casts the <see cref="double"/> <paramref name="x"/> to a <see cref="short"/> and returns the result, which is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshortsaturated(double x)
        {
            return (short)math.clamp(x, short.MinValue, short.MaxValue);
        }


        /// <summary>       Casts the <see cref="MaxMath.ushort2"/> <paramref name="x"/> to a <see cref="MaxMath.short2"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshortsaturated(ushort2 x)
        {
            return (short2)min((ushort)short.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort3"/> <paramref name="x"/> to a <see cref="MaxMath.short3"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshortsaturated(ushort3 x)
        {
            return (short3)min((ushort)short.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort4"/> <paramref name="x"/> to a <see cref="MaxMath.short4"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshortsaturated(ushort4 x)
        {
            return (short4)min((ushort)short.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort8"/> <paramref name="x"/> to a <see cref="MaxMath.short8"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsaturated(ushort8 x)
        {
            return (short8)min((ushort)short.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort16"/> <paramref name="x"/> to a <see cref="MaxMath.short16"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshortsaturated(ushort16 x)
        {
            return (short16)min((ushort)short.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="int2"/> <paramref name="x"/> to a <see cref="MaxMath.short2"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshortsaturated(int2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                return Xse.packs_epi32(_x, _x);
            }
            else
            {
                return new short2(toshortsaturated(x.x), toshortsaturated(x.y));
            }
        }

        /// <summary>       Casts the <see cref="int3"/> <paramref name="x"/> to a <see cref="MaxMath.short3"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshortsaturated(int3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                return Xse.packs_epi32(_x, _x);
            }
            else
            {
                return new short3(toshortsaturated(x.x), toshortsaturated(x.y), toshortsaturated(x.z));
            }
        }

        /// <summary>       Casts the <see cref="int4"/> <paramref name="x"/> to a <see cref="MaxMath.short4"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshortsaturated(int4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                return Xse.packs_epi32(_x, _x);
            }
            else
            {
                return new short4(toshortsaturated(x.x), toshortsaturated(x.y), toshortsaturated(x.z), toshortsaturated(x.w));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.int8"/> <paramref name="x"/> to a <see cref="MaxMath.short8"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsaturated(int8 x)
        {
            return toshortsaturated(x.v4_0, x.v4_4);
        }

        /// <summary>       Casts the <see cref="int4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.short8"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsaturated(int4 lo, int4 hi)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _lo = RegisterConversion.ToV128(lo);
                v128 _hi = RegisterConversion.ToV128(hi);

                return Xse.packs_epi32(_lo, _hi);
            }
            else
            {
                return new short8(toshortsaturated(lo.x), toshortsaturated(lo.y), toshortsaturated(lo.z), toshortsaturated(lo.w),
                                  toshortsaturated(hi.x), toshortsaturated(hi.y), toshortsaturated(hi.z), toshortsaturated(hi.w));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.int8"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.short16"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshortsaturated(int8 lo, int8 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 packed = Avx2.mm256_packs_epi32(lo, hi);

                return Avx2.mm256_permute4x64_epi64(packed, Sse.SHUFFLE(3, 1, 2, 0));
            }
            else
            {
                return new short16(toshortsaturated(lo), toshortsaturated(hi));
            }
        }

        /// <summary>       Casts the <see cref="uint2"/> <paramref name="x"/> to a <see cref="MaxMath.short2"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshortsaturated(uint2 x)
        {
            return (short2)math.min((uint)short.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="uint3"/> <paramref name="x"/> to a <see cref="MaxMath.short3"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshortsaturated(uint3 x)
        {
            return (short3)math.min((uint)short.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="uint4"/> <paramref name="x"/> to a <see cref="MaxMath.short4"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshortsaturated(uint4 x)
        {
            return (short4)math.min((uint)short.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.uint8"/> <paramref name="x"/> to a <see cref="MaxMath.short8"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsaturated(uint8 x)
        {
            return (short8)min((uint)short.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="uint4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.short8"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsaturated(uint4 lo, uint4 hi)
        {
            return (short8)min((uint)short.MaxValue, new uint8(lo, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.uint8"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.short16"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshortsaturated(uint8 lo, uint8 hi)
        {
            uint8 MAX_VALUE = (uint)short.MaxValue;

            return new short16((short8)min(MAX_VALUE, lo), (short8)min(MAX_VALUE, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.long2"/> <paramref name="x"/> to a <see cref="MaxMath.short2"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshortsaturated(long2 x)
        {
            return (short2)clamp(x, short.MinValue, short.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long3"/> <paramref name="x"/> to a <see cref="MaxMath.short3"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshortsaturated(long3 x)
        {
            return (short3)clamp(x, short.MinValue, short.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/> <paramref name="x"/> to a <see cref="MaxMath.short4"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshortsaturated(long4 x)
        {
            return (short4)clamp(x, short.MinValue, short.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.short8"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsaturated(long4 lo, long4 hi)
        {
            long4 MIN_VALUE = short.MinValue;
            long4 MAX_VALUE = short.MaxValue;

            return new short8((short4)clamp(lo, MIN_VALUE, MAX_VALUE),
                              (short4)clamp(hi, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/> and <paramref name="x12_15"/> to a <see cref="MaxMath.short16"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshortsaturated(long4 x0_3, long4 x4_7, long4 x8_11, long4 x12_15)
        {
            long4 MIN_VALUE = short.MinValue;
            long4 MAX_VALUE = short.MaxValue;

            return new short16((short4)clamp(x0_3,   MIN_VALUE, MAX_VALUE),
                               (short4)clamp(x4_7,   MIN_VALUE, MAX_VALUE),
                               (short4)clamp(x8_11,  MIN_VALUE, MAX_VALUE),
                               (short4)clamp(x12_15, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong2"/> <paramref name="x"/> to a <see cref="MaxMath.short2"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshortsaturated(ulong2 x)
        {
            return (short2)min((ulong)short.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong3"/> <paramref name="x"/> to a <see cref="MaxMath.short3"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshortsaturated(ulong3 x)
        {
            return (short3)min((ulong)short.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/> <paramref name="x"/> to a <see cref="MaxMath.short4"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshortsaturated(ulong4 x)
        {
            return (short4)min((ulong)short.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.short8"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsaturated(ulong4 lo, ulong4 hi)
        {
            ulong4 MAX_VALUE = (ulong)short.MaxValue;

            return new short8((short4)min(MAX_VALUE, lo),
                              (short4)min(MAX_VALUE, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/> and <paramref name="x12_15"/> to a <see cref="MaxMath.short16"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshortsaturated(ulong4 x0_3, ulong4 x4_7, ulong4 x8_11, ulong4 x12_15)
        {
            ulong4 MAX_VALUE = (ulong)short.MaxValue;

            return new short16((short4)min(x0_3,   MAX_VALUE),
                               (short4)min(x4_7,   MAX_VALUE),
                               (short4)min(x8_11,  MAX_VALUE),
                               (short4)min(x12_15, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter2"/> <paramref name="x"/> to a <see cref="MaxMath.short2"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshortsaturated(quarter2 x)
        {
            return toshortsaturated((float2)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter3"/> <paramref name="x"/> to a <see cref="MaxMath.short3"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshortsaturated(quarter3 x)
        {
            return toshortsaturated((float3)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/> <paramref name="x"/> to a <see cref="MaxMath.short4"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshortsaturated(quarter4 x)
        {
            return toshortsaturated((float4)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.short8"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsaturated(quarter4 lo, quarter4 hi)
        {
            return toshortsaturated(new float8(lo, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/> and <paramref name="x12_15"/> to a <see cref="MaxMath.short16"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshortsaturated(quarter4 x0_3, quarter4 x4_7, quarter4 x8_11, quarter4 x12_15)
        {
            return toshortsaturated(new quarter8(x0_3, x4_7), new quarter8(x8_11, x12_15));
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter8"/> <paramref name="x"/> to a <see cref="MaxMath.short8"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsaturated(quarter8 x)
        {
            return toshortsaturated((float8)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter8"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.short8"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshortsaturated(quarter8 lo, quarter8 hi)
        {
            return toshortsaturated((float8)lo, (float8)hi);
        }

        /// <summary>       Casts the <see cref="half2"/> <paramref name="x"/> to a <see cref="MaxMath.short2"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshortsaturated(half2 x)
        {
            return toshortsaturated((float2)x);
        }

        /// <summary>       Casts the <see cref="half3"/> <paramref name="x"/> to a <see cref="MaxMath.short3"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshortsaturated(half3 x)
        {
            return toshortsaturated((float3)x);
        }

        /// <summary>       Casts the <see cref="half4"/> <paramref name="x"/> to a <see cref="MaxMath.short4"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshortsaturated(half4 x)
        {
            return toshortsaturated((float4)x);
        }

        /// <summary>       Casts the <see cref="half4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.short8"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsaturated(half4 lo, half4 hi)
        {
            return toshortsaturated(new float8(lo, hi));
        }

        /// <summary>       Casts the <see cref="half4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/> and <paramref name="x12_15"/> to a <see cref="MaxMath.short16"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshortsaturated(half4 x0_3, half4 x4_7, half4 x8_11, half4 x12_15)
        {
            return toshortsaturated(new half8(x0_3, x4_7), new half8(x8_11, x12_15));
        }

        /// <summary>       Casts the <see cref="MaxMath.half8"/> <paramref name="x"/> to a <see cref="MaxMath.short8"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsaturated(half8 x)
        {
            return toshortsaturated((float8)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.half8"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.short16"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshortsaturated(half8 lo, half8 hi)
        {
            return toshortsaturated((float8)lo, (float8)hi);
        }


        /// <summary>       Casts the <see cref="float2"/> <paramref name="x"/> to a <see cref="MaxMath.short2"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshortsaturated(float2 x)
        {
            return (short2)math.clamp(x, short.MinValue, short.MaxValue);
        }

        /// <summary>       Casts the <see cref="float3"/> <paramref name="x"/> to a <see cref="MaxMath.short3"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshortsaturated(float3 x)
        {
            return (short3)math.clamp(x, short.MinValue, short.MaxValue);
        }

        /// <summary>       Casts the <see cref="float4"/> <paramref name="x"/> to a <see cref="MaxMath.short4"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshortsaturated(float4 x)
        {
            return (short4)math.clamp(x, short.MinValue, short.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.float8"/> <paramref name="x"/> to a <see cref="MaxMath.short8"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsaturated(float8 x)
        {
            return (short8)clamp(x, short.MinValue, short.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.float8"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.short16"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshortsaturated(float8 lo, float8 hi)
        {
            float8 MIN_VALUE = short.MinValue;
            float8 MAX_VALUE = short.MaxValue;

            return new short16((short8)clamp(lo, MIN_VALUE, MAX_VALUE),
                               (short8)clamp(hi, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="double2"/> <paramref name="x"/> to a <see cref="MaxMath.short2"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshortsaturated(double2 x)
        {
            return (short2)math.clamp(x, short.MinValue, short.MaxValue);
        }

        /// <summary>       Casts the <see cref="double3"/> <paramref name="x"/> to a <see cref="MaxMath.short3"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshortsaturated(double3 x)
        {
            return (short3)math.clamp(x, short.MinValue, short.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/> <paramref name="x"/> to a <see cref="MaxMath.short4"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshortsaturated(double4 x)
        {
            return (short4)math.clamp(x, short.MinValue, short.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.short8"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshortsaturated(double4 lo, double4 hi)
        {
            double4 MIN_VALUE = short.MinValue;
            double4 MAX_VALUE = short.MaxValue;

            return new short8((short4)math.clamp(lo, MIN_VALUE, MAX_VALUE),
                              (short4)math.clamp(hi, MIN_VALUE, MAX_VALUE));
        }

        /// <summary>       Casts the <see cref="double4"/>s <paramref name="x0_3"/>, <paramref name="x4_7"/>, <paramref name="x8_11"/> and <paramref name="x12_15"/> to a <see cref="MaxMath.short16"/> and returns the result, where each component is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshortsaturated(double4 x0_3, double4 x4_7, double4 x8_11, double4 x12_15)
        {
            double4 MIN_VALUE = short.MinValue;
            double4 MAX_VALUE = short.MaxValue;

            return new short16((short4)math.clamp(x0_3,   MIN_VALUE, MAX_VALUE),
                               (short4)math.clamp(x4_7,   MIN_VALUE, MAX_VALUE),
                               (short4)math.clamp(x8_11,  MIN_VALUE, MAX_VALUE),
                               (short4)math.clamp(x12_15, MIN_VALUE, MAX_VALUE));
        }
        #endregion

        #region To uint
        /// <summary>       Casts the <see cref="sbyte"/> <paramref name="x"/> to a <see cref="uint"/> and returns the result, which is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touintsaturated(sbyte x)
        {
            return (uint)math.max(x, (int)uint.MinValue);
        }

        /// <summary>       Casts the <see cref="short"/> <paramref name="x"/> to a <see cref="uint"/> and returns the result, which is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touintsaturated(short x)
        {
            return (uint)math.max(x, (int)uint.MinValue);
        }

        /// <summary>       Casts the <see cref="int"/> <paramref name="x"/> to a <see cref="uint"/> and returns the result, which is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touintsaturated(int x)
        {
            return (uint)math.max(x, (int)uint.MinValue);
        }

        /// <summary>       Casts the <see cref="Int128"/> <paramref name="x"/> to a <see cref="uint"/> and returns the result, which is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touintsaturated(Int128 x)
        {
            return (uint)clamp(x, uint.MinValue, uint.MaxValue);
        }


        /// <summary>       Casts the <see cref="long"/> <paramref name="x"/> to a <see cref="uint"/> and returns the result, which is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touintsaturated(long x)
        {
            return (uint)math.clamp(x, uint.MinValue, uint.MaxValue);
        }

        /// <summary>       Casts the <see cref="ulong"/> <paramref name="x"/> to a <see cref="uint"/> and returns the result, which is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touintsaturated(ulong x)
        {
            return (uint)math.min(uint.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="UInt128"/> <paramref name="x"/> to a <see cref="uint"/> and returns the result, which is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touintsaturated(UInt128 x)
        {
            return (uint)min(uint.MaxValue, x);
        }


        /// <summary>       Casts the <see cref="quarter"/> <paramref name="x"/> to a <see cref="uint"/> and returns the result, which is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touintsaturated(quarter x)
        {
            return touintsaturated((float)x);
        }

        /// <summary>       Casts the <see cref="half"/> <paramref name="x"/> to a <see cref="uint"/> and returns the result, which is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touintsaturated(half x)
        {
            return touintsaturated((float)x);
        }

        /// <summary>       Casts the <see cref="float"/> <paramref name="x"/> to a <see cref="uint"/> and returns the result, which is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touintsaturated(float x)
        {
            return math.select(math.select((uint)x, uint.MinValue, x <= uint.MinValue), uint.MaxValue, x >= uint.MaxValue);
        }

        /// <summary>       Casts the <see cref="double"/> <paramref name="x"/> to a <see cref="uint"/> and returns the result, which is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touintsaturated(double x)
        {
            return (uint)math.clamp(x, uint.MinValue, uint.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte2"/> <paramref name="x"/> to a <see cref="uint2"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touintsaturated(sbyte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return (uint2)max((sbyte)uint.MinValue, x);
            }
            else
            {
                return (uint2)(byte2)max((sbyte)uint.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte3"/> <paramref name="x"/> to a <see cref="uint3"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touintsaturated(sbyte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return (uint3)max((sbyte)uint.MinValue, x);
            }
            else
            {
                return (uint3)(byte3)max((sbyte)uint.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte4"/> <paramref name="x"/> to a <see cref="uint4"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touintsaturated(sbyte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return (uint4)max((sbyte)uint.MinValue, x);
            }
            else
            {
                return (uint4)(byte4)max((sbyte)uint.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte8"/> <paramref name="x"/> to a <see cref="MaxMath.uint8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touintsaturated(sbyte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return (uint8)max((sbyte)uint.MinValue, x);
            }
            else
            {
                return (uint8)(byte8)max((sbyte)uint.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short2"/> <paramref name="x"/> to a <see cref="uint2"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touintsaturated(short2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return (uint2)max((short)uint.MinValue, x);
            }
            else
            {
                return (uint2)(ushort2)max((short)uint.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short3"/> <paramref name="x"/> to a <see cref="uint3"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touintsaturated(short3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return (uint3)max((short)uint.MinValue, x);
            }
            else
            {
                return (uint3)(ushort3)max((short)uint.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short4"/> <paramref name="x"/> to a <see cref="uint4"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touintsaturated(short4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return (uint4)max((short)uint.MinValue, x);
            }
            else
            {
                return (uint4)(ushort4)max((short)uint.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short8"/> <paramref name="x"/> to a <see cref="MaxMath.uint8"/> and returns the result, where each component is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touintsaturated(short8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return (uint8)max((short)uint.MinValue, x);
            }
            else
            {
                return (uint8)(ushort8)max((short)uint.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="int2"/> <paramref name="x"/> to a <see cref="uint2"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touintsaturated(int2 x)
        {
            return (uint2)math.max((int)uint.MinValue, x);
        }

        /// <summary>       Casts the <see cref="int3"/> <paramref name="x"/> to a <see cref="uint3"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touintsaturated(int3 x)
        {
            return (uint3)math.max((int)uint.MinValue, x);
        }

        /// <summary>       Casts the <see cref="int4"/> <paramref name="x"/> to a <see cref="uint4"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touintsaturated(int4 x)
        {
            return (uint4)math.max((int)uint.MinValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.int8"/> <paramref name="x"/> to a <see cref="MaxMath.uint8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touintsaturated(int8 x)
        {
            return (uint8)max((int)uint.MinValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.long2"/> <paramref name="x"/> to a <see cref="uint2"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touintsaturated(long2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 clamped = clamp(x, uint.MinValue, uint.MaxValue);

                return RegisterConversion.ToUInt2(Xse.cvtepi64_epi32(clamped));
            }
            else
            {
                return new uint2(touintsaturated(x.x), touintsaturated(x.y));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.long3"/> <paramref name="x"/> to a <see cref="uint3"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touintsaturated(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 clamped = clamp(x, uint.MinValue, uint.MaxValue);

                return RegisterConversion.ToUInt3(Xse.mm256_cvtepi64_epi32(clamped));
            }
            else
            {
                return new uint3(touintsaturated(x.xy), touintsaturated(x.z));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/> <paramref name="x"/> to a <see cref="uint4"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touintsaturated(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 clamped = clamp(x, uint.MinValue, uint.MaxValue);

                return RegisterConversion.ToUInt4(Xse.mm256_cvtepi64_epi32(clamped));
            }
            else
            {
                return new uint4(touintsaturated(x.xy), touintsaturated(x.zw));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.uint8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touintsaturated(long4 lo, long4 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MIN_VALUE = new long4(uint.MinValue);
                v256 MAX_VALUE = new long4(uint.MaxValue);

                v256 clamped_lo = clamp(lo, MIN_VALUE, MAX_VALUE);
                v256 clamped_hi = clamp(hi, MIN_VALUE, MAX_VALUE);

                return Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(Xse.mm256_cvtepi64_epi32(clamped_lo)), Xse.mm256_cvtepi64_epi32(clamped_hi), 1);
            }
            else
            {
                return new uint8(touintsaturated(lo), touintsaturated(hi));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong2"/> <paramref name="x"/> to a <see cref="uint2"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touintsaturated(ulong2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 clamped = min(x, uint.MaxValue);

                return RegisterConversion.ToUInt2(Xse.cvtepi64_epi32(clamped));
            }
            else
            {
                return new uint2(touintsaturated(x.x), touintsaturated(x.y));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong3"/> <paramref name="x"/> to a <see cref="uint3"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touintsaturated(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 clamped = min(x, uint.MaxValue);

                return RegisterConversion.ToUInt3(Xse.mm256_cvtepi64_epi32(clamped));
            }
            else
            {
                return new uint3(touintsaturated(x.xy), touintsaturated(x.z));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/> <paramref name="x"/> to a <see cref="uint4"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touintsaturated(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 clamped = min(x, uint.MaxValue);

                return RegisterConversion.ToUInt4(Xse.mm256_cvtepi64_epi32(clamped));
            }
            else
            {
                return new uint4(touintsaturated(x.xy), touintsaturated(x.zw));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.uint8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touintsaturated(ulong4 lo, ulong4 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MAX_VALUE = new ulong4(uint.MaxValue);

                v256 clamped_lo = min(lo, MAX_VALUE);
                v256 clamped_hi = min(hi, MAX_VALUE);

                return Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(Xse.mm256_cvtepi64_epi32(clamped_lo)), Xse.mm256_cvtepi64_epi32(clamped_hi), 1);
            }
            else
            {
                return new uint8(touintsaturated(lo), touintsaturated(hi));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter2"/> <paramref name="x"/> to a <see cref="uint2"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touintsaturated(quarter2 x)
        {
            return touintsaturated((float2)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter3"/> <paramref name="x"/> to a <see cref="uint3"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touintsaturated(quarter3 x)
        {
            return touintsaturated((float3)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/> <paramref name="x"/> to a <see cref="uint4"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touintsaturated(quarter4 x)
        {
            return touintsaturated((float4)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.uint8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touintsaturated(quarter4 lo, quarter4 hi)
        {
            return touintsaturated(new quarter8(lo, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter8"/> <paramref name="x"/> to a <see cref="MaxMath.uint8"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touintsaturated(quarter8 x)
        {
            return touintsaturated((float8)x);
        }

        /// <summary>       Casts the <see cref="half2"/> <paramref name="x"/> to a <see cref="uint2"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touintsaturated(half2 x)
        {
            return touintsaturated((float2)x);
        }

        /// <summary>       Casts the <see cref="half3"/> <paramref name="x"/> to a <see cref="uint3"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touintsaturated(half3 x)
        {
            return touintsaturated((float3)x);
        }

        /// <summary>       Casts the <see cref="half4"/> <paramref name="x"/> to a <see cref="uint4"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touintsaturated(half4 x)
        {
            return touintsaturated((float4)x);
        }

        /// <summary>       Casts the <see cref="half4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.uint8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touintsaturated(half4 lo, half4 hi)
        {
            return touintsaturated(new half8(lo, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.half8"/> <paramref name="x"/> to a <see cref="MaxMath.uint8"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touintsaturated(half8 x)
        {
            return touintsaturated((float8)x);
        }

        /// <summary>       Casts the <see cref="float2"/> <paramref name="x"/> to a <see cref="uint2"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touintsaturated(float2 x)
        {
            return math.select(math.select((uint2)x, uint.MinValue, x <= uint.MinValue), uint.MaxValue, x >= uint.MaxValue);
        }

        /// <summary>       Casts the <see cref="float3"/> <paramref name="x"/> to a <see cref="uint3"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touintsaturated(float3 x)
        {
            return math.select(math.select((uint3)x, uint.MinValue, x <= uint.MinValue), uint.MaxValue, x >= uint.MaxValue);
        }

        /// <summary>       Casts the <see cref="float4"/> <paramref name="x"/> to a <see cref="uint4"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touintsaturated(float4 x)
        {
            return math.select(math.select((uint4)x, uint.MinValue, x <= uint.MinValue), uint.MaxValue, x >= uint.MaxValue);
        }

        /// <summary>       Casts the <see cref="float4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.uint8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touintsaturated(float4 lo, float4 hi)
        {
            return touintsaturated(new float8(lo, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.float8"/> <paramref name="lo"/> to a <see cref="MaxMath.uint8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touintsaturated(float8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MIN_VALUE = new v256(uint.MinValue);
                v256 MAX_VALUE = new v256(uint.MaxValue);
                v256 MIN_VALUE_F32 = new v256((float)uint.MinValue);
                v256 MAX_VALUE_F32 = new v256((float)uint.MaxValue);

                v256 cast = (uint8)x;

                v256 overflowMask  = Xse.mm256_cmpge_ps(x, MAX_VALUE_F32);
                v256 underflowMask = Xse.mm256_cmple_ps(x, MIN_VALUE_F32);

                return Avx.mm256_blendv_ps(Avx.mm256_blendv_ps(cast, MIN_VALUE, underflowMask), MAX_VALUE, overflowMask);
            }
            else if (Avx.IsAvxSupported)
            {
                v256 MIN_VALUE = new v256(uint.MinValue);
                v256 MAX_VALUE = new v256(uint.MaxValue);
                v256 MIN_VALUE_F32 = new v256((float)uint.MinValue);
                v256 MAX_VALUE_F32 = new v256((float)uint.MaxValue);

                v256 cast = (uint8)x;

                v256 overflowMask  = Xse.mm256_cmpge_ps(x, MAX_VALUE_F32);
                v256 underflowMask = Xse.mm256_cmple_ps(x, MIN_VALUE_F32);

                v256 result = Avx.mm256_blendv_ps(Avx.mm256_blendv_ps(cast, MIN_VALUE, underflowMask), MAX_VALUE, overflowMask);

                v128 lo = Avx.mm256_castps256_ps128(result);
                v128 hi = Avx.mm256_extractf128_ps(result, 1);

                return new uint8(RegisterConversion.ToUInt4(lo), RegisterConversion.ToUInt4(hi));
            }
            else
            {
                return select(select((uint8)x, uint.MinValue, x <= uint.MinValue), uint.MaxValue, x >= uint.MaxValue);
            }
        }

        /// <summary>       Casts the <see cref="double2"/> <paramref name="x"/> to a <see cref="uint2"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touintsaturated(double2 x)
        {
            return (uint2)math.clamp(x, uint.MinValue, uint.MaxValue);
        }

        /// <summary>       Casts the <see cref="double3"/> <paramref name="x"/> to a <see cref="uint3"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touintsaturated(double3 x)
        {
            return (uint3)math.clamp(x, uint.MinValue, uint.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/> <paramref name="x"/> to a <see cref="uint4"/> and returns the result, where each component is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touintsaturated(double4 x)
        {
            return (uint4)math.clamp(x, uint.MinValue, uint.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.uint8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touintsaturated(double4 lo, double4 hi)
        {
            return new uint8(touintsaturated(lo), touintsaturated(hi));
        }
        #endregion

        #region To int
        /// <summary>       Casts the <see cref="uint"/> <paramref name="x"/> to an <see cref="int"/> and returns the result, which is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int tointsaturated(uint x)
        {
            return (int)math.min(x, (uint)int.MaxValue);
        }

        /// <summary>       Casts the <see cref="long"/> <paramref name="x"/> to an <see cref="int"/> and returns the result, which is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int tointsaturated(long x)
        {
            return (int)math.clamp(x, int.MinValue, int.MaxValue);
        }

        /// <summary>       Casts the <see cref="Int128"/> <paramref name="x"/> to a <see cref="int"/> and returns the result, which is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int tointsaturated(Int128 x)
        {
            return (int)clamp(x, int.MinValue, int.MaxValue);
        }


        /// <summary>       Casts the <see cref="ulong"/> <paramref name="x"/> to an <see cref="int"/> and returns the result, which is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int tointsaturated(ulong x)
        {
            return (int)math.min(int.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="UInt128"/> <paramref name="x"/> to a <see cref="int"/> and returns the result, which is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int tointsaturated(UInt128 x)
        {
            return (int)min(int.MaxValue, x);
        }


        /// <summary>       Casts the <see cref="quarter"/> <paramref name="x"/> to a <see cref="int"/> and returns the result, which is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int tointsaturated(quarter x)
        {
            return tointsaturated((float)x);
        }

        /// <summary>       Casts the <see cref="half"/> <paramref name="x"/> to a <see cref="int"/> and returns the result, which is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int tointsaturated(half x)
        {
            return tointsaturated((float)x);
        }

        /// <summary>       Casts the <see cref="float"/> <paramref name="x"/> to an <see cref="int"/> and returns the result, which is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int tointsaturated(float x)
        {
            return math.select(math.select((int)x, int.MinValue, x <= int.MinValue), int.MaxValue, x >= int.MaxValue);
        }

        /// <summary>       Casts the <see cref="double"/> <paramref name="x"/> to an <see cref="int"/> and returns the result, which is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int tointsaturated(double x)
        {
            return (int)math.clamp(x, int.MinValue, int.MaxValue);
        }

        /// <summary>       Casts the <see cref="uint2"/> <paramref name="x"/> to an <see cref="int2"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tointsaturated(uint2 x)
        {
            return (int2)math.min((uint)int.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="uint3"/> <paramref name="x"/> to an <see cref="int3"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tointsaturated(uint3 x)
        {
            return (int3)math.min((uint)int.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="uint4"/> <paramref name="x"/> to an <see cref="int4"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tointsaturated(uint4 x)
        {
            return (int4)math.min((uint)int.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.uint8"/> <paramref name="x"/> to an <see cref="MaxMath.int8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tointsaturated(uint8 x)
        {
            return (int8)min((uint)int.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.long2"/> <paramref name="x"/> to an <see cref="int2"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tointsaturated(long2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 clamped = clamp(x, int.MinValue, int.MaxValue);

                return RegisterConversion.ToInt2(Xse.cvtepi64_epi32(clamped));
            }
            else
            {
                return new int2(tointsaturated(x.x), tointsaturated(x.y));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.long3"/> <paramref name="x"/> to an <see cref="int3"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tointsaturated(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 clamped = clamp(x, int.MinValue, int.MaxValue);

                return RegisterConversion.ToInt3(Xse.mm256_cvtepi64_epi32(clamped));
            }
            else
            {
                return new int3(tointsaturated(x.xy), tointsaturated(x.z));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/> <paramref name="x"/> to an <see cref="int4"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tointsaturated(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 clamped = clamp(x, int.MinValue, int.MaxValue);

                return RegisterConversion.ToInt4(Xse.mm256_cvtepi64_epi32(clamped));
            }
            else
            {
                return new int4(tointsaturated(x.xy), tointsaturated(x.zw));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/>s <paramref name="lo"/> and <paramref name="hi"/> to an <see cref="MaxMath.int8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tointsaturated(long4 lo, long4 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MIN_VALUE = new long4(int.MinValue);
                v256 MAX_VALUE = new long4(int.MaxValue);

                v256 clamped_lo = clamp(lo, MIN_VALUE, MAX_VALUE);
                v256 clamped_hi = clamp(hi, MIN_VALUE, MAX_VALUE);

                return Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(Xse.mm256_cvtepi64_epi32(clamped_lo)), Xse.mm256_cvtepi64_epi32(clamped_hi), 1);
            }
            else
            {
                return new int8(tointsaturated(lo), tointsaturated(hi));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong2"/> <paramref name="x"/> to an <see cref="int2"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tointsaturated(ulong2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 clamped = min(x, int.MaxValue);

                return RegisterConversion.ToInt2(Xse.cvtepi64_epi32(clamped));
            }
            else
            {
                return new int2(tointsaturated(x.x), tointsaturated(x.y));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong3"/> <paramref name="x"/> to an <see cref="int3"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tointsaturated(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 clamped = min(x, int.MaxValue);

                return RegisterConversion.ToInt3(Xse.mm256_cvtepi64_epi32(clamped));
            }
            else
            {
                return new int3(tointsaturated(x.xy), tointsaturated(x.z));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/> <paramref name="x"/> to an <see cref="int4"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tointsaturated(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 clamped = min(x, int.MaxValue);

                return RegisterConversion.ToInt4(Xse.mm256_cvtepi64_epi32(clamped));
            }
            else
            {
                return new int4(tointsaturated(x.xy), tointsaturated(x.zw));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/>s <paramref name="lo"/> and <paramref name="hi"/> to an <see cref="MaxMath.int8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tointsaturated(ulong4 lo, ulong4 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MAX_VALUE = new ulong4(int.MaxValue);

                v256 clamped_lo = min(lo, MAX_VALUE);
                v256 clamped_hi = min(hi, MAX_VALUE);

                return Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(Xse.mm256_cvtepi64_epi32(clamped_lo)), Xse.mm256_cvtepi64_epi32(clamped_hi), 1);
            }
            else
            {
                return new int8(tointsaturated(lo), tointsaturated(hi));
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter2"/> <paramref name="x"/> to a <see cref="int2"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tointsaturated(quarter2 x)
        {
            return tointsaturated((float2)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter3"/> <paramref name="x"/> to a <see cref="int3"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tointsaturated(quarter3 x)
        {
            return tointsaturated((float3)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/> <paramref name="x"/> to a <see cref="int4"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tointsaturated(quarter4 x)
        {
            return tointsaturated((float4)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.int8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tointsaturated(quarter4 lo, quarter4 hi)
        {
            return tointsaturated(new quarter8(lo, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter8"/> <paramref name="x"/> to a <see cref="MaxMath.int8"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tointsaturated(quarter8 x)
        {
            return tointsaturated((float8)x);
        }

        /// <summary>       Casts the <see cref="half2"/> <paramref name="x"/> to a <see cref="int2"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tointsaturated(half2 x)
        {
            return tointsaturated((float2)x);
        }

        /// <summary>       Casts the <see cref="half3"/> <paramref name="x"/> to a <see cref="int3"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tointsaturated(half3 x)
        {
            return tointsaturated((float3)x);
        }

        /// <summary>       Casts the <see cref="half4"/> <paramref name="x"/> to a <see cref="int4"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tointsaturated(half4 x)
        {
            return tointsaturated((float4)x);
        }

        /// <summary>       Casts the <see cref="half4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.int8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tointsaturated(half4 lo, half4 hi)
        {
            return tointsaturated(new half8(lo, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.half8"/> <paramref name="x"/> to a <see cref="MaxMath.int8"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tointsaturated(half8 x)
        {
            return tointsaturated((float8)x);
        }

        /// <summary>       Casts the <see cref="float2"/> <paramref name="x"/> to an <see cref="int2"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tointsaturated(float2 x)
        {
            return math.select(math.select((int2)x, int.MinValue, x <= int.MinValue), int.MaxValue, x >= int.MaxValue);
        }

        /// <summary>       Casts the <see cref="float3"/> <paramref name="x"/> to an <see cref="int3"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tointsaturated(float3 x)
        {
            return math.select(math.select((int3)x, int.MinValue, x <= int.MinValue), int.MaxValue, x >= int.MaxValue);
        }

        /// <summary>       Casts the <see cref="float4"/> <paramref name="x"/> to an <see cref="int4"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tointsaturated(float4 x)
        {
            return math.select(math.select((int4)x, int.MinValue, x <= int.MinValue), int.MaxValue, x >= int.MaxValue);
        }

        /// <summary>       Casts the <see cref="float4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.int8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tointsaturated(float4 lo, float4 hi)
        {
            return tointsaturated(new float8(lo, hi));
        }

        /// <summary>       Casts the <see cref="MaxMath.float8"/> <paramref name="lo"/> to an <see cref="MaxMath.int8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tointsaturated(float8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MIN_VALUE = new v256(int.MinValue);
                v256 MAX_VALUE = new v256(int.MaxValue);
                v256 MIN_VALUE_F32 = new v256((float)int.MinValue);
                v256 MAX_VALUE_F32 = new v256((float)int.MaxValue);

                v256 cast = Avx.mm256_cvttps_epi32(x);

                v256 overflowMask  = Xse.mm256_cmpge_ps(x, MAX_VALUE_F32);
                v256 underflowMask = Xse.mm256_cmple_ps(x, MIN_VALUE_F32);

                return Avx.mm256_blendv_ps(Avx.mm256_blendv_ps(cast, MIN_VALUE, underflowMask), MAX_VALUE, overflowMask);
            }
            else if (Avx.IsAvxSupported)
            {
                v256 MIN_VALUE = new v256(int.MinValue);
                v256 MAX_VALUE = new v256(int.MaxValue);
                v256 MIN_VALUE_F32 = new v256((float)int.MinValue);
                v256 MAX_VALUE_F32 = new v256((float)int.MaxValue);

                v256 cast = Avx.mm256_cvttps_epi32(x);

                v256 overflowMask  = Xse.mm256_cmpge_ps(x, MAX_VALUE_F32);
                v256 underflowMask = Xse.mm256_cmple_ps(x, MIN_VALUE_F32);

                v256 result = Avx.mm256_blendv_ps(Avx.mm256_blendv_ps(cast, MIN_VALUE, underflowMask), MAX_VALUE, overflowMask);

                v128 lo = Avx.mm256_castps256_ps128(result);
                v128 hi = Avx.mm256_extractf128_ps(result, 1);

                return new int8(RegisterConversion.ToInt4(lo), RegisterConversion.ToInt4(hi));
            }
            else
            {
                return select(select((int8)x, int.MinValue, x <= int.MinValue), int.MaxValue, x >= int.MaxValue);
            }
        }

        /// <summary>       Casts the <see cref="double2"/> <paramref name="x"/> to an <see cref="int2"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tointsaturated(double2 x)
        {
            return (int2)math.clamp(x, int.MinValue, int.MaxValue);
        }

        /// <summary>       Casts the <see cref="double3"/> <paramref name="x"/> to an <see cref="int3"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tointsaturated(double3 x)
        {
            return (int3)math.clamp(x, int.MinValue, int.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/> <paramref name="x"/> to an <see cref="int4"/> and returns the result, where each component is clamped to the interval [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tointsaturated(double4 x)
        {
            return (int4)math.clamp(x, int.MinValue, int.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/>s <paramref name="lo"/> and <paramref name="hi"/> to an <see cref="MaxMath.int8"/> and returns the result, where each component is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tointsaturated(double4 lo, double4 hi)
        {
            return new int8(tointsaturated(lo), tointsaturated(hi));
        }
        #endregion

        #region To ulong
        /// <summary>       Casts the <see cref="sbyte"/> <paramref name="x"/> to a <see cref="ulong"/> and returns the result, which is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong toulongsaturated(sbyte x)
        {
            return (ulong)math.max((long)ulong.MinValue, x);
        }

        /// <summary>       Casts the <see cref="short"/> <paramref name="x"/> to a <see cref="ulong"/> and returns the result, which is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong toulongsaturated(short x)
        {
            return (ulong)math.max((long)ulong.MinValue, x);
        }

        /// <summary>       Casts the <see cref="int"/> <paramref name="x"/> to a <see cref="ulong"/> and returns the result, which is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong toulongsaturated(int x)
        {
            return (ulong)math.max((long)ulong.MinValue, x);
        }

        /// <summary>       Casts the <see cref="long"/> <paramref name="x"/> to a <see cref="ulong"/> and returns the result, which is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong toulongsaturated(long x)
        {
            return (ulong)math.max((long)ulong.MinValue, x);
        }

        /// <summary>       Casts the <see cref="Int128"/> <paramref name="x"/> to a <see cref="ulong"/> and returns the result, which is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong toulongsaturated(Int128 x)
        {
            return (ulong)clamp(x, ulong.MinValue, ulong.MaxValue);
        }


        /// <summary>       Casts the <see cref="UInt128"/> <paramref name="x"/> to a <see cref="ulong"/> and returns the result, which is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong toulongsaturated(UInt128 x)
        {
            return x.hi64 == 0 ? x.lo64 : ulong.MaxValue;
        }


        /// <summary>       Casts the <see cref="quarter"/> <paramref name="x"/> to a <see cref="ulong"/> and returns the result, which is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong toulongsaturated(quarter x)
        {
            return toulongsaturated((float)x);
        }

        /// <summary>       Casts the <see cref="half"/> <paramref name="x"/> to a <see cref="ulong"/> and returns the result, which is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong toulongsaturated(half x)
        {
            return toulongsaturated((float)x);
        }

        /// <summary>       Casts the <see cref="float"/> <paramref name="x"/> to a <see cref="ulong"/> and returns the result, which is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong toulongsaturated(float x)
        {
            return math.select(math.select((ulong)x, ulong.MinValue, x <= ulong.MinValue), ulong.MaxValue, x >= ulong.MaxValue);
        }

        /// <summary>       Casts the <see cref="double"/> <paramref name="x"/> to a <see cref="ulong"/> and returns the result, which is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong toulongsaturated(double x)
        {
            return math.select(math.select((ulong)x, ulong.MinValue, x <= ulong.MinValue), ulong.MaxValue, x >= ulong.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte2"/> <paramref name="x"/> to a <see cref="MaxMath.ulong2"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulongsaturated(sbyte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return (ulong2)max((sbyte)ulong.MinValue, x);
            }
            else
            {
                return (ulong2)(byte2)max((sbyte)ulong.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte3"/> <paramref name="x"/> to a <see cref="MaxMath.ulong3"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulongsaturated(sbyte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return (ulong3)max((sbyte)ulong.MinValue, x);
            }
            else
            {
                return (ulong3)(byte3)max((sbyte)ulong.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte4"/> <paramref name="x"/> to a <see cref="MaxMath.ulong4"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulongsaturated(sbyte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return (ulong4)max((sbyte)ulong.MinValue, x);
            }
            else
            {
                return (ulong4)(byte4)max((sbyte)ulong.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short2"/> <paramref name="x"/> to a <see cref="MaxMath.ulong2"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulongsaturated(short2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return (ulong2)max((short)ulong.MinValue, x);
            }
            else
            {
                return (ulong2)(ushort2)max((short)ulong.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short3"/> <paramref name="x"/> to a <see cref="MaxMath.ulong3"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulongsaturated(short3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return (ulong3)max((short)ulong.MinValue, x);
            }
            else
            {
                return (ulong3)(ushort3)max((short)ulong.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.short4"/> <paramref name="x"/> to a <see cref="MaxMath.ulong4"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulongsaturated(short4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return (ulong4)max((short)ulong.MinValue, x);
            }
            else
            {
                return (ulong4)(ushort4)max((short)ulong.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="int2"/> <paramref name="x"/> to a <see cref="MaxMath.ulong2"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulongsaturated(int2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return (ulong2)math.max((int)ulong.MinValue, x);
            }
            else
            {
                return (ulong2)(uint2)math.max((int)ulong.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="int3"/> <paramref name="x"/> to a <see cref="MaxMath.ulong3"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulongsaturated(int3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return (ulong3)math.max((int)ulong.MinValue, x);
            }
            else
            {
                return (ulong3)(uint3)math.max((int)ulong.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="int4"/> <paramref name="x"/> to a <see cref="MaxMath.ulong4"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulongsaturated(int4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return (ulong4)math.max((int)ulong.MinValue, x);
            }
            else
            {
                return (ulong4)(uint4)math.max((int)ulong.MinValue, x);
            }
        }

        /// <summary>       Casts the <see cref="MaxMath.long2"/> <paramref name="x"/> to a <see cref="MaxMath.ulong2"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulongsaturated(long2 x)
        {
            return (ulong2)max((long)ulong.MinValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.long3"/> <paramref name="x"/> to a <see cref="MaxMath.ulong3"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulongsaturated(long3 x)
        {
            return (ulong3)max((long)ulong.MinValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/> <paramref name="x"/> to a <see cref="MaxMath.ulong4"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulongsaturated(long4 x)
        {
            return (ulong4)max((long)ulong.MinValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter2"/> <paramref name="x"/> to a <see cref="MaxMath.ulong2"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulongsaturated(quarter2 x)
        {
            return toulongsaturated((float2)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter3"/> <paramref name="x"/> to a <see cref="MaxMath.ulong3"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulongsaturated(quarter3 x)
        {
            return toulongsaturated((float3)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/> <paramref name="x"/> to a <see cref="MaxMath.ulong4"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulongsaturated(quarter4 x)
        {
            return toulongsaturated((float4)x);
        }

        /// <summary>       Casts the <see cref="half2"/> <paramref name="x"/> to a <see cref="MaxMath.ulong2"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulongsaturated(half2 x)
        {
            return toulongsaturated((float2)x);
        }

        /// <summary>       Casts the <see cref="half3"/> <paramref name="x"/> to a <see cref="MaxMath.ulong3"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulongsaturated(half3 x)
        {
            return toulongsaturated((float3)x);
        }

        /// <summary>       Casts the <see cref="half4"/> <paramref name="x"/> to a <see cref="MaxMath.ulong4"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulongsaturated(half4 x)
        {
            return toulongsaturated((float4)x);
        }

        /// <summary>       Casts the <see cref="float2"/> <paramref name="x"/> to a <see cref="MaxMath.ulong2"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulongsaturated(float2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                v128 MIN_VALUE = new v128(ulong.MinValue);
                v128 MAX_VALUE = new v128(ulong.MaxValue);
                v128 MIN_VALUE_F32 = new v128((float)ulong.MinValue, (float)ulong.MinValue, 0f, 0f);
                v128 MAX_VALUE_F32 = new v128((float)ulong.MaxValue, (float)ulong.MaxValue, 0f, 0f);

                v128 cast = (ulong2)x;

                v128 underflowMask = Xse.cmple_ps(_x, MIN_VALUE_F32);
                underflowMask = Xse.unpacklo_epi32(underflowMask, underflowMask);
                v128 overflowMask  = Xse.cmpge_ps(_x, MAX_VALUE_F32);
                overflowMask = Xse.unpacklo_epi32(overflowMask, overflowMask);

                return Xse.blendv_si128(Xse.blendv_si128(cast, MIN_VALUE, underflowMask), MAX_VALUE, overflowMask);
            }
            else
            {
                return new ulong2(toulongsaturated(x.x), toulongsaturated(x.y));
            }
        }

        /// <summary>       Casts the <see cref="float3"/> <paramref name="x"/> to a <see cref="MaxMath.ulong3"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulongsaturated(float3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                v256 MIN_VALUE = new v256(ulong.MinValue);
                v256 MAX_VALUE = new v256(ulong.MaxValue);
                v128 MIN_VALUE_F32 = new v128((float)ulong.MinValue);
                v128 MAX_VALUE_F32 = new v128((float)ulong.MaxValue);

                v256 cast = (ulong3)x;

                v128 underflowMask128 = Sse.cmple_ps(_x, MIN_VALUE_F32);
                v256 underflowMask256 = Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(underflowMask128), Sse.SHUFFLE(1, 1, 0, 0));
                underflowMask256 = Avx2.mm256_unpacklo_epi32(underflowMask256, underflowMask256);
                v128 overflowMask128 = Sse.cmpge_ps(_x, MAX_VALUE_F32);
                v256 overflowMask256 = Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(overflowMask128), Sse.SHUFFLE(1, 1, 0, 0));
                overflowMask256 = Avx2.mm256_unpacklo_epi32(overflowMask256, overflowMask256);

                return Xse.mm256_blendv_si256(Xse.mm256_blendv_si256(cast, MIN_VALUE, underflowMask256), MAX_VALUE, overflowMask256);
            }
            else
            {
                return new ulong3(toulongsaturated(x.xy), toulongsaturated(x.z));
            }
        }

        /// <summary>       Casts the <see cref="float4"/> <paramref name="x"/> to a <see cref="MaxMath.ulong4"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulongsaturated(float4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                v256 MIN_VALUE = new v256(ulong.MinValue);
                v256 MAX_VALUE = new v256(ulong.MaxValue);
                v128 MIN_VALUE_F32 = new v128((float)ulong.MinValue);
                v128 MAX_VALUE_F32 = new v128((float)ulong.MaxValue);

                v256 cast = (ulong4)x;

                v128 underflowMask128 = Sse.cmple_ps(_x, MIN_VALUE_F32);
                v256 underflowMask256 = Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(underflowMask128), Sse.SHUFFLE(1, 1, 0, 0));
                underflowMask256 = Avx2.mm256_unpacklo_epi32(underflowMask256, underflowMask256);
                v128 overflowMask128 = Sse.cmpge_ps(_x, MAX_VALUE_F32);
                v256 overflowMask256 = Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(overflowMask128), Sse.SHUFFLE(1, 1, 0, 0));
                overflowMask256 = Avx2.mm256_unpacklo_epi32(overflowMask256, overflowMask256);

                return Xse.mm256_blendv_si256(Xse.mm256_blendv_si256(cast, MIN_VALUE, underflowMask256), MAX_VALUE, overflowMask256);
            }
            else
            {
                return new ulong4(toulongsaturated(x.xy), toulongsaturated(x.zw));
            }
        }

        /// <summary>       Casts the <see cref="double2"/> <paramref name="x"/> to a <see cref="MaxMath.ulong2"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulongsaturated(double2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                v128 MIN_VALUE = new v128(ulong.MinValue);
                v128 MAX_VALUE = new v128(ulong.MaxValue);
                v128 MIN_VALUE_F64 = new v128((double)ulong.MinValue);
                v128 MAX_VALUE_F64 = new v128((double)ulong.MaxValue);

                v128 cast = (ulong2)x;

                v128 underflowMask = Xse.cmple_pd(_x, MIN_VALUE_F64);
                v128 overflowMask  = Xse.cmpge_pd(_x, MAX_VALUE_F64);

                return Xse.blendv_si128(Xse.blendv_si128(cast, MIN_VALUE, underflowMask), MAX_VALUE, overflowMask);
            }
            else
            {
                return new ulong2(toulongsaturated(x.x), toulongsaturated(x.y));
            }
        }

        /// <summary>       Casts the <see cref="double3"/> <paramref name="x"/> to a <see cref="MaxMath.ulong3"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulongsaturated(double3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 _x = RegisterConversion.ToV256(x);

                v256 MIN_VALUE = new v256(ulong.MinValue);
                v256 MAX_VALUE = new v256(ulong.MaxValue);
                v256 MIN_VALUE_F64 = new v256((double)ulong.MinValue);
                v256 MAX_VALUE_F64 = new v256((double)ulong.MaxValue);

                v256 cast = (ulong3)x;

                v256 underflowMask = Xse.mm256_cmple_pd(_x, MIN_VALUE_F64);
                v256 overflowMask  = Xse.mm256_cmpge_pd(_x, MAX_VALUE_F64);

                return Avx.mm256_blendv_pd(Avx.mm256_blendv_pd(cast, MIN_VALUE, underflowMask), MAX_VALUE, overflowMask);
            }
            else
            {
                return new ulong3(toulongsaturated(x.xy), toulongsaturated(x.z));
            }
        }

        /// <summary>       Casts the <see cref="double4"/> <paramref name="x"/> to a <see cref="MaxMath.ulong4"/> and returns the result, where each component is clamped to the interval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulongsaturated(double4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 _x = RegisterConversion.ToV256(x);

                v256 MIN_VALUE = new v256(ulong.MinValue);
                v256 MAX_VALUE = new v256(ulong.MaxValue);
                v256 MIN_VALUE_F64 = new v256((double)ulong.MinValue);
                v256 MAX_VALUE_F64 = new v256((double)ulong.MaxValue);

                v256 cast = (ulong4)x;

                v256 underflowMask = Xse.mm256_cmple_pd(_x, MIN_VALUE_F64);
                v256 overflowMask  = Xse.mm256_cmpge_pd(_x, MAX_VALUE_F64);

                return Avx.mm256_blendv_pd(Avx.mm256_blendv_pd(cast, MIN_VALUE, underflowMask), MAX_VALUE, overflowMask);
            }
            else
            {
                return new ulong4(toulongsaturated(x.xy), toulongsaturated(x.zw));
            }
        }
        #endregion

        #region To long
        /// <summary>       Casts the <see cref="Int128"/> <paramref name="x"/> to a <see cref="long"/> and returns the result, which is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long tolongsaturated(Int128 x)
        {
            return (long)clamp(x, long.MinValue, long.MaxValue);
        }


        /// <summary>       Casts the <see cref="ulong"/> <paramref name="x"/> to a <see cref="long"/> and returns the result, which is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long tolongsaturated(ulong x)
        {
            return (long)math.min((ulong)long.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="UInt128"/> <paramref name="x"/> to a <see cref="long"/> and returns the result, which is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long tolongsaturated(UInt128 x)
        {
            return (long)min(long.MaxValue, x);
        }


        /// <summary>       Casts the <see cref="quarter"/> <paramref name="x"/> to a <see cref="long"/> and returns the result, which is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long tolongsaturated(quarter x)
        {
            return tolongsaturated((float)x);
        }

        /// <summary>       Casts the <see cref="half"/> <paramref name="x"/> to a <see cref="long"/> and returns the result, which is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long tolongsaturated(half x)
        {
            return tolongsaturated((float)x);
        }

        /// <summary>       Casts the <see cref="float"/> <paramref name="x"/> to a <see cref="long"/> and returns the result, which is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long tolongsaturated(float x)
        {
            return math.select(math.select((long)x, long.MinValue, x <= long.MinValue), long.MaxValue, x >= long.MaxValue);
        }

        /// <summary>       Casts the <see cref="double"/> <paramref name="x"/> to a <see cref="long"/> and returns the result, which is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long tolongsaturated(double x)
        {
            return math.select(math.select((long)x, long.MinValue, x <= long.MinValue), long.MaxValue, x >= long.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong2"/> <paramref name="x"/> to a <see cref="MaxMath.long2"/> and returns the result, where each component is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolongsaturated(ulong2 x)
        {
            return (long2)min((ulong)long.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong3"/> <paramref name="x"/> to a <see cref="MaxMath.long3"/> and returns the result, where each component is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolongsaturated(ulong3 x)
        {
            return (long3)min((ulong)long.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/> <paramref name="x"/> to a <see cref="MaxMath.long4"/> and returns the result, where each component is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolongsaturated(ulong4 x)
        {
            return (long4)min((ulong)long.MaxValue, x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter2"/> <paramref name="x"/> to a <see cref="MaxMath.long2"/> and returns the result, where each component is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolongsaturated(quarter2 x)
        {
            return tolongsaturated((float2)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter3"/> <paramref name="x"/> to a <see cref="MaxMath.long3"/> and returns the result, where each component is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolongsaturated(quarter3 x)
        {
            return tolongsaturated((float3)x);
        }

        /// <summary>       Casts the <see cref="MaxMath.quarter4"/> <paramref name="x"/> to a <see cref="MaxMath.long4"/> and returns the result, where each component is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolongsaturated(quarter4 x)
        {
            return tolongsaturated((float4)x);
        }

        /// <summary>       Casts the <see cref="half2"/> <paramref name="x"/> to a <see cref="MaxMath.long2"/> and returns the result, where each component is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolongsaturated(half2 x)
        {
            return tolongsaturated((float2)x);
        }

        /// <summary>       Casts the <see cref="half3"/> <paramref name="x"/> to a <see cref="MaxMath.long3"/> and returns the result, where each component is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolongsaturated(half3 x)
        {
            return tolongsaturated((float3)x);
        }

        /// <summary>       Casts the <see cref="half4"/> <paramref name="x"/> to a <see cref="MaxMath.long4"/> and returns the result, where each component is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolongsaturated(half4 x)
        {
            return tolongsaturated((float4)x);
        }

        /// <summary>       Casts the <see cref="float2"/> <paramref name="x"/> to a <see cref="MaxMath.long2"/> and returns the result, where each component is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolongsaturated(float2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                v128 MIN_VALUE = new v128(long.MinValue);
                v128 MAX_VALUE = new v128(long.MaxValue);
                v128 MIN_VALUE_F32 = new v128((float)long.MinValue, (float)long.MinValue, 0f, 0f);
                v128 MAX_VALUE_F32 = new v128((float)long.MaxValue, (float)long.MaxValue, 0f, 0f);

                v128 cast = (long2)x;

                v128 underflowMask = Xse.cmple_ps(_x, MIN_VALUE_F32);
                underflowMask = Xse.unpacklo_epi32(underflowMask, underflowMask);
                v128 overflowMask  = Xse.cmpge_ps(_x, MAX_VALUE_F32);
                overflowMask = Xse.unpacklo_epi32(overflowMask, overflowMask);

                return Xse.blendv_si128(Xse.blendv_si128(cast, MIN_VALUE, underflowMask), MAX_VALUE, overflowMask);
            }
            else
            {
                return new long2(tolongsaturated(x.x), tolongsaturated(x.y));
            }
        }

        /// <summary>       Casts the <see cref="float3"/> <paramref name="x"/> to a <see cref="MaxMath.long3"/> and returns the result, where each component is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolongsaturated(float3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                v256 MIN_VALUE = new v256(long.MinValue);
                v256 MAX_VALUE = new v256(long.MaxValue);
                v128 MIN_VALUE_F32 = new v128((float)long.MinValue);
                v128 MAX_VALUE_F32 = new v128((float)long.MaxValue);

                v256 cast = (long3)x;

                v128 underflowMask128 = Sse.cmple_ps(_x, MIN_VALUE_F32);
                v256 underflowMask256 = Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(underflowMask128), Sse.SHUFFLE(1, 1, 0, 0));
                underflowMask256 = Avx2.mm256_unpacklo_epi32(underflowMask256, underflowMask256);
                v128 overflowMask128 = Sse.cmpge_ps(_x, MAX_VALUE_F32);
                v256 overflowMask256 = Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(overflowMask128), Sse.SHUFFLE(1, 1, 0, 0));
                overflowMask256 = Avx2.mm256_unpacklo_epi32(overflowMask256, overflowMask256);

                return Xse.mm256_blendv_si256(Xse.mm256_blendv_si256(cast, MIN_VALUE, underflowMask256), MAX_VALUE, overflowMask256);
            }
            else
            {
                return new long3(tolongsaturated(x.xy), tolongsaturated(x.z));
            }
        }

        /// <summary>       Casts the <see cref="float4"/> <paramref name="x"/> to a <see cref="MaxMath.long4"/> and returns the result, where each component is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolongsaturated(float4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                v256 MIN_VALUE = new v256(long.MinValue);
                v256 MAX_VALUE = new v256(long.MaxValue);
                v128 MIN_VALUE_F32 = new v128((float)long.MinValue);
                v128 MAX_VALUE_F32 = new v128((float)long.MaxValue);

                v256 cast = (long4)x;

                v128 underflowMask128 = Sse.cmple_ps(_x, MIN_VALUE_F32);
                v256 underflowMask256 = Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(underflowMask128), Sse.SHUFFLE(1, 1, 0, 0));
                underflowMask256 = Avx2.mm256_unpacklo_epi32(underflowMask256, underflowMask256);
                v128 overflowMask128 = Sse.cmpge_ps(_x, MAX_VALUE_F32);
                v256 overflowMask256 = Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(overflowMask128), Sse.SHUFFLE(1, 1, 0, 0));
                overflowMask256 = Avx2.mm256_unpacklo_epi32(overflowMask256, overflowMask256);

                return Xse.mm256_blendv_si256(Xse.mm256_blendv_si256(cast, MIN_VALUE, underflowMask256), MAX_VALUE, overflowMask256);
            }
            else
            {
                return new long4(tolongsaturated(x.xy), tolongsaturated(x.zw));
            }
        }

        /// <summary>       Casts the <see cref="double2"/> <paramref name="x"/> to a <see cref="MaxMath.long2"/> and returns the result, where each component is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolongsaturated(double2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x = RegisterConversion.ToV128(x);

                v128 MIN_VALUE = new v128(long.MinValue);
                v128 MAX_VALUE = new v128(long.MaxValue);
                v128 MIN_VALUE_F64 = new v128((double)long.MinValue);
                v128 MAX_VALUE_F64 = new v128((double)long.MaxValue);

                v128 cast = (long2)x;

                v128 underflowMask = Xse.cmple_pd(_x, MIN_VALUE_F64);
                v128 overflowMask  = Xse.cmpge_pd(_x, MAX_VALUE_F64);

                return Xse.blendv_si128(Xse.blendv_si128(cast, MIN_VALUE, underflowMask), MAX_VALUE, overflowMask);
            }
            else
            {
                return new long2(tolongsaturated(x.x), tolongsaturated(x.y));
            }
        }

        /// <summary>       Casts the <see cref="double3"/> <paramref name="x"/> to a <see cref="MaxMath.long3"/> and returns the result, where each component is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolongsaturated(double3 x)
        {
            if (Avx.IsAvxSupported)
            {
                v256 _x = RegisterConversion.ToV256(x);

                v256 MIN_VALUE = new v256(long.MinValue);
                v256 MAX_VALUE = new v256(long.MaxValue);
                v256 MIN_VALUE_F64 = new v256((double)long.MinValue);
                v256 MAX_VALUE_F64 = new v256((double)long.MaxValue);

                v256 cast = (long3)x;

                v256 underflowMask = Xse.mm256_cmple_pd(_x, MIN_VALUE_F64);
                v256 overflowMask  = Xse.mm256_cmpge_pd(_x, MAX_VALUE_F64);

                return Avx.mm256_blendv_pd(Avx.mm256_blendv_pd(cast, MIN_VALUE, underflowMask), MAX_VALUE, overflowMask);
            }
            else
            {
                return new long3(tolongsaturated(x.xy), tolongsaturated(x.z));
            }
        }

        /// <summary>       Casts the <see cref="double4"/> <paramref name="x"/> to a <see cref="MaxMath.long4"/> and returns the result, where each component is clamped to the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolongsaturated(double4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 _x = RegisterConversion.ToV256(x);

                v256 MIN_VALUE = new v256(long.MinValue);
                v256 MAX_VALUE = new v256(long.MaxValue);
                v256 MIN_VALUE_F64 = new v256((double)long.MinValue);
                v256 MAX_VALUE_F64 = new v256((double)long.MaxValue);

                v256 cast = (long4)x;

                v256 underflowMask = Xse.mm256_cmple_pd(_x, MIN_VALUE_F64);
                v256 overflowMask  = Xse.mm256_cmpge_pd(_x, MAX_VALUE_F64);

                return Avx.mm256_blendv_pd(Avx.mm256_blendv_pd(cast, MIN_VALUE, underflowMask), MAX_VALUE, overflowMask);
            }
            else
            {
                return new long4(tolongsaturated(x.xy), tolongsaturated(x.zw));
            }
        }
        #endregion

        #region To UInt128
        /// <summary>       Casts the <see cref="quarter"/> <paramref name="x"/> to a <see cref="UInt128"/> and returns the result, which is clamped to the interval [<see cref="UInt128.MinValue"/>, <see cref="UInt128.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 touint128saturated(quarter x)
        {
            return select(select((UInt128)x, UInt128.MaxValue, x >= (float)UInt128.MaxValue), UInt128.MinValue, x <= (float)UInt128.MinValue);
        }

        /// <summary>       Casts the <see cref="half"/> <paramref name="x"/> to a <see cref="UInt128"/> and returns the result, which is clamped to the interval [<see cref="UInt128.MinValue"/>, <see cref="UInt128.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 touint128saturated(half x)
        {
            return select(select((UInt128)x, UInt128.MaxValue, x >= (float)UInt128.MaxValue), UInt128.MinValue, x <= (float)UInt128.MinValue);
        }

        /// <summary>       Casts the <see cref="float"/> <paramref name="x"/> to a <see cref="UInt128"/> and returns the result, which is clamped to the interval [<see cref="UInt128.MinValue"/>, <see cref="UInt128.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 touint128saturated(float x)
        {
            return (UInt128)math.max(x, 0f);
        }

        /// <summary>       Casts the <see cref="double"/> <paramref name="x"/> to a <see cref="UInt128"/> and returns the result, which is clamped to the interval [<see cref="UInt128.MinValue"/>, <see cref="UInt128.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 touint128saturated(double x)
        {
            return select(select((UInt128)x, UInt128.MaxValue, x >= (double)UInt128.MaxValue), UInt128.MinValue, x <= (double)UInt128.MinValue);
        }
        #endregion

        #region To Int128
        /// <summary>       Casts the <see cref="quarter"/> <paramref name="x"/> to an <see cref="Int128"/> and returns the result, which is clamped to the interval [<see cref="Int128.MinValue"/>, <see cref="Int128.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 toint128saturated(quarter x)
        {
            return select(select((Int128)x, Int128.MaxValue, x >= (float)Int128.MaxValue), Int128.MinValue, x <= (float)Int128.MinValue);
        }

        /// <summary>       Casts the <see cref="half"/> <paramref name="x"/> to an <see cref="Int128"/> and returns the result, which is clamped to the interval [<see cref="Int128.MinValue"/>, <see cref="Int128.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 toint128saturated(half x)
        {
            return select(select((Int128)x, Int128.MaxValue, x >= (float)Int128.MaxValue), Int128.MinValue, x <= (float)Int128.MinValue);
        }

        /// <summary>       Casts the <see cref="float"/> <paramref name="x"/> to an <see cref="Int128"/> and returns the result, which is clamped to the interval [<see cref="Int128.MinValue"/>, <see cref="Int128.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 toint128saturated(float x)
        {
            return select(select((Int128)x, Int128.MaxValue, x >= (float)Int128.MaxValue), Int128.MinValue, x <= (float)Int128.MinValue);
        }

        /// <summary>       Casts the <see cref="double"/> <paramref name="x"/> to an <see cref="Int128"/> and returns the result, which is clamped to the interval [<see cref="Int128.MinValue"/>, <see cref="Int128.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 toint128saturated(double x)
        {
            return select(select((Int128)x, Int128.MaxValue, x >= (double)Int128.MaxValue), Int128.MinValue, x <= (double)Int128.MinValue);
        }
        #endregion


        #region To quarter
        /// <summary>       Casts the <see cref="sbyte"/> <paramref name="x"/> to a <see cref="quarter"/> and returns the result, which is clamped to the interval [<see cref="quarter.MinValue"/>, <see cref="quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquartersaturated(sbyte x)
        {
            return quarter.SByteToQuarter(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="short"/> <paramref name="x"/> to a <see cref="quarter"/> and returns the result, which is clamped to the interval [<see cref="quarter.MinValue"/>, <see cref="quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquartersaturated(short x)
        {
            return quarter.ShortToQuarter(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="int"/> <paramref name="x"/> to a <see cref="quarter"/> and returns the result, which is clamped to the interval [<see cref="quarter.MinValue"/>, <see cref="quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquartersaturated(int x)
        {
            return quarter.IntToQuarter(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="long"/> <paramref name="x"/> to a <see cref="quarter"/> and returns the result, which is clamped to the longerval [<see cref="quarter.MinValue"/>, <see cref="quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquartersaturated(long x)
        {
            return quarter.LongToQuarter(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="Int128"/> <paramref name="x"/> to a <see cref="quarter"/> and returns the result, which is clamped to the longerval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquartersaturated(Int128 x)
        {
            return quarter.Int128ToQuarter(x, quarter.MaxValue);
        }


        /// <summary>       Casts the <see cref="byte"/> <paramref name="x"/> to a <see cref="quarter"/> and returns the result, which is clamped to the interval [<see cref="quarter.MinValue"/>, <see cref="quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquartersaturated(byte x)
        {
            return quarter.ByteToQuarter(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="ushort"/> <paramref name="x"/> to a <see cref="quarter"/> and returns the result, which is clamped to the interval [<see cref="quarter.MinValue"/>, <see cref="quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquartersaturated(ushort x)
        {
            return quarter.UShortToQuarter(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="uint"/> <paramref name="x"/> to a <see cref="quarter"/> and returns the result, which is clamped to the interval [<see cref="quarter.MinValue"/>, <see cref="quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquartersaturated(uint x)
        {
            return quarter.UIntToQuarter(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="ulong"/> <paramref name="x"/> to a <see cref="quarter"/> and returns the result, which is clamped to the interval [<see cref="quarter.MinValue"/>, <see cref="quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquartersaturated(ulong x)
        {
            return quarter.ULongToQuarter(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="UInt128"/> <paramref name="x"/> to a <see cref="quarter"/> and returns the result, which is clamped to the longerval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquartersaturated(UInt128 x)
        {
            return quarter.UInt128ToQuarter(x, quarter.MaxValue);
        }


        /// <summary>       Casts the <see cref="half"/> <paramref name="x"/> to a <see cref="quarter"/> and returns the result, which is clamped to the interval [<see cref="quarter.MinValue"/>, <see cref="quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquartersaturated(half x)
        {
            return (quarter)math.clamp((float)x, quarter.MinValue, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="float"/> <paramref name="x"/> to a <see cref="quarter"/> and returns the result, which is clamped to the interval [<see cref="quarter.MinValue"/>, <see cref="quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquartersaturated(float x)
        {
            return (quarter)math.clamp(x, quarter.MinValue, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="double"/> <paramref name="x"/> to a <see cref="quarter"/> and returns the result, which is clamped to the interval [<see cref="quarter.MinValue"/>, <see cref="quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquartersaturated(double x)
        {
            return (quarter)math.clamp(x, quarter.MinValue, quarter.MaxValue);
        }


        /// <summary>       Casts the <see cref="MaxMath.sbyte2"/> <paramref name="x"/> to a <see cref="MaxMath.quarter2"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersaturated(sbyte2 x)
        {
            return MaxMath.quarter2.SByte2ToQuarter2(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte3"/> <paramref name="x"/> to a <see cref="MaxMath.quarter3"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersaturated(sbyte3 x)
        {
            return MaxMath.quarter3.SByte3ToQuarter3(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte4"/> <paramref name="x"/> to a <see cref="MaxMath.quarter4"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersaturated(sbyte4 x)
        {
            return MaxMath.quarter4.SByte4ToQuarter4(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.sbyte8"/> <paramref name="x"/> to a <see cref="MaxMath.quarter8"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquartersaturated(sbyte8 x)
        {
            return MaxMath.quarter8.SByte8ToQuarter8(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.short2"/> <paramref name="x"/> to a <see cref="MaxMath.quarter2"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersaturated(short2 x)
        {
            return MaxMath.quarter2.Short2ToQuarter2(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.short3"/> <paramref name="x"/> to a <see cref="MaxMath.quarter3"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersaturated(short3 x)
        {
            return MaxMath.quarter3.Short3ToQuarter3(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.short4"/> <paramref name="x"/> to a <see cref="MaxMath.quarter4"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersaturated(short4 x)
        {
            return MaxMath.quarter4.Short4ToQuarter4(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.short8"/> <paramref name="x"/> to a <see cref="MaxMath.quarter8"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquartersaturated(short8 x)
        {
            return MaxMath.quarter8.Short8ToQuarter8(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="int2"/> <paramref name="x"/> to a <see cref="MaxMath.quarter2"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersaturated(int2 x)
        {
            return MaxMath.quarter2.Int2ToQuarter2(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="int3"/> <paramref name="x"/> to a <see cref="MaxMath.quarter3"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersaturated(int3 x)
        {
            return MaxMath.quarter3.Int3ToQuarter3(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="int4"/> <paramref name="x"/> to a <see cref="MaxMath.quarter4"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersaturated(int4 x)
        {
            return MaxMath.quarter4.Int4ToQuarter4(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.int8"/> <paramref name="x"/> to a <see cref="MaxMath.quarter8"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquartersaturated(int8 x)
        {
            return MaxMath.quarter8.Int8ToQuarter8(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long2"/> <paramref name="x"/> to a <see cref="MaxMath.quarter2"/> and returns the result, where each component is clamped to the longerval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersaturated(long2 x)
        {
            return MaxMath.quarter2.Long2ToQuarter2(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long3"/> <paramref name="x"/> to a <see cref="MaxMath.quarter3"/> and returns the result, where each component is clamped to the longerval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersaturated(long3 x)
        {
            return MaxMath.quarter3.Long3ToQuarter3(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/> <paramref name="x"/> to a <see cref="MaxMath.quarter4"/> and returns the result, where each component is clamped to the longerval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersaturated(long4 x)
        {
            return MaxMath.quarter4.Long4ToQuarter4(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.quarter8"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquartersaturated(long4 lo, long4 hi)
        {
            return new quarter8(toquartersaturated(lo), toquartersaturated(hi));
        }


        /// <summary>       Casts the <see cref="MaxMath.byte2"/> <paramref name="x"/> to a <see cref="MaxMath.quarter2"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersaturated(byte2 x)
        {
            return MaxMath.quarter2.Byte2ToQuarter2(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.byte3"/> <paramref name="x"/> to a <see cref="MaxMath.quarter3"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersaturated(byte3 x)
        {
            return MaxMath.quarter3.Byte3ToQuarter3(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.byte4"/> <paramref name="x"/> to a <see cref="MaxMath.quarter4"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersaturated(byte4 x)
        {
            return MaxMath.quarter4.Byte4ToQuarter4(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.byte8"/> <paramref name="x"/> to a <see cref="MaxMath.quarter8"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquartersaturated(byte8 x)
        {
            return MaxMath.quarter8.Byte8ToQuarter8(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort2"/> <paramref name="x"/> to a <see cref="MaxMath.quarter2"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersaturated(ushort2 x)
        {
            return MaxMath.quarter2.UShort2ToQuarter2(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort3"/> <paramref name="x"/> to a <see cref="MaxMath.quarter3"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersaturated(ushort3 x)
        {
            return MaxMath.quarter3.UShort3ToQuarter3(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort4"/> <paramref name="x"/> to a <see cref="MaxMath.quarter4"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersaturated(ushort4 x)
        {
            return MaxMath.quarter4.UShort4ToQuarter4(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort8"/> <paramref name="x"/> to a <see cref="MaxMath.quarter8"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquartersaturated(ushort8 x)
        {
            return MaxMath.quarter8.UShort8ToQuarter8(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="uint2"/> <paramref name="x"/> to a <see cref="MaxMath.quarter2"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersaturated(uint2 x)
        {
            return MaxMath.quarter2.UInt2ToQuarter2(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="uint3"/> <paramref name="x"/> to a <see cref="MaxMath.quarter3"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersaturated(uint3 x)
        {
            return MaxMath.quarter3.UInt3ToQuarter3(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="uint4"/> <paramref name="x"/> to a <see cref="MaxMath.quarter4"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersaturated(uint4 x)
        {
            return MaxMath.quarter4.UInt4ToQuarter4(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.uint8"/> <paramref name="x"/> to a <see cref="MaxMath.quarter8"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquartersaturated(uint8 x)
        {
            return MaxMath.quarter8.UInt8ToQuarter8(x, quarter.MaxValue);
        }


        /// <summary>       Casts the <see cref="MaxMath.ulong2"/> <paramref name="x"/> to a <see cref="MaxMath.quarter2"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersaturated(ulong2 x)
        {
            return MaxMath.quarter2.ULong2ToQuarter2(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong3"/> <paramref name="x"/> to a <see cref="MaxMath.quarter3"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersaturated(ulong3 x)
        {
            return MaxMath.quarter3.ULong3ToQuarter3(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/> <paramref name="x"/> to a <see cref="MaxMath.quarter4"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersaturated(ulong4 x)
        {
            return MaxMath.quarter4.ULong4ToQuarter4(x, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.quarter8"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquartersaturated(ulong4 lo, ulong4 hi)
        {
            return new quarter8(toquartersaturated(lo), toquartersaturated(hi));
        }


        /// <summary>       Casts the <see cref="half2"/> <paramref name="x"/> to a <see cref="MaxMath.quarter2"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersaturated(half2 x)
        {
            return (quarter2)math.clamp((float2)x, quarter.MinValue, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="half3"/> <paramref name="x"/> to a <see cref="MaxMath.quarter3"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersaturated(half3 x)
        {
            return (quarter3)math.clamp((float3)x, quarter.MinValue, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="half4"/> <paramref name="x"/> to a <see cref="MaxMath.quarter4"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersaturated(half4 x)
        {
            return (quarter4)math.clamp((float4)x, quarter.MinValue, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.half8"/> <paramref name="x"/> to a <see cref="MaxMath.quarter8"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquartersaturated(half8 x)
        {
            return (quarter8)clamp((float8)x, quarter.MinValue, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="float2"/> <paramref name="x"/> to a <see cref="MaxMath.quarter2"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersaturated(float2 x)
        {
            return (quarter2)math.clamp(x, quarter.MinValue, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="float3"/> <paramref name="x"/> to a <see cref="MaxMath.quarter3"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersaturated(float3 x)
        {
            return (quarter3)math.clamp(x, quarter.MinValue, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="float4"/> <paramref name="x"/> to a <see cref="MaxMath.quarter4"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersaturated(float4 x)
        {
            return (quarter4)math.clamp(x, quarter.MinValue, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.float8"/> <paramref name="x"/> to a <see cref="MaxMath.quarter8"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquartersaturated(float8 x)
        {
            return (quarter8)clamp(x, quarter.MinValue, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="double2"/> <paramref name="x"/> to a <see cref="MaxMath.quarter2"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquartersaturated(double2 x)
        {
            return (quarter2)math.clamp(x, quarter.MinValue, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="double3"/> <paramref name="x"/> to a <see cref="MaxMath.quarter3"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquartersaturated(double3 x)
        {
            return (quarter3)math.clamp(x, quarter.MinValue, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/> <paramref name="x"/> to a <see cref="MaxMath.quarter4"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquartersaturated(double4 x)
        {
            return (quarter4)math.clamp(x, quarter.MinValue, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.quarter8"/> and returns the result, where each component is clamped to the interval [<see cref="MaxMath.quarter.MinValue"/>, <see cref="MaxMath.quarter.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquartersaturated(double4 lo, double4 hi)
        {
            double4 MIN_VALUE = quarter.MinValue;
            double4 MAX_VALUE = quarter.MaxValue;

            return new quarter8((quarter4)math.clamp(lo, MIN_VALUE, MAX_VALUE),
                                (quarter4)math.clamp(hi, MIN_VALUE, MAX_VALUE));
        }
        #endregion

        #region To half
        /// <summary>       Casts the <see cref="int"/> <paramref name="x"/> to a <see cref="half"/> and returns the result, which is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfsaturated(int x)
        {
            return (half)(float)math.clamp(x, (int)half.MinValue, (int)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="long"/> <paramref name="x"/> to a <see cref="half"/> and returns the result, which is clamped to the longerval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfsaturated(long x)
        {
            return (half)(float)math.clamp(x, (long)half.MinValue, (long)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="Int128"/> <paramref name="x"/> to a <see cref="half"/> and returns the result, which is clamped to the longerval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfsaturated(Int128 x)
        {
            return (half)clamp(x, (Int128)half.MinValue, (Int128)half.MaxValue);
        }


        /// <summary>       Casts the <see cref="ushort"/> <paramref name="x"/> to a <see cref="half"/> and returns the result, which is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfsaturated(ushort x)
        {
            return (half)(float)min(x, (ushort)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="uint"/> <paramref name="x"/> to a <see cref="half"/> and returns the result, which is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfsaturated(uint x)
        {
            return (half)(float)math.min(x, (uint)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="ulong"/> <paramref name="x"/> to a <see cref="half"/> and returns the result, which is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfsaturated(ulong x)
        {
            return (half)math.min(x, (ulong)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="UInt128"/> <paramref name="x"/> to a <see cref="half"/> and returns the result, which is clamped to the longerval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfsaturated(UInt128 x)
        {
            return (half)min(x, (UInt128)half.MaxValue);
        }


        /// <summary>       Casts the <see cref="float"/> <paramref name="x"/> to a <see cref="half"/> and returns the result, which is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfsaturated(float x)
        {
            return (half)math.clamp(x, half.MinValue, half.MaxValue);
        }

        /// <summary>       Casts the <see cref="double"/> <paramref name="x"/> to a <see cref="half"/> and returns the result, which is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfsaturated(double x)
        {
            return (half)math.clamp(x, half.MinValue, half.MaxValue);
        }


        /// <summary>       Casts the <see cref="int2"/> <paramref name="x"/> to a <see cref="half2"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfsaturated(int2 x)
        {
            return (half2)(float2)math.clamp(x, (int)half.MinValue, (int)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="int3"/> <paramref name="x"/> to a <see cref="half3"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfsaturated(int3 x)
        {
            return (half3)(float3)math.clamp(x, (int)half.MinValue, (int)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="int4"/> <paramref name="x"/> to a <see cref="half4"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfsaturated(int4 x)
        {
            return (half4)(float4)math.clamp(x, (int)half.MinValue, (int)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.int8"/> <paramref name="x"/> to a <see cref="MaxMath.half8"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfsaturated(int8 x)
        {
            return (half8)(float8)clamp(x, (int)half.MinValue, (int)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long2"/> <paramref name="x"/> to a <see cref="half2"/> and returns the result, where each component is clamped to the longerval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfsaturated(long2 x)
        {
            return (half2)(float2)clamp(x, (long)half.MinValue, (long)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long3"/> <paramref name="x"/> to a <see cref="half3"/> and returns the result, where each component is clamped to the longerval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfsaturated(long3 x)
        {
            return (half3)(float3)clamp(x, (long)half.MinValue, (long)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/> <paramref name="x"/> to a <see cref="half4"/> and returns the result, where each component is clamped to the longerval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfsaturated(long4 x)
        {
            return (half4)(float4)clamp(x, (long)half.MinValue, (long)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.long4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.half8"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfsaturated(long4 lo, long4 hi)
        {
            long4 MIN_VALUE = (long)half.MinValue;
            long4 MAX_VALUE = (long)half.MaxValue;

            return (half8)new float8((float4)clamp(lo, MIN_VALUE, MAX_VALUE), (float4)clamp(hi, MIN_VALUE, MAX_VALUE));
        }


        /// <summary>       Casts the <see cref="MaxMath.ushort2"/> <paramref name="x"/> to a <see cref="half2"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfsaturated(ushort2 x)
        {
            return (half2)(float2)min(x, (ushort)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort3"/> <paramref name="x"/> to a <see cref="half3"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfsaturated(ushort3 x)
        {
            return (half3)(float3)min(x, (ushort)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort4"/> <paramref name="x"/> to a <see cref="half4"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfsaturated(ushort4 x)
        {
            return (half4)(float4)min(x, (ushort)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ushort8"/> <paramref name="x"/> to a <see cref="MaxMath.half8"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfsaturated(ushort8 x)
        {
            return (half8)(float8)min(x, (ushort)half.MaxValue);
        }


        /// <summary>       Casts the <see cref="uint2"/> <paramref name="x"/> to a <see cref="half2"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfsaturated(uint2 x)
        {
            return (half2)(float2)math.min(x, (uint)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="uint3"/> <paramref name="x"/> to a <see cref="half3"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfsaturated(uint3 x)
        {
            return (half3)(float3)math.min(x, (uint)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="uint4"/> <paramref name="x"/> to a <see cref="half4"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfsaturated(uint4 x)
        {
            return (half4)(float4)math.min(x, (uint)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.uint8"/> <paramref name="x"/> to a <see cref="MaxMath.half8"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfsaturated(uint8 x)
        {
            return (half8)(float8)min(x, (uint)half.MaxValue);
        }


        /// <summary>       Casts the <see cref="MaxMath.ulong2"/> <paramref name="x"/> to a <see cref="half2"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfsaturated(ulong2 x)
        {
            return (half2)min(x, (ulong)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong3"/> <paramref name="x"/> to a <see cref="half3"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfsaturated(ulong3 x)
        {
            return (half3)min(x, (ulong)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/> <paramref name="x"/> to a <see cref="half4"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfsaturated(ulong4 x)
        {
            return (half4)min(x, (ulong)half.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.ulong4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.half8"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfsaturated(ulong4 lo, ulong4 hi)
        {
            ulong4 MAX_VALUE = (ulong)half.MaxValue;

            return (half8)new float8((float4)min(lo, MAX_VALUE), (float4)min(hi, MAX_VALUE));
        }


        /// <summary>       Casts the <see cref="float2"/> <paramref name="x"/> to a <see cref="half2"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfsaturated(float2 x)
        {
            return (half2)math.clamp(x, half.MinValue, half.MaxValue);
        }

        /// <summary>       Casts the <see cref="float3"/> <paramref name="x"/> to a <see cref="half3"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfsaturated(float3 x)
        {
            return (half3)math.clamp(x, half.MinValue, half.MaxValue);
        }

        /// <summary>       Casts the <see cref="float4"/> <paramref name="x"/> to a <see cref="half4"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfsaturated(float4 x)
        {
            return (half4)math.clamp(x, half.MinValue, half.MaxValue);
        }

        /// <summary>       Casts the <see cref="MaxMath.float8"/> <paramref name="x"/> to a <see cref="MaxMath.half8"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfsaturated(float8 x)
        {
            return (half8)clamp(x, half.MinValue, half.MaxValue);
        }

        /// <summary>       Casts the <see cref="double2"/> <paramref name="x"/> to a <see cref="half2"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfsaturated(double2 x)
        {
            return (half2)math.clamp(x, half.MinValue, half.MaxValue);
        }

        /// <summary>       Casts the <see cref="double3"/> <paramref name="x"/> to a <see cref="half3"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfsaturated(double3 x)
        {
            return (half3)math.clamp(x, half.MinValue, half.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/> <paramref name="x"/> to a <see cref="half4"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfsaturated(double4 x)
        {
            return (half4)math.clamp(x, half.MinValue, half.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.half8"/> and returns the result, where each component is clamped to the interval [<see cref="half.MinValue"/>, <see cref="half.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfsaturated(double4 lo, double4 hi)
        {
            double4 MIN_VALUE = half.MinValue;
            double4 MAX_VALUE = half.MaxValue;

            return (half8)new float8((float4)math.clamp(lo, MIN_VALUE, MAX_VALUE), (float4)math.clamp(hi, MIN_VALUE, MAX_VALUE));
        }
        #endregion

        #region To float
        /// <summary>       Casts the <see cref="UInt128"/> <paramref name="x"/> to a <see cref="float"/> and returns the result, which is clamped to the interval [<see cref="float.MinValue"/>, <see cref="float.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float tofloatsaturated(UInt128 x)
        {
            float result = x;

            return math.isinf(result) ? float.MaxValue : result;
        }


        /// <summary>       Casts the <see cref="double"/> <paramref name="x"/> to a <see cref="float"/> and returns the result, which is clamped to the interval [<see cref="float.MinValue"/>, <see cref="float.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float tofloatsaturated(double x)
        {
            return (float)math.clamp(x, float.MinValue, float.MaxValue);
        }


        /// <summary>       Casts the <see cref="double2"/> <paramref name="x"/> to a <see cref="float2"/> and returns the result, where each component is clamped to the interval [<see cref="float.MinValue"/>, <see cref="float.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tofloatsaturated(double2 x)
        {
            return (float2)math.clamp(x, float.MinValue, float.MaxValue);
        }

        /// <summary>       Casts the <see cref="double3"/> <paramref name="x"/> to a <see cref="float3"/> and returns the result, where each component is clamped to the interval [<see cref="float.MinValue"/>, <see cref="float.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tofloatsaturated(double3 x)
        {
            return (float3)math.clamp(x, float.MinValue, float.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/> <paramref name="x"/> to a <see cref="float4"/> and returns the result, where each component is clamped to the interval [<see cref="float.MinValue"/>, <see cref="float.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tofloatsaturated(double4 x)
        {
            return (float4)math.clamp(x, float.MinValue, float.MaxValue);
        }

        /// <summary>       Casts the <see cref="double4"/>s <paramref name="lo"/> and <paramref name="hi"/> to a <see cref="MaxMath.float8"/> and returns the result, where each component is clamped to the interval [<see cref="float.MinValue"/>, <see cref="float.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tofloatsaturated(double4 lo, double4 hi)
        {
            double4 MIN_VALUE = float.MinValue;
            double4 MAX_VALUE = float.MaxValue;

            return new float8((float4)math.clamp(lo, MIN_VALUE, MAX_VALUE), (float4)math.clamp(hi, MIN_VALUE, MAX_VALUE));
        }
        #endregion
    }
}