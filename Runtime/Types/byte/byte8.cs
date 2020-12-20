using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Explicit, Size = 8)]
    unsafe public struct byte8 : IEquatable<byte8>, IFormattable
    {
        [FieldOffset(0)] internal long cast_long;

        [FieldOffset(0)] public byte x0;
        [FieldOffset(1)] public byte x1;
        [FieldOffset(2)] public byte x2;
        [FieldOffset(3)] public byte x3;
        [FieldOffset(4)] public byte x4;
        [FieldOffset(5)] public byte x5;
        [FieldOffset(6)] public byte x6;
        [FieldOffset(7)] public byte x7;


        public static byte8 zero => default(byte8);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte8(byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7)
        {
            this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, (sbyte)x7, (sbyte)x6, (sbyte)x5, (sbyte)x4, (sbyte)x3, (sbyte)x2, (sbyte)x1, (sbyte)x0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte8(byte x0x8)
        {
            this = Sse2.set1_epi8((sbyte)x0x8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte8(byte2 x01, byte2 x23, byte2 x45, byte2 x67)
        {
            this = new byte8(new byte4(x01, x23), new byte4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte8(byte2 x01, byte3 x234, byte3 x567)
        {
            this = new byte8((byte4)Sse2.unpacklo_epi16(x01, x234),
                             (byte4)Sse4_1.insert_epi8(Sse2.bslli_si128(x567, sizeof(byte)), x234.z, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte8(byte3 x012, byte2 x34, byte3 x567)
        {
            this = new byte8((byte4)Sse4_1.insert_epi8(x012, x34.x, 3),
                             (byte4)Sse4_1.insert_epi8(Sse2.bslli_si128(x567, sizeof(byte)), x34.y, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte8(byte3 x012, byte3 x345, byte2 x67)
        {
            this = new byte8((byte4)Sse4_1.insert_epi8(x012, x345.x, 3),
                             (byte4)Sse2.unpacklo_epi16(Sse2.bsrli_si128(x345, sizeof(byte)), x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte8(byte4 x0123, byte2 x45, byte2 x67)
        {
            this = new byte8(x0123, new byte4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte8(byte2 x01, byte4 x2345, byte2 x67)
        {
            this = new byte8((byte4)Sse2.unpacklo_epi16(x01, x2345),
                             (byte4)Sse2.unpacklo_epi16(Sse2.bsrli_si128(x2345, 2 * sizeof(byte)), x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte8(byte2 x01, byte2 x23, byte4 x4567)
        {
            this = new byte8(new byte4(x01, x23), x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte8(byte4 x0123, byte4 x4567)
        {
            this = Sse2.unpacklo_epi32(x0123, x4567);
        }


        public byte4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public byte4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 1)); }
        public byte4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 4, 5, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 2)); }

        public byte3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public byte3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 1)); }
        public byte3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 4, 5, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 2)); }
        public byte3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(5, 6, 7, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }

        public byte2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public byte2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 1)); }
        public byte2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 4, 5, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 2)); }
        public byte2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(5, 6, 7, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 3)); }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(byte8 input) => Sse4_1.insert_epi64(default(v128), input.cast_long, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte8(v128 input) => new byte8{ cast_long = input.SLong0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte8(byte input) => new byte8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(sbyte8 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(ushort8 input) => Cast.ShortToByte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(short8 input) => Cast.ShortToByte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(uint8 input) => Cast.Int8ToByte8(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(int8 input) => Cast.Int8ToByte8(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(float8 input) => (byte8)(int8)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort8(byte8 input) => Sse4_1.cvtepu8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short8(byte8 input) => Sse4_1.cvtepu8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint8(byte8 input) => Avx2.mm256_cvtepu8_epi32(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(byte8 input) => Avx2.mm256_cvtepu8_epi32(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(byte8 input) => (float8)(int8)input;


        public byte this[[AssumeRange(0, 7)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 8);
                
                fixed (void* ptr = &this)
                {
                    return ((byte*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                fixed (void* ptr = &this)
                {
                    ((byte*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator + (byte8 lhs, byte8 rhs) => Sse2.add_epi8(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator - (byte8 lhs, byte8 rhs) => Sse2.sub_epi8(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator * (byte8 lhs, byte8 rhs) => (byte8)((ushort8)lhs * (ushort8)rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator / (byte8 lhs, byte8 rhs) => Operator.vdiv_byte(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator % (byte8 lhs, byte8 rhs) => Operator.vrem_byte(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator * (byte lhs, byte8 rhs) => rhs * lhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator * (byte8 lhs, byte rhs) => (v128)((byte16)((v128)lhs) * rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator / (byte8 lhs, byte rhs) => (v128)((byte16)((v128)lhs) / rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator % (byte8 lhs, byte rhs) => (v128)((byte16)((v128)lhs) % rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator & (byte8 lhs, byte8 rhs) => Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator | (byte8 lhs, byte8 rhs) => Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator ^ (byte8 lhs, byte8 rhs) => Sse2.xor_si128(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator ++ (byte8 x) => Sse2.add_epi8(x, new v128((byte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator -- (byte8 x) => Sse2.sub_epi8(x, new v128((byte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator ~ (byte8 x) => Sse2.andnot_si128(x, new v128((sbyte)-1));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator <<(byte8 x, int n) => Operator.shl_byte(x, n);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator >> (byte8 x, int n) => Operator.shrl_byte(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (byte8 lhs, byte8 rhs) => TestIsTrue(Sse2.cmpeq_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (byte8 lhs, byte8 rhs) => TestIsTrue(Operator.greater_mask_byte(rhs, lhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (byte8 lhs, byte8 rhs) => TestIsTrue(Operator.greater_mask_byte(lhs, rhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (byte8 lhs, byte8 rhs) => TestIsFalse(Sse2.cmpeq_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (byte8 lhs, byte8 rhs) => TestIsFalse(Operator.greater_mask_byte(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (byte8 lhs, byte8 rhs) => TestIsFalse(Operator.greater_mask_byte(rhs, lhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsTrue(v128 input) 
        {
            return Sse2.and_si128(input, new v128(0x0101_0101));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsFalse(v128 input)
        {
            return Sse2.andnot_si128(input, new v128(0x0101_0101));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(byte8 other) => maxmath.bitmask32(8 * sizeof(byte)) == (maxmath.bitmask32(8 * sizeof(byte)) & (Sse2.movemask_epi8(Sse2.cmpeq_epi8(this, other))));

        public override bool Equals(object obj) => Equals((byte8)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v64(this);


        public override string ToString() => $"byte8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public string ToString(string format, IFormatProvider formatProvider) => $"byte8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}