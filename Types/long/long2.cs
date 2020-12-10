using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Sequential, Size = 16)]
    unsafe public struct long2 : IEquatable<long2>
    {
        [NoAlias] public long x;
        [NoAlias] public long y;
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(long x,      long y)
        {
            this = Sse2.set_epi64x(y, x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(long xy)
        {
            this = Sse2.set1_epi64x(xy);
        }

        
        #region Shuffle
        public long4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastq_epi64(this); }
        public long4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 0, 0, 1)); }
        public long4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 0, 1, 0)); }
        public long4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 1, 0, 0)); }
        public long4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 0, 0, 0)); }
        public long4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 0, 1, 1)); }
        public long4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 1, 0, 1)); }
        public long4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 0, 0, 1)); }
        public long4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 1, 1, 0)); }
        public long4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastsi128_si256(this); }
        public long4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 1, 0, 0)); }
        public long4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 1, 1, 1)); }
        public long4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 0, 1, 1)); }
        public long4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 1, 0, 1)); }
        public long4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 1, 1, 0)); }
        public long4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 1, 1, 1)); }

        public long3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastq_epi64(this); }
        public long3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 0, 0, 1)); }
        public long3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastsi128_si256(this); }                                     
        public long3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 1, 0, 0)); } 
        public long3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 0, 1, 1)); } 
        public long3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 1, 0, 1)); } 
        public long3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 1, 1, 0)); } 
        public long3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 1, 1, 1)); } 

        public long2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0)); }
        public long2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(1, 0, 3, 2)); }
        public long2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(3, 2, 3, 2)); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v128(long2 input) => new v128(input.x, input.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v128 x)
        public static implicit operator long2(v128 input) => new long2 { x = input.SLong0, y = input.SLong1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(long input) => new long2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(ulong2 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(uint2 input) => Sse4_1.cvtepu32_epi64(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(int2 input) => Sse4_1.cvtepi32_epi64(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(half2 input) => (long2)(int2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(float2 input) => new long2((long)input.x, (long)input.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(double2 input) => new long2((long)input.x, (long)input.y);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(long2 input) { v128 t = Cast.Long2ToInt2(input); return *(uint2*)&t; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(long2 input) { v128 t = Cast.Long2ToInt2(input); return *(int2*)&t; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(long2 input) => (half2)(float2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(long2 input) => new float2((float)input.x, (float)input.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(long2 input) => new double2((double)input.x, (double)input.y);


        public long this[[AssumeRange(0, 1)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    return ((long*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    ((long*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (long2 lhs, long2 rhs) => Sse2.add_epi64(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 lhs, long2 rhs) => Sse2.sub_epi64(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 lhs, long2 rhs) => new long2(lhs.x * rhs.x,    lhs.y * rhs.y);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 lhs, long2 rhs) => new long2(lhs.x / rhs.x,    lhs.y / rhs.y);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 lhs, long2 rhs) => new long2(lhs.x % rhs.x,    lhs.y % rhs.y);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 lhs, long2 rhs) => Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 lhs, long2 rhs) => Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 lhs, long2 rhs) => Sse2.xor_si128(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 x) => Sse2.sub_epi64(default(v128), x);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ++ (long2 x) => Sse2.add_epi64(x, new v128(1L));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator -- (long2 x) => Sse2.sub_epi64(x, new v128(1L));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ~ (long2 x) => Sse2.andnot_si128(x, new v128(-1L));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator << (long2 x, int n) => Operator.shl_long(x, n);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator >> (long2 x, int n) => Operator.shra_long(x, n);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (long2 lhs, long2 rhs) => TestIsTrue(Sse4_1.cmpeq_epi64(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (long2 lhs, long2 rhs) => TestIsTrue(Sse4_2.cmpgt_epi64(rhs, lhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (long2 lhs, long2 rhs) => TestIsTrue(Sse4_2.cmpgt_epi64(lhs, rhs));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (long2 lhs, long2 rhs) => TestIsFalse(Sse4_1.cmpeq_epi64(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (long2 lhs, long2 rhs) => TestIsFalse(Sse4_2.cmpgt_epi64(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (long2 lhs, long2 rhs) => TestIsFalse(Sse4_2.cmpgt_epi64(rhs, lhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsTrue(v128 input)
        {
            int cast = 0x0101 & Sse2.movemask_epi8(input);

            return *(bool2*)&cast;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsFalse(v128 input)
        {
            int result = maxmath.andn(0x0101, Sse2.movemask_epi8(input));

            return *(bool2*)&result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(long2 other) => maxmath.cvt_boolean(Sse4_1.test_all_ones(Sse4_1.cmpeq_epi64(this, other)));

        public override bool Equals(object obj) => Equals((long2)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash._128bit(this);


        public override string ToString() => $"long2({x}, {y})";
    }
}