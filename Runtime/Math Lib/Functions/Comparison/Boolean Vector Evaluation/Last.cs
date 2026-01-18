using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="bool2"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(bool2 x)
        {
VectorAssert.IsNotGreater<byte2, byte>(tobyte(x), 1, 2);

            return 3 - (int)((uint)math.lzcnt((uint)*(ushort*)&x) / 8);
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="bool3"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 2)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(bool3 x)
        {
VectorAssert.IsNotGreater<byte3, byte>(tobyte(x), 1, 3);

            int toInt = *(byte*)&x.z << 16;
            *(ushort*)&toInt = *(ushort*)&x;

            return 3 - (int)((uint)math.lzcnt(toInt) / 8);
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="bool4"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 3)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(bool4 x)
        {
VectorAssert.IsNotGreater<byte4, byte>(tobyte(x), 1, 4);

            return 3 - (int)((uint)math.lzcnt(*(int*)&x) / 8);
        }

        /// <summary>       Returns the index of the last <see langword="true"/> of a <see cref="MaxMath.bool8"/> or -1 if none are <see langword="true"/>.      </summary>
        [return: AssumeRange(-1, 7)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int last(bool8 x)
        {
VectorAssert.IsNotGreater<byte8, byte>(tobyte(x), 1, 8);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return 7 - (int)((uint)math.lzcnt(((v128)x).SLong0) / 8);
            }
            else
            {
                return 7 - (int)((uint)math.lzcnt(*(long*)&x) / 8);
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
                return 31 - math.lzcnt(Xse.movemask_epi8(Xse.neg_epi8(x)));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return 31 - (math.lzcnt(Xse.movemask_epi8x4(Xse.neg_epi8(x))) / 4);
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
                return 31 - math.lzcnt(Avx2.mm256_movemask_epi8(Xse.mm256_neg_epi8(x)));
            }
            else if (Sse2.IsSse2Supported)
            {
                return 31 - math.lzcnt(Xse.movemask_epi8(Xse.neg_epi8(x.v16_0)) | (Xse.movemask_epi8(Xse.neg_epi8(x.v16_16)) << 16));
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
    }
}