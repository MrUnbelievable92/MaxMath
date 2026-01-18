using System;
using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static partial class t_Divider
    {
        private static void TestByte(Action<byte, byte, byte, byte> baseTest)
        {
            baseTest(0, byte.MaxValue / 3,      1, byte.MaxValue / 3);
            baseTest(0, byte.MaxValue / 3,      byte.MaxValue / 3, 2 * (byte.MaxValue / 3));
            baseTest(0, byte.MaxValue / 3,      2 * (byte.MaxValue / 3), byte.MaxValue);
            baseTest(byte.MaxValue / 3, 2 * (byte.MaxValue / 3),         1, byte.MaxValue / 3);
            baseTest(byte.MaxValue / 3, 2 * (byte.MaxValue / 3),         byte.MaxValue / 3, 2 * (byte.MaxValue / 3));
            baseTest(byte.MaxValue / 3, 2 * (byte.MaxValue / 3),         2 * (byte.MaxValue / 3), byte.MaxValue);
            baseTest(2 * (byte.MaxValue / 3), byte.MaxValue,         1, byte.MaxValue / 3);
            baseTest(2 * (byte.MaxValue / 3), byte.MaxValue,         byte.MaxValue / 3, 2 * (byte.MaxValue / 3));
            baseTest(2 * (byte.MaxValue / 3), byte.MaxValue,         2 * (byte.MaxValue / 3), byte.MaxValue);
        }

        private static void TestUShort(Action<ushort, ushort, ushort, ushort> baseTest)
        {
            baseTest(0, ushort.MaxValue / 3,      1, ushort.MaxValue / 3);
            baseTest(0, ushort.MaxValue / 3,      ushort.MaxValue / 3, 2 * (ushort.MaxValue / 3));
            baseTest(0, ushort.MaxValue / 3,      2 * (ushort.MaxValue / 3), ushort.MaxValue);
            baseTest(ushort.MaxValue / 3, 2 * (ushort.MaxValue / 3),         1, ushort.MaxValue / 3);
            baseTest(ushort.MaxValue / 3, 2 * (ushort.MaxValue / 3),         ushort.MaxValue / 3, 2 * (ushort.MaxValue / 3));
            baseTest(ushort.MaxValue / 3, 2 * (ushort.MaxValue / 3),         2 * (ushort.MaxValue / 3), ushort.MaxValue);
            baseTest(2 * (ushort.MaxValue / 3), ushort.MaxValue,         1, ushort.MaxValue / 3);
            baseTest(2 * (ushort.MaxValue / 3), ushort.MaxValue,         ushort.MaxValue / 3, 2 * (ushort.MaxValue / 3));
            baseTest(2 * (ushort.MaxValue / 3), ushort.MaxValue,         2 * (ushort.MaxValue / 3), ushort.MaxValue);
        }

        private static void TestUInt(Action<uint, uint, uint, uint> baseTest)
        {
            baseTest(0, uint.MaxValue / 3,      1, uint.MaxValue / 3);
            baseTest(0, uint.MaxValue / 3,      uint.MaxValue / 3, 2 * (uint.MaxValue / 3));
            baseTest(0, uint.MaxValue / 3,      2 * (uint.MaxValue / 3), uint.MaxValue);
            baseTest(uint.MaxValue / 3, 2 * (uint.MaxValue / 3),         1, uint.MaxValue / 3);
            baseTest(uint.MaxValue / 3, 2 * (uint.MaxValue / 3),         uint.MaxValue / 3, 2 * (uint.MaxValue / 3));
            baseTest(uint.MaxValue / 3, 2 * (uint.MaxValue / 3),         2 * (uint.MaxValue / 3), uint.MaxValue);
            baseTest(2 * (uint.MaxValue / 3), uint.MaxValue,         1, uint.MaxValue / 3);
            baseTest(2 * (uint.MaxValue / 3), uint.MaxValue,         uint.MaxValue / 3, 2 * (uint.MaxValue / 3));
            baseTest(2 * (uint.MaxValue / 3), uint.MaxValue,         2 * (uint.MaxValue / 3), uint.MaxValue);
        }

        private static void TestULong(Action<ulong, ulong, ulong, ulong> baseTest)
        {
            baseTest(0, ulong.MaxValue / 3,      1, ulong.MaxValue / 3);
            baseTest(0, ulong.MaxValue / 3,      ulong.MaxValue / 3, 2 * (ulong.MaxValue / 3));
            baseTest(0, ulong.MaxValue / 3,      2 * (ulong.MaxValue / 3), ulong.MaxValue);
            baseTest(ulong.MaxValue / 3, 2 * (ulong.MaxValue / 3),         1, ulong.MaxValue / 3);
            baseTest(ulong.MaxValue / 3, 2 * (ulong.MaxValue / 3),         ulong.MaxValue / 3, 2 * (ulong.MaxValue / 3));
            baseTest(ulong.MaxValue / 3, 2 * (ulong.MaxValue / 3),         2 * (ulong.MaxValue / 3), ulong.MaxValue);
            baseTest(2 * (ulong.MaxValue / 3), ulong.MaxValue,         1, ulong.MaxValue / 3);
            baseTest(2 * (ulong.MaxValue / 3), ulong.MaxValue,         ulong.MaxValue / 3, 2 * (ulong.MaxValue / 3));
            baseTest(2 * (ulong.MaxValue / 3), ulong.MaxValue,         2 * (ulong.MaxValue / 3), ulong.MaxValue);
        }

        private static void TestUInt128(Action<UInt128, UInt128, UInt128, UInt128> baseTest)
        {
            baseTest(0, UInt128.MaxValue / 3,      1, UInt128.MaxValue / 3);
            baseTest(0, UInt128.MaxValue / 3,      UInt128.MaxValue / 3, 2 * (UInt128.MaxValue / 3));
            baseTest(0, UInt128.MaxValue / 3,      2 * (UInt128.MaxValue / 3), UInt128.MaxValue);
            baseTest(UInt128.MaxValue / 3, 2 * (UInt128.MaxValue / 3),         1, UInt128.MaxValue / 3);
            baseTest(UInt128.MaxValue / 3, 2 * (UInt128.MaxValue / 3),         UInt128.MaxValue / 3, 2 * (UInt128.MaxValue / 3));
            baseTest(UInt128.MaxValue / 3, 2 * (UInt128.MaxValue / 3),         2 * (UInt128.MaxValue / 3), UInt128.MaxValue);
            baseTest(2 * (UInt128.MaxValue / 3), UInt128.MaxValue,         1, UInt128.MaxValue / 3);
            baseTest(2 * (UInt128.MaxValue / 3), UInt128.MaxValue,         UInt128.MaxValue / 3, 2 * (UInt128.MaxValue / 3));
            baseTest(2 * (UInt128.MaxValue / 3), UInt128.MaxValue,         2 * (UInt128.MaxValue / 3), UInt128.MaxValue);
        }


        private static void TestSByte(Action<sbyte, sbyte, sbyte, sbyte> baseTest)
        {
            baseTest(sbyte.MinValue, sbyte.MinValue,      1, sbyte.MaxValue / 3);
            baseTest(sbyte.MinValue, sbyte.MinValue,      sbyte.MaxValue / 3, 2 * (sbyte.MaxValue / 3));
            baseTest(sbyte.MinValue, sbyte.MinValue,      2 * (sbyte.MaxValue / 3), sbyte.MaxValue);
            baseTest(sbyte.MinValue, sbyte.MinValue,      sbyte.MinValue, 2 * (sbyte.MinValue / 3));
            baseTest(sbyte.MinValue, sbyte.MinValue,      2 * (sbyte.MinValue / 3), sbyte.MinValue / 3);
            baseTest(sbyte.MinValue, sbyte.MinValue,      sbyte.MinValue / 3, 0);

            baseTest(0, sbyte.MaxValue / 3,      1, sbyte.MaxValue / 3);
            baseTest(0, sbyte.MaxValue / 3,      sbyte.MaxValue / 3, 2 * (sbyte.MaxValue / 3));
            baseTest(0, sbyte.MaxValue / 3,      2 * (sbyte.MaxValue / 3), sbyte.MaxValue);
            baseTest(0, sbyte.MaxValue / 3,      sbyte.MinValue, 2 * (sbyte.MinValue / 3));
            baseTest(0, sbyte.MaxValue / 3,      2 * (sbyte.MinValue / 3), sbyte.MinValue / 3);
            baseTest(0, sbyte.MaxValue / 3,      sbyte.MinValue / 3, 0);
            baseTest(sbyte.MaxValue / 3, 2 * (sbyte.MaxValue / 3),         1, sbyte.MaxValue / 3);
            baseTest(sbyte.MaxValue / 3, 2 * (sbyte.MaxValue / 3),         sbyte.MaxValue / 3, 2 * (sbyte.MaxValue / 3));
            baseTest(sbyte.MaxValue / 3, 2 * (sbyte.MaxValue / 3),         2 * (sbyte.MaxValue / 3), sbyte.MaxValue);
            baseTest(sbyte.MaxValue / 3, 2 * (sbyte.MaxValue / 3),         sbyte.MinValue, 2 * (sbyte.MinValue / 3));
            baseTest(sbyte.MaxValue / 3, 2 * (sbyte.MaxValue / 3),         2 * (sbyte.MinValue / 3), sbyte.MinValue / 3);
            baseTest(sbyte.MaxValue / 3, 2 * (sbyte.MaxValue / 3),         sbyte.MinValue / 3, 0);
            baseTest(2 * (sbyte.MaxValue / 3), sbyte.MaxValue,         1, sbyte.MaxValue / 3);
            baseTest(2 * (sbyte.MaxValue / 3), sbyte.MaxValue,         sbyte.MaxValue / 3, 2 * (sbyte.MaxValue / 3));
            baseTest(2 * (sbyte.MaxValue / 3), sbyte.MaxValue,         2 * (sbyte.MaxValue / 3), sbyte.MaxValue);
            baseTest(2 * (sbyte.MaxValue / 3), sbyte.MaxValue,         sbyte.MinValue, 2 * (sbyte.MinValue / 3));
            baseTest(2 * (sbyte.MaxValue / 3), sbyte.MaxValue,         2 * (sbyte.MinValue / 3), sbyte.MinValue / 3);
            baseTest(2 * (sbyte.MaxValue / 3), sbyte.MaxValue,         sbyte.MinValue / 3, 0);

            baseTest(sbyte.MinValue, 2 * (sbyte.MinValue / 3),      1, sbyte.MaxValue / 3);
            baseTest(sbyte.MinValue, 2 * (sbyte.MinValue / 3),      sbyte.MaxValue / 3, 2 * (sbyte.MaxValue / 3));
            baseTest(sbyte.MinValue, 2 * (sbyte.MinValue / 3),      2 * (sbyte.MaxValue / 3), sbyte.MaxValue);
            baseTest(sbyte.MinValue, 2 * (sbyte.MinValue / 3),      sbyte.MinValue, 2 * (sbyte.MinValue / 3));
            baseTest(sbyte.MinValue, 2 * (sbyte.MinValue / 3),      2 * (sbyte.MinValue / 3), sbyte.MinValue / 3);
            baseTest(sbyte.MinValue, 2 * (sbyte.MinValue / 3),      sbyte.MinValue / 3, 0);
            baseTest(2 * (sbyte.MinValue / 3), sbyte.MinValue / 3,         1, sbyte.MaxValue / 3);
            baseTest(2 * (sbyte.MinValue / 3), sbyte.MinValue / 3,         sbyte.MaxValue / 3, 2 * (sbyte.MaxValue / 3));
            baseTest(2 * (sbyte.MinValue / 3), sbyte.MinValue / 3,         2 * (sbyte.MaxValue / 3), sbyte.MaxValue);
            baseTest(2 * (sbyte.MinValue / 3), sbyte.MinValue / 3,         sbyte.MinValue, 2 * (sbyte.MinValue / 3));
            baseTest(2 * (sbyte.MinValue / 3), sbyte.MinValue / 3,         2 * (sbyte.MinValue / 3), sbyte.MinValue / 3);
            baseTest(2 * (sbyte.MinValue / 3), sbyte.MinValue / 3,         sbyte.MinValue / 3, 0);
            baseTest(sbyte.MinValue / 3, 1,         1, sbyte.MaxValue / 3);
            baseTest(sbyte.MinValue / 3, 1,         sbyte.MaxValue / 3, 2 * (sbyte.MaxValue / 3));
            baseTest(sbyte.MinValue / 3, 1,         2 * (sbyte.MaxValue / 3), sbyte.MaxValue);
            baseTest(sbyte.MinValue / 3, 1,         sbyte.MinValue, 2 * (sbyte.MinValue / 3));
            baseTest(sbyte.MinValue / 3, 1,         2 * (sbyte.MinValue / 3), sbyte.MinValue / 3);
            baseTest(sbyte.MinValue / 3, 1,         sbyte.MinValue / 3, 0);
        }

        private static void TestShort(Action<short, short, short, short> baseTest)
        {
            baseTest(short.MinValue, short.MinValue,      1, short.MaxValue / 3);
            baseTest(short.MinValue, short.MinValue,      short.MaxValue / 3, 2 * (short.MaxValue / 3));
            baseTest(short.MinValue, short.MinValue,      2 * (short.MaxValue / 3), short.MaxValue);
            baseTest(short.MinValue, short.MinValue,      short.MinValue, 2 * (short.MinValue / 3));
            baseTest(short.MinValue, short.MinValue,      2 * (short.MinValue / 3), short.MinValue / 3);
            baseTest(short.MinValue, short.MinValue,      short.MinValue / 3, 0);

            baseTest(0, short.MaxValue / 3,      1, short.MaxValue / 3);
            baseTest(0, short.MaxValue / 3,      short.MaxValue / 3, 2 * (short.MaxValue / 3));
            baseTest(0, short.MaxValue / 3,      2 * (short.MaxValue / 3), short.MaxValue);
            baseTest(0, short.MaxValue / 3,      short.MinValue, 2 * (short.MinValue / 3));
            baseTest(0, short.MaxValue / 3,      2 * (short.MinValue / 3), short.MinValue / 3);
            baseTest(0, short.MaxValue / 3,      short.MinValue / 3, 0);
            baseTest(short.MaxValue / 3, 2 * (short.MaxValue / 3),         1, short.MaxValue / 3);
            baseTest(short.MaxValue / 3, 2 * (short.MaxValue / 3),         short.MaxValue / 3, 2 * (short.MaxValue / 3));
            baseTest(short.MaxValue / 3, 2 * (short.MaxValue / 3),         2 * (short.MaxValue / 3), short.MaxValue);
            baseTest(short.MaxValue / 3, 2 * (short.MaxValue / 3),         short.MinValue, 2 * (short.MinValue / 3));
            baseTest(short.MaxValue / 3, 2 * (short.MaxValue / 3),         2 * (short.MinValue / 3), short.MinValue / 3);
            baseTest(short.MaxValue / 3, 2 * (short.MaxValue / 3),         short.MinValue / 3, 0);
            baseTest(2 * (short.MaxValue / 3), short.MaxValue,         1, short.MaxValue / 3);
            baseTest(2 * (short.MaxValue / 3), short.MaxValue,         short.MaxValue / 3, 2 * (short.MaxValue / 3));
            baseTest(2 * (short.MaxValue / 3), short.MaxValue,         2 * (short.MaxValue / 3), short.MaxValue);
            baseTest(2 * (short.MaxValue / 3), short.MaxValue,         short.MinValue, 2 * (short.MinValue / 3));
            baseTest(2 * (short.MaxValue / 3), short.MaxValue,         2 * (short.MinValue / 3), short.MinValue / 3);
            baseTest(2 * (short.MaxValue / 3), short.MaxValue,         short.MinValue / 3, 0);

            baseTest(short.MinValue, 2 * (short.MinValue / 3),      1, short.MaxValue / 3);
            baseTest(short.MinValue, 2 * (short.MinValue / 3),      short.MaxValue / 3, 2 * (short.MaxValue / 3));
            baseTest(short.MinValue, 2 * (short.MinValue / 3),      2 * (short.MaxValue / 3), short.MaxValue);
            baseTest(short.MinValue, 2 * (short.MinValue / 3),      short.MinValue, 2 * (short.MinValue / 3));
            baseTest(short.MinValue, 2 * (short.MinValue / 3),      2 * (short.MinValue / 3), short.MinValue / 3);
            baseTest(short.MinValue, 2 * (short.MinValue / 3),      short.MinValue / 3, 0);
            baseTest(2 * (short.MinValue / 3), short.MinValue / 3,         1, short.MaxValue / 3);
            baseTest(2 * (short.MinValue / 3), short.MinValue / 3,         short.MaxValue / 3, 2 * (short.MaxValue / 3));
            baseTest(2 * (short.MinValue / 3), short.MinValue / 3,         2 * (short.MaxValue / 3), short.MaxValue);
            baseTest(2 * (short.MinValue / 3), short.MinValue / 3,         short.MinValue, 2 * (short.MinValue / 3));
            baseTest(2 * (short.MinValue / 3), short.MinValue / 3,         2 * (short.MinValue / 3), short.MinValue / 3);
            baseTest(2 * (short.MinValue / 3), short.MinValue / 3,         short.MinValue / 3, 0);
            baseTest(short.MinValue / 3, 1,         1, short.MaxValue / 3);
            baseTest(short.MinValue / 3, 1,         short.MaxValue / 3, 2 * (short.MaxValue / 3));
            baseTest(short.MinValue / 3, 1,         2 * (short.MaxValue / 3), short.MaxValue);
            baseTest(short.MinValue / 3, 1,         short.MinValue, 2 * (short.MinValue / 3));
            baseTest(short.MinValue / 3, 1,         2 * (short.MinValue / 3), short.MinValue / 3);
            baseTest(short.MinValue / 3, 1,         short.MinValue / 3, 0);
        }

        private static void TestInt(Action<int, int, int, int> baseTest)
        {
            try
            {
                baseTest(int.MinValue, int.MaxValue,      1, int.MaxValue / 3);
                baseTest(int.MinValue, int.MaxValue,      int.MaxValue / 3, 2 * (int.MaxValue / 3));
                baseTest(int.MinValue, int.MaxValue,      2 * (int.MaxValue / 3), int.MaxValue);
                baseTest(int.MinValue, int.MaxValue,      int.MinValue, 2 * (int.MinValue / 3));
                baseTest(int.MinValue, int.MaxValue,      2 * (int.MinValue / 3), int.MinValue / 3);
                baseTest(int.MinValue, int.MaxValue,      int.MinValue / 3, 0);

                baseTest(int.MinValue, 2 * (int.MinValue / 3),      1, int.MaxValue / 3);
                baseTest(int.MinValue, 2 * (int.MinValue / 3),      int.MaxValue / 3, 2 * (int.MaxValue / 3));
                baseTest(int.MinValue, 2 * (int.MinValue / 3),      2 * (int.MaxValue / 3), int.MaxValue);
                baseTest(int.MinValue, 2 * (int.MinValue / 3),      int.MinValue, 2 * (int.MinValue / 3));
                baseTest(int.MinValue, 2 * (int.MinValue / 3),      2 * (int.MinValue / 3), int.MinValue / 3);
                baseTest(int.MinValue, 2 * (int.MinValue / 3),      int.MinValue / 3, 0);
            }
            catch (OverflowException)
            {
                // MinValue / -1 => hardware exception (64bit/32bit narrowing division)
            }

            baseTest(0, int.MaxValue / 3,      1, int.MaxValue / 3);
            baseTest(0, int.MaxValue / 3,      int.MaxValue / 3, 2 * (int.MaxValue / 3));
            baseTest(0, int.MaxValue / 3,      2 * (int.MaxValue / 3), int.MaxValue);
            baseTest(0, int.MaxValue / 3,      int.MinValue, 2 * (int.MinValue / 3));
            baseTest(0, int.MaxValue / 3,      2 * (int.MinValue / 3), int.MinValue / 3);
            baseTest(0, int.MaxValue / 3,      int.MinValue / 3, 0);
            baseTest(int.MaxValue / 3, 2 * (int.MaxValue / 3),         1, int.MaxValue / 3);
            baseTest(int.MaxValue / 3, 2 * (int.MaxValue / 3),         int.MaxValue / 3, 2 * (int.MaxValue / 3));
            baseTest(int.MaxValue / 3, 2 * (int.MaxValue / 3),         2 * (int.MaxValue / 3), int.MaxValue);
            baseTest(int.MaxValue / 3, 2 * (int.MaxValue / 3),         int.MinValue, 2 * (int.MinValue / 3));
            baseTest(int.MaxValue / 3, 2 * (int.MaxValue / 3),         2 * (int.MinValue / 3), int.MinValue / 3);
            baseTest(int.MaxValue / 3, 2 * (int.MaxValue / 3),         int.MinValue / 3, 0);
            baseTest(2 * (int.MaxValue / 3), int.MaxValue,         1, int.MaxValue / 3);
            baseTest(2 * (int.MaxValue / 3), int.MaxValue,         int.MaxValue / 3, 2 * (int.MaxValue / 3));
            baseTest(2 * (int.MaxValue / 3), int.MaxValue,         2 * (int.MaxValue / 3), int.MaxValue);
            baseTest(2 * (int.MaxValue / 3), int.MaxValue,         int.MinValue, 2 * (int.MinValue / 3));
            baseTest(2 * (int.MaxValue / 3), int.MaxValue,         2 * (int.MinValue / 3), int.MinValue / 3);
            baseTest(2 * (int.MaxValue / 3), int.MaxValue,         int.MinValue / 3, 0);

            baseTest(2 * (int.MinValue / 3), int.MinValue / 3,         1, int.MaxValue / 3);
            baseTest(2 * (int.MinValue / 3), int.MinValue / 3,         int.MaxValue / 3, 2 * (int.MaxValue / 3));
            baseTest(2 * (int.MinValue / 3), int.MinValue / 3,         2 * (int.MaxValue / 3), int.MaxValue);
            baseTest(2 * (int.MinValue / 3), int.MinValue / 3,         int.MinValue, 2 * (int.MinValue / 3));
            baseTest(2 * (int.MinValue / 3), int.MinValue / 3,         2 * (int.MinValue / 3), int.MinValue / 3);
            baseTest(2 * (int.MinValue / 3), int.MinValue / 3,         int.MinValue / 3, 0);
            baseTest(int.MinValue / 3, 1,         1, int.MaxValue / 3);
            baseTest(int.MinValue / 3, 1,         int.MaxValue / 3, 2 * (int.MaxValue / 3));
            baseTest(int.MinValue / 3, 1,         2 * (int.MaxValue / 3), int.MaxValue);
            baseTest(int.MinValue / 3, 1,         int.MinValue, 2 * (int.MinValue / 3));
            baseTest(int.MinValue / 3, 1,         2 * (int.MinValue / 3), int.MinValue / 3);
            baseTest(int.MinValue / 3, 1,         int.MinValue / 3, 0);
        }

        private static void TestLong(Action<long, long, long, long> baseTest)
        {
            try
            {
                baseTest(long.MinValue, long.MinValue,      1, long.MaxValue / 3);
                baseTest(long.MinValue, long.MinValue,      long.MaxValue / 3, 2 * (long.MaxValue / 3));
                baseTest(long.MinValue, long.MinValue,      2 * (long.MaxValue / 3), long.MaxValue);
                baseTest(long.MinValue, long.MinValue,      long.MinValue, 2 * (long.MinValue / 3));
                baseTest(long.MinValue, long.MinValue,      2 * (long.MinValue / 3), long.MinValue / 3);
                baseTest(long.MinValue, long.MinValue,      long.MinValue / 3, 0);

                baseTest(long.MinValue, 2 * (long.MinValue / 3),      1, long.MaxValue / 3);
                baseTest(long.MinValue, 2 * (long.MinValue / 3),      long.MaxValue / 3, 2 * (long.MaxValue / 3));
                baseTest(long.MinValue, 2 * (long.MinValue / 3),      2 * (long.MaxValue / 3), long.MaxValue);
                baseTest(long.MinValue, 2 * (long.MinValue / 3),      long.MinValue, 2 * (long.MinValue / 3));
                baseTest(long.MinValue, 2 * (long.MinValue / 3),      2 * (long.MinValue / 3), long.MinValue / 3);
                baseTest(long.MinValue, 2 * (long.MinValue / 3),      long.MinValue / 3, 0);
            }
            catch (OverflowException)
            {
                // MinValue / -1 => hardware exception (128bit/64bit narrowing division)
            }

            baseTest(0, long.MaxValue / 3,      1, long.MaxValue / 3);
            baseTest(0, long.MaxValue / 3,      long.MaxValue / 3, 2 * (long.MaxValue / 3));
            baseTest(0, long.MaxValue / 3,      2 * (long.MaxValue / 3), long.MaxValue);
            baseTest(0, long.MaxValue / 3,      long.MinValue, 2 * (long.MinValue / 3));
            baseTest(0, long.MaxValue / 3,      2 * (long.MinValue / 3), long.MinValue / 3);
            baseTest(0, long.MaxValue / 3,      long.MinValue / 3, 0);
            baseTest(long.MaxValue / 3, 2 * (long.MaxValue / 3),         1, long.MaxValue / 3);
            baseTest(long.MaxValue / 3, 2 * (long.MaxValue / 3),         long.MaxValue / 3, 2 * (long.MaxValue / 3));
            baseTest(long.MaxValue / 3, 2 * (long.MaxValue / 3),         2 * (long.MaxValue / 3), long.MaxValue);
            baseTest(long.MaxValue / 3, 2 * (long.MaxValue / 3),         long.MinValue, 2 * (long.MinValue / 3));
            baseTest(long.MaxValue / 3, 2 * (long.MaxValue / 3),         2 * (long.MinValue / 3), long.MinValue / 3);
            baseTest(long.MaxValue / 3, 2 * (long.MaxValue / 3),         long.MinValue / 3, 0);
            baseTest(2 * (long.MaxValue / 3), long.MaxValue,         1, long.MaxValue / 3);
            baseTest(2 * (long.MaxValue / 3), long.MaxValue,         long.MaxValue / 3, 2 * (long.MaxValue / 3));
            baseTest(2 * (long.MaxValue / 3), long.MaxValue,         2 * (long.MaxValue / 3), long.MaxValue);
            baseTest(2 * (long.MaxValue / 3), long.MaxValue,         long.MinValue, 2 * (long.MinValue / 3));
            baseTest(2 * (long.MaxValue / 3), long.MaxValue,         2 * (long.MinValue / 3), long.MinValue / 3);
            baseTest(2 * (long.MaxValue / 3), long.MaxValue,         long.MinValue / 3, 0);

            baseTest(2 * (long.MinValue / 3), long.MinValue / 3,         1, long.MaxValue / 3);
            baseTest(2 * (long.MinValue / 3), long.MinValue / 3,         long.MaxValue / 3, 2 * (long.MaxValue / 3));
            baseTest(2 * (long.MinValue / 3), long.MinValue / 3,         2 * (long.MaxValue / 3), long.MaxValue);
            baseTest(2 * (long.MinValue / 3), long.MinValue / 3,         long.MinValue, 2 * (long.MinValue / 3));
            baseTest(2 * (long.MinValue / 3), long.MinValue / 3,         2 * (long.MinValue / 3), long.MinValue / 3);
            baseTest(2 * (long.MinValue / 3), long.MinValue / 3,         long.MinValue / 3, 0);
            baseTest(long.MinValue / 3, 1,         1, long.MaxValue / 3);
            baseTest(long.MinValue / 3, 1,         long.MaxValue / 3, 2 * (long.MaxValue / 3));
            baseTest(long.MinValue / 3, 1,         2 * (long.MaxValue / 3), long.MaxValue);
            baseTest(long.MinValue / 3, 1,         long.MinValue, 2 * (long.MinValue / 3));
            baseTest(long.MinValue / 3, 1,         2 * (long.MinValue / 3), long.MinValue / 3);
            baseTest(long.MinValue / 3, 1,         long.MinValue / 3, 0);
        }

        private static void TestInt128(Action<Int128, Int128, Int128, Int128> baseTest)
        {
            try
            {
                baseTest(Int128.MinValue, Int128.MinValue,      1, Int128.MaxValue / 3);
                baseTest(Int128.MinValue, Int128.MinValue,      Int128.MaxValue / 3, 2 * (Int128.MaxValue / 3));
                baseTest(Int128.MinValue, Int128.MinValue,      2 * (Int128.MaxValue / 3), Int128.MaxValue);
                baseTest(Int128.MinValue, Int128.MinValue,      Int128.MinValue, 2 * (Int128.MinValue / 3));
                baseTest(Int128.MinValue, Int128.MinValue,      2 * (Int128.MinValue / 3), Int128.MinValue / 3);
                baseTest(Int128.MinValue, Int128.MinValue,      Int128.MinValue / 3, 0);

                baseTest(Int128.MinValue, 2 * (Int128.MinValue / 3),      1, Int128.MaxValue / 3);
                baseTest(Int128.MinValue, 2 * (Int128.MinValue / 3),      Int128.MaxValue / 3, 2 * (Int128.MaxValue / 3));
                baseTest(Int128.MinValue, 2 * (Int128.MinValue / 3),      2 * (Int128.MaxValue / 3), Int128.MaxValue);
                baseTest(Int128.MinValue, 2 * (Int128.MinValue / 3),      Int128.MinValue, 2 * (Int128.MinValue / 3));
                baseTest(Int128.MinValue, 2 * (Int128.MinValue / 3),      2 * (Int128.MinValue / 3), Int128.MinValue / 3);
                baseTest(Int128.MinValue, 2 * (Int128.MinValue / 3),      Int128.MinValue / 3, 0);
            }
            catch (OverflowException)
            {
                // MinValue / -1 => hardware exception (128bit/64bit narrowing division)
            }

            baseTest(0, Int128.MaxValue / 3,      1, Int128.MaxValue / 3);
            baseTest(0, Int128.MaxValue / 3,      Int128.MaxValue / 3, 2 * (Int128.MaxValue / 3));
            baseTest(0, Int128.MaxValue / 3,      2 * (Int128.MaxValue / 3), Int128.MaxValue);
            baseTest(0, Int128.MaxValue / 3,      Int128.MinValue, 2 * (Int128.MinValue / 3));
            baseTest(0, Int128.MaxValue / 3,      2 * (Int128.MinValue / 3), Int128.MinValue / 3);
            baseTest(0, Int128.MaxValue / 3,      Int128.MinValue / 3, 0);
            baseTest(Int128.MaxValue / 3, 2 * (Int128.MaxValue / 3),         1, Int128.MaxValue / 3);
            baseTest(Int128.MaxValue / 3, 2 * (Int128.MaxValue / 3),         Int128.MaxValue / 3, 2 * (Int128.MaxValue / 3));
            baseTest(Int128.MaxValue / 3, 2 * (Int128.MaxValue / 3),         2 * (Int128.MaxValue / 3), Int128.MaxValue);
            baseTest(Int128.MaxValue / 3, 2 * (Int128.MaxValue / 3),         Int128.MinValue, 2 * (Int128.MinValue / 3));
            baseTest(Int128.MaxValue / 3, 2 * (Int128.MaxValue / 3),         2 * (Int128.MinValue / 3), Int128.MinValue / 3);
            baseTest(Int128.MaxValue / 3, 2 * (Int128.MaxValue / 3),         Int128.MinValue / 3, 0);
            baseTest(2 * (Int128.MaxValue / 3), Int128.MaxValue,         1, Int128.MaxValue / 3);
            baseTest(2 * (Int128.MaxValue / 3), Int128.MaxValue,         Int128.MaxValue / 3, 2 * (Int128.MaxValue / 3));
            baseTest(2 * (Int128.MaxValue / 3), Int128.MaxValue,         2 * (Int128.MaxValue / 3), Int128.MaxValue);
            baseTest(2 * (Int128.MaxValue / 3), Int128.MaxValue,         Int128.MinValue, 2 * (Int128.MinValue / 3));
            baseTest(2 * (Int128.MaxValue / 3), Int128.MaxValue,         2 * (Int128.MinValue / 3), Int128.MinValue / 3);
            baseTest(2 * (Int128.MaxValue / 3), Int128.MaxValue,         Int128.MinValue / 3, 0);

            baseTest(2 * (Int128.MinValue / 3), Int128.MinValue / 3,         1, Int128.MaxValue / 3);
            baseTest(2 * (Int128.MinValue / 3), Int128.MinValue / 3,         Int128.MaxValue / 3, 2 * (Int128.MaxValue / 3));
            baseTest(2 * (Int128.MinValue / 3), Int128.MinValue / 3,         2 * (Int128.MaxValue / 3), Int128.MaxValue);
            baseTest(2 * (Int128.MinValue / 3), Int128.MinValue / 3,         Int128.MinValue, 2 * (Int128.MinValue / 3));
            baseTest(2 * (Int128.MinValue / 3), Int128.MinValue / 3,         2 * (Int128.MinValue / 3), Int128.MinValue / 3);
            baseTest(2 * (Int128.MinValue / 3), Int128.MinValue / 3,         Int128.MinValue / 3, 0);
            baseTest(Int128.MinValue / 3, 1,         1, Int128.MaxValue / 3);
            baseTest(Int128.MinValue / 3, 1,         Int128.MaxValue / 3, 2 * (Int128.MaxValue / 3));
            baseTest(Int128.MinValue / 3, 1,         2 * (Int128.MaxValue / 3), Int128.MaxValue);
            baseTest(Int128.MinValue / 3, 1,         Int128.MinValue, 2 * (Int128.MinValue / 3));
            baseTest(Int128.MinValue / 3, 1,         2 * (Int128.MinValue / 3), Int128.MinValue / 3);
            baseTest(Int128.MinValue / 3, 1,         Int128.MinValue / 3, 0);
        }


        [Test]
        public static void _UInt128()
        {
            TestUInt128(
            (minL, maxL, minR, maxR) =>
            {
                Random128 rng = Random128.New;
                Divider<UInt128> d1 = new Divider<UInt128>((UInt128)1);
                Divider<UInt128> d2 = new Divider<UInt128>((UInt128)2);
                Divider<UInt128> pow2;

                for (int i = 0; i < 8; i++)
                {
                    UInt128 denum = rng.NextUInt128(minR, maxR);
                    Divider<UInt128> d = new Divider<UInt128>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        UInt128 num = rng.NextUInt128(minL, maxL);

                        UInt128 trueQuo = maxmath.divrem(num, denum, out UInt128 trueRem);
                        UInt128 quoTest = d.DivRem(num, out UInt128 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<UInt128>((UInt128)1 << (int)rng.NextUInt128(0, 128));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }


        [Test]
        public static void _ulong()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong> d1 = new Divider<ulong>((ulong)1);
                Divider<ulong> d2 = new Divider<ulong>((ulong)2);
                Divider<ulong> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong denum = rng.NextULong(minR, maxR);
                    Divider<ulong> d = new Divider<ulong>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ulong num = rng.NextULong(minL, maxL);

                        ulong trueQuo = maxmath.divrem(num, denum, out ulong trueRem);
                        ulong quoTest = d.DivRem(num, out ulong remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ulong>(1ul << (int)rng.NextULong(0, 64));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ulong2()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong2> d1 = new Divider<ulong2>((ulong2)1);
                Divider<ulong2> d2 = new Divider<ulong2>((ulong2)2);
                Divider<ulong2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong2 denum = rng.NextULong2(minR, maxR);
                    Divider<ulong2> d = new Divider<ulong2>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ulong2 num = rng.NextULong2(minL, maxL);

                        ulong2 trueQuo = maxmath.divrem(num, denum, out ulong2 trueRem);
                        ulong2 quoTest = d.DivRem(num, out ulong2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ulong2>(maxmath.shl(1ul, rng.NextULong2(0, 64)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ulong2_ulong()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong> d1 = new Divider<ulong>((ulong)1);
                Divider<ulong> d2 = new Divider<ulong>((ulong)2);
                Divider<ulong> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong denum = rng.NextULong(minR, maxR);
                    Divider<ulong> d = new Divider<ulong>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ulong2 num = rng.NextULong2(minL, maxL);

                        ulong2 trueQuo = maxmath.divrem(num, denum, out ulong2 trueRem);
                        ulong2 quoTest = d.DivRem(num, out ulong2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);

                        try
                        {
                        Assert.AreEqual(trueRem, remTest);
                        }
                        catch (Exception)
                        {
                            UnityEngine.Debug.Log(num);
                            throw;
                        }
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ulong>(1ul << (int)rng.NextULong(0, 64));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ulong_ulong2()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong2> d1 = new Divider<ulong2>((ulong2)1);
                Divider<ulong2> d2 = new Divider<ulong2>((ulong2)2);
                Divider<ulong2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong2 denum = rng.NextULong2(minR, maxR);
                    Divider<ulong2> d = new Divider<ulong2>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ulong num = rng.NextULong(minL, maxL);

                        ulong2 trueQuo = maxmath.divrem(num, denum, out ulong2 trueRem);
                        ulong2 quoTest = d.DivRem(num, out ulong2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ulong2>(maxmath.shl(1ul, rng.NextULong2(0, 64)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ulong3()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong3> d1 = new Divider<ulong3>((ulong3)1);
                Divider<ulong3> d2 = new Divider<ulong3>((ulong3)2);
                Divider<ulong3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong3 denum = rng.NextULong3(minR, maxR);
                    Divider<ulong3> d = new Divider<ulong3>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ulong3 num = rng.NextULong3(minL, maxL);

                        ulong3 trueQuo = maxmath.divrem(num, denum, out ulong3 trueRem);
                        ulong3 quoTest = d.DivRem(num, out ulong3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ulong3>(maxmath.shl(1ul, rng.NextULong3(0, 64)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ulong3_ulong()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong> d1 = new Divider<ulong>((ulong)1);
                Divider<ulong> d2 = new Divider<ulong>((ulong)2);
                Divider<ulong> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong denum = rng.NextULong(minR, maxR);
                    Divider<ulong> d = new Divider<ulong>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ulong3 num = rng.NextULong3(minL, maxL);

                        ulong3 trueQuo = maxmath.divrem(num, denum, out ulong3 trueRem);
                        ulong3 quoTest = d.DivRem(num, out ulong3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ulong>(1ul << (int)rng.NextULong(0, 64));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ulong_ulong3()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong3> d1 = new Divider<ulong3>((ulong3)1);
                Divider<ulong3> d2 = new Divider<ulong3>((ulong3)2);
                Divider<ulong3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong3 denum = rng.NextULong3(minR, maxR);
                    Divider<ulong3> d = new Divider<ulong3>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ulong num = rng.NextULong(minL, maxL);

                        ulong3 trueQuo = maxmath.divrem(num, denum, out ulong3 trueRem);
                        ulong3 quoTest = d.DivRem(num, out ulong3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ulong3>(maxmath.shl(1ul, rng.NextULong3(0, 64)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ulong4()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong4> d1 = new Divider<ulong4>((ulong4)1);
                Divider<ulong4> d2 = new Divider<ulong4>((ulong4)2);
                Divider<ulong4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong4 denum = rng.NextULong4(minR, maxR);
                    Divider<ulong4> d = new Divider<ulong4>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ulong4 num = rng.NextULong4(minL, maxL);

                        ulong4 trueQuo = maxmath.divrem(num, denum, out ulong4 trueRem);
                        ulong4 quoTest = d.DivRem(num, out ulong4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ulong4>(maxmath.shl(1ul, rng.NextULong4(0, 64)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ulong4_ulong()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong> d1 = new Divider<ulong>((ulong)1);
                Divider<ulong> d2 = new Divider<ulong>((ulong)2);
                Divider<ulong> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong denum = rng.NextULong(minR, maxR);
                    Divider<ulong> d = new Divider<ulong>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ulong4 num = rng.NextULong4(minL, maxL);

                        ulong4 trueQuo = maxmath.divrem(num, denum, out ulong4 trueRem);
                        ulong4 quoTest = d.DivRem(num, out ulong4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ulong>(1ul << (int)rng.NextULong(0, 64));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ulong_ulong4()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong4> d1 = new Divider<ulong4>((ulong4)1);
                Divider<ulong4> d2 = new Divider<ulong4>((ulong4)2);
                Divider<ulong4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong4 denum = rng.NextULong4(minR, maxR);
                    Divider<ulong4> d = new Divider<ulong4>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ulong num = rng.NextULong(minL, maxL);

                        ulong4 trueQuo = maxmath.divrem(num, denum, out ulong4 trueRem);
                        ulong4 quoTest = d.DivRem(num, out ulong4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ulong4>(maxmath.shl(1ul, rng.NextULong4(0, 64)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }


        [Test]
        public static void _uint()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint> d1 = new Divider<uint>((uint)1);
                Divider<uint> d2 = new Divider<uint>((uint)2);
                Divider<uint> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint denum = rng.NextUInt(minR, maxR);
                    Divider<uint> d = new Divider<uint>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        uint num = rng.NextUInt(minL, maxL);

                        uint trueQuo = maxmath.divrem(num, denum, out uint trueRem);
                        uint quoTest = d.DivRem(num, out uint remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<uint>(1u << (int)rng.NextUInt(0, 32));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _uint2()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint2> d1 = new Divider<uint2>((uint2)1);
                Divider<uint2> d2 = new Divider<uint2>((uint2)2);
                Divider<uint2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint2 denum = rng.NextUInt2(minR, maxR);
                    Divider<uint2> d = new Divider<uint2>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        uint2 num = rng.NextUInt2(minL, maxL);

                        uint2 trueQuo = maxmath.divrem(num, denum, out uint2 trueRem);
                        uint2 quoTest = d.DivRem(num, out uint2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<uint2>(maxmath.shl(1u, rng.NextUInt2(0, 32)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _uint2_uint()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint> d1 = new Divider<uint>((uint)1);
                Divider<uint> d2 = new Divider<uint>((uint)2);
                Divider<uint> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint denum = rng.NextUInt(minR, maxR);
                    Divider<uint> d = new Divider<uint>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        uint2 num = rng.NextUInt2(minL, maxL);

                        uint2 trueQuo = maxmath.divrem(num, denum, out uint2 trueRem);
                        uint2 quoTest = d.DivRem(num, out uint2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<uint>(1u << (int)rng.NextUInt(0, 32));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _uint_uint2()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint2> d1 = new Divider<uint2>((uint2)1);
                Divider<uint2> d2 = new Divider<uint2>((uint2)2);
                Divider<uint2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint2 denum = rng.NextUInt2(minR, maxR);
                    Divider<uint2> d = new Divider<uint2>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        uint num = rng.NextUInt(minL, maxL);

                        uint2 trueQuo = maxmath.divrem(num, denum, out uint2 trueRem);
                        uint2 quoTest = d.DivRem(num, out uint2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<uint2>(maxmath.shl(1u, rng.NextUInt2(0, 32)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _uint3()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint3> d1 = new Divider<uint3>((uint3)1);
                Divider<uint3> d2 = new Divider<uint3>((uint3)2);
                Divider<uint3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint3 denum = rng.NextUInt3(minR, maxR);
                    Divider<uint3> d = new Divider<uint3>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        uint3 num = rng.NextUInt3(minL, maxL);

                        uint3 trueQuo = maxmath.divrem(num, denum, out uint3 trueRem);
                        uint3 quoTest = d.DivRem(num, out uint3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<uint3>(maxmath.shl(1u, rng.NextUInt3(0, 32)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _uint3_uint()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint> d1 = new Divider<uint>((uint)1);
                Divider<uint> d2 = new Divider<uint>((uint)2);
                Divider<uint> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint denum = rng.NextUInt(minR, maxR);
                    Divider<uint> d = new Divider<uint>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        uint3 num = rng.NextUInt3(minL, maxL);

                        uint3 trueQuo = maxmath.divrem(num, denum, out uint3 trueRem);
                        uint3 quoTest = d.DivRem(num, out uint3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<uint>(1u << (int)rng.NextUInt(0, 32));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _uint_uint3()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint3> d1 = new Divider<uint3>((uint3)1);
                Divider<uint3> d2 = new Divider<uint3>((uint3)2);
                Divider<uint3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint3 denum = rng.NextUInt3(minL, maxL);
                    Divider<uint3> d = new Divider<uint3>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        uint num = rng.NextUInt(minR, maxR);

                        uint3 trueQuo = maxmath.divrem(num, denum, out uint3 trueRem);
                        uint3 quoTest = d.DivRem(num, out uint3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<uint3>(maxmath.shl(1u, rng.NextUInt3(0, 32)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _uint4()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint4> d1 = new Divider<uint4>((uint4)1);
                Divider<uint4> d2 = new Divider<uint4>((uint4)2);
                Divider<uint4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint4 denum = rng.NextUInt4(minR, maxR);
                    Divider<uint4> d = new Divider<uint4>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        uint4 num = rng.NextUInt4(minL, maxL);

                        uint4 trueQuo = maxmath.divrem(num, denum, out uint4 trueRem);
                        uint4 quoTest = d.DivRem(num, out uint4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<uint4>(maxmath.shl(1u, rng.NextUInt4(0, 32)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _uint4_uint()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint> d1 = new Divider<uint>((uint)1);
                Divider<uint> d2 = new Divider<uint>((uint)2);
                Divider<uint> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint denum = rng.NextUInt(minR, maxR);
                    Divider<uint> d = new Divider<uint>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        uint4 num = rng.NextUInt4(minL, maxL);

                        uint4 trueQuo = maxmath.divrem(num, denum, out uint4 trueRem);
                        uint4 quoTest = d.DivRem(num, out uint4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<uint>(1u << (int)rng.NextUInt(0, 32));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _uint_uint4()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint4> d1 = new Divider<uint4>((uint4)1);
                Divider<uint4> d2 = new Divider<uint4>((uint4)2);
                Divider<uint4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint4 denum = rng.NextUInt4(minR, maxR);
                    Divider<uint4> d = new Divider<uint4>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        uint num = rng.NextUInt(minL, maxL);

                        uint4 trueQuo = maxmath.divrem(num, denum, out uint4 trueRem);
                        uint4 quoTest = d.DivRem(num, out uint4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<uint4>(maxmath.shl(1u, rng.NextUInt4(0, 32)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _uint8()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint8> d1 = new Divider<uint8>((uint8)1);
                Divider<uint8> d2 = new Divider<uint8>((uint8)2);
                Divider<uint8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint8 denum = rng.NextUInt8(minR, maxR);
                    Divider<uint8> d = new Divider<uint8>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        uint8 num = rng.NextUInt8(minL, maxL);

                        uint8 trueQuo = maxmath.divrem(num, denum, out uint8 trueRem);
                        uint8 quoTest = d.DivRem(num, out uint8 remTest);

                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<uint8>(maxmath.shl(1u, rng.NextUInt8(0, 32)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _uint8_uint()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint> d1 = new Divider<uint>((uint)1);
                Divider<uint> d2 = new Divider<uint>((uint)2);
                Divider<uint> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint denum = rng.NextUInt(minR, maxR);
                    Divider<uint> d = new Divider<uint>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        uint8 num = rng.NextUInt8(minL, maxL);

                        uint8 trueQuo = maxmath.divrem(num, denum, out uint8 trueRem);
                        uint8 quoTest = d.DivRem(num, out uint8 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<uint>(1u << (int)rng.NextUInt(0, 32));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _uint_uint8()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint8> d1 = new Divider<uint8>((uint8)1);
                Divider<uint8> d2 = new Divider<uint8>((uint8)2);
                Divider<uint8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint8 denum = rng.NextUInt8(minR, maxR);
                    Divider<uint8> d = new Divider<uint8>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        uint num = rng.NextUInt(minL, maxL);

                        uint8 trueQuo = maxmath.divrem(num, denum, out uint8 trueRem);
                        uint8 quoTest = d.DivRem(num, out uint8 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<uint8>(maxmath.shl(1u, rng.NextUInt8(0, 32)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }


        [Test]
        public static void _ushort()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort> d1 = new Divider<ushort>((ushort)1);
                Divider<ushort> d2 = new Divider<ushort>((ushort)2);
                Divider<ushort> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort denum = rng.NextUShort(minR, maxR);
                    Divider<ushort> d = new Divider<ushort>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ushort num = rng.NextUShort(minL, maxL);

                        ushort trueQuo = maxmath.divrem(num, denum, out ushort trueRem);
                        ushort quoTest = d.DivRem(num, out ushort remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ushort>((ushort)(1u << (int)rng.NextUShort(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ushort2()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort2> d1 = new Divider<ushort2>((ushort2)1);
                Divider<ushort2> d2 = new Divider<ushort2>((ushort2)2);
                Divider<ushort2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort2 denum = rng.NextUShort2(minR, maxR);
                    Divider<ushort2> d = new Divider<ushort2>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ushort2 num = rng.NextUShort2(minL, maxL);

                        ushort2 trueQuo = maxmath.divrem(num, denum, out ushort2 trueRem);
                        ushort2 quoTest = d.DivRem(num, out ushort2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ushort2>(maxmath.shl((ushort)1u, rng.NextUShort2(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ushort2_ushort()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort> d1 = new Divider<ushort>((ushort)1);
                Divider<ushort> d2 = new Divider<ushort>((ushort)2);
                Divider<ushort> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort denum = rng.NextUShort(minR, maxR);
                    Divider<ushort> d = new Divider<ushort>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ushort2 num = rng.NextUShort2(minL, maxL);

                        ushort2 trueQuo = maxmath.divrem(num, denum, out ushort2 trueRem);
                        ushort2 quoTest = d.DivRem(num, out ushort2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ushort>((ushort)(1u << rng.NextUShort(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ushort_ushort2()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort2> d1 = new Divider<ushort2>((ushort2)1);
                Divider<ushort2> d2 = new Divider<ushort2>((ushort2)2);
                Divider<ushort2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort2 denum = rng.NextUShort2(minR, maxR);
                    Divider<ushort2> d = new Divider<ushort2>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ushort num = rng.NextUShort(minL, maxL);

                        ushort2 trueQuo = maxmath.divrem(num, denum, out ushort2 trueRem);
                        ushort2 quoTest = d.DivRem(num, out ushort2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ushort2>(maxmath.shl((ushort)1u, rng.NextUShort2(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ushort3()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort3> d1 = new Divider<ushort3>((ushort3)1);
                Divider<ushort3> d2 = new Divider<ushort3>((ushort3)2);
                Divider<ushort3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort3 denum = rng.NextUShort3(minR, maxR);
                    Divider<ushort3> d = new Divider<ushort3>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ushort3 num = rng.NextUShort3(minL, maxL);

                        ushort3 trueQuo = maxmath.divrem(num, denum, out ushort3 trueRem);
                        ushort3 quoTest = d.DivRem(num, out ushort3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ushort3>(maxmath.shl((ushort)1u, rng.NextUShort3(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ushort3_ushort()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort> d1 = new Divider<ushort>((ushort)1);
                Divider<ushort> d2 = new Divider<ushort>((ushort)2);
                Divider<ushort> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort denum = rng.NextUShort(minR, maxR);
                    Divider<ushort> d = new Divider<ushort>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ushort3 num = rng.NextUShort3(minL, maxL);

                        ushort3 trueQuo = maxmath.divrem(num, denum, out ushort3 trueRem);
                        ushort3 quoTest = d.DivRem(num, out ushort3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ushort>((ushort)(1u << rng.NextUShort(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ushort_ushort3()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort3> d1 = new Divider<ushort3>((ushort3)1);
                Divider<ushort3> d2 = new Divider<ushort3>((ushort3)2);
                Divider<ushort3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort3 denum = rng.NextUShort3(minR, maxR);
                    Divider<ushort3> d = new Divider<ushort3>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ushort num = rng.NextUShort(minL, maxL);

                        ushort3 trueQuo = maxmath.divrem(num, denum, out ushort3 trueRem);
                        ushort3 quoTest = d.DivRem(num, out ushort3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ushort3>(maxmath.shl((ushort)1u, rng.NextUShort3(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ushort4()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort4> d1 = new Divider<ushort4>((ushort4)1);
                Divider<ushort4> d2 = new Divider<ushort4>((ushort4)2);
                Divider<ushort4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort4 denum = rng.NextUShort4(minR, maxR);
                    Divider<ushort4> d = new Divider<ushort4>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ushort4 num = rng.NextUShort4(minL, maxL);

                        ushort4 trueQuo = maxmath.divrem(num, denum, out ushort4 trueRem);
                        ushort4 quoTest = d.DivRem(num, out ushort4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ushort4>(maxmath.shl((ushort)1u, rng.NextUShort4(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ushort4_ushort()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort> d1 = new Divider<ushort>((ushort)1);
                Divider<ushort> d2 = new Divider<ushort>((ushort)2);
                Divider<ushort> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort denum = rng.NextUShort(minR, maxR);
                    Divider<ushort> d = new Divider<ushort>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ushort4 num = rng.NextUShort4(minL, maxL);

                        ushort4 trueQuo = maxmath.divrem(num, denum, out ushort4 trueRem);
                        ushort4 quoTest = d.DivRem(num, out ushort4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ushort>((ushort)(1u << rng.NextUShort(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ushort_ushort4()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort4> d1 = new Divider<ushort4>((ushort4)1);
                Divider<ushort4> d2 = new Divider<ushort4>((ushort4)2);
                Divider<ushort4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort4 denum = rng.NextUShort4(minR, maxR);
                    Divider<ushort4> d = new Divider<ushort4>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ushort num = rng.NextUShort(minL, maxL);

                        ushort4 trueQuo = maxmath.divrem(num, denum, out ushort4 trueRem);
                        ushort4 quoTest = d.DivRem(num, out ushort4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ushort4>(maxmath.shl((ushort)1u, rng.NextUShort4(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ushort8()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort8> d1 = new Divider<ushort8>((ushort8)1);
                Divider<ushort8> d2 = new Divider<ushort8>((ushort8)2);
                Divider<ushort8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort8 denum = rng.NextUShort8(minR, maxR);
                    Divider<ushort8> d = new Divider<ushort8>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ushort8 num = rng.NextUShort8(minL, maxL);

                        ushort8 trueQuo = maxmath.divrem(num, denum, out ushort8 trueRem);
                        ushort8 quoTest = d.DivRem(num, out ushort8 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ushort8>(maxmath.shl((ushort)1u, rng.NextUShort8(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ushort8_ushort()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort> d1 = new Divider<ushort>((ushort)1);
                Divider<ushort> d2 = new Divider<ushort>((ushort)2);
                Divider<ushort> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort denum = rng.NextUShort(minR, maxR);
                    Divider<ushort> d = new Divider<ushort>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ushort8 num = rng.NextUShort8(minL, maxL);

                        ushort8 trueQuo = maxmath.divrem(num, denum, out ushort8 trueRem);
                        ushort8 quoTest = d.DivRem(num, out ushort8 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ushort>((ushort)(1u << rng.NextUShort(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ushort_ushort8()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort8> d1 = new Divider<ushort8>((ushort8)1);
                Divider<ushort8> d2 = new Divider<ushort8>((ushort8)2);
                Divider<ushort8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort8 denum = rng.NextUShort8(minR, maxR);
                    Divider<ushort8> d = new Divider<ushort8>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ushort num = rng.NextUShort(minL, maxL);

                        ushort8 trueQuo = maxmath.divrem(num, denum, out ushort8 trueRem);
                        ushort8 quoTest = d.DivRem(num, out ushort8 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ushort8>(maxmath.shl((ushort)1u, rng.NextUShort8(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ushort16()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort16> d1 = new Divider<ushort16>((ushort16)1);
                Divider<ushort16> d2 = new Divider<ushort16>((ushort16)2);
                Divider<ushort16> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort16 denum = rng.NextUShort16(minR, maxR);
                    Divider<ushort16> d = new Divider<ushort16>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ushort16 num = rng.NextUShort16(minL, maxL);

                        ushort16 trueQuo = maxmath.divrem(num, denum, out ushort16 trueRem);
                        ushort16 quoTest = d.DivRem(num, out ushort16 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ushort16>(maxmath.shl((ushort)1u, rng.NextUShort16(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ushort16_ushort()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort> d1 = new Divider<ushort>((ushort)1);
                Divider<ushort> d2 = new Divider<ushort>((ushort)2);
                Divider<ushort> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort denum = rng.NextUShort(minR, maxR);
                    Divider<ushort> d = new Divider<ushort>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ushort16 num = rng.NextUShort16(minL, maxL);

                        ushort16 trueQuo = maxmath.divrem(num, denum, out ushort16 trueRem);
                        ushort16 quoTest = d.DivRem(num, out ushort16 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ushort>((ushort)(1u << rng.NextUShort(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _ushort_ushort16()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort16> d1 = new Divider<ushort16>((ushort16)1);
                Divider<ushort16> d2 = new Divider<ushort16>((ushort16)2);
                Divider<ushort16> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort16 denum = rng.NextUShort16(minR, maxR);
                    Divider<ushort16> d = new Divider<ushort16>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        ushort num = rng.NextUShort(minL, maxL);

                        ushort16 trueQuo = maxmath.divrem(num, denum, out ushort16 trueRem);
                        ushort16 quoTest = d.DivRem(num, out ushort16 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<ushort16>(maxmath.shl((ushort)1u, rng.NextUShort16(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }



        [Test]
        public static void _byte()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte> d1 = new Divider<byte>((byte)1);
                Divider<byte> d2 = new Divider<byte>((byte)2);
                Divider<byte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte denum = rng.NextByte(minR, maxR);
                    Divider<byte> d = new Divider<byte>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte num = rng.NextByte(minL, maxL);

                        byte trueQuo = maxmath.divrem(num, denum, out byte trueRem);
                        byte quoTest = d.DivRem(num, out byte remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte>((byte)(1u << (int)rng.NextByte(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte2()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte2> d1 = new Divider<byte2>((byte2)1);
                Divider<byte2> d2 = new Divider<byte2>((byte2)2);
                Divider<byte2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte2 denum = rng.NextByte2(minR, maxR);
                    Divider<byte2> d = new Divider<byte2>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte2 num = rng.NextByte2(minL, maxL);

                        byte2 trueQuo = maxmath.divrem(num, denum, out byte2 trueRem);
                        byte2 quoTest = d.DivRem(num, out byte2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte2>(maxmath.shl((byte)1u, rng.NextByte2(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte2_byte()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte> d1 = new Divider<byte>((byte)1);
                Divider<byte> d2 = new Divider<byte>((byte)2);
                Divider<byte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte denum = rng.NextByte(minR, maxR);
                    Divider<byte> d = new Divider<byte>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte2 num = rng.NextByte2(minL, maxL);

                        byte2 trueQuo = maxmath.divrem(num, denum, out byte2 trueRem);
                        byte2 quoTest = d.DivRem(num, out byte2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte>((byte)(1u << rng.NextByte(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte_byte2()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte2> d1 = new Divider<byte2>((byte2)1);
                Divider<byte2> d2 = new Divider<byte2>((byte2)2);
                Divider<byte2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte2 denum = rng.NextByte2(minR, maxR);
                    Divider<byte2> d = new Divider<byte2>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte num = rng.NextByte(minL, maxL);

                        byte2 trueQuo = maxmath.divrem(num, denum, out byte2 trueRem);
                        byte2 quoTest = d.DivRem(num, out byte2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte2>(maxmath.shl((byte)1u, rng.NextByte2(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte3()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte3> d1 = new Divider<byte3>((byte3)1);
                Divider<byte3> d2 = new Divider<byte3>((byte3)2);
                Divider<byte3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte3 denum = rng.NextByte3(minR, maxR);
                    Divider<byte3> d = new Divider<byte3>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte3 num = rng.NextByte3(minL, maxL);

                        byte3 trueQuo = maxmath.divrem(num, denum, out byte3 trueRem);
                        byte3 quoTest = d.DivRem(num, out byte3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte3>(maxmath.shl((byte)1u, rng.NextByte3(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte3_byte()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte> d1 = new Divider<byte>((byte)1);
                Divider<byte> d2 = new Divider<byte>((byte)2);
                Divider<byte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte denum = rng.NextByte(minR, maxR);
                    Divider<byte> d = new Divider<byte>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte3 num = rng.NextByte3(minL, maxL);

                        byte3 trueQuo = maxmath.divrem(num, denum, out byte3 trueRem);
                        byte3 quoTest = d.DivRem(num, out byte3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte>((byte)(1u << rng.NextByte(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte_byte3()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte3> d1 = new Divider<byte3>((byte3)1);
                Divider<byte3> d2 = new Divider<byte3>((byte3)2);
                Divider<byte3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte3 denum = rng.NextByte3(minR, maxR);
                    Divider<byte3> d = new Divider<byte3>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte num = rng.NextByte(minL, maxL);

                        byte3 trueQuo = maxmath.divrem(num, denum, out byte3 trueRem);
                        byte3 quoTest = d.DivRem(num, out byte3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte3>(maxmath.shl((byte)1u, rng.NextByte3(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte4()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte4> d1 = new Divider<byte4>((byte4)1);
                Divider<byte4> d2 = new Divider<byte4>((byte4)2);
                Divider<byte4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte4 denum = rng.NextByte4(minR, maxR);
                    Divider<byte4> d = new Divider<byte4>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte4 num = rng.NextByte4(minL, maxL);

                        byte4 trueQuo = maxmath.divrem(num, denum, out byte4 trueRem);
                        byte4 quoTest = d.DivRem(num, out byte4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte4>(maxmath.shl((byte)1u, rng.NextByte4(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte4_byte()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte> d1 = new Divider<byte>((byte)1);
                Divider<byte> d2 = new Divider<byte>((byte)2);
                Divider<byte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte denum = rng.NextByte(minR, maxR);
                    Divider<byte> d = new Divider<byte>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte4 num = rng.NextByte4(minL, maxL);

                        byte4 trueQuo = maxmath.divrem(num, denum, out byte4 trueRem);
                        byte4 quoTest = d.DivRem(num, out byte4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte>((byte)(1u << rng.NextByte(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte_byte4()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte4> d1 = new Divider<byte4>((byte4)1);
                Divider<byte4> d2 = new Divider<byte4>((byte4)2);
                Divider<byte4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte4 denum = rng.NextByte4(minR, maxR);
                    Divider<byte4> d = new Divider<byte4>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte num = rng.NextByte(minL, maxL);

                        byte4 trueQuo = maxmath.divrem(num, denum, out byte4 trueRem);
                        byte4 quoTest = d.DivRem(num, out byte4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte4>(maxmath.shl((byte)1u, rng.NextByte4(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte8()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte8> d1 = new Divider<byte8>((byte8)1);
                Divider<byte8> d2 = new Divider<byte8>((byte8)2);
                Divider<byte8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte8 denum = rng.NextByte8(minR, maxR);
                    Divider<byte8> d = new Divider<byte8>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte8 num = rng.NextByte8(minL, maxL);

                        byte8 trueQuo = maxmath.divrem(num, denum, out byte8 trueRem);
                        byte8 quoTest = d.DivRem(num, out byte8 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte8>(maxmath.shl((byte)1u, rng.NextByte8(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte8_byte()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte> d1 = new Divider<byte>((byte)1);
                Divider<byte> d2 = new Divider<byte>((byte)2);
                Divider<byte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte denum = rng.NextByte(minR, maxR);
                    Divider<byte> d = new Divider<byte>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte8 num = rng.NextByte8(minL, maxL);

                        byte8 trueQuo = maxmath.divrem(num, denum, out byte8 trueRem);
                        byte8 quoTest = d.DivRem(num, out byte8 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte>((byte)(1u << rng.NextByte(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte_byte8()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte8> d1 = new Divider<byte8>((byte8)1);
                Divider<byte8> d2 = new Divider<byte8>((byte8)2);
                Divider<byte8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte8 denum = rng.NextByte8(minR, maxR);
                    Divider<byte8> d = new Divider<byte8>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte num = rng.NextByte(minL, maxL);

                        byte8 trueQuo = maxmath.divrem(num, denum, out byte8 trueRem);
                        byte8 quoTest = d.DivRem(num, out byte8 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte8>(maxmath.shl((byte)1u, rng.NextByte8(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte16()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte16> d1 = new Divider<byte16>((byte16)1);
                Divider<byte16> d2 = new Divider<byte16>((byte16)2);
                Divider<byte16> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte16 denum = rng.NextByte16(minR, maxR);
                    Divider<byte16> d = new Divider<byte16>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte16 num = rng.NextByte16(minL, maxL);

                        byte16 trueQuo = maxmath.divrem(num, denum, out byte16 trueRem);
                        byte16 quoTest = d.DivRem(num, out byte16 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte16>(maxmath.shl((byte)1u, rng.NextByte16(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte16_byte()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte> d1 = new Divider<byte>((byte)1);
                Divider<byte> d2 = new Divider<byte>((byte)2);
                Divider<byte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte denum = rng.NextByte(minR, maxR);
                    Divider<byte> d = new Divider<byte>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte16 num = rng.NextByte16(minL, maxL);

                        byte16 trueQuo = maxmath.divrem(num, denum, out byte16 trueRem);
                        byte16 quoTest = d.DivRem(num, out byte16 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte>((byte)(1u << rng.NextByte(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte_byte16()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte16> d1 = new Divider<byte16>((byte16)1);
                Divider<byte16> d2 = new Divider<byte16>((byte16)2);
                Divider<byte16> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte16 denum = rng.NextByte16(minR, maxR);
                    Divider<byte16> d = new Divider<byte16>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte num = rng.NextByte(minL, maxL);

                        byte16 trueQuo = maxmath.divrem(num, denum, out byte16 trueRem);
                        byte16 quoTest = d.DivRem(num, out byte16 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte16>(maxmath.shl((byte)1u, rng.NextByte16(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte32()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte32> d1 = new Divider<byte32>((byte32)1);
                Divider<byte32> d2 = new Divider<byte32>((byte32)2);
                Divider<byte32> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte32 denum = rng.NextByte32(minR, maxR);
                    Divider<byte32> d = new Divider<byte32>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte32 num = rng.NextByte32(minL, maxL);

                        byte32 trueQuo = maxmath.divrem(num, denum, out byte32 trueRem);
                        byte32 quoTest = d.DivRem(num, out byte32 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte32>(maxmath.shl((byte)1u, rng.NextByte32(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte32_byte()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte> d1 = new Divider<byte>((byte)1);
                Divider<byte> d2 = new Divider<byte>((byte)2);
                Divider<byte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte denum = rng.NextByte(minR, maxR);
                    Divider<byte> d = new Divider<byte>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte32 num = rng.NextByte32(minL, maxL);

                        byte32 trueQuo = maxmath.divrem(num, denum, out byte32 trueRem);
                        byte32 quoTest = d.DivRem(num, out byte32 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte>((byte)(1u << rng.NextByte(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _byte_byte32()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte32> d1 = new Divider<byte32>((byte32)1);
                Divider<byte32> d2 = new Divider<byte32>((byte32)2);
                Divider<byte32> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte32 denum = rng.NextByte32(minR, maxR);
                    Divider<byte32> d = new Divider<byte32>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        byte num = rng.NextByte(minL, maxL);

                        byte32 trueQuo = maxmath.divrem(num, denum, out byte32 trueRem);
                        byte32 quoTest = d.DivRem(num, out byte32 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        pow2 = new Divider<byte32>(maxmath.shl((byte)1u, rng.NextByte32(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }



        [Test]
        public static void _Int128()
        {
            TestInt128(
            (minL, maxL, minR, maxR) =>
            {
                Random128 rng = Random128.New;
                Divider<Int128> d1 = new Divider<Int128>((Int128)9);
                Divider<Int128> d2 = new Divider<Int128>((Int128)8);
                Divider<Int128> dm1 = new Divider<Int128>((Int128)(-9));
                Divider<Int128> dm2 = new Divider<Int128>((Int128)(-8));
                Divider<Int128> overflow = new Divider<Int128>(Int128.MinValue);
                Divider<Int128> pow2;

                for (int i = 0; i < 8; i++)
                {
                    Int128 denum = rng.NextInt128(minR, maxR);
                    Divider<Int128> d = new Divider<Int128>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        Int128 num = rng.NextInt128(minL, maxL);

                        Int128 trueQuo = maxmath.divrem(num, denum, out Int128 trueRem);
                        Int128 quoTest = d.DivRem(num, out Int128 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 9, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 8, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -9, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -8, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, Int128.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<Int128>((Int128)1 << (int)rng.NextInt128(0, 128));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<Int128>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }


        [Test]
        public static void _long()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long> d1 = new Divider<long>((long)1);
                Divider<long> d2 = new Divider<long>((long)2);
                Divider<long> dm1 = new Divider<long>((long)-1);
                Divider<long> dm2 = new Divider<long>((long)-2);
                Divider<long> overflow = new Divider<long>(long.MinValue);
                Divider<long> pow2;

                for (int i = 0; i < 8; i++)
                {
                    long denum = rng.NextLong(minR, maxR);
                    Divider<long> d = new Divider<long>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        long num = rng.NextLong(minL, maxL);

                        long trueQuo = maxmath.divrem(num, denum, out long trueRem);
                        long quoTest = d.DivRem(num, out long remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, long.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<long>(1L << (int)rng.NextLong(0, 64));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<long>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _long2()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long2> d1 = new Divider<long2>((long2)1);
                Divider<long2> d2 = new Divider<long2>((long2)2);
                Divider<long2> dm1 = new Divider<long2>((long2)(-1));
                Divider<long2> dm2 = new Divider<long2>((long2)(-2));
                Divider<long2> overflow = new Divider<long2>((long2)long.MinValue);
                Divider<long2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    long2 denum = rng.NextLong2(minR, maxR);
                    Divider<long2> d = new Divider<long2>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        long2 num = rng.NextLong2(minL, maxL);

                        long2 trueQuo = maxmath.divrem(num, denum, out long2 trueRem);
                        long2 quoTest = d.DivRem(num, out long2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, long.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<long2>(maxmath.shl((long2)1L, rng.NextLong2(0, 64)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<long2>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _long2_long()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long> d1 = new Divider<long>((long)1);
                Divider<long> d2 = new Divider<long>((long)2);
                Divider<long> dm1 = new Divider<long>((long)(-1));
                Divider<long> dm2 = new Divider<long>((long)(-2));
                Divider<long> overflow = new Divider<long>((long)long.MinValue);
                Divider<long> pow2;

                for (int i = 0; i < 8; i++)
                {
                    long denum = rng.NextLong(minR, maxR);
                    Divider<long> d = new Divider<long>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        long2 num = rng.NextLong2(minL, maxL);

                        long2 trueQuo = maxmath.divrem(num, denum, out long2 trueRem);
                        long2 quoTest = d.DivRem(num, out long2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, long.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<long>(1L << (int)rng.NextLong(0, 64));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<long>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _long_long2()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long2> d1 = new Divider<long2>((long2)1);
                Divider<long2> d2 = new Divider<long2>((long2)2);
                Divider<long2> dm1 = new Divider<long2>((long2)(-1));
                Divider<long2> dm2 = new Divider<long2>((long2)(-2));
                Divider<long2> overflow = new Divider<long2>((long2)long.MinValue);
                Divider<long2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    long2 denum = rng.NextLong2(minR, maxR);
                    Divider<long2> d = new Divider<long2>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        long num = rng.NextLong(minL, maxL);

                        long2 trueQuo = maxmath.divrem(num, denum, out long2 trueRem);
                        long2 quoTest = d.DivRem(num, out long2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, long.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<long2>(maxmath.shl((long2)1L, rng.NextLong2(0, 64)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<long2>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _long3()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long3> d1 = new Divider<long3>((long3)1);
                Divider<long3> d2 = new Divider<long3>((long3)2);
                Divider<long3> dm1 = new Divider<long3>((long3)(-1));
                Divider<long3> dm2 = new Divider<long3>((long3)(-2));
                Divider<long3> overflow = new Divider<long3>((long3)long.MinValue);
                Divider<long3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    long3 denum = rng.NextLong3(minR, maxR);
                    Divider<long3> d = new Divider<long3>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        long3 num = rng.NextLong3(minL, maxL);

                        long3 trueQuo = maxmath.divrem(num, denum, out long3 trueRem);
                        long3 quoTest = d.DivRem(num, out long3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, long.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<long3>(maxmath.shl((long3)1L, rng.NextLong3(0, 64)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<long3>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _long3_long()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long> d1 = new Divider<long>((long)1);
                Divider<long> d2 = new Divider<long>((long)2);
                Divider<long> dm1 = new Divider<long>((long)(-1));
                Divider<long> dm2 = new Divider<long>((long)(-2));
                Divider<long> overflow = new Divider<long>((long)long.MinValue);
                Divider<long> pow2;

                for (int i = 0; i < 8; i++)
                {
                    long denum = rng.NextLong(minR, maxR);
                    Divider<long> d = new Divider<long>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        long3 num = rng.NextLong3(minL, maxL);

                        long3 trueQuo = maxmath.divrem(num, denum, out long3 trueRem);
                        long3 quoTest = d.DivRem(num, out long3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, long.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<long>(1L << (int)rng.NextLong(0, 64));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<long>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _long_long3()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long3> d1 = new Divider<long3>((long3)1);
                Divider<long3> d2 = new Divider<long3>((long3)2);
                Divider<long3> dm1 = new Divider<long3>((long3)(-1));
                Divider<long3> dm2 = new Divider<long3>((long3)(-2));
                Divider<long3> overflow = new Divider<long3>((long3)long.MinValue);
                Divider<long3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    long3 denum = rng.NextLong3(minR, maxR);
                    Divider<long3> d = new Divider<long3>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        long num = rng.NextLong(minL, maxL);

                        long3 trueQuo = maxmath.divrem(num, denum, out long3 trueRem);
                        long3 quoTest = d.DivRem(num, out long3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, long.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<long3>(maxmath.shl((long3)1L, rng.NextLong3(0, 64)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<long3>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _long4()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long4> d1 = new Divider<long4>((long4)1);
                Divider<long4> d2 = new Divider<long4>((long4)2);
                Divider<long4> dm1 = new Divider<long4>((long4)(-1));
                Divider<long4> dm2 = new Divider<long4>((long4)(-2));
                Divider<long4> overflow = new Divider<long4>((long4)long.MinValue);
                Divider<long4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    long4 denum = rng.NextLong4(minR, maxR);
                    Divider<long4> d = new Divider<long4>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        long4 num = rng.NextLong4(minL, maxL);

                        long4 trueQuo = maxmath.divrem(num, denum, out long4 trueRem);
                        long4 quoTest = d.DivRem(num, out long4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, long.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<long4>(maxmath.shl((long4)1L, rng.NextLong4(0, 64)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<long4>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _long4_long()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long> d1 = new Divider<long>((long)1);
                Divider<long> d2 = new Divider<long>((long)2);
                Divider<long> dm1 = new Divider<long>((long)(-1));
                Divider<long> dm2 = new Divider<long>((long)(-2));
                Divider<long> overflow = new Divider<long>((long)long.MinValue);
                Divider<long> pow2;

                for (int i = 0; i < 8; i++)
                {
                    long denum = rng.NextLong(minR, maxR);
                    Divider<long> d = new Divider<long>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        long4 num = rng.NextLong4(minL, maxL);

                        long4 trueQuo = maxmath.divrem(num, denum, out long4 trueRem);
                        long4 quoTest = d.DivRem(num, out long4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, long.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<long>(1L << (int)rng.NextLong(0, 64));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<long>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _long_long4()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long4> d1 = new Divider<long4>((long4)1);
                Divider<long4> d2 = new Divider<long4>((long4)2);
                Divider<long4> dm1 = new Divider<long4>((long4)(-1));
                Divider<long4> dm2 = new Divider<long4>((long4)(-2));
                Divider<long4> overflow = new Divider<long4>((long4)long.MinValue);
                Divider<long4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    long4 denum = rng.NextLong4(minR, maxR);
                    Divider<long4> d = new Divider<long4>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        long num = rng.NextLong(minL, maxL);

                        long4 trueQuo = maxmath.divrem(num, denum, out long4 trueRem);
                        long4 quoTest = d.DivRem(num, out long4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, long.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<long4>(maxmath.shl((long4)1L, rng.NextLong4(0, 64)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<long4>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }


        [Test]
        public static void _int()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int> d1 = new Divider<int>((int)1);
                Divider<int> d2 = new Divider<int>((int)2);
                Divider<int> dm1 = new Divider<int>((int)-1);
                Divider<int> dm2 = new Divider<int>((int)-2);
                Divider<int> overflow = new Divider<int>(int.MinValue);
                Divider<int> pow2;

                for (int i = 0; i < 8; i++)
                {
                    int denum = rng.NextInt(minR, maxR);
                    Divider<int> d = new Divider<int>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        int num = rng.NextInt(minL, maxL);

                        int trueQuo = maxmath.divrem(num, denum, out int trueRem);
                        int quoTest = d.DivRem(num, out int remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, int.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<int>(1 << rng.NextInt(0, 32));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<int>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _int2()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int2> d1 = new Divider<int2>((int2)1);
                Divider<int2> d2 = new Divider<int2>((int2)2);
                Divider<int2> dm1 = new Divider<int2>((int2)(-1));
                Divider<int2> dm2 = new Divider<int2>((int2)(-2));
                Divider<int2> overflow = new Divider<int2>((int2)int.MinValue);
                Divider<int2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    int2 denum = rng.NextInt2(minR, maxR);
                    Divider<int2> d = new Divider<int2>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        int2 num = rng.NextInt2(minL, maxL);

                        int2 trueQuo = maxmath.divrem(num, denum, out int2 trueRem);
                        int2 quoTest = d.DivRem(num, out int2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, int.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<int2>(maxmath.shl((int2)1, rng.NextInt2(0, 32)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<int2>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _int2_int()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int> d1 = new Divider<int>((int)1);
                Divider<int> d2 = new Divider<int>((int)2);
                Divider<int> dm1 = new Divider<int>((int)(-1));
                Divider<int> dm2 = new Divider<int>((int)(-2));
                Divider<int> overflow = new Divider<int>((int)int.MinValue);
                Divider<int> pow2;

                for (int i = 0; i < 8; i++)
                {
                    int denum = rng.NextInt(minR, maxR);
                    Divider<int> d = new Divider<int>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        int2 num = rng.NextInt2(minL, maxL);

                        int2 trueQuo = maxmath.divrem(num, denum, out int2 trueRem);
                        int2 quoTest = d.DivRem(num, out int2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, int.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<int>(1 << rng.NextInt(0, 32));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<int>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _int_int2()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int2> d1 = new Divider<int2>((int2)1);
                Divider<int2> d2 = new Divider<int2>((int2)2);
                Divider<int2> dm1 = new Divider<int2>((int2)(-1));
                Divider<int2> dm2 = new Divider<int2>((int2)(-2));
                Divider<int2> overflow = new Divider<int2>((int2)int.MinValue);
                Divider<int2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    int2 denum = rng.NextInt2(minR, maxR);
                    Divider<int2> d = new Divider<int2>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        int num = rng.NextInt(minL, maxL);

                        int2 trueQuo = maxmath.divrem(num, denum, out int2 trueRem);
                        int2 quoTest = d.DivRem(num, out int2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, int.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<int2>(maxmath.shl((int2)1, rng.NextInt2(0, 32)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<int2>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _int3()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int3> d1 = new Divider<int3>((int3)1);
                Divider<int3> d2 = new Divider<int3>((int3)2);
                Divider<int3> dm1 = new Divider<int3>((int3)(-1));
                Divider<int3> dm2 = new Divider<int3>((int3)(-2));
                Divider<int3> overflow = new Divider<int3>((int3)int.MinValue);
                Divider<int3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    int3 denum = rng.NextInt3(minR, maxR);
                    Divider<int3> d = new Divider<int3>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        int3 num = rng.NextInt3(minL, maxL);

                        int3 trueQuo = maxmath.divrem(num, denum, out int3 trueRem);
                        int3 quoTest = d.DivRem(num, out int3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, int.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<int3>(maxmath.shl((int3)1, rng.NextInt3(0, 32)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<int3>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _int3_int()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int> d1 = new Divider<int>((int)1);
                Divider<int> d2 = new Divider<int>((int)2);
                Divider<int> dm1 = new Divider<int>((int)(-1));
                Divider<int> dm2 = new Divider<int>((int)(-2));
                Divider<int> overflow = new Divider<int>((int)int.MinValue);
                Divider<int> pow2;

                for (int i = 0; i < 8; i++)
                {
                    int denum = rng.NextInt(minR, maxR);
                    Divider<int> d = new Divider<int>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        int3 num = rng.NextInt3(minL, maxL);

                        int3 trueQuo = maxmath.divrem(num, denum, out int3 trueRem);
                        int3 quoTest = d.DivRem(num, out int3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, int.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<int>(1 << rng.NextInt(0, 32));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<int>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _int_int3()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int3> d1 = new Divider<int3>((int3)1);
                Divider<int3> d2 = new Divider<int3>((int3)2);
                Divider<int3> dm1 = new Divider<int3>((int3)(-1));
                Divider<int3> dm2 = new Divider<int3>((int3)(-2));
                Divider<int3> overflow = new Divider<int3>((int3)int.MinValue);
                Divider<int3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    int3 denum = rng.NextInt3(minR, maxR);
                    Divider<int3> d = new Divider<int3>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        int num = rng.NextInt(minL, maxL);

                        int3 trueQuo = maxmath.divrem(num, denum, out int3 trueRem);
                        int3 quoTest = d.DivRem(num, out int3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, int.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<int3>(maxmath.shl((int3)1, rng.NextInt3(0, 32)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<int3>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _int4()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int4> d1 = new Divider<int4>((int4)1);
                Divider<int4> d2 = new Divider<int4>((int4)2);
                Divider<int4> dm1 = new Divider<int4>((int4)(-1));
                Divider<int4> dm2 = new Divider<int4>((int4)(-2));
                Divider<int4> overflow = new Divider<int4>((int4)int.MinValue);
                Divider<int4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    int4 denum = rng.NextInt4(minR, maxR);
                    Divider<int4> d = new Divider<int4>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        int4 num = rng.NextInt4(minL, maxL);

                        int4 trueQuo = maxmath.divrem(num, denum, out int4 trueRem);
                        int4 quoTest = d.DivRem(num, out int4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, int.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<int4>(maxmath.shl((int4)1, rng.NextInt4(0, 32)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<int4>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _int4_int()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int> d1 = new Divider<int>((int)1);
                Divider<int> d2 = new Divider<int>((int)2);
                Divider<int> dm1 = new Divider<int>((int)(-1));
                Divider<int> dm2 = new Divider<int>((int)(-2));
                Divider<int> overflow = new Divider<int>((int)int.MinValue);
                Divider<int> pow2;

                for (int i = 0; i < 8; i++)
                {
                    int denum = rng.NextInt(minR, maxR);
                    Divider<int> d = new Divider<int>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        int4 num = rng.NextInt4(minL, maxL);

                        int4 trueQuo = maxmath.divrem(num, denum, out int4 trueRem);
                        int4 quoTest = d.DivRem(num, out int4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, int.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<int>(1 << rng.NextInt(0, 32));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<int>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _int_int4()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int4> d1 = new Divider<int4>((int4)1);
                Divider<int4> d2 = new Divider<int4>((int4)2);
                Divider<int4> dm1 = new Divider<int4>((int4)(-1));
                Divider<int4> dm2 = new Divider<int4>((int4)(-2));
                Divider<int4> overflow = new Divider<int4>((int4)int.MinValue);
                Divider<int4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    int4 denum = rng.NextInt4(minR, maxR);
                    Divider<int4> d = new Divider<int4>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        int num = rng.NextInt(minL, maxL);

                        int4 trueQuo = maxmath.divrem(num, denum, out int4 trueRem);
                        int4 quoTest = d.DivRem(num, out int4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, int.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<int4>(maxmath.shl((int4)1, rng.NextInt4(0, 32)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<int4>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _int8()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int8> d1 = new Divider<int8>((int8)1);
                Divider<int8> d2 = new Divider<int8>((int8)2);
                Divider<int8> dm1 = new Divider<int8>((int8)(-1));
                Divider<int8> dm2 = new Divider<int8>((int8)(-2));
                Divider<int8> overflow = new Divider<int8>((int8)int.MinValue);
                Divider<int8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    int8 denum = rng.NextInt8(minR, maxR);
                    Divider<int8> d = new Divider<int8>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        int8 num = rng.NextInt8(minL, maxL);

                        int8 trueQuo = maxmath.divrem(num, denum, out int8 trueRem);
                        int8 quoTest = d.DivRem(num, out int8 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, int.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<int8>(maxmath.shl((int8)1, rng.NextInt8(0, 32)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<int8>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _int8_int()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int> d1 = new Divider<int>((int)1);
                Divider<int> d2 = new Divider<int>((int)2);
                Divider<int> dm1 = new Divider<int>((int)(-1));
                Divider<int> dm2 = new Divider<int>((int)(-2));
                Divider<int> overflow = new Divider<int>((int)int.MinValue);
                Divider<int> pow2;

                for (int i = 0; i < 8; i++)
                {
                    int denum = rng.NextInt(minR, maxR);
                    Divider<int> d = new Divider<int>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        int8 num = rng.NextInt8(minL, maxL);

                        int8 trueQuo = maxmath.divrem(num, denum, out int8 trueRem);
                        int8 quoTest = d.DivRem(num, out int8 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, int.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<int>(1 << rng.NextInt(0, 32));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<int>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _int_int8()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int8> d1 = new Divider<int8>((int8)1);
                Divider<int8> d2 = new Divider<int8>((int8)2);
                Divider<int8> dm1 = new Divider<int8>((int8)(-1));
                Divider<int8> dm2 = new Divider<int8>((int8)(-2));
                Divider<int8> overflow = new Divider<int8>((int8)int.MinValue);
                Divider<int8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    int8 denum = rng.NextInt8(minR, maxR);
                    Divider<int8> d = new Divider<int8>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        int num = rng.NextInt(minL, maxL);

                        int8 trueQuo = maxmath.divrem(num, denum, out int8 trueRem);
                        int8 quoTest = d.DivRem(num, out int8 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, int.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<int8>(maxmath.shl((int8)1, rng.NextInt8(0, 32)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<int8>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }


        [Test]
        public static void _short()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short> d1 = new Divider<short>((short)1);
                Divider<short> d2 = new Divider<short>((short)2);
                Divider<short> dm1 = new Divider<short>((short)-1);
                Divider<short> dm2 = new Divider<short>((short)-2);
                Divider<short> overflow = new Divider<short>(short.MinValue);
                Divider<short> pow2;

                for (int i = 0; i < 8; i++)
                {
                    short denum = rng.NextShort(minR, maxR);
                    Divider<short> d = new Divider<short>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        short num = rng.NextShort(minL, maxL);

                        short trueQuo = maxmath.divrem(num, denum, out short trueRem);
                        short quoTest = d.DivRem(num, out short remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, short.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<short>((short)(1 << rng.NextShort(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<short>((short)-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _short2()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short2> d1 = new Divider<short2>((short2)1);
                Divider<short2> d2 = new Divider<short2>((short2)2);
                Divider<short2> dm1 = new Divider<short2>((short2)(-1));
                Divider<short2> dm2 = new Divider<short2>((short2)(-2));
                Divider<short2> overflow = new Divider<short2>((short2)short.MinValue);
                Divider<short2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    short2 denum = rng.NextShort2(minR, maxR);
                    Divider<short2> d = new Divider<short2>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        short2 num = rng.NextShort2(minL, maxL);

                        short2 trueQuo = maxmath.divrem(num, denum, out short2 trueRem);
                        short2 quoTest = d.DivRem(num, out short2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, short.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<short2>(maxmath.shl((short)1, rng.NextShort2(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<short2>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _short2_short()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short> d1 = new Divider<short>((short)1);
                Divider<short> d2 = new Divider<short>((short)2);
                Divider<short> dm1 = new Divider<short>((short)(-1));
                Divider<short> dm2 = new Divider<short>((short)(-2));
                Divider<short> overflow = new Divider<short>((short)short.MinValue);
                Divider<short> pow2;

                for (int i = 0; i < 8; i++)
                {
                    short denum = rng.NextShort(minR, maxR);
                    Divider<short> d = new Divider<short>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        short2 num = rng.NextShort2(minL, maxL);

                        short2 trueQuo = maxmath.divrem(num, denum, out short2 trueRem);
                        short2 quoTest = d.DivRem(num, out short2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, short.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<short>((short)(1 << rng.NextShort(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<short>((short)-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _short_short2()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short2> d1 = new Divider<short2>((short2)1);
                Divider<short2> d2 = new Divider<short2>((short2)2);
                Divider<short2> dm1 = new Divider<short2>((short2)(-1));
                Divider<short2> dm2 = new Divider<short2>((short2)(-2));
                Divider<short2> overflow = new Divider<short2>((short2)short.MinValue);
                Divider<short2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    short2 denum = rng.NextShort2(minR, maxR);
                    Divider<short2> d = new Divider<short2>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        short num = rng.NextShort(minL, maxL);

                        short2 trueQuo = maxmath.divrem(num, denum, out short2 trueRem);
                        short2 quoTest = d.DivRem(num, out short2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, short.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<short2>(maxmath.shl((short)1, rng.NextShort2(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<short2>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _short3()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short3> d1 = new Divider<short3>((short3)1);
                Divider<short3> d2 = new Divider<short3>((short3)2);
                Divider<short3> dm1 = new Divider<short3>((short3)(-1));
                Divider<short3> dm2 = new Divider<short3>((short3)(-2));
                Divider<short3> overflow = new Divider<short3>((short3)short.MinValue);
                Divider<short3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    short3 denum = rng.NextShort3(minR, maxR);
                    Divider<short3> d = new Divider<short3>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        short3 num = rng.NextShort3(minL, maxL);

                        short3 trueQuo = maxmath.divrem(num, denum, out short3 trueRem);
                        short3 quoTest = d.DivRem(num, out short3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, short.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<short3>(maxmath.shl((short)1, rng.NextShort3(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<short3>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _short3_short()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short> d1 = new Divider<short>((short)1);
                Divider<short> d2 = new Divider<short>((short)2);
                Divider<short> dm1 = new Divider<short>((short)(-1));
                Divider<short> dm2 = new Divider<short>((short)(-2));
                Divider<short> overflow = new Divider<short>((short)short.MinValue);
                Divider<short> pow2;

                for (int i = 0; i < 8; i++)
                {
                    short denum = rng.NextShort(minR, maxR);
                    Divider<short> d = new Divider<short>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        short3 num = rng.NextShort3(minL, maxL);

                        short3 trueQuo = maxmath.divrem(num, denum, out short3 trueRem);
                        short3 quoTest = d.DivRem(num, out short3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, short.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<short>((short)(1 << rng.NextShort(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<short>((short)-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _short_short3()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short3> d1 = new Divider<short3>((short3)1);
                Divider<short3> d2 = new Divider<short3>((short3)2);
                Divider<short3> dm1 = new Divider<short3>((short3)(-1));
                Divider<short3> dm2 = new Divider<short3>((short3)(-2));
                Divider<short3> overflow = new Divider<short3>((short3)short.MinValue);
                Divider<short3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    short3 denum = rng.NextShort3(minR, maxR);
                    Divider<short3> d = new Divider<short3>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        short num = rng.NextShort(minL, maxL);

                        short3 trueQuo = maxmath.divrem(num, denum, out short3 trueRem);
                        short3 quoTest = d.DivRem(num, out short3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, short.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<short3>(maxmath.shl((short)1, rng.NextShort3(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<short3>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _short4()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short4> d1 = new Divider<short4>((short4)1);
                Divider<short4> d2 = new Divider<short4>((short4)2);
                Divider<short4> dm1 = new Divider<short4>((short4)(-1));
                Divider<short4> dm2 = new Divider<short4>((short4)(-2));
                Divider<short4> overflow = new Divider<short4>((short4)short.MinValue);
                Divider<short4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    short4 denum = rng.NextShort4(minR, maxR);
                    Divider<short4> d = new Divider<short4>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        short4 num = rng.NextShort4(minL, maxL);

                        short4 trueQuo = maxmath.divrem(num, denum, out short4 trueRem);
                        short4 quoTest = d.DivRem(num, out short4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, short.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<short4>(maxmath.shl((short)1, rng.NextShort4(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<short4>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _short4_short()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short> d1 = new Divider<short>((short)1);
                Divider<short> d2 = new Divider<short>((short)2);
                Divider<short> dm1 = new Divider<short>((short)(-1));
                Divider<short> dm2 = new Divider<short>((short)(-2));
                Divider<short> overflow = new Divider<short>((short)short.MinValue);
                Divider<short> pow2;

                for (int i = 0; i < 8; i++)
                {
                    short denum = rng.NextShort(minR, maxR);
                    Divider<short> d = new Divider<short>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        short4 num = rng.NextShort4(minL, maxL);

                        short4 trueQuo = maxmath.divrem(num, denum, out short4 trueRem);
                        short4 quoTest = d.DivRem(num, out short4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, short.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<short>((short)(1 << rng.NextShort(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<short>((short)-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _short_short4()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short4> d1 = new Divider<short4>((short4)1);
                Divider<short4> d2 = new Divider<short4>((short4)2);
                Divider<short4> dm1 = new Divider<short4>((short4)(-1));
                Divider<short4> dm2 = new Divider<short4>((short4)(-2));
                Divider<short4> overflow = new Divider<short4>((short4)short.MinValue);
                Divider<short4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    short4 denum = rng.NextShort4(minR, maxR);
                    Divider<short4> d = new Divider<short4>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        short num = rng.NextShort(minL, maxL);

                        short4 trueQuo = maxmath.divrem(num, denum, out short4 trueRem);
                        short4 quoTest = d.DivRem(num, out short4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, short.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<short4>(maxmath.shl((short)1, rng.NextShort4(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<short4>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _short8()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short8> d1 = new Divider<short8>((short8)1);
                Divider<short8> d2 = new Divider<short8>((short8)2);
                Divider<short8> dm1 = new Divider<short8>((short8)(-1));
                Divider<short8> dm2 = new Divider<short8>((short8)(-2));
                Divider<short8> overflow = new Divider<short8>((short8)short.MinValue);
                Divider<short8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    short8 denum = rng.NextShort8(minR, maxR);
                    Divider<short8> d = new Divider<short8>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        short8 num = rng.NextShort8(minL, maxL);

                        short8 trueQuo = maxmath.divrem(num, denum, out short8 trueRem);
                        short8 quoTest = d.DivRem(num, out short8 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, short.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<short8>(maxmath.shl((short)1, rng.NextShort8(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<short8>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _short8_short()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short> d1 = new Divider<short>((short)1);
                Divider<short> d2 = new Divider<short>((short)2);
                Divider<short> dm1 = new Divider<short>((short)(-1));
                Divider<short> dm2 = new Divider<short>((short)(-2));
                Divider<short> overflow = new Divider<short>((short)short.MinValue);
                Divider<short> pow2;

                for (int i = 0; i < 8; i++)
                {
                    short denum = rng.NextShort(minR, maxR);
                    Divider<short> d = new Divider<short>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        short8 num = rng.NextShort8(minL, maxL);

                        short8 trueQuo = maxmath.divrem(num, denum, out short8 trueRem);
                        short8 quoTest = d.DivRem(num, out short8 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, short.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<short>((short)(1 << rng.NextShort(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<short>((short)-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _short_short8()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short8> d1 = new Divider<short8>((short8)1);
                Divider<short8> d2 = new Divider<short8>((short8)2);
                Divider<short8> dm1 = new Divider<short8>((short8)(-1));
                Divider<short8> dm2 = new Divider<short8>((short8)(-2));
                Divider<short8> overflow = new Divider<short8>((short8)short.MinValue);
                Divider<short8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    short8 denum = rng.NextShort8(minR, maxR);
                    Divider<short8> d = new Divider<short8>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        short num = rng.NextShort(minL, maxL);

                        short8 trueQuo = maxmath.divrem(num, denum, out short8 trueRem);
                        short8 quoTest = d.DivRem(num, out short8 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, short.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<short8>(maxmath.shl((short)1, rng.NextShort8(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<short8>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _short16()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short16> d1 = new Divider<short16>((short16)1);
                Divider<short16> d2 = new Divider<short16>((short16)2);
                Divider<short16> dm1 = new Divider<short16>((short16)(-1));
                Divider<short16> dm2 = new Divider<short16>((short16)(-2));
                Divider<short16> overflow = new Divider<short16>((short16)short.MinValue);
                Divider<short16> pow2;

                for (int i = 0; i < 8; i++)
                {
                    short16 denum = rng.NextShort16(minR, maxR);
                    Divider<short16> d = new Divider<short16>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        short16 num = rng.NextShort16(minL, maxL);

                        short16 trueQuo = maxmath.divrem(num, denum, out short16 trueRem);
                        short16 quoTest = d.DivRem(num, out short16 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, short.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<short16>(maxmath.shl((short)1, rng.NextShort16(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<short16>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _short16_short()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short> d1 = new Divider<short>((short)1);
                Divider<short> d2 = new Divider<short>((short)2);
                Divider<short> dm1 = new Divider<short>((short)(-1));
                Divider<short> dm2 = new Divider<short>((short)(-2));
                Divider<short> overflow = new Divider<short>((short)short.MinValue);
                Divider<short> pow2;

                for (int i = 0; i < 8; i++)
                {
                    short denum = rng.NextShort(minR, maxR);
                    Divider<short> d = new Divider<short>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        short16 num = rng.NextShort16(minL, maxL);

                        short16 trueQuo = maxmath.divrem(num, denum, out short16 trueRem);
                        short16 quoTest = d.DivRem(num, out short16 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, short.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<short>((short)(1 << rng.NextShort(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<short>((short)-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _short_short16()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short16> d1 = new Divider<short16>((short16)1);
                Divider<short16> d2 = new Divider<short16>((short16)2);
                Divider<short16> dm1 = new Divider<short16>((short16)(-1));
                Divider<short16> dm2 = new Divider<short16>((short16)(-2));
                Divider<short16> overflow = new Divider<short16>((short16)short.MinValue);
                Divider<short16> pow2;

                for (int i = 0; i < 8; i++)
                {
                    short16 denum = rng.NextShort16(minR, maxR);
                    Divider<short16> d = new Divider<short16>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        short num = rng.NextShort(minL, maxL);

                        short16 trueQuo = maxmath.divrem(num, denum, out short16 trueRem);
                        short16 quoTest = d.DivRem(num, out short16 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, short.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<short16>(maxmath.shl((short)1, rng.NextShort16(0, 16)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<short16>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }



        [Test]
        public static void _sbyte()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte> d1 = new Divider<sbyte>((sbyte)1);
                Divider<sbyte> d2 = new Divider<sbyte>((sbyte)2);
                Divider<sbyte> dm1 = new Divider<sbyte>((sbyte)-1);
                Divider<sbyte> dm2 = new Divider<sbyte>((sbyte)-2);
                Divider<sbyte> overflow = new Divider<sbyte>(sbyte.MinValue);
                Divider<sbyte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte denum = rng.NextSByte(minR, maxR);
                    Divider<sbyte> d = new Divider<sbyte>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte num = rng.NextSByte(minL, maxL);

                        sbyte trueQuo = maxmath.divrem(num, denum, out sbyte trueRem);
                        sbyte quoTest = d.DivRem(num, out sbyte remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte>((sbyte)(1 << rng.NextByte(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte>((sbyte)-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte2()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte2> d1 = new Divider<sbyte2>((sbyte2)1);
                Divider<sbyte2> d2 = new Divider<sbyte2>((sbyte2)2);
                Divider<sbyte2> dm1 = new Divider<sbyte2>((sbyte2)(-1));
                Divider<sbyte2> dm2 = new Divider<sbyte2>((sbyte2)(-2));
                Divider<sbyte2> overflow = new Divider<sbyte2>((sbyte2)sbyte.MinValue);
                Divider<sbyte2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte2 denum = rng.NextSByte2(minR, maxR);
                    Divider<sbyte2> d = new Divider<sbyte2>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte2 num = rng.NextSByte2(minL, maxL);

                        sbyte2 trueQuo = maxmath.divrem(num, denum, out sbyte2 trueRem);
                        sbyte2 quoTest = d.DivRem(num, out sbyte2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte2>(maxmath.shl((sbyte)1, rng.NextSByte2(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte2>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte2_sbyte()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte> d1 = new Divider<sbyte>((sbyte)1);
                Divider<sbyte> d2 = new Divider<sbyte>((sbyte)2);
                Divider<sbyte> dm1 = new Divider<sbyte>((sbyte)(-1));
                Divider<sbyte> dm2 = new Divider<sbyte>((sbyte)(-2));
                Divider<sbyte> overflow = new Divider<sbyte>((sbyte)sbyte.MinValue);
                Divider<sbyte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte denum = rng.NextSByte(minR, maxR);
                    Divider<sbyte> d = new Divider<sbyte>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte2 num = rng.NextSByte2(minL, maxL);

                        sbyte2 trueQuo = maxmath.divrem(num, denum, out sbyte2 trueRem);
                        sbyte2 quoTest = d.DivRem(num, out sbyte2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte>((sbyte)(1 << rng.NextSByte(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte>((sbyte)-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte_sbyte2()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte2> d1 = new Divider<sbyte2>((sbyte2)1);
                Divider<sbyte2> d2 = new Divider<sbyte2>((sbyte2)2);
                Divider<sbyte2> dm1 = new Divider<sbyte2>((sbyte2)(-1));
                Divider<sbyte2> dm2 = new Divider<sbyte2>((sbyte2)(-2));
                Divider<sbyte2> overflow = new Divider<sbyte2>((sbyte2)sbyte.MinValue);
                Divider<sbyte2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte2 denum = rng.NextSByte2(minR, maxR);
                    Divider<sbyte2> d = new Divider<sbyte2>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte num = rng.NextSByte(minL, maxL);

                        sbyte2 trueQuo = maxmath.divrem(num, denum, out sbyte2 trueRem);
                        sbyte2 quoTest = d.DivRem(num, out sbyte2 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte2>(maxmath.shl((sbyte)1, rng.NextSByte2(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte2>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte3()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte3> d1 = new Divider<sbyte3>((sbyte3)1);
                Divider<sbyte3> d2 = new Divider<sbyte3>((sbyte3)2);
                Divider<sbyte3> dm1 = new Divider<sbyte3>((sbyte3)(-1));
                Divider<sbyte3> dm2 = new Divider<sbyte3>((sbyte3)(-2));
                Divider<sbyte3> overflow = new Divider<sbyte3>((sbyte3)sbyte.MinValue);
                Divider<sbyte3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte3 denum = rng.NextSByte3(minR, maxR);
                    Divider<sbyte3> d = new Divider<sbyte3>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte3 num = rng.NextSByte3(minL, maxL);

                        sbyte3 trueQuo = maxmath.divrem(num, denum, out sbyte3 trueRem);
                        sbyte3 quoTest = d.DivRem(num, out sbyte3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte3>(maxmath.shl((sbyte)1, rng.NextSByte3(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte3>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte3_sbyte()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte> d1 = new Divider<sbyte>((sbyte)1);
                Divider<sbyte> d2 = new Divider<sbyte>((sbyte)2);
                Divider<sbyte> dm1 = new Divider<sbyte>((sbyte)(-1));
                Divider<sbyte> dm2 = new Divider<sbyte>((sbyte)(-2));
                Divider<sbyte> overflow = new Divider<sbyte>((sbyte)sbyte.MinValue);
                Divider<sbyte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte denum = rng.NextSByte(minR, maxR);
                    Divider<sbyte> d = new Divider<sbyte>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte3 num = rng.NextSByte3(minL, maxL);

                        sbyte3 trueQuo = maxmath.divrem(num, denum, out sbyte3 trueRem);
                        sbyte3 quoTest = d.DivRem(num, out sbyte3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte>((sbyte)(1 << rng.NextSByte(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte>((sbyte)-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte_sbyte3()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte3> d1 = new Divider<sbyte3>((sbyte3)1);
                Divider<sbyte3> d2 = new Divider<sbyte3>((sbyte3)2);
                Divider<sbyte3> dm1 = new Divider<sbyte3>((sbyte3)(-1));
                Divider<sbyte3> dm2 = new Divider<sbyte3>((sbyte3)(-2));
                Divider<sbyte3> overflow = new Divider<sbyte3>((sbyte3)sbyte.MinValue);
                Divider<sbyte3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte3 denum = rng.NextSByte3(minR, maxR);
                    Divider<sbyte3> d = new Divider<sbyte3>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte num = rng.NextSByte(minL, maxL);

                        sbyte3 trueQuo = maxmath.divrem(num, denum, out sbyte3 trueRem);
                        sbyte3 quoTest = d.DivRem(num, out sbyte3 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte3>(maxmath.shl((sbyte)1, rng.NextSByte3(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte3>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte4()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte4> d1 = new Divider<sbyte4>((sbyte4)1);
                Divider<sbyte4> d2 = new Divider<sbyte4>((sbyte4)2);
                Divider<sbyte4> dm1 = new Divider<sbyte4>((sbyte4)(-1));
                Divider<sbyte4> dm2 = new Divider<sbyte4>((sbyte4)(-2));
                Divider<sbyte4> overflow = new Divider<sbyte4>((sbyte4)sbyte.MinValue);
                Divider<sbyte4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte4 denum = rng.NextSByte4(minR, maxR);
                    Divider<sbyte4> d = new Divider<sbyte4>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte4 num = rng.NextSByte4(minL, maxL);

                        sbyte4 trueQuo = maxmath.divrem(num, denum, out sbyte4 trueRem);
                        sbyte4 quoTest = d.DivRem(num, out sbyte4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte4>(maxmath.shl((sbyte)1, rng.NextSByte4(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte4>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte4_sbyte()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte> d1 = new Divider<sbyte>((sbyte)1);
                Divider<sbyte> d2 = new Divider<sbyte>((sbyte)2);
                Divider<sbyte> dm1 = new Divider<sbyte>((sbyte)(-1));
                Divider<sbyte> dm2 = new Divider<sbyte>((sbyte)(-2));
                Divider<sbyte> overflow = new Divider<sbyte>((sbyte)sbyte.MinValue);
                Divider<sbyte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte denum = rng.NextSByte(minR, maxR);
                    Divider<sbyte> d = new Divider<sbyte>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte4 num = rng.NextSByte4(minL, maxL);

                        sbyte4 trueQuo = maxmath.divrem(num, denum, out sbyte4 trueRem);
                        sbyte4 quoTest = d.DivRem(num, out sbyte4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte>((sbyte)(1 << rng.NextSByte(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte>((sbyte)-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte_sbyte4()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte4> d1 = new Divider<sbyte4>((sbyte4)1);
                Divider<sbyte4> d2 = new Divider<sbyte4>((sbyte4)2);
                Divider<sbyte4> dm1 = new Divider<sbyte4>((sbyte4)(-1));
                Divider<sbyte4> dm2 = new Divider<sbyte4>((sbyte4)(-2));
                Divider<sbyte4> overflow = new Divider<sbyte4>((sbyte4)sbyte.MinValue);
                Divider<sbyte4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte4 denum = rng.NextSByte4(minR, maxR);
                    Divider<sbyte4> d = new Divider<sbyte4>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte num = rng.NextSByte(minL, maxL);

                        sbyte4 trueQuo = maxmath.divrem(num, denum, out sbyte4 trueRem);
                        sbyte4 quoTest = d.DivRem(num, out sbyte4 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte4>(maxmath.shl((sbyte)1, rng.NextSByte4(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte4>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte8()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte8> d1 = new Divider<sbyte8>((sbyte8)1);
                Divider<sbyte8> d2 = new Divider<sbyte8>((sbyte8)2);
                Divider<sbyte8> dm1 = new Divider<sbyte8>((sbyte8)(-1));
                Divider<sbyte8> dm2 = new Divider<sbyte8>((sbyte8)(-2));
                Divider<sbyte8> overflow = new Divider<sbyte8>((sbyte8)sbyte.MinValue);
                Divider<sbyte8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte8 denum = rng.NextSByte8(minR, maxR);
                    Divider<sbyte8> d = new Divider<sbyte8>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte8 num = rng.NextSByte8(minL, maxL);

                        sbyte8 trueQuo = maxmath.divrem(num, denum, out sbyte8 trueRem);
                        sbyte8 quoTest = d.DivRem(num, out sbyte8 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte8>(maxmath.shl((sbyte)1, rng.NextSByte8(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte8>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte8_sbyte()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte> d1 = new Divider<sbyte>((sbyte)1);
                Divider<sbyte> d2 = new Divider<sbyte>((sbyte)2);
                Divider<sbyte> dm1 = new Divider<sbyte>((sbyte)(-1));
                Divider<sbyte> dm2 = new Divider<sbyte>((sbyte)(-2));
                Divider<sbyte> overflow = new Divider<sbyte>((sbyte)sbyte.MinValue);
                Divider<sbyte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte denum = rng.NextSByte(minR, maxR);
                    Divider<sbyte> d = new Divider<sbyte>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte8 num = rng.NextSByte8(minL, maxL);

                        sbyte8 trueQuo = maxmath.divrem(num, denum, out sbyte8 trueRem);
                        sbyte8 quoTest = d.DivRem(num, out sbyte8 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte>((sbyte)(1 << rng.NextSByte(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte>((sbyte)-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte_sbyte8()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte8> d1 = new Divider<sbyte8>((sbyte8)1);
                Divider<sbyte8> d2 = new Divider<sbyte8>((sbyte8)2);
                Divider<sbyte8> dm1 = new Divider<sbyte8>((sbyte8)(-1));
                Divider<sbyte8> dm2 = new Divider<sbyte8>((sbyte8)(-2));
                Divider<sbyte8> overflow = new Divider<sbyte8>((sbyte8)sbyte.MinValue);
                Divider<sbyte8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte8 denum = rng.NextSByte8(minR, maxR);
                    Divider<sbyte8> d = new Divider<sbyte8>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte num = rng.NextSByte(minL, maxL);

                        sbyte8 trueQuo = maxmath.divrem(num, denum, out sbyte8 trueRem);
                        sbyte8 quoTest = d.DivRem(num, out sbyte8 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte8>(maxmath.shl((sbyte)1, rng.NextSByte8(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte8>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte16()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte16> d1 = new Divider<sbyte16>((sbyte16)1);
                Divider<sbyte16> d2 = new Divider<sbyte16>((sbyte16)2);
                Divider<sbyte16> dm1 = new Divider<sbyte16>((sbyte16)(-1));
                Divider<sbyte16> dm2 = new Divider<sbyte16>((sbyte16)(-2));
                Divider<sbyte16> overflow = new Divider<sbyte16>((sbyte16)sbyte.MinValue);
                Divider<sbyte16> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte16 denum = rng.NextSByte16(minR, maxR);
                    Divider<sbyte16> d = new Divider<sbyte16>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte16 num = rng.NextSByte16(minL, maxL);

                        sbyte16 trueQuo = maxmath.divrem(num, denum, out sbyte16 trueRem);
                        sbyte16 quoTest = d.DivRem(num, out sbyte16 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte16>(maxmath.shl((sbyte)1, rng.NextSByte16(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte16>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte16_sbyte()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte> d1 = new Divider<sbyte>((sbyte)1);
                Divider<sbyte> d2 = new Divider<sbyte>((sbyte)2);
                Divider<sbyte> dm1 = new Divider<sbyte>((sbyte)(-1));
                Divider<sbyte> dm2 = new Divider<sbyte>((sbyte)(-2));
                Divider<sbyte> overflow = new Divider<sbyte>((sbyte)sbyte.MinValue);
                Divider<sbyte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte denum = rng.NextSByte(minR, maxR);
                    Divider<sbyte> d = new Divider<sbyte>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte16 num = rng.NextSByte16(minL, maxL);

                        sbyte16 trueQuo = maxmath.divrem(num, denum, out sbyte16 trueRem);
                        sbyte16 quoTest = d.DivRem(num, out sbyte16 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte>((sbyte)(1 << rng.NextSByte(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte>((sbyte)-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte_sbyte16()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte16> d1 = new Divider<sbyte16>((sbyte16)1);
                Divider<sbyte16> d2 = new Divider<sbyte16>((sbyte16)2);
                Divider<sbyte16> dm1 = new Divider<sbyte16>((sbyte16)(-1));
                Divider<sbyte16> dm2 = new Divider<sbyte16>((sbyte16)(-2));
                Divider<sbyte16> overflow = new Divider<sbyte16>((sbyte16)sbyte.MinValue);
                Divider<sbyte16> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte16 denum = rng.NextSByte16(minR, maxR);
                    Divider<sbyte16> d = new Divider<sbyte16>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte num = rng.NextSByte(minL, maxL);

                        sbyte16 trueQuo = maxmath.divrem(num, denum, out sbyte16 trueRem);
                        sbyte16 quoTest = d.DivRem(num, out sbyte16 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte16>(maxmath.shl((sbyte)1, rng.NextSByte16(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte16>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte32()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte32> d1 = new Divider<sbyte32>((sbyte32)1);
                Divider<sbyte32> d2 = new Divider<sbyte32>((sbyte32)2);
                Divider<sbyte32> dm1 = new Divider<sbyte32>((sbyte32)(-1));
                Divider<sbyte32> dm2 = new Divider<sbyte32>((sbyte32)(-2));
                Divider<sbyte32> overflow = new Divider<sbyte32>((sbyte32)sbyte.MinValue);
                Divider<sbyte32> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte32 denum = rng.NextSByte32(minR, maxR);
                    Divider<sbyte32> d = new Divider<sbyte32>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte32 num = rng.NextSByte32(minL, maxL);

                        sbyte32 trueQuo = maxmath.divrem(num, denum, out sbyte32 trueRem);
                        sbyte32 quoTest = d.DivRem(num, out sbyte32 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte32>(maxmath.shl((sbyte)1, rng.NextSByte32(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte32>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte32_sbyte()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte> d1 = new Divider<sbyte>((sbyte)1);
                Divider<sbyte> d2 = new Divider<sbyte>((sbyte)2);
                Divider<sbyte> dm1 = new Divider<sbyte>((sbyte)(-1));
                Divider<sbyte> dm2 = new Divider<sbyte>((sbyte)(-2));
                Divider<sbyte> overflow = new Divider<sbyte>((sbyte)sbyte.MinValue);
                Divider<sbyte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte denum = rng.NextSByte(minR, maxR);
                    Divider<sbyte> d = new Divider<sbyte>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte32 num = rng.NextSByte32(minL, maxL);

                        sbyte32 trueQuo = maxmath.divrem(num, denum, out sbyte32 trueRem);
                        sbyte32 quoTest = d.DivRem(num, out sbyte32 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte>((sbyte)(1 << rng.NextSByte(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte>((sbyte)-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }

        [Test]
        public static void _sbyte_sbyte32()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte32> d1 = new Divider<sbyte32>((sbyte32)1);
                Divider<sbyte32> d2 = new Divider<sbyte32>((sbyte32)2);
                Divider<sbyte32> dm1 = new Divider<sbyte32>((sbyte32)(-1));
                Divider<sbyte32> dm2 = new Divider<sbyte32>((sbyte32)(-2));
                Divider<sbyte32> overflow = new Divider<sbyte32>((sbyte32)sbyte.MinValue);
                Divider<sbyte32> pow2;

                for (int i = 0; i < 8; i++)
                {
                    sbyte32 denum = rng.NextSByte32(minR, maxR);
                    Divider<sbyte32> d = new Divider<sbyte32>(denum);

                    for (int j = 0; j < 4; j++)
                    {
                        sbyte num = rng.NextSByte(minL, maxL);

                        sbyte32 trueQuo = maxmath.divrem(num, denum, out sbyte32 trueRem);
                        sbyte32 quoTest = d.DivRem(num, out sbyte32 remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d);
                        Assert.AreEqual(trueRem, num % d);

                        trueQuo = maxmath.divrem(num, 1, out trueRem);
                        quoTest = d1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d1);
                        Assert.AreEqual(trueRem, num % d1);

                        trueQuo = maxmath.divrem(num, 2, out trueRem);
                        quoTest = d2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / d2);
                        Assert.AreEqual(trueRem, num % d2);

                        trueQuo = maxmath.divrem(num, -1, out trueRem);
                        quoTest = dm1.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm1);
                        Assert.AreEqual(trueRem, num % dm1);

                        trueQuo = maxmath.divrem(num, -2, out trueRem);
                        quoTest = dm2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / dm2);
                        Assert.AreEqual(trueRem, num % dm2);

                        trueQuo = maxmath.divrem(num, sbyte.MinValue, out trueRem);
                        quoTest = overflow.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / overflow);
                        Assert.AreEqual(trueRem, num % overflow);

                        pow2 = new Divider<sbyte32>(maxmath.shl((sbyte)1, rng.NextSByte32(0, 8)));
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                        pow2 = new Divider<sbyte32>(-pow2.Divisor);
                        trueQuo = maxmath.divrem(num, pow2.Divisor, out trueRem);
                        quoTest = pow2.DivRem(num, out remTest);
                        Assert.AreEqual(trueQuo, quoTest);
                        Assert.AreEqual(trueRem, remTest);
                        Assert.AreEqual(trueQuo, num / pow2);
                        Assert.AreEqual(trueRem, num % pow2);
                    }
                }
            });
        }


        [Test]
        public static void divisibility__UInt128()
        {
            TestUInt128(
            (minL, maxL, minR, maxR) =>
            {
                Random128 rng = Random128.New;
                Divider<UInt128> d1 = new Divider<UInt128>((UInt128)1);
                Divider<UInt128> d2 = new Divider<UInt128>((UInt128)2);
                Divider<UInt128> pow2;

                for (int i = 0; i < 8; i++)
                {
                    UInt128 denum = rng.NextUInt128(minR, maxR);
                    Divider<UInt128> d = new Divider<UInt128>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        UInt128 num = rng.NextUInt128(minL, maxL);
                        pow2 = new Divider<UInt128>((UInt128)1 << (int)rng.NextUInt128(0, 128));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }


        [Test]
        public static void divisibility__ulong()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong> d1 = new Divider<ulong>((ulong)1);
                Divider<ulong> d2 = new Divider<ulong>((ulong)2);
                Divider<ulong> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong denum = rng.NextULong(minR, maxR);
                    Divider<ulong> d = new Divider<ulong>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ulong num = rng.NextULong(minL, maxL);
                        pow2 = new Divider<ulong>(1ul << (int)rng.NextULong(0, 64));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ulong2()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong2> d1 = new Divider<ulong2>((ulong2)1);
                Divider<ulong2> d2 = new Divider<ulong2>((ulong2)2);
                Divider<ulong2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong2 denum = rng.NextULong2(minR, maxR);
                    Divider<ulong2> d = new Divider<ulong2>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ulong2 num = rng.NextULong2(minL, maxL);
                        pow2 = new Divider<ulong2>(maxmath.shl(1ul, rng.NextULong2(0, 64)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ulong2_ulong()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong> d1 = new Divider<ulong>((ulong)1);
                Divider<ulong> d2 = new Divider<ulong>((ulong)2);
                Divider<ulong> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong denum = rng.NextULong(minR, maxR);
                    Divider<ulong> d = new Divider<ulong>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ulong2 num = rng.NextULong2(minL, maxL);
                        pow2 = new Divider<ulong>(1ul << (int)rng.NextULong(0, 64));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ulong_ulong2()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong2> d1 = new Divider<ulong2>((ulong2)1);
                Divider<ulong2> d2 = new Divider<ulong2>((ulong2)2);
                Divider<ulong2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong2 denum = rng.NextULong2(minR, maxR);
                    Divider<ulong2> d = new Divider<ulong2>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ulong num = rng.NextULong(minL, maxL);
                        pow2 = new Divider<ulong2>(maxmath.shl(1ul, rng.NextULong2(0, 64)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ulong3()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong3> d1 = new Divider<ulong3>((ulong3)1);
                Divider<ulong3> d2 = new Divider<ulong3>((ulong3)2);
                Divider<ulong3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong3 denum = rng.NextULong3(minR, maxR);
                    Divider<ulong3> d = new Divider<ulong3>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ulong3 num = rng.NextULong3(minL, maxL);
                        pow2 = new Divider<ulong3>(maxmath.shl(1ul, rng.NextULong3(0, 64)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ulong3_ulong()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong> d1 = new Divider<ulong>((ulong)1);
                Divider<ulong> d2 = new Divider<ulong>((ulong)2);
                Divider<ulong> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong denum = rng.NextULong(minR, maxR);
                    Divider<ulong> d = new Divider<ulong>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ulong3 num = rng.NextULong3(minL, maxL);
                        pow2 = new Divider<ulong>(1ul << (int)rng.NextULong(0, 64));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ulong_ulong3()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong3> d1 = new Divider<ulong3>((ulong3)1);
                Divider<ulong3> d2 = new Divider<ulong3>((ulong3)2);
                Divider<ulong3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong3 denum = rng.NextULong3(minR, maxR);
                    Divider<ulong3> d = new Divider<ulong3>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ulong num = rng.NextULong(minL, maxL);
                        pow2 = new Divider<ulong3>(maxmath.shl(1ul, rng.NextULong3(0, 64)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ulong4()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong4> d1 = new Divider<ulong4>((ulong4)1);
                Divider<ulong4> d2 = new Divider<ulong4>((ulong4)2);
                Divider<ulong4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong4 denum = rng.NextULong4(minR, maxR);
                    Divider<ulong4> d = new Divider<ulong4>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ulong4 num = rng.NextULong4(minL, maxL);
                        pow2 = new Divider<ulong4>(maxmath.shl(1ul, rng.NextULong4(0, 64)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ulong4_ulong()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong> d1 = new Divider<ulong>((ulong)1);
                Divider<ulong> d2 = new Divider<ulong>((ulong)2);
                Divider<ulong> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong denum = rng.NextULong(minR, maxR);
                    Divider<ulong> d = new Divider<ulong>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ulong4 num = rng.NextULong4(minL, maxL);
                        pow2 = new Divider<ulong>(1ul << (int)rng.NextULong(0, 64));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ulong_ulong4()
        {
            TestULong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<ulong4> d1 = new Divider<ulong4>((ulong4)1);
                Divider<ulong4> d2 = new Divider<ulong4>((ulong4)2);
                Divider<ulong4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ulong4 denum = rng.NextULong4(minR, maxR);
                    Divider<ulong4> d = new Divider<ulong4>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ulong num = rng.NextULong(minL, maxL);
                        pow2 = new Divider<ulong4>(maxmath.shl(1ul, rng.NextULong4(0, 64)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }


        [Test]
        public static void divisibility__uint()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint> d1 = new Divider<uint>((uint)1);
                Divider<uint> d2 = new Divider<uint>((uint)2);
                Divider<uint> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint denum = rng.NextUInt(minR, maxR);
                    Divider<uint> d = new Divider<uint>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        uint num = rng.NextUInt(minL, maxL);
                        pow2 = new Divider<uint>(1u << (int)rng.NextUInt(0, 32));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__uint2()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint2> d1 = new Divider<uint2>((uint2)1);
                Divider<uint2> d2 = new Divider<uint2>((uint2)2);
                Divider<uint2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint2 denum = rng.NextUInt2(minR, maxR);
                    Divider<uint2> d = new Divider<uint2>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        uint2 num = rng.NextUInt2(minL, maxL);
                        pow2 = new Divider<uint2>(maxmath.shl(1u, rng.NextUInt2(0, 32)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__uint2_uint()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint> d1 = new Divider<uint>((uint)1);
                Divider<uint> d2 = new Divider<uint>((uint)2);
                Divider<uint> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint denum = rng.NextUInt(minR, maxR);
                    Divider<uint> d = new Divider<uint>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        uint2 num = rng.NextUInt2(minL, maxL);
                        pow2 = new Divider<uint>(1u << (int)rng.NextUInt(0, 32));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__uint_uint2()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint2> d1 = new Divider<uint2>((uint2)1);
                Divider<uint2> d2 = new Divider<uint2>((uint2)2);
                Divider<uint2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint2 denum = rng.NextUInt2(minR, maxR);
                    Divider<uint2> d = new Divider<uint2>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        uint num = rng.NextUInt(minL, maxL);
                        pow2 = new Divider<uint2>(maxmath.shl(1u, rng.NextUInt2(0, 32)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__uint3()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint3> d1 = new Divider<uint3>((uint3)1);
                Divider<uint3> d2 = new Divider<uint3>((uint3)2);
                Divider<uint3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint3 denum = rng.NextUInt3(minR, maxR);
                    Divider<uint3> d = new Divider<uint3>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        uint3 num = rng.NextUInt3(minL, maxL);
                        pow2 = new Divider<uint3>(maxmath.shl(1u, rng.NextUInt3(0, 32)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__uint3_uint()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint> d1 = new Divider<uint>((uint)1);
                Divider<uint> d2 = new Divider<uint>((uint)2);
                Divider<uint> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint denum = rng.NextUInt(minR, maxR);
                    Divider<uint> d = new Divider<uint>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        uint3 num = rng.NextUInt3(minL, maxL);
                        pow2 = new Divider<uint>(1u << (int)rng.NextUInt(0, 32));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__uint_uint3()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint3> d1 = new Divider<uint3>((uint3)1);
                Divider<uint3> d2 = new Divider<uint3>((uint3)2);
                Divider<uint3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint3 denum = rng.NextUInt3(minL, maxL);
                    Divider<uint3> d = new Divider<uint3>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        uint num = rng.NextUInt(minR, maxR);
                        pow2 = new Divider<uint3>(maxmath.shl(1u, rng.NextUInt3(0, 32)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__uint4()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint4> d1 = new Divider<uint4>((uint4)1);
                Divider<uint4> d2 = new Divider<uint4>((uint4)2);
                Divider<uint4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint4 denum = rng.NextUInt4(minR, maxR);
                    Divider<uint4> d = new Divider<uint4>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        uint4 num = rng.NextUInt4(minL, maxL);
                        pow2 = new Divider<uint4>(maxmath.shl(1u, rng.NextUInt4(0, 32)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__uint4_uint()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint> d1 = new Divider<uint>((uint)1);
                Divider<uint> d2 = new Divider<uint>((uint)2);
                Divider<uint> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint denum = rng.NextUInt(minR, maxR);
                    Divider<uint> d = new Divider<uint>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        uint4 num = rng.NextUInt4(minL, maxL);
                        pow2 = new Divider<uint>(1u << (int)rng.NextUInt(0, 32));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__uint_uint4()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint4> d1 = new Divider<uint4>((uint4)1);
                Divider<uint4> d2 = new Divider<uint4>((uint4)2);
                Divider<uint4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint4 denum = rng.NextUInt4(minR, maxR);
                    Divider<uint4> d = new Divider<uint4>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        uint num = rng.NextUInt(minL, maxL);
                        pow2 = new Divider<uint4>(maxmath.shl(1u, rng.NextUInt4(0, 32)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__uint8()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint8> d1 = new Divider<uint8>((uint8)1);
                Divider<uint8> d2 = new Divider<uint8>((uint8)2);
                Divider<uint8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint8 denum = rng.NextUInt8(minR, maxR);
                    Divider<uint8> d = new Divider<uint8>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        uint8 num = rng.NextUInt8(minL, maxL);
                        pow2 = new Divider<uint8>(maxmath.shl(1u, rng.NextUInt8(0, 32)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__uint8_uint()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint> d1 = new Divider<uint>((uint)1);
                Divider<uint> d2 = new Divider<uint>((uint)2);
                Divider<uint> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint denum = rng.NextUInt(minR, maxR);
                    Divider<uint> d = new Divider<uint>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        uint8 num = rng.NextUInt8(minL, maxL);
                        pow2 = new Divider<uint>(1u << (int)rng.NextUInt(0, 32));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__uint_uint8()
        {
            TestUInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<uint8> d1 = new Divider<uint8>((uint8)1);
                Divider<uint8> d2 = new Divider<uint8>((uint8)2);
                Divider<uint8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    uint8 denum = rng.NextUInt8(minR, maxR);
                    Divider<uint8> d = new Divider<uint8>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        uint num = rng.NextUInt(minL, maxL);
                        pow2 = new Divider<uint8>(maxmath.shl(1u, rng.NextUInt8(0, 32)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }


        [Test]
        public static void divisibility__ushort()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort> d1 = new Divider<ushort>((ushort)1);
                Divider<ushort> d2 = new Divider<ushort>((ushort)2);
                Divider<ushort> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort denum = rng.NextUShort(minR, maxR);
                    Divider<ushort> d = new Divider<ushort>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ushort num = rng.NextUShort(minL, maxL);
                        pow2 = new Divider<ushort>((ushort)(1u << (int)rng.NextUShort(0, 16)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ushort2()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort2> d1 = new Divider<ushort2>((ushort2)1);
                Divider<ushort2> d2 = new Divider<ushort2>((ushort2)2);
                Divider<ushort2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort2 denum = rng.NextUShort2(minR, maxR);
                    Divider<ushort2> d = new Divider<ushort2>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ushort2 num = rng.NextUShort2(minL, maxL);
                        pow2 = new Divider<ushort2>(maxmath.shl((ushort)1u, rng.NextUShort2(0, 16)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ushort2_ushort()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort> d1 = new Divider<ushort>((ushort)1);
                Divider<ushort> d2 = new Divider<ushort>((ushort)2);
                Divider<ushort> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort denum = rng.NextUShort(minR, maxR);
                    Divider<ushort> d = new Divider<ushort>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ushort2 num = rng.NextUShort2(minL, maxL);
                        pow2 = new Divider<ushort>((ushort)(1u << rng.NextUShort(0, 16)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ushort_ushort2()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort2> d1 = new Divider<ushort2>((ushort2)1);
                Divider<ushort2> d2 = new Divider<ushort2>((ushort2)2);
                Divider<ushort2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort2 denum = rng.NextUShort2(minR, maxR);
                    Divider<ushort2> d = new Divider<ushort2>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ushort num = rng.NextUShort(minL, maxL);
                        pow2 = new Divider<ushort2>(maxmath.shl((ushort)1u, rng.NextUShort2(0, 16)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ushort3()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort3> d1 = new Divider<ushort3>((ushort3)1);
                Divider<ushort3> d2 = new Divider<ushort3>((ushort3)2);
                Divider<ushort3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort3 denum = rng.NextUShort3(minR, maxR);
                    Divider<ushort3> d = new Divider<ushort3>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ushort3 num = rng.NextUShort3(minL, maxL);
                        pow2 = new Divider<ushort3>(maxmath.shl((ushort)1u, rng.NextUShort3(0, 16)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ushort3_ushort()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort> d1 = new Divider<ushort>((ushort)1);
                Divider<ushort> d2 = new Divider<ushort>((ushort)2);
                Divider<ushort> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort denum = rng.NextUShort(minR, maxR);
                    Divider<ushort> d = new Divider<ushort>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ushort3 num = rng.NextUShort3(minL, maxL);
                        pow2 = new Divider<ushort>((ushort)(1u << rng.NextUShort(0, 16)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ushort_ushort3()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort3> d1 = new Divider<ushort3>((ushort3)1);
                Divider<ushort3> d2 = new Divider<ushort3>((ushort3)2);
                Divider<ushort3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort3 denum = rng.NextUShort3(minR, maxR);
                    Divider<ushort3> d = new Divider<ushort3>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ushort num = rng.NextUShort(minL, maxL);
                        pow2 = new Divider<ushort3>(maxmath.shl((ushort)1u, rng.NextUShort3(0, 16)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ushort4()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort4> d1 = new Divider<ushort4>((ushort4)1);
                Divider<ushort4> d2 = new Divider<ushort4>((ushort4)2);
                Divider<ushort4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort4 denum = rng.NextUShort4(minR, maxR);
                    Divider<ushort4> d = new Divider<ushort4>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ushort4 num = rng.NextUShort4(minL, maxL);
                        pow2 = new Divider<ushort4>(maxmath.shl((ushort)1u, rng.NextUShort4(0, 16)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ushort4_ushort()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort> d1 = new Divider<ushort>((ushort)1);
                Divider<ushort> d2 = new Divider<ushort>((ushort)2);
                Divider<ushort> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort denum = rng.NextUShort(minR, maxR);
                    Divider<ushort> d = new Divider<ushort>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ushort4 num = rng.NextUShort4(minL, maxL);
                        pow2 = new Divider<ushort>((ushort)(1u << rng.NextUShort(0, 16)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ushort_ushort4()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort4> d1 = new Divider<ushort4>((ushort4)1);
                Divider<ushort4> d2 = new Divider<ushort4>((ushort4)2);
                Divider<ushort4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort4 denum = rng.NextUShort4(minR, maxR);
                    Divider<ushort4> d = new Divider<ushort4>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ushort num = rng.NextUShort(minL, maxL);
                        pow2 = new Divider<ushort4>(maxmath.shl((ushort)1u, rng.NextUShort4(0, 16)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ushort8()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort8> d1 = new Divider<ushort8>((ushort8)1);
                Divider<ushort8> d2 = new Divider<ushort8>((ushort8)2);
                Divider<ushort8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort8 denum = rng.NextUShort8(minR, maxR);
                    Divider<ushort8> d = new Divider<ushort8>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ushort8 num = rng.NextUShort8(minL, maxL);
                        pow2 = new Divider<ushort8>(maxmath.shl((ushort)1u, rng.NextUShort8(0, 16)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ushort8_ushort()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort> d1 = new Divider<ushort>((ushort)1);
                Divider<ushort> d2 = new Divider<ushort>((ushort)2);
                Divider<ushort> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort denum = rng.NextUShort(minR, maxR);
                    Divider<ushort> d = new Divider<ushort>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ushort8 num = rng.NextUShort8(minL, maxL);
                        pow2 = new Divider<ushort>((ushort)(1u << rng.NextUShort(0, 16)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ushort_ushort8()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort8> d1 = new Divider<ushort8>((ushort8)1);
                Divider<ushort8> d2 = new Divider<ushort8>((ushort8)2);
                Divider<ushort8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort8 denum = rng.NextUShort8(minR, maxR);
                    Divider<ushort8> d = new Divider<ushort8>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ushort num = rng.NextUShort(minL, maxL);
                        pow2 = new Divider<ushort8>(maxmath.shl((ushort)1u, rng.NextUShort8(0, 16)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ushort16()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort16> d1 = new Divider<ushort16>((ushort16)1);
                Divider<ushort16> d2 = new Divider<ushort16>((ushort16)2);
                Divider<ushort16> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort16 denum = rng.NextUShort16(minR, maxR);
                    Divider<ushort16> d = new Divider<ushort16>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ushort16 num = rng.NextUShort16(minL, maxL);
                        pow2 = new Divider<ushort16>(maxmath.shl((ushort)1u, rng.NextUShort16(0, 16)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ushort16_ushort()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort> d1 = new Divider<ushort>((ushort)1);
                Divider<ushort> d2 = new Divider<ushort>((ushort)2);
                Divider<ushort> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort denum = rng.NextUShort(minR, maxR);
                    Divider<ushort> d = new Divider<ushort>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ushort16 num = rng.NextUShort16(minL, maxL);
                        pow2 = new Divider<ushort>((ushort)(1u << rng.NextUShort(0, 16)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__ushort_ushort16()
        {
            TestUShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<ushort16> d1 = new Divider<ushort16>((ushort16)1);
                Divider<ushort16> d2 = new Divider<ushort16>((ushort16)2);
                Divider<ushort16> pow2;

                for (int i = 0; i < 8; i++)
                {
                    ushort16 denum = rng.NextUShort16(minR, maxR);
                    Divider<ushort16> d = new Divider<ushort16>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        ushort num = rng.NextUShort(minL, maxL);
                        pow2 = new Divider<ushort16>(maxmath.shl((ushort)1u, rng.NextUShort16(0, 16)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }



        [Test]
        public static void divisibility__byte()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte> d1 = new Divider<byte>((byte)1);
                Divider<byte> d2 = new Divider<byte>((byte)2);
                Divider<byte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte denum = rng.NextByte(minR, maxR);
                    Divider<byte> d = new Divider<byte>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte num = rng.NextByte(minL, maxL);
                        pow2 = new Divider<byte>((byte)(1u << (int)rng.NextByte(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte2()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte2> d1 = new Divider<byte2>((byte2)1);
                Divider<byte2> d2 = new Divider<byte2>((byte2)2);
                Divider<byte2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte2 denum = rng.NextByte2(minR, maxR);
                    Divider<byte2> d = new Divider<byte2>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte2 num = rng.NextByte2(minL, maxL);
                        pow2 = new Divider<byte2>(maxmath.shl((byte)1u, rng.NextByte2(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte2_byte()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte> d1 = new Divider<byte>((byte)1);
                Divider<byte> d2 = new Divider<byte>((byte)2);
                Divider<byte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte denum = rng.NextByte(minR, maxR);
                    Divider<byte> d = new Divider<byte>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte2 num = rng.NextByte2(minL, maxL);
                        pow2 = new Divider<byte>((byte)(1u << rng.NextByte(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte_byte2()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte2> d1 = new Divider<byte2>((byte2)1);
                Divider<byte2> d2 = new Divider<byte2>((byte2)2);
                Divider<byte2> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte2 denum = rng.NextByte2(minR, maxR);
                    Divider<byte2> d = new Divider<byte2>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte num = rng.NextByte(minL, maxL);
                        pow2 = new Divider<byte2>(maxmath.shl((byte)1u, rng.NextByte2(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte3()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte3> d1 = new Divider<byte3>((byte3)1);
                Divider<byte3> d2 = new Divider<byte3>((byte3)2);
                Divider<byte3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte3 denum = rng.NextByte3(minR, maxR);
                    Divider<byte3> d = new Divider<byte3>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte3 num = rng.NextByte3(minL, maxL);
                        pow2 = new Divider<byte3>(maxmath.shl((byte)1u, rng.NextByte3(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte3_byte()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte> d1 = new Divider<byte>((byte)1);
                Divider<byte> d2 = new Divider<byte>((byte)2);
                Divider<byte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte denum = rng.NextByte(minR, maxR);
                    Divider<byte> d = new Divider<byte>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte3 num = rng.NextByte3(minL, maxL);
                        pow2 = new Divider<byte>((byte)(1u << rng.NextByte(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte_byte3()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte3> d1 = new Divider<byte3>((byte3)1);
                Divider<byte3> d2 = new Divider<byte3>((byte3)2);
                Divider<byte3> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte3 denum = rng.NextByte3(minR, maxR);
                    Divider<byte3> d = new Divider<byte3>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte num = rng.NextByte(minL, maxL);
                        pow2 = new Divider<byte3>(maxmath.shl((byte)1u, rng.NextByte3(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte4()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte4> d1 = new Divider<byte4>((byte4)1);
                Divider<byte4> d2 = new Divider<byte4>((byte4)2);
                Divider<byte4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte4 denum = rng.NextByte4(minR, maxR);
                    Divider<byte4> d = new Divider<byte4>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte4 num = rng.NextByte4(minL, maxL);
                        pow2 = new Divider<byte4>(maxmath.shl((byte)1u, rng.NextByte4(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte4_byte()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte> d1 = new Divider<byte>((byte)1);
                Divider<byte> d2 = new Divider<byte>((byte)2);
                Divider<byte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte denum = rng.NextByte(minR, maxR);
                    Divider<byte> d = new Divider<byte>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte4 num = rng.NextByte4(minL, maxL);
                        pow2 = new Divider<byte>((byte)(1u << rng.NextByte(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte_byte4()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte4> d1 = new Divider<byte4>((byte4)1);
                Divider<byte4> d2 = new Divider<byte4>((byte4)2);
                Divider<byte4> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte4 denum = rng.NextByte4(minR, maxR);
                    Divider<byte4> d = new Divider<byte4>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte num = rng.NextByte(minL, maxL);
                        pow2 = new Divider<byte4>(maxmath.shl((byte)1u, rng.NextByte4(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte8()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte8> d1 = new Divider<byte8>((byte8)1);
                Divider<byte8> d2 = new Divider<byte8>((byte8)2);
                Divider<byte8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte8 denum = rng.NextByte8(minR, maxR);
                    Divider<byte8> d = new Divider<byte8>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte8 num = rng.NextByte8(minL, maxL);
                        pow2 = new Divider<byte8>(maxmath.shl((byte)1u, rng.NextByte8(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte8_byte()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte> d1 = new Divider<byte>((byte)1);
                Divider<byte> d2 = new Divider<byte>((byte)2);
                Divider<byte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte denum = rng.NextByte(minR, maxR);
                    Divider<byte> d = new Divider<byte>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte8 num = rng.NextByte8(minL, maxL);
                        pow2 = new Divider<byte>((byte)(1u << rng.NextByte(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte_byte8()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte8> d1 = new Divider<byte8>((byte8)1);
                Divider<byte8> d2 = new Divider<byte8>((byte8)2);
                Divider<byte8> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte8 denum = rng.NextByte8(minR, maxR);
                    Divider<byte8> d = new Divider<byte8>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte num = rng.NextByte(minL, maxL);
                        pow2 = new Divider<byte8>(maxmath.shl((byte)1u, rng.NextByte8(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte16()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte16> d1 = new Divider<byte16>((byte16)1);
                Divider<byte16> d2 = new Divider<byte16>((byte16)2);
                Divider<byte16> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte16 denum = rng.NextByte16(minR, maxR);
                    Divider<byte16> d = new Divider<byte16>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte16 num = rng.NextByte16(minL, maxL);
                        pow2 = new Divider<byte16>(maxmath.shl((byte)1u, rng.NextByte16(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte16_byte()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte> d1 = new Divider<byte>((byte)1);
                Divider<byte> d2 = new Divider<byte>((byte)2);
                Divider<byte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte denum = rng.NextByte(minR, maxR);
                    Divider<byte> d = new Divider<byte>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte16 num = rng.NextByte16(minL, maxL);
                        pow2 = new Divider<byte>((byte)(1u << rng.NextByte(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte_byte16()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte16> d1 = new Divider<byte16>((byte16)1);
                Divider<byte16> d2 = new Divider<byte16>((byte16)2);
                Divider<byte16> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte16 denum = rng.NextByte16(minR, maxR);
                    Divider<byte16> d = new Divider<byte16>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte num = rng.NextByte(minL, maxL);
                        pow2 = new Divider<byte16>(maxmath.shl((byte)1u, rng.NextByte16(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte32()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte32> d1 = new Divider<byte32>((byte32)1);
                Divider<byte32> d2 = new Divider<byte32>((byte32)2);
                Divider<byte32> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte32 denum = rng.NextByte32(minR, maxR);
                    Divider<byte32> d = new Divider<byte32>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte32 num = rng.NextByte32(minL, maxL);
                        pow2 = new Divider<byte32>(maxmath.shl((byte)1u, rng.NextByte32(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte32_byte()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte> d1 = new Divider<byte>((byte)1);
                Divider<byte> d2 = new Divider<byte>((byte)2);
                Divider<byte> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte denum = rng.NextByte(minR, maxR);
                    Divider<byte> d = new Divider<byte>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte32 num = rng.NextByte32(minL, maxL);
                        pow2 = new Divider<byte>((byte)(1u << rng.NextByte(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__byte_byte32()
        {
            TestByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<byte32> d1 = new Divider<byte32>((byte32)1);
                Divider<byte32> d2 = new Divider<byte32>((byte32)2);
                Divider<byte32> pow2;

                for (int i = 0; i < 8; i++)
                {
                    byte32 denum = rng.NextByte32(minR, maxR);
                    Divider<byte32> d = new Divider<byte32>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        byte num = rng.NextByte(minL, maxL);
                        pow2 = new Divider<byte32>(maxmath.shl((byte)1u, rng.NextByte32(0, 8)));

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                    }
                }
            });
        }



        [Test]
        public static void divisibility__Int128()
        {
            TestInt128(
            (minL, maxL, minR, maxR) =>
            {
                Random128 rng = Random128.New;
                Divider<Int128> d1 = new Divider<Int128>((Int128)1);
                Divider<Int128> d2 = new Divider<Int128>((Int128)2);
                Divider<Int128> dm1 = new Divider<Int128>((Int128)(-1));
                Divider<Int128> dm2 = new Divider<Int128>((Int128)(-2));
                Divider<Int128> overflow = new Divider<Int128>(Int128.MinValue);
                Divider<Int128> pow2;
                Divider<Int128> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    Int128 denum = rng.NextInt128(minR, maxR);
                    Divider<Int128> d = new Divider<Int128>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        Int128 num = rng.NextInt128(minL, maxL);
                        pow2 = new Divider<Int128>((Int128)1L << (int)rng.NextInt128(0, 128));
                        pow2m = new Divider<Int128>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }


        [Test]
        public static void divisibility__long()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long> d1 = new Divider<long>((long)1);
                Divider<long> d2 = new Divider<long>((long)2);
                Divider<long> dm1 = new Divider<long>((long)-1);
                Divider<long> dm2 = new Divider<long>((long)-2);
                Divider<long> overflow = new Divider<long>(long.MinValue);
                Divider<long> pow2;
                Divider<long> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    long denum = rng.NextLong(minR, maxR);
                    Divider<long> d = new Divider<long>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        long num = rng.NextLong(minL, maxL);
                        pow2 = new Divider<long>(1L << (int)rng.NextLong(0, 64));
                        pow2m = new Divider<long>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__long2()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long2> d1 = new Divider<long2>((long2)1);
                Divider<long2> d2 = new Divider<long2>((long2)2);
                Divider<long2> dm1 = new Divider<long2>((long2)(-1));
                Divider<long2> dm2 = new Divider<long2>((long2)(-2));
                Divider<long2> overflow = new Divider<long2>((long2)long.MinValue);
                Divider<long2> pow2;
                Divider<long2> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    long2 denum = rng.NextLong2(minR, maxR);
                    Divider<long2> d = new Divider<long2>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        long2 num = rng.NextLong2(minL, maxL);
                        pow2 = new Divider<long2>(maxmath.shl((long2)1L, rng.NextLong2(0, 64)));
                        pow2m = new Divider<long2>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__long2_long()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long> d1 = new Divider<long>((long)1);
                Divider<long> d2 = new Divider<long>((long)2);
                Divider<long> dm1 = new Divider<long>((long)(-1));
                Divider<long> dm2 = new Divider<long>((long)(-2));
                Divider<long> overflow = new Divider<long>((long)long.MinValue);
                Divider<long> pow2;
                Divider<long> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    long denum = rng.NextLong(minR, maxR);
                    Divider<long> d = new Divider<long>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        long2 num = rng.NextLong2(minL, maxL);
                        pow2 = new Divider<long>(1L << (int)rng.NextLong(0, 64));
                        pow2m = new Divider<long>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__long_long2()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long2> d1 = new Divider<long2>((long2)1);
                Divider<long2> d2 = new Divider<long2>((long2)2);
                Divider<long2> dm1 = new Divider<long2>((long2)(-1));
                Divider<long2> dm2 = new Divider<long2>((long2)(-2));
                Divider<long2> overflow = new Divider<long2>((long2)long.MinValue);
                Divider<long2> pow2;
                Divider<long2> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    long2 denum = rng.NextLong2(minR, maxR);
                    Divider<long2> d = new Divider<long2>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        long num = rng.NextLong(minL, maxL);
                        pow2 = new Divider<long2>(maxmath.shl((long2)1L, rng.NextLong2(0, 64)));
                        pow2m = new Divider<long2>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__long3()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long3> d1 = new Divider<long3>((long3)1);
                Divider<long3> d2 = new Divider<long3>((long3)2);
                Divider<long3> dm1 = new Divider<long3>((long3)(-1));
                Divider<long3> dm2 = new Divider<long3>((long3)(-2));
                Divider<long3> overflow = new Divider<long3>((long3)long.MinValue);
                Divider<long3> pow2;
                Divider<long3> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    long3 denum = rng.NextLong3(minR, maxR);
                    Divider<long3> d = new Divider<long3>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        long3 num = rng.NextLong3(minL, maxL);
                        pow2 = new Divider<long3>(maxmath.shl((long3)1L, rng.NextLong3(0, 64)));
                        pow2m = new Divider<long3>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__long3_long()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long> d1 = new Divider<long>((long)1);
                Divider<long> d2 = new Divider<long>((long)2);
                Divider<long> dm1 = new Divider<long>((long)(-1));
                Divider<long> dm2 = new Divider<long>((long)(-2));
                Divider<long> overflow = new Divider<long>((long)long.MinValue);
                Divider<long> pow2;
                Divider<long> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    long denum = rng.NextLong(minR, maxR);
                    Divider<long> d = new Divider<long>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        long3 num = rng.NextLong3(minL, maxL);
                        pow2 = new Divider<long>(1L << (int)rng.NextLong(0, 64));
                        pow2m = new Divider<long>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__long_long3()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long3> d1 = new Divider<long3>((long3)1);
                Divider<long3> d2 = new Divider<long3>((long3)2);
                Divider<long3> dm1 = new Divider<long3>((long3)(-1));
                Divider<long3> dm2 = new Divider<long3>((long3)(-2));
                Divider<long3> overflow = new Divider<long3>((long3)long.MinValue);
                Divider<long3> pow2;
                Divider<long3> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    long3 denum = rng.NextLong3(minR, maxR);
                    Divider<long3> d = new Divider<long3>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        long num = rng.NextLong(minL, maxL);
                        pow2 = new Divider<long3>(maxmath.shl((long3)1L, rng.NextLong3(0, 64)));
                        pow2m = new Divider<long3>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__long4()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long4> d1 = new Divider<long4>((long4)1);
                Divider<long4> d2 = new Divider<long4>((long4)2);
                Divider<long4> dm1 = new Divider<long4>((long4)(-1));
                Divider<long4> dm2 = new Divider<long4>((long4)(-2));
                Divider<long4> overflow = new Divider<long4>((long4)long.MinValue);
                Divider<long4> pow2;
                Divider<long4> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    long4 denum = rng.NextLong4(minR, maxR);
                    Divider<long4> d = new Divider<long4>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        long4 num = rng.NextLong4(minL, maxL);
                        pow2 = new Divider<long4>(maxmath.shl((long4)1L, rng.NextLong4(0, 64)));
                        pow2m = new Divider<long4>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__long4_long()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long> d1 = new Divider<long>((long)1);
                Divider<long> d2 = new Divider<long>((long)2);
                Divider<long> dm1 = new Divider<long>((long)(-1));
                Divider<long> dm2 = new Divider<long>((long)(-2));
                Divider<long> overflow = new Divider<long>((long)long.MinValue);
                Divider<long> pow2;
                Divider<long> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    long denum = rng.NextLong(minR, maxR);
                    Divider<long> d = new Divider<long>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        long4 num = rng.NextLong4(minL, maxL);
                        pow2 = new Divider<long>(1L << (int)rng.NextLong(0, 64));
                        pow2m = new Divider<long>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__long_long4()
        {
            TestLong(
            (minL, maxL, minR, maxR) =>
            {
                Random64 rng = Random64.New;
                Divider<long4> d1 = new Divider<long4>((long4)1);
                Divider<long4> d2 = new Divider<long4>((long4)2);
                Divider<long4> dm1 = new Divider<long4>((long4)(-1));
                Divider<long4> dm2 = new Divider<long4>((long4)(-2));
                Divider<long4> overflow = new Divider<long4>((long4)long.MinValue);
                Divider<long4> pow2;
                Divider<long4> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    long4 denum = rng.NextLong4(minR, maxR);
                    Divider<long4> d = new Divider<long4>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        long num = rng.NextLong(minL, maxL);
                        pow2 = new Divider<long4>(maxmath.shl((long4)1L, rng.NextLong4(0, 64)));
                        pow2m = new Divider<long4>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }


        [Test]
        public static void divisibility__int()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int> d1 = new Divider<int>((int)1);
                Divider<int> d2 = new Divider<int>((int)2);
                Divider<int> dm1 = new Divider<int>((int)-1);
                Divider<int> dm2 = new Divider<int>((int)-2);
                Divider<int> overflow = new Divider<int>(int.MinValue);
                Divider<int> pow2;
                Divider<int> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    int denum = rng.NextInt(minR, maxR);
                    Divider<int> d = new Divider<int>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        int num = rng.NextInt(minL, maxL);
                        pow2 = new Divider<int>(1 << rng.NextInt(0, 32));
                        pow2m = new Divider<int>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__int2()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int2> d1 = new Divider<int2>((int2)1);
                Divider<int2> d2 = new Divider<int2>((int2)2);
                Divider<int2> dm1 = new Divider<int2>((int2)(-1));
                Divider<int2> dm2 = new Divider<int2>((int2)(-2));
                Divider<int2> overflow = new Divider<int2>((int2)int.MinValue);
                Divider<int2> pow2;
                Divider<int2> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    int2 denum = rng.NextInt2(minR, maxR);
                    Divider<int2> d = new Divider<int2>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        int2 num = rng.NextInt2(minL, maxL);
                        pow2 = new Divider<int2>(maxmath.shl((int2)1, rng.NextInt2(0, 32)));
                        pow2m = new Divider<int2>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__int2_int()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int> d1 = new Divider<int>((int)1);
                Divider<int> d2 = new Divider<int>((int)2);
                Divider<int> dm1 = new Divider<int>((int)(-1));
                Divider<int> dm2 = new Divider<int>((int)(-2));
                Divider<int> overflow = new Divider<int>((int)int.MinValue);
                Divider<int> pow2;
                Divider<int> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    int denum = rng.NextInt(minR, maxR);
                    Divider<int> d = new Divider<int>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        int2 num = rng.NextInt2(minL, maxL);
                        pow2 = new Divider<int>(1 << rng.NextInt(0, 32));
                        pow2m = new Divider<int>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__int_int2()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int2> d1 = new Divider<int2>((int2)1);
                Divider<int2> d2 = new Divider<int2>((int2)2);
                Divider<int2> dm1 = new Divider<int2>((int2)(-1));
                Divider<int2> dm2 = new Divider<int2>((int2)(-2));
                Divider<int2> overflow = new Divider<int2>((int2)int.MinValue);
                Divider<int2> pow2;
                Divider<int2> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    int2 denum = rng.NextInt2(minR, maxR);
                    Divider<int2> d = new Divider<int2>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        int num = rng.NextInt(minL, maxL);
                        pow2 = new Divider<int2>(maxmath.shl((int2)1, rng.NextInt2(0, 32)));
                        pow2m = new Divider<int2>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__int3()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int3> d1 = new Divider<int3>((int3)1);
                Divider<int3> d2 = new Divider<int3>((int3)2);
                Divider<int3> dm1 = new Divider<int3>((int3)(-1));
                Divider<int3> dm2 = new Divider<int3>((int3)(-2));
                Divider<int3> overflow = new Divider<int3>((int3)int.MinValue);
                Divider<int3> pow2;
                Divider<int3> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    int3 denum = rng.NextInt3(minR, maxR);
                    Divider<int3> d = new Divider<int3>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        int3 num = rng.NextInt3(minL, maxL);
                        pow2 = new Divider<int3>(maxmath.shl((int3)1, rng.NextInt3(0, 32)));
                        pow2m = new Divider<int3>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__int3_int()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int> d1 = new Divider<int>((int)1);
                Divider<int> d2 = new Divider<int>((int)2);
                Divider<int> dm1 = new Divider<int>((int)(-1));
                Divider<int> dm2 = new Divider<int>((int)(-2));
                Divider<int> overflow = new Divider<int>((int)int.MinValue);
                Divider<int> pow2;
                Divider<int> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    int denum = rng.NextInt(minR, maxR);
                    Divider<int> d = new Divider<int>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        int3 num = rng.NextInt3(minL, maxL);
                        pow2 = new Divider<int>(1 << rng.NextInt(0, 32));
                        pow2m = new Divider<int>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__int_int3()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int3> d1 = new Divider<int3>((int3)1);
                Divider<int3> d2 = new Divider<int3>((int3)2);
                Divider<int3> dm1 = new Divider<int3>((int3)(-1));
                Divider<int3> dm2 = new Divider<int3>((int3)(-2));
                Divider<int3> overflow = new Divider<int3>((int3)int.MinValue);
                Divider<int3> pow2;
                Divider<int3> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    int3 denum = rng.NextInt3(minR, maxR);
                    Divider<int3> d = new Divider<int3>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        int num = rng.NextInt(minL, maxL);
                        pow2 = new Divider<int3>(maxmath.shl((int3)1, rng.NextInt3(0, 32)));
                        pow2m = new Divider<int3>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__int4()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int4> d1 = new Divider<int4>((int4)1);
                Divider<int4> d2 = new Divider<int4>((int4)2);
                Divider<int4> dm1 = new Divider<int4>((int4)(-1));
                Divider<int4> dm2 = new Divider<int4>((int4)(-2));
                Divider<int4> overflow = new Divider<int4>((int4)int.MinValue);
                Divider<int4> pow2;
                Divider<int4> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    int4 denum = rng.NextInt4(minR, maxR);
                    Divider<int4> d = new Divider<int4>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        int4 num = rng.NextInt4(minL, maxL);
                        pow2 = new Divider<int4>(maxmath.shl((int4)1, rng.NextInt4(0, 32)));
                        pow2m = new Divider<int4>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__int4_int()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int> d1 = new Divider<int>((int)1);
                Divider<int> d2 = new Divider<int>((int)2);
                Divider<int> dm1 = new Divider<int>((int)(-1));
                Divider<int> dm2 = new Divider<int>((int)(-2));
                Divider<int> overflow = new Divider<int>((int)int.MinValue);
                Divider<int> pow2;
                Divider<int> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    int denum = rng.NextInt(minR, maxR);
                    Divider<int> d = new Divider<int>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        int4 num = rng.NextInt4(minL, maxL);
                        pow2 = new Divider<int>(1 << rng.NextInt(0, 32));
                        pow2m = new Divider<int>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__int_int4()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int4> d1 = new Divider<int4>((int4)1);
                Divider<int4> d2 = new Divider<int4>((int4)2);
                Divider<int4> dm1 = new Divider<int4>((int4)(-1));
                Divider<int4> dm2 = new Divider<int4>((int4)(-2));
                Divider<int4> overflow = new Divider<int4>((int4)int.MinValue);
                Divider<int4> pow2;
                Divider<int4> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    int4 denum = rng.NextInt4(minR, maxR);
                    Divider<int4> d = new Divider<int4>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        int num = rng.NextInt(minL, maxL);
                        pow2 = new Divider<int4>(maxmath.shl((int4)1, rng.NextInt4(0, 32)));
                        pow2m = new Divider<int4>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__int8()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int8> d1 = new Divider<int8>((int8)1);
                Divider<int8> d2 = new Divider<int8>((int8)2);
                Divider<int8> dm1 = new Divider<int8>((int8)(-1));
                Divider<int8> dm2 = new Divider<int8>((int8)(-2));
                Divider<int8> overflow = new Divider<int8>((int8)int.MinValue);
                Divider<int8> pow2;
                Divider<int8> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    int8 denum = rng.NextInt8(minR, maxR);
                    Divider<int8> d = new Divider<int8>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        int8 num = rng.NextInt8(minL, maxL);
                        pow2 = new Divider<int8>(maxmath.shl((int8)1, rng.NextInt8(0, 32)));
                        pow2m = new Divider<int8>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__int8_int()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int> d1 = new Divider<int>((int)1);
                Divider<int> d2 = new Divider<int>((int)2);
                Divider<int> dm1 = new Divider<int>((int)(-1));
                Divider<int> dm2 = new Divider<int>((int)(-2));
                Divider<int> overflow = new Divider<int>((int)int.MinValue);
                Divider<int> pow2;
                Divider<int> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    int denum = rng.NextInt(minR, maxR);
                    Divider<int> d = new Divider<int>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        int8 num = rng.NextInt8(minL, maxL);
                        pow2 = new Divider<int>(1 << rng.NextInt(0, 32));
                        pow2m = new Divider<int>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__int_int8()
        {
            TestInt(
            (minL, maxL, minR, maxR) =>
            {
                Random32 rng = Random32.New;
                Divider<int8> d1 = new Divider<int8>((int8)1);
                Divider<int8> d2 = new Divider<int8>((int8)2);
                Divider<int8> dm1 = new Divider<int8>((int8)(-1));
                Divider<int8> dm2 = new Divider<int8>((int8)(-2));
                Divider<int8> overflow = new Divider<int8>((int8)int.MinValue);
                Divider<int8> pow2;
                Divider<int8> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    int8 denum = rng.NextInt8(minR, maxR);
                    Divider<int8> d = new Divider<int8>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        int num = rng.NextInt(minL, maxL);
                        pow2 = new Divider<int8>(maxmath.shl((int8)1, rng.NextInt8(0, 32)));
                        pow2m = new Divider<int8>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }


        [Test]
        public static void divisibility__short()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short> d1 = new Divider<short>((short)1);
                Divider<short> d2 = new Divider<short>((short)2);
                Divider<short> dm1 = new Divider<short>((short)-1);
                Divider<short> dm2 = new Divider<short>((short)-2);
                Divider<short> overflow = new Divider<short>(short.MinValue);
                Divider<short> pow2;
                Divider<short> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    short denum = rng.NextShort(minR, maxR);
                    Divider<short> d = new Divider<short>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        short num = rng.NextShort(minL, maxL);
                        pow2 = new Divider<short>((short)(1 << rng.NextShort(0, 16)));
                        pow2m = new Divider<short>((short)-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__short2()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short2> d1 = new Divider<short2>((short2)1);
                Divider<short2> d2 = new Divider<short2>((short2)2);
                Divider<short2> dm1 = new Divider<short2>((short2)(-1));
                Divider<short2> dm2 = new Divider<short2>((short2)(-2));
                Divider<short2> overflow = new Divider<short2>((short2)short.MinValue);
                Divider<short2> pow2;
                Divider<short2> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    short2 denum = rng.NextShort2(minR, maxR);
                    Divider<short2> d = new Divider<short2>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        short2 num = rng.NextShort2(minL, maxL);
                        pow2 = new Divider<short2>(maxmath.shl((short)1, rng.NextShort2(0, 16)));
                        pow2m = new Divider<short2>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__short2_short()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short> d1 = new Divider<short>((short)1);
                Divider<short> d2 = new Divider<short>((short)2);
                Divider<short> dm1 = new Divider<short>((short)(-1));
                Divider<short> dm2 = new Divider<short>((short)(-2));
                Divider<short> overflow = new Divider<short>((short)short.MinValue);
                Divider<short> pow2;
                Divider<short> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    short denum = rng.NextShort(minR, maxR);
                    Divider<short> d = new Divider<short>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        short2 num = rng.NextShort2(minL, maxL);
                        pow2 = new Divider<short>((short)(1 << rng.NextShort(0, 16)));
                        pow2m = new Divider<short>((short)-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__short_short2()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short2> d1 = new Divider<short2>((short2)1);
                Divider<short2> d2 = new Divider<short2>((short2)2);
                Divider<short2> dm1 = new Divider<short2>((short2)(-1));
                Divider<short2> dm2 = new Divider<short2>((short2)(-2));
                Divider<short2> overflow = new Divider<short2>((short2)short.MinValue);
                Divider<short2> pow2;
                Divider<short2> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    short2 denum = rng.NextShort2(minR, maxR);
                    Divider<short2> d = new Divider<short2>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        short num = rng.NextShort(minL, maxL);
                        pow2 = new Divider<short2>(maxmath.shl((short)1, rng.NextShort2(0, 16)));
                        pow2m = new Divider<short2>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__short3()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short3> d1 = new Divider<short3>((short3)1);
                Divider<short3> d2 = new Divider<short3>((short3)2);
                Divider<short3> dm1 = new Divider<short3>((short3)(-1));
                Divider<short3> dm2 = new Divider<short3>((short3)(-2));
                Divider<short3> overflow = new Divider<short3>((short3)short.MinValue);
                Divider<short3> pow2;
                Divider<short3> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    short3 denum = rng.NextShort3(minR, maxR);
                    Divider<short3> d = new Divider<short3>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        short3 num = rng.NextShort3(minL, maxL);
                        pow2 = new Divider<short3>(maxmath.shl((short)1, rng.NextShort3(0, 16)));
                        pow2m = new Divider<short3>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__short3_short()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short> d1 = new Divider<short>((short)1);
                Divider<short> d2 = new Divider<short>((short)2);
                Divider<short> dm1 = new Divider<short>((short)(-1));
                Divider<short> dm2 = new Divider<short>((short)(-2));
                Divider<short> overflow = new Divider<short>((short)short.MinValue);
                Divider<short> pow2;
                Divider<short> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    short denum = rng.NextShort(minR, maxR);
                    Divider<short> d = new Divider<short>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        short3 num = rng.NextShort3(minL, maxL);
                        pow2 = new Divider<short>((short)(1 << rng.NextShort(0, 16)));
                        pow2m = new Divider<short>((short)-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__short_short3()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short3> d1 = new Divider<short3>((short3)1);
                Divider<short3> d2 = new Divider<short3>((short3)2);
                Divider<short3> dm1 = new Divider<short3>((short3)(-1));
                Divider<short3> dm2 = new Divider<short3>((short3)(-2));
                Divider<short3> overflow = new Divider<short3>((short3)short.MinValue);
                Divider<short3> pow2;
                Divider<short3> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    short3 denum = rng.NextShort3(minR, maxR);
                    Divider<short3> d = new Divider<short3>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        short num = rng.NextShort(minL, maxL);
                        pow2 = new Divider<short3>(maxmath.shl((short)1, rng.NextShort3(0, 16)));
                        pow2m = new Divider<short3>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__short4()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short4> d1 = new Divider<short4>((short4)1);
                Divider<short4> d2 = new Divider<short4>((short4)2);
                Divider<short4> dm1 = new Divider<short4>((short4)(-1));
                Divider<short4> dm2 = new Divider<short4>((short4)(-2));
                Divider<short4> overflow = new Divider<short4>((short4)short.MinValue);
                Divider<short4> pow2;
                Divider<short4> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    short4 denum = rng.NextShort4(minR, maxR);
                    Divider<short4> d = new Divider<short4>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        short4 num = rng.NextShort4(minL, maxL);
                        pow2 = new Divider<short4>(maxmath.shl((short)1, rng.NextShort4(0, 16)));
                        pow2m = new Divider<short4>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__short4_short()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short> d1 = new Divider<short>((short)1);
                Divider<short> d2 = new Divider<short>((short)2);
                Divider<short> dm1 = new Divider<short>((short)(-1));
                Divider<short> dm2 = new Divider<short>((short)(-2));
                Divider<short> overflow = new Divider<short>((short)short.MinValue);
                Divider<short> pow2;
                Divider<short> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    short denum = rng.NextShort(minR, maxR);
                    Divider<short> d = new Divider<short>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        short4 num = rng.NextShort4(minL, maxL);
                        pow2 = new Divider<short>((short)(1 << rng.NextShort(0, 16)));
                        pow2m = new Divider<short>((short)-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__short_short4()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short4> d1 = new Divider<short4>((short4)1);
                Divider<short4> d2 = new Divider<short4>((short4)2);
                Divider<short4> dm1 = new Divider<short4>((short4)(-1));
                Divider<short4> dm2 = new Divider<short4>((short4)(-2));
                Divider<short4> overflow = new Divider<short4>((short4)short.MinValue);
                Divider<short4> pow2;
                Divider<short4> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    short4 denum = rng.NextShort4(minR, maxR);
                    Divider<short4> d = new Divider<short4>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        short num = rng.NextShort(minL, maxL);
                        pow2 = new Divider<short4>(maxmath.shl((short)1, rng.NextShort4(0, 16)));
                        pow2m = new Divider<short4>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__short8()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short8> d1 = new Divider<short8>((short8)1);
                Divider<short8> d2 = new Divider<short8>((short8)2);
                Divider<short8> dm1 = new Divider<short8>((short8)(-1));
                Divider<short8> dm2 = new Divider<short8>((short8)(-2));
                Divider<short8> overflow = new Divider<short8>((short8)short.MinValue);
                Divider<short8> pow2;
                Divider<short8> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    short8 denum = rng.NextShort8(minR, maxR);
                    Divider<short8> d = new Divider<short8>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        short8 num = rng.NextShort8(minL, maxL);
                        pow2 = new Divider<short8>(maxmath.shl((short)1, rng.NextShort8(0, 16)));
                        pow2m = new Divider<short8>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__short8_short()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short> d1 = new Divider<short>((short)1);
                Divider<short> d2 = new Divider<short>((short)2);
                Divider<short> dm1 = new Divider<short>((short)(-1));
                Divider<short> dm2 = new Divider<short>((short)(-2));
                Divider<short> overflow = new Divider<short>((short)short.MinValue);
                Divider<short> pow2;
                Divider<short> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    short denum = rng.NextShort(minR, maxR);
                    Divider<short> d = new Divider<short>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        short8 num = rng.NextShort8(minL, maxL);
                        pow2 = new Divider<short>((short)(1 << rng.NextShort(0, 16)));
                        pow2m = new Divider<short>((short)-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__short_short8()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short8> d1 = new Divider<short8>((short8)1);
                Divider<short8> d2 = new Divider<short8>((short8)2);
                Divider<short8> dm1 = new Divider<short8>((short8)(-1));
                Divider<short8> dm2 = new Divider<short8>((short8)(-2));
                Divider<short8> overflow = new Divider<short8>((short8)short.MinValue);
                Divider<short8> pow2;
                Divider<short8> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    short8 denum = rng.NextShort8(minR, maxR);
                    Divider<short8> d = new Divider<short8>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        short num = rng.NextShort(minL, maxL);
                        pow2 = new Divider<short8>(maxmath.shl((short)1, rng.NextShort8(0, 16)));
                        pow2m = new Divider<short8>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__short16()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short16> d1 = new Divider<short16>((short16)1);
                Divider<short16> d2 = new Divider<short16>((short16)2);
                Divider<short16> dm1 = new Divider<short16>((short16)(-1));
                Divider<short16> dm2 = new Divider<short16>((short16)(-2));
                Divider<short16> overflow = new Divider<short16>((short16)short.MinValue);
                Divider<short16> pow2;
                Divider<short16> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    short16 denum = rng.NextShort16(minR, maxR);
                    Divider<short16> d = new Divider<short16>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        short16 num = rng.NextShort16(minL, maxL);
                        pow2 = new Divider<short16>(maxmath.shl((short)1, rng.NextShort16(0, 16)));
                        pow2m = new Divider<short16>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__short16_short()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short> d1 = new Divider<short>((short)1);
                Divider<short> d2 = new Divider<short>((short)2);
                Divider<short> dm1 = new Divider<short>((short)(-1));
                Divider<short> dm2 = new Divider<short>((short)(-2));
                Divider<short> overflow = new Divider<short>((short)short.MinValue);
                Divider<short> pow2;
                Divider<short> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    short denum = rng.NextShort(minR, maxR);
                    Divider<short> d = new Divider<short>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        short16 num = rng.NextShort16(minL, maxL);
                        pow2 = new Divider<short>((short)(1 << rng.NextShort(0, 16)));
                        pow2m = new Divider<short>((short)-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__short_short16()
        {
            TestShort(
            (minL, maxL, minR, maxR) =>
            {
                Random16 rng = Random16.New;
                Divider<short16> d1 = new Divider<short16>((short16)1);
                Divider<short16> d2 = new Divider<short16>((short16)2);
                Divider<short16> dm1 = new Divider<short16>((short16)(-1));
                Divider<short16> dm2 = new Divider<short16>((short16)(-2));
                Divider<short16> overflow = new Divider<short16>((short16)short.MinValue);
                Divider<short16> pow2;
                Divider<short16> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    short16 denum = rng.NextShort16(minR, maxR);
                    Divider<short16> d = new Divider<short16>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        short num = rng.NextShort(minL, maxL);
                        pow2 = new Divider<short16>(maxmath.shl((short)1, rng.NextShort16(0, 16)));
                        pow2m = new Divider<short16>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }



        [Test]
        public static void divisibility__sbyte()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte> d1 = new Divider<sbyte>((sbyte)1);
                Divider<sbyte> d2 = new Divider<sbyte>((sbyte)2);
                Divider<sbyte> dm1 = new Divider<sbyte>((sbyte)-1);
                Divider<sbyte> dm2 = new Divider<sbyte>((sbyte)-2);
                Divider<sbyte> overflow = new Divider<sbyte>(sbyte.MinValue);
                Divider<sbyte> pow2;
                Divider<sbyte> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte denum = rng.NextSByte(minR, maxR);
                    Divider<sbyte> d = new Divider<sbyte>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte num = rng.NextSByte(minL, maxL);
                        pow2 = new Divider<sbyte>((sbyte)(1 << rng.NextByte(0, 8)));
                        pow2m = new Divider<sbyte>((sbyte)-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__sbyte2()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte2> d1 = new Divider<sbyte2>((sbyte2)1);
                Divider<sbyte2> d2 = new Divider<sbyte2>((sbyte2)2);
                Divider<sbyte2> dm1 = new Divider<sbyte2>((sbyte2)(-1));
                Divider<sbyte2> dm2 = new Divider<sbyte2>((sbyte2)(-2));
                Divider<sbyte2> overflow = new Divider<sbyte2>((sbyte2)sbyte.MinValue);
                Divider<sbyte2> pow2;
                Divider<sbyte2> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte2 denum = rng.NextSByte2(minR, maxR);
                    Divider<sbyte2> d = new Divider<sbyte2>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte2 num = rng.NextSByte2(minL, maxL);
                        pow2 = new Divider<sbyte2>(maxmath.shl((sbyte)1, rng.NextSByte2(0, 8)));
                        pow2m = new Divider<sbyte2>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__sbyte2_sbyte()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte> d1 = new Divider<sbyte>((sbyte)1);
                Divider<sbyte> d2 = new Divider<sbyte>((sbyte)2);
                Divider<sbyte> dm1 = new Divider<sbyte>((sbyte)(-1));
                Divider<sbyte> dm2 = new Divider<sbyte>((sbyte)(-2));
                Divider<sbyte> overflow = new Divider<sbyte>((sbyte)sbyte.MinValue);
                Divider<sbyte> pow2;
                Divider<sbyte> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte denum = rng.NextSByte(minR, maxR);
                    Divider<sbyte> d = new Divider<sbyte>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte2 num = rng.NextSByte2(minL, maxL);
                        pow2 = new Divider<sbyte>((sbyte)(1 << rng.NextSByte(0, 8)));
                        pow2m = new Divider<sbyte>((sbyte)-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__sbyte_sbyte2()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte2> d1 = new Divider<sbyte2>((sbyte2)1);
                Divider<sbyte2> d2 = new Divider<sbyte2>((sbyte2)2);
                Divider<sbyte2> dm1 = new Divider<sbyte2>((sbyte2)(-1));
                Divider<sbyte2> dm2 = new Divider<sbyte2>((sbyte2)(-2));
                Divider<sbyte2> overflow = new Divider<sbyte2>((sbyte2)sbyte.MinValue);
                Divider<sbyte2> pow2;
                Divider<sbyte2> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte2 denum = rng.NextSByte2(minR, maxR);
                    Divider<sbyte2> d = new Divider<sbyte2>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte num = rng.NextSByte(minL, maxL);
                        pow2 = new Divider<sbyte2>(maxmath.shl((sbyte)1, rng.NextSByte2(0, 8)));
                        pow2m = new Divider<sbyte2>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility_sbyte3()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte3> d1 = new Divider<sbyte3>((sbyte3)1);
                Divider<sbyte3> d2 = new Divider<sbyte3>((sbyte3)2);
                Divider<sbyte3> dm1 = new Divider<sbyte3>((sbyte3)(-1));
                Divider<sbyte3> dm2 = new Divider<sbyte3>((sbyte3)(-2));
                Divider<sbyte3> overflow = new Divider<sbyte3>((sbyte3)sbyte.MinValue);
                Divider<sbyte3> pow2;
                Divider<sbyte3> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte3 denum = rng.NextSByte3(minR, maxR);
                    Divider<sbyte3> d = new Divider<sbyte3>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte3 num = rng.NextSByte3(minL, maxL);
                        pow2 = new Divider<sbyte3>(maxmath.shl((sbyte)1, rng.NextSByte3(0, 8)));
                        pow2m = new Divider<sbyte3>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility_sbyte3__sbyte()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte> d1 = new Divider<sbyte>((sbyte)1);
                Divider<sbyte> d2 = new Divider<sbyte>((sbyte)2);
                Divider<sbyte> dm1 = new Divider<sbyte>((sbyte)(-1));
                Divider<sbyte> dm2 = new Divider<sbyte>((sbyte)(-2));
                Divider<sbyte> overflow = new Divider<sbyte>((sbyte)sbyte.MinValue);
                Divider<sbyte> pow2;
                Divider<sbyte> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte denum = rng.NextSByte(minR, maxR);
                    Divider<sbyte> d = new Divider<sbyte>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte3 num = rng.NextSByte3(minL, maxL);
                        pow2 = new Divider<sbyte>((sbyte)(1 << rng.NextSByte(0, 8)));
                        pow2m = new Divider<sbyte>((sbyte)-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__sbyte_sbyte3()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte3> d1 = new Divider<sbyte3>((sbyte3)1);
                Divider<sbyte3> d2 = new Divider<sbyte3>((sbyte3)2);
                Divider<sbyte3> dm1 = new Divider<sbyte3>((sbyte3)(-1));
                Divider<sbyte3> dm2 = new Divider<sbyte3>((sbyte3)(-2));
                Divider<sbyte3> overflow = new Divider<sbyte3>((sbyte3)sbyte.MinValue);
                Divider<sbyte3> pow2;
                Divider<sbyte3> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte3 denum = rng.NextSByte3(minR, maxR);
                    Divider<sbyte3> d = new Divider<sbyte3>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte num = rng.NextSByte(minL, maxL);
                        pow2 = new Divider<sbyte3>(maxmath.shl((sbyte)1, rng.NextSByte3(0, 8)));
                        pow2m = new Divider<sbyte3>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__sbyte4()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte4> d1 = new Divider<sbyte4>((sbyte4)1);
                Divider<sbyte4> d2 = new Divider<sbyte4>((sbyte4)2);
                Divider<sbyte4> dm1 = new Divider<sbyte4>((sbyte4)(-1));
                Divider<sbyte4> dm2 = new Divider<sbyte4>((sbyte4)(-2));
                Divider<sbyte4> overflow = new Divider<sbyte4>((sbyte4)sbyte.MinValue);
                Divider<sbyte4> pow2;
                Divider<sbyte4> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte4 denum = rng.NextSByte4(minR, maxR);
                    Divider<sbyte4> d = new Divider<sbyte4>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte4 num = rng.NextSByte4(minL, maxL);
                        pow2 = new Divider<sbyte4>(maxmath.shl((sbyte)1, rng.NextSByte4(0, 8)));
                        pow2m = new Divider<sbyte4>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__sbyte4_sbyte()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte> d1 = new Divider<sbyte>((sbyte)1);
                Divider<sbyte> d2 = new Divider<sbyte>((sbyte)2);
                Divider<sbyte> dm1 = new Divider<sbyte>((sbyte)(-1));
                Divider<sbyte> dm2 = new Divider<sbyte>((sbyte)(-2));
                Divider<sbyte> overflow = new Divider<sbyte>((sbyte)sbyte.MinValue);
                Divider<sbyte> pow2;
                Divider<sbyte> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte denum = rng.NextSByte(minR, maxR);
                    Divider<sbyte> d = new Divider<sbyte>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte4 num = rng.NextSByte4(minL, maxL);
                        pow2 = new Divider<sbyte>((sbyte)(1 << rng.NextSByte(0, 8)));
                        pow2m = new Divider<sbyte>((sbyte)-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__sbyte_sbyte4()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte4> d1 = new Divider<sbyte4>((sbyte4)1);
                Divider<sbyte4> d2 = new Divider<sbyte4>((sbyte4)2);
                Divider<sbyte4> dm1 = new Divider<sbyte4>((sbyte4)(-1));
                Divider<sbyte4> dm2 = new Divider<sbyte4>((sbyte4)(-2));
                Divider<sbyte4> overflow = new Divider<sbyte4>((sbyte4)sbyte.MinValue);
                Divider<sbyte4> pow2;
                Divider<sbyte4> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte4 denum = rng.NextSByte4(minR, maxR);
                    Divider<sbyte4> d = new Divider<sbyte4>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte num = rng.NextSByte(minL, maxL);
                        pow2 = new Divider<sbyte4>(maxmath.shl((sbyte)1, rng.NextSByte4(0, 8)));
                        pow2m = new Divider<sbyte4>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__sbyte8()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte8> d1 = new Divider<sbyte8>((sbyte8)1);
                Divider<sbyte8> d2 = new Divider<sbyte8>((sbyte8)2);
                Divider<sbyte8> dm1 = new Divider<sbyte8>((sbyte8)(-1));
                Divider<sbyte8> dm2 = new Divider<sbyte8>((sbyte8)(-2));
                Divider<sbyte8> overflow = new Divider<sbyte8>((sbyte8)sbyte.MinValue);
                Divider<sbyte8> pow2;
                Divider<sbyte8> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte8 denum = rng.NextSByte8(minR, maxR);
                    Divider<sbyte8> d = new Divider<sbyte8>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte8 num = rng.NextSByte8(minL, maxL);
                        pow2 = new Divider<sbyte8>(maxmath.shl((sbyte)1, rng.NextSByte8(0, 8)));
                        pow2m = new Divider<sbyte8>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__sbyte8_sbyte()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte> d1 = new Divider<sbyte>((sbyte)1);
                Divider<sbyte> d2 = new Divider<sbyte>((sbyte)2);
                Divider<sbyte> dm1 = new Divider<sbyte>((sbyte)(-1));
                Divider<sbyte> dm2 = new Divider<sbyte>((sbyte)(-2));
                Divider<sbyte> overflow = new Divider<sbyte>((sbyte)sbyte.MinValue);
                Divider<sbyte> pow2;
                Divider<sbyte> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte denum = rng.NextSByte(minR, maxR);
                    Divider<sbyte> d = new Divider<sbyte>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte8 num = rng.NextSByte8(minL, maxL);
                        pow2 = new Divider<sbyte>((sbyte)(1 << rng.NextSByte(0, 8)));
                        pow2m = new Divider<sbyte>((sbyte)-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__sbyte_sbyte8()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte8> d1 = new Divider<sbyte8>((sbyte8)1);
                Divider<sbyte8> d2 = new Divider<sbyte8>((sbyte8)2);
                Divider<sbyte8> dm1 = new Divider<sbyte8>((sbyte8)(-1));
                Divider<sbyte8> dm2 = new Divider<sbyte8>((sbyte8)(-2));
                Divider<sbyte8> overflow = new Divider<sbyte8>((sbyte8)sbyte.MinValue);
                Divider<sbyte8> pow2;
                Divider<sbyte8> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte8 denum = rng.NextSByte8(minR, maxR);
                    Divider<sbyte8> d = new Divider<sbyte8>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte num = rng.NextSByte(minL, maxL);
                        pow2 = new Divider<sbyte8>(maxmath.shl((sbyte)1, rng.NextSByte8(0, 8)));
                        pow2m = new Divider<sbyte8>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__sbyte16()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte16> d1 = new Divider<sbyte16>((sbyte16)1);
                Divider<sbyte16> d2 = new Divider<sbyte16>((sbyte16)2);
                Divider<sbyte16> dm1 = new Divider<sbyte16>((sbyte16)(-1));
                Divider<sbyte16> dm2 = new Divider<sbyte16>((sbyte16)(-2));
                Divider<sbyte16> overflow = new Divider<sbyte16>((sbyte16)sbyte.MinValue);
                Divider<sbyte16> pow2;
                Divider<sbyte16> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte16 denum = rng.NextSByte16(minR, maxR);
                    Divider<sbyte16> d = new Divider<sbyte16>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte16 num = rng.NextSByte16(minL, maxL);
                        pow2 = new Divider<sbyte16>(maxmath.shl((sbyte)1, rng.NextSByte16(0, 8)));
                        pow2m = new Divider<sbyte16>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__sbyte16_sbyte()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte> d1 = new Divider<sbyte>((sbyte)1);
                Divider<sbyte> d2 = new Divider<sbyte>((sbyte)2);
                Divider<sbyte> dm1 = new Divider<sbyte>((sbyte)(-1));
                Divider<sbyte> dm2 = new Divider<sbyte>((sbyte)(-2));
                Divider<sbyte> overflow = new Divider<sbyte>((sbyte)sbyte.MinValue);
                Divider<sbyte> pow2;
                Divider<sbyte> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte denum = rng.NextSByte(minR, maxR);
                    Divider<sbyte> d = new Divider<sbyte>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte16 num = rng.NextSByte16(minL, maxL);
                        pow2 = new Divider<sbyte>((sbyte)(1 << rng.NextSByte(0, 8)));
                        pow2m = new Divider<sbyte>((sbyte)-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__sbyte_sbyte16()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte16> d1 = new Divider<sbyte16>((sbyte16)1);
                Divider<sbyte16> d2 = new Divider<sbyte16>((sbyte16)2);
                Divider<sbyte16> dm1 = new Divider<sbyte16>((sbyte16)(-1));
                Divider<sbyte16> dm2 = new Divider<sbyte16>((sbyte16)(-2));
                Divider<sbyte16> overflow = new Divider<sbyte16>((sbyte16)sbyte.MinValue);
                Divider<sbyte16> pow2;
                Divider<sbyte16> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte16 denum = rng.NextSByte16(minR, maxR);
                    Divider<sbyte16> d = new Divider<sbyte16>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte num = rng.NextSByte(minL, maxL);
                        pow2 = new Divider<sbyte16>(maxmath.shl((sbyte)1, rng.NextSByte16(0, 8)));
                        pow2m = new Divider<sbyte16>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility_sbyte32()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte32> d1 = new Divider<sbyte32>((sbyte32)1);
                Divider<sbyte32> d2 = new Divider<sbyte32>((sbyte32)2);
                Divider<sbyte32> dm1 = new Divider<sbyte32>((sbyte32)(-1));
                Divider<sbyte32> dm2 = new Divider<sbyte32>((sbyte32)(-2));
                Divider<sbyte32> overflow = new Divider<sbyte32>((sbyte32)sbyte.MinValue);
                Divider<sbyte32> pow2;
                Divider<sbyte32> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte32 denum = rng.NextSByte32(minR, maxR);
                    Divider<sbyte32> d = new Divider<sbyte32>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte32 num = rng.NextSByte32(minL, maxL);
                        pow2 = new Divider<sbyte32>(maxmath.shl((sbyte)1, rng.NextSByte32(0, 8)));
                        pow2m = new Divider<sbyte32>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility_sbyte32_sbyte()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte> d1 = new Divider<sbyte>((sbyte)1);
                Divider<sbyte> d2 = new Divider<sbyte>((sbyte)2);
                Divider<sbyte> dm1 = new Divider<sbyte>((sbyte)(-1));
                Divider<sbyte> dm2 = new Divider<sbyte>((sbyte)(-2));
                Divider<sbyte> overflow = new Divider<sbyte>((sbyte)sbyte.MinValue);
                Divider<sbyte> pow2;
                Divider<sbyte> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte denum = rng.NextSByte(minR, maxR);
                    Divider<sbyte> d = new Divider<sbyte>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte32 num = rng.NextSByte32(minL, maxL);
                        pow2 = new Divider<sbyte>((sbyte)(1 << rng.NextSByte(0, 8)));
                        pow2m = new Divider<sbyte>((sbyte)-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }

        [Test]
        public static void divisibility__sbyte_sbyte32()
        {
            TestSByte(
            (minL, maxL, minR, maxR) =>
            {
                Random8 rng = Random8.New;
                Divider<sbyte32> d1 = new Divider<sbyte32>((sbyte32)1);
                Divider<sbyte32> d2 = new Divider<sbyte32>((sbyte32)2);
                Divider<sbyte32> dm1 = new Divider<sbyte32>((sbyte32)(-1));
                Divider<sbyte32> dm2 = new Divider<sbyte32>((sbyte32)(-2));
                Divider<sbyte32> overflow = new Divider<sbyte32>((sbyte32)sbyte.MinValue);
                Divider<sbyte32> pow2;
                Divider<sbyte32> pow2m;

                for (int i = 0; i < 8; i++)
                {
                    sbyte32 denum = rng.NextSByte32(minR, maxR);
                    Divider<sbyte32> d = new Divider<sbyte32>(denum);

                    for (int j = 0; j < 8; j++)
                    {
                        sbyte num = rng.NextSByte(minL, maxL);
                        pow2 = new Divider<sbyte32>(maxmath.shl((sbyte)1, rng.NextSByte32(0, 8)));
                        pow2m = new Divider<sbyte32>(-pow2.Divisor);

                        Assert.AreEqual(num % d == 0, d.EvenlyDivides(num));
                        Assert.AreEqual(num % d1 == 0, d1.EvenlyDivides(num));
                        Assert.AreEqual(num % d2 == 0, d2.EvenlyDivides(num));
                        Assert.AreEqual(num % dm1 == 0, dm1.EvenlyDivides(num));
                        Assert.AreEqual(num % dm2 == 0, dm2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2 == 0, pow2.EvenlyDivides(num));
                        Assert.AreEqual(num % pow2m == 0, pow2m.EvenlyDivides(num));
                        Assert.AreEqual(num % overflow == 0, overflow.EvenlyDivides(num));
                    }
                }
            });
        }
    }
}
