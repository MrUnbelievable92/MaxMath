using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpeq_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_ps(a, b, (int)Avx.CMP.EQ_OQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmplt_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_ps(a, b, (int)Avx.CMP.LT_OQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpgt_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_ps(a, b, (int)Avx.CMP.GT_OQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmple_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_ps(a, b, (int)Avx.CMP.LE_OQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpge_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_ps(a, b, (int)Avx.CMP.GE_OQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpneq_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_ps(a, b, (int)Avx.CMP.NEQ_UQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpnlt_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_ps(a, b, (int)Avx.CMP.NLT_UQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpngt_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_ps(a, b, (int)Avx.CMP.NGT_UQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpnle_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_ps(a, b, (int)Avx.CMP.NLE_UQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpnge_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_ps(a, b, (int)Avx.CMP.NGE_UQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpord_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_ps(a, b, (int)Avx.CMP.ORD_Q);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpunord_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_ps(a, b, (int)Avx.CMP.UNORD_Q);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpeq_pd(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_pd(a, b, (int)Avx.CMP.EQ_OQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmplt_pd(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_pd(a, b, (int)Avx.CMP.LT_OQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpgt_pd(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_pd(a, b, (int)Avx.CMP.GT_OQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmple_pd(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_pd(a, b, (int)Avx.CMP.LE_OQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpge_pd(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_pd(a, b, (int)Avx.CMP.GE_OQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpneq_pd(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_pd(a, b, (int)Avx.CMP.NEQ_UQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpnlt_pd(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_pd(a, b, (int)Avx.CMP.NLT_UQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpngt_pd(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_pd(a, b, (int)Avx.CMP.NGT_UQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpnle_pd(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_pd(a, b, (int)Avx.CMP.NLE_UQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpnge_pd(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_pd(a, b, (int)Avx.CMP.NGE_UQ);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpord_pd(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_pd(a, b, (int)Avx.CMP.ORD_Q);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpunord_pd(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cmp_pd(a, b, (int)Avx.CMP.UNORD_Q);
            }
            else throw new IllegalInstructionException();
        }
    }
}
