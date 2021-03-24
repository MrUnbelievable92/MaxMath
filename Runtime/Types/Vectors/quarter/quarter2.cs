using DevTools;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 2 * sizeof(byte))]  [DebuggerTypeProxy(typeof(quarter2.DebuggerProxy))]
    unsafe public struct quarter2 : IEquatable<quarter2>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public quarter x;
            public quarter y;

            public DebuggerProxy(quarter2 v)
            {
                x = v.x;
                y = v.y;
            }
        }


        [FieldOffset(0)] private fixed byte asArray[2];

        [FieldOffset(0)] public quarter x;
        [FieldOffset(1)] public quarter y;


        public static quarter2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(quarter x, quarter y)
        {
            this = maxmath.asquarter(new byte2(x.value, y.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(quarter xy)
        {
            this = maxmath.asquarter(new byte2(xy.value));
        }


        #region Shuffle
        public quarter4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxxx); }
        public quarter4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxxx); }
        public quarter4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyxx); }
        public quarter4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxyx); }
        public quarter4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxxy); }
        public quarter4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyxx); }
        public quarter4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxyx); }
        public quarter4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxxy); }
        public quarter4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyyx); }
        public quarter4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyxy); }
        public quarter4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxyy); }
        public quarter4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyyx); }
        public quarter4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyxy); }
        public quarter4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxyy); }
        public quarter4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyyy); }
        public quarter4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyyy); }
        
        public quarter3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxx); }
        public quarter3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxx); }
        public quarter3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyx); }
        public quarter3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxy); }
        public quarter3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyx); }
        public quarter3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxy); }
        public quarter3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyy); }
        public quarter3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyy); }

        public quarter2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xx); }
        public          quarter2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yx; }
        public quarter2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yy); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(quarter2 input) => maxmath.asbyte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter2(v128 input) => maxmath.asquarter((byte2)input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter2(quarter input) => new quarter2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(sbyte2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte2 sign = input & (sbyte)-0b1000_0000;
                sbyte2 abs = maxmath.abs(input);
                v128 overflowMask = Sse2.cmpgt_epi8(abs, new sbyte2(15));


                float2 f = abs;

                int2 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = Sse2.cmpeq_epi8(abs, default(v128));

                sbyte2 infinity = (sbyte)quarter.PositiveInfinity.value;
                sbyte2 regular = Sse2.andnot_si128(notZeroMask, (sbyte2)f32);

                return (v128)(sign | Mask.BlendV(regular, infinity, overflowMask));
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(byte2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 overflowMask = Sse2.cmpgt_epi8(input, new byte2(15));


                float2 f = input;

                int2 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = Sse2.cmpeq_epi8(input, default(v128));

                byte2 infinity = quarter.PositiveInfinity.value;
                byte2 regular = Sse2.andnot_si128(notZeroMask, (byte2)f32);

                return Mask.BlendV(regular, infinity, overflowMask);
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(short2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte2 sign = (sbyte2)((ushort2)input >> 15) << 7;
                short2 abs = maxmath.abs(input);
                v128 overflowMask = (sbyte2)(short2)Sse2.cmpgt_epi16(abs, new short2(15));


                float2 f = abs;

                int2 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                int2 cast = abs;
                v128 notZeroMask = Sse2.cmpeq_epi32(*(v128*)&cast, default(v128));

                sbyte2 infinity = (sbyte)quarter.PositiveInfinity.value;
                v128 masked = Sse2.andnot_si128(notZeroMask, *(v128*)&f32);
                sbyte2 regular = (sbyte2)(*(int2*)&masked);

                return (v128)(sign | Mask.BlendV(regular, infinity, overflowMask));
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(ushort2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 overflowMask = (sbyte2)(ushort2)Sse2.cmpgt_epi16(input, new ushort2(15));


                float2 f = input;

                int2 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                int2 cast = input;
                v128 notZeroMask = Sse2.cmpeq_epi32(*(v128*)&cast, default(v128));

                byte2 infinity = quarter.PositiveInfinity.value;
                v128 masked = Sse2.andnot_si128(notZeroMask, *(v128*)&f32);
                byte2 regular = (byte2)(*(int2*)&masked);

                return Mask.BlendV(regular, infinity, overflowMask);
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(int2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte2 sign = (sbyte2)((uint2)input >> 31) << 7;
                int2 abs = math.abs(input);
                v128 overflowMask = Sse2.cmpgt_epi32(*(v128*)&abs, new v128(15, 15, 0, 0));
                overflowMask = (sbyte2)(*(int2*)&overflowMask);


                float2 f = abs;

                int2 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = Sse2.cmpeq_epi32(*(v128*)&abs, default(v128));

                sbyte2 infinity = (sbyte)quarter.PositiveInfinity.value;
                v128 masked = Sse2.andnot_si128(notZeroMask, *(v128*)&f32);
                sbyte2 regular = (sbyte2)(*(int2*)&masked);

                return (v128)(sign | Mask.BlendV(regular, infinity, overflowMask));
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(uint2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 overflowMask = Sse2.cmpgt_epi32(*(v128*)&input, new v128(15, 15, 0, 0));
                overflowMask = (sbyte2)(*(int2*)&overflowMask);


                float2 f = input;

                int2 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = Sse2.cmpeq_epi32(*(v128*)&input, default(v128));

                byte2 infinity = quarter.PositiveInfinity.value;
                v128 masked = Sse2.andnot_si128(notZeroMask, *(v128*)&f32);
                byte2 regular = (byte2)(*(int2*)&masked);

                return Mask.BlendV(regular, infinity, overflowMask);
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(long2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte2 sign = (sbyte2)((ulong2)input >> 63) << 7;
                long2 abs = maxmath.abs(input);
                v128 overflowMask = (sbyte2)(long2)Operator.greater_mask_long(abs, new long2(15));


                v128 castToInt = Cast.Long2ToInt2(abs);
                float2 f = *(int2*)&castToInt;

                int2 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = Sse2.cmpeq_epi32(castToInt, default(v128));

                sbyte2 infinity = (sbyte)quarter.PositiveInfinity.value;
                sbyte2 regular = Cast.Int4ToByte4(Sse2.andnot_si128(notZeroMask, *(v128*)&f32));

                return (v128)(sign | Mask.BlendV(regular, infinity, overflowMask));
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(ulong2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 overflowMask = (sbyte2)(ulong2)Operator.greater_mask_long(input, new ulong2(15));


                v128 castToInt = Cast.Long2ToInt2(input);
                float2 f = *(int2*)&castToInt;

                int2 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = Sse2.cmpeq_epi32(castToInt, default(v128));

                byte2 infinity = quarter.PositiveInfinity.value;
                byte2 regular = Cast.Int4ToByte4(Sse2.andnot_si128(notZeroMask, *(v128*)&f32));

                return Mask.BlendV(regular, infinity, overflowMask);
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(half2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                byte2 f8_sign = (byte2)((maxmath.asushort(input) >> 15) << 7);
                uint2 f16_exponent = (maxmath.asushort(input) << 1) >> 11;


                uint2 f16_mantissa = (maxmath.asushort(input) << 6) >> 6;

                int2 cmp = 13 - (int2)f16_exponent;
                v128 cmpIsZeroOrNegativeMask = Sse2.cmpgt_epi32(new v128(1L | (1L << 32), 0L), *(v128*)&cmp);

                int2 denormalShift = maxmath.shrl((int2)0b0001_0000, cmp);
                v128 denormalExponent = Sse2.andnot_si128(cmpIsZeroOrNegativeMask, *(v128*)&denormalShift);
                denormalExponent = Sse2.add_epi32(denormalExponent,
                                                  Sse2.and_si128(new v128(1L | (1L << 32), 0L),
                                                                 Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f16_exponent, new v128(9L | (9L << 32), 0L)),
                                                                                Sse2.andnot_si128(Sse2.cmpgt_epi32(new v128(0x0200L | (0x0200L << 32), 0L),
                                                                                                                   *(v128*)&f16_mantissa),
                                                                                                  new v128(-1L, 0L)))));

                v128 mantissaIfSmallerEpsilon = Sse2.and_si128(new v128(1L | (1L << 32), 0L),
                                                               Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f16_exponent, new v128(8L | (8L << 32), 0L)),
                                                                              Sse2.andnot_si128(Sse2.cmpeq_epi32(*(v128*)&f16_mantissa, default(v128)), new v128(-1L, 0L))));

                int2 normalExponent = (*(int2*)&cmpIsZeroOrNegativeMask & ((int2)f16_exponent - (15 + quarter.EXPONENT_BIAS))) << quarter.MANTISSA_BITS;

                int2 mantissaShift = 6 + maxmath.andnot(cmp, *(int2*)&cmpIsZeroOrNegativeMask);
                uint2 shifted = maxmath.shrl(f16_mantissa, mantissaShift);

                v128 exponentMantissa = Sse2.or_si128(Sse2.or_si128(*(v128*)&normalExponent, denormalExponent),
                                                      Sse2.or_si128(mantissaIfSmallerEpsilon, *(v128*)&shifted));

                v128 infNanexponentMantissa = Sse2.or_si128(new v128((long)quarter.PositiveInfinity.value | ((long)quarter.PositiveInfinity.value << 32), 0L),
                                                            Sse2.and_si128(new v128(1L | (1L << 32), 0L),
                                                                           Sse2.cmpgt_epi32(Sse2.and_si128(Cast.UShortToInt(maxmath.asushort(input)), new v128((long)maxmath.bitmask32(15) | ((long)maxmath.bitmask32(15) << 32), 0L)),
                                                                                            new v128(0x7C00L | (0x7C00L << 32), 0L))));

                v128 underflowMask = Sse2.cmpgt_epi32(new v128(8L | (8L << 32), 0L), *(v128*)&f16_exponent);
                v128 overflowMask = Sse2.cmpgt_epi32(*(v128*)&f16_exponent, new v128(18L | (18L << 32), 0L));

                exponentMantissa = Mask.BlendV(exponentMantissa, default(v128), underflowMask);
                exponentMantissa = Mask.BlendV(exponentMantissa, *(v128*)&infNanexponentMantissa, overflowMask);

                return maxmath.asquarter(f8_sign | (byte2)(*(uint2*)&exponentMantissa));
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(float2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                byte2 f8_sign = (byte2)((math.asuint(input) >> 31) << 7);
                uint2 f32_exponent = (math.asuint(input) << 1) >> 24;


                uint2 f32_mantissa = (math.asuint(input) << 9) >> 9;

                int2 cmp = 125 - (int2)f32_exponent;
                v128 cmpIsZeroOrNegativeMask = Sse2.cmpgt_epi32(new v128(1L | (1L << 32), 0L), *(v128*)&cmp);

                int2 denormalShift = maxmath.shrl((int2)0b0001_0000, cmp);
                v128 denormalExponent = Sse2.andnot_si128(cmpIsZeroOrNegativeMask, *(v128*)&denormalShift);
                denormalExponent = Sse2.add_epi32(denormalExponent,
                                                  Sse2.and_si128(new v128(1L | (1L << 32), 0L),
                                                                 Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f32_exponent, new v128(121L | (121L << 32), 0L)),
                                                                                Sse2.andnot_si128(Sse2.cmpgt_epi32(new v128(0x0040_0000L | (0x0040_0000L << 32), 0L),
                                                                                                                   *(v128*)&f32_mantissa),
                                                                                                  new v128(-1L, 0L)))));

                v128 mantissaIfSmallerEpsilon = Sse2.and_si128(new v128(1L | (1L << 32), 0L),
                                                               Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f32_exponent, new v128(120L | (120L << 32), 0L)),
                                                                              Sse2.andnot_si128(Sse2.cmpeq_epi32(*(v128*)&f32_mantissa, default(v128)), new v128(-1L, 0L))));

                int2 normalExponent = (*(int2*)&cmpIsZeroOrNegativeMask & ((int2)f32_exponent - (127 + quarter.EXPONENT_BIAS))) << quarter.MANTISSA_BITS;

                int2 mantissaShift = 19 + maxmath.andnot(cmp, *(int2*)&cmpIsZeroOrNegativeMask);
                uint2 shifted = maxmath.shrl(f32_mantissa, mantissaShift);


                v128 exponentMantissa = Sse2.or_si128(Sse2.or_si128(*(v128*)&normalExponent, denormalExponent),
                                                      Sse2.or_si128(mantissaIfSmallerEpsilon, *(v128*)&shifted));

                v128 infNanexponentMantissa = Sse2.or_si128(new v128((long)quarter.PositiveInfinity.value | ((long)quarter.PositiveInfinity.value << 32), 0L),
                                                            Sse2.and_si128(new v128(1L | (1L << 32), 0L),
                                                                           Sse2.cmpgt_epi32(Sse.and_ps(*(v128*)&input, new v128((long)maxmath.bitmask32(31) | ((long)maxmath.bitmask32(31) << 32), 0L)),
                                                                                            new v128(0x7F80_0000L | (0x7F80_0000L << 32), 0L))));

                v128 underflowMask = Sse2.cmpgt_epi32(new v128(120L | (120L << 32), 0L), *(v128*)&f32_exponent);
                v128 overflowMask = Sse2.cmpgt_epi32(*(v128*)&f32_exponent, new v128(130L | (130L << 32), 0L));

                exponentMantissa = Mask.BlendV(exponentMantissa, default(v128), underflowMask);
                exponentMantissa = Mask.BlendV(exponentMantissa, *(v128*)&infNanexponentMantissa, overflowMask);

                return maxmath.asquarter(f8_sign | (byte2)(*(int2*)&exponentMantissa));
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(double2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                byte2 f8_sign = (byte2)((maxmath.asulong(input) >> 63) << 7);
                uint2 f64_exponent = (uint2)((maxmath.asulong(input) << 1) >> 53);


                ulong2 f64_mantissa = (maxmath.asulong(input) << 12) >> 12;

                int2 cmp = 1021 - (int2)f64_exponent;
                v128 cmpIsZeroOrNegativeMask = Sse2.cmpgt_epi32(new v128(1L | (1L << 32), 0L), *(v128*)&cmp);

                int2 denormalShift = maxmath.shrl((int2)0b0001_0000, cmp);
                v128 denormalExponent = Sse2.andnot_si128(cmpIsZeroOrNegativeMask, *(v128*)&denormalShift);
                denormalExponent = Sse2.add_epi32(denormalExponent,
                                                  Sse2.and_si128(new v128(1L | (1L << 32), 0L),
                                                                 Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f64_exponent, new v128(1017L | (1017L << 32), 0L)),
                                                                                Cast.Long2ToInt2(Sse2.andnot_si128(Operator.greater_mask_long(new v128(0x0008_0000_0000_0000ul, 0x0008_0000_0000_0000ul),
                                                                                                                                      f64_mantissa),
                                                                                                                   new v128(-1))))));

                v128 mantissaIfSmallerEpsilon = Sse2.and_si128(new v128(1L | (1L << 32), 0L),
                                                               Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f64_exponent, new v128(1016L | (1016L << 32), 0L)),
                                                                              Cast.Long2ToInt2(Sse2.andnot_si128(Sse2.cmpeq_epi32(f64_mantissa, default(v128)), new v128(-1)))));

                int2 normalExponent = (*(int2*)&cmpIsZeroOrNegativeMask & ((int2)f64_exponent - (1023 + quarter.EXPONENT_BIAS))) << quarter.MANTISSA_BITS;

                int2 mantissaShift = 48 + maxmath.andnot(cmp, *(int2*)&cmpIsZeroOrNegativeMask);
                ulong2 shifted = maxmath.shrl(f64_mantissa, (ulong2)mantissaShift);


                v128 exponentMantissa = Sse2.or_si128(Sse2.or_si128(*(v128*)&normalExponent, denormalExponent),
                                                      Sse2.or_si128(mantissaIfSmallerEpsilon, Cast.Long2ToInt2(shifted)));

                v128 infNanexponentMantissa = Sse2.or_si128(new v128((long)quarter.PositiveInfinity.value | ((long)quarter.PositiveInfinity.value << 32), 0L),
                                                            Sse2.and_si128(new v128(1L | (1L << 32), 0L),
                                                                           Cast.Long2ToInt2(Operator.greater_mask_long(Sse2.and_pd(*(v128*)&input, new v128(maxmath.bitmask64(63L))),
                                                                                                               new v128(0x7FF0_0000_0000_0000L)))));

                v128 underflowMask = Sse2.cmpgt_epi32(new v128(1016L | (1016L << 32), 0L), *(v128*)&f64_exponent);
                v128 overflowMask = Sse2.cmpgt_epi32(*(v128*)&f64_exponent, new v128(1026L | (1026L << 32), 0L));

                exponentMantissa = Mask.BlendV(exponentMantissa, default(v128), underflowMask);
                exponentMantissa = Mask.BlendV(exponentMantissa, *(v128*)&infNanexponentMantissa, overflowMask);

                return maxmath.asquarter(f8_sign | Cast.Int4ToByte4(exponentMantissa));
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte2(quarter2 input) => (sbyte2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(quarter2 input) => (byte2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2(quarter2 input) => (short2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(quarter2 input) => (ushort2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(quarter2 input) => (int2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(quarter2 input) => (uint2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(quarter2 input) => (int2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(quarter2 input) => (uint2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(quarter2 input) => (half2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(quarter2 input)
        {
            uint2 widen = maxmath.asbyte(input);

            uint2 sign = (widen >> 7) << 31;
            uint2 fusedExponentMantissa = (widen << (32 - (quarter.MANTISSA_BITS + quarter.EXPONENT_BITS))) >> 6;

            bool2 isNanOrInfinity = (widen & 0b0111_0000) == 0b0111_0000;
            uint2 nanInfinityOrZeroExponent = math.select(0u, 255u << 23, isNanOrInfinity);
            float2 magic = math.select(math.asfloat((255 - 1 + quarter.EXPONENT_BIAS) << 23), 1f, isNanOrInfinity);

            return magic * math.asfloat(sign | nanInfinityOrZeroExponent | fusedExponentMantissa);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(quarter2 input)
        {
            ulong2 widen = maxmath.asbyte(input);
             
            ulong2 sign = (widen >> 7) << 63;
            ulong2 fusedExponentMantissa = (widen << (64 - (quarter.MANTISSA_BITS + quarter.EXPONENT_BITS))) >> 9;

            bool2 isNanOrInfinity = (widen & 0b0111_0000) == 0b0111_0000;
            ulong2 nanInfinityOrZeroExponent = maxmath.select(0ul, 2047ul << 52, isNanOrInfinity);
            double2 magic = math.select(math.asdouble((2047L - 1L + quarter.EXPONENT_BIAS) << 52), 1d, isNanOrInfinity);

            return magic * maxmath.asdouble(sign | nanInfinityOrZeroExponent | fusedExponentMantissa);
        }


        public quarter this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                return maxmath.asquarter(asArray[index]);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 2);

                asArray[index] = maxmath.asbyte(value);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter2 left, quarter2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 maskedLeft = Sse2.and_si128(left, new byte2(0b0111_1111));
                v128 maskedRight = Sse2.and_si128(right, new byte2(0b0111_1111));


                v128 nan = Sse2.and_si128(Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedLeft, new byte2(0b0111_0000)), new v128(-1)),
                                          Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedRight, new byte2(0b0111_0000)), new v128(-1)));

                v128 zero = Sse2.and_si128(Sse2.cmpeq_epi8(default(v128), maskedLeft),
                                           Sse2.cmpeq_epi8(default(v128), maskedRight));

                v128 value = Sse2.cmpeq_epi8(left, right);


                v128 result = Sse2.sub_epi8(default(v128), Sse2.and_si128(nan, Sse2.or_si128(zero, value)));

                return *(bool2*)&result;
            }
            else
            {
                return new bool2(left.x == right.x, left.y == right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter2 left, quarter2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 maskedLeft = Sse2.and_si128(left, new byte2(0b0111_1111));
                v128 maskedRight = Sse2.and_si128(right, new byte2(0b0111_1111));


                v128 nan = Sse2.or_si128(Sse2.cmpgt_epi8(maskedLeft, new byte2(0b0111_0000)),
                                         Sse2.cmpgt_epi8(maskedRight, new byte2(0b0111_0000)));

                v128 zero = Sse2.or_si128(Sse2.andnot_si128(Sse2.cmpeq_epi8(default(v128), maskedLeft), new v128(-1)),
                                          Sse2.andnot_si128(Sse2.cmpeq_epi8(default(v128), maskedRight), new v128(-1)));

                v128 value = Sse2.andnot_si128(Sse2.cmpeq_epi8(left, right), new v128(-1));


                v128 result = Sse2.sub_epi8(default(v128), Sse2.or_si128(nan, Sse2.and_si128(zero, value)));

                return *(bool2*)&result;
            }
            else
            {
                return new bool2(left.x != right.x, left.y != right.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(quarter2 other)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 maskedLeft = Sse2.and_si128(this, new byte2(0b0111_1111));
                v128 maskedRight = Sse2.and_si128(other, new byte2(0b0111_1111));


                v128 nan = Sse2.and_si128(Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedLeft, new byte2(0b0111_0000)), new v128(-1)),
                                          Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedRight, new byte2(0b0111_0000)), new v128(-1)));

                v128 zero = Sse2.and_si128(Sse2.cmpeq_epi8(default(v128), maskedLeft),
                                           Sse2.cmpeq_epi8(default(v128), maskedRight));

                v128 value = Sse2.cmpeq_epi8(this, other);


                v128 result = Sse2.and_si128(nan, Sse2.or_si128(zero, value));

                return result.UShort0 == ushort.MaxValue;
            }
            else
            {
                return this.x == other.x && this.y == other.y;
            }
        }

        public override bool Equals(object obj) => Equals((quarter2)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            if (Sse.IsSseSupported)
            {
                return ((v128)this).UShort0;
            }
            else
            {
                quarter2 temp = this;
                return *(ushort*)&temp;
            }
        }


        public override string ToString() => $"quarter2({x}, {y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"quarter2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}