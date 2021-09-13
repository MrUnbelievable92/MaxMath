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
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 8 * sizeof(byte))]  [DebuggerTypeProxy(typeof(quarter8.DebuggerProxy))]
    unsafe public struct quarter8 : IEquatable<quarter8>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public quarter x0;
            public quarter x1;
            public quarter x2;
            public quarter x3;
            public quarter x4;
            public quarter x5;
            public quarter x6;
            public quarter x7;

            public DebuggerProxy(quarter8 v)
            {
                x0 = v.x0;
                x1 = v.x1;
                x2 = v.x2;
                x3 = v.x3;
                x4 = v.x4;
                x5 = v.x5;
                x6 = v.x6;
                x7 = v.x7;
            }
        }


        [FieldOffset(0)] private fixed byte asArray[8];

        [FieldOffset(0)] public quarter x0;
        [FieldOffset(1)] public quarter x1;
        [FieldOffset(2)] public quarter x2;
        [FieldOffset(3)] public quarter x3;
        [FieldOffset(4)] public quarter x4;
        [FieldOffset(5)] public quarter x5;
        [FieldOffset(6)] public quarter x6;
        [FieldOffset(7)] public quarter x7;


        public static quarter8 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter x0, quarter x1, quarter x2, quarter x3, quarter x4, quarter x5, quarter x6, quarter x7)
        {
            this = maxmath.asquarter(new byte8(x0.value, x1.value, x2.value, x3.value, x4.value, x5.value, x6.value, x7.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter x0x8)
        {
            this = maxmath.asquarter(new byte8(x0x8.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter2 x01, quarter2 x23, quarter2 x45, quarter2 x67)
        {
            this = maxmath.asquarter(new byte8(maxmath.asbyte(x01), maxmath.asbyte(x23), maxmath.asbyte(x45), maxmath.asbyte(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter2 x01, quarter3 x234, quarter3 x567)
        {
            this = maxmath.asquarter(new byte8(maxmath.asbyte(x01), maxmath.asbyte(x234), maxmath.asbyte(x567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter3 x012, quarter2 x34, quarter3 x567)
        {
            this = maxmath.asquarter(new byte8(maxmath.asbyte(x012), maxmath.asbyte(x34), maxmath.asbyte(x567)));
        }   

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter3 x012, quarter3 x345, quarter2 x67)
        {
            this = maxmath.asquarter(new byte8(maxmath.asbyte(x012), maxmath.asbyte(x345), maxmath.asbyte(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter4 x0123, quarter2 x45, quarter2 x67)
        {
            this = maxmath.asquarter(new byte8(maxmath.asbyte(x0123), maxmath.asbyte(x45), maxmath.asbyte(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter2 x01, quarter4 x2345, quarter2 x67)
        {
            this = maxmath.asquarter(new byte8(maxmath.asbyte(x01), maxmath.asbyte(x2345), maxmath.asbyte(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter2 x01, quarter2 x23, quarter4 x4567)
        {
            this = maxmath.asquarter(new byte8(maxmath.asbyte(x01), maxmath.asbyte(x23), maxmath.asbyte(x4567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter4 x0123, quarter4 x4567)
        {
            this = maxmath.asquarter(new byte8(maxmath.asbyte(x0123), maxmath.asbyte(x4567)));
        }


        public quarter4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v4_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v4_0 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public quarter4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v4_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v4_1 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public quarter4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v4_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v4_2 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public quarter4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v4_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v4_3 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public quarter4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v4_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v4_4 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }

        public quarter3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v3_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v3_0 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public quarter3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v3_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v3_1 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public quarter3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v3_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v3_2 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public quarter3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v3_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v3_3 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public quarter3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v3_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v3_4 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public quarter3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v3_5); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v3_5 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }

        public quarter2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v2_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v2_0 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public quarter2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v2_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v2_1 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public quarter2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v2_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v2_2 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public quarter2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v2_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v2_3 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public quarter2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v2_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v2_4 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public quarter2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v2_5); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v2_5 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public quarter2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).v2_6); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = maxmath.asbyte(this); temp.v2_6 = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(quarter8 input) => new v128(*(long*)&input, 0L);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter8(v128 input) { long x = input.SLong0; return *(quarter8*)&x; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter8(quarter input) => new quarter8(input);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter8 Byte8ToQuarter8(byte8 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 overflowMask = Operator.greater_mask_byte(input, new byte8(15));


                float8 f = input;

                int8 f32 = maxmath.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = Sse2.cmpeq_epi8(input, default(v128));

                byte8 infinity = overflowValue.value;
                byte8 regular = Sse2.andnot_si128(notZeroMask, (byte8)f32);

                return Mask.BlendV(regular, infinity, overflowMask);
            }
            else
            {
                return new quarter8(quarter.ByteToQuarter(input.x0, overflowValue), 
                                    quarter.ByteToQuarter(input.x1, overflowValue), 
                                    quarter.ByteToQuarter(input.x2, overflowValue), 
                                    quarter.ByteToQuarter(input.x3, overflowValue), 
                                    quarter.ByteToQuarter(input.x4, overflowValue), 
                                    quarter.ByteToQuarter(input.x5, overflowValue), 
                                    quarter.ByteToQuarter(input.x6, overflowValue), 
                                    quarter.ByteToQuarter(input.x7, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(byte8 input)
        {
            return Byte8ToQuarter8(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter8 SByte8ToQuarter8(sbyte8 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte8 sign = input & unchecked((sbyte)0b1000_0000);
                sbyte8 abs = maxmath.abs(input);
                v128 overflowMask = Sse2.cmpgt_epi8(abs, new sbyte8(15));


                float8 f = abs;

                int8 f32 = maxmath.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = Sse2.cmpeq_epi8(abs, default(v128));

                sbyte8 infinity = (sbyte)overflowValue.value;
                sbyte8 regular = Sse2.andnot_si128(notZeroMask, (sbyte8)f32);

                return (v128)(sign | Mask.BlendV(regular, infinity, overflowMask));
            }
            else
            {
                return new quarter8(quarter.SByteToQuarter(input.x0, overflowValue), 
                                    quarter.SByteToQuarter(input.x1, overflowValue), 
                                    quarter.SByteToQuarter(input.x2, overflowValue), 
                                    quarter.SByteToQuarter(input.x3, overflowValue), 
                                    quarter.SByteToQuarter(input.x4, overflowValue), 
                                    quarter.SByteToQuarter(input.x5, overflowValue), 
                                    quarter.SByteToQuarter(input.x6, overflowValue), 
                                    quarter.SByteToQuarter(input.x7, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(sbyte8 input)
        {
            return SByte8ToQuarter8(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter8 UShort8ToQuarter8(ushort8 input, quarter overflowValue)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 overflowMask = (sbyte8)(ushort8)Operator.greater_mask_ushort(input, new ushort8(15));


                float8 f = input;

                int8 f32 = maxmath.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v256 notZeroMask = Avx2.mm256_cmpeq_epi32((int8)input, default(v256));

                byte8 infinity = overflowValue.value;
                byte8 regular = (byte8)(int8)Avx2.mm256_andnot_si256(notZeroMask, f32);

                return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 overflowMask = (sbyte8)(ushort8)Operator.greater_mask_ushort(input, new ushort8(15));


                float8 f = input;

                int8 f32 = maxmath.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = (sbyte8)(ushort8)Sse2.andnot_si128(Sse2.cmpeq_epi16(input, default(v128)), new v128(-1));

                byte8 infinity = overflowValue.value;
                byte8 regular = notZeroMask & (byte8)f32;

                return Mask.BlendV(regular, infinity, overflowMask);
            }
            else
            {
                return new quarter8(quarter.UShortToQuarter(input.x0, overflowValue), 
                                    quarter.UShortToQuarter(input.x1, overflowValue), 
                                    quarter.UShortToQuarter(input.x2, overflowValue), 
                                    quarter.UShortToQuarter(input.x3, overflowValue), 
                                    quarter.UShortToQuarter(input.x4, overflowValue), 
                                    quarter.UShortToQuarter(input.x5, overflowValue), 
                                    quarter.UShortToQuarter(input.x6, overflowValue), 
                                    quarter.UShortToQuarter(input.x7, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(ushort8 input)
        {
            return UShort8ToQuarter8(input, quarter.PositiveInfinity);
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter8 Short8ToQuarter8(short8 input, quarter overflowValue)
        {
            if (Avx2.IsAvx2Supported)
            {
                sbyte8 sign = (sbyte8)((ushort8)input >> 15) << 7;
                short8 abs = maxmath.abs(input);
                v128 overflowMask = (sbyte8)(short8)Sse2.cmpgt_epi16(abs, new short8(15));


                float8 f = abs;

                int8 f32 = maxmath.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v256 notZeroMask = Avx2.mm256_cmpeq_epi32((int8)input, default(v256));

                sbyte8 infinity = (sbyte)overflowValue.value;
                sbyte8 regular = (sbyte8)(int8)Avx2.mm256_andnot_si256(notZeroMask, f32);

                return (v128)(sign | Sse4_1.blendv_epi8(regular, infinity, overflowMask));
            }
            else if (Sse2.IsSse2Supported)
            {
                sbyte8 sign = (sbyte8)((ushort8)input >> 15) << 7;
                short8 abs = maxmath.abs(input);
                v128 overflowMask = (sbyte8)(short8)Sse2.cmpgt_epi16(abs, new short8(15));


                float8 f = abs;

                int8 f32 = maxmath.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = (sbyte8)(short8)Sse2.andnot_si128(Sse2.cmpeq_epi16(abs, default(v128)), new v128(-1));

                sbyte8 infinity = (sbyte)overflowValue.value;
                sbyte8 regular = (notZeroMask & (sbyte8)f32);

                return (v128)(sign | Mask.BlendV(regular, infinity, overflowMask));
            }
            else
            {
                return new quarter8(quarter.ShortToQuarter(input.x0, overflowValue), 
                                    quarter.ShortToQuarter(input.x1, overflowValue), 
                                    quarter.ShortToQuarter(input.x2, overflowValue), 
                                    quarter.ShortToQuarter(input.x3, overflowValue), 
                                    quarter.ShortToQuarter(input.x4, overflowValue), 
                                    quarter.ShortToQuarter(input.x5, overflowValue), 
                                    quarter.ShortToQuarter(input.x6, overflowValue), 
                                    quarter.ShortToQuarter(input.x7, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(short8 input)
        {
            return Short8ToQuarter8(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter8 UInt8ToQuarter8(uint8 input, quarter overflowValue)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 overflowMask = Cast.Int8ToByte8(Operator.greater_mask_uint(input, new v256(15)));


                float8 f = input;

                int8 f32 = maxmath.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v256 notZeroMask = Avx2.mm256_cmpeq_epi32(input, default(v256));

                byte8 infinity = overflowValue.value;
                byte8 regular = Cast.Int8ToByte8(Avx2.mm256_andnot_si256(notZeroMask, f32));

                return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
            }
            else
            {
                return new quarter8(quarter4.UInt4ToQuarter4(input.v4_0, overflowValue),
                                    quarter4.UInt4ToQuarter4(input.v4_4, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(uint8 input)
        {
            return UInt8ToQuarter8(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter8 Int8ToQuarter8(int8 input, quarter overflowValue)
        {
            if (Avx2.IsAvx2Supported)
            {
                sbyte8 sign = (sbyte8)((uint8)input >> 31) << 7;
                int8 abs = maxmath.abs(input);
                v128 overflowMask = Cast.Int8ToByte8(Avx2.mm256_cmpgt_epi32(abs, new v256(15)));


                float8 f = abs;

                int8 f32 = maxmath.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v256 notZeroMask = Avx2.mm256_cmpeq_epi32(input, default(v256));

                sbyte8 infinity = (sbyte)overflowValue.value;
                sbyte8 regular = Cast.Int8ToByte8(Avx2.mm256_andnot_si256(notZeroMask, f32));

                return (v128)(sign | Sse4_1.blendv_epi8(regular, infinity, overflowMask));
            }
            else
            {
                return new quarter8(quarter4.Int4ToQuarter4(input.v4_0, overflowValue),
                                    quarter4.Int4ToQuarter4(input.v4_4, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(int8 input)
        {
            return Int8ToQuarter8(input, quarter.PositiveInfinity);
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 Half8ToQuarter8InRange(half8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                byte8 f8_sign = (byte8)((maxmath.asushort(input) >> 15) << 7);
                uint8 f16_exponent = (maxmath.asushort(input) << 1) >> 11;


                uint8 f16_mantissa = (maxmath.asushort(input) << 6) >> 6;

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
                                                                                          Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(f16_mantissa, default(v256)), new v256(-1))));

                int8 normalExponent = ((int8)cmpIsZeroOrNegativeMask & ((int8)f16_exponent - (15 + quarter.EXPONENT_BIAS))) << quarter.MANTISSA_BITS;

                int8 mantissaShift = 6 + maxmath.andnot(cmp, (int8)cmpIsZeroOrNegativeMask);


                v256 exponentMantissa = Avx2.mm256_or_si256(Avx2.mm256_or_si256(normalExponent, denormalExponent),
                                                            Avx2.mm256_or_si256(mantissaIfSmallerEpsilon, Avx2.mm256_srlv_epi32(f16_mantissa, mantissaShift)));

                return maxmath.asquarter(f8_sign | Cast.Int8ToByte8(exponentMantissa));
            }
            else
            {
                return new quarter8(quarter4.Half4ToQuarter4InRange(input.v4_0),
                                    quarter4.Half4ToQuarter4InRange(input.v4_4));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(half8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                byte8 f8_sign = (byte8)((maxmath.asushort(input) >> 15) << 7);
                uint8 f16_exponent = (maxmath.asushort(input) << 1) >> 11;


                uint8 f16_mantissa = (maxmath.asushort(input) << 6) >> 6;

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
                                                                                          Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(f16_mantissa, default(v256)), new v256(-1))));

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
                
                exponentMantissa = Avx2.mm256_andnot_si256(underflowMask, exponentMantissa);
                exponentMantissa = Avx2.mm256_blendv_epi8(exponentMantissa, infNanexponentMantissa, overflowMask);

                return maxmath.asquarter(f8_sign | Cast.Int8ToByte8(exponentMantissa));
            }
            else
            {
                return new quarter8((quarter4)input.v4_0, (quarter4)input.v4_4);
            }
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 Float8ToQuarter8InRange(float8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                byte8 f8_sign = (byte8)((maxmath.asuint(input) >> 31) << 7);
                uint8 f32_exponent = (maxmath.asuint(input) << 1) >> 24;


                uint8 f32_mantissa = (maxmath.asuint(input) << 9) >> 9;

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
                                                                                          Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(f32_mantissa, default(v256)), new v256(-1))));

                int8 normalExponent = ((int8)cmpIsZeroOrNegativeMask & ((int8)f32_exponent - (127 + quarter.EXPONENT_BIAS))) << quarter.MANTISSA_BITS;

                int8 mantissaShift = 19 + maxmath.andnot(cmp, (int8)cmpIsZeroOrNegativeMask);


                v256 exponentMantissa = Avx2.mm256_or_si256(Avx2.mm256_or_si256(normalExponent, denormalExponent),
                                                            Avx2.mm256_or_si256(mantissaIfSmallerEpsilon, Avx2.mm256_srlv_epi32(f32_mantissa, mantissaShift)));

                return maxmath.asquarter(f8_sign | Cast.Int8ToByte8(exponentMantissa));
            }
            else
            {
                return new quarter8(quarter4.Float4ToQuarter4InRange(input.v4_0),
                                    quarter4.Float4ToQuarter4InRange(input.v4_4));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(float8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                byte8 f8_sign = (byte8)((maxmath.asuint(input) >> 31) << 7);
                uint8 f32_exponent = (maxmath.asuint(input) << 1) >> 24;


                uint8 f32_mantissa = (maxmath.asuint(input) << 9) >> 9;

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
                                                                                          Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(f32_mantissa, default(v256)), new v256(-1))));

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
                
                exponentMantissa = Avx2.mm256_andnot_si256(underflowMask, exponentMantissa);
                exponentMantissa = Avx2.mm256_blendv_epi8(exponentMantissa, infNanexponentMantissa, overflowMask);

                return maxmath.asquarter(f8_sign | Cast.Int8ToByte8(exponentMantissa));
            }
            else
            {
                return new quarter8((quarter4)input.v4_0, (quarter4)input.v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(quarter8 input) => (byte8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte8(quarter8 input) => (sbyte8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(quarter8 input) => (ushort8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(quarter8 input) => (short8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(quarter8 input) => (uint8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int8(quarter8 input) => (int8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(quarter8 input) => (half8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(quarter8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                uint8 widen = maxmath.asbyte(input);

                uint8 sign = (widen >> 7) << 31;
                uint8 fusedExponentMantissa = (widen << (32 - (quarter.MANTISSA_BITS + quarter.EXPONENT_BITS))) >> 6;

                v256 isNanOrInfinity = Avx2.mm256_cmpeq_epi32((widen & 0b0111_0000), (uint8)0b0111_0000);
                uint8 nanInfinityOrZeroExponent = Avx2.mm256_blendv_epi8(default(v256), (uint8)(255u << 23), isNanOrInfinity);
                float8 magic = Avx2.mm256_blendv_epi8(new v256((255 - 1 + quarter.EXPONENT_BIAS) << 23), new v256(1f), isNanOrInfinity);

                return magic * maxmath.asfloat(sign | nanInfinityOrZeroExponent | fusedExponentMantissa);
            }
            else
            {
                return new float8((float4)input.v4_0, (float4)input.v4_4);
            }
        }


        public quarter this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 8);

                return maxmath.asquarter(asArray[index]);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                asArray[index] = maxmath.asbyte(value);
            }
        }
    

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter8 left, quarter8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 maskedLeft = Sse2.and_si128(left, new byte8(0b0111_1111));
                v128 maskedRight = Sse2.and_si128(right, new byte8(0b0111_1111));


                v128 nan = Sse2.and_si128(Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedLeft, new byte8(0b0111_0000)), new v128(-1)),
                                          Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedRight, new byte8(0b0111_0000)), new v128(-1)));

                v128 zero = Sse2.and_si128(Sse2.cmpeq_epi8(default(v128), maskedLeft),
                                           Sse2.cmpeq_epi8(default(v128), maskedRight));

                v128 value = Sse2.cmpeq_epi8(left, right);


                return Sse2.sub_epi8(default(v128), Sse2.and_si128(nan, Sse2.or_si128(zero, value)));
            }
            else
            {
                return new bool8(left.x0 == right.x0, left.x1 == right.x1, left.x2 == right.x2, left.x3 == right.x3, left.x4 == right.x4, left.x5 == right.x5, left.x6 == right.x6, left.x7 == right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter8 left, quarter8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 maskedLeft = Sse2.and_si128(left, new byte8(0b0111_1111));
                v128 maskedRight = Sse2.and_si128(right, new byte8(0b0111_1111));


                v128 nan = Sse2.or_si128(Sse2.cmpgt_epi8(maskedLeft, new byte8(0b0111_0000)),
                                         Sse2.cmpgt_epi8(maskedRight, new byte8(0b0111_0000)));

                v128 zero = Sse2.or_si128(Sse2.andnot_si128(Sse2.cmpeq_epi8(default(v128), maskedLeft), new v128(-1)),
                                          Sse2.andnot_si128(Sse2.cmpeq_epi8(default(v128), maskedRight), new v128(-1)));

                v128 value = Sse2.andnot_si128(Sse2.cmpeq_epi8(left, right), new v128(-1));


                return Sse2.sub_epi8(default(v128), Sse2.or_si128(nan, Sse2.and_si128(zero, value)));
            }
            else
            {
                return new bool8(left.x0 != right.x0, left.x1 != right.x1, left.x2 != right.x2, left.x3 != right.x3, left.x4 != right.x4, left.x5 != right.x5, left.x6 != right.x6, left.x7 != right.x7);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(quarter8 other)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 maskedLeft = Sse2.and_si128(this, new byte8(0b0111_1111));
                v128 maskedRight = Sse2.and_si128(other, new byte8(0b0111_1111));


                v128 nan = Sse2.and_si128(Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedLeft, new byte8(0b0111_0000)), new v128(-1)),
                                          Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedRight, new byte8(0b0111_0000)), new v128(-1)));

                v128 zero = Sse2.and_si128(Sse2.cmpeq_epi8(default(v128), maskedLeft),
                                           Sse2.cmpeq_epi8(default(v128), maskedRight));

                v128 value = Sse2.cmpeq_epi8(this, other);


                v128 result = Sse2.and_si128(nan, Sse2.or_si128(zero, value));

                return result.ULong0 == ulong.MaxValue;
            }
            else
            {
                return ((this.x0 == other.x0 & this.x1 == other.x1) & (this.x2 == other.x2 & this.x3 == other.x3)) & ((this.x4 == other.x4 & this.x5 == other.x5) & (this.x6 == other.x6 & this.x7 == other.x7));
            }
        }

        public override bool Equals(object obj) => Equals((quarter8)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            if (Sse2.IsSse2Supported)
            {
                quarter8 temp = this;
                return (*(long*)&temp).GetHashCode();
            }
            else
            {
                return Hash.v64(this);
            }
        }


        public override string ToString() => $"quarter8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public string ToString(string format, IFormatProvider formatProvider) => $"quarter8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}