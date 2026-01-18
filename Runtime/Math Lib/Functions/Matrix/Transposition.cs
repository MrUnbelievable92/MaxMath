using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>		Returns the <see cref="MaxMath.long2x2"/> transposition of a <see cref="MaxMath.long2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 transpose(long2x2 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return new long2x2(Xse.unpacklo_epi64(v.c0, v.c1),
                                   Xse.unpackhi_epi64(v.c0, v.c1));
            }
            else
            {
                return new long2x2(v.c0.x, v.c0.y,
                                   v.c1.x, v.c1.y);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.long3x2"/> transposition of a <see cref="MaxMath.long2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 transpose(long2x3 v)
        {
            if (Avx2.IsAvx2Supported)
            {
                return new long3x2(Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(Xse.unpacklo_epi64(v.c0, v.c1)), v.c2,    1),
                                   Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(Xse.unpackhi_epi64(v.c0, v.c1)), v.c2.yx, 1));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new long3x2(new long3(Xse.unpacklo_epi64(v.c0, v.c1), v.c2.x),
                                   new long3(Xse.unpackhi_epi64(v.c0, v.c1), v.c2.y));
            }
            else
            {
                return new long3x2(v.c0.x, v.c0.y,
                                   v.c1.x, v.c1.y,
                                   v.c2.x, v.c2.y);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.long4x2"/> transposition of a <see cref="MaxMath.long2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 transpose(long2x4 v)
        {
            if (Avx2.IsAvx2Supported)
            {
                long4 lo = new long4(v.c0, v.c2);
                long4 hi = new long4(v.c1, v.c3);

                return new long4x2(Avx2.mm256_unpacklo_epi64(lo, hi),
                                   Avx2.mm256_unpackhi_epi64(lo, hi));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new long4x2(new long4(Xse.unpacklo_epi64(v.c0, v.c1),
                                             Xse.unpacklo_epi64(v.c2, v.c3)),
                                   new long4(Xse.unpackhi_epi64(v.c0, v.c1),
                                             Xse.unpackhi_epi64(v.c2, v.c3)));
            }
            else
            {
                return new long4x2(v.c0.x, v.c0.y,
                                   v.c1.x, v.c1.y,
                                   v.c2.x, v.c2.y,
                                   v.c3.x, v.c3.y);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.long2x3"/> transposition of a <see cref="MaxMath.long3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 transpose(long3x2 v)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 unpacklo = Avx2.mm256_unpacklo_epi64(v.c0, v.c1);

                return new long2x3(Avx.mm256_castsi256_si128(unpacklo),
                                   Avx.mm256_castsi256_si128(Avx2.mm256_unpackhi_epi64(v.c0, v.c1)),
                                   Avx2.mm256_extracti128_si256(unpacklo, 1));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new long2x3(Xse.unpacklo_epi64(v.c0._xy, v.c1._xy),
                                   Xse.unpackhi_epi64(v.c0._xy, v.c1._xy),
                                   new long2(v.c0.z, v.c1.z));
            }
            else
            {
                return new long2x3(v.c0.x, v.c0.y, v.c0.z,
                                   v.c1.x, v.c1.y, v.c1.z);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.long3x3"/> transposition of a <see cref="MaxMath.long3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x3 transpose(long3x3 v)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 lo = Avx2.mm256_unpacklo_epi64(v.c0, v.c1);
                v256 hi = Avx2.mm256_unpackhi_epi64(v.c0, v.c1);

                return new long3x3(Avx2.mm256_inserti128_si256(lo, Avx.mm256_castsi256_si128(v.c2), 1),
                                   Avx2.mm256_inserti128_si256(hi, ((long2)Avx.mm256_castsi256_si128(v.c2)).yx, 1),
                                   Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(Avx2.mm256_extracti128_si256(lo, 1)), Avx2.mm256_extracti128_si256(v.c2, 1), 1));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new long3x3(new long3(Xse.unpacklo_epi64(v.c0._xy, v.c1._xy), v.c2.x),
                                   new long3(Xse.unpackhi_epi64(v.c0._xy, v.c1._xy), v.c2.y),
                                   new long3(v.c0.z, v.c1.z, v.c2.z));
            }
            else
            {
                return new long3x3(v.c0.x, v.c0.y, v.c0.z,
                                   v.c1.x, v.c1.y, v.c1.z,
                                   v.c2.x, v.c2.y, v.c2.z);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.long4x3"/> transposition of a <see cref="MaxMath.long3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 transpose(long3x4 v)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 lo_lo = Avx2.mm256_unpacklo_epi64(v.c0, v.c1);
                v256 lo_hi = Avx2.mm256_unpacklo_epi64(v.c2, v.c3);

                return new long4x3(Avx2.mm256_inserti128_si256(lo_lo, Avx.mm256_castsi256_si128(lo_hi), 1),
                                   Avx2.mm256_inserti128_si256(Avx2.mm256_unpackhi_epi64(v.c0, v.c1), Avx.mm256_castsi256_si128(Avx2.mm256_unpackhi_epi64(v.c2, v.c3)), 1),
                                   Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(Avx2.mm256_extracti128_si256(lo_lo, 1)), Avx2.mm256_extracti128_si256(lo_hi, 1), 1));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new long4x3(new long4(Xse.unpacklo_epi64(v.c0._xy, v.c1._xy), Xse.unpacklo_epi64(v.c2._xy, v.c3._xy)),
                                   new long4(Xse.unpackhi_epi64(v.c0._xy, v.c1._xy), Xse.unpackhi_epi64(v.c2._xy, v.c3._xy)),
                                   new long4(v.c0.z, v.c1.z, v.c2.z, v.c3.z));
            }
            else
            {
                return new long4x3(v.c0.x, v.c0.y, v.c0.z,
                                   v.c1.x, v.c1.y, v.c1.z,
                                   v.c2.x, v.c2.y, v.c2.z,
                                   v.c3.x, v.c3.y, v.c3.z);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.long2x4"/> transposition of a <see cref="MaxMath.long4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 transpose(long4x2 v)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 unpacklo = Avx2.mm256_unpacklo_epi64(v.c0, v.c1);
                v256 unpackhi = Avx2.mm256_unpackhi_epi64(v.c0, v.c1);

                return new long2x4(Avx.mm256_castsi256_si128(unpacklo),
                                   Avx.mm256_castsi256_si128(unpackhi),
                                   Avx2.mm256_extracti128_si256(unpacklo, 1),
                                   Avx2.mm256_extracti128_si256(unpackhi, 1));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new long2x4(Xse.unpacklo_epi64(v.c0._xy, v.c1._xy),
                                   Xse.unpackhi_epi64(v.c0._xy, v.c1._xy),
                                   Xse.unpacklo_epi64(v.c0._zw, v.c1._zw),
                                   Xse.unpackhi_epi64(v.c0._zw, v.c1._zw));
            }
            else
            {
                return new long2x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                   v.c1.x, v.c1.y, v.c1.z, v.c1.w);
            }
        }

        /// <summary>		Returns the long<see cref="MaxMath.long3x4"/>3x4 transposition of a <see cref="MaxMath.long4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x4 transpose(long4x3 v)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 lo = Avx2.mm256_unpacklo_epi64(v.c0, v.c1);
                v256 hi = Avx2.mm256_unpackhi_epi64(v.c0, v.c1);

                return new long3x4(Avx2.mm256_inserti128_si256(lo, Avx.mm256_castsi256_si128(v.c2), 1),
                                   Avx2.mm256_inserti128_si256(hi, ((long2)Avx.mm256_castsi256_si128(v.c2)).yx, 1),
                                   Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(Avx2.mm256_extracti128_si256(lo, 1)), Avx2.mm256_extracti128_si256(v.c2, 1), 1),
                                   Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(Avx2.mm256_extracti128_si256(hi, 1)), ((long2)Avx2.mm256_extracti128_si256(v.c2, 1)).yx, 1));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new long3x4(new long3(Xse.unpacklo_epi64(v.c0._xy, v.c1._xy), v.c2.x),
                                   new long3(Xse.unpackhi_epi64(v.c0._xy, v.c1._xy), v.c2.y),
                                   new long3(Xse.unpacklo_epi64(v.c0._zw, v.c1._zw), v.c2.z),
                                   new long3(Xse.unpackhi_epi64(v.c0._zw, v.c1._zw), v.c2.w));
            }
            else
            {
                return new long3x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                   v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                                   v.c2.x, v.c2.y, v.c2.z, v.c2.w);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.long4x4"/> transposition of a <see cref="MaxMath.long4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x4 transpose(long4x4 v)
        {
            if (Avx2.IsAvx2Supported)
            {
                long4 lo_lo = Avx2.mm256_unpacklo_epi64(v.c0, v.c1);
                long4 lo_hi = Avx2.mm256_unpacklo_epi64(v.c2, v.c3);

                long4 hi_lo = Avx2.mm256_unpackhi_epi64(v.c0, v.c1);
                long4 hi_hi = Avx2.mm256_unpackhi_epi64(v.c2, v.c3);

                return new long4x4(Avx2.mm256_inserti128_si256(lo_lo, Avx.mm256_castsi256_si128(lo_hi), 1),
                                   Avx2.mm256_inserti128_si256(hi_lo, Avx.mm256_castsi256_si128(hi_hi), 1),
                                   Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(Avx2.mm256_extracti128_si256(lo_lo, 1)), Avx2.mm256_extracti128_si256(lo_hi, 1), 1),
                                   Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(Avx2.mm256_extracti128_si256(hi_lo, 1)), Avx2.mm256_extracti128_si256(hi_hi, 1), 1));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new long4x4(new long4(Xse.unpacklo_epi64(v.c0._xy, v.c1._xy), Xse.unpacklo_epi64(v.c2._xy, v.c3._xy)),
                                   new long4(Xse.unpackhi_epi64(v.c0._xy, v.c1._xy), Xse.unpackhi_epi64(v.c2._xy, v.c3._xy)),
                                   new long4(Xse.unpacklo_epi64(v.c0._zw, v.c1._zw), Xse.unpacklo_epi64(v.c2._zw, v.c3._zw)),
                                   new long4(Xse.unpackhi_epi64(v.c0._zw, v.c1._zw), Xse.unpackhi_epi64(v.c2._zw, v.c3._zw)));
            }
            else
            {
                return new long4x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                   v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                                   v.c2.x, v.c2.y, v.c2.z, v.c2.w,
                                   v.c3.x, v.c3.y, v.c3.z, v.c3.w);
            }
        }


        /// <summary>		Returns the <see cref="MaxMath.ulong2x2"/> transposition of a u <see cref="MaxMath.long2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 transpose(ulong2x2 v)
        {
            return (ulong2x2)transpose((long2x2)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3x2"/> transposition of a u <see cref="MaxMath.long2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 transpose(ulong2x3 v)
        {
            return (ulong3x2)transpose((long2x3)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4x2"/> transposition of a u <see cref="MaxMath.long2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 transpose(ulong2x4 v)
        {
            return (ulong4x2)transpose((long2x4)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong2x3"/> transposition of a u <see cref="MaxMath.long3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 transpose(ulong3x2 v)
        {
            return (ulong2x3)transpose((long3x2)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3x3"/> transposition of a u <see cref="MaxMath.long3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 transpose(ulong3x3 v)
        {
            return (ulong3x3)transpose((long3x3)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4x3"/> transposition of a u <see cref="MaxMath.long3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 transpose(ulong3x4 v)
        {
            return (ulong4x3)transpose((long3x4)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong2x4"/> transposition of a u <see cref="MaxMath.long4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x4 transpose(ulong4x2 v)
        {
            return (ulong2x4)transpose((long4x2)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3x4"/> transposition of a u <see cref="MaxMath.long4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 transpose(ulong4x3 v)
        {
            return (ulong3x4)transpose((long4x3)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4x4"/> transposition of a u <see cref="MaxMath.long4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 transpose(ulong4x4 v)
        {
            return (ulong4x4)transpose((long4x4)v);
        }


        /// <summary>		Returns the <see cref="MaxMath.short2x2"/> transposition of a <see cref="MaxMath.short2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 transpose(short2x2 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo = Xse.unpacklo_epi16(v.c0, v.c1);

                return new short2x2(unpacklo,
                                    Xse.bsrli_si128(unpacklo, 2 * sizeof(short)));
            }
            else
            {
                return new short2x2(v.c0.x, v.c0.y,
                                    v.c1.x, v.c1.y);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.short3x2"/> transposition of a <see cref="MaxMath.short2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x2 transpose(short2x3 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo = Xse.unpacklo_epi16(v.c0, v.c1);

                return new short3x2(Xse.unpacklo_epi32(unpacklo, v.c2),
                                    Xse.unpacklo_epi32(Xse.bsrli_si128(unpacklo, 2 * sizeof(short)), Xse.bsrli_si128(v.c2, 1 * sizeof(short))));
            }
            else
            {
                return new short3x2(v.c0.x, v.c0.y,
                                    v.c1.x, v.c1.y,
                                    v.c2.x, v.c2.y);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.short4x2"/> transposition of a <see cref="MaxMath.short2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 transpose(short2x4 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo_lo = Xse.unpacklo_epi16(v.c0, v.c1);
                v128 unpacklo_hi = Xse.unpacklo_epi16(v.c2, v.c3);

                return new short4x2(Xse.unpacklo_epi32(unpacklo_lo, unpacklo_hi),
                                    Xse.unpacklo_epi32(Xse.bsrli_si128(unpacklo_lo, 2 * sizeof(short)), Xse.bsrli_si128(unpacklo_hi, 2 * sizeof(short))));
            }
            else
            {
                return new short4x2(v.c0.x, v.c0.y,
                                    v.c1.x, v.c1.y,
                                    v.c2.x, v.c2.y,
                                    v.c3.x, v.c3.y);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.short2x3"/> transposition of a <see cref="MaxMath.short3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 transpose(short3x2 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo = Xse.unpacklo_epi16(v.c0, v.c1);

                return new short2x3(unpacklo,
                                    Xse.bsrli_si128(unpacklo, 2 * sizeof(short)),
                                    Xse.bsrli_si128(unpacklo, 4 * sizeof(short)));
            }
            else
            {
                return new short2x3(v.c0.x, v.c0.y, v.c0.z,
                                    v.c1.x, v.c1.y, v.c1.z);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.short3x3"/> transposition of a <see cref="MaxMath.short3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 transpose(short3x3 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo = Xse.unpacklo_epi16(v.c0, v.c1);

                return new short3x3(Xse.unpacklo_epi32(unpacklo, v.c2),
                                    Xse.unpacklo_epi32(Xse.bsrli_si128(unpacklo, 2 * sizeof(short)), Xse.bsrli_si128(v.c2, 1 * sizeof(short))),
                                    Xse.unpacklo_epi32(Xse.bsrli_si128(unpacklo, 4 * sizeof(short)), Xse.bsrli_si128(v.c2, 2 * sizeof(short))));
            }
            else
            {
                return new short3x3(v.c0.x, v.c0.y, v.c0.z,
                                    v.c1.x, v.c1.y, v.c1.z,
                                    v.c2.x, v.c2.y, v.c2.z);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.short4x3"/> transposition of a <see cref="MaxMath.short3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 transpose(short3x4 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo_lo = Xse.unpacklo_epi16(v.c0, v.c1);
                v128 unpacklo_hi = Xse.unpacklo_epi16(v.c2, v.c3);

                v128 unpacklo = Xse.unpacklo_epi32(unpacklo_lo, unpacklo_hi);

                return new short4x3(unpacklo,
                                    Xse.bsrli_si128(unpacklo, 4 * sizeof(short)),
                                    Xse.unpacklo_epi32(Xse.bsrli_si128(unpacklo_lo, 4 * sizeof(short)), Xse.bsrli_si128(unpacklo_hi, 4 * sizeof(short))));
            }
            else
            {
                return new short4x3(v.c0.x, v.c0.y, v.c0.z,
                                    v.c1.x, v.c1.y, v.c1.z,
                                    v.c2.x, v.c2.y, v.c2.z,
                                    v.c3.x, v.c3.y, v.c3.z);
            }

        }

        /// <summary>		Returns the <see cref="MaxMath.short2x4"/> transposition of a <see cref="MaxMath.short4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 transpose(short4x2 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo = Xse.unpacklo_epi16(v.c0, v.c1);

                return new short2x4(unpacklo,
                                    Xse.bsrli_si128(unpacklo, 2 * sizeof(short)),
                                    Xse.bsrli_si128(unpacklo, 4 * sizeof(short)),
                                    Xse.bsrli_si128(unpacklo, 6 * sizeof(short)));
            }
            else
            {
                return new short2x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                    v.c1.x, v.c1.y, v.c1.z, v.c1.w);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.short3x4"/> transposition of a <see cref="MaxMath.short4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x4 transpose(short4x3 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo = Xse.unpacklo_epi16(v.c0, v.c1);

                return new short3x4(Xse.unpacklo_epi32(unpacklo, v.c2),
                                    Xse.unpacklo_epi32(Xse.bsrli_si128(unpacklo, 2 * sizeof(short)), Xse.bsrli_si128(v.c2, 1 * sizeof(short))),
                                    Xse.unpackhi_epi32(unpacklo, Xse.bslli_si128(v.c2, 2 * sizeof(short))),
                                    Xse.unpacklo_epi32(Xse.bsrli_si128(unpacklo, 6 * sizeof(short)), Xse.bsrli_si128(v.c2, 3 * sizeof(short))));
            }
            else
            {
                return new short3x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                    v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                                    v.c2.x, v.c2.y, v.c2.z, v.c2.w);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.short4x4"/> transposition of a <see cref="MaxMath.short4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x4 transpose(short4x4 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo_lo = Xse.unpacklo_epi16(v.c0, v.c1);
                v128 unpacklo_hi = Xse.unpacklo_epi16(v.c2, v.c3);

                v128 unpacklo = Xse.unpacklo_epi32(unpacklo_lo, unpacklo_hi);
                v128 unpackhi = Xse.unpackhi_epi32(unpacklo_lo, unpacklo_hi);

                return new short4x4(unpacklo,
                                    Xse.bsrli_si128(unpacklo, 4 * sizeof(short)),
                                    unpackhi,
                                    Xse.bsrli_si128(unpackhi, 4 * sizeof(short)));
            }
            else
            {
                return new short4x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                    v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                                    v.c2.x, v.c2.y, v.c2.z, v.c2.w,
                                    v.c3.x, v.c3.y, v.c3.z, v.c3.w);
            }
        }


        /// <summary>		Returns the <see cref="MaxMath.ushort2x2"/> transposition of a <see cref="MaxMath.ushort2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x2 transpose(ushort2x2 v)
        {
            return (ushort2x2)transpose((short2x2)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort3x2"/> transposition of a <see cref="MaxMath.ushort2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 transpose(ushort2x3 v)
        {
            return (ushort3x2)transpose((short2x3)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4x2"/> transposition of a <see cref="MaxMath.ushort2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 transpose(ushort2x4 v)
        {
            return (ushort4x2)transpose((short2x4)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort2x3"/> transposition of a u <see cref="MaxMath.short3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 transpose(ushort3x2 v)
        {
            return (ushort2x3)transpose((short3x2)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort3x3"/> transposition of a u <see cref="MaxMath.short3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 transpose(ushort3x3 v)
        {
            return (ushort3x3)transpose((short3x3)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4x3"/> transposition of a <see cref="MaxMath.ushort3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 transpose(ushort3x4 v)
        {
            return (ushort4x3)transpose((short3x4)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort2x4"/> transposition of a u <see cref="MaxMath.short4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 transpose(ushort4x2 v)
        {
            return (ushort2x4)transpose((short4x2)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort3x4"/> transposition of a u <see cref="MaxMath.short4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x4 transpose(ushort4x3 v)
        {
            return (ushort3x4)transpose((short4x3)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4x4"/> transposition of a u <see cref="MaxMath.short4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x4 transpose(ushort4x4 v)
        {
            return (ushort4x4)transpose((short4x4)v);
        }


        /// <summary>		Returns the <see cref="MaxMath.sbyte2x2"/> transposition of an <see cref="MaxMath.sbyte2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 transpose(sbyte2x2 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo = Xse.unpacklo_epi8(v.c0, v.c1);

                return new sbyte2x2(unpacklo,
                                    Xse.bsrli_si128(unpacklo, 2 * sizeof(sbyte)));
            }
            else
            {
                return new sbyte2x2(v.c0.x, v.c0.y,
                                    v.c1.x, v.c1.y);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3x2"/> transposition of an <see cref="MaxMath.sbyte2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x2 transpose(sbyte2x3 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo = Xse.unpacklo_epi8(v.c0, v.c1);

                if (BurstArchitecture.IsTableLookupSupported)
                {
                    unpacklo = Xse.unpacklo_epi16(unpacklo, v.c2);

                    return new sbyte3x2(unpacklo,
                                        Xse.shuffle_epi8(unpacklo, new v128(4, 5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)));
                }
                else
                {
                    return new sbyte3x2(Xse.unpacklo_epi16(unpacklo, v.c2),
                                        Xse.unpacklo_epi16(Xse.bsrli_si128(unpacklo, 2 * sizeof(sbyte)),
                                                           Xse.bsrli_si128(v.c2, sizeof(sbyte))));
                }
            }
            else
            {
                return new sbyte3x2(v.c0.x, v.c0.y,
                                    v.c1.x, v.c1.y,
                                    v.c2.x, v.c2.y);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4x2"/> transposition of an <see cref="MaxMath.sbyte2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 transpose(sbyte2x4 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo = Xse.unpacklo_epi16(Xse.unpacklo_epi8(v.c0, v.c1),
                                                   Xse.unpacklo_epi8(v.c2, v.c3));

                return new sbyte4x2(unpacklo,
                                    Xse.bsrli_si128(unpacklo, 4 * sizeof(sbyte)));
            }
            else
            {
                return new sbyte4x2(v.c0.x, v.c0.y,
                                    v.c1.x, v.c1.y,
                                    v.c2.x, v.c2.y,
                                    v.c3.x, v.c3.y);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte2x3"/> transposition of an <see cref="MaxMath.sbyte3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x3 transpose(sbyte3x2 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo = Xse.unpacklo_epi8(v.c0, v.c1);

                return new sbyte2x3(unpacklo,
                                    Xse.bsrli_si128(unpacklo, 2 * sizeof(byte)),
                                    Xse.bsrli_si128(unpacklo, 4 * sizeof(byte)));
            }
            else
            {
                return new sbyte2x3(v.c0.x, v.c0.y, v.c0.z,
                                    v.c1.x, v.c1.y, v.c1.z);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3x3"/> transposition of an <see cref="MaxMath.sbyte3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x3 transpose(sbyte3x3 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo = Xse.unpacklo_epi8(v.c0, v.c1);


                if (BurstArchitecture.IsTableLookupSupported)
                {
                    unpacklo = Xse.unpacklo_epi16(unpacklo,
                                                   v.c2);

                    return new sbyte3x3(unpacklo,
                                    Xse.shuffle_epi8(unpacklo, new v128(4, 5, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)),
                                    Xse.shuffle_epi8(unpacklo, new v128(8, 9, 6,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)));
                }
                else
                {
                    return new sbyte3x3(Xse.unpacklo_epi16(unpacklo, v.c2),
                                        Xse.unpacklo_epi16(Xse.bsrli_si128(unpacklo, 2 * sizeof(sbyte)), Xse.bsrli_si128(v.c2, 1 * sizeof(sbyte))),
                                        Xse.unpacklo_epi16(Xse.bsrli_si128(unpacklo, 4 * sizeof(sbyte)), Xse.bsrli_si128(v.c2, 2 * sizeof(sbyte))));
                }
            }
            else
            {
                return new sbyte3x3(v.c0.x, v.c0.y, v.c0.z,
                                    v.c1.x, v.c1.y, v.c1.z,
                                    v.c2.x, v.c2.y, v.c2.z);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4x3"/> transposition of an <see cref="MaxMath.sbyte3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x3 transpose(sbyte3x4 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo = Xse.unpacklo_epi16(Xse.unpacklo_epi8(v.c0, v.c1),
                                                    Xse.unpacklo_epi8(v.c2, v.c3));

                return new sbyte4x3(unpacklo,
                                    Xse.bsrli_si128(unpacklo,  4 * sizeof(sbyte)),
                                    Xse.bsrli_si128(unpacklo,  8 * sizeof(sbyte)));
            }
            else
            {
                return new sbyte4x3(v.c0.x, v.c0.y, v.c0.z,
                                    v.c1.x, v.c1.y, v.c1.z,
                                    v.c2.x, v.c2.y, v.c2.z,
                                    v.c3.x, v.c3.y, v.c3.z);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte2x4"/> transposition of an <see cref="MaxMath.sbyte4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x4 transpose(sbyte4x2 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo = Xse.unpacklo_epi8(v.c0, v.c1);

                return new sbyte2x4(unpacklo,
                                    Xse.bsrli_si128(unpacklo, 2 * sizeof(byte)),
                                    Xse.bsrli_si128(unpacklo, 4 * sizeof(byte)),
                                    Xse.bsrli_si128(unpacklo, 6 * sizeof(byte)));
            }
            else
            {
                return new sbyte2x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                    v.c1.x, v.c1.y, v.c1.z, v.c1.w);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3x4"/> transposition of an <see cref="MaxMath.sbyte4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 transpose(sbyte4x3 v)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 unpacklo = Xse.unpacklo_epi16(Xse.unpacklo_epi8(v.c0, v.c1),
                                                    v.c2);

                return new sbyte3x4(unpacklo,
                                    Xse.shuffle_epi8(unpacklo, new v128( 4,  5, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)),
                                    Xse.shuffle_epi8(unpacklo, new v128( 8,  9, 6,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)),
                                    Xse.shuffle_epi8(unpacklo, new v128(12, 13, 7,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo = Xse.unpacklo_epi8(v.c0, v.c1);

                return new sbyte3x4(Xse.unpacklo_epi16(unpacklo, v.c2),
                                    Xse.unpacklo_epi16(Xse.bsrli_si128(unpacklo, 2 * sizeof(sbyte)), Xse.bsrli_si128(v.c2, 1 * sizeof(sbyte))),
                                    Xse.unpacklo_epi16(Xse.bsrli_si128(unpacklo, 4 * sizeof(sbyte)), Xse.bsrli_si128(v.c2, 2 * sizeof(sbyte))),
                                    Xse.unpacklo_epi16(Xse.bsrli_si128(unpacklo, 6 * sizeof(sbyte)), Xse.bsrli_si128(v.c2, 3 * sizeof(sbyte))));
            }
            else
            {
                return new sbyte3x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                    v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                                    v.c2.x, v.c2.y, v.c2.z, v.c2.w);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4x4"/> transposition of an <see cref="MaxMath.sbyte4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 transpose(sbyte4x4 v)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 unpacklo = Xse.unpacklo_epi16(Xse.unpacklo_epi8(v.c0, v.c1),
                                                    Xse.unpacklo_epi8(v.c2, v.c3));

                return new sbyte4x4(unpacklo,
                                    Xse.bsrli_si128(unpacklo, 4  * sizeof(sbyte)),
                                    Xse.bsrli_si128(unpacklo, 8  * sizeof(sbyte)),
                                    Xse.bsrli_si128(unpacklo, 12 * sizeof(sbyte)));
            }
            else
            {
                return new sbyte4x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                    v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                                    v.c2.x, v.c2.y, v.c2.z, v.c2.w,
                                    v.c3.x, v.c3.y, v.c3.z, v.c3.w);
            }
        }


        /// <summary>		Returns the <see cref="MaxMath.byte2x2"/> transposition of a <see cref="MaxMath.byte2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x2 transpose(byte2x2 v)
        {
            return (byte2x2)transpose((sbyte2x2)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte3x2"/> transposition of a <see cref="MaxMath.byte2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x2 transpose(byte2x3 v)
        {
            return (byte3x2)transpose((sbyte2x3)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4x2"/> transposition of a <see cref="MaxMath.byte2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 transpose(byte2x4 v)
        {
            return (byte4x2)transpose((sbyte2x4)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte2x3"/> transposition of a <see cref="MaxMath.byte3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x3 transpose(byte3x2 v)
        {
            return (byte2x3)transpose((sbyte3x2)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte3x3"/> transposition of a <see cref="MaxMath.byte3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 transpose(byte3x3 v)
        {
            return (byte3x3)transpose((sbyte3x3)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4x3"/> transposition of a <see cref="bMaxMath.yte3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 transpose(byte3x4 v)
        {
            return (byte4x3)transpose((sbyte3x4)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte2x4"/> transposition of a <see cref="MaxMath.byte4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 transpose(byte4x2 v)
        {
            return (byte2x4)transpose((sbyte4x2)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte3x4"/> transposition of a <see cref="MaxMath.byte4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x4 transpose(byte4x3 v)
        {
            return (byte3x4)transpose((sbyte4x3)v);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4x4"/> transposition of a <see cref="MaxMath.byte4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x4 transpose(byte4x4 v)
        {
            return (byte4x4)transpose((sbyte4x4)v);
        }
    }
}