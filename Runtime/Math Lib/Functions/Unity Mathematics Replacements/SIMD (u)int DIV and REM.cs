using System.Runtime.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint div(byte dividend, byte divisor) => (uint)dividend / (uint)divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 div(byte2 dividend, byte2 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 div(byte3 dividend, byte3 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 div(byte4 dividend, byte4 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 div(byte8 dividend, byte8 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 div(byte16 dividend, byte16 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 div(byte32 dividend, byte32 divisor) => dividend / divisor;


        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint div(ushort dividend, ushort divisor) => (uint)dividend / (uint)divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 div(ushort2 dividend, ushort2 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 div(ushort3 dividend, ushort3 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 div(ushort4 dividend, ushort4 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 div(ushort8 dividend, ushort8 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 div(ushort16 dividend, ushort16 divisor) => dividend / divisor;


        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint div(uint dividend, uint divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 div(uint2 dividend, uint2 divisor)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.div_epu32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), 2));
            }
            else
            {
                return dividend / divisor;
            }
        }

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 div(uint3 dividend, uint3 divisor)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.div_epu32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), 3));
            }
            else
            {
                return dividend / divisor;
            }
        }

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 div(uint4 dividend, uint4 divisor)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.div_epu32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), 4));
            }
            else
            {
                return dividend / divisor;
            }
        }

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 div(uint8 dividend, uint8 divisor) => dividend / divisor;


        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong div(ulong dividend, ulong divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 div(ulong2 dividend, ulong2 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 div(ulong3 dividend, ulong3 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 div(ulong4 dividend, ulong4 divisor) => dividend / divisor;


        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int div(sbyte dividend, sbyte divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 div(sbyte2 dividend, sbyte2 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 div(sbyte3 dividend, sbyte3 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 div(sbyte4 dividend, sbyte4 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 div(sbyte8 dividend, sbyte8 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 div(sbyte16 dividend, sbyte16 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 div(sbyte32 dividend, sbyte32 divisor) => dividend / divisor;


        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int div(short dividend, short divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 div(short2 dividend, short2 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 div(short3 dividend, short3 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 div(short4 dividend, short4 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 div(short8 dividend, short8 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 div(short16 dividend, short16 divisor) => dividend / divisor;


        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int div(int dividend, int divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 div(int2 dividend, int2 divisor)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.div_epu32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), 2));
            }
            else
            {
                return dividend / divisor;
            }
        }

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 div(int3 dividend, int3 divisor)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.div_epu32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), 3));
            }
            else
            {
                return dividend / divisor;
            }
        }

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 div(int4 dividend, int4 divisor)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.div_epu32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), 4));
            }
            else
            {
                return dividend / divisor;
            }
        }

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 div(int8 dividend, int8 divisor) => dividend / divisor;


        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long div(long dividend, long divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 div(long2 dividend, long2 divisor) => dividend / divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the result.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 div(long3 dividend, long3 divisor) => dividend / divisor;


        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      <%summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mod(byte dividend, byte divisor) => (uint)dividend % (uint)divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      <%summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mod(byte2 dividend, byte2 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      <%summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mod(byte3 dividend, byte3 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      <%summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mod(byte4 dividend, byte4 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      <%summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 mod(byte8 dividend, byte8 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      <%summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 mod(byte16 dividend, byte16 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      <%summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 mod(byte32 dividend, byte32 divisor) => dividend % divisor;


        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      <%summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mod(ushort dividend, ushort divisor) => (uint)dividend % (uint)divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      <%summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mod(ushort2 dividend, ushort2 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      <%summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mod(ushort3 dividend, ushort3 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      <%summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mod(ushort4 dividend, ushort4 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      <%summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 mod(ushort8 dividend, ushort8 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      <%summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 mod(ushort16 dividend, ushort16 divisor) => dividend % divisor;


        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      <%summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mod(uint dividend, uint divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 mod(uint2 dividend, uint2 divisor)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.rem_epu32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), 2));
            }
            else
            {
                return dividend % divisor;
            }
        }

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 mod(uint3 dividend, uint3 divisor)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.rem_epu32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), 3));
            }
            else
            {
                return dividend % divisor;
            }
        }

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 mod(uint4 dividend, uint4 divisor)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.rem_epu32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), 4));
            }
            else
            {
                return dividend % divisor;
            }
        }

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      <%summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 mod(uint8 dividend, uint8 divisor) => dividend % divisor;


        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong mod(ulong dividend, ulong divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mod(ulong2 dividend, ulong2 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mod(ulong3 dividend, ulong3 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mod(ulong4 dividend, ulong4 divisor) => dividend % divisor;


        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mod(sbyte dividend, sbyte divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mod(sbyte2 dividend, sbyte2 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mod(sbyte3 dividend, sbyte3 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mod(sbyte4 dividend, sbyte4 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 mod(sbyte8 dividend, sbyte8 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 mod(sbyte16 dividend, sbyte16 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 mod(sbyte32 dividend, sbyte32 divisor) => dividend % divisor;


        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mod(short dividend, short divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mod(short2 dividend, short2 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mod(short3 dividend, short3 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mod(short4 dividend, short4 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 mod(short8 dividend, short8 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 mod(short16 dividend, short16 divisor) => dividend % divisor;


        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 mod(int2 dividend, int2 divisor)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.rem_epu32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), 2));
            }
            else
            {
                return dividend % divisor;
            }
        }

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 mod(int3 dividend, int3 divisor)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.rem_epu32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), 3));
            }
            else
            {
                return dividend % divisor;
            }
        }

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 mod(int4 dividend, int4 divisor)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.rem_epu32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), 4));
            }
            else
            {
                return dividend % divisor;
            }
        }

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      <%summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 mod(int8 dividend, int8 divisor) => dividend % divisor;


        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long mod(long dividend, long divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mod(long2 dividend, long2 divisor) => dividend % divisor;

        /// <summary>       Divides '<paramref name="dividend"/>' by '<paramref name="divisor"/>' and returns the remainder.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mod(long3 dividend, long3 divisor) => dividend % divisor;
    }
}
