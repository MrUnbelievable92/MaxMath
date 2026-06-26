using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool2"/> or a value greater than 1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 4)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(bool2 x)
        {
VectorAssert.IsNotGreater<byte2, byte>(tobyte(x), 1, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int)((uint)tzcnt((uint)x.Reinterpret<bool2, ushort>()) / 8);
            }
            else
            {
                return (int)((uint)tzcnt((uint)*(ushort*)&x) / 8);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool3"/> or a value greater than 2 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 4)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(bool3 x)
        {
VectorAssert.IsNotGreater<byte3, byte>(tobyte(x), 1, 3);
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int)((uint)tzcnt(((v128)x).UInt0) / 8);
            }
            else
            {
                int toInt = tobyte(x.z) << 16;
                *(ushort*)&toInt = *(ushort*)&x;

                return (int)((uint)tzcnt(toInt) / 8);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool4"/> or a value greater than 3 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 4)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(bool4 x)
        {
VectorAssert.IsNotGreater<byte4, byte>(tobyte(x), 1, 4);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int)((uint)tzcnt(x.Reinterpret<bool4, uint>()) / 8);
            }
            else
            {
                return (int)((uint)tzcnt(*(uint*)&x) / 8);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool8"/> or a value greater than 7 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 8)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(bool8 x)
        {
VectorAssert.IsNotGreater<byte8, byte>(tobyte(x), 1, 8);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int)((uint)tzcnt(((v128)x).ULong0) / 8);
            }
            else
            {
                return (int)((uint)tzcnt(*(ulong*)&x) / 8);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool16"/> or a value greater than 15 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 32)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(bool16 x)
        {
VectorAssert.IsNotGreater<byte16, byte>(tobyte(x), 1, 16);

            if (Sse2.IsSse2Supported)
            {
                return tzcnt(Xse.movemask_epi8(Xse.neg_epi8(x)));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return tzcnt(Xse.movemask_epi8x4(Xse.neg_epi8(x))) / 4;
            }
            else
            {
                int first8 = first(x.v8_0);

                if (first8 == 8)
                {
                    int last8 = first(x.v8_8);

                    return last8 == 8 ? 32 : 8 + last8;
                }
                else
                {
                    return first8;
                }
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool32"/> or a value greater than 31 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 32)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(bool32 x)
        {
VectorAssert.IsNotGreater<byte32, byte>(tobyte(x), 1, 32);

            if (Avx2.IsAvx2Supported)
            {
                return tzcnt(Avx2.mm256_movemask_epi8(Xse.mm256_neg_epi8(x)));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return tzcnt(Xse.movemask_epi8(Xse.neg_epi8(x.v16_0)) | (Xse.movemask_epi8(Xse.neg_epi8(x.v16_16)) << 16));
            }
            else
            {
                int first16 = first(x.v16_0);

                if (first16 == 32)
                {
                    int last16 = first(x.v16_16);

                    return last16 == 32 ? 32 : 16 + last16;
                }
                else
                {
                    return first16;
                }
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool2"/> or a value greater than 1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 4)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(Unity.Mathematics.bool2 x) => first((bool2)x);

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool3"/> or a value greater than 2 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 4)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(Unity.Mathematics.bool3 x) => first((bool3)x);

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool4"/> or a value greater than 3 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 4)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(Unity.Mathematics.bool4 x) => first((bool4)x);


        
        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool2"/> or a value greater than 1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 4)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int)((uint)tzcnt((uint)((v128)x.mask).UShort0) / 8);
            }
            else
            {
                return first((bool2)x);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool3"/> or a value greater than 2 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 4)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int)((uint)tzcnt(((v128)x.mask).UInt0) / 8);
            }
            else
            {
                return first((bool3)x);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool4"/> or a value greater than 3 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 4)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask8x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int)((uint)tzcnt(((v128)x.mask).UInt0) / 8);
            }
            else
            {
                return first((bool4)x);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool8"/> or a value greater than 7 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 8)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask8x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int)((uint)tzcnt(((v128)x.mask).ULong0) / 8);
            }
            else
            {
                return first((bool8)x);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool16"/> or a value greater than 15 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 32)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask8x16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return tzcnt(Xse.movemask_epi8(x));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return tzcnt(Xse.movemask_epi8x4(x)) / 4;
            }
            else
            {
                return first((bool16)x);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool32"/> or a value greater than 31 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 32)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask8x32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return tzcnt(Avx2.mm256_movemask_epi8(x));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return tzcnt(Xse.movemask_epi8(x.v16_0) | (Xse.movemask_epi8(x.v16_16) << 16));
            }
            else
            {
                return first((bool32)x);
            }
        }

        
        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool2"/> or a value greater than 1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 4)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int)((uint)tzcnt((uint)((v128)x.mask).UInt0) / 16);
            }
            else
            {
                return first((bool2)x);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool3"/> or a value greater than 2 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 4)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int)((uint)tzcnt(((v128)x.mask).ULong0) / 16);
            }
            else
            {
                return first((bool3)x);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool4"/> or a value greater than 3 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 8)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask16x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int)((uint)tzcnt(((v128)x.mask).ULong0) / 16);
            }
            else
            {
                return first((bool4)x);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool8"/> or a value greater than 7 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 32)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask16x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tzcnt(Xse.movemask_epi8(x)) / 2;
            }
            else
            {
                return first((bool8)x);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool16"/> or a value greater than 15 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 32)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask16x16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return tzcnt(Avx2.mm256_movemask_epi8(x)) / 2;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return tzcnt(Xse.movemask_epi8(x.v8_0) | (Xse.movemask_epi8(x.v8_8) << 16)) / 2;
            }
            else
            {
                return first((bool16)x);
            }
        }

        
        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool2"/> or a value greater than 1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 4)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int)((uint)tzcnt((uint)((v128)x.mask).ULong0) / 32);
            }
            else
            {
                return first((bool2)x);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool3"/> or a value greater than 2 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 32)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tzcnt(Xse.movemask_ps(x));
            }
            else
            {
                return first((bool3)x);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool4"/> or a value greater than 3 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 32)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask32x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tzcnt(Xse.movemask_ps(x));
            }
            else
            {
                return first((bool4)x);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool8"/> or a value greater than 7 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 32)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask32x8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return tzcnt(Avx.mm256_movemask_ps(x));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return tzcnt(Xse.movemask_ps(x.v4_0) | (Xse.movemask_ps(x.v4_4) << 4));
            }
            else
            {
                return first((bool8)x);
            }
        }

        
        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool2"/> or a value greater than 1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 32)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tzcnt(Xse.movemask_pd(x));
            }
            else
            {
                return first((bool2)x);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool3"/> or a value greater than 2 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 32)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask64x3 x)
        {
            if (Avx.IsAvxSupported)
            {
                return tzcnt(Avx.mm256_movemask_pd(x));
            }
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tzcnt(Xse.movemask_pd(x.xy) | (Xse.movemask_pd(x.mask.zw) << 2));
            }
            else
            {
                return first((bool3)x);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool4"/> or a value greater than 3 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 32)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(mask64x4 x)
        {
            if (Avx.IsAvxSupported)
            {
                return tzcnt(Avx.mm256_movemask_pd(x));
            }
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tzcnt(Xse.movemask_pd(x.xy) | (Xse.movemask_pd(x.zw) << 2));
            }
            else
            {
                return first((bool4)x);
            }
        }
    }
}