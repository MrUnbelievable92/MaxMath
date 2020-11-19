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
    unsafe public struct short8 : IEquatable<short8>
    {
        [NoAlias] [FieldOffset(0)]  public short x0;
        [NoAlias] [FieldOffset(2)]  public short x1;
        [NoAlias] [FieldOffset(4)]  public short x2;
        [NoAlias] [FieldOffset(6)]  public short x3;
        [NoAlias] [FieldOffset(8)]  public short x4;
        [NoAlias] [FieldOffset(10)] public short x5;
        [NoAlias] [FieldOffset(12)] public short x6;
        [NoAlias] [FieldOffset(14)] public short x7;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short x0, short x1, short x2, short x3, short x4, short x5, short x6, short x7)
        {
            this = X86.Sse2.set_epi16(x7, x6, x5, x4, x3, x2, x1, x0);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short x0x8)
        {
            this = X86.Sse2.set1_epi16(x0x8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short2 x01, short2 x23, short2 x45, short2 x67)
        {
            this = new short8(new short4(x01, x23), new short4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short2 x01, short3 x234, short3 x567)
        {
            this = new short8((short4)X86.Sse2.unpacklo_epi32(x01, x234),
                              (short4)X86.Sse2.insert_epi16(X86.Sse2.bslli_si128(x567, sizeof(short)), x234.z, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short3 x012, short2 x34, short3 x567)
        {
            this = new short8((short4)X86.Sse2.insert_epi16(x012, x34.x, 3),
                              (short4)X86.Sse2.insert_epi16(X86.Sse2.bslli_si128(x567, sizeof(short)), x34.y, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short3 x012, short3 x345, short2 x67)
        {
            this = new short8((short4)X86.Sse2.insert_epi16(x012, x345.x, 3),
                              (short4)X86.Sse2.unpacklo_epi32(X86.Sse2.bsrli_si128(x345, sizeof(short)), x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short4 x0123, short2 x45, short2 x67)
        {
            this = new short8(x0123, new short4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short2 x01, short4 x2345, short2 x67)
        {
            this = new short8((short4)X86.Sse2.unpacklo_epi32(x01,   x2345),
                              (short4)X86.Sse2.unpacklo_epi32(X86.Sse2.bsrli_si128(x2345, 2 * sizeof(short)), x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short2 x01, short2 x23, short4 x4567)
        {
            this = new short8(new short4(x01, x23), x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short4 x0123, short4 x4567)
        {
            this = X86.Sse2.unpacklo_epi64(x0123, x4567);
        }


        public short4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; } 
        public short4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 3,  4, 5,  6, 7,  8, 9,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public short4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 2, 1)); } 
        public short4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(6, 7,  8, 9,  10, 11,  12, 13,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public short4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 3, 2)); } 
                                                                                    
        public short3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public short3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 3,  4, 5,  6, 7,  8, 9,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public short3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 2, 1)); } 
        public short3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(6, 7,  8, 9,  10, 11,  12, 13,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public short3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 3, 2)); } 
        public short3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(10, 11,  12, 13,  14, 15,  15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
                                                                                   
        public short2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public short2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 3,  4, 5,  6, 7,  8, 9,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public short2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 2, 1)); } 
        public short2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(6, 7,  8, 9,  10, 11,  12, 13,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public short2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 3, 2)); } 
        public short2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(10, 11,  12, 13,  14, 15,  15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public short2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 0, 3)); }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   X86.Sse4_1.stream_load_si128(void* ptr)   X86.Sse2.load(u)_[...].
        public static implicit operator v128(short8 input) => new v128(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   X86.Sse.store_ps(void* ptr, v128 x)
        public static implicit operator short8(v128 input) => new short8 { x0 = input.SShort0, x1 = input.SShort1, x2 = input.SShort2, x3 = input.SShort3, x4 = input.SShort4, x5 = input.SShort5, x6 = input.SShort6, x7 = input.SShort7 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short8(short input) => new short8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(ushort8 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(uint8 input) => Cast.Int8ToShort8(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(int8 input) => Cast.Int8ToShort8(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(float8 input) => (short8)(int8)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(short8 input) => X86.Avx2.mm256_cvtepi16_epi32(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(short8 input) => X86.Avx2.mm256_cvtepi16_epi32(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(short8 input) => (float8)(int8)input;


        public short this[[AssumeRange(0, 7)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 8);
                
                fixed (void* ptr = &this)
                {
                    return ((short*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                fixed (void* ptr = &this)
                {
                    ((short*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator + (short8 lhs, short8 rhs) => X86.Sse2.add_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (short8 lhs, short8 rhs) => X86.Sse2.sub_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (short8 lhs, short8 rhs) => X86.Sse2.mullo_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator / (short8 lhs, short8 rhs) => new short8((short)(lhs.x0 / rhs.x0),    (short)(lhs.x1 / rhs.x1),    (short)(lhs.x2 / rhs.x2),    (short)(lhs.x3 / rhs.x3),    (short)(lhs.x4 / rhs.x4),    (short)(lhs.x5 / rhs.x5),    (short)(lhs.x6 / rhs.x6),    (short)(lhs.x7 / rhs.x7));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator % (short8 lhs, short8 rhs) => new short8((short)(lhs.x0 % rhs.x0),    (short)(lhs.x1 % rhs.x1),    (short)(lhs.x2 % rhs.x2),    (short)(lhs.x3 % rhs.x3),    (short)(lhs.x4 % rhs.x4),    (short)(lhs.x5 % rhs.x5),    (short)(lhs.x6 % rhs.x6),    (short)(lhs.x7 % rhs.x7));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator & (short8 lhs, short8 rhs) => X86.Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator | (short8 lhs, short8 rhs) => X86.Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ^ (short8 lhs, short8 rhs) => X86.Sse2.xor_si128(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (short8 x) => X86.Ssse3.sign_epi16(x, new v128((short)-1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ++ (short8 x) => X86.Sse2.add_epi16(x, new v128((short)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator -- (short8 x) => X86.Sse2.sub_epi16(x, new v128((short)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ~ (short8 x) => X86.Sse2.andnot_si128(x, new v128((short)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator << (short8 x, int n) => Operator.shl_short(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator >> (short8 x, int n) => Operator.shra_short(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator == (short8 lhs, short8 rhs) => TestIsTrue(X86.Sse2.cmpeq_epi16(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator < (short8 lhs, short8 rhs) => TestIsTrue(X86.Sse2.cmpgt_epi16(rhs, lhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator > (short8 lhs, short8 rhs) => TestIsTrue(X86.Sse2.cmpgt_epi16(lhs, rhs));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator != (short8 lhs, short8 rhs) => TestIsFalse(X86.Sse2.cmpeq_epi16(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator <= (short8 lhs, short8 rhs) => TestIsFalse(X86.Sse2.cmpgt_epi16(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator >= (short8 lhs, short8 rhs) => TestIsFalse(X86.Sse2.cmpgt_epi16(rhs, lhs));


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
        public bool Equals(short8 other) => maxmath.cvt_boolean(X86.Sse4_1.test_all_ones(X86.Sse2.cmpeq_epi16(this, other)));

        public override bool Equals(object obj) => Equals((short8)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash._128bit(this);


        public override string ToString() => $"short8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
    }
}