using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 blendv_epi8(v128 a, v128 b, v128 mask)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.blendv_epi8(a, b, mask);
			}
            else if (Architecture.IsSIMDSupported)
            {
                return blendv_si128(a, b, srai_epi8(mask, 7));
            }
			else throw new IllegalInstructionException();
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_blendv_si256(v256 a, v256 b, v256 mask)
        {
            //if (Avx512.IsAvx512Supported)
            //{
            //    UNSAFE - performs bit-by-bit blend and not byte-by-byte
            //    return mm256_ternarylogic_si256(A, B, C, TernaryOperation.OxD8);
            //}
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(a, b, mask);
            }
            else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 blendv_si128(v128 a, v128 b, v128 mask)
        {
            //if (Avx512.IsAvx512Supported)
            //{
            //    UNSAFE - performs bit-by-bit blend and not byte-by-byte
            //    return ternarylogic_si128(A, B, C, TernaryOperation.OxD8);
            //}
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.blendv_epi8(a, b, mask);
            }
            else if (Sse2.IsSse2Supported)
            {
                // UNSAFE - performs bit-by-bit blend and not byte-by-byte
                return or_si128(and_si128(mask, b),
                                andnot_si128(mask, a));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                // UNSAFE - performs bit-by-bit blend and not byte-by-byte
                return Arm.Neon.vbslq_u8(mask, b, a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 blendv_ps(v128 a, v128 b, v128 mask)
        {
            //if (Avx512.IsAvx512Supported)
            //{
            //    UNSAFE - performs bit-by-bit blend and not float-by-float
            //    return ternarylogic_si128(A, B, C, TernaryOperation.OxD8);
            //}
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.blendv_ps(a, b, mask);
            }
            else if (Architecture.IsSIMDSupported)
            {
                return blendv_si128(a, b, srai_epi32(mask, 31));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 blendv_pd(v128 a, v128 b, v128 mask)
        {
            //if (Avx512.IsAvx512Supported)
            //{
            //    UNSAFE - performs bit-by-bit blend and not double-by-double
            //    return ternarylogic_si128(A, B, C, TernaryOperation.OxD8);
            //}
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.blendv_pd(a, b, mask);
            }
            else if (Architecture.IsSIMDSupported)
            {
                return blendv_si128(a, b, srai_epi64(mask, 63));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 blend_epi16(v128 a, v128 b, byte imm8)
        {
            v128 mask = new v128((short)(-((imm8 >> 0) & 1)),
                                 (short)(-((imm8 >> 1) & 1)),
                                 (short)(-((imm8 >> 2) & 1)),
                                 (short)(-((imm8 >> 3) & 1)),
                                 (short)(-((imm8 >> 4) & 1)),
                                 (short)(-((imm8 >> 5) & 1)),
                                 (short)(-((imm8 >> 6) & 1)),
                                 (short)(-((imm8 >> 7) & 1)));

            if (Sse2.IsSse2Supported)
            {
                return blendv_si128(a, b, mask);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vbslq_u16(mask, b, a);
            }
            else throw new IllegalInstructionException();
        }
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 blend_pd(v128 a, v128 b, int imm8)
		{
            v128 mask = new v128(-((imm8 >> 0) & 1L),
                                 -((imm8 >> 1) & 1L));

            if (Sse2.IsSse2Supported)
            {
                return blendv_si128(a, b, mask);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vbslq_f64(mask, b, a);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 blend_ps(v128 a, v128 b, int imm8)
		{
            v128 mask = new v128(-((imm8 >> 0) & 1),
                                 -((imm8 >> 1) & 1),
                                 -((imm8 >> 2) & 1),
                                 -((imm8 >> 3) & 1));

            if (Sse2.IsSse2Supported)
            {
                return blendv_si128(a, b, mask);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vbslq_f32(mask, b, a);
            }
			else throw new IllegalInstructionException();
		}
    }
}
