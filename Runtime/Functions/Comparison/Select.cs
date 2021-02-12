using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte select(byte a, byte b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 select(byte2 a, byte2 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 select(byte3 a, byte3 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 select(byte4 a, byte4 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 select(byte8 a, byte8 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 select(byte16 a, byte16 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 select(byte32 a, byte32 b, bool c)
        {
            return c ? b : a;
        }


        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte select(sbyte a, sbyte b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 select(sbyte2 a, sbyte2 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 select(sbyte3 a, sbyte3 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 select(sbyte4 a, sbyte4 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 select(sbyte8 a, sbyte8 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 select(sbyte16 a, sbyte16 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 select(sbyte32 a, sbyte32 b, bool c)
        {
            return c ? b : a;
        }


        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort select(ushort a, ushort b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 select(ushort2 a, ushort2 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 select(ushort3 a, ushort3 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 select(ushort4 a, ushort4 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 select(ushort8 a, ushort8 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 select(ushort16 a, ushort16 b, bool c)
        {
            return c ? b : a;
        }


        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short select(short a, short b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 select(short2 a, short2 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 select(short3 a, short3 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 select(short4 a, short4 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 select(short8 a, short8 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 select(short16 a, short16 b, bool c)
        {
            return c ? b : a;
        }


        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 select(int8 a, int8 b, bool c)
        {
            return c ? b : a;
        }


        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 select(uint8 a, uint8 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 select(long2 a, long2 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 select(long3 a, long3 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 select(long4 a, long4 b, bool c)
        {
            return c ? b : a;
        }


        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 select(ulong2 a, ulong2 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 select(ulong3 a, ulong3 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 select(ulong4 a, ulong4 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter select(quarter a, quarter b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 select(quarter2 a, quarter2 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 select(quarter3 a, quarter3 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 select(quarter4 a, quarter4 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 select(quarter8 a, quarter8 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half select(half a, half b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 select(half2 a, half2 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 select(half3 a, half3 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 select(half4 a, half4 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 select(half8 a, half8 b, bool c)
        {
            return c ? b : a;
        }

        /// <summary>       Returns b if c is true, a otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 select(float8 a, float8 b, bool c)
        {
            return c ? b : a;
        }


        /// <summary>       Returns a componentwise selection between two byte2 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 select(byte2 a, byte2 b, int c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Mask.BlendV(a, b, (byte2)Mask.Int2FromInt(c));
            }
            else
            {
                return select(a, b, tobool(1 & new byte2((byte)c, (byte)((uint)c >> 1))));
            }
        }

        /// <summary>       Returns a componentwise selection between two byte3 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 select(byte3 a, byte3 b, int c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Mask.BlendV(a, b, (byte3)Mask.Int3FromInt(c));
            }
            else
            {
                return select(a, b, tobool(1 & new byte3((byte)c, (byte)((uint)c >> 1), (byte)((uint)c >> 2))));
            }
        }

        /// <summary>       Returns a componentwise selection between two byte3 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 select(byte4 a, byte4 b, int c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Mask.BlendV(a, b, (byte4)Mask.Int4FromInt(c));
            }
            else
            {
                return select(a, b, tobool(1 & new byte4((byte)c, (byte)((uint)c >> 1), (byte)((uint)c >> 2), (byte)((uint)c >> 3))));
            }
        }

        /// <summary>       Returns a componentwise selection between two byte8 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 select(byte8 a, byte8 b, int c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Mask.BlendV(a, b, (byte8)Mask.Int8FromInt(c));
            }
            else
            {
                return select(a, b, tobool(1 & new byte8((byte)c, (byte)((uint)c >> 1), (byte)((uint)c >> 2), (byte)((uint)c >> 3), (byte)((uint)c >> 4), (byte)((uint)c >> 5), (byte)((uint)c >> 6), (byte)((uint)c >> 7))));
            }
        }

        /// <summary>       Returns a componentwise selection between two byte16 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 select(byte16 a, byte16 b, int c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Mask.BlendV(a, b, (sbyte16)Mask.Short16FromInt(c));
            }
            else
            {
                return select(a, b, tobool(1 & new byte16((byte)c, (byte)((uint)c >> 1), (byte)((uint)c >> 2), (byte)((uint)c >> 3), (byte)((uint)c >> 4), (byte)((uint)c >> 5), (byte)((uint)c >> 6), (byte)((uint)c >> 7), (byte)((uint)c >> 8), (byte)((uint)c >> 9), (byte)((uint)c >> 10), (byte)((uint)c >> 11), (byte)((uint)c >> 12), (byte)((uint)c >> 13), (byte)((uint)c >> 14), (byte)((uint)c >> 15))));
            }
        }

        /// <summary>       Returns a componentwise selection between two byte32 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 select(byte32 a, byte32 b, int c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(a, b, Mask.SByte32FromInt(c));
            }
            else
            {
                return new byte32(select(a.v16_0, b.v16_0, c), select(a.v16_16, b.v16_16, (int)((uint)c >> 16)));
            }
        }


        /// <summary>       Returns a componentwise selection between two sbyte2 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 select(sbyte2 a, sbyte2 b, int c)
        {
            return (sbyte2)select((byte2)a, (byte2)b, c);
        }

        /// <summary>       Returns a componentwise selection between two sbyte3 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 select(sbyte3 a, sbyte3 b, int c)
        {
            return (sbyte3)select((byte3)a, (byte3)b, c);
        }

        /// <summary>       Returns a componentwise selection between two sbyte3 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 select(sbyte4 a, sbyte4 b, int c)
        {
            return (sbyte4)select((byte4)a, (byte4)b, c);
        }

        /// <summary>       Returns a componentwise selection between two sbyte8 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 select(sbyte8 a, sbyte8 b, int c)
        {
            return (sbyte8)select((byte8)a, (byte8)b, c);
        }

        /// <summary>       Returns a componentwise selection between two sbyte16 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 select(sbyte16 a, sbyte16 b, int c)
        {
            return (sbyte16)select((byte16)a, (byte16)b, c);
        }

        /// <summary>       Returns a componentwise selection between two sbyte32 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 select(sbyte32 a, sbyte32 b, int c)
        {
            return (sbyte32)select((byte32)a, (byte32)b, c);
        }


        /// <summary>       Returns a componentwise selection between two ushort2 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 select(ushort2 a, ushort2 b, int c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Mask.Short2FromInt(c));
            }
            else
            {
                return select(a, b, tobool(1 & new ushort2((ushort)c, (ushort)((uint)c >> 1))));
            }
        }

        /// <summary>       Returns a componentwise selection between two ushort3 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 select(ushort3 a, ushort3 b, int c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Mask.BlendV(a, b, (short3)Mask.Int3FromInt(c));
            }
            else
            {
                return select(a, b, tobool(1 & new ushort3((ushort)c, (ushort)((uint)c >> 1), (ushort)((uint)c >> 2))));
            }
        }

        /// <summary>       Returns a componentwise selection between two ushort4 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 select(ushort4 a, ushort4 b, int c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Mask.BlendV(a, b, (short4)Mask.Int4FromInt(c));
            }
            else
            {
                return select(a, b, tobool(1 & new ushort4((ushort)c, (ushort)((uint)c >> 1), (ushort)((uint)c >> 2), (ushort)((uint)c >> 3))));
            }
        }

        /// <summary>       Returns a componentwise selection between two ushort8 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 select(ushort8 a, ushort8 b, int c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Mask.BlendV(a, b, (short8)Mask.Int8FromInt(c));
            }
            else
            {
                return select(a, b, tobool(1 & new ushort8((ushort)c, (ushort)((uint)c >> 1), (ushort)((uint)c >> 2), (ushort)((uint)c >> 3), (ushort)((uint)c >> 4), (ushort)((uint)c >> 5), (ushort)((uint)c >> 6), (ushort)((uint)c >> 7))));
            }
        }

        /// <summary>       Returns a componentwise selection between two ushort16 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 select(ushort16 a, ushort16 b, int c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(a, b, Mask.Short16FromInt(c));
            }
            else
            {
                return new ushort16(select(a.v8_0, b.v8_0, c), select(a.v8_8, b.v8_8, (int)((uint)c >> 8)));
            }
        }


        /// <summary>       Returns a componentwise selection between two short2 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 select(short2 a, short2 b, int c)
        {
            return (short2)select((ushort2)a, (ushort2)b, c);
        }

        /// <summary>       Returns a componentwise selection between two short3 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 select(short3 a, short3 b, int c)
        {
            return (short3)select((ushort3)a, (ushort3)b, c);
        }

        /// <summary>       Returns a componentwise selection between two short4 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 select(short4 a, short4 b, int c)
        {
            return (short4)select((ushort4)a, (ushort4)b, c);
        }

        /// <summary>       Returns a componentwise selection between two short8 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 select(short8 a, short8 b, int c)
        {
            return (short8)select((ushort8)a, (ushort8)b, c);
        }

        /// <summary>       Returns a componentwise selection between two short16 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 select(short16 a, short16 b, int c)
        {
            return (short16)select((ushort16)a, (ushort16)b, c);
        }


        /// <summary>       Returns a componentwise selection between two int2 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 select(int2 a, int2 b, int c)
        {
            if (Sse2.IsSse2Supported)
            {
                int2 mask = Mask.Int2FromInt(c);
                v128 temp = Mask.BlendV(*(v128*)&a, *(v128*)&b, *(v128*)&mask);

                return *(int2*)&temp;
            }
            else
            {
                return math.select(a, b, tobool(1 & new int2(c, (int)((uint)c >> 1))));
            }
        }

        /// <summary>       Returns a componentwise selection between two int3 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 select(int3 a, int3 b, int c)
        {
            if (Sse2.IsSse2Supported)
            {
                int3 mask = Mask.Int3FromInt(c);
                v128 temp = Mask.BlendV(*(v128*)&a, *(v128*)&b, *(v128*)&mask);

                return *(int3*)&temp;
            }
            else
            {
                return math.select(a, b, tobool(1 & new int3(c, (int)((uint)c >> 1), (int)((uint)c >> 2))));
            }
        }

        /// <summary>       Returns a componentwise selection between two int4 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 select(int4 a, int4 b, int c)
        {
            if (Sse2.IsSse2Supported)
            {
                int4 mask = Mask.Int4FromInt(c);
                v128 temp = Mask.BlendV(*(v128*)&a, *(v128*)&b, *(v128*)&mask);

                return *(int4*)&temp;
            }
            else
            {
                return math.select(a, b, tobool(1 & new int4(c, (int)((uint)c >> 1), (int)((uint)c >> 2), (int)((uint)c >> 3))));
            }
        }

        /// <summary>       Returns a componentwise selection between two int8 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 select(int8 a, int8 b, int c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(a, b, Mask.Int8FromInt(c));
            }
            else
            {
                return new int8(select(a.v4_0, b.v4_0, c), select(a.v4_4, b.v4_4, (int)((uint)c >> 4)));
            }
        }


        /// <summary>       Returns a componentwise selection between two uint2 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 select(uint2 a, uint2 b, int c)
        {
            return (uint2)select((int2)a, (int2)b, c);
        }

        /// <summary>       Returns a componentwise selection between two uint3 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 select(uint3 a, uint3 b, int c)
        {
            return (uint3)select((int3)a, (int3)b, c);
        }

        /// <summary>       Returns a componentwise selection between two uint4 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 select(uint4 a, uint4 b, int c)
        {
            return (uint4)select((int4)a, (int4)b, c);
        }

        /// <summary>       Returns a componentwise selection between two uint8 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 select(uint8 a, uint8 b, int c)
        {
            return (uint8)select((int8)a, (int8)b, c);
        }


        /// <summary>       Returns a componentwise selection between two long2 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 select(long2 a, long2 b, int c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Mask.Long2FromInt(c));
            }
            else
            {
                return select(a, b, tobool(1 & new long2(c, (uint)c >> 1)));
            }
        }

        /// <summary>       Returns a componentwise selection between two long3 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 select(long3 a, long3 b, int c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(a, b, Mask.Long3FromInt(c));
            }
            else
            {
                return new long3(select(a.xy, b.xy, c), tobool(((uint)c >> 2) & 1) ? b.z : a.z);
            }
        }

        /// <summary>       Returns a componentwise selection between two long4 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 select(long4 a, long4 b, int c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(a, b, Mask.Long4FromInt(c));
            }
            else
            {
                return new long4(select(a.xy, b.xy, c), select(a.zw, b.zw, c >> 2));
            }
        }


        /// <summary>       Returns a componentwise selection between two ulong2 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 select(ulong2 a, ulong2 b, int c)
        {
            return (ulong2)select((long2)a, (long2)b, c);
        }

        /// <summary>       Returns a componentwise selection between two ulong3 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 select(ulong3 a, ulong3 b, int c)
        {
            return (ulong3)select((long3)a, (long3)b, c);
        }

        /// <summary>       Returns a componentwise selection between two ulong4 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 select(ulong4 a, ulong4 b, int c)
        {
            return (ulong4)select((long4)a, (long4)b, c);
        }


        /// <summary>       Returns a componentwise selection between two quarter2 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 select(quarter2 a, quarter2 b, int c)
        {
            return asquarter(select(asbyte(a), asbyte(b), c));
        }

        /// <summary>       Returns a componentwise selection between two quarter3 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 select(quarter3 a, quarter3 b, int c)
        {
            return asquarter(select(asbyte(a), asbyte(b), c));
        }

        /// <summary>       Returns a componentwise selection between two quarter3 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 select(quarter4 a, quarter4 b, int c)
        {
            return asquarter(select(asbyte(a), asbyte(b), c));
        }

        /// <summary>       Returns a componentwise selection between two quarter8 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 select(quarter8 a, quarter8 b, int c)
        {
            return asquarter(select(asbyte(a), asbyte(b), c));
        }


        /// <summary>       Returns a componentwise selection between two half2 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 select(half2 a, half2 b, int c)
        {
            return ashalf(select(asushort(a), asushort(b), c));
        }

        /// <summary>       Returns a componentwise selection between two half3 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 select(half3 a, half3 b, int c)
        {
            return ashalf(select(asushort(a), asushort(b), c));
        }

        /// <summary>       Returns a componentwise selection between two half4 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 select(half4 a, half4 b, int c)
        {
            return ashalf(select(asushort(a), asushort(b), c));
        }

        /// <summary>       Returns a componentwise selection between two half8 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 select(half8 a, half8 b, int c)
        {
            return ashalf(select(asushort(a), asushort(b), c));
        }


        /// <summary>       Returns a componentwise selection between two double2 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 select(double2 a, double2 b, int c)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 temp = Sse4_1.blendv_pd(*(v128*)&a, *(v128*)&b, Mask.Long2FromInt(c));

                return *(double2*)&temp;
            }
            else
            {
                return math.select(a, b, tobool(1 & new long2(c, (uint)c >> 1)));
            }
        }

        /// <summary>       Returns a componentwise selection between two double3 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 select(double3 a, double3 b, int c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 temp = Avx.mm256_blendv_pd(*(v256*)&a, *(v256*)&b, Mask.Long3FromInt(c));

                return *(double3*)&temp;
            }
            else
            {
                return new double3(select(a.xy, b.xy, c), tobool(((uint)c >> 2) & 1) ? b.z : a.z);
            }
        }

        /// <summary>       Returns a componentwise selection between two double4 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 select(double4 a, double4 b, int c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 temp = Avx.mm256_blendv_pd(*(v256*)&a, *(v256*)&b, Mask.Long4FromInt(c));

                return *(double4*)&temp;
            }
            else
            {
                return new double4(select(a.xy, b.xy, c), select(a.zw, b.zw, c >> 2));
            }
        }


        /// <summary>       Returns a componentwise selection between two float2 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 select(float2 a, float2 b, int c)
        {
            if (Sse4_1.IsSse41Supported)
            {
                int2 mask = Mask.Int2FromInt(c);
                v128 temp = Sse4_1.blendv_ps(*(v128*)&a, *(v128*)&b, *(v128*)&mask);

                return *(float2*)&temp;
            }
            else
            {
                return math.select(a, b, tobool(1 & new int2(c, (int)((uint)c >> 1))));
            }
        }

        /// <summary>       Returns a componentwise selection between two float3 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 select(float3 a, float3 b, int c)
        {
            if (Sse4_1.IsSse41Supported)
            {
                int3 mask = Mask.Int3FromInt(c);
                v128 temp = Sse4_1.blendv_ps(*(v128*)&a, *(v128*)&b, *(v128*)&mask);

                return *(float3*)&temp;
            }
            else
            {
                return math.select(a, b, tobool(1 & new int3(c, (int)((uint)c >> 1), (int)((uint)c >> 2))));
            }
        }

        /// <summary>       Returns a componentwise selection between two float4 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 select(float4 a, float4 b, int c)
        {
            if (Sse4_1.IsSse41Supported)
            {
                int4 mask = Mask.Int4FromInt(c);
                v128 temp = Sse4_1.blendv_ps(*(v128*)&a, *(v128*)&b, *(v128*)&mask);

                return *(float4*)&temp;
            }
            else
            {
                return math.select(a, b, tobool(1 & new int4(c, (int)((uint)c >> 1), (int)((uint)c >> 2), (int)((uint)c >> 3))));
            }
        }

        /// <summary>       Returns a componentwise selection between two float8 vectors a and b based on a bitmask c. Per component, the component from b is selected when the corresponding LSB order bit in c is 1, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 select(float8 a, float8 b, int c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx.mm256_blendv_ps(a, b, Mask.Int8FromInt(c));
            }
            else
            {
                return new float8(select(a.v4_0, b.v4_0, c), select(a.v4_4, b.v4_4, (int)((uint)c >> 4)));
            }
        }


        /// <summary>       Returns a componentwise selection between two byte2 vectors a and b based on a bool2 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 select(byte2 a, byte2 b, bool2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(b, a, Sse2.cmpeq_epi8(*(v128*)&c, default(v128)));
            }
            else
            {
                return new byte2(c.x ? b.x : a.x, c.y ? b.y : a.y);
            }
        }

        /// <summary>       Returns a componentwise selection between two byte2 vectors a and b based on a bool3 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 select(byte3 a, byte3 b, bool3 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(b, a, Sse2.cmpeq_epi8(*(v128*)&c, default(v128)));
            }
            else
            {
                return new byte3(c.x ? b.x : a.x, c.y ? b.y : a.y, c.z ? b.z : a.z);
            }
        }

        /// <summary>       Returns a componentwise selection between two byte4 vectors a and b based on a bool4 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 select(byte4 a, byte4 b, bool4 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(b, a, Sse2.cmpeq_epi8(*(v128*)&c, default(v128)));
            }
            else
            {
                return new byte4(c.x ? b.x : a.x, c.y ? b.y : a.y, c.z ? b.z : a.z, c.w ? b.w : a.w);
            }
        }

        /// <summary>       Returns a componentwise selection between two byte8 vectors a and b based on a bool8 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 select(byte8 a, byte8 b, bool8 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(b, a, Sse2.cmpeq_epi8(c, default(v128)));
            }
            else
            {
                return new byte8(c.x0 ? b.x0 : a.x0, c.x1 ? b.x1 : a.x1, c.x2 ? b.x2 : a.x2, c.x3 ? b.x3 : a.x3, c.x4 ? b.x4 : a.x4, c.x5 ? b.x5 : a.x5, c.x6 ? b.x6 : a.x6, c.x7 ? b.x7 : a.x7);
            }
        }

        /// <summary>       Returns a componentwise selection between two byte16 vectors a and b based on a bool16 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 select(byte16 a, byte16 b, bool16 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(b, a, Sse2.cmpeq_epi8(c, default(v128)));
            }
            else
            {
                return new byte16(c.x0 ? b.x0 : a.x0, c.x1 ? b.x1 : a.x1, c.x2 ? b.x2 : a.x2, c.x3 ? b.x3 : a.x3, c.x4 ? b.x4 : a.x4, c.x5 ? b.x5 : a.x5, c.x6 ? b.x6 : a.x6, c.x7 ? b.x7 : a.x7, c.x8 ? b.x8 : a.x8, c.x9 ? b.x9 : a.x9, c.x10 ? b.x10 : a.x10, c.x11 ? b.x11 : a.x11, c.x12 ? b.x12 : a.x12, c.x13 ? b.x13 : a.x13, c.x14 ? b.x14 : a.x14, c.x15 ? b.x15 : a.x15);
            }
        }

        /// <summary>       Returns a componentwise selection between two byte32 vectors a and b based on a bool32 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 select(byte32 a, byte32 b, bool32 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(b, a, Avx2.mm256_cmpeq_epi8(c, default(v256)));
            }
            else
            {
                return new byte32(select(a.v16_0, b.v16_0, c.v16_0), select(a.v16_16, b.v16_16, c.v16_16));
            }
        }


        /// <summary>       Returns a componentwise selection between two sbyte2 vectors a and b based on a bool2 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 select(sbyte2 a, sbyte2 b, bool2 c)
        {
            return (sbyte2)select((byte2)a, (byte2)b, c);
        }

        /// <summary>       Returns a componentwise selection between two sbyte2 vectors a and b based on a bool3 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 select(sbyte3 a, sbyte3 b, bool3 c)
        {
            return (sbyte3)select((byte3)a, (byte3)b, c);
        }

        /// <summary>       Returns a componentwise selection between two sbyte4 vectors a and b based on a bool4 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 select(sbyte4 a, sbyte4 b, bool4 c)
        {
            return (sbyte4)select((byte4)a, (byte4)b, c);
        }

        /// <summary>       Returns a componentwise selection between two sbyte8 vectors a and b based on a bool8 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 select(sbyte8 a, sbyte8 b, bool8 c)
        {
            return (sbyte8)select((byte8)a, (byte8)b, c);
        }

        /// <summary>       Returns a componentwise selection between two sbyte16 vectors a and b based on a bool16 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 select(sbyte16 a, sbyte16 b, bool16 c)
        {
            return (sbyte16)select((byte16)a, (byte16)b, c);
        }

        /// <summary>       Returns a componentwise selection between two sbyte32 vectors a and b based on a bool32 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 select(sbyte32 a, sbyte32 b, bool32 c)
        {
            return (sbyte32)select((byte32)a, (byte32)b, c);
        }


        /// <summary>       Returns a componentwise selection between two ushort2 vectors a and b based on a bool2 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 select(ushort2 a, ushort2 b, bool2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(b, a, (short2)((sbyte2)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
            }
            else
            {
                return new ushort2(c.x ? b.x : a.x, c.y ? b.y : a.y);
            }
        }

        /// <summary>       Returns a componentwise selection between two ushort3 vectors a and b based on a bool3 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 select(ushort3 a, ushort3 b, bool3 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(b, a, (short3)((sbyte3)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
            }
            else
            {
                return new ushort3(c.x ? b.x : a.x, c.y ? b.y : a.y, c.z ? b.z : a.z);
            }
        }

        /// <summary>       Returns a componentwise selection between two ushort4 vectors a and b based on a bool4 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 select(ushort4 a, ushort4 b, bool4 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(b, a, (short4)((sbyte4)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
            }
            else
            {
                return new ushort4(c.x ? b.x : a.x, c.y ? b.y : a.y, c.z ? b.z : a.z, c.w ? b.w : a.w);
            }
        }

        /// <summary>       Returns a componentwise selection between two ushort8 vectors a and b based on a bool8 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 select(ushort8 a, ushort8 b, bool8 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(b, a, (short8)((sbyte8)Sse2.cmpeq_epi8(c, default(v128))));
            }
            else
            {
                return new ushort8(c.x0 ? b.x0 : a.x0, c.x1 ? b.x1 : a.x1, c.x2 ? b.x2 : a.x2, c.x3 ? b.x3 : a.x3, c.x4 ? b.x4 : a.x4, c.x5 ? b.x5 : a.x5, c.x6 ? b.x6 : a.x6, c.x7 ? b.x7 : a.x7);
            }
        }

        /// <summary>       Returns a componentwise selection between two ushort16 vectors a and b based on a bool16 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 select(ushort16 a, ushort16 b, bool16 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(b, a, (short16)((sbyte16)Sse2.cmpeq_epi8(c, default(v128))));
            }
            else
            {
                return new ushort16(select(a.v8_0, b.v8_0, c.v8_0), select(a.v8_8, b.v8_8, c.v8_8));
            }
        }


        /// <summary>       Returns a componentwise selection between two short2 vectors a and b based on a bool2 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 select(short2 a, short2 b, bool2 c)
        {
            return (short2)select((ushort2)a, (ushort2)b, c);
        }

        /// <summary>       Returns a componentwise selection between two short3 vectors a and b based on a bool3 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 select(short3 a, short3 b, bool3 c)
        {
            return (short3)select((ushort3)a, (ushort3)b, c);
        }

        /// <summary>       Returns a componentwise selection between two short4 vectors a and b based on a bool4 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 select(short4 a, short4 b, bool4 c)
        {
            return (short4)select((ushort4)a, (ushort4)b, c);
        }

        /// <summary>       Returns a componentwise selection between two short8 vectors a and b based on a bool8 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 select(short8 a, short8 b, bool8 c)
        {
            return (short8)select((ushort8)a, (ushort8)b, c);
        }

        /// <summary>       Returns a componentwise selection between two short16 vectors a and b based on a bool16 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 select(short16 a, short16 b, bool16 c)
        {
            return (short16)select((ushort16)a, (ushort16)b, c);
        }


        /// <summary>       Returns a componentwise selection between two int8 vectors a and b based on a bool8 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 select(int8 a, int8 b, bool8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(b, a, (int8)((sbyte8)Sse2.cmpeq_epi8(c, default(v128))));
            }
            else
            {
                return new int8(math.select(a.v4_0, b.v4_0, c.v4_0), math.select(a.v4_4, b.v4_4, c.v4_4));
            }
        }


        /// <summary>       Returns a componentwise selection between two uint8 vectors a and b based on a bool8 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 select(uint8 a, uint8 b, bool8 c)
        {
            return (uint8)select((int8)a, (int8)b, c);
        }


        /// <summary>       Returns a componentwise selection between two long2 vectors a and b based on a bool2 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 select(long2 a, long2 b, bool2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(b, a, (long2)((sbyte2)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
            }
            else
            {
                return new long2(c.x ? b.x : a.x, c.y ? b.y : a.y);
            }
        }

        /// <summary>       Returns a componentwise selection between two long3 vectors a and b based on a bool3 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 select(long3 a, long3 b, bool3 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(b, a, (long3)((sbyte3)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
            }
            else
            {
                return new long3(select(a.xy, b.xy, c.xy), c.z ? b.z : a.z);
            }
        }

        /// <summary>       Returns a componentwise selection between two long4 vectors a and b based on a bool4 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 select(long4 a, long4 b, bool4 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(b, a, (long4)((sbyte4)Sse2.cmpeq_epi8(*(v128*)&c, default(v128))));
            }
            else
            {
                return new long4(select(a.xy, b.xy, c.xy), select(a.zw, b.zw, c.zw));
            }
        }


        /// <summary>       Returns a componentwise selection between two ulong2 vectors a and b based on a bool2 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 select(ulong2 a, ulong2 b, bool2 c)
        {
            return (ulong2)select((long2)a, (long2)b, c);
        }

        /// <summary>       Returns a componentwise selection between two ulong3 vectors a and b based on a bool3 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 select(ulong3 a, ulong3 b, bool3 c)
        {
            return (ulong3)select((long3)a, (long3)b, c);
        }

        /// <summary>       Returns a componentwise selection between two ulong4 vectors a and b based on a bool4 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 select(ulong4 a, ulong4 b, bool4 c)
        {
            return (ulong4)select((long4)a, (long4)b, c);
        }


        /// <summary>       Returns a componentwise selection between two quarter2 vectors a and b based on a bool2 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 select(quarter2 a, quarter2 b, bool2 c)
        {
            return asquarter(select(asbyte(a), asbyte(b), c));
        }

        /// <summary>       Returns a componentwise selection between two quarter2 vectors a and b based on a bool3 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 select(quarter3 a, quarter3 b, bool3 c)
        {
            return asquarter(select(asbyte(a), asbyte(b), c));
        }

        /// <summary>       Returns a componentwise selection between two quarter4 vectors a and b based on a bool4 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 select(quarter4 a, quarter4 b, bool4 c)
        {
            return asquarter(select(asbyte(a), asbyte(b), c));
        }

        /// <summary>       Returns a componentwise selection between two quarter8 vectors a and b based on a bool8 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 select(quarter8 a, quarter8 b, bool8 c)
        {
            return asquarter(select(asbyte(a), asbyte(b), c));
        }


        /// <summary>       Returns a componentwise selection between two half2 vectors a and b based on a bool2 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 select(half2 a, half2 b, bool2 c)
        {
            return ashalf(select(asushort(a), asushort(b), c));
        }

        /// <summary>       Returns a componentwise selection between two half3 vectors a and b based on a bool3 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 select(half3 a, half3 b, bool3 c)
        {
            return ashalf(select(asushort(a), asushort(b), c));
        }

        /// <summary>       Returns a componentwise selection between two half4 vectors a and b based on a bool4 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 select(half4 a, half4 b, bool4 c)
        {
            return ashalf(select(asushort(a), asushort(b), c));
        }

        /// <summary>       Returns a componentwise selection between two half8 vectors a and b based on a bool8 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 select(half8 a, half8 b, bool8 c)
        {
            return ashalf(select(asushort(a), asushort(b), c));
        }


        /// <summary>       Returns a componentwise selection between two float8 vectors a and b based on a bool8 selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 select(float8 a, float8 b, bool8 c)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_blendv_ps(b, a, (int8)((sbyte8)Sse2.cmpeq_epi8(c, default(v128))));
            }
            else
            {
                return new float8(math.select(a.v4_0, b.v4_0, c.v4_0), math.select(a.v4_4, b.v4_4, c.v4_4));
            }
        }
    }
}