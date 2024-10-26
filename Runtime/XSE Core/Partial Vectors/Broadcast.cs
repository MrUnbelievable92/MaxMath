using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtsi32_si128(int a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.cvtsi32_si128(a);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Xse.imm8.Arm.vsetq_lane_s32(a, Arm.Neon.vdupq_n_s32(0), 0);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtsi64x_si128(long a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.cvtsi64x_si128(a);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Xse.imm8.Arm.vsetq_lane_s64(a, Arm.Neon.vdupq_n_s64(0), 0);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtsi32_si128(uint a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtsi32_si128((int)a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtsi64x_si128(ulong a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtsi64x_si128((long)a);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtsi32_si256(int a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_castsi128_si256(cvtsi32_si128(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtsi64x_si256(long a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_castsi128_si256(cvtsi64x_si128(a));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtsi32_si256(uint a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_castsi128_si256(cvtsi32_si128(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtsi64x_si256(ulong a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_castsi128_si256(cvtsi64x_si128(a));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 set1_epi8(byte a, byte elements = 16)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 lo = cvtsi32_si128(a);

                if (Ssse3.IsSsse3Supported)
                {
                    return shuffle_epi8(lo, setzero_si128());
                }
                else
                {
                    switch(elements)
                    {
                        case 1:
                        {
                            return lo;
                        }
                        case 2:
                        {
                            return unpacklo_epi8(lo, lo);
                        }
                        case 3:
                        case 4:
                        case 8:
                        {
                            lo = unpacklo_epi8(lo, lo);

                            return shufflelo_epi16(lo, Sse.SHUFFLE(0, 0, 0, 0));
                        }
                        default:
                        {
                            return Sse2.set1_epi8((sbyte)a);
                        }
                    }
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vdupq_n_s8((sbyte)a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 set1_epi16(ushort a, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 lo = cvtsi32_si128(a);

                if (Ssse3.IsSsse3Supported)
                {
                    return shuffle_epi16(lo, setzero_si128());
                }
                else
                {
                    switch(elements)
                    {
                        case 1:
                        {
                            return lo;
                        }
                        case 2:
                        case 3:
                        case 4:
                        {
                            return shufflelo_epi16(lo, Sse.SHUFFLE(0, 0, 0, 0));
                        }
                        default:
                        {
                            return Sse2.set1_epi16((short)a);
                        }
                    }
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vdupq_n_s16((short)a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 set1_epi32(uint a, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                if (elements == 1)
                {
                    return cvtsi32_si128(a);
                }
                else
                {
                    return Sse2.set1_epi32((int)a);
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vdupq_n_s32((int)a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 set1_epi64x(ulong a, byte elements = 2)
        {
            if (Sse2.IsSse2Supported)
            {
                if (elements == 1)
                {
                    return cvtsi64x_si128(a);
                }
                else
                {
                    return Sse2.set1_epi64x((long)a);
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vdupq_n_s64((long)a);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 set1_epi8(sbyte a, byte elements = 16)
        {
            if (Architecture.IsSIMDSupported)
            {
                return set1_epi8((byte)a, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 set1_epi16(short a, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                return set1_epi16((ushort)a, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 set1_epi32(int a, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                return set1_epi32((uint)a, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 set1_epi64x(long a, byte elements = 2)
        {
            if (Architecture.IsSIMDSupported)
            {
                return set1_epi64x((ulong)a, elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 set1_ps(float a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse.set1_ps(a);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vdupq_n_f32(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 set1_pd(double a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.set1_pd(a);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vdupq_n_f64(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_set1_epi8(sbyte a)
        {
            if (Avx.IsAvxSupported)
            {
                return mm256_set1_epi8((byte)a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_set1_epi16(short a)
        {
            if (Avx.IsAvxSupported)
            {
                return mm256_set1_epi16((ushort)a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_set1_epi32(int a)
        {
            if (Avx.IsAvxSupported)
            {
                return mm256_set1_epi32((uint)a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_set1_epi64x(long a)
        {
            if (Avx.IsAvxSupported)
            {
                return mm256_set1_epi64x((ulong)a);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_set1_epi8(byte a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_set1_epi8(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_set1_epi16(ushort a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_set1_epi16((short)a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_set1_epi32(uint a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_set1_epi32((int)a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_set1_epi64x(ulong a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_set1_epi64x((long)a);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_set1_ps(float a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_set1_ps(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_set1_pd(double a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_set1_pd(a);
            }
            else throw new IllegalInstructionException();
        }
    }
}
