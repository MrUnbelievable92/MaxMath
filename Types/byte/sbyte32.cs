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
    unsafe public struct sbyte32 : IEquatable<sbyte32>
    {
        [NoAlias] public sbyte x0;
        [NoAlias] public sbyte x1;
        [NoAlias] public sbyte x2;
        [NoAlias] public sbyte x3;
        [NoAlias] public sbyte x4;
        [NoAlias] public sbyte x5;
        [NoAlias] public sbyte x6;
        [NoAlias] public sbyte x7;
        [NoAlias] public sbyte x8;
        [NoAlias] public sbyte x9;
        [NoAlias] public sbyte x10;
        [NoAlias] public sbyte x11;
        [NoAlias] public sbyte x12;
        [NoAlias] public sbyte x13;
        [NoAlias] public sbyte x14;
        [NoAlias] public sbyte x15;
        [NoAlias] public sbyte x16;
        [NoAlias] public sbyte x17;
        [NoAlias] public sbyte x18;
        [NoAlias] public sbyte x19;
        [NoAlias] public sbyte x20;
        [NoAlias] public sbyte x21;
        [NoAlias] public sbyte x22;
        [NoAlias] public sbyte x23;
        [NoAlias] public sbyte x24;
        [NoAlias] public sbyte x25;
        [NoAlias] public sbyte x26;
        [NoAlias] public sbyte x27;
        [NoAlias] public sbyte x28;
        [NoAlias] public sbyte x29;
        [NoAlias] public sbyte x30;
        [NoAlias] public sbyte x31;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(sbyte x0, sbyte x1, sbyte x2, sbyte x3, sbyte x4, sbyte x5, sbyte x6, sbyte x7, sbyte x8, sbyte x9, sbyte x10, sbyte x11, sbyte x12, sbyte x13, sbyte x14, sbyte x15, sbyte x16, sbyte x17, sbyte x18, sbyte x19, sbyte x20, sbyte x21, sbyte x22, sbyte x23, sbyte x24, sbyte x25, sbyte x26, sbyte x27, sbyte x28, sbyte x29, sbyte x30, sbyte x31)
        {
            this = Avx.mm256_set_epi8((byte)x31, (byte)x30, (byte)x29, (byte)x28, (byte)x27, (byte)x26, (byte)x25, (byte)x24, (byte)x23, (byte)x22, (byte)x21, (byte)x20, (byte)x19, (byte)x18, (byte)x17, (byte)x16, (byte)x15, (byte)x14, (byte)x13, (byte)x12, (byte)x11, (byte)x10, (byte)x9, (byte)x8, (byte)x7, (byte)x6, (byte)x5, (byte)x4, (byte)x3, (byte)x2, (byte)x1, (byte)x0);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(sbyte x0x32)
        {
            this = new v256(x0x32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(sbyte8 v8_0, sbyte8 v8_1, sbyte8 v8_2, sbyte8 v8_3)
        {
            this = new sbyte32(new sbyte16(v8_0, v8_1), new sbyte16(v8_2, v8_3));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(sbyte16 v16_0, sbyte16 v16_1)
        {
            this = Avx.mm256_set_m128i(v16_1, v16_0);
        }


















        public sbyte16 v16_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(this); }







        public sbyte16 v16_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_extracti128_si256(this, 1); }















        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v256(sbyte32 input) => new v256(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7, input.x8, input.x9, input.x10, input.x11, input.x12, input.x13, input.x14, input.x15, input.x16, input.x17, input.x18, input.x19, input.x20, input.x21, input.x22, input.x23, input.x24, input.x25, input.x26, input.x27, input.x28, input.x29, input.x30, input.x31);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v256 x)
        public static implicit operator sbyte32(v256 input) => new sbyte32 { x0 = input.SByte0, x1 = input.SByte1, x2 = input.SByte2, x3 = input.SByte3, x4 = input.SByte4, x5 = input.SByte5, x6 = input.SByte6, x7 = input.SByte7, x8 = input.SByte8, x9 = input.SByte9, x10 = input.SByte10, x11 = input.SByte11, x12 = input.SByte12, x13 = input.SByte13, x14 = input.SByte14, x15 = input.SByte15, x16 = input.SByte16, x17 = input.SByte17, x18 = input.SByte18, x19 = input.SByte19, x20 = input.SByte20, x21 = input.SByte21, x22 = input.SByte22, x23 = input.SByte23, x24 = input.SByte24, x25 = input.SByte25, x26 = input.SByte26, x27 = input.SByte27, x28 = input.SByte28, x29 = input.SByte29, x30 = input.SByte30, x31 = input.SByte31 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte32(sbyte input) => new sbyte32(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(byte32 input) => (v256)input;


        public sbyte this[[AssumeRange(0, 31)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 32);
                
                fixed (void* ptr = &this)
                {
                    return ((sbyte*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 32);

                fixed (void* ptr = &this)
                {
                    ((sbyte*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator + (sbyte32 lhs, sbyte32 rhs) => Avx2.mm256_add_epi8(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator - (sbyte32 lhs, sbyte32 rhs) => Avx2.mm256_sub_epi8(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator * (sbyte32 lhs, sbyte32 rhs) => new sbyte32((sbyte16)((short16)lhs.v16_0 * (short16)rhs.v16_0), (sbyte16)((short16)lhs.v16_16 * (short16)rhs.v16_16));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator / (sbyte32 lhs, sbyte32 rhs) => Operator.vdiv_sbyte(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator % (sbyte32 lhs, sbyte32 rhs) => Operator.vrem_sbyte(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator & (sbyte32 lhs, sbyte32 rhs) => Avx2.mm256_and_si256(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator | (sbyte32 lhs, sbyte32 rhs) => Avx2.mm256_or_si256(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator ^ (sbyte32 lhs, sbyte32 rhs) => Avx2.mm256_xor_si256(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator - (sbyte32 x) => Avx2.mm256_sign_epi8(x, new v256((sbyte)-1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator ++ (sbyte32 x) => Avx2.mm256_add_epi8(x, new v256((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator -- (sbyte32 x) => Avx2.mm256_sub_epi8(x, new v256((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator ~ (sbyte32 x) => Avx2.mm256_andnot_si256(x, new v256((sbyte)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator << (sbyte32 x, int n) => Operator.shl_byte(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator >> (sbyte32 x, int n) => Operator.shra_byte(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (sbyte32 lhs, sbyte32 rhs) => TestIsTrue(Avx2.mm256_cmpeq_epi8(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator < (sbyte32 lhs, sbyte32 rhs) => TestIsTrue(Avx2.mm256_cmpgt_epi8(rhs, lhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator > (sbyte32 lhs, sbyte32 rhs) => TestIsTrue(Avx2.mm256_cmpgt_epi8(lhs, rhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (sbyte32 lhs, sbyte32 rhs) => TestIsFalse(Avx2.mm256_cmpeq_epi8(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator <= (sbyte32 lhs, sbyte32 rhs) => TestIsFalse(Avx2.mm256_cmpgt_epi8(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator >= (sbyte32 lhs, sbyte32 rhs) => TestIsFalse(Avx2.mm256_cmpgt_epi8(rhs, lhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool32 TestIsTrue(v256 input)
        {
            return Avx2.mm256_and_si256(input, new v256((sbyte)1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool32 TestIsFalse(v256 input)
        {
            return Avx2.mm256_andnot_si256(input, new v256((sbyte)1));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(sbyte32 other) => maxmath.cvt_boolean(Avx.mm256_testc_si256(Avx2.mm256_cmpeq_epi8(this, other), new v256(-1)));

        public override bool Equals(object obj) => Equals((sbyte32)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash._256bit(this);


        public override string ToString() =>  $"sbyte32({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15},    {x16}, {x17}, {x18}, {x19},    {x20}, {x21}, {x22}, {x23},    {x24}, {x25}, {x26}, {x27},    {x28}, {x29}, {x30}, {x31})";
    }
}