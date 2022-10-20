using System.Runtime.CompilerServices;
using Unity.Mathematics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of the logical <see langword="&amp;" /> operation between two <see cref="UInt128"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 andnot(UInt128 left, UInt128 right)
        {
            return new UInt128(andnot(left.lo64, right.lo64), andnot(left.hi64, right.hi64));
        }

        /// <summary>       Returns the result of the logical <see langword="&amp;" /> operation between two <see cref="Int128"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 andnot(Int128 left, Int128 right)
        {
            return new Int128(andnot(left.lo64, right.lo64), andnot(left.hi64, right.hi64));
        }


        /// <summary>       Returns the result of the logical <see langword="&amp;" /> operation between two <see cref="bool"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool andnot(bool left, bool right)
        {
            return tobool(andnot(tobyte(left), tobyte(right)));
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="bool2"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 andnot(bool2 left, bool2 right)
        {
Assert.IsSafeBoolean(left.x);
Assert.IsSafeBoolean(left.y);
Assert.IsSafeBoolean(right.x);
Assert.IsSafeBoolean(right.y);

            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToBool2(Sse2.andnot_si128(RegisterConversion.ToV128(right), RegisterConversion.ToV128(left)));
            }
            else
            {
                return left & !right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="bool3"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 andnot(bool3 left, bool3 right)
        {
Assert.IsSafeBoolean(left.x);
Assert.IsSafeBoolean(left.y);
Assert.IsSafeBoolean(left.z);
Assert.IsSafeBoolean(right.x);
Assert.IsSafeBoolean(right.y);
Assert.IsSafeBoolean(right.z);

            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToBool3(Sse2.andnot_si128(RegisterConversion.ToV128(right), RegisterConversion.ToV128(left)));
            }
            else
            {
                return left & !right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="bool4"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 andnot(bool4 left, bool4 right)
        {
Assert.IsSafeBoolean(left.x);
Assert.IsSafeBoolean(left.y);
Assert.IsSafeBoolean(left.z);
Assert.IsSafeBoolean(left.w);
Assert.IsSafeBoolean(right.x);
Assert.IsSafeBoolean(right.y);
Assert.IsSafeBoolean(right.z);
Assert.IsSafeBoolean(right.w);

            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToBool4(Sse2.andnot_si128(RegisterConversion.ToV128(right), RegisterConversion.ToV128(left)));
            }
            else
            {
                return left & !right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.bool8"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 andnot(bool8 left, bool8 right)
        {
Assert.IsSafeBoolean(left.x0);
Assert.IsSafeBoolean(left.x1);
Assert.IsSafeBoolean(left.x2);
Assert.IsSafeBoolean(left.x3);
Assert.IsSafeBoolean(left.x4);
Assert.IsSafeBoolean(left.x5);
Assert.IsSafeBoolean(left.x6);
Assert.IsSafeBoolean(left.x7);
Assert.IsSafeBoolean(right.x0);
Assert.IsSafeBoolean(right.x1);
Assert.IsSafeBoolean(right.x2);
Assert.IsSafeBoolean(right.x3);
Assert.IsSafeBoolean(right.x4);
Assert.IsSafeBoolean(right.x5);
Assert.IsSafeBoolean(right.x6);
Assert.IsSafeBoolean(right.x7);

            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & !right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.bool16"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 andnot(bool16 left, bool16 right)
        {
Assert.IsSafeBoolean(left.x0);
Assert.IsSafeBoolean(left.x1);
Assert.IsSafeBoolean(left.x2);
Assert.IsSafeBoolean(left.x3);
Assert.IsSafeBoolean(left.x4);
Assert.IsSafeBoolean(left.x5);
Assert.IsSafeBoolean(left.x6);
Assert.IsSafeBoolean(left.x7);
Assert.IsSafeBoolean(left.x8);
Assert.IsSafeBoolean(left.x9);
Assert.IsSafeBoolean(left.x10);
Assert.IsSafeBoolean(left.x11);
Assert.IsSafeBoolean(left.x12);
Assert.IsSafeBoolean(left.x13);
Assert.IsSafeBoolean(left.x14);
Assert.IsSafeBoolean(left.x15);
Assert.IsSafeBoolean(right.x0);
Assert.IsSafeBoolean(right.x1);
Assert.IsSafeBoolean(right.x2);
Assert.IsSafeBoolean(right.x3);
Assert.IsSafeBoolean(right.x4);
Assert.IsSafeBoolean(right.x5);
Assert.IsSafeBoolean(right.x6);
Assert.IsSafeBoolean(right.x7);
Assert.IsSafeBoolean(right.x8);
Assert.IsSafeBoolean(right.x9);
Assert.IsSafeBoolean(right.x10);
Assert.IsSafeBoolean(right.x11);
Assert.IsSafeBoolean(right.x12);
Assert.IsSafeBoolean(right.x13);
Assert.IsSafeBoolean(right.x14);
Assert.IsSafeBoolean(right.x15);

            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & !right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.bool32"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 andnot(bool32 left, bool32 right)
        {
Assert.IsSafeBoolean(left.x0);
Assert.IsSafeBoolean(left.x1);
Assert.IsSafeBoolean(left.x2);
Assert.IsSafeBoolean(left.x3);
Assert.IsSafeBoolean(left.x4);
Assert.IsSafeBoolean(left.x5);
Assert.IsSafeBoolean(left.x6);
Assert.IsSafeBoolean(left.x7);
Assert.IsSafeBoolean(left.x8);
Assert.IsSafeBoolean(left.x9);
Assert.IsSafeBoolean(left.x10);
Assert.IsSafeBoolean(left.x11);
Assert.IsSafeBoolean(left.x12);
Assert.IsSafeBoolean(left.x13);
Assert.IsSafeBoolean(left.x14);
Assert.IsSafeBoolean(left.x15);
Assert.IsSafeBoolean(left.x16);
Assert.IsSafeBoolean(left.x17);
Assert.IsSafeBoolean(left.x18);
Assert.IsSafeBoolean(left.x19);
Assert.IsSafeBoolean(left.x20);
Assert.IsSafeBoolean(left.x21);
Assert.IsSafeBoolean(left.x22);
Assert.IsSafeBoolean(left.x23);
Assert.IsSafeBoolean(left.x24);
Assert.IsSafeBoolean(left.x25);
Assert.IsSafeBoolean(left.x26);
Assert.IsSafeBoolean(left.x27);
Assert.IsSafeBoolean(left.x28);
Assert.IsSafeBoolean(left.x29);
Assert.IsSafeBoolean(left.x30);
Assert.IsSafeBoolean(left.x31);
Assert.IsSafeBoolean(right.x0);
Assert.IsSafeBoolean(right.x1);
Assert.IsSafeBoolean(right.x2);
Assert.IsSafeBoolean(right.x3);
Assert.IsSafeBoolean(right.x4);
Assert.IsSafeBoolean(right.x5);
Assert.IsSafeBoolean(right.x6);
Assert.IsSafeBoolean(right.x7);
Assert.IsSafeBoolean(right.x8);
Assert.IsSafeBoolean(right.x9);
Assert.IsSafeBoolean(right.x10);
Assert.IsSafeBoolean(right.x11);
Assert.IsSafeBoolean(right.x12);
Assert.IsSafeBoolean(right.x13);
Assert.IsSafeBoolean(right.x14);
Assert.IsSafeBoolean(right.x15);
Assert.IsSafeBoolean(right.x16);
Assert.IsSafeBoolean(right.x17);
Assert.IsSafeBoolean(right.x18);
Assert.IsSafeBoolean(right.x19);
Assert.IsSafeBoolean(right.x20);
Assert.IsSafeBoolean(right.x21);
Assert.IsSafeBoolean(right.x22);
Assert.IsSafeBoolean(right.x23);
Assert.IsSafeBoolean(right.x24);
Assert.IsSafeBoolean(right.x25);
Assert.IsSafeBoolean(right.x26);
Assert.IsSafeBoolean(right.x27);
Assert.IsSafeBoolean(right.x28);
Assert.IsSafeBoolean(right.x29);
Assert.IsSafeBoolean(right.x30);
Assert.IsSafeBoolean(right.x31);

            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_andnot_si256(right, left);
            }
            else
            {
                return new bool32(andnot(left.v16_0, right.v16_0), andnot(left.v16_16, right.v16_16));
            }
        }


        /// <summary>       Returns the result of the logical <see langword="&amp;" /> operation between two <see cref="byte"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte andnot(byte left, byte right)
        {
            return (byte)andnot((uint)left, (uint)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.byte2"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 andnot(byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.byte3"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 andnot(byte3 left, byte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.byte4"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 andnot(byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.byte8"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 andnot(byte8 left, byte8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.byte16"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 andnot(byte16 left, byte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.byte32"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 andnot(byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_andnot_si256(right, left);
            }
            else
            {
                return new byte32(andnot(left.v16_0, right.v16_0), andnot(left.v16_16, right.v16_16));
            }
        }


        /// <summary>       Returns the result of the logical <see langword="&amp;" /> operation between two <see cref="sbyte"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte andnot(sbyte left, sbyte right)
        {
            return (sbyte)andnot((byte)left, (byte)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.sbyte2"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 andnot(sbyte2 left, sbyte2 right)
        {
            return (sbyte2)andnot((byte2)left, (byte2)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.sbyte3"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 andnot(sbyte3 left, sbyte3 right)
        {
            return (sbyte3)andnot((byte3)left, (byte3)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.sbyte4"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 andnot(sbyte4 left, sbyte4 right)
        {
            return (sbyte4)andnot((byte4)left, (byte4)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.sbyte8"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 andnot(sbyte8 left, sbyte8 right)
        {
            return (sbyte8)andnot((byte8)left, (byte8)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.sbyte16"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 andnot(sbyte16 left, sbyte16 right)
        {
            return (sbyte16)andnot((byte16)left, (byte16)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.sbyte32"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 andnot(sbyte32 left, sbyte32 right)
        {
            return (sbyte32)andnot((byte32)left, (byte32)right);
        }


        /// <summary>       Returns the result of the logical <see langword="&amp;" /> operation between two <see cref="ushort"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort andnot(ushort left, ushort right)
        {
            return (ushort)andnot((uint)left, (uint)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.ushort2"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 andnot(ushort2 left, ushort2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.ushort3"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 andnot(ushort3 left, ushort3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.ushort4"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 andnot(ushort4 left, ushort4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.ushort8"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 andnot(ushort8 left, ushort8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.ushort16"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 andnot(ushort16 left, ushort16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_andnot_si256(right, left);
            }
            else
            {
                return new ushort16(andnot(left.v8_0, right.v8_0), andnot(left.v8_8, right.v8_8));
            }
        }


        /// <summary>       Returns the result of the logical <see langword="&amp;" /> operation between two <see cref="short"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short andnot(short left, short right)
        {
            return (short)andnot((ushort)left, (ushort)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.short2"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 andnot(short2 left, short2 right)
        {
            return (short2)andnot((ushort2)left, (ushort2)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.short3"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 andnot(short3 left, short3 right)
        {
            return (short3)andnot((ushort3)left, (ushort3)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.short4"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 andnot(short4 left, short4 right)
        {
            return (short4)andnot((ushort4)left, (ushort4)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.short8"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 andnot(short8 left, short8 right)
        {
            return (short8)andnot((ushort8)left, (ushort8)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.short16"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 andnot(short16 left, short16 right)
        {
            return (short16)andnot((ushort16)left, (ushort16)right);
        }


        /// <summary>       Returns the result of the logical <see langword="&amp;" /> operation between two <see cref="int"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int andnot(int left, int right)
        {
            return (int)andnot((uint)left, (uint)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="int2"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 andnot(int2 left, int2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt2(Sse2.andnot_si128(RegisterConversion.ToV128(right), RegisterConversion.ToV128(left)));
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="int3"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 andnot(int3 left, int3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt3(Sse2.andnot_si128(RegisterConversion.ToV128(right), RegisterConversion.ToV128(left)));
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="int4"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 andnot(int4 left, int4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt4(Sse2.andnot_si128(RegisterConversion.ToV128(right), RegisterConversion.ToV128(left)));
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.int8"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 andnot(int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_andnot_si256(right, left);
            }
            else
            {
                return new int8(andnot(left.v4_0, right.v4_0), andnot(left.v4_4, right.v4_4));
            }
        }


        /// <summary>       Returns the result of the logical <see langword="&amp;" /> operation between two <see cref="uint"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint andnot(uint left, uint right)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.andn_u32(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="uint2"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 andnot(uint2 left, uint2 right)
        {
            return (uint2)andnot((int2)left, (int2)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="uint3"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 andnot(uint3 left, uint3 right)
        {
            return (uint3)andnot((int3)left, (int3)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="uint4"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 andnot(uint4 left, uint4 right)
        {
            return (uint4)andnot((int4)left, (int4)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.uint8"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 andnot(uint8 left, uint8 right)
        {
            return (uint8)andnot((int8)left, (int8)right);
        }


        /// <summary>       Returns the result of the logical <see langword="&amp;" /> operation between two <see cref="long"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long andnot(long left, long right)
        {
            return (long)andnot((ulong)left, (ulong)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.long2"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 andnot(long2 left, long2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.long3"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 andnot(long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_andnot_si256(right, left);
            }
            else
            {
                return new long3(andnot(left.xy, right.xy), andnot(left.z, right.z));
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.long4"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 andnot(long4 left, long4 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_andnot_si256(right, left);
            }
            else
            {
                return new long4(andnot(left.xy, right.xy), andnot(left.zw, right.zw));
            }
        }


        /// <summary>       Returns the result of the logical <see langword="&amp;" /> operation between two <see cref="ulong"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong andnot(ulong left, ulong right)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.andn_u64(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.ulong2"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 andnot(ulong2 left, ulong2 right)
        {
            return (ulong2)andnot((long2)left, (long2)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.ulong3"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 andnot(ulong3 left, ulong3 right)
        {
            return (ulong3)andnot((long3)left, (long3)right);
        }

        /// <summary>       Returns the result of the componentwise logical <see langword="&amp;" /> operation between two <see cref="MaxMath.ulong4"/>s <paramref name="left"/> and <see langword="~" /><paramref name="right"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 andnot(ulong4 left, ulong4 right)
        {
            return (ulong4)andnot((long4)left, (long4)right);
        }
    }
}