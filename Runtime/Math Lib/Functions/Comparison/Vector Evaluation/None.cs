using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(bool2x2 x)
        {
            return none(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(bool2x3 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(bool2x4 x)
        {
            return none(x.c0 | x.c1 | x.c2 | x.c3);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(bool3x2 x)
        {
            return none(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(bool3x3 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(bool3x4 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(bool4x2 x)
        {
            return none(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(bool4x3 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(bool4x4 x)
        {
            return none(x.c0 | x.c1 | x.c2 | x.c3);
        }


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask8x2x2 x)
        {
            return none(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask8x2x3 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask8x2x4 x)
        {
            return none(x.c0 | x.c1 | x.c2 | x.c3);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask8x3x2 x)
        {
            return none(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask8x3x3 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask8x3x4 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask8x4x2 x)
        {
            return none(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask8x4x3 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask8x4x4 x)
        {
            return none(x.c0 | x.c1 | x.c2 | x.c3);
        }


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask16x2x2 x)
        {
            return none(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask16x2x3 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask16x2x4 x)
        {
            return none(x.c0 | x.c1 | x.c2 | x.c3);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask16x3x2 x)
        {
            return none(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask16x3x3 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask16x3x4 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask16x4x2 x)
        {
            return none(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask16x4x3 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask16x4x4 x)
        {
            return none(x.c0 | x.c1 | x.c2 | x.c3);
        }


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask32x2x2 x)
        {
            return none(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask32x2x3 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask32x2x4 x)
        {
            return none(x.c0 | x.c1 | x.c2 | x.c3);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask32x3x2 x)
        {
            return none(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask32x3x3 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask32x3x4 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask32x4x2 x)
        {
            return none(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask32x4x3 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask32x4x4 x)
        {
            return none(x.c0 | x.c1 | x.c2 | x.c3);
        }


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask64x2x2 x)
        {
            return none(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask64x2x3 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask64x2x4 x)
        {
            return none(x.c0 | x.c1 | x.c2 | x.c3);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask64x3x2 x)
        {
            return none(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask64x3x3 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask64x3x4 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask64x4x2 x)
        {
            return none(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask64x4x3 x)
        {
            return none(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask64x4x4 x)
        {
            return none(x.c0 | x.c1 | x.c2 | x.c3);
        }


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(bool2 x)
        {
            return !any(x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(bool3 x)
        {
            return !any(x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(bool4 x)
        {
            return !any(x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool8"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(bool8 x)
        {
VectorAssert.IsNotGreater<byte8, byte>(tobyte(x), 1, 8);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<bool>(Xse.neg_epi8(x), 8);
            }
            else
            {
                return *(long*)&x == 0;
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool16"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(bool16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<bool>(Xse.neg_epi8(x));
            }
            else
            {
                return none(x.v8_0 | x.v8_8);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool32"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(bool32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_allfalse_epi256<bool>(Xse.mm256_neg_epi8(x));
            }
            else
            {
                return none(x.v16_0 | x.v16_16);
            }
        }


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(Unity.Mathematics.bool2 x) => none((bool2)x);

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(Unity.Mathematics.bool3 x) => none((bool3)x);

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(Unity.Mathematics.bool4 x) => none((bool4)x);


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<byte>(x, 2);
            }
            else
            {
                return none((bool2)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<byte>(x, 3);
            }
            else
            {
                return none((bool3)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask8x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<byte>(x, 4);
            }
            else
            {
                return none((bool4)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool8"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask8x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<byte>(x, 8);
            }
            else
            {
                return none((bool8)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool16"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask8x16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<byte>(x);
            }
            else
            {
                return none(x.v8_0 | x.v8_8);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool32"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask8x32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_allfalse_epi256<byte>(x);
            }
            else
            {
                return none(x.v16_0 | x.v16_16);
            }
        }


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<ushort>(x, 2);
            }
            else
            {
                return none((bool2)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<ushort>(x, 3);
            }
            else
            {
                return none((bool3)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask16x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<ushort>(x, 4);
            }
            else
            {
                return none((bool4)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool8"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask16x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<ushort>(x, 8);
            }
            else
            {
                return none((bool8)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool16"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask16x16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_allfalse_epi256<ushort>(x);
            }
            else
            {
                return none(x.v8_0 | x.v8_8);
            }
        }


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<uint>(x, 2);
            }
            else
            {
                return none((bool2)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<uint>(x, 3);
            }
            else
            {
                return none((bool3)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask32x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<uint>(x, 4);
            }
            else
            {
                return none((bool4)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool8"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask32x8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_allfalse_epi256<uint>(x);
            }
            else
            {
                return none((bool8)x);
            }
        }


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<ulong>(x, 2);
            }
            else
            {
                return none((bool2)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask64x3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_allfalse_epi256<ulong>(x, 3);
            }
            else
            {
                return none((bool3)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(mask64x4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_allfalse_epi256<ulong>(x, 4);
            }
            else
            {
                return none((bool4)x);
            }
        }


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="byte2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<byte>(Xse.cmpeq_epi8(x, Xse.setzero_si128()), 2);
            }
            else
            {
                return all(x == 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="byte3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<byte>(Xse.cmpeq_epi8(x, Xse.setzero_si128()), 3);
            }
            else
            {
                return all(x == 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="byte4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<byte>(Xse.cmpeq_epi8(x, Xse.setzero_si128()), 4);
            }
            else
            {
                return all(x == 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="byte8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<byte>(Xse.cmpeq_epi8(x, Xse.setzero_si128()), 8);
            }
            else
            {
                return all(x == 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="byte16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<byte>(Xse.cmpeq_epi8(x, Xse.setzero_si128()));
            }
            else
            {
                return all(x == 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="byte32"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_alltrue_epi256<byte>(Avx2.mm256_cmpeq_epi8(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return none(x.v16_0 | x.v16_16);
            }
        }


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="sbyte2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(sbyte2 x)
        {
            return none((byte2)x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="sbyte3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(sbyte3 x)
        {
            return none((byte3)x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="sbyte4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(sbyte4 x)
        {
            return none((byte4)x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="sbyte8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(sbyte8 x)
        {
            return none((byte8)x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="sbyte16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(sbyte16 x)
        {
            return none((byte16)x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="sbyte32"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(sbyte32 x)
        {
            return none((byte32)x);
        }


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="short2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(short2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<short>(Xse.cmpeq_epi16(x, Xse.setzero_si128()), 2);
            }
            else
            {
                return all(x == 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="short3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(short3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<short>(Xse.cmpeq_epi16(x, Xse.setzero_si128()), 3);
            }
            else
            {
                return all(x == 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="short4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(short4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<short>(Xse.cmpeq_epi16(x, Xse.setzero_si128()), 4);
            }
            else
            {
                return all(x == 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="short8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(short8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<short>(Xse.cmpeq_epi16(x, Xse.setzero_si128()));
            }
            else
            {
                return all(x == 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="short16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_alltrue_epi256<short>(Avx2.mm256_cmpeq_epi16(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return none(x.v8_0 | x.v8_8);
            }
        }


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="ushort2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(ushort2 x)
        {
            return none((short2)x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="ushort3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(ushort3 x)
        {
            return none((short3)x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="ushort4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(ushort4 x)
        {
            return none((short4)x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="ushort8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(ushort8 x)
        {
            return none((short8)x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="ushort16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(ushort16 x)
        {
            return none((short16)x);
        }


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="int2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(int2 x)
        {
            return !any(x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="int3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(int3 x)
        {
            return !any(x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="int4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(int4 x)
        {
            return !any(x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="int8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_alltrue_epi256<int>(Avx2.mm256_cmpeq_epi32(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return none(x.v4_0 | x.v4_4);
            }
        }

        
        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="uint2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(uint2 x)
        {
            return !any(x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="uint3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(uint3 x)
        {
            return !any(x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="uint4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(uint4 x)
        {
            return !any(x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="uint8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(uint8 x)
        {
            return none((int8)x);
        }


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="long2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(long2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<long>(Xse.cmpeq_epi64(x, Xse.setzero_si128()));
            }
            else
            {
                return all(x == 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="long3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_alltrue_epi256<long>(Avx2.mm256_cmpeq_epi32(x, Avx.mm256_setzero_si256()), 3);
            }
            else
            {
                return none(x.xy) & (x.z == 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="long4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_alltrue_epi256<long>(Avx2.mm256_cmpeq_epi32(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return none(x.xy | x.zw);
            }
        }


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="ulong2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(ulong2 x)
        {
            return none((long2)x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="ulong3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(ulong3 x)
        {
            return none((long3)x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="ulong4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(ulong4 x)
        {
            return none((long4)x);
        }

        
        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="quarter2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(quarter2 x)
        {
            return all(x == (quarter)0f);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="quarter3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(quarter3 x)
        {
            return all(x == (quarter)0f);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="quarter4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(quarter4 x)
        {
            return all(x == (quarter)0f);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="quarter8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(quarter8 x)
        {
            return all(x == (quarter)0f);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="quarter16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(quarter16 x)
        {
            return all(x == (quarter)0f);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="quarter32"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(quarter32 x)
        {
            return all(x == (quarter)0f);
        }

        
        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="half2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(half2 x)
        {
            return all(x == (half)0f);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="half3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(half3 x)
        {
            return all(x == (half)0f);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="half4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(half4 x)
        {
            return all(x == (half)0f);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="half8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(half8 x)
        {
            return all(x == (half)0f);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="half16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(half16 x)
        {
            return all(x == (half)0f);
        }

        
        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="float2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(float2 x)
        {
            return !any(x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="float3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(float3 x)
        {
            return !any(x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="float4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(float4 x)
        {
            return !any(x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="float8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_alltrue_f256<float>(Xse.mm256_cmpeq_ps(x, Avx.mm256_setzero_ps()));
            }
            else
            {
                return none(x.v4_0) & none(x.v4_4);
            }
        }


        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="double2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(double2 x)
        {
            return !any(x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="double3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(double3 x)
        {
            return !any(x);
        }

        /// <summary>       Returns <see langword="true"/> if none of the components of the input <see cref="double4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool none(double4 x)
        {
            return !any(x);
        }
    }
}