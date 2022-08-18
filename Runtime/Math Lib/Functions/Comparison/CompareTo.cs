using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static int compareto(UInt128 x, UInt128 y)
        {
            if (Xse.constexpr.IS_TRUE(x.hi64 == 0))
            {
                return tobyte((ulong)x > y) - tobyte((ulong)x < y);
            }
            else if (Xse.constexpr.IS_TRUE(y.hi64 == 0))
            {
                return tobyte(x > (ulong)y) - tobyte(x < (ulong)y);
            }
            else
            {
                return tobyte(x > y) - tobyte(x < y);
            }
        }

        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(Int128 x, Int128 y)
        {
            if (Xse.constexpr.IS_TRUE(x.hi64 == 0 || x.hi64 == ulong.MaxValue))
            {
                return tobyte((long)x > y) - tobyte((long)x < y);
            }
            else if (Xse.constexpr.IS_TRUE(y.hi64 == 0 || y.hi64 == ulong.MaxValue))
            {
                return tobyte(x > (long)y) - tobyte(x < (long)y);
            }
            else
            {
                return tobyte(x > y) - tobyte(x < y);
            }
        }


        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(sbyte x, sbyte y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }

        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static int compareto(byte x, byte y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }


        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(short x, short y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }

        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(ushort x, ushort y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }


        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static int compareto(int x, int y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }

        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static int compareto(uint x, uint y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }


        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static int compareto(long x, long y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }

        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static int compareto(ulong x, ulong y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }


        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static int compareto(float x, float y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }

        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static int compareto(double x, double y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }


        /// <summary>       Returns an <see cref="MaxMath.sbyte2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 compareto(sbyte2 x, sbyte2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(Sse2.cmpgt_epi8(y, x), Sse2.cmpgt_epi8(x, y));
            }
            else
            {
                return new sbyte2((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 compareto(sbyte3 x, sbyte3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(Sse2.cmpgt_epi8(y, x), Sse2.cmpgt_epi8(x, y));
            }
            else
            {
                return new sbyte3((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y),
                                  (sbyte)compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 compareto(sbyte4 x, sbyte4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(Sse2.cmpgt_epi8(y, x), Sse2.cmpgt_epi8(x, y));
            }
            else
            {
                return new sbyte4((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y),
                                  (sbyte)compareto(x.z, y.z),
                                  (sbyte)compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte8"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 compareto(sbyte8 x, sbyte8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(Sse2.cmpgt_epi8(y, x), Sse2.cmpgt_epi8(x, y));
            }
            else
            {
                return new sbyte8((sbyte)compareto(x.x0, y.x0),
                                  (sbyte)compareto(x.x1, y.x1),
                                  (sbyte)compareto(x.x2, y.x2),
                                  (sbyte)compareto(x.x3, y.x3),
                                  (sbyte)compareto(x.x4, y.x4),
                                  (sbyte)compareto(x.x5, y.x5),
                                  (sbyte)compareto(x.x6, y.x6),
                                  (sbyte)compareto(x.x7, y.x7));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte16"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 compareto(sbyte16 x, sbyte16 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(Sse2.cmpgt_epi8(y, x), Sse2.cmpgt_epi8(x, y));
            }
            else
            {
                return new sbyte16((sbyte)compareto(x.x0,  y.x0),
                                   (sbyte)compareto(x.x1,  y.x1),
                                   (sbyte)compareto(x.x2,  y.x2),
                                   (sbyte)compareto(x.x3,  y.x3),
                                   (sbyte)compareto(x.x4,  y.x4),
                                   (sbyte)compareto(x.x5,  y.x5),
                                   (sbyte)compareto(x.x6,  y.x6),
                                   (sbyte)compareto(x.x7,  y.x7),
                                   (sbyte)compareto(x.x8,  y.x8),
                                   (sbyte)compareto(x.x9,  y.x9),
                                   (sbyte)compareto(x.x10, y.x10),
                                   (sbyte)compareto(x.x11, y.x11),
                                   (sbyte)compareto(x.x12, y.x12),
                                   (sbyte)compareto(x.x13, y.x13),
                                   (sbyte)compareto(x.x14, y.x14),
                                   (sbyte)compareto(x.x15, y.x15));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte32"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 compareto(sbyte32 x, sbyte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi8(Avx2.mm256_cmpgt_epi8(y, x), Avx2.mm256_cmpgt_epi8(x, y));
            }
            else
            {
                return new sbyte32(compareto(x.v16_0,  y.v16_0),
                                   compareto(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Returns an <see cref="MaxMath.sbyte2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 compareto(byte2 x, byte2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(Xse.cmpge_epu8(y, x, 2), Xse.cmpge_epu8(x, y, 2));
            }
            else
            {
                return new sbyte2((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 compareto(byte3 x, byte3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(Xse.cmpge_epu8(y, x, 3), Xse.cmpge_epu8(x, y, 3));
            }
            else
            {
                return new sbyte3((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y),
                                  (sbyte)compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 compareto(byte4 x, byte4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(Xse.cmpge_epu8(y, x, 4), Xse.cmpge_epu8(x, y, 4));
            }
            else
            {
                return new sbyte4((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y),
                                  (sbyte)compareto(x.z, y.z),
                                  (sbyte)compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte8"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 compareto(byte8 x, byte8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(Xse.cmpge_epu8(y, x, 8), Xse.cmpge_epu8(x, y, 8));
            }
            else
            {
                return new sbyte8((sbyte)compareto(x.x0, y.x0),
                                  (sbyte)compareto(x.x1, y.x1),
                                  (sbyte)compareto(x.x2, y.x2),
                                  (sbyte)compareto(x.x3, y.x3),
                                  (sbyte)compareto(x.x4, y.x4),
                                  (sbyte)compareto(x.x5, y.x5),
                                  (sbyte)compareto(x.x6, y.x6),
                                  (sbyte)compareto(x.x7, y.x7));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte16"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 compareto(byte16 x, byte16 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(Xse.cmpge_epu8(y, x, 16), Xse.cmpge_epu8(x, y, 16));
            }
            else
            {
                return new sbyte16((sbyte)compareto(x.x0,  y.x0),
                                   (sbyte)compareto(x.x1,  y.x1),
                                   (sbyte)compareto(x.x2,  y.x2),
                                   (sbyte)compareto(x.x3,  y.x3),
                                   (sbyte)compareto(x.x4,  y.x4),
                                   (sbyte)compareto(x.x5,  y.x5),
                                   (sbyte)compareto(x.x6,  y.x6),
                                   (sbyte)compareto(x.x7,  y.x7),
                                   (sbyte)compareto(x.x8,  y.x8),
                                   (sbyte)compareto(x.x9,  y.x9),
                                   (sbyte)compareto(x.x10, y.x10),
                                   (sbyte)compareto(x.x11, y.x11),
                                   (sbyte)compareto(x.x12, y.x12),
                                   (sbyte)compareto(x.x13, y.x13),
                                   (sbyte)compareto(x.x14, y.x14),
                                   (sbyte)compareto(x.x15, y.x15));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte32"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 compareto(byte32 x, byte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi8(Xse.mm256_cmpge_epu8(y, x), Xse.mm256_cmpge_epu8(x, y));
            }
            else
            {
                return new sbyte32(compareto(x.v16_0,  y.v16_0),
                                   compareto(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Returns a <see cref="MaxMath.short2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 compareto(short2 x, short2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(Sse2.cmpgt_epi16(y, x), Sse2.cmpgt_epi16(x, y));
            }
            else
            {
                return new short2((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 compareto(short3 x, short3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(Sse2.cmpgt_epi16(y, x), Sse2.cmpgt_epi16(x, y));
            }
            else
            {
                return new short3((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y),
                                  (short)compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 compareto(short4 x, short4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(Sse2.cmpgt_epi16(y, x), Sse2.cmpgt_epi16(x, y));
            }
            else
            {
                return new short4((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y),
                                  (short)compareto(x.z, y.z),
                                  (short)compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short8"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 compareto(short8 x, short8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(Sse2.cmpgt_epi16(y, x), Sse2.cmpgt_epi16(x, y));
            }
            else
            {
                return new short8((short)compareto(x.x0, y.x0),
                                  (short)compareto(x.x1, y.x1),
                                  (short)compareto(x.x2, y.x2),
                                  (short)compareto(x.x3, y.x3),
                                  (short)compareto(x.x4, y.x4),
                                  (short)compareto(x.x5, y.x5),
                                  (short)compareto(x.x6, y.x6),
                                  (short)compareto(x.x7, y.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short16"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 compareto(short16 x, short16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi16(Avx2.mm256_cmpgt_epi16(y, x), Avx2.mm256_cmpgt_epi16(x, y));
            }
            else
            {
                return new short16(compareto(x.v8_0,  y.v8_0),
                                   compareto(x.v8_8,  y.v8_8));
            }
        }


        /// <summary>       Returns a <see cref="MaxMath.short2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 compareto(ushort2 x, ushort2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Sse4_1.IsSse41Supported && !(Xse.constexpr.ALL_LE_EPU16(x, (ushort)short.MaxValue, 2) && Xse.constexpr.ALL_LE_EPU16(y, (ushort)short.MaxValue, 2)))
                {
                    return Sse2.sub_epi16(Xse.cmpge_epu16(y, x, 2), Xse.cmpge_epu16(x, y, 2));
                }
                 

                return Sse2.sub_epi16(Xse.cmpgt_epu16(y, x, 2), Xse.cmpgt_epu16(x, y, 2));
            }
            else
            {
                return new short2((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 compareto(ushort3 x, ushort3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Sse4_1.IsSse41Supported && !(Xse.constexpr.ALL_LE_EPU16(x, (ushort)short.MaxValue, 3) && Xse.constexpr.ALL_LE_EPU16(y, (ushort)short.MaxValue, 3)))
                {
                    return Sse2.sub_epi16(Xse.cmpge_epu16(y, x, 3), Xse.cmpge_epu16(x, y, 3));
                }

                return Sse2.sub_epi16(Xse.cmpgt_epu16(y, x, 3), Xse.cmpgt_epu16(x, y, 3));
            }
            else
            {
                return new short3((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y),
                                  (short)compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 compareto(ushort4 x, ushort4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Sse4_1.IsSse41Supported && !(Xse.constexpr.ALL_LE_EPU16(x, (ushort)short.MaxValue, 4) && Xse.constexpr.ALL_LE_EPU16(y, (ushort)short.MaxValue, 4)))
                {
                    return Sse2.sub_epi16(Xse.cmpge_epu16(y, x, 4), Xse.cmpge_epu16(x, y, 4));
                }

                return Sse2.sub_epi16(Xse.cmpgt_epu16(y, x, 4), Xse.cmpgt_epu16(x, y, 4));
            }
            else
            {
                return new short4((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y),
                                  (short)compareto(x.z, y.z),
                                  (short)compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short8"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 compareto(ushort8 x, ushort8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Sse4_1.IsSse41Supported && !(Xse.constexpr.ALL_LE_EPU16(x, (ushort)short.MaxValue, 8) && Xse.constexpr.ALL_LE_EPU16(y, (ushort)short.MaxValue, 8)))
                {
                    return Sse2.sub_epi16(Xse.cmpge_epu16(y, x, 8), Xse.cmpge_epu16(x, y, 8));
                }

                return Sse2.sub_epi16(Xse.cmpgt_epu16(y, x, 8), Xse.cmpgt_epu16(x, y, 8));
            }
            else
            {
                return new short8((short)compareto(x.x0, y.x0),
                                  (short)compareto(x.x1, y.x1),
                                  (short)compareto(x.x2, y.x2),
                                  (short)compareto(x.x3, y.x3),
                                  (short)compareto(x.x4, y.x4),
                                  (short)compareto(x.x5, y.x5),
                                  (short)compareto(x.x6, y.x6),
                                  (short)compareto(x.x7, y.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short16"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 compareto(ushort16 x, ushort16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi16(Xse.mm256_cmpge_epu16(y, x), Xse.mm256_cmpge_epu16(x, y));
            }
            else
            {
                return new short16(compareto(x.v8_0, y.v8_0),
                                   compareto(x.v8_8, y.v8_8));
            }
        }


        /// <summary>       Returns an <see cref="int2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 compareto(int2 x, int2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);
                v128 _y = RegisterConversion.ToV128(y);
                
                return RegisterConversion.ToType<int2>(Sse2.sub_epi32(Sse2.cmpgt_epi32(_y, _x), Sse2.cmpgt_epi32(_x, _y)));
            }
            else
            {
                return new int2(compareto(x.x, y.x),
                                compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns an <see cref="int3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 compareto(int3 x, int3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);
                v128 _y = RegisterConversion.ToV128(y);
                
                return RegisterConversion.ToType<int3>(Sse2.sub_epi32(Sse2.cmpgt_epi32(_y, _x), Sse2.cmpgt_epi32(_x, _y)));
            }
            else
            {
                return new int3(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns an <see cref="int4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 compareto(int4 x, int4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);
                v128 _y = RegisterConversion.ToV128(y);
                
                return RegisterConversion.ToType<int4>(Sse2.sub_epi32(Sse2.cmpgt_epi32(_y, _x), Sse2.cmpgt_epi32(_x, _y)));
            }
            else
            {
                return new int4(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z),
                                compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.int8"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 compareto(int8 x, int8 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi32(Avx2.mm256_cmpgt_epi32(y, x), Avx2.mm256_cmpgt_epi32(x, y));
            }
            else
            {
                return new int8(compareto(x.v4_0, y.v4_0),
                                compareto(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Returns an <see cref="int2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 compareto(uint2 x, uint2 y)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);
                v128 _y = RegisterConversion.ToV128(y);
                
                return RegisterConversion.ToType<int2>(Sse2.sub_epi32(Sse2.cmpeq_epi32(Sse4_1.max_epu32(_y, _x), _y), Sse2.cmpeq_epi32(Sse4_1.max_epu32(_x, _y), _x)));;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);
                v128 _y = RegisterConversion.ToV128(y);
                
                return RegisterConversion.ToType<int2>(Sse2.sub_epi32(Xse.cmpgt_epu32(_y, _x, 2), Xse.cmpgt_epu32(_x, _y, 2)));
            }
            else
            {
                return new int2(compareto(x.x, y.x),
                                compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns an <see cref="int3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 compareto(uint3 x, uint3 y)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);
                v128 _y = RegisterConversion.ToV128(y);
                
                return RegisterConversion.ToType<int3>(Sse2.sub_epi32(Sse2.cmpeq_epi32(Sse4_1.max_epu32(_y, _x), _y), Sse2.cmpeq_epi32(Sse4_1.max_epu32(_x, _y), _x)));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);
                v128 _y = RegisterConversion.ToV128(y);
                
                return RegisterConversion.ToType<int3>(Sse2.sub_epi32(Xse.cmpgt_epu32(_y, _x, 3), Xse.cmpgt_epu32(_x, _y, 3)));
            }
            else
            {
                return new int3(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns an <see cref="int4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 compareto(uint4 x, uint4 y)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);
                v128 _y = RegisterConversion.ToV128(y);
                
                return RegisterConversion.ToType<int4>(Sse2.sub_epi32(Sse2.cmpeq_epi32(Sse4_1.max_epu32(_y, _x), _y), Sse2.cmpeq_epi32(Sse4_1.max_epu32(_x, _y), _x)));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);
                v128 _y = RegisterConversion.ToV128(y);
                
                return RegisterConversion.ToType<int4>(Sse2.sub_epi32(Xse.cmpgt_epu32(_y, _x, 4), Xse.cmpgt_epu32(_x, _y, 4)));
            }
            else
            {
                return new int4(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z),
                                compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.int8"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 compareto(uint8 x, uint8 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi32(Xse.mm256_cmpge_epu32(y, x), Xse.mm256_cmpge_epu32(x, y));
            }
            else
            {
                return new int8(compareto(x.v4_0, y.v4_0),
                                compareto(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Returns a <see cref="MaxMath.long2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 compareto(long2 x, long2 y)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse2.sub_epi64(Xse.cmpgt_epi64(y, x), Xse.cmpgt_epi64(x, y));
            }
            else
            {
                return new long2(compareto(x.x, y.x),
                                 compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.long3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 compareto(long3 x, long3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi64(Xse.mm256_cmpgt_epi64(y, x, 3), Xse.mm256_cmpgt_epi64(x, y, 3));
            }
            else
            {
                return new long3(compareto(x.xy, y.xy),
                                 compareto(x.z,  y.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.long4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 compareto(long4 x, long4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi64(Xse.mm256_cmpgt_epi64(y, x, 4), Xse.mm256_cmpgt_epi64(x, y, 4));
            }
            else
            {
                return new long4(compareto(x.xy, y.xy),
                                 compareto(x.zw, y.zw));
            }
        }


        /// <summary>       Returns a <see cref="MaxMath.long2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 compareto(ulong2 x, ulong2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi64(Xse.cmpgt_epu64(y, x), Xse.cmpgt_epu64(x, y));
            }
            else
            {
                return new long2(compareto(x.x, y.x),
                                 compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.long3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 compareto(ulong3 x, ulong3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi64(Xse.mm256_cmpgt_epu64(y, x), Xse.mm256_cmpgt_epu64(x, y));
            }
            else
            {
                return new long3(compareto(x.xy, y.xy),
                                 compareto(x.z,  y.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.long4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 compareto(ulong4 x, ulong4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi64(Xse.mm256_cmpgt_epu64(y, x), Xse.mm256_cmpgt_epu64(x, y));
            }
            else
            {
                return new long4(compareto(x.xy, y.xy),
                                 compareto(x.zw, y.zw));
            }
        }


        /// <summary>       Returns an <see cref="int2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 compareto(float2 x, float2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);
                v128 _y = RegisterConversion.ToV128(y);

                return RegisterConversion.ToType<int2>(Sse2.sub_epi32(Sse.cmpgt_ps(_y, _x), Sse.cmpgt_ps(_x, _y)));
            }
            else
            {
                return new int2(compareto(x.x, y.x),
                                compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns an <see cref="int3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 compareto(float3 x, float3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);
                v128 _y = RegisterConversion.ToV128(y);

                return RegisterConversion.ToType<int3>(Sse2.sub_epi32(Sse.cmpgt_ps(_y, _x), Sse.cmpgt_ps(_x, _y)));
            }
            else
            {
                return new int3(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns an <see cref="int4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 compareto(float4 x, float4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);
                v128 _y = RegisterConversion.ToV128(y);

                return RegisterConversion.ToType<int4>(Sse2.sub_epi32(Sse.cmpgt_ps(_y, _x), Sse.cmpgt_ps(_x, _y)));
            }
            else
            {
                return new int4(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z),
                                compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.int8"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 compareto(float8 x, float8 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi32(Avx.mm256_cmp_ps(y, x, (int)Avx.CMP.GT_OS), Avx.mm256_cmp_ps(x, y, (int)Avx.CMP.GT_OS));
            }
            else
            {
                return new int8(compareto(x.v4_0, y.v4_0),
                                compareto(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Returns a <see cref="MaxMath.long2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 compareto(double2 x, double2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = RegisterConversion.ToV128(x);
                v128 _y = RegisterConversion.ToV128(y);

                return Sse2.sub_epi64(Sse2.cmpgt_pd(_y, _x), Sse2.cmpgt_pd(_x, _y));
            }
            else
            {
                return new long2(compareto(x.x, y.x),
                                 compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.long3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 compareto(double3 x, double3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 _x = RegisterConversion.ToV256(x);
                v256 _y = RegisterConversion.ToV256(y);

                return Avx2.mm256_sub_epi64(Avx.mm256_cmp_pd(_y, _x, (int)Avx.CMP.GT_OS), Avx.mm256_cmp_pd(_x, _y, (int)Avx.CMP.GT_OS));
            }
            else
            {
                return new long3(compareto(x.xy, y.xy),
                                 compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.long4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 compareto(double4 x, double4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 _x = RegisterConversion.ToV256(x);
                v256 _y = RegisterConversion.ToV256(y);

                return Avx2.mm256_sub_epi64(Avx.mm256_cmp_pd(_y, _x, (int)Avx.CMP.GT_OS), Avx.mm256_cmp_pd(_x, _y, (int)Avx.CMP.GT_OS));
            }
            else
            {
                return new long4(compareto(x.xy, y.xy),
                                 compareto(x.zw, y.zw));
            }
        }
    }
}