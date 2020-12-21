using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 shl(int2 x, int2 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

                return *(int2*)&temp;
            }
            else
            {
                return new int2(x.x << n.x, x.y << n.y);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 shl(int3 x, int3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

                return *(int3*)&temp;
            }
            else
            {
                return new int3(x.x << n.x, x.y << n.y, x.z << n.z);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 shl(int4 x, int4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

                return *(int4*)&temp;
            }
            else
            {
                return new int4(x.x << n.x, x.y << n.y, x.z << n.z, x.w << n.w);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 shl(int8 x, int8 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sllv_epi32(x, n);
            }
            else
            {
                return new int8(x.x0 << n.x0, x.x1 << n.x1, x.x2 << n.x2, x.x3 << n.x3, x.x4 << n.x4, x.x5 << n.x5, x.x6 << n.x6, x.x7 << n.x7);
            }
        }


        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 shl(uint2 x, uint2 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

                return *(uint2*)&temp;
            }
            else
            {
                return new uint2(x.x << (int)n.x, x.y << (int)n.y);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 shl(uint3 x, uint3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

                return *(uint3*)&temp;
            }
            else
            {
                return new uint3(x.x << (int)n.x, x.y << (int)n.y, x.z << (int)n.z);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 shl(uint4 x, uint4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

                return *(uint4*)&temp;
            }
            else
            {
                return new uint4(x.x << (int)n.x, x.y << (int)n.y, x.z << (int)n.z, x.w << (int)n.w);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 shl(uint8 x, uint8 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sllv_epi32(x, n);
            }
            else
            {
                return new uint8(x.x0 << (int)n.x0, x.x1 << (int)n.x1, x.x2 << (int)n.x2, x.x3 << (int)n.x3, x.x4 << (int)n.x4, x.x5 << (int)n.x5, x.x6 << (int)n.x6, x.x7 << (int)n.x7);
            }
        }


        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 shl(uint2 x, int2 n)
        {
            return shl(x, (uint2)n);
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 shl(uint3 x, int3 n)
        {
            return shl(x, (uint3)n);
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 shl(uint4 x, int4 n)
        {
            return shl(x, (uint4)n);
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 shl(uint8 x, int8 n)
        {
            return shl(x, (uint8)n);
        }


        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shl(long2 x, long2 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.sllv_epi64(x, n);
            }
            else
            {
                return new long2(x.x << (int)n.x, x.y << (int)n.y);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shl(long3 x, long3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sllv_epi64(x, n);
            }
            else
            {
                return new long3(x.x << (int)n.x, x.y << (int)n.y, x.z << (int)n.z);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shl(long4 x, long4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sllv_epi64(x, n);
            }
            else
            {
                return new long4(x.x << (int)n.x, x.y << (int)n.y, x.z << (int)n.z, x.w << (int)n.w);
            }
        }


        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shl(ulong2 x, ulong2 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.sllv_epi64(x, n);
            }
            else
            {
                return new ulong2(x.x << (int)n.x, x.y << (int)n.y);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shl(ulong3 x, ulong3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sllv_epi64(x, n);
            }
            else
            {
                return new ulong3(x.x << (int)n.x, x.y << (int)n.y, x.z << (int)n.z);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shl(ulong4 x, ulong4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sllv_epi64(x, n);
            }
            else
            {
                return new ulong4(x.x << (int)n.x, x.y << (int)n.y, x.z << (int)n.z, x.w << (int)n.w);
            }
        }


        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shl(ulong2 x, long2 n)
        {
            return shl(x, (ulong2)n);
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shl(ulong3 x, long3 n)
        {
            return shl(x, (ulong3)n);
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shl(ulong4 x, long4 n)
        {
            return shl(x, (ulong4)n);
        }


        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 shrl(int2 x, int2 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

                return *(int2*)&temp;
            }
            else
            {
                return (int2)new uint2((uint)x.x >> n.x, (uint)x.y >> n.y);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 shrl(int3 x, int3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

                return *(int3*)&temp;
            }
            else
            {
                return (int3)new uint3((uint)x.x >> n.x, (uint)x.y >> n.y, (uint)x.z >> n.z);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 shrl(int4 x, int4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

                return *(int4*)&temp;
            }
            else
            {
                return (int4)new uint4((uint)x.x >> n.x, (uint)x.y >> n.y, (uint)x.z >> n.z, (uint)x.w >> n.w);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 shrl(int8 x, int8 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srlv_epi32(x, n);
            }
            else
            {
                return (int8)new uint8((uint)x.x0 >> n.x0, (uint)x.x1 >> n.x1, (uint)x.x2 >> n.x2, (uint)x.x3 >> n.x3, (uint)x.x4 >> n.x4, (uint)x.x5 >> n.x5, (uint)x.x6 >> n.x6, (uint)x.x7 >> n.x7);
            }
        }


        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 shrl(uint2 x, uint2 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

                return *(uint2*)&temp;
            }
            else
            {
                return new uint2(x.x >> (int)n.x, x.y >> (int)n.y);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 shrl(uint3 x, uint3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

                return *(uint3*)&temp;
            }
            else
            {
                return new uint3(x.x >> (int)n.x, x.y >> (int)n.y, x.z >> (int)n.z);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 shrl(uint4 x, uint4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

                return *(uint4*)&temp;
            }
            else
            {
                return new uint4(x.x >> (int)n.x, x.y >> (int)n.y, x.z >> (int)n.z, x.w >> (int)n.w);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 shrl(uint8 x, uint8 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srlv_epi32(x, n);
            }
            else
            {
                return new uint8(x.x0 >> (int)n.x0, x.x1 >> (int)n.x1, x.x2 >> (int)n.x2, x.x3 >> (int)n.x3, x.x4 >> (int)n.x4, x.x5 >> (int)n.x5, x.x6 >> (int)n.x6, x.x7 >> (int)n.x7);
            }
        }


        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 shrl(uint2 x, int2 n)
        {
            return shrl(x, (uint2)n);
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 shrl(uint3 x, int3 n)
        {
            return shrl(x, (uint3)n);
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 shrl(uint4 x, int4 n)
        {
            return shrl(x, (uint4)n);
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 shrl(uint8 x, int8 n)
        {
            return shrl(x, (uint8)n);
        }


        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shrl(long2 x, long2 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.srlv_epi64(x, n);
            }
            else
            {
                return (long2)new ulong2((ulong)x.x >> (int)n.x, (ulong)x.y >> (int)n.y);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shrl(long3 x, long3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srlv_epi64(x, n);
            }
            else
            {
                return (long3)new ulong3((ulong)x.x >> (int)n.x, (ulong)x.y >> (int)n.y, (ulong)x.z >> (int)n.z);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shrl(long4 x, long4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srlv_epi64(x, n);
            }
            else
            {
                return (long4)new ulong4((ulong)x.x >> (int)n.x, (ulong)x.y >> (int)n.y, (ulong)x.z >> (int)n.z, (ulong)x.w >> (int)n.w);
            }
        }


        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shrl(ulong2 x, ulong2 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.srlv_epi64(x, n);
            }
            else
            {
                return new ulong2(x.x >> (int)n.x, x.y >> (int)n.y);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shrl(ulong3 x, ulong3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srlv_epi64(x, n);
            }
            else
            {
                return new ulong3(x.x >> (int)n.x, x.y >> (int)n.y, x.z >> (int)n.z);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shrl(ulong4 x, ulong4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srlv_epi64(x, n);
            }
            else
            {
                return new ulong4(x.x >> (int)n.x, x.y >> (int)n.y, x.z >> (int)n.z, x.w >> (int)n.w);
            }
        }


        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shrl(ulong2 x, long2 n)
        {
            return shrl(x, (ulong2)n);
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shrl(ulong3 x, long3 n)
        {
            return shrl(x, (ulong3)n);
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shrl(ulong4 x, long4 n)
        {
            return shrl(x, (ulong4)n);
        }


        /// <summary>       Returns the result of a componentwise bitshift right (arithmetic) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 shra(int2 x, int2 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Avx2.srav_epi32(*(v128*)&x, *(v128*)&n);

                return *(int2*)&temp;
            }
            else
            {
                return new int2(x.x >> n.x, x.y >> n.y);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift right (arithmetic) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 shra(int3 x, int3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Avx2.srav_epi32(*(v128*)&x, *(v128*)&n);

                return *(int3*)&temp;
            }
            else
            {
                return new int3(x.x >> n.x, x.y >> n.y, x.z >> n.z);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift right (arithmetic) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 shra(int4 x, int4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Avx2.srav_epi32(*(v128*)&x, *(v128*)&n);

                return *(int4*)&temp;
            }
            else
            {
                return new int4(x.x >> n.x, x.y >> n.y, x.z >> n.z, x.w >> n.w);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift right (arithmetic) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 shra(int8 x, int8 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srav_epi32(x, n);
            }
            else
            {
                return new int8(x.x0 >> n.x0, x.x1 >> n.x1, x.x2 >> n.x2, x.x3 >> n.x3, x.x4 >> n.x4, x.x5 >> n.x5, x.x6 >> n.x6, x.x7 >> n.x7);
            }
        }


        /// <summary>       Returns the result of a componentwise bitshift right (arithmetic) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shra(long2 x, long2 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                long2 mask = Sse2.and_si128(Sse4_2.cmpgt_epi64(n, default(v128)),
                                            Sse4_2.cmpgt_epi64(default(v128), x));

                mask = Avx2.sllv_epi64(mask, (64L - n));

                return mask | Avx2.srlv_epi64(x, n);
            }
            else
            {
                return new long2(x.x >> (int)n.x, x.y >> (int)n.y);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift right (arithmetic) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shra(long3 x, long3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                long3 mask = Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi64(n, default(v256)),
                                                  Avx2.mm256_cmpgt_epi64(default(v256), x));

                mask = Avx2.mm256_sllv_epi64(mask, (64L - n));

                return mask | Avx2.mm256_srlv_epi64(x, n);
            }
            else
            {
                return new long3(x.x >> (int)n.x, x.y >> (int)n.y, x.z >> (int)n.z);
            }
        }

        /// <summary>       Returns the result of a componentwise bitshift right (arithmetic) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shra(long4 x, long4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                long4 mask = Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi64(n, default(v256)),
                                                  Avx2.mm256_cmpgt_epi64(default(v256), x));

                mask = Avx2.mm256_sllv_epi64(mask, (64L - n));

                return mask | Avx2.mm256_srlv_epi64(x, n);
            }
            else
            {
                return new long4(x.x >> (int)n.x, x.y >> (int)n.y, x.z >> (int)n.z, x.w >> (int)n.w);
            }
        }
    }
}