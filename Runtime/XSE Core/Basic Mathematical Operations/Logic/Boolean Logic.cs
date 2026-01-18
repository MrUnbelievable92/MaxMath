using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 not_si128(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                //if (Avx512.IsAvx512Supported)
                //{
                //    return ternarylogic_si128(a, a, a, TernaryOperation.OxOF);
                //}
                //else
                //{
                      return xor_si128(a, setall_si128());
                //}
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vmvnq_u32(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_not_si256(v256 a)
        {
            if (Avx.IsAvxSupported)
            {
                //if (Avx512.IsAvx512Supported)
                //{
                //    return mm256_ternarylogic_si256(a, a, a, TernaryOperation.OxOF);
                //}
                //else
                //{
                      return Avx.mm256_xor_ps(a, mm256_setall_ps());
                //}
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 nand_si128(v128 a, v128 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                //if (Avx512.IsAvx512Supported)
                //{
                //    return ternarylogic_si128(b, a, a, TernaryOperation.Ox3F);
                //}
                //else
                //{
                      return not_si128(and_si128(a, b));
                //}
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_nand_si256(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                //if (Avx512.IsAvx512Supported)
                //{
                //    return mm256_ternarylogic_si256(b, a, a, TernaryOperation.Ox3F);
                //}
                //else
                //{
                      return mm256_not_si256(Avx.mm256_and_ps(a, b));
                //}
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 ornot_si128(v128 a, v128 b)
        {
            //if (Avx512.IsAvx512Supported)
            //{
            //    return ternarylogic_si128(b, a, a, TernaryOperation.OxF3);
            //}
            //else
            if (Sse2.IsSse2Supported)
            {
                return or_si128(not_si128(a), b);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vornq_u32(b, a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_ornot_si256(v256 a, v256 b)
        {
            //if (Avx512.IsAvx512Supported)
            //{
            //    return mm256_ternarylogic_si256(b, a, a, TernaryOperation.OxF3);
            //}
            //else
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_or_ps(mm256_not_si256(a), b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 nor_si128(v128 a, v128 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                //if (Avx512.IsAvx512Supported)
                //{
                //    return ternarylogic_si128(a, b, a, TernaryOperation.OxO3);
                //}
                //else
                //{
                      return not_si128(or_si128(a, b));
                //}
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_nor_si256(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                //if (Avx512.IsAvx512Supported)
                //{
                //    return mm256_ternarylogic_si256(a, b, a, TernaryOperation.OxO3);
                //}
                //else
                //{
                      return mm256_not_si256(Avx.mm256_or_ps(a, b));
                //}
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 xnor_si128(v128 a, v128 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                //if (Avx512.IsAvx512Supported)
                //{
                //    return ternarylogic_si128(a, b, a, TernaryOperation.OxC3);
                //}
                //else
                //{
                      if (constexpr.IS_CONST(a))
                      {
                          return xor_si128(not_si128(a), b);
                      }
                      else if (constexpr.IS_CONST(b))
                      {
                          return xor_si128(a, not_si128(b));
                      }
                      else
                      {
                          return not_si128(xor_si128(a, b));
                      }
                //}
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_xnor_si256(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                //if (Avx512.IsAvx512Supported)
                //{
                //    return mm256_ternarylogic_si256(a, b, a, TernaryOperation.OxC3);
                //}
                //else
                //{
                      if (constexpr.IS_CONST(a))
                      {
                          return Avx.mm256_xor_ps(mm256_not_si256(a), b);
                      }
                      else if (constexpr.IS_CONST(b))
                      {
                          return Avx.mm256_xor_ps(a, mm256_not_si256(b));
                      }
                      else
                      {
                          return mm256_not_si256(Avx.mm256_xor_ps(a, b));
                      }
                //}
            }
            else throw new IllegalInstructionException();
        }
    }
}
