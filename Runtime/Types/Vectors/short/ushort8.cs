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
    unsafe public struct ushort8 : IEquatable<ushort8>, IFormattable
    {
        [NoAlias] public ushort x0;
        [NoAlias] public ushort x1;
        [NoAlias] public ushort x2;
        [NoAlias] public ushort x3;
        [NoAlias] public ushort x4;
        [NoAlias] public ushort x5;
        [NoAlias] public ushort x6;
        [NoAlias] public ushort x7;


        public static ushort8 zero => default(ushort8);


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


        public ushort4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this;                  set => this = Sse4_1.insert_epi64(this, *(long*)&value, 0); } 
        public ushort4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 1); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 1 * sizeof(ushort)), 0b0001_1110); }
        public ushort4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 2); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 2 * sizeof(ushort)), 0b0011_1100); }
        public ushort4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 3); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 3 * sizeof(ushort)), 0b0111_1000); }
        public ushort4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 4); set => this = Sse4_1.insert_epi64(this, *(long*)&value, 1); }

        public ushort3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this;                  set => this = Sse4_1.blend_epi16(this, value, 0b0000_0111); }             
        public ushort3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 1); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 1 * sizeof(ushort)), 0b0000_1110); }
        public ushort3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 2); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 2 * sizeof(ushort)), 0b0001_1100); }
        public ushort3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 3); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 3 * sizeof(ushort)), 0b0011_1000); }
        public ushort3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 4); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 4 * sizeof(ushort)), 0b0111_0000); }
        public ushort3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 5); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 5 * sizeof(ushort)), 0b1110_0000); } 
                                                                                                                                                                                               
        public ushort2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this;                  set => this = Sse4_1.insert_epi32(this, *(int*)&value, 0); }
        public ushort2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 1); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 1 * sizeof(ushort)), 0b0000_0110); }
        public ushort2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 2); set => this = Sse4_1.insert_epi32(this, *(int*)&value, 1); }
        public ushort2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 3); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 3 * sizeof(ushort)), 0b0001_1000); }
        public ushort2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 4); set => this = Sse4_1.insert_epi32(this, *(int*)&value, 2); }
        public ushort2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 5); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 5 * sizeof(ushort)), 0b0110_0000); } 
        public ushort2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 6); set => this = Sse4_1.insert_epi32(this, *(int*)&value, 3); }


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
        public static explicit operator ushort8(half8 input) => (ushort8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(float8 input) => (ushort8)(int8)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint8(ushort8 input) => Avx2.mm256_cvtepu16_epi32(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(ushort8 input) => Avx2.mm256_cvtepu16_epi32(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(ushort8 input) => (half8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(ushort8 input) => Cast.UShort8ToFloat8(input);


        public ushort this[int index]
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
        public static ushort8 operator + (ushort8 left, ushort8 right) => Sse2.add_epi16(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator - (ushort8 left, ushort8 right) => Sse2.sub_epi16(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator * (ushort8 left, ushort8 right) => Sse2.mullo_epi16(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator / (ushort8 left, ushort8 right) => Operator.vdiv_ushort(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator % (ushort8 left, ushort8 right) => Operator.vrem_ushort(left, right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator * (ushort left, ushort8 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator * (ushort8 left, ushort right) => new ushort8((ushort)(left.x0 * right), (ushort)(left.x1 * right), (ushort)(left.x2 * right), (ushort)(left.x3 * right), (ushort)(left.x4 * right), (ushort)(left.x5 * right), (ushort)(left.x6 * right), (ushort)(left.x7 * right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator / (ushort8 left, ushort right) => new ushort8((ushort)(left.x0 / right), (ushort)(left.x1 / right), (ushort)(left.x2 / right), (ushort)(left.x3 / right), (ushort)(left.x4 / right), (ushort)(left.x5 / right), (ushort)(left.x6 / right), (ushort)(left.x7 / right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator % (ushort8 left, ushort right) => new ushort8((ushort)(left.x0 % right), (ushort)(left.x1 % right), (ushort)(left.x2 % right), (ushort)(left.x3 % right), (ushort)(left.x4 % right), (ushort)(left.x5 % right), (ushort)(left.x6 % right), (ushort)(left.x7 % right));



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator & (ushort8 left, ushort8 right) => Sse2.and_si128(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator | (ushort8 left, ushort8 right) => Sse2.or_si128(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator ^ (ushort8 left, ushort8 right) => Sse2.xor_si128(left, right);
    

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
        public static bool8 operator == (ushort8 left, ushort8 right) => TestIsTrue(Sse2.cmpeq_epi16(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (ushort8 left, ushort8 right) => TestIsTrue(Operator.greater_mask_ushort(right, left));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (ushort8 left, ushort8 right) => TestIsTrue(Operator.greater_mask_ushort(left, right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (ushort8 left, ushort8 right) => TestIsFalse(Sse2.cmpeq_epi16(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (ushort8 left, ushort8 right) => TestIsFalse(Operator.greater_mask_ushort(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (ushort8 left, ushort8 right) => TestIsFalse(Operator.greater_mask_ushort(right, left));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsTrue(v128 input)
        {
            return Sse2.and_si128((byte8)(ushort8)input, new v128(0x0101_0101));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsFalse(v128 input)
        {
            return Sse2.andnot_si128((byte8)(ushort8)input, new v128(0x0101_0101));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ushort8 other) => maxmath.bitmask32(8 * sizeof(short)) == Sse2.movemask_epi8(Sse2.cmpeq_epi16(this, other));

        public override bool Equals(object obj) => Equals((ushort8)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v128(this);


        public override string ToString() => $"ushort8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ushort8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}