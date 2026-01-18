using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public partial struct Divider<T>
        where T : unmanaged, IEquatable<T>, IFormattable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly T DivRem(byte x, out T remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly byte2 DivRem(byte2 x, out byte2 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly byte3 DivRem(byte3 x, out byte3 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly byte4 DivRem(byte4 x, out byte4 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly byte8 DivRem(byte8 x, out byte8 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly byte16 DivRem(byte16 x, out byte16 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly byte32 DivRem(byte32 x, out byte32 remainder)
        {
            remainder = x % this;
            return      x / this;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly T DivRem(ushort x, out T remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly ushort2 DivRem(ushort2 x, out ushort2 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly ushort3 DivRem(ushort3 x, out ushort3 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly ushort4 DivRem(ushort4 x, out ushort4 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly ushort8 DivRem(ushort8 x, out ushort8 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly ushort16 DivRem(ushort16 x, out ushort16 remainder)
        {
            remainder = x % this;
            return      x / this;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly T DivRem(uint x, out T remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly uint2 DivRem(uint2 x, out uint2 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly uint3 DivRem(uint3 x, out uint3 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly uint4 DivRem(uint4 x, out uint4 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly uint8 DivRem(uint8 x, out uint8 remainder)
        {
            remainder = x % this;
            return      x / this;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly T DivRem(ulong x, out T remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly ulong2 DivRem(ulong2 x, out ulong2 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly ulong3 DivRem(ulong3 x, out ulong3 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly ulong4 DivRem(ulong4 x, out ulong4 remainder)
        {
            remainder = x % this;
            return      x / this;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly UInt128 DivRem(UInt128 x, out UInt128 remainder)
        {
            remainder = x % this;
            return      x / this;
        }
    }
}
