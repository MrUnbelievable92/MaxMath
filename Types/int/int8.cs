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
    [Serializable] [StructLayout(LayoutKind.Explicit, Size = 32)]
    unsafe public struct int8 : IEquatable<int8>
    {
        [NoAlias] [FieldOffset(0)]  public int x0;
        [NoAlias] [FieldOffset(4)]  public int x1;
        [NoAlias] [FieldOffset(8)]  public int x2;
        [NoAlias] [FieldOffset(12)] public int x3;
        [NoAlias] [FieldOffset(16)] public int x4;
        [NoAlias] [FieldOffset(20)] public int x5;
        [NoAlias] [FieldOffset(24)] public int x6;
        [NoAlias] [FieldOffset(28)] public int x7;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int x0, int x1, int x2, int x3, int x4, int x5, int x6, int x7)
        {
            this = X86.Avx.mm256_set_epi32(x7, x6, x5, x4, x3, x2, x1, x0);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int x0x8)
        {
            this = X86.Avx.mm256_set1_epi32(x0x8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int2 x01, int2 x23, int2 x45, int2 x67)
        {
            this = new int8(new int4(x01, x23), new int4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int2 x01, int3 x234, int3 x567)
        {
            this = X86.Avx.mm256_set_m128i(X86.Sse4_1.insert_epi32(X86.Sse2.bslli_si128(*(v128*)&x567, sizeof(int)), (int)x234.z, 0),
                                           X86.Sse2.unpacklo_epi64(*(v128*)&x01, *(v128*)&x234));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int3 x012, int2 x34, int3 x567)
        {
            this = X86.Avx.mm256_set_m128i(X86.Sse4_1.insert_epi32(X86.Sse2.bslli_si128(*(v128*)&x567, sizeof(int)), (int)x34.y, 0),
                                           X86.Sse4_1.insert_epi32(*(v128*)&x012, (int)x34.x, 3));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int3 x012, int3 x345, int2 x67)
        {
            this = X86.Avx.mm256_set_m128i(X86.Sse2.unpacklo_epi64(X86.Sse2.bsrli_si128(*(v128*)&x345, sizeof(int)), *(v128*)&x67),
                                           X86.Sse4_1.insert_epi32(*(v128*)&x012, (int)x345.x, 3));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int4 x0123, int2 x45, int2 x67)
        {
            this = new int8(x0123, new int4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int2 x01, int4 x2345, int2 x67)
        {
            v128 t = *(v128*)&x2345;

            this = X86.Avx.mm256_set_m128i(X86.Sse2.unpackhi_epi64(t, X86.Sse2.bslli_si128(*(v128*)&x67, 2 * sizeof(int))),
                                           X86.Sse2.unpacklo_epi64(*(v128*)&x01, t));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int2 x01, int2 x23, int4 x4567)
        {
            this = new int8(new int4(x01, x23), x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int4 x0123, int4 x4567)
        {
            this = X86.Avx.mm256_set_m128i(*(v128*)&x4567,
                                           *(v128*)&x0123);
        }


        public int4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Avx.mm256_castsi256_si128(this); return *(int4*)&t; } }
        public int4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Avx.mm256_castsi256_si128(X86.Avx2.mm256_permutevar8x32_epi32(this, new v256(1, 2, 3, 4,   0, 0, 0, 0))); return *(int4*)&t; } }
        public int4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Avx.mm256_castsi256_si128(X86.Avx2.mm256_permutevar8x32_epi32(this, new v256(2, 3, 4, 5,   0, 0, 0, 0))); return *(int4*)&t; } }
        public int4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Avx.mm256_castsi256_si128(X86.Avx2.mm256_permutevar8x32_epi32(this, new v256(3, 4, 5, 6,   0, 0, 0, 0))); return *(int4*)&t; } }
        public int4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Avx2.mm256_extracti128_si256(this, 1); return *(int4*)&t; } }

        public int3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Avx.mm256_castsi256_si128(this); return *(int3*)&t; } }
        public int3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Sse2.bsrli_si128(X86.Avx.mm256_castsi256_si128(this), sizeof(int)); return *(int3*)&t; } }
        public int3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Avx.mm256_castsi256_si128(X86.Avx2.mm256_permutevar8x32_epi32(this, new v256(2, 3, 4,   0, 0, 0, 0, 0))); return *(int3*)&t; } }
        public int3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Avx.mm256_castsi256_si128(X86.Avx2.mm256_permutevar8x32_epi32(this, new v256(3, 4, 5,   0, 0, 0, 0, 0))); return *(int3*)&t; } }
        public int3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Avx2.mm256_extracti128_si256(this, 1); return *(int3*)&t; } }
        public int3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Avx.mm256_castsi256_si128(X86.Avx2.mm256_permutevar8x32_epi32(this, new v256(5, 6, 7,   0, 0, 0, 0, 0))); return *(int3*)&t; } }

        public int2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Avx.mm256_castsi256_si128(this); return *(int2*)&t; } }
        public int2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Sse2.bsrli_si128(X86.Avx.mm256_castsi256_si128(this), sizeof(int)); return *(int2*)&t; } }
        public int2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Sse2.bsrli_si128(X86.Avx.mm256_castsi256_si128(this), 2 * sizeof(int)); return *(int2*)&t; } }
        public int2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Avx.mm256_castsi256_si128(X86.Avx2.mm256_permutevar8x32_epi32(this, new v256(3, 4,   0, 0, 0, 0, 0, 0))); return *(int2*)&t; } }
        public int2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Avx2.mm256_extracti128_si256(this, 1); return *(int2*)&t; } }
        public int2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Avx.mm256_castsi256_si128(X86.Avx2.mm256_permutevar8x32_epi32(this, new v256(5, 6,   0, 0, 0, 0, 0, 0))); return *(int2*)&t; } }
        public int2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { v128 t = X86.Avx.mm256_castsi256_si128(X86.Avx2.mm256_permute4x64_epi64(this, X86.Sse.SHUFFLE(0, 0, 0,   3))); return *(int2*)&t; } }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   X86.Sse4_1.stream_load_si128(void* ptr)   X86.Sse.load_ps(void* ptr)
        public static implicit operator v256(int8 input) => new v256(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   X86.Sse.store_ps(void* ptr, v256 x)
        public static implicit operator int8(v256 input) => new int8 { x0 = input.SInt0, x1 = input.SInt1, x2 = input.SInt2, x3 = input.SInt3, x4 = input.SInt4, x5 = input.SInt5, x6 = input.SInt6, x7 = input.SInt7 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(int input) => new int8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int8(uint8 input) => (v256)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int8(float8 input) => X86.Avx.mm256_cvttps_epi32(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(int8 input) => X86.Avx.mm256_cvtepi32_ps(input);


        public int this[[AssumeRange(0, 7)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 8);
                
                fixed (void* ptr = &this)
                {
                    return ((int*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                fixed (void* ptr = &this)
                {
                    ((int*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator + (int8 lhs, int8 rhs) => X86.Avx2.mm256_add_epi32(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator - (int8 lhs, int8 rhs) => X86.Avx2.mm256_sub_epi32(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator * (int8 lhs, int8 rhs) => X86.Avx2.mm256_mullo_epi32(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator / (int8 lhs, int8 rhs) => new int8((lhs.x0 / rhs.x0),    (lhs.x1 / rhs.x1),    (lhs.x2 / rhs.x2),    (lhs.x3 / rhs.x3),    (lhs.x4 / rhs.x4),    (lhs.x5 / rhs.x5),    (lhs.x6 / rhs.x6),    (lhs.x7 / rhs.x7));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator % (int8 lhs, int8 rhs) => new int8((lhs.x0 % rhs.x0),    (lhs.x1 % rhs.x1),    (lhs.x2 % rhs.x2),    (lhs.x3 % rhs.x3),    (lhs.x4 % rhs.x4),    (lhs.x5 % rhs.x5),    (lhs.x6 % rhs.x6),    (lhs.x7 % rhs.x7));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator & (int8 lhs, int8 rhs) => X86.Avx2.mm256_and_si256(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator | (int8 lhs, int8 rhs) => X86.Avx2.mm256_or_si256(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator ^ (int8 lhs, int8 rhs) => X86.Avx2.mm256_xor_si256(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator - (int8 x) => X86.Avx2.mm256_sign_epi32(x, new v256((int)-1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator ++ (int8 x) => X86.Avx2.mm256_add_epi32(x, new v256((int)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator -- (int8 x) => X86.Avx2.mm256_sub_epi32(x, new v256((int)1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator ~ (int8 x) => X86.Avx2.mm256_andnot_si256(x, new v256((int)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator << (int8 x, int n) => Operator.shl_int(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator >> (int8 x, int n)
        { 
            switch (n)
            {
                case 1:  return X86.Avx2.mm256_srai_epi32(x, 1);
                case 2:  return X86.Avx2.mm256_srai_epi32(x, 2);
                case 3:  return X86.Avx2.mm256_srai_epi32(x, 3);
                case 4:  return X86.Avx2.mm256_srai_epi32(x, 4);
                case 5:  return X86.Avx2.mm256_srai_epi32(x, 5);
                case 6:  return X86.Avx2.mm256_srai_epi32(x, 6);
                case 7:  return X86.Avx2.mm256_srai_epi32(x, 7);
                case 8:  return X86.Avx2.mm256_srai_epi32(x, 8);
                case 9:  return X86.Avx2.mm256_srai_epi32(x, 9);
                case 10: return X86.Avx2.mm256_srai_epi32(x, 10);
                case 11: return X86.Avx2.mm256_srai_epi32(x, 11);
                case 12: return X86.Avx2.mm256_srai_epi32(x, 12);
                case 13: return X86.Avx2.mm256_srai_epi32(x, 13);
                case 14: return X86.Avx2.mm256_srai_epi32(x, 14);
                case 15: return X86.Avx2.mm256_srai_epi32(x, 15);
                case 16: return X86.Avx2.mm256_srai_epi32(x, 16);
                case 17: return X86.Avx2.mm256_srai_epi32(x, 17);
                case 18: return X86.Avx2.mm256_srai_epi32(x, 18);
                case 19: return X86.Avx2.mm256_srai_epi32(x, 19);
                case 20: return X86.Avx2.mm256_srai_epi32(x, 20);
                case 21: return X86.Avx2.mm256_srai_epi32(x, 21);
                case 22: return X86.Avx2.mm256_srai_epi32(x, 22);
                case 23: return X86.Avx2.mm256_srai_epi32(x, 23);
                case 24: return X86.Avx2.mm256_srai_epi32(x, 24);
                case 25: return X86.Avx2.mm256_srai_epi32(x, 25);
                case 26: return X86.Avx2.mm256_srai_epi32(x, 26);
                case 27: return X86.Avx2.mm256_srai_epi32(x, 27);
                case 28: return X86.Avx2.mm256_srai_epi32(x, 28);
                case 29: return X86.Avx2.mm256_srai_epi32(x, 29);
                case 30: return X86.Avx2.mm256_srai_epi32(x, 30);
                case 31: return X86.Avx2.mm256_srai_epi32(x, 31);

                default: return x;
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator == (int8 lhs, int8 rhs) => TestIsTrue(X86.Avx2.mm256_cmpeq_epi32(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator < (int8 lhs, int8 rhs) => TestIsTrue(X86.Avx2.mm256_cmpgt_epi32(rhs, lhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator > (int8 lhs, int8 rhs) => TestIsTrue(X86.Avx2.mm256_cmpgt_epi32(lhs, rhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator != (int8 lhs, int8 rhs) => TestIsFalse(X86.Avx2.mm256_cmpeq_epi32(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator <= (int8 lhs, int8 rhs) => TestIsFalse(X86.Avx2.mm256_cmpgt_epi32(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator >= (int8 lhs, int8 rhs) => TestIsFalse(X86.Avx2.mm256_cmpgt_epi32(rhs, lhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4x2 TestIsTrue(v256 input)
        {
            long result = 0x0101_0101_0101_0101L & X86.Sse4_1.extract_epi64((byte8)(uint8)input, 0);

            return *(bool4x2*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4x2 TestIsFalse(v256 input)
        {
            long result = maxmath.andn(0x0101_0101_0101_0101L, X86.Sse4_1.extract_epi64((byte8)(uint8)input, 0));

            return *(bool4x2*)&result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(int8 other) => maxmath.cvt_boolean(X86.Avx.mm256_testc_si256(X86.Avx2.mm256_cmpeq_epi32(this, other), new v256(-1)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => Equals((int8)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash._256bit(this);

        public override string ToString() => $"int8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
    }
}