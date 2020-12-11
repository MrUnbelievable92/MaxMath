using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]   [StructLayout(LayoutKind.Explicit, Size = 8)]
    unsafe public struct bool8 : IEquatable<bool8>
    {
        [FieldOffset(0)] internal long cast_long;

        [FieldOffset(0)] public bool x0;
        [FieldOffset(1)] public bool x1;
        [FieldOffset(2)] public bool x2;
        [FieldOffset(3)] public bool x3;
        [FieldOffset(4)] public bool x4;
        [FieldOffset(5)] public bool x5;
        [FieldOffset(6)] public bool x6;
        [FieldOffset(7)] public bool x7;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7)
        {
            this = Sse2.set_epi8(0,
                                 0,
                                 0,
                                 0,
                                 0,
                                 0,
                                 0,
                                 0,
                                 maxmath.cvt_int8(x7),
                                 maxmath.cvt_int8(x6),
                                 maxmath.cvt_int8(x5),
                                 maxmath.cvt_int8(x4),
                                 maxmath.cvt_int8(x3),
                                 maxmath.cvt_int8(x2),
                                 maxmath.cvt_int8(x1),
                                 maxmath.cvt_int8(x0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool x0x8)
        {
            this = new v128(maxmath.cvt_uint8(x0x8));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool2 x01, bool2 x23, bool2 x45, bool2 x67)
        {
            this = (v128)new byte8(*(byte2*)&x01, *(byte2*)&x23, *(byte2*)&x45, *(byte2*)&x67);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool2 x01, bool3 x234, bool3 x567)
        {
            this = (v128)new byte8(*(byte2*)&x01, *(byte3*)&x234, *(byte3*)&x567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool3 x012, bool2 x34, bool3 x567)
        {
            this = (v128)new byte8(*(byte3*)&x012, *(byte2*)&x34, *(byte3*)&x567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool3 x012, bool3 x345, bool2 x67)
        {
            this = (v128)new byte8(*(byte3*)&x012, *(byte3*)&x345, *(byte2*)&x67);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool4 x0123, bool2 x45, bool2 x67)
        {
            this = (v128)new byte8(*(byte4*)&x0123, *(byte2*)&x45, *(byte2*)&x67);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool2 x01, bool4 x2345, bool2 x67)
        {
            this = (v128)new byte8(*(byte2*)&x01, *(byte4*)&x2345, *(byte2*)&x67);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool2 x01, bool2 x23, bool4 x4567)
        {
            this = (v128)new byte8(*(byte2*)&x01, *(byte2*)&x23, *(byte4*)&x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool4 x0123, bool4 x4567)
        {
            this = (v128)new byte8(*(byte4*)&x0123, *(byte4*)&x4567);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(bool8 input) => Sse2.set1_epi64x(input.cast_long);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool8(v128 input)
        {
#if UNITY_EDITOR
            return new bool8 { x0 = maxmath.cvt_boolean(input.Byte0),
                               x1 = maxmath.cvt_boolean(input.Byte1),
                               x2 = maxmath.cvt_boolean(input.Byte2),
                               x3 = maxmath.cvt_boolean(input.Byte3),
                               x4 = maxmath.cvt_boolean(input.Byte4),
                               x5 = maxmath.cvt_boolean(input.Byte5),
                               x6 = maxmath.cvt_boolean(input.Byte6),
                               x7 = maxmath.cvt_boolean(input.Byte7) };
#else
            return new bool8 { cast_long = Sse4_1.extract_epi64(input, 0) }
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool8(bool v) => new bool8(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool4x2(bool8 input) => *(bool4x2*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool8(bool4x2 input) => *(bool8*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool2x4(bool8 input) => *(bool2x4*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool8(bool2x4 input) => *(bool8*)&input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (bool8 lhs, bool8 rhs) => Sse2.and_si128(new v128((byte)1), Sse2.cmpeq_epi8(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (bool8 lhs, bool8 rhs) => Sse2.andnot_si128(Sse2.cmpeq_epi8(lhs, rhs), new v128((byte)1));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator & (bool8 lhs, bool8 rhs) => Sse2.and_si128(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator | (bool8 lhs, bool8 rhs) => Sse2.or_si128(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator ^ (bool8 lhs, bool8 rhs) => Sse2.xor_si128(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator ! (bool8 val) => Sse2.andnot_si128(val, new v128((byte)1));


        public bool this[[AssumeRange(0, 7)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 8);
                
                fixed (void* ptr = &this)
                {
                    return ((bool*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                fixed (void* ptr = &this)
                {
                    ((bool*)ptr)[index] = value;
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(bool8 other) => maxmath.cvt_boolean(Sse4_1.testc_si128(Sse2.cmpeq_epi8(this, other), new v128(-1L, 0L)));

        public override bool Equals(object obj) => Equals((bool8)obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash._128bit(this);

        public override string ToString() => $"bool8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
    }
}