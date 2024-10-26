using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Creates a <see cref="UInt128"/> bit field from 16 <see cref="byte"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bitfield(byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7, byte x8, byte x9, byte x10, byte x11, byte x12, byte x13, byte x14, byte x15)
        {
            return new UInt128(bitfield(x0, x1, x2, x3, x4, x5, x6, x7), bitfield(x8, x9, x10, x11, x12, x13, x14, x15));
        }

        /// <summary>       Creates a <see cref="UInt128"/> bit field from 16 <see cref="sbyte"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bitfield(sbyte x0, sbyte x1, sbyte x2, sbyte x3, sbyte x4, sbyte x5, sbyte x6, sbyte x7, sbyte x8, sbyte x9, sbyte x10, sbyte x11, sbyte x12, sbyte x13, sbyte x14, sbyte x15)
        {
            return new UInt128(bitfield(x0, x1, x2, x3, x4, x5, x6, x7), bitfield(x8, x9, x10, x11, x12, x13, x14, x15));
        }

        /// <summary>       Creates a <see cref="UInt128"/> bit field from 8 <see cref="ushort"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bitfield(ushort x0, ushort x1, ushort x2, ushort x3, ushort x4, ushort x5, ushort x6, ushort x7)
        {
            return new UInt128(bitfield(x0, x1, x2, x3), bitfield(x4, x5, x6, x7));
        }

        /// <summary>       Creates a <see cref="UInt128"/> bit field from 8 <see cref="short"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bitfield(short x0, short x1, short x2, short x3, short x4, short x5, short x6, short x7)
        {
            return new UInt128(bitfield(x0, x1, x2, x3), bitfield(x4, x5, x6, x7));
        }

        /// <summary>       Creates a <see cref="UInt128"/> bit field from 4 <see cref="uint"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bitfield(uint x0, uint x1, uint x2, uint x3)
        {
            return new UInt128(bitfield(x0, x1), bitfield(x2, x3));
        }

        /// <summary>       Creates a <see cref="UInt128"/> bit field from 4 <see cref="int"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bitfield(int x0, int x1, int x2, int x3)
        {
            return new UInt128(bitfield(x0, x1), bitfield(x2, x3));
        }

        /// <summary>       Creates a <see cref="UInt128"/> bit field from 2 <see cref="ulong"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bitfield(ulong x0, ulong x1)
        {
            return new UInt128(x0, x1);
        }

        /// <summary>       Creates a <see cref="UInt128"/> bit field from 2 <see cref="long"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bitfield(long x0, long x1)
        {
            return new UInt128(x0, x1);
        }


        /// <summary>       Creates a <see cref="ushort"/> bit field from 2 <see cref="byte"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bitfield(byte x0, byte x1)
        {
            return (ushort)((uint)x0 + ((uint)x1 << 8));
        }

        /// <summary>       Creates a <see cref="MaxMath.ushort2"/> bit field vector from 2 <see cref="MaxMath.byte2"/> vectors by packing 2 <see cref="byte"/> components into the corresponding <see cref="ushort"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bitfield(byte2 x0, byte2 x1)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.unpacklo_epi8(x0, x1);
            }
            else
            {
                return new ushort2(bitfield(x0.x, x1.x), bitfield(x0.y, x1.y));
            }
        }

        /// <summary>       Creates a <see cref="MaxMath.ushort3"/> bit field vector from 2 <see cref="MaxMath.byte3"/> vectors by packing 2 <see cref="byte"/> components into the corresponding <see cref="ushort"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bitfield(byte3 x0, byte3 x1)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.unpacklo_epi8(x0, x1);
            }
            else
            {
                return new ushort3(bitfield(x0.x, x1.x), bitfield(x0.y, x1.y), bitfield(x0.z, x1.z));
            }
        }

        /// <summary>       Creates a <see cref="MaxMath.ushort4"/> bit field vector from 2 <see cref="MaxMath.byte4"/> vectors by packing 2 <see cref="byte"/> components into the corresponding <see cref="ushort"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bitfield(byte4 x0, byte4 x1)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.unpacklo_epi8(x0, x1);
            }
            else
            {
                return new ushort4(bitfield(x0.x, x1.x), bitfield(x0.y, x1.y), bitfield(x0.z, x1.z), bitfield(x0.w, x1.w));
            }
        }

        /// <summary>       Creates a <see cref="MaxMath.ushort8"/> bit field vector from 2 <see cref="MaxMath.byte8"/> vectors by packing 2 <see cref="byte"/> components into the corresponding <see cref="ushort"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bitfield(byte8 x0, byte8 x1)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.unpacklo_epi8(x0, x1);
            }
            else
            {
                return new ushort8(bitfield(x0.x0, x1.x0), bitfield(x0.x1, x1.x1), bitfield(x0.x2, x1.x2), bitfield(x0.x3, x1.x3), bitfield(x0.x4, x1.x4), bitfield(x0.x5, x1.x5), bitfield(x0.x6, x1.x6), bitfield(x0.x7, x1.x7));
            }
        }

        /// <summary>       Creates a <see cref="MaxMath.ushort16"/> bit field vector from 2 <see cref="MaxMath.byte16"/> vectors by packing 2 <see cref="byte"/> components into the corresponding <see cref="ushort"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bitfield(byte16 x0, byte16 x1)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 lo = Xse.unpacklo_epi8(x0, x1);
                v128 hi = Xse.unpackhi_epi8(x0, x1);

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(lo), hi, 1);
                }
                else
                {
                    return new ushort16(lo, hi);
                }
            }
            else
            {
                return new ushort16(bitfield(x0.x0, x1.x0), bitfield(x0.x1, x1.x1), bitfield(x0.x2, x1.x2), bitfield(x0.x3, x1.x3), bitfield(x0.x4, x1.x4), bitfield(x0.x5, x1.x5), bitfield(x0.x6, x1.x6), bitfield(x0.x7, x1.x7), bitfield(x0.x8, x1.x8), bitfield(x0.x9, x1.x9), bitfield(x0.x10, x1.x10), bitfield(x0.x11, x1.x11), bitfield(x0.x12, x1.x12), bitfield(x0.x13, x1.x13), bitfield(x0.x14, x1.x14), bitfield(x0.x15, x1.x15));
            }
        }


        /// <summary>       Creates a <see cref="ushort"/> bit field from 2 <see cref="sbyte"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bitfield(sbyte x0, sbyte x1)
        {
            return bitfield((byte)x0, (byte)x1);
        }

        /// <summary>       Creates a <see cref="MaxMath.ushort2"/> bit field vector from 2 <see cref="MaxMath.sbyte2"/> vectors by packing 2 <see cref="sbyte"/> components into the corresponding <see cref="ushort"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bitfield(sbyte2 x0, sbyte2 x1)
        {
            return bitfield((byte2)x0, (byte2)x1);
        }

        /// <summary>       Creates a <see cref="MaxMath.ushort3"/> bit field vector from 2 <see cref="MaxMath.sbyte3"/> vectors by packing 2 <see cref="sbyte"/> components into the corresponding <see cref="ushort"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bitfield(sbyte3 x0, sbyte3 x1)
        {
            return bitfield((byte3)x0, (byte3)x1);
        }

        /// <summary>       Creates a <see cref="MaxMath.ushort4"/> bit field vector from 2 <see cref="MaxMath.sbyte4"/> vectors by packing 2 <see cref="sbyte"/> components into the corresponding <see cref="ushort"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bitfield(sbyte4 x0, sbyte4 x1)
        {
            return bitfield((byte4)x0, (byte4)x1);
        }

        /// <summary>       Creates a <see cref="MaxMath.ushort8"/> bit field vector from 2 <see cref="MaxMath.sbyte8"/> vectors by packing 2 <see cref="sbyte"/> components into the corresponding <see cref="ushort"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bitfield(sbyte8 x0, sbyte8 x1)
        {
            return bitfield((byte8)x0, (byte8)x1);
        }

        /// <summary>       Creates a <see cref="MaxMath.ushort16"/> bit field vector from 2 <see cref="MaxMath.sbyte16"/> vectors by packing 2 <see cref="sbyte"/> components into the corresponding <see cref="ushort"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bitfield(sbyte16 x0, sbyte16 x1)
        {
            return bitfield((byte16)x0, (byte16)x1);
        }


        /// <summary>       Creates a <see cref="uint"/> bit field from 4 <see cref="byte"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bitfield(byte x0, byte x1, byte x2, byte x3)
        {
            return ((uint)x0 + ((uint)x1 << 8)) | (((uint)x2 << 16) | ((uint)x3 << 24));
        }

        /// <summary>       Creates a <see cref="uint2"/> bit field vector from 4 <see cref="MaxMath.byte2"/> vectors by packing 4 <see cref="byte"/> components into the corresponding <see cref="uint"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bitfield(byte2 x0, byte2 x1, byte2 x2, byte2 x3)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 lo0 = Xse.unpacklo_epi8(x0, x1);
                v128 lo1 = Xse.unpacklo_epi8(x2, x3);

                return RegisterConversion.ToUInt2(Xse.unpacklo_epi16(lo0, lo1));
            }
            else
            {
                return new uint2(bitfield(x0.x, x1.x, x2.x, x3.x), bitfield(x0.y, x1.y, x2.y, x3.y));
            }
        }

        /// <summary>       Creates a <see cref="uint3"/> bit field vector from 4 <see cref="MaxMath.byte3"/> vectors by packing 4 <see cref="byte"/> components into the corresponding <see cref="uint"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bitfield(byte3 x0, byte3 x1, byte3 x2, byte3 x3)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 lo0 = Xse.unpacklo_epi8(x0, x1);
                v128 lo1 = Xse.unpacklo_epi8(x2, x3);

                return RegisterConversion.ToUInt3(Xse.unpacklo_epi16(lo0, lo1));
            }
            else
            {
                return new uint3(bitfield(x0.x, x1.x, x2.x, x3.x), bitfield(x0.y, x1.y, x2.y, x3.y), bitfield(x0.z, x1.z, x2.z, x3.z));
            }
        }

        /// <summary>       Creates a <see cref="uint4"/> bit field vector from 4 <see cref="MaxMath.byte4"/> vectors by packing 4 <see cref="byte"/> components into the corresponding <see cref="uint"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bitfield(byte4 x0, byte4 x1, byte4 x2, byte4 x3)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 lo0 = Xse.unpacklo_epi8(x0, x1);
                v128 lo1 = Xse.unpacklo_epi8(x2, x3);

                return RegisterConversion.ToUInt4(Xse.unpacklo_epi16(lo0, lo1));
            }
            else
            {
                return new uint4(bitfield(x0.x, x1.x, x2.x, x3.x), bitfield(x0.y, x1.y, x2.y, x3.y), bitfield(x0.z, x1.z, x2.z, x3.z), bitfield(x0.w, x1.w, x2.w, x3.w));
            }
        }

        /// <summary>       Creates a <see cref="MaxMath.uint8"/> bit field vector from 4 <see cref="MaxMath.byte8"/> vectors by packing 4 <see cref="byte"/> components into the corresponding <see cref="uint"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bitfield(byte8 x0, byte8 x1, byte8 x2, byte8 x3)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 lo0 = Xse.unpacklo_epi8(x0, x1);
                v128 lo1 = Xse.unpacklo_epi8(x2, x3);
                v128 resultlo = Xse.unpacklo_epi16(lo0, lo1);
                v128 resulthi = Xse.unpackhi_epi16(lo0, lo1);

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(resultlo), resulthi, 1);
                }
                else
                {
                    return new uint8(RegisterConversion.ToUInt4(resultlo), RegisterConversion.ToUInt4(resulthi));
                }
            }
            else
            {
                return new uint8(bitfield(x0.x0, x1.x0, x2.x0, x3.x0),
                                 bitfield(x0.x1, x1.x1, x2.x1, x3.x1),
                                 bitfield(x0.x2, x1.x2, x2.x2, x3.x2),
                                 bitfield(x0.x3, x1.x3, x2.x3, x3.x3),
                                 bitfield(x0.x4, x1.x4, x2.x4, x3.x4),
                                 bitfield(x0.x5, x1.x5, x2.x5, x3.x5),
                                 bitfield(x0.x6, x1.x6, x2.x6, x3.x6),
                                 bitfield(x0.x7, x1.x7, x2.x7, x3.x7));
            }
        }


        /// <summary>       Creates a <see cref="uint"/> bit field from 4 <see cref="sbyte"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bitfield(sbyte x0, sbyte x1, sbyte x2, sbyte x3)
        {
            return bitfield((byte)x0, (byte)x1, (byte)x2, (byte)x3);
        }

        /// <summary>       Creates a <see cref="uint2"/> bit field vector from 4 <see cref="MaxMath.sbyte2"/> vectors by packing 4 <see cref="sbyte"/> components into the corresponding <see cref="uint"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bitfield(sbyte2 x0, sbyte2 x1, sbyte2 x2, sbyte2 x3)
        {
            return bitfield((byte2)x0, (byte2)x1, (byte2)x2, (byte2)x3);
        }

        /// <summary>       Creates a <see cref="uint3"/> bit field vector from 4 <see cref="MaxMath.sbyte3"/> vectors by packing 4 <see cref="sbyte"/> components into the corresponding <see cref="uint"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bitfield(sbyte3 x0, sbyte3 x1, sbyte3 x2, sbyte3 x3)
        {
            return bitfield((byte3)x0, (byte3)x1, (byte3)x2, (byte3)x3);
        }

        /// <summary>       Creates a <see cref="uint4"/> bit field vector from 4 <see cref="MaxMath.sbyte4"/> vectors by packing 4 <see cref="sbyte"/> components into the corresponding <see cref="uint"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bitfield(sbyte4 x0, sbyte4 x1, sbyte4 x2, sbyte4 x3)
        {
            return bitfield((byte4)x0, (byte4)x1, (byte4)x2, (byte4)x3);
        }

        /// <summary>       Creates a <see cref="MaxMath.uint8"/> bit field vector from 4 <see cref="MaxMath.sbyte8"/> vectors by packing 4 <see cref="sbyte"/> components into the corresponding <see cref="uint"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bitfield(sbyte8 x0, sbyte8 x1, sbyte8 x2, sbyte8 x3)
        {
            return bitfield((byte8)x0, (byte8)x1, (byte8)x2, (byte8)x3);
        }


        /// <summary>       Creates a <see cref="uint"/> bit field from 2 <see cref="ushort"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bitfield(ushort x0, ushort x1)
        {
            return (uint)x0 | ((uint)x1 << 16);
        }

        /// <summary>       Creates a <see cref="uint2"/> bit field vector from 2 <see cref="MaxMath.ushort2"/> vectors by packing 2 <see cref="ushort"/> components into the corresponding <see cref="uint"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bitfield(ushort2 x0, ushort2 x1)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.unpacklo_epi16(x0, x1));
            }
            else
            {
                return new uint2(bitfield(x0.x, x1.x), bitfield(x0.y, x1.y));
            }
        }

        /// <summary>       Creates a <see cref="uint3"/> bit field vector from 2 <see cref="MaxMath.ushort3"/> vectors by packing 2 <see cref="ushort"/> components into the corresponding <see cref="uint"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bitfield(ushort3 x0, ushort3 x1)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.unpacklo_epi16(x0, x1));
            }
            else
            {
                return new uint3(bitfield(x0.x, x1.x), bitfield(x0.y, x1.y), bitfield(x0.z, x1.z));
            }
        }

        /// <summary>       Creates a <see cref="uint4"/> bit field vector from 2 <see cref="MaxMath.ushort4"/> vectors by packing 2 <see cref="ushort"/> components into the corresponding <see cref="uint"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bitfield(ushort4 x0, ushort4 x1)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.unpacklo_epi16(x0, x1));
            }
            else
            {
                return new uint4(bitfield(x0.x, x1.x), bitfield(x0.y, x1.y), bitfield(x0.z, x1.z), bitfield(x0.w, x1.w));
            }
        }

        /// <summary>       Creates a <see cref="MaxMath.uint8"/> bit field vector from 2 <see cref="MaxMath.ushort8"/> vectors by packing 2 <see cref="ushort"/> components into the corresponding <see cref="uint"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bitfield(ushort8 x0, ushort8 x1)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 resultlo = Xse.unpacklo_epi16(x0, x1);
                v128 resulthi = Xse.unpackhi_epi16(x0, x1);

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(resultlo), resulthi, 1);
                }
                else
                {
                    return new uint8(RegisterConversion.ToUInt4(resultlo), RegisterConversion.ToUInt4(resulthi));
                }
            }
            else
            {
                return new uint8(bitfield(x0.x0, x1.x0),
                                 bitfield(x0.x1, x1.x1),
                                 bitfield(x0.x2, x1.x2),
                                 bitfield(x0.x3, x1.x3),
                                 bitfield(x0.x4, x1.x4),
                                 bitfield(x0.x5, x1.x5),
                                 bitfield(x0.x6, x1.x6),
                                 bitfield(x0.x7, x1.x7));
            }
        }


        /// <summary>       Creates a <see cref="uint"/> bit field from 2 <see cref="short"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bitfield(short x0, short x1)
        {
            return bitfield((ushort)x0, (ushort)x1);
        }

        /// <summary>       Creates a <see cref="uint2"/> bit field vector from 2 <see cref="MaxMath.short2"/> vectors by packing 2 <see cref="short"/> components into the corresponding <see cref="uint"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bitfield(short2 x0, short2 x1)
        {
            return bitfield((ushort2)x0, (ushort2)x1);
        }

        /// <summary>       Creates a <see cref="uint3"/> bit field vector from 2 <see cref="MaxMath.short3"/> vectors by packing 2 <see cref="short"/> components into the corresponding <see cref="uint"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bitfield(short3 x0, short3 x1)
        {
            return bitfield((ushort3)x0, (ushort3)x1);
        }

        /// <summary>       Creates a <see cref="uint4"/> bit field vector from 2 <see cref="MaxMath.short4"/> vectors by packing 2 <see cref="short"/> components into the corresponding <see cref="uint"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bitfield(short4 x0, short4 x1)
        {
            return bitfield((ushort4)x0, (ushort4)x1);
        }

        /// <summary>       Creates a <see cref="MaxMath.uint8"/> bit field vector from 2 <see cref="MaxMath.short8"/> vectors by packing 2 <see cref="short"/> components into the corresponding <see cref="uint"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bitfield(short8 x0, short8 x1)
        {
            return bitfield((ushort8)x0, (ushort8)x1);
        }


        /// <summary>       Creates a <see cref="ulong"/> bit field from 8 <see cref="byte"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bitfield(byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7)
        {
            return (((uint)x0 + ((uint)x1 << 8)) | (((uint)x2 << 16) | ((uint)x3 << 24))) | ((((ulong)x4 << 32) + ((ulong)x5 << 40)) + (((ulong)x6 << 48) | ((ulong)x7 << 56)));
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong2"/> bit field vector from 8 <see cref="MaxMath.byte2"/> vectors by packing 8 <see cref="byte"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bitfield(byte2 x0, byte2 x1, byte2 x2, byte2 x3, byte2 x4, byte2 x5, byte2 x6, byte2 x7)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 x01 = Xse.unpacklo_epi8(x0, x1);
                v128 x23 = Xse.unpacklo_epi8(x2, x3);
                v128 x45 = Xse.unpacklo_epi8(x4, x5);
                v128 x67 = Xse.unpacklo_epi8(x6, x7);

                v128 x0123 = Xse.unpacklo_epi16(x01, x23);
                v128 x4567 = Xse.unpacklo_epi16(x45, x67);

                return Xse.unpacklo_epi32(x0123, x4567);
            }
            else
            {
                return new ulong2(bitfield(x0.x, x1.x, x2.x, x3.x, x4.x, x5.x, x6.x, x7.x),
                                  bitfield(x0.y, x1.y, x2.y, x3.y, x4.y, x5.y, x6.y, x7.y));
            }
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong3"/> bit field vector from 8 <see cref="MaxMath.byte3"/> vectors by packing 8 <see cref="byte"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bitfield(byte3 x0, byte3 x1, byte3 x2, byte3 x3, byte3 x4, byte3 x5, byte3 x6, byte3 x7)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 x01 = Xse.unpacklo_epi8(x0, x1);
                v128 x23 = Xse.unpacklo_epi8(x2, x3);
                v128 x45 = Xse.unpacklo_epi8(x4, x5);
                v128 x67 = Xse.unpacklo_epi8(x6, x7);

                v128 x0123 = Xse.unpacklo_epi16(x01, x23);
                v128 x4567 = Xse.unpacklo_epi16(x45, x67);

                v128 resultlo = Xse.unpacklo_epi32(x0123, x4567);
                v128 resulthi = Xse.unpackhi_epi32(x0123, x4567);

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(resultlo), resulthi, 1);
                }
                else
                {
                    return new ulong3(resultlo, resulthi.ULong0);
                }
            }
            else
            {
                return new ulong3(bitfield(x0.x, x1.x, x2.x, x3.x, x4.x, x5.x, x6.x, x7.x),
                                  bitfield(x0.y, x1.y, x2.y, x3.y, x4.y, x5.y, x6.y, x7.y),
                                  bitfield(x0.z, x1.z, x2.z, x3.z, x4.z, x5.z, x6.z, x7.z));
            }
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong4"/> bit field vector from 8 <see cref="MaxMath.byte4"/> vectors by packing 8 <see cref="byte"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bitfield(byte4 x0, byte4 x1, byte4 x2, byte4 x3, byte4 x4, byte4 x5, byte4 x6, byte4 x7)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 x01 = Xse.unpacklo_epi8(x0, x1);
                v128 x23 = Xse.unpacklo_epi8(x2, x3);
                v128 x45 = Xse.unpacklo_epi8(x4, x5);
                v128 x67 = Xse.unpacklo_epi8(x6, x7);

                v128 x0123 = Xse.unpacklo_epi16(x01, x23);
                v128 x4567 = Xse.unpacklo_epi16(x45, x67);

                v128 resultlo = Xse.unpacklo_epi32(x0123, x4567);
                v128 resulthi = Xse.unpackhi_epi32(x0123, x4567);

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(resultlo), resulthi, 1);
                }
                else
                {
                    return new ulong4(resultlo, resulthi);
                }
            }
            else
            {
                return new ulong4(bitfield(x0.x, x1.x, x2.x, x3.x, x4.x, x5.x, x6.x, x7.x),
                                  bitfield(x0.y, x1.y, x2.y, x3.y, x4.y, x5.y, x6.y, x7.y),
                                  bitfield(x0.z, x1.z, x2.z, x3.z, x4.z, x5.z, x6.z, x7.z),
                                  bitfield(x0.w, x1.w, x2.w, x3.w, x4.w, x5.w, x6.w, x7.w));
            }
        }


        /// <summary>       Creates a <see cref="ulong"/> bit field from 8 <see cref="sbyte"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bitfield(sbyte x0, sbyte x1, sbyte x2, sbyte x3, sbyte x4, sbyte x5, sbyte x6, sbyte x7)
        {
            return bitfield((byte)x0, (byte)x1, (byte)x2, (byte)x3, (byte)x4, (byte)x5, (byte)x6, (byte)x7);
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong2"/> bit field vector from 8 <see cref="MaxMath.sbyte2"/> vectors by packing 8 <see cref="sbyte"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bitfield(sbyte2 x0, sbyte2 x1, sbyte2 x2, sbyte2 x3, sbyte2 x4, sbyte2 x5, sbyte2 x6, sbyte2 x7)
        {
            return bitfield((sbyte2)x0, (sbyte2)x1, (sbyte2)x2, (sbyte2)x3, (sbyte2)x4, (sbyte2)x5, (sbyte2)x6, (sbyte2)x7);
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong3"/> bit field vector from 8 <see cref="MaxMath.sbyte3"/> vectors by packing 8 <see cref="sbyte"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bitfield(sbyte3 x0, sbyte3 x1, sbyte3 x2, sbyte3 x3, sbyte3 x4, sbyte3 x5, sbyte3 x6, sbyte3 x7)
        {
            return bitfield((sbyte3)x0, (sbyte3)x1, (sbyte3)x2, (sbyte3)x3, (sbyte3)x4, (sbyte3)x5, (sbyte3)x6, (sbyte3)x7);
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong4"/> bit field vector from 8 <see cref="MaxMath.sbyte4"/> vectors by packing 8 <see cref="sbyte"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bitfield(sbyte4 x0, sbyte4 x1, sbyte4 x2, sbyte4 x3, sbyte4 x4, sbyte4 x5, sbyte4 x6, sbyte4 x7)
        {
            return bitfield((sbyte4)x0, (sbyte4)x1, (sbyte4)x2, (sbyte4)x3, (sbyte4)x4, (sbyte4)x5, (sbyte4)x6, (sbyte4)x7);
        }


        /// <summary>       Creates a <see cref="ulong"/> bit field from 4 <see cref="ushort"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bitfield(ushort x0, ushort x1, ushort x2, ushort x3)
        {
            return ((uint)x0 + ((uint)x1 << 16)) | (((ulong)x2 << 32) | ((ulong)x3 << 48));
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong2"/> bit field vector from 4 <see cref="MaxMath.ushort2"/> vectors by packing 4 <see cref="ushort"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bitfield(ushort2 x0, ushort2 x1, ushort2 x2, ushort2 x3)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 x01 = Xse.unpacklo_epi16(x0, x1);
                v128 x23 = Xse.unpacklo_epi16(x2, x3);

                return Xse.unpacklo_epi32(x01, x23);
            }
            else
            {
                return new ulong2(bitfield(x0.x, x1.x, x2.x, x3.x), bitfield(x0.y, x1.y, x2.y, x3.y));
            }
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong3"/> bit field vector from 4 <see cref="MaxMath.ushort3"/> vectors by packing 4 <see cref="ushort"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bitfield(ushort3 x0, ushort3 x1, ushort3 x2, ushort3 x3)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 x01 = Xse.unpacklo_epi16(x0, x1);
                v128 x23 = Xse.unpacklo_epi16(x2, x3);

                v128 resultlo = Xse.unpacklo_epi32(x01, x23);
                v128 resulthi = Xse.unpackhi_epi32(x01, x23);

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(resultlo), resulthi, 1);
                }
                else
                {
                    return new ulong3(resultlo, resulthi.ULong0);
                }
            }
            else
            {
                return new ulong3(bitfield(x0.x, x1.x, x2.x, x3.x), bitfield(x0.y, x1.y, x2.y, x3.y), bitfield(x0.z, x1.z, x2.z, x3.z));
            }
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong4"/> bit field vector from 4 <see cref="MaxMath.ushort4"/> vectors by packing 4 <see cref="ushort"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bitfield(ushort4 x0, ushort4 x1, ushort4 x2, ushort4 x3)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 x01 = Xse.unpacklo_epi16(x0, x1);
                v128 x23 = Xse.unpacklo_epi16(x2, x3);

                v128 resultlo = Xse.unpacklo_epi32(x01, x23);
                v128 resulthi = Xse.unpackhi_epi32(x01, x23);

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(resultlo), resulthi, 1);
                }
                else
                {
                    return new ulong4(resultlo, resulthi);
                }
            }
            else
            {
                return new ulong4(bitfield(x0.x, x1.x, x2.x, x3.x), bitfield(x0.y, x1.y, x2.y, x3.y), bitfield(x0.z, x1.z, x2.z, x3.z), bitfield(x0.w, x1.w, x2.w, x3.w));
            }
        }


        /// <summary>       Creates a <see cref="ulong"/> bit field from 4 <see cref="short"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bitfield(short x0, short x1, short x2, short x3)
        {
            return bitfield((ushort)x0, (ushort)x1, (ushort)x2, (ushort)x3);
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong2"/> bit field vector from 4 <see cref="MaxMath.short2"/> vectors by packing 4 <see cref="short"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bitfield(short2 x0, short2 x1, short2 x2, short2 x3)
        {
            return bitfield((ushort2)x0, (ushort2)x1, (ushort2)x2, (ushort2)x3);
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong3"/> bit field vector from 4 <see cref="MaxMath.short3"/> vectors by packing 4 <see cref="short"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bitfield(short3 x0, short3 x1, short3 x2, short3 x3)
        {
            return bitfield((ushort3)x0, (ushort3)x1, (ushort3)x2, (ushort3)x3);
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong4"/> bit field vector from 4 <see cref="MaxMath.short4"/> vectors by packing 4 <see cref="short"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bitfield(short4 x0, short4 x1, short4 x2, short4 x3)
        {
            return bitfield((ushort4)x0, (ushort4)x1, (ushort4)x2, (ushort4)x3);
        }


        /// <summary>       Creates a <see cref="ulong"/> bit field from 2 <see cref="uint"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bitfield(uint x0, uint x1)
        {
            return (ulong)x0 | ((ulong)x1 << 32);
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong2"/> bit field vector from 2 <see cref="uint2"/> vectors by packing 2 <see cref="uint"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bitfield(uint2 x0, uint2 x1)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.unpacklo_epi32(RegisterConversion.ToV128(x0), RegisterConversion.ToV128(x1));
            }
            else
            {
                return new ulong2(bitfield(x0.x, x1.x), bitfield(x0.y, x1.y));
            }
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong3"/> bit field vector from 2 <see cref="uint3"/> vectors by packing 2 <see cref="uint"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bitfield(uint3 x0, uint3 x1)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x0 = RegisterConversion.ToV128(x0);
                v128 _x1 = RegisterConversion.ToV128(x1);

                v128 resultlo = Xse.unpacklo_epi32(_x0, _x1);
                v128 resulthi = Xse.unpackhi_epi32(_x0, _x1);

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(resultlo), resulthi, 1);
                }
                else
                {
                    return new ulong3(resultlo, resulthi.ULong0);
                }
            }
            else
            {
                return new ulong3(bitfield(x0.x, x1.x), bitfield(x0.y, x1.y), bitfield(x0.z, x1.z));
            }
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong4"/> bit field vector from 2 <see cref="uint4"/> vectors by packing 2 <see cref="uint"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bitfield(uint4 x0, uint4 x1)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x0 = RegisterConversion.ToV128(x0);
                v128 _x1 = RegisterConversion.ToV128(x1);

                v128 resultlo = Xse.unpacklo_epi32(_x0, _x1);
                v128 resulthi = Xse.unpackhi_epi32(_x0, _x1);

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(resultlo), resulthi, 1);
                }
                else
                {
                    return new ulong4(resultlo, resulthi);
                }
            }
            else
            {
                return new ulong4(bitfield(x0.x, x1.x), bitfield(x0.y, x1.y), bitfield(x0.z, x1.z), bitfield(x0.w, x1.w));
            }
        }


        /// <summary>       Creates a <see cref="ulong"/> bit field from 2 <see cref="int"/>s, where the parameter order reflects the byte order of the return value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bitfield(int x0, int x1)
        {
            return bitfield((uint)x0, (uint)x1);
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong2"/> bit field vector from 2 <see cref="int2"/> vectors by packing 2 <see cref="int"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bitfield(int2 x0, int2 x1)
        {
            return bitfield((uint2)x0, (uint2)x1);
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong3"/> bit field vector from 2 <see cref="int3"/> vectors by packing 2 <see cref="int"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bitfield(int3 x0, int3 x1)
        {
            return bitfield((uint3)x0, (uint3)x1);
        }

        /// <summary>       Creates a <see cref="MaxMath.ulong4"/> bit field vector from 2 <see cref="int4"/> vectors by packing 2 <see cref="int"/> components into the corresponding <see cref="ulong"/> component, where the parameter order reflects the byte order of the return value for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bitfield(int4 x0, int4 x1)
        {
            return bitfield((uint4)x0, (uint4)x1);
        }
    }
}