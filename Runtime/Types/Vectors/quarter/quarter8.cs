using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Sequential, Size = 8)]
    unsafe public struct quarter8 : IEquatable<quarter8>, IFormattable
    {
        [NoAlias] public quarter x0;
        [NoAlias] public quarter x1;
        [NoAlias] public quarter x2;
        [NoAlias] public quarter x3;
        [NoAlias] public quarter x4;
        [NoAlias] public quarter x5;
        [NoAlias] public quarter x6;
        [NoAlias] public quarter x7;


        public static quarter8 zero => default(quarter8);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter x0, quarter x1, quarter x2, quarter x3, quarter x4, quarter x5, quarter x6, quarter x7)
        {
            this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, (sbyte)x7.value, (sbyte)x6.value, (sbyte)x5.value, (sbyte)x4.value, (sbyte)x3.value, (sbyte)x2.value, (sbyte)x1.value, (sbyte)x0.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter x0x8)
        {
            this = Sse2.set1_epi8((sbyte)x0x8.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter2 x01, quarter2 x23, quarter2 x45, quarter2 x67)
        {
            this = new quarter8(new quarter4(x01, x23), new quarter4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter2 x01, quarter3 x234, quarter3 x567)
        {
            this = new quarter8((quarter4)Sse2.unpacklo_epi16(x01, x234),
                                (quarter4)Sse4_1.insert_epi8(Sse2.bslli_si128(x567, sizeof(quarter)), x234.z.value, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter3 x012, quarter2 x34, quarter3 x567)
        {
            this = new quarter8((quarter4)Sse4_1.insert_epi8(x012, x34.x.value, 3),
                                (quarter4)Sse4_1.insert_epi8(Sse2.bslli_si128(x567, sizeof(quarter)), x34.y.value, 0));
        }   

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter3 x012, quarter3 x345, quarter2 x67)
        {
            this = new quarter8((quarter4)Sse4_1.insert_epi8(x012, x345.x.value, 3),
                                (quarter4)Sse2.unpacklo_epi16(Sse2.bsrli_si128(x345, sizeof(quarter)), x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter4 x0123, quarter2 x45, quarter2 x67)
        {
            this = new quarter8(x0123, new quarter4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter2 x01, quarter4 x2345, quarter2 x67)
        {
            this = new quarter8((quarter4)Sse2.unpacklo_epi16(x01, x2345),
                                (quarter4)Sse2.unpacklo_epi16(Sse2.bsrli_si128(x2345, 2 * sizeof(quarter)), x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter2 x01, quarter2 x23, quarter4 x4567)
        {
            this = new quarter8(new quarter4(x01, x23), x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter4 x0123, quarter4 x4567)
        {
            this = Sse2.unpacklo_epi32(x0123, x4567);
        }


        public quarter4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v4_0); set { byte8 t = maxmath.asbyte(this); t.v4_0 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }
        public quarter4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v4_1); set { byte8 t = maxmath.asbyte(this); t.v4_1 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }
        public quarter4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v4_2); set { byte8 t = maxmath.asbyte(this); t.v4_2 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }
        public quarter4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v4_3); set { byte8 t = maxmath.asbyte(this); t.v4_3 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }
        public quarter4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v4_4); set { byte8 t = maxmath.asbyte(this); t.v4_4 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }

        public quarter3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v3_0); set { byte8 t = maxmath.asbyte(this); t.v3_0 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }
        public quarter3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v3_1); set { byte8 t = maxmath.asbyte(this); t.v3_1 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }
        public quarter3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v3_2); set { byte8 t = maxmath.asbyte(this); t.v3_2 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }
        public quarter3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v3_3); set { byte8 t = maxmath.asbyte(this); t.v3_3 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }
        public quarter3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v3_4); set { byte8 t = maxmath.asbyte(this); t.v3_4 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }
        public quarter3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v3_5); set { byte8 t = maxmath.asbyte(this); t.v3_5 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }

        public quarter2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v2_0); set { byte8 t = maxmath.asbyte(this); t.v2_0 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }
        public quarter2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v2_1); set { byte8 t = maxmath.asbyte(this); t.v2_1 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }
        public quarter2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v2_2); set { byte8 t = maxmath.asbyte(this); t.v2_2 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }
        public quarter2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v2_3); set { byte8 t = maxmath.asbyte(this); t.v2_3 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }
        public quarter2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v2_4); set { byte8 t = maxmath.asbyte(this); t.v2_4 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }
        public quarter2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v2_5); set { byte8 t = maxmath.asbyte(this); t.v2_5 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }
        public quarter2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v2_6); set { byte8 t = maxmath.asbyte(this); t.v2_6 = maxmath.asbyte(value); this = maxmath.asquarter(t); } }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(quarter8 input) => new v128(*(long*)&input, 0L);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter8(v128 input) { long x = input.SLong0; return *(quarter8*)&x; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter8(quarter input) => new quarter8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(byte8 input)
        {
            v128 overflowMask = Sse2.cmpgt_epi8(input, new byte8(15));


            float8 f = input;

            int8 f32 = maxmath.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
            f32 >>= 19;

            v128 notZeroMask = Sse2.andnot_si128(Sse2.cmpeq_epi8(input, default(v128)), new v128(-1));

            byte8 infinity = quarter.PositiveInfinity.value;
            byte8 regular = notZeroMask & (byte8)f32;

            return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(sbyte8 input)
        {
            sbyte8 sign = input & (sbyte)-0b1000_0000;
            sbyte8 abs = maxmath.abs(input);
            v128 overflowMask = Sse2.cmpgt_epi8(abs, new sbyte8(15));


            float8 f = abs;

            int8 f32 = maxmath.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
            f32 >>= 19;

            v128 notZeroMask = Sse2.andnot_si128(Sse2.cmpeq_epi8(abs, default(v128)), new v128(-1));

            sbyte8 infinity = sign | (sbyte)quarter.PositiveInfinity.value;
            sbyte8 regular = sign | (notZeroMask & (sbyte8)f32);

            return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(ushort8 input)
        {
            v128 overflowMask = (sbyte8)(ushort8)Sse2.cmpgt_epi16(input, new ushort4(15));


            float8 f = input;

            int8 f32 = maxmath.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
            f32 >>= 19;

            v128 notZeroMask = (sbyte8)(ushort8)Sse2.andnot_si128(Sse2.cmpeq_epi16(input, default(v128)), new v128(-1));

            byte8 infinity = quarter.PositiveInfinity.value;
            byte8 regular = notZeroMask & (byte8)f32;

            return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(short8 input)
        {
            sbyte8 sign = (sbyte8)((ushort8)input >> 15) << 7;
            short8 abs = maxmath.abs(input);
            v128 overflowMask = (sbyte8)(short8)Sse2.cmpgt_epi16(abs, new short4(15));


            float8 f = abs;

            int8 f32 = maxmath.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
            f32 >>= 19;

            v128 notZeroMask = (sbyte8)(short8)Sse2.andnot_si128(Sse2.cmpeq_epi16(abs, default(v128)), new v128(-1));

            sbyte8 infinity = sign | (sbyte)quarter.PositiveInfinity.value;
            sbyte8 regular = sign | (notZeroMask & (sbyte8)f32);

            return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(uint8 input)
        {
            v128 overflowMask = Cast.Int8ToByte8(Avx2.mm256_cmpgt_epi32(input, new v256(15)));


            float8 f = input;

            int8 f32 = maxmath.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
            f32 >>= 19;

            v128 notZeroMask = Cast.Int8ToByte8(Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(input, default(v256)), new v256(-1)));

            byte8 infinity = quarter.PositiveInfinity.value;
            byte8 regular = notZeroMask & (byte8)f32;

            return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(int8 input)
        {
            sbyte8 sign = (sbyte8)((uint8)input >> 31) << 7;
            int8 abs = maxmath.abs(input);
            v128 overflowMask = Cast.Int8ToByte8(Avx2.mm256_cmpgt_epi32(abs, new v256(15)));


            float8 f = abs;

            int8 f32 = maxmath.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
            f32 >>= 19;

            v128 notZeroMask = Cast.Int8ToByte8(Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(abs, default(v256)), new v256(-1)));

            sbyte8 infinity = sign | (sbyte)quarter.PositiveInfinity.value;
            sbyte8 regular = sign | (notZeroMask & (sbyte8)f32);

            return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(half8 input)
        {
            byte8 f8_sign      = (byte8)((maxmath.asushort(input) >> 15) << 7);
            uint8 f16_exponent = (maxmath.asushort(input) >> 10) & 0x001F;


            uint8 f16_mantissa = maxmath.asushort(input) & 0x03FF;

            int8 cmp = 13 - (int8)f16_exponent;
            v256 cmpIsZeroOrNegativeMask = Avx2.mm256_cmpgt_epi32(new v256(1), cmp);

            int8 denormalShift = maxmath.shrl((int8)0b0001_0000, cmp);
            v256 denormalExponent = Avx2.mm256_andnot_si256(cmpIsZeroOrNegativeMask, denormalShift);
            denormalExponent = Avx2.mm256_add_epi32(denormalExponent,
                                                    Avx2.mm256_and_si256(new v256(1),
                                                                         Avx2.mm256_and_si256(Avx2.mm256_cmpeq_epi32(f16_exponent, new v256(9)),
                                                                                              Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi32(new v256(0x0200), 
                                                                                                                                             f16_mantissa), 
                                                                                                                            new v256(-1)))));

            v256 mantissaIfSmallerEpsilon = Avx2.mm256_and_si256(new v256(1),
                                                                 Avx2.mm256_and_si256(Avx2.mm256_cmpeq_epi32(f16_exponent, new v256(8)),
                                                                                      Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(f16_mantissa, default(v256)),  new v256(-1))));

            int8 normalExponent = ((int8)cmpIsZeroOrNegativeMask & ((int8)f16_exponent - (15 + quarter.EXPONENT_BIAS))) << quarter.MANTISSA_BITS;

            int8 mantissaShift = 6 + maxmath.andnot(cmp, (int8)cmpIsZeroOrNegativeMask);


            v256 exponentMantissa = Avx2.mm256_or_si256(Avx2.mm256_or_si256(normalExponent, denormalExponent),
                                                        Avx2.mm256_or_si256(mantissaIfSmallerEpsilon, Avx2.mm256_srlv_epi32(f16_mantissa, mantissaShift)));

            v256 infNanexponentMantissa = Avx2.mm256_or_si256(new v256((int)quarter.PositiveInfinity.value),
                                                              Avx2.mm256_and_si256(new v256(1),
                                                                                   Avx2.mm256_cmpgt_epi32(Avx2.mm256_and_si256((int8)(maxmath.asushort(input)), new v256(maxmath.bitmask32(15))),
                                                                                                          new v256(0x7C00))));

            v256 underflowMask = Avx2.mm256_cmpgt_epi32(new v256(8), f16_exponent);
            v256 overflowMask = Avx2.mm256_cmpgt_epi32(f16_exponent, new v256(18));

            exponentMantissa = Avx2.mm256_blendv_epi8(exponentMantissa, default(v256), underflowMask);
            exponentMantissa = Avx2.mm256_blendv_epi8(exponentMantissa, infNanexponentMantissa, overflowMask);
            
            return maxmath.asquarter(f8_sign | Cast.Int8ToByte8(exponentMantissa));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(float8 input)
        {
            byte8 f8_sign      = (byte8)((maxmath.asuint(input) >> 31) << 7);
            uint8 f32_exponent = (maxmath.asuint(input) >> 23) & 0x00FF;


            uint8 f32_mantissa = maxmath.asuint(input) & 0x007F_FFFFu;

            int8 cmp = 125 - (int8)f32_exponent;
            v256 cmpIsZeroOrNegativeMask = Avx2.mm256_cmpgt_epi32(new v256(1), cmp);

            int8 denormalShift = maxmath.shrl((int8)0b0001_0000, cmp);
            v256 denormalExponent = Avx2.mm256_andnot_si256(cmpIsZeroOrNegativeMask, denormalShift);
            denormalExponent = Avx2.mm256_add_epi32(denormalExponent,
                                                    Avx2.mm256_and_si256(new v256(1),
                                                                         Avx2.mm256_and_si256(Avx2.mm256_cmpeq_epi32(f32_exponent, new v256(121)),
                                                                                              Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi32(new v256(0x0040_0000), 
                                                                                                                                             f32_mantissa), 
                                                                                                                            new v256(-1)))));

            v256 mantissaIfSmallerEpsilon = Avx2.mm256_and_si256(new v256(1),
                                                                 Avx2.mm256_and_si256(Avx2.mm256_cmpeq_epi32(f32_exponent, new v256(120)),
                                                                                      Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(f32_mantissa, default(v256)),  new v256(-1))));

            int8 normalExponent = ((int8)cmpIsZeroOrNegativeMask & ((int8)f32_exponent - (127 + quarter.EXPONENT_BIAS))) << quarter.MANTISSA_BITS;

            int8 mantissaShift = 19 + maxmath.andnot(cmp, (int8)cmpIsZeroOrNegativeMask);


            v256 exponentMantissa = Avx2.mm256_or_si256(Avx2.mm256_or_si256(normalExponent, denormalExponent),
                                                        Avx2.mm256_or_si256(mantissaIfSmallerEpsilon, Avx2.mm256_srlv_epi32(f32_mantissa, mantissaShift)));

            v256 infNanexponentMantissa = Avx2.mm256_or_si256(new v256((int)quarter.PositiveInfinity.value),
                                                              Avx2.mm256_and_si256(new v256(1),
                                                                                   Avx2.mm256_cmpgt_epi32(Avx.mm256_and_ps(input, new v256(maxmath.bitmask32(31))),
                                                                                                          new v256(0x7F80_0000))));

            v256 underflowMask = Avx2.mm256_cmpgt_epi32(new v256(120), f32_exponent);
            v256 overflowMask = Avx2.mm256_cmpgt_epi32(f32_exponent, new v256(130));

            exponentMantissa = Avx2.mm256_blendv_epi8(exponentMantissa, default(v256), underflowMask);
            exponentMantissa = Avx2.mm256_blendv_epi8(exponentMantissa, infNanexponentMantissa, overflowMask);
            
            return maxmath.asquarter(f8_sign | Cast.Int8ToByte8(exponentMantissa));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(quarter8 input) => (byte8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte8(quarter8 input) => (sbyte8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(quarter8 input) => (ushort8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short8(quarter8 input) => (short8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(quarter8 input) => (uint8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(quarter8 input) => (int8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(quarter8 input) => (half8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(quarter8 input)
        {
            uint8 widen = maxmath.asbyte(input);

            uint8 signMask = 0b1000_0000;
            uint8 sign = (widen & signMask) << 24;
            uint8 fusedExponentMantissa = maxmath.andnot(widen, signMask) << (23 - quarter.MANTISSA_BITS);
                
            v256 isNanOrInfinity = Avx2.mm256_cmpeq_epi32((widen & 0b0111_0000), (uint8)0b0111_0000);
            uint8 nanInfinityOrZeroExponent = Avx2.mm256_blendv_epi8(default(v256), (uint8)(255u << 23), isNanOrInfinity);
            float8 magic = Avx2.mm256_blendv_epi8(new v256((255 - 1 + quarter.EXPONENT_BIAS) << 23), new v256(1f), isNanOrInfinity);

            return magic * maxmath.asfloat(sign | nanInfinityOrZeroExponent | fusedExponentMantissa);
        }


        public quarter this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 8);
                
                fixed (void* ptr = &this)
                {
                    return ((quarter*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                fixed (void* ptr = &this)
                {
                    ((quarter*)ptr)[index] = value;
                }
            }
        }
    

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter8 left, quarter8 right)
        {
            v128 maskedLeft  = Sse2.and_si128(left,  new byte8(0b0111_1111));
            v128 maskedRight = Sse2.and_si128(right, new byte8(0b0111_1111));


            v128 nan = Sse2.and_si128(Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedLeft,  new byte8(0b0111_0000)), new v128(-1)),
                                      Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedRight, new byte8(0b0111_0000)), new v128(-1)));

            v128 zero = Sse2.and_si128(Sse2.cmpeq_epi8(default(v128), maskedLeft),
                                       Sse2.cmpeq_epi8(default(v128), maskedRight));

            v128 value = Sse2.cmpeq_epi8(left, right);


            return Sse2.and_si128(new byte8(1), Sse2.and_si128(nan, Sse2.or_si128(zero, value)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter8 left, quarter8 right)
        {
            v128 maskedLeft  = Sse2.and_si128(left,  new byte8(0b0111_1111));
            v128 maskedRight = Sse2.and_si128(right, new byte8(0b0111_1111));


            v128 nan = Sse2.or_si128(Sse2.cmpgt_epi8(maskedLeft,  new byte8(0b0111_0000)),
                                     Sse2.cmpgt_epi8(maskedRight, new byte8(0b0111_0000)));

            v128 zero = Sse2.or_si128(Sse2.andnot_si128(Sse2.cmpeq_epi8(default(v128), maskedLeft),  new v128(-1)),
                                      Sse2.andnot_si128(Sse2.cmpeq_epi8(default(v128), maskedRight), new v128(-1)));

            v128 value = Sse2.andnot_si128(Sse2.cmpeq_epi8(left, right), new v128(-1));


            return Sse2.and_si128(new byte8(1), Sse2.or_si128(nan, Sse2.and_si128(zero, value)));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(quarter8 other)
        {
            v128 maskedLeft  = Sse2.and_si128(this,  new byte8(0b0111_1111));
            v128 maskedRight = Sse2.and_si128(other, new byte8(0b0111_1111));


            v128 nan = Sse2.and_si128(Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedLeft,  new byte8(0b0111_0000)), new v128(-1)),
                                      Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedRight, new byte8(0b0111_0000)), new v128(-1)));

            v128 zero = Sse2.and_si128(Sse2.cmpeq_epi8(default(v128), maskedLeft),
                                       Sse2.cmpeq_epi8(default(v128), maskedRight));

            v128 value = Sse2.cmpeq_epi8(this, other);


            v128 result = Sse2.and_si128(nan, Sse2.or_si128(zero, value));

            return result.ULong0 == ulong.MaxValue;
        }

        public override bool Equals(object obj) => Equals((quarter8)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v64(this);


        public override string ToString() => $"quarter8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public string ToString(string format, IFormatProvider formatProvider) => $"quarter8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}