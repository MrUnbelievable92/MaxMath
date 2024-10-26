using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public partial struct Divider<T>
        where T : unmanaged, IEquatable<T>, IFormattable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T DivRem(sbyte x, out T remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2 DivRem(sbyte2 x, out sbyte2 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3 DivRem(sbyte3 x, out sbyte3 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4 DivRem(sbyte4 x, out sbyte4 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8 DivRem(sbyte8 x, out sbyte8 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16 DivRem(sbyte16 x, out sbyte16 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32 DivRem(sbyte32 x, out sbyte32 remainder)
        {
            remainder = x % this;
            return      x / this;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T DivRem(short x, out T remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2 DivRem(short2 x, out short2 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3 DivRem(short3 x, out short3 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4 DivRem(short4 x, out short4 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8 DivRem(short8 x, out short8 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16 DivRem(short16 x, out short16 remainder)
        {
            remainder = x % this;
            return      x / this;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T DivRem(int x, out T remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2 DivRem(int2 x, out int2 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3 DivRem(int3 x, out int3 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4 DivRem(int4 x, out int4 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8 DivRem(int8 x, out int8 remainder)
        {
            remainder = x % this;
            return      x / this;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T DivRem(long x, out T remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2 DivRem(long2 x, out long2 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3 DivRem(long3 x, out long3 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4 DivRem(long4 x, out long4 remainder)
        {
            remainder = x % this;
            return      x / this;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128 DivRem(Int128 x, out Int128 remainder)
        {
            remainder = x % this;
            return      x / this;
        }
    }
}
