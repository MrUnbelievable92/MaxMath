using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool2x2 x)
        {
            return all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool2x3 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool2x4 x)
        {
            return all(x.c0 & x.c1 & x.c2 & x.c3);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool3x2 x)
        {
            return all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool3x3 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool3x4 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool4x2 x)
        {
            return all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool4x3 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool4x4 x)
        {
            return all(x.c0 & x.c1 & x.c2 & x.c3);
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask8x2x2 x)
        {
            return all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask8x2x3 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask8x2x4 x)
        {
            return all(x.c0 & x.c1 & x.c2 & x.c3);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask8x3x2 x)
        {
            return all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask8x3x3 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask8x3x4 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask8x4x2 x)
        {
            return all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask8x4x3 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask8x4x4 x)
        {
            return all(x.c0 & x.c1 & x.c2 & x.c3);
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask16x2x2 x)
        {
            return all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask16x2x3 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask16x2x4 x)
        {
            return all(x.c0 & x.c1 & x.c2 & x.c3);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask16x3x2 x)
        {
            return all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask16x3x3 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask16x3x4 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask16x4x2 x)
        {
            return all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask16x4x3 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask16x4x4 x)
        {
            return all(x.c0 & x.c1 & x.c2 & x.c3);
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask32x2x2 x)
        {
            return all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask32x2x3 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask32x2x4 x)
        {
            return all(x.c0 & x.c1 & x.c2 & x.c3);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask32x3x2 x)
        {
            return all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask32x3x3 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask32x3x4 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask32x4x2 x)
        {
            return all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask32x4x3 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask32x4x4 x)
        {
            return all(x.c0 & x.c1 & x.c2 & x.c3);
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask64x2x2 x)
        {
            return all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask64x2x3 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask64x2x4 x)
        {
            return all(x.c0 & x.c1 & x.c2 & x.c3);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask64x3x2 x)
        {
            return all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask64x3x3 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask64x3x4 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4x2"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask64x4x2 x)
        {
            return all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4x3"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask64x4x3 x)
        {
            return all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4x4"/> matrix are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask64x4x4 x)
        {
            return all(x.c0 & x.c1 & x.c2 & x.c3);
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool2 x)
        {
            return Unity.Mathematics.math.all(x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool3 x)
        {
            return Unity.Mathematics.math.all(x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool4 x)
        {
            return Unity.Mathematics.math.all(x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool8"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool8 x)
        {
VectorAssert.IsNotGreater<byte8, byte>(tobyte(x), 1, 8);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<bool>(Xse.neg_epi8(x), 8);
            }
            else
            {
                return *(long*)&x == 0x0101_0101_0101_0101;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool16"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<bool>(Xse.neg_epi8(x));
            }
            else
            {
                return all(x.v8_0 & x.v8_8);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool32"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_alltrue_epi256<bool>(Xse.mm256_neg_epi8(x));
            }
            else
            {
                return all(x.v16_0 & x.v16_16);
            }
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(Unity.Mathematics.bool2 x) => all((bool2)x);

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(Unity.Mathematics.bool3 x) => all((bool3)x);

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(Unity.Mathematics.bool4 x) => all((bool4)x);


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<byte>(x, 2);
            }
            else
            {
                return all((bool2)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<byte>(x, 3);
            }
            else
            {
                return all((bool3)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask8x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<byte>(x, 4);
            }
            else
            {
                return all((bool4)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool8"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask8x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<byte>(x, 8);
            }
            else
            {
                return all((bool8)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool16"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask8x16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<byte>(x);
            }
            else
            {
                return all(x.v8_0 & x.v8_8);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool32"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask8x32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_alltrue_epi256<byte>(x);
            }
            else
            {
                return all(x.v16_0 & x.v16_16);
            }
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<ushort>(x, 2);
            }
            else
            {
                return all((bool2)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<ushort>(x, 3);
            }
            else
            {
                return all((bool3)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask16x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<ushort>(x, 4);
            }
            else
            {
                return all((bool4)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool8"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask16x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<ushort>(x, 8);
            }
            else
            {
                return all((bool8)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool16"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask16x16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_alltrue_epi256<ushort>(x);
            }
            else
            {
                return all(x.v8_0 & x.v8_8);
            }
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<uint>(x, 2);
            }
            else
            {
                return all((bool2)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<uint>(x, 3);
            }
            else
            {
                return all((bool3)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask32x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<uint>(x, 4);
            }
            else
            {
                return all((bool4)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool8"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask32x8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_alltrue_epi256<uint>(x);
            }
            else
            {
                return all((bool8)x);
            }
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool2"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<ulong>(x, 2);
            }
            else
            {
                return all((bool2)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool3"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask64x3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_alltrue_epi256<ulong>(x, 3);
            }
            else
            {
                return all((bool3)x);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="bool4"/> are <see langword="true"/>, <see langword="false"/> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(mask64x4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_alltrue_epi256<ulong>(x, 4);
            }
            else
            {
                return all((bool4)x);
            }
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="byte2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<byte>(Xse.cmpeq_epi8(x, Xse.setzero_si128()), 2);
            }
            else
            {
                return all(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="byte3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<byte>(Xse.cmpeq_epi8(x, Xse.setzero_si128()), 3);
            }
            else
            {
                return all(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="byte4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<byte>(Xse.cmpeq_epi8(x, Xse.setzero_si128()), 4);
            }
            else
            {
                return all(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="byte8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<byte>(Xse.cmpeq_epi8(x, Xse.setzero_si128()), 8);
            }
            else
            {
                return all(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="byte16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<byte>(Xse.cmpeq_epi8(x, Xse.setzero_si128()));
            }
            else
            {
                return all(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="byte32"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_allfalse_epi256<byte>(Avx2.mm256_cmpeq_epi8(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return all(x.v16_0) & all(x.v16_16);
            }
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="sbyte2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte2 x)
        {
            return all((byte2)x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="sbyte3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte3 x)
        {
            return all((byte3)x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="sbyte4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte4 x)
        {
            return all((byte4)x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="sbyte8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte8 x)
        {
            return all((byte8)x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="sbyte16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte16 x)
        {
            return all((byte16)x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="sbyte32"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte32 x)
        {
            return all((byte32)x);
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="short2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(short2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<short>(Xse.cmpeq_epi16(x, Xse.setzero_si128()), 2);
            }
            else
            {
                return all(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="short3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(short3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<short>(Xse.cmpeq_epi16(x, Xse.setzero_si128()), 3);
            }
            else
            {
                return all(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="short4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(short4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<short>(Xse.cmpeq_epi16(x, Xse.setzero_si128()), 4);
            }
            else
            {
                return all(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="short8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(short8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<short>(Xse.cmpeq_epi16(x, Xse.setzero_si128()));
            }
            else
            {
                return all(x != (short)0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="short16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_allfalse_epi256<short>(Avx2.mm256_cmpeq_epi16(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return all(x.v8_0) & all(x.v8_8);
            }
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="ushort2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ushort2 x)
        {
            return all((short2)x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="ushort3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ushort3 x)
        {
            return all((short3)x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="ushort4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ushort4 x)
        {
            return all((short4)x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="ushort8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ushort8 x)
        {
            return all((short8)x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="ushort16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ushort16 x)
        {
            return all((short16)x);
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="int2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(int2 x)
        {
            return Unity.Mathematics.math.all(x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="int3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(int3 x)
        {
            return Unity.Mathematics.math.all(x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="int4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(int4 x)
        {
            return Unity.Mathematics.math.all(x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="int8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_allfalse_epi256<int>(Avx2.mm256_cmpeq_epi32(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return all(x.v4_0) & all(x.v4_4);
            }
        }

        
        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="uint2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(uint2 x)
        {
            return Unity.Mathematics.math.all(x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="uint3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(uint3 x)
        {
            return Unity.Mathematics.math.all(x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="uint4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(uint4 x)
        {
            return Unity.Mathematics.math.all(x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="uint8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(uint8 x)
        {
            return all((int8)x);
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="long2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(long2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<long>(Xse.cmpeq_epi64(x, Xse.setzero_si128()));
            }
            else
            {
                return all(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="long3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_allfalse_epi256<long>(Avx2.mm256_cmpeq_epi32(x, Avx.mm256_setzero_si256()), 3);
            }
            else
            {
                return all(x.xy) & (x.z != 0);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="long4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_allfalse_epi256<long>(Avx2.mm256_cmpeq_epi32(x, Avx.mm256_setzero_si256()));
            }
            else
            {
                return all(x.xy) & all(x.zw);
            }
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="ulong2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ulong2 x)
        {
            return all((long2)x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="ulong3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ulong3 x)
        {
            return all((long3)x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="ulong4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ulong4 x)
        {
            return all((long4)x);
        }

        
        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="quarter2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(quarter2 x)
        {
            return all(x != (quarter)0f);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="quarter3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(quarter3 x)
        {
            return all(x != (quarter)0f);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="quarter4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(quarter4 x)
        {
            return all(x != (quarter)0f);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="quarter8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(quarter8 x)
        {
            return all(x != (quarter)0f);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="quarter16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(quarter16 x)
        {
            return all(x != (quarter)0f);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="quarter32"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(quarter32 x)
        {
            return all(x != (quarter)0f);
        }

        
        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="half2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(half2 x)
        {
            return all(x != (half)0f);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="half3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(half3 x)
        {
            return all(x != (half)0f);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="half4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(half4 x)
        {
            return all(x != (half)0f);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="half8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(half8 x)
        {
            return all(x != (half)0f);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="half16"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(half16 x)
        {
            return all(x != (half)0f);
        }

        
        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="float2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(float2 x)
        {
            return Unity.Mathematics.math.all(x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="float3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(float3 x)
        {
            return Unity.Mathematics.math.all(x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="float4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(float4 x)
        {
            return Unity.Mathematics.math.all(x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="float8"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_allfalse_f256<float>(Xse.mm256_cmpeq_ps(x, Avx.mm256_setzero_ps()));
            }
            else
            {
                return all(x.v4_0) & all(x.v4_4);
            }
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="double2"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(double2 x)
        {
            return Unity.Mathematics.math.all(x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="double3"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(double3 x)
        {
            return Unity.Mathematics.math.all(x);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of the input <see cref="double4"/> are non-zero, <see langword="false"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(double4 x)
        {
            return Unity.Mathematics.math.all(x);
        }
    }
}