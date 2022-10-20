using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static Unity.Mathematics.math;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable] 
    [StructLayout(LayoutKind.Explicit, Size = 8 * sizeof(byte))]  
    [DebuggerTypeProxy(typeof(quarter8.DebuggerProxy))]
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
            this = asquarter(new byte8(x0.value, x1.value, x2.value, x3.value, x4.value, x5.value, x6.value, x7.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter x0x8)
        {
            this = asquarter(new byte8(x0x8.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter2 x01, quarter2 x23, quarter2 x45, quarter2 x67)
        {
            this = asquarter(new byte8(asbyte(x01), asbyte(x23), asbyte(x45), asbyte(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter2 x01, quarter3 x234, quarter3 x567)
        {
            this = asquarter(new byte8(asbyte(x01), asbyte(x234), asbyte(x567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter3 x012, quarter2 x34, quarter3 x567)
        {
            this = asquarter(new byte8(asbyte(x012), asbyte(x34), asbyte(x567)));
        }   

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter3 x012, quarter3 x345, quarter2 x67)
        {
            this = asquarter(new byte8(asbyte(x012), asbyte(x345), asbyte(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter4 x0123, quarter2 x45, quarter2 x67)
        {
            this = asquarter(new byte8(asbyte(x0123), asbyte(x45), asbyte(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter2 x01, quarter4 x2345, quarter2 x67)
        {
            this = asquarter(new byte8(asbyte(x01), asbyte(x2345), asbyte(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter2 x01, quarter2 x23, quarter4 x4567)
        {
            this = asquarter(new byte8(asbyte(x01), asbyte(x23), asbyte(x4567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter4 x0123, quarter4 x4567)
        {
            this = asquarter(new byte8(asbyte(x0123), asbyte(x4567)));
        }


        public quarter4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v4_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v4_0 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v4_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v4_1 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v4_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v4_2 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v4_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v4_3 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v4_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v4_4 = asbyte(value); this = asquarter(temp); } }

        public quarter3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v3_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v3_0 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v3_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v3_1 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v3_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v3_2 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v3_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v3_3 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v3_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v3_4 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v3_5); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v3_5 = asbyte(value); this = asquarter(temp); } }

        public quarter2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v2_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v2_0 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v2_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v2_1 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v2_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v2_2 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v2_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v2_3 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v2_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v2_4 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v2_5); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v2_5 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).v2_6); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v2_6 = asbyte(value); this = asquarter(temp); } }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(quarter8 input)
        {
            v128 result;

            if (Avx.IsAvxSupported)
            {
                result = Avx.undefined_si128();
            }
            else
            {
                v128* dummyPtr = &result;
            }

            result.Byte0 = input.x0.value;
            result.Byte1 = input.x1.value;
            result.Byte2 = input.x2.value;
            result.Byte3 = input.x3.value;
            result.Byte4 = input.x4.value;
            result.Byte5 = input.x5.value;
            result.Byte6 = input.x6.value;
            result.Byte7 = input.x7.value;
            
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter8(v128 input) => new quarter8 { x0 = maxmath.asquarter(input.Byte0), x1 = maxmath.asquarter(input.Byte1), x2 = maxmath.asquarter(input.Byte2), x3 = maxmath.asquarter(input.Byte3), x4 = maxmath.asquarter(input.Byte4), x5 = maxmath.asquarter(input.Byte5), x6 = maxmath.asquarter(input.Byte6), x7 = maxmath.asquarter(input.Byte7) };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter8(quarter input) => new quarter8(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(half input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(float input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(double input) => (quarter)input;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter8 Byte8ToQuarter8(byte8 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepu8_pq(input, overflowValue, elements: 8);
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
                return quarter.Vectorized.cvtepi8_pq(input, overflowValue, elements: 8);
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
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepu16_pq(input, overflowValue, elements: 8);
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
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepi16_pq(input, overflowValue, elements: 8);
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
                return quarter.Vectorized.mm256_cvtepu32_pq(input, overflowValue);
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
                return quarter.Vectorized.mm256_cvtepi32_pq(input, overflowValue);
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
        public static explicit operator quarter8(half8 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtph_pq(input, elements: 8);
            }
            else
            {
                return new quarter8((quarter4)input.v4_0, (quarter4)input.v4_4);
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(float8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return quarter.Vectorized.mm256_cvtps_pq(input);
            }
            else
            {
                return new quarter8((quarter4)input.v4_0, (quarter4)input.v4_4);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter8 FloatToQuarterInRange(float8 f)
        {
            if (Avx2.IsAvx2Supported)
            {
                return quarter.Vectorized.mm256_cvtps_pq(f, promiseInRange: true);
            }
            else
            {
                return new quarter8(quarter4.FloatToQuarterInRange(f.v4_0), quarter4.FloatToQuarterInRange(f.v4_4));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter8 FloatToQuarterInRangeAbs(float8 f)
        {
            if (Avx2.IsAvx2Supported)
            {
                return quarter.Vectorized.mm256_cvtps_pq(f, promiseAbsoluteAndInRange: true);
            }
            else
            {
                return new quarter8(quarter4.FloatToQuarterInRangeAbs(f.v4_0), quarter4.FloatToQuarterInRangeAbs(f.v4_4));
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
                return quarter.Vectorized.mm256_cvtpq_ps(input);
            }
            else
            {
                return new float8((float4)input.v4_0, (float4)input.v4_4);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float8 QuarterToFloatInRange(quarter8 q)
        {
            if (Avx2.IsAvx2Supported)
            {
                return quarter.Vectorized.mm256_cvtpq_ps(q, promiseInRange: true);
            }
            else
            {
                return new float8(quarter4.QuarterToFloatInRange(q.v4_0), quarter4.QuarterToFloatInRange(q.v4_4));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float8 QuarterToFloatInRangeAbs(quarter8 q)
        {
            if (Avx2.IsAvx2Supported)
            {
                return quarter.Vectorized.mm256_cvtpq_ps(q, promiseAbsoluteAndInRange: true);
            }
            else
            {
                return new float8(quarter4.QuarterToFloatInRangeAbs(q.v4_0), quarter4.QuarterToFloatInRangeAbs(q.v4_4));
            }
        }


        public quarter this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 8);

                if (Sse2.IsSse2Supported)
                {
                    return asquarter(Xse.extract_epi8(this, (byte)index));
                }
                else
                {
                    quarter8 onStack = this;

                    return *((quarter*)&onStack + index);
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                if (Sse2.IsSse2Supported)
                {
                    this = Xse.insert_epi8(this, asbyte(value), (byte)index);
                }
                else
                {
                    quarter8 onStack = this;
                    *((quarter*)&onStack + index) = value;
                    this = onStack;
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 operator - (quarter8 value)
        {
            return asquarter(asbyte(value) ^ new byte8(0b1000_0000));
        }
    

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter8 left, quarter8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue8(quarter.Vectorized.cmpeq_pq(left, right, elements: 8));
            }
            else
            {
                return new bool8(left.x0 == right.x0, left.x1 == right.x1, left.x2 == right.x2, left.x3 == right.x3, left.x4 == right.x4, left.x5 == right.x5, left.x6 == right.x6, left.x7 == right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter8 left, quarter right)
        {
            return left == (quarter8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter left, quarter8 right)
        {
            return (quarter8)left == right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter8 left, half right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter8);
            }
            else
            {
                return (float8)left == (float8)right;
            } 
        }

        public static bool8 operator == (half left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right == default(quarter8);
            }
            else
            {
                return (float8)left == (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter8 left, half8 right)
        {
            if (Xse.constexpr.ALL_EQ_PS((float8)right, 0f))
            {
                return left == default(quarter8);
            }
            else
            {
                return (float8)left == (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (half8 left, quarter8 right)
        {
            if (Xse.constexpr.ALL_EQ_PS((float8)left, 0f))
            {
                return right == default(quarter8);
            }
            else
            {
                return (float8)left == (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter8 left, float right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter8);
            }
            else
            {
                return (float8)left == (float8)right;
            } 
        }

        public static bool8 operator == (float left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right == default(quarter8);
            }
            else
            {
                return (float8)left == (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter8 left, float8 right)
        {
            if (Xse.constexpr.IS_TRUE(all(right == 0f)))
            {
                return left == default(quarter8);
            }
            else
            {
                return (float8)left == (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (float8 left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(all(left == 0f)))
            {
                return right == default(quarter8);
            }
            else
            {
                return (float8)left == (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter8 left, double right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter8);
            }
            else
            {
                return new bool8((double4)left.v4_0 == right, (double4)left.v4_4 == right);
            } 
        }

        public static bool8 operator == (double left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right == default(quarter8);
            }
            else
            {
                return new bool8((double4)right.v4_0 == left, (double4)right.v4_4 == left);
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter8 left, quarter8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue8(quarter.Vectorized.cmpneq_pq(left, right, elements: 8));
            }
            else
            {
                return new bool8(left.x0 != right.x0, left.x1 != right.x1, left.x2 != right.x2, left.x3 != right.x3, left.x4 != right.x4, left.x5 != right.x5, left.x6 != right.x6, left.x7 != right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter8 left, quarter right)
        {
            return left != (quarter8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter left, quarter8 right)
        {
            return (quarter8)left != right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter8 left, half right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter8);
            }
            else
            {
                return (float8)left != (float8)right;
            } 
        }

        public static bool8 operator != (half left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right != default(quarter8);
            }
            else
            {
                return (float8)left != (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter8 left, half8 right)
        {
            if (Xse.constexpr.ALL_EQ_PS((float8)right, 0f))
            {
                return left != default(quarter8);
            }
            else
            {
                return (float8)left != (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (half8 left, quarter8 right)
        {
            if (Xse.constexpr.ALL_EQ_PS((float8)left, 0f))
            {
                return right != default(quarter8);
            }
            else
            {
                return (float8)left != (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter8 left, float right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter8);
            }
            else
            {
                return (float8)left != (float8)right;
            } 
        }

        public static bool8 operator != (float left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right != default(quarter8);
            }
            else
            {
                return (float8)left != (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter8 left, float8 right)
        {
            if (Xse.constexpr.IS_TRUE(all(right == 0f)))
            {
                return left != default(quarter8);
            }
            else
            {
                return (float8)left != (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (float8 left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(all(left == 0f)))
            {
                return right != default(quarter8);
            }
            else
            {
                return (float8)left != (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter8 left, double right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter8);
            }
            else
            {
                return new bool8((double4)left.v4_0 != right, (double4)left.v4_4 != right);
            } 
        }

        public static bool8 operator != (double left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right != default(quarter8);
            }
            else
            {
                return new bool8((double4)right.v4_0 != left, (double4)right.v4_4 != left);
            } 
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (quarter8 left, quarter8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue8(quarter.Vectorized.cmplt_pq(left, right, elements: 8));
            }
            else
            {
                return new bool8(left.x0 < right.x0, left.x1 < right.x1, left.x2 < right.x2, left.x3 < right.x3, left.x4 < right.x4, left.x5 < right.x5, left.x6 < right.x6, left.x7 < right.x7);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (quarter8 left, quarter right)
        {
            return left < (quarter8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (quarter left, quarter8 right)
        {
            return (quarter8)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (quarter8 left, half right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter8);
            }
            else
            {
                return (float8)left < (float8)right;
            } 
        }

        public static bool8 operator < (half left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter8);
            }
            else
            {
                return (float8)left < (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (quarter8 left, half8 right)
        {
            if (Xse.constexpr.IS_TRUE(maxmath.all((float8)right == 0f)))
            {
                return left < default(quarter8);
            }
            else
            {
                return (float8)left < (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (half8 left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(maxmath.all((float8)left == 0f)))
            {
                return right > default(quarter8);
            }
            else
            {
                return (float8)left < (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (quarter8 left, float right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter8);
            }
            else
            {
                return (float8)left < (float8)right;
            } 
        }

        public static bool8 operator < (float left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter8);
            }
            else
            {
                return (float8)left < (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (quarter8 left, float8 right)
        {
            if (Xse.constexpr.IS_TRUE(maxmath.all(right == 0f)))
            {
                return left < default(quarter8);
            }
            else
            {
                return (float8)left < (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (float8 left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(maxmath.all(left == 0f)))
            {
                return right > default(quarter8);
            }
            else
            {
                return (float8)left < (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (quarter8 left, double right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter8);
            }
            else
            {
                return new bool8((double4)left.v4_0 < (double4)right, (double4)left.v4_4 < (double4)right);
            } 
        }

        public static bool8 operator < (double left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter8);
            }
            else
            {
                return new bool8((double4)left < (double4)right.v4_0, (double4)left < (double4)right.v4_4);
            } 
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (quarter8 left, quarter8 right) => right < left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (quarter8 left, quarter right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (quarter left, quarter8 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (quarter8 left, half right) => right < left;

        public static bool8 operator > (half left, quarter8 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (quarter8 left, half8 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (half8 left, quarter8 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (quarter8 left, float right) => right < left;

        public static bool8 operator > (float left, quarter8 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (quarter8 left, float8 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (float8 left, quarter8 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (quarter8 left, double right) => right < left;

        public static bool8 operator > (double left, quarter8 right) => right < left;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (quarter8 left, quarter8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue8(quarter.Vectorized.cmple_pq(left, right, elements: 8));
            }
            else
            {
                return new bool8(left.x0 <= right.x0, left.x1 <= right.x1, left.x2 <= right.x2, left.x3 <= right.x3, left.x4 <= right.x4, left.x5 <= right.x5, left.x6 <= right.x6, left.x7 <= right.x7);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (quarter8 left, quarter right)
        {
            return left <= (quarter8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (quarter left, quarter8 right)
        {
            return (quarter8)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (quarter8 left, half right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter8);
            }
            else
            {
                return (float8)left <= (float8)right;
            } 
        }

        public static bool8 operator <= (half left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right >= default(quarter8);
            }
            else
            {
                return (float8)left <= (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (quarter8 left, half8 right)
        {
            if (Xse.constexpr.IS_TRUE(maxmath.all((float8)right == 0f)))
            {
                return left <= default(quarter8);
            }
            else
            {
                return (float8)left <= (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (half8 left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(maxmath.all((float8)left == 0f)))
            {
                return right >= default(quarter8);
            }
            else
            {
                return (float8)left <= (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (quarter8 left, float right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter8);
            }
            else
            {
                return (float8)left <= (float8)right;
            } 
        }

        public static bool8 operator <= (float left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right >= default(quarter8);
            }
            else
            {
                return (float8)left <= (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (quarter8 left, float8 right)
        {
            if (Xse.constexpr.IS_TRUE(maxmath.all(right == 0f)))
            {
                return left <= default(quarter8);
            }
            else
            {
                return (float8)left <= (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (float8 left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(maxmath.all(left == 0f)))
            {
                return right >= default(quarter8);
            }
            else
            {
                return (float8)left <= (float8)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (quarter8 left, double right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter8);
            }
            else
            {
                return new bool8((double4)left.v4_0 <= (double4)right, (double4)left.v4_4 <= (double4)right);
            } 
        }

        public static bool8 operator <= (double left, quarter8 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right >= default(quarter8);
            }
            else
            {
                return new bool8((double4)left <= (double4)right.v4_0, (double4)left <= (double4)right.v4_4);
            } 
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (quarter8 left, quarter8 right) => right <= left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (quarter8 left, quarter right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (quarter left, quarter8 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (quarter8 left, half right) => right <= left;

        public static bool8 operator >= (half left, quarter8 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (quarter8 left, half8 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (half8 left, quarter8 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (quarter8 left, float right) => right <= left;

        public static bool8 operator >= (float left, quarter8 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (quarter8 left, float8 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (float8 left, quarter8 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (quarter8 left, double right) => right <= left;

        public static bool8 operator >= (double left, quarter8 right) => right <= left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(quarter8 other)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.vcmpeq_pq(this, other, elements: 8);
            }
            else
            {
                return ((this.x0 == other.x0 & this.x1 == other.x1) & (this.x2 == other.x2 & this.x3 == other.x3)) & ((this.x4 == other.x4 & this.x5 == other.x5) & (this.x6 == other.x6 & this.x7 == other.x7));
            }
        }

        public override bool Equals(object obj) => obj is quarter8 converted && this.Equals(converted);


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