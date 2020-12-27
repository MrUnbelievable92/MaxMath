using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]   [StructLayout(LayoutKind.Sequential, Size = 32)]
    unsafe public struct bool32 : IEquatable<bool32>
    {
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x0;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x1;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x2;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x3;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x4;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x5;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x6;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x7;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x8;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x9;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x10;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x11;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x12;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x13;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x14;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x15;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x16;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x17;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x18;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x19;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x20;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x21;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x22;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x23;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x24;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x25;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x26;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x27;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x28;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x29;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x30;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x31;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7, bool x8, bool x9, bool x10, bool x11, bool x12, bool x13, bool x14, bool x15, bool x16, bool x17, bool x18, bool x19, bool x20, bool x21, bool x22, bool x23, bool x24, bool x25, bool x26, bool x27, bool x28, bool x29, bool x30, bool x31)
        {
            this = Avx.mm256_set_epi8(maxmath.touint8(x31),
                                      maxmath.touint8(x30),
                                      maxmath.touint8(x29),
                                      maxmath.touint8(x28),
                                      maxmath.touint8(x27),
                                      maxmath.touint8(x26),
                                      maxmath.touint8(x25),
                                      maxmath.touint8(x24),
                                      maxmath.touint8(x23),
                                      maxmath.touint8(x22),
                                      maxmath.touint8(x21),
                                      maxmath.touint8(x20),
                                      maxmath.touint8(x19),
                                      maxmath.touint8(x18),
                                      maxmath.touint8(x17),
                                      maxmath.touint8(x16),
                                      maxmath.touint8(x15),
                                      maxmath.touint8(x14),
                                      maxmath.touint8(x13),
                                      maxmath.touint8(x12),
                                      maxmath.touint8(x11),
                                      maxmath.touint8(x10),
                                      maxmath.touint8(x9),
                                      maxmath.touint8(x8),
                                      maxmath.touint8(x7),
                                      maxmath.touint8(x6),
                                      maxmath.touint8(x5),
                                      maxmath.touint8(x4),
                                      maxmath.touint8(x3),
                                      maxmath.touint8(x2),
                                      maxmath.touint8(x1),
                                      maxmath.touint8(x0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool x0x32)
        {
            this = (v256)new byte32(maxmath.touint8(x0x32));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool8 v8_0, bool8 v8_1, bool8 v8_2, bool8 v8_3)
        {
            this = (v256)new byte32(new byte16((v128)v8_0, (v128)v8_1), new byte16((v128)v8_2, (v128)v8_3));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool16 v16_0, bool16 v16_1)
        {
            this = (v256)new byte32((v128)v16_0, (v128)v16_1);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v256(bool32 input) => new v256(*(byte*)&input.x0, *(byte*)&input.x1, *(byte*)&input.x2, *(byte*)&input.x3, *(byte*)&input.x4, *(byte*)&input.x5, *(byte*)&input.x6, *(byte*)&input.x7, *(byte*)&input.x8, *(byte*)&input.x9, *(byte*)&input.x10, *(byte*)&input.x11, *(byte*)&input.x12, *(byte*)&input.x13, *(byte*)&input.x14, *(byte*)&input.x15, *(byte*)&input.x16, *(byte*)&input.x17, *(byte*)&input.x18, *(byte*)&input.x19, *(byte*)&input.x20, *(byte*)&input.x21, *(byte*)&input.x22, *(byte*)&input.x23, *(byte*)&input.x24, *(byte*)&input.x25, *(byte*)&input.x26, *(byte*)&input.x27, *(byte*)&input.x28, *(byte*)&input.x29, *(byte*)&input.x30, *(byte*)&input.x31);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v256 x)
        public static implicit operator bool32(v256 input) => new bool32 { x0 = maxmath.tobool(input.Byte0), x1 = maxmath.tobool(input.Byte1), x2 = maxmath.tobool(input.Byte2), x3 = maxmath.tobool(input.Byte3), x4 = maxmath.tobool(input.Byte4), x5 = maxmath.tobool(input.Byte5), x6 = maxmath.tobool(input.Byte6), x7 = maxmath.tobool(input.Byte7), x8 = maxmath.tobool(input.Byte8), x9 = maxmath.tobool(input.Byte9), x10 = maxmath.tobool(input.Byte10), x11 = maxmath.tobool(input.Byte11), x12 = maxmath.tobool(input.Byte12), x13 = maxmath.tobool(input.Byte13), x14 = maxmath.tobool(input.Byte14), x15 = maxmath.tobool(input.Byte15), x16 = maxmath.tobool(input.Byte16), x17 = maxmath.tobool(input.Byte17), x18 = maxmath.tobool(input.Byte18), x19 = maxmath.tobool(input.Byte19), x20 = maxmath.tobool(input.Byte20), x21 = maxmath.tobool(input.Byte21), x22 = maxmath.tobool(input.Byte22), x23 = maxmath.tobool(input.Byte23), x24 = maxmath.tobool(input.Byte24), x25 = maxmath.tobool(input.Byte25), x26 = maxmath.tobool(input.Byte26), x27 = maxmath.tobool(input.Byte27), x28 = maxmath.tobool(input.Byte28), x29 = maxmath.tobool(input.Byte29), x30 = maxmath.tobool(input.Byte30), x31 = maxmath.tobool(input.Byte31) };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool32(bool x) => new bool32(x);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (bool32 lhs, bool32 rhs) => Avx2.mm256_and_si256(new v256((byte)1), Avx2.mm256_cmpeq_epi8(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (bool32 lhs, bool32 rhs) => Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi8(lhs, rhs), new v256((byte)1));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator & (bool32 lhs, bool32 rhs) => Avx2.mm256_and_si256(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator | (bool32 lhs, bool32 rhs) => Avx2.mm256_or_si256(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator ^ (bool32 lhs, bool32 rhs) => Avx2.mm256_xor_si256(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator ! (bool32 val) => Avx2.mm256_andnot_si256(val, new v256((byte)1));


        public bool this[int index]
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
        public bool Equals(bool32 other) => -1 == Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi8(this, other));

        public override bool Equals(object obj) => Equals((bool32)obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Avx2.mm256_movemask_epi8(Avx2.mm256_slli_epi16(this, 7));

        public override string ToString() => $"bool32({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15},    {x16}, {x17}, {x18}, {x19},    {x20}, {x21}, {x22}, {x23},    {x24}, {x25}, {x26}, {x27},    {x28}, {x29}, {x30}, {x31})";
    }
}