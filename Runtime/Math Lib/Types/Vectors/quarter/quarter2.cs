using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable] 
    [StructLayout(LayoutKind.Explicit, Size = 2 * sizeof(byte))] 
    [DebuggerTypeProxy(typeof(quarter2.DebuggerProxy))]
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


        [FieldOffset(0)] public quarter x;
        [FieldOffset(1)] public quarter y;


        public static quarter2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(quarter x, quarter y)
        {
            this = asquarter(new byte2(x.value, y.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(quarter xy)
        {
            this = asquarter(new byte2(xy.value));
        }


        #region Shuffle
        public readonly quarter4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxxx); }
        public readonly quarter4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxxx); }
        public readonly quarter4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyxx); }
        public readonly quarter4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxyx); }
        public readonly quarter4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxxy); }
        public readonly quarter4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyxx); }
        public readonly quarter4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxyx); }
        public readonly quarter4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxxy); }
        public readonly quarter4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyyx); }
        public readonly quarter4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyxy); }
        public readonly quarter4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxyy); }
        public readonly quarter4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyyx); }
        public readonly quarter4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyxy); }
        public readonly quarter4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxyy); }
        public readonly quarter4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyyy); }
        public readonly quarter4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyyy); }
        
        public readonly quarter3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxx); }
        public readonly quarter3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxx); }
        public readonly quarter3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyx); }
        public readonly quarter3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxy); }
        public readonly quarter3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyx); }
        public readonly quarter3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxy); }
        public readonly quarter3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyy); }
        public readonly quarter3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyy); }

        public readonly quarter2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xx); }
        public          quarter2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yx; }
        public readonly quarter2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yy); }
        #endregion

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(quarter2 input)
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

            result.Byte0 = input.x.value;
            result.Byte1 = input.y.value;
            
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter2(v128 input) => new quarter2 { x = maxmath.asquarter(input.Byte0), y = maxmath.asquarter(input.Byte1) };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter2(quarter input) => new quarter2(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(half input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(float input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(double input) => (quarter)input;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter2 SByte2ToQuarter2(sbyte2 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepi8_pq(input, overflowValue, elements: 2);
            }
            else
            {
                return new quarter2(quarter.SByteToQuarter(input.x, overflowValue), 
                                    quarter.SByteToQuarter(input.y, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(sbyte2 input)
        {
            return SByte2ToQuarter2(input, quarter.PositiveInfinity);
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter2 Byte2ToQuarter2(byte2 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepu8_pq(input, overflowValue, elements: 2);
            }
            else
            {
                return new quarter2(quarter.ByteToQuarter(input.x, overflowValue), 
                                    quarter.ByteToQuarter(input.y, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(byte2 input)
        {
            return Byte2ToQuarter2(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter2 Short2ToQuarter2(short2 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepi16_pq(input, overflowValue, elements: 2);
            }
            else
            {
                return new quarter2(quarter.ShortToQuarter(input.x, overflowValue), 
                                    quarter.ShortToQuarter(input.y, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(short2 input)
        {
            return Short2ToQuarter2(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter2 UShort2ToQuarter2(ushort2 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepu16_pq(input, overflowValue, elements: 2);
            }
            else
            {
                return new quarter2(quarter.UShortToQuarter(input.x, overflowValue), 
                                    quarter.UShortToQuarter(input.y, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(ushort2 input)
        {
            return UShort2ToQuarter2(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter2 Int2ToQuarter2(int2 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepi32_pq(RegisterConversion.ToV128(input), overflowValue, elements: 2);
            }
            else
            {
                return new quarter2(quarter.IntToQuarter(input.x, overflowValue), 
                                    quarter.IntToQuarter(input.y, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(int2 input)
        {
            return Int2ToQuarter2(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter2 UInt2ToQuarter2(uint2 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepu32_pq(RegisterConversion.ToV128(input), overflowValue, elements: 2);
            }
            else
            {
                return new quarter2(quarter.UIntToQuarter(input.x, overflowValue), 
                                    quarter.UIntToQuarter(input.y, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(uint2 input)
        {
            return UInt2ToQuarter2(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter2 Long2ToQuarter2(long2 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepi64_pq(input, overflowValue);
            }
            else
            {
                return new quarter2(quarter.LongToQuarter(input.x, overflowValue), 
                                    quarter.LongToQuarter(input.y, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(long2 input)
        {
            return Long2ToQuarter2(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter2 ULong2ToQuarter2(ulong2 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepu64_pq(input, overflowValue);
            }
            else
            {
                return new quarter2(quarter.ULongToQuarter(input.x, overflowValue), 
                                    quarter.ULongToQuarter(input.y, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(ulong2 input)
        {
            return ULong2ToQuarter2(input, quarter.PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(half2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtph_pq(RegisterConversion.ToV128(input), elements: 2);
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
                return quarter.Vectorized.cvtps_pq(RegisterConversion.ToV128(input), elements: 2);
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter2 FloatToQuarterInRange(float2 f)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtps_pq(RegisterConversion.ToV128(f), promiseInRange: true, elements: 2);
            }
            else
            {
                return new quarter2(quarter.FloatToQuarterInRange(f.x), quarter.FloatToQuarterInRange(f.y));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter2 FloatToQuarterInRangeAbs(float2 f)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtps_pq(RegisterConversion.ToV128(f), promiseAbsoluteAndInRange: true, elements: 2);
            }
            else
            {
                return new quarter2(quarter.FloatToQuarterInRangeAbs(f.x), quarter.FloatToQuarterInRangeAbs(f.y));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(double2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtpd_pq(RegisterConversion.ToV128(input));
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter2 DoubleToQuarterInRange(double2 d)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtpd_pq(RegisterConversion.ToV128(d), promiseInRange: true);
            }
            else
            {
                return new quarter2(quarter.DoubleToQuarterInRange(d.x), quarter.DoubleToQuarterInRange(d.y));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter2 DoubleToQuarterInRangeAbs(double2 d)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtpd_pq(RegisterConversion.ToV128(d), promiseAbsoluteAndInRange: true);
            }
            else
            {
                return new quarter2(quarter.DoubleToQuarterInRangeAbs(d.x), quarter.DoubleToQuarterInRangeAbs(d.y));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(quarter2 input) => (sbyte2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(quarter2 input) => (byte2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(quarter2 input) => (short2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(quarter2 input) => (ushort2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(quarter2 input) => (int2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(quarter2 input) => (uint2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(quarter2 input) => (int2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(quarter2 input) => (ulong2)(int2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(quarter2 input) => (half2)(float2)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(quarter2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat2(quarter.Vectorized.cvtpq_ps(input, elements: 2));
            }
            else
            {
                return new float2(input.x, input.y);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float2 QuarterToFloatInRange(quarter2 q)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat2(quarter.Vectorized.cvtpq_ps(q, promiseInRange: true, elements: 2));
            }
            else
            {
                return new float2(quarter.QuarterToFloatInRange(q.x), quarter.QuarterToFloatInRange(q.y));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float2 QuarterToFloatInRangeAbs(quarter2 q)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat2(quarter.Vectorized.cvtpq_ps(q, promiseAbsoluteAndInRange: true, elements: 2));
            }
            else
            {
                return new float2(quarter.QuarterToFloatInRangeAbs(q.x), quarter.QuarterToFloatInRangeAbs(q.y));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(quarter2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToDouble2(quarter.Vectorized.cvtpq_pd(input));
            }
            else
            {
                return new double2((double)input.x, (double)input.y);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double2 QuarterToDoubleInRange(quarter2 q)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToDouble2(quarter.Vectorized.cvtpq_pd(q, promiseInRange: true));
            }
            else
            {
                return new double2(quarter.QuarterToDoubleInRange(q.x), quarter.QuarterToDoubleInRange(q.y));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double2 QuarterToDoubleInRangeAbs(quarter2 q)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToDouble2(quarter.Vectorized.cvtpq_pd(q, promiseAbsoluteAndInRange: true));
            }
            else
            {
                return new double2(quarter.QuarterToDoubleInRangeAbs(q.x), quarter.QuarterToDoubleInRangeAbs(q.y));
            }
        }


        public quarter this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 2);

                if (Sse2.IsSse2Supported)
                {
                    return asquarter(Xse.extract_epi8(this, (byte)index));
                }
                else
                {
                    quarter2 onStack = this;

                    return *((quarter*)&onStack + index);
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 2);

                if (Sse2.IsSse2Supported)
                {
                    this = Xse.insert_epi8(this, asbyte(value), (byte)index);
                }
                else
                {
                    quarter2 onStack = this;
                    *((quarter*)&onStack + index) = value;
                    this = onStack;
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 operator - (quarter2 value)
        {
            return asquarter(asbyte(value) ^ new byte2(0b1000_0000));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter2 left, quarter2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 results = RegisterConversion.IsTrue8(quarter.Vectorized.cmpeq_pq(left, right, elements: 2));

                return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x == right.x, left.y == right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter2 left, quarter right)
        {
            return left == (quarter2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter left, quarter2 right)
        {
            return (quarter2)left == right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter2 left, half right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter2);
            }
            else
            {
                return (float2)left == (float2)right;
            } 
        }

        public static bool2 operator == (half left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right == default(quarter2);
            }
            else
            {
                return (float2)left == (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter2 left, half2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float2)right == 0f)))
            {
                return left == default(quarter2);
            }
            else
            {
                return (float2)left == (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (half2 left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float2)left == 0f)))
            {
                return right == default(quarter2);
            }
            else
            {
                return (float2)left == (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter2 left, float right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter2);
            }
            else
            {
                return (float2)left == (float2)right;
            } 
        }

        public static bool2 operator == (float left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right == default(quarter2);
            }
            else
            {
                return (float2)left == (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter2 left, float2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left == default(quarter2);
            }
            else
            {
                return (float2)left == (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (float2 left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right == default(quarter2);
            }
            else
            {
                return (float2)left == (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter2 left, double right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter2);
            }
            else
            {
                return (double2)left == (double2)right;
            } 
        }

        public static bool2 operator == (double left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right == default(quarter2);
            }
            else
            {
                return (double2)left == (double2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter2 left, double2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left == default(quarter2);
            }
            else
            {
                return (double2)left == (double2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (double2 left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right == default(quarter2);
            }
            else
            {
                return (double2)left == (double2)right;
            } 
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter2 left, quarter2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 results = RegisterConversion.IsTrue8(quarter.Vectorized.cmpneq_pq(left, right, elements: 2));

                return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x != right.x, left.y != right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter2 left, quarter right)
        {
            return left != (quarter2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter left, quarter2 right)
        {
            return (quarter2)left != right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter2 left, half right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter2);
            }
            else
            {
                return (float2)left != (float2)right;
            } 
        }

        public static bool2 operator != (half left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right != default(quarter2);
            }
            else
            {
                return (float2)left != (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter2 left, half2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float2)right == 0f)))
            {
                return left != default(quarter2);
            }
            else
            {
                return (float2)left != (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (half2 left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float2)left == 0f)))
            {
                return right != default(quarter2);
            }
            else
            {
                return (float2)left != (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter2 left, float right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter2);
            }
            else
            {
                return (float2)left != (float2)right;
            } 
        }

        public static bool2 operator != (float left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right != default(quarter2);
            }
            else
            {
                return (float2)left != (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter2 left, float2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left != default(quarter2);
            }
            else
            {
                return (float2)left != (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (float2 left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right != default(quarter2);
            }
            else
            {
                return (float2)left != (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter2 left, double right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter2);
            }
            else
            {
                return (double2)left != (double2)right;
            } 
        }

        public static bool2 operator != (double left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right != default(quarter2);
            }
            else
            {
                return (double2)left != (double2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter2 left, double2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left != default(quarter2);
            }
            else
            {
                return (double2)left != (double2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (double2 left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right != default(quarter2);
            }
            else
            {
                return (double2)left != (double2)right;
            } 
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter2 left, quarter2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(quarter.Vectorized.cmplt_pq(left, right, elements: 2)));
            }
            else
            {
                return new bool2(left.x < right.x, left.y < right.y);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter2 left, quarter right)
        {
            return left < (quarter2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter left, quarter2 right)
        {
            return (quarter2)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter2 left, half right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter2);
            }
            else
            {
                return (float2)left < (float2)right;
            } 
        }

        public static bool2 operator < (half left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter2);
            }
            else
            {
                return (float2)left < (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter2 left, half2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float2)right == 0f)))
            {
                return left < default(quarter2);
            }
            else
            {
                return (float2)left < (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (half2 left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float2)left == 0f)))
            {
                return right > default(quarter2);
            }
            else
            {
                return (float2)left < (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter2 left, float right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter2);
            }
            else
            {
                return (float2)left < (float2)right;
            } 
        }

        public static bool2 operator < (float left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter2);
            }
            else
            {
                return (float2)left < (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter2 left, float2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left < default(quarter2);
            }
            else
            {
                return (float2)left < (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (float2 left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right > default(quarter2);
            }
            else
            {
                return (float2)left < (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter2 left, double right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter2);
            }
            else
            {
                return (double2)left < (double2)right;
            } 
        }

        public static bool2 operator < (double left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter2);
            }
            else
            {
                return (double2)left < (double2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter2 left, double2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left < default(quarter2);
            }
            else
            {
                return (double2)left < (double2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (double2 left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right > default(quarter2);
            }
            else
            {
                return (double2)left < (double2)right;
            } 
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter2 left, quarter2 right) => right < left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter2 left, quarter right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter left, quarter2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter2 left, half right) => right < left;

        public static bool2 operator > (half left, quarter2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter2 left, half2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (half2 left, quarter2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter2 left, float right) => right < left;

        public static bool2 operator > (float left, quarter2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter2 left, float2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (float2 left, quarter2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter2 left, double right) => right < left;

        public static bool2 operator > (double left, quarter2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter2 left, double2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (double2 left, quarter2 right) => right < left;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter2 left, quarter2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(quarter.Vectorized.cmple_pq(left, right, elements: 2)));
            }
            else
            {
                return new bool2(left.x <= right.x, left.y <= right.y);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter2 left, quarter right)
        {
            return left <= (quarter2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter left, quarter2 right)
        {
            return (quarter2)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter2 left, half right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter2);
            }
            else
            {
                return (float2)left <= (float2)right;
            } 
        }

        public static bool2 operator <= (half left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right >= default(quarter2);
            }
            else
            {
                return (float2)left <= (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter2 left, half2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float2)right == 0f)))
            {
                return left <= default(quarter2);
            }
            else
            {
                return (float2)left <= (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (half2 left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float2)left == 0f)))
            {
                return right >= default(quarter2);
            }
            else
            {
                return (float2)left <= (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter2 left, float right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter2);
            }
            else
            {
                return (float2)left <= (float2)right;
            } 
        }

        public static bool2 operator <= (float left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right >= default(quarter2);
            }
            else
            {
                return (float2)left <= (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter2 left, float2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left <= default(quarter2);
            }
            else
            {
                return (float2)left <= (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (float2 left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right >= default(quarter2);
            }
            else
            {
                return (float2)left <= (float2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter2 left, double right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter2);
            }
            else
            {
                return (double2)left <= (double2)right;
            } 
        }

        public static bool2 operator <= (double left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right >= default(quarter2);
            }
            else
            {
                return (double2)left <= (double2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter2 left, double2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left <= default(quarter2);
            }
            else
            {
                return (double2)left <= (double2)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (double2 left, quarter2 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right >= default(quarter2);
            }
            else
            {
                return (double2)left <= (double2)right;
            } 
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter2 left, quarter2 right) => right <= left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter2 left, quarter right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter left, quarter2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter2 left, half right) => right <= left;

        public static bool2 operator >= (half left, quarter2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter2 left, half2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (half2 left, quarter2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter2 left, float right) => right <= left;

        public static bool2 operator >= (float left, quarter2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter2 left, float2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (float2 left, quarter2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter2 left, double right) => right <= left;

        public static bool2 operator >= (double left, quarter2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter2 left, double2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (double2 left, quarter2 right) => right <= left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(quarter2 other)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.vcmpeq_pq(this, other, elements: 2);
            }
            else
            {
                return this.x == other.x && this.y == other.y;
            }
        }

        public override readonly bool Equals(object obj) => obj is quarter2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
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


        public override readonly string ToString() => $"quarter2({x}, {y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"quarter2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}