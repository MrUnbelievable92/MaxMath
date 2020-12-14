using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Sequential, Size = 32)]
    unsafe public struct byte32 : IEquatable<byte32>, IFormattable
    {
        [NoAlias] public byte x0;
        [NoAlias] public byte x1;
        [NoAlias] public byte x2;
        [NoAlias] public byte x3;
        [NoAlias] public byte x4;
        [NoAlias] public byte x5;
        [NoAlias] public byte x6;
        [NoAlias] public byte x7;
        [NoAlias] public byte x8;
        [NoAlias] public byte x9;
        [NoAlias] public byte x10;
        [NoAlias] public byte x11;
        [NoAlias] public byte x12;
        [NoAlias] public byte x13;
        [NoAlias] public byte x14;
        [NoAlias] public byte x15;
        [NoAlias] public byte x16;
        [NoAlias] public byte x17;
        [NoAlias] public byte x18;
        [NoAlias] public byte x19;
        [NoAlias] public byte x20;
        [NoAlias] public byte x21;
        [NoAlias] public byte x22;
        [NoAlias] public byte x23;
        [NoAlias] public byte x24;
        [NoAlias] public byte x25;
        [NoAlias] public byte x26;
        [NoAlias] public byte x27;
        [NoAlias] public byte x28;
        [NoAlias] public byte x29;
        [NoAlias] public byte x30;
        [NoAlias] public byte x31;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7, byte x8, byte x9, byte x10, byte x11, byte x12, byte x13, byte x14, byte x15, byte x16, byte x17, byte x18, byte x19, byte x20, byte x21, byte x22, byte x23, byte x24, byte x25, byte x26, byte x27, byte x28, byte x29, byte x30, byte x31)
        {
            this = Avx.mm256_set_epi8(x31, x30, x29, x28, x27, x26, x25, x24, x23, x22, x21, x20, x19, x18, x17, x16, x15, x14, x13, x12, x11, x10, x9, x8, x7, x6, x5, x4, x3, x2, x1, x0);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte x0x32)
        {
            this = new v256(x0x32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte8 v8_0, byte8 v8_1, byte8 v8_2, byte8 v8_3)
        {
            this = new byte32(new byte16(v8_0, v8_1), new byte16(v8_2, v8_3));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte16 v16_0, byte16 v16_1)
        {
            this = Avx.mm256_set_m128i(v16_1, v16_0);
        }


















        public byte16 v16_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(this); }







        public byte16 v16_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_extracti128_si256(this, 1); }















        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v256(byte32 input) => new v256(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7, input.x8, input.x9, input.x10, input.x11, input.x12, input.x13, input.x14, input.x15, input.x16, input.x17, input.x18, input.x19, input.x20, input.x21, input.x22, input.x23, input.x24, input.x25, input.x26, input.x27, input.x28, input.x29, input.x30, input.x31);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v256 x)
        public static implicit operator byte32(v256 input) => new byte32 { x0 = input.Byte0, x1 = input.Byte1, x2 = input.Byte2, x3 = input.Byte3, x4 = input.Byte4, x5 = input.Byte5, x6 = input.Byte6, x7 = input.Byte7, x8 = input.Byte8, x9 = input.Byte9, x10 = input.Byte10, x11 = input.Byte11, x12 = input.Byte12, x13 = input.Byte13, x14 = input.Byte14, x15 = input.Byte15, x16 = input.Byte16, x17 = input.Byte17, x18 = input.Byte18, x19 = input.Byte19, x20 = input.Byte20, x21 = input.Byte21, x22 = input.Byte22, x23 = input.Byte23, x24 = input.Byte24, x25 = input.Byte25, x26 = input.Byte26, x27 = input.Byte27, x28 = input.Byte28, x29 = input.Byte29, x30 = input.Byte30, x31 = input.Byte31 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte32(byte input) => new byte32(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(sbyte32 input) => (v256)input;


        public byte this[[AssumeRange(0, 31)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 32);
                
                fixed (void* ptr = &this)
                {
                    return ((byte*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 32);

                fixed (void* ptr = &this)
                {
                    ((byte*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator + (byte32 lhs, byte32 rhs) => Avx2.mm256_add_epi8(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator - (byte32 lhs, byte32 rhs) => Avx2.mm256_sub_epi8(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator * (byte32 lhs, byte32 rhs) => Operator.mul_byte(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator / (byte32 lhs, byte32 rhs) => Operator.vdiv_byte(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator % (byte32 lhs, byte32 rhs) => Operator.vrem_byte(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator / (byte32 lhs, byte rhs) => Operator.div(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator % (byte32 lhs, byte rhs) => Operator.rem(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator & (byte32 lhs, byte32 rhs) => Avx2.mm256_and_si256(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator | (byte32 lhs, byte32 rhs) => Avx2.mm256_or_si256(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator ^ (byte32 lhs, byte32 rhs) => Avx2.mm256_xor_si256(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator ++ (byte32 x) => Avx2.mm256_add_epi8(x, new v256((byte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator -- (byte32 x) => Avx2.mm256_sub_epi8(x, new v256((byte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator ~ (byte32 x) => Avx2.mm256_andnot_si256(x, new v256((sbyte)-1));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator << (byte32 x, int n) => Operator.shl_byte(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator >> (byte32 x, int n) => Operator.shrl_byte(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (byte32 lhs, byte32 rhs) => TestIsTrue(Avx2.mm256_cmpeq_epi8(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator < (byte32 lhs, byte32 rhs) => TestIsTrue(Operator.greater_mask_byte(rhs, lhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator > (byte32 lhs, byte32 rhs) => TestIsTrue(Operator.greater_mask_byte(lhs, rhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (byte32 lhs, byte32 rhs) => TestIsFalse(Avx2.mm256_cmpeq_epi8(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator <= (byte32 lhs, byte32 rhs) => TestIsFalse(Operator.greater_mask_byte(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator >= (byte32 lhs, byte32 rhs) => TestIsFalse(Operator.greater_mask_byte(rhs, lhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool32 TestIsTrue(v256 input)
        {
            return Avx2.mm256_and_si256(input, new v256((byte)1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool32 TestIsFalse(v256 input)
        {
            return Avx2.mm256_andnot_si256(input, new v256((byte)1));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(byte32 other) => maxmath.tobool(Avx.mm256_testc_si256(Avx2.mm256_cmpeq_epi8(this, other), new v256(-1)));

        public override bool Equals(object obj) => Equals((byte32)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v256(this);


        public override string ToString() =>  $"byte32({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15},    {x16}, {x17}, {x18}, {x19},    {x20}, {x21}, {x22}, {x23},    {x24}, {x25}, {x26}, {x27},    {x28}, {x29}, {x30}, {x31})";
        public string ToString(string format, IFormatProvider formatProvider) => $"byte32({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)},    {x8.ToString(format, formatProvider)}, {x9.ToString(format, formatProvider)}, {x10.ToString(format, formatProvider)}, {x11.ToString(format, formatProvider)},    {x12.ToString(format, formatProvider)}, {x13.ToString(format, formatProvider)}, {x14.ToString(format, formatProvider)}, {x15.ToString(format, formatProvider)},    {x16.ToString(format, formatProvider)}, {x17.ToString(format, formatProvider)}, {x18.ToString(format, formatProvider)}, {x19.ToString(format, formatProvider)},    {x20.ToString(format, formatProvider)}, {x21.ToString(format, formatProvider)}, {x22.ToString(format, formatProvider)}, {x23.ToString(format, formatProvider)},    {x24.ToString(format, formatProvider)}, {x25.ToString(format, formatProvider)}, {x26.ToString(format, formatProvider)}, {x27.ToString(format, formatProvider)},    {x28.ToString(format, formatProvider)}, {x29.ToString(format, formatProvider)}, {x30.ToString(format, formatProvider)}, {x31.ToString(format, formatProvider)})";
    }
}