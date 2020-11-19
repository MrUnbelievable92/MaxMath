using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Explicit, Size = 16)]
    unsafe public struct ulong2 : IEquatable<ulong2>
    {
        [NoAlias] [FieldOffset(0)] public ulong x;
        [NoAlias] [FieldOffset(8)] public ulong y;
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(ulong x, ulong y)
        {
            this = X86.Sse2.set_epi64x((long)y, (long)x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(ulong xy)
        {
            this = X86.Sse2.set1_epi64x((long)xy);
        }


        #region Shuffle
        public ulong4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_broadcastq_epi64(this); }
        public ulong4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(0, 0, 0, 1)); }
        public ulong4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(0, 0, 1, 0)); }
        public ulong4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(0, 1, 0, 0)); }
        public ulong4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(1, 0, 0, 0)); }
        public ulong4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(0, 0, 1, 1)); }
        public ulong4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(0, 1, 0, 1)); }
        public ulong4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(1, 0, 0, 1)); }
        public ulong4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(0, 1, 1, 0)); }
        public ulong4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_broadcastsi128_si256(this); }
        public ulong4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(1, 1, 0, 0)); }
        public ulong4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(0, 1, 1, 1)); }
        public ulong4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(1, 0, 1, 1)); }
        public ulong4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(1, 1, 0, 1)); }
        public ulong4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(1, 1, 1, 0)); }
        public ulong4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(1, 1, 1, 1)); }
             
        public ulong3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_broadcastq_epi64(this); }
        public ulong3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(3, 0, 0, 1)); }
        public ulong3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_broadcastsi128_si256(this); }                                     
        public ulong3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(3, 1, 0, 0)); } 
        public ulong3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(3, 0, 1, 1)); } 
        public ulong3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(3, 1, 0, 1)); } 
        public ulong3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(3, 1, 1, 0)); } 
        public ulong3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_permute4x64_epi64(X86.Avx.mm256_castsi128_si256(this), X86.Sse.SHUFFLE(3, 1, 1, 1)); } 
      
        public ulong2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(1, 0, 1, 0)); }
        public ulong2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(1, 0, 3, 2)); }
        public ulong2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(3, 2, 3, 2)); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   X86.Sse4_1.stream_load_si128(void* ptr)   X86.Sse.load_ps(void* ptr)
        public static implicit operator v128(ulong2 input) => new v128(input.x, input.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   X86.Sse.store_ps(void* ptr, v128 x)
        public static implicit operator ulong2(v128 input) => new ulong2 { x = input.ULong0, y = input.ULong1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2(ulong input) => new ulong2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(long2 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2(uint2 input) => X86.Sse4_1.cvtepu32_epi64(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(int2 input) => X86.Sse4_1.cvtepi32_epi64(*(v128*)&input);

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
        public static explicit operator half2(ulong2 input) => (half2)(float2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(ulong2 input) => new float2((float)input.x, (float)input.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(ulong2 input) => new double2((double)input.x, (double)input.y);


        public ulong this[[AssumeRange(0, 1)] int index]
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
        public static ulong2 operator + (ulong2 lhs, ulong2 rhs) => X86.Sse2.add_epi64(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (ulong2 lhs, ulong2 rhs) => X86.Sse2.sub_epi64(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (ulong2 lhs, ulong2 rhs) => new ulong2(lhs.x * rhs.x,    lhs.y * rhs.y);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (ulong2 lhs, ulong2 rhs) => new ulong2(lhs.x / rhs.x,    lhs.y / rhs.y);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (ulong2 lhs, ulong2 rhs) => new ulong2(lhs.x % rhs.x,    lhs.y % rhs.y);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (ulong2 lhs, ulong2 rhs) => X86.Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (ulong2 lhs, ulong2 rhs) => X86.Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (ulong2 lhs, ulong2 rhs) => X86.Sse2.xor_si128(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ++ (ulong2 x) => X86.Sse2.add_epi64(x, new v128(1L));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator -- (ulong2 x) => X86.Sse2.sub_epi64(x, new v128(1L));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ~ (ulong2 x) => X86.Sse2.andnot_si128(x, new v128(-1L));
    
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator << (ulong2 x, int n) => Operator.shl_long(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator >> (ulong2 x, int n)
        {
            switch (n)
            {
                case 1:  return X86.Sse2.srli_epi64(x, 1);
                case 2:  return X86.Sse2.srli_epi64(x, 2);
                case 3:  return X86.Sse2.srli_epi64(x, 3);
                case 4:  return X86.Sse2.srli_epi64(x, 4);
                case 5:  return X86.Sse2.srli_epi64(x, 5);
                case 6:  return X86.Sse2.srli_epi64(x, 6);
                case 7:  return X86.Sse2.srli_epi64(x, 7);
                case 8:  return X86.Sse2.srli_epi64(x, 8);
                case 9:  return X86.Sse2.srli_epi64(x, 9);
                case 10: return X86.Sse2.srli_epi64(x, 10);
                case 11: return X86.Sse2.srli_epi64(x, 11);
                case 12: return X86.Sse2.srli_epi64(x, 12);
                case 13: return X86.Sse2.srli_epi64(x, 13);
                case 14: return X86.Sse2.srli_epi64(x, 14);
                case 15: return X86.Sse2.srli_epi64(x, 15);
                case 16: return X86.Sse2.srli_epi64(x, 16);
                case 17: return X86.Sse2.srli_epi64(x, 17);
                case 18: return X86.Sse2.srli_epi64(x, 18);
                case 19: return X86.Sse2.srli_epi64(x, 19);
                case 20: return X86.Sse2.srli_epi64(x, 20);
                case 21: return X86.Sse2.srli_epi64(x, 21);
                case 22: return X86.Sse2.srli_epi64(x, 22);
                case 23: return X86.Sse2.srli_epi64(x, 23);
                case 24: return X86.Sse2.srli_epi64(x, 24);
                case 25: return X86.Sse2.srli_epi64(x, 25);
                case 26: return X86.Sse2.srli_epi64(x, 26);
                case 27: return X86.Sse2.srli_epi64(x, 27);
                case 28: return X86.Sse2.srli_epi64(x, 28);
                case 29: return X86.Sse2.srli_epi64(x, 29);
                case 30: return X86.Sse2.srli_epi64(x, 30);
                case 31: return X86.Sse2.srli_epi64(x, 31);
                case 32: return X86.Sse2.srli_epi64(x, 32);
                case 33: return X86.Sse2.srli_epi64(x, 33);
                case 34: return X86.Sse2.srli_epi64(x, 34);
                case 35: return X86.Sse2.srli_epi64(x, 35);
                case 36: return X86.Sse2.srli_epi64(x, 36);
                case 37: return X86.Sse2.srli_epi64(x, 37);
                case 38: return X86.Sse2.srli_epi64(x, 38);
                case 39: return X86.Sse2.srli_epi64(x, 39);
                case 40: return X86.Sse2.srli_epi64(x, 40);
                case 41: return X86.Sse2.srli_epi64(x, 41);
                case 42: return X86.Sse2.srli_epi64(x, 42);
                case 43: return X86.Sse2.srli_epi64(x, 43);
                case 44: return X86.Sse2.srli_epi64(x, 44);
                case 45: return X86.Sse2.srli_epi64(x, 45);
                case 46: return X86.Sse2.srli_epi64(x, 46);
                case 47: return X86.Sse2.srli_epi64(x, 47);
                case 48: return X86.Sse2.srli_epi64(x, 48);
                case 49: return X86.Sse2.srli_epi64(x, 49);
                case 50: return X86.Sse2.srli_epi64(x, 50);
                case 51: return X86.Sse2.srli_epi64(x, 51);
                case 52: return X86.Sse2.srli_epi64(x, 52);
                case 53: return X86.Sse2.srli_epi64(x, 53);
                case 54: return X86.Sse2.srli_epi64(x, 54);
                case 55: return X86.Sse2.srli_epi64(x, 55);
                case 56: return X86.Sse2.srli_epi64(x, 56);
                case 57: return X86.Sse2.srli_epi64(x, 57);
                case 58: return X86.Sse2.srli_epi64(x, 58);
                case 59: return X86.Sse2.srli_epi64(x, 59);
                case 60: return X86.Sse2.srli_epi64(x, 60);
                case 61: return X86.Sse2.srli_epi64(x, 61);
                case 62: return X86.Sse2.srli_epi64(x, 62);
                case 63: return X86.Sse2.srli_epi64(x, 63);
    
                default: return x;
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (ulong2 lhs, ulong2 rhs) => TestIsTrue(X86.Sse4_1.cmpeq_epi64(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (ulong2 lhs, ulong2 rhs) => new bool2(lhs.x < rhs.x, lhs.y < rhs.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (ulong2 lhs, ulong2 rhs) => new bool2(lhs.x > rhs.x, lhs.y > rhs.y);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (ulong2 lhs, ulong2 rhs) => TestIsFalse(X86.Sse4_1.cmpeq_epi64(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (ulong2 lhs, ulong2 rhs) => new bool2(lhs.x <= rhs.x, lhs.y <= rhs.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (ulong2 lhs, ulong2 rhs) => new bool2(lhs.x >= rhs.x, lhs.y >= rhs.y);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsTrue(v128 input)
        {
            int cast = 0x0101 & X86.Sse2.movemask_epi8(input);

            return *(bool2*)&cast;
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsFalse(v128 input)
        {
            int result = maxmath.andn(0x0101, X86.Sse2.movemask_epi8(input));

            return *(bool2*)&result;
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ulong2 other) => maxmath.cvt_boolean(X86.Sse4_1.test_all_ones(X86.Sse4_1.cmpeq_epi64(this, other)));

        public override bool Equals(object obj) => Equals((ulong2)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash._128bit(this);


        public override string ToString() => $"ulong2({x}, {y})";
    }
}