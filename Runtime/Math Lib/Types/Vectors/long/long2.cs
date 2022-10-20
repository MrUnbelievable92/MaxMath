using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable]  
    [StructLayout(LayoutKind.Explicit, Size = 2 * sizeof(long))]  
    [DebuggerTypeProxy(typeof(long2.DebuggerProxy))]
    unsafe public struct long2 : IEquatable<long2>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public long x;
            public long y;

            public DebuggerProxy(long2 v)
            {
                x = v.x;
                y = v.y;
            }
        }


        [FieldOffset(0)] public long x;
        [FieldOffset(8)] public long y;


        public static long2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(long x, long y)
        {
            if (Sse2.IsSse2Supported)
            {
                this.x = x;
                this.y = y;
            }
            else
            {
                this = Sse2.set_epi64x(y, x);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(long xy)
        {
            if (Sse2.IsSse2Supported)
            {
                this.x = this.y = xy;
            }
            else
            {
                this = Sse2.set1_epi64x(xy);
            }
        }


        #region Shuffle
        public readonly long4 xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_broadcastq_epi64(this);
                }
                else if (Sse2.IsSse2Supported)
                {
                    long2 _xx = xx;

                    return new long4(_xx, _xx);
                }
                else
                {
                    return new long4(x, x, x, x);
                }
            }
        }
        public readonly long4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 0, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yx, xx);
                }
                else
                {
                    return new long4(y, x, x, x);
                }
            }
        }
        public readonly long4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 0, 1, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(this, xx);
                }
                else
                {
                    return new long4(x, y, x, x);
                }
            }
        }
        public readonly long4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 1, 0, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xx, yx);
                }
                else
                {
                    return new long4(x, x, y, x);
                }
            }
        }
        public readonly long4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 0, 0, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xx, this);
                }
                else
                {
                    return new long4(x, x, x, y);
                }
            }
        }
        public readonly long4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 0, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yy, xx);
                }
                else
                {
                    return new long4(y, y, x, x);
                }
            }
        }
        public readonly long4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 1, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    long2 _yx = yx;

                    return new long4(_yx, _yx);
                }
                else
                {
                    return new long4(y, x, y, x);
                }
            }
        }
        public readonly long4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 0, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yx, this);
                }
                else
                {
                    return new long4(y, x, x, y);
                }
            }
        }
        public readonly long4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 1, 1, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(this, yx);
                }
                else
                {
                    return new long4(x, y, y, x);
                }
            }
        }
        public readonly long4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 0, 1, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(this, this);
                }
                else
                {
                    return new long4(x, y, x, y);
                }
            }
        }
        public readonly long4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 1, 0, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xx, yy);
                }
                else
                {
                    return new long4(x, x, y, y);
                }
            }
        }
        public readonly long4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 1, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yy, yx);
                }
                else
                {
                    return new long4(y, y, y, x);
                }
            }
        }
        public readonly long4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 0, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yy, this);
                }
                else
                {
                    return new long4(y, y, x, y);
                }
            }
        }
        public readonly long4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 1, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yx, yy);
                }
                else
                {
                    return new long4(y, x, y, y);
                }
            }
        }
        public readonly long4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 1, 1, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(this, yy);
                }
                else
                {
                    return new long4(x, y, y, y);
                }
            }
        }
        public readonly long4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 1, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    long2 _yy = yy;

                    return new long4(_yy, _yy);
                }
                else
                {
                    return new long4(y, y, y, y);
                }
            }
        }

        public readonly long3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_broadcastq_epi64(this);
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(xx, x);
                }
                else
                {
                    return new long3(x, x, x);
                }
            }
        }
        public readonly long3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 0, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(yx, x);
                }
                else
                {
                    return new long3(y, x, x);
                }
            }
        }
        public readonly long3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 0, 1, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(this, x);
                }
                else
                {
                    return new long3(x, y, x);
                }
            }
        }
        public readonly long3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 1, 0, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(xx, y);
                }
                else
                {
                    return new long3(x, x, y);
                }
            }
        }
        public readonly long3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 0, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(yy, x);
                }
                else
                {
                    return new long3(y, y, x);
                }
            }
        }
        public readonly long3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 1, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(yx, y);
                }
                else
                {
                    return new long3(y, x, y);
                }
            }
        }
        public readonly long3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 1, 1, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(this, y);
                }
                else
                {
                    return new long3(x, y, y);
                }
            }
        }
        public readonly long3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 1, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(yy, y);
                }
                else
                {
                    return new long3(y, y, y);
                }
            }
        }

        public readonly long2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0));
                }
                else
                {
                    return new long2(x, x);
                }
            }
        }
        public          long2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shuffle_epi32(this, Sse.SHUFFLE(1, 0, 3, 2));
                }
                else
                {
                    return new long2(y, x);
                }
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.yx;
            }
        }
        public readonly long2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shuffle_epi32(this, Sse.SHUFFLE(3, 2, 3, 2));
                }
                else
                {
                    return new long2(y, y);
                }
            }
        }
        #endregion

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(long2 input) => new v128 { SLong0 = input.x, SLong1 = input.y };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(v128 input) => new long2 { x = input.SLong0, y = input.SLong1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(long input) => new long2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(ulong2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(long2*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(uint2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepu32_epi64(RegisterConversion.ToV128(input));
            }
            else
            {
                return new long2((long)input.x, (long)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(int2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi32_epi64(RegisterConversion.ToV128(input));
            }
            else
            {
                return new long2((long)input.x, (long)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(half2 input) => (long2)(int2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(float2 input) => new long2((long)input.x, (long)input.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(double2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvttpd_epi64(RegisterConversion.ToV128(input));
            }
            else
            {
                return new long2((long)input.x, (long)input.y);
            }
        } 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(long2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt2(Xse.cvtepi64_epi32(input));
            }
            else
            {
                return new uint2((uint)input.x, (uint)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(long2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt2(Xse.cvtepi64_epi32(input));
            }
            else
            {
                return new int2((int)input.x, (int)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(long2 input) => (half2)(float2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(long2 input) => new float2((float)input.x, (float)input.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(long2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToDouble2(Xse.cvtepi64_pd(input));
            }
            
            return new double2((double)input.x, (double)input.y);
        } 


        public long this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 2);

                if (Sse2.IsSse2Supported)
                {
                    return (long)Xse.extract_epi64(this, (byte)index);
                }
                else
                {
                    long2 onStack = this;
                    
                    return *((long*)&onStack + index);
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 2);

                if (Sse2.IsSse2Supported)
                {
                    this = Xse.insert_epi64(this, (ulong)value, (byte)index);
                }
                else
                {
                    long2 onStack = this;
                    *((long*)&onStack + index) = value;
                    this = onStack;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (long2 left, long2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi64(left, right);
            }
            else
            {
                return new long2(left.x + right.x, left.y + right.y);
            }
        }
            
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 left, long2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi64(left, right);
            }
            else
            {
                return new long2(left.x - right.x, left.y - right.y);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, long2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.mullo_epi64(left, right);
            }
            else
            {
                return new long2(left.x * right.x, left.y * right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, long2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.div_epi64(left, right);
            }
            else
            {
                return new long2(left.x / right.x, left.y / right.y);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, long2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rem_epi64(left, right);
            }
            else
            {
                return new long2(left.x % right.x, left.y % right.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long left, long2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, long right)
        {
            if (Constant.IsConstantExpression(right))
            {
                 return new long2(left.x * right, left.y * right);
            }
            else
            {
                return left * (long2)right;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, long right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.div_epi64(left, right);
                }
            }
                
            return left / (long2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, long right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.rem_epi64(left, right);
                }
            }
                
            return left % (long2)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, long2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new long2((long)(left.x & right.x), (long)(left.y & right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, long2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new long2((long)(left.x | right.x), (long)(left.y | right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, long2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new long2((long)(left.x ^ right.x), (long)(left.y ^ right.y));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.neg_epi64(x);
            }
            else
            {
                return new long2(-x.x, -x.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ++ (long2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.inc_epi64(x);
            }
            else
            {
                return new long2(x.x + 1, x.y + 1);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator -- (long2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.dec_epi64(x);
            }
            else
            {
                return new long2(x.x - 1, x.y - 1);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ~ (long2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.not_si128(x);
            }
            else
            {
                return new long2(~x.x, ~x.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator << (long2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.slli_epi64(x, n);
            }
            else
            {
                return new long2(x.x << n, x.y << n);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator >> (long2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srai_epi64(x, n);
            }
            else
            {
                return new long2(x.x >> n, x.y >> n);
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (long2 left, long2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                int results = RegisterConversion.IsTrue64(Xse.cmpeq_epi64(left, right));

                return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x == right.x, left.y == right.y);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (long2 left, long2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                int results = RegisterConversion.IsTrue64(Xse.cmplt_epi64(left, right));

                return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x < right.x, left.y < right.y);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (long2 left, long2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                int results = RegisterConversion.IsTrue64(Xse.cmpgt_epi64(left, right));

                return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x > right.x, left.y > right.y);
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (long2 left, long2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                int results = RegisterConversion.IsFalse64(Xse.cmpeq_epi64(left, right));

                return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x != right.x, left.y != right.y);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (long2 left, long2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                int results = RegisterConversion.IsFalse64(Xse.cmpgt_epi64(left, right));

                return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x <= right.x, left.y <= right.y);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (long2 left, long2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                int results = RegisterConversion.IsFalse64(Xse.cmplt_epi64(left, right));

                return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x >= right.x, left.y >= right.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(long2 other)
        {
            if (Sse2.IsSse2Supported)
            {
                return bitmask32(16) == Sse2.movemask_epi8(Xse.cmpeq_epi64(this, other));
            }
            else
            {
                return this.x == other.x & this.y == other.y;
            }
        }

        public override readonly bool Equals(object obj) => obj is long2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Sse2.IsSse2Supported)
            {
                return Hash.v128(this);
            }
            else
            {
                long temp = x ^ y;

                return (int)(temp ^ (temp >> 32));
            }
        }


        public override readonly string ToString() => $"long2({x}, {y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"long2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}