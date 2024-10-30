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
        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="bool2"/>.       </summary>
        [return: AssumeRange(0ul, 2ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint count(bool2 x)
        {
VectorAssert.IsNotGreater<byte2, byte>(tobyte(x), 1, 2);

            if (Architecture.IsSIMDSupported)
            {
                return (uint)math.countbits((uint)RegisterConversion.ToV128(x).UShort0);
            }
            else
            {
                return (uint)math.countbits((uint)(*(ushort*)&x));
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="bool3"/>.       </summary>
        [return: AssumeRange(0ul, 3ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint count(bool3 x)
        {
VectorAssert.IsNotGreater<byte3, byte>(tobyte(x), 1, 3);

            int toInt = *(byte*)&x.z << 16;
            *(ushort*)&toInt = *(ushort*)&x;

            return (uint)math.countbits(toInt);
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="bool4"/>.       </summary>
        [return: AssumeRange(0ul, 4ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint count(bool4 x)
        {
VectorAssert.IsNotGreater<byte4, byte>(tobyte(x), 1, 4);

            if (Architecture.IsSIMDSupported)
            {
                return (uint)math.countbits(RegisterConversion.ToV128(x).UInt0);
            }
            else
            {
                return (uint)math.countbits(*(uint*)&x);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool8"/>.       </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint count(bool8 x)
        {
VectorAssert.IsNotGreater<byte8, byte>(tobyte(x), 1, 8);

            if (Architecture.IsSIMDSupported)
            {
                return (uint)math.countbits(((v128)x).ULong0);
            }
            else
            {
                return (uint)math.countbits(*(ulong*)&x);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool16"/>.       </summary>
        [return: AssumeRange(0ul, 16ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint count(bool16 x)
        {
VectorAssert.IsNotGreater<byte16, byte>(tobyte(x), 1, 16);

            if (Architecture.IsSIMDSupported)
            {
                return (uint)math.countbits(Xse.movemask_epi8(Xse.neg_epi8(x)));
            }
            else
            {
                return count(x.v8_0) + count(x.v8_8);
            }
        }

        /// <summary>       Returns the number of <see langword="true"/> values in a <see cref="MaxMath.bool32"/>.       </summary>
        [return: AssumeRange(0ul, 32ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint count(bool32 x)
        {
VectorAssert.IsNotGreater<byte32, byte>(tobyte(x), 1, 32);

            if (Avx2.IsAvx2Supported)
            {
                return (uint)math.countbits(Avx2.mm256_movemask_epi8(Xse.mm256_neg_epi8(x)));
            }
            else
            {
                return count(x.v16_0) + count(x.v16_16);
            }
        }
    }
}