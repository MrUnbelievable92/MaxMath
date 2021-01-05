using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]
    unsafe public struct Random8
    {
        public byte State;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Random8(byte seed = 0x3A)
        {
            State = seed;

            NextState();
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
        private byte NextState()
        {
Assert.AreNotEqual(State, 0);

            byte t = State;

            State = (byte)(State ^ (State << 7));
            State = (byte)(State ^ (State >> 5));
            State = (byte)(State ^ (State << 3));

            return t;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool NextBool()
        {
            uint result = NextState() & 1u;

            return *(bool*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2 NextBool2()
        {
            bool2 result = ((Random16)this).NextBool2();

            NextState();

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3 NextBool3()
        {
            bool3 result = ((Random32)this).NextBool3();

            NextState();

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4 NextBool4()
        {
            bool4 result = ((Random32)this).NextBool4();

            NextState();

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8 NextBool8()
        {
            bool8 result = ((Random64)this).NextBool8();

            NextState();

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16 NextBool16()
        {
            bool16 result = ((Random64)this).NextBool16();

            NextState();

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32 NextBool32()
        {
            bool32 result = ((Random64)this).NextBool32();

            NextState();

            return result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte NextSByte()
        {
            return (sbyte)(sbyte.MinValue ^ NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2 NextSByte2()
        {
            return sbyte.MinValue ^ new sbyte2((sbyte)NextState(), (sbyte)NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3 NextSByte3()
        {
            return sbyte.MinValue ^ new sbyte3((sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4 NextSByte4()
        {
            return sbyte.MinValue ^ new sbyte4((sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8 NextSByte8()
        {
            return sbyte.MinValue ^ new sbyte8((sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16 NextSByte16()
        {
            return sbyte.MinValue ^ new sbyte16((sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32 NextSByte32()
        {
            return sbyte.MinValue ^ new sbyte32((sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState(), (sbyte)NextState());
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte NextSByte(sbyte min, sbyte max)
        {
Assert.IsNotSmaller(max, min);

            return (sbyte)(min + (((uint)NextState() * (max - min)) >> 8));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2 NextSByte2(sbyte2 min, sbyte2 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);

            ushort2 t = (ushort2)(max - min) * new ushort2(NextState(), NextState());

            return min + Ssse3.shuffle_epi8(t, new v128(1 | (3 << 8),   0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3 NextSByte3(sbyte3 min, sbyte3 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);

            ushort3 t = (ushort3)(max - min) * new ushort3(NextState(), NextState(), NextState());

            return min + Ssse3.shuffle_epi8(t, new v128(1 | (3 << 8) | (5 << 16),     0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4 NextSByte4(sbyte4 min, sbyte4 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);
Assert.IsNotSmaller(max.w, min.w);

            ushort4 t = (ushort4)(max - min) * new ushort4(NextState(), NextState(), NextState(), NextState());

            return min + Ssse3.shuffle_epi8(t, new v128(1 | (3 << 8) | (5 << 16) | (7 << 24),     0, 0, 0));
        }

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

            ushort8 t = (ushort8)(max - min) * new ushort8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());

            return min + Ssse3.shuffle_epi8(t, new v128(1L | (3L << 8) | (5L << 16) | (7L << 24) | (9L << 32) | (11L << 40) | (13L << 48) | (15L << 56),     0L));
        }

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

            ushort16 t = (ushort16)(max - min) * new ushort16(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());

            t = Avx2.mm256_shuffle_epi8(t, new v256(1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0,
                                                    1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0));

            return min + Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(t, Sse.SHUFFLE(0, 0, 2, 0)));
        }

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

            max -= min;

            ushort16 lo = (ushort16)max.v16_0  * new ushort16(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());
            ushort16 hi = (ushort16)max.v16_16 * new ushort16(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());

            lo = Avx2.mm256_shuffle_epi8(lo, new v256(1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0,
                                                      1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0));
            hi = Avx2.mm256_shuffle_epi8(hi, new v256(1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0,
                                                      1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0));

            return min + new sbyte32(Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(lo, Sse.SHUFFLE(0, 0, 2, 0))),
                                     Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(hi, Sse.SHUFFLE(0, 0, 2, 0))));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte NextByte()
        {
            return (byte)(byte.MaxValue + NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2 NextByte2()
        {
            return byte.MaxValue + new byte2(NextState(), NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3 NextByte3()
        {
            return byte.MaxValue + new byte3(NextState(), NextState(), NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4 NextByte4()
        {
            return byte.MaxValue + new byte4(NextState(), NextState(), NextState(), NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte8 NextByte8()
        {
            return byte.MaxValue + new byte8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16 NextByte16()
        {
            return byte.MaxValue + new byte16(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32 NextByte32()
        {
            return byte.MaxValue + new byte32(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte NextByte(byte max)
        {
            return (byte)(((uint)NextState() * max) >> 8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2 NextByte(byte2 max)
        {
            short2 t = (short2)max * new short2(NextState(), NextState());

            return Ssse3.shuffle_epi8(t, new v128(1 | (3 << 8),     0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3 NextByte3(byte3 max)
        {
            short3 t = (short3)max * new short3(NextState(), NextState(), NextState());

            return Ssse3.shuffle_epi8(t, new v128(1 | (3 << 8) | (5 << 16),     0, 0, 0));

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4 NextByte4(byte4 max)
        {
            short4 t = (short4)max * new short4(NextState(), NextState(), NextState(), NextState());

            return Ssse3.shuffle_epi8(t, new v128(1 | (3 << 8) | (5 << 16) | (7 << 24),     0, 0, 0));

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte8 NextByte8(byte8 max)
        {
            short8 t = (short8)max * new short8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());

            return Ssse3.shuffle_epi8(t, new v128(1L | (3L << 8) | (5L << 16) | (7L << 24) | (9L << 32) | (11L << 40) | (13L << 48) | (15L << 56),     0L));

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16 NextByte16(byte16 max)
        {
            short16 t = (short16)max * new short16(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());

            t = Avx2.mm256_shuffle_epi8(t, new v256(1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0,
                                                    1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0));

            return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(t, Sse.SHUFFLE(0, 0, 2, 0)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32 NextByte32(byte32 max)
        {
            short16 lo = (short16)max.v16_0  * new short16(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());
            short16 hi = (short16)max.v16_16 * new short16(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());

            lo = Avx2.mm256_shuffle_epi8(lo, new v256(1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0,
                                                      1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0));
            hi = Avx2.mm256_shuffle_epi8(hi, new v256(1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0,
                                                      1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0));

            return new byte32(Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(lo, Sse.SHUFFLE(0, 0, 2, 0))),
                              Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(hi, Sse.SHUFFLE(0, 0, 2, 0))));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte NextByte(byte min, byte max)
        {
Assert.IsNotSmaller(max, min);

            return (byte)(min + (((uint)NextState() * (max - min)) >> 8));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2 NextByte2(byte2 min, byte2 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);

            short2 t = (short2)(max - min) * new short2(NextState(), NextState());

            return min + Ssse3.shuffle_epi8(t, new v128(1 | (3 << 8),   0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3 NextByte3(byte3 min, byte3 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);

            short3 t = (short3)(max - min) * new short3(NextState(), NextState(), NextState());

            return min + Ssse3.shuffle_epi8(t, new v128(1 | (3 << 8) | (5 << 16),     0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4 NextByte4(byte4 min, byte4 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);
Assert.IsNotSmaller(max.w, min.w);

            short4 t = (short4)(max - min) * new short4(NextState(), NextState(), NextState(), NextState());

            return min + Ssse3.shuffle_epi8(t, new v128(1 | (3 << 8) | (5 << 16) | (7 << 24),     0, 0, 0));
        }

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

            short8 t = (short8)(max - min) * new short8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());

            return min + Ssse3.shuffle_epi8(t, new v128(1L | (3L << 8) | (5L << 16) | (7L << 24) | (9L << 32) | (11L << 40) | (13L << 48) | (15L << 56),     0L));
        }

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

            short16 t = (short16)(max - min) * new short16(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());

            t = Avx2.mm256_shuffle_epi8(t, new v256(1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0,
                                                    1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0));

            return min + Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(t, Sse.SHUFFLE(0, 0, 2, 0)));
        }

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

            max -= min;

            short16 lo = (short16)max.v16_0  * new short16(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());
            short16 hi = (short16)max.v16_16 * new short16(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());

            lo = Avx2.mm256_shuffle_epi8(lo, new v256(1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0,
                                                      1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0));
            hi = Avx2.mm256_shuffle_epi8(hi, new v256(1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0,
                                                      1, 3, 5, 7, 9, 11, 13, 15,     0, 0, 0, 0, 0, 0, 0, 0));

            return min + new byte32(Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(lo, Sse.SHUFFLE(0, 0, 2, 0))),
                                    Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(hi, Sse.SHUFFLE(0, 0, 2, 0))));
        }
    }
}