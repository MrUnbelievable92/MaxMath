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
    unsafe public struct ushort8 : IEquatable<ushort8>
    {
        [NoAlias] public ushort x0;
        [NoAlias] public ushort x1;
        [NoAlias] public ushort x2;
        [NoAlias] public ushort x3;
        [NoAlias] public ushort x4;
        [NoAlias] public ushort x5;
        [NoAlias] public ushort x6;
        [NoAlias] public ushort x7;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort x0, ushort x1, ushort x2, ushort x3, ushort x4, ushort x5, ushort x6, ushort x7)
        {
            this = Sse2.set_epi16((short)x7, (short)x6, (short)x5, (short)x4, (short)x3, (short)x2, (short)x1, (short)x0);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort x0x8)
        {
            this = Sse2.set1_epi16((short)x0x8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort2 x01, ushort2 x23, ushort2 x45, ushort2 x67)
        {
            this = new ushort8(new ushort4(x01, x23), new ushort4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort2 x01, ushort3 x234, ushort3 x567)
        {
            this = new ushort8((ushort4)Sse2.unpacklo_epi32(x01, x234),
                               (ushort4)Sse2.insert_epi16(Sse2.bslli_si128(x567, sizeof(ushort)), x234.z, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort3 x012, ushort2 x34, ushort3 x567)
        {
            this = new ushort8((ushort4)Sse2.insert_epi16(x012, x34.x, 3),
                               (ushort4)Sse2.insert_epi16(Sse2.bslli_si128(x567, sizeof(ushort)), x34.y, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort3 x012, ushort3 x345, ushort2 x67)
        {
            this = new ushort8((ushort4)Sse2.insert_epi16(x012, x345.x, 3),
                               (ushort4)Sse2.unpacklo_epi32(Sse2.bsrli_si128(x345, sizeof(ushort)), x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort4 x0123, ushort2 x45, ushort2 x67)
        {
            this = new ushort8(x0123, new ushort4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort2 x01, ushort4 x2345, ushort2 x67)
        {
            this = new ushort8((ushort4)Sse2.unpacklo_epi32(x01,   x2345),
                               (ushort4)Sse2.unpacklo_epi32(Sse2.bsrli_si128(x2345, 2 * sizeof(ushort)), x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort2 x01, ushort2 x23, ushort4 x4567)
        {
            this = new ushort8(new ushort4(x01, x23), x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort4 x0123, ushort4 x4567)
        {
            this = Sse2.unpacklo_epi64(x0123, x4567);
        }


        public ushort4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; } 
        public ushort4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3,  4, 5,  6, 7,  8, 9,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public ushort4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(0, 0, 2, 1)); } 
        public ushort4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(6, 7,  8, 9,  10, 11,  12, 13,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public ushort4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(0, 0, 3, 2)); } 
                                                                               
        public ushort3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public ushort3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3,  4, 5,  6, 7,  8, 9,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public ushort3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(0, 0, 2, 1)); } 
        public ushort3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(6, 7,  8, 9,  10, 11,  12, 13,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public ushort3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(0, 0, 3, 2)); } 
        public ushort3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(10, 11,  12, 13,  14, 15,  15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
                                                                             
        public ushort2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public ushort2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3,  4, 5,  6, 7,  8, 9,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public ushort2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(0, 0, 2, 1)); } 
        public ushort2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(6, 7,  8, 9,  10, 11,  12, 13,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public ushort2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(0, 0, 3, 2)); } 
        public ushort2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(10, 11,  12, 13,  14, 15,  15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public ushort2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(0, 0, 0, 3)); }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v128(ushort8 input) => new v128(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v128 x)
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
        public static implicit operator uint8(ushort8 input) => Avx2.mm256_cvtepu16_epi32(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(ushort8 input) => Avx2.mm256_cvtepu16_epi32(input);

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
        public static ushort8 operator + (ushort8 lhs, ushort8 rhs) => Sse2.add_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator - (ushort8 lhs, ushort8 rhs) => Sse2.sub_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator * (ushort8 lhs, ushort8 rhs) => Sse2.mullo_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator / (ushort8 lhs, ushort8 rhs) => new ushort8((ushort)(lhs.x0 / rhs.x0),    (ushort)(lhs.x1 / rhs.x1),    (ushort)(lhs.x2 / rhs.x2),    (ushort)(lhs.x3 / rhs.x3),    (ushort)(lhs.x4 / rhs.x4),    (ushort)(lhs.x5 / rhs.x5),    (ushort)(lhs.x6 / rhs.x6),    (ushort)(lhs.x7 / rhs.x7));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator % (ushort8 lhs, ushort8 rhs) => new ushort8((ushort)(lhs.x0 % rhs.x0),    (ushort)(lhs.x1 % rhs.x1),    (ushort)(lhs.x2 % rhs.x2),    (ushort)(lhs.x3 % rhs.x3),    (ushort)(lhs.x4 % rhs.x4),    (ushort)(lhs.x5 % rhs.x5),    (ushort)(lhs.x6 % rhs.x6),    (ushort)(lhs.x7 % rhs.x7));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator / (ushort8 lhs, ushort rhs) => Operator.div(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator % (ushort8 lhs, ushort rhs) => Operator.rem(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator & (ushort8 lhs, ushort8 rhs) => Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator | (ushort8 lhs, ushort8 rhs) => Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator ^ (ushort8 lhs, ushort8 rhs) => Sse2.xor_si128(lhs, rhs);
    

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator ++ (ushort8 x) => Sse2.add_epi16(x, new v128((ushort)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator -- (ushort8 x) => Sse2.sub_epi16(x, new v128((ushort)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator ~ (ushort8 x) => Sse2.andnot_si128(x, new v128((short)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator << (ushort8 x, int n) => Operator.shl_short(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator >> (ushort8 x, int n) => Operator.shrl_short(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (ushort8 lhs, ushort8 rhs) => TestIsTrue(Sse2.cmpeq_epi16(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (ushort8 lhs, ushort8 rhs) => (int8)lhs < (int8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (ushort8 lhs, ushort8 rhs) => (int8)lhs > (int8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (ushort8 lhs, ushort8 rhs) => TestIsFalse(Sse2.cmpeq_epi16(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (ushort8 lhs, ushort8 rhs) => (int8)lhs <= (int8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (ushort8 lhs, ushort8 rhs) => (int8)lhs >= (int8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsTrue(v128 input)
        {
            return Sse2.and_si128((byte8)(ushort8)input, new v128(0x0101_0101_0101_0101L, 0L));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsFalse(v128 input)
        {
            return Sse2.andnot_si128((byte8)(ushort8)input, new v128(0x0101_0101_0101_0101L, 0L));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ushort8 other) => maxmath.cvt_boolean(Sse4_1.test_all_ones(Sse2.cmpeq_epi16(this, other)));

        public override bool Equals(object obj) => Equals((ushort8)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash._128bit(this);


        public override string ToString() => $"ushort8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
    }
}