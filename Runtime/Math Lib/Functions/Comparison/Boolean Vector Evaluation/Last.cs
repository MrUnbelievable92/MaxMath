using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool2"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(bool2 x)
        {
VectorAssert.IsNotGreater<byte2, byte>(tobyte(x), 1, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return 3 - (int)((uint)lzcnt((uint)x.Reinterpret<bool2, ushort>()) / 8);
            }
            else
            {
                return 3 - (int)((uint)lzcnt((uint)*(ushort*)&x) / 8);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool3"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 2)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(bool3 x)
        {
VectorAssert.IsNotGreater<byte3, byte>(tobyte(x), 1, 3);
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                return 3 - (int)((uint)lzcnt((((v128)x).UInt0 & 0x00FF_FFFF)) / 8);
            }
            else
            {
                int toInt = tobyte(x.z) << 16;
                *(ushort*)&toInt = *(ushort*)&x;

                return 3 - (int)((uint)lzcnt(toInt) / 8);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool4"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 3)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(bool4 x)
        {
VectorAssert.IsNotGreater<byte4, byte>(tobyte(x), 1, 4);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return 3 - (int)((uint)lzcnt(x.Reinterpret<bool4, uint>()) / 8);
            }
            else
            {
                return 3 - (int)((uint)lzcnt(*(uint*)&x) / 8);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool8"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 7)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(bool8 x)
        {
VectorAssert.IsNotGreater<byte8, byte>(tobyte(x), 1, 8);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return 7 - (int)((uint)lzcnt(((v128)x).ULong0) / 8);
            }
            else
            {
                return 7 - (int)((uint)lzcnt(*(ulong*)&x) / 8);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool16"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 15)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(bool16 x)
        {
VectorAssert.IsNotGreater<byte16, byte>(tobyte(x), 1, 16);

            if (Sse2.IsSse2Supported)
            {
                return 31 - lzcnt(Xse.movemask_epi8(Xse.neg_epi8(x)));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return 15 - (lzcnt(Xse.movemask_epi8x4(Xse.neg_epi8(x))) / 4);
            }
            else
            {
                int last8 = last(x.v8_8);

                if (last8 != -1)
                {
                    return 8 + last8;
                }
                else
                {
                    return last(x.v8_0);
                }
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool32"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 31)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(bool32 x)
        {
VectorAssert.IsNotGreater<byte32, byte>(tobyte(x), 1, 32);

            if (Avx2.IsAvx2Supported)
            {
                return 31 - lzcnt(Avx2.mm256_movemask_epi8(Xse.mm256_neg_epi8(x)));
            }
            else if (Sse2.IsSse2Supported)
            {
                return 31 - lzcnt(Xse.movemask_epi8(Xse.neg_epi8(x.v16_0)) | (Xse.movemask_epi8(Xse.neg_epi8(x.v16_16)) << 16));
            }
            else
            {
                int last16 = last(x.v16_16);

                if (last16 != -1)
                {
                    return 16 + last16;
                }
                else
                {
                    return last(x.v16_0);
                }
            }
        }


        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool2"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(Unity.Mathematics.bool2 x) => last((bool2)x);

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool3"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 2)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(Unity.Mathematics.bool3 x) => last((bool3)x);

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool4"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 3)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(Unity.Mathematics.bool4 x) => last((bool4)x);


        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool2"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return 3 - (int)((uint)lzcnt((uint)((v128)x).UShort0 / 8));
            }
            else
            {
                return last((bool2)x);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool3"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 2)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return 3 - (int)((uint)lzcnt(((v128)x).UInt0 & 0x00FF_FFFF) / 8);
            }
            else
            {
                return last((bool3)x);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool4"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 3)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask8x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return 3 - (int)((uint)lzcnt(((v128)x).UInt0) / 8);
            }
            else
            {
                return last((bool4)x);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool8"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 7)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask8x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return 7 - (int)((uint)lzcnt(((v128)x).ULong0) / 8);
            }
            else
            {
                return last((bool8)x);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool16"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 15)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask8x16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 31 - lzcnt(Xse.movemask_epi8(x));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return 15 - (lzcnt(Xse.movemask_epi8x4(x)) / 4);
            }
            else
            {
                return last((bool16)x);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool32"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 31)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask8x32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 31 - lzcnt(Avx2.mm256_movemask_epi8(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return 31 - lzcnt(Xse.movemask_epi8(x.v16_0) | (Xse.movemask_epi8(x.v16_16) << 16));
            }
            else
            {
                return last((bool32)x);
            }
        }


        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool2"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return 1 - (int)lzcnt(((v128)x).UInt0 / 16);
            }
            else
            {
                return last((bool2)x);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool3"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 2)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return 3 - (int)((uint)lzcnt((((v128)x).ULong0 & 0x0000_FFFF_FFFF_FFFF)) / 16);
            }
            else
            {
                return last((bool3)x);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool4"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 3)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask16x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return 3 - (int)((uint)lzcnt(((v128)x).ULong0) / 16);
            }
            else
            {
                return last((bool4)x);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool8"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 7)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask16x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int)(15 - (uint)lzcnt(Xse.movemask_epi8(x)) / 2);
            }
            else
            {
                return last((bool8)x);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool16"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 15)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask16x16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 15 - lzcnt(Avx2.mm256_movemask_epi8(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return 15 - (int)((uint)lzcnt(Xse.movemask_epi8(x.v8_0) | (Xse.movemask_epi8(x.v8_8) << 16)) / 2);
            }
            else
            {
                return last((bool16)x);
            }
        }


        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool2"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return 31 - lzcnt(Xse.movemask_ps(x) & 0b0011);
            }
            else
            {
                return last((bool2)x);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool3"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 2)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return 31 - lzcnt(Xse.movemask_ps(x) & 0b0111);
            }
            else
            {
                return last((bool3)x);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool4"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 3)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask32x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return 31 - lzcnt(Xse.movemask_ps(x));
            }
            else
            {
                return last((bool4)x);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool8"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 7)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask32x8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return 31 - lzcnt(Avx.mm256_movemask_ps(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return 31 - lzcnt(Xse.movemask_ps(x.v4_0) | (Xse.movemask_ps(x.v4_4) << 4));
            }
            else
            {
                return last((bool8)x);
            }
        }


        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool2"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return 31 - lzcnt(Xse.movemask_pd(x));
            }
            else
            {
                return last((bool2)x);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool3"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 2)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask64x3 x)
        {
            if (Avx.IsAvxSupported)
            {
                return 31 - lzcnt(Avx.mm256_movemask_pd(x) & 0b0111);
            }
            else if (Sse2.IsSse2Supported)
            {
                return 31 - lzcnt(Xse.movemask_pd(x.xy) | (Xse.movemask_pd(x.xy) << 2));
            }
            else
            {
                return last((bool3)x);
            }
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool4"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 3)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(mask64x4 x)
        {
            if (Avx.IsAvxSupported)
            {
                return 31 - lzcnt(Avx.mm256_movemask_pd(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return 31 - lzcnt(Xse.movemask_pd(x.xy) | (Xse.movemask_pd(x.xy) << 2));
            }
            else
            {
                return last((bool4)x);
            }
        }
    }
}