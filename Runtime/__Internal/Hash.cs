using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    // Simple hashing based on the .NET standard => XOR
    internal static class Hash
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v24(v128 x)
        {
            return maxmath.bitmask32(24) & x.SInt0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v48(v128 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.xor_si128(x, Xse.shufflelo_epi16(x, Sse.SHUFFLE(0, 0, 2, 2))).SInt0;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v64(v128 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.xor_si128(x, Xse.shufflelo_epi16(x, Sse.SHUFFLE(0, 0, 3, 2))).SInt0;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v128(v128 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return v64(Xse.xor_si128(x, Xse.shuffle_epi32(x, Sse.SHUFFLE(0, 0, 3, 2))));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v192(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 hi = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(2, 2, 2, 2)));

                return v128(Xse.xor_si128(Avx.mm256_castsi256_si128(x), hi));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v256(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return v128(Xse.xor_si128(Avx.mm256_castsi256_si128(x),
                                          Avx2.mm256_extracti128_si256(x, 1)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v256(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return v128(Sse.xor_ps(Avx.mm256_castps256_ps128(x),
                                       Avx.mm256_extractf128_ps(x, 1)));
            }
            else throw new IllegalInstructionException();
        }
    }
}