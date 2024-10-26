using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte extract_epi8(v128 a, byte i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (Sse4_1.IsSse41Supported)
                {
                    switch (i)
                    {
                        case 15: return Sse4_1.extract_epi8(a, 15);
                        case 14: return Sse4_1.extract_epi8(a, 14);
                        case 13: return Sse4_1.extract_epi8(a, 13);
                        case 12: return Sse4_1.extract_epi8(a, 12);
                        case 11: return Sse4_1.extract_epi8(a, 11);
                        case 10: return Sse4_1.extract_epi8(a, 10);
                        case 9:  return Sse4_1.extract_epi8(a, 9);
                        case 8:  return Sse4_1.extract_epi8(a, 8);
                        case 7:  return Sse4_1.extract_epi8(a, 7);
                        case 6:  return Sse4_1.extract_epi8(a, 6);
                        case 5:  return Sse4_1.extract_epi8(a, 5);
                        case 4:  return Sse4_1.extract_epi8(a, 4);
                        case 3:  return Sse4_1.extract_epi8(a, 3);
                        case 2:  return Sse4_1.extract_epi8(a, 2);
                        case 1:  return Sse4_1.extract_epi8(a, 1);
                        case 0:  return (byte)Sse2.cvtsi128_si32(a);

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else if (Sse2.IsSse2Supported)
                {
                    switch (i)
                    {
                        case 15: return (byte)((uint)Sse2.extract_epi16(a, 7) >> 8);
                        case 14: return (byte)Sse2.extract_epi16(a, 7);
                        case 13: return (byte)((uint)Sse2.extract_epi16(a, 6) >> 8);
                        case 12: return (byte)Sse2.extract_epi16(a, 6);
                        case 11: return (byte)((uint)Sse2.extract_epi16(a, 5) >> 8);
                        case 10: return (byte)Sse2.extract_epi16(a, 5);
                        case 9:  return (byte)((uint)Sse2.extract_epi16(a, 4) >> 8);
                        case 8:  return (byte)Sse2.extract_epi16(a, 4);
                        case 7:  return (byte)((ulong)Sse2.cvtsi128_si64x(a) >> 56);
                        case 6:  return (byte)((ulong)Sse2.cvtsi128_si64x(a) >> 48);
                        case 5:  return (byte)((ulong)Sse2.cvtsi128_si64x(a) >> 40);
                        case 4:  return (byte)((ulong)Sse2.cvtsi128_si64x(a) >> 32);
                        case 3:  return (byte)((uint)Sse2.cvtsi128_si32(a) >> 24);
                        case 2:  return (byte)((uint)Sse2.cvtsi128_si32(a) >> 16);
                        case 1:  return (byte)((uint)Sse2.cvtsi128_si32(a) >> 8);
                        case 0:  return (byte)Sse2.cvtsi128_si32(a);

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Xse.imm8.Arm.vgetq_lane_u8(a, i);
                }
                else throw new IllegalInstructionException();
            }
            else
            {
Assert.IsNotGreater(i, 15);

                return *((byte*)&a + i);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort extract_epi16(v128 a, byte i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (Sse2.IsSse2Supported)
                {
                    switch (i)
                    {
                        case 7: return Sse2.extract_epi16(a, 7);
                        case 6: return Sse2.extract_epi16(a, 6);
                        case 5: return Sse2.extract_epi16(a, 5);
                        case 4: return Sse2.extract_epi16(a, 4);
                        case 3: return Sse2.extract_epi16(a, 3);
                        case 2: return Sse2.extract_epi16(a, 2);
                        case 1: return Sse2.extract_epi16(a, 1);
                        case 0: return (ushort)Sse2.cvtsi128_si32(a);

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Xse.imm8.Arm.vgetq_lane_u16(a, i);
                }
                else throw new IllegalInstructionException();
            }
            else
            {
Assert.IsNotGreater(i, 7);

                return *((ushort*)&a + i);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint extract_epi32(v128 a, byte i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (Sse4_1.IsSse41Supported)
                {
                    switch (i)
                    {
                        case 3: return (uint)Sse4_1.extract_epi32(a, 3);
                        case 2: return (uint)Sse4_1.extract_epi32(a, 2);
                        case 1: return (uint)Sse4_1.extract_epi32(a, 1);
                        case 0: return (uint)Sse2.cvtsi128_si32(a);

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else if (Sse2.IsSse2Supported)
                {
                    switch (i)
                    {
                        case 3: return (uint)Sse2.cvtsi128_si32(bsrli_si128(a, 3 * sizeof(int)));
                        case 2: return (uint)Sse2.cvtsi128_si32(bsrli_si128(a, 2 * sizeof(int)));
                        case 1: return (uint)((ulong)Sse2.cvtsi128_si64x(a) >> 32);
                        case 0: return (uint)Sse2.cvtsi128_si32(a);

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Xse.imm8.Arm.vgetq_lane_u32(a, i);
                }
                else throw new IllegalInstructionException();
            }
            else
            {
Assert.IsNotGreater(i, 3);

                return *((uint*)&a + i);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong extract_epi64(v128 a, byte i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (Sse4_1.IsSse41Supported)
                {
                    switch (i)
                    {
                        case 1: return (ulong)Sse4_1.extract_epi64(a, 1);
                        case 0: return (ulong)Sse2.cvtsi128_si64x(a);

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else if (Sse2.IsSse2Supported)
                {
                    switch (i)
                    {
                        case 1: return (ulong)Sse2.cvtsi128_si64x(bsrli_si128(a, 1 * sizeof(ulong)));
                        case 0: return (ulong)Sse2.cvtsi128_si64x(a);

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Xse.imm8.Arm.vgetq_lane_u64(a, i);
                }
                else throw new IllegalInstructionException();
            }
            else
            {
Assert.IsNotGreater(i, 1);

                return *((ulong*)&a + i);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float extract_ps(v128 a, byte i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (Sse4_1.IsSse41Supported)
                {
                    switch (i)
                    {
                        case 3: return Sse4_1.extractf_ps(a, 3);
                        case 2: return Sse4_1.extractf_ps(a, 2);
                        case 1: return Sse4_1.extractf_ps(a, 1);
                        case 0: return math.asfloat(Sse2.cvtsi128_si32(a));

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else if (Sse2.IsSse2Supported)
                {
                    switch (i)
                    {
                        case 3: return math.asfloat(Sse2.cvtsi128_si32(bsrli_si128(a, 3 * sizeof(float))));
                        case 2: return math.asfloat(Sse2.cvtsi128_si32(bsrli_si128(a, 2 * sizeof(float))));
                        case 1: return math.asfloat(Sse2.cvtsi128_si32(bsrli_si128(a, 1 * sizeof(float))));
                        case 0: return math.asfloat(Sse2.cvtsi128_si32(a));

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Xse.imm8.Arm.vgetq_lane_f32(a, i);
                }
                else throw new IllegalInstructionException();
            }
            else
            {
Assert.IsNotGreater(i, 3);

                return *((float*)&a + i);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double extract_pd(v128 a, byte i)
        {
            if (Sse2.IsSse2Supported)
            {
                return math.asdouble(extract_epi64(a, i));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Xse.imm8.Arm.vgetq_lane_f32(a, i);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte mm256_extract_epi8(v256 a, byte i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (Avx2.IsAvx2Supported)
                {
                    switch (i)
                    {
                        case 31: return (byte)Avx2.mm256_extract_epi8(a, 31);
                        case 30: return (byte)Avx2.mm256_extract_epi8(a, 30);
                        case 29: return (byte)Avx2.mm256_extract_epi8(a, 29);
                        case 28: return (byte)Avx2.mm256_extract_epi8(a, 28);
                        case 27: return (byte)Avx2.mm256_extract_epi8(a, 27);
                        case 26: return (byte)Avx2.mm256_extract_epi8(a, 26);
                        case 25: return (byte)Avx2.mm256_extract_epi8(a, 25);
                        case 24: return (byte)Avx2.mm256_extract_epi8(a, 24);
                        case 23: return (byte)Avx2.mm256_extract_epi8(a, 23);
                        case 22: return (byte)Avx2.mm256_extract_epi8(a, 22);
                        case 21: return (byte)Avx2.mm256_extract_epi8(a, 21);
                        case 20: return (byte)Avx2.mm256_extract_epi8(a, 20);
                        case 19: return (byte)Avx2.mm256_extract_epi8(a, 19);
                        case 18: return (byte)Avx2.mm256_extract_epi8(a, 18);
                        case 17: return (byte)Avx2.mm256_extract_epi8(a, 17);
                        case 16: return (byte)Avx2.mm256_extract_epi8(a, 16);
                        case 15: return (byte)Avx2.mm256_extract_epi8(a, 15);
                        case 14: return (byte)Avx2.mm256_extract_epi8(a, 14);
                        case 13: return (byte)Avx2.mm256_extract_epi8(a, 13);
                        case 12: return (byte)Avx2.mm256_extract_epi8(a, 12);
                        case 11: return (byte)Avx2.mm256_extract_epi8(a, 11);
                        case 10: return (byte)Avx2.mm256_extract_epi8(a, 10);
                        case 9:  return (byte)Avx2.mm256_extract_epi8(a, 9);
                        case 8:  return (byte)Avx2.mm256_extract_epi8(a, 8);
                        case 7:  return (byte)Avx2.mm256_extract_epi8(a, 7);
                        case 6:  return (byte)Avx2.mm256_extract_epi8(a, 6);
                        case 5:  return (byte)Avx2.mm256_extract_epi8(a, 5);
                        case 4:  return (byte)Avx2.mm256_extract_epi8(a, 4);
                        case 3:  return (byte)Avx2.mm256_extract_epi8(a, 3);
                        case 2:  return (byte)Avx2.mm256_extract_epi8(a, 2);
                        case 1:  return (byte)Avx2.mm256_extract_epi8(a, 1);
                        case 0:  return (byte)Sse2.cvtsi128_si32(Avx.mm256_castsi256_si128(a));

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else throw new IllegalInstructionException();
            }
            else
            {
Assert.IsNotGreater(i, 31);

                return *((byte*)&a + i);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort mm256_extract_epi16(v256 a, byte i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (Avx2.IsAvx2Supported)
                {
                    switch (i)
                    {
                        case 15: return (ushort)Avx2.mm256_extract_epi16(a, 15);
                        case 14: return (ushort)Avx2.mm256_extract_epi16(a, 14);
                        case 13: return (ushort)Avx2.mm256_extract_epi16(a, 13);
                        case 12: return (ushort)Avx2.mm256_extract_epi16(a, 12);
                        case 11: return (ushort)Avx2.mm256_extract_epi16(a, 11);
                        case 10: return (ushort)Avx2.mm256_extract_epi16(a, 10);
                        case 9:  return (ushort)Avx2.mm256_extract_epi16(a, 9);
                        case 8:  return (ushort)Avx2.mm256_extract_epi16(a, 8);
                        case 7:  return (ushort)Avx2.mm256_extract_epi16(a, 7);
                        case 6:  return (ushort)Avx2.mm256_extract_epi16(a, 6);
                        case 5:  return (ushort)Avx2.mm256_extract_epi16(a, 5);
                        case 4:  return (ushort)Avx2.mm256_extract_epi16(a, 4);
                        case 3:  return (ushort)Avx2.mm256_extract_epi16(a, 3);
                        case 2:  return (ushort)Avx2.mm256_extract_epi16(a, 2);
                        case 1:  return (ushort)Avx2.mm256_extract_epi16(a, 1);
                        case 0:  return (ushort)Sse2.cvtsi128_si32(Avx.mm256_castsi256_si128(a));

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else throw new IllegalInstructionException();
            }
            else
            {
Assert.IsNotGreater(i, 15);

                return *((ushort*)&a + i);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mm256_extract_epi32(v256 a, byte i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (Avx.IsAvxSupported)
                {
                    switch (i)
                    {
                        case 7:  return (uint)Avx.mm256_extract_epi32(a, 7);
                        case 6:  return (uint)Avx.mm256_extract_epi32(a, 6);
                        case 5:  return (uint)Avx.mm256_extract_epi32(a, 5);
                        case 4:  return (uint)Avx.mm256_extract_epi32(a, 4);
                        case 3:  return (uint)Avx.mm256_extract_epi32(a, 3);
                        case 2:  return (uint)Avx.mm256_extract_epi32(a, 2);
                        case 1:  return (uint)Avx.mm256_extract_epi32(a, 1);
                        case 0:  return (uint)Sse2.cvtsi128_si32(Avx.mm256_castsi256_si128(a));

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else throw new IllegalInstructionException();
            }
            else
            {
Assert.IsNotGreater(i, 7);

                return *((uint*)&a + i);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong mm256_extract_epi64(v256 a, byte i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (Avx.IsAvxSupported)
                {
                    switch (i)
                    {
                        case 3:  return (ulong)Avx.mm256_extract_epi64(a, 3);
                        case 2:  return (ulong)Avx.mm256_extract_epi64(a, 2);
                        case 1:  return (ulong)Avx.mm256_extract_epi64(a, 1);
                        case 0:  return (ulong)Sse2.cvtsi128_si64x(Avx.mm256_castsi256_si128(a));

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else throw new IllegalInstructionException();
            }
            else
            {
Assert.IsNotGreater(i, 3);

                return *((ulong*)&a + i);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float mm256_extract_ps(v256 a, byte i)
        {
            if (Avx.IsAvxSupported)
            {
                return math.asfloat(mm256_extract_epi32(a, i));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double mm256_extract_pd(v256 a, byte i)
        {
            if (Avx.IsAvxSupported)
            {
                return math.asdouble(mm256_extract_epi64(a, i));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 insert_epi8(v128 a, byte v, byte i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (Sse4_1.IsSse41Supported)
                {
                    switch (i)
                    {
                        case 15: return Sse4_1.insert_epi8(a, v, 15);
                        case 14: return Sse4_1.insert_epi8(a, v, 14);
                        case 13: return Sse4_1.insert_epi8(a, v, 13);
                        case 12: return Sse4_1.insert_epi8(a, v, 12);
                        case 11: return Sse4_1.insert_epi8(a, v, 11);
                        case 10: return Sse4_1.insert_epi8(a, v, 10);
                        case 9:  return Sse4_1.insert_epi8(a, v, 9);
                        case 8:  return Sse4_1.insert_epi8(a, v, 8);
                        case 7:  return Sse4_1.insert_epi8(a, v, 7);
                        case 6:  return Sse4_1.insert_epi8(a, v, 6);
                        case 5:  return Sse4_1.insert_epi8(a, v, 5);
                        case 4:  return Sse4_1.insert_epi8(a, v, 4);
                        case 3:  return Sse4_1.insert_epi8(a, v, 3);
                        case 2:  return Sse4_1.insert_epi8(a, v, 2);
                        case 1:  return Sse4_1.insert_epi8(a, v, 1);
                        case 0:  return Sse4_1.insert_epi8(a, v, 0);

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else if (Sse2.IsSse2Supported)
                {
                    switch (i)
                    {
                        case 15:
                        {
                            ushort s = Sse2.extract_epi16(a, 7);
                            *((byte*)&s + 1) = v;

                            return Sse2.insert_epi16(a, s, 7);
                        }
                        case 14:
                        {
                            ushort s = Sse2.extract_epi16(a, 7);
                            *(byte*)&s = v;

                            return Sse2.insert_epi16(a, s, 7);
                        }
                        case 13:
                        {
                            ushort s = Sse2.extract_epi16(a, 6);
                            *((byte*)&s + 1) = v;

                            return Sse2.insert_epi16(a, s, 6);
                        }
                        case 12:
                        {
                            ushort s = Sse2.extract_epi16(a, 6);
                            *(byte*)&s = v;

                            return Sse2.insert_epi16(a, s, 6);
                        }
                        case 11:
                        {
                            ushort s = Sse2.extract_epi16(a, 5);
                            *((byte*)&s + 1) = v;

                            return Sse2.insert_epi16(a, s, 5);
                        }
                        case 10:
                        {
                            ushort s = Sse2.extract_epi16(a, 5);
                            *(byte*)&s = v;

                            return Sse2.insert_epi16(a, s, 5);
                        }
                        case 9:
                        {
                            ushort s = Sse2.extract_epi16(a, 4);
                            *((byte*)&s + 1) = v;

                            return Sse2.insert_epi16(a, s, 4);
                        }
                        case 8:
                        {
                            ushort s = Sse2.extract_epi16(a, 4);
                            *(byte*)&s = v;

                            return Sse2.insert_epi16(a, s, 4);
                        }
                        case 7:
                        {
                            v128 MASK = Xse.cvtsi64x_si128(0xFF00_0000_0000_0000);

                            return Sse2.or_si128(Xse.cvtsi64x_si128((long)v << 56), Sse2.andnot_si128(MASK, a));
                        }
                        case 6:
                        {
                            v128 MASK = Xse.cvtsi64x_si128(0xFF_0000_0000_0000);

                            return Sse2.or_si128(Xse.cvtsi64x_si128((long)v << 48), Sse2.andnot_si128(MASK, a));
                        }
                        case 5:
                        {
                            v128 MASK = Xse.cvtsi64x_si128(0xFF00_0000_0000);

                            return Sse2.or_si128(Xse.cvtsi64x_si128((long)v << 40), Sse2.andnot_si128(MASK, a));
                        }
                        case 4:
                        {
                            v128 MASK = Xse.cvtsi64x_si128(0xFF_0000_0000);

                            return Sse2.or_si128(Xse.cvtsi64x_si128((long)v << 32), Sse2.andnot_si128(MASK, a));
                        }
                        case 3:
                        {
                            v128 MASK = Xse.cvtsi32_si128(0xFF00_0000);

                            return Sse2.or_si128(Xse.cvtsi32_si128(v << 24), Sse2.andnot_si128(MASK, a));
                        }
                        case 2:
                        {
                            v128 MASK = Xse.cvtsi32_si128(0xFF_0000);

                            return Sse2.or_si128(Xse.cvtsi32_si128(v << 16), Sse2.andnot_si128(MASK, a));
                        }
                        case 1:
                        {
                            v128 MASK = Xse.cvtsi32_si128(0xFF00);

                            return Sse2.or_si128(Xse.cvtsi32_si128(v << 8), Sse2.andnot_si128(MASK, a));
                        }
                        case 0:
                        {
                            v128 MASK = Xse.cvtsi32_si128(0xFF);

                            return Sse2.or_si128(Xse.cvtsi32_si128(v), Sse2.andnot_si128(MASK, a));
                        }

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Xse.imm8.Arm.vsetq_lane_s8((sbyte)v, a, i);
                }
                else throw new IllegalInstructionException();
            }
            else
            {
Assert.IsNotGreater(i, 15);

                *((byte*)&a + i) = v;

                return a;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 insert_epi16(v128 a, ushort v, byte i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (Sse2.IsSse2Supported)
                {
                    switch (i)
                    {
                        case 7: return Sse2.insert_epi16(a, v, 7);
                        case 6: return Sse2.insert_epi16(a, v, 6);
                        case 5: return Sse2.insert_epi16(a, v, 5);
                        case 4: return Sse2.insert_epi16(a, v, 4);
                        case 3: return Sse2.insert_epi16(a, v, 3);
                        case 2: return Sse2.insert_epi16(a, v, 2);
                        case 1: return Sse2.insert_epi16(a, v, 1);
                        case 0: return Sse2.insert_epi16(a, v, 0);

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Xse.imm8.Arm.vsetq_lane_s16((short)v, a, i);
                }
                else throw new IllegalInstructionException();
            }
            else
            {
Assert.IsNotGreater(i, 7);

                *((ushort*)&a + i) = v;

                return a;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 insert_epi32(v128 a, uint v, byte i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (Sse4_1.IsSse41Supported)
                {
                    switch (i)
                    {
                        case 3: return Sse4_1.insert_epi32(a, (int)v, 3);
                        case 2: return Sse4_1.insert_epi32(a, (int)v, 2);
                        case 1: return Sse4_1.insert_epi32(a, (int)v, 1);
                        case 0: return Sse4_1.insert_epi32(a, (int)v, 0);

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else if (Sse2.IsSse2Supported)
                {
                    switch (i)
                    {
                        case 3: return Sse2.or_si128(bslli_si128(Xse.cvtsi32_si128((int)v), 3 * sizeof(int)), Sse2.and_si128(new v128(-1, -1, -1, 0), a));
                        case 2: return Sse2.or_si128(bslli_si128(Xse.cvtsi32_si128((int)v), 2 * sizeof(int)), Sse2.and_si128(new v128(-1, -1, 0, -1), a));
                        case 1: return Sse2.or_si128(Xse.cvtsi64x_si128((long)v << 32), Sse2.andnot_si128(Xse.cvtsi64x_si128(0xFFFF_FFFF_0000_0000), a));
                        case 0: return Sse2.or_si128(Xse.cvtsi32_si128((int)v), Sse2.andnot_si128(Xse.cvtsi32_si128(0xFFFF_FFFF), a));

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Xse.imm8.Arm.vsetq_lane_s32((int)v, a, i);
                }
                else throw new IllegalInstructionException();
            }
            else
            {
Assert.IsNotGreater(i, 3);

                *((uint*)&a + i) = v;

                return a;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 insert_epi64(v128 a, ulong v, byte i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (Sse4_1.IsSse41Supported)
                {
                    switch (i)
                    {
                        case 1: return Sse4_1.insert_epi64(a, (long)v, 1);
                        case 0: return Sse4_1.insert_epi64(a, (long)v, 0);

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else if (Sse2.IsSse2Supported)
                {
                    switch (i)
                    {
                        case 1: return Sse2.unpacklo_epi64(a, Xse.cvtsi64x_si128((long)v));
                        case 0: return Sse2.or_si128(Xse.cvtsi64x_si128((long)v), Sse2.andnot_si128(Xse.cvtsi64x_si128(-1L), a));

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Xse.imm8.Arm.vsetq_lane_s64((long)v, a, i);
                }
                else throw new IllegalInstructionException();
            }
            else
            {
Assert.IsNotGreater(i, 1);

                *((ulong*)&a + i) = v;

                return a;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 insert_ps(v128 a, float v, byte i)
        {
            if (Architecture.IsSIMDSupported)
            {
                return insert_epi32(a, math.asuint(v), i);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 insert_pd(v128 a, double v, byte i)
        {
            if (Architecture.IsSIMDSupported)
            {
                return insert_epi64(a, math.asulong(v), i);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_insert_epi8(v256 a, byte v, byte i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (Avx.IsAvxSupported)
                {
                    switch (i)
                    {
                        case 31: return Avx.mm256_insert_epi8(a, (sbyte)v, 31);
                        case 30: return Avx.mm256_insert_epi8(a, (sbyte)v, 30);
                        case 29: return Avx.mm256_insert_epi8(a, (sbyte)v, 29);
                        case 28: return Avx.mm256_insert_epi8(a, (sbyte)v, 28);
                        case 27: return Avx.mm256_insert_epi8(a, (sbyte)v, 27);
                        case 26: return Avx.mm256_insert_epi8(a, (sbyte)v, 26);
                        case 25: return Avx.mm256_insert_epi8(a, (sbyte)v, 25);
                        case 24: return Avx.mm256_insert_epi8(a, (sbyte)v, 24);
                        case 23: return Avx.mm256_insert_epi8(a, (sbyte)v, 23);
                        case 22: return Avx.mm256_insert_epi8(a, (sbyte)v, 22);
                        case 21: return Avx.mm256_insert_epi8(a, (sbyte)v, 21);
                        case 20: return Avx.mm256_insert_epi8(a, (sbyte)v, 20);
                        case 19: return Avx.mm256_insert_epi8(a, (sbyte)v, 19);
                        case 18: return Avx.mm256_insert_epi8(a, (sbyte)v, 18);
                        case 17: return Avx.mm256_insert_epi8(a, (sbyte)v, 17);
                        case 16: return Avx.mm256_insert_epi8(a, (sbyte)v, 16);
                        case 15: return Avx.mm256_insert_epi8(a, (sbyte)v, 15);
                        case 14: return Avx.mm256_insert_epi8(a, (sbyte)v, 14);
                        case 13: return Avx.mm256_insert_epi8(a, (sbyte)v, 13);
                        case 12: return Avx.mm256_insert_epi8(a, (sbyte)v, 12);
                        case 11: return Avx.mm256_insert_epi8(a, (sbyte)v, 11);
                        case 10: return Avx.mm256_insert_epi8(a, (sbyte)v, 10);
                        case 9:  return Avx.mm256_insert_epi8(a, (sbyte)v, 9);
                        case 8:  return Avx.mm256_insert_epi8(a, (sbyte)v, 8);
                        case 7:  return Avx.mm256_insert_epi8(a, (sbyte)v, 7);
                        case 6:  return Avx.mm256_insert_epi8(a, (sbyte)v, 6);
                        case 5:  return Avx.mm256_insert_epi8(a, (sbyte)v, 5);
                        case 4:  return Avx.mm256_insert_epi8(a, (sbyte)v, 4);
                        case 3:  return Avx.mm256_insert_epi8(a, (sbyte)v, 3);
                        case 2:  return Avx.mm256_insert_epi8(a, (sbyte)v, 2);
                        case 1:  return Avx.mm256_insert_epi8(a, (sbyte)v, 1);
                        case 0:  return Avx.mm256_insert_epi8(a, (sbyte)v, 0);

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else throw new IllegalInstructionException();
            }
            else
            {
Assert.IsNotGreater(i, 31);

                *((byte*)&a + i) = v;

                return a;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_insert_epi16(v256 a, ushort v, byte i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (Avx.IsAvxSupported)
                {
                    switch (i)
                    {
                        case 15: return Avx.mm256_insert_epi16(a, (short)v, 15);
                        case 14: return Avx.mm256_insert_epi16(a, (short)v, 14);
                        case 13: return Avx.mm256_insert_epi16(a, (short)v, 13);
                        case 12: return Avx.mm256_insert_epi16(a, (short)v, 12);
                        case 11: return Avx.mm256_insert_epi16(a, (short)v, 11);
                        case 10: return Avx.mm256_insert_epi16(a, (short)v, 10);
                        case 9:  return Avx.mm256_insert_epi16(a, (short)v, 9);
                        case 8:  return Avx.mm256_insert_epi16(a, (short)v, 8);
                        case 7:  return Avx.mm256_insert_epi16(a, (short)v, 7);
                        case 6:  return Avx.mm256_insert_epi16(a, (short)v, 6);
                        case 5:  return Avx.mm256_insert_epi16(a, (short)v, 5);
                        case 4:  return Avx.mm256_insert_epi16(a, (short)v, 4);
                        case 3:  return Avx.mm256_insert_epi16(a, (short)v, 3);
                        case 2:  return Avx.mm256_insert_epi16(a, (short)v, 2);
                        case 1:  return Avx.mm256_insert_epi16(a, (short)v, 1);
                        case 0:  return Avx.mm256_insert_epi16(a, (short)v, 0);

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else throw new IllegalInstructionException();
            }
            else
            {
Assert.IsNotGreater(i, 15);

                *((ushort*)&a + i) = v;

                return a;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_insert_epi32(v256 a, uint v, byte i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (Avx.IsAvxSupported)
                {
                    switch (i)
                    {
                        case 7: return Avx.mm256_insert_epi32(a, (int)v, 7);
                        case 6: return Avx.mm256_insert_epi32(a, (int)v, 6);
                        case 5: return Avx.mm256_insert_epi32(a, (int)v, 5);
                        case 4: return Avx.mm256_insert_epi32(a, (int)v, 4);
                        case 3: return Avx.mm256_insert_epi32(a, (int)v, 3);
                        case 2: return Avx.mm256_insert_epi32(a, (int)v, 2);
                        case 1: return Avx.mm256_insert_epi32(a, (int)v, 1);
                        case 0: return Avx.mm256_insert_epi32(a, (int)v, 0);

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else throw new IllegalInstructionException();
            }
            else
            {
Assert.IsNotGreater(i, 7);

                *((uint*)&a + i) = v;

                return a;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_insert_epi64(v256 a, ulong v, byte i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (Avx.IsAvxSupported)
                {
                    switch (i)
                    {
                        case 3: return Avx.mm256_insert_epi64(a, (long)v, 3);
                        case 2: return Avx.mm256_insert_epi64(a, (long)v, 2);
                        case 1: return Avx.mm256_insert_epi64(a, (long)v, 1);
                        case 0: return Avx.mm256_insert_epi64(a, (long)v, 0);

                        default: throw new IndexOutOfRangeException();
                    }
                }
                else throw new IllegalInstructionException();
            }
            else
            {
Assert.IsNotGreater(i, 3);

                *((ulong*)&a + i) = v;

                return a;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_insert_ps(v256 a, float v, byte i)
        {
            if (Avx.IsAvxSupported)
            {
                return mm256_insert_epi32(a, math.asuint(v), i);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_insert_pd(v256 a, double v, byte i)
        {
            if (Avx.IsAvxSupported)
            {
                return mm256_insert_epi64(a, math.asulong(v), i);
            }
            else throw new IllegalInstructionException();
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 insert_ps(v128 a, v128 b, int imm8)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.insert_ps(a, b, imm8);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                v128 mask = new v128
                (
                    (imm8 & (1 << 0)) != 0 ? -1 : 0,
                    (imm8 & (1 << 1)) != 0 ? -1 : 0,
                    (imm8 & (1 << 1)) != 0 ? -1 : 0,
                    (imm8 & (1 << 1)) != 0 ? -1 : 0
                );

                v128 tmp1 = Xse.imm8.Arm.vsetq_lane_f32(Xse.imm8.Arm.vgetq_lane_f32(b, (imm8 >> 6) & 0x3), a, 0);
                v128 tmp2 = Xse.imm8.Arm.vsetq_lane_f32(Xse.imm8.Arm.vgetq_lane_f32(tmp1, 0), a, ((imm8 >> 4) & 0x3));

                return Arm.Neon.vbslq_f32(mask, setzero_ps(), tmp2);
            }
			else throw new IllegalInstructionException();
		}
    }
}
