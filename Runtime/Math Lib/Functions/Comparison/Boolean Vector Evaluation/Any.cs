using System.Runtime.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool2x2"/> is <see langword="true"/>, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool2x2 x)
        {
            return any(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool2x3"/> is <see langword="true"/>, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool2x3 x)
        {
            return any(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool2x4"/> is <see langword="true"/>, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool2x4 x)
        {
            return any(x.c0 | x.c1 | x.c2 | x.c3);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool3x2"/> is <see langword="true"/>, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool3x2 x)
        {
            return any(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool3x3"/> is <see langword="true"/>, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool3x3 x)
        {
            return any(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool3x4"/> is <see langword="true"/>, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool3x4 x)
        {
            return any(x.c0 | x.c1 | x.c2 | x.c3);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool4x2"/> is <see langword="true"/>, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool4x2 x)
        {
            return any(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool4x3"/> is <see langword="true"/>, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool4x3 x)
        {
            return any(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool4x4"/> is <see langword="true"/>, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool4x4 x)
        {
            return any(x.c0 | x.c1 | x.c2 | x.c3);
        }


        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool2"/> is <see langword="true"/>, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool2 x)
        {
            return Unity.Mathematics.math.any(x);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool3"/> is <see langword="true"/>, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool3 x)
        {
            return Unity.Mathematics.math.any(x);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool4"/> is <see langword="true"/>, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool4 x)
        {
            return Unity.Mathematics.math.any(x);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool8"/> is <see langword="true"/>, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool8 x)
        {
VectorAssert.IsNotGreater<byte8, byte>(tobyte(x), 1, 8);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<bool>(Xse.neg_epi8(x), 8);
            }
            else
            {
                return *(long*)&x != 0;
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool16"/> is <see langword="true"/>, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<bool>(Xse.neg_epi8(x));
            }
            else
            {
                return any(x.v8_0 | x.v8_8);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool32"/> is <see langword="true"/>, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notallfalse_epi256<bool>(Xse.mm256_neg_epi8(x));
            }
            else
            {
                return any(x.v16_0 | x.v16_16);
            }
        }


        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool2"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(Unity.Mathematics.bool2 x) => any((bool2)x);

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool3"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(Unity.Mathematics.bool3 x) => any((bool3)x);

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool4"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(Unity.Mathematics.bool4 x) => any((bool4)x);


        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool2"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(x, 2);
            }
            else
            {
                return any((bool2)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool3"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(x, 3);
            }
            else
            {
                return any((bool3)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool4"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask8x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(x, 4);
            }
            else
            {
                return any((bool4)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool8"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask8x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(x, 8);
            }
            else
            {
                return any((bool8)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool16"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask8x16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(x);
            }
            else
            {
                return any(x.v8_0 & x.v8_8);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool32"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask8x32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notallfalse_epi256<byte>(x);
            }
            else
            {
                return any(x.v16_0 & x.v16_16);
            }
        }


        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool2"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<ushort>(x, 2);
            }
            else
            {
                return any((bool2)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool3"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<ushort>(x, 3);
            }
            else
            {
                return any((bool3)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool4"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask16x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<ushort>(x, 4);
            }
            else
            {
                return any((bool4)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool8"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask16x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<ushort>(x, 8);
            }
            else
            {
                return any((bool8)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool16"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask16x16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notallfalse_epi256<ushort>(x);
            }
            else
            {
                return any(x.v8_0 & x.v8_8);
            }
        }


        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool2"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<uint>(x, 2);
            }
            else
            {
                return any((bool2)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool3"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<uint>(x, 3);
            }
            else
            {
                return any((bool3)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool4"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask32x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<uint>(x, 4);
            }
            else
            {
                return any((bool4)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool8"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask32x8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notallfalse_epi256<uint>(x);
            }
            else
            {
                return any((bool8)x);
            }
        }


        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool2"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<ulong>(x, 2);
            }
            else
            {
                return any((bool2)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool3"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask64x3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notallfalse_epi256<ulong>(x, 3);
            }
            else
            {
                return any((bool3)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.bool4"/> is <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(mask64x4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notallfalse_epi256<ulong>(x, 4);
            }
            else
            {
                return any((bool4)x);
            }
        }


        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.byte2"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(x, 2);
            }
            else
            {
                return any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.byte3"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(x, 3);
            }
            else
            {
                return any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.byte4"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(x, 4);
            }
            else
            {
                return any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.byte8"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(x, 8);
            }
            else
            {
                return any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.byte16"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notalltrue_epi128<byte>(Xse.cmpeq_epi8(x, Xse.setzero_si128()));
            }
            else
            {
                return any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.byte32"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notalltrue_epi256<byte>(Avx2.mm256_cmpeq_epi8(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return any(x.v16_0 | x.v16_16);
            }
        }


        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.sbyte2"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte2 x)
        {
            return any((byte2)x);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.sbyte3"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte3 x)
        {
            return any((byte3)x);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.sbyte4"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte4 x)
        {
            return any((byte4)x);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.sbyte8"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte8 x)
        {
            return any((byte8)x);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.sbyte16"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte16 x)
        {
            return any((byte16)x);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.sbyte32"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte32 x)
        {
            return any((byte32)x);
        }


        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.short2"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(short2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<short>(x, 2);
            }
            else
            {
                return any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.short3"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(short3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<short>(x, 3);
            }
            else
            {
                return any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.short4"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(short4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<short>(x, 4);
            }
            else
            {
                return any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.short8"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(short8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<short>(Xse.cmpeq_epi16(x, Xse.setzero_si128()));
            }
            else
            {
                return any(x != (short)0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.short16"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notalltrue_epi256<short>(Avx2.mm256_cmpeq_epi16(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return any(x.v8_0 | x.v8_8);
            }
        }


        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.ushort2"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ushort2 x)
        {
            return any((short2)x);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.ushort3"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ushort3 x)
        {
            return any((short3)x);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.ushort4"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ushort4 x)
        {
            return any((short4)x);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.ushort8"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ushort8 x)
        {
            return any((short8)x);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.ushort16"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ushort16 x)
        {
            return any((short16)x);
        }

        
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.int2"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(int2 x)
        {
            return Unity.Mathematics.math.any(x);
        }
        
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.int3"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(int3 x)
        {
            return Unity.Mathematics.math.any(x);
        }
        
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.int4"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(int4 x)
        {
            return Unity.Mathematics.math.any(x);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.int8"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notalltrue_epi256<int>(Avx2.mm256_cmpeq_epi32(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return any(x.v4_0 | x.v4_4);
            }
        }

        
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.uint2"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(uint2 x)
        {
            return Unity.Mathematics.math.any(x);
        }
        
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.uint3"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(uint3 x)
        {
            return Unity.Mathematics.math.any(x);
        }
        
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.uint4"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(uint4 x)
        {
            return Unity.Mathematics.math.any(x);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.uint8"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(uint8 x)
        {
            return any((int8)x);
        }


        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.long2"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(long2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notalltrue_epi128<long>(Xse.cmpeq_epi64(x, Xse.setzero_si128()));
            }
            else
            {
                return any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.long3"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notalltrue_epi256<long>(Avx2.mm256_cmpeq_epi64(x, Avx.mm256_setzero_si256()), 3);
            }
            else
            {
                return any(x.xy) | (x.z != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.long4"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notalltrue_epi256<long>(Avx2.mm256_cmpeq_epi64(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return any(x.xy | x.zw);
            }
        }


        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.ulong2"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ulong2 x)
        {
            return any((long2)x);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.ulong3"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ulong3 x)
        {
            return any((long3)x);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.ulong4"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ulong4 x)
        {
            return any((long4)x);
        }

        
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.quarter2"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(quarter2 x)
        {
            return any(x != (quarter)0f);
        }
        
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.quarter3"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(quarter3 x)
        {
            return any(x != (quarter)0f);
        }
        
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.quarter4"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(quarter4 x)
        {
            return any(x != (quarter)0f);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.quarter8"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(quarter8 x)
        {
            return any(x != (quarter)0f);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.quarter16"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(quarter16 x)
        {
            return any(x != (quarter)0f);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.quarter32"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(quarter32 x)
        {
            return any(x != (quarter)0f);
        }

        
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.half2"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(half2 x)
        {
            return any(x != (half)0f);
        }
        
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.half3"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(half3 x)
        {
            return any(x != (half)0f);
        }
        
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.half4"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(half4 x)
        {
            return any(x != (half)0f);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.half8"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(half8 x)
        {
            return any(x != (half)0f);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.half16"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(half16 x)
        {
            return any(x != (half)0f);
        }

        
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.float2"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(float2 x)
        {
            return Unity.Mathematics.math.any(x);
        }
        
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.float3"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(float3 x)
        {
            return Unity.Mathematics.math.any(x);
        }
        
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.float4"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(float4 x)
        {
            return Unity.Mathematics.math.any(x);
        }

        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.float8"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_notalltrue_f256<float>(Xse.mm256_cmpeq_ps(x, Avx.mm256_setzero_ps()));
            }
            else
            {
                return any(x.v4_0) | any(x.v4_4);
            }
        }


        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.double2"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(double2 x)
        {
            return Unity.Mathematics.math.any(x);
        }
        
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.double3"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(double3 x)
        {
            return Unity.Mathematics.math.any(x);
        }
        
        /// <summary>       Returns <see langword="true"/> if any of the components of the input <see cref="MaxMath.double4"/> is non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(double4 x)
        {
            return Unity.Mathematics.math.any(x);
        }
    }
}