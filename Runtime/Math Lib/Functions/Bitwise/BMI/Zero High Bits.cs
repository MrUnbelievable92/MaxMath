using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bzhi_epi8(v128 a, v128 startIndex, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI8(startIndex, 0, elements))
                    {
                        return Sse2.setzero_si128();
                    }

                    if (Ssse3.IsSsse3Supported)
                    {
                        v128 LOOKUP = new v128(0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111);

                        return Sse2.and_si128(a, Ssse3.shuffle_epi8(LOOKUP, startIndex));
                    }
                    else
                    {
                        v128 ONE = Sse2.set1_epi8(1);

                        return Sse2.and_si128(a, Sse2.sub_epi8(sllv_epi8(ONE, startIndex, elements), ONE));
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bzhi_epi16(v128 a, v128 startIndex, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI16(startIndex, 0, elements))
                    {
                        return Sse2.setzero_si128();
                    }


                    v128 ONE = Sse2.set1_epi16(1);

                    return Sse2.and_si128(a, Sse2.sub_epi16(sllv_epi16(ONE, startIndex, elements), ONE));
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bzhi_epi32(v128 a, v128 startIndex, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI32(startIndex, 0, elements))
                    {
                        return Sse2.setzero_si128();
                    }


                    return Sse2.andnot_si128(sllv_epi32(setall_si128(), startIndex, elements), a);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bzhi_epi64(v128 a, v128 startIndex)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI64(startIndex, 0))
                    {
                        return Sse2.setzero_si128();
                    }


                    return Sse2.andnot_si128(sllv_epi64(setall_si128(), startIndex), a);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bzhi_epi8(v256 a, v256 startIndex)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI8(startIndex, 0))
                    {
                        return Avx.mm256_setzero_si256();
                    }


                    v256 LOOKUP = new v256(0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111,
                                           0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111);

                    return Avx2.mm256_and_si256(a, Avx2.mm256_shuffle_epi8(LOOKUP, startIndex));
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bzhi_epi16(v256 a, v256 startIndex)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI16(startIndex, 0))
                    {
                        return Avx.mm256_setzero_si256();
                    }


                    v256 ONE = Avx.mm256_set1_epi16(1);

                    return Avx2.mm256_and_si256(a, Avx2.mm256_sub_epi16(mm256_sllv_epi16(ONE, startIndex), ONE));
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bzhi_epi32(v256 a, v256 startIndex)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI32(startIndex, 0))
                    {
                        return Avx.mm256_setzero_si256();
                    }


                    return Avx2.mm256_andnot_si256(Avx2.mm256_sllv_epi32(mm256_setall_si256(), startIndex), a);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bzhi_epi64(v256 a, v256 startIndex, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI64(startIndex, 0, elements))
                    {
                        return Avx.mm256_setzero_si256();
                    }


                    return Avx2.mm256_andnot_si256(Avx2.mm256_sllv_epi64(mm256_setall_si256(), startIndex), a);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_zerohigh(Int128 x, int startIndex)
        {
            return (Int128)bits_zerohigh((UInt128)x, startIndex);
        }

        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_zerohigh(UInt128 x, int startIndex)
        {
            return andnot(x, UInt128.MaxValue << startIndex);
        }


        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_zerohigh(byte x, int startIndex)
        {
            return (byte)bits_zerohigh((uint)x, startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_zerohigh(byte2 x, byte2 startIndex)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.bzhi_epi8(x, startIndex, 2);
            }
            else
            {
                return new byte2(bits_zerohigh(x.x, startIndex.x), bits_zerohigh(x.y, startIndex.y));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bits_zerohigh(byte3 x, byte3 startIndex)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.bzhi_epi8(x, startIndex, 3);
            }
            else
            {
                return new byte3(bits_zerohigh(x.x, startIndex.x), bits_zerohigh(x.y, startIndex.y), bits_zerohigh(x.z, startIndex.z));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bits_zerohigh(byte4 x, byte4 startIndex)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.bzhi_epi8(x, startIndex, 4);
            }
            else
            {
                return new byte4(bits_zerohigh(x.x, startIndex.x), bits_zerohigh(x.y, startIndex.y), bits_zerohigh(x.z, startIndex.z), bits_zerohigh(x.w, startIndex.w));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bits_zerohigh(byte8 x, byte8 startIndex)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.bzhi_epi8(x, startIndex, 8);
            }
            else
            {
                return new byte8(bits_zerohigh(x.x0, startIndex.x0), bits_zerohigh(x.x1, startIndex.x1), bits_zerohigh(x.x2, startIndex.x2), bits_zerohigh(x.x3, startIndex.x3), bits_zerohigh(x.x4, startIndex.x4), bits_zerohigh(x.x5, startIndex.x5), bits_zerohigh(x.x6, startIndex.x6), bits_zerohigh(x.x7, startIndex.x7));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bits_zerohigh(byte16 x, byte16 startIndex)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.bzhi_epi8(x, startIndex, 16);
            }
            else
            {
                return new byte16(bits_zerohigh(x.x0, startIndex.x0), bits_zerohigh(x.x1, startIndex.x1), bits_zerohigh(x.x2, startIndex.x2), bits_zerohigh(x.x3, startIndex.x3), bits_zerohigh(x.x4, startIndex.x4), bits_zerohigh(x.x5, startIndex.x5), bits_zerohigh(x.x6, startIndex.x6), bits_zerohigh(x.x7, startIndex.x7), bits_zerohigh(x.x8, startIndex.x8), bits_zerohigh(x.x9, startIndex.x9), bits_zerohigh(x.x10, startIndex.x10), bits_zerohigh(x.x11, startIndex.x11), bits_zerohigh(x.x12, startIndex.x12), bits_zerohigh(x.x13, startIndex.x13), bits_zerohigh(x.x14, startIndex.x14), bits_zerohigh(x.x15, startIndex.x15));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bits_zerohigh(byte32 x, byte32 startIndex)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bzhi_epi8(x, startIndex);
            }
            else
            {
                return new byte32(bits_zerohigh(x.v16_0, startIndex.v16_0), bits_zerohigh(x.v16_16, startIndex.v16_16));
            }
        }


        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_zerohigh(sbyte x, int startIndex)
        {
            return (sbyte)bits_zerohigh((byte)x, startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bits_zerohigh(sbyte2 x, sbyte2 startIndex)
        {
            return (sbyte2)bits_zerohigh((byte2)x, (byte2)startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bits_zerohigh(sbyte3 x, sbyte3 startIndex)
        {
            return (sbyte3)bits_zerohigh((byte3)x, (byte3)startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bits_zerohigh(sbyte4 x, sbyte4 startIndex)
        {
            return (sbyte4)bits_zerohigh((byte4)x, (byte4)startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bits_zerohigh(sbyte8 x, sbyte8 startIndex)
        {
            return (sbyte8)bits_zerohigh((byte8)x, (byte8)startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bits_zerohigh(sbyte16 x, sbyte16 startIndex)
        {
            return (sbyte16)bits_zerohigh((byte16)x, (byte16)startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bits_zerohigh(sbyte32 x, sbyte32 startIndex)
        {
            return (sbyte32)bits_zerohigh((byte32)x, (byte32)startIndex);
        }


        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_zerohigh(ushort x, int startIndex)
        {
            return (ushort)bits_zerohigh((uint)x, startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bits_zerohigh(ushort2 x, ushort2 startIndex)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.bzhi_epi16(x, startIndex, 2);
            }
            else
            {
                return new ushort2(bits_zerohigh(x.x, startIndex.x), bits_zerohigh(x.y, startIndex.y));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bits_zerohigh(ushort3 x, ushort3 startIndex)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.bzhi_epi16(x, startIndex, 3);
            }
            else
            {
                return new ushort3(bits_zerohigh(x.x, startIndex.x), bits_zerohigh(x.y, startIndex.y), bits_zerohigh(x.z, startIndex.z));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bits_zerohigh(ushort4 x, ushort4 startIndex)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.bzhi_epi16(x, startIndex, 4);
            }
            else
            {
                return new ushort4(bits_zerohigh(x.x, startIndex.x), bits_zerohigh(x.y, startIndex.y), bits_zerohigh(x.z, startIndex.z), bits_zerohigh(x.w, startIndex.w));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bits_zerohigh(ushort8 x, ushort8 startIndex)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.bzhi_epi16(x, startIndex, 8);
            }
            else
            {
                return new ushort8(bits_zerohigh(x.x0, startIndex.x0), bits_zerohigh(x.x1, startIndex.x1), bits_zerohigh(x.x2, startIndex.x2), bits_zerohigh(x.x3, startIndex.x3), bits_zerohigh(x.x4, startIndex.x4), bits_zerohigh(x.x5, startIndex.x5), bits_zerohigh(x.x6, startIndex.x6), bits_zerohigh(x.x7, startIndex.x7));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bits_zerohigh(ushort16 x, ushort16 startIndex)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bzhi_epi16(x, startIndex);
            }
            else
            {
                return new ushort16(bits_zerohigh(x.v8_0, startIndex.v8_0), bits_zerohigh(x.v8_8, startIndex.v8_8));
            }
        }


        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_zerohigh(short x, int startIndex)
        {
            return (short)bits_zerohigh((ushort)x, startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bits_zerohigh(short2 x, short2 startIndex)
        {
            return (short2)bits_zerohigh((ushort2)x, (ushort2)startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bits_zerohigh(short3 x, short3 startIndex)
        {
            return (short3)bits_zerohigh((ushort3)x, (ushort3)startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bits_zerohigh(short4 x, short4 startIndex)
        {
            return (short4)bits_zerohigh((ushort4)x, (ushort4)startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bits_zerohigh(short8 x, short8 startIndex)
        {
            return (short8)bits_zerohigh((ushort8)x, (ushort8)startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bits_zerohigh(short16 x, short16 startIndex)
        {
            return (short16)bits_zerohigh((ushort16)x, (ushort16)startIndex);
        }


        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_zerohigh(uint x, int startIndex)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.bzhi_u32(x, (uint)startIndex);
            }
            else
            {
                return andnot(x, uint.MaxValue << startIndex);
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_zerohigh(uint2 x, uint2 startIndex)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint2>(Xse.bzhi_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(startIndex), 2));
            }
            else
            {
                return new uint2(bits_zerohigh(x.x, (int)startIndex.x), bits_zerohigh(x.y, (int)startIndex.y));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bits_zerohigh(uint3 x, uint3 startIndex)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint3>(Xse.bzhi_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(startIndex), 3));
            }
            else
            {
                return new uint3(bits_zerohigh(x.x, (int)startIndex.x), bits_zerohigh(x.y, (int)startIndex.y), bits_zerohigh(x.z, (int)startIndex.z));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bits_zerohigh(uint4 x, uint4 startIndex)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint4>(Xse.bzhi_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(startIndex), 4));
            }
            else
            {
                return new uint4(bits_zerohigh(x.x, (int)startIndex.x), bits_zerohigh(x.y, (int)startIndex.y), bits_zerohigh(x.z, (int)startIndex.z), bits_zerohigh(x.w, (int)startIndex.w));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bits_zerohigh(uint8 x, uint8 startIndex)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bzhi_epi32(x, startIndex);
            }
            else
            {
                return new uint8(bits_zerohigh(x.v4_0, startIndex.v4_0), bits_zerohigh(x.v4_4, startIndex.v4_4));
            }
        }


        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_zerohigh(int x, int startIndex)
        {
            return (int)bits_zerohigh((uint)x, startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bits_zerohigh(int2 x, int2 startIndex)
        {
            return (int2)bits_zerohigh((uint2)x, (uint2)startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bits_zerohigh(int3 x, int3 startIndex)
        {
            return (int3)bits_zerohigh((uint3)x, (uint3)startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bits_zerohigh(int4 x, int4 startIndex)
        {
            return (int4)bits_zerohigh((uint4)x, (uint4)startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bits_zerohigh(int8 x, int8 startIndex)
        {
            return (int8)bits_zerohigh((uint8)x, (uint8)startIndex);
        }


        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_zerohigh(ulong x, int startIndex)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.bzhi_u64(x, (uint)startIndex);
            }
            else
            {
                return andnot(x, ulong.MaxValue << startIndex);
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bits_zerohigh(ulong2 x, ulong2 startIndex)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.bzhi_epi64(x, startIndex);
            }
            else
            {
                return new ulong2(bits_zerohigh(x.x, (int)startIndex.x), bits_zerohigh(x.y, (int)startIndex.y));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bits_zerohigh(ulong3 x, ulong3 startIndex)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bzhi_epi64(x, startIndex, 3);
            }
            else
            {
                return new ulong3(bits_zerohigh(x.xy, startIndex.xy), bits_zerohigh(x.z, (int)startIndex.z));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bits_zerohigh(ulong4 x, ulong4 startIndex)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bzhi_epi64(x, startIndex, 4);
            }
            else
            {
                return new ulong4(bits_zerohigh(x.xy, startIndex.xy), bits_zerohigh(x.zw, startIndex.zw));
            }
        }


        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_zerohigh(long x, int startIndex)
        {
            return (long)bits_zerohigh((ulong)x, startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bits_zerohigh(long2 x, long2 startIndex)
        {
            return (long2)bits_zerohigh((ulong2)x, (ulong2)startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bits_zerohigh(long3 x, long3 startIndex)
        {
            return (long3)bits_zerohigh((ulong3)x, (ulong3)startIndex);
        }
        
        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bits_zerohigh(long4 x, long4 startIndex)
        {
            return (long4)bits_zerohigh((ulong4)x, (ulong4)startIndex);
        }
    }
}