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
    unsafe public struct ulong2 : IEquatable<ulong2>, IFormattable
    {
        [NoAlias] public ulong x;
        [NoAlias] public ulong y;


        public static ulong2 zero => default(ulong2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(ulong x, ulong y)
        {
            this = Sse2.set_epi64x((long)y, (long)x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(ulong xy)
        {
            this = Sse2.set1_epi64x((long)xy);
        }


        #region Shuffle
        public ulong4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastq_epi64(this); }
        public ulong4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 0, 0, 1)); }
        public ulong4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 0, 1, 0)); }
        public ulong4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 1, 0, 0)); }
        public ulong4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 0, 0, 0)); }
        public ulong4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 0, 1, 1)); }
        public ulong4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 1, 0, 1)); }
        public ulong4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 0, 0, 1)); }
        public ulong4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 1, 1, 0)); }
        public ulong4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastsi128_si256(this); }
        public ulong4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 1, 0, 0)); }
        public ulong4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 1, 1, 1)); }
        public ulong4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 0, 1, 1)); }
        public ulong4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 1, 0, 1)); }
        public ulong4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 1, 1, 0)); }
        public ulong4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 1, 1, 1)); }
             
        public ulong3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastq_epi64(this); }
        public ulong3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 0, 0, 1)); }
        public ulong3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastsi128_si256(this); }                                     
        public ulong3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 1, 0, 0)); } 
        public ulong3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 0, 1, 1)); } 
        public ulong3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 1, 0, 1)); } 
        public ulong3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 1, 1, 0)); } 
        public ulong3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 1, 1, 1)); } 
      
        public ulong2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0)); }
        public ulong2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(1, 0, 3, 2)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yx; }
        public ulong2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(3, 2, 3, 2)); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v128(ulong2 input) => new v128(input.x, input.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v128 x)
        public static implicit operator ulong2(v128 input) => new ulong2 { x = input.ULong0, y = input.ULong1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2(ulong input) => new ulong2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(long2 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2(uint2 input) => Sse4_1.cvtepu32_epi64(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(int2 input) => Sse4_1.cvtepi32_epi64(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(half2 input) => (ulong2)(int2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(float2 input) => new ulong2((ulong)input.x, (ulong)input.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(double2 input) => new ulong2((ulong)input.x, (ulong)input.y);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(ulong2 input) { v128 t = Cast.Long2ToInt2(input); return *(uint2*)&t; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(ulong2 input) { v128 t = Cast.Long2ToInt2(input); return *(int2*)&t; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(ulong2 input) => (half2)(float2)(uint2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(ulong2 input) => new float2((float)input.x, (float)input.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(ulong2 input) => new double2((double)input.x, (double)input.y);


        public ulong this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    return ((ulong*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    ((ulong*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator + (ulong2 left, ulong2 right) => Sse2.add_epi64(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (ulong2 left, ulong2 right) => Sse2.sub_epi64(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (ulong2 left, ulong2 right) => Operator.mul_long(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (ulong2 left, ulong2 right) => new ulong2(left.x / right.x,    left.y / right.y);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (ulong2 left, ulong2 right) => new ulong2(left.x % right.x,    left.y % right.y);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (ulong2 left, ulong right) => new ulong2(left.x / right, left.y / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (ulong2 left, ulong right) => new ulong2(left.x % right, left.y % right);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (ulong2 left, ulong2 right) => Sse2.and_si128(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (ulong2 left, ulong2 right) => Sse2.or_si128(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (ulong2 left, ulong2 right) => Sse2.xor_si128(left, right);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ++ (ulong2 x) => Sse2.add_epi64(x, new v128(1L));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator -- (ulong2 x) => Sse2.sub_epi64(x, new v128(1L));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ~ (ulong2 x) => Sse2.andnot_si128(x, new v128(-1L));
    
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator << (ulong2 x, int n) => Operator.shl_long(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator >> (ulong2 x, int n) => Operator.shrl_long(x, n);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (ulong2 left, ulong2 right) => TestIsTrue(Sse4_1.cmpeq_epi64(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (ulong2 left, ulong2 right) => new bool2(left.x < right.x, left.y < right.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (ulong2 left, ulong2 right) => new bool2(left.x > right.x, left.y > right.y);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (ulong2 left, ulong2 right) => TestIsFalse(Sse4_1.cmpeq_epi64(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (ulong2 left, ulong2 right) => new bool2(left.x <= right.x, left.y <= right.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (ulong2 left, ulong2 right) => new bool2(left.x >= right.x, left.y >= right.y);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsTrue(v128 input)
        {
            int cast = 0x0101 & Sse2.movemask_epi8(input);

            return *(bool2*)&cast;
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsFalse(v128 input)
        {
            int result = maxmath.andnot(0x0101, Sse2.movemask_epi8(input));

            return *(bool2*)&result;
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ulong2 other) => maxmath.bitmask32(2) == Sse2.movemask_pd(Sse4_1.cmpeq_epi64(this, other));

        public override bool Equals(object obj) => Equals((ulong2)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v128(this);


        public override string ToString() => $"ulong2({x}, {y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ulong2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}