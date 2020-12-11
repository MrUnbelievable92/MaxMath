using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static byte select(byte a, byte b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static byte2 select(byte2 a, byte2 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static byte3 select(byte3 a, byte3 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static byte4 select(byte4 a, byte4 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static byte8 select(byte8 a, byte8 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static byte16 select(byte16 a, byte16 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static byte32 select(byte32 a, byte32 b, bool c)
        {
            return c ? b : a;
        }


        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static sbyte select(sbyte a, sbyte b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static sbyte2 select(sbyte2 a, sbyte2 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static sbyte3 select(sbyte3 a, sbyte3 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static sbyte4 select(sbyte4 a, sbyte4 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static sbyte8 select(sbyte8 a, sbyte8 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static sbyte16 select(sbyte16 a, sbyte16 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static sbyte32 select(sbyte32 a, sbyte32 b, bool c)
        {
            return c ? b : a;
        }


        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static ushort select(ushort a, ushort b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static ushort2 select(ushort2 a, ushort2 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static ushort3 select(ushort3 a, ushort3 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static ushort4 select(ushort4 a, ushort4 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static ushort8 select(ushort8 a, ushort8 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static ushort16 select(ushort16 a, ushort16 b, bool c)
        {
            return c ? b : a;
        }


        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static short select(short a, short b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static short2 select(short2 a, short2 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static short3 select(short3 a, short3 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static short4 select(short4 a, short4 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static short8 select(short8 a, short8 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static short16 select(short16 a, short16 b, bool c)
        {
            return c ? b : a;
        }


        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static int8 select(int8 a, int8 b, bool c)
        {
            return c ? b : a;
        }


        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static uint8 select(uint8 a, uint8 b, bool c)
        {
            return c ? b : a;
        }


        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static float8 select(float8 a, float8 b, bool c)
        {
            return c ? b : a;
        }


        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static long2 select(long2 a, long2 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static long3 select(long3 a, long3 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static long4 select(long4 a, long4 b, bool c)
        {
            return c ? b : a;
        }


        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static ulong2 select(ulong2 a, ulong2 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static ulong3 select(ulong3 a, ulong3 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        public static ulong4 select(ulong4 a, ulong4 b, bool c)
        {
            return c ? b : a;
        }


        /// <summary>       Returns a componentwise selection between two byte2 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 select(byte2 a, byte2 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, Mask.V2FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two byte3 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 select(byte3 a, byte3 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, Mask.V3FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two byte3 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 select(byte4 a, byte4 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, Mask.V4FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two byte8 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 select(byte8 a, byte8 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, Mask.V8FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two byte16 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 select(byte16 a, byte16 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, Mask.V16FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two byte32 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 select(byte32 a, byte32 b, int c)
        {
            return Avx2.mm256_blendv_epi8(a, b, Mask.V32FromInt(c));
        }


        /// <summary>       Returns a componentwise selection between two sbyte2 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 select(sbyte2 a, sbyte2 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, Mask.V2FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two sbyte3 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 select(sbyte3 a, sbyte3 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, Mask.V3FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two sbyte3 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 select(sbyte4 a, sbyte4 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, Mask.V4FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two sbyte8 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 select(sbyte8 a, sbyte8 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, Mask.V8FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two sbyte16 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 select(sbyte16 a, sbyte16 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, Mask.V16FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two sbyte32 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 select(sbyte32 a, sbyte32 b, int c)
        {
            return Avx2.mm256_blendv_epi8(a, b, Mask.V32FromInt(c));
        }


        /// <summary>       Returns a componentwise selection between two ushort2 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 select(ushort2 a, ushort2 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, (short2)Mask.V2FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two ushort3 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 select(ushort3 a, ushort3 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, (short3)Mask.V3FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two ushort4 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 select(ushort4 a, ushort4 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, (short4)Mask.V4FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two ushort8 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 select(ushort8 a, ushort8 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, (short8)Mask.V8FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two ushort16 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 select(ushort16 a, ushort16 b, int c)
        {
            return Avx2.mm256_blendv_epi8(a, b, (short16)Mask.V16FromInt(c));
        }


        /// <summary>       Returns a componentwise selection between two short2 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 select(short2 a, short2 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, (short2)Mask.V2FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two short3 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 select(short3 a, short3 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, (short3)Mask.V3FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two short4 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 select(short4 a, short4 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, (short4)Mask.V4FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two short8 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 select(short8 a, short8 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, (short8)Mask.V8FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two short16 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 select(short16 a, short16 b, int c)
        {
            return Avx2.mm256_blendv_epi8(a, b, (short16)Mask.V16FromInt(c));
        }


        /// <summary>       Returns a componentwise selection between two int2 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 select(int2 a, int2 b, int c)
        {
            v128 temp = Sse4_1.blendv_epi8(*(v128*)&a, *(v128*)&b, Sse4_1.cvtepi8_epi32(Mask.V2FromInt(c)));

            return *(int2*)&temp;
        }

        /// <summary>       Returns a componentwise selection between two int3 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 select(int3 a, int3 b, int c)
        {
            v128 temp = Sse4_1.blendv_epi8(*(v128*)&a, *(v128*)&b, Sse4_1.cvtepi8_epi32(Mask.V3FromInt(c)));

            return *(int3*)&temp;
        }

        /// <summary>       Returns a componentwise selection between two int4 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 select(int4 a, int4 b, int c)
        {
            v128 temp = Sse4_1.blendv_epi8(*(v128*)&a, *(v128*)&b, Sse4_1.cvtepi8_epi32(Mask.V4FromInt(c)));

            return *(int4*)&temp;
        }

        /// <summary>       Returns a componentwise selection between two int8 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 select(int8 a, int8 b, int c)
        {
            return Avx2.mm256_blendv_epi8(a, b, (int8)Mask.V8FromInt(c));
        }


        /// <summary>       Returns a componentwise selection between two uint2 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 select(uint2 a, uint2 b, int c)
        {
            v128 temp = Sse4_1.blendv_epi8(*(v128*)&a, *(v128*)&b, Sse4_1.cvtepi8_epi32(Mask.V2FromInt(c)));

            return *(uint2*)&temp;
        }

        /// <summary>       Returns a componentwise selection between two uint3 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 select(uint3 a, uint3 b, int c)
        {
            v128 temp = Sse4_1.blendv_epi8(*(v128*)&a, *(v128*)&b, Sse4_1.cvtepi8_epi32(Mask.V3FromInt(c)));

            return *(uint3*)&temp;
        }

        /// <summary>       Returns a componentwise selection between two uint4 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 select(uint4 a, uint4 b, int c)
        {
            v128 temp = Sse4_1.blendv_epi8(*(v128*)&a, *(v128*)&b, Sse4_1.cvtepi8_epi32(Mask.V4FromInt(c)));

            return *(uint4*)&temp;
        }

        /// <summary>       Returns a componentwise selection between two uint8 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 select(uint8 a, uint8 b, int c)
        {
            return Avx2.mm256_blendv_epi8(a, b, (int8)Mask.V8FromInt(c));
        }


        /// <summary>       Returns a componentwise selection between two long2 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 select(long2 a, long2 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, (long2)Mask.V2FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two long3 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 select(long3 a, long3 b, int c)
        {
            return Avx2.mm256_blendv_epi8(a, b, (long3)Mask.V3FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two long4 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 select(long4 a, long4 b, int c)
        {
            return Avx2.mm256_blendv_epi8(a, b, (long4)Mask.V4FromInt(c));
        }


        /// <summary>       Returns a componentwise selection between two ulong2 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 select(ulong2 a, ulong2 b, int c)
        {
            return Sse4_1.blendv_epi8(a, b, (long2)Mask.V2FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two ulong3 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 select(ulong3 a, ulong3 b, int c)
        {
            return Avx2.mm256_blendv_epi8(a, b, (long3)Mask.V3FromInt(c));
        }

        /// <summary>       Returns a componentwise selection between two ulong4 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 select(ulong4 a, ulong4 b, int c)
        {
            return Avx2.mm256_blendv_epi8(a, b, (long4)Mask.V4FromInt(c));
        }


        /// <summary>       Returns a componentwise selection between two double2 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 select(double2 a, double2 b, int c)
        {
            v128 temp = Sse4_1.blendv_pd(*(v128*)&a, *(v128*)&b, (long2)Mask.V2FromInt(c));

            return *(double2*)&temp;
        }

        /// <summary>       Returns a componentwise selection between two double3 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 select(double3 a, double3 b, int c)
        {
            v256 temp = Avx.mm256_blendv_pd(*(v256*)&a, *(v256*)&b, (long3)Mask.V3FromInt(c));

            return *(double3*)&temp;
        }

        /// <summary>       Returns a componentwise selection between two double4 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 select(double4 a, double4 b, int c)
        {
            v256 temp = Avx.mm256_blendv_pd(*(v256*)&a, *(v256*)&b, (long4)Mask.V4FromInt(c));

            return *(double4*)&temp;
        }
        /// <summary>       Returns a componentwise selection between two float2 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 select(float2 a, float2 b, int c)
        {
            v128 temp = Sse4_1.blendv_ps(*(v128*)&a, *(v128*)&b, Sse4_1.cvtepi8_epi32(Mask.V2FromInt(c)));

            return *(float2*)&temp;
        }

        /// <summary>       Returns a componentwise selection between two float3 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 select(float3 a, float3 b, int c)
        {
            v128 temp = Sse4_1.blendv_ps(*(v128*)&a, *(v128*)&b, Sse4_1.cvtepi8_epi32(Mask.V3FromInt(c)));

            return *(float3*)&temp;
        }

        /// <summary>       Returns a componentwise selection between two float4 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 select(float4 a, float4 b, int c)
        {
            v128 temp = Sse4_1.blendv_ps(*(v128*)&a, *(v128*)&b, Sse4_1.cvtepi8_epi32(Mask.V4FromInt(c)));

            return *(float4*)&temp;
        }

        /// <summary>       Returns a componentwise selection between two float8 vectors a and b based on a bitmask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 select(float8 a, float8 b, int c)
        {
            return Avx.mm256_blendv_ps(a, b, (int8)Mask.V8FromInt(c));
        }


        /// <summary>       Returns a componentwise selection between two byte2 vectors a and b based on a bool2 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 select(byte2 a, byte2 b, bool2 c)
        {
            return Sse4_1.blendv_epi8(b, a, Sse2.cmpeq_epi8(*(v128*)&c, default(v128)));
        }

        /// <summary>       Returns a componentwise selection between two byte2 vectors a and b based on a bool3 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 select(byte3 a, byte3 b, bool3 c)
        {
            return Sse4_1.blendv_epi8(b, a, Sse2.cmpeq_epi8(*(v128*)&c, default(v128)));
        }

        /// <summary>       Returns a componentwise selection between two byte4 vectors a and b based on a bool4 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 select(byte4 a, byte4 b, bool4 c)
        {
            return Sse4_1.blendv_epi8(b, a, Sse2.cmpeq_epi8(*(v128*)&c, default(v128)));
        }

        /// <summary>       Returns a componentwise selection between two byte8 vectors a and b based on a bool8 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 select(byte8 a, byte8 b, bool8 c)
        {
            return Sse4_1.blendv_epi8(b, a, Sse2.cmpeq_epi8(c, default(v128)));
        }

        /// <summary>       Returns a componentwise selection between two byte16 vectors a and b based on a bool16 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 select(byte16 a, byte16 b, bool16 c)
        {
            return Sse4_1.blendv_epi8(b, a, Sse2.cmpeq_epi8(c, default(v128)));
        }

        /// <summary>       Returns a componentwise selection between two byte32 vectors a and b based on a bool32 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 select(byte32 a, byte32 b, bool32 c)
        {
            return Avx2.mm256_blendv_epi8(b, a, Avx2.mm256_cmpeq_epi8(c, default(v256)));
        }


        /// <summary>       Returns a componentwise selection between two sbyte2 vectors a and b based on a bool2 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 select(sbyte2 a, sbyte2 b, bool2 c)
        {
            return Sse4_1.blendv_epi8(b, a, Sse2.cmpeq_epi8(*(v128*)&c, default(v128)));
        }

        /// <summary>       Returns a componentwise selection between two sbyte2 vectors a and b based on a bool3 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 select(sbyte3 a, sbyte3 b, bool3 c)
        {
            return Sse4_1.blendv_epi8(b, a, Sse2.cmpeq_epi8(*(v128*)&c, default(v128)));
        }

        /// <summary>       Returns a componentwise selection between two sbyte4 vectors a and b based on a bool4 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 select(sbyte4 a, sbyte4 b, bool4 c)
        {
            return Sse4_1.blendv_epi8(b, a, Sse2.cmpeq_epi8(*(v128*)&c, default(v128)));
        }

        /// <summary>       Returns a componentwise selection between two sbyte8 vectors a and b based on a bool8 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 select(sbyte8 a, sbyte8 b, bool8 c)
        {
            return Sse4_1.blendv_epi8(b, a, Sse2.cmpeq_epi8(c, default(v128)));
        }

        /// <summary>       Returns a componentwise selection between two sbyte16 vectors a and b based on a bool16 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 select(sbyte16 a, sbyte16 b, bool16 c)
        {
            return Sse4_1.blendv_epi8(b, a, Sse2.cmpeq_epi8(c, default(v128)));
        }

        /// <summary>       Returns a componentwise selection between two sbyte32 vectors a and b based on a bool32 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 select(sbyte32 a, sbyte32 b, bool32 c)
        {
            return Avx2.mm256_blendv_epi8(b, a, Avx2.mm256_cmpeq_epi8(c, default(v256)));
        }


        /// <summary>       Returns a componentwise selection between two ushort2 vectors a and b based on a bool2 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 select(ushort2 a, ushort2 b, bool2 c)
        {
            return Sse4_1.blendv_epi8(b, a, (short2)((sbyte2)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
        }

        /// <summary>       Returns a componentwise selection between two ushort3 vectors a and b based on a bool3 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 select(ushort3 a, ushort3 b, bool3 c)
        {
            return Sse4_1.blendv_epi8(b, a, (short3)((sbyte3)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
        }

        /// <summary>       Returns a componentwise selection between two ushort4 vectors a and b based on a bool4 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 select(ushort4 a, ushort4 b, bool4 c)
        {
            return Sse4_1.blendv_epi8(b, a, (short4)((sbyte4)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
        }

        /// <summary>       Returns a componentwise selection between two ushort8 vectors a and b based on a bool8 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 select(ushort8 a, ushort8 b, bool8 c)
        {
            return Sse4_1.blendv_epi8(b, a, (short8)((sbyte8)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
        }

        /// <summary>       Returns a componentwise selection between two ushort16 vectors a and b based on a bool16 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 select(ushort16 a, ushort16 b, bool16 c)
        {
            return Avx2.mm256_blendv_epi8(b, a, (short16)((sbyte16)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
        }

        
        /// <summary>       Returns a componentwise selection between two short2 vectors a and b based on a bool2 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 select(short2 a, short2 b, bool2 c)
        {
            return Sse4_1.blendv_epi8(b, a, (short2)((sbyte2)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
        }

        /// <summary>       Returns a componentwise selection between two short3 vectors a and b based on a bool3 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 select(short3 a, short3 b, bool3 c)
        {
            return Sse4_1.blendv_epi8(b, a, (short3)((sbyte3)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
        }

        /// <summary>       Returns a componentwise selection between two short4 vectors a and b based on a bool4 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 select(short4 a, short4 b, bool4 c)
        {
            return Sse4_1.blendv_epi8(b, a, (short4)((sbyte4)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
        }

        /// <summary>       Returns a componentwise selection between two short8 vectors a and b based on a bool8 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 select(short8 a, short8 b, bool8 c)
        {
            return Sse4_1.blendv_epi8(b, a, (short8)((sbyte8)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
        }

        /// <summary>       Returns a componentwise selection between two short16 vectors a and b based on a bool16 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 select(short16 a, short16 b, bool16 c)
        {
            return Avx2.mm256_blendv_epi8(b, a, (short16)((sbyte16)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
        }


        /// <summary>       Returns a componentwise selection between two int8 vectors a and b based on a bool8 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 select(int8 a, int8 b, bool8 c)
        {
            return Avx2.mm256_blendv_epi8(b, a, (int8)((sbyte8)Sse2.cmpeq_epi8(c, default(v128))));
        }


        /// <summary>       Returns a componentwise selection between two uint8 vectors a and b based on a bool8 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 select(uint8 a, uint8 b, bool8 c)
        {
            return Avx2.mm256_blendv_epi8(b, a, (int8)((sbyte8)Sse2.cmpeq_epi8(c, default(v128))));
        }


        /// <summary>       Returns a componentwise selection between two long2 vectors a and b based on a bool2 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 select(long2 a, long2 b, bool2 c)
        {
            return Sse4_1.blendv_epi8(b, a, (long2)((sbyte2)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
        }

        /// <summary>       Returns a componentwise selection between two long3 vectors a and b based on a bool3 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 select(long3 a, long3 b, bool3 c)
        {
            return Avx2.mm256_blendv_epi8(b, a, (long3)((sbyte3)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
        }

        /// <summary>       Returns a componentwise selection between two long4 vectors a and b based on a bool4 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 select(long4 a, long4 b, bool4 c)
        {
            return Avx2.mm256_blendv_epi8(b, a, (long4)((sbyte4)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
        }


        /// <summary>       Returns a componentwise selection between two ulong2 vectors a and b based on a bool2 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 select(ulong2 a, ulong2 b, bool2 c)
        {
            return Sse4_1.blendv_epi8(b, a, (long2)((sbyte2)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
        }

        /// <summary>       Returns a componentwise selection between two ulong3 vectors a and b based on a bool3 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 select(ulong3 a, ulong3 b, bool3 c)
        {
            return Avx2.mm256_blendv_epi8(b, a, (long3)((sbyte3)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
        }

        /// <summary>       Returns a componentwise selection between two ulong4 vectors a and b based on a bool4 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 select(ulong4 a, ulong4 b, bool4 c)
        {
            return Avx2.mm256_blendv_epi8(b, a, (long4)((sbyte4)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
        }

        
        /// <summary>       Returns a componentwise selection between two float8 vectors a and b based on a bool8 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 select(float8 a, float8 b, bool8 c)
        {
            return Avx.mm256_blendv_ps(b, a, (int8)((sbyte8)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
        }
    }
}