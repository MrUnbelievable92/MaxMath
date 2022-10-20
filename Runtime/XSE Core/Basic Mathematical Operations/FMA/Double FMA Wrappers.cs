//#define TESTING


using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fmadd_pd(v128 a, v128 b, v128 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fmadd_pd(a, b, c);
            }
            else 
#endif
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_pd(Sse2.mul_pd(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fmsub_pd(v128 a, v128 b, v128 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fmsub_pd(a, b, c);
            }
            else 
#endif
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_pd(Sse2.mul_pd(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fnmadd_pd(v128 a, v128 b, v128 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fnmadd_pd(a, b, c);
            }
            else 
#endif
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_pd(c, Sse2.mul_pd(a, b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fnmsub_pd(v128 a, v128 b, v128 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fnmsub_pd(a, b, c);
            }
            else 
#endif
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_pd(Sse2.mul_pd(a, b), neg_pd(c));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fmaddsub_pd(v128 a, v128 b, v128 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fmaddsub_pd(a, b, c);
            }
            else 
#endif
            if (Sse3.IsSse3Supported)
            {
                return Sse3.addsub_pd(Sse2.mul_pd(a, b), c);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.add_pd(Sse2.mul_pd(a, b), Sse2.xor_pd(c, new v128(1ul << 63, 0)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fmsubadd_pd(v128 a, v128 b, v128 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fmsubadd_pd(a, b, c);
            }
            else 
#endif
            if (Sse3.IsSse3Supported)
            {
                return Sse3.addsub_pd(Sse2.mul_pd(a, b), Sse2.xor_pd(c, new v128(1ul << 63, 0)));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_pd(Sse2.mul_pd(a, b), Sse2.xor_pd(c, new v128(1ul << 63, 0)));
            }
            else throw new IllegalInstructionException();
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fmadd_pd(v256 a, v256 b, v256 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fmadd_pd(a, b, c);
            }
            else 
#endif
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_add_pd(Avx.mm256_mul_pd(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fmsub_pd(v256 a, v256 b, v256 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fmsub_pd(a, b, c);
            }
            else 
#endif
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sub_pd(Avx.mm256_mul_pd(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fnmadd_pd(v256 a, v256 b, v256 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fnmadd_pd(a, b, c);
            }
            else 
#endif
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sub_pd(c, Avx.mm256_mul_pd(a, b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fnmsub_pd(v256 a, v256 b, v256 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fnmsub_pd(a, b, c);
            }
            else 
#endif
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sub_pd(Avx.mm256_mul_pd(a, b), mm256_neg_pd(c));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fmaddsub_pd(v256 a, v256 b, v256 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fmaddsub_pd(a, b, c);
            }
            else 
#endif
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_addsub_pd(Avx.mm256_mul_pd(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fmsubadd_pd(v256 a, v256 b, v256 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fmsubadd_pd(a, b, c);
            }
            else 
#endif
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_addsub_pd(Avx.mm256_mul_pd(a, b), Avx.mm256_xor_pd(c, new v256(1ul << 63, 0, 1ul << 63, 0)));
            }
            else throw new IllegalInstructionException();
        }
    }
}
