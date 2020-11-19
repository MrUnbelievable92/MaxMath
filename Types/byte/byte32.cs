using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Explicit, Size = 32)]
    unsafe public struct byte32 : IEquatable<byte32>
    {
        [NoAlias] [FieldOffset(0)]  public byte x0;
        [NoAlias] [FieldOffset(1)]  public byte x1;
        [NoAlias] [FieldOffset(2)]  public byte x2;
        [NoAlias] [FieldOffset(3)]  public byte x3;
        [NoAlias] [FieldOffset(4)]  public byte x4;
        [NoAlias] [FieldOffset(5)]  public byte x5;
        [NoAlias] [FieldOffset(6)]  public byte x6;
        [NoAlias] [FieldOffset(7)]  public byte x7;
        [NoAlias] [FieldOffset(8)]  public byte x8;
        [NoAlias] [FieldOffset(9)]  public byte x9;
        [NoAlias] [FieldOffset(10)] public byte x10;
        [NoAlias] [FieldOffset(11)] public byte x11;
        [NoAlias] [FieldOffset(12)] public byte x12;
        [NoAlias] [FieldOffset(13)] public byte x13;
        [NoAlias] [FieldOffset(14)] public byte x14;
        [NoAlias] [FieldOffset(15)] public byte x15;
        [NoAlias] [FieldOffset(16)] public byte x16;
        [NoAlias] [FieldOffset(17)] public byte x17;
        [NoAlias] [FieldOffset(18)] public byte x18;
        [NoAlias] [FieldOffset(19)] public byte x19;
        [NoAlias] [FieldOffset(20)] public byte x20;
        [NoAlias] [FieldOffset(21)] public byte x21;
        [NoAlias] [FieldOffset(22)] public byte x22;
        [NoAlias] [FieldOffset(23)] public byte x23;
        [NoAlias] [FieldOffset(24)] public byte x24;
        [NoAlias] [FieldOffset(25)] public byte x25;
        [NoAlias] [FieldOffset(26)] public byte x26;
        [NoAlias] [FieldOffset(27)] public byte x27;
        [NoAlias] [FieldOffset(28)] public byte x28;
        [NoAlias] [FieldOffset(29)] public byte x29;
        [NoAlias] [FieldOffset(30)] public byte x30;
        [NoAlias] [FieldOffset(31)] public byte x31;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7, byte x8, byte x9, byte x10, byte x11, byte x12, byte x13, byte x14, byte x15, byte x16, byte x17, byte x18, byte x19, byte x20, byte x21, byte x22, byte x23, byte x24, byte x25, byte x26, byte x27, byte x28, byte x29, byte x30, byte x31)
        {
            this = X86.Avx.mm256_set_epi8(x31, x30, x29, x28, x27, x26, x25, x24, x23, x22, x21, x20, x19, x18, x17, x16, x15, x14, x13, x12, x11, x10, x9, x8, x7, x6, x5, x4, x3, x2, x1, x0);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte x0x32)
        {
            this = new v256(x0x32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte16 v16_0, byte16 v16_1)
        {
            this = X86.Avx.mm256_set_m128i(v16_1, v16_0);
        }


















        public byte16 v16_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx.mm256_castsi256_si128(this); }







        public byte16 v16_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.mm256_extracti128_si256(this, 1); }















        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   X86.Sse4_1.stream_load_si128(void* ptr)   X86.Sse.load_ps(void* ptr)
        public static implicit operator v256(byte32 input) => new v256(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7, input.x8, input.x9, input.x10, input.x11, input.x12, input.x13, input.x14, input.x15, input.x16, input.x17, input.x18, input.x19, input.x20, input.x21, input.x22, input.x23, input.x24, input.x25, input.x26, input.x27, input.x28, input.x29, input.x30, input.x31);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   X86.Sse.store_ps(void* ptr, v256 x)
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
        public static byte32 operator + (byte32 lhs, byte32 rhs) => X86.Avx2.mm256_add_epi8(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator - (byte32 lhs, byte32 rhs) => X86.Avx2.mm256_sub_epi8(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator * (byte32 lhs, byte32 rhs) => new byte32((byte16)((ushort16)lhs.v16_0 * (ushort16)rhs.v16_0), (byte16)((ushort16)lhs.v16_16 * (ushort16)rhs.v16_16));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator / (byte32 lhs, byte32 rhs) => Operator.div_byte(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator % (byte32 lhs, byte32 rhs) => Operator.rem_byte(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator & (byte32 lhs, byte32 rhs) => X86.Avx2.mm256_and_si256(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator | (byte32 lhs, byte32 rhs) => X86.Avx2.mm256_or_si256(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator ^ (byte32 lhs, byte32 rhs) => X86.Avx2.mm256_xor_si256(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator ++ (byte32 x) => X86.Avx2.mm256_add_epi8(x, new v256((byte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator -- (byte32 x) => X86.Avx2.mm256_sub_epi8(x, new v256((byte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator ~ (byte32 x) => X86.Avx2.mm256_andnot_si256(x, new v256((sbyte)-1));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator << (byte32 x, int n) => Operator.shl_byte(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator >> (byte32 x, int n) => Operator.shrl_byte(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (byte32 lhs, byte32 rhs) => TestIsTrue(X86.Avx2.mm256_cmpeq_epi8(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator < (byte32 lhs, byte32 rhs) => TestIsTrue(Operator.greater_mask_byte(rhs, lhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator > (byte32 lhs, byte32 rhs) => TestIsTrue(Operator.greater_mask_byte(lhs, rhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (byte32 lhs, byte32 rhs) => TestIsFalse(X86.Avx2.mm256_cmpeq_epi8(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator <= (byte32 lhs, byte32 rhs) => TestIsFalse(Operator.greater_mask_byte(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator >= (byte32 lhs, byte32 rhs) => TestIsFalse(Operator.greater_mask_byte(rhs, lhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool32 TestIsTrue(v256 input)
        {
            input = X86.Avx2.mm256_and_si256(new v256((byte)1), input);

            return *(bool32*)&input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool32 TestIsFalse(v256 input)
        {
            input = X86.Avx2.mm256_andnot_si256(input, new v256((byte)1));

            return *(bool32*)&input;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(byte32 other) => maxmath.cvt_boolean(X86.Avx.mm256_testc_si256(X86.Avx2.mm256_cmpeq_epi8(this, other), new v256(-1)));

        public override bool Equals(object obj) => Equals((byte32)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash._256bit(this);


        public override string ToString() =>  $"byte32({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15},    {x16}, {x17}, {x18}, {x19},    {x20}, {x21}, {x22}, {x23},    {x24}, {x25}, {x26}, {x27},    {x28}, {x29}, {x30}, {x31})";
    }
}