using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte3 c)
        {
            return ((byte16)X86.Avx2.broadcastb_epi8(c)).Equals((byte16)X86.Ssse3.shuffle_epi8(c, new v128(0, 1, 2,   0,   0, 1, 2,   0,  0, 1, 2,   0,   0, 1, 2,   0)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte4 c)
        {
            return ((byte16)X86.Avx2.broadcastb_epi8(c)).Equals((byte16)X86.Avx2.broadcastd_epi32(c));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte8 c)
        {
            return ((byte16)X86.Avx2.broadcastb_epi8(c)).Equals((byte16)X86.Ssse3.shuffle_epi8(c, new v128(1, 2, 3, 4, 5, 6, 7,    0, 0, 0, 0, 0, 0, 0, 0, 0)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte16 c)
        {
            return ((byte16)X86.Avx2.broadcastb_epi8(c)).Equals(c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte32 c)
        {
            return ((byte32)X86.Avx2.mm256_broadcastb_epi8(X86.Avx.mm256_castsi256_si128(c))).Equals(c);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(sbyte3 c)
        {
            return all_eq((byte3)c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(sbyte4 c)
        {
            return all_eq((byte4)c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(sbyte8 c)
        {
            return all_eq((byte8)c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(sbyte16 c)
        {
            return all_eq((byte16)c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(sbyte32 c)
        {
            return all_eq((byte32)c);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(short3 c)
        {
            return ((short8)X86.Avx2.broadcastw_epi16(c)).Equals((short8)X86.Ssse3.shuffle_epi8(c, new v128(0, 1, 2, 3, 4, 5,   0, 1,    0, 1, 2, 3, 4, 5,    0, 1)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(short4 c)
        {
            return ((short8)X86.Avx2.broadcastw_epi16(c)).Equals((short8)X86.Avx2.broadcastq_epi64(c));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(short8 c)
        {
            return ((short8)X86.Avx2.broadcastw_epi16(c)).Equals(c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(short16 c)
        {
            return ((short16)X86.Avx2.mm256_broadcastw_epi16(X86.Avx.mm256_castsi256_si128(c))).Equals(c);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ushort3 c)
        {
            return all_eq((short3)c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ushort4 c)
        {
            return all_eq((short4)c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ushort8 c)
        {
            return all_eq((short8)c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ushort16 c)
        {
            return all_eq((short16)c);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(int3 c)
        {
            return c.xx.Equals(c.yz);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(int4 c)
        {
            return c.xxxx.Equals(c);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(int8 c)
        {
            return X86.Avx2.mm256_broadcastd_epi32(X86.Avx.mm256_castsi256_si128(c)).Equals(c);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(uint3 c)
        {
            return c.xx.Equals(c.yz);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(uint4 c)
        {
            return c.xxxx.Equals(c);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(uint8 c)
        {
            return all_eq((int8)c);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(long3 c)
        {
            return c.xx.Equals(c.yz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(long4 c)
        {
            return c.xxxx.Equals(c);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ulong3 c)
        {
            return all_eq((long3)c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ulong4 c)
        {
            return all_eq((long4)c);
        }
    }
}