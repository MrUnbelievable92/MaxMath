using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <see langword="true" /> if an <see cref="UInt128"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="UInt128"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(UInt128 x, UInt128 min, UInt128 max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns <see langword="true" /> if an <see cref="Int128"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="Int128"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(Int128 x, Int128 min, Int128 max)
        {
            return x >= min & x <= max;
        }


        /// <summary>       Returns <see langword="true" /> if an <see cref="byte"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="byte"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(byte x, byte min, byte max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="MaxMath.byte2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.byte2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(byte2 x, byte2 min, byte2 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="MaxMath.byte3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.byte3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(byte3 x, byte3 min, byte3 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="MaxMath.byte4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.byte4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(byte4 x, byte4 min, byte4 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.byte8"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.byte8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinrange(byte8 x, byte8 min, byte8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> indicating for each component of a <see cref="MaxMath.byte16"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.byte16"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isinrange(byte16 x, byte16 min, byte16 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="MaxMath.bool32"/> indicating for each component of a <see cref="MaxMath.byte32"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.byte32"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 isinrange(byte32 x, byte32 min, byte32 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary>       Returns <see langword="true" /> if an <see cref="sbyte"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="sbyte"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(sbyte x, sbyte min, sbyte max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of an <see cref="MaxMath.sbyte2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.sbyte2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(sbyte2 x, sbyte2 min, sbyte2 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of an <see cref="MaxMath.sbyte3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.sbyte3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(sbyte3 x, sbyte3 min, sbyte3 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of an <see cref="MaxMath.sbyte4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.sbyte4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(sbyte4 x, sbyte4 min, sbyte4 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of an <see cref="MaxMath.sbyte8"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.sbyte8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinrange(sbyte8 x, sbyte8 min, sbyte8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> indicating for each component of an <see cref="MaxMath.sbyte16"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.sbyte16"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isinrange(sbyte16 x, sbyte16 min, sbyte16 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="MaxMath.bool32"/> indicating for each component of an <see cref="MaxMath.sbyte32"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.sbyte32"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 isinrange(sbyte32 x, sbyte32 min, sbyte32 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary>       Returns <see langword="true" /> if an <see cref="short"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="short"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(short x, short min, short max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="MaxMath.short2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.short2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(short2 x, short2 min, short2 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="MaxMath.short3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.short3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(short3 x, short3 min, short3 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="MaxMath.short4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.short4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(short4 x, short4 min, short4 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.short8"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.short8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinrange(short8 x, short8 min, short8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> indicating for each component of a <see cref="MaxMath.short16"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.short16"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isinrange(short16 x, short16 min, short16 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary>       Returns <see langword="true" /> if an <see cref="ushort"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="ushort"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(ushort x, ushort min, ushort max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="MaxMath.ushort2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.ushort2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(ushort2 x, ushort2 min, ushort2 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="MaxMath.ushort3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.ushort3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(ushort3 x, ushort3 min, ushort3 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="MaxMath.ushort4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.ushort4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(ushort4 x, ushort4 min, ushort4 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.ushort8"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.ushort8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinrange(ushort8 x, ushort8 min, ushort8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> indicating for each component of a <see cref="MaxMath.ushort16"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.ushort16"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isinrange(ushort16 x, ushort16 min, ushort16 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary>       Returns <see langword="true" /> if an <see cref="int"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="int"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(int x, int min, int max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of an <see cref="int2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="int2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(int2 x, int2 min, int2 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of an <see cref="int3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="int3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(int3 x, int3 min, int3 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of an <see cref="int4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="int4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(int4 x, int4 min, int4 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of an <see cref="MaxMath.int8"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.int8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinrange(int8 x, int8 min, int8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary>       Returns <see langword="true" /> if a <see cref="uint"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="uint"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(uint x, uint min, uint max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="uint2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="uint2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(uint2 x, uint2 min, uint2 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="uint3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="uint3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(uint3 x, uint3 min, uint3 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="uint4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="uint4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(uint4 x, uint4 min, uint4 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.uint8"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.uint8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinrange(uint8 x, uint8 min, uint8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary>       Returns <see langword="true" /> if a <see cref="long"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="long"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(long x, long min, long max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="MaxMath.long2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.long2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(long2 x, long2 min, long2 max)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ALL_ONES = Sse2.cmpeq_epi32(default(v128), default(v128));

                v128 cmpMin = Operator.greater_mask_long(min, x);
                cmpMin = Sse2.xor_si128(cmpMin, ALL_ONES);
                
                v128 cmpMax = Operator.greater_mask_long(x, max);
                    
                int toBool = ConvertToBool.IsTrue64(Sse2.andnot_si128(cmpMax, cmpMin));
                
                return *(bool2*)&toBool;
            }
            else
            {
                return new bool2(isinrange(x.x, min.x, max.x),
                                 isinrange(x.y, min.y, max.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="MaxMath.long3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.long3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(long3 x, long3 min, long3 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ALL_ONES = Avx2.mm256_cmpeq_epi32(default(v256), default(v256));

                v256 cmpMin = Avx2.mm256_cmpgt_epi64(min, x);
                cmpMin = Avx2.mm256_xor_si256(cmpMin, ALL_ONES);
                
                v256 cmpMax = Avx2.mm256_cmpgt_epi64(x, max);
                    
                int toBool = ConvertToBool.IsTrue64(Avx2.mm256_andnot_si256(cmpMax, cmpMin));
                
                return *(bool3*)&toBool;
            }
            else
            {
                return new bool3(isinrange(x.xy, min.xy, max.xy),
                                 isinrange(x.z, min.z, max.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="MaxMath.long4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.long4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(long4 x, long4 min, long4 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ALL_ONES = Avx2.mm256_cmpeq_epi32(default(v256), default(v256));

                v256 cmpMin = Avx2.mm256_cmpgt_epi64(min, x);
                cmpMin = Avx2.mm256_xor_si256(cmpMin, ALL_ONES);
                
                v256 cmpMax = Avx2.mm256_cmpgt_epi64(x, max);
                    
                int toBool = ConvertToBool.IsTrue64(Avx2.mm256_andnot_si256(cmpMax, cmpMin));
                
                return *(bool4*)&toBool;
            }
            else
            {
                return new bool4(isinrange(x.xy, min.xy, max.xy),
                                 isinrange(x.zw, min.zw, max.zw));
            }
        }


        /// <summary>       Returns <see langword="true" /> if a <see cref="ulong"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="ulong"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(ulong x, ulong min, ulong max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="MaxMath.ulong2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.ulong2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(ulong2 x, ulong2 min, ulong2 max)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ALL_ONES = Sse2.cmpeq_epi32(default(v128), default(v128));

                v128 cmpMin = Operator.greater_mask_ulong(min, x);
                cmpMin = Sse2.xor_si128(cmpMin, ALL_ONES);
                
                v128 cmpMax = Operator.greater_mask_ulong(x, max);
                    
                int toBool = ConvertToBool.IsTrue64(Sse2.andnot_si128(cmpMax, cmpMin));
                
                return *(bool2*)&toBool;
            }
            else
            {
                return new bool2(isinrange(x.x, min.x, max.x),
                                 isinrange(x.y, min.y, max.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="MaxMath.ulong3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.ulong3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(ulong3 x, ulong3 min, ulong3 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ALL_ONES = Avx2.mm256_cmpeq_epi32(default(v256), default(v256));

                v256 cmpMin = Operator.greater_mask_ulong(min, x);
                cmpMin = Avx2.mm256_xor_si256(cmpMin, ALL_ONES);
                
                v256 cmpMax = Operator.greater_mask_ulong(x, max);
                    
                int toBool = ConvertToBool.IsTrue64(Avx2.mm256_andnot_si256(cmpMax, cmpMin));
                
                return *(bool3*)&toBool;
            }
            else
            {
                return new bool3(isinrange(x.xy, min.xy, max.xy),
                                 isinrange(x.z, min.z, max.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="MaxMath.ulong4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.ulong4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(ulong4 x, ulong4 min, ulong4 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ALL_ONES = Avx2.mm256_cmpeq_epi32(default(v256), default(v256));

                v256 cmpMin = Operator.greater_mask_ulong(min, x);
                cmpMin = Avx2.mm256_xor_si256(cmpMin, ALL_ONES);
                
                v256 cmpMax = Operator.greater_mask_ulong(x, max);
                    
                int toBool = ConvertToBool.IsTrue64(Avx2.mm256_andnot_si256(cmpMax, cmpMin));
                
                return *(bool4*)&toBool;
            }
            else
            {
                return new bool4(isinrange(x.xy, min.xy, max.xy),
                                 isinrange(x.zw, min.zw, max.zw));
            }
        }


        /// <summary>       Returns <see langword="true" /> if a <see cref="float"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="float"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(float x, float min, float max)
        {
            return math.min(math.max(x, min), max) == x;

            //fails at +/- 0. Saving one or two clock cycles is not worth the risk
            //return math.asint(math.min(math.max(x, min), max)) == math.asint(x);
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="float2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="float2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(float2 x, float2 min, float2 max)
        {
            return math.min(math.max(x, min), max) == x;

            //fails at +/- 0. Saving one or two clock cycles is not worth the risk
            //return math.asint(math.min(math.max(x, min), max)) == math.asint(x);
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="float3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="float3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(float3 x, float3 min, float3 max)
        {
            return math.min(math.max(x, min), max) == x;

            //fails at +/- 0. Saving one or two clock cycles is not worth the risk
            //return math.asint(math.min(math.max(x, min), max)) == math.asint(x);
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="float4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="float4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(float4 x, float4 min, float4 max)
        {
            return math.min(math.max(x, min), max) == x;

            //fails at +/- 0. Saving one or two clock cycles is not worth the risk
            //return math.asint(math.min(math.max(x, min), max)) == math.asint(x);
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.float8"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.float8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinrange(float8 x, float8 min, float8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;

            //fails at +/- 0. Saving one or two clock cycles is not worth the risk
            //return asint(maxmath.min(maxmath.max(x, min), max)) == asint(x);
        }


        /// <summary>       Returns <see langword="true" /> if a <see cref="double"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="double"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(double x, double min, double max)
        {
            return math.min(math.max(x, min), max) == x;

            //fails at +/- 0. Saving one or two clock cycles is not worth the risk
            //return math.aslong(math.min(math.max(x, min), max)) == math.aslong(x);
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="double2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="double2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(double2 x, double2 min, double2 max)
        {
            return math.min(math.max(x, min), max) == x;

            //fails at +/- 0. Saving one or two clock cycles is not worth the risk
            //return aslong(math.min(math.max(x, min), max)) == aslong(x);
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="double3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="double3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(double3 x, double3 min, double3 max)
        {
            return math.min(math.max(x, min), max) == x;

            //fails at +/- 0. Saving one or two clock cycles is not worth the risk
            //return aslong(math.min(math.max(x, min), max)) == aslong(x);
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="double4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="double4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(double4 x, double4 min, double4 max)
        {
            return math.min(math.max(x, min), max) == x;

            //fails at +/- 0. Saving one or two clock cycles is not worth the risk
            //return aslong(math.min(math.max(x, min), max)) == aslong(x);
        }
    }
}