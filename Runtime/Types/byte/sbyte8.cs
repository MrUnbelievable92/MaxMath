using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Explicit, Size = 8)]
    unsafe public struct sbyte8 : IEquatable<sbyte8>, IFormattable
    {
        [FieldOffset(0)] internal long cast_long;

        [FieldOffset(0)] public sbyte x0;
        [FieldOffset(1)] public sbyte x1;
        [FieldOffset(2)] public sbyte x2;
        [FieldOffset(3)] public sbyte x3;
        [FieldOffset(4)] public sbyte x4;
        [FieldOffset(5)] public sbyte x5;
        [FieldOffset(6)] public sbyte x6;
        [FieldOffset(7)] public sbyte x7;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte x0, sbyte x1, sbyte x2, sbyte x3, sbyte x4, sbyte x5, sbyte x6, sbyte x7)
        {
            this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, x7, x6, x5, x4, x3, x2, x1, x0);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte x0x8)
        {
            this = Sse2.set1_epi8(x0x8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte2 x01, sbyte2 x23, sbyte2 x45, sbyte2 x67)
        {
            this = new sbyte8(new sbyte4(x01, x23), new sbyte4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte2 x01, sbyte3 x234, sbyte3 x567)
        {
            this = new sbyte8((sbyte4)Sse2.unpacklo_epi16(x01, x234),
                              (sbyte4)Sse4_1.insert_epi8(Sse2.bslli_si128(x567, sizeof(sbyte)), (byte)x234.z, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte3 x012, sbyte2 x34, sbyte3 x567)
        {
            this = new sbyte8((sbyte4)Sse4_1.insert_epi8(x012, (byte)x34.x, 3),
                              (sbyte4)Sse4_1.insert_epi8(Sse2.bslli_si128(x567, sizeof(sbyte)), (byte)x34.y, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte3 x012, sbyte3 x345, sbyte2 x67)
        {
            this = new sbyte8((sbyte4)Sse4_1.insert_epi8(x012, (byte)x345.x, 3),
                              (sbyte4)Sse2.unpacklo_epi16(Sse2.bsrli_si128(x345, sizeof(sbyte)), x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte4 x0123, sbyte2 x45, sbyte2 x67)
        {
            this = new sbyte8(x0123, new sbyte4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte2 x01, sbyte4 x2345, sbyte2 x67)
        {
            this = new sbyte8((sbyte4)Sse2.unpacklo_epi16(x01, x2345),
                              (sbyte4)Sse2.unpacklo_epi16(Sse2.bsrli_si128(x2345, 2 * sizeof(sbyte)), x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte2 x01, sbyte2 x23, sbyte4 x4567)
        {
            this = new sbyte8(new sbyte4(x01, x23), x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte4 x0123, sbyte4 x4567)
        {
            this = Sse2.unpacklo_epi32(x0123, x4567);
        }


        public sbyte4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public sbyte4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 4,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); } 
        public sbyte4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 1)); }
        public sbyte4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 4, 5, 6,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 2)); }
                                                                                  
        public sbyte3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public sbyte3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 4,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 1)); }
        public sbyte3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 4, 5, 6,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 2)); }
        public sbyte3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(5, 6, 7, 8,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
                                                                   
        public sbyte2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public sbyte2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 4,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 1)); }
        public sbyte2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 4, 5, 6,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 2)); }
        public sbyte2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(5, 6, 7, 8,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 3)); }


        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static implicit operator v128(sbyte8 input) => Sse4_1.insert_epi64(default(v128), input.cast_long, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static implicit operator sbyte8(v128 input) => new sbyte8 { cast_long = Sse4_1.extract_epi64(input, 0) };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte8(sbyte input) => new sbyte8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte8(byte8 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte8(short8 input) => Cast.ShortToByte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte8(ushort8 input) => Cast.ShortToByte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte8(uint8 input) => Cast.Int8ToByte8(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte8(int8 input) => Cast.Int8ToByte8(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte8(float8 input) => (sbyte8)(int8)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short8(sbyte8 input) => Sse4_1.cvtepi8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(sbyte8 input) => Sse4_1.cvtepi8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(sbyte8 input) => Avx2.mm256_cvtepi8_epi32(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(sbyte8 input) => Avx2.mm256_cvtepi8_epi32(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(sbyte8 input) => (float8)(int8)input;


        public sbyte this[[AssumeRange(0, 7)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 8);
                
                fixed (void* ptr = &this)
                {
                    return ((sbyte*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                fixed (void* ptr = &this)
                {
                    ((sbyte*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator + (sbyte8 lhs, sbyte8 rhs) => Sse2.add_epi8(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator - (sbyte8 lhs, sbyte8 rhs) => Sse2.sub_epi8(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator * (sbyte8 lhs, sbyte8 rhs) => (sbyte8)((short8)lhs * (short8)rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator / (sbyte8 lhs, sbyte8 rhs)
        {
#if UNITY_EDITOR
            return (v128)Operator.vdiv_sbyte((v128)lhs, new sbyte16(rhs, new sbyte8(1)));
#else
            return (v128)Operator.vdiv_byte((v128)lhs, (v128)rhs);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator % (sbyte8 lhs, sbyte8 rhs)
        {
#if UNITY_EDITOR
            return (v128)Operator.vrem_sbyte((v128)lhs, new sbyte16(rhs, new sbyte8(1)));
#else
            return (v128)Operator.vrem_byte((v128)lhs, (v128)rhs);
#endif
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator & (sbyte8 lhs, sbyte8 rhs) => Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator | (sbyte8 lhs, sbyte8 rhs) => Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator ^ (sbyte8 lhs, sbyte8 rhs) => Sse2.xor_si128(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator - (sbyte8 x) => Ssse3.sign_epi8(x, new v128((sbyte)-1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator ++ (sbyte8 x) => Sse2.add_epi8(x, new v128((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator -- (sbyte8 x) => Sse2.sub_epi8(x, new v128((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator ~ (sbyte8 x) => Sse2.andnot_si128(x, new v128((sbyte)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator << (sbyte8 x, int n) => Operator.shl_byte(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator >> (sbyte8 x, int n) => (sbyte8)((short8)x >> n);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (sbyte8 lhs, sbyte8 rhs) => TestIsTrue(Sse2.cmpeq_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (sbyte8 lhs, sbyte8 rhs) => TestIsTrue(Sse2.cmpgt_epi8(rhs, lhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (sbyte8 lhs, sbyte8 rhs) => TestIsTrue(Sse2.cmpgt_epi8(lhs, rhs));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (sbyte8 lhs, sbyte8 rhs) => TestIsFalse(Sse2.cmpeq_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (sbyte8 lhs, sbyte8 rhs) => TestIsFalse(Sse2.cmpgt_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (sbyte8 lhs, sbyte8 rhs) => TestIsFalse(Sse2.cmpgt_epi8(rhs, lhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsTrue(v128 input)
        {
            return Sse2.and_si128(input, new v128((sbyte)1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsFalse(v128 input)
        {
            return Sse2.andnot_si128(input, new v128((sbyte)1));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(sbyte8 other) => maxmath.tobool(Sse4_1.testc_si128(Sse2.cmpeq_epi8(this, other), new v128(-1L, 0L)));

        public override bool Equals(object obj) => Equals((sbyte8)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v64(this);


        public override string ToString() => $"sbyte8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public string ToString(string format, IFormatProvider formatProvider) => $"sbyte8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}