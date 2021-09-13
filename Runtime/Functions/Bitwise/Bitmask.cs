using DevTools;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns a 128-bit bitmask with all bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bitmask128(ulong numBits, ulong index = 0)
        {
Assert.IsBetween(index, 0u, 127u);
Assert.IsBetween(numBits, 0u, 128ul - index);

            return (uint)(bits_masktolowest((UInt128)1 << ((int)numBits - 1)) << (int)index); 
        }

        /// <summary>       Returns a 128-bit bitmask with all bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bitmask128(long numBits, long index = 0) => (Int128)bitmask128((ulong)numBits, (ulong)index);


        /// <summary>       Returns an 8-bit bitmask with all bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bitmask8(uint numBits, uint index = 0)
        {
Assert.IsBetween(index, 0u, 7u);
Assert.IsBetween(numBits, 0u, 8u - index);

            return (byte)(bits_masktolowest(1u << ((int)numBits - 1)) << (int)index); 
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.byte2"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bitmask8(byte2 numBits, byte2 index = default(byte2))
        {
Assert.IsBetween(index.x, 0u, 7u);
Assert.IsBetween(index.y, 0u, 7u);
Assert.IsBetween(numBits.x, 0u, 8u - index.x);
Assert.IsBetween(numBits.y, 0u, 8u - index.y);

            // mask
            index = shl(byte.MaxValue, index);

            if (Sse2.IsSse2Supported)
            {
                v128 isMaxBitsMask = Sse2.cmpeq_epi8(numBits, new byte2(8));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return (byte2)(-toshort(numBits == 16)) | andnot(index, shl(index, numBits));
            }
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.byte3"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bitmask8(byte3 numBits, byte3 index = default(byte3))
        {
Assert.IsBetween(index.x, 0u, 7u);
Assert.IsBetween(index.y, 0u, 7u);
Assert.IsBetween(index.z, 0u, 7u);
Assert.IsBetween(numBits.x, 0u, 8u - index.x);
Assert.IsBetween(numBits.y, 0u, 8u - index.y);
Assert.IsBetween(numBits.z, 0u, 8u - index.z);

            // mask
            index = shl(byte.MaxValue, index);

            if (Sse2.IsSse2Supported)
            {
                v128 isMaxBitsMask = Sse2.cmpeq_epi8(numBits, new byte4(8));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return (byte3)(-toshort(numBits == 16)) | andnot(index, shl(index, numBits));
            }
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.byte4"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bitmask8(byte4 numBits, byte4 index = default(byte4))
        {
Assert.IsBetween(index.x, 0u, 7u);
Assert.IsBetween(index.y, 0u, 7u);
Assert.IsBetween(index.z, 0u, 7u);
Assert.IsBetween(index.w, 0u, 7u);
Assert.IsBetween(numBits.x, 0u, 8u - index.x);
Assert.IsBetween(numBits.y, 0u, 8u - index.y);
Assert.IsBetween(numBits.z, 0u, 8u - index.z);
Assert.IsBetween(numBits.w, 0u, 8u - index.w);

            // mask
            index = shl(byte.MaxValue, index);

            if (Sse2.IsSse2Supported)
            {
                v128 isMaxBitsMask = Sse2.cmpeq_epi8(numBits, new byte4(8));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return (byte4)(-toshort(numBits == 16)) | andnot(index, shl(index, numBits));
            }
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.byte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bitmask8(byte8 numBits, byte8 index = default(byte8))
        {
Assert.IsBetween(index.x0, 0u, 7u);
Assert.IsBetween(index.x1, 0u, 7u);
Assert.IsBetween(index.x2, 0u, 7u);
Assert.IsBetween(index.x3, 0u, 7u);
Assert.IsBetween(index.x4, 0u, 7u);
Assert.IsBetween(index.x5, 0u, 7u);
Assert.IsBetween(index.x6, 0u, 7u);
Assert.IsBetween(index.x7, 0u, 7u);
Assert.IsBetween(numBits.x0, 0u, 8u - index.x0);
Assert.IsBetween(numBits.x1, 0u, 8u - index.x1);
Assert.IsBetween(numBits.x2, 0u, 8u - index.x2);
Assert.IsBetween(numBits.x3, 0u, 8u - index.x3);
Assert.IsBetween(numBits.x4, 0u, 8u - index.x4);
Assert.IsBetween(numBits.x5, 0u, 8u - index.x5);
Assert.IsBetween(numBits.x6, 0u, 8u - index.x6);
Assert.IsBetween(numBits.x7, 0u, 8u - index.x7);


            if (Sse2.IsSse2Supported)
            {
                // mask
                index = shl(byte.MaxValue, index);

                v128 isMaxBitsMask = Sse2.cmpeq_epi8(numBits, new byte8(8));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return (byte8)(-toshort(numBits == 16)) | andnot(index, shl(index, numBits));
            }
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.byte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bitmask8(byte16 numBits, byte16 index = default(byte16))
        {
Assert.IsBetween(index.x0,  0u, 7u);
Assert.IsBetween(index.x1,  0u, 7u);
Assert.IsBetween(index.x2,  0u, 7u);
Assert.IsBetween(index.x3,  0u, 7u);
Assert.IsBetween(index.x4,  0u, 7u);
Assert.IsBetween(index.x5,  0u, 7u);
Assert.IsBetween(index.x6,  0u, 7u);
Assert.IsBetween(index.x7,  0u, 7u);
Assert.IsBetween(index.x8,  0u, 7u);
Assert.IsBetween(index.x9,  0u, 7u);
Assert.IsBetween(index.x10, 0u, 7u);
Assert.IsBetween(index.x11, 0u, 7u);
Assert.IsBetween(index.x12, 0u, 7u);
Assert.IsBetween(index.x13, 0u, 7u);
Assert.IsBetween(index.x14, 0u, 7u);
Assert.IsBetween(index.x15, 0u, 7u);
Assert.IsBetween(numBits.x0,  0u, 8u - index.x0);
Assert.IsBetween(numBits.x1,  0u, 8u - index.x1);
Assert.IsBetween(numBits.x2,  0u, 8u - index.x2);
Assert.IsBetween(numBits.x3,  0u, 8u - index.x3);
Assert.IsBetween(numBits.x4,  0u, 8u - index.x4);
Assert.IsBetween(numBits.x5,  0u, 8u - index.x5);
Assert.IsBetween(numBits.x6,  0u, 8u - index.x6);
Assert.IsBetween(numBits.x7,  0u, 8u - index.x7);
Assert.IsBetween(numBits.x8,  0u, 8u - index.x8);
Assert.IsBetween(numBits.x9,  0u, 8u - index.x9);
Assert.IsBetween(numBits.x10, 0u, 8u - index.x10);
Assert.IsBetween(numBits.x11, 0u, 8u - index.x11);
Assert.IsBetween(numBits.x12, 0u, 8u - index.x12);
Assert.IsBetween(numBits.x13, 0u, 8u - index.x13);
Assert.IsBetween(numBits.x14, 0u, 8u - index.x14);
Assert.IsBetween(numBits.x15, 0u, 8u - index.x15);


            if (Sse2.IsSse2Supported)
            {
                // mask
                index = shl(byte.MaxValue, index);

                v128 isMaxBitsMask = Sse2.cmpeq_epi8(numBits, new byte16(8));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return new byte16(bitmask8(numBits.v8_0, index.v8_0), bitmask8(numBits.v8_8, index.v8_8));
            }
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.byte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bitmask8(byte32 numBits, byte32 index = default(byte32))
        {
Assert.IsBetween(index.x0,  0u, 7u);
Assert.IsBetween(index.x1,  0u, 7u);
Assert.IsBetween(index.x2,  0u, 7u);
Assert.IsBetween(index.x3,  0u, 7u);
Assert.IsBetween(index.x4,  0u, 7u);
Assert.IsBetween(index.x5,  0u, 7u);
Assert.IsBetween(index.x6,  0u, 7u);
Assert.IsBetween(index.x7,  0u, 7u);
Assert.IsBetween(index.x8,  0u, 7u);
Assert.IsBetween(index.x9,  0u, 7u);
Assert.IsBetween(index.x10, 0u, 7u);
Assert.IsBetween(index.x11, 0u, 7u);
Assert.IsBetween(index.x12, 0u, 7u);
Assert.IsBetween(index.x13, 0u, 7u);
Assert.IsBetween(index.x14, 0u, 7u);
Assert.IsBetween(index.x15, 0u, 7u);
Assert.IsBetween(index.x16, 0u, 7u);
Assert.IsBetween(index.x17, 0u, 7u);
Assert.IsBetween(index.x18, 0u, 7u);
Assert.IsBetween(index.x19, 0u, 7u);
Assert.IsBetween(index.x20, 0u, 7u);
Assert.IsBetween(index.x21, 0u, 7u);
Assert.IsBetween(index.x22, 0u, 7u);
Assert.IsBetween(index.x23, 0u, 7u);
Assert.IsBetween(index.x24, 0u, 7u);
Assert.IsBetween(index.x25, 0u, 7u);
Assert.IsBetween(index.x26, 0u, 7u);
Assert.IsBetween(index.x27, 0u, 7u);
Assert.IsBetween(index.x28, 0u, 7u);
Assert.IsBetween(index.x29, 0u, 7u);
Assert.IsBetween(index.x30, 0u, 7u);
Assert.IsBetween(index.x31, 0u, 7u);
Assert.IsBetween(numBits.x0,  0u, 8u - index.x0);
Assert.IsBetween(numBits.x1,  0u, 8u - index.x1);
Assert.IsBetween(numBits.x2,  0u, 8u - index.x2);
Assert.IsBetween(numBits.x3,  0u, 8u - index.x3);
Assert.IsBetween(numBits.x4,  0u, 8u - index.x4);
Assert.IsBetween(numBits.x5,  0u, 8u - index.x5);
Assert.IsBetween(numBits.x6,  0u, 8u - index.x6);
Assert.IsBetween(numBits.x7,  0u, 8u - index.x7);
Assert.IsBetween(numBits.x8,  0u, 8u - index.x8);
Assert.IsBetween(numBits.x9,  0u, 8u - index.x9);
Assert.IsBetween(numBits.x10, 0u, 8u - index.x10);
Assert.IsBetween(numBits.x11, 0u, 8u - index.x11);
Assert.IsBetween(numBits.x12, 0u, 8u - index.x12);
Assert.IsBetween(numBits.x13, 0u, 8u - index.x13);
Assert.IsBetween(numBits.x14, 0u, 8u - index.x14);
Assert.IsBetween(numBits.x15, 0u, 8u - index.x15);
Assert.IsBetween(numBits.x16, 0u, 8u - index.x16);
Assert.IsBetween(numBits.x17, 0u, 8u - index.x17);
Assert.IsBetween(numBits.x18, 0u, 8u - index.x18);
Assert.IsBetween(numBits.x19, 0u, 8u - index.x19);
Assert.IsBetween(numBits.x20, 0u, 8u - index.x20);
Assert.IsBetween(numBits.x21, 0u, 8u - index.x21);
Assert.IsBetween(numBits.x22, 0u, 8u - index.x22);
Assert.IsBetween(numBits.x23, 0u, 8u - index.x23);
Assert.IsBetween(numBits.x24, 0u, 8u - index.x24);
Assert.IsBetween(numBits.x25, 0u, 8u - index.x25);
Assert.IsBetween(numBits.x26, 0u, 8u - index.x26);
Assert.IsBetween(numBits.x27, 0u, 8u - index.x27);
Assert.IsBetween(numBits.x28, 0u, 8u - index.x28);
Assert.IsBetween(numBits.x29, 0u, 8u - index.x29);
Assert.IsBetween(numBits.x30, 0u, 8u - index.x30);
Assert.IsBetween(numBits.x31, 0u, 8u - index.x31);


            if (Avx2.IsAvx2Supported)
            {
                // mask
                index = shl(byte.MaxValue, index);

                v256 isMaxBitsMask = Avx2.mm256_cmpeq_epi8(numBits, new byte32(8));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return new byte32(bitmask8(numBits.v16_0, index.v16_0), bitmask8(numBits.v16_16, index.v16_16));
            }
        }


        /// <summary>       Returns a 16-bit bitmask with all bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bitmask16(uint numBits, uint index = 0)
        {
Assert.IsBetween(index, 0u, 15u);
Assert.IsBetween(numBits, 0u, 16u - index);

            return (ushort)(bits_masktolowest(1u << ((int)numBits - 1)) << (int)index); 
        }

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.ushort2"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bitmask16(ushort2 numBits, ushort2 index = default(ushort2))
        {
Assert.IsBetween(index.x, 0u, 15u);
Assert.IsBetween(index.y, 0u, 15u);
Assert.IsBetween(numBits.x, 0u, 16u - index.x);
Assert.IsBetween(numBits.y, 0u, 16u - index.y);

            // mask
            index = shl(ushort.MaxValue, index);

            if (Sse2.IsSse2Supported)
            {
                v128 isMaxBitsMask = Sse2.cmpeq_epi16(numBits, new ushort2(16));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return (ushort2)(-toshort(numBits == 16)) | andnot(index, shl(index, numBits));
            }
        }

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.ushort3"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bitmask16(ushort3 numBits, ushort3 index = default(ushort3))
        {
Assert.IsBetween(index.x, 0u, 15u);
Assert.IsBetween(index.y, 0u, 15u);
Assert.IsBetween(index.z, 0u, 15u);
Assert.IsBetween(numBits.x, 0u, 16u - index.x);
Assert.IsBetween(numBits.y, 0u, 16u - index.y);
Assert.IsBetween(numBits.z, 0u, 16u - index.z);

            // mask
            index = shl(ushort.MaxValue, index);

            if (Sse2.IsSse2Supported)
            {
                v128 isMaxBitsMask = Sse2.cmpeq_epi16(numBits, new ushort4(16));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return (ushort3)(-toshort(numBits == 16)) | andnot(index, shl(index, numBits));
            }
        }

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.ushort4"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bitmask16(ushort4 numBits, ushort4 index = default(ushort4))
        {
Assert.IsBetween(index.x, 0u, 15u);
Assert.IsBetween(index.y, 0u, 15u);
Assert.IsBetween(index.z, 0u, 15u);
Assert.IsBetween(index.w, 0u, 15u);
Assert.IsBetween(numBits.x, 0u, 16u - index.x);
Assert.IsBetween(numBits.y, 0u, 16u - index.y);
Assert.IsBetween(numBits.z, 0u, 16u - index.z);
Assert.IsBetween(numBits.w, 0u, 16u - index.w);

            // mask
            index = shl(ushort.MaxValue, index);

            if (Sse2.IsSse2Supported)
            {
                v128 isMaxBitsMask = Sse2.cmpeq_epi16(numBits, new ushort4(16));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return (ushort4)(-toshort(numBits == 16)) | andnot(index, shl(index, numBits));
            }
        }

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.ushort8"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bitmask16(ushort8 numBits, ushort8 index = default(ushort8))
        {
Assert.IsBetween(index.x0, 0u, 15u);
Assert.IsBetween(index.x1, 0u, 15u);
Assert.IsBetween(index.x2, 0u, 15u);
Assert.IsBetween(index.x3, 0u, 15u);
Assert.IsBetween(index.x4, 0u, 15u);
Assert.IsBetween(index.x5, 0u, 15u);
Assert.IsBetween(index.x6, 0u, 15u);
Assert.IsBetween(index.x7, 0u, 15u);
Assert.IsBetween(numBits.x0, 0u, 16u - index.x0);
Assert.IsBetween(numBits.x1, 0u, 16u - index.x1);
Assert.IsBetween(numBits.x2, 0u, 16u - index.x2);
Assert.IsBetween(numBits.x3, 0u, 16u - index.x3);
Assert.IsBetween(numBits.x4, 0u, 16u - index.x4);
Assert.IsBetween(numBits.x5, 0u, 16u - index.x5);
Assert.IsBetween(numBits.x6, 0u, 16u - index.x6);
Assert.IsBetween(numBits.x7, 0u, 16u - index.x7);


            if (Sse2.IsSse2Supported)
            {
                // mask
                index = shl(ushort.MaxValue, index);

                v128 isMaxBitsMask = Sse2.cmpeq_epi16(numBits, new ushort8(16));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return (ushort8)(-toshort(numBits == 16)) | andnot(index, shl(index, numBits));
            }
        }

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.ushort8"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bitmask16(ushort16 numBits, ushort16 index = default(ushort16))
        {
Assert.IsBetween(index.x0,  0u, 15u);
Assert.IsBetween(index.x1,  0u, 15u);
Assert.IsBetween(index.x2,  0u, 15u);
Assert.IsBetween(index.x3,  0u, 15u);
Assert.IsBetween(index.x4,  0u, 15u);
Assert.IsBetween(index.x5,  0u, 15u);
Assert.IsBetween(index.x6,  0u, 15u);
Assert.IsBetween(index.x7,  0u, 15u);
Assert.IsBetween(index.x8,  0u, 15u);
Assert.IsBetween(index.x9,  0u, 15u);
Assert.IsBetween(index.x10, 0u, 15u);
Assert.IsBetween(index.x11, 0u, 15u);
Assert.IsBetween(index.x12, 0u, 15u);
Assert.IsBetween(index.x13, 0u, 15u);
Assert.IsBetween(index.x14, 0u, 15u);
Assert.IsBetween(index.x15, 0u, 15u);
Assert.IsBetween(numBits.x0,  0u, 16u - index.x0);
Assert.IsBetween(numBits.x1,  0u, 16u - index.x1);
Assert.IsBetween(numBits.x2,  0u, 16u - index.x2);
Assert.IsBetween(numBits.x3,  0u, 16u - index.x3);
Assert.IsBetween(numBits.x4,  0u, 16u - index.x4);
Assert.IsBetween(numBits.x5,  0u, 16u - index.x5);
Assert.IsBetween(numBits.x6,  0u, 16u - index.x6);
Assert.IsBetween(numBits.x7,  0u, 16u - index.x7);
Assert.IsBetween(numBits.x8,  0u, 16u - index.x8);
Assert.IsBetween(numBits.x9,  0u, 16u - index.x9);
Assert.IsBetween(numBits.x10, 0u, 16u - index.x10);
Assert.IsBetween(numBits.x11, 0u, 16u - index.x11);
Assert.IsBetween(numBits.x12, 0u, 16u - index.x12);
Assert.IsBetween(numBits.x13, 0u, 16u - index.x13);
Assert.IsBetween(numBits.x14, 0u, 16u - index.x14);
Assert.IsBetween(numBits.x15, 0u, 16u - index.x15);


            if (Avx2.IsAvx2Supported)
            {
                // mask
                index = shl(ushort.MaxValue, index);

                v256 isMaxBitsMask = Avx2.mm256_cmpeq_epi16(numBits, new ushort16(16));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return new ushort16(bitmask16(numBits.v8_0, index.v8_0), bitmask16(numBits.v8_8, index.v8_8));
            }
        }


        /// <summary>       Returns a 32-bit bitmask with all bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bitmask32(uint numBits, uint index = 0)
        {
Assert.IsBetween(index, 0u, 31u);
Assert.IsBetween(numBits, 0u, 32u - index);

            return (uint)(bits_masktolowest(1ul << ((int)numBits - 1)) << (int)index); 
        }

        /// <summary>       Returns a 32-bit bitmask <see cref="uint2"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bitmask32(uint2 numBits, uint2 index = default(uint2))
        {
Assert.IsBetween(index.x, 0u, 31u);
Assert.IsBetween(index.y, 0u, 31u);
Assert.IsBetween(numBits.x, 0u, 32u - index.x);
Assert.IsBetween(numBits.y, 0u, 32u - index.y);

            // mask
            index = shl(uint.MaxValue, index);

            if (Sse2.IsSse2Supported)
            {
                v128 isMaxBitsMask = Sse2.cmpeq_epi32(UnityMathematicsLink.Tov128(numBits), new v128(32));

                return (*(uint2*)&isMaxBitsMask) | andnot(index, shl(index, numBits));
            }
            else
            {
                return (uint2)(-toint(numBits == 32)) | andnot(index, shl(index, numBits));
            }
        }

        /// <summary>       Returns a 32-bit bitmask <see cref="uint3"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bitmask32(uint3 numBits, uint3 index = default(uint3))
        {
Assert.IsBetween(index.x, 0u, 31u);
Assert.IsBetween(index.y, 0u, 31u);
Assert.IsBetween(index.z, 0u, 31u);
Assert.IsBetween(numBits.x, 0u, 32u - index.x);
Assert.IsBetween(numBits.y, 0u, 32u - index.y);
Assert.IsBetween(numBits.z, 0u, 32u - index.z);

            // mask
            index = shl(uint.MaxValue, index);

            if (Sse2.IsSse2Supported)
            {
                v128 isMaxBitsMask = Sse2.cmpeq_epi32(UnityMathematicsLink.Tov128(numBits), new v128(32));

                return (*(uint3*)&isMaxBitsMask) | andnot(index, shl(index, numBits));
            }
            else
            {
                return (uint3)(-toint(numBits == 32)) | andnot(index, shl(index, numBits));
            }
        }

        /// <summary>       Returns a 32-bit bitmask <see cref="uint4"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bitmask32(uint4 numBits, uint4 index = default(uint4))
        {
Assert.IsBetween(index.x, 0u, 31u);
Assert.IsBetween(index.y, 0u, 31u);
Assert.IsBetween(index.z, 0u, 31u);
Assert.IsBetween(index.w, 0u, 31u);
Assert.IsBetween(numBits.x, 0u, 32u - index.x);
Assert.IsBetween(numBits.y, 0u, 32u - index.y);
Assert.IsBetween(numBits.z, 0u, 32u - index.z);
Assert.IsBetween(numBits.w, 0u, 32u - index.w);

            // mask
            index = shl(uint.MaxValue, index);

            if (Sse2.IsSse2Supported)
            {
                v128 isMaxBitsMask = Sse2.cmpeq_epi32(UnityMathematicsLink.Tov128(numBits), new v128(32));

                return (*(uint4*)&isMaxBitsMask) | andnot(index, shl(index, numBits));
            }
            else
            {
                return (uint4)(-toint(numBits == 32)) | andnot(index, shl(index, numBits));
            }
        }

        /// <summary>       Returns a 32-bit bitmask <see cref="MaxMath.uint8"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bitmask32(uint8 numBits, uint8 index = default(uint8))
        {
Assert.IsBetween(index.x0, 0u, 31u);
Assert.IsBetween(index.x1, 0u, 31u);
Assert.IsBetween(index.x2, 0u, 31u);
Assert.IsBetween(index.x3, 0u, 31u);
Assert.IsBetween(index.x4, 0u, 31u);
Assert.IsBetween(index.x5, 0u, 31u);
Assert.IsBetween(index.x6, 0u, 31u);
Assert.IsBetween(index.x7, 0u, 31u);
Assert.IsBetween(numBits.x0, 0u, 32u - index.x0);
Assert.IsBetween(numBits.x1, 0u, 32u - index.x1);
Assert.IsBetween(numBits.x2, 0u, 32u - index.x2);
Assert.IsBetween(numBits.x3, 0u, 32u - index.x3);
Assert.IsBetween(numBits.x4, 0u, 32u - index.x4);
Assert.IsBetween(numBits.x5, 0u, 32u - index.x5);
Assert.IsBetween(numBits.x6, 0u, 32u - index.x6);
Assert.IsBetween(numBits.x7, 0u, 32u - index.x7);


            if (Avx2.IsAvx2Supported)
            {
                // mask
                index = shl(uint.MaxValue, index);

                v256 isMaxBitsMask = Avx2.mm256_cmpeq_epi32(numBits, new v256(32));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return new uint8(bitmask32(numBits.v4_0, index.v4_0), bitmask32(numBits.v4_4, index.v4_4));
            }
        }


        /// <summary>       Returns a 64-bit bitmask with all bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bitmask64(ulong numBits, ulong index = 0)
        {
Assert.IsBetween(index, 0ul, 63ul);
Assert.IsBetween(numBits, 0ul, 64ul - index);

            return bits_masktolowest(1ul << ((int)numBits - 1)) << (int)index;
        }

        /// <summary>       Returns a 64-bit bitmask <see cref="MaxMath.ulong2"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bitmask64(ulong2 numBits, ulong2 index = default(ulong2))
        {
Assert.IsBetween(index.x, 0ul, 63ul);
Assert.IsBetween(index.y, 0ul, 63ul);
Assert.IsBetween(numBits.x, 0ul, 64ul - index.x);
Assert.IsBetween(numBits.y, 0ul, 64ul - index.y);

            // mask
            index = shl(ulong.MaxValue, index);

            if (Sse2.IsSse2Supported)
            {
                v128 isMaxBitsMask = Operator.equals_mask_long(numBits, new v128(64ul));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return (ulong2)(-tolong(numBits == 64)) | andnot(index, shl(index, numBits));
            }
        }

        /// <summary>       Returns a 64-bit bitmask <see cref="MaxMath.ulong3"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bitmask64(ulong3 numBits, ulong3 index = default(ulong3))
        {
Assert.IsBetween(index.x, 0ul, 63ul);
Assert.IsBetween(index.y, 0ul, 63ul);
Assert.IsBetween(index.z, 0ul, 63ul);
Assert.IsBetween(numBits.x, 0ul, 64ul - index.x);
Assert.IsBetween(numBits.y, 0ul, 64ul - index.y);
Assert.IsBetween(numBits.z, 0ul, 64ul - index.z);

            if (Avx2.IsAvx2Supported)
            {
                // mask
                index = shl(ulong.MaxValue, index);

                v256 isMaxBitsMask = Avx2.mm256_cmpeq_epi64(numBits, new v256(64ul));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return new ulong3(bitmask64(numBits._xy, index._xy), bitmask64(numBits.z, index.z));
            }
        }

        /// <summary>       Returns a 64-bit bitmask <see cref="MaxMath.ulong4"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bitmask64(ulong4 numBits, ulong4 index = default(ulong4))
        {
Assert.IsBetween(index.x, 0ul, 63ul);
Assert.IsBetween(index.y, 0ul, 63ul);
Assert.IsBetween(index.z, 0ul, 63ul);
Assert.IsBetween(index.w, 0ul, 63ul);
Assert.IsBetween(numBits.x, 0ul, 64ul - index.x);
Assert.IsBetween(numBits.y, 0ul, 64ul - index.y);
Assert.IsBetween(numBits.z, 0ul, 64ul - index.z);
Assert.IsBetween(numBits.w, 0ul, 64ul - index.w);

            if (Avx2.IsAvx2Supported)
            {
                // mask
                index = shl(ulong.MaxValue, index);

                v256 isMaxBitsMask = Avx2.mm256_cmpeq_epi64(numBits, new v256(64ul));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return new ulong4(bitmask64(numBits._xy, index._xy), bitmask64(numBits._zw, index._zw));
            }
        }


        /// <summary>       Returns an 8-bit bitmask with all bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bitmask8(int numBits, int index = 0) => (sbyte)bitmask8((uint)numBits, (uint)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.sbyte2"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bitmask8(sbyte2 numBits, sbyte2 index = default(sbyte2)) => (sbyte2)bitmask8((byte2)numBits, (byte2)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.sbyte3"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bitmask8(sbyte3 numBits, sbyte3 index = default(sbyte3)) => (sbyte3)bitmask8((byte3)numBits, (byte3)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.sbyte4"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bitmask8(sbyte4 numBits, sbyte4 index = default(sbyte4)) => (sbyte4)bitmask8((byte4)numBits, (byte4)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.sbyte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bitmask8(sbyte8 numBits, sbyte8 index = default(sbyte8)) => (sbyte8)bitmask8((byte8)numBits, (byte8)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.sbyte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bitmask8(sbyte16 numBits, sbyte16 index = default(sbyte16)) => (sbyte16)bitmask8((byte16)numBits, (byte16)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.sbyte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bitmask8(sbyte32 numBits, sbyte32 index = default(sbyte32)) => (sbyte32)bitmask8((byte32)numBits, (byte32)index);


        /// <summary>       Returns a 16-bit bitmask with all bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bitmask16(int numBits, int index = 0) => (short)bitmask16((uint)numBits, (uint)index);

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.short2"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bitmask16(short2 numBits, short2 index = default(short2)) => (short2)bitmask16((ushort2)numBits, (ushort2)index);

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.short3"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bitmask16(short3 numBits, short3 index = default(short3)) => (short3)bitmask16((ushort3)numBits, (ushort3)index);

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.short4"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bitmask16(short4 numBits, short4 index = default(short4)) => (short4)bitmask16((ushort4)numBits, (ushort4)index);

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.short8"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bitmask16(short8 numBits, short8 index = default(short8)) => (short8)bitmask16((ushort8)numBits, (ushort8)index);

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.short8"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bitmask16(short16 numBits, short16 index = default(short16)) => (short16)bitmask16((ushort16)numBits, (ushort16)index);


        /// <summary>       Returns a 32-bit bitmask with all bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bitmask32(int numBits, int index = 0) => (int)bitmask32((uint)numBits, (uint)index);

        /// <summary>       Returns a 32-bit bitmask <see cref="int2"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bitmask32(int2 numBits, int2 index = default(int2)) => (int2)bitmask32((uint2)numBits, (uint2)index);

        /// <summary>       Returns a 32-bit bitmask <see cref="int3"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bitmask32(int3 numBits, int3 index = default(int3)) => (int3)bitmask32((uint3)numBits, (uint3)index);

        /// <summary>       Returns a 32-bit bitmask <see cref="int4"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bitmask32(int4 numBits, int4 index = default(int4)) => (int4)bitmask32((uint4)numBits, (uint4)index);

        /// <summary>       Returns a 32-bit bitmask <see cref="MaxMath.int8"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bitmask32(int8 numBits, int8 index = default(int8)) => (int8)bitmask32((uint8)numBits, (uint8)index);


        /// <summary>       Returns a 64-bit bitmask with all bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bitmask64(long numBits, long index = 0) => (long)bitmask64((ulong)numBits, (ulong)index);

        /// <summary>       Returns a 64-bit bitmask <see cref="MaxMath.long2"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bitmask64(long2 numBits, long2 index = default(long2)) => (long2)bitmask64((ulong2)numBits, (ulong2)index);

        /// <summary>       Returns a 64-bit bitmask <see cref="MaxMath.long3"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bitmask64(long3 numBits, long3 index = default(long3)) => (long3)bitmask64((ulong3)numBits, (ulong3)index);

        /// <summary>       Returns a 64-bit bitmask <see cref="MaxMath.long4"/> with all componentwise bits set to 1 from <paramref name="index"/> to (<paramref name="index"/> + <paramref name="numBits"/> - 1) in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bitmask64(long4 numBits, long4 index = new long4()) => (long4)bitmask64((ulong4)numBits, (ulong4)index);
    }
}