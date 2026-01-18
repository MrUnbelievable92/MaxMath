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
            if (BurstArchitecture.IsFMASupported)
            {
                return fmadd_ps(a, rcp23_ps(b), c);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return add_ps(div_ps(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fdsub_ps(v128 a, v128 b, v128 c)
        {
            if (BurstArchitecture.IsFMASupported)
            {
                return fmsub_ps(a, rcp23_ps(b), c);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return sub_ps(div_ps(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fndadd_ps(v128 a, v128 b, v128 c)
        {
            if (BurstArchitecture.IsFMASupported)
            {
                return fnmadd_ps(a, rcp23_ps(b), c);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return sub_ps(c, div_ps(a, b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fndsub_ps(v128 a, v128 b, v128 c)
        {
            if (BurstArchitecture.IsFMASupported)
            {
                return fnmsub_ps(a, rcp23_ps(b), c);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return sub_ps(neg_ps(c), div_ps(a, b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fdaddsub_ps(v128 a, v128 b, v128 c)
        {
            if (BurstArchitecture.IsFMASupported)
            {
                return fmaddsub_ps(a, rcp23_ps(b), c);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return addsub_ps(div_ps(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fdsubadd_ps(v128 a, v128 b, v128 c)
        {
            if (BurstArchitecture.IsFMASupported)
            {
                return fmsubadd_ps(a, rcp23_ps(b), c);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return subadd_ps(div_ps(a, b), c);
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
                return Avx.mm256_sub_ps(mm256_neg_ps(c), Avx.mm256_div_ps(a, b));
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
                return mm256_subadd_ps(Avx.mm256_div_ps(a, b), c);
            }
            else throw new IllegalInstructionException();
        }
    }
}
