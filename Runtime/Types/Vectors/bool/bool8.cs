using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]   [StructLayout(LayoutKind.Sequential, Size = 8)]
    unsafe public struct bool8 : IEquatable<bool8>
    {
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x0;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x1;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x2;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x3;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x4;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x5;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x6;
        [NoAlias] [MarshalAs(UnmanagedType.U1)] public bool x7;


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
                                 maxmath.toint8(x7),
                                 maxmath.toint8(x6),
                                 maxmath.toint8(x5),
                                 maxmath.toint8(x4),
                                 maxmath.toint8(x3),
                                 maxmath.toint8(x2),
                                 maxmath.toint8(x1),
                                 maxmath.toint8(x0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool x0x8)
        {
            this = new v128(maxmath.touint8(x0x8));
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


        public bool4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { bool8 t = this; return *(bool4*)&t; } }                    
        public bool4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { byte4 t = ((byte8)(v128)this).v4_1; return *(bool4*)&t; } }
        public bool4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { byte4 t = ((byte8)(v128)this).v4_2; return *(bool4*)&t; } }
        public bool4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { byte4 t = ((byte8)(v128)this).v4_3; return *(bool4*)&t; } }
        public bool4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { byte4 t = ((byte8)(v128)this).v4_4; return *(bool4*)&t; } }
                                                                              
        public bool3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { bool8 t = this; return *(bool3*)&t; } }
        public bool3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { byte3 t = ((byte8)(v128)this).v3_1; return *(bool3*)&t; } }
        public bool3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { byte3 t = ((byte8)(v128)this).v3_2; return *(bool3*)&t; } }
        public bool3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { byte3 t = ((byte8)(v128)this).v3_3; return *(bool3*)&t; } }
        public bool3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { byte3 t = ((byte8)(v128)this).v3_4; return *(bool3*)&t; } }
        public bool3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { byte3 t = ((byte8)(v128)this).v3_5; return *(bool3*)&t; } }
                                                                                 
        public bool2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { bool8 t = this; return *(bool2*)&t; } }
        public bool2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { byte2 t = ((byte8)(v128)this).v2_1; return *(bool2*)&t; } }
        public bool2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { byte2 t = ((byte8)(v128)this).v2_2; return *(bool2*)&t; } }
        public bool2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { byte2 t = ((byte8)(v128)this).v2_3; return *(bool2*)&t; } }
        public bool2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { byte2 t = ((byte8)(v128)this).v2_4; return *(bool2*)&t; } }
        public bool2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { byte2 t = ((byte8)(v128)this).v2_5; return *(bool2*)&t; } }
        public bool2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { byte2 t = ((byte8)(v128)this).v2_6; return *(bool2*)&t; } }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(bool8 input) => new v128(*(long*)&input, 0L);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool8(v128 input)
        {
#if DEBUG
            return new bool8 { x0 = maxmath.tobool(input.Byte0),
                               x1 = maxmath.tobool(input.Byte1),
                               x2 = maxmath.tobool(input.Byte2),
                               x3 = maxmath.tobool(input.Byte3),
                               x4 = maxmath.tobool(input.Byte4),
                               x5 = maxmath.tobool(input.Byte5),
                               x6 = maxmath.tobool(input.Byte6),
                               x7 = maxmath.tobool(input.Byte7) };
#else
            long x = input.SLong0;

            return *(bool8*)&x;
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool8(bool x) => new bool8(x);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (bool8 left, bool8 right) => Sse2.and_si128(new v128((byte)1), Sse2.cmpeq_epi8(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (bool8 left, bool8 right) => Sse2.andnot_si128(Sse2.cmpeq_epi8(left, right), new v128((byte)1));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator & (bool8 left, bool8 right) => Sse2.and_si128(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator | (bool8 left, bool8 right) => Sse2.or_si128(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator ^ (bool8 left, bool8 right) => Sse2.xor_si128(left, right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator ! (bool8 val) => Sse2.andnot_si128(val, new v128((byte)1));


        public bool this[int index]
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
        public bool Equals(bool8 other) => maxmath.bitmask32(8 * sizeof(bool)) == (maxmath.bitmask32(8 * sizeof(bool)) & (Sse2.movemask_epi8(Sse2.cmpeq_epi8(this, other))));

        public override bool Equals(object obj) => Equals((bool8)obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => maxmath.bitmask32(8 * sizeof(bool)) & Sse2.movemask_epi8(Sse2.slli_epi16(this, 7));

        public override string ToString() => $"bool8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
    }
}