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
    unsafe public struct ushort8 : IEquatable<ushort8>
    {
        [NoAlias] [FieldOffset(0)]  public ushort x0;
        [NoAlias] [FieldOffset(2)]  public ushort x1;
        [NoAlias] [FieldOffset(4)]  public ushort x2;
        [NoAlias] [FieldOffset(6)]  public ushort x3;
        [NoAlias] [FieldOffset(8)]  public ushort x4;
        [NoAlias] [FieldOffset(10)] public ushort x5;
        [NoAlias] [FieldOffset(12)] public ushort x6;
        [NoAlias] [FieldOffset(14)] public ushort x7;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort x0, ushort x1, ushort x2, ushort x3, ushort x4, ushort x5, ushort x6, ushort x7)
        {
            this = X86.Sse2.set_epi16((short)x7, (short)x6, (short)x5, (short)x4, (short)x3, (short)x2, (short)x1, (short)x0);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort x0x8)
        {
            this = X86.Sse2.set1_epi16((short)x0x8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort2 x01, ushort2 x23, ushort2 x45, ushort2 x67)
        {
            this = new ushort8(new ushort4(x01, x23), new ushort4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort2 x01, ushort3 x234, ushort3 x567)
        {
            this = new ushort8((ushort4)X86.Sse2.unpacklo_epi32(x01, x234),
                               (ushort4)X86.Sse2.insert_epi16(X86.Sse2.bslli_si128(x567, sizeof(ushort)), x234.z, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort3 x012, ushort2 x34, ushort3 x567)
        {
            this = new ushort8((ushort4)X86.Sse2.insert_epi16(x012, x34.x, 3),
                               (ushort4)X86.Sse2.insert_epi16(X86.Sse2.bslli_si128(x567, sizeof(ushort)), x34.y, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort3 x012, ushort3 x345, ushort2 x67)
        {
            this = new ushort8((ushort4)X86.Sse2.insert_epi16(x012, x345.x, 3),
                               (ushort4)X86.Sse2.unpacklo_epi32(X86.Sse2.bsrli_si128(x345, sizeof(ushort)), x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort4 x0123, ushort2 x45, ushort2 x67)
        {
            this = new ushort8(x0123, new ushort4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort2 x01, ushort4 x2345, ushort2 x67)
        {
            this = new ushort8((ushort4)X86.Sse2.unpacklo_epi32(x01,   x2345),
                               (ushort4)X86.Sse2.unpacklo_epi32(X86.Sse2.bsrli_si128(x2345, 2 * sizeof(ushort)), x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort2 x01, ushort2 x23, ushort4 x4567)
        {
            this = new ushort8(new ushort4(x01, x23), x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort4 x0123, ushort4 x4567)
        {
            this = X86.Sse2.unpacklo_epi64(x0123, x4567);
        }


        public ushort4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; } 
        public ushort4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 3,  4, 5,  6, 7,  8, 9,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public ushort4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 2, 1)); } 
        public ushort4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(6, 7,  8, 9,  10, 11,  12, 13,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public ushort4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 3, 2)); } 
                                                                               
        public ushort3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public ushort3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 3,  4, 5,  6, 7,  8, 9,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public ushort3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 2, 1)); } 
        public ushort3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(6, 7,  8, 9,  10, 11,  12, 13,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public ushort3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 3, 2)); } 
        public ushort3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(10, 11,  12, 13,  14, 15,  15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
                                                                             
        public ushort2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public ushort2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 3,  4, 5,  6, 7,  8, 9,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public ushort2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 2, 1)); } 
        public ushort2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(6, 7,  8, 9,  10, 11,  12, 13,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public ushort2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 3, 2)); } 
        public ushort2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(10, 11,  12, 13,  14, 15,  15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public ushort2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 0, 3)); }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   X86.Sse4_1.stream_load_si128(void* ptr)   X86.Sse.load_ps(void* ptr)
        public static implicit operator v128(ushort8 input) => new v128(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   X86.Sse.store_ps(void* ptr, v128 x)
        public static implicit operator ushort8(v128 input) => new ushort8 { x0 = input.UShort0, x1 = input.UShort1, x2 = input.UShort2, x3 = input.UShort3, x4 = input.UShort4, x5 = input.UShort5, x6 = input.UShort6, x7 = input.UShort7 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort8(ushort input) => new ushort8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(short8 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(uint8 input) => Cast.Int8ToShort8(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(int8 input) => Cast.Int8ToShort8(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(float8 input) => (ushort8)(int8)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint8(ushort8 input) => X86.Avx2.mm256_cvtepu16_epi32(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(ushort8 input) => X86.Avx2.mm256_cvtepu16_epi32(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(ushort8 input) => (float8)(int8)input;


        public ushort this[[AssumeRange(0, 7)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 8);
                
                fixed (void* ptr = &this)
                {
                    return ((ushort*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                fixed (void* ptr = &this)
                {
                    ((ushort*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator + (ushort8 lhs, ushort8 rhs) => X86.Sse2.add_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator - (ushort8 lhs, ushort8 rhs) => X86.Sse2.sub_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator * (ushort8 lhs, ushort8 rhs) => X86.Sse2.mullo_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator / (ushort8 lhs, ushort8 rhs) => new ushort8((ushort)(lhs.x0 / rhs.x0),    (ushort)(lhs.x1 / rhs.x1),    (ushort)(lhs.x2 / rhs.x2),    (ushort)(lhs.x3 / rhs.x3),    (ushort)(lhs.x4 / rhs.x4),    (ushort)(lhs.x5 / rhs.x5),    (ushort)(lhs.x6 / rhs.x6),    (ushort)(lhs.x7 / rhs.x7));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator % (ushort8 lhs, ushort8 rhs) => new ushort8((ushort)(lhs.x0 % rhs.x0),    (ushort)(lhs.x1 % rhs.x1),    (ushort)(lhs.x2 % rhs.x2),    (ushort)(lhs.x3 % rhs.x3),    (ushort)(lhs.x4 % rhs.x4),    (ushort)(lhs.x5 % rhs.x5),    (ushort)(lhs.x6 % rhs.x6),    (ushort)(lhs.x7 % rhs.x7));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator / (ushort8 lhs, ushort rhs) => (v128)maxmath.idiv((v128)lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator % (ushort8 lhs, ushort rhs) => throw new NotImplementedException();

    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator & (ushort8 lhs, ushort8 rhs) => X86.Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator | (ushort8 lhs, ushort8 rhs) => X86.Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator ^ (ushort8 lhs, ushort8 rhs) => X86.Sse2.xor_si128(lhs, rhs);
    

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator ++ (ushort8 x) => X86.Sse2.add_epi16(x, new v128((ushort)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator -- (ushort8 x) => X86.Sse2.sub_epi16(x, new v128((ushort)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator ~ (ushort8 x) => X86.Sse2.andnot_si128(x, new v128((short)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator << (ushort8 x, int n) => Operator.shl_short(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator >> (ushort8 x, int n) => Operator.shrl_short(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator == (ushort8 lhs, ushort8 rhs) => TestIsTrue(X86.Sse2.cmpeq_epi16(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator < (ushort8 lhs, ushort8 rhs) => (int8)lhs < (int8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator > (ushort8 lhs, ushort8 rhs) => (int8)lhs > (int8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator != (ushort8 lhs, ushort8 rhs) => TestIsFalse(X86.Sse2.cmpeq_epi16(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator <= (ushort8 lhs, ushort8 rhs) => (int8)lhs <= (int8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator >= (ushort8 lhs, ushort8 rhs) => (int8)lhs >= (int8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4x2 TestIsTrue(v128 input)
        {
            long result = 0x0101_0101_0101_0101L & X86.Sse4_1.extract_epi64((byte8)(ushort8)input, 0);

            return *(bool4x2*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4x2 TestIsFalse(v128 input)
        {
            long result = maxmath.andn(0x0101_0101_0101_0101L, X86.Sse4_1.extract_epi64((byte8)(ushort8)input, 0));

            return *(bool4x2*)&result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ushort8 other) => maxmath.cvt_boolean(X86.Sse4_1.test_all_ones(X86.Sse2.cmpeq_epi16(this, other)));

        public override bool Equals(object obj) => Equals((ushort8)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash._128bit(this);


        public override string ToString() => $"ushort8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
    }
}