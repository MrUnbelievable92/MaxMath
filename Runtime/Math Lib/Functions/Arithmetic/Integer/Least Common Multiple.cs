using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lcm_epu8(v128 a, v128 b, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    switch (elements)
                    {
                        case 2:
                        case 3:
                        case 4:
                        {
                            v128 left;
                            if (Constant.IsConstantExpression(a))
                            {
                                left = cvtepu8_ps(b); // counter-intuitive but this is free (ILP during gcd); whereas multiplication at the very end could be up to 4 cycles faster this way
                            }
                            else
                            {
                                left = cvtepu8_ps(a);
                            }

                            v128 right = cvtepu8_ps(gcd_epu8(a, b));
                            v128 ints = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left, right);

                            if (Sse4_1.IsSse41Supported)
                            {
                                if (Constant.IsConstantExpression(a))
                                {
                                    return cvtepi32_epi8(Sse4_1.mullo_epi32(ints, a), elements);
                                }
                                else
                                {
                                    return cvtepi32_epi8(Sse4_1.mullo_epi32(ints, b), elements);
                                }
                            }
                            else
                            {
                                if (Constant.IsConstantExpression(a))
                                {
                                    return cvtepi16_epi8(Sse2.mullo_epi16(Sse2.packs_epi32(ints, ints), a), elements);
                                }
                                else
                                {
                                    return cvtepi16_epi8(Sse2.mullo_epi16(Sse2.packs_epi32(ints, ints), b), elements);
                                }
                            }
                        }
                        case 8:
                        {
                            v128 leftLo;
                            v128 leftHi;
                            if (Constant.IsConstantExpression(a))
                            {
                                leftLo = cvt2x2epu16_ps(cvtepu8_epi16(b), out leftHi); // counter-intuitive but this is free (ILP during gcd); whereas multiplication at the very end could be up to 4 cycles faster this way
                            }
                            else
                            {
                                leftLo = cvt2x2epu16_ps(cvtepu8_epi16(a), out leftHi);
                            }

                            v128 rightLo = cvt2x2epu16_ps(cvtepu8_epi16(gcd_epu8(a, b)),  out v128 rightHi);

                            v128 intsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                            v128 intsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);

                            if (Constant.IsConstantExpression(a))
                            {
                                return cvtepi16_epi8(Sse2.mullo_epi16(Sse2.packs_epi32(intsLo, intsHi), a), 8);
                            }
                            else
                            {
                                return cvtepi16_epi8(Sse2.mullo_epi16(Sse2.packs_epi32(intsLo, intsHi), b), 8);
                            }
                        }
                        default:
                        {
                            if (Constant.IsConstantExpression(a))
                            {
                                return mullo_epi8(div_epu8(b, gcd_epu8(a, b)), a);
                            }
                            else
                            {
                                return mullo_epi8(div_epu8(a, gcd_epu8(a, b)), b);
                            }
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lcm_epu8(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (Constant.IsConstantExpression(a))
                    {
                        return mm256_mullo_epi8(mm256_div_epu8(b, mm256_gcd_epu8(a, b)), a);
                    }
                    else
                    {
                        return mm256_mullo_epi8(mm256_div_epu8(a, mm256_gcd_epu8(a, b)), b);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lcm_epu16(v128 a, v128 b, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Constant.IsConstantExpression(a))
                    {
                        return Sse2.mullo_epi16(div_epu16(b, gcd_epu16(a, b), elements), a);
                    }
                    else
                    {
                        return Sse2.mullo_epi16(div_epu16(a, gcd_epu16(a, b), elements), b);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lcm_epu16(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (Constant.IsConstantExpression(a))
                    {
                        return Avx2.mm256_mullo_epi16(mm256_div_epu16(b, mm256_gcd_epu16(a, b)), a);
                    }
                    else
                    {
                        return Avx2.mm256_mullo_epi16(mm256_div_epu16(a, mm256_gcd_epu16(a, b)), b);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lcm_epu32(v128 a, v128 b, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Constant.IsConstantExpression(a))
                    {
                        return mullo_epi32(div_epu32(b, gcd_epu32(a, b, elements), elements), a, elements);
                    }
                    else
                    {
                        return mullo_epi32(div_epu32(a, gcd_epu32(a, b, elements), elements), b, elements);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lcm_epu32(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (Constant.IsConstantExpression(a))
                    {
                        return Avx2.mm256_mullo_epi32(mm256_div_epu32(b, mm256_gcd_epu32(a, b)), a);
                    }
                    else
                    {
                        return Avx2.mm256_mullo_epi32(mm256_div_epu32(a, mm256_gcd_epu32(a, b)), b);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lcm_epu64(v128 a, v128 b)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Constant.IsConstantExpression(a))
                    {
                        return mullo_epi64(div_epu64(b, gcd_epu64(a, b)), a);
                    }
                    else
                    {
                        return mullo_epi64(div_epu64(a, gcd_epu64(a, b)), b);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lcm_epu64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (Constant.IsConstantExpression(a))
                    {
                        return mm256_mullo_epi64(mm256_div_epu64(b, mm256_gcd_epu64(a, b, elements), elements), a, elements);
                    }
                    else
                    {
                        return mm256_mullo_epi64(mm256_div_epu64(a, mm256_gcd_epu64(a, b, elements), elements), b, elements);
                    }
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the least common multiple of two <see cref="UInt128"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 lcm(UInt128 x, UInt128 y)
        {
            if (Constant.IsConstantExpression(x))
            {
                return (y / gcd(x, y)) * x;
            }
            else
            {
                return (x / gcd(x, y)) * y;
            }
        }

        /// <summary>       Returns the least common multiple of two <see cref="Int128"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 lcm(Int128 x, Int128 y)
        {
            UInt128 absX = (UInt128)abs(x);
            UInt128 absY = (UInt128)abs(y);

            if (Constant.IsConstantExpression(absX))
            {
                return (absY / gcd(absX, absY)) * absX;
            }
            else
            {
                return (absX / gcd(absX, absY)) * absY;
            }
        }


        /// <summary>       Returns the least common multiple of the of two <see cref="byte"/>s.       </summary>
        [return: AssumeRange(0ul, (ulong)byte.MaxValue * byte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static uint lcm(byte x, byte y)
        {
            return lcm((uint)x, (uint)y);
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 lcm(byte2 x, byte2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu8(x, y, 2);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 lcm(byte3 x, byte3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu8(x, y, 3);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 lcm(byte4 x, byte4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu8(x, y, 4);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 lcm(byte8 x, byte8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu8(x, y, 8);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte16"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 lcm(byte16 x, byte16 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu8(x, y, 16);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte32"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 lcm(byte32 x, byte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu8(x, y);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }


        /// <summary>       Returns the least common multiple of the of two <see cref="sbyte"/>s.       </summary>
        [return: AssumeRange(0ul, ((ulong)sbyte.MaxValue + 1ul) * ((ulong)sbyte.MaxValue + 1ul))]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static uint lcm(sbyte x, sbyte y)
        {
            return lcm((int)x, (int)y);
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 lcm(sbyte2 x, sbyte2 y)
        {
            byte2 absX = (byte2)abs(x);
            byte2 absY = (byte2)abs(y);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu8(absX, absY, 2);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 lcm(sbyte3 x, sbyte3 y)
        {
            byte3 absX = (byte3)abs(x);
            byte3 absY = (byte3)abs(y);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu8(absX, absY, 3);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 lcm(sbyte4 x, sbyte4 y)
        {
            byte4 absX = (byte4)abs(x);
            byte4 absY = (byte4)abs(y);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu8(absX, absY, 4);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 lcm(sbyte8 x, sbyte8 y)
        {
            byte8 absX = (byte8)abs(x);
            byte8 absY = (byte8)abs(y);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu8(absX, absY, 8);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte16"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 lcm(sbyte16 x, sbyte16 y)
        {
            byte16 absX = (byte16)abs(x);
            byte16 absY = (byte16)abs(y);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu8(absX, absY, 16);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte32"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 lcm(sbyte32 x, sbyte32 y)
        {
            byte32 absX = (byte32)abs(x);
            byte32 absY = (byte32)abs(y);
            
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu8(absX, absY);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }


        /// <summary>       Returns the least common multiple of the of two <see cref="ushort"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(ushort x, ushort y)
        {
            return lcm((uint)x, (uint)y);
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ushort2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 lcm(ushort2 x, ushort2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu16(x, y, 2);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ushort3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 lcm(ushort3 x, ushort3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu16(x, y, 3);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ushort4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 lcm(ushort4 x, ushort4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu16(x, y, 4);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ushort8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 lcm(ushort8 x, ushort8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu16(x, y, 8);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ushort16"/>s.r.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 lcm(ushort16 x, ushort16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu16(x, y);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }


        /// <summary>       Returns the least common multiple of the of two <see cref="short"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(short x, short y)
        {
            return lcm((int)x, (int)y);
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.short2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 lcm(short2 x, short2 y)
        {
            ushort2 absX = (ushort2)abs(x);
            ushort2 absY = (ushort2)abs(y);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu16(absX, absY, 2);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.short3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 lcm(short3 x, short3 y)
        {
            ushort3 absX = (ushort3)abs(x);
            ushort3 absY = (ushort3)abs(y);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu16(absX, absY, 3);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.short4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 lcm(short4 x, short4 y)
        {
            ushort4 absX = (ushort4)abs(x);
            ushort4 absY = (ushort4)abs(y);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu16(absX, absY, 4);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.short8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 lcm(short8 x, short8 y)
        {
            ushort8 absX = (ushort8)abs(x);
            ushort8 absY = (ushort8)abs(y);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu16(absX, absY, 8);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.short16"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 lcm(short16 x, short16 y)
        {
            ushort16 absX = (ushort16)abs(x);
            ushort16 absY = (ushort16)abs(y);
            
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu16(absX, absY);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }


        /// <summary>       Returns the least common multiple of the of two <see cref="int"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(int x, int y)
        {
            uint absX = Xse.constexpr.IS_TRUE(x >= 0) ? (uint)x : (uint)math.abs(x);
            uint absY = Xse.constexpr.IS_TRUE(x >= 0) ? (uint)y : (uint)math.abs(y);
            
            if (Constant.IsConstantExpression(absX))
            {
                return (absY / gcd(absX, absY)) * absX;
            }
            else
            {
                return (absX / gcd(absX, absY)) * absY;
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="int2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 lcm(int2 x, int2 y)
        {
            uint2 absX = Xse.constexpr.IS_TRUE(math.all(x >= 0)) ? (uint2)x : (uint2)abs(x);
            uint2 absY = Xse.constexpr.IS_TRUE(math.all(x >= 0)) ? (uint2)y : (uint2)abs(y);
            
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt2(Xse.lcm_epu32(RegisterConversion.ToV128(absX), RegisterConversion.ToV128(absY), 2));
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="int3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 lcm(int3 x, int3 y)
        {
            uint3 absX = Xse.constexpr.IS_TRUE(math.all(x >= 0)) ? (uint3)x : (uint3)abs(x);
            uint3 absY = Xse.constexpr.IS_TRUE(math.all(x >= 0)) ? (uint3)y : (uint3)abs(y);
            
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt3(Xse.lcm_epu32(RegisterConversion.ToV128(absX), RegisterConversion.ToV128(absY), 3));
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="int4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 lcm(int4 x, int4 y)
        {
            uint4 absX = Xse.constexpr.IS_TRUE(math.all(x >= 0)) ? (uint4)x : (uint4)abs(x);
            uint4 absY = Xse.constexpr.IS_TRUE(math.all(x >= 0)) ? (uint4)y : (uint4)abs(y);
            
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt4(Xse.lcm_epu32(RegisterConversion.ToV128(absX), RegisterConversion.ToV128(absY), 4));
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.int8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 lcm(int8 x, int8 y)
        {
            uint8 absX = Xse.constexpr.IS_TRUE(all(x >= 0)) ? (uint8)x : (uint8)abs(x);
            uint8 absY = Xse.constexpr.IS_TRUE(all(x >= 0)) ? (uint8)y : (uint8)abs(y);
            
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu32(absX, absY);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }



        /// <summary>       Returns the least common multiple of two <see cref="uint"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(uint x, uint y)
        {
            if (Constant.IsConstantExpression(x))
            {
                return (y / gcd(x, y)) * x;
            }
            else
            {
                return (x / gcd(x, y)) * y;
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="uint2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 lcm(uint2 x, uint2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt2(Xse.lcm_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 2));
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="uint3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 lcm(uint3 x, uint3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt3(Xse.lcm_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 3));
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="uint4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 lcm(uint4 x, uint4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt4(Xse.lcm_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 4));
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.uint8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 lcm(uint8 x, uint8 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu32(x, y);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }


        /// <summary>       Returns the least common multiple of two <see cref="long"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong lcm(long x, long y)
        {
            ulong absX = Xse.constexpr.IS_TRUE(x >= 0) ? (ulong)x : (ulong)math.abs(x);
            ulong absY = Xse.constexpr.IS_TRUE(x >= 0) ? (ulong)y : (ulong)math.abs(y);
            
            if (Constant.IsConstantExpression(x))
            {
                return (absY / gcd(absX, absY)) * absX;
            }
            else
            {
                return (absX / gcd(absX, absY)) * absY;
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.long2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 lcm(long2 x, long2 y)
        {
            ulong2 absX = (ulong2)abs(x);
            ulong2 absY = (ulong2)abs(y);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu64(absX, absY);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.long3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 lcm(long3 x, long3 y)
        {
            ulong3 absX = (ulong3)abs(x);
            ulong3 absY = (ulong3)abs(y);
            
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu64(absX, absY, 3);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.long4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 lcm(long4 x, long4 y)
        {
            ulong4 absX = (ulong4)abs(x);
            ulong4 absY = (ulong4)abs(y);
            
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu64(absX, absY, 4);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (absY / gcd(absX, absY)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY)) * absY;
                }
            }
        }


        /// <summary>       Returns the least common multiple of two <see cref="ulong"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong lcm(ulong x, ulong y)
        {
            if (Constant.IsConstantExpression(x))
            {
                return (y / gcd(x, y)) * x;
            }
            else
            {
                return (x / gcd(x, y)) * y;
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ulong2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 lcm(ulong2 x, ulong2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.lcm_epu64(x, y);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ulong3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 lcm(ulong3 x, ulong3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu64(x, y, 3);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ulong4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 lcm(ulong4 x, ulong4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu64(x, y, 4);
            }
            else
            {
                if (Constant.IsConstantExpression(x))
                {
                    return (y / gcd(x, y)) * x;
                }
                else
                {
                    return (x / gcd(x, y)) * y;
                }
            }
        }
    }
}