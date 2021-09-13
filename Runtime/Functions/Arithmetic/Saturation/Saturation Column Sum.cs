using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.byte2"/>, so that the sum is clamped to <see cref="byte.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte csumsaturated(byte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epu8(x, Sse2.bsrli_si128(x, 1 * sizeof(byte))).Byte0;
            }
            else
            {
                return (byte)math.min(byte.MaxValue, csum(x));
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.byte3"/>, so that the sum is clamped to <see cref="byte.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte csumsaturated(byte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 y = Sse2.bsrli_si128(x, 1 * sizeof(byte));
                v128 z = Sse2.bsrli_si128(x, 2 * sizeof(byte));

                return Sse2.adds_epu8(Sse2.adds_epu8(x, y), z).Byte0;
            }
            else
            {
                return (byte)math.min(byte.MaxValue, csum(x));
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.byte4"/>, so that the sum is clamped to <see cref="byte.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte csumsaturated(byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 xz_yw = Sse2.adds_epu8(x, Sse2.bsrli_si128(x, 2 * sizeof(byte)));

                return Sse2.adds_epu8(xz_yw, Sse2.bsrli_si128(xz_yw, 1 * sizeof(byte))).Byte0;
            }
            else
            {
                return (byte)math.min(byte.MaxValue, csum(x));
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.byte8"/>, so that the sum is clamped to <see cref="byte.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte csumsaturated(byte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _1 = Sse2.adds_epu8(x, Sse2.bsrli_si128(x, 4 * sizeof(byte)));
                v128 _2 = Sse2.adds_epu8(_1, Sse2.bsrli_si128(_1, 2 * sizeof(byte)));

                return Sse2.adds_epu8(_2, Sse2.bsrli_si128(_2, 1 * sizeof(byte))).Byte0;
            }
            else
            {
                return (byte)math.min(byte.MaxValue, csum(x));
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.byte16"/>, so that the sum is clamped to <see cref="byte.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte csumsaturated(byte16 x)
        {   
            if (Sse2.IsSse2Supported)
            {
                v128 _1 = Sse2.adds_epu8(x, Sse2.bsrli_si128(x, 8 * sizeof(byte)));
                v128 _2 = Sse2.adds_epu8(_1, Sse2.bsrli_si128(_1, 4 * sizeof(byte)));
                v128 _3 = Sse2.adds_epu8(_2, Sse2.bsrli_si128(_2, 2 * sizeof(byte)));

                return Sse2.adds_epu8(_3, Sse2.bsrli_si128(_3, 1 * sizeof(byte))).Byte0;
            }
            else
            {
                return (byte)math.min(byte.MaxValue, csum(x));
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.byte32"/>, so that the sum is clamped to <see cref="byte.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte csumsaturated(byte32 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 lohi = Sse2.adds_epu8(x.v16_0, x.v16_16);

                v128 _1 = Sse2.adds_epu8(lohi, Sse2.bsrli_si128(lohi, 8 * sizeof(byte)));
                v128 _2 = Sse2.adds_epu8(_1, Sse2.bsrli_si128(_1, 4 * sizeof(byte)));
                v128 _3 = Sse2.adds_epu8(_2, Sse2.bsrli_si128(_2, 2 * sizeof(byte)));

                return Sse2.adds_epu8(_3, Sse2.bsrli_si128(_3, 1 * sizeof(byte))).Byte0;
            }
            else
            {
                return (byte)math.min(byte.MaxValue, csum(x));
            }
        }


        /// <summary>       Returns the saturated horizontal sum of components of an <see cref="MaxMath.sbyte2"/>, so that the sum is clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte csumsaturated(sbyte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epi8(x, Sse2.bsrli_si128(x, 1 * sizeof(sbyte))).SByte0;
            }
            else
            {   
                return (sbyte)math.clamp(csum(x), sbyte.MinValue, sbyte.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of an <see cref="MaxMath.sbyte3"/>, so that the sum is clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte csumsaturated(sbyte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 cast = Cast.SByteToShort(x);

                v128 y = Sse2.bsrli_si128(cast, 1 * sizeof(short));
                v128 z = Sse2.bsrli_si128(cast, 2 * sizeof(short));

                v128 sum = Sse2.add_epi16(Sse2.add_epi16(cast, y), z);

                return Sse2.packs_epi16(sum, sum).SByte0;
            }
            else
            {   
                return (sbyte)math.clamp(csum(x), sbyte.MinValue, sbyte.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of an <see cref="MaxMath.sbyte4"/>, so that the sum is clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte csumsaturated(sbyte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 cast = Cast.SByteToShort(x);

                v128 _1 = Sse2.add_epi16(cast, Sse2.shufflelo_epi16(cast, Sse.SHUFFLE(0, 0, 3, 2)));
                v128 _2 = Sse2.add_epi16(_1, Sse2.shufflelo_epi16(_1, Sse.SHUFFLE(0, 0, 0, 1)));

                return Sse2.packs_epi16(_2, _2).SByte0;
            }
            else
            {   
                return (sbyte)math.clamp(csum(x), sbyte.MinValue, sbyte.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of an <see cref="MaxMath.sbyte8"/>, so that the sum is clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte csumsaturated(sbyte8 x)                            
        {       
            if (Sse2.IsSse2Supported)
            {
                v128 cast = Cast.SByteToShort(x);

                v128 _1 = Sse2.add_epi16(cast, Sse2.shuffle_epi32(cast, Sse.SHUFFLE(0, 0, 3, 2)));
                v128 _2 = Sse2.add_epi16(_1, Sse2.shufflelo_epi16(_1, Sse.SHUFFLE(0, 0, 3, 2)));
                v128 _3 = Sse2.add_epi16(_2, Sse2.shufflelo_epi16(_2, Sse.SHUFFLE(0, 0, 0, 1)));

                return Sse2.packs_epi16(_3, _3).SByte0;
            }
            else
            {   
                return (sbyte)math.clamp(csum(x), sbyte.MinValue, sbyte.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of an <see cref="MaxMath.sbyte16"/>, so that the sum is clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte csumsaturated(sbyte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 cast_lo = Cast.SByteToShort(x);
                v128 cast_hi = Cast.SByteToShort(Sse2.bsrli_si128(x, 8 * sizeof(sbyte)));

                v128 _1 = Sse2.add_epi16(cast_lo, cast_hi);
                v128 _2 = Sse2.add_epi16(_1, Sse2.shuffle_epi32(_1, Sse.SHUFFLE(0, 0, 3, 2)));
                v128 _3 = Sse2.add_epi16(_2, Sse2.shufflelo_epi16(_2, Sse.SHUFFLE(0, 0, 3, 2)));
                v128 _4 = Sse2.add_epi16(_3, Sse2.shufflelo_epi16(_3, Sse.SHUFFLE(0, 0, 0, 1)));

                return Sse2.packs_epi16(_4, _4).SByte0;
            }
            else
            {   
                return (sbyte)math.clamp(csum(x), sbyte.MinValue, sbyte.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of an <see cref="MaxMath.sbyte32"/>, so that the sum is clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte csumsaturated(sbyte32 x)
        {
            if (Sse2.IsSse2Supported)
            {
                short16 cast_lohi = (short16)x.v16_0 + (short16)x.v16_16;

                v128 _1 = Sse2.add_epi16(cast_lohi.v8_0, cast_lohi.v8_8);
                v128 _2 = Sse2.add_epi16(_1, Sse2.shuffle_epi32(_1, Sse.SHUFFLE(0, 0, 3, 2)));
                v128 _3 = Sse2.add_epi16(_2, Sse2.shufflelo_epi16(_2, Sse.SHUFFLE(0, 0, 3, 2)));
                v128 _4 = Sse2.add_epi16(_3, Sse2.shufflelo_epi16(_3, Sse.SHUFFLE(0, 0, 0, 1)));

                return Sse2.packs_epi16(_4, _4).SByte0;
            }
            else
            {   
                return (sbyte)math.clamp(csum(x), sbyte.MinValue, sbyte.MaxValue);
            }
        }


        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.short2"/>, so that the sum is clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short csumsaturated(short2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epi16(x, Sse2.bsrli_si128(x, 1 * sizeof(short))).SShort0;
            }
            else
            {   
                return (short)math.clamp(csum(x), short.MinValue, short.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.short3"/>, so that the sum is clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short csumsaturated(short3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 cast = Cast.ShortToInt(x);

                v128 y = Sse2.bsrli_si128(cast, 1 * sizeof(int));
                v128 z = Sse2.bsrli_si128(cast, 2 * sizeof(int));

                v128 sum = Sse2.add_epi32(Sse2.add_epi32(cast, y), z);

                return Sse2.packs_epi32(sum, sum).SShort0;
            }
            else
            {   
                return (short)math.clamp(csum(x), short.MinValue, short.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.short4"/>, so that the sum is clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short csumsaturated(short4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 cast = Cast.ShortToInt(x);

                v128 _1 = Sse2.add_epi32(cast, Sse2.shuffle_epi32(cast, Sse.SHUFFLE(0, 0, 3, 2)));
                v128 _2 = Sse2.add_epi32(_1, Sse2.shuffle_epi32(_1, Sse.SHUFFLE(0, 0, 0, 1)));

                return Sse2.packs_epi32(_2, _2).SShort0;
            }
            else
            {   
                return (short)math.clamp(csum(x), short.MinValue, short.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.short8"/>, so that the sum is clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short csumsaturated(short8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 cast_lo = Cast.ShortToInt(x);
                v128 cast_hi = Cast.ShortToInt(Sse2.bsrli_si128(x, 4 * sizeof(short)));

                v128 _1 = Sse2.add_epi32(cast_lo, cast_hi);
                v128 _2 = Sse2.add_epi32(_1, Sse2.shuffle_epi32(_1, Sse.SHUFFLE(0, 0, 3, 2)));
                v128 _3 = Sse2.add_epi32(_2, Sse2.shuffle_epi32(_2, Sse.SHUFFLE(0, 0, 0, 1)));

                return Sse2.packs_epi32(_3, _3).SShort0;
            }
            else
            {   
                return (short)math.clamp(csum(x), short.MinValue, short.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.short16"/>, so that the sum is clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short csumsaturated(short16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                int8 cast_lohi = (int8)x.v8_0 + (int8)x.v8_8;

                int4 __1 = cast_lohi.v4_0 + cast_lohi.v4_4;
                v128 _1 = UnityMathematicsLink.Tov128(__1);
                v128 _2 = Sse2.add_epi32(_1, Sse2.shuffle_epi32(_1, Sse.SHUFFLE(0, 0, 3, 2)));
                v128 _3 = Sse2.add_epi32(_2, Sse2.shuffle_epi32(_2, Sse.SHUFFLE(0, 0, 0, 1)));

                return Sse2.packs_epi32(_3, _3).SShort0;
            }
            else
            {   
                return (short)math.clamp(csum(x), short.MinValue, short.MaxValue);
            }
        }


        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.ushort2"/>, so that the sum is clamped to <see cref="ushort.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort csumsaturated(ushort2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epu16(x, Sse2.bsrli_si128(x, 1 * sizeof(ushort))).UShort0;
            }
            else
            {   
                return (ushort)math.min(csum(x), ushort.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.ushort3"/>, so that the sum is clamped to <see cref="ushort.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort csumsaturated(ushort3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 y = Sse2.bsrli_si128(x, 1 * sizeof(ushort));
                v128 z = Sse2.bsrli_si128(x, 2 * sizeof(ushort));

                return Sse2.adds_epu16(Sse2.adds_epu16(x, y), z).UShort0;
            }
            else
            {   
                return (ushort)math.min(csum(x), ushort.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.ushort4"/>, so that the sum is clamped to <see cref="ushort.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort csumsaturated(ushort4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 xz_yw = Sse2.adds_epu16(x, Sse2.bsrli_si128(x, 2 * sizeof(ushort)));

                return Sse2.adds_epu16(xz_yw, Sse2.bsrli_si128(xz_yw, 1 * sizeof(short))).UShort0;
            }
            else
            {   
                return (ushort)math.min(csum(x), ushort.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.ushort8"/>, so that the sum is clamped to <see cref="ushort.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort csumsaturated(ushort8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _1 = Sse2.adds_epu16(x, Sse2.bsrli_si128(x, 4 * sizeof(ushort)));
                v128 _2 = Sse2.adds_epu16(_1, Sse2.bsrli_si128(_1, 2 * sizeof(ushort)));

                return Sse2.adds_epu16(_2, Sse2.bsrli_si128(_2, 1 * sizeof(ushort))).UShort0;
            }
            else
            {   
                return (ushort)math.min(csum(x), ushort.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.ushort16"/>, so that the sum is clamped to <see cref="ushort.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort csumsaturated(ushort16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 lohi = Sse2.adds_epu16(x.v8_0, x.v8_8);
                v128 _1 = Sse2.adds_epu16(lohi, Sse2.bsrli_si128(lohi, 4 * sizeof(ushort)));
                v128 _2 = Sse2.adds_epu16(_1, Sse2.bsrli_si128(_1, 2 * sizeof(ushort)));

                return Sse2.adds_epu16(_2, Sse2.bsrli_si128(_2, 1 * sizeof(ushort))).UShort0;
            }
            else
            {   
                return (ushort)math.min(csum(x), ushort.MaxValue);
            }
        }


        /// <summary>       Returns the saturated horizontal sum of components of an <see cref="int2"/>, so that the sum is clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csumsaturated(int2 x)
        {
            return (int)math.clamp((long)x.x + (long)x.y, int.MinValue, int.MaxValue);
        }

        /// <summary>       Returns the saturated horizontal sum of components of an <see cref="int3"/>, so that the sum is clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csumsaturated(int3 x)
        {
            return (int)math.clamp(csum((long3)x), int.MinValue, int.MaxValue);
        }

        /// <summary>       Returns the saturated horizontal sum of components of an <see cref="int4"/>, so that the sum is clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csumsaturated(int4 x)
        {
            return (int)math.clamp(csum((long4)x), int.MinValue, int.MaxValue);
        }

        /// <summary>       Returns the saturated horizontal sum of components of an <see cref="MaxMath.int8"/>, so that the sum is clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csumsaturated(int8 x)
        {
            return (int)math.clamp(csum((long4)x.v4_0 + (long4)x.v4_4), int.MinValue, int.MaxValue);
        }


        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="uint2"/>, so that the sum is clamped to <see cref="uint.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csumsaturated(uint2 x)
        {
            return (uint)math.min((ulong)x.x + (ulong)x.y, uint.MaxValue);
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="uint3"/>, so that the sum is clamped to <see cref="uint.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csumsaturated(uint3 x)
        {
            return (uint)math.min(csum((ulong3)x), uint.MaxValue);
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="uint4"/>, so that the sum is clamped to <see cref="uint.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csumsaturated(uint4 x)
        {
            return (uint)math.min(csum((ulong4)x), uint.MaxValue);
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.uint8"/>, so that the sum is clamped to <see cref="uint.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csumsaturated(uint8 x)
        {
            return (uint)math.min(csum((ulong4)x.v4_0 + (ulong4)x.v4_4), uint.MaxValue);
        }


        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.long2"/>, so that the sum is clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long csumsaturated(long2 x)
        {
            return addsaturated(x.x, x.y);
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.long3"/>, so that the sum is clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long csumsaturated(long3 x)
        {
            Int128 sum = x.x;
            
            sum += x.y;
            sum += x.z;

            return (long)clamp(sum, long.MinValue, long.MaxValue);
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.long4"/>, so that the sum is clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long csumsaturated(long4 x)
        {
            return (long)clamp(((Int128)x.x + x.y) + ((Int128)x.z + x.w), long.MinValue, long.MaxValue);
        }


        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.ulong2"/>, so that the sum is clamped to <see cref="ulong.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong csumsaturated(ulong2 x)
        {
            return addsaturated(x.x, x.y);
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.ulong3"/>, so that the sum is clamped to <see cref="ulong.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong csumsaturated(ulong3 x)
        {
            return addsaturated(addsaturated(x.x, x.z), x.y);
        }

        /// <summary>       Returns the saturated horizontal sum of components of a <see cref="MaxMath.ulong4"/>, so that the sum is clamped to <see cref="ulong.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong csumsaturated(ulong4 x)
        {
            return addsaturated(addsaturated(x.x, x.y), addsaturated(x.z, x.w));
        }


        /// <summary>       Returns the saturated horizontal sum of components ofa<see cref="float2"/>, so that the sum is clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float csumsaturated(float2 x)
        {
            return addsaturated(x.x, x.y);
        }

        /// <summary>       Returns the saturated horizontal sum of components ofa<see cref="float3"/>, so that the sum is clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float csumsaturated(float3 x)
        {
            return addsaturated(addsaturated(x.x, x.y), x.z);
        }

        /// <summary>       Returns the saturated horizontal sum of components ofa<see cref="float4"/>, so that the sum is clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float csumsaturated(float4 x)
        {
            double2 _0 = (double2)x.xy + (double2)x.zw;

            return (float)math.clamp(_0.x * _0.y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Returns the saturated horizontal sum of components ofa<see cref="MaxMath.float8"/>, so that the sum is clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float csumsaturated(float8 x)
        {
            double4 _0 = (double4)x.v4_0 + (double4)x.v4_4;
            double2 _1 = _0.xy + _0.zw;

            return (float)math.clamp(_1.x * _1.y, float.MinValue, float.MaxValue);
        }


        //// <summary>       Returns the saturated horizontal sum of components ofa<see cref="double2"/>, so that the sum is clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double csumsaturated(double2 x)
        {
            return addsaturated(x.x, x.y);
        }

        /// <summary>       Returns the saturated horizontal sum of components ofa<see cref="double3"/>, so that the sum is clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double csumsaturated(double3 x)
        {
            return addsaturated(addsaturated(x.x, x.y), x.z);
        }

        /// <summary>       Returns the saturated horizontal sum of components ofa<see cref="double4"/>, so that the sum is clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double csumsaturated(double4 x)
        {
            return addsaturated(addsaturated(x.x, x.y), addsaturated(x.z, x.w));
        }
    }
}