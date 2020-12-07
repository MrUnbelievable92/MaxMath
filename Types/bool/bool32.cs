using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    [Serializable]   [StructLayout(LayoutKind.Explicit, Size = 32)]
    unsafe public struct bool32 : IEquatable<bool32>
    {
        [NoAlias] [FieldOffset(0)]  public bool x0;
        [NoAlias] [FieldOffset(1)]  public bool x1;
        [NoAlias] [FieldOffset(2)]  public bool x2;
        [NoAlias] [FieldOffset(3)]  public bool x3;
        [NoAlias] [FieldOffset(4)]  public bool x4;
        [NoAlias] [FieldOffset(5)]  public bool x5;
        [NoAlias] [FieldOffset(6)]  public bool x6;
        [NoAlias] [FieldOffset(7)]  public bool x7;
        [NoAlias] [FieldOffset(8)]  public bool x8;
        [NoAlias] [FieldOffset(9)]  public bool x9;
        [NoAlias] [FieldOffset(10)] public bool x10;
        [NoAlias] [FieldOffset(11)] public bool x11;
        [NoAlias] [FieldOffset(12)] public bool x12;
        [NoAlias] [FieldOffset(13)] public bool x13;
        [NoAlias] [FieldOffset(14)] public bool x14;
        [NoAlias] [FieldOffset(15)] public bool x15;
        [NoAlias] [FieldOffset(16)] public bool x16;
        [NoAlias] [FieldOffset(17)] public bool x17;
        [NoAlias] [FieldOffset(18)] public bool x18;
        [NoAlias] [FieldOffset(19)] public bool x19;
        [NoAlias] [FieldOffset(20)] public bool x20;
        [NoAlias] [FieldOffset(21)] public bool x21;
        [NoAlias] [FieldOffset(22)] public bool x22;
        [NoAlias] [FieldOffset(23)] public bool x23;
        [NoAlias] [FieldOffset(24)] public bool x24;
        [NoAlias] [FieldOffset(25)] public bool x25;
        [NoAlias] [FieldOffset(26)] public bool x26;
        [NoAlias] [FieldOffset(27)] public bool x27;
        [NoAlias] [FieldOffset(28)] public bool x28;
        [NoAlias] [FieldOffset(29)] public bool x29;
        [NoAlias] [FieldOffset(30)] public bool x30;
        [NoAlias] [FieldOffset(31)] public bool x31;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7, bool x8, bool x9, bool x10, bool x11, bool x12, bool x13, bool x14, bool x15, bool x16, bool x17, bool x18, bool x19, bool x20, bool x21, bool x22, bool x23, bool x24, bool x25, bool x26, bool x27, bool x28, bool x29, bool x30, bool x31)
        {
            this = X86.Avx.mm256_set_epi8(maxmath.cvt_uint8(x31),
                                          maxmath.cvt_uint8(x30),
                                          maxmath.cvt_uint8(x29),
                                          maxmath.cvt_uint8(x28),
                                          maxmath.cvt_uint8(x27),
                                          maxmath.cvt_uint8(x26),
                                          maxmath.cvt_uint8(x25),
                                          maxmath.cvt_uint8(x24),
                                          maxmath.cvt_uint8(x23),
                                          maxmath.cvt_uint8(x22),
                                          maxmath.cvt_uint8(x21),
                                          maxmath.cvt_uint8(x20),
                                          maxmath.cvt_uint8(x19),
                                          maxmath.cvt_uint8(x18),
                                          maxmath.cvt_uint8(x17),
                                          maxmath.cvt_uint8(x16),
                                          maxmath.cvt_uint8(x15),
                                          maxmath.cvt_uint8(x14),
                                          maxmath.cvt_uint8(x13),
                                          maxmath.cvt_uint8(x12),
                                          maxmath.cvt_uint8(x11),
                                          maxmath.cvt_uint8(x10),
                                          maxmath.cvt_uint8(x9),
                                          maxmath.cvt_uint8(x8),
                                          maxmath.cvt_uint8(x7),
                                          maxmath.cvt_uint8(x6),
                                          maxmath.cvt_uint8(x5),
                                          maxmath.cvt_uint8(x4),
                                          maxmath.cvt_uint8(x3),
                                          maxmath.cvt_uint8(x2),
                                          maxmath.cvt_uint8(x1),
                                          maxmath.cvt_uint8(x0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool4x4 v16_0, bool4x4 v16_1)
        {
            this = X86.Avx.mm256_set_m128i(*(v128*)&v16_1, *(v128*)&v16_0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool x0x32)
        {
            this = new v256(maxmath.cvt_uint8(x0x32));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   X86.Sse4_1.stream_load_si128(void* ptr)   X86.Sse.load_ps(void* ptr)
        public static implicit operator v256(bool32 input) => new v256(*(byte*)&input.x0, *(byte*)&input.x1, *(byte*)&input.x2, *(byte*)&input.x3, *(byte*)&input.x4, *(byte*)&input.x5, *(byte*)&input.x6, *(byte*)&input.x7, *(byte*)&input.x8, *(byte*)&input.x9, *(byte*)&input.x10, *(byte*)&input.x11, *(byte*)&input.x12, *(byte*)&input.x13, *(byte*)&input.x14, *(byte*)&input.x15, *(byte*)&input.x16, *(byte*)&input.x17, *(byte*)&input.x18, *(byte*)&input.x19, *(byte*)&input.x20, *(byte*)&input.x21, *(byte*)&input.x22, *(byte*)&input.x23, *(byte*)&input.x24, *(byte*)&input.x25, *(byte*)&input.x26, *(byte*)&input.x27, *(byte*)&input.x28, *(byte*)&input.x29, *(byte*)&input.x30, *(byte*)&input.x31);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   X86.Sse.store_ps(void* ptr, v256 x)
        public static implicit operator bool32(v256 input) => new bool32 { x0 = maxmath.cvt_boolean(input.Byte0), x1 = maxmath.cvt_boolean(input.Byte1), x2 = maxmath.cvt_boolean(input.Byte2), x3 = maxmath.cvt_boolean(input.Byte3), x4 = maxmath.cvt_boolean(input.Byte4), x5 = maxmath.cvt_boolean(input.Byte5), x6 = maxmath.cvt_boolean(input.Byte6), x7 = maxmath.cvt_boolean(input.Byte7), x8 = maxmath.cvt_boolean(input.Byte8), x9 = maxmath.cvt_boolean(input.Byte9), x10 = maxmath.cvt_boolean(input.Byte10), x11 = maxmath.cvt_boolean(input.Byte11), x12 = maxmath.cvt_boolean(input.Byte12), x13 = maxmath.cvt_boolean(input.Byte13), x14 = maxmath.cvt_boolean(input.Byte14), x15 = maxmath.cvt_boolean(input.Byte15), x16 = maxmath.cvt_boolean(input.Byte16), x17 = maxmath.cvt_boolean(input.Byte17), x18 = maxmath.cvt_boolean(input.Byte18), x19 = maxmath.cvt_boolean(input.Byte19), x20 = maxmath.cvt_boolean(input.Byte20), x21 = maxmath.cvt_boolean(input.Byte21), x22 = maxmath.cvt_boolean(input.Byte22), x23 = maxmath.cvt_boolean(input.Byte23), x24 = maxmath.cvt_boolean(input.Byte24), x25 = maxmath.cvt_boolean(input.Byte25), x26 = maxmath.cvt_boolean(input.Byte26), x27 = maxmath.cvt_boolean(input.Byte27), x28 = maxmath.cvt_boolean(input.Byte28), x29 = maxmath.cvt_boolean(input.Byte29), x30 = maxmath.cvt_boolean(input.Byte30), x31 = maxmath.cvt_boolean(input.Byte31) };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool32(bool v) => new bool32(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (bool32 lhs, bool32 rhs) => X86.Avx2.mm256_and_si256(new v256((byte)1), X86.Avx2.mm256_cmpeq_epi8(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (bool32 lhs, bool32 rhs) => X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpeq_epi8(lhs, rhs), new v256((byte)1));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator & (bool32 lhs, bool32 rhs) => X86.Avx2.mm256_and_si256(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator | (bool32 lhs, bool32 rhs) => X86.Avx2.mm256_or_si256(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator ^ (bool32 lhs, bool32 rhs) => X86.Avx2.mm256_xor_si256(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator ! (bool32 val) => X86.Avx2.mm256_andnot_si256(val, new v256((byte)1));


        public bool this[[AssumeRange(0, 31)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 32);
                
                fixed (void* ptr = &this)
                {
                    return ((bool*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 32);

                fixed (void* ptr = &this)
                {
                    ((bool*)ptr)[index] = value;
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(bool32 other) => ((byte32)(v256)this).Equals((byte32)(v256)other);

        public override bool Equals(object obj) => Equals((bool32)obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash._256bit((byte32)(v256)this);

        public override string ToString() => $"bool32({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15},    {x16}, {x17}, {x18}, {x19},    {x20}, {x21}, {x22}, {x23},    {x24}, {x25}, {x26}, {x27},    {x28}, {x29}, {x30}, {x31})";
    }
}