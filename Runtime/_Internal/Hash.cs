using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

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
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(x, Sse2.shufflelo_epi16(x, Sse.SHUFFLE(0, 0, 2, 2))).SInt0;
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v64(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(x, Sse2.shufflelo_epi16(x, Sse.SHUFFLE(0, 0, 3, 2))).SInt0;
            }
            else throw new BurstCompilerException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v128(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                x = Sse2.xor_si128(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 0, 3, 2)));

                return Sse2.xor_si128(x, Sse2.shufflelo_epi16(x, Sse.SHUFFLE(0, 0, 3, 2))).SInt0;
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v192(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 hi = ((long2)Avx2.mm256_extracti128_si256(x, 1)).xx;

                return v64(Sse2.xor_si128(Avx.mm256_castsi256_si128(x), hi));
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v256(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return v128(Sse2.xor_si128(Avx.mm256_castsi256_si128(x),
                                           Avx2.mm256_extracti128_si256(x, 1)));
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v256(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return v128(Sse2.xor_si128(Avx.mm256_castps256_ps128(x),
                                           Avx.mm256_extractf128_ps(x, 1)));
            }
            else throw new BurstCompilerException();
        }
    }
}