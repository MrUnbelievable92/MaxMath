using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns number of trailing zeros in the binary representations of a byte value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 8ul)]
        public static byte tzcnt(byte x)
        {
            // eliminates second test hardcoded by Unity; min(tzcnt, 8) adds another branch (for whatever reason)

            return (x == 0) ? (byte)8 : (byte)math.tzcnt((uint)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a byte2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tzcnt(byte2 x)
        {
            return new byte2(tzcnt(x.x), tzcnt(x.y));
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a byte3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tzcnt(byte3 x)
        {
            return new byte3(tzcnt(x.x), tzcnt(x.y), tzcnt(x.z));
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a byte4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tzcnt(byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 compareMask = x & (byte4)(-(sbyte4)x);

                byte4 first  = Mask.BlendV(default(v128), new byte4(1), Sse2.cmpeq_epi8(x, default(v128)));
                byte4 second = Mask.BlendV(new byte4(4), default(v128), Sse2.cmpeq_epi8(compareMask & (byte4)0x0F, default(v128)));
                byte4 third  = Mask.BlendV(new byte4(2), default(v128), Sse2.cmpeq_epi8(compareMask & (byte4)0x33, default(v128)));
                byte4 fourth = Mask.BlendV(new byte4(1), default(v128), Sse2.cmpeq_epi8(compareMask & (byte4)0x55, default(v128)));

                return (7 + first) - (second - third) - fourth;
            }
            else
            {
                return new byte4(tzcnt(x.x), tzcnt(x.y), tzcnt(x.z), tzcnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a byte8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tzcnt(byte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 compareMask = x & (byte8)(-(sbyte8)x);

                byte8 first  = Mask.BlendV(default(v128), new byte8(1), Sse2.cmpeq_epi8(x, default(v128)));
                byte8 second = Mask.BlendV(new byte8(4), default(v128), Sse2.cmpeq_epi8(compareMask & (byte8)0x0F, default(v128)));
                byte8 third  = Mask.BlendV(new byte8(2), default(v128), Sse2.cmpeq_epi8(compareMask & (byte8)0x33, default(v128)));
                byte8 fourth = Mask.BlendV(new byte8(1), default(v128), Sse2.cmpeq_epi8(compareMask & (byte8)0x55, default(v128)));

                return (7 + first) - (second - third) - fourth;
            }
            else
            {
                return new byte8(tzcnt(x.x0), tzcnt(x.x1), tzcnt(x.x2), tzcnt(x.x3), tzcnt(x.x4), tzcnt(x.x5), tzcnt(x.x6), tzcnt(x.x7));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a byte16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tzcnt(byte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 compareMask = x & (byte16)(-(sbyte16)x);

                byte16 first  = Mask.BlendV(default(v128), new byte16(1), Sse2.cmpeq_epi8(x, default(v128)));
                byte16 second = Mask.BlendV(new byte16(4), default(v128), Sse2.cmpeq_epi8(compareMask & (byte16)0x0F, default(v128)));
                byte16 third  = Mask.BlendV(new byte16(2), default(v128), Sse2.cmpeq_epi8(compareMask & (byte16)0x33, default(v128)));
                byte16 fourth = Mask.BlendV(new byte16(1), default(v128), Sse2.cmpeq_epi8(compareMask & (byte16)0x55, default(v128)));
                
                return (7 + first) - (second - third) - fourth;
            }
            else
            {
                return new byte16(tzcnt(x.x0), tzcnt(x.x1), tzcnt(x.x2), tzcnt(x.x3), tzcnt(x.x4), tzcnt(x.x5), tzcnt(x.x6), tzcnt(x.x7), tzcnt(x.x8), tzcnt(x.x9), tzcnt(x.x10), tzcnt(x.x11), tzcnt(x.x12), tzcnt(x.x13), tzcnt(x.x14), tzcnt(x.x15));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a byte32 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tzcnt(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 compareMask = x & (byte32)(-(sbyte32)x);

                byte32 first  = Avx2.mm256_blendv_epi8(default(v256), new byte32(1), Avx2.mm256_cmpeq_epi8(x, default(v256)));
                byte32 second = Avx2.mm256_blendv_epi8(new byte32(4), default(v256), Avx2.mm256_cmpeq_epi8(compareMask & (byte32)0x0F, default(v256)));
                byte32 third  = Avx2.mm256_blendv_epi8(new byte32(2), default(v256), Avx2.mm256_cmpeq_epi8(compareMask & (byte32)0x33, default(v256)));
                byte32 fourth = Avx2.mm256_blendv_epi8(new byte32(1), default(v256), Avx2.mm256_cmpeq_epi8(compareMask & (byte32)0x55, default(v256)));

                return (7 + first) - (second - third) - fourth;
            }
            else
            {
                return new byte32(tzcnt(x.v16_0), tzcnt(x.v16_16));
            }
        }


        /// <summary>       Returns number of trailing zeros in the binary representations of an sbyte value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 8)]
        public static sbyte tzcnt(sbyte x)
        {
            return (sbyte)tzcnt((byte)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an sbyte2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tzcnt(sbyte2 x)
        {
            return (sbyte2)tzcnt((byte2)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an sbyte3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tzcnt(sbyte3 x)
        {
            return (sbyte3)tzcnt((byte3)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an sbyte4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tzcnt(sbyte4 x)
        {
            return (sbyte4)tzcnt((byte4)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an sbyte8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tzcnt(sbyte8 x)
        {
            return (sbyte8)tzcnt((byte8)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an sbyte16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tzcnt(sbyte16 x)
        {
            return (sbyte16)tzcnt((byte16)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an sbyte32 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tzcnt(sbyte32 x)
        {
            return (sbyte32)tzcnt((byte32)x);
        }


        /// <summary>       Returns number of trailing zeros in the binary representations of a ushort value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 16ul)]
        public static ushort tzcnt(ushort x)
        {
            // eliminates second test hardcoded by Unity; min(tzcnt, 16) adds another branch (for whatever reason)

            return (x == 0) ? (ushort)16 : (ushort)math.tzcnt((uint)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a ushort2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 tzcnt(ushort2 x)
        {
            return new ushort2(tzcnt(x.x), tzcnt(x.y));
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a ushort3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 tzcnt(ushort3 x)
        {
            return new ushort3(tzcnt(x.x), tzcnt(x.y), tzcnt(x.z));
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a ushort4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 tzcnt(ushort4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 compareMask = x & (ushort4)(-(short4)x);

                ushort4 first  = Mask.BlendV(default(v128), new ushort4(1), Sse2.cmpeq_epi16(x, default(v128)));
                ushort4 second = Mask.BlendV(new ushort4(8), default(v128), Sse2.cmpeq_epi16(compareMask & (ushort4)0x00FF, default(v128)));
                ushort4 third  = Mask.BlendV(new ushort4(4), default(v128), Sse2.cmpeq_epi16(compareMask & (ushort4)0x0F0F, default(v128)));
                ushort4 fourth = Mask.BlendV(new ushort4(2), default(v128), Sse2.cmpeq_epi16(compareMask & (ushort4)0x3333, default(v128)));
                ushort4 fifth  = Mask.BlendV(new ushort4(1), default(v128), Sse2.cmpeq_epi16(compareMask & (ushort4)0x5555, default(v128)));

                return (15 + first) - ((second - third) - (fourth - fifth));
            }
            else
            {
                return new ushort4(tzcnt(x.x), tzcnt(x.y), tzcnt(x.z), tzcnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a ushort8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 tzcnt(ushort8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 compareMask = x & (ushort8)(-(short8)x);

                ushort8 first  = Mask.BlendV(default(v128), new ushort8(1), Sse2.cmpeq_epi16(x, default(v128)));
                ushort8 second = Mask.BlendV(new ushort8(8), default(v128), Sse2.cmpeq_epi16(compareMask & (ushort8)0x00FF, default(v128)));
                ushort8 third  = Mask.BlendV(new ushort8(4), default(v128), Sse2.cmpeq_epi16(compareMask & (ushort8)0x0F0F, default(v128)));
                ushort8 fourth = Mask.BlendV(new ushort8(2), default(v128), Sse2.cmpeq_epi16(compareMask & (ushort8)0x3333, default(v128)));
                ushort8 fifth  = Mask.BlendV(new ushort8(1), default(v128), Sse2.cmpeq_epi16(compareMask & (ushort8)0x5555, default(v128)));

                return (15 + first) - ((second - third) - (fourth - fifth));
            }
            else
            {
                return new ushort8(tzcnt(x.x0), tzcnt(x.x1), tzcnt(x.x2), tzcnt(x.x3), tzcnt(x.x4), tzcnt(x.x5), tzcnt(x.x6), tzcnt(x.x7));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a ushort16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 tzcnt(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 compareMask = x & (ushort16)(-(short16)x);

                ushort16 first  = Avx2.mm256_blendv_epi8(default(v256), new ushort16(1), Avx2.mm256_cmpeq_epi16(x, default(v256)));
                ushort16 second = Avx2.mm256_blendv_epi8(new ushort16(8), default(v256), Avx2.mm256_cmpeq_epi16(compareMask & (ushort16)0x00FF, default(v256)));
                ushort16 third  = Avx2.mm256_blendv_epi8(new ushort16(4), default(v256), Avx2.mm256_cmpeq_epi16(compareMask & (ushort16)0x0F0F, default(v256)));
                ushort16 fourth = Avx2.mm256_blendv_epi8(new ushort16(2), default(v256), Avx2.mm256_cmpeq_epi16(compareMask & (ushort16)0x3333, default(v256)));
                ushort16 fifth  = Avx2.mm256_blendv_epi8(new ushort16(1), default(v256), Avx2.mm256_cmpeq_epi16(compareMask & (ushort16)0x5555, default(v256)));

                return (15 + first) - ((second - third) - (fourth - fifth));
            }
            else
            {
                return new ushort16(tzcnt(x.v8_0), tzcnt(x.v8_8));
            }
        }


        /// <summary>       Returns number of trailing zeros in the binary representations of a short value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 16)]
        public static short tzcnt(short x)
        {
            return (short)tzcnt((ushort)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a short2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 tzcnt(short2 x)
        {
            return (short2)tzcnt((ushort2)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a short3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 tzcnt(short3 x)
        {
            return (short3)tzcnt((ushort3)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a short4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 tzcnt(short4 x)
        {
            return (short4)tzcnt((ushort4)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a short8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 tzcnt(short8 x)
        {
            return (short8)tzcnt((ushort8)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a short16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 tzcnt(short16 x)
        {
            return (short16)tzcnt((ushort16)x);
        }


        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a uint8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 tzcnt(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 compareMask = x & Avx2.mm256_sign_epi16(x, new v256(-1));

                uint8 first  = Avx2.mm256_blendv_epi8(default(v256),  new uint8(1), Avx2.mm256_cmpeq_epi32(x, default(v256)));
                uint8 second = Avx2.mm256_blendv_epi8(new uint8(16), default(v256), Avx2.mm256_cmpeq_epi32(compareMask & (uint8)0x0000_FFFF, default(v256)));
                uint8 third  = Avx2.mm256_blendv_epi8(new uint8(8),  default(v256), Avx2.mm256_cmpeq_epi32(compareMask & (uint8)0x00FF_00FF, default(v256)));
                uint8 fourth = Avx2.mm256_blendv_epi8(new uint8(4),  default(v256), Avx2.mm256_cmpeq_epi32(compareMask & (uint8)0x0F0F_0F0F, default(v256)));
                uint8 fifth  = Avx2.mm256_blendv_epi8(new uint8(2),  default(v256), Avx2.mm256_cmpeq_epi32(compareMask & (uint8)0x3333_3333, default(v256)));
                uint8 sixth  = Avx2.mm256_blendv_epi8(new uint8(1),  default(v256), Avx2.mm256_cmpeq_epi32(compareMask & (uint8)0x5555_5555, default(v256)));

                return (31 + first) - ((second - third) - (fourth - fifth)) - sixth;
            }
            else
            {
                return new uint8((uint4)math.tzcnt(x.v4_0), (uint4)math.tzcnt(x.v4_4));
            }
        }


        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an int8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tzcnt(int8 x)
        {
            return (int8)tzcnt((uint8)x);
        }


        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a ulong2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 tzcnt(ulong2 x)
        {
            return new ulong2((ulong)math.tzcnt(x.x), (ulong)math.tzcnt(x.y));
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a ulong3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 tzcnt(ulong3 x)
        {
            return new ulong3((ulong)math.tzcnt(x.x), (ulong)math.tzcnt(x.y), (ulong)math.tzcnt(x.z));
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a ulong4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 tzcnt(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                ulong4 isZero = Avx2.mm256_cmpeq_epi64(x, default(v256));

                x &= Avx2.mm256_sub_epi64(default(v256), x);

                ulong4 y = x & 0x0000_0000_FFFF_FFFF;
                ulong4 cmp = Avx2.mm256_cmpeq_epi64(y, default(v256));

                ulong4 bits = Avx2.mm256_blendv_epi8(y, x >> 32, cmp);
                ulong4 offset = Avx2.mm256_blendv_epi8((ulong4)0x03FF, (ulong4)0x03DF, cmp);

                bits += 0x4330_0000_0000_0000ul;
                bits = Avx.mm256_sub_pd(bits, new v256(4_503_599_627_370_496d));
                bits = (bits >> 52) - offset;

                return Avx2.mm256_blendv_epi8(bits, new ulong4(64), isZero);
            }
            else
            {
                return new ulong4((ulong)math.tzcnt(x.x), (ulong)math.tzcnt(x.y), (ulong)math.tzcnt(x.z), (ulong)math.tzcnt(x.w));
            }
        }


        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a long2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tzcnt(long2 x)
        {
            return (long2)tzcnt((ulong2)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a long3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tzcnt(long3 x)
        {
            return (long3)tzcnt((ulong3)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a long4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tzcnt(long4 x)
        {
            return (long4)tzcnt((ulong4)x);
        }
    }
}