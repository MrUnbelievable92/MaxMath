using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epu8(v128 a, bool nonZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPI8(a, 0, elements);

                    v128 result = cmpeq_epi8(blsr_epi8(a), setzero_si128());

                    if (!nonZero)
                    {
                        result = andnot_si128(cmpeq_epi8(a, setzero_si128()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epu16(v128 a, bool nonZero = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPI16(a, 0, elements);

                    v128 result = cmpeq_epi16(blsr_epi16(a), setzero_si128());
                    
                    if (!nonZero)
                    {
                        result = andnot_si128(cmpeq_epi16(a, setzero_si128()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epu32(v128 a, bool nonZero = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPI32(a, 0, elements);

                    v128 result = cmpeq_epi32(blsr_epi32(a), setzero_si128());
                    
                    if (!nonZero)
                    {
                        result = andnot_si128(cmpeq_epi32(a, setzero_si128()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epu64(v128 a, bool nonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPI64(a, 0);

                    v128 result = cmpeq_epi64(blsr_epi64(a), setzero_si128());
                    
                    if (!nonZero)
                    {
                        result = andnot_si128(cmpeq_epi64(a, setzero_si128()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epu8(v256 a, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPI8(a, 0);

                    v256 result = Avx2.mm256_cmpeq_epi8(mm256_blsr_epi8(a), Avx.mm256_setzero_si256());
                    
                    if (!nonZero)
                    {
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi8(a, Avx.mm256_setzero_si256()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epu16(v256 a, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPI16(a, 0);

                    v256 result = Avx2.mm256_cmpeq_epi16(mm256_blsr_epi16(a), Avx.mm256_setzero_si256());
                    
                    if (!nonZero)
                    {
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi16(a, Avx.mm256_setzero_si256()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epu32(v256 a, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPI32(a, 0);

                    v256 result = Avx2.mm256_cmpeq_epi32(mm256_blsr_epi32(a), Avx.mm256_setzero_si256());
                    
                    if (!nonZero)
                    {
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(a, Avx.mm256_setzero_si256()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epu64(v256 a, bool nonZero = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPI64(a, 0, elements);

                    v256 result = Avx2.mm256_cmpeq_epi64(mm256_blsr_epi64(a), Avx.mm256_setzero_si256());
                    
                    if (!nonZero)
                    {
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(a, Avx.mm256_setzero_si256()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epi8(v128 a, bool positive = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    positive |= constexpr.ALL_GT_EPI8(a, 0, elements);

                    v128 result = cmpeq_epi8(blsr_epi8(a), setzero_si128());

                    if (!positive)
                    {
                        result = and_si128(cmpgt_epi8(a, setzero_si128()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epi16(v128 a, bool positive = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    positive |= constexpr.ALL_GT_EPI16(a, 0, elements);

                    v128 result = cmpeq_epi16(blsr_epi16(a), setzero_si128());
                    
                    if (!positive)
                    {
                        result = and_si128(cmpgt_epi16(a, setzero_si128()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epi32(v128 a, bool positive = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    positive |= constexpr.ALL_GT_EPI32(a, 0, elements);

                    v128 result = cmpeq_epi32(blsr_epi32(a), setzero_si128());
                    
                    if (!positive)
                    {
                        result = and_si128(cmpgt_epi32(a, setzero_si128()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epi64(v128 a, bool positive = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    positive |= constexpr.ALL_GT_EPI64(a, 0);

                    v128 result = cmpeq_epi64(blsr_epi64(a), setzero_si128());
                    
                    if (!positive)
                    {
                        result = and_si128(cmpgt_epi64(a, setzero_si128()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epi8(v256 a, bool positive = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    positive |= constexpr.ALL_GT_EPI8(a, 0);

                    v256 result = Avx2.mm256_cmpeq_epi8(mm256_blsr_epi8(a), Avx.mm256_setzero_si256());
                    
                    if (!positive)
                    {
                        result = Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi8(a, Avx.mm256_setzero_si256()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epi16(v256 a, bool positive = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    positive |= constexpr.ALL_GT_EPI16(a, 0);

                    v256 result = Avx2.mm256_cmpeq_epi16(mm256_blsr_epi16(a), Avx.mm256_setzero_si256());
                    
                    if (!positive)
                    {
                        result = Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi16(a, Avx.mm256_setzero_si256()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epi32(v256 a, bool positive = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    positive |= constexpr.ALL_GT_EPI32(a, 0);

                    v256 result = Avx2.mm256_cmpeq_epi32(mm256_blsr_epi32(a), Avx.mm256_setzero_si256());
                    
                    if (!positive)
                    {
                        result = Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi32(a, Avx.mm256_setzero_si256()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epi64(v256 a, bool positive = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    positive |= constexpr.ALL_GT_EPI64(a, 0, elements);

                    v256 result = Avx2.mm256_cmpeq_epi64(mm256_blsr_epi64(a), Avx.mm256_setzero_si256());
                    
                    if (!positive)
                    {
                        result = Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi64(a, Avx.mm256_setzero_si256()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }

    unsafe public static partial class math
    {
        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> if <paramref name="x"/> is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(UInt128 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsPopcntSupported)
            {
                return countbits(x) == 1;
            }
            else
            {
                return (promises.Promises(Promise.NonZero) || x.IsNotZero) & (bits_resetlowest(x) == 0);
            }
        }
        
        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(Int128 x, Promise promises = Promise.Nothing)
        {
            return  (promises.Promises(Promise.Positive) || (x > 0)) & (bits_resetlowest(x) == 0);
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> if <paramref name="x"/> is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(byte x, Promise promises = Promise.Nothing)
        {
            return (promises.Promises(Promise.NonZero) || (x != 0)) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 ispow2(byte2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu8(x, promises.Promises(Promise.NonZero), 2);
            }
            else
            {
                return new mask8x2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 ispow2(byte3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu8(x, promises.Promises(Promise.NonZero), 3);
            }
            else
            {
                return new mask8x3(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 ispow2(byte4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu8(x, promises.Promises(Promise.NonZero), 4);
            }
            else
            {
                return new mask8x4(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises), ispow2(x.w, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 ispow2(byte8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu8(x, promises.Promises(Promise.NonZero), 8);
            }
            else
            {
                return new mask8x8(ispow2(x.x0, promises), ispow2(x.x1, promises), ispow2(x.x2, promises), ispow2(x.x3, promises), ispow2(x.x4, promises), ispow2(x.x5, promises), ispow2(x.x6, promises), ispow2(x.x7, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 ispow2(byte16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu8(x, promises.Promises(Promise.NonZero), 16);
            }
            else
            {
                return new mask8x16(ispow2(x.x0, promises), ispow2(x.x1, promises), ispow2(x.x2, promises), ispow2(x.x3, promises), ispow2(x.x4, promises), ispow2(x.x5, promises), ispow2(x.x6, promises), ispow2(x.x7, promises), ispow2(x.x8, promises), ispow2(x.x9, promises), ispow2(x.x10, promises), ispow2(x.x11, promises), ispow2(x.x12, promises), ispow2(x.x13, promises), ispow2(x.x14, promises), ispow2(x.x15, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 ispow2(byte32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epu8(x, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new mask8x32(ispow2(x.v16_0, promises), ispow2(x.v16_16, promises));
            }
        }

        
        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results if <paramref name="x"/> is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(sbyte x, Promise promises = Promise.Nothing)
        {
            return (promises.Promises(Promise.Positive) || (x > 0)) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 ispow2(sbyte2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi8(x, promises.Promises(Promise.Positive), 2);
            }
            else
            {
                return new mask8x2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 ispow2(sbyte3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi8(x, promises.Promises(Promise.Positive), 3);
            }
            else
            {
                return new mask8x3(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 ispow2(sbyte4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi8(x, promises.Promises(Promise.Positive), 4);
            }
            else
            {
                return new mask8x4(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises), ispow2(x.w, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 ispow2(sbyte8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi8(x, promises.Promises(Promise.Positive), 8);
            }
            else
            {
                return new mask8x8(ispow2(x.x0, promises), ispow2(x.x1, promises), ispow2(x.x2, promises), ispow2(x.x3, promises), ispow2(x.x4, promises), ispow2(x.x5, promises), ispow2(x.x6, promises), ispow2(x.x7, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 ispow2(sbyte16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi8(x, promises.Promises(Promise.Positive), 16);
            }
            else
            {
                return new mask8x16(ispow2(x.x0, promises), ispow2(x.x1, promises), ispow2(x.x2, promises), ispow2(x.x3, promises), ispow2(x.x4, promises), ispow2(x.x5, promises), ispow2(x.x6, promises), ispow2(x.x7, promises), ispow2(x.x8, promises), ispow2(x.x9, promises), ispow2(x.x10, promises), ispow2(x.x11, promises), ispow2(x.x12, promises), ispow2(x.x13, promises), ispow2(x.x14, promises), ispow2(x.x15, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 ispow2(sbyte32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epi8(x, promises.Promises(Promise.Positive));
            }
            else
            {
                return new mask8x32(ispow2(x.v16_0, promises), ispow2(x.v16_16, promises));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> if <paramref name="x"/> is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(ushort x, Promise promises = Promise.Nothing)
        {
            return (promises.Promises(Promise.NonZero) || (x != 0)) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 ispow2(ushort2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu16(x, promises.Promises(Promise.NonZero), 2);
            }
            else
            {
                return new mask16x2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 ispow2(ushort3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu16(x, promises.Promises(Promise.NonZero), 3);
            }
            else
            {
                return new mask16x3(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 ispow2(ushort4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu16(x, promises.Promises(Promise.NonZero), 4);
            }
            else
            {
                return new mask16x4(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises), ispow2(x.w, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 ispow2(ushort8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu16(x, promises.Promises(Promise.NonZero), 8);
            }
            else
            {
                return new mask16x8(ispow2(x.x0, promises), ispow2(x.x1, promises), ispow2(x.x2, promises), ispow2(x.x3, promises), ispow2(x.x4, promises), ispow2(x.x5, promises), ispow2(x.x6, promises), ispow2(x.x7, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 ispow2(ushort16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epu16(x, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new mask16x16(ispow2(x.v8_0, promises), ispow2(x.v8_8, promises));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results if <paramref name="x"/> is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(short x, Promise promises = Promise.Nothing)
        {
            return (promises.Promises(Promise.Positive) || (x > 0)) & (bits_resetlowest(x) == 0);
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(short2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi16(x, promises.Promises(Promise.Positive), 2);
            }
            else
            {
                return new mask16x2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 ispow2(short3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi16(x, promises.Promises(Promise.Positive), 3);
            }
            else
            {
                return new mask16x3(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 ispow2(short4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi16(x, promises.Promises(Promise.Positive), 4);
            }
            else
            {
                return new mask16x4(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises), ispow2(x.w, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 ispow2(short8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi16(x, promises.Promises(Promise.Positive), 8);
            }
            else
            {
                return new mask16x8(ispow2(x.x0, promises), ispow2(x.x1, promises), ispow2(x.x2, promises), ispow2(x.x3, promises), ispow2(x.x4, promises), ispow2(x.x5, promises), ispow2(x.x6, promises), ispow2(x.x7, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 ispow2(short16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epi16(x, promises.Promises(Promise.Positive));
            }
            else
            {
                return new mask16x16(ispow2(x.v8_0, promises), ispow2(x.v8_8, promises));
            }
        }

        
        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> if <paramref name="x"/> is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(uint x, Promise promises = Promise.Nothing)
        {
            return (promises.Promises(Promise.NonZero) || (x != 0)) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(uint2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu32(x, promises.Promises(Promise.NonZero), 2);
            }
            else
            {
                return new mask32x2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 ispow2(uint3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu32(x, promises.Promises(Promise.NonZero), 3);
            }
            else
            {
                return new mask32x3(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 ispow2(uint4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu32(x, promises.Promises(Promise.NonZero), 4);
            }
            else
            {
                return new mask32x4(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises), ispow2(x.w, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 ispow2(uint8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epu32(x, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new mask32x8(ispow2(x.v4_0, promises), ispow2(x.v4_4, promises));
            }
        }

        
        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results if <paramref name="x"/> is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(int x, Promise promises = Promise.Nothing)
        {
            return (promises.Promises(Promise.Positive) || (x > 0)) & (bits_resetlowest(x) == 0);
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(int2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi32(x, promises.Promises(Promise.Positive), 2);
            }
            else
            {
                return new mask32x2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 ispow2(int3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi32(x, promises.Promises(Promise.Positive), 3);
            }
            else
            {
                return new mask32x3(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 ispow2(int4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi32(x, promises.Promises(Promise.Positive), 4);
            }
            else
            {
                return new mask32x4(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises), ispow2(x.w, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 ispow2(int8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epi32(x, promises.Promises(Promise.Positive));
            }
            else
            {
                return new mask32x8(ispow2(x.v4_0, promises), ispow2(x.v4_4, promises));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> if <paramref name="x"/> is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(ulong x, Promise promises = Promise.Nothing)
        {
            return (promises.Promises(Promise.NonZero) || (x != 0)) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 ispow2(ulong2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu64(x, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new mask64x2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 ispow2(ulong3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epu64(x, promises.Promises(Promise.NonZero), 3);
            }
            else
            {
                return new mask64x3(ispow2(x.xy, promises), ispow2(x.z, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 ispow2(ulong4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epu64(x, promises.Promises(Promise.NonZero), 4);
            }
            else
            {
                return new mask64x4(ispow2(x.xy, promises), ispow2(x.zw, promises));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results if <paramref name="x"/> is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(long x, Promise promises = Promise.Nothing)
        {
            return (promises.Promises(Promise.Positive) || (x > 0)) & (bits_resetlowest(x) == 0);
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 ispow2(long2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi64(x, promises.Promises(Promise.Positive));
            }
            else
            {
                return new mask64x2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 ispow2(long3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epi64(x, promises.Promises(Promise.Positive), 3);
            }
            else
            {
                return new mask64x3(ispow2(x.xy, promises), ispow2(x.z, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 ispow2(long4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epi64(x, promises.Promises(Promise.Positive), 4);
            }
            else
            {
                return new mask64x4(ispow2(x.xy, promises), ispow2(x.zw, promises));
            }
        }
    }
}