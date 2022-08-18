using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using DevTools;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]
    unsafe public struct Random8
    {
        public byte State;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Random8(byte seed = 0b0111_1001)
        {
            State = seed;

            NextState();
        }

        
        /// <summary>       Returns a randomly seeded <see cref="Random8"/>.     </summary>
        public static Random8 New
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get 
            {
                byte seed = (byte)Environment.TickCount;
                seed += maxmath.tobyte(seed == 0);

                return new Random8(seed);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random16(Random8 input)
        {
            return new Random16(input.State);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random32(Random8 input)
        {
            return new Random32(input.State);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random64(Random8 input)
        {
            return new Random64(input.State);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random128(Random8 input)
        {
            return new Random128(input.State);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private byte NextState()
        {
Assert.AreNotEqual(State, 0);

            byte temp = State;

            State = (byte)(State ^ (State << 7));
            State = (byte)(State ^ (State >> 5));
            State = (byte)(State ^ (State << 3));

            return temp;
        }

        /// <summary>       Returns a uniformly random <see cref="bool"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool NextBool()
        {
            uint result = NextState() & 1u;

            return *(bool*)&result;
        }

        /// <summary>       Returns a uniformly random <see cref="bool2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2 NextBool2()
        {
            bool2 result = ((Random16)this).NextBool2();

            NextState();

            return result;
        }

        /// <summary>       Returns a uniformly random <see cref="bool3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3 NextBool3()
        {
            bool3 result = ((Random32)this).NextBool3();

            NextState();

            return result;
        }

        /// <summary>       Returns a uniformly random <see cref="bool4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4 NextBool4()
        {
            bool4 result = ((Random32)this).NextBool4();

            NextState();

            return result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.bool8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8 NextBool8()
        {
            bool8 result = ((Random64)this).NextBool8();

            NextState();

            return result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.bool16"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16 NextBool16()
        {
            bool16 result = ((Random64)this).NextBool16();

            NextState();

            return result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.bool32"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32 NextBool32()
        {
            bool32 result = ((Random64)this).NextBool32();

            NextState();

            return result;
        }


        /// <summary>       Returns a uniformly random <see cref="sbyte"/> in the interval [-127, 127].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte NextSByte()
        {
            return (sbyte)(sbyte.MinValue ^ NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.sbyte2"/> with all components in the interval [-127, 127].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2 NextSByte2()
        {
            return sbyte.MinValue ^ new sbyte2((sbyte)NextState(), (sbyte)NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.sbyte3"/> with all components in the interval [-127, 127].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3 NextSByte3()
        {
            return sbyte.MinValue ^ new sbyte3((sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.sbyte4"/> with all components in the interval [-127, 127].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4 NextSByte4()
        {
            return sbyte.MinValue ^ new sbyte4((sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.sbyte8"/> with all components in the interval [-127, 127].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8 NextSByte8()
        {
            return sbyte.MinValue ^ new sbyte8((sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.sbyte16"/> with all components in the interval [-127, 127].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16 NextSByte16()
        {
            return sbyte.MinValue ^ new sbyte16((sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.sbyte32"/> with all components in the interval [-127, 127].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32 NextSByte32()
        {
            return sbyte.MinValue ^ new sbyte32((sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState());
        }


        /// <summary>       Returns a uniformly random <see cref="sbyte"/> in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte NextSByte(sbyte min, sbyte max)
        {
Assert.IsNotSmaller(max, min);

            return (sbyte)(min + (((uint)NextState() * (max - min)) >> 8));
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.sbyte2"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2 NextSByte2(sbyte2 min, sbyte2 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
            
            if (Sse2.IsSse2Supported)
            {
                return min + Xse.mulhi_epu8(max - min, new byte2(NextState(), NextState()), 2);
            }
            else
            {
                return min + (sbyte2)(((ushort2)(max - min) * new ushort2(NextState(), NextState())) >> 8);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.sbyte3"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3 NextSByte3(sbyte3 min, sbyte3 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);
            
            if (Sse2.IsSse2Supported)
            {
                return min + Xse.mulhi_epu8(max - min, new byte3(NextState(), NextState(), NextState()), 3);
            }
            else
            {
                return min + (sbyte3)(((ushort3)(max - min) * new ushort3(NextState(), NextState(), NextState())) >> 8);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.sbyte4"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4 NextSByte4(sbyte4 min, sbyte4 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);
Assert.IsNotSmaller(max.w, min.w);
            
            if (Sse2.IsSse2Supported)
            {
                return min + Xse.mulhi_epu8(max - min, new byte4(NextState(), NextState(), NextState(), NextState()), 4);
            }
            else
            {
                return min + (sbyte4)(((ushort4)(max - min) * new ushort4(NextState(), NextState(), NextState(), NextState())) >> 8);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.sbyte8"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8 NextSByte8(sbyte8 min, sbyte8 max)
        {
Assert.IsNotSmaller(max.x0, min.x0);
Assert.IsNotSmaller(max.x1, min.x1);
Assert.IsNotSmaller(max.x2, min.x2);
Assert.IsNotSmaller(max.x3, min.x3);
Assert.IsNotSmaller(max.x4, min.x4);
Assert.IsNotSmaller(max.x5, min.x5);
Assert.IsNotSmaller(max.x6, min.x6);
Assert.IsNotSmaller(max.x7, min.x7);
            
            if (Sse2.IsSse2Supported)
            {
                return min + Xse.mulhi_epu8(max - min, new byte8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState()), 8);
            }
            else
            {
                return min + (sbyte8)(((ushort8)(max - min) * new ushort8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState())) >> 8);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.sbyte16"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16 NextSByte16(sbyte16 min, sbyte16 max)
        {
Assert.IsNotSmaller(max.x0,  min.x0);
Assert.IsNotSmaller(max.x1,  min.x1);
Assert.IsNotSmaller(max.x2,  min.x2);
Assert.IsNotSmaller(max.x3,  min.x3);
Assert.IsNotSmaller(max.x4,  min.x4);
Assert.IsNotSmaller(max.x5,  min.x5);
Assert.IsNotSmaller(max.x6,  min.x6);
Assert.IsNotSmaller(max.x7,  min.x7);
Assert.IsNotSmaller(max.x8,  min.x8);
Assert.IsNotSmaller(max.x9,  min.x9);
Assert.IsNotSmaller(max.x10, min.x10);
Assert.IsNotSmaller(max.x11, min.x11);
Assert.IsNotSmaller(max.x12, min.x12);
Assert.IsNotSmaller(max.x13, min.x13);
Assert.IsNotSmaller(max.x14, min.x14);
Assert.IsNotSmaller(max.x15, min.x15);
            
            if (Sse2.IsSse2Supported)
            {
                return min + Xse.mulhi_epu8(max - min, new byte16(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState()));
            }
            else
            {
                return new sbyte16(NextSByte8(min.v8_0, max.v8_0), NextSByte8(min.v8_8, max.v8_8));
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.sbyte32"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32 NextSByte32(sbyte32 min, sbyte32 max)
        {
Assert.IsNotSmaller(max.x0,  min.x0);
Assert.IsNotSmaller(max.x1,  min.x1);
Assert.IsNotSmaller(max.x2,  min.x2);
Assert.IsNotSmaller(max.x3,  min.x3);
Assert.IsNotSmaller(max.x4,  min.x4);
Assert.IsNotSmaller(max.x5,  min.x5);
Assert.IsNotSmaller(max.x6,  min.x6);
Assert.IsNotSmaller(max.x7,  min.x7);
Assert.IsNotSmaller(max.x8,  min.x8);
Assert.IsNotSmaller(max.x9,  min.x9);
Assert.IsNotSmaller(max.x10, min.x10);
Assert.IsNotSmaller(max.x11, min.x11);
Assert.IsNotSmaller(max.x12, min.x12);
Assert.IsNotSmaller(max.x13, min.x13);
Assert.IsNotSmaller(max.x14, min.x14);
Assert.IsNotSmaller(max.x15, min.x15);
Assert.IsNotSmaller(max.x16, min.x16);
Assert.IsNotSmaller(max.x17, min.x17);
Assert.IsNotSmaller(max.x18, min.x18);
Assert.IsNotSmaller(max.x19, min.x19);
Assert.IsNotSmaller(max.x20, min.x20);
Assert.IsNotSmaller(max.x21, min.x21);
Assert.IsNotSmaller(max.x22, min.x22);
Assert.IsNotSmaller(max.x23, min.x23);
Assert.IsNotSmaller(max.x24, min.x24);
Assert.IsNotSmaller(max.x25, min.x25);
Assert.IsNotSmaller(max.x26, min.x26);
Assert.IsNotSmaller(max.x27, min.x27);
Assert.IsNotSmaller(max.x28, min.x28);
Assert.IsNotSmaller(max.x29, min.x29);
Assert.IsNotSmaller(max.x30, min.x30);
Assert.IsNotSmaller(max.x31, min.x31);
            
            if (Avx2.IsAvx2Supported)
            {
                return min + Xse.mm256_mulhi_epu8(max - min, new byte32(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState()));
            }
            else
            {
                return new sbyte32(NextSByte8(min.v8_0, max.v8_0), NextSByte8(min.v8_8, max.v8_8), NextSByte8(min.v8_16, max.v8_16), NextSByte8(min.v8_24, max.v8_24));
            }
        }


        /// <summary>       Returns a uniformly random <see cref="byte"/> in the interval [0, 254].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte NextByte()
        {
            return (byte)(NextState() - 1);
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte2"/> with all components in the interval [0, 254].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2 NextByte2()
        {
            return byte.MaxValue + new byte2(NextState(), NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte3"/> with all components in the interval [0, 254].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3 NextByte3()
        {
            return byte.MaxValue + new byte3(NextState(), NextState(), NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte4"/> with all components in the interval [0, 254].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4 NextByte4()
        {
            return byte.MaxValue + new byte4(NextState(), NextState(), NextState(), NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte8"/> with all components in the interval [0, 254].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte8 NextByte8()
        {
            return byte.MaxValue + new byte8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte16"/> with all components in the interval [0, 254].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16 NextByte16()
        {
            return byte.MaxValue + new byte16(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte32"/> with all components in the interval [0, 254].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32 NextByte32()
        {
            return byte.MaxValue + new byte32(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());
        }


        /// <summary>       Returns a uniformly random <see cref="byte"/> in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte NextByte(byte max)
        {
            return (byte)(((uint)NextState() * max) >> 8);
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte2"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2 NextByte(byte2 max)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.mulhi_epu8(max, new byte2(NextState(), NextState()), 2);
            }
            else
            {
                return (byte2)(((short2)max * new short2(NextState(), NextState())) >> 8);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte3"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3 NextByte3(byte3 max)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.mulhi_epu8(max, new byte3(NextState(), NextState(), NextState()), 3);
            }
            else
            {
                return (byte3)(((short3)max * new short3(NextState(), NextState(), NextState())) >> 8);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte4"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4 NextByte4(byte4 max)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.mulhi_epu8(max, new byte4(NextState(), NextState(), NextState(), NextState()), 4);
            }
            else
            {
                return (byte4)(((short4)max * new short4(NextState(), NextState(), NextState(), NextState())) >> 8);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte8"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte8 NextByte8(byte8 max)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.mulhi_epu8(max, new byte8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState()), 8);
            }
            else
            {
                return (byte8)(((short8)max * new short8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState())) >> 8);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte16"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16 NextByte16(byte16 max)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.mulhi_epu8(max, new byte16(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState()));
            }
            else
            {
                return new byte16(NextByte8(max.v8_0), NextByte8(max.v8_8));
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte32"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32 NextByte32(byte32 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mulhi_epu8(max, new byte32(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState()));
            }
            else
            {
                return new byte32(NextByte8(max.v8_0), NextByte8(max.v8_8), NextByte8(max.v8_16), NextByte8(max.v8_24));
            }
        }


        /// <summary>       Returns a uniformly random <see cref="byte"/> in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte NextByte(byte min, byte max)
        {
Assert.IsNotSmaller(max, min);

            return (byte)(min + (((uint)NextState() * (max - min)) >> 8));
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte2"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2 NextByte2(byte2 min, byte2 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
            
            if (Sse2.IsSse2Supported)
            {
                return min + Xse.mulhi_epu8(max - min, new byte2(NextState(), NextState()), 2);
            }
            else
            {
                return min + (byte2)(((short2)(max - min) * new short2(NextState(), NextState())) >> 8);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte3"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3 NextByte3(byte3 min, byte3 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);
            
            if (Sse2.IsSse2Supported)
            {
                return min + Xse.mulhi_epu8(max - min, new byte3(NextState(), NextState(), NextState()), 3);
            }
            else
            {
                return min + (byte3)(((short3)(max - min) * new short3(NextState(), NextState(), NextState())) >> 8);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte4"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4 NextByte4(byte4 min, byte4 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);
Assert.IsNotSmaller(max.w, min.w);
            
            if (Sse2.IsSse2Supported)
            {
                return min + Xse.mulhi_epu8(max - min, new byte4(NextState(), NextState(), NextState(), NextState()), 4);
            }
            else
            {
                return min + (byte4)(((short4)(max - min) * new short4(NextState(), NextState(), NextState(), NextState())) >> 8);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte8"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte8 NextByte8(byte8 min, byte8 max)
        {
Assert.IsNotSmaller(max.x0, min.x0);
Assert.IsNotSmaller(max.x1, min.x1);
Assert.IsNotSmaller(max.x2, min.x2);
Assert.IsNotSmaller(max.x3, min.x3);
Assert.IsNotSmaller(max.x4, min.x4);
Assert.IsNotSmaller(max.x5, min.x5);
Assert.IsNotSmaller(max.x6, min.x6);
Assert.IsNotSmaller(max.x7, min.x7);

            if (Sse2.IsSse2Supported)
            {
                return min + Xse.mulhi_epu8(max - min, new byte8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState()), 8);
            }
            else
            {
                return min + (byte8)(((short8)(max - min) * new short8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState())) >> 8);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte16"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16 NextByte16(byte16 min, byte16 max)
        {
Assert.IsNotSmaller(max.x0,  min.x0);
Assert.IsNotSmaller(max.x1,  min.x1);
Assert.IsNotSmaller(max.x2,  min.x2);
Assert.IsNotSmaller(max.x3,  min.x3);
Assert.IsNotSmaller(max.x4,  min.x4);
Assert.IsNotSmaller(max.x5,  min.x5);
Assert.IsNotSmaller(max.x6,  min.x6);
Assert.IsNotSmaller(max.x7,  min.x7);
Assert.IsNotSmaller(max.x8,  min.x8);
Assert.IsNotSmaller(max.x9,  min.x9);
Assert.IsNotSmaller(max.x10, min.x10);
Assert.IsNotSmaller(max.x11, min.x11);
Assert.IsNotSmaller(max.x12, min.x12);
Assert.IsNotSmaller(max.x13, min.x13);
Assert.IsNotSmaller(max.x14, min.x14);
Assert.IsNotSmaller(max.x15, min.x15);

            if (Sse2.IsSse2Supported)
            {
                return min + Xse.mulhi_epu8(max - min, new byte16(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState()));
            }
            else
            {
                return new byte16(NextByte8(min.v8_0, max.v8_0), NextByte8(min.v8_8, max.v8_8));
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.byte32"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32 NextByte32(byte32 min, byte32 max)
        {
Assert.IsNotSmaller(max.x0,  min.x0);
Assert.IsNotSmaller(max.x1,  min.x1);
Assert.IsNotSmaller(max.x2,  min.x2);
Assert.IsNotSmaller(max.x3,  min.x3);
Assert.IsNotSmaller(max.x4,  min.x4);
Assert.IsNotSmaller(max.x5,  min.x5);
Assert.IsNotSmaller(max.x6,  min.x6);
Assert.IsNotSmaller(max.x7,  min.x7);
Assert.IsNotSmaller(max.x8,  min.x8);
Assert.IsNotSmaller(max.x9,  min.x9);
Assert.IsNotSmaller(max.x10, min.x10);
Assert.IsNotSmaller(max.x11, min.x11);
Assert.IsNotSmaller(max.x12, min.x12);
Assert.IsNotSmaller(max.x13, min.x13);
Assert.IsNotSmaller(max.x14, min.x14);
Assert.IsNotSmaller(max.x15, min.x15);
Assert.IsNotSmaller(max.x16, min.x16);
Assert.IsNotSmaller(max.x17, min.x17);
Assert.IsNotSmaller(max.x18, min.x18);
Assert.IsNotSmaller(max.x19, min.x19);
Assert.IsNotSmaller(max.x20, min.x20);
Assert.IsNotSmaller(max.x21, min.x21);
Assert.IsNotSmaller(max.x22, min.x22);
Assert.IsNotSmaller(max.x23, min.x23);
Assert.IsNotSmaller(max.x24, min.x24);
Assert.IsNotSmaller(max.x25, min.x25);
Assert.IsNotSmaller(max.x26, min.x26);
Assert.IsNotSmaller(max.x27, min.x27);
Assert.IsNotSmaller(max.x28, min.x28);
Assert.IsNotSmaller(max.x29, min.x29);
Assert.IsNotSmaller(max.x30, min.x30);
Assert.IsNotSmaller(max.x31, min.x31);

            if (Avx2.IsAvx2Supported)
            {
                return min + Xse.mm256_mulhi_epu8(max - min, new byte32(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState()));
            }
            else
            {
                return new byte32(NextByte16(min.v16_0, max.v16_0), NextByte16(min.v16_16, max.v16_16));
            }
        }
    }
}