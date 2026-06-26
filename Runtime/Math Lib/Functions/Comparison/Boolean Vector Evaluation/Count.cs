using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool2"/>.       </summary>
        [return: AssumeRange(0ul, 2ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(bool2 x)
        {
VectorAssert.IsNotGreater<byte2, byte>(tobyte(x), 1, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return countbits((uint)x.Reinterpret<bool2, ushort>());
            }
            else
            {
                return countbits((uint)(*(ushort*)&x));
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool3"/>.       </summary>
        [return: AssumeRange(0ul, 3ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(bool3 x)
        {
VectorAssert.IsNotGreater<byte3, byte>(tobyte(x), 1, 3);

            int toInt = tobyte(x.z) << 16;
            *(ushort*)&toInt = *(ushort*)&x;

            return countbits(toInt);
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool4"/>.       </summary>
        [return: AssumeRange(0ul, 4ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(bool4 x)
        {
VectorAssert.IsNotGreater<byte4, byte>(tobyte(x), 1, 4);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return countbits(x.Reinterpret<bool4, uint>());
            }
            else
            {
                return countbits(*(uint*)&x);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool8"/>.       </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(bool8 x)
        {
VectorAssert.IsNotGreater<byte8, byte>(tobyte(x), 1, 8);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return countbits(((v128)x).ULong0);
            }
            else
            {
                return countbits(*(ulong*)&x);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool16"/>.       </summary>
        [return: AssumeRange(0ul, 16ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(bool16 x)
        {
VectorAssert.IsNotGreater<byte16, byte>(tobyte(x), 1, 16);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return countbits(Xse.movemask_epi8(Xse.neg_epi8(x)));
            }
            else
            {
                return (byte)(count(x.v8_0) + count(x.v8_8));
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool32"/>.       </summary>
        [return: AssumeRange(0ul, 32ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(bool32 x)
        {
VectorAssert.IsNotGreater<byte32, byte>(tobyte(x), 1, 32);

            if (Avx2.IsAvx2Supported)
            {
                return countbits(Avx2.mm256_movemask_epi8(Xse.mm256_neg_epi8(x)));
            }
            else
            {
                return (byte)(count(x.v16_0) + count(x.v16_16));
            }
        }


        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool2"/>.       </summary>
        [return: AssumeRange(0ul, 2ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(Unity.Mathematics.bool2 x) => count((bool2)x);

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool3"/>.       </summary>
        [return: AssumeRange(0ul, 3ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(Unity.Mathematics.bool3 x) => count((bool3)x);

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool4"/>.       </summary>
        [return: AssumeRange(0ul, 4ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(Unity.Mathematics.bool4 x) => count((bool4)x);


        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool2"/>.       </summary>
        [return: AssumeRange(0ul, 2ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte)(countbits(((v128)x).UShort0) / 8);
            }
            else
            {
                return count((bool2)x);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool3"/>.       </summary>
        [return: AssumeRange(0ul, 3ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte)(countbits(Xse.movemask_epi8(x) & 0b0111));
            }
            else
            {
                return count((bool3)x);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool4"/>.       </summary>
        [return: AssumeRange(0ul, 4ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask8x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte)(countbits(((v128)x).UInt0) / 8);
            }
            else
            {
                return count((bool4)x);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool8"/>.       </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask8x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte)(countbits(((v128)x).ULong0) / 8);
            }
            else
            {
                return count((bool8)x);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool16"/>.       </summary>
        [return: AssumeRange(0ul, 16ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask8x16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return countbits(Xse.movemask_epi8(x));
            }
            else
            {
                return count((bool16)x);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool32"/>.       </summary>
        [return: AssumeRange(0ul, 32ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask8x32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return countbits(Avx2.mm256_movemask_epi8(x));
            }
            else
            {
                return (byte)(count(x.v16_0) + count(x.v16_16));
            }
        }


        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool2"/>.       </summary>
        [return: AssumeRange(0ul, 2ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte)(countbits(((v128)x).UInt0) / 16);
            }
            else
            {
                return count((bool2)x);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool3"/>.       </summary>
        [return: AssumeRange(0ul, 3ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte)(countbits(Xse.movemask_epi8(x) & 0b0011_1111) / 2);
            }
            else
            {
                return count((bool3)x);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool4"/>.       </summary>
        [return: AssumeRange(0ul, 4ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask16x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte)(countbits(((v128)x).ULong0) / 16);
            }
            else
            {
                return count((bool4)x);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool8"/>.       </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask16x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte)(countbits(Xse.movemask_epi8(x)) / 2);
            }
            else
            {
                return count((bool8)x);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool16"/>.       </summary>
        [return: AssumeRange(0ul, 16ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask16x16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return (byte)(countbits(Avx2.mm256_movemask_epi8(x)) / 2);
            }
            else
            {
                return (byte)(count(x.v8_0) + count(x.v8_8));
            }
        }


        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool2"/>.       </summary>
        [return: AssumeRange(0ul, 2ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte)(countbits(((v128)x).ULong0) / 32);
            }
            else
            {
                return count((bool2)x);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool3"/>.       </summary>
        [return: AssumeRange(0ul, 3ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return countbits(Xse.movemask_ps(x) & 0b0111);
            }
            else
            {
                return count((bool3)x);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool4"/>.       </summary>
        [return: AssumeRange(0ul, 4ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask32x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return countbits(Xse.movemask_ps(x));
            }
            else
            {
                return count((bool4)x);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool8"/>.       </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask32x8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return countbits(Avx.mm256_movemask_ps(x));
            }
            else
            {
                return (byte)(count(x.v4_0) + count(x.v4_4));
            }
        }


        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool2"/>.       </summary>
        [return: AssumeRange(0ul, 2ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return countbits(Xse.movemask_pd(x));
            }
            else
            {
                return count((bool2)x);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool3"/>.       </summary>
        [return: AssumeRange(0ul, 3ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask64x3 x)
        {
            if (Avx.IsAvxSupported)
            {
                return countbits(Avx.mm256_movemask_pd(x) & 0b0111);
            }
            else
            {
                return (byte)(count(x.xy) + tobyte(x.z));
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool4"/>.       </summary>
        [return: AssumeRange(0ul, 4ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte count(mask64x4 x)
        {
            if (Avx.IsAvxSupported)
            {
                return countbits(Avx.mm256_movemask_pd(x));
            }
            else
            {
                return (byte)(count(x.xy) + count(x.zw));
            }
        }
    }
}