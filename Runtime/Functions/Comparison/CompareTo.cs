using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns -1 if x is smaller than y, 1 if x is greater than y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(-1, 1)]
        public static int compareto(sbyte x, sbyte y)
        {
            return touint8(x > y) - touint8(x < y);
        }

        /// <summary>       Returns -1 if x is smaller than y, 1 if x is greater than y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(-1, 1)]
        public static int compareto(byte x, byte y)
        {
            return touint8(x > y) - touint8(x < y);
        }


        /// <summary>       Returns -1 if x is smaller than y, 1 if x is greater than y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(-1, 1)]
        public static int compareto(short x, short y)
        {
            return touint8(x > y) - touint8(x < y);
        }

        /// <summary>       Returns -1 if x is smaller than y, 1 if x is greater than y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(-1, 1)]
        public static int compareto(ushort x, ushort y)
        {
            return touint8(x > y) - touint8(x < y);
        }


        /// <summary>       Returns -1 if x is smaller than y, 1 if x is greater than y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-1, 1)]
        public static int compareto(int x, int y)
        {
            return touint8(x > y) - touint8(x < y);
        }

        /// <summary>       Returns -1 if x is smaller than y, 1 if x is greater than y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-1, 1)]
        public static int compareto(uint x, uint y)
        {
            return touint8(x > y) - touint8(x < y);
        }


        /// <summary>       Returns -1 if x is smaller than y, 1 if x is greater than y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-1, 1)]
        public static int compareto(long x, long y)
        {
            return touint8(x > y) - touint8(x < y);
        }

        /// <summary>       Returns -1 if x is smaller than y, 1 if x is greater than y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-1, 1)]
        public static int compareto(ulong x, ulong y)
        {
            return touint8(x > y) - touint8(x < y);
        }


        /// <summary>       Returns -1 if x is smaller than y, 1 if x is greater than y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-1, 1)]
        public static int compareto(float x, float y)
        {
            return touint8(x > y) - touint8(x < y);
        }

        /// <summary>       Returns -1 if x is smaller than y, 1 if x is greater than y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-1, 1)]
        public static int compareto(double x, double y)
        {
            return touint8(x > y) - touint8(x < y);
        }


        /// <summary>       Returns an sbyte2 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 compareto(sbyte2 x, sbyte2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte2 xGreatery = Sse2.cmpgt_epi8(x, y);
                sbyte2 yGreaterx = Sse2.cmpgt_epi8(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new sbyte2((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns an sbyte3 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 compareto(sbyte3 x, sbyte3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte3 xGreatery = Sse2.cmpgt_epi8(x, y);
                sbyte3 yGreaterx = Sse2.cmpgt_epi8(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new sbyte3((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y),
                                  (sbyte)compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns an sbyte4 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 compareto(sbyte4 x, sbyte4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte4 xGreatery = Sse2.cmpgt_epi8(x, y);
                sbyte4 yGreaterx = Sse2.cmpgt_epi8(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new sbyte4((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y),
                                  (sbyte)compareto(x.z, y.z),
                                  (sbyte)compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns an sbyte8 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 compareto(sbyte8 x, sbyte8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte8 xGreatery = Sse2.cmpgt_epi8(x, y);
                sbyte8 yGreaterx = Sse2.cmpgt_epi8(y, x);

                return (0 - xGreatery) + yGreaterx;
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

        /// <summary>       Returns an sbyte16 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 compareto(sbyte16 x, sbyte16 y)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte16 xGreatery = Sse2.cmpgt_epi8(x, y);
                sbyte16 yGreaterx = Sse2.cmpgt_epi8(y, x);

                return (0 - xGreatery) + yGreaterx;
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

        /// <summary>       Returns an sbyte32 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 compareto(sbyte32 x, sbyte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                sbyte32 xGreatery = Avx2.mm256_cmpgt_epi8(x, y);
                sbyte32 yGreaterx = Avx2.mm256_cmpgt_epi8(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new sbyte32(compareto(x.v16_0,  y.v16_0),
                                   compareto(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Returns an sbyte2 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 compareto(byte2 x, byte2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte2 xGreatery = Operator.greater_mask_byte(x, y);
                sbyte2 yGreaterx = Operator.greater_mask_byte(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new sbyte2((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns an sbyte3 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 compareto(byte3 x, byte3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte3 xGreatery = Operator.greater_mask_byte(x, y);
                sbyte3 yGreaterx = Operator.greater_mask_byte(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new sbyte3((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y),
                                  (sbyte)compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns an sbyte4 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 compareto(byte4 x, byte4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte4 xGreatery = Operator.greater_mask_byte(x, y);
                sbyte4 yGreaterx = Operator.greater_mask_byte(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new sbyte4((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y),
                                  (sbyte)compareto(x.z, y.z),
                                  (sbyte)compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns an sbyte8 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 compareto(byte8 x, byte8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte8 xGreatery = Operator.greater_mask_byte(x, y);
                sbyte8 yGreaterx = Operator.greater_mask_byte(y, x);

                return (0 - xGreatery) + yGreaterx;
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

        /// <summary>       Returns an sbyte16 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 compareto(byte16 x, byte16 y)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte16 xGreatery = Operator.greater_mask_byte(x, y);
                sbyte16 yGreaterx = Operator.greater_mask_byte(y, x);

                return (0 - xGreatery) + yGreaterx;
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

        /// <summary>       Returns an sbyte32 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 compareto(byte32 x, byte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                sbyte32 xGreatery = Operator.greater_mask_byte(x, y);
                sbyte32 yGreaterx = Operator.greater_mask_byte(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new sbyte32(compareto(x.v16_0,  y.v16_0),
                                   compareto(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Returns a short2 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 compareto(short2 x, short2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                short2 xGreatery = Sse2.cmpgt_epi16(x, y);
                short2 yGreaterx = Sse2.cmpgt_epi16(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new short2((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns a short3 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 compareto(short3 x, short3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                short3 xGreatery = Sse2.cmpgt_epi16(x, y);
                short3 yGreaterx = Sse2.cmpgt_epi16(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new short3((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y),
                                  (short)compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns a short4 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 compareto(short4 x, short4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                short4 xGreatery = Sse2.cmpgt_epi16(x, y);
                short4 yGreaterx = Sse2.cmpgt_epi16(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new short4((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y),
                                  (short)compareto(x.z, y.z),
                                  (short)compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns a short8 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 compareto(short8 x, short8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                short8 xGreatery = Sse2.cmpgt_epi16(x, y);
                short8 yGreaterx = Sse2.cmpgt_epi16(y, x);

                return (0 - xGreatery) + yGreaterx;
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

        /// <summary>       Returns a short16 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 compareto(short16 x, short16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                short16 xGreatery = Avx2.mm256_cmpgt_epi16(x, y);
                short16 yGreaterx = Avx2.mm256_cmpgt_epi16(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new short16(compareto(x.v8_0,  y.v8_0),
                                   compareto(x.v8_8,  y.v8_8));
            }
        }


        /// <summary>       Returns a short2 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 compareto(ushort2 x, ushort2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                short2 xGreatery = Operator.greater_mask_ushort(x, y);
                short2 yGreaterx = Operator.greater_mask_ushort(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new short2((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns a short3 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 compareto(ushort3 x, ushort3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                short3 xGreatery = Operator.greater_mask_ushort(x, y);
                short3 yGreaterx = Operator.greater_mask_ushort(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new short3((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y),
                                  (short)compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns a short4 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 compareto(ushort4 x, ushort4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                short4 xGreatery = Operator.greater_mask_ushort(x, y);
                short4 yGreaterx = Operator.greater_mask_ushort(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new short4((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y),
                                  (short)compareto(x.z, y.z),
                                  (short)compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns a short8 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 compareto(ushort8 x, ushort8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                short8 xGreatery = Operator.greater_mask_ushort(x, y);
                short8 yGreaterx = Operator.greater_mask_ushort(y, x);

                return (0 - xGreatery) + yGreaterx;
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

        /// <summary>       Returns a short16 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 compareto(ushort16 x, ushort16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                short16 xGreatery = Operator.greater_mask_ushort(x, y);
                short16 yGreaterx = Operator.greater_mask_ushort(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new short16(compareto(x.v8_0, y.v8_0),
                                   compareto(x.v8_8, y.v8_8));
            }
        }


        /// <summary>       Returns an int2 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 compareto(int2 x, int2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 xGreatery = Sse2.cmpgt_epi32(*(v128*)&x, *(v128*)&y);
                v128 yGreaterx = Sse2.cmpgt_epi32(*(v128*)&y, *(v128*)&x);

                return (0 - *(int2*)&xGreatery) + *(int2*)&yGreaterx;
            }
            else
            {
                return new int2(compareto(x.x, y.x),
                                compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns an int3 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 compareto(int3 x, int3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 xGreatery = Sse2.cmpgt_epi32(*(v128*)&x, *(v128*)&y);
                v128 yGreaterx = Sse2.cmpgt_epi32(*(v128*)&y, *(v128*)&x);

                return (0 - *(int3*)&xGreatery) + *(int3*)&yGreaterx;
            }
            else
            {
                return new int3(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns an int4 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 compareto(int4 x, int4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 xGreatery = Sse2.cmpgt_epi32(*(v128*)&x, *(v128*)&y);
                v128 yGreaterx = Sse2.cmpgt_epi32(*(v128*)&y, *(v128*)&x);

                return (0 - *(int4*)&xGreatery) + *(int4*)&yGreaterx;
            }
            else
            {
                return new int4(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z),
                                compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns an int8 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 compareto(int8 x, int8 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                int8 xGreatery = Avx2.mm256_cmpgt_epi32(x, y);
                int8 yGreaterx = Avx2.mm256_cmpgt_epi32(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new int8(compareto(x.v4_0, y.v4_0),
                                compareto(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Returns an int2 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 compareto(uint2 x, uint2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 xGreatery = Operator.greater_mask_uint(*(v128*)&x, *(v128*)&y);
                v128 yGreaterx = Operator.greater_mask_uint(*(v128*)&y, *(v128*)&x);

                return (0 - *(int2*)&xGreatery) + *(int2*)&yGreaterx;
            }
            else
            {
                return new int2(compareto(x.x, y.x),
                                compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns an int3 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 compareto(uint3 x, uint3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 xGreatery = Operator.greater_mask_uint(*(v128*)&x, *(v128*)&y);
                v128 yGreaterx = Operator.greater_mask_uint(*(v128*)&y, *(v128*)&x);

                return (0 - *(int3*)&xGreatery) + *(int3*)&yGreaterx;
            }
            else
            {
                return new int3(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns an int4 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 compareto(uint4 x, uint4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 xGreatery = Operator.greater_mask_uint(*(v128*)&x, *(v128*)&y);
                v128 yGreaterx = Operator.greater_mask_uint(*(v128*)&y, *(v128*)&x);

                return (0 - *(int4*)&xGreatery) + *(int4*)&yGreaterx;
            }
            else
            {
                return new int4(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z),
                                compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns an int8 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 compareto(uint8 x, uint8 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                int8 xGreatery = Operator.greater_mask_uint(x, y);
                int8 yGreaterx = Operator.greater_mask_uint(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new int8(compareto(x.v4_0, y.v4_0),
                                compareto(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Returns a long2 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 compareto(long2 x, long2 y)
        {
            if (Sse4_2.IsSse42Supported)
            {
                long2 xGreatery = Sse4_2.cmpgt_epi64(x, y);
                long2 yGreaterx = Sse4_2.cmpgt_epi64(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new long2(compareto(x.x, y.x),
                                 compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns a long3 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 compareto(long3 x, long3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                long3 xGreatery = Avx2.mm256_cmpgt_epi64(x, y);
                long3 yGreaterx = Avx2.mm256_cmpgt_epi64(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new long3(compareto(x.xy, y.xy),
                                 compareto(x.z,  y.z));
            }
        }

        /// <summary>       Returns a long4 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 compareto(long4 x, long4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                long4 xGreatery = Avx2.mm256_cmpgt_epi64(x, y);
                long4 yGreaterx = Avx2.mm256_cmpgt_epi64(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new long4(compareto(x.xy, y.xy),
                                 compareto(x.zw, y.zw));
            }
        }


        /// <summary>       Returns a long2 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 compareto(ulong2 x, ulong2 y)
        {
            if (Sse4_2.IsSse42Supported)
            {
                long2 xGreatery = Operator.greater_mask_ulong(x, y);
                long2 yGreaterx = Operator.greater_mask_ulong(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new long2(compareto(x.x, y.x),
                                 compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns a long3 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 compareto(ulong3 x, ulong3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                long3 xGreatery = Operator.greater_mask_ulong(x, y);
                long3 yGreaterx = Operator.greater_mask_ulong(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new long3(compareto(x.xy, y.xy),
                                 compareto(x.z,  y.z));
            }
        }

        /// <summary>       Returns a long4 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 compareto(ulong4 x, ulong4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                long4 xGreatery = Operator.greater_mask_ulong(x, y);
                long4 yGreaterx = Operator.greater_mask_ulong(y, x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new long4(compareto(x.xy, y.xy),
                                 compareto(x.zw, y.zw));
            }
        }


        /// <summary>       Returns an int2 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 compareto(float2 x, float2 y)
        {
            if (Sse.IsSseSupported)
            {
                v128 xGreatery = Sse.cmpgt_ps(*(v128*)&x, *(v128*)&y);
                v128 yGreaterx = Sse.cmpgt_ps(*(v128*)&y, *(v128*)&x);

                return (0 - *(int2*)&xGreatery) + *(int2*)&yGreaterx;
            }
            else
            {
                return new int2(compareto(x.x, y.x),
                                compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns an int3 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 compareto(float3 x, float3 y)
        {
            if (Sse.IsSseSupported)
            {
                v128 xGreatery = Sse.cmpgt_ps(*(v128*)&x, *(v128*)&y);
                v128 yGreaterx = Sse.cmpgt_ps(*(v128*)&y, *(v128*)&x);

                return (0 - *(int3*)&xGreatery) + *(int3*)&yGreaterx;
            }
            else
            {
                return new int3(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns an int4 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 compareto(float4 x, float4 y)
        {
            if (Sse.IsSseSupported)
            {
                v128 xGreatery = Sse.cmpgt_ps(*(v128*)&x, *(v128*)&y);
                v128 yGreaterx = Sse.cmpgt_ps(*(v128*)&y, *(v128*)&x);

                return (0 - *(int4*)&xGreatery) + *(int4*)&yGreaterx;
            }
            else
            {
                return new int4(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z),
                                compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns an int8 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 compareto(float8 x, float8 y)
        {
            if (Avx.IsAvxSupported)
            {
                int8 xGreatery = Avx.mm256_cmp_ps(x, y, (int)Avx.CMP.GT_OS);
                int8 yGreaterx = Avx.mm256_cmp_ps(y, x, (int)Avx.CMP.GT_OS);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new int8(compareto(x.v4_0, y.v4_0),
                                compareto(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Returns a long2 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 compareto(double2 x, double2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                long2 xGreatery = Sse2.cmpgt_pd(*(v128*)&x, *(v128*)&y);
                long2 yGreaterx = Sse2.cmpgt_pd(*(v128*)&y, *(v128*)&x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new long2(compareto(x.x, y.x),
                                 compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns a long3 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 compareto(double3 x, double3 y)
        {
            if (Avx.IsAvxSupported)
            {
                long3 xGreatery = Avx.mm256_cmp_pd(*(v256*)&x, *(v256*)&y, (int)Avx.CMP.GT_OS);
                long3 yGreaterx = Avx.mm256_cmp_pd(*(v256*)&y, *(v256*)&x, (int)Avx.CMP.GT_OS);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new long3(compareto(x.xy, y.xy),
                                 compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns a long4 vector with each element set to -1 if the corresponding value in x is smaller than the corresponding value in y, 1 if the corresponding value in x is greater than the corresponding value in y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 compareto(double4 x, double4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                long4 xGreatery = Avx2.mm256_cmpgt_epi64(*(v256*)&x, *(v256*)&y);
                long4 yGreaterx = Avx2.mm256_cmpgt_epi64(*(v256*)&y, *(v256*)&x);

                return (0 - xGreatery) + yGreaterx;
            }
            else
            {
                return new long4(compareto(x.xy, y.xy),
                                 compareto(x.zw, y.zw));
            }
        }
    }
}