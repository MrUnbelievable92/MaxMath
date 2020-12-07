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
            this = X86.Avx.mm256_set_epi8(*(byte*)&x31,
                                          *(byte*)&x30,
                                          *(byte*)&x29,
                                          *(byte*)&x28,
                                          *(byte*)&x27,
                                          *(byte*)&x26,
                                          *(byte*)&x25,
                                          *(byte*)&x24,
                                          *(byte*)&x23,
                                          *(byte*)&x22,
                                          *(byte*)&x21,
                                          *(byte*)&x20,
                                          *(byte*)&x19,
                                          *(byte*)&x18,
                                          *(byte*)&x17,
                                          *(byte*)&x16,
                                          *(byte*)&x15,
                                          *(byte*)&x14,
                                          *(byte*)&x13,
                                          *(byte*)&x12,
                                          *(byte*)&x11,
                                          *(byte*)&x10,
                                          *(byte*)&x9,
                                          *(byte*)&x8,
                                          *(byte*)&x7,
                                          *(byte*)&x6,
                                          *(byte*)&x5,
                                          *(byte*)&x4,
                                          *(byte*)&x3,
                                          *(byte*)&x2,
                                          *(byte*)&x1,
                                          *(byte*)&x0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool4x4 v16_0, bool4x4 v16_1)
        {
            this = X86.Avx.mm256_set_m128i(*(v128*)&v16_1, *(v128*)&v16_0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool x0x20)
        {
            this = new v256(*(byte*)&x0x20);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   X86.Sse4_1.stream_load_si128(void* ptr)   X86.Sse.load_ps(void* ptr)
        public static implicit operator v256(bool32 input) => new v256(*(byte*)&input.x0, *(byte*)&input.x1, *(byte*)&input.x2, *(byte*)&input.x3, *(byte*)&input.x4, *(byte*)&input.x5, *(byte*)&input.x6, *(byte*)&input.x7, *(byte*)&input.x8, *(byte*)&input.x9, *(byte*)&input.x10, *(byte*)&input.x11, *(byte*)&input.x12, *(byte*)&input.x13, *(byte*)&input.x14, *(byte*)&input.x15, *(byte*)&input.x16, *(byte*)&input.x17, *(byte*)&input.x18, *(byte*)&input.x19, *(byte*)&input.x20, *(byte*)&input.x21, *(byte*)&input.x22, *(byte*)&input.x23, *(byte*)&input.x24, *(byte*)&input.x25, *(byte*)&input.x26, *(byte*)&input.x27, *(byte*)&input.x28, *(byte*)&input.x29, *(byte*)&input.x30, *(byte*)&input.x31);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   X86.Sse.store_ps(void* ptr, v256 x)
        public static implicit operator bool32(v256 input) => new bool32 { x0 = *(bool*)&input.Byte0, x1 = *(bool*)&input.Byte1, x2 = *(bool*)&input.Byte2, x3 = *(bool*)&input.Byte3, x4 = *(bool*)&input.Byte4, x5 = *(bool*)&input.Byte5, x6 = *(bool*)&input.Byte6, x7 = *(bool*)&input.Byte7, x8 = *(bool*)&input.Byte8, x9 = *(bool*)&input.Byte9, x10 = *(bool*)&input.Byte10, x11 = *(bool*)&input.Byte11, x12 = *(bool*)&input.Byte12, x13 = *(bool*)&input.Byte13, x14 = *(bool*)&input.Byte14, x15 = *(bool*)&input.Byte15, x16 = *(bool*)&input.Byte16, x17 = *(bool*)&input.Byte17, x18 = *(bool*)&input.Byte18, x19 = *(bool*)&input.Byte19, x20 = *(bool*)&input.Byte20, x21 = *(bool*)&input.Byte21, x22 = *(bool*)&input.Byte22, x23 = *(bool*)&input.Byte23, x24 = *(bool*)&input.Byte24, x25 = *(bool*)&input.Byte25, x26 = *(bool*)&input.Byte26, x27 = *(bool*)&input.Byte27, x28 = *(bool*)&input.Byte28, x29 = *(bool*)&input.Byte29, x30 = *(bool*)&input.Byte30, x31 = *(bool*)&input.Byte31 };

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