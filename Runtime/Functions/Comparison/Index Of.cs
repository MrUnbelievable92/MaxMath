using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    // optimizable (imm8 shuffles instead of byte shuffles)
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the index of the first occurence of a byte value x in a byte2 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(byte2 v, byte x)
        {
            if (Sse2.IsSse2Supported)
            {
                return math.tzcnt(bitmask32(2 * sizeof(byte)) & Sse2.movemask_epi8(Sse2.cmpeq_epi8(v, new byte2(x))));
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }

        /// <summary>       Returns the index of the first occurence of a byte value x in a byte3 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(byte3 v, byte x)
        {
            if (Sse2.IsSse2Supported)
            {
                return math.tzcnt(bitmask32(3 * sizeof(byte)) & Sse2.movemask_epi8(Sse2.cmpeq_epi8(v, new byte3(x))));
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }

        /// <summary>       Returns the index of the first occurence of a byte value x in a byte4 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(byte4 v, byte x)
        {
            if (Sse2.IsSse2Supported)
            {
                return math.tzcnt(bitmask32(4 * sizeof(byte)) & Sse2.movemask_epi8(Sse2.cmpeq_epi8(v, new byte4(x))));
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }

        /// <summary>       Returns the index of the first occurence of a byte value x in a byte8 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(byte8 v, byte x)
        {
            if (Sse2.IsSse2Supported)
            {
                return math.tzcnt(bitmask32(8 * sizeof(byte)) & Sse2.movemask_epi8(Sse2.cmpeq_epi8(v, new byte8(x))));
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }

        /// <summary>       Returns the index of the first occurence of a byte value x in a byte16 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(byte16 v, byte x)
        {
            if (Sse2.IsSse2Supported)
            {
                return math.tzcnt(Sse2.movemask_epi8(Sse2.cmpeq_epi8(v, new byte16(x))));
            }
            else
            {
                for (int i = 0; i < 16; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }

        
        /// <summary>       Returns the index of the first occurence of a byte value x in a byte32 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(byte32 v, byte x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return math.tzcnt(Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi8(v, new byte32(x))));
            }
            else if (Sse2.IsSse2Supported)
            {
                byte16 broadcast = x;

                return math.tzcnt(Sse2.movemask_epi8(Sse2.cmpeq_epi8(v._v16_0, broadcast)) | 
                                  (Sse2.movemask_epi8(Sse2.cmpeq_epi8(v._v16_16, broadcast)) << 16));
            }
            else
            {
                for (int i = 0; i < 32; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }


        /// <summary>       Returns the index of the first occurence of an sbyte value x in an sbyte2 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(sbyte2 v, sbyte x)
        {
            return indexof((byte2)v, (byte)x);
        }

        /// <summary>       Returns the index of the first occurence of an sbyte value x in an sbyte3 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(sbyte3 v, sbyte x)
        {
            return indexof((byte3)v, (byte)x);
        }

        /// <summary>       Returns the index of the first occurence of an sbyte value x in an sbyte4 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(sbyte4 v, sbyte x)
        {
            return indexof((byte4)v, (byte)x);
        }

        /// <summary>       Returns the index of the first occurence of an sbyte value x in an sbyte8 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(sbyte8 v, sbyte x)
        {
            return indexof((byte8)v, (byte)x);
        }

        /// <summary>       Returns the index of the first occurence of an sbyte value x in an sbyte16 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(sbyte16 v, sbyte x)
        {
            return indexof((byte16)v, (byte)x);
        }

        /// <summary>       Returns the index of the first occurence of an sbyte value x in an sbyte32 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(sbyte32 v, sbyte x)
        {
            return indexof((byte32)v, (byte)x);
        }


        /// <summary>       Returns the index of the first occurence of a ushort value x in a ushort2 vector v. If no value in v is equal to x, this function returns 16.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(ushort2 v, ushort x)
        {
            if (Sse2.IsSse2Supported)
            {
                return math.tzcnt(bitmask32(2 * sizeof(ushort)) & Sse2.movemask_epi8(Sse2.cmpeq_epi16(v, new ushort2(x)))) >> 1;
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 16;
            }
        }

        /// <summary>       Returns the index of the first occurence of a ushort value x in a ushort3 vector v. If no value in v is equal to x, this function returns 16.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(ushort3 v, ushort x)
        {
            if (Sse2.IsSse2Supported)
            {
                return math.tzcnt(bitmask32(3 * sizeof(ushort)) & Sse2.movemask_epi8(Sse2.cmpeq_epi16(v, new ushort3(x)))) >> 1;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 16;
            }
        }

        /// <summary>       Returns the index of the first occurence of a ushort value x in a ushort4 vector v. If no value in v is equal to x, this function returns 16.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(ushort4 v, ushort x)
        {
            if (Sse2.IsSse2Supported)
            {
                return math.tzcnt(bitmask32(4 * sizeof(ushort)) & Sse2.movemask_epi8(Sse2.cmpeq_epi16(v, new ushort4(x)))) >> 1;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 16;
            }
        }

        /// <summary>       Returns the index of the first occurence of a ushort value x in a ushort2 vector v. If no value in v is equal to x, this function returns 16.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(ushort8 v, ushort x)
        {
            if (Sse2.IsSse2Supported)
            {
                return math.tzcnt(Sse2.movemask_epi8(Sse2.cmpeq_epi16(v, new ushort8(x)))) >> 1;
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 16;
            }
        }

        /// <summary>       Returns the index of the first occurence of a ushort value x in a ushort2 vector v. If no value in v is equal to x, this function returns 16.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(ushort16 v, ushort x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return math.tzcnt(Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi16(v, new ushort16(x)))) >> 1;
            }
            else if (Sse2.IsSse2Supported)
            {
                ushort8 broadcast = x;

                return math.tzcnt(Sse2.movemask_epi8(Sse2.cmpeq_epi16(v._v8_0, broadcast)) |
                                  (Sse2.movemask_epi8(Sse2.cmpeq_epi16(v._v8_8, broadcast)) << 16)) >> 1;
            }
            else
            {
                for (int i = 0; i < 16; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 16;
            }
        }


        /// <summary>       Returns the index of the first occurence of a short value x in a short2 vector v. If no value in v is equal to x, this function returns 16.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(short2 v, short x)
        {
            return indexof((ushort2)v, (ushort)x);
        }

        /// <summary>       Returns the index of the first occurence of a short value x in a short3 vector v. If no value in v is equal to x, this function returns 16.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(short3 v, short x)
        {
            return indexof((ushort3)v, (ushort)x);
        }

        /// <summary>       Returns the index of the first occurence of a short value x in a short4 vector v. If no value in v is equal to x, this function returns 16.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(short4 v, short x)
        {
            return indexof((ushort4)v, (ushort)x);
        }

        /// <summary>       Returns the index of the first occurence of a short value x in a short8 vector v. If no value in v is equal to x, this function returns 16.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(short8 v, short x)
        {
            return indexof((ushort8)v, (ushort)x);
        }

        /// <summary>       Returns the index of the first occurence of a short value x in a short16 vector v. If no value in v is equal to x, this function returns 16.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(short16 v, short x)
        {
            return indexof((ushort16)v, (ushort)x);
        }


        /// <summary>       Returns the index of the first occurence of a uint value x in a uint2 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(uint2 v, uint x)
        {
            if (Sse2.IsSse2Supported)
            {
                return math.tzcnt(bitmask32(2 * sizeof(uint)) & Sse.movemask_ps(Sse2.cmpeq_epi32(*(v128*)&v, new v128(x))));
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }

        /// <summary>       Returns the index of the first occurence of a uint value x in a uint3 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(uint3 v, uint x)
        {
            if (Sse2.IsSse2Supported)
            {
                return math.tzcnt(bitmask32(3 * sizeof(uint)) & Sse.movemask_ps(Sse2.cmpeq_epi32(*(v128*)&v, new v128(x))));
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }

        /// <summary>       Returns the index of the first occurence of a uint value x in a uint4 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(uint4 v, uint x)
        {
            if (Sse2.IsSse2Supported)
            {
                return math.tzcnt(Sse.movemask_ps(Sse2.cmpeq_epi32(*(v128*)&v, new v128(x))));
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }

        /// <summary>       Returns the index of the first occurence of a uint value x in a uint2 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(uint8 v, uint x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return math.tzcnt(Avx.mm256_movemask_ps(Avx2.mm256_cmpeq_epi32(v, new uint8(x))));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 broadcast = new v128(x);

                return math.tzcnt(Sse.movemask_ps(Sse2.cmpeq_epi32(*(v128*)&v._v4_0, broadcast)) |
                                  (Sse.movemask_ps(Sse2.cmpeq_epi32(*(v128*)&v._v4_4, broadcast)) << 4));
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }


        /// <summary>       Returns the index of the first occurence of an int value x in an int2 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(int2 v, int x)
        {
            return indexof((uint2)v, (uint)x);
        }

        /// <summary>       Returns the index of the first occurence of an int value x in an int3 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(int3 v, int x)
        {
            return indexof((uint3)v, (uint)x);
        }

        /// <summary>       Returns the index of the first occurence of an int value x in an int4 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(int4 v, int x)
        {
            return indexof((uint4)v, (uint)x);
        }

        /// <summary>       Returns the index of the first occurence of an int value x in an int8 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(int8 v, int x)
        {
            return indexof((uint8)v, (uint)x);
        }


        /// <summary>       Returns the index of the first occurence of a ulong value x in a ulong2 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long indexof(ulong2 v, ulong x)
        {
            if (Sse2.IsSse2Supported)
            {
                return math.tzcnt(Sse2.movemask_pd(Operator.equals_mask_long(v, new v128(x))));
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }

        /// <summary>       Returns the index of the first occurence of a ulong value x in a ulong3 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long indexof(ulong3 v, ulong x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return math.tzcnt(bitmask32(3 * sizeof(ulong)) & Avx.mm256_movemask_pd(Avx2.mm256_cmpeq_epi64(v, new ulong3(x))));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 broadcast = new v128(x);

                return math.tzcnt(Sse2.movemask_pd(Operator.equals_mask_long(v._xy, broadcast)) |
                                  (toint32(v.z == x) << 2));
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }

        /// <summary>       Returns the index of the first occurence of a ulong value x in a ulong4 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long indexof(ulong4 v, ulong x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return math.tzcnt(Avx.mm256_movemask_pd(Avx2.mm256_cmpeq_epi64(v, new ulong4(x))));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 broadcast = new v128(x);

                return math.tzcnt(Sse2.movemask_pd(Operator.equals_mask_long(v._xy, broadcast)) |
                                  (Sse2.movemask_pd(Operator.equals_mask_long(v._zw, broadcast)) << 2));
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }


        /// <summary>       Returns the index of the first occurence of a long value x in a long2 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long indexof(long2 v, long x)
        {
            return indexof((ulong2)v, (ulong)x);
        }

        /// <summary>       Returns the index of the first occurence of a long value x in a long3 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long indexof(long3 v, long x)
        {
            return indexof((ulong3)v, (ulong)x);
        }

        /// <summary>       Returns the index of the first occurence of a long value x in a long4 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long indexof(long4 v, long x)
        {
            return indexof((ulong4)v, (ulong)x);
        }


        /// <summary>       Returns the index of the first occurence of a float value x in a float2 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(float2 v, float x)
        {
            if (Sse.IsSseSupported)
            {
                return math.tzcnt(bitmask32(2 * sizeof(float)) & Sse.movemask_ps(Sse.cmpeq_ps(*(v128*)&v, new v128(x))));
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }

        /// <summary>       Returns the index of the first occurence of a float value x in a float3 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(float3 v, float x)
        {
            if (Sse.IsSseSupported)
            {
                return math.tzcnt(bitmask32(3 * sizeof(float)) & Sse.movemask_ps(Sse.cmpeq_ps(*(v128*)&v, new v128(x))));
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }

        /// <summary>       Returns the index of the first occurence of a float value x in a float4 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(float4 v, float x)
        {
            if (Sse.IsSseSupported)
            {
                return math.tzcnt(Sse.movemask_ps(Sse.cmpeq_ps(*(v128*)&v, new v128(x))));
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }

        /// <summary>       Returns the index of the first occurence of a float value x in a float2 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int indexof(float8 v, float x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return math.tzcnt(Avx.mm256_movemask_ps(Avx.mm256_cmp_ps(v, new float8(x), (int)Avx.CMP.EQ_OQ)));
            }
            else if (Sse.IsSseSupported)
            {
                v128 broadcast = new v128(x);

                return math.tzcnt(Sse.movemask_ps(Sse.cmpeq_ps(*(v128*)&v._v4_0, broadcast)) |
                                  (Sse.movemask_ps(Sse.cmpeq_ps(*(v128*)&v._v4_4, broadcast)) << 4));
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }


        /// <summary>       Returns the index of the first occurence of a double value x in a double2 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long indexof(double2 v, double x)
        {
            if (Sse2.IsSse2Supported)
            {
                return math.tzcnt(Sse2.movemask_pd(Sse2.cmpeq_pd(*(v128*)&v, new v128(x))));
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }

        /// <summary>       Returns the index of the first occurence of a double value x in a double3 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long indexof(double3 v, double x)
        {
            if (Avx.IsAvxSupported)
            {
                return math.tzcnt(bitmask32(3 * sizeof(double)) & Avx.mm256_movemask_pd(Avx.mm256_cmp_pd(*(v256*)&v, new v256(x), (int)Avx.CMP.EQ_OQ)));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 broadcast = new v128(x);
                double2 _xy = v.xy;

                return math.tzcnt(Sse2.movemask_pd(Sse2.cmpeq_pd(*(v128*)&_xy, broadcast)) |
                                  (toint32(v.z == x) << 2));
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }

        /// <summary>       Returns the index of the first occurence of a double value x in a double4 vector v. If no value in v is equal to x, this function returns 32.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long indexof(double4 v, double x)
        {
            if (Avx.IsAvxSupported)
            {
                return math.tzcnt(Avx.mm256_movemask_pd(Avx.mm256_cmp_pd(*(v256*)&v, new v256(x), (int)Avx.CMP.EQ_OQ)));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 broadcast = new v128(x);
                double2 _xy = v.xy;
                double2 _zw = v.zw;

                return math.tzcnt(Sse2.movemask_pd(Sse2.cmpeq_pd(*(v128*)&_xy, broadcast)) |
                                  (Sse2.movemask_pd(Sse2.cmpeq_pd(*(v128*)&_zw, broadcast)) << 2));
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (v[i] == x)
                    {
                        return i;
                    }
                    else continue;
                }

                return 32;
            }
        }
    }
}