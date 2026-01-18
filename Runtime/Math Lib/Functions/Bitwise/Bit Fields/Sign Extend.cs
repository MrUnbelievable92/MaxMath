using System.Runtime.CompilerServices;
using Unity.Mathematics;
using DevTools;
using MaxMath.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns a sign-extended <see cref="Int128"/> from a signed integer with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 signextend(Int128 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 128);

            return (x << (128 - numBits)) >> (128 - numBits);
        }


        /// <summary>       Returns a sign-extended <see cref="sbyte"/> from a signed integer with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte signextend(sbyte x, int numBits)
        {
Assert.IsBetween(numBits, 1, 8);

            return (sbyte)((x << (32 - numBits)) >> (32 - numBits));
        }

        /// <summary>       Returns a sign-extended <see cref="MaxMath.sbyte2"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 signextend(sbyte2 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 8);

            if (BurstArchitecture.IsVectorShift8Supported)
            {
                return (x << (8 - numBits)) >> (8 - numBits);
            }
            else
            {
                return (x ^ (sbyte)(1 << (numBits - 1))) - (sbyte)(1 << (numBits - 1));
            }
        }

        /// <summary>       Returns a sign-extended <see cref="MaxMath.sbyte3"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 signextend(sbyte3 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 8);
            
            if (BurstArchitecture.IsVectorShift8Supported)
            {
                return (x << (8 - numBits)) >> (8 - numBits);
            }
            else
            {
                return (x ^ (sbyte)(1 << (numBits - 1))) - (sbyte)(1 << (numBits - 1));
            }
        }

        /// <summary>       Returns a sign-extended <see cref="MaxMath.sbyte4"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 signextend(sbyte4 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 8);
            
            if (BurstArchitecture.IsVectorShift8Supported)
            {
                return (x << (8 - numBits)) >> (8 - numBits);
            }
            else
            {
                return (x ^ (sbyte)(1 << (numBits - 1))) - (sbyte)(1 << (numBits - 1));
            }
        }

        /// <summary>       Returns a sign-extended <see cref="MaxMath.sbyte8"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 signextend(sbyte8 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 8);
            
            if (BurstArchitecture.IsVectorShift8Supported)
            {
                return (x << (8 - numBits)) >> (8 - numBits);
            }
            else
            {
                return (x ^ (sbyte)(1 << (numBits - 1))) - (sbyte)(1 << (numBits - 1));
            }
        }

        /// <summary>       Returns a sign-extended <see cref="MaxMath.sbyte16"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 signextend(sbyte16 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 8);
            
            if (BurstArchitecture.IsVectorShift8Supported)
            {
                return (x << (8 - numBits)) >> (8 - numBits);
            }
            else
            {
                return (x ^ (sbyte)(1 << (numBits - 1))) - (sbyte)(1 << (numBits - 1));
            }
        }

        /// <summary>       Returns a sign-extended <see cref="MaxMath.sbyte32"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 signextend(sbyte32 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 8);

            if (BurstArchitecture.IsVectorShift8Supported)
            {
                return (x << (8 - numBits)) >> (8 - numBits);
            }
            else
            {
                return (x ^ (sbyte)(1 << (numBits - 1))) - (sbyte)(1 << (numBits - 1));
            }
        }


        /// <summary>       Returns a sign-extended <see cref="short"/> from a signed integer with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short signextend(short x, int numBits)
        {
Assert.IsBetween(numBits, 1, 16);

            return (short)((x << (32 - numBits)) >> (32 - numBits));
        }

        /// <summary>       Returns a sign-extended <see cref="MaxMath.short2"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 signextend(short2 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 16);

            return (x << (16 - numBits)) >> (16 - numBits);
        }

        /// <summary>       Returns a sign-extended <see cref="MaxMath.short3"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 signextend(short3 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 16);

            return (x << (16 - numBits)) >> (16 - numBits);
        }

        /// <summary>       Returns a sign-extended <see cref="MaxMath.short4"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 signextend(short4 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 16);

            return (x << (16 - numBits)) >> (16 - numBits);
        }

        /// <summary>       Returns a sign-extended <see cref="MaxMath.short8"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 signextend(short8 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 16);

            return (x << (16 - numBits)) >> (16 - numBits);
        }

        /// <summary>       Returns a sign-extended <see cref="MaxMath.short16"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 signextend(short16 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 16);

            return (x << (16 - numBits)) >> (16 - numBits);
        }


        /// <summary>       Returns a sign-extended <see cref="int"/> from a signed integer with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int signextend(int x, int numBits)
        {
Assert.IsBetween(numBits, 1, 32);

            return (x << (32 - numBits)) >> (32 - numBits);
        }

        /// <summary>       Returns a sign-extended <see cref="int2"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 signextend(int2 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 32);

            return (x << (32 - numBits)) >> (32 - numBits);
        }

        /// <summary>       Returns a sign-extended <see cref="int3"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 signextend(int3 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 32);

            return (x << (32 - numBits)) >> (32 - numBits);
        }

        /// <summary>       Returns a sign-extended <see cref="int4"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 signextend(int4 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 32);

            return (x << (32 - numBits)) >> (32 - numBits);
        }

        /// <summary>       Returns a sign-extended <see cref="MaxMath.int8"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 signextend(int8 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 32);

            return (x << (32 - numBits)) >> (32 - numBits);
        }


        /// <summary>       Returns a sign-extended <see cref="long"/> from a signed integer with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long signextend(long x, int numBits)
        {
Assert.IsBetween(numBits, 1, 64);
            
            if (BurstArchitecture.IsShiftRightArithmetic64Supported)
            {
                return (x << (64 - numBits)) >> (64 - numBits);
            }
            else
            {
                return (x ^ (1L << (numBits - 1))) - (1L << (numBits - 1));
            }
        }

        /// <summary>       Returns a sign-extended <see cref="MaxMath.long2"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 signextend(long2 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 64);
            
            if (BurstArchitecture.IsShiftRightArithmetic64Supported)
            {
                return (x << (64 - numBits)) >> (64 - numBits);
            }
            else
            {
                return (x ^ (1L << (numBits - 1))) - (1L << (numBits - 1));
            }
        }

        /// <summary>       Returns a sign-extended <see cref="MaxMath.long3"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 signextend(long3 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 64);
            
            if (BurstArchitecture.IsShiftRightArithmetic64Supported)
            {
                return (x << (64 - numBits)) >> (64 - numBits);
            }
            else
            {
                return (x ^ (1L << (numBits - 1))) - (1L << (numBits - 1));
            }
        }

        /// <summary>       Returns a sign-extended <see cref="MaxMath.long4"/> from a vector of signed integers with <paramref name="numBits"/> bits.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 signextend(long4 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 64);
            
            if (BurstArchitecture.IsShiftRightArithmetic64Supported)
            {
                return (x << (64 - numBits)) >> (64 - numBits);
            }
            else
            {
                return (x ^ (1L << (numBits - 1))) - (1L << (numBits - 1));
            }
        }
    }
}