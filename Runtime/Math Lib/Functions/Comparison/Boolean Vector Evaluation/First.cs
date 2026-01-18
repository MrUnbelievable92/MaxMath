using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="bool2"/> or 4 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 4)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(bool2 x)
        {
VectorAssert.IsNotGreater<byte2, byte>(tobyte(x), 1, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int)((uint)math.tzcnt((uint)RegisterConversion.ToV128(x).UShort0) / 8);
            }
            else
            {
                return (int)((uint)math.tzcnt((uint)*(ushort*)&x) / 8);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="bool3"/> or 4 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 4)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(bool3 x)
        {
VectorAssert.IsNotGreater<byte3, byte>(tobyte(x), 1, 3);

            int toInt = *(byte*)&x.z << 16;
            *(ushort*)&toInt = *(ushort*)&x;

            return (int)((uint)math.tzcnt(toInt) / 8);
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="bool4"/> or 4 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 4)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(bool4 x)
        {
VectorAssert.IsNotGreater<byte4, byte>(tobyte(x), 1, 4);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int)((uint)math.tzcnt(RegisterConversion.ToV128(x).UInt0) / 8);
            }
            else
            {
                return (int)((uint)math.tzcnt(*(uint*)&x) / 8);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool8"/> or 8 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 8)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(bool8 x)
        {
VectorAssert.IsNotGreater<byte8, byte>(tobyte(x), 1, 8);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int)((uint)math.tzcnt(((v128)x).ULong0) / 8);
            }
            else
            {
                return (int)((uint)math.tzcnt(*(ulong*)&x) / 8);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool16"/> or 32 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 32)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(bool16 x)
        {
VectorAssert.IsNotGreater<byte16, byte>(tobyte(x), 1, 16);

            if (Sse2.IsSse2Supported)
            {
                return math.tzcnt(Xse.movemask_epi8(Xse.neg_epi8(x)));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return math.tzcnt(Xse.movemask_epi8x4(Xse.neg_epi8(x))) / 4;
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

        /// <summary>       Returns the index of the first <see langword="true"/> value of a <see cref="MaxMath.bool32"/> or 32 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(0, 32)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int first(bool32 x)
        {
VectorAssert.IsNotGreater<byte32, byte>(tobyte(x), 1, 32);

            if (Avx2.IsAvx2Supported)
            {
                return math.tzcnt(Avx2.mm256_movemask_epi8(Xse.mm256_neg_epi8(x)));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return math.tzcnt(Xse.movemask_epi8(Xse.neg_epi8(x.v16_0)) | (Xse.movemask_epi8(Xse.neg_epi8(x.v16_16)) << 16));
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
    }
}