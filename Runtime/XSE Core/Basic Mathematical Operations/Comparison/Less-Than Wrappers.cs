using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmplt_epu8(v128 left, v128 right, byte elements = 16)
        {
            if (Sse2.IsSse2Supported)
            {
                return cmpgt_epu8(right, left, elements);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcltq_u8(left, right);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmplt_epu8(v256 left, v256 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cmpgt_epu8(right, left);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmplt_epu16(v128 left, v128 right, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                return cmpgt_epu16(right, left, elements);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcltq_u16(left, right);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmplt_epu16(v256 left, v256 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cmpgt_epu16(right, left);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmplt_epu32(v128 left, v128 right, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                return cmpgt_epu32(right, left, elements);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcltq_u32(left, right);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmplt_epu32(v256 left, v256 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cmpgt_epu32(right, left);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmplt_epu64(v128 left, v128 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return cmpgt_epu64(right, left);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcltq_u64(left, right);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmplt_epu64(v256 left, v256 right, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cmpgt_epu64(right, left, elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmplt_epi8(v128 left, v128 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.cmplt_epi8(left, right);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcltq_s8(left, right);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmplt_epi8(v256 left, v256 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cmpgt_epi8(right, left);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmplt_epi16(v128 left, v128 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.cmplt_epi16(left, right);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcltq_s16(left, right);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmplt_epi16(v256 left, v256 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cmpgt_epi16(right, left);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmplt_epi32(v128 left, v128 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.cmplt_epi32(left, right);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcltq_s32(left, right);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmplt_epi32(v256 left, v256 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cmpgt_epi32(right, left);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmplt_epi64(v128 left, v128 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return cmpgt_epi64(right, left);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcltq_s64(left, right);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmplt_epi64(v256 left, v256 right, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cmpgt_epi64(right, left, elements);
            }
            else throw new IllegalInstructionException();
        }
    }
}