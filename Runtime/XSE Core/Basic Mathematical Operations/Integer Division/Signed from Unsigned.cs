using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte SIGNED_FROM_UNSIGNED_DIV_I8(out sbyte signedRemainder, sbyte signedDividend, sbyte signedDivisor, byte unsignedQuotient, byte unsignedRemainder, bool divisorPositive = false, bool divisorNegative = false, bool dividendPositive = false, bool dividendNegative = false)
        {
            dividendPositive |= constexpr.IS_TRUE(signedDividend >= 0);
            dividendNegative |= constexpr.IS_TRUE(signedDividend <= 0);
            divisorPositive |= constexpr.IS_TRUE(signedDivisor >= 0);
            divisorNegative |= constexpr.IS_TRUE(signedDivisor <= 0);

            sbyte signedQuotient = (sbyte)unsignedQuotient;
            signedRemainder = (sbyte)unsignedRemainder;

            if (dividendPositive && divisorPositive)
            {
                return signedQuotient;
            }

            if (!dividendPositive)
            {
                signedRemainder = signedDividend <= 0 ? (sbyte)-unsignedRemainder : signedRemainder;
            }

            if (!((dividendPositive && divisorPositive)
               || (dividendNegative && divisorNegative)))
            {
                if ((dividendPositive && divisorNegative)
                 || (dividendNegative && divisorPositive))
                {
                    signedQuotient = (sbyte)-signedQuotient;
                }
                else
                {
                    signedQuotient = (sbyte)(signedDividend ^ signedDivisor) < 0 ? (sbyte)-signedQuotient : signedQuotient;
                }
            }

            return signedQuotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 SIGNED_FROM_UNSIGNED_DIV_EPI8(out v128 signedRemainder, v128 signedDividend, v128 signedDivisor, v128 unsignedQuotient, v128 unsignedRemainder, byte elements = 16, bool divisorPositive = false, bool divisorNegative = false, bool dividendPositive = false, bool dividendNegative = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                dividendPositive |= constexpr.ALL_GE_EPI8(signedDividend, 0, elements);
                dividendNegative |= constexpr.ALL_LE_EPI8(signedDividend, 0, elements);
                divisorPositive |= constexpr.ALL_GE_EPI8(signedDivisor, 0, elements);
                divisorNegative |= constexpr.ALL_LE_EPI8(signedDivisor, 0, elements);

                v128 signedQuotient = unsignedQuotient;
                signedRemainder = unsignedRemainder;

                if (dividendPositive && divisorPositive)
                {
                    return signedQuotient;
                }

                v128 dividendNegativeMask = dividendNegative ? setall_si128() : srai_epi8(signedDividend, 7);
                v128 divisorNegativeMask = divisorNegative ? setall_si128() : srai_epi8(signedDivisor, 7);

                if (!dividendPositive)
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        signedRemainder = sign_epi8(unsignedRemainder, signedDividend);
                    }
                    else
                    {
                        signedRemainder = sub_epi8(xor_si128(unsignedRemainder, dividendNegativeMask), dividendNegativeMask);
                    }
                }

                if (!((dividendPositive && divisorPositive)
                   || (dividendNegative && divisorNegative)))
                {
                    if ((dividendPositive && divisorNegative)
                     || (dividendNegative && divisorPositive))
                    {
                        signedQuotient = neg_epi8(signedQuotient);
                    }
                    else
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            v128 signMask = xor_si128(signedDividend, signedDivisor);
                            if (!constexpr.ALL_NEQ_EPI8(signedDividend, signedDivisor, elements))
                            {
                                signMask = sub_epi8(signMask, cmpeq_epi8(signedDividend, signedDivisor));
                            }

                            signedQuotient = sign_epi8(unsignedQuotient, signMask);
                        }
                        else
                        {
                            v128 mustNegateQ = xor_si128(dividendNegativeMask, divisorNegativeMask);

                            signedQuotient = sub_epi8(xor_si128(unsignedQuotient, mustNegateQ), mustNegateQ);
                        }
                    }
                }

                return signedQuotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 SIGNED_FROM_UNSIGNED_DIV_EPI8(out v256 signedRemainder, v256 signedDividend, v256 signedDivisor, v256 unsignedQuotient, v256 unsignedRemainder, bool divisorPositive = false, bool divisorNegative = false, bool dividendPositive = false, bool dividendNegative = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                dividendPositive |= constexpr.ALL_GE_EPI8(signedDividend, 0);
                dividendNegative |= constexpr.ALL_LE_EPI8(signedDividend, 0);
                divisorPositive |= constexpr.ALL_GE_EPI8(signedDivisor, 0);
                divisorNegative |= constexpr.ALL_LE_EPI8(signedDivisor, 0);

                v256 signedQuotient = unsignedQuotient;
                signedRemainder = unsignedRemainder;

                if (dividendPositive && divisorPositive)
                {
                    return signedQuotient;
                }

                if (!dividendPositive)
                {
                    signedRemainder = Avx2.mm256_sign_epi8(unsignedRemainder, signedDividend);
                }

                if (!((dividendPositive && divisorPositive)
                   || (dividendNegative && divisorNegative)))
                {
                    if ((dividendPositive && divisorNegative)
                     || (dividendNegative && divisorPositive))
                    {
                        signedQuotient = mm256_neg_epi8(signedQuotient);
                    }
                    else
                    {
                        v256 signMask = Avx2.mm256_xor_si256(signedDividend, signedDivisor);
                        if (!constexpr.ALL_NEQ_EPI8(signedDividend, signedDivisor))
                        {
                            signMask = Avx2.mm256_sub_epi8(signMask, Avx2.mm256_cmpeq_epi8(signedDividend, signedDivisor));
                        }

                        signedQuotient = Avx2.mm256_sign_epi8(unsignedQuotient, signMask);
                    }
                }

                return signedQuotient;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short SIGNED_FROM_UNSIGNED_DIV_I16(out short signedRemainder, short signedDividend, short signedDivisor, ushort unsignedQuotient, ushort unsignedRemainder, bool divisorPositive = false, bool divisorNegative = false, bool dividendPositive = false, bool dividendNegative = false)
        {
            dividendPositive |= constexpr.IS_TRUE(signedDividend >= 0);
            dividendNegative |= constexpr.IS_TRUE(signedDividend <= 0);
            divisorPositive |= constexpr.IS_TRUE(signedDivisor >= 0);
            divisorNegative |= constexpr.IS_TRUE(signedDivisor <= 0);

            short signedQuotient = (short)unsignedQuotient;
            signedRemainder = (short)unsignedRemainder;

            if (dividendPositive && divisorPositive)
            {
                return signedQuotient;
            }

            if (!dividendPositive)
            {
                signedRemainder = (short)(signedDividend <= 0 ? -unsignedRemainder : signedRemainder);
            }

            if (!((dividendPositive && divisorPositive)
               || (dividendNegative && divisorNegative)))
            {
                if ((dividendPositive && divisorNegative)
                 || (dividendNegative && divisorPositive))
                {
                    signedQuotient = (short)-signedQuotient;
                }
                else
                {
                    signedQuotient = (short)(signedDividend ^ signedDivisor) < 0 ? (short)-signedQuotient : signedQuotient;
                }
            }

            return signedQuotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 SIGNED_FROM_UNSIGNED_DIV_EPI16(out v128 signedRemainder, v128 signedDividend, v128 signedDivisor, v128 unsignedQuotient, v128 unsignedRemainder, byte elements = 8, bool divisorPositive = false, bool divisorNegative = false, bool dividendPositive = false, bool dividendNegative = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                dividendPositive |= constexpr.ALL_GE_EPI16(signedDividend, 0, elements);
                dividendNegative |= constexpr.ALL_LE_EPI16(signedDividend, 0, elements);
                divisorPositive |= constexpr.ALL_GE_EPI16(signedDivisor, 0, elements);
                divisorNegative |= constexpr.ALL_LE_EPI16(signedDivisor, 0, elements);

                v128 signedQuotient = unsignedQuotient;
                signedRemainder = unsignedRemainder;

                if (dividendPositive && divisorPositive)
                {
                    return signedQuotient;
                }

                v128 dividendNegativeMask = dividendNegative ? setall_si128() : srai_epi16(signedDividend, 15);
                v128 divisorNegativeMask = divisorNegative ? setall_si128() : srai_epi16(signedDivisor, 15);

                if (!dividendPositive)
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        signedRemainder = sign_epi16(unsignedRemainder, signedDividend);
                    }
                    else
                    {
                        signedRemainder = sub_epi16(xor_si128(unsignedRemainder, dividendNegativeMask), dividendNegativeMask);
                    }
                }

                if (!((dividendPositive && divisorPositive)
                   || (dividendNegative && divisorNegative)))
                {
                    if ((dividendPositive && divisorNegative)
                     || (dividendNegative && divisorPositive))
                    {
                        signedQuotient = neg_epi16(signedQuotient);
                    }
                    else
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            v128 signMask = xor_si128(signedDividend, signedDivisor);
                            if (!constexpr.ALL_NEQ_EPI16(signedDividend, signedDivisor, elements))
                            {
                                signMask = sub_epi16(signMask, cmpeq_epi16(signedDividend, signedDivisor));
                            }

                            signedQuotient = sign_epi16(unsignedQuotient, signMask);
                        }
                        else
                        {
                            v128 mustNegateQ = xor_si128(dividendNegativeMask, divisorNegativeMask);

                            signedQuotient = sub_epi16(xor_si128(unsignedQuotient, mustNegateQ), mustNegateQ);
                        }
                    }
                }

                return signedQuotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 SIGNED_FROM_UNSIGNED_DIV_EPI16(out v256 signedRemainder, v256 signedDividend, v256 signedDivisor, v256 unsignedQuotient, v256 unsignedRemainder, bool divisorPositive = false, bool divisorNegative = false, bool dividendPositive = false, bool dividendNegative = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                dividendPositive |= constexpr.ALL_GE_EPI16(signedDividend, 0);
                dividendNegative |= constexpr.ALL_LE_EPI16(signedDividend, 0);
                divisorPositive |= constexpr.ALL_GE_EPI16(signedDivisor, 0);
                divisorNegative |= constexpr.ALL_LE_EPI16(signedDivisor, 0);

                v256 signedQuotient = unsignedQuotient;
                signedRemainder = unsignedRemainder;

                if (dividendPositive && divisorPositive)
                {
                    return signedQuotient;
                }

                if (!dividendPositive)
                {
                    signedRemainder = Avx2.mm256_sign_epi16(unsignedRemainder, signedDividend);
                }

                if (!((dividendPositive && divisorPositive)
                   || (dividendNegative && divisorNegative)))
                {
                    if ((dividendPositive && divisorNegative)
                     || (dividendNegative && divisorPositive))
                    {
                        signedQuotient = mm256_neg_epi16(signedQuotient);
                    }
                    else
                    {
                        v256 signMask = Avx2.mm256_xor_si256(signedDividend, signedDivisor);
                        if (!constexpr.ALL_NEQ_EPI16(signedDividend, signedDivisor))
                        {
                            signMask = Avx2.mm256_sub_epi16(signMask, Avx2.mm256_cmpeq_epi16(signedDividend, signedDivisor));
                        }

                        signedQuotient = Avx2.mm256_sign_epi16(unsignedQuotient, signMask);
                    }
                }

                return signedQuotient;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int SIGNED_FROM_UNSIGNED_DIV_I32(out int signedRemainder, int signedDividend, int signedDivisor, uint unsignedQuotient, uint unsignedRemainder, bool divisorPositive = false, bool divisorNegative = false, bool dividendPositive = false, bool dividendNegative = false)
        {
            dividendPositive |= constexpr.IS_TRUE(signedDividend >= 0);
            dividendNegative |= constexpr.IS_TRUE(signedDividend <= 0);
            divisorPositive |= constexpr.IS_TRUE(signedDivisor >= 0);
            divisorNegative |= constexpr.IS_TRUE(signedDivisor <= 0);

            int signedQuotient = (int)unsignedQuotient;
            signedRemainder = (int)unsignedRemainder;

            if (dividendPositive && divisorPositive)
            {
                return signedQuotient;
            }

            if (!dividendPositive)
            {
                signedRemainder = signedDividend <= 0 ? -signedRemainder : signedRemainder;
            }

            if (!((dividendPositive && divisorPositive)
               || (dividendNegative && divisorNegative)))
            {
                if ((dividendPositive && divisorNegative)
                 || (dividendNegative && divisorPositive))
                {
                    signedQuotient = -signedQuotient;
                }
                else
                {
                    signedQuotient = (signedDividend ^ signedDivisor) < 0 ? -signedQuotient : signedQuotient;
                }
            }

            return signedQuotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 SIGNED_FROM_UNSIGNED_DIV_EPI32(out v128 signedRemainder, v128 signedDividend, v128 signedDivisor, v128 unsignedQuotient, v128 unsignedRemainder, byte elements = 4, bool divisorPositive = false, bool divisorNegative = false, bool dividendPositive = false, bool dividendNegative = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                dividendPositive |= constexpr.ALL_GE_EPI32(signedDividend, 0, elements);
                dividendNegative |= constexpr.ALL_LE_EPI32(signedDividend, 0, elements);
                divisorPositive |= constexpr.ALL_GE_EPI32(signedDivisor, 0, elements);
                divisorNegative |= constexpr.ALL_LE_EPI32(signedDivisor, 0, elements);

                v128 signedQuotient = unsignedQuotient;
                signedRemainder = unsignedRemainder;

                if (dividendPositive && divisorPositive)
                {
                    return signedQuotient;
                }

                v128 dividendNegativeMask = dividendNegative ? setall_si128() : srai_epi32(signedDividend, 31);
                v128 divisorNegativeMask = divisorNegative ? setall_si128() : srai_epi32(signedDivisor, 31);

                if (!dividendPositive)
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        signedRemainder = sign_epi32(unsignedRemainder, signedDividend);
                    }
                    else
                    {
                        signedRemainder = sub_epi32(xor_si128(unsignedRemainder, dividendNegativeMask), dividendNegativeMask);
                    }
                }

                if (!((dividendPositive && divisorPositive)
                   || (dividendNegative && divisorNegative)))
                {
                    if ((dividendPositive && divisorNegative)
                     || (dividendNegative && divisorPositive))
                    {
                        signedQuotient = neg_epi32(signedQuotient);
                    }
                    else
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            v128 signMask = xor_si128(signedDividend, signedDivisor);
                            if (!constexpr.ALL_NEQ_EPI32(signedDividend, signedDivisor, elements))
                            {
                                signMask = sub_epi32(signMask, cmpeq_epi32(signedDividend, signedDivisor));
                            }

                            signedQuotient = sign_epi32(unsignedQuotient, signMask);
                        }
                        else
                        {
                            v128 mustNegateQ = xor_si128(dividendNegativeMask, divisorNegativeMask);

                            signedQuotient = sub_epi32(xor_si128(unsignedQuotient, mustNegateQ), mustNegateQ);
                        }
                    }
                }

                return signedQuotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 SIGNED_FROM_UNSIGNED_DIV_EPI32(out v256 signedRemainder, v256 signedDividend, v256 signedDivisor, v256 unsignedQuotient, v256 unsignedRemainder, bool divisorPositive = false, bool divisorNegative = false, bool dividendPositive = false, bool dividendNegative = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                dividendPositive |= constexpr.ALL_GE_EPI32(signedDividend, 0);
                dividendNegative |= constexpr.ALL_LE_EPI32(signedDividend, 0);
                divisorPositive |= constexpr.ALL_GE_EPI32(signedDivisor, 0);
                divisorNegative |= constexpr.ALL_LE_EPI32(signedDivisor, 0);

                v256 signedQuotient = unsignedQuotient;
                signedRemainder = unsignedRemainder;

                if (dividendPositive && divisorPositive)
                {
                    return signedQuotient;
                }

                if (!dividendPositive)
                {
                    signedRemainder = Avx2.mm256_sign_epi32(unsignedRemainder, signedDividend);
                }

                if (!((dividendPositive && divisorPositive)
                   || (dividendNegative && divisorNegative)))
                {
                    if ((dividendPositive && divisorNegative)
                     || (dividendNegative && divisorPositive))
                    {
                        signedQuotient = mm256_neg_epi32(signedQuotient);
                    }
                    else
                    {
                        v256 signMask = Avx2.mm256_xor_si256(signedDividend, signedDivisor);
                        if (!constexpr.ALL_NEQ_EPI32(signedDividend, signedDivisor))
                        {
                            signMask = Avx2.mm256_sub_epi32(signMask, Avx2.mm256_cmpeq_epi32(signedDividend, signedDivisor));
                        }

                        signedQuotient = Avx2.mm256_sign_epi32(unsignedQuotient, signMask);
                    }
                }

                return signedQuotient;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long SIGNED_FROM_UNSIGNED_DIV_I64(out long signedRemainder, long signedDividend, long signedDivisor, ulong unsignedQuotient, ulong unsignedRemainder, bool divisorPositive = false, bool divisorNegative = false, bool dividendPositive = false, bool dividendNegative = false)
        {
            dividendPositive |= constexpr.IS_TRUE(signedDividend >= 0);
            dividendNegative |= constexpr.IS_TRUE(signedDividend <= 0);
            divisorPositive |= constexpr.IS_TRUE(signedDivisor >= 0);
            divisorNegative |= constexpr.IS_TRUE(signedDivisor <= 0);

            long signedQuotient = (long)unsignedQuotient;
            signedRemainder = (long)unsignedRemainder;

            if (dividendPositive && divisorPositive)
            {
                return signedQuotient;
            }

            if (!dividendPositive)
            {
                signedRemainder = signedDividend <= 0 ? -signedRemainder : signedRemainder;
            }

            if (!((dividendPositive && divisorPositive)
               || (dividendNegative && divisorNegative)))
            {
                if ((dividendPositive && divisorNegative)
                 || (dividendNegative && divisorPositive))
                {
                    signedQuotient = -signedQuotient;
                }
                else
                {
                    signedQuotient = (signedDividend ^ signedDivisor) < 0 ? -signedQuotient : signedQuotient;
                }
            }

            return signedQuotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 SIGNED_FROM_UNSIGNED_DIV_EPI64(out v128 signedRemainder, v128 signedDividend, v128 signedDivisor, v128 unsignedQuotient, v128 unsignedRemainder, bool divisorPositive = false, bool divisorNegative = false, bool dividendPositive = false, bool dividendNegative = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                dividendPositive |= constexpr.ALL_GE_EPI64(signedDividend, 0);
                dividendNegative |= constexpr.ALL_LE_EPI64(signedDividend, 0);
                divisorPositive |= constexpr.ALL_GE_EPI64(signedDivisor, 0);
                divisorNegative |= constexpr.ALL_LE_EPI64(signedDivisor, 0);

                v128 signedQuotient = unsignedQuotient;
                signedRemainder = unsignedRemainder;

                if (dividendPositive && divisorPositive)
                {
                    return signedQuotient;
                }

                v128 dividendNegativeMask = dividendNegative ? setall_si128() : srai_epi64(signedDividend, 63);
                v128 divisorNegativeMask = dividendNegative ? setall_si128() : srai_epi64(signedDivisor, 63);

                if (!dividendPositive)
                {
                    signedRemainder = sub_epi64(xor_si128(unsignedRemainder, dividendNegativeMask), dividendNegativeMask);
                }

                if (!((dividendPositive && divisorPositive)
                   || (dividendNegative && divisorNegative)))
                {
                    if ((dividendPositive && divisorNegative)
                     || (dividendNegative && divisorPositive))
                    {
                        signedQuotient = neg_epi64(signedQuotient);
                    }
                    else
                    {
                        v128 mustNegateQ = xor_si128(dividendNegativeMask, divisorNegativeMask);

                        signedQuotient = sub_epi64(xor_si128(unsignedQuotient, mustNegateQ), mustNegateQ);
                    }
                }

                return signedQuotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 SIGNED_FROM_UNSIGNED_DIV_EPI64(out v256 signedRemainder, v256 signedDividend, v256 signedDivisor, v256 unsignedQuotient, v256 unsignedRemainder, byte elements = 4, bool divisorPositive = false, bool divisorNegative = false, bool dividendPositive = false, bool dividendNegative = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                dividendPositive |= constexpr.ALL_GE_EPI64(signedDividend, 0, elements);
                dividendNegative |= constexpr.ALL_LE_EPI64(signedDividend, 0, elements);
                divisorPositive |= constexpr.ALL_GE_EPI64(signedDivisor, 0, elements);
                divisorNegative |= constexpr.ALL_LE_EPI64(signedDivisor, 0, elements);

                v256 signedQuotient = unsignedQuotient;
                signedRemainder = unsignedRemainder;

                if (dividendPositive && divisorPositive)
                {
                    return signedQuotient;
                }

                v256 dividendNegativeMask = dividendNegative ? mm256_setall_si256() : mm256_srai_epi64(signedDividend, 63);
                v256 divisorNegativeMask = divisorNegative ? mm256_setall_si256() : mm256_srai_epi64(signedDivisor, 63);

                if (!dividendPositive)
                {
                    signedRemainder = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(unsignedRemainder, dividendNegativeMask), dividendNegativeMask);
                }

                if (!((dividendPositive && divisorPositive)
                   || (dividendNegative && divisorNegative)))
                {
                    if ((dividendPositive && divisorNegative)
                     || (dividendNegative && divisorPositive))
                    {
                        signedQuotient = mm256_neg_epi64(signedQuotient);
                    }
                    else
                    {
                        v256 mustNegateQ = Avx2.mm256_xor_si256(dividendNegativeMask, divisorNegativeMask);

                        signedQuotient = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(unsignedQuotient, mustNegateQ), mustNegateQ);
                    }
                }

                return signedQuotient;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Int128 SIGNED_FROM_UNSIGNED_DIV_I128(out Int128 signedRemainder, long signedDividendHi, long signedDivisorHi, UInt128 unsignedQuotient, UInt128 unsignedRemainder, bool divisorPositive = false, bool divisorNegative = false, bool dividendPositive = false, bool dividendNegative = false)
        {
            dividendPositive |= constexpr.IS_TRUE(signedDividendHi >= 0);
            dividendNegative |= constexpr.IS_TRUE(signedDividendHi /*intentional*/ < /*intentional*/ 0);
            divisorPositive |= constexpr.IS_TRUE(signedDivisorHi >= 0);
            divisorNegative |= constexpr.IS_TRUE(signedDivisorHi /*intentional*/ < /*intentional*/ 0);

            Int128 signedQuotient = (Int128)unsignedQuotient;
            signedRemainder = (Int128)unsignedRemainder;

            if (dividendPositive && divisorPositive)
            {
                return signedQuotient;
            }

            if (!dividendPositive)
            {
                signedRemainder = signedDividendHi <= 0 ? -signedRemainder : signedRemainder;
            }

            if (!((dividendPositive && divisorPositive)
               || (dividendNegative && divisorNegative)))
            {
                if ((dividendPositive && divisorNegative)
                 || (dividendNegative && divisorPositive))
                {
                    signedQuotient = -signedQuotient;
                }
                else
                {
                    signedQuotient = (signedDividendHi ^ signedDivisorHi) < 0 ? -signedQuotient : signedQuotient;
                }
            }

            return signedQuotient;
        }
    }
}
