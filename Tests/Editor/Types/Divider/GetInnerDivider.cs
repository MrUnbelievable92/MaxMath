using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static partial class t_Divider
	{
		[Test]
		public static void GetInnerDivider_byte2_byte()
		{
			for (int i = 0; i < 2; i++)
			{
				byte2 outer = new byte2(1, 2);
				byte inner = *((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte>(inner), new Divider<byte2>(outer).GetInnerDivider<byte>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte3_byte()
		{
			for (int i = 0; i < 3; i++)
			{
				byte3 outer = new byte3(1, 2, 3);
				byte inner = *((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte>(inner), new Divider<byte3>(outer).GetInnerDivider<byte>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte3_byte2()
		{
			for (int i = 0; i < 2; i++)
			{
				byte3 outer = new byte3(1, 2, 3);
				byte2 inner = *(byte2*)((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte2>(inner), new Divider<byte3>(outer).GetInnerDivider<byte2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte4_byte()
		{
			for (int i = 0; i < 4; i++)
			{
				byte4 outer = new byte4(1, 2, 3, 4);
				byte inner = *((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte>(inner), new Divider<byte4>(outer).GetInnerDivider<byte>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte4_byte2()
		{
			for (int i = 0; i < 3; i++)
			{
				byte4 outer = new byte4(1, 2, 3, 4);
				byte2 inner = *(byte2*)((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte2>(inner), new Divider<byte4>(outer).GetInnerDivider<byte2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte4_byte3()
		{
			for (int i = 0; i < 2; i++)
			{
				byte4 outer = new byte4(1, 2, 3, 4);
				byte3 inner = *(byte3*)((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte3>(inner), new Divider<byte4>(outer).GetInnerDivider<byte3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte8_byte()
		{
			for (int i = 0; i < 8; i++)
			{
				byte8 outer = new byte8(1, 2, 3, 4, 5, 6, 7, 8);
				byte inner = *((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte>(inner), new Divider<byte8>(outer).GetInnerDivider<byte>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte8_byte2()
		{
			for (int i = 0; i < 7; i++)
			{
				byte8 outer = new byte8(1, 2, 3, 4, 5, 6, 7, 8);
				byte2 inner = *(byte2*)((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte2>(inner), new Divider<byte8>(outer).GetInnerDivider<byte2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte8_byte3()
		{
			for (int i = 0; i < 6; i++)
			{
				byte8 outer = new byte8(1, 2, 3, 4, 5, 6, 7, 8);
				byte3 inner = *(byte3*)((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte3>(inner), new Divider<byte8>(outer).GetInnerDivider<byte3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte8_byte4()
		{
			for (int i = 0; i < 5; i++)
			{
				byte8 outer = new byte8(1, 2, 3, 4, 5, 6, 7, 8);
				byte4 inner = *(byte4*)((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte4>(inner), new Divider<byte8>(outer).GetInnerDivider<byte4>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte16_byte()
		{
			for (int i = 0; i < 16; i++)
			{
				byte16 outer = new byte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				byte inner = *((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte>(inner), new Divider<byte16>(outer).GetInnerDivider<byte>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte16_byte2()
		{
			for (int i = 0; i < 15; i++)
			{
				byte16 outer = new byte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				byte2 inner = *(byte2*)((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte2>(inner), new Divider<byte16>(outer).GetInnerDivider<byte2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte16_byte3()
		{
			for (int i = 0; i < 14; i++)
			{
				byte16 outer = new byte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				byte3 inner = *(byte3*)((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte3>(inner), new Divider<byte16>(outer).GetInnerDivider<byte3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte16_byte4()
		{
			for (int i = 0; i < 13; i++)
			{
				byte16 outer = new byte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				byte4 inner = *(byte4*)((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte4>(inner), new Divider<byte16>(outer).GetInnerDivider<byte4>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte16_byte8()
		{
			for (int i = 0; i < 8; i++)
			{
				byte16 outer = new byte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				byte8 inner = *(byte8*)((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte8>(inner), new Divider<byte16>(outer).GetInnerDivider<byte8>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte32_byte()
		{
			for (int i = 0; i < 32; i++)
			{
				byte32 outer = new byte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				byte inner = *((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte>(inner), new Divider<byte32>(outer).GetInnerDivider<byte>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte32_byte2()
		{
			for (int i = 0; i < 31; i++)
			{
				byte32 outer = new byte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				byte2 inner = *(byte2*)((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte2>(inner), new Divider<byte32>(outer).GetInnerDivider<byte2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte32_byte3()
		{
			for (int i = 0; i < 30; i++)
			{
				byte32 outer = new byte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				byte3 inner = *(byte3*)((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte3>(inner), new Divider<byte32>(outer).GetInnerDivider<byte3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte32_byte4()
		{
			for (int i = 0; i < 29; i++)
			{
				byte32 outer = new byte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				byte4 inner = *(byte4*)((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte4>(inner), new Divider<byte32>(outer).GetInnerDivider<byte4>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte32_byte8()
		{
			for (int i = 0; i < 25; i++)
			{
				byte32 outer = new byte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				byte8 inner = *(byte8*)((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte8>(inner), new Divider<byte32>(outer).GetInnerDivider<byte8>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_byte32_byte16()
		{
			for (int i = 0; i < 17; i++)
			{
				byte32 outer = new byte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				byte16 inner = *(byte16*)((byte*)&outer + i);

				Assert.AreEqual(new Divider<byte16>(inner), new Divider<byte32>(outer).GetInnerDivider<byte16>(i));
			}
		}


		[Test]
		public static void GetInnerDivider_sbyte2_sbyte()
		{
			for (int i = 0; i < 2; i++)
			{
				sbyte2 outer = new sbyte2(1, 2);
				sbyte inner = *((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte>(inner), new Divider<sbyte2>(outer).GetInnerDivider<sbyte>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte3_sbyte()
		{
			for (int i = 0; i < 3; i++)
			{
				sbyte3 outer = new sbyte3(1, 2, 3);
				sbyte inner = *((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte>(inner), new Divider<sbyte3>(outer).GetInnerDivider<sbyte>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte3_sbyte2()
		{
			for (int i = 0; i < 2; i++)
			{
				sbyte3 outer = new sbyte3(1, 2, 3);
				sbyte2 inner = *(sbyte2*)((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte2>(inner), new Divider<sbyte3>(outer).GetInnerDivider<sbyte2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte4_sbyte()
		{
			for (int i = 0; i < 4; i++)
			{
				sbyte4 outer = new sbyte4(1, 2, 3, 4);
				sbyte inner = *((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte>(inner), new Divider<sbyte4>(outer).GetInnerDivider<sbyte>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte4_sbyte2()
		{
			for (int i = 0; i < 3; i++)
			{
				sbyte4 outer = new sbyte4(1, 2, 3, 4);
				sbyte2 inner = *(sbyte2*)((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte2>(inner), new Divider<sbyte4>(outer).GetInnerDivider<sbyte2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte4_sbyte3()
		{
			for (int i = 0; i < 2; i++)
			{
				sbyte4 outer = new sbyte4(1, 2, 3, 4);
				sbyte3 inner = *(sbyte3*)((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte3>(inner), new Divider<sbyte4>(outer).GetInnerDivider<sbyte3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte8_sbyte()
		{
			for (int i = 0; i < 8; i++)
			{
				sbyte8 outer = new sbyte8(1, 2, 3, 4, 5, 6, 7, 8);
				sbyte inner = *((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte>(inner), new Divider<sbyte8>(outer).GetInnerDivider<sbyte>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte8_sbyte2()
		{
			for (int i = 0; i < 7; i++)
			{
				sbyte8 outer = new sbyte8(1, 2, 3, 4, 5, 6, 7, 8);
				sbyte2 inner = *(sbyte2*)((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte2>(inner), new Divider<sbyte8>(outer).GetInnerDivider<sbyte2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte8_sbyte3()
		{
			for (int i = 0; i < 6; i++)
			{
				sbyte8 outer = new sbyte8(1, 2, 3, 4, 5, 6, 7, 8);
				sbyte3 inner = *(sbyte3*)((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte3>(inner), new Divider<sbyte8>(outer).GetInnerDivider<sbyte3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte8_sbyte4()
		{
			for (int i = 0; i < 5; i++)
			{
				sbyte8 outer = new sbyte8(1, 2, 3, 4, 5, 6, 7, 8);
				sbyte4 inner = *(sbyte4*)((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte4>(inner), new Divider<sbyte8>(outer).GetInnerDivider<sbyte4>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte16_sbyte()
		{
			for (int i = 0; i < 16; i++)
			{
				sbyte16 outer = new sbyte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				sbyte inner = *((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte>(inner), new Divider<sbyte16>(outer).GetInnerDivider<sbyte>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte16_sbyte2()
		{
			for (int i = 0; i < 15; i++)
			{
				sbyte16 outer = new sbyte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				sbyte2 inner = *(sbyte2*)((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte2>(inner), new Divider<sbyte16>(outer).GetInnerDivider<sbyte2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte16_sbyte3()
		{
			for (int i = 0; i < 14; i++)
			{
				sbyte16 outer = new sbyte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				sbyte3 inner = *(sbyte3*)((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte3>(inner), new Divider<sbyte16>(outer).GetInnerDivider<sbyte3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte16_sbyte4()
		{
			for (int i = 0; i < 13; i++)
			{
				sbyte16 outer = new sbyte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				sbyte4 inner = *(sbyte4*)((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte4>(inner), new Divider<sbyte16>(outer).GetInnerDivider<sbyte4>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte16_sbyte8()
		{
			for (int i = 0; i < 8; i++)
			{
				sbyte16 outer = new sbyte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				sbyte8 inner = *(sbyte8*)((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte8>(inner), new Divider<sbyte16>(outer).GetInnerDivider<sbyte8>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte32_sbyte()
		{
			for (int i = 0; i < 32; i++)
			{
				sbyte32 outer = new sbyte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				sbyte inner = *((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte>(inner), new Divider<sbyte32>(outer).GetInnerDivider<sbyte>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte32_sbyte2()
		{
			for (int i = 0; i < 31; i++)
			{
				sbyte32 outer = new sbyte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				sbyte2 inner = *(sbyte2*)((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte2>(inner), new Divider<sbyte32>(outer).GetInnerDivider<sbyte2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte32_sbyte3()
		{
			for (int i = 0; i < 30; i++)
			{
				sbyte32 outer = new sbyte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				sbyte3 inner = *(sbyte3*)((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte3>(inner), new Divider<sbyte32>(outer).GetInnerDivider<sbyte3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte32_sbyte4()
		{
			for (int i = 0; i < 29; i++)
			{
				sbyte32 outer = new sbyte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				sbyte4 inner = *(sbyte4*)((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte4>(inner), new Divider<sbyte32>(outer).GetInnerDivider<sbyte4>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte32_sbyte8()
		{
			for (int i = 0; i < 25; i++)
			{
				sbyte32 outer = new sbyte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				sbyte8 inner = *(sbyte8*)((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte8>(inner), new Divider<sbyte32>(outer).GetInnerDivider<sbyte8>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_sbyte32_sbyte16()
		{
			for (int i = 0; i < 17; i++)
			{
				sbyte32 outer = new sbyte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
				sbyte16 inner = *(sbyte16*)((sbyte*)&outer + i);

				Assert.AreEqual(new Divider<sbyte16>(inner), new Divider<sbyte32>(outer).GetInnerDivider<sbyte16>(i));
			}
		}


		[Test]
		public static void GetInnerDivider_ushort2_ushort()
		{
			for (int i = 0; i < 2; i++)
			{
				ushort2 outer = new ushort2(1, 2);
				ushort inner = *((ushort*)&outer + i);

				Assert.AreEqual(new Divider<ushort>(inner), new Divider<ushort2>(outer).GetInnerDivider<ushort>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ushort3_ushort()
		{
			for (int i = 0; i < 3; i++)
			{
				ushort3 outer = new ushort3(1, 2, 3);
				ushort inner = *((ushort*)&outer + i);

				Assert.AreEqual(new Divider<ushort>(inner), new Divider<ushort3>(outer).GetInnerDivider<ushort>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ushort3_ushort2()
		{
			for (int i = 0; i < 2; i++)
			{
				ushort3 outer = new ushort3(1, 2, 3);
				ushort2 inner = *(ushort2*)((ushort*)&outer + i);

				Assert.AreEqual(new Divider<ushort2>(inner), new Divider<ushort3>(outer).GetInnerDivider<ushort2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ushort4_ushort()
		{
			for (int i = 0; i < 4; i++)
			{
				ushort4 outer = new ushort4(1, 2, 3, 4);
				ushort inner = *((ushort*)&outer + i);

				Assert.AreEqual(new Divider<ushort>(inner), new Divider<ushort4>(outer).GetInnerDivider<ushort>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ushort4_ushort2()
		{
			for (int i = 0; i < 3; i++)
			{
				ushort4 outer = new ushort4(1, 2, 3, 4);
				ushort2 inner = *(ushort2*)((ushort*)&outer + i);

				Assert.AreEqual(new Divider<ushort2>(inner), new Divider<ushort4>(outer).GetInnerDivider<ushort2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ushort4_ushort3()
		{
			for (int i = 0; i < 2; i++)
			{
				ushort4 outer = new ushort4(1, 2, 3, 4);
				ushort3 inner = *(ushort3*)((ushort*)&outer + i);

				Assert.AreEqual(new Divider<ushort3>(inner), new Divider<ushort4>(outer).GetInnerDivider<ushort3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ushort8_ushort()
		{
			for (int i = 0; i < 8; i++)
			{
				ushort8 outer = new ushort8(1, 2, 3, 4, 5, 6, 7, 8);
				ushort inner = *((ushort*)&outer + i);

				Assert.AreEqual(new Divider<ushort>(inner), new Divider<ushort8>(outer).GetInnerDivider<ushort>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ushort8_ushort2()
		{
			for (int i = 0; i < 7; i++)
			{
				ushort8 outer = new ushort8(1, 2, 3, 4, 5, 6, 7, 8);
				ushort2 inner = *(ushort2*)((ushort*)&outer + i);

				Assert.AreEqual(new Divider<ushort2>(inner), new Divider<ushort8>(outer).GetInnerDivider<ushort2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ushort8_ushort3()
		{
			for (int i = 0; i < 6; i++)
			{
				ushort8 outer = new ushort8(1, 2, 3, 4, 5, 6, 7, 8);
				ushort3 inner = *(ushort3*)((ushort*)&outer + i);

				Assert.AreEqual(new Divider<ushort3>(inner), new Divider<ushort8>(outer).GetInnerDivider<ushort3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ushort8_ushort4()
		{
			for (int i = 0; i < 5; i++)
			{
				ushort8 outer = new ushort8(1, 2, 3, 4, 5, 6, 7, 8);
				ushort4 inner = *(ushort4*)((ushort*)&outer + i);

				Assert.AreEqual(new Divider<ushort4>(inner), new Divider<ushort8>(outer).GetInnerDivider<ushort4>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ushort16_ushort()
		{
			for (int i = 0; i < 16; i++)
			{
				ushort16 outer = new ushort16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				ushort inner = *((ushort*)&outer + i);

				Assert.AreEqual(new Divider<ushort>(inner), new Divider<ushort16>(outer).GetInnerDivider<ushort>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ushort16_ushort2()
		{
			for (int i = 0; i < 15; i++)
			{
				ushort16 outer = new ushort16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				ushort2 inner = *(ushort2*)((ushort*)&outer + i);

				Assert.AreEqual(new Divider<ushort2>(inner), new Divider<ushort16>(outer).GetInnerDivider<ushort2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ushort16_ushort3()
		{
			for (int i = 0; i < 14; i++)
			{
				ushort16 outer = new ushort16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				ushort3 inner = *(ushort3*)((ushort*)&outer + i);

				Assert.AreEqual(new Divider<ushort3>(inner), new Divider<ushort16>(outer).GetInnerDivider<ushort3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ushort16_ushort4()
		{
			for (int i = 0; i < 13; i++)
			{
				ushort16 outer = new ushort16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				ushort4 inner = *(ushort4*)((ushort*)&outer + i);

				Assert.AreEqual(new Divider<ushort4>(inner), new Divider<ushort16>(outer).GetInnerDivider<ushort4>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ushort16_ushort8()
		{
			for (int i = 0; i < 8; i++)
			{
				ushort16 outer = new ushort16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				ushort8 inner = *(ushort8*)((ushort*)&outer + i);

				Assert.AreEqual(new Divider<ushort8>(inner), new Divider<ushort16>(outer).GetInnerDivider<ushort8>(i));
			}
		}


		[Test]
		public static void GetInnerDivider_short2_short()
		{
			for (int i = 0; i < 2; i++)
			{
				short2 outer = new short2(1, 2);
				short inner = *((short*)&outer + i);

				Assert.AreEqual(new Divider<short>(inner), new Divider<short2>(outer).GetInnerDivider<short>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_short3_short()
		{
			for (int i = 0; i < 3; i++)
			{
				short3 outer = new short3(1, 2, 3);
				short inner = *((short*)&outer + i);

				Assert.AreEqual(new Divider<short>(inner), new Divider<short3>(outer).GetInnerDivider<short>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_short3_short2()
		{
			for (int i = 0; i < 2; i++)
			{
				short3 outer = new short3(1, 2, 3);
				short2 inner = *(short2*)((short*)&outer + i);

				Assert.AreEqual(new Divider<short2>(inner), new Divider<short3>(outer).GetInnerDivider<short2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_short4_short()
		{
			for (int i = 0; i < 4; i++)
			{
				short4 outer = new short4(1, 2, 3, 4);
				short inner = *((short*)&outer + i);

				Assert.AreEqual(new Divider<short>(inner), new Divider<short4>(outer).GetInnerDivider<short>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_short4_short2()
		{
			for (int i = 0; i < 3; i++)
			{
				short4 outer = new short4(1, 2, 3, 4);
				short2 inner = *(short2*)((short*)&outer + i);

				Assert.AreEqual(new Divider<short2>(inner), new Divider<short4>(outer).GetInnerDivider<short2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_short4_short3()
		{
			for (int i = 0; i < 2; i++)
			{
				short4 outer = new short4(1, 2, 3, 4);
				short3 inner = *(short3*)((short*)&outer + i);

				Assert.AreEqual(new Divider<short3>(inner), new Divider<short4>(outer).GetInnerDivider<short3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_short8_short()
		{
			for (int i = 0; i < 8; i++)
			{
				short8 outer = new short8(1, 2, 3, 4, 5, 6, 7, 8);
				short inner = *((short*)&outer + i);

				Assert.AreEqual(new Divider<short>(inner), new Divider<short8>(outer).GetInnerDivider<short>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_short8_short2()
		{
			for (int i = 0; i < 7; i++)
			{
				short8 outer = new short8(1, 2, 3, 4, 5, 6, 7, 8);
				short2 inner = *(short2*)((short*)&outer + i);

				Assert.AreEqual(new Divider<short2>(inner), new Divider<short8>(outer).GetInnerDivider<short2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_short8_short3()
		{
			for (int i = 0; i < 6; i++)
			{
				short8 outer = new short8(1, 2, 3, 4, 5, 6, 7, 8);
				short3 inner = *(short3*)((short*)&outer + i);

				Assert.AreEqual(new Divider<short3>(inner), new Divider<short8>(outer).GetInnerDivider<short3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_short8_short4()
		{
			for (int i = 0; i < 5; i++)
			{
				short8 outer = new short8(1, 2, 3, 4, 5, 6, 7, 8);
				short4 inner = *(short4*)((short*)&outer + i);

				Assert.AreEqual(new Divider<short4>(inner), new Divider<short8>(outer).GetInnerDivider<short4>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_short16_short()
		{
			for (int i = 0; i < 16; i++)
			{
				short16 outer = new short16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				short inner = *((short*)&outer + i);

				Assert.AreEqual(new Divider<short>(inner), new Divider<short16>(outer).GetInnerDivider<short>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_short16_short2()
		{
			for (int i = 0; i < 15; i++)
			{
				short16 outer = new short16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				short2 inner = *(short2*)((short*)&outer + i);

				Assert.AreEqual(new Divider<short2>(inner), new Divider<short16>(outer).GetInnerDivider<short2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_short16_short3()
		{
			for (int i = 0; i < 14; i++)
			{
				short16 outer = new short16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				short3 inner = *(short3*)((short*)&outer + i);

				Assert.AreEqual(new Divider<short3>(inner), new Divider<short16>(outer).GetInnerDivider<short3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_short16_short4()
		{
			for (int i = 0; i < 13; i++)
			{
				short16 outer = new short16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				short4 inner = *(short4*)((short*)&outer + i);

				Assert.AreEqual(new Divider<short4>(inner), new Divider<short16>(outer).GetInnerDivider<short4>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_short16_short8()
		{
			for (int i = 0; i < 8; i++)
			{
				short16 outer = new short16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
				short8 inner = *(short8*)((short*)&outer + i);

				Assert.AreEqual(new Divider<short8>(inner), new Divider<short16>(outer).GetInnerDivider<short8>(i));
			}
		}


		[Test]
		public static void GetInnerDivider_uint2_uint()
		{
			for (int i = 0; i < 2; i++)
			{
				uint2 outer = new uint2(1, 2);
				uint inner = *((uint*)&outer + i);

				Assert.AreEqual(new Divider<uint>(inner), new Divider<uint2>(outer).GetInnerDivider<uint>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_uint3_uint()
		{
			for (int i = 0; i < 3; i++)
			{
				uint3 outer = new uint3(1, 2, 3);
				uint inner = *((uint*)&outer + i);

				Assert.AreEqual(new Divider<uint>(inner), new Divider<uint3>(outer).GetInnerDivider<uint>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_uint3_uint2()
		{
			for (int i = 0; i < 2; i++)
			{
				uint3 outer = new uint3(1, 2, 3);
				uint2 inner = *(uint2*)((uint*)&outer + i);

				Assert.AreEqual(new Divider<uint2>(inner), new Divider<uint3>(outer).GetInnerDivider<uint2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_uint4_uint()
		{
			for (int i = 0; i < 4; i++)
			{
				uint4 outer = new uint4(1, 2, 3, 4);
				uint inner = *((uint*)&outer + i);

				Assert.AreEqual(new Divider<uint>(inner), new Divider<uint4>(outer).GetInnerDivider<uint>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_uint4_uint2()
		{
			for (int i = 0; i < 3; i++)
			{
				uint4 outer = new uint4(1, 2, 3, 4);
				uint2 inner = *(uint2*)((uint*)&outer + i);

				Assert.AreEqual(new Divider<uint2>(inner), new Divider<uint4>(outer).GetInnerDivider<uint2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_uint4_uint3()
		{
			for (int i = 0; i < 2; i++)
			{
				uint4 outer = new uint4(1, 2, 3, 4);
				uint3 inner = *(uint3*)((uint*)&outer + i);

				Assert.AreEqual(new Divider<uint3>(inner), new Divider<uint4>(outer).GetInnerDivider<uint3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_uint8_uint()
		{
			for (int i = 0; i < 8; i++)
			{
				uint8 outer = new uint8(1, 2, 3, 4, 5, 6, 7, 8);
				uint inner = *((uint*)&outer + i);

				Assert.AreEqual(new Divider<uint>(inner), new Divider<uint8>(outer).GetInnerDivider<uint>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_uint8_uint2()
		{
			for (int i = 0; i < 7; i++)
			{
				uint8 outer = new uint8(1, 2, 3, 4, 5, 6, 7, 8);
				uint2 inner = *(uint2*)((uint*)&outer + i);

				Assert.AreEqual(new Divider<uint2>(inner), new Divider<uint8>(outer).GetInnerDivider<uint2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_uint8_uint3()
		{
			for (int i = 0; i < 6; i++)
			{
				uint8 outer = new uint8(1, 2, 3, 4, 5, 6, 7, 8);
				uint3 inner = *(uint3*)((uint*)&outer + i);

				Assert.AreEqual(new Divider<uint3>(inner), new Divider<uint8>(outer).GetInnerDivider<uint3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_uint8_uint4()
		{
			for (int i = 0; i < 5; i++)
			{
				uint8 outer = new uint8(1, 2, 3, 4, 5, 6, 7, 8);
				uint4 inner = *(uint4*)((uint*)&outer + i);

				Assert.AreEqual(new Divider<uint4>(inner), new Divider<uint8>(outer).GetInnerDivider<uint4>(i));
			}
		}


		[Test]
		public static void GetInnerDivider_int2_int()
		{
			for (int i = 0; i < 2; i++)
			{
				int2 outer = new int2(1, 2);
				int inner = *((int*)&outer + i);

				Assert.AreEqual(new Divider<int>(inner), new Divider<int2>(outer).GetInnerDivider<int>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_int3_int()
		{
			for (int i = 0; i < 3; i++)
			{
				int3 outer = new int3(1, 2, 3);
				int inner = *((int*)&outer + i);

				Assert.AreEqual(new Divider<int>(inner), new Divider<int3>(outer).GetInnerDivider<int>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_int3_int2()
		{
			for (int i = 0; i < 2; i++)
			{
				int3 outer = new int3(1, 2, 3);
				int2 inner = *(int2*)((int*)&outer + i);

				Assert.AreEqual(new Divider<int2>(inner), new Divider<int3>(outer).GetInnerDivider<int2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_int4_int()
		{
			for (int i = 0; i < 4; i++)
			{
				int4 outer = new int4(1, 2, 3, 4);
				int inner = *((int*)&outer + i);

				Assert.AreEqual(new Divider<int>(inner), new Divider<int4>(outer).GetInnerDivider<int>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_int4_int2()
		{
			for (int i = 0; i < 3; i++)
			{
				int4 outer = new int4(1, 2, 3, 4);
				int2 inner = *(int2*)((int*)&outer + i);

				Assert.AreEqual(new Divider<int2>(inner), new Divider<int4>(outer).GetInnerDivider<int2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_int4_int3()
		{
			for (int i = 0; i < 2; i++)
			{
				int4 outer = new int4(1, 2, 3, 4);
				int3 inner = *(int3*)((int*)&outer + i);

				Assert.AreEqual(new Divider<int3>(inner), new Divider<int4>(outer).GetInnerDivider<int3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_int8_int()
		{
			for (int i = 0; i < 8; i++)
			{
				int8 outer = new int8(1, 2, 3, 4, 5, 6, 7, 8);
				int inner = *((int*)&outer + i);

				Assert.AreEqual(new Divider<int>(inner), new Divider<int8>(outer).GetInnerDivider<int>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_int8_int2()
		{
			for (int i = 0; i < 7; i++)
			{
				int8 outer = new int8(1, 2, 3, 4, 5, 6, 7, 8);
				int2 inner = *(int2*)((int*)&outer + i);

				Assert.AreEqual(new Divider<int2>(inner), new Divider<int8>(outer).GetInnerDivider<int2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_int8_int3()
		{
			for (int i = 0; i < 6; i++)
			{
				int8 outer = new int8(1, 2, 3, 4, 5, 6, 7, 8);
				int3 inner = *(int3*)((int*)&outer + i);

				Assert.AreEqual(new Divider<int3>(inner), new Divider<int8>(outer).GetInnerDivider<int3>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_int8_int4()
		{
			for (int i = 0; i < 5; i++)
			{
				int8 outer = new int8(1, 2, 3, 4, 5, 6, 7, 8);
				int4 inner = *(int4*)((int*)&outer + i);

				Assert.AreEqual(new Divider<int4>(inner), new Divider<int8>(outer).GetInnerDivider<int4>(i));
			}
		}


		[Test]
		public static void GetInnerDivider_ulong2_ulong()
		{
			for (int i = 0; i < 2; i++)
			{
				ulong2 outer = new ulong2(1, 2);
				ulong inner = *((ulong*)&outer + i);

				Assert.AreEqual(new Divider<ulong>(inner), new Divider<ulong2>(outer).GetInnerDivider<ulong>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ulong3_ulong()
		{
			for (int i = 0; i < 3; i++)
			{
				ulong3 outer = new ulong3(1, 2, 3);
				ulong inner = *((ulong*)&outer + i);

				Assert.AreEqual(new Divider<ulong>(inner), new Divider<ulong3>(outer).GetInnerDivider<ulong>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ulong3_ulong2()
		{
			for (int i = 0; i < 2; i++)
			{
				ulong3 outer = new ulong3(1, 2, 3);
				ulong2 inner = *(ulong2*)((ulong*)&outer + i);

				Assert.AreEqual(new Divider<ulong2>(inner), new Divider<ulong3>(outer).GetInnerDivider<ulong2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ulong4_ulong()
		{
			for (int i = 0; i < 4; i++)
			{
				ulong4 outer = new ulong4(1, 2, 3, 4);
				ulong inner = *((ulong*)&outer + i);

				Assert.AreEqual(new Divider<ulong>(inner), new Divider<ulong4>(outer).GetInnerDivider<ulong>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ulong4_ulong2()
		{
			for (int i = 0; i < 3; i++)
			{
				ulong4 outer = new ulong4(1, 2, 3, 4);
				ulong2 inner = *(ulong2*)((ulong*)&outer + i);

				Assert.AreEqual(new Divider<ulong2>(inner), new Divider<ulong4>(outer).GetInnerDivider<ulong2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_ulong4_ulong3()
		{
			for (int i = 0; i < 2; i++)
			{
				ulong4 outer = new ulong4(1, 2, 3, 4);
				ulong3 inner = *(ulong3*)((ulong*)&outer + i);

				Assert.AreEqual(new Divider<ulong3>(inner), new Divider<ulong4>(outer).GetInnerDivider<ulong3>(i));
			}
		}


		[Test]
		public static void GetInnerDivider_long2_long()
		{
			for (int i = 0; i < 2; i++)
			{
				long2 outer = new long2(1, 2);
				long inner = *((long*)&outer + i);

				Assert.AreEqual(new Divider<long>(inner), new Divider<long2>(outer).GetInnerDivider<long>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_long3_long()
		{
			for (int i = 0; i < 3; i++)
			{
				long3 outer = new long3(1, 2, 3);
				long inner = *((long*)&outer + i);

				Assert.AreEqual(new Divider<long>(inner), new Divider<long3>(outer).GetInnerDivider<long>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_long3_long2()
		{
			for (int i = 0; i < 2; i++)
			{
				long3 outer = new long3(1, 2, 3);
				long2 inner = *(long2*)((long*)&outer + i);

				Assert.AreEqual(new Divider<long2>(inner), new Divider<long3>(outer).GetInnerDivider<long2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_long4_long()
		{
			for (int i = 0; i < 4; i++)
			{
				long4 outer = new long4(1, 2, 3, 4);
				long inner = *((long*)&outer + i);

				Assert.AreEqual(new Divider<long>(inner), new Divider<long4>(outer).GetInnerDivider<long>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_long4_long2()
		{
			for (int i = 0; i < 3; i++)
			{
				long4 outer = new long4(1, 2, 3, 4);
				long2 inner = *(long2*)((long*)&outer + i);

				Assert.AreEqual(new Divider<long2>(inner), new Divider<long4>(outer).GetInnerDivider<long2>(i));
			}
		}

		[Test]
		public static void GetInnerDivider_long4_long3()
		{
			for (int i = 0; i < 2; i++)
			{
				long4 outer = new long4(1, 2, 3, 4);
				long3 inner = *(long3*)((long*)&outer + i);

				Assert.AreEqual(new Divider<long3>(inner), new Divider<long4>(outer).GetInnerDivider<long3>(i));
			}
		}
    }
}
