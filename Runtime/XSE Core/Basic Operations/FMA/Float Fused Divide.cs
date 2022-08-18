using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fdadd_ps(v128 a, v128 b, v128 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fmadd_ps(a, rcp23_ps(b), c);
            }
            else if (Sse.IsSseSupported)
            {
                return Sse.add_ps(Sse.div_ps(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fdsub_ps(v128 a, v128 b, v128 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fmsub_ps(a, rcp23_ps(b), c);
            }
            else if (Sse.IsSseSupported)
            {
                return Sse.sub_ps(Sse.div_ps(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fndadd_ps(v128 a, v128 b, v128 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fnmadd_ps(a, rcp23_ps(b), c);
            }
            else if (Sse.IsSseSupported)
            {
                return Sse.sub_ps(c, Sse.div_ps(a, b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fndsub_ps(v128 a, v128 b, v128 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fnmsub_ps(a, rcp23_ps(b), c);
            }
            else if (Sse.IsSseSupported)
            {
                return Sse.sub_ps(Sse.div_ps(a, b), neg_ps(c));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fdaddsub_ps(v128 a, v128 b, v128 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fmaddsub_ps(a, rcp23_ps(b), c);
            }
            else if (Sse3.IsSse3Supported)
            {
                return Sse3.addsub_ps(Sse.div_ps(a, b), c);
            }
            else if (Sse.IsSseSupported)
            {
                return Sse.add_ps(Sse.div_ps(a, b), Sse.xor_ps(c, new v128(1 << 31, 0, 1 << 31, 0)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fdsubadd_ps(v128 a, v128 b, v128 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fmsubadd_ps(a, rcp23_ps(b), c);
            }
            else if (Sse3.IsSse3Supported)
            {
                return Sse3.addsub_ps(Sse.div_ps(a, b), Sse.xor_ps(c, new v128(1 << 31, 0, 1 << 31, 0)));
            }
            else if (Sse.IsSseSupported)
            {
                return Sse.sub_ps(Sse.div_ps(a, b), Sse.xor_ps(c, new v128(1 << 31, 0, 1 << 31, 0)));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fdadd_ps(v256 a, v256 b, v256 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fmadd_ps(a, mm256_rcp23_ps(b), c);
            }
            else if (Avx.IsAvxSupported)
            {
                return Avx.mm256_add_ps(Avx.mm256_div_ps(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fdsub_ps(v256 a, v256 b, v256 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fmsub_ps(a, mm256_rcp23_ps(b), c);
            }
            else if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sub_ps(Avx.mm256_div_ps(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fndadd_ps(v256 a, v256 b, v256 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fnmadd_ps(a, mm256_rcp23_ps(b), c);
            }
            else if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sub_ps(c, Avx.mm256_div_ps(a, b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fndsub_ps(v256 a, v256 b, v256 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fnmsub_ps(a, mm256_rcp23_ps(b), c);
            }
            else if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sub_ps(Avx.mm256_div_ps(a, b), mm256_neg_ps(c));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fdaddsub_ps(v256 a, v256 b, v256 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fmaddsub_ps(a, mm256_rcp23_ps(b), c);
            }
            else if (Avx.IsAvxSupported)
            {
                return Avx.mm256_addsub_ps(Avx.mm256_div_ps(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fdsubadd_ps(v256 a, v256 b, v256 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fmsubadd_ps(a, mm256_rcp23_ps(b), c);
            }
            else if (Avx.IsAvxSupported)
            {
                return Avx.mm256_addsub_ps(Avx.mm256_div_ps(a, b), Avx.mm256_xor_ps(c, new v256(1 << 31, 0, 1 << 31, 0, 1 << 31, 0, 1 << 31, 0)));
            }
            else throw new IllegalInstructionException();
        }
    }
}
