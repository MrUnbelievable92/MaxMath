using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
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
                return new long2x3(Xse.unpacklo_epi64(v.c0.__x0, v.c1.__x0),
                                   Xse.unpackhi_epi64(v.c0.__x0, v.c1.__x0),
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
                return new long3x3(new long3(Xse.unpacklo_epi64(v.c0.__x0, v.c1.__x0), v.c2.x),
                                   new long3(Xse.unpackhi_epi64(v.c0.__x0, v.c1.__x0), v.c2.y),
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
                return new long4x3(new long4(Xse.unpacklo_epi64(v.c0.__x0, v.c1.__x0), Xse.unpacklo_epi64(v.c2.__x0, v.c3.__x0)),
                                   new long4(Xse.unpackhi_epi64(v.c0.__x0, v.c1.__x0), Xse.unpackhi_epi64(v.c2.__x0, v.c3.__x0)),
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
                return new long2x4(Xse.unpacklo_epi64(v.c0.__x0, v.c1.__x0),
                                   Xse.unpackhi_epi64(v.c0.__x0, v.c1.__x0),
                                   Xse.unpacklo_epi64(v.c0.__x2, v.c1.__x2),
                                   Xse.unpackhi_epi64(v.c0.__x2, v.c1.__x2));
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
                return new long3x4(new long3(Xse.unpacklo_epi64(v.c0.__x0, v.c1.__x0), v.c2.x),
                                   new long3(Xse.unpackhi_epi64(v.c0.__x0, v.c1.__x0), v.c2.y),
                                   new long3(Xse.unpacklo_epi64(v.c0.__x2, v.c1.__x2), v.c2.z),
                                   new long3(Xse.unpackhi_epi64(v.c0.__x2, v.c1.__x2), v.c2.w));
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
                return new long4x4(new long4(Xse.unpacklo_epi64(v.c0.__x0, v.c1.__x0), Xse.unpacklo_epi64(v.c2.__x0, v.c3.__x0)),
                                   new long4(Xse.unpackhi_epi64(v.c0.__x0, v.c1.__x0), Xse.unpackhi_epi64(v.c2.__x0, v.c3.__x0)),
                                   new long4(Xse.unpacklo_epi64(v.c0.__x2, v.c1.__x2), Xse.unpacklo_epi64(v.c2.__x2, v.c3.__x2)),
                                   new long4(Xse.unpackhi_epi64(v.c0.__x2, v.c1.__x2), Xse.unpackhi_epi64(v.c2.__x2, v.c3.__x2)));
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

        
        /// <summary>		Returns the <see cref="MaxMath.int2x2"/> transposition of an <see cref="MaxMath.int2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 transpose(int2x2 v)
        {
            return Unity.Mathematics.math.transpose(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.int3x2"/> transposition of an <see cref="MaxMath.int2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 transpose(int2x3 v)
        {
            return Unity.Mathematics.math.transpose(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.int4x2"/> transposition of an <see cref="MaxMath.int2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 transpose(int2x4 v)
        {
            return Unity.Mathematics.math.transpose(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.int2x3"/> transposition of an <see cref="MaxMath.int3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 transpose(int3x2 v)
        {
            return Unity.Mathematics.math.transpose(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.int3x3"/> transposition of an <see cref="MaxMath.int3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 transpose(int3x3 v)
        {
            return Unity.Mathematics.math.transpose(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.int4x3"/> transposition of an <see cref="MaxMath.int3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 transpose(int3x4 v)
        {
            return Unity.Mathematics.math.transpose(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.int2x4"/> transposition of an <see cref="MaxMath.int4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 transpose(int4x2 v)
        {
            return Unity.Mathematics.math.transpose(v);
        }

        /// <summary>		Returns the int<see cref="MaxMath.int3x4"/>3x4 transposition of an <see cref="MaxMath.int4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 transpose(int4x3 v)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 lo = Xse.unpacklo_epi32(v.c0, v.c1);
                v128 hi = Xse.unpackhi_epi32(v.c0, v.c1);

                return new int3x4(Xse.unpacklo_epi64(lo, v.c2),
                                  shuffle(lo, v.c2, ShuffleComponent.LeftZ, ShuffleComponent.LeftW, ShuffleComponent.RightY, ShuffleComponent.RightY).xyz,
                                  shuffle(hi, v.c2, ShuffleComponent.LeftX, ShuffleComponent.LeftY, ShuffleComponent.RightZ, ShuffleComponent.RightZ).xyz,
                                  shuffle(hi, v.c2, ShuffleComponent.LeftZ, ShuffleComponent.LeftW, ShuffleComponent.RightW, ShuffleComponent.RightW).xyz);
            }
            else
            {
                return new int3x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                  v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                                  v.c2.x, v.c2.y, v.c2.z, v.c2.w);
            }
        }

        /// <summary>		Returns the <see cref="MaxMath.int4x4"/> transposition of an <see cref="MaxMath.int4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 transpose(int4x4 v)
        {
            return Unity.Mathematics.math.transpose(v);
        }

        
        /// <summary>		Returns the <see cref="MaxMath.uint2x2"/> transposition of a <see cref="MaxMath.uint2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x2 transpose(uint2x2 v)
        {
            return Unity.Mathematics.math.transpose(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.uint3x2"/> transposition of a <see cref="MaxMath.uint2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 transpose(uint2x3 v)
        {
            return Unity.Mathematics.math.transpose(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.uint4x2"/> transposition of a <see cref="MaxMath.uint2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 transpose(uint2x4 v)
        {
            return Unity.Mathematics.math.transpose(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.uint2x3"/> transposition of a <see cref="MaxMath.uint3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 transpose(uint3x2 v)
        {
            return Unity.Mathematics.math.transpose(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.uint3x3"/> transposition of a <see cref="MaxMath.uint3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 transpose(uint3x3 v)
        {
            return Unity.Mathematics.math.transpose(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.uint4x3"/> transposition of a <see cref="MaxMath.uint3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 transpose(uint3x4 v)
        {
            return Unity.Mathematics.math.transpose(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.uint2x4"/> transposition of a <see cref="MaxMath.uint4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 transpose(uint4x2 v)
        {
            return Unity.Mathematics.math.transpose(v);
        }

        /// <summary>		Returns the uint<see cref="MaxMath.uint3x4"/>3x4 transposition of a <see cref="MaxMath.uint4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 transpose(uint4x3 v)
        {
            return Unity.Mathematics.math.transpose(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.uint4x4"/> transposition of a <see cref="MaxMath.uint4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 transpose(uint4x4 v)
        {
            return Unity.Mathematics.math.transpose(v);
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

        
        /// <summary>		Returns the <see cref="MaxMath.float2x2"/> transposition of a <see cref="MaxMath.float2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 transpose(float2x2 v)
        {
            uint2x2 r = transpose(v.Reinterpret<float2x2, uint2x2>());
            return r.Reinterpret<uint2x2, float2x2>();
        }

        /// <summary>		Returns the <see cref="MaxMath.float3x2"/> transposition of a <see cref="MaxMath.float2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 transpose(float2x3 v)
        {
            uint3x2 r = transpose(v.Reinterpret<float2x3, uint2x3>());
            return r.Reinterpret<uint3x2, float3x2>();
        }

        /// <summary>		Returns the <see cref="MaxMath.float4x2"/> transposition of a <see cref="MaxMath.float2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 transpose(float2x4 v)
        {
            uint4x2 r = transpose(v.Reinterpret<float2x4, uint2x4>());
            return r.Reinterpret<uint4x2, float4x2>();
        }

        /// <summary>		Returns the <see cref="MaxMath.float2x3"/> transposition of a <see cref="MaxMath.float3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 transpose(float3x2 v)
        {
            uint2x3 r = transpose(v.Reinterpret<float3x2, uint3x2>());
            return r.Reinterpret<uint2x3, float2x3>();
        }

        /// <summary>		Returns the <see cref="MaxMath.float3x3"/> transposition of a <see cref="MaxMath.float3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 transpose(float3x3 v)
        {
            uint3x3 r = transpose(v.Reinterpret<float3x3, uint3x3>());
            return r.Reinterpret<uint3x3, float3x3>();
        }

        /// <summary>		Returns the <see cref="MaxMath.float4x3"/> transposition of a <see cref="MaxMath.float3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 transpose(float3x4 v)
        {
            uint4x3 r = transpose(v.Reinterpret<float3x4, uint3x4>());
            return r.Reinterpret<uint4x3, float4x3>();
        }

        /// <summary>		Returns the <see cref="MaxMath.float2x4"/> transposition of a <see cref="MaxMath.float4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 transpose(float4x2 v)
        {
            uint2x4 r = transpose(v.Reinterpret<float4x2, uint4x2>());
            return r.Reinterpret<uint2x4, float2x4>();
        }

        /// <summary>		Returns the float<see cref="MaxMath.float3x4"/>3x4 transposition of a <see cref="MaxMath.float4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 transpose(float4x3 v)
        {
            uint3x4 r = transpose(v.Reinterpret<float4x3, uint4x3>());
            return r.Reinterpret<uint3x4, float3x4>();
        }

        /// <summary>		Returns the <see cref="MaxMath.float4x4"/> transposition of a <see cref="MaxMath.float4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 transpose(float4x4 v)
        {
            uint4x4 r = transpose(v.Reinterpret<float4x4, uint4x4>());
            return r.Reinterpret<uint4x4, float4x4>();
        }

        
        /// <summary>		Returns the <see cref="MaxMath.double2x2"/> transposition of a <see cref="MaxMath.double2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 transpose(double2x2 v)
        {
            ulong2x2 r = transpose(v.Reinterpret<double2x2, ulong2x2>());
            return r.Reinterpret<ulong2x2, double2x2>();
        }

        /// <summary>		Returns the <see cref="MaxMath.double3x2"/> transposition of a <see cref="MaxMath.double2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 transpose(double2x3 v)
        {
            ulong3x2 r = transpose(v.Reinterpret<double2x3, ulong2x3>());
            return r.Reinterpret<ulong3x2, double3x2>();
        }

        /// <summary>		Returns the <see cref="MaxMath.double4x2"/> transposition of a <see cref="MaxMath.double2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 transpose(double2x4 v)
        {
            ulong4x2 r = transpose(v.Reinterpret<double2x4, ulong2x4>());
            return r.Reinterpret<ulong4x2, double4x2>();
        }

        /// <summary>		Returns the <see cref="MaxMath.double2x3"/> transposition of a <see cref="MaxMath.double3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 transpose(double3x2 v)
        {
            ulong2x3 r = transpose(v.Reinterpret<double3x2, ulong3x2>());
            return r.Reinterpret<ulong2x3, double2x3>();
        }

        /// <summary>		Returns the <see cref="MaxMath.double3x3"/> transposition of a <see cref="MaxMath.double3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 transpose(double3x3 v)
        {
            ulong3x3 r = transpose(v.Reinterpret<double3x3, ulong3x3>());
            return r.Reinterpret<ulong3x3, double3x3>();
        }

        /// <summary>		Returns the <see cref="MaxMath.double4x3"/> transposition of a <see cref="MaxMath.double3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 transpose(double3x4 v)
        {
            ulong4x3 r = transpose(v.Reinterpret<double3x4, ulong3x4>());
            return r.Reinterpret<ulong4x3, double4x3>();
        }

        /// <summary>		Returns the <see cref="MaxMath.double2x4"/> transposition of a <see cref="MaxMath.double4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 transpose(double4x2 v)
        {
            ulong2x4 r = transpose(v.Reinterpret<double4x2, ulong4x2>());
            return r.Reinterpret<ulong2x4, double2x4>();
        }

        /// <summary>		Returns the double<see cref="MaxMath.double3x4"/>3x4 transposition of a <see cref="MaxMath.double4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 transpose(double4x3 v)
        {
            ulong3x4 r = transpose(v.Reinterpret<double4x3, ulong4x3>());
            return r.Reinterpret<ulong3x4, double3x4>();
        }

        /// <summary>		Returns the <see cref="MaxMath.double4x4"/> transposition of a <see cref="MaxMath.double4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 transpose(double4x4 v)
        {
            ulong4x4 r = transpose(v.Reinterpret<double4x4, ulong4x4>());
            return r.Reinterpret<ulong4x4, double4x4>();
        }

        
        /// <summary>		Returns the <see cref="MaxMath.bool2x2"/> transposition of a <see cref="MaxMath.bool2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 transpose(bool2x2 v) => transpose((mask8x2x2)v);

        /// <summary>		Returns the <see cref="MaxMath.bool3x2"/> transposition of a <see cref="MaxMath.bool2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 transpose(bool2x3 v) => transpose((mask8x2x3)v);

        /// <summary>		Returns the <see cref="MaxMath.bool4x2"/> transposition of a <see cref="MaxMath.bool2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 transpose(bool2x4 v) => transpose((mask8x2x4)v);

        /// <summary>		Returns the <see cref="MaxMath.bool2x3"/> transposition of a <see cref="MaxMath.bool3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 transpose(bool3x2 v) => transpose((mask8x3x2)v);

        /// <summary>		Returns the <see cref="MaxMath.bool3x3"/> transposition of a <see cref="MaxMath.bool3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 transpose(bool3x3 v) => transpose((mask8x3x3)v);

        /// <summary>		Returns the <see cref="MaxMath.bool4x3"/> transposition of a <see cref="MaxMath.bool3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 transpose(bool3x4 v) => transpose((mask8x3x4)v);

        /// <summary>		Returns the <see cref="MaxMath.bool2x4"/> transposition of a <see cref="MaxMath.bool4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 transpose(bool4x2 v) => transpose((mask8x4x2)v);

        /// <summary>		Returns the bool<see cref="MaxMath.bool3x4"/>3x4 transposition of a <see cref="MaxMath.bool4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 transpose(bool4x3 v) => transpose((mask8x4x3)v);

        /// <summary>		Returns the <see cref="MaxMath.bool4x4"/> transposition of a <see cref="MaxMath.bool4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 transpose(bool4x4 v) => transpose((mask8x4x4)v);

        
        /// <summary>		Returns the <see cref="MaxMath.Unity.Mathematics.bool2x2"/> transposition of a <see cref="MaxMath.Unity.Mathematics.bool2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 transpose(Unity.Mathematics.bool2x2 v) => transpose((bool2x2)v);

        /// <summary>		Returns the <see cref="MaxMath.Unity.Mathematics.bool3x2"/> transposition of a <see cref="MaxMath.Unity.Mathematics.bool2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 transpose(Unity.Mathematics.bool2x3 v) => transpose((bool2x3)v);

        /// <summary>		Returns the <see cref="MaxMath.Unity.Mathematics.bool4x2"/> transposition of a <see cref="MaxMath.Unity.Mathematics.bool2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 transpose(Unity.Mathematics.bool2x4 v) => transpose((bool2x4)v);

        /// <summary>		Returns the <see cref="MaxMath.Unity.Mathematics.bool2x3"/> transposition of a <see cref="MaxMath.Unity.Mathematics.bool3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 transpose(Unity.Mathematics.bool3x2 v) => transpose((bool3x2)v);

        /// <summary>		Returns the <see cref="MaxMath.Unity.Mathematics.bool3x3"/> transposition of a <see cref="MaxMath.Unity.Mathematics.bool3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 transpose(Unity.Mathematics.bool3x3 v) => transpose((bool3x3)v);

        /// <summary>		Returns the <see cref="MaxMath.Unity.Mathematics.bool4x3"/> transposition of a <see cref="MaxMath.Unity.Mathematics.bool3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 transpose(Unity.Mathematics.bool3x4 v) => transpose((bool3x4)v);

        /// <summary>		Returns the <see cref="MaxMath.Unity.Mathematics.bool2x4"/> transposition of a <see cref="MaxMath.Unity.Mathematics.bool4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 transpose(Unity.Mathematics.bool4x2 v) => transpose((bool4x2)v);

        /// <summary>		Returns the Unity.Mathematics.bool<see cref="MaxMath.Unity.Mathematics.bool3x4"/>3x4 transposition of a <see cref="MaxMath.Unity.Mathematics.bool4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 transpose(Unity.Mathematics.bool4x3 v) => transpose((bool4x3)v);

        /// <summary>		Returns the <see cref="MaxMath.Unity.Mathematics.bool4x4"/> transposition of a <see cref="MaxMath.Unity.Mathematics.bool4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 transpose(Unity.Mathematics.bool4x4 v) => transpose((bool4x4)v);

        
        /// <summary>		Returns the <see cref="MaxMath.bool2x2"/> transposition of a <see cref="MaxMath.bool2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 transpose(mask8x2x2 v)
        {
            byte2x2 t = new byte2x2 { c0 = (v128)v.c0, c1 = (v128)v.c1 };
            t = transpose(t);
            return new mask8x2x2 { c0 = (v128)t.c0, c1 = (v128)t.c1 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool3x2"/> transposition of a <see cref="MaxMath.bool2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 transpose(mask8x2x3 v)
        {
            byte2x3 t = new byte2x3 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2 };
            byte3x2 t2 = transpose(t);
            return new mask8x3x2 { c0 = (v128)t2.c0, c1 = (v128)t2.c1 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool4x2"/> transposition of a <see cref="MaxMath.bool2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 transpose(mask8x2x4 v)
        {
            byte2x4 t = new byte2x4 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2, c3 = (v128)v.c3 };
            byte4x2 t2 = transpose(t);
            return new mask8x4x2 { c0 = (v128)t2.c0, c1 = (v128)t2.c1 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool2x3"/> transposition of a <see cref="MaxMath.bool3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 transpose(mask8x3x2 v)
        {
            byte3x2 t = new byte3x2 { c0 = (v128)v.c0, c1 = (v128)v.c1 };
            byte2x3 t2 = transpose(t);
            return new mask8x2x3 { c0 = (v128)t2.c0, c1 = (v128)t2.c1, c2 = (v128)t2.c2 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool3x3"/> transposition of a <see cref="MaxMath.bool3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 transpose(mask8x3x3 v)
        {
            byte3x3 t = new byte3x3 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2 };
            t = transpose(t);
            return new mask8x3x3 { c0 = (v128)t.c0, c1 = (v128)t.c1, c2 = (v128)t.c2 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool4x3"/> transposition of a <see cref="MaxMath.bool3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 transpose(mask8x3x4 v)
        {
            byte3x4 t = new byte3x4 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2, c3 = (v128)v.c3 };
            byte4x3 t2 = transpose(t);
            return new mask8x4x3 { c0 = (v128)t2.c0, c1 = (v128)t2.c1, c2 = (v128)t2.c2 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool2x4"/> transposition of a <see cref="MaxMath.bool4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 transpose(mask8x4x2 v)
        {
            byte4x2 t = new byte4x2 { c0 = (v128)v.c0, c1 = (v128)v.c1 };
            byte2x4 t2 = transpose(t);
            return new mask8x2x4 { c0 = (v128)t2.c0, c1 = (v128)t2.c1, c2 = (v128)t2.c2, c3 = (v128)t2.c3 };
        }

        /// <summary>		Returns the mask8x<see cref="MaxMath.bool3x4"/>3x4 transposition of a <see cref="MaxMath.bool4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 transpose(mask8x4x3 v)
        {
            byte4x3 t = new byte4x3 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2 };
            byte3x4 t2 = transpose(t);
            return new mask8x3x4 { c0 = (v128)t2.c0, c1 = (v128)t2.c1, c2 = (v128)t2.c2, c3 = (v128)t2.c3 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool4x4"/> transposition of a <see cref="MaxMath.bool4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 transpose(mask8x4x4 v)
        {
            byte4x4 t = new byte4x4 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2, c3 = (v128)v.c3 };
            t = transpose(t);
            return new mask8x4x4 { c0 = (v128)t.c0, c1 = (v128)t.c1, c2 = (v128)t.c2, c3 = (v128)t.c3 };
        }

        
        /// <summary>		Returns the <see cref="MaxMath.bool2x2"/> transposition of a <see cref="MaxMath.bool2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 transpose(mask16x2x2 v)
        {
            ushort2x2 t = new ushort2x2 { c0 = (v128)v.c0, c1 = (v128)v.c1 };
            t = transpose(t);
            return new mask16x2x2 { c0 = (v128)t.c0, c1 = (v128)t.c1 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool3x2"/> transposition of a <see cref="MaxMath.bool2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3x2 transpose(mask16x2x3 v)
        {
            ushort2x3 t = new ushort2x3 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2 };
            ushort3x2 t2 = transpose(t);
            return new mask16x3x2 { c0 = (v128)t2.c0, c1 = (v128)t2.c1 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool4x2"/> transposition of a <see cref="MaxMath.bool2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x2 transpose(mask16x2x4 v)
        {
            ushort2x4 t = new ushort2x4 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2, c3 = (v128)v.c3 };
            ushort4x2 t2 = transpose(t);
            return new mask16x4x2 { c0 = (v128)t2.c0, c1 = (v128)t2.c1 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool2x3"/> transposition of a <see cref="MaxMath.bool3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 transpose(mask16x3x2 v)
        {
            ushort3x2 t = new ushort3x2 { c0 = (v128)v.c0, c1 = (v128)v.c1 };
            ushort2x3 t2 = transpose(t);
            return new mask16x2x3 { c0 = (v128)t2.c0, c1 = (v128)t2.c1, c2 = (v128)t2.c2 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool3x3"/> transposition of a <see cref="MaxMath.bool3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3x3 transpose(mask16x3x3 v)
        {
            ushort3x3 t = new ushort3x3 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2 };
            t = transpose(t);
            return new mask16x3x3 { c0 = (v128)t.c0, c1 = (v128)t.c1, c2 = (v128)t.c2 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool4x3"/> transposition of a <see cref="MaxMath.bool3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 transpose(mask16x3x4 v)
        {
            ushort3x4 t = new ushort3x4 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2, c3 = (v128)v.c3 };
            ushort4x3 t2 = transpose(t);
            return new mask16x4x3 { c0 = (v128)t2.c0, c1 = (v128)t2.c1, c2 = (v128)t2.c2 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool2x4"/> transposition of a <see cref="MaxMath.bool4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x4 transpose(mask16x4x2 v)
        {
            ushort4x2 t = new ushort4x2 { c0 = (v128)v.c0, c1 = (v128)v.c1 };
            ushort2x4 t2 = transpose(t);
            return new mask16x2x4 { c0 = (v128)t2.c0, c1 = (v128)t2.c1, c2 = (v128)t2.c2, c3 = (v128)t2.c3 };
        }

        /// <summary>		Returns the mask16x<see cref="MaxMath.bool3x4"/>3x4 transposition of a <see cref="MaxMath.bool4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3x4 transpose(mask16x4x3 v)
        {
            ushort4x3 t = new ushort4x3 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2 };
            ushort3x4 t2 = transpose(t);
            return new mask16x3x4 { c0 = (v128)t2.c0, c1 = (v128)t2.c1, c2 = (v128)t2.c2, c3 = (v128)t2.c3 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool4x4"/> transposition of a <see cref="MaxMath.bool4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x4 transpose(mask16x4x4 v)
        {
            ushort4x4 t = new ushort4x4 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2, c3 = (v128)v.c3 };
            t = transpose(t);
            return new mask16x4x4 { c0 = (v128)t.c0, c1 = (v128)t.c1, c2 = (v128)t.c2, c3 = (v128)t.c3 };
        }

        
        /// <summary>		Returns the <see cref="MaxMath.bool2x2"/> transposition of a <see cref="MaxMath.bool2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 transpose(mask32x2x2 v)
        {
            uint2x2 t = new uint2x2 { c0 = (v128)v.c0, c1 = (v128)v.c1 };
            t = transpose(t);
            return new mask32x2x2 { c0 = (v128)t.c0, c1 = (v128)t.c1 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool3x2"/> transposition of a <see cref="MaxMath.bool2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 transpose(mask32x2x3 v)
        {
            uint2x3 t = new uint2x3 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2 };
            uint3x2 t2 = transpose(t);
            return new mask32x3x2 { c0 = (v128)t2.c0, c1 = (v128)t2.c1 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool4x2"/> transposition of a <see cref="MaxMath.bool2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 transpose(mask32x2x4 v)
        {
            uint2x4 t = new uint2x4 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2, c3 = (v128)v.c3 };
            uint4x2 t2 = transpose(t);
            return new mask32x4x2 { c0 = (v128)t2.c0, c1 = (v128)t2.c1 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool2x3"/> transposition of a <see cref="MaxMath.bool3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 transpose(mask32x3x2 v)
        {
            uint3x2 t = new uint3x2 { c0 = (v128)v.c0, c1 = (v128)v.c1 };
            uint2x3 t2 = transpose(t);
            return new mask32x2x3 { c0 = (v128)t2.c0, c1 = (v128)t2.c1, c2 = (v128)t2.c2 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool3x3"/> transposition of a <see cref="MaxMath.bool3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 transpose(mask32x3x3 v)
        {
            uint3x3 t = new uint3x3 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2 };
            t = transpose(t);
            return new mask32x3x3 { c0 = (v128)t.c0, c1 = (v128)t.c1, c2 = (v128)t.c2 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool4x3"/> transposition of a <see cref="MaxMath.bool3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 transpose(mask32x3x4 v)
        {
            uint3x4 t = new uint3x4 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2, c3 = (v128)v.c3 };
            uint4x3 t2 = transpose(t);
            return new mask32x4x3 { c0 = (v128)t2.c0, c1 = (v128)t2.c1, c2 = (v128)t2.c2 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool2x4"/> transposition of a <see cref="MaxMath.bool4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 transpose(mask32x4x2 v)
        {
            uint4x2 t = new uint4x2 { c0 = (v128)v.c0, c1 = (v128)v.c1 };
            uint2x4 t2 = transpose(t);
            return new mask32x2x4 { c0 = (v128)t2.c0, c1 = (v128)t2.c1, c2 = (v128)t2.c2, c3 = (v128)t2.c3 };
        }

        /// <summary>		Returns the mask32x<see cref="MaxMath.bool3x4"/>3x4 transposition of a <see cref="MaxMath.bool4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 transpose(mask32x4x3 v)
        {
            uint4x3 t = new uint4x3 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2 };
            uint3x4 t2 = transpose(t);
            return new mask32x3x4 { c0 = (v128)t2.c0, c1 = (v128)t2.c1, c2 = (v128)t2.c2, c3 = (v128)t2.c3 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool4x4"/> transposition of a <see cref="MaxMath.bool4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 transpose(mask32x4x4 v)
        {
            uint4x4 t = new uint4x4 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2, c3 = (v128)v.c3 };
            t = transpose(t);
            return new mask32x4x4 { c0 = (v128)t.c0, c1 = (v128)t.c1, c2 = (v128)t.c2, c3 = (v128)t.c3 };
        }

        
        /// <summary>		Returns the <see cref="MaxMath.bool2x2"/> transposition of a <see cref="MaxMath.bool2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 transpose(mask64x2x2 v)
        {
            ulong2x2 t = new ulong2x2 { c0 = (v128)v.c0, c1 = (v128)v.c1 };
            t = transpose(t);
            return new mask64x2x2 { c0 = (v128)t.c0, c1 = (v128)t.c1 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool3x2"/> transposition of a <see cref="MaxMath.bool2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 transpose(mask64x2x3 v)
        {
            ulong2x3 t = new ulong2x3 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2 };
            ulong3x2 t2 = transpose(t);
            return new mask64x3x2 { c0 = (v256)t2.c0, c1 = (v256)t2.c1 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool4x2"/> transposition of a <see cref="MaxMath.bool2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 transpose(mask64x2x4 v)
        {
            ulong2x4 t = new ulong2x4 { c0 = (v128)v.c0, c1 = (v128)v.c1, c2 = (v128)v.c2, c3 = (v128)v.c3 };
            ulong4x2 t2 = transpose(t);
            return new mask64x4x2 { c0 = (v256)t2.c0, c1 = (v256)t2.c1 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool2x3"/> transposition of a <see cref="MaxMath.bool3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 transpose(mask64x3x2 v)
        {
            ulong3x2 t = new ulong3x2 { c0 = (v256)v.c0, c1 = (v256)v.c1 };
            ulong2x3 t2 = transpose(t);
            return new mask64x2x3 { c0 = (v128)t2.c0, c1 = (v128)t2.c1, c2 = (v128)t2.c2 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool3x3"/> transposition of a <see cref="MaxMath.bool3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 transpose(mask64x3x3 v)
        {
            ulong3x3 t = new ulong3x3 { c0 = (v256)v.c0, c1 = (v256)v.c1, c2 = (v256)v.c2 };
            t = transpose(t);
            return new mask64x3x3 { c0 = (v256)t.c0, c1 = (v256)t.c1, c2 = (v256)t.c2 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool4x3"/> transposition of a <see cref="MaxMath.bool3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 transpose(mask64x3x4 v)
        {
            ulong3x4 t = new ulong3x4 { c0 = (v256)v.c0, c1 = (v256)v.c1, c2 = (v256)v.c2, c3 = (v256)v.c3 };
            ulong4x3 t2 = transpose(t);
            return new mask64x4x3 { c0 = (v256)t2.c0, c1 = (v256)t2.c1, c2 = (v256)t2.c2 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool2x4"/> transposition of a <see cref="MaxMath.bool4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 transpose(mask64x4x2 v)
        {
            ulong4x2 t = new ulong4x2 { c0 = (v256)v.c0, c1 = (v256)v.c1 };
            ulong2x4 t2 = transpose(t);
            return new mask64x2x4 { c0 = (v128)t2.c0, c1 = (v128)t2.c1, c2 = (v128)t2.c2, c3 = (v128)t2.c3 };
        }

        /// <summary>		Returns the mask64x<see cref="MaxMath.bool3x4"/>3x4 transposition of a <see cref="MaxMath.bool4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 transpose(mask64x4x3 v)
        {
            ulong4x3 t = new ulong4x3 { c0 = (v256)v.c0, c1 = (v256)v.c1, c2 = (v256)v.c2 };
            ulong3x4 t2 = transpose(t);
            return new mask64x3x4 { c0 = (v256)t2.c0, c1 = (v256)t2.c1, c2 = (v256)t2.c2, c3 = (v256)t2.c3 };
        }

        /// <summary>		Returns the <see cref="MaxMath.bool4x4"/> transposition of a <see cref="MaxMath.bool4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 transpose(mask64x4x4 v)
        {
            ulong4x4 t = new ulong4x4 { c0 = (v256)v.c0, c1 = (v256)v.c1, c2 = (v256)v.c2, c3 = (v256)v.c3 };
            t = transpose(t);
            return new mask64x4x4 { c0 = (v256)t.c0, c1 = (v256)t.c1, c2 = (v256)t.c2, c3 = (v256)t.c3 };
        }
    }
}