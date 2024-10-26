using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static partial class t_Divider
	{
		[Test]
		public static void SetInnerDivider_byte2_byte()
		{
			byte inner = byte.MaxValue - 1;

			for (int i = 0; i < 2; i++)
			{
				byte2 outer = new byte2(1, 2);
				byte2 cmp = outer;

				*((byte*)&cmp + i) = inner;

				Divider<byte2> outerDivider = new Divider<byte2>(outer);
				outerDivider.SetInnerDivider(new Divider<byte>(inner), i);
				Assert.AreEqual(new Divider<byte2>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte3_byte()
		{
			byte inner = byte.MaxValue - 1;

			for (int i = 0; i < 3; i++)
			{
				byte3 outer = new byte3(1, 2, 3);
				byte3 cmp = outer;

				*((byte*)&cmp + i) = inner;

				Divider<byte3> outerDivider = new Divider<byte3>(outer);
				outerDivider.SetInnerDivider(new Divider<byte>(inner), i);
				Assert.AreEqual(new Divider<byte3>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte3_byte2()
		{
			byte2 inner = new byte2(byte.MaxValue - 1, byte.MaxValue - 2);

			for (int i = 0; i < 2; i++)
			{
				byte3 outer = new byte3(1, 2, 3);
				byte3 cmp = outer;

				*(byte2*)((byte*)&cmp + i) = inner;

				Divider<byte3> outerDivider = new Divider<byte3>(outer);
				outerDivider.SetInnerDivider(new Divider<byte2>(inner), i);
				Assert.AreEqual(new Divider<byte3>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte4_byte()
		{
			byte inner = byte.MaxValue - 1;

			for (int i = 0; i < 4; i++)
			{
				byte4 outer = new byte4(1, 2, 3, 4);
				byte4 cmp = outer;

				*((byte*)&cmp + i) = inner;

				Divider<byte4> outerDivider = new Divider<byte4>(outer);
				outerDivider.SetInnerDivider(new Divider<byte>(inner), i);
				Assert.AreEqual(new Divider<byte4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte4_byte2()
		{
			byte2 inner = new byte2(byte.MaxValue - 1, byte.MaxValue - 2);

			for (int i = 0; i < 3; i++)
			{
				byte4 outer = new byte4(1, 2, 3, 4);
				byte4 cmp = outer;

				*(byte2*)((byte*)&cmp + i) = inner;

				Divider<byte4> outerDivider = new Divider<byte4>(outer);
				outerDivider.SetInnerDivider(new Divider<byte2>(inner), i);
				Assert.AreEqual(new Divider<byte4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte4_byte3()
		{
			byte3 inner = new byte3(byte.MaxValue - 1, byte.MaxValue - 2, byte.MaxValue - 3);

			for (int i = 0; i < 2; i++)
			{
				byte4 outer = new byte4(1, 2, 3, 4);
				byte4 cmp = outer;

				*(byte3*)((byte*)&cmp + i) = inner;

				Divider<byte4> outerDivider = new Divider<byte4>(outer);
				outerDivider.SetInnerDivider(new Divider<byte3>(inner), i);
				Assert.AreEqual(new Divider<byte4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte8_byte()
		{
			byte inner = byte.MaxValue - 1;

			for (int i = 0; i < 8; i++)
			{
				byte8 outer = new byte8(1, 2, 3, 4, 5, 6, 7, 8);
				byte8 cmp = outer;

				*((byte*)&cmp + i) = inner;

				Divider<byte8> outerDivider = new Divider<byte8>(outer);
				outerDivider.SetInnerDivider(new Divider<byte>(inner), i);
				Assert.AreEqual(new Divider<byte8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte8_byte2()
		{
			byte2 inner = new byte2(byte.MaxValue - 1, byte.MaxValue - 2);

			for (int i = 0; i < 7; i++)
			{
				byte8 outer = new byte8(1, 2, 3, 4, 5, 6, 7, 8);
				byte8 cmp = outer;

				*(byte2*)((byte*)&cmp + i) = inner;

				Divider<byte8> outerDivider = new Divider<byte8>(outer);
				outerDivider.SetInnerDivider(new Divider<byte2>(inner), i);
				Assert.AreEqual(new Divider<byte8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte8_byte3()
		{
			byte3 inner = new byte3(byte.MaxValue - 1, byte.MaxValue - 2, byte.MaxValue - 3);

			for (int i = 0; i < 6; i++)
			{
				byte8 outer = new byte8(1, 2, 3, 4, 5, 6, 7, 8);
				byte8 cmp = outer;

				*(byte3*)((byte*)&cmp + i) = inner;

				Divider<byte8> outerDivider = new Divider<byte8>(outer);
				outerDivider.SetInnerDivider(new Divider<byte3>(inner), i);
				Assert.AreEqual(new Divider<byte8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte8_byte4()
		{
			byte4 inner = new byte4(byte.MaxValue - 1, byte.MaxValue - 2, byte.MaxValue - 3, byte.MaxValue - 4);

			for (int i = 0; i < 5; i++)
			{
				byte8 outer = new byte8(1, 2, 3, 4, 5, 6, 7, 8);
				byte8 cmp = outer;

				*(byte4*)((byte*)&cmp + i) = inner;

				Divider<byte8> outerDivider = new Divider<byte8>(outer);
				outerDivider.SetInnerDivider(new Divider<byte4>(inner), i);
				Assert.AreEqual(new Divider<byte8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte16_byte()
		{
			byte inner = byte.MaxValue - 1;

			for (int i = 0; i < 16; i++)
			{
				byte16 outer = new byte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				byte16 cmp = outer;

				*((byte*)&cmp + i) = inner;

				Divider<byte16> outerDivider = new Divider<byte16>(outer);
				outerDivider.SetInnerDivider(new Divider<byte>(inner), i);
				Assert.AreEqual(new Divider<byte16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte16_byte2()
		{
			byte2 inner = new byte2(byte.MaxValue - 1, byte.MaxValue - 2);

			for (int i = 0; i < 15; i++)
			{
				byte16 outer = new byte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				byte16 cmp = outer;

				*(byte2*)((byte*)&cmp + i) = inner;

				Divider<byte16> outerDivider = new Divider<byte16>(outer);
				outerDivider.SetInnerDivider(new Divider<byte2>(inner), i);
				Assert.AreEqual(new Divider<byte16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte16_byte3()
		{
			byte3 inner = new byte3(byte.MaxValue - 1, byte.MaxValue - 2, byte.MaxValue - 3);

			for (int i = 0; i < 14; i++)
			{
				byte16 outer = new byte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				byte16 cmp = outer;

				*(byte3*)((byte*)&cmp + i) = inner;

				Divider<byte16> outerDivider = new Divider<byte16>(outer);
				outerDivider.SetInnerDivider(new Divider<byte3>(inner), i);
				Assert.AreEqual(new Divider<byte16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte16_byte4()
		{
			byte4 inner = new byte4(byte.MaxValue - 1, byte.MaxValue - 2, byte.MaxValue - 3, byte.MaxValue - 4);

			for (int i = 0; i < 13; i++)
			{
				byte16 outer = new byte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				byte16 cmp = outer;

				*(byte4*)((byte*)&cmp + i) = inner;

				Divider<byte16> outerDivider = new Divider<byte16>(outer);
				outerDivider.SetInnerDivider(new Divider<byte4>(inner), i);
				Assert.AreEqual(new Divider<byte16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte16_byte8()
		{
			byte8 inner = new byte8(byte.MaxValue - 1, byte.MaxValue - 2, byte.MaxValue - 3, byte.MaxValue - 4, byte.MaxValue - 5, byte.MaxValue - 6, byte.MaxValue - 7, byte.MaxValue - 8);

			for (int i = 0; i < 8; i++)
			{
				byte16 outer = new byte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				byte16 cmp = outer;

				*(byte8*)((byte*)&cmp + i) = inner;

				Divider<byte16> outerDivider = new Divider<byte16>(outer);
				outerDivider.SetInnerDivider(new Divider<byte8>(inner), i);
				Assert.AreEqual(new Divider<byte16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte32_byte()
		{
			byte inner = byte.MaxValue - 1;

			for (int i = 0; i < 32; i++)
			{
				byte32 outer = new byte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				byte32 cmp = outer;

				*((byte*)&cmp + i) = inner;

				Divider<byte32> outerDivider = new Divider<byte32>(outer);
				outerDivider.SetInnerDivider(new Divider<byte>(inner), i);
				Assert.AreEqual(new Divider<byte32>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte32_byte2()
		{
			byte2 inner = new byte2(byte.MaxValue - 1, byte.MaxValue - 2);

			for (int i = 0; i < 31; i++)
			{
				byte32 outer = new byte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				byte32 cmp = outer;

				*(byte2*)((byte*)&cmp + i) = inner;

				Divider<byte32> outerDivider = new Divider<byte32>(outer);
				outerDivider.SetInnerDivider(new Divider<byte2>(inner), i);
				Assert.AreEqual(new Divider<byte32>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte32_byte3()
		{
			byte3 inner = new byte3(byte.MaxValue - 1, byte.MaxValue - 2, byte.MaxValue - 3);

			for (int i = 0; i < 30; i++)
			{
				byte32 outer = new byte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				byte32 cmp = outer;

				*(byte3*)((byte*)&cmp + i) = inner;

				Divider<byte32> outerDivider = new Divider<byte32>(outer);
				outerDivider.SetInnerDivider(new Divider<byte3>(inner), i);
				Assert.AreEqual(new Divider<byte32>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte32_byte4()
		{
			byte4 inner = new byte4(byte.MaxValue - 1, byte.MaxValue - 2, byte.MaxValue - 3, byte.MaxValue - 4);

			for (int i = 0; i < 29; i++)
			{
				byte32 outer = new byte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				byte32 cmp = outer;

				*(byte4*)((byte*)&cmp + i) = inner;

				Divider<byte32> outerDivider = new Divider<byte32>(outer);
				outerDivider.SetInnerDivider(new Divider<byte4>(inner), i);
				Assert.AreEqual(new Divider<byte32>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte32_byte8()
		{
			byte8 inner = new byte8(byte.MaxValue - 1, byte.MaxValue - 2, byte.MaxValue - 3, byte.MaxValue - 4, byte.MaxValue - 5, byte.MaxValue - 6, byte.MaxValue - 7, byte.MaxValue - 8);

			for (int i = 0; i < 25; i++)
			{
				byte32 outer = new byte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				byte32 cmp = outer;

				*(byte8*)((byte*)&cmp + i) = inner;

				Divider<byte32> outerDivider = new Divider<byte32>(outer);
				outerDivider.SetInnerDivider(new Divider<byte8>(inner), i);
				Assert.AreEqual(new Divider<byte32>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_byte32_byte16()
		{
			byte16 inner = new byte16(byte.MaxValue - 1, byte.MaxValue - 2, byte.MaxValue - 3, byte.MaxValue - 4, byte.MaxValue - 5, byte.MaxValue - 6, byte.MaxValue - 7, byte.MaxValue - 8, byte.MaxValue - 9, byte.MaxValue - 10, byte.MaxValue - 11, byte.MaxValue - 12, byte.MaxValue - 13, byte.MaxValue - 14, byte.MaxValue - 15, byte.MaxValue - 16);

			for (int i = 0; i < 17; i++)
			{
				byte32 outer = new byte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				byte32 cmp = outer;

				*(byte16*)((byte*)&cmp + i) = inner;

				Divider<byte32> outerDivider = new Divider<byte32>(outer);
				outerDivider.SetInnerDivider(new Divider<byte16>(inner), i);
				Assert.AreEqual(new Divider<byte32>(cmp), outerDivider);
			}
		}


		[Test]
		public static void SetInnerDivider_sbyte2_sbyte()
		{
			sbyte inner = sbyte.MaxValue - 1;

			for (int i = 0; i < 2; i++)
			{
				sbyte2 outer = new sbyte2(1, 2);
				sbyte2 cmp = outer;

				*((sbyte*)&cmp + i) = inner;

				Divider<sbyte2> outerDivider = new Divider<sbyte2>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte>(inner), i);
				Assert.AreEqual(new Divider<sbyte2>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte3_sbyte()
		{
			sbyte inner = sbyte.MaxValue - 1;

			for (int i = 0; i < 3; i++)
			{
				sbyte3 outer = new sbyte3(1, 2, 3);
				sbyte3 cmp = outer;

				*((sbyte*)&cmp + i) = inner;

				Divider<sbyte3> outerDivider = new Divider<sbyte3>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte>(inner), i);
				Assert.AreEqual(new Divider<sbyte3>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte3_sbyte2()
		{
			sbyte2 inner = new sbyte2(sbyte.MaxValue - 1, sbyte.MaxValue - 2);

			for (int i = 0; i < 2; i++)
			{
				sbyte3 outer = new sbyte3(1, 2, 3);
				sbyte3 cmp = outer;

				*(sbyte2*)((sbyte*)&cmp + i) = inner;

				Divider<sbyte3> outerDivider = new Divider<sbyte3>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte2>(inner), i);
				Assert.AreEqual(new Divider<sbyte3>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte4_sbyte()
		{
			sbyte inner = sbyte.MaxValue - 1;

			for (int i = 0; i < 4; i++)
			{
				sbyte4 outer = new sbyte4(1, 2, 3, 4);
				sbyte4 cmp = outer;

				*((sbyte*)&cmp + i) = inner;

				Divider<sbyte4> outerDivider = new Divider<sbyte4>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte>(inner), i);
				Assert.AreEqual(new Divider<sbyte4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte4_sbyte2()
		{
			sbyte2 inner = new sbyte2(sbyte.MaxValue - 1, sbyte.MaxValue - 2);

			for (int i = 0; i < 3; i++)
			{
				sbyte4 outer = new sbyte4(1, 2, 3, 4);
				sbyte4 cmp = outer;

				*(sbyte2*)((sbyte*)&cmp + i) = inner;

				Divider<sbyte4> outerDivider = new Divider<sbyte4>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte2>(inner), i);
				Assert.AreEqual(new Divider<sbyte4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte4_sbyte3()
		{
			sbyte3 inner = new sbyte3(sbyte.MaxValue - 1, sbyte.MaxValue - 2, sbyte.MaxValue - 3);

			for (int i = 0; i < 2; i++)
			{
				sbyte4 outer = new sbyte4(1, 2, 3, 4);
				sbyte4 cmp = outer;

				*(sbyte3*)((sbyte*)&cmp + i) = inner;

				Divider<sbyte4> outerDivider = new Divider<sbyte4>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte3>(inner), i);
				Assert.AreEqual(new Divider<sbyte4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte8_sbyte()
		{
			sbyte inner = sbyte.MaxValue - 1;

			for (int i = 0; i < 8; i++)
			{
				sbyte8 outer = new sbyte8(1, 2, 3, 4, 5, 6, 7, 8);
				sbyte8 cmp = outer;

				*((sbyte*)&cmp + i) = inner;

				Divider<sbyte8> outerDivider = new Divider<sbyte8>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte>(inner), i);
				Assert.AreEqual(new Divider<sbyte8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte8_sbyte2()
		{
			sbyte2 inner = new sbyte2(sbyte.MaxValue - 1, sbyte.MaxValue - 2);

			for (int i = 0; i < 7; i++)
			{
				sbyte8 outer = new sbyte8(1, 2, 3, 4, 5, 6, 7, 8);
				sbyte8 cmp = outer;

				*(sbyte2*)((sbyte*)&cmp + i) = inner;

				Divider<sbyte8> outerDivider = new Divider<sbyte8>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte2>(inner), i);
				Assert.AreEqual(new Divider<sbyte8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte8_sbyte3()
		{
			sbyte3 inner = new sbyte3(sbyte.MaxValue - 1, sbyte.MaxValue - 2, sbyte.MaxValue - 3);

			for (int i = 0; i < 6; i++)
			{
				sbyte8 outer = new sbyte8(1, 2, 3, 4, 5, 6, 7, 8);
				sbyte8 cmp = outer;

				*(sbyte3*)((sbyte*)&cmp + i) = inner;

				Divider<sbyte8> outerDivider = new Divider<sbyte8>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte3>(inner), i);
				Assert.AreEqual(new Divider<sbyte8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte8_sbyte4()
		{
			sbyte4 inner = new sbyte4(sbyte.MaxValue - 1, sbyte.MaxValue - 2, sbyte.MaxValue - 3, sbyte.MaxValue - 4);

			for (int i = 0; i < 5; i++)
			{
				sbyte8 outer = new sbyte8(1, 2, 3, 4, 5, 6, 7, 8);
				sbyte8 cmp = outer;

				*(sbyte4*)((sbyte*)&cmp + i) = inner;

				Divider<sbyte8> outerDivider = new Divider<sbyte8>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte4>(inner), i);
				Assert.AreEqual(new Divider<sbyte8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte16_sbyte()
		{
			sbyte inner = sbyte.MaxValue - 1;

			for (int i = 0; i < 16; i++)
			{
				sbyte16 outer = new sbyte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				sbyte16 cmp = outer;

				*((sbyte*)&cmp + i) = inner;

				Divider<sbyte16> outerDivider = new Divider<sbyte16>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte>(inner), i);
				Assert.AreEqual(new Divider<sbyte16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte16_sbyte2()
		{
			sbyte2 inner = new sbyte2(sbyte.MaxValue - 1, sbyte.MaxValue - 2);

			for (int i = 0; i < 15; i++)
			{
				sbyte16 outer = new sbyte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				sbyte16 cmp = outer;

				*(sbyte2*)((sbyte*)&cmp + i) = inner;

				Divider<sbyte16> outerDivider = new Divider<sbyte16>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte2>(inner), i);
				Assert.AreEqual(new Divider<sbyte16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte16_sbyte3()
		{
			sbyte3 inner = new sbyte3(sbyte.MaxValue - 1, sbyte.MaxValue - 2, sbyte.MaxValue - 3);

			for (int i = 0; i < 14; i++)
			{
				sbyte16 outer = new sbyte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				sbyte16 cmp = outer;

				*(sbyte3*)((sbyte*)&cmp + i) = inner;

				Divider<sbyte16> outerDivider = new Divider<sbyte16>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte3>(inner), i);
				Assert.AreEqual(new Divider<sbyte16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte16_sbyte4()
		{
			sbyte4 inner = new sbyte4(sbyte.MaxValue - 1, sbyte.MaxValue - 2, sbyte.MaxValue - 3, sbyte.MaxValue - 4);

			for (int i = 0; i < 13; i++)
			{
				sbyte16 outer = new sbyte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				sbyte16 cmp = outer;

				*(sbyte4*)((sbyte*)&cmp + i) = inner;

				Divider<sbyte16> outerDivider = new Divider<sbyte16>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte4>(inner), i);
				Assert.AreEqual(new Divider<sbyte16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte16_sbyte8()
		{
			sbyte8 inner = new sbyte8(sbyte.MaxValue - 1, sbyte.MaxValue - 2, sbyte.MaxValue - 3, sbyte.MaxValue - 4, sbyte.MaxValue - 5, sbyte.MaxValue - 6, sbyte.MaxValue - 7, sbyte.MaxValue - 8);

			for (int i = 0; i < 8; i++)
			{
				sbyte16 outer = new sbyte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				sbyte16 cmp = outer;

				*(sbyte8*)((sbyte*)&cmp + i) = inner;

				Divider<sbyte16> outerDivider = new Divider<sbyte16>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte8>(inner), i);
				Assert.AreEqual(new Divider<sbyte16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte32_sbyte()
		{
			sbyte inner = sbyte.MaxValue - 1;

			for (int i = 0; i < 32; i++)
			{
				sbyte32 outer = new sbyte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				sbyte32 cmp = outer;

				*((sbyte*)&cmp + i) = inner;

				Divider<sbyte32> outerDivider = new Divider<sbyte32>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte>(inner), i);
				Assert.AreEqual(new Divider<sbyte32>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte32_sbyte2()
		{
			sbyte2 inner = new sbyte2(sbyte.MaxValue - 1, sbyte.MaxValue - 2);

			for (int i = 0; i < 31; i++)
			{
				sbyte32 outer = new sbyte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				sbyte32 cmp = outer;

				*(sbyte2*)((sbyte*)&cmp + i) = inner;

				Divider<sbyte32> outerDivider = new Divider<sbyte32>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte2>(inner), i);
				Assert.AreEqual(new Divider<sbyte32>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte32_sbyte3()
		{
			sbyte3 inner = new sbyte3(sbyte.MaxValue - 1, sbyte.MaxValue - 2, sbyte.MaxValue - 3);

			for (int i = 0; i < 30; i++)
			{
				sbyte32 outer = new sbyte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				sbyte32 cmp = outer;

				*(sbyte3*)((sbyte*)&cmp + i) = inner;

				Divider<sbyte32> outerDivider = new Divider<sbyte32>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte3>(inner), i);
				Assert.AreEqual(new Divider<sbyte32>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte32_sbyte4()
		{
			sbyte4 inner = new sbyte4(sbyte.MaxValue - 1, sbyte.MaxValue - 2, sbyte.MaxValue - 3, sbyte.MaxValue - 4);

			for (int i = 0; i < 29; i++)
			{
				sbyte32 outer = new sbyte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				sbyte32 cmp = outer;

				*(sbyte4*)((sbyte*)&cmp + i) = inner;

				Divider<sbyte32> outerDivider = new Divider<sbyte32>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte4>(inner), i);
				Assert.AreEqual(new Divider<sbyte32>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte32_sbyte8()
		{
			sbyte8 inner = new sbyte8(sbyte.MaxValue - 1, sbyte.MaxValue - 2, sbyte.MaxValue - 3, sbyte.MaxValue - 4, sbyte.MaxValue - 5, sbyte.MaxValue - 6, sbyte.MaxValue - 7, sbyte.MaxValue - 8);

			for (int i = 0; i < 25; i++)
			{
				sbyte32 outer = new sbyte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				sbyte32 cmp = outer;

				*(sbyte8*)((sbyte*)&cmp + i) = inner;

				Divider<sbyte32> outerDivider = new Divider<sbyte32>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte8>(inner), i);
				Assert.AreEqual(new Divider<sbyte32>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_sbyte32_sbyte16()
		{
			sbyte16 inner = new sbyte16(sbyte.MaxValue - 1, sbyte.MaxValue - 2, sbyte.MaxValue - 3, sbyte.MaxValue - 4, sbyte.MaxValue - 5, sbyte.MaxValue - 6, sbyte.MaxValue - 7, sbyte.MaxValue - 8, sbyte.MaxValue - 9, sbyte.MaxValue - 10, sbyte.MaxValue - 11, sbyte.MaxValue - 12, sbyte.MaxValue - 13, sbyte.MaxValue - 14, sbyte.MaxValue - 15, sbyte.MaxValue - 16);

			for (int i = 0; i < 17; i++)
			{
				sbyte32 outer = new sbyte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				sbyte32 cmp = outer;

				*(sbyte16*)((sbyte*)&cmp + i) = inner;

				Divider<sbyte32> outerDivider = new Divider<sbyte32>(outer);
				outerDivider.SetInnerDivider(new Divider<sbyte16>(inner), i);
				Assert.AreEqual(new Divider<sbyte32>(cmp), outerDivider);
			}
		}


		[Test]
		public static void SetInnerDivider_ushort2_ushort()
		{
			ushort inner = ushort.MaxValue - 1;

			for (int i = 0; i < 2; i++)
			{
				ushort2 outer = new ushort2(1, 2);
				ushort2 cmp = outer;

				*((ushort*)&cmp + i) = inner;

				Divider<ushort2> outerDivider = new Divider<ushort2>(outer);
				outerDivider.SetInnerDivider(new Divider<ushort>(inner), i);
				Assert.AreEqual(new Divider<ushort2>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ushort3_ushort()
		{
			ushort inner = ushort.MaxValue - 1;

			for (int i = 0; i < 3; i++)
			{
				ushort3 outer = new ushort3(1, 2, 3);
				ushort3 cmp = outer;

				*((ushort*)&cmp + i) = inner;

				Divider<ushort3> outerDivider = new Divider<ushort3>(outer);
				outerDivider.SetInnerDivider(new Divider<ushort>(inner), i);
				Assert.AreEqual(new Divider<ushort3>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ushort3_ushort2()
		{
			ushort2 inner = new ushort2(ushort.MaxValue - 1, ushort.MaxValue - 2);

			for (int i = 0; i < 2; i++)
			{
				ushort3 outer = new ushort3(1, 2, 3);
				ushort3 cmp = outer;

				*(ushort2*)((ushort*)&cmp + i) = inner;

				Divider<ushort3> outerDivider = new Divider<ushort3>(outer);
				outerDivider.SetInnerDivider(new Divider<ushort2>(inner), i);
				Assert.AreEqual(new Divider<ushort3>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ushort4_ushort()
		{
			ushort inner = ushort.MaxValue - 1;

			for (int i = 0; i < 4; i++)
			{
				ushort4 outer = new ushort4(1, 2, 3, 4);
				ushort4 cmp = outer;

				*((ushort*)&cmp + i) = inner;

				Divider<ushort4> outerDivider = new Divider<ushort4>(outer);
				outerDivider.SetInnerDivider(new Divider<ushort>(inner), i);
				Assert.AreEqual(new Divider<ushort4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ushort4_ushort2()
		{
			ushort2 inner = new ushort2(ushort.MaxValue - 1, ushort.MaxValue - 2);

			for (int i = 0; i < 3; i++)
			{
				ushort4 outer = new ushort4(1, 2, 3, 4);
				ushort4 cmp = outer;

				*(ushort2*)((ushort*)&cmp + i) = inner;

				Divider<ushort4> outerDivider = new Divider<ushort4>(outer);
				outerDivider.SetInnerDivider(new Divider<ushort2>(inner), i);
				Assert.AreEqual(new Divider<ushort4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ushort4_ushort3()
		{
			ushort3 inner = new ushort3(ushort.MaxValue - 1, ushort.MaxValue - 2, ushort.MaxValue - 3);

			for (int i = 0; i < 2; i++)
			{
				ushort4 outer = new ushort4(1, 2, 3, 4);
				ushort4 cmp = outer;

				*(ushort3*)((ushort*)&cmp + i) = inner;

				Divider<ushort4> outerDivider = new Divider<ushort4>(outer);
				outerDivider.SetInnerDivider(new Divider<ushort3>(inner), i);
				Assert.AreEqual(new Divider<ushort4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ushort8_ushort()
		{
			ushort inner = ushort.MaxValue - 1;

			for (int i = 0; i < 8; i++)
			{
				ushort8 outer = new ushort8(1, 2, 3, 4, 5, 6, 7, 8);
				ushort8 cmp = outer;

				*((ushort*)&cmp + i) = inner;

				Divider<ushort8> outerDivider = new Divider<ushort8>(outer);
				outerDivider.SetInnerDivider(new Divider<ushort>(inner), i);
				Assert.AreEqual(new Divider<ushort8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ushort8_ushort2()
		{
			ushort2 inner = new ushort2(ushort.MaxValue - 1, ushort.MaxValue - 2);

			for (int i = 0; i < 7; i++)
			{
				ushort8 outer = new ushort8(1, 2, 3, 4, 5, 6, 7, 8);
				ushort8 cmp = outer;

				*(ushort2*)((ushort*)&cmp + i) = inner;

				Divider<ushort8> outerDivider = new Divider<ushort8>(outer);
				outerDivider.SetInnerDivider(new Divider<ushort2>(inner), i);
				Assert.AreEqual(new Divider<ushort8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ushort8_ushort3()
		{
			ushort3 inner = new ushort3(ushort.MaxValue - 1, ushort.MaxValue - 2, ushort.MaxValue - 3);

			for (int i = 0; i < 6; i++)
			{
				ushort8 outer = new ushort8(1, 2, 3, 4, 5, 6, 7, 8);
				ushort8 cmp = outer;

				*(ushort3*)((ushort*)&cmp + i) = inner;

				Divider<ushort8> outerDivider = new Divider<ushort8>(outer);
				outerDivider.SetInnerDivider(new Divider<ushort3>(inner), i);
				Assert.AreEqual(new Divider<ushort8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ushort8_ushort4()
		{
			ushort4 inner = new ushort4(ushort.MaxValue - 1, ushort.MaxValue - 2, ushort.MaxValue - 3, ushort.MaxValue - 4);

			for (int i = 0; i < 5; i++)
			{
				ushort8 outer = new ushort8(1, 2, 3, 4, 5, 6, 7, 8);
				ushort8 cmp = outer;

				*(ushort4*)((ushort*)&cmp + i) = inner;

				Divider<ushort8> outerDivider = new Divider<ushort8>(outer);
				outerDivider.SetInnerDivider(new Divider<ushort4>(inner), i);
				Assert.AreEqual(new Divider<ushort8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ushort16_ushort()
		{
			ushort inner = ushort.MaxValue - 1;

			for (int i = 0; i < 16; i++)
			{
				ushort16 outer = new ushort16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				ushort16 cmp = outer;

				*((ushort*)&cmp + i) = inner;

				Divider<ushort16> outerDivider = new Divider<ushort16>(outer);
				outerDivider.SetInnerDivider(new Divider<ushort>(inner), i);
				Assert.AreEqual(new Divider<ushort16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ushort16_ushort2()
		{
			ushort2 inner = new ushort2(ushort.MaxValue - 1, ushort.MaxValue - 2);

			for (int i = 0; i < 15; i++)
			{
				ushort16 outer = new ushort16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				ushort16 cmp = outer;

				*(ushort2*)((ushort*)&cmp + i) = inner;

				Divider<ushort16> outerDivider = new Divider<ushort16>(outer);
				outerDivider.SetInnerDivider(new Divider<ushort2>(inner), i);
				Assert.AreEqual(new Divider<ushort16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ushort16_ushort3()
		{
			ushort3 inner = new ushort3(ushort.MaxValue - 1, ushort.MaxValue - 2, ushort.MaxValue - 3);

			for (int i = 0; i < 14; i++)
			{
				ushort16 outer = new ushort16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				ushort16 cmp = outer;

				*(ushort3*)((ushort*)&cmp + i) = inner;

				Divider<ushort16> outerDivider = new Divider<ushort16>(outer);
				outerDivider.SetInnerDivider(new Divider<ushort3>(inner), i);
				Assert.AreEqual(new Divider<ushort16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ushort16_ushort4()
		{
			ushort4 inner = new ushort4(ushort.MaxValue - 1, ushort.MaxValue - 2, ushort.MaxValue - 3, ushort.MaxValue - 4);

			for (int i = 0; i < 13; i++)
			{
				ushort16 outer = new ushort16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				ushort16 cmp = outer;

				*(ushort4*)((ushort*)&cmp + i) = inner;

				Divider<ushort16> outerDivider = new Divider<ushort16>(outer);
				outerDivider.SetInnerDivider(new Divider<ushort4>(inner), i);
				Assert.AreEqual(new Divider<ushort16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ushort16_ushort8()
		{
			ushort8 inner = new ushort8(ushort.MaxValue - 1, ushort.MaxValue - 2, ushort.MaxValue - 3, ushort.MaxValue - 4, ushort.MaxValue - 5, ushort.MaxValue - 6, ushort.MaxValue - 7, ushort.MaxValue - 8);

			for (int i = 0; i < 8; i++)
			{
				ushort16 outer = new ushort16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				ushort16 cmp = outer;

				*(ushort8*)((ushort*)&cmp + i) = inner;

				Divider<ushort16> outerDivider = new Divider<ushort16>(outer);
				outerDivider.SetInnerDivider(new Divider<ushort8>(inner), i);
				Assert.AreEqual(new Divider<ushort16>(cmp), outerDivider);
			}
		}


		[Test]
		public static void SetInnerDivider_short2_short()
		{
			short inner = short.MaxValue - 1;

			for (int i = 0; i < 2; i++)
			{
				short2 outer = new short2(1, 2);
				short2 cmp = outer;

				*((short*)&cmp + i) = inner;

				Divider<short2> outerDivider = new Divider<short2>(outer);
				outerDivider.SetInnerDivider(new Divider<short>(inner), i);
				Assert.AreEqual(new Divider<short2>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_short3_short()
		{
			short inner = short.MaxValue - 1;

			for (int i = 0; i < 3; i++)
			{
				short3 outer = new short3(1, 2, 3);
				short3 cmp = outer;

				*((short*)&cmp + i) = inner;

				Divider<short3> outerDivider = new Divider<short3>(outer);
				outerDivider.SetInnerDivider(new Divider<short>(inner), i);
				Assert.AreEqual(new Divider<short3>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_short3_short2()
		{
			short2 inner = new short2(short.MaxValue - 1, short.MaxValue - 2);

			for (int i = 0; i < 2; i++)
			{
				short3 outer = new short3(1, 2, 3);
				short3 cmp = outer;

				*(short2*)((short*)&cmp + i) = inner;

				Divider<short3> outerDivider = new Divider<short3>(outer);
				outerDivider.SetInnerDivider(new Divider<short2>(inner), i);
				Assert.AreEqual(new Divider<short3>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_short4_short()
		{
			short inner = short.MaxValue - 1;

			for (int i = 0; i < 4; i++)
			{
				short4 outer = new short4(1, 2, 3, 4);
				short4 cmp = outer;

				*((short*)&cmp + i) = inner;

				Divider<short4> outerDivider = new Divider<short4>(outer);
				outerDivider.SetInnerDivider(new Divider<short>(inner), i);
				Assert.AreEqual(new Divider<short4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_short4_short2()
		{
			short2 inner = new short2(short.MaxValue - 1, short.MaxValue - 2);

			for (int i = 0; i < 3; i++)
			{
				short4 outer = new short4(1, 2, 3, 4);
				short4 cmp = outer;

				*(short2*)((short*)&cmp + i) = inner;

				Divider<short4> outerDivider = new Divider<short4>(outer);
				outerDivider.SetInnerDivider(new Divider<short2>(inner), i);
				Assert.AreEqual(new Divider<short4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_short4_short3()
		{
			short3 inner = new short3(short.MaxValue - 1, short.MaxValue - 2, short.MaxValue - 3);

			for (int i = 0; i < 2; i++)
			{
				short4 outer = new short4(1, 2, 3, 4);
				short4 cmp = outer;

				*(short3*)((short*)&cmp + i) = inner;

				Divider<short4> outerDivider = new Divider<short4>(outer);
				outerDivider.SetInnerDivider(new Divider<short3>(inner), i);
				Assert.AreEqual(new Divider<short4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_short8_short()
		{
			short inner = short.MaxValue - 1;

			for (int i = 0; i < 8; i++)
			{
				short8 outer = new short8(1, 2, 3, 4, 5, 6, 7, 8);
				short8 cmp = outer;

				*((short*)&cmp + i) = inner;

				Divider<short8> outerDivider = new Divider<short8>(outer);
				outerDivider.SetInnerDivider(new Divider<short>(inner), i);
				Assert.AreEqual(new Divider<short8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_short8_short2()
		{
			short2 inner = new short2(short.MaxValue - 1, short.MaxValue - 2);

			for (int i = 0; i < 7; i++)
			{
				short8 outer = new short8(1, 2, 3, 4, 5, 6, 7, 8);
				short8 cmp = outer;

				*(short2*)((short*)&cmp + i) = inner;

				Divider<short8> outerDivider = new Divider<short8>(outer);
				outerDivider.SetInnerDivider(new Divider<short2>(inner), i);
				Assert.AreEqual(new Divider<short8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_short8_short3()
		{
			short3 inner = new short3(short.MaxValue - 1, short.MaxValue - 2, short.MaxValue - 3);

			for (int i = 0; i < 6; i++)
			{
				short8 outer = new short8(1, 2, 3, 4, 5, 6, 7, 8);
				short8 cmp = outer;

				*(short3*)((short*)&cmp + i) = inner;

				Divider<short8> outerDivider = new Divider<short8>(outer);
				outerDivider.SetInnerDivider(new Divider<short3>(inner), i);
				Assert.AreEqual(new Divider<short8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_short8_short4()
		{
			short4 inner = new short4(short.MaxValue - 1, short.MaxValue - 2, short.MaxValue - 3, short.MaxValue - 4);

			for (int i = 0; i < 5; i++)
			{
				short8 outer = new short8(1, 2, 3, 4, 5, 6, 7, 8);
				short8 cmp = outer;

				*(short4*)((short*)&cmp + i) = inner;

				Divider<short8> outerDivider = new Divider<short8>(outer);
				outerDivider.SetInnerDivider(new Divider<short4>(inner), i);
				Assert.AreEqual(new Divider<short8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_short16_short()
		{
			short inner = short.MaxValue - 1;

			for (int i = 0; i < 16; i++)
			{
				short16 outer = new short16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				short16 cmp = outer;

				*((short*)&cmp + i) = inner;

				Divider<short16> outerDivider = new Divider<short16>(outer);
				outerDivider.SetInnerDivider(new Divider<short>(inner), i);
				Assert.AreEqual(new Divider<short16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_short16_short2()
		{
			short2 inner = new short2(short.MaxValue - 1, short.MaxValue - 2);

			for (int i = 0; i < 15; i++)
			{
				short16 outer = new short16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				short16 cmp = outer;

				*(short2*)((short*)&cmp + i) = inner;

				Divider<short16> outerDivider = new Divider<short16>(outer);
				outerDivider.SetInnerDivider(new Divider<short2>(inner), i);
				Assert.AreEqual(new Divider<short16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_short16_short3()
		{
			short3 inner = new short3(short.MaxValue - 1, short.MaxValue - 2, short.MaxValue - 3);

			for (int i = 0; i < 14; i++)
			{
				short16 outer = new short16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				short16 cmp = outer;

				*(short3*)((short*)&cmp + i) = inner;

				Divider<short16> outerDivider = new Divider<short16>(outer);
				outerDivider.SetInnerDivider(new Divider<short3>(inner), i);
				Assert.AreEqual(new Divider<short16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_short16_short4()
		{
			short4 inner = new short4(short.MaxValue - 1, short.MaxValue - 2, short.MaxValue - 3, short.MaxValue - 4);

			for (int i = 0; i < 13; i++)
			{
				short16 outer = new short16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				short16 cmp = outer;

				*(short4*)((short*)&cmp + i) = inner;

				Divider<short16> outerDivider = new Divider<short16>(outer);
				outerDivider.SetInnerDivider(new Divider<short4>(inner), i);
				Assert.AreEqual(new Divider<short16>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_short16_short8()
		{
			short8 inner = new short8(short.MaxValue - 1, short.MaxValue - 2, short.MaxValue - 3, short.MaxValue - 4, short.MaxValue - 5, short.MaxValue - 6, short.MaxValue - 7, short.MaxValue - 8);

			for (int i = 0; i < 8; i++)
			{
				short16 outer = new short16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				short16 cmp = outer;

				*(short8*)((short*)&cmp + i) = inner;

				Divider<short16> outerDivider = new Divider<short16>(outer);
				outerDivider.SetInnerDivider(new Divider<short8>(inner), i);
				Assert.AreEqual(new Divider<short16>(cmp), outerDivider);
			}
		}


		[Test]
		public static void SetInnerDivider_uint2_uint()
		{
			uint inner = uint.MaxValue - 1;

			for (int i = 0; i < 2; i++)
			{
				uint2 outer = new uint2(1, 2);
				uint2 cmp = outer;

				*((uint*)&cmp + i) = inner;

				Divider<uint2> outerDivider = new Divider<uint2>(outer);
				outerDivider.SetInnerDivider(new Divider<uint>(inner), i);
				Assert.AreEqual(new Divider<uint2>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_uint3_uint()
		{
			uint inner = uint.MaxValue - 1;

			for (int i = 0; i < 3; i++)
			{
				uint3 outer = new uint3(1, 2, 3);
				uint3 cmp = outer;

				*((uint*)&cmp + i) = inner;

				Divider<uint3> outerDivider = new Divider<uint3>(outer);
				outerDivider.SetInnerDivider(new Divider<uint>(inner), i);
				Assert.AreEqual(new Divider<uint3>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_uint3_uint2()
		{
			uint2 inner = new uint2(uint.MaxValue - 1, uint.MaxValue - 2);

			for (int i = 0; i < 2; i++)
			{
				uint3 outer = new uint3(1, 2, 3);
				uint3 cmp = outer;

				*(uint2*)((uint*)&cmp + i) = inner;

				Divider<uint3> outerDivider = new Divider<uint3>(outer);
				outerDivider.SetInnerDivider(new Divider<uint2>(inner), i);
				Assert.AreEqual(new Divider<uint3>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_uint4_uint()
		{
			uint inner = uint.MaxValue - 1;

			for (int i = 0; i < 4; i++)
			{
				uint4 outer = new uint4(1, 2, 3, 4);
				uint4 cmp = outer;

				*((uint*)&cmp + i) = inner;

				Divider<uint4> outerDivider = new Divider<uint4>(outer);
				outerDivider.SetInnerDivider(new Divider<uint>(inner), i);
				Assert.AreEqual(new Divider<uint4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_uint4_uint2()
		{
			uint2 inner = new uint2(uint.MaxValue - 1, uint.MaxValue - 2);

			for (int i = 0; i < 3; i++)
			{
				uint4 outer = new uint4(1, 2, 3, 4);
				uint4 cmp = outer;

				*(uint2*)((uint*)&cmp + i) = inner;

				Divider<uint4> outerDivider = new Divider<uint4>(outer);
				outerDivider.SetInnerDivider(new Divider<uint2>(inner), i);
				Assert.AreEqual(new Divider<uint4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_uint4_uint3()
		{
			uint3 inner = new uint3(uint.MaxValue - 1, uint.MaxValue - 2, uint.MaxValue - 3);

			for (int i = 0; i < 2; i++)
			{
				uint4 outer = new uint4(1, 2, 3, 4);
				uint4 cmp = outer;

				*(uint3*)((uint*)&cmp + i) = inner;

				Divider<uint4> outerDivider = new Divider<uint4>(outer);
				outerDivider.SetInnerDivider(new Divider<uint3>(inner), i);
				Assert.AreEqual(new Divider<uint4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_uint8_uint()
		{
			uint inner = uint.MaxValue - 1;

			for (int i = 0; i < 8; i++)
			{
				uint8 outer = new uint8(1, 2, 3, 4, 5, 6, 7, 8);
				uint8 cmp = outer;

				*((uint*)&cmp + i) = inner;

				Divider<uint8> outerDivider = new Divider<uint8>(outer);
				outerDivider.SetInnerDivider(new Divider<uint>(inner), i);
				Assert.AreEqual(new Divider<uint8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_uint8_uint2()
		{
			uint2 inner = new uint2(uint.MaxValue - 1, uint.MaxValue - 2);

			for (int i = 0; i < 7; i++)
			{
				uint8 outer = new uint8(1, 2, 3, 4, 5, 6, 7, 8);
				uint8 cmp = outer;

				*(uint2*)((uint*)&cmp + i) = inner;

				Divider<uint8> outerDivider = new Divider<uint8>(outer);
				outerDivider.SetInnerDivider(new Divider<uint2>(inner), i);
				Assert.AreEqual(new Divider<uint8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_uint8_uint3()
		{
			uint3 inner = new uint3(uint.MaxValue - 1, uint.MaxValue - 2, uint.MaxValue - 3);

			for (int i = 0; i < 6; i++)
			{
				uint8 outer = new uint8(1, 2, 3, 4, 5, 6, 7, 8);
				uint8 cmp = outer;

				*(uint3*)((uint*)&cmp + i) = inner;

				Divider<uint8> outerDivider = new Divider<uint8>(outer);
				outerDivider.SetInnerDivider(new Divider<uint3>(inner), i);
				Assert.AreEqual(new Divider<uint8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_uint8_uint4()
		{
			uint4 inner = new uint4(uint.MaxValue - 1, uint.MaxValue - 2, uint.MaxValue - 3, uint.MaxValue - 4);

			for (int i = 0; i < 5; i++)
			{
				uint8 outer = new uint8(1, 2, 3, 4, 5, 6, 7, 8);
				uint8 cmp = outer;

				*(uint4*)((uint*)&cmp + i) = inner;

				Divider<uint8> outerDivider = new Divider<uint8>(outer);
				outerDivider.SetInnerDivider(new Divider<uint4>(inner), i);
				Assert.AreEqual(new Divider<uint8>(cmp), outerDivider);
			}
		}


		[Test]
		public static void SetInnerDivider_int2_int()
		{
			int inner = int.MaxValue - 1;

			for (int i = 0; i < 2; i++)
			{
				int2 outer = new int2(1, 2);
				int2 cmp = outer;

				*((int*)&cmp + i) = inner;

				Divider<int2> outerDivider = new Divider<int2>(outer);
				outerDivider.SetInnerDivider(new Divider<int>(inner), i);
				Assert.AreEqual(new Divider<int2>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_int3_int()
		{
			int inner = int.MaxValue - 1;

			for (int i = 0; i < 3; i++)
			{
				int3 outer = new int3(1, 2, 3);
				int3 cmp = outer;

				*((int*)&cmp + i) = inner;

				Divider<int3> outerDivider = new Divider<int3>(outer);
				outerDivider.SetInnerDivider(new Divider<int>(inner), i);
				Assert.AreEqual(new Divider<int3>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_int3_int2()
		{
			int2 inner = new int2(int.MaxValue - 1, int.MaxValue - 2);

			for (int i = 0; i < 2; i++)
			{
				int3 outer = new int3(1, 2, 3);
				int3 cmp = outer;

				*(int2*)((int*)&cmp + i) = inner;

				Divider<int3> outerDivider = new Divider<int3>(outer);
				outerDivider.SetInnerDivider(new Divider<int2>(inner), i);
				Assert.AreEqual(new Divider<int3>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_int4_int()
		{
			int inner = int.MaxValue - 1;

			for (int i = 0; i < 4; i++)
			{
				int4 outer = new int4(1, 2, 3, 4);
				int4 cmp = outer;

				*((int*)&cmp + i) = inner;

				Divider<int4> outerDivider = new Divider<int4>(outer);
				outerDivider.SetInnerDivider(new Divider<int>(inner), i);
				Assert.AreEqual(new Divider<int4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_int4_int2()
		{
			int2 inner = new int2(int.MaxValue - 1, int.MaxValue - 2);

			for (int i = 0; i < 3; i++)
			{
				int4 outer = new int4(1, 2, 3, 4);
				int4 cmp = outer;

				*(int2*)((int*)&cmp + i) = inner;

				Divider<int4> outerDivider = new Divider<int4>(outer);
				outerDivider.SetInnerDivider(new Divider<int2>(inner), i);
				Assert.AreEqual(new Divider<int4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_int4_int3()
		{
			int3 inner = new int3(int.MaxValue - 1, int.MaxValue - 2, int.MaxValue - 3);

			for (int i = 0; i < 2; i++)
			{
				int4 outer = new int4(1, 2, 3, 4);
				int4 cmp = outer;

				*(int3*)((int*)&cmp + i) = inner;

				Divider<int4> outerDivider = new Divider<int4>(outer);
				outerDivider.SetInnerDivider(new Divider<int3>(inner), i);
				Assert.AreEqual(new Divider<int4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_int8_int()
		{
			int inner = int.MaxValue - 1;

			for (int i = 0; i < 8; i++)
			{
				int8 outer = new int8(1, 2, 3, 4, 5, 6, 7, 8);
				int8 cmp = outer;

				*((int*)&cmp + i) = inner;

				Divider<int8> outerDivider = new Divider<int8>(outer);
				outerDivider.SetInnerDivider(new Divider<int>(inner), i);
				Assert.AreEqual(new Divider<int8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_int8_int2()
		{
			int2 inner = new int2(int.MaxValue - 1, int.MaxValue - 2);

			for (int i = 0; i < 7; i++)
			{
				int8 outer = new int8(1, 2, 3, 4, 5, 6, 7, 8);
				int8 cmp = outer;

				*(int2*)((int*)&cmp + i) = inner;

				Divider<int8> outerDivider = new Divider<int8>(outer);
				outerDivider.SetInnerDivider(new Divider<int2>(inner), i);
				Assert.AreEqual(new Divider<int8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_int8_int3()
		{
			int3 inner = new int3(int.MaxValue - 1, int.MaxValue - 2, int.MaxValue - 3);

			for (int i = 0; i < 6; i++)
			{
				int8 outer = new int8(1, 2, 3, 4, 5, 6, 7, 8);
				int8 cmp = outer;

				*(int3*)((int*)&cmp + i) = inner;

				Divider<int8> outerDivider = new Divider<int8>(outer);
				outerDivider.SetInnerDivider(new Divider<int3>(inner), i);
				Assert.AreEqual(new Divider<int8>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_int8_int4()
		{
			int4 inner = new int4(int.MaxValue - 1, int.MaxValue - 2, int.MaxValue - 3, int.MaxValue - 4);

			for (int i = 0; i < 5; i++)
			{
				int8 outer = new int8(1, 2, 3, 4, 5, 6, 7, 8);
				int8 cmp = outer;

				*(int4*)((int*)&cmp + i) = inner;

				Divider<int8> outerDivider = new Divider<int8>(outer);
				outerDivider.SetInnerDivider(new Divider<int4>(inner), i);
				Assert.AreEqual(new Divider<int8>(cmp), outerDivider);
			}
		}


		[Test]
		public static void SetInnerDivider_ulong2_ulong()
		{
			ulong inner = ulong.MaxValue - 1;

			for (int i = 0; i < 2; i++)
			{
				ulong2 outer = new ulong2(1, 2);
				ulong2 cmp = outer;

				*((ulong*)&cmp + i) = inner;

				Divider<ulong2> outerDivider = new Divider<ulong2>(outer);
				outerDivider.SetInnerDivider(new Divider<ulong>(inner), i);
				Assert.AreEqual(new Divider<ulong2>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ulong3_ulong()
		{
			ulong inner = ulong.MaxValue - 1;

			for (int i = 0; i < 3; i++)
			{
				ulong3 outer = new ulong3(1, 2, 3);
				ulong3 cmp = outer;

				*((ulong*)&cmp + i) = inner;

				Divider<ulong3> outerDivider = new Divider<ulong3>(outer);
				outerDivider.SetInnerDivider(new Divider<ulong>(inner), i);
				Assert.AreEqual(new Divider<ulong3>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ulong3_ulong2()
		{
			ulong2 inner = new ulong2(ulong.MaxValue - 1, ulong.MaxValue - 2);

			for (int i = 0; i < 2; i++)
			{
				ulong3 outer = new ulong3(1, 2, 3);
				ulong3 cmp = outer;

				*(ulong2*)((ulong*)&cmp + i) = inner;

				Divider<ulong3> outerDivider = new Divider<ulong3>(outer);
				outerDivider.SetInnerDivider(new Divider<ulong2>(inner), i);
				Assert.AreEqual(new Divider<ulong3>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ulong4_ulong()
		{
			ulong inner = ulong.MaxValue - 1;

			for (int i = 0; i < 4; i++)
			{
				ulong4 outer = new ulong4(1, 2, 3, 4);
				ulong4 cmp = outer;

				*((ulong*)&cmp + i) = inner;

				Divider<ulong4> outerDivider = new Divider<ulong4>(outer);
				outerDivider.SetInnerDivider(new Divider<ulong>(inner), i);
				Assert.AreEqual(new Divider<ulong4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ulong4_ulong2()
		{
			ulong2 inner = new ulong2(ulong.MaxValue - 1, ulong.MaxValue - 2);

			for (int i = 0; i < 3; i++)
			{
				ulong4 outer = new ulong4(1, 2, 3, 4);
				ulong4 cmp = outer;

				*(ulong2*)((ulong*)&cmp + i) = inner;

				Divider<ulong4> outerDivider = new Divider<ulong4>(outer);
				outerDivider.SetInnerDivider(new Divider<ulong2>(inner), i);
				Assert.AreEqual(new Divider<ulong4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_ulong4_ulong3()
		{
			ulong3 inner = new ulong3(ulong.MaxValue - 1, ulong.MaxValue - 2, ulong.MaxValue - 3);

			for (int i = 0; i < 2; i++)
			{
				ulong4 outer = new ulong4(1, 2, 3, 4);
				ulong4 cmp = outer;

				*(ulong3*)((ulong*)&cmp + i) = inner;

				Divider<ulong4> outerDivider = new Divider<ulong4>(outer);
				outerDivider.SetInnerDivider(new Divider<ulong3>(inner), i);
				Assert.AreEqual(new Divider<ulong4>(cmp), outerDivider);
			}
		}


		[Test]
		public static void SetInnerDivider_long2_long()
		{
			long inner = long.MaxValue - 1;

			for (int i = 0; i < 2; i++)
			{
				long2 outer = new long2(1, 2);
				long2 cmp = outer;

				*((long*)&cmp + i) = inner;

				Divider<long2> outerDivider = new Divider<long2>(outer);
				outerDivider.SetInnerDivider(new Divider<long>(inner), i);
				Assert.AreEqual(new Divider<long2>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_long3_long()
		{
			long inner = long.MaxValue - 1;

			for (int i = 0; i < 3; i++)
			{
				long3 outer = new long3(1, 2, 3);
				long3 cmp = outer;

				*((long*)&cmp + i) = inner;

				Divider<long3> outerDivider = new Divider<long3>(outer);
				outerDivider.SetInnerDivider(new Divider<long>(inner), i);
				Assert.AreEqual(new Divider<long3>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_long3_long2()
		{
			long2 inner = new long2(long.MaxValue - 1, long.MaxValue - 2);

			for (int i = 0; i < 2; i++)
			{
				long3 outer = new long3(1, 2, 3);
				long3 cmp = outer;

				*(long2*)((long*)&cmp + i) = inner;

				Divider<long3> outerDivider = new Divider<long3>(outer);
				outerDivider.SetInnerDivider(new Divider<long2>(inner), i);
				Assert.AreEqual(new Divider<long3>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_long4_long()
		{
			long inner = long.MaxValue - 1;

			for (int i = 0; i < 4; i++)
			{
				long4 outer = new long4(1, 2, 3, 4);
				long4 cmp = outer;

				*((long*)&cmp + i) = inner;

				Divider<long4> outerDivider = new Divider<long4>(outer);
				outerDivider.SetInnerDivider(new Divider<long>(inner), i);
				Assert.AreEqual(new Divider<long4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_long4_long2()
		{
			long2 inner = new long2(long.MaxValue - 1, long.MaxValue - 2);

			for (int i = 0; i < 3; i++)
			{
				long4 outer = new long4(1, 2, 3, 4);
				long4 cmp = outer;

				*(long2*)((long*)&cmp + i) = inner;

				Divider<long4> outerDivider = new Divider<long4>(outer);
				outerDivider.SetInnerDivider(new Divider<long2>(inner), i);
				Assert.AreEqual(new Divider<long4>(cmp), outerDivider);
			}
		}

		[Test]
		public static void SetInnerDivider_long4_long3()
		{
			long3 inner = new long3(long.MaxValue - 1, long.MaxValue - 2, long.MaxValue - 3);

			for (int i = 0; i < 2; i++)
			{
				long4 outer = new long4(1, 2, 3, 4);
				long4 cmp = outer;

				*(long3*)((long*)&cmp + i) = inner;

				Divider<long4> outerDivider = new Divider<long4>(outer);
				outerDivider.SetInnerDivider(new Divider<long3>(inner), i);
				Assert.AreEqual(new Divider<long4>(cmp), outerDivider);
			}
		}
    }
}
