using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the bit pattern of an sbyte as a quarter.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter asquarter(sbyte x)
        {
            return new quarter { value = (byte)x };
        }

        /// <summary>       Returns the bit pattern of an sbyte2 as a quarter2.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 asquarter(sbyte2 x)
        {
            return (v128)x;
        }

        /// <summary>       Returns the bit pattern of an sbyte3 as a quarter3.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 asquarter(sbyte3 x)
        {
            return (v128)x;
        }
        
        /// <summary>       Returns the bit pattern of an sbyte4 as a quarter4.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 asquarter(sbyte4 x)
        {
            return (v128)x;
        }
        
        /// <summary>       Returns the bit pattern of an sbyte8 as a quarter8.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 asquarter(sbyte8 x)
        {
            return (v128)x;
        }


        /// <summary>       Returns the bit pattern of a byte as a quarter.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter asquarter(byte x)
        {
            return new quarter { value = x };
        }

        /// <summary>       Returns the bit pattern of a byte2 as a quarter2.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 asquarter(byte2 x)
        {
            return (v128)x;
        }

        /// <summary>       Returns the bit pattern of a byte3 as a quarter3.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 asquarter(byte3 x)
        {
            return (v128)x;
        }
        
        /// <summary>       Returns the bit pattern of a byte4 as a quarter4.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 asquarter(byte4 x)
        {
            return (v128)x;
        }
        
        /// <summary>       Returns the bit pattern of a byte8 as a quarter8.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 asquarter(byte8 x)
        {
            return (v128)x;
        }


        /// <summary>       Returns the bit pattern of a quarter as an sbyte.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte assbyte(quarter x)
        {
            return (sbyte)x.value;
        }

        /// <summary>       Returns the bit pattern of a quarter2 as an sbyte2.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 assbyte(quarter2 x)
        {
            return (v128)x;
        }

        /// <summary>       Returns the bit pattern of a quarter3 as an sbyte3.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 assbyte(quarter3 x)
        {
            return (v128)x;
        }
        
        /// <summary>       Returns the bit pattern of a quarter4 as an sbyte4.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 assbyte(quarter4 x)
        {
            return (v128)x;
        }
        
        /// <summary>       Returns the bit pattern of a quarter8 as an sbyte8.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 assbyte(quarter8 x)
        {
            return (v128)x;
        }


        /// <summary>       Returns the bit pattern of a quarter as a byte.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte asbyte(quarter x)
        {
            return x.value;
        }

        /// <summary>       Returns the bit pattern of a quarter2 as a byte2.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 asbyte(quarter2 x)
        {
            return (v128)x;
        }

        /// <summary>       Returns the bit pattern of a quarter3 as a byte3.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 asbyte(quarter3 x)
        {
            return (v128)x;
        }
        
        /// <summary>       Returns the bit pattern of a quarter4 as a byte4.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 asbyte(quarter4 x)
        {
            return (v128)x;
        }
        
        /// <summary>       Returns the bit pattern of a quarter8 as a byte8.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 asbyte(quarter8 x)
        {
            return (v128)x;
        }


        /// <summary>       Returns the bit pattern of a short as a half.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half ashalf(short x)
        {
            return new half { value = (ushort)x };
        }

        /// <summary>       Returns the bit pattern of a short2 as a half2.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 ashalf(short2 x)
        {
            return *(half2*)&x;
        }

        /// <summary>       Returns the bit pattern of a short3 as a half3.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 ashalf(short3 x)
        {
            return *(half3*)&x;
        }

        /// <summary>       Returns the bit pattern of a short4 as a half4.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 ashalf(short4 x)
        {
            return *(half4*)&x;
        }

        /// <summary>       Returns the bit pattern of a short8 as a half8.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 ashalf(short8 x)
        {
            return (v128)x;
        }


        /// <summary>       Returns the bit pattern of a ushort as a half.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half ashalf(ushort x)
        {
            return new half { value = x };
        }

        /// <summary>       Returns the bit pattern of a ushort2 as a half2.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 ashalf(ushort2 x)
        {
            return *(half2*)&x;
        }

        /// <summary>       Returns the bit pattern of a ushort3 as a half3.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 ashalf(ushort3 x)
        {
            return *(half3*)&x;
        }

        /// <summary>       Returns the bit pattern of a ushort4 as a half4.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 ashalf(ushort4 x)
        {
            return *(half4*)&x;
        }

        /// <summary>       Returns the bit pattern of a ushort8 as a half8.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 ashalf(ushort8 x)
        {
            return (v128)x;
        }


        /// <summary>       Returns the bit pattern of a half as a short.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short asshort(half x)
        {
            return (short)x.value;
        }

        /// <summary>       Returns the bit pattern of a half2 as a short2.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 asshort(half2 x)
        {
            return *(short2*)&x;
        }

        /// <summary>       Returns the bit pattern of a half3 as a short3.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 asshort(half3 x)
        {
            return *(short3*)&x;
        }

        /// <summary>       Returns the bit pattern of a half4 as a short4.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 asshort(half4 x)
        {
            return *(short4*)&x;
        }

        /// <summary>       Returns the bit pattern of a half8 as a short8.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 asshort(half8 x)
        {
            return (v128)x;
        }


        /// <summary>       Returns the bit pattern of a half as a ushort.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort asushort(half x)
        {
            return x.value;
        }

        /// <summary>       Returns the bit pattern of a half2 as a ushort2.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 asushort(half2 x)
        {
            return *(ushort2*)&x;
        }

        /// <summary>       Returns the bit pattern of a half3 as a ushort3.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 asushort(half3 x)
        {
            return *(ushort3*)&x;
        }

        /// <summary>       Returns the bit pattern of a half4 as a ushort4.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 asushort(half4 x)
        {
            return *(ushort4*)&x;
        }

        /// <summary>       Returns the bit pattern of a half8 as a ushort8.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 asushort(half8 x)
        {
            return (v128)x;
        }


        /// <summary>       Returns the bit pattern of a float8 as an int8.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 asint(float8 x)
        {
            return (v256)x;
        }

        /// <summary>       Returns the bit pattern of a float8 as a uint8.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 asuint(float8 x)
        {
            return (v256)x;
        }


        /// <summary>       Returns the bit pattern of an int8 as a float8.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 asfloat(int8 x)
        {
            return (v256)x;
        }

        /// <summary>       Returns the bit pattern of a uint8 as a float8.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 asfloat(uint8 x)
        {
            return (v256)x;
        }


        /// <summary>       Returns the bit pattern of a double2 as a long2.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 aslong(double2 x)
        {
            return *(v128*)&x;
        }

        /// <summary>       Returns the bit pattern of a double3 as a long3.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 aslong(double3 x)
        {
            return *(v256*)&x;
        }

        /// <summary>       Returns the bit pattern of a double4 as a long4.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 aslong(double4 x)
        {
            return *(v256*)&x;
        }


        /// <summary>       Returns the bit pattern of a double2 as a ulong2.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 asulong(double2 x)
        {
            return *(v128*)&x;
        }

        /// <summary>       Returns the bit pattern of a double3 as a ulong3.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 asulong(double3 x)
        {
            return *(v256*)&x;
        }

        /// <summary>       Returns the bit pattern of a double4 as a ulong4.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 asulong(double4 x)
        {
            return *(v256*)&x;
        }


        /// <summary>       Returns the bit pattern of a long2 as a double2.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 asdouble(long2 x)
        {
            return *(double2*)&x;
        }

        /// <summary>       Returns the bit pattern of a long3 as a double2.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 asdouble(long3 x)
        {
            return *(double3*)&x;
        }

        /// <summary>       Returns the bit pattern of a long4 as a double4.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 asdouble(long4 x)
        {
            return *(double4*)&x;
        }


        /// <summary>       Returns the bit pattern of a ulong2 as a double2.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 asdouble(ulong2 x)
        {
            return *(double2*)&x;
        }

        /// <summary>       Returns the bit pattern of a ulong3 as a double3.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 asdouble(ulong3 x)
        {
            return *(double3*)&x;
        }

        /// <summary>       Returns the bit pattern of a ulong4 as a double4.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 asdouble(ulong4 x)
        {
            return *(double4*)&x;
        }
    }
}