using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="UInt128"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0ul, 6_981_463_658_331ul)]
        public static ulong intcbrt(UInt128 x)
        {
            ulong y = 0;
            UInt128 b = 1;

            UInt128 t = x >> 126;
            if ((t.lo | t.hi) != 0) 
            {
                x -= b << 126;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 123) >= b.lo) 
            {
                x -= b << 123;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 120) >= b.lo) 
            {
                x -= b << 120;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 117) >= b.lo) 
            {
                x -= b << 117;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 114) >= b.lo) 
            {
                x -= b << 114;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 111) >= b.lo) 
            {
                x -= b << 111;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 108) >= b.lo) 
            {
                x -= b << 108;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 105) >= b.lo) 
            {
                x -= b << 105;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 102) >= b.lo) 
            {
                x -= b << 102;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 99) >= b.lo) 
            {
                x -= b << 99;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 96) >= b.lo) 
            {
                x -= b << 96;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 93) >= b.lo) 
            {
                x -= b << 93;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 90) >= b.lo) 
            {
                x -= b << 90;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 87) >= b.lo) 
            {
                x -= b << 87;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 84) >= b.lo) 
            {
                x -= b << 84;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 81) >= b.lo) 
            {
                x -= b << 81;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 78) >= b.lo) 
            {
                x -= b << 78;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 75) >= b.lo) 
            {
                x -= b << 75;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 72) >= b.lo) 
            {
                x -= b << 72;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 69) >= b.lo) 
            {
                x -= b << 69;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 66) >= b.lo) 
            {
                x -= b << 66;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 63) >= b.lo) 
            {
                x -= b << 63;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 60) >= b.lo) 
            {
                x -= b << 60;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 57) >= b.lo) 
            {
                x -= b << 57;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 54) >= b.lo) 
            {
                x -= b << 54;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 51) >= b.lo) 
            {
                x -= b << 51;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 48) >= b.lo) 
            {
                x -= b << 48;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 45) >= b.lo) 
            {
                x -= b << 45;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 42) >= b.lo) 
            {
                x -= b << 42;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 39) >= b.lo) 
            {
                x -= b << 39;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;    // ((1704458887ul * 3) * (1704458887ul + 1)) + 1 at max; last safe ulong
            
            if ((x >> 36) >= b.lo) 
            {
                x -= b << 36;
                y++;
            }
            
            y += y;
            ulong lo = Common.umul128(3 * y, y + 1, out ulong hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 33) >= b) 
            {
                x -= b << 33;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 30) >= b) 
            {
                x -= b << 30;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 27) >= b) 
            {
                x -= b << 27;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 24) >= b) 
            {
                x -= b << 24;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 21) >= b) 
            {
                x -= b << 21;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 18) >= b) 
            {
                x -= b << 18;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 15) >= b) 
            {
                x -= b << 15;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 12) >= b) 
            {
                x -= b << 12;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 9) >= b) 
            {
                x -= b << 9;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 6) >= b) 
            {
                x -= b << 6;
                y++;
            }

            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 3) >= b) 
            {
                x -= b << 3;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);

            y += tobyte(x >= b);

            return y;
        }


        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of an <see cref="Int128"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(-5_541_191_377_756L, 6_981_463_658_331L)]
        public static long intcbrt(Int128 x, bool handleNegativeInput = false)
        {
            if (handleNegativeInput)
            {
                bool negative = (long)x.intern.hi < 0;
                ulong _cbrt = intcbrt((UInt128)abs(x));

                return math.select((long)_cbrt, -(long)_cbrt, negative);
            }
            else
            {
                return (long)intcbrt((UInt128)x);
            }
        }


        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="byte"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0ul, 6ul)]
        public static byte intcbrt(byte x)
        {
            uint _x = x;
            uint y = 0;
            uint b = 1;
            
            if ((_x >> 6) != 0) 
            {
                _x -= b << 6;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((_x >> 3) >= b) 
            {
                _x -= b << 3;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            y += tobyte(_x >= b);

            return (byte)y;
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte2"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 intcbrt(byte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = Cast.ByteToShort(x);
                v128 ONE = Sse2.set1_epi16(1);

                v128 y = Sse2.setzero_si128();
                v128 b = ONE;

                v128 shrl = Sse2.srli_epi16(_x, 6);
                v128 greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                v128 subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 6));
                v128 addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                _x = Sse2.sub_epi16(_x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(_x, 3);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 3));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                _x = Sse2.sub_epi16(_x, subFromX);
                y = Sse2.add_epi16(y, addToY);
                
                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                greaterEqualMask = Sse2.cmpgt_epi16(b, _x);
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                y = Sse2.add_epi16(y, addToY);

                return Sse2.packus_epi16(y, y);
            }
            else
            {
                return new byte2(intcbrt(x.x), intcbrt(x.y));
            }
        } 

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte3"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 intcbrt(byte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = Cast.ByteToShort(x);
                v128 ONE = Sse2.set1_epi16(1);

                v128 y = Sse2.setzero_si128();
                v128 b = ONE;

                v128 shrl = Sse2.srli_epi16(_x, 6);
                v128 greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                v128 subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 6));
                v128 addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                _x = Sse2.sub_epi16(_x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(_x, 3);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 3));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                _x = Sse2.sub_epi16(_x, subFromX);
                y = Sse2.add_epi16(y, addToY);
                
                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                greaterEqualMask = Sse2.cmpgt_epi16(b, _x);
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                y = Sse2.add_epi16(y, addToY);
                
                return Sse2.packus_epi16(y, y);
            }
            else
            {
                return new byte3(intcbrt(x.x), intcbrt(x.y), intcbrt(x.z));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte4"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 intcbrt(byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = Cast.ByteToShort(x);
                v128 ONE = Sse2.set1_epi16(1);

                v128 y = Sse2.setzero_si128();
                v128 b = ONE;

                v128 shrl = Sse2.srli_epi16(_x, 6);
                v128 greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                v128 subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 6));
                v128 addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                _x = Sse2.sub_epi16(_x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(_x, 3);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 3));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                _x = Sse2.sub_epi16(_x, subFromX);
                y = Sse2.add_epi16(y, addToY);
                
                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                greaterEqualMask = Sse2.cmpgt_epi16(b, _x);
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                y = Sse2.add_epi16(y, addToY);
                
                return Sse2.packus_epi16(y, y);
            }
            else
            {
                return new byte4(intcbrt(x.x), intcbrt(x.y), intcbrt(x.z), intcbrt(x.w));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte8"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 intcbrt(byte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = Cast.ByteToShort(x);
                v128 ONE = Sse2.set1_epi16(1);

                v128 y = Sse2.setzero_si128();
                v128 b = ONE;

                v128 shrl = Sse2.srli_epi16(_x, 6);
                v128 greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                v128 subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 6));
                v128 addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                _x = Sse2.sub_epi16(_x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(_x, 3);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 3));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                _x = Sse2.sub_epi16(_x, subFromX);
                y = Sse2.add_epi16(y, addToY);
                
                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                greaterEqualMask = Sse2.cmpgt_epi16(b, _x);
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                y = Sse2.add_epi16(y, addToY);
                
                return Sse2.packus_epi16(y, y);
            }
            else
            {
                return new byte8(intcbrt(x.x0), 
                                 intcbrt(x.x1), 
                                 intcbrt(x.x2), 
                                 intcbrt(x.x3), 
                                 intcbrt(x.x4), 
                                 intcbrt(x.x5), 
                                 intcbrt(x.x6), 
                                 intcbrt(x.x7));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte16"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 intcbrt(byte16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 _x = Avx2.mm256_cvtepu8_epi16(x);
                v256 ONE = Avx.mm256_set1_epi16(1);

                v256 y = Avx.mm256_setzero_si256();
                v256 b = ONE;

                v256 shrl = Avx2.mm256_srli_epi16(_x, 6);
                v256 greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, shrl);
                v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi16(b, 6));
                v256 addToY   = Avx2.mm256_add_epi16(ONE, greaterEqualMask);
                _x = Avx2.mm256_sub_epi16(_x, subFromX);
                y = Avx2.mm256_add_epi16(y, addToY);

                y = Avx2.mm256_add_epi16(y, y);
                b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, Avx2.mm256_slli_epi16(y, 1)),
                                                                     Avx2.mm256_add_epi16(y, ONE)));
                shrl = Avx2.mm256_srli_epi16(_x, 3);
                greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi16(b, 3));
                addToY   = Avx2.mm256_add_epi16(ONE, greaterEqualMask);
                _x = Avx2.mm256_sub_epi16(_x, subFromX);
                y = Avx2.mm256_add_epi16(y, addToY);
                
                y = Avx2.mm256_add_epi16(y, y);
                b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, Avx2.mm256_slli_epi16(y, 1)),
                                                                     Avx2.mm256_add_epi16(y, ONE)));
                greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, _x);
                addToY   = Avx2.mm256_add_epi16(ONE, greaterEqualMask);
                y = Avx2.mm256_add_epi16(y, addToY);

                return Sse2.packus_epi16(Avx.mm256_castsi256_si128(y), Avx2.mm256_extracti128_si256(y, 1));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ONE = Sse2.set1_epi8(1);

                v128 y = Sse2.setzero_si128();
                v128 b = ONE;
                
                v128 shrl = Operator.shrl_byte(x, 6);
                v128 greaterEqualMask = Sse2.cmpgt_epi8(b, shrl);
                v128 subFromX = Sse2.andnot_si128(greaterEqualMask, Operator.shl_byte(b, 6));
                v128 addToY   = Sse2.add_epi8(ONE, greaterEqualMask);
                x = Sse2.sub_epi8(x, subFromX);
                y = Sse2.add_epi8(y, addToY);

                y = Sse2.add_epi8(y, y);
                b = Sse2.add_epi8(ONE, Operator.mul_byte(Sse2.add_epi8(y, Sse2.add_epi8(y, y)),
                                                         Sse2.add_epi8(y, ONE)));
                shrl = Operator.shrl_byte(x, 3);
                greaterEqualMask = Sse2.cmpgt_epi8(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Operator.shl_byte(b, 3));
                addToY   = Sse2.add_epi8(ONE, greaterEqualMask);
                x = Sse2.sub_epi8(x, subFromX);
                y = Sse2.add_epi8(y, addToY);
                
                y = Sse2.add_epi8(y, y);
                b = Sse2.add_epi8(ONE, Operator.mul_byte(Sse2.add_epi8(y, Sse2.add_epi8(y, y)),
                                                         Sse2.add_epi8(y, ONE)));

                greaterEqualMask = Sse2.cmpeq_epi8(Sse2.max_epu8(b, x), x);
                y = Sse2.sub_epi8(y, greaterEqualMask);

                return y;
            }
            else
            {
                return new byte16(intcbrt(x.x0), 
                                  intcbrt(x.x1), 
                                  intcbrt(x.x2), 
                                  intcbrt(x.x3), 
                                  intcbrt(x.x4), 
                                  intcbrt(x.x5), 
                                  intcbrt(x.x6), 
                                  intcbrt(x.x7), 
                                  intcbrt(x.x8), 
                                  intcbrt(x.x9), 
                                  intcbrt(x.x10), 
                                  intcbrt(x.x11), 
                                  intcbrt(x.x12), 
                                  intcbrt(x.x13), 
                                  intcbrt(x.x14), 
                                  intcbrt(x.x15));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte32"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 intcbrt(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ONE = Avx.mm256_set1_epi8(1);

                v256 y = Avx.mm256_setzero_si256();
                v256 b = ONE;

                v256 shrl = Operator.shrl_byte(x, 6);
                v256 greaterEqualMask = Avx2.mm256_cmpgt_epi8(b, shrl);
                v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Operator.shl_byte(b, 6));
                v256 addToY   = Avx2.mm256_add_epi8(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi8(x, subFromX);
                y = Avx2.mm256_add_epi8(y, addToY);

                y = Avx2.mm256_add_epi8(y, y);
                b = Avx2.mm256_add_epi8(ONE, Operator.mul_byte(Avx2.mm256_add_epi8(y, Avx2.mm256_add_epi8(y, y)),
                                                               Avx2.mm256_add_epi8(y, ONE)));
                shrl = Operator.shrl_byte(x, 3);
                greaterEqualMask = Avx2.mm256_cmpgt_epi8(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Operator.shl_byte(b, 3));
                addToY   = Avx2.mm256_add_epi8(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi8(x, subFromX);
                y = Avx2.mm256_add_epi8(y, addToY);
                
                y = Avx2.mm256_add_epi8(y, y);
                b = Avx2.mm256_add_epi8(ONE, Operator.mul_byte(Avx2.mm256_add_epi8(y, Avx2.mm256_add_epi8(y, y)),
                                                               Avx2.mm256_add_epi8(y, ONE)));

                greaterEqualMask = Avx2.mm256_cmpeq_epi8(Avx2.mm256_max_epu8(b, x), x);
                y = Avx2.mm256_sub_epi8(y, greaterEqualMask);

                return y;
            }
            else
            {
                return new byte32(intcbrt(x.v16_0), intcbrt(x.v16_16));
            }
        }

        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of an <see cref="sbyte"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(-5, 6)]
        public static sbyte intcbrt(sbyte x, bool handleNegativeInput = false)
        {
            if (handleNegativeInput)
            {
                bool negative = x < 0;
                byte _cbrt = intcbrt((byte)math.select(x, -x, negative));

                return select((sbyte)_cbrt, (sbyte)-(sbyte)_cbrt, negative);
            }
            else
            {
                return (sbyte)intcbrt((byte)x);
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of an <see cref="MaxMath.sbyte2"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 intcbrt(sbyte2 x, bool handleNegativeInput = false)
        {
            if (Sse2.IsSse2Supported)
            {
                if (handleNegativeInput)
                {
                    v128 ZERO = Sse2.setzero_si128();

                    v128 negative = Sse2.cmpgt_epi8(ZERO, x);
                    v128 _cbrt;
                    if (Ssse3.IsSsse3Supported)
                    {
                        _cbrt = intcbrt((byte2)Ssse3.abs_epi8(x));
                        
                    }
                    else
                    {
                        _cbrt = intcbrt((byte2)Sse2.xor_si128(Sse2.add_epi8(x, negative), negative));
                    }
                    
                    return Sse2.xor_si128(Sse2.add_epi8(_cbrt, negative), negative);
                }
                else 
                {
                    return (sbyte2)intcbrt((byte2)x);
                }
            }
            else
            {
                return new sbyte2(intcbrt(x.x, handleNegativeInput), intcbrt(x.y, handleNegativeInput));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of an <see cref="MaxMath.sbyte3"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 intcbrt(sbyte3 x, bool handleNegativeInput = false)
        {
            if (Sse2.IsSse2Supported)
            {
                if (handleNegativeInput)
                {
                    v128 ZERO = Sse2.setzero_si128();

                    v128 negative = Sse2.cmpgt_epi8(ZERO, x);
                    v128 _cbrt;
                    if (Ssse3.IsSsse3Supported)
                    {
                        _cbrt = intcbrt((byte3)Ssse3.abs_epi8(x));
                        
                    }
                    else
                    {
                        _cbrt = intcbrt((byte3)Sse2.xor_si128(Sse2.add_epi8(x, negative), negative));
                    }
                    
                    return Sse2.xor_si128(Sse2.add_epi8(_cbrt, negative), negative);
                }
                else 
                {
                    return (sbyte3)intcbrt((byte3)x);
                }
            }
            else
            {
                return new sbyte3(intcbrt(x.x, handleNegativeInput), intcbrt(x.y, handleNegativeInput),  intcbrt(x.z, handleNegativeInput));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of an <see cref="MaxMath.sbyte4"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 intcbrt(sbyte4 x, bool handleNegativeInput = false)
        {
            if (Sse2.IsSse2Supported)
            {
                if (handleNegativeInput)
                {
                    v128 ZERO = Sse2.setzero_si128();

                    v128 negative = Sse2.cmpgt_epi8(ZERO, x);
                    v128 _cbrt;
                    if (Ssse3.IsSsse3Supported)
                    {
                        _cbrt = intcbrt((byte4)Ssse3.abs_epi8(x));
                        
                    }
                    else
                    {
                        _cbrt = intcbrt((byte4)Sse2.xor_si128(Sse2.add_epi8(x, negative), negative));
                    }
                    
                    return Sse2.xor_si128(Sse2.add_epi8(_cbrt, negative), negative);
                }
                else 
                {
                    return (sbyte4)intcbrt((byte4)x);
                }
            }
            else
            {
                return new sbyte4(intcbrt(x.x, handleNegativeInput), intcbrt(x.y, handleNegativeInput),  intcbrt(x.z, handleNegativeInput),  intcbrt(x.w, handleNegativeInput));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of an <see cref="MaxMath.sbyte8"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 intcbrt(sbyte8 x, bool handleNegativeInput = false)
        {
            if (Sse2.IsSse2Supported)
            {
                if (handleNegativeInput)
                {
                    v128 ZERO = Sse2.setzero_si128();

                    v128 negative = Sse2.cmpgt_epi8(ZERO, x);
                    v128 _cbrt;
                    if (Ssse3.IsSsse3Supported)
                    {
                        _cbrt = intcbrt((byte8)Ssse3.abs_epi8(x));
                        
                    }
                    else
                    {
                        _cbrt = intcbrt((byte8)Sse2.xor_si128(Sse2.add_epi8(x, negative), negative));
                    }
                    
                    return Sse2.xor_si128(Sse2.add_epi8(_cbrt, negative), negative);
                }
                else 
                {
                    return (sbyte8)intcbrt((byte8)x);
                }
            }
            else
            {
                return new sbyte8(intcbrt(x.x0, handleNegativeInput), 
                                  intcbrt(x.x1, handleNegativeInput),  
                                  intcbrt(x.x2, handleNegativeInput),  
                                  intcbrt(x.x3, handleNegativeInput),  
                                  intcbrt(x.x4, handleNegativeInput),  
                                  intcbrt(x.x5, handleNegativeInput),  
                                  intcbrt(x.x6, handleNegativeInput),  
                                  intcbrt(x.x7, handleNegativeInput));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of an <see cref="MaxMath.sbyte16"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 intcbrt(sbyte16 x, bool handleNegativeInput = false)
        {
            if (Sse2.IsSse2Supported)
            {
                if (handleNegativeInput)
                {
                    v128 ZERO = Sse2.setzero_si128();

                    v128 negative = Sse2.cmpgt_epi8(ZERO, x);
                    v128 _cbrt;
                    if (Ssse3.IsSsse3Supported)
                    {
                        _cbrt = intcbrt((byte16)Ssse3.abs_epi8(x));
                        
                    }
                    else
                    {
                        _cbrt = intcbrt((byte16)Sse2.xor_si128(Sse2.add_epi8(x, negative), negative));
                    }
                    
                    return Sse2.xor_si128(Sse2.add_epi8(_cbrt, negative), negative);
                }
                else 
                {
                    return (sbyte16)intcbrt((byte16)x);
                }
            }
            else
            {
                return new sbyte16(intcbrt(x.x0,  handleNegativeInput), 
                                   intcbrt(x.x1,  handleNegativeInput),  
                                   intcbrt(x.x2,  handleNegativeInput),  
                                   intcbrt(x.x3,  handleNegativeInput),  
                                   intcbrt(x.x4,  handleNegativeInput),  
                                   intcbrt(x.x5,  handleNegativeInput),  
                                   intcbrt(x.x6,  handleNegativeInput),  
                                   intcbrt(x.x7,  handleNegativeInput),  
                                   intcbrt(x.x8,  handleNegativeInput),  
                                   intcbrt(x.x9,  handleNegativeInput),  
                                   intcbrt(x.x10, handleNegativeInput),  
                                   intcbrt(x.x11, handleNegativeInput),  
                                   intcbrt(x.x12, handleNegativeInput),  
                                   intcbrt(x.x13, handleNegativeInput),  
                                   intcbrt(x.x14, handleNegativeInput),  
                                   intcbrt(x.x15, handleNegativeInput));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of an <see cref="MaxMath.sbyte32"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 intcbrt(sbyte32 x, bool handleNegativeInput = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (handleNegativeInput)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 negative = Avx2.mm256_cmpgt_epi8(ZERO, x);
                    v256 _cbrt = intcbrt((byte32)Avx2.mm256_abs_epi8(x));
                    
                    return Avx2.mm256_xor_si256(Avx2.mm256_add_epi8(_cbrt, negative), negative);
                }
                else 
                {
                    return (sbyte32)intcbrt((byte32)x);
                }
            }
            else
            {
                return new sbyte32(intcbrt(x.v16_0, handleNegativeInput), intcbrt(x.v16_16, handleNegativeInput));
            }
        }


        /// <summary>       Computes the integer cube root ⌊∛<paramref name="_x"/>⌋ of a <see cref="ushort"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0ul, 40ul)]
        public static ushort intcbrt(ushort x)
        {
            uint _x = x;
            uint y = 0;
            uint b = 1;
            
            if ((_x >> 15) != 0) 
            {
                _x -= b << 15;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((_x >> 12) >= b) 
            {
                _x -= b << 12;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((_x >> 9) >= b) 
            {
                _x -= b << 9;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((_x >> 6) >= b) 
            {
                _x -= b << 6;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((_x >> 3) >= b) 
            {
                _x -= b << 3;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            y += tobyte(_x >= b);

            return (ushort)y;
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort2"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 intcbrt(ushort2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ONE = Sse2.set1_epi16(1);

                v128 y = Sse2.setzero_si128();
                v128 b = ONE;
                
                v128 shrl = Sse2.srli_epi16(x, 15);
                v128 greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                v128 subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 15));
                v128 addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(x, 12);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 12));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(x, 9);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 9));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(x, 6);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 6));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(x, 3);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 3));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                
                greaterEqualMask = Sse2.cmpgt_epi16(b, x);
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                y = Sse2.add_epi16(y, addToY);

                return y;
            }
            else
            {
                return new ushort2(intcbrt(x.x), intcbrt(x.y));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort3"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 intcbrt(ushort3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ONE = Sse2.set1_epi16(1);

                v128 y = Sse2.setzero_si128();
                v128 b = ONE;
                
                v128 shrl = Sse2.srli_epi16(x, 15);
                v128 greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                v128 subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 15));
                v128 addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(x, 12);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 12));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(x, 9);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 9));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(x, 6);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 6));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(x, 3);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 3));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                
                greaterEqualMask = Sse2.cmpgt_epi16(b, x);
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                y = Sse2.add_epi16(y, addToY);

                return y;
            }
            else
            {
                return new ushort3(intcbrt(x.x), intcbrt(x.y), intcbrt(x.z));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort4"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 intcbrt(ushort4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ONE = Sse2.set1_epi16(1);

                v128 y = Sse2.setzero_si128();
                v128 b = ONE;
                
                v128 shrl = Sse2.srli_epi16(x, 15);
                v128 greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                v128 subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 15));
                v128 addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(x, 12);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 12));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(x, 9);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 9));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(x, 6);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 6));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(x, 3);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 3));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                
                greaterEqualMask = Sse2.cmpgt_epi16(b, x);
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                y = Sse2.add_epi16(y, addToY);

                return y;
            }
            else
            {
                return new ushort4(intcbrt(x.x), intcbrt(x.y), intcbrt(x.z), intcbrt(x.w));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort8"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 intcbrt(ushort8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ONE = Sse2.set1_epi16(1);

                v128 y = Sse2.setzero_si128();
                v128 b = ONE;
                
                v128 shrl = Sse2.srli_epi16(x, 15);
                v128 greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                v128 subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 15));
                v128 addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(x, 12);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 12));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(x, 9);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 9));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(x, 6);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 6));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                shrl = Sse2.srli_epi16(x, 3);
                greaterEqualMask = Sse2.cmpgt_epi16(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 3));
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                x = Sse2.sub_epi16(x, subFromX);
                y = Sse2.add_epi16(y, addToY);

                y = Sse2.add_epi16(y, y);
                b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, Sse2.slli_epi16(y, 1)),
                                                         Sse2.add_epi16(y, ONE)));
                
                greaterEqualMask = Sse2.cmpgt_epi16(b, x);
                addToY   = Sse2.add_epi16(ONE, greaterEqualMask);
                y = Sse2.add_epi16(y, addToY);

                return y;
            }
            else
            {
                return new ushort8(intcbrt(x.x0), 
                                   intcbrt(x.x1), 
                                   intcbrt(x.x2), 
                                   intcbrt(x.x3), 
                                   intcbrt(x.x4), 
                                   intcbrt(x.x5), 
                                   intcbrt(x.x6), 
                                   intcbrt(x.x7));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort16"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 intcbrt(ushort16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v256 ONE = Avx.mm256_set1_epi16(1);

                v256 y = Avx.mm256_setzero_si256();
                v256 b = ONE;
                
                v256 shrl = Avx2.mm256_srli_epi16(x, 15);
                v256 greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, shrl);
                v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi16(b, 15));
                v256 addToY   = Avx2.mm256_add_epi16(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi16(x, subFromX);
                y = Avx2.mm256_add_epi16(y, addToY);

                y = Avx2.mm256_add_epi16(y, y);
                b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, Avx2.mm256_slli_epi16(y, 1)),
                                                                     Avx2.mm256_add_epi16(y, ONE)));
                shrl = Avx2.mm256_srli_epi16(x, 12);
                greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi16(b, 12));
                addToY   = Avx2.mm256_add_epi16(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi16(x, subFromX);
                y = Avx2.mm256_add_epi16(y, addToY);

                y = Avx2.mm256_add_epi16(y, y);
                b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, Avx2.mm256_slli_epi16(y, 1)),
                                                                     Avx2.mm256_add_epi16(y, ONE)));
                shrl = Avx2.mm256_srli_epi16(x, 9);
                greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi16(b, 9));
                addToY   = Avx2.mm256_add_epi16(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi16(x, subFromX);
                y = Avx2.mm256_add_epi16(y, addToY);

                y = Avx2.mm256_add_epi16(y, y);
                b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, Avx2.mm256_slli_epi16(y, 1)),
                                                                     Avx2.mm256_add_epi16(y, ONE)));
                shrl = Avx2.mm256_srli_epi16(x, 6);
                greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi16(b, 6));
                addToY   = Avx2.mm256_add_epi16(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi16(x, subFromX);
                y = Avx2.mm256_add_epi16(y, addToY);

                y = Avx2.mm256_add_epi16(y, y);
                b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, Avx2.mm256_slli_epi16(y, 1)),
                                                                     Avx2.mm256_add_epi16(y, ONE)));
                shrl = Avx2.mm256_srli_epi16(x, 3);
                greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi16(b, 3));
                addToY   = Avx2.mm256_add_epi16(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi16(x, subFromX);
                y = Avx2.mm256_add_epi16(y, addToY);

                y = Avx2.mm256_add_epi16(y, y);
                b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, Avx2.mm256_slli_epi16(y, 1)),
                                                                     Avx2.mm256_add_epi16(y, ONE)));
                
                greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, x);
                addToY   = Avx2.mm256_add_epi16(ONE, greaterEqualMask);
                y = Avx2.mm256_add_epi16(y, addToY);

                return y;
            }
            else
            {
                return new ushort16(intcbrt(x.v8_0), intcbrt(x.v8_8));
            }
        }

        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="short"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(-32, 40)]
        public static short intcbrt(short x, bool handleNegativeInput = false)
        {
            if (handleNegativeInput)
            {
                bool negative = x < 0;
                ushort _cbrt = intcbrt((ushort)math.select(x, -x, negative));

                return select((short)_cbrt, (short)-(short)_cbrt, negative);
            }
            else
            {
                return (short)intcbrt((ushort)x);
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.short2"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 intcbrt(short2 x, bool handleNegativeInput = false)
        {
            if (Sse2.IsSse2Supported)
            {
                if (handleNegativeInput)
                {
                    v128 ZERO = Sse2.setzero_si128();

                    v128 negative = Sse2.cmpgt_epi16(ZERO, x);
                    v128 _cbrt;
                    if (Ssse3.IsSsse3Supported)
                    {
                        _cbrt = intcbrt((ushort2)Ssse3.abs_epi16(x));
                        
                    }
                    else
                    {
                        _cbrt = intcbrt((ushort2)Sse2.xor_si128(Sse2.add_epi16(x, negative), negative));
                    }
                    
                    return Sse2.xor_si128(Sse2.add_epi16(_cbrt, negative), negative);
                }
                else 
                {
                    return (short2)intcbrt((ushort2)x);
                }
            }
            else
            {
                return new short2(intcbrt(x.x,  handleNegativeInput), 
                                  intcbrt(x.y,  handleNegativeInput));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.short3"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 intcbrt(short3 x, bool handleNegativeInput = false)
        {
            if (Sse2.IsSse2Supported)
            {
                if (handleNegativeInput)
                {
                    v128 ZERO = Sse2.setzero_si128();

                    v128 negative = Sse2.cmpgt_epi16(ZERO, x);
                    v128 _cbrt;
                    if (Ssse3.IsSsse3Supported)
                    {
                        _cbrt = intcbrt((ushort3)Ssse3.abs_epi16(x));
                        
                    }
                    else
                    {
                        _cbrt = intcbrt((ushort3)Sse2.xor_si128(Sse2.add_epi16(x, negative), negative));
                    }
                    
                    return Sse2.xor_si128(Sse2.add_epi16(_cbrt, negative), negative);
                }
                else 
                {
                    return (short3)intcbrt((ushort3)x);
                }
            }
            else
            {
                return new short3(intcbrt(x.x,  handleNegativeInput), 
                                  intcbrt(x.y,  handleNegativeInput),  
                                  intcbrt(x.z,  handleNegativeInput));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.short4"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 intcbrt(short4 x, bool handleNegativeInput = false)
        {
            if (Sse2.IsSse2Supported)
            {
                if (handleNegativeInput)
                {
                    v128 ZERO = Sse2.setzero_si128();

                    v128 negative = Sse2.cmpgt_epi16(ZERO, x);
                    v128 _cbrt;
                    if (Ssse3.IsSsse3Supported)
                    {
                        _cbrt = intcbrt((ushort4)Ssse3.abs_epi16(x));
                        
                    }
                    else
                    {
                        _cbrt = intcbrt((ushort4)Sse2.xor_si128(Sse2.add_epi16(x, negative), negative));
                    }
                    
                    return Sse2.xor_si128(Sse2.add_epi16(_cbrt, negative), negative);
                }
                else 
                {
                    return (short4)intcbrt((ushort4)x);
                }
            }
            else
            {
                return new short4(intcbrt(x.x,  handleNegativeInput), 
                                  intcbrt(x.y,  handleNegativeInput),  
                                  intcbrt(x.z,  handleNegativeInput),  
                                  intcbrt(x.w,  handleNegativeInput));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.short8"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 intcbrt(short8 x, bool handleNegativeInput = false)
        {
            if (Sse2.IsSse2Supported)
            {
                if (handleNegativeInput)
                {
                    v128 ZERO = Sse2.setzero_si128();

                    v128 negative = Sse2.cmpgt_epi16(ZERO, x);
                    v128 _cbrt;
                    if (Ssse3.IsSsse3Supported)
                    {
                        _cbrt = intcbrt((ushort8)Ssse3.abs_epi16(x));
                        
                    }
                    else
                    {
                        _cbrt = intcbrt((ushort8)Sse2.xor_si128(Sse2.add_epi16(x, negative), negative));
                    }
                    
                    return Sse2.xor_si128(Sse2.add_epi16(_cbrt, negative), negative);
                }
                else 
                {
                    return (short8)intcbrt((ushort8)x);
                }
            }
            else
            {
                return new short8(intcbrt(x.x0,  handleNegativeInput), 
                                  intcbrt(x.x1,  handleNegativeInput),  
                                  intcbrt(x.x2,  handleNegativeInput),  
                                  intcbrt(x.x3,  handleNegativeInput),  
                                  intcbrt(x.x4,  handleNegativeInput),  
                                  intcbrt(x.x5,  handleNegativeInput),  
                                  intcbrt(x.x6,  handleNegativeInput),  
                                  intcbrt(x.x7,  handleNegativeInput));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.short16"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 intcbrt(short16 x, bool handleNegativeInput = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (handleNegativeInput)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 negative = Avx2.mm256_cmpgt_epi16(ZERO, x);
                    v256 _cbrt = intcbrt((ushort16)Avx2.mm256_abs_epi16(x));
                    
                    return Avx2.mm256_xor_si256(Avx2.mm256_add_epi16(_cbrt, negative), negative);
                }
                else 
                {
                    return (short16)intcbrt((ushort16)x);
                }
            }
            else
            {
                return new short16(intcbrt(x.v8_0, handleNegativeInput), intcbrt(x.v8_8, handleNegativeInput));
            }
        }


        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="uint"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0ul, 1_625ul)]
        public static uint intcbrt(uint x)
        {
            uint y = 0;
            uint b = 1;


            if ((x >> 30) != 0) 
            {
                x -= b << 30;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 27) >= b) 
            {
                x -= b << 27;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 24) >= b) 
            {
                x -= b << 24;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 21) >= b) 
            {
                x -= b << 21;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 18) >= b) 
            {
                x -= b << 18;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 15) >= b) 
            {
                x -= b << 15;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 12) >= b) 
            {
                x -= b << 12;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 9) >= b) 
            {
                x -= b << 9;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 6) >= b) 
            {
                x -= b << 6;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 3) >= b) 
            {
                x -= b << 3;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            y += tobyte(x >= b);

            return y;
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="uint2"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 intcbrt(uint2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = UnityMathematicsLink.Tov128(x);

                v128 ONE = Sse2.set1_epi32(1);

                v128 y = Sse2.setzero_si128();
                v128 b = ONE;
                
                v128 shrl = Sse2.srli_epi32(_x, 30);
                v128 greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                v128 subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 30));
                v128 addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 27);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 27));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 24);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 24));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 21);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 21));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 18);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 18));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 15);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 15));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 12);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 12));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 9);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 9));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 6);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 6));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 3);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 3));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                
                greaterEqualMask = Sse2.cmpgt_epi32(b, _x);
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                y = Sse2.add_epi32(y, addToY);

                return *(uint2*)&y;
            }
            else
            {
                return new uint2(intcbrt(x.x), intcbrt(x.y));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="uint3"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 intcbrt(uint3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = UnityMathematicsLink.Tov128(x);

                v128 ONE = Sse2.set1_epi32(1);

                v128 y = Sse2.setzero_si128();
                v128 b = ONE;
                
                v128 shrl = Sse2.srli_epi32(_x, 30);
                v128 greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                v128 subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 30));
                v128 addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 27);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 27));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 24);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 24));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 21);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 21));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 18);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 18));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 15);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 15));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 12);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 12));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 9);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 9));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 6);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 6));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 3);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 3));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                
                greaterEqualMask = Sse2.cmpgt_epi32(b, _x);
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                y = Sse2.add_epi32(y, addToY);

                return *(uint3*)&y;
            }
            else
            {
                return new uint3(intcbrt(x.x), intcbrt(x.y), intcbrt(x.z));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="uint4"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 intcbrt(uint4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = UnityMathematicsLink.Tov128(x);

                v128 ONE = Sse2.set1_epi32(1);

                v128 y = Sse2.setzero_si128();
                v128 b = ONE;
                
                v128 shrl = Sse2.srli_epi32(_x, 30);
                v128 greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                v128 subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 30));
                v128 addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 27);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 27));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 24);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 24));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 21);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 21));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 18);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 18));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 15);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 15));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 12);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 12));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 9);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 9));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 6);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 6));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                shrl = Sse2.srli_epi32(_x, 3);
                greaterEqualMask = Sse2.cmpgt_epi32(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 3));
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                _x = Sse2.sub_epi32(_x, subFromX);
                y = Sse2.add_epi32(y, addToY);

                y = Sse2.add_epi32(y, y);
                b = Sse2.add_epi32(ONE, Operator.mul_int(Sse2.add_epi32(y, Sse2.slli_epi32(y, 1)),
                                                         Sse2.add_epi32(y, ONE)));
                
                greaterEqualMask = Sse2.cmpgt_epi32(b, _x);
                addToY   = Sse2.add_epi32(ONE, greaterEqualMask);
                y = Sse2.add_epi32(y, addToY);

                return *(uint4*)&y;
            }
            else
            {
                return new uint4(intcbrt(x.x), intcbrt(x.y), intcbrt(x.z), intcbrt(x.w));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.uint8"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 intcbrt(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ONE = Avx.mm256_set1_epi32(1);

                v256 y = Avx.mm256_setzero_si256();
                v256 b = ONE;
                
                v256 shrl = Avx2.mm256_srli_epi32(x, 30);
                v256 greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, shrl);
                v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 30));
                v256 addToY   = Avx2.mm256_add_epi32(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi32(x, subFromX);
                y = Avx2.mm256_add_epi32(y, addToY);

                y = Avx2.mm256_add_epi32(y, y);
                b = Avx2.mm256_add_epi32(ONE, Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(y, Avx2.mm256_slli_epi32(y, 1)),
                                                                     Avx2.mm256_add_epi32(y, ONE)));
                shrl = Avx2.mm256_srli_epi32(x, 27);
                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 27));
                addToY   = Avx2.mm256_add_epi32(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi32(x, subFromX);
                y = Avx2.mm256_add_epi32(y, addToY);

                y = Avx2.mm256_add_epi32(y, y);
                b = Avx2.mm256_add_epi32(ONE, Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(y, Avx2.mm256_slli_epi32(y, 1)),
                                                                     Avx2.mm256_add_epi32(y, ONE)));
                shrl = Avx2.mm256_srli_epi32(x, 24);
                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 24));
                addToY   = Avx2.mm256_add_epi32(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi32(x, subFromX);
                y = Avx2.mm256_add_epi32(y, addToY);

                y = Avx2.mm256_add_epi32(y, y);
                b = Avx2.mm256_add_epi32(ONE, Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(y, Avx2.mm256_slli_epi32(y, 1)),
                                                                     Avx2.mm256_add_epi32(y, ONE)));
                shrl = Avx2.mm256_srli_epi32(x, 21);
                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 21));
                addToY   = Avx2.mm256_add_epi32(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi32(x, subFromX);
                y = Avx2.mm256_add_epi32(y, addToY);

                y = Avx2.mm256_add_epi32(y, y);
                b = Avx2.mm256_add_epi32(ONE, Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(y, Avx2.mm256_slli_epi32(y, 1)),
                                                                     Avx2.mm256_add_epi32(y, ONE)));
                shrl = Avx2.mm256_srli_epi32(x, 18);
                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 18));
                addToY   = Avx2.mm256_add_epi32(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi32(x, subFromX);
                y = Avx2.mm256_add_epi32(y, addToY);

                y = Avx2.mm256_add_epi32(y, y);
                b = Avx2.mm256_add_epi32(ONE, Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(y, Avx2.mm256_slli_epi32(y, 1)),
                                                                     Avx2.mm256_add_epi32(y, ONE)));
                shrl = Avx2.mm256_srli_epi32(x, 15);
                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 15));
                addToY   = Avx2.mm256_add_epi32(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi32(x, subFromX);
                y = Avx2.mm256_add_epi32(y, addToY);

                y = Avx2.mm256_add_epi32(y, y);
                b = Avx2.mm256_add_epi32(ONE, Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(y, Avx2.mm256_slli_epi32(y, 1)),
                                                                     Avx2.mm256_add_epi32(y, ONE)));
                shrl = Avx2.mm256_srli_epi32(x, 12);
                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 12));
                addToY   = Avx2.mm256_add_epi32(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi32(x, subFromX);
                y = Avx2.mm256_add_epi32(y, addToY);

                y = Avx2.mm256_add_epi32(y, y);
                b = Avx2.mm256_add_epi32(ONE, Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(y, Avx2.mm256_slli_epi32(y, 1)),
                                                                     Avx2.mm256_add_epi32(y, ONE)));
                shrl = Avx2.mm256_srli_epi32(x, 9);
                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 9));
                addToY   = Avx2.mm256_add_epi32(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi32(x, subFromX);
                y = Avx2.mm256_add_epi32(y, addToY);

                y = Avx2.mm256_add_epi32(y, y);
                b = Avx2.mm256_add_epi32(ONE, Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(y, Avx2.mm256_slli_epi32(y, 1)),
                                                                     Avx2.mm256_add_epi32(y, ONE)));
                shrl = Avx2.mm256_srli_epi32(x, 6);
                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 6));
                addToY   = Avx2.mm256_add_epi32(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi32(x, subFromX);
                y = Avx2.mm256_add_epi32(y, addToY);

                y = Avx2.mm256_add_epi32(y, y);
                b = Avx2.mm256_add_epi32(ONE, Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(y, Avx2.mm256_slli_epi32(y, 1)),
                                                                     Avx2.mm256_add_epi32(y, ONE)));
                shrl = Avx2.mm256_srli_epi32(x, 3);
                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 3));
                addToY   = Avx2.mm256_add_epi32(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi32(x, subFromX);
                y = Avx2.mm256_add_epi32(y, addToY);

                y = Avx2.mm256_add_epi32(y, y);
                b = Avx2.mm256_add_epi32(ONE, Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(y, Avx2.mm256_slli_epi32(y, 1)),
                                                                     Avx2.mm256_add_epi32(y, ONE)));
                
                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, x);
                addToY   = Avx2.mm256_add_epi32(ONE, greaterEqualMask);
                y = Avx2.mm256_add_epi32(y, addToY);

                return y;
            }
            else
            {
                return new uint8(intcbrt(x.v4_0), intcbrt(x.v4_4));
            }
        }

        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of an <see cref="int"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(-1_290, 1_625)]
        public static int intcbrt(int x, bool handleNegativeInput = false)
        {
            if (handleNegativeInput)
            {
                bool negative = x < 0;
                uint _cbrt = intcbrt((uint)math.select(x, -x, negative));

                return math.select((int)_cbrt, -(int)_cbrt, negative);
            }
            else
            {
                return (int)intcbrt((uint)x);
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="int2"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 intcbrt(int2 x, bool handleNegativeInput = false)
        {
            if (handleNegativeInput)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 ZERO = Sse2.setzero_si128();

                    v128 _x = UnityMathematicsLink.Tov128(x);

                    v128 negative = Sse2.cmpgt_epi32(ZERO, _x);
                    v128 abs;
                    if (Ssse3.IsSsse3Supported)
                    {
                        abs = Ssse3.abs_epi32(_x);
                    }
                    else
                    {
                        abs = Sse2.xor_si128(Sse2.add_epi32(_x, negative), negative);
                    }
                    uint2 _cbrt = intcbrt(*(uint2*)&abs);
                    
                    v128 result = Sse2.xor_si128(Sse2.add_epi32(UnityMathematicsLink.Tov128(_cbrt), negative), negative);

                    return *(int2*)&result;
                }
                else
                {
                    bool2 negative = x < 0;
                    uint2 _cbrt = intcbrt((uint2)math.select(x, -x, negative));

                    return math.select((int2)_cbrt, -(int2)_cbrt, negative);
                }
            }
            else
            {
                return (int2)intcbrt((uint2)x);
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="int3"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 intcbrt(int3 x, bool handleNegativeInput = false)
        {
            if (handleNegativeInput)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 ZERO = Sse2.setzero_si128();

                    v128 _x = UnityMathematicsLink.Tov128(x);

                    v128 negative = Sse2.cmpgt_epi32(ZERO, _x);
                    v128 abs;
                    if (Ssse3.IsSsse3Supported)
                    {
                        abs = Ssse3.abs_epi32(_x);
                    }
                    else
                    {
                        abs = Sse2.xor_si128(Sse2.add_epi32(_x, negative), negative);
                    }
                    uint3 _cbrt = intcbrt(*(uint3*)&abs);
                    
                    v128 result = Sse2.xor_si128(Sse2.add_epi32(UnityMathematicsLink.Tov128(_cbrt), negative), negative);

                    return *(int3*)&result;
                }
                else
                {
                    bool3 negative = x < 0;
                    uint3 _cbrt = intcbrt((uint3)math.select(x, -x, negative));

                    return math.select((int3)_cbrt, -(int3)_cbrt, negative);
                }
            }
            else
            {
                return (int3)intcbrt((uint3)x);
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="int4"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 intcbrt(int4 x, bool handleNegativeInput = false)
        {
            if (handleNegativeInput)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 ZERO = Sse2.setzero_si128();

                    v128 _x = UnityMathematicsLink.Tov128(x);

                    v128 negative = Sse2.cmpgt_epi32(ZERO, _x);
                    v128 abs;
                    if (Ssse3.IsSsse3Supported)
                    {
                        abs = Ssse3.abs_epi32(_x);
                    }
                    else
                    {
                        abs = Sse2.xor_si128(Sse2.add_epi32(_x, negative), negative);
                    }
                    uint4 _cbrt = intcbrt(*(uint4*)&abs);
                    
                    v128 result = Sse2.xor_si128(Sse2.add_epi32(UnityMathematicsLink.Tov128(_cbrt), negative), negative);

                    return *(int4*)&result;
                }
                else
                {
                    bool4 negative = x < 0;
                    uint4 _cbrt = intcbrt((uint4)math.select(x, -x, negative));

                    return math.select((int4)_cbrt, -(int4)_cbrt, negative);
                }
            }
            else
            {
                return (int4)intcbrt((uint4)x);
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.int8"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 intcbrt(int8 x, bool handleNegativeInput = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (handleNegativeInput)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 negative = Avx2.mm256_cmpgt_epi32(ZERO, x);
                    uint8 _cbrt = intcbrt((uint8)Avx2.mm256_abs_epi32(x));

                    return Avx2.mm256_xor_si256(Avx2.mm256_add_epi32(_cbrt, negative), negative);
                }
                else 
                {
                    return (int8)intcbrt((uint8)x);
                }
            }
            else
            {
                return new int8(intcbrt(x.v4_0, handleNegativeInput), intcbrt(x.v4_4, handleNegativeInput));
            }
        }


        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="ulong"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0ul, 2_642_245ul)]
        public static ulong intcbrt(ulong x)
        {
            ulong y = 0;
            ulong b = 1;
            
            if ((x >> 63) != 0) 
            {
                x -= b << 63;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 60) >= b) 
            {
                x -= b << 60;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 57) >= b) 
            {
                x -= b << 57;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 54) >= b) 
            {
                x -= b << 54;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 51) >= b) 
            {
                x -= b << 51;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 48) >= b) 
            {
                x -= b << 48;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 45) >= b) 
            {
                x -= b << 45;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 42) >= b) 
            {
                x -= b << 42;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 39) >= b) 
            {
                x -= b << 39;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 36) >= b) 
            {
                x -= b << 36;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 33) >= b) 
            {
                x -= b << 33;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 30) >= b) 
            {
                x -= b << 30;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 27) >= b) 
            {
                x -= b << 27;
                y++;
            }
            
            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 24) >= b) 
            {
                x -= b << 24;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 21) >= b) 
            {
                x -= b << 21;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 18) >= b) 
            {
                x -= b << 18;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 15) >= b) 
            {
                x -= b << 15;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 12) >= b) 
            {
                x -= b << 12;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 9) >= b) 
            {
                x -= b << 9;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 6) >= b) 
            {
                x -= b << 6;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            
            if ((x >> 3) >= b) 
            {
                x -= b << 3;
                y++;
            }

            y += y;
            b = ((3 * y) * (y + 1)) + 1;
            y += tobyte(x >= b);

            return y;
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ulong2"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 intcbrt(ulong2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ONE = Sse2.set1_epi64x(1);

                v128 y = Sse2.setzero_si128();
                v128 b = ONE;
                
                v128 shrl = Sse2.srli_epi64(x, 63);
                v128 greaterEqualMask = Operator.greater_mask_long(b, shrl);
                v128 subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 63));
                v128 addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 60);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 60));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 57);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 57));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 54);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 54));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 51);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 51));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 48);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 48));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 45);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 45));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 42);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 42));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 39);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 39));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 36);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 36));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 33);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 33));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 30);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 30));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 27);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 27));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 24);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 24));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 21);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 21));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 18);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 18));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 15);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 15));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 12);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 12));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 9);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 9));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 6);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 6));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                shrl = Sse2.srli_epi64(x, 3);
                greaterEqualMask = Operator.greater_mask_long(b, shrl);
                subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 3));
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                x = Sse2.sub_epi64(x, subFromX);
                y = Sse2.add_epi64(y, addToY);

                y = Sse2.add_epi64(y, y);
                b = Sse2.add_epi64(ONE, Operator.mul_long(Sse2.add_epi64(y, Sse2.slli_epi64(y, 1)),
                                                          Sse2.add_epi64(y, ONE)));
                
                greaterEqualMask = Operator.greater_mask_long(b, x);
                addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                y = Sse2.add_epi64(y, addToY);

                return y;
            }
            else
            {
                return new ulong2(intcbrt(x.x), intcbrt(x.y));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ulong3"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 intcbrt(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ONE = Avx.mm256_set1_epi64x(1);

                v256 y = Avx.mm256_setzero_si256();
                v256 b = ONE;
                
                v256 shrl = Avx2.mm256_srli_epi64(x, 63);
                v256 greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 63));
                v256 addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 60);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 60));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 57);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 57));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 54);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 54));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 51);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 51));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 48);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 48));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 45);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 45));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 42);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 42));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 39);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 39));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 36);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 36));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 33);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 33));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 30);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 30));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 27);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 27));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 24);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 24));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 21);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 21));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 18);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 18));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 15);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 15));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 12);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 12));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 9);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 9));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 6);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 6));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 3);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 3));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, x);
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                y = Avx2.mm256_add_epi64(y, addToY);

                return y;
            }
            else
            {
                return new ulong3(intcbrt(x.xy), intcbrt(x.z));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ulong4"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 intcbrt(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ONE = Avx.mm256_set1_epi64x(1);

                v256 y = Avx.mm256_setzero_si256();
                v256 b = ONE;
                
                v256 shrl = Avx2.mm256_srli_epi64(x, 63);
                v256 greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 63));
                v256 addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 60);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 60));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 57);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 57));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 54);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 54));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 51);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 51));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 48);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 48));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 45);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 45));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 42);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 42));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 39);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 39));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 36);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 36));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 33);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 33));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 30);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 30));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 27);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 27));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 24);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 24));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 21);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 21));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 18);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 18));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 15);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 15));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 12);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 12));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 9);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 9));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 6);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 6));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                shrl = Avx2.mm256_srli_epi64(x, 3);
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, shrl);
                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 3));
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                x = Avx2.mm256_sub_epi64(x, subFromX);
                y = Avx2.mm256_add_epi64(y, addToY);

                y = Avx2.mm256_add_epi64(y, y);
                b = Avx2.mm256_add_epi64(ONE, Operator.mul_long(Avx2.mm256_add_epi64(y, Avx2.mm256_slli_epi64(y, 1)),
                                                                Avx2.mm256_add_epi64(y, ONE)));
                
                greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, x);
                addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                y = Avx2.mm256_add_epi64(y, addToY);

                return y;
            }
            else
            {
                return new ulong4(intcbrt(x.xy), intcbrt(x.zw));
            }
        }

        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="long"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(-2_097_152, 2_642_245)]
        public static long intcbrt(long x, bool handleNegativeInput = false)
        {
            if (handleNegativeInput)
            {
                bool negative = x < 0;
                ulong _cbrt = intcbrt((ulong)math.select(x, -x, negative));

                return math.select((long)_cbrt, -(long)_cbrt, negative);
            }
            else
            {
                return (long)intcbrt((ulong)x);
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.long2"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 intcbrt(long2 x, bool handleNegativeInput = false)
        {
            if (handleNegativeInput)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 ZERO = Sse2.setzero_si128();

                    v128 negative = Operator.greater_mask_long(ZERO, x);
                    v128 _cbrt = intcbrt((ulong2)Sse2.xor_si128(Sse2.add_epi64(x, negative), negative));

                    return Sse2.xor_si128(Sse2.add_epi64(_cbrt, negative), negative);
                }
                else
                {
                    bool2 negative = x < 0;
                    ulong2 _cbrt = intcbrt((ulong2)select(x, -x, negative));

                    return select((long2)_cbrt, -(long2)_cbrt, negative);
                }
            }
            else
            {
                return (long2)intcbrt((ulong2)x);
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.long3"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 intcbrt(long3 x, bool handleNegativeInput = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (handleNegativeInput)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 negative = Avx2.mm256_cmpgt_epi64(ZERO, x);
                    v256 _cbrt = intcbrt((ulong3)Avx2.mm256_xor_si256(Avx2.mm256_add_epi64(x, negative), negative));
                    
                    return Avx2.mm256_xor_si256(Avx2.mm256_add_epi64(_cbrt, negative), negative);
                }
                else 
                {
                    return (long3)intcbrt((ulong3)x);
                }
            }
            else
            {
                return new long3(intcbrt(x.xy, handleNegativeInput), intcbrt(x.z, handleNegativeInput));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.long4"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 intcbrt(long4 x, bool handleNegativeInput = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (handleNegativeInput)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 negative = Avx2.mm256_cmpgt_epi64(ZERO, x);
                    v256 _cbrt = intcbrt((ulong4)Avx2.mm256_xor_si256(Avx2.mm256_add_epi64(x, negative), negative));
                    
                    return Avx2.mm256_xor_si256(Avx2.mm256_add_epi64(_cbrt, negative), negative);
                }
                else 
                {
                    return (long4)intcbrt((ulong4)x);
                }
            }
            else
            {
                return new long4(intcbrt(x.xy, handleNegativeInput), intcbrt(x.zw, handleNegativeInput));
            }
        }
    }
}