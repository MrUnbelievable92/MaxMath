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
    unsafe public struct short8 : IEquatable<short8>, IFormattable
    {
        [NoAlias] public short x0;
        [NoAlias] public short x1;
        [NoAlias] public short x2;
        [NoAlias] public short x3;
        [NoAlias] public short x4;
        [NoAlias] public short x5;
        [NoAlias] public short x6;
        [NoAlias] public short x7;


        public static short8 zero => default(short8);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short x0, short x1, short x2, short x3, short x4, short x5, short x6, short x7)
        {
            this = Sse2.set_epi16(x7, x6, x5, x4, x3, x2, x1, x0);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short x0x8)
        {
            this = Sse2.set1_epi16(x0x8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short2 x01, short2 x23, short2 x45, short2 x67)
        {
            this = new short8(new short4(x01, x23), new short4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short2 x01, short3 x234, short3 x567)
        {
            this = new short8((short4)Sse2.unpacklo_epi32(x01, x234),
                              (short4)Sse2.insert_epi16(Sse2.bslli_si128(x567, sizeof(short)), x234.z, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short3 x012, short2 x34, short3 x567)
        {
            this = new short8((short4)Sse2.insert_epi16(x012, x34.x, 3),
                              (short4)Sse2.insert_epi16(Sse2.bslli_si128(x567, sizeof(short)), x34.y, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short3 x012, short3 x345, short2 x67)
        {
            this = new short8((short4)Sse2.insert_epi16(x012, x345.x, 3),
                              (short4)Sse2.unpacklo_epi32(Sse2.bsrli_si128(x345, sizeof(short)), x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short4 x0123, short2 x45, short2 x67)
        {
            this = new short8(x0123, new short4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short2 x01, short4 x2345, short2 x67)
        {
            this = new short8((short4)Sse2.unpacklo_epi32(x01,   x2345),
                              (short4)Sse2.unpacklo_epi32(Sse2.bsrli_si128(x2345, 2 * sizeof(short)), x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short2 x01, short2 x23, short4 x4567)
        {
            this = new short8(new short4(x01, x23), x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short4 x0123, short4 x4567)
        {
            this = Sse2.unpacklo_epi64(x0123, x4567);
        }


        public short4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this;                  set => this = Sse4_1.insert_epi64(this, *(long*)&value, 0); } 
        public short4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 1); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 1 * sizeof(ushort)), 0b0001_1110); }
        public short4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 2); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 2 * sizeof(ushort)), 0b0011_1100); }
        public short4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 3); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 3 * sizeof(ushort)), 0b0111_1000); }
        public short4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 4); set => this = Sse4_1.insert_epi64(this, *(long*)&value, 1); }
                                                                                 
        public short3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this;                  set => this = Sse4_1.blend_epi16(this, value, 0b0000_0111); }             
        public short3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 1); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 1 * sizeof(ushort)), 0b0000_1110); }
        public short3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 2); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 2 * sizeof(ushort)), 0b0001_1100); }
        public short3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 3); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 3 * sizeof(ushort)), 0b0011_1000); }
        public short3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 4); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 4 * sizeof(ushort)), 0b0111_0000); }
        public short3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 5); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 5 * sizeof(ushort)), 0b1110_0000); }
                                                                                                                                                                                              
        public short2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this;                  set => this = Sse4_1.insert_epi32(this, *(int*)&value, 0); }
        public short2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 1); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 1 * sizeof(ushort)), 0b0000_0110); }
        public short2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 2); set => this = Sse4_1.insert_epi32(this, *(int*)&value, 1); }
        public short2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 3); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 3 * sizeof(ushort)), 0b0001_1000); }
        public short2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 4); set => this = Sse4_1.insert_epi32(this, *(int*)&value, 2); }
        public short2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 5); set => this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 5 * sizeof(ushort)), 0b0110_0000); } 
        public short2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 6); set => this = Sse4_1.insert_epi32(this, *(int*)&value, 3); }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse2.load(u)_[...].
        public static implicit operator v128(short8 input) => new v128(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v128 x)
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
        public static explicit operator uint8(short8 input) => Avx2.mm256_cvtepi16_epi32(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(short8 input) => Avx2.mm256_cvtepi16_epi32(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(short8 input) => (float8)(int8)input;


        public short this[int index]
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
        public static short8 operator + (short8 left, short8 right) => Sse2.add_epi16(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (short8 left, short8 right) => Sse2.sub_epi16(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (short8 left, short8 right) => Sse2.mullo_epi16(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator / (short8 left, short8 right) => Operator.vdiv_short(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator % (short8 left, short8 right) => Operator.vrem_short(left, right); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (short left, short8 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (short8 left, short right) => new short8((short)(left.x0 * right), (short)(left.x1 * right), (short)(left.x2 * right), (short)(left.x3 * right), (short)(left.x4 * right), (short)(left.x5 * right), (short)(left.x6 * right), (short)(left.x7 * right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator / (short8 left, short right) => new short8((short)(left.x0 / right), (short)(left.x1 / right), (short)(left.x2 / right), (short)(left.x3 / right), (short)(left.x4 / right), (short)(left.x5 / right), (short)(left.x6 / right), (short)(left.x7 / right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator % (short8 left, short right) => new short8((short)(left.x0 % right), (short)(left.x1 % right), (short)(left.x2 % right), (short)(left.x3 % right), (short)(left.x4 % right), (short)(left.x5 % right), (short)(left.x6 % right), (short)(left.x7 % right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator & (short8 left, short8 right) => Sse2.and_si128(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator | (short8 left, short8 right) => Sse2.or_si128(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ^ (short8 left, short8 right) => Sse2.xor_si128(left, right);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (short8 x) => Ssse3.sign_epi16(x, new v128((short)-1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ++ (short8 x) => Sse2.add_epi16(x, new v128((short)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator -- (short8 x) => Sse2.sub_epi16(x, new v128((short)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ~ (short8 x) => Sse2.andnot_si128(x, new v128((short)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator << (short8 x, int n) => Operator.shl_short(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator >> (short8 x, int n) => Operator.shra_short(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (short8 left, short8 right) => TestIsTrue(Sse2.cmpeq_epi16(left, right));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (short8 left, short8 right) => TestIsTrue(Sse2.cmpgt_epi16(right, left));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (short8 left, short8 right) => TestIsTrue(Sse2.cmpgt_epi16(left, right));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (short8 left, short8 right) => TestIsFalse(Sse2.cmpeq_epi16(left, right));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (short8 left, short8 right) => TestIsFalse(Sse2.cmpgt_epi16(left, right));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (short8 left, short8 right) => TestIsFalse(Sse2.cmpgt_epi16(right, left));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsTrue(v128 input)
        {
            return Sse2.and_si128((byte8)(short8)input, new v128(0x0101_0101));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsFalse(v128 input)
        {
            return Sse2.andnot_si128((byte8)(short8)input, new v128(0x0101_0101));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(short8 other) => maxmath.bitmask32(8 * sizeof(short)) == Sse2.movemask_epi8(Sse2.cmpeq_epi16(this, other));

        public override bool Equals(object obj) => Equals((short8)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v128(this);


        public override string ToString() => $"short8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public string ToString(string format, IFormatProvider formatProvider) => $"short8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}