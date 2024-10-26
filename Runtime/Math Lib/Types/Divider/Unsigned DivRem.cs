using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public partial struct Divider<T>
        where T : unmanaged, IEquatable<T>, IFormattable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T DivRem(byte x, out T remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2 DivRem(byte2 x, out byte2 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3 DivRem(byte3 x, out byte3 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4 DivRem(byte4 x, out byte4 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte8 DivRem(byte8 x, out byte8 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16 DivRem(byte16 x, out byte16 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32 DivRem(byte32 x, out byte32 remainder)
        {
            remainder = x % this;
            return      x / this;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T DivRem(ushort x, out T remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2 DivRem(ushort2 x, out ushort2 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3 DivRem(ushort3 x, out ushort3 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4 DivRem(ushort4 x, out ushort4 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8 DivRem(ushort8 x, out ushort8 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort16 DivRem(ushort16 x, out ushort16 remainder)
        {
            remainder = x % this;
            return      x / this;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T DivRem(uint x, out T remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2 DivRem(uint2 x, out uint2 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3 DivRem(uint3 x, out uint3 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4 DivRem(uint4 x, out uint4 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8 DivRem(uint8 x, out uint8 remainder)
        {
            remainder = x % this;
            return      x / this;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T DivRem(ulong x, out T remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2 DivRem(ulong2 x, out ulong2 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3 DivRem(ulong3 x, out ulong3 remainder)
        {
            remainder = x % this;
            return      x / this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4 DivRem(ulong4 x, out ulong4 remainder)
        {
            remainder = x % this;
            return      x / this;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128 DivRem(UInt128 x, out UInt128 remainder)
        {
            remainder = x % this;
            return      x / this;
        }
    }
}
