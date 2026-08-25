using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(bool2x2 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(bool2x3 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(bool2x4 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(bool3x2 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(bool3x3 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(bool3x4 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(bool4x2 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(bool4x3 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(bool4x4 x)
        {
            return !all(x);
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask8x2x2 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask8x2x3 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask8x2x4 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask8x3x2 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask8x3x3 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask8x3x4 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask8x4x2 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask8x4x3 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask8x4x4 x)
        {
            return !all(x);
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask16x2x2 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask16x2x3 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask16x2x4 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask16x3x2 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask16x3x3 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask16x3x4 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask16x4x2 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask16x4x3 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask16x4x4 x)
        {
            return !all(x);
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask32x2x2 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask32x2x3 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask32x2x4 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask32x3x2 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask32x3x3 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask32x3x4 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask32x4x2 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask32x4x3 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask32x4x4 x)
        {
            return !all(x);
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask64x2x2 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask64x2x3 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask64x2x4 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask64x3x2 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask64x3x3 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask64x3x4 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask64x4x2 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask64x4x3 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask64x4x4 x)
        {
            return !all(x);
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(bool2 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(bool3 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(bool4 x)
        {
            return !all(x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool8"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(bool8 x)
        {
VectorAssert.IsNotGreater<byte8, byte>(tobyte(x), 1, 8);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notalltrue_epi128<byte>(x, 8);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool16"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(bool16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notalltrue_epi128<byte>(x, 16);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool32"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(bool32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notalltrue_epi256<byte>(x);
            }
            else
            {
                return !all(x);
            }
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(Unity.Mathematics.bool2 x) => notall((bool2)x);

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(Unity.Mathematics.bool3 x) => notall((bool3)x);

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(Unity.Mathematics.bool4 x) => notall((bool4)x);


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notalltrue_epi128<byte>(x, 2);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notalltrue_epi128<byte>(x, 3);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask8x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notalltrue_epi128<byte>(x, 4);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool8"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask8x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notalltrue_epi128<byte>(x, 8);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool16"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask8x16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notalltrue_epi128<byte>(x, 16);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool32"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask8x32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notalltrue_epi256<byte>(x);
            }
            else
            {
                return !all(x);
            }
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notalltrue_epi128<ushort>(x, 2);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notalltrue_epi128<ushort>(x, 3);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask16x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notalltrue_epi128<ushort>(x, 4);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool8"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask16x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notalltrue_epi128<ushort>(x, 8);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool16"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask16x16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notalltrue_epi256<ushort>(x);
            }
            else
            {
                return !all(x);
            }
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notalltrue_epi128<uint>(x, 2);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notalltrue_epi128<uint>(x, 3);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask32x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notalltrue_epi128<uint>(x, 4);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool8"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask32x8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notalltrue_epi256<uint>(x);
            }
            else
            {
                return !all(x);
            }
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notalltrue_epi128<ulong>(x, 2);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask64x3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notalltrue_epi256<ulong>(x, 3);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(mask64x4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notalltrue_epi256<ulong>(x, 4);
            }
            else
            {
                return !all(x);
            }
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="byte2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(Xse.cmpeq_epi8(x, Xse.setzero_si128()), 2);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="byte3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(Xse.cmpeq_epi8(x, Xse.setzero_si128()), 3);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="byte4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(Xse.cmpeq_epi8(x, Xse.setzero_si128()), 4);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="byte8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(Xse.cmpeq_epi8(x, Xse.setzero_si128()), 8);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="byte16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(Xse.cmpeq_epi8(x, Xse.setzero_si128()), 16);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="byte32"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notallfalse_epi256<byte>(Avx2.mm256_cmpeq_epi8(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return notall(x.v16_0) | notall(x.v16_16);
            }
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="sbyte2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(sbyte2 x)
        {
            return notall((byte2)x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="sbyte3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(sbyte3 x)
        {
            return notall((byte3)x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="sbyte4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(sbyte4 x)
        {
            return notall((byte4)x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="sbyte8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(sbyte8 x)
        {
            return notall((byte8)x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="sbyte16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(sbyte16 x)
        {
            return notall((byte16)x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="sbyte32"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(sbyte32 x)
        {
            return notall((byte32)x);
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="short2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(short2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<ushort>(Xse.cmpeq_epi16(x, Xse.setzero_si128()), 2);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="short3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(short3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<ushort>(Xse.cmpeq_epi16(x, Xse.setzero_si128()), 3);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="short4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(short4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<ushort>(Xse.cmpeq_epi16(x, Xse.setzero_si128()), 4);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="short8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(short8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<ushort>(Xse.cmpeq_epi16(x, Xse.setzero_si128()), 8);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="short16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notallfalse_epi256<ushort>(Avx2.mm256_cmpeq_epi16(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return notall(x.v8_0) | notall(x.v8_8);
            }
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="ushort2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(ushort2 x)
        {
            return notall((short2)x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="ushort3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(ushort3 x)
        {
            return notall((short3)x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="ushort4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(ushort4 x)
        {
            return notall((short4)x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="ushort8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(ushort8 x)
        {
            return notall((short8)x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="ushort16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(ushort16 x)
        {
            return notall((short16)x);
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="int2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(int2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<uint>(Xse.cmpeq_epi32(x, Xse.setzero_si128()), 2);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="int3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(int3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<uint>(Xse.cmpeq_epi32(x, Xse.setzero_si128()), 3);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="int4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(int4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<uint>(Xse.cmpeq_epi32(x, Xse.setzero_si128()), 4);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="int8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notallfalse_epi256<uint>(Avx2.mm256_cmpeq_epi32(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return notall(x.v4_0) | notall(x.v4_4);
            }
        }

        
        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="uint2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(uint2 x)
        {
            return notall((int2)x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="uint3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(uint3 x)
        {
            return notall((int3)x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="uint4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(uint4 x)
        {
            return notall((int4)x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="uint8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(uint8 x)
        {
            return notall((int8)x);
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="long2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(long2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<ulong>(Xse.cmpeq_epi64(x, Xse.setzero_si128()), 2);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="long3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notallfalse_epi256<ulong>(Avx2.mm256_cmpeq_epi64(x, Avx.mm256_setzero_si256()), 3);
            }
            else
            {
                return notall(x.xy) | (x.z == 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="long4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notallfalse_epi256<ulong>(Avx2.mm256_cmpeq_epi64(x, Avx.mm256_setzero_si256()), 4);
            }
            else
            {
                return notall(x.xy) | notall(x.zw);
            }
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="ulong2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(ulong2 x)
        {
            return notall((long2)x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="ulong3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(ulong3 x)
        {
            return notall((long3)x);
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="ulong4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(ulong4 x)
        {
            return notall((long4)x);
        }

        
        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="quarter2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(quarter2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(Xse.cmpeq_pq(x, Xse.setzero_si128()), 2);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="quarter3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(quarter3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(Xse.cmpeq_pq(x, Xse.setzero_si128()), 3);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="quarter4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(quarter4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(Xse.cmpeq_pq(x, Xse.setzero_si128()), 4);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="quarter8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(quarter8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(Xse.cmpeq_pq(x, Xse.setzero_si128()), 8);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="quarter16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(quarter16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<byte>(Xse.cmpeq_pq(x, Xse.setzero_si128()), 16);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="quarter32"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(quarter32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notallfalse_epi256<byte>(Xse.mm256_cmpeq_pq(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return notall(x.v16_0) | notall(x.v16_16);
            }
        }

        
        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="half2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(half2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<ushort>(Xse.cmpeq_ph(x, Xse.setzero_si128()), 2);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="half3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(half3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<ushort>(Xse.cmpeq_ph(x, Xse.setzero_si128()), 3);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="half4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(half4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<ushort>(Xse.cmpeq_ph(x, Xse.setzero_si128()), 4);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="half8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(half8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_epi128<ushort>(Xse.cmpeq_ph(x, Xse.setzero_si128()), 8);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="half16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(half16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notallfalse_epi256<ushort>(Xse.mm256_cmpeq_ph(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return notall(x.v8_0) | notall(x.v8_8);
            }
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="float2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(float2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_f128<uint>(Xse.cmpeq_ps(x, Xse.setzero_si128()), 2);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="float3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(float3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_f128<uint>(Xse.cmpeq_ps(x, Xse.setzero_si128()), 3);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="float4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(float4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_f128<uint>(Xse.cmpeq_ps(x, Xse.setzero_si128()), 4);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="float8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(float8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notallfalse_f256<uint>(Xse.mm256_cmpeq_ps(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return notall(x.v4_0) | notall(x.v4_4);
            }
        }


        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="double2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(double2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.notallfalse_f128<ulong>(Xse.cmpeq_pd(x, Xse.setzero_si128()), 2);
            }
            else
            {
                return !all(x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="double3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(double3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notallfalse_f256<ulong>(Xse.mm256_cmpeq_pd(x, Avx.mm256_setzero_si256()), 3);
            }
            else
            {
                return notall(x.xy) | (x.z == 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if not all of the components of the input <see cref="double4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool notall(double4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_notallfalse_f256<ulong>(Xse.mm256_cmpeq_pd(x, Avx.mm256_setzero_si256()), 4);
            }
            else
            {
                return notall(x.xy) | notall(x.zw);
            }
        }
    }
}