using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static partial class t_Divider
	{
		[Test]
		public static void get_xxxx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xxxx, new Divider<byte4>(new byte4(o8.x, o8.x, o8.x, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xxxx, new Divider<ushort4>(new ushort4(o16.x, o16.x, o16.x, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xxxx, new Divider<uint4>(new uint4(o32.x, o32.x, o32.x, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xxxx, new Divider<ulong4>(new ulong4(o64.x, o64.x, o64.x, o64.x)));
		}

		[Test]
		public static void get_xxxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xxxy, new Divider<byte4>(new byte4(o8.x, o8.x, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xxxy, new Divider<ushort4>(new ushort4(o16.x, o16.x, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xxxy, new Divider<uint4>(new uint4(o32.x, o32.x, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xxxy, new Divider<ulong4>(new ulong4(o64.x, o64.x, o64.x, o64.y)));
		}

		[Test]
		public static void get_xxxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xxxz, new Divider<byte4>(new byte4(o8.x, o8.x, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xxxz, new Divider<ushort4>(new ushort4(o16.x, o16.x, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xxxz, new Divider<uint4>(new uint4(o32.x, o32.x, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xxxz, new Divider<ulong4>(new ulong4(o64.x, o64.x, o64.x, o64.z)));
		}

		[Test]
		public static void get_xxxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xxxw, new Divider<byte4>(new byte4(o8.x, o8.x, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xxxw, new Divider<ushort4>(new ushort4(o16.x, o16.x, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xxxw, new Divider<uint4>(new uint4(o32.x, o32.x, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xxxw, new Divider<ulong4>(new ulong4(o64.x, o64.x, o64.x, o64.w)));
		}

		[Test]
		public static void get_xxyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xxyx, new Divider<byte4>(new byte4(o8.x, o8.x, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xxyx, new Divider<ushort4>(new ushort4(o16.x, o16.x, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xxyx, new Divider<uint4>(new uint4(o32.x, o32.x, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xxyx, new Divider<ulong4>(new ulong4(o64.x, o64.x, o64.y, o64.x)));
		}

		[Test]
		public static void get_xxyy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xxyy, new Divider<byte4>(new byte4(o8.x, o8.x, o8.y, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xxyy, new Divider<ushort4>(new ushort4(o16.x, o16.x, o16.y, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xxyy, new Divider<uint4>(new uint4(o32.x, o32.x, o32.y, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xxyy, new Divider<ulong4>(new ulong4(o64.x, o64.x, o64.y, o64.y)));
		}

		[Test]
		public static void get_xxyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xxyz, new Divider<byte4>(new byte4(o8.x, o8.x, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xxyz, new Divider<ushort4>(new ushort4(o16.x, o16.x, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xxyz, new Divider<uint4>(new uint4(o32.x, o32.x, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xxyz, new Divider<ulong4>(new ulong4(o64.x, o64.x, o64.y, o64.z)));
		}

		[Test]
		public static void get_xxyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xxyw, new Divider<byte4>(new byte4(o8.x, o8.x, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xxyw, new Divider<ushort4>(new ushort4(o16.x, o16.x, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xxyw, new Divider<uint4>(new uint4(o32.x, o32.x, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xxyw, new Divider<ulong4>(new ulong4(o64.x, o64.x, o64.y, o64.w)));
		}

		[Test]
		public static void get_xxzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xxzx, new Divider<byte4>(new byte4(o8.x, o8.x, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xxzx, new Divider<ushort4>(new ushort4(o16.x, o16.x, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xxzx, new Divider<uint4>(new uint4(o32.x, o32.x, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xxzx, new Divider<ulong4>(new ulong4(o64.x, o64.x, o64.z, o64.x)));
		}

		[Test]
		public static void get_xxzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xxzy, new Divider<byte4>(new byte4(o8.x, o8.x, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xxzy, new Divider<ushort4>(new ushort4(o16.x, o16.x, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xxzy, new Divider<uint4>(new uint4(o32.x, o32.x, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xxzy, new Divider<ulong4>(new ulong4(o64.x, o64.x, o64.z, o64.y)));
		}

		[Test]
		public static void get_xxzz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xxzz, new Divider<byte4>(new byte4(o8.x, o8.x, o8.z, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xxzz, new Divider<ushort4>(new ushort4(o16.x, o16.x, o16.z, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xxzz, new Divider<uint4>(new uint4(o32.x, o32.x, o32.z, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xxzz, new Divider<ulong4>(new ulong4(o64.x, o64.x, o64.z, o64.z)));
		}

		[Test]
		public static void get_xxzw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xxzw, new Divider<byte4>(new byte4(o8.x, o8.x, o8.z, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xxzw, new Divider<ushort4>(new ushort4(o16.x, o16.x, o16.z, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xxzw, new Divider<uint4>(new uint4(o32.x, o32.x, o32.z, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xxzw, new Divider<ulong4>(new ulong4(o64.x, o64.x, o64.z, o64.w)));
		}

		[Test]
		public static void get_xxwx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xxwx, new Divider<byte4>(new byte4(o8.x, o8.x, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xxwx, new Divider<ushort4>(new ushort4(o16.x, o16.x, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xxwx, new Divider<uint4>(new uint4(o32.x, o32.x, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xxwx, new Divider<ulong4>(new ulong4(o64.x, o64.x, o64.w, o64.x)));
		}

		[Test]
		public static void get_xxwy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xxwy, new Divider<byte4>(new byte4(o8.x, o8.x, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xxwy, new Divider<ushort4>(new ushort4(o16.x, o16.x, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xxwy, new Divider<uint4>(new uint4(o32.x, o32.x, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xxwy, new Divider<ulong4>(new ulong4(o64.x, o64.x, o64.w, o64.y)));
		}

		[Test]
		public static void get_xxwz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xxwz, new Divider<byte4>(new byte4(o8.x, o8.x, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xxwz, new Divider<ushort4>(new ushort4(o16.x, o16.x, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xxwz, new Divider<uint4>(new uint4(o32.x, o32.x, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xxwz, new Divider<ulong4>(new ulong4(o64.x, o64.x, o64.w, o64.z)));
		}

		[Test]
		public static void get_xxww()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xxww, new Divider<byte4>(new byte4(o8.x, o8.x, o8.w, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xxww, new Divider<ushort4>(new ushort4(o16.x, o16.x, o16.w, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xxww, new Divider<uint4>(new uint4(o32.x, o32.x, o32.w, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xxww, new Divider<ulong4>(new ulong4(o64.x, o64.x, o64.w, o64.w)));
		}

		[Test]
		public static void get_xyxx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xyxx, new Divider<byte4>(new byte4(o8.x, o8.y, o8.x, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xyxx, new Divider<ushort4>(new ushort4(o16.x, o16.y, o16.x, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xyxx, new Divider<uint4>(new uint4(o32.x, o32.y, o32.x, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xyxx, new Divider<ulong4>(new ulong4(o64.x, o64.y, o64.x, o64.x)));
		}

		[Test]
		public static void get_xyxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xyxy, new Divider<byte4>(new byte4(o8.x, o8.y, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xyxy, new Divider<ushort4>(new ushort4(o16.x, o16.y, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xyxy, new Divider<uint4>(new uint4(o32.x, o32.y, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xyxy, new Divider<ulong4>(new ulong4(o64.x, o64.y, o64.x, o64.y)));
		}

		[Test]
		public static void get_xyxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xyxz, new Divider<byte4>(new byte4(o8.x, o8.y, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xyxz, new Divider<ushort4>(new ushort4(o16.x, o16.y, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xyxz, new Divider<uint4>(new uint4(o32.x, o32.y, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xyxz, new Divider<ulong4>(new ulong4(o64.x, o64.y, o64.x, o64.z)));
		}

		[Test]
		public static void get_xyxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xyxw, new Divider<byte4>(new byte4(o8.x, o8.y, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xyxw, new Divider<ushort4>(new ushort4(o16.x, o16.y, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xyxw, new Divider<uint4>(new uint4(o32.x, o32.y, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xyxw, new Divider<ulong4>(new ulong4(o64.x, o64.y, o64.x, o64.w)));
		}

		[Test]
		public static void get_xyyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xyyx, new Divider<byte4>(new byte4(o8.x, o8.y, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xyyx, new Divider<ushort4>(new ushort4(o16.x, o16.y, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xyyx, new Divider<uint4>(new uint4(o32.x, o32.y, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xyyx, new Divider<ulong4>(new ulong4(o64.x, o64.y, o64.y, o64.x)));
		}

		[Test]
		public static void get_xyyy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xyyy, new Divider<byte4>(new byte4(o8.x, o8.y, o8.y, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xyyy, new Divider<ushort4>(new ushort4(o16.x, o16.y, o16.y, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xyyy, new Divider<uint4>(new uint4(o32.x, o32.y, o32.y, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xyyy, new Divider<ulong4>(new ulong4(o64.x, o64.y, o64.y, o64.y)));
		}

		[Test]
		public static void get_xyyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xyyz, new Divider<byte4>(new byte4(o8.x, o8.y, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xyyz, new Divider<ushort4>(new ushort4(o16.x, o16.y, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xyyz, new Divider<uint4>(new uint4(o32.x, o32.y, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xyyz, new Divider<ulong4>(new ulong4(o64.x, o64.y, o64.y, o64.z)));
		}

		[Test]
		public static void get_xyyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xyyw, new Divider<byte4>(new byte4(o8.x, o8.y, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xyyw, new Divider<ushort4>(new ushort4(o16.x, o16.y, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xyyw, new Divider<uint4>(new uint4(o32.x, o32.y, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xyyw, new Divider<ulong4>(new ulong4(o64.x, o64.y, o64.y, o64.w)));
		}

		[Test]
		public static void get_xyzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xyzx, new Divider<byte4>(new byte4(o8.x, o8.y, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xyzx, new Divider<ushort4>(new ushort4(o16.x, o16.y, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xyzx, new Divider<uint4>(new uint4(o32.x, o32.y, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xyzx, new Divider<ulong4>(new ulong4(o64.x, o64.y, o64.z, o64.x)));
		}

		[Test]
		public static void get_xyzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xyzy, new Divider<byte4>(new byte4(o8.x, o8.y, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xyzy, new Divider<ushort4>(new ushort4(o16.x, o16.y, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xyzy, new Divider<uint4>(new uint4(o32.x, o32.y, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xyzy, new Divider<ulong4>(new ulong4(o64.x, o64.y, o64.z, o64.y)));
		}

		[Test]
		public static void get_xyzz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xyzz, new Divider<byte4>(new byte4(o8.x, o8.y, o8.z, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xyzz, new Divider<ushort4>(new ushort4(o16.x, o16.y, o16.z, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xyzz, new Divider<uint4>(new uint4(o32.x, o32.y, o32.z, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xyzz, new Divider<ulong4>(new ulong4(o64.x, o64.y, o64.z, o64.z)));
		}

		[Test]
		public static void get_xywx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xywx, new Divider<byte4>(new byte4(o8.x, o8.y, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xywx, new Divider<ushort4>(new ushort4(o16.x, o16.y, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xywx, new Divider<uint4>(new uint4(o32.x, o32.y, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xywx, new Divider<ulong4>(new ulong4(o64.x, o64.y, o64.w, o64.x)));
		}

		[Test]
		public static void get_xywy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xywy, new Divider<byte4>(new byte4(o8.x, o8.y, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xywy, new Divider<ushort4>(new ushort4(o16.x, o16.y, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xywy, new Divider<uint4>(new uint4(o32.x, o32.y, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xywy, new Divider<ulong4>(new ulong4(o64.x, o64.y, o64.w, o64.y)));
		}

		[Test]
		public static void get_xywz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xywz, new Divider<byte4>(new byte4(o8.x, o8.y, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xywz, new Divider<ushort4>(new ushort4(o16.x, o16.y, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xywz, new Divider<uint4>(new uint4(o32.x, o32.y, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xywz, new Divider<ulong4>(new ulong4(o64.x, o64.y, o64.w, o64.z)));
		}

		[Test]
		public static void get_xyww()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xyww, new Divider<byte4>(new byte4(o8.x, o8.y, o8.w, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xyww, new Divider<ushort4>(new ushort4(o16.x, o16.y, o16.w, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xyww, new Divider<uint4>(new uint4(o32.x, o32.y, o32.w, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xyww, new Divider<ulong4>(new ulong4(o64.x, o64.y, o64.w, o64.w)));
		}

		[Test]
		public static void get_xzxx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xzxx, new Divider<byte4>(new byte4(o8.x, o8.z, o8.x, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xzxx, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.x, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xzxx, new Divider<uint4>(new uint4(o32.x, o32.z, o32.x, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xzxx, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.x, o64.x)));
		}

		[Test]
		public static void get_xzxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xzxy, new Divider<byte4>(new byte4(o8.x, o8.z, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xzxy, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xzxy, new Divider<uint4>(new uint4(o32.x, o32.z, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xzxy, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.x, o64.y)));
		}

		[Test]
		public static void get_xzxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xzxz, new Divider<byte4>(new byte4(o8.x, o8.z, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xzxz, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xzxz, new Divider<uint4>(new uint4(o32.x, o32.z, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xzxz, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.x, o64.z)));
		}

		[Test]
		public static void get_xzxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xzxw, new Divider<byte4>(new byte4(o8.x, o8.z, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xzxw, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xzxw, new Divider<uint4>(new uint4(o32.x, o32.z, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xzxw, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.x, o64.w)));
		}

		[Test]
		public static void get_xzyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xzyx, new Divider<byte4>(new byte4(o8.x, o8.z, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xzyx, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xzyx, new Divider<uint4>(new uint4(o32.x, o32.z, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xzyx, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.y, o64.x)));
		}

		[Test]
		public static void get_xzyy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xzyy, new Divider<byte4>(new byte4(o8.x, o8.z, o8.y, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xzyy, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.y, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xzyy, new Divider<uint4>(new uint4(o32.x, o32.z, o32.y, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xzyy, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.y, o64.y)));
		}

		[Test]
		public static void get_xzyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xzyz, new Divider<byte4>(new byte4(o8.x, o8.z, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xzyz, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xzyz, new Divider<uint4>(new uint4(o32.x, o32.z, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xzyz, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.y, o64.z)));
		}

		[Test]
		public static void get_xzyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xzyw, new Divider<byte4>(new byte4(o8.x, o8.z, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xzyw, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xzyw, new Divider<uint4>(new uint4(o32.x, o32.z, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xzyw, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.y, o64.w)));
		}

		[Test]
		public static void get_xzzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xzzx, new Divider<byte4>(new byte4(o8.x, o8.z, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xzzx, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xzzx, new Divider<uint4>(new uint4(o32.x, o32.z, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xzzx, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.z, o64.x)));
		}

		[Test]
		public static void get_xzzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xzzy, new Divider<byte4>(new byte4(o8.x, o8.z, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xzzy, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xzzy, new Divider<uint4>(new uint4(o32.x, o32.z, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xzzy, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.z, o64.y)));
		}

		[Test]
		public static void get_xzzz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xzzz, new Divider<byte4>(new byte4(o8.x, o8.z, o8.z, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xzzz, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.z, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xzzz, new Divider<uint4>(new uint4(o32.x, o32.z, o32.z, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xzzz, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.z, o64.z)));
		}

		[Test]
		public static void get_xzzw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xzzw, new Divider<byte4>(new byte4(o8.x, o8.z, o8.z, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xzzw, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.z, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xzzw, new Divider<uint4>(new uint4(o32.x, o32.z, o32.z, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xzzw, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.z, o64.w)));
		}

		[Test]
		public static void get_xzwx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xzwx, new Divider<byte4>(new byte4(o8.x, o8.z, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xzwx, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xzwx, new Divider<uint4>(new uint4(o32.x, o32.z, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xzwx, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.w, o64.x)));
		}

		[Test]
		public static void get_xzwy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xzwy, new Divider<byte4>(new byte4(o8.x, o8.z, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xzwy, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xzwy, new Divider<uint4>(new uint4(o32.x, o32.z, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xzwy, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.w, o64.y)));
		}

		[Test]
		public static void get_xzwz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xzwz, new Divider<byte4>(new byte4(o8.x, o8.z, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xzwz, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xzwz, new Divider<uint4>(new uint4(o32.x, o32.z, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xzwz, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.w, o64.z)));
		}

		[Test]
		public static void get_xzww()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xzww, new Divider<byte4>(new byte4(o8.x, o8.z, o8.w, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xzww, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.w, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xzww, new Divider<uint4>(new uint4(o32.x, o32.z, o32.w, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xzww, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.w, o64.w)));
		}

		[Test]
		public static void get_xwxx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xwxx, new Divider<byte4>(new byte4(o8.x, o8.w, o8.x, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xwxx, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.x, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xwxx, new Divider<uint4>(new uint4(o32.x, o32.w, o32.x, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xwxx, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.x, o64.x)));
		}

		[Test]
		public static void get_xwxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xwxy, new Divider<byte4>(new byte4(o8.x, o8.w, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xwxy, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xwxy, new Divider<uint4>(new uint4(o32.x, o32.w, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xwxy, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.x, o64.y)));
		}

		[Test]
		public static void get_xwxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xwxz, new Divider<byte4>(new byte4(o8.x, o8.w, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xwxz, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xwxz, new Divider<uint4>(new uint4(o32.x, o32.w, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xwxz, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.x, o64.z)));
		}

		[Test]
		public static void get_xwxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xwxw, new Divider<byte4>(new byte4(o8.x, o8.w, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xwxw, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xwxw, new Divider<uint4>(new uint4(o32.x, o32.w, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xwxw, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.x, o64.w)));
		}

		[Test]
		public static void get_xwyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xwyx, new Divider<byte4>(new byte4(o8.x, o8.w, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xwyx, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xwyx, new Divider<uint4>(new uint4(o32.x, o32.w, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xwyx, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.y, o64.x)));
		}

		[Test]
		public static void get_xwyy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xwyy, new Divider<byte4>(new byte4(o8.x, o8.w, o8.y, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xwyy, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.y, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xwyy, new Divider<uint4>(new uint4(o32.x, o32.w, o32.y, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xwyy, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.y, o64.y)));
		}

		[Test]
		public static void get_xwyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xwyz, new Divider<byte4>(new byte4(o8.x, o8.w, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xwyz, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xwyz, new Divider<uint4>(new uint4(o32.x, o32.w, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xwyz, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.y, o64.z)));
		}

		[Test]
		public static void get_xwyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xwyw, new Divider<byte4>(new byte4(o8.x, o8.w, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xwyw, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xwyw, new Divider<uint4>(new uint4(o32.x, o32.w, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xwyw, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.y, o64.w)));
		}

		[Test]
		public static void get_xwzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xwzx, new Divider<byte4>(new byte4(o8.x, o8.w, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xwzx, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xwzx, new Divider<uint4>(new uint4(o32.x, o32.w, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xwzx, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.z, o64.x)));
		}

		[Test]
		public static void get_xwzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xwzy, new Divider<byte4>(new byte4(o8.x, o8.w, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xwzy, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xwzy, new Divider<uint4>(new uint4(o32.x, o32.w, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xwzy, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.z, o64.y)));
		}

		[Test]
		public static void get_xwzz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xwzz, new Divider<byte4>(new byte4(o8.x, o8.w, o8.z, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xwzz, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.z, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xwzz, new Divider<uint4>(new uint4(o32.x, o32.w, o32.z, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xwzz, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.z, o64.z)));
		}

		[Test]
		public static void get_xwzw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xwzw, new Divider<byte4>(new byte4(o8.x, o8.w, o8.z, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xwzw, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.z, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xwzw, new Divider<uint4>(new uint4(o32.x, o32.w, o32.z, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xwzw, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.z, o64.w)));
		}

		[Test]
		public static void get_xwwx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xwwx, new Divider<byte4>(new byte4(o8.x, o8.w, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xwwx, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xwwx, new Divider<uint4>(new uint4(o32.x, o32.w, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xwwx, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.w, o64.x)));
		}

		[Test]
		public static void get_xwwy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xwwy, new Divider<byte4>(new byte4(o8.x, o8.w, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xwwy, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xwwy, new Divider<uint4>(new uint4(o32.x, o32.w, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xwwy, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.w, o64.y)));
		}

		[Test]
		public static void get_xwwz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xwwz, new Divider<byte4>(new byte4(o8.x, o8.w, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xwwz, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xwwz, new Divider<uint4>(new uint4(o32.x, o32.w, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xwwz, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.w, o64.z)));
		}

		[Test]
		public static void get_xwww()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).xwww, new Divider<byte4>(new byte4(o8.x, o8.w, o8.w, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).xwww, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.w, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).xwww, new Divider<uint4>(new uint4(o32.x, o32.w, o32.w, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).xwww, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.w, o64.w)));
		}

		[Test]
		public static void get_yxxx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yxxx, new Divider<byte4>(new byte4(o8.y, o8.x, o8.x, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yxxx, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.x, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yxxx, new Divider<uint4>(new uint4(o32.y, o32.x, o32.x, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yxxx, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.x, o64.x)));
		}

		[Test]
		public static void get_yxxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yxxy, new Divider<byte4>(new byte4(o8.y, o8.x, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yxxy, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yxxy, new Divider<uint4>(new uint4(o32.y, o32.x, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yxxy, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.x, o64.y)));
		}

		[Test]
		public static void get_yxxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yxxz, new Divider<byte4>(new byte4(o8.y, o8.x, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yxxz, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yxxz, new Divider<uint4>(new uint4(o32.y, o32.x, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yxxz, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.x, o64.z)));
		}

		[Test]
		public static void get_yxxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yxxw, new Divider<byte4>(new byte4(o8.y, o8.x, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yxxw, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yxxw, new Divider<uint4>(new uint4(o32.y, o32.x, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yxxw, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.x, o64.w)));
		}

		[Test]
		public static void get_yxyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yxyx, new Divider<byte4>(new byte4(o8.y, o8.x, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yxyx, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yxyx, new Divider<uint4>(new uint4(o32.y, o32.x, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yxyx, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.y, o64.x)));
		}

		[Test]
		public static void get_yxyy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yxyy, new Divider<byte4>(new byte4(o8.y, o8.x, o8.y, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yxyy, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.y, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yxyy, new Divider<uint4>(new uint4(o32.y, o32.x, o32.y, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yxyy, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.y, o64.y)));
		}

		[Test]
		public static void get_yxyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yxyz, new Divider<byte4>(new byte4(o8.y, o8.x, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yxyz, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yxyz, new Divider<uint4>(new uint4(o32.y, o32.x, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yxyz, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.y, o64.z)));
		}

		[Test]
		public static void get_yxyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yxyw, new Divider<byte4>(new byte4(o8.y, o8.x, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yxyw, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yxyw, new Divider<uint4>(new uint4(o32.y, o32.x, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yxyw, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.y, o64.w)));
		}

		[Test]
		public static void get_yxzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yxzx, new Divider<byte4>(new byte4(o8.y, o8.x, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yxzx, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yxzx, new Divider<uint4>(new uint4(o32.y, o32.x, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yxzx, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.z, o64.x)));
		}

		[Test]
		public static void get_yxzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yxzy, new Divider<byte4>(new byte4(o8.y, o8.x, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yxzy, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yxzy, new Divider<uint4>(new uint4(o32.y, o32.x, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yxzy, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.z, o64.y)));
		}

		[Test]
		public static void get_yxzz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yxzz, new Divider<byte4>(new byte4(o8.y, o8.x, o8.z, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yxzz, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.z, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yxzz, new Divider<uint4>(new uint4(o32.y, o32.x, o32.z, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yxzz, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.z, o64.z)));
		}

		[Test]
		public static void get_yxzw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yxzw, new Divider<byte4>(new byte4(o8.y, o8.x, o8.z, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yxzw, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.z, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yxzw, new Divider<uint4>(new uint4(o32.y, o32.x, o32.z, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yxzw, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.z, o64.w)));
		}

		[Test]
		public static void get_yxwx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yxwx, new Divider<byte4>(new byte4(o8.y, o8.x, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yxwx, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yxwx, new Divider<uint4>(new uint4(o32.y, o32.x, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yxwx, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.w, o64.x)));
		}

		[Test]
		public static void get_yxwy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yxwy, new Divider<byte4>(new byte4(o8.y, o8.x, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yxwy, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yxwy, new Divider<uint4>(new uint4(o32.y, o32.x, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yxwy, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.w, o64.y)));
		}

		[Test]
		public static void get_yxwz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yxwz, new Divider<byte4>(new byte4(o8.y, o8.x, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yxwz, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yxwz, new Divider<uint4>(new uint4(o32.y, o32.x, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yxwz, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.w, o64.z)));
		}

		[Test]
		public static void get_yxww()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yxww, new Divider<byte4>(new byte4(o8.y, o8.x, o8.w, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yxww, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.w, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yxww, new Divider<uint4>(new uint4(o32.y, o32.x, o32.w, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yxww, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.w, o64.w)));
		}

		[Test]
		public static void get_yyxx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yyxx, new Divider<byte4>(new byte4(o8.y, o8.y, o8.x, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yyxx, new Divider<ushort4>(new ushort4(o16.y, o16.y, o16.x, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yyxx, new Divider<uint4>(new uint4(o32.y, o32.y, o32.x, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yyxx, new Divider<ulong4>(new ulong4(o64.y, o64.y, o64.x, o64.x)));
		}

		[Test]
		public static void get_yyxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yyxy, new Divider<byte4>(new byte4(o8.y, o8.y, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yyxy, new Divider<ushort4>(new ushort4(o16.y, o16.y, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yyxy, new Divider<uint4>(new uint4(o32.y, o32.y, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yyxy, new Divider<ulong4>(new ulong4(o64.y, o64.y, o64.x, o64.y)));
		}

		[Test]
		public static void get_yyxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yyxz, new Divider<byte4>(new byte4(o8.y, o8.y, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yyxz, new Divider<ushort4>(new ushort4(o16.y, o16.y, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yyxz, new Divider<uint4>(new uint4(o32.y, o32.y, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yyxz, new Divider<ulong4>(new ulong4(o64.y, o64.y, o64.x, o64.z)));
		}

		[Test]
		public static void get_yyxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yyxw, new Divider<byte4>(new byte4(o8.y, o8.y, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yyxw, new Divider<ushort4>(new ushort4(o16.y, o16.y, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yyxw, new Divider<uint4>(new uint4(o32.y, o32.y, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yyxw, new Divider<ulong4>(new ulong4(o64.y, o64.y, o64.x, o64.w)));
		}

		[Test]
		public static void get_yyyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yyyx, new Divider<byte4>(new byte4(o8.y, o8.y, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yyyx, new Divider<ushort4>(new ushort4(o16.y, o16.y, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yyyx, new Divider<uint4>(new uint4(o32.y, o32.y, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yyyx, new Divider<ulong4>(new ulong4(o64.y, o64.y, o64.y, o64.x)));
		}

		[Test]
		public static void get_yyyy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yyyy, new Divider<byte4>(new byte4(o8.y, o8.y, o8.y, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yyyy, new Divider<ushort4>(new ushort4(o16.y, o16.y, o16.y, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yyyy, new Divider<uint4>(new uint4(o32.y, o32.y, o32.y, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yyyy, new Divider<ulong4>(new ulong4(o64.y, o64.y, o64.y, o64.y)));
		}

		[Test]
		public static void get_yyyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yyyz, new Divider<byte4>(new byte4(o8.y, o8.y, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yyyz, new Divider<ushort4>(new ushort4(o16.y, o16.y, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yyyz, new Divider<uint4>(new uint4(o32.y, o32.y, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yyyz, new Divider<ulong4>(new ulong4(o64.y, o64.y, o64.y, o64.z)));
		}

		[Test]
		public static void get_yyyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yyyw, new Divider<byte4>(new byte4(o8.y, o8.y, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yyyw, new Divider<ushort4>(new ushort4(o16.y, o16.y, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yyyw, new Divider<uint4>(new uint4(o32.y, o32.y, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yyyw, new Divider<ulong4>(new ulong4(o64.y, o64.y, o64.y, o64.w)));
		}

		[Test]
		public static void get_yyzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yyzx, new Divider<byte4>(new byte4(o8.y, o8.y, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yyzx, new Divider<ushort4>(new ushort4(o16.y, o16.y, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yyzx, new Divider<uint4>(new uint4(o32.y, o32.y, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yyzx, new Divider<ulong4>(new ulong4(o64.y, o64.y, o64.z, o64.x)));
		}

		[Test]
		public static void get_yyzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yyzy, new Divider<byte4>(new byte4(o8.y, o8.y, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yyzy, new Divider<ushort4>(new ushort4(o16.y, o16.y, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yyzy, new Divider<uint4>(new uint4(o32.y, o32.y, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yyzy, new Divider<ulong4>(new ulong4(o64.y, o64.y, o64.z, o64.y)));
		}

		[Test]
		public static void get_yyzz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yyzz, new Divider<byte4>(new byte4(o8.y, o8.y, o8.z, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yyzz, new Divider<ushort4>(new ushort4(o16.y, o16.y, o16.z, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yyzz, new Divider<uint4>(new uint4(o32.y, o32.y, o32.z, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yyzz, new Divider<ulong4>(new ulong4(o64.y, o64.y, o64.z, o64.z)));
		}

		[Test]
		public static void get_yyzw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yyzw, new Divider<byte4>(new byte4(o8.y, o8.y, o8.z, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yyzw, new Divider<ushort4>(new ushort4(o16.y, o16.y, o16.z, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yyzw, new Divider<uint4>(new uint4(o32.y, o32.y, o32.z, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yyzw, new Divider<ulong4>(new ulong4(o64.y, o64.y, o64.z, o64.w)));
		}

		[Test]
		public static void get_yywx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yywx, new Divider<byte4>(new byte4(o8.y, o8.y, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yywx, new Divider<ushort4>(new ushort4(o16.y, o16.y, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yywx, new Divider<uint4>(new uint4(o32.y, o32.y, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yywx, new Divider<ulong4>(new ulong4(o64.y, o64.y, o64.w, o64.x)));
		}

		[Test]
		public static void get_yywy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yywy, new Divider<byte4>(new byte4(o8.y, o8.y, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yywy, new Divider<ushort4>(new ushort4(o16.y, o16.y, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yywy, new Divider<uint4>(new uint4(o32.y, o32.y, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yywy, new Divider<ulong4>(new ulong4(o64.y, o64.y, o64.w, o64.y)));
		}

		[Test]
		public static void get_yywz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yywz, new Divider<byte4>(new byte4(o8.y, o8.y, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yywz, new Divider<ushort4>(new ushort4(o16.y, o16.y, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yywz, new Divider<uint4>(new uint4(o32.y, o32.y, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yywz, new Divider<ulong4>(new ulong4(o64.y, o64.y, o64.w, o64.z)));
		}

		[Test]
		public static void get_yyww()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yyww, new Divider<byte4>(new byte4(o8.y, o8.y, o8.w, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yyww, new Divider<ushort4>(new ushort4(o16.y, o16.y, o16.w, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yyww, new Divider<uint4>(new uint4(o32.y, o32.y, o32.w, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yyww, new Divider<ulong4>(new ulong4(o64.y, o64.y, o64.w, o64.w)));
		}

		[Test]
		public static void get_yzxx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yzxx, new Divider<byte4>(new byte4(o8.y, o8.z, o8.x, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yzxx, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.x, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yzxx, new Divider<uint4>(new uint4(o32.y, o32.z, o32.x, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yzxx, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.x, o64.x)));
		}

		[Test]
		public static void get_yzxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yzxy, new Divider<byte4>(new byte4(o8.y, o8.z, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yzxy, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yzxy, new Divider<uint4>(new uint4(o32.y, o32.z, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yzxy, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.x, o64.y)));
		}

		[Test]
		public static void get_yzxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yzxz, new Divider<byte4>(new byte4(o8.y, o8.z, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yzxz, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yzxz, new Divider<uint4>(new uint4(o32.y, o32.z, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yzxz, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.x, o64.z)));
		}

		[Test]
		public static void get_yzxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yzxw, new Divider<byte4>(new byte4(o8.y, o8.z, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yzxw, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yzxw, new Divider<uint4>(new uint4(o32.y, o32.z, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yzxw, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.x, o64.w)));
		}

		[Test]
		public static void get_yzyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yzyx, new Divider<byte4>(new byte4(o8.y, o8.z, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yzyx, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yzyx, new Divider<uint4>(new uint4(o32.y, o32.z, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yzyx, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.y, o64.x)));
		}

		[Test]
		public static void get_yzyy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yzyy, new Divider<byte4>(new byte4(o8.y, o8.z, o8.y, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yzyy, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.y, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yzyy, new Divider<uint4>(new uint4(o32.y, o32.z, o32.y, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yzyy, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.y, o64.y)));
		}

		[Test]
		public static void get_yzyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yzyz, new Divider<byte4>(new byte4(o8.y, o8.z, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yzyz, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yzyz, new Divider<uint4>(new uint4(o32.y, o32.z, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yzyz, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.y, o64.z)));
		}

		[Test]
		public static void get_yzyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yzyw, new Divider<byte4>(new byte4(o8.y, o8.z, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yzyw, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yzyw, new Divider<uint4>(new uint4(o32.y, o32.z, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yzyw, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.y, o64.w)));
		}

		[Test]
		public static void get_yzzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yzzx, new Divider<byte4>(new byte4(o8.y, o8.z, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yzzx, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yzzx, new Divider<uint4>(new uint4(o32.y, o32.z, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yzzx, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.z, o64.x)));
		}

		[Test]
		public static void get_yzzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yzzy, new Divider<byte4>(new byte4(o8.y, o8.z, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yzzy, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yzzy, new Divider<uint4>(new uint4(o32.y, o32.z, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yzzy, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.z, o64.y)));
		}

		[Test]
		public static void get_yzzz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yzzz, new Divider<byte4>(new byte4(o8.y, o8.z, o8.z, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yzzz, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.z, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yzzz, new Divider<uint4>(new uint4(o32.y, o32.z, o32.z, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yzzz, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.z, o64.z)));
		}

		[Test]
		public static void get_yzzw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yzzw, new Divider<byte4>(new byte4(o8.y, o8.z, o8.z, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yzzw, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.z, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yzzw, new Divider<uint4>(new uint4(o32.y, o32.z, o32.z, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yzzw, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.z, o64.w)));
		}

		[Test]
		public static void get_yzwx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yzwx, new Divider<byte4>(new byte4(o8.y, o8.z, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yzwx, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yzwx, new Divider<uint4>(new uint4(o32.y, o32.z, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yzwx, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.w, o64.x)));
		}

		[Test]
		public static void get_yzwy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yzwy, new Divider<byte4>(new byte4(o8.y, o8.z, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yzwy, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yzwy, new Divider<uint4>(new uint4(o32.y, o32.z, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yzwy, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.w, o64.y)));
		}

		[Test]
		public static void get_yzwz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yzwz, new Divider<byte4>(new byte4(o8.y, o8.z, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yzwz, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yzwz, new Divider<uint4>(new uint4(o32.y, o32.z, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yzwz, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.w, o64.z)));
		}

		[Test]
		public static void get_yzww()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).yzww, new Divider<byte4>(new byte4(o8.y, o8.z, o8.w, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).yzww, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.w, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).yzww, new Divider<uint4>(new uint4(o32.y, o32.z, o32.w, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).yzww, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.w, o64.w)));
		}

		[Test]
		public static void get_ywxx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).ywxx, new Divider<byte4>(new byte4(o8.y, o8.w, o8.x, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).ywxx, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.x, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).ywxx, new Divider<uint4>(new uint4(o32.y, o32.w, o32.x, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).ywxx, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.x, o64.x)));
		}

		[Test]
		public static void get_ywxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).ywxy, new Divider<byte4>(new byte4(o8.y, o8.w, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).ywxy, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).ywxy, new Divider<uint4>(new uint4(o32.y, o32.w, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).ywxy, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.x, o64.y)));
		}

		[Test]
		public static void get_ywxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).ywxz, new Divider<byte4>(new byte4(o8.y, o8.w, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).ywxz, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).ywxz, new Divider<uint4>(new uint4(o32.y, o32.w, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).ywxz, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.x, o64.z)));
		}

		[Test]
		public static void get_ywxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).ywxw, new Divider<byte4>(new byte4(o8.y, o8.w, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).ywxw, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).ywxw, new Divider<uint4>(new uint4(o32.y, o32.w, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).ywxw, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.x, o64.w)));
		}

		[Test]
		public static void get_ywyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).ywyx, new Divider<byte4>(new byte4(o8.y, o8.w, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).ywyx, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).ywyx, new Divider<uint4>(new uint4(o32.y, o32.w, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).ywyx, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.y, o64.x)));
		}

		[Test]
		public static void get_ywyy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).ywyy, new Divider<byte4>(new byte4(o8.y, o8.w, o8.y, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).ywyy, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.y, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).ywyy, new Divider<uint4>(new uint4(o32.y, o32.w, o32.y, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).ywyy, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.y, o64.y)));
		}

		[Test]
		public static void get_ywyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).ywyz, new Divider<byte4>(new byte4(o8.y, o8.w, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).ywyz, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).ywyz, new Divider<uint4>(new uint4(o32.y, o32.w, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).ywyz, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.y, o64.z)));
		}

		[Test]
		public static void get_ywyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).ywyw, new Divider<byte4>(new byte4(o8.y, o8.w, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).ywyw, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).ywyw, new Divider<uint4>(new uint4(o32.y, o32.w, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).ywyw, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.y, o64.w)));
		}

		[Test]
		public static void get_ywzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).ywzx, new Divider<byte4>(new byte4(o8.y, o8.w, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).ywzx, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).ywzx, new Divider<uint4>(new uint4(o32.y, o32.w, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).ywzx, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.z, o64.x)));
		}

		[Test]
		public static void get_ywzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).ywzy, new Divider<byte4>(new byte4(o8.y, o8.w, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).ywzy, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).ywzy, new Divider<uint4>(new uint4(o32.y, o32.w, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).ywzy, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.z, o64.y)));
		}

		[Test]
		public static void get_ywzz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).ywzz, new Divider<byte4>(new byte4(o8.y, o8.w, o8.z, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).ywzz, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.z, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).ywzz, new Divider<uint4>(new uint4(o32.y, o32.w, o32.z, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).ywzz, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.z, o64.z)));
		}

		[Test]
		public static void get_ywzw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).ywzw, new Divider<byte4>(new byte4(o8.y, o8.w, o8.z, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).ywzw, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.z, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).ywzw, new Divider<uint4>(new uint4(o32.y, o32.w, o32.z, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).ywzw, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.z, o64.w)));
		}

		[Test]
		public static void get_ywwx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).ywwx, new Divider<byte4>(new byte4(o8.y, o8.w, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).ywwx, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).ywwx, new Divider<uint4>(new uint4(o32.y, o32.w, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).ywwx, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.w, o64.x)));
		}

		[Test]
		public static void get_ywwy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).ywwy, new Divider<byte4>(new byte4(o8.y, o8.w, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).ywwy, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).ywwy, new Divider<uint4>(new uint4(o32.y, o32.w, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).ywwy, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.w, o64.y)));
		}

		[Test]
		public static void get_ywwz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).ywwz, new Divider<byte4>(new byte4(o8.y, o8.w, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).ywwz, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).ywwz, new Divider<uint4>(new uint4(o32.y, o32.w, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).ywwz, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.w, o64.z)));
		}

		[Test]
		public static void get_ywww()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).ywww, new Divider<byte4>(new byte4(o8.y, o8.w, o8.w, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).ywww, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.w, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).ywww, new Divider<uint4>(new uint4(o32.y, o32.w, o32.w, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).ywww, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.w, o64.w)));
		}

		[Test]
		public static void get_zxxx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zxxx, new Divider<byte4>(new byte4(o8.z, o8.x, o8.x, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zxxx, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.x, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zxxx, new Divider<uint4>(new uint4(o32.z, o32.x, o32.x, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zxxx, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.x, o64.x)));
		}

		[Test]
		public static void get_zxxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zxxy, new Divider<byte4>(new byte4(o8.z, o8.x, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zxxy, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zxxy, new Divider<uint4>(new uint4(o32.z, o32.x, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zxxy, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.x, o64.y)));
		}

		[Test]
		public static void get_zxxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zxxz, new Divider<byte4>(new byte4(o8.z, o8.x, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zxxz, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zxxz, new Divider<uint4>(new uint4(o32.z, o32.x, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zxxz, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.x, o64.z)));
		}

		[Test]
		public static void get_zxxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zxxw, new Divider<byte4>(new byte4(o8.z, o8.x, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zxxw, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zxxw, new Divider<uint4>(new uint4(o32.z, o32.x, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zxxw, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.x, o64.w)));
		}

		[Test]
		public static void get_zxyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zxyx, new Divider<byte4>(new byte4(o8.z, o8.x, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zxyx, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zxyx, new Divider<uint4>(new uint4(o32.z, o32.x, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zxyx, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.y, o64.x)));
		}

		[Test]
		public static void get_zxyy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zxyy, new Divider<byte4>(new byte4(o8.z, o8.x, o8.y, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zxyy, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.y, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zxyy, new Divider<uint4>(new uint4(o32.z, o32.x, o32.y, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zxyy, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.y, o64.y)));
		}

		[Test]
		public static void get_zxyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zxyz, new Divider<byte4>(new byte4(o8.z, o8.x, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zxyz, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zxyz, new Divider<uint4>(new uint4(o32.z, o32.x, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zxyz, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.y, o64.z)));
		}

		[Test]
		public static void get_zxyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zxyw, new Divider<byte4>(new byte4(o8.z, o8.x, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zxyw, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zxyw, new Divider<uint4>(new uint4(o32.z, o32.x, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zxyw, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.y, o64.w)));
		}

		[Test]
		public static void get_zxzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zxzx, new Divider<byte4>(new byte4(o8.z, o8.x, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zxzx, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zxzx, new Divider<uint4>(new uint4(o32.z, o32.x, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zxzx, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.z, o64.x)));
		}

		[Test]
		public static void get_zxzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zxzy, new Divider<byte4>(new byte4(o8.z, o8.x, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zxzy, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zxzy, new Divider<uint4>(new uint4(o32.z, o32.x, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zxzy, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.z, o64.y)));
		}

		[Test]
		public static void get_zxzz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zxzz, new Divider<byte4>(new byte4(o8.z, o8.x, o8.z, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zxzz, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.z, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zxzz, new Divider<uint4>(new uint4(o32.z, o32.x, o32.z, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zxzz, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.z, o64.z)));
		}

		[Test]
		public static void get_zxzw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zxzw, new Divider<byte4>(new byte4(o8.z, o8.x, o8.z, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zxzw, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.z, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zxzw, new Divider<uint4>(new uint4(o32.z, o32.x, o32.z, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zxzw, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.z, o64.w)));
		}

		[Test]
		public static void get_zxwx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zxwx, new Divider<byte4>(new byte4(o8.z, o8.x, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zxwx, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zxwx, new Divider<uint4>(new uint4(o32.z, o32.x, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zxwx, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.w, o64.x)));
		}

		[Test]
		public static void get_zxwy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zxwy, new Divider<byte4>(new byte4(o8.z, o8.x, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zxwy, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zxwy, new Divider<uint4>(new uint4(o32.z, o32.x, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zxwy, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.w, o64.y)));
		}

		[Test]
		public static void get_zxwz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zxwz, new Divider<byte4>(new byte4(o8.z, o8.x, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zxwz, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zxwz, new Divider<uint4>(new uint4(o32.z, o32.x, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zxwz, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.w, o64.z)));
		}

		[Test]
		public static void get_zxww()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zxww, new Divider<byte4>(new byte4(o8.z, o8.x, o8.w, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zxww, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.w, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zxww, new Divider<uint4>(new uint4(o32.z, o32.x, o32.w, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zxww, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.w, o64.w)));
		}

		[Test]
		public static void get_zyxx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zyxx, new Divider<byte4>(new byte4(o8.z, o8.y, o8.x, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zyxx, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.x, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zyxx, new Divider<uint4>(new uint4(o32.z, o32.y, o32.x, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zyxx, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.x, o64.x)));
		}

		[Test]
		public static void get_zyxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zyxy, new Divider<byte4>(new byte4(o8.z, o8.y, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zyxy, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zyxy, new Divider<uint4>(new uint4(o32.z, o32.y, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zyxy, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.x, o64.y)));
		}

		[Test]
		public static void get_zyxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zyxz, new Divider<byte4>(new byte4(o8.z, o8.y, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zyxz, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zyxz, new Divider<uint4>(new uint4(o32.z, o32.y, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zyxz, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.x, o64.z)));
		}

		[Test]
		public static void get_zyxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zyxw, new Divider<byte4>(new byte4(o8.z, o8.y, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zyxw, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zyxw, new Divider<uint4>(new uint4(o32.z, o32.y, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zyxw, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.x, o64.w)));
		}

		[Test]
		public static void get_zyyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zyyx, new Divider<byte4>(new byte4(o8.z, o8.y, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zyyx, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zyyx, new Divider<uint4>(new uint4(o32.z, o32.y, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zyyx, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.y, o64.x)));
		}

		[Test]
		public static void get_zyyy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zyyy, new Divider<byte4>(new byte4(o8.z, o8.y, o8.y, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zyyy, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.y, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zyyy, new Divider<uint4>(new uint4(o32.z, o32.y, o32.y, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zyyy, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.y, o64.y)));
		}

		[Test]
		public static void get_zyyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zyyz, new Divider<byte4>(new byte4(o8.z, o8.y, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zyyz, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zyyz, new Divider<uint4>(new uint4(o32.z, o32.y, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zyyz, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.y, o64.z)));
		}

		[Test]
		public static void get_zyyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zyyw, new Divider<byte4>(new byte4(o8.z, o8.y, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zyyw, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zyyw, new Divider<uint4>(new uint4(o32.z, o32.y, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zyyw, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.y, o64.w)));
		}

		[Test]
		public static void get_zyzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zyzx, new Divider<byte4>(new byte4(o8.z, o8.y, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zyzx, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zyzx, new Divider<uint4>(new uint4(o32.z, o32.y, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zyzx, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.z, o64.x)));
		}

		[Test]
		public static void get_zyzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zyzy, new Divider<byte4>(new byte4(o8.z, o8.y, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zyzy, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zyzy, new Divider<uint4>(new uint4(o32.z, o32.y, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zyzy, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.z, o64.y)));
		}

		[Test]
		public static void get_zyzz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zyzz, new Divider<byte4>(new byte4(o8.z, o8.y, o8.z, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zyzz, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.z, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zyzz, new Divider<uint4>(new uint4(o32.z, o32.y, o32.z, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zyzz, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.z, o64.z)));
		}

		[Test]
		public static void get_zyzw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zyzw, new Divider<byte4>(new byte4(o8.z, o8.y, o8.z, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zyzw, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.z, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zyzw, new Divider<uint4>(new uint4(o32.z, o32.y, o32.z, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zyzw, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.z, o64.w)));
		}

		[Test]
		public static void get_zywx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zywx, new Divider<byte4>(new byte4(o8.z, o8.y, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zywx, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zywx, new Divider<uint4>(new uint4(o32.z, o32.y, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zywx, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.w, o64.x)));
		}

		[Test]
		public static void get_zywy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zywy, new Divider<byte4>(new byte4(o8.z, o8.y, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zywy, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zywy, new Divider<uint4>(new uint4(o32.z, o32.y, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zywy, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.w, o64.y)));
		}

		[Test]
		public static void get_zywz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zywz, new Divider<byte4>(new byte4(o8.z, o8.y, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zywz, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zywz, new Divider<uint4>(new uint4(o32.z, o32.y, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zywz, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.w, o64.z)));
		}

		[Test]
		public static void get_zyww()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zyww, new Divider<byte4>(new byte4(o8.z, o8.y, o8.w, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zyww, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.w, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zyww, new Divider<uint4>(new uint4(o32.z, o32.y, o32.w, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zyww, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.w, o64.w)));
		}

		[Test]
		public static void get_zzxx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zzxx, new Divider<byte4>(new byte4(o8.z, o8.z, o8.x, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zzxx, new Divider<ushort4>(new ushort4(o16.z, o16.z, o16.x, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zzxx, new Divider<uint4>(new uint4(o32.z, o32.z, o32.x, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zzxx, new Divider<ulong4>(new ulong4(o64.z, o64.z, o64.x, o64.x)));
		}

		[Test]
		public static void get_zzxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zzxy, new Divider<byte4>(new byte4(o8.z, o8.z, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zzxy, new Divider<ushort4>(new ushort4(o16.z, o16.z, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zzxy, new Divider<uint4>(new uint4(o32.z, o32.z, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zzxy, new Divider<ulong4>(new ulong4(o64.z, o64.z, o64.x, o64.y)));
		}

		[Test]
		public static void get_zzxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zzxz, new Divider<byte4>(new byte4(o8.z, o8.z, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zzxz, new Divider<ushort4>(new ushort4(o16.z, o16.z, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zzxz, new Divider<uint4>(new uint4(o32.z, o32.z, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zzxz, new Divider<ulong4>(new ulong4(o64.z, o64.z, o64.x, o64.z)));
		}

		[Test]
		public static void get_zzxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zzxw, new Divider<byte4>(new byte4(o8.z, o8.z, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zzxw, new Divider<ushort4>(new ushort4(o16.z, o16.z, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zzxw, new Divider<uint4>(new uint4(o32.z, o32.z, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zzxw, new Divider<ulong4>(new ulong4(o64.z, o64.z, o64.x, o64.w)));
		}

		[Test]
		public static void get_zzyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zzyx, new Divider<byte4>(new byte4(o8.z, o8.z, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zzyx, new Divider<ushort4>(new ushort4(o16.z, o16.z, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zzyx, new Divider<uint4>(new uint4(o32.z, o32.z, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zzyx, new Divider<ulong4>(new ulong4(o64.z, o64.z, o64.y, o64.x)));
		}

		[Test]
		public static void get_zzyy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zzyy, new Divider<byte4>(new byte4(o8.z, o8.z, o8.y, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zzyy, new Divider<ushort4>(new ushort4(o16.z, o16.z, o16.y, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zzyy, new Divider<uint4>(new uint4(o32.z, o32.z, o32.y, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zzyy, new Divider<ulong4>(new ulong4(o64.z, o64.z, o64.y, o64.y)));
		}

		[Test]
		public static void get_zzyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zzyz, new Divider<byte4>(new byte4(o8.z, o8.z, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zzyz, new Divider<ushort4>(new ushort4(o16.z, o16.z, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zzyz, new Divider<uint4>(new uint4(o32.z, o32.z, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zzyz, new Divider<ulong4>(new ulong4(o64.z, o64.z, o64.y, o64.z)));
		}

		[Test]
		public static void get_zzyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zzyw, new Divider<byte4>(new byte4(o8.z, o8.z, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zzyw, new Divider<ushort4>(new ushort4(o16.z, o16.z, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zzyw, new Divider<uint4>(new uint4(o32.z, o32.z, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zzyw, new Divider<ulong4>(new ulong4(o64.z, o64.z, o64.y, o64.w)));
		}

		[Test]
		public static void get_zzzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zzzx, new Divider<byte4>(new byte4(o8.z, o8.z, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zzzx, new Divider<ushort4>(new ushort4(o16.z, o16.z, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zzzx, new Divider<uint4>(new uint4(o32.z, o32.z, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zzzx, new Divider<ulong4>(new ulong4(o64.z, o64.z, o64.z, o64.x)));
		}

		[Test]
		public static void get_zzzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zzzy, new Divider<byte4>(new byte4(o8.z, o8.z, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zzzy, new Divider<ushort4>(new ushort4(o16.z, o16.z, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zzzy, new Divider<uint4>(new uint4(o32.z, o32.z, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zzzy, new Divider<ulong4>(new ulong4(o64.z, o64.z, o64.z, o64.y)));
		}

		[Test]
		public static void get_zzzz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zzzz, new Divider<byte4>(new byte4(o8.z, o8.z, o8.z, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zzzz, new Divider<ushort4>(new ushort4(o16.z, o16.z, o16.z, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zzzz, new Divider<uint4>(new uint4(o32.z, o32.z, o32.z, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zzzz, new Divider<ulong4>(new ulong4(o64.z, o64.z, o64.z, o64.z)));
		}

		[Test]
		public static void get_zzzw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zzzw, new Divider<byte4>(new byte4(o8.z, o8.z, o8.z, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zzzw, new Divider<ushort4>(new ushort4(o16.z, o16.z, o16.z, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zzzw, new Divider<uint4>(new uint4(o32.z, o32.z, o32.z, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zzzw, new Divider<ulong4>(new ulong4(o64.z, o64.z, o64.z, o64.w)));
		}

		[Test]
		public static void get_zzwx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zzwx, new Divider<byte4>(new byte4(o8.z, o8.z, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zzwx, new Divider<ushort4>(new ushort4(o16.z, o16.z, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zzwx, new Divider<uint4>(new uint4(o32.z, o32.z, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zzwx, new Divider<ulong4>(new ulong4(o64.z, o64.z, o64.w, o64.x)));
		}

		[Test]
		public static void get_zzwy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zzwy, new Divider<byte4>(new byte4(o8.z, o8.z, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zzwy, new Divider<ushort4>(new ushort4(o16.z, o16.z, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zzwy, new Divider<uint4>(new uint4(o32.z, o32.z, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zzwy, new Divider<ulong4>(new ulong4(o64.z, o64.z, o64.w, o64.y)));
		}

		[Test]
		public static void get_zzwz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zzwz, new Divider<byte4>(new byte4(o8.z, o8.z, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zzwz, new Divider<ushort4>(new ushort4(o16.z, o16.z, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zzwz, new Divider<uint4>(new uint4(o32.z, o32.z, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zzwz, new Divider<ulong4>(new ulong4(o64.z, o64.z, o64.w, o64.z)));
		}

		[Test]
		public static void get_zzww()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zzww, new Divider<byte4>(new byte4(o8.z, o8.z, o8.w, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zzww, new Divider<ushort4>(new ushort4(o16.z, o16.z, o16.w, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zzww, new Divider<uint4>(new uint4(o32.z, o32.z, o32.w, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zzww, new Divider<ulong4>(new ulong4(o64.z, o64.z, o64.w, o64.w)));
		}

		[Test]
		public static void get_zwxx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zwxx, new Divider<byte4>(new byte4(o8.z, o8.w, o8.x, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zwxx, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.x, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zwxx, new Divider<uint4>(new uint4(o32.z, o32.w, o32.x, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zwxx, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.x, o64.x)));
		}

		[Test]
		public static void get_zwxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zwxy, new Divider<byte4>(new byte4(o8.z, o8.w, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zwxy, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zwxy, new Divider<uint4>(new uint4(o32.z, o32.w, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zwxy, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.x, o64.y)));
		}

		[Test]
		public static void get_zwxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zwxz, new Divider<byte4>(new byte4(o8.z, o8.w, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zwxz, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zwxz, new Divider<uint4>(new uint4(o32.z, o32.w, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zwxz, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.x, o64.z)));
		}

		[Test]
		public static void get_zwxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zwxw, new Divider<byte4>(new byte4(o8.z, o8.w, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zwxw, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zwxw, new Divider<uint4>(new uint4(o32.z, o32.w, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zwxw, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.x, o64.w)));
		}

		[Test]
		public static void get_zwyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zwyx, new Divider<byte4>(new byte4(o8.z, o8.w, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zwyx, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zwyx, new Divider<uint4>(new uint4(o32.z, o32.w, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zwyx, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.y, o64.x)));
		}

		[Test]
		public static void get_zwyy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zwyy, new Divider<byte4>(new byte4(o8.z, o8.w, o8.y, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zwyy, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.y, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zwyy, new Divider<uint4>(new uint4(o32.z, o32.w, o32.y, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zwyy, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.y, o64.y)));
		}

		[Test]
		public static void get_zwyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zwyz, new Divider<byte4>(new byte4(o8.z, o8.w, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zwyz, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zwyz, new Divider<uint4>(new uint4(o32.z, o32.w, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zwyz, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.y, o64.z)));
		}

		[Test]
		public static void get_zwyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zwyw, new Divider<byte4>(new byte4(o8.z, o8.w, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zwyw, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zwyw, new Divider<uint4>(new uint4(o32.z, o32.w, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zwyw, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.y, o64.w)));
		}

		[Test]
		public static void get_zwzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zwzx, new Divider<byte4>(new byte4(o8.z, o8.w, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zwzx, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zwzx, new Divider<uint4>(new uint4(o32.z, o32.w, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zwzx, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.z, o64.x)));
		}

		[Test]
		public static void get_zwzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zwzy, new Divider<byte4>(new byte4(o8.z, o8.w, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zwzy, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zwzy, new Divider<uint4>(new uint4(o32.z, o32.w, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zwzy, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.z, o64.y)));
		}

		[Test]
		public static void get_zwzz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zwzz, new Divider<byte4>(new byte4(o8.z, o8.w, o8.z, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zwzz, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.z, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zwzz, new Divider<uint4>(new uint4(o32.z, o32.w, o32.z, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zwzz, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.z, o64.z)));
		}

		[Test]
		public static void get_zwzw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zwzw, new Divider<byte4>(new byte4(o8.z, o8.w, o8.z, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zwzw, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.z, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zwzw, new Divider<uint4>(new uint4(o32.z, o32.w, o32.z, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zwzw, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.z, o64.w)));
		}

		[Test]
		public static void get_zwwx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zwwx, new Divider<byte4>(new byte4(o8.z, o8.w, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zwwx, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zwwx, new Divider<uint4>(new uint4(o32.z, o32.w, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zwwx, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.w, o64.x)));
		}

		[Test]
		public static void get_zwwy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zwwy, new Divider<byte4>(new byte4(o8.z, o8.w, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zwwy, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zwwy, new Divider<uint4>(new uint4(o32.z, o32.w, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zwwy, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.w, o64.y)));
		}

		[Test]
		public static void get_zwwz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zwwz, new Divider<byte4>(new byte4(o8.z, o8.w, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zwwz, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zwwz, new Divider<uint4>(new uint4(o32.z, o32.w, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zwwz, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.w, o64.z)));
		}

		[Test]
		public static void get_zwww()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).zwww, new Divider<byte4>(new byte4(o8.z, o8.w, o8.w, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).zwww, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.w, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).zwww, new Divider<uint4>(new uint4(o32.z, o32.w, o32.w, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).zwww, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.w, o64.w)));
		}

		[Test]
		public static void get_wxxx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wxxx, new Divider<byte4>(new byte4(o8.w, o8.x, o8.x, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wxxx, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.x, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wxxx, new Divider<uint4>(new uint4(o32.w, o32.x, o32.x, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wxxx, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.x, o64.x)));
		}

		[Test]
		public static void get_wxxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wxxy, new Divider<byte4>(new byte4(o8.w, o8.x, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wxxy, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wxxy, new Divider<uint4>(new uint4(o32.w, o32.x, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wxxy, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.x, o64.y)));
		}

		[Test]
		public static void get_wxxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wxxz, new Divider<byte4>(new byte4(o8.w, o8.x, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wxxz, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wxxz, new Divider<uint4>(new uint4(o32.w, o32.x, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wxxz, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.x, o64.z)));
		}

		[Test]
		public static void get_wxxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wxxw, new Divider<byte4>(new byte4(o8.w, o8.x, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wxxw, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wxxw, new Divider<uint4>(new uint4(o32.w, o32.x, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wxxw, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.x, o64.w)));
		}

		[Test]
		public static void get_wxyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wxyx, new Divider<byte4>(new byte4(o8.w, o8.x, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wxyx, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wxyx, new Divider<uint4>(new uint4(o32.w, o32.x, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wxyx, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.y, o64.x)));
		}

		[Test]
		public static void get_wxyy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wxyy, new Divider<byte4>(new byte4(o8.w, o8.x, o8.y, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wxyy, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.y, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wxyy, new Divider<uint4>(new uint4(o32.w, o32.x, o32.y, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wxyy, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.y, o64.y)));
		}

		[Test]
		public static void get_wxyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wxyz, new Divider<byte4>(new byte4(o8.w, o8.x, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wxyz, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wxyz, new Divider<uint4>(new uint4(o32.w, o32.x, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wxyz, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.y, o64.z)));
		}

		[Test]
		public static void get_wxyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wxyw, new Divider<byte4>(new byte4(o8.w, o8.x, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wxyw, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wxyw, new Divider<uint4>(new uint4(o32.w, o32.x, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wxyw, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.y, o64.w)));
		}

		[Test]
		public static void get_wxzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wxzx, new Divider<byte4>(new byte4(o8.w, o8.x, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wxzx, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wxzx, new Divider<uint4>(new uint4(o32.w, o32.x, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wxzx, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.z, o64.x)));
		}

		[Test]
		public static void get_wxzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wxzy, new Divider<byte4>(new byte4(o8.w, o8.x, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wxzy, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wxzy, new Divider<uint4>(new uint4(o32.w, o32.x, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wxzy, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.z, o64.y)));
		}

		[Test]
		public static void get_wxzz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wxzz, new Divider<byte4>(new byte4(o8.w, o8.x, o8.z, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wxzz, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.z, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wxzz, new Divider<uint4>(new uint4(o32.w, o32.x, o32.z, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wxzz, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.z, o64.z)));
		}

		[Test]
		public static void get_wxzw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wxzw, new Divider<byte4>(new byte4(o8.w, o8.x, o8.z, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wxzw, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.z, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wxzw, new Divider<uint4>(new uint4(o32.w, o32.x, o32.z, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wxzw, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.z, o64.w)));
		}

		[Test]
		public static void get_wxwx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wxwx, new Divider<byte4>(new byte4(o8.w, o8.x, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wxwx, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wxwx, new Divider<uint4>(new uint4(o32.w, o32.x, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wxwx, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.w, o64.x)));
		}

		[Test]
		public static void get_wxwy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wxwy, new Divider<byte4>(new byte4(o8.w, o8.x, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wxwy, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wxwy, new Divider<uint4>(new uint4(o32.w, o32.x, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wxwy, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.w, o64.y)));
		}

		[Test]
		public static void get_wxwz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wxwz, new Divider<byte4>(new byte4(o8.w, o8.x, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wxwz, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wxwz, new Divider<uint4>(new uint4(o32.w, o32.x, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wxwz, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.w, o64.z)));
		}

		[Test]
		public static void get_wxww()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wxww, new Divider<byte4>(new byte4(o8.w, o8.x, o8.w, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wxww, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.w, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wxww, new Divider<uint4>(new uint4(o32.w, o32.x, o32.w, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wxww, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.w, o64.w)));
		}

		[Test]
		public static void get_wyxx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wyxx, new Divider<byte4>(new byte4(o8.w, o8.y, o8.x, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wyxx, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.x, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wyxx, new Divider<uint4>(new uint4(o32.w, o32.y, o32.x, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wyxx, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.x, o64.x)));
		}

		[Test]
		public static void get_wyxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wyxy, new Divider<byte4>(new byte4(o8.w, o8.y, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wyxy, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wyxy, new Divider<uint4>(new uint4(o32.w, o32.y, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wyxy, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.x, o64.y)));
		}

		[Test]
		public static void get_wyxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wyxz, new Divider<byte4>(new byte4(o8.w, o8.y, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wyxz, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wyxz, new Divider<uint4>(new uint4(o32.w, o32.y, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wyxz, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.x, o64.z)));
		}

		[Test]
		public static void get_wyxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wyxw, new Divider<byte4>(new byte4(o8.w, o8.y, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wyxw, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wyxw, new Divider<uint4>(new uint4(o32.w, o32.y, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wyxw, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.x, o64.w)));
		}

		[Test]
		public static void get_wyyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wyyx, new Divider<byte4>(new byte4(o8.w, o8.y, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wyyx, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wyyx, new Divider<uint4>(new uint4(o32.w, o32.y, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wyyx, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.y, o64.x)));
		}

		[Test]
		public static void get_wyyy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wyyy, new Divider<byte4>(new byte4(o8.w, o8.y, o8.y, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wyyy, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.y, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wyyy, new Divider<uint4>(new uint4(o32.w, o32.y, o32.y, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wyyy, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.y, o64.y)));
		}

		[Test]
		public static void get_wyyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wyyz, new Divider<byte4>(new byte4(o8.w, o8.y, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wyyz, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wyyz, new Divider<uint4>(new uint4(o32.w, o32.y, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wyyz, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.y, o64.z)));
		}

		[Test]
		public static void get_wyyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wyyw, new Divider<byte4>(new byte4(o8.w, o8.y, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wyyw, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wyyw, new Divider<uint4>(new uint4(o32.w, o32.y, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wyyw, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.y, o64.w)));
		}

		[Test]
		public static void get_wyzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wyzx, new Divider<byte4>(new byte4(o8.w, o8.y, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wyzx, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wyzx, new Divider<uint4>(new uint4(o32.w, o32.y, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wyzx, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.z, o64.x)));
		}

		[Test]
		public static void get_wyzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wyzy, new Divider<byte4>(new byte4(o8.w, o8.y, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wyzy, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wyzy, new Divider<uint4>(new uint4(o32.w, o32.y, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wyzy, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.z, o64.y)));
		}

		[Test]
		public static void get_wyzz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wyzz, new Divider<byte4>(new byte4(o8.w, o8.y, o8.z, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wyzz, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.z, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wyzz, new Divider<uint4>(new uint4(o32.w, o32.y, o32.z, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wyzz, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.z, o64.z)));
		}

		[Test]
		public static void get_wyzw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wyzw, new Divider<byte4>(new byte4(o8.w, o8.y, o8.z, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wyzw, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.z, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wyzw, new Divider<uint4>(new uint4(o32.w, o32.y, o32.z, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wyzw, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.z, o64.w)));
		}

		[Test]
		public static void get_wywx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wywx, new Divider<byte4>(new byte4(o8.w, o8.y, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wywx, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wywx, new Divider<uint4>(new uint4(o32.w, o32.y, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wywx, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.w, o64.x)));
		}

		[Test]
		public static void get_wywy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wywy, new Divider<byte4>(new byte4(o8.w, o8.y, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wywy, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wywy, new Divider<uint4>(new uint4(o32.w, o32.y, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wywy, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.w, o64.y)));
		}

		[Test]
		public static void get_wywz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wywz, new Divider<byte4>(new byte4(o8.w, o8.y, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wywz, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wywz, new Divider<uint4>(new uint4(o32.w, o32.y, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wywz, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.w, o64.z)));
		}

		[Test]
		public static void get_wyww()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wyww, new Divider<byte4>(new byte4(o8.w, o8.y, o8.w, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wyww, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.w, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wyww, new Divider<uint4>(new uint4(o32.w, o32.y, o32.w, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wyww, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.w, o64.w)));
		}

		[Test]
		public static void get_wzxx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wzxx, new Divider<byte4>(new byte4(o8.w, o8.z, o8.x, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wzxx, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.x, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wzxx, new Divider<uint4>(new uint4(o32.w, o32.z, o32.x, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wzxx, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.x, o64.x)));
		}

		[Test]
		public static void get_wzxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wzxy, new Divider<byte4>(new byte4(o8.w, o8.z, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wzxy, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wzxy, new Divider<uint4>(new uint4(o32.w, o32.z, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wzxy, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.x, o64.y)));
		}

		[Test]
		public static void get_wzxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wzxz, new Divider<byte4>(new byte4(o8.w, o8.z, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wzxz, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wzxz, new Divider<uint4>(new uint4(o32.w, o32.z, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wzxz, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.x, o64.z)));
		}

		[Test]
		public static void get_wzxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wzxw, new Divider<byte4>(new byte4(o8.w, o8.z, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wzxw, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wzxw, new Divider<uint4>(new uint4(o32.w, o32.z, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wzxw, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.x, o64.w)));
		}

		[Test]
		public static void get_wzyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wzyx, new Divider<byte4>(new byte4(o8.w, o8.z, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wzyx, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wzyx, new Divider<uint4>(new uint4(o32.w, o32.z, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wzyx, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.y, o64.x)));
		}

		[Test]
		public static void get_wzyy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wzyy, new Divider<byte4>(new byte4(o8.w, o8.z, o8.y, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wzyy, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.y, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wzyy, new Divider<uint4>(new uint4(o32.w, o32.z, o32.y, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wzyy, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.y, o64.y)));
		}

		[Test]
		public static void get_wzyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wzyz, new Divider<byte4>(new byte4(o8.w, o8.z, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wzyz, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wzyz, new Divider<uint4>(new uint4(o32.w, o32.z, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wzyz, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.y, o64.z)));
		}

		[Test]
		public static void get_wzyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wzyw, new Divider<byte4>(new byte4(o8.w, o8.z, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wzyw, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wzyw, new Divider<uint4>(new uint4(o32.w, o32.z, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wzyw, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.y, o64.w)));
		}

		[Test]
		public static void get_wzzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wzzx, new Divider<byte4>(new byte4(o8.w, o8.z, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wzzx, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wzzx, new Divider<uint4>(new uint4(o32.w, o32.z, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wzzx, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.z, o64.x)));
		}

		[Test]
		public static void get_wzzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wzzy, new Divider<byte4>(new byte4(o8.w, o8.z, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wzzy, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wzzy, new Divider<uint4>(new uint4(o32.w, o32.z, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wzzy, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.z, o64.y)));
		}

		[Test]
		public static void get_wzzz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wzzz, new Divider<byte4>(new byte4(o8.w, o8.z, o8.z, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wzzz, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.z, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wzzz, new Divider<uint4>(new uint4(o32.w, o32.z, o32.z, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wzzz, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.z, o64.z)));
		}

		[Test]
		public static void get_wzzw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wzzw, new Divider<byte4>(new byte4(o8.w, o8.z, o8.z, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wzzw, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.z, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wzzw, new Divider<uint4>(new uint4(o32.w, o32.z, o32.z, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wzzw, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.z, o64.w)));
		}

		[Test]
		public static void get_wzwx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wzwx, new Divider<byte4>(new byte4(o8.w, o8.z, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wzwx, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wzwx, new Divider<uint4>(new uint4(o32.w, o32.z, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wzwx, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.w, o64.x)));
		}

		[Test]
		public static void get_wzwy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wzwy, new Divider<byte4>(new byte4(o8.w, o8.z, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wzwy, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wzwy, new Divider<uint4>(new uint4(o32.w, o32.z, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wzwy, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.w, o64.y)));
		}

		[Test]
		public static void get_wzwz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wzwz, new Divider<byte4>(new byte4(o8.w, o8.z, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wzwz, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wzwz, new Divider<uint4>(new uint4(o32.w, o32.z, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wzwz, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.w, o64.z)));
		}

		[Test]
		public static void get_wzww()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wzww, new Divider<byte4>(new byte4(o8.w, o8.z, o8.w, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wzww, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.w, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wzww, new Divider<uint4>(new uint4(o32.w, o32.z, o32.w, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wzww, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.w, o64.w)));
		}

		[Test]
		public static void get_wwxx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wwxx, new Divider<byte4>(new byte4(o8.w, o8.w, o8.x, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wwxx, new Divider<ushort4>(new ushort4(o16.w, o16.w, o16.x, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wwxx, new Divider<uint4>(new uint4(o32.w, o32.w, o32.x, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wwxx, new Divider<ulong4>(new ulong4(o64.w, o64.w, o64.x, o64.x)));
		}

		[Test]
		public static void get_wwxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wwxy, new Divider<byte4>(new byte4(o8.w, o8.w, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wwxy, new Divider<ushort4>(new ushort4(o16.w, o16.w, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wwxy, new Divider<uint4>(new uint4(o32.w, o32.w, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wwxy, new Divider<ulong4>(new ulong4(o64.w, o64.w, o64.x, o64.y)));
		}

		[Test]
		public static void get_wwxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wwxz, new Divider<byte4>(new byte4(o8.w, o8.w, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wwxz, new Divider<ushort4>(new ushort4(o16.w, o16.w, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wwxz, new Divider<uint4>(new uint4(o32.w, o32.w, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wwxz, new Divider<ulong4>(new ulong4(o64.w, o64.w, o64.x, o64.z)));
		}

		[Test]
		public static void get_wwxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wwxw, new Divider<byte4>(new byte4(o8.w, o8.w, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wwxw, new Divider<ushort4>(new ushort4(o16.w, o16.w, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wwxw, new Divider<uint4>(new uint4(o32.w, o32.w, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wwxw, new Divider<ulong4>(new ulong4(o64.w, o64.w, o64.x, o64.w)));
		}

		[Test]
		public static void get_wwyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wwyx, new Divider<byte4>(new byte4(o8.w, o8.w, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wwyx, new Divider<ushort4>(new ushort4(o16.w, o16.w, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wwyx, new Divider<uint4>(new uint4(o32.w, o32.w, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wwyx, new Divider<ulong4>(new ulong4(o64.w, o64.w, o64.y, o64.x)));
		}

		[Test]
		public static void get_wwyy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wwyy, new Divider<byte4>(new byte4(o8.w, o8.w, o8.y, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wwyy, new Divider<ushort4>(new ushort4(o16.w, o16.w, o16.y, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wwyy, new Divider<uint4>(new uint4(o32.w, o32.w, o32.y, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wwyy, new Divider<ulong4>(new ulong4(o64.w, o64.w, o64.y, o64.y)));
		}

		[Test]
		public static void get_wwyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wwyz, new Divider<byte4>(new byte4(o8.w, o8.w, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wwyz, new Divider<ushort4>(new ushort4(o16.w, o16.w, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wwyz, new Divider<uint4>(new uint4(o32.w, o32.w, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wwyz, new Divider<ulong4>(new ulong4(o64.w, o64.w, o64.y, o64.z)));
		}

		[Test]
		public static void get_wwyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wwyw, new Divider<byte4>(new byte4(o8.w, o8.w, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wwyw, new Divider<ushort4>(new ushort4(o16.w, o16.w, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wwyw, new Divider<uint4>(new uint4(o32.w, o32.w, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wwyw, new Divider<ulong4>(new ulong4(o64.w, o64.w, o64.y, o64.w)));
		}

		[Test]
		public static void get_wwzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wwzx, new Divider<byte4>(new byte4(o8.w, o8.w, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wwzx, new Divider<ushort4>(new ushort4(o16.w, o16.w, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wwzx, new Divider<uint4>(new uint4(o32.w, o32.w, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wwzx, new Divider<ulong4>(new ulong4(o64.w, o64.w, o64.z, o64.x)));
		}

		[Test]
		public static void get_wwzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wwzy, new Divider<byte4>(new byte4(o8.w, o8.w, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wwzy, new Divider<ushort4>(new ushort4(o16.w, o16.w, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wwzy, new Divider<uint4>(new uint4(o32.w, o32.w, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wwzy, new Divider<ulong4>(new ulong4(o64.w, o64.w, o64.z, o64.y)));
		}

		[Test]
		public static void get_wwzz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wwzz, new Divider<byte4>(new byte4(o8.w, o8.w, o8.z, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wwzz, new Divider<ushort4>(new ushort4(o16.w, o16.w, o16.z, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wwzz, new Divider<uint4>(new uint4(o32.w, o32.w, o32.z, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wwzz, new Divider<ulong4>(new ulong4(o64.w, o64.w, o64.z, o64.z)));
		}

		[Test]
		public static void get_wwzw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wwzw, new Divider<byte4>(new byte4(o8.w, o8.w, o8.z, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wwzw, new Divider<ushort4>(new ushort4(o16.w, o16.w, o16.z, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wwzw, new Divider<uint4>(new uint4(o32.w, o32.w, o32.z, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wwzw, new Divider<ulong4>(new ulong4(o64.w, o64.w, o64.z, o64.w)));
		}

		[Test]
		public static void get_wwwx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wwwx, new Divider<byte4>(new byte4(o8.w, o8.w, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wwwx, new Divider<ushort4>(new ushort4(o16.w, o16.w, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wwwx, new Divider<uint4>(new uint4(o32.w, o32.w, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wwwx, new Divider<ulong4>(new ulong4(o64.w, o64.w, o64.w, o64.x)));
		}

		[Test]
		public static void get_wwwy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wwwy, new Divider<byte4>(new byte4(o8.w, o8.w, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wwwy, new Divider<ushort4>(new ushort4(o16.w, o16.w, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wwwy, new Divider<uint4>(new uint4(o32.w, o32.w, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wwwy, new Divider<ulong4>(new ulong4(o64.w, o64.w, o64.w, o64.y)));
		}

		[Test]
		public static void get_wwwz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wwwz, new Divider<byte4>(new byte4(o8.w, o8.w, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wwwz, new Divider<ushort4>(new ushort4(o16.w, o16.w, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wwwz, new Divider<uint4>(new uint4(o32.w, o32.w, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wwwz, new Divider<ulong4>(new ulong4(o64.w, o64.w, o64.w, o64.z)));
		}

		[Test]
		public static void get_wwww()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<byte4>(o8).wwww, new Divider<byte4>(new byte4(o8.w, o8.w, o8.w, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ushort4>(o16).wwww, new Divider<ushort4>(new ushort4(o16.w, o16.w, o16.w, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<uint4>(o32).wwww, new Divider<uint4>(new uint4(o32.w, o32.w, o32.w, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Assert.AreEqual(new Divider<ulong4>(o64).wwww, new Divider<ulong4>(new ulong4(o64.w, o64.w, o64.w, o64.w)));
		}

		[Test]
		public static void get_xxx()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).xxx, new Divider<byte3>(new byte3(o8.x, o8.x, o8.x)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).xxx, new Divider<ushort3>(new ushort3(o16.x, o16.x, o16.x)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).xxx, new Divider<uint3>(new uint3(o32.x, o32.x, o32.x)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).xxx, new Divider<ulong3>(new ulong3(o64.x, o64.x, o64.x)));
		}

		[Test]
		public static void get_xxy()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).xxy, new Divider<byte3>(new byte3(o8.x, o8.x, o8.y)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).xxy, new Divider<ushort3>(new ushort3(o16.x, o16.x, o16.y)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).xxy, new Divider<uint3>(new uint3(o32.x, o32.x, o32.y)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).xxy, new Divider<ulong3>(new ulong3(o64.x, o64.x, o64.y)));
		}

		[Test]
		public static void get_xxz()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).xxz, new Divider<byte3>(new byte3(o8.x, o8.x, o8.z)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).xxz, new Divider<ushort3>(new ushort3(o16.x, o16.x, o16.z)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).xxz, new Divider<uint3>(new uint3(o32.x, o32.x, o32.z)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).xxz, new Divider<ulong3>(new ulong3(o64.x, o64.x, o64.z)));
		}

		[Test]
		public static void get_xyx()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).xyx, new Divider<byte3>(new byte3(o8.x, o8.y, o8.x)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).xyx, new Divider<ushort3>(new ushort3(o16.x, o16.y, o16.x)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).xyx, new Divider<uint3>(new uint3(o32.x, o32.y, o32.x)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).xyx, new Divider<ulong3>(new ulong3(o64.x, o64.y, o64.x)));
		}

		[Test]
		public static void get_xyy()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).xyy, new Divider<byte3>(new byte3(o8.x, o8.y, o8.y)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).xyy, new Divider<ushort3>(new ushort3(o16.x, o16.y, o16.y)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).xyy, new Divider<uint3>(new uint3(o32.x, o32.y, o32.y)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).xyy, new Divider<ulong3>(new ulong3(o64.x, o64.y, o64.y)));
		}

		[Test]
		public static void get_xzx()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).xzx, new Divider<byte3>(new byte3(o8.x, o8.z, o8.x)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).xzx, new Divider<ushort3>(new ushort3(o16.x, o16.z, o16.x)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).xzx, new Divider<uint3>(new uint3(o32.x, o32.z, o32.x)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).xzx, new Divider<ulong3>(new ulong3(o64.x, o64.z, o64.x)));
		}

		[Test]
		public static void get_xzy()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).xzy, new Divider<byte3>(new byte3(o8.x, o8.z, o8.y)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).xzy, new Divider<ushort3>(new ushort3(o16.x, o16.z, o16.y)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).xzy, new Divider<uint3>(new uint3(o32.x, o32.z, o32.y)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).xzy, new Divider<ulong3>(new ulong3(o64.x, o64.z, o64.y)));
		}

		[Test]
		public static void get_xzz()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).xzz, new Divider<byte3>(new byte3(o8.x, o8.z, o8.z)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).xzz, new Divider<ushort3>(new ushort3(o16.x, o16.z, o16.z)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).xzz, new Divider<uint3>(new uint3(o32.x, o32.z, o32.z)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).xzz, new Divider<ulong3>(new ulong3(o64.x, o64.z, o64.z)));
		}

		[Test]
		public static void get_yxx()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).yxx, new Divider<byte3>(new byte3(o8.y, o8.x, o8.x)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).yxx, new Divider<ushort3>(new ushort3(o16.y, o16.x, o16.x)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).yxx, new Divider<uint3>(new uint3(o32.y, o32.x, o32.x)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).yxx, new Divider<ulong3>(new ulong3(o64.y, o64.x, o64.x)));
		}

		[Test]
		public static void get_yxy()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).yxy, new Divider<byte3>(new byte3(o8.y, o8.x, o8.y)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).yxy, new Divider<ushort3>(new ushort3(o16.y, o16.x, o16.y)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).yxy, new Divider<uint3>(new uint3(o32.y, o32.x, o32.y)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).yxy, new Divider<ulong3>(new ulong3(o64.y, o64.x, o64.y)));
		}

		[Test]
		public static void get_yxz()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).yxz, new Divider<byte3>(new byte3(o8.y, o8.x, o8.z)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).yxz, new Divider<ushort3>(new ushort3(o16.y, o16.x, o16.z)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).yxz, new Divider<uint3>(new uint3(o32.y, o32.x, o32.z)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).yxz, new Divider<ulong3>(new ulong3(o64.y, o64.x, o64.z)));
		}

		[Test]
		public static void get_yyx()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).yyx, new Divider<byte3>(new byte3(o8.y, o8.y, o8.x)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).yyx, new Divider<ushort3>(new ushort3(o16.y, o16.y, o16.x)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).yyx, new Divider<uint3>(new uint3(o32.y, o32.y, o32.x)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).yyx, new Divider<ulong3>(new ulong3(o64.y, o64.y, o64.x)));
		}

		[Test]
		public static void get_yyy()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).yyy, new Divider<byte3>(new byte3(o8.y, o8.y, o8.y)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).yyy, new Divider<ushort3>(new ushort3(o16.y, o16.y, o16.y)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).yyy, new Divider<uint3>(new uint3(o32.y, o32.y, o32.y)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).yyy, new Divider<ulong3>(new ulong3(o64.y, o64.y, o64.y)));
		}

		[Test]
		public static void get_yyz()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).yyz, new Divider<byte3>(new byte3(o8.y, o8.y, o8.z)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).yyz, new Divider<ushort3>(new ushort3(o16.y, o16.y, o16.z)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).yyz, new Divider<uint3>(new uint3(o32.y, o32.y, o32.z)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).yyz, new Divider<ulong3>(new ulong3(o64.y, o64.y, o64.z)));
		}

		[Test]
		public static void get_yzx()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).yzx, new Divider<byte3>(new byte3(o8.y, o8.z, o8.x)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).yzx, new Divider<ushort3>(new ushort3(o16.y, o16.z, o16.x)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).yzx, new Divider<uint3>(new uint3(o32.y, o32.z, o32.x)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).yzx, new Divider<ulong3>(new ulong3(o64.y, o64.z, o64.x)));
		}

		[Test]
		public static void get_yzy()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).yzy, new Divider<byte3>(new byte3(o8.y, o8.z, o8.y)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).yzy, new Divider<ushort3>(new ushort3(o16.y, o16.z, o16.y)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).yzy, new Divider<uint3>(new uint3(o32.y, o32.z, o32.y)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).yzy, new Divider<ulong3>(new ulong3(o64.y, o64.z, o64.y)));
		}

		[Test]
		public static void get_yzz()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).yzz, new Divider<byte3>(new byte3(o8.y, o8.z, o8.z)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).yzz, new Divider<ushort3>(new ushort3(o16.y, o16.z, o16.z)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).yzz, new Divider<uint3>(new uint3(o32.y, o32.z, o32.z)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).yzz, new Divider<ulong3>(new ulong3(o64.y, o64.z, o64.z)));
		}

		[Test]
		public static void get_zxx()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).zxx, new Divider<byte3>(new byte3(o8.z, o8.x, o8.x)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).zxx, new Divider<ushort3>(new ushort3(o16.z, o16.x, o16.x)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).zxx, new Divider<uint3>(new uint3(o32.z, o32.x, o32.x)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).zxx, new Divider<ulong3>(new ulong3(o64.z, o64.x, o64.x)));
		}

		[Test]
		public static void get_zxy()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).zxy, new Divider<byte3>(new byte3(o8.z, o8.x, o8.y)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).zxy, new Divider<ushort3>(new ushort3(o16.z, o16.x, o16.y)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).zxy, new Divider<uint3>(new uint3(o32.z, o32.x, o32.y)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).zxy, new Divider<ulong3>(new ulong3(o64.z, o64.x, o64.y)));
		}

		[Test]
		public static void get_zxz()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).zxz, new Divider<byte3>(new byte3(o8.z, o8.x, o8.z)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).zxz, new Divider<ushort3>(new ushort3(o16.z, o16.x, o16.z)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).zxz, new Divider<uint3>(new uint3(o32.z, o32.x, o32.z)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).zxz, new Divider<ulong3>(new ulong3(o64.z, o64.x, o64.z)));
		}

		[Test]
		public static void get_zyx()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).zyx, new Divider<byte3>(new byte3(o8.z, o8.y, o8.x)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).zyx, new Divider<ushort3>(new ushort3(o16.z, o16.y, o16.x)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).zyx, new Divider<uint3>(new uint3(o32.z, o32.y, o32.x)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).zyx, new Divider<ulong3>(new ulong3(o64.z, o64.y, o64.x)));
		}

		[Test]
		public static void get_zyy()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).zyy, new Divider<byte3>(new byte3(o8.z, o8.y, o8.y)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).zyy, new Divider<ushort3>(new ushort3(o16.z, o16.y, o16.y)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).zyy, new Divider<uint3>(new uint3(o32.z, o32.y, o32.y)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).zyy, new Divider<ulong3>(new ulong3(o64.z, o64.y, o64.y)));
		}

		[Test]
		public static void get_zyz()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).zyz, new Divider<byte3>(new byte3(o8.z, o8.y, o8.z)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).zyz, new Divider<ushort3>(new ushort3(o16.z, o16.y, o16.z)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).zyz, new Divider<uint3>(new uint3(o32.z, o32.y, o32.z)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).zyz, new Divider<ulong3>(new ulong3(o64.z, o64.y, o64.z)));
		}

		[Test]
		public static void get_zzx()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).zzx, new Divider<byte3>(new byte3(o8.z, o8.z, o8.x)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).zzx, new Divider<ushort3>(new ushort3(o16.z, o16.z, o16.x)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).zzx, new Divider<uint3>(new uint3(o32.z, o32.z, o32.x)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).zzx, new Divider<ulong3>(new ulong3(o64.z, o64.z, o64.x)));
		}

		[Test]
		public static void get_zzy()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).zzy, new Divider<byte3>(new byte3(o8.z, o8.z, o8.y)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).zzy, new Divider<ushort3>(new ushort3(o16.z, o16.z, o16.y)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).zzy, new Divider<uint3>(new uint3(o32.z, o32.z, o32.y)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).zzy, new Divider<ulong3>(new ulong3(o64.z, o64.z, o64.y)));
		}

		[Test]
		public static void get_zzz()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Assert.AreEqual(new Divider<byte3>(o8).zzz, new Divider<byte3>(new byte3(o8.z, o8.z, o8.z)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Assert.AreEqual(new Divider<ushort3>(o16).zzz, new Divider<ushort3>(new ushort3(o16.z, o16.z, o16.z)));
			uint3 o32 = new uint3(1, 2, 3);
			Assert.AreEqual(new Divider<uint3>(o32).zzz, new Divider<uint3>(new uint3(o32.z, o32.z, o32.z)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Assert.AreEqual(new Divider<ulong3>(o64).zzz, new Divider<ulong3>(new ulong3(o64.z, o64.z, o64.z)));
		}

		[Test]
		public static void get_xx()
		{
			byte2 o8 = new byte2(1, 2);
			Assert.AreEqual(new Divider<byte2>(o8).xx, new Divider<byte2>(new byte2(o8.x, o8.x)));
			ushort2 o16 = new ushort2(1, 2);
			Assert.AreEqual(new Divider<ushort2>(o16).xx, new Divider<ushort2>(new ushort2(o16.x, o16.x)));
			uint2 o32 = new uint2(1, 2);
			Assert.AreEqual(new Divider<uint2>(o32).xx, new Divider<uint2>(new uint2(o32.x, o32.x)));
			ulong2 o64 = new ulong2(1, 2);
			Assert.AreEqual(new Divider<ulong2>(o64).xx, new Divider<ulong2>(new ulong2(o64.x, o64.x)));
		}

		[Test]
		public static void get_yx()
		{
			byte2 o8 = new byte2(1, 2);
			Assert.AreEqual(new Divider<byte2>(o8).yx, new Divider<byte2>(new byte2(o8.y, o8.x)));
			ushort2 o16 = new ushort2(1, 2);
			Assert.AreEqual(new Divider<ushort2>(o16).yx, new Divider<ushort2>(new ushort2(o16.y, o16.x)));
			uint2 o32 = new uint2(1, 2);
			Assert.AreEqual(new Divider<uint2>(o32).yx, new Divider<uint2>(new uint2(o32.y, o32.x)));
			ulong2 o64 = new ulong2(1, 2);
			Assert.AreEqual(new Divider<ulong2>(o64).yx, new Divider<ulong2>(new ulong2(o64.y, o64.x)));
		}

		[Test]
		public static void get_yy()
		{
			byte2 o8 = new byte2(1, 2);
			Assert.AreEqual(new Divider<byte2>(o8).yy, new Divider<byte2>(new byte2(o8.y, o8.y)));
			ushort2 o16 = new ushort2(1, 2);
			Assert.AreEqual(new Divider<ushort2>(o16).yy, new Divider<ushort2>(new ushort2(o16.y, o16.y)));
			uint2 o32 = new uint2(1, 2);
			Assert.AreEqual(new Divider<uint2>(o32).yy, new Divider<uint2>(new uint2(o32.y, o32.y)));
			ulong2 o64 = new ulong2(1, 2);
			Assert.AreEqual(new Divider<ulong2>(o64).yy, new Divider<ulong2>(new ulong2(o64.y, o64.y)));
		}


		[Test]
		public static void set_xywz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.xywz = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.x, o8.y, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.xywz = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.x, o16.y, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.xywz = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.x, o32.y, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.xywz = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.x, o64.y, o64.w, o64.z)));
		}

		[Test]
		public static void set_xzyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.xzyw = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.x, o8.z, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.xzyw = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.xzyw = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.x, o32.z, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.xzyw = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.y, o64.w)));
		}

		[Test]
		public static void set_xzwy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.xzwy = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.x, o8.w, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.xzwy = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.xzwy = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.x, o32.w, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.xzwy = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.y, o64.z)));
		}

		[Test]
		public static void set_xwyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.xwyz = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.x, o8.z, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.xwyz = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.x, o16.z, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.xwyz = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.x, o32.z, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.xwyz = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.x, o64.z, o64.w, o64.y)));
		}

		[Test]
		public static void set_xwzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.xwzy = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.x, o8.w, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.xwzy = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.x, o16.w, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.xwzy = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.x, o32.w, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.xwzy = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.x, o64.w, o64.z, o64.y)));
		}

		[Test]
		public static void set_yxzw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.yxzw = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.y, o8.x, o8.z, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.yxzw = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.z, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.yxzw = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.y, o32.x, o32.z, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.yxzw = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.z, o64.w)));
		}

		[Test]
		public static void set_yxwz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.yxwz = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.y, o8.x, o8.w, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.yxwz = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.y, o16.x, o16.w, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.yxwz = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.y, o32.x, o32.w, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.yxwz = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.y, o64.x, o64.w, o64.z)));
		}

		[Test]
		public static void set_yzxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.yzxw = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.z, o8.x, o8.y, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.yzxw = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.y, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.yzxw = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.z, o32.x, o32.y, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.yzxw = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.y, o64.w)));
		}

		[Test]
		public static void set_yzwx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.yzwx = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.w, o8.x, o8.y, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.yzwx = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.y, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.yzwx = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.w, o32.x, o32.y, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.yzwx = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.y, o64.z)));
		}

		[Test]
		public static void set_ywxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.ywxz = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.z, o8.x, o8.w, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.ywxz = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.z, o16.x, o16.w, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.ywxz = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.z, o32.x, o32.w, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.ywxz = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.z, o64.x, o64.w, o64.y)));
		}

		[Test]
		public static void set_ywzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.ywzx = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.w, o8.x, o8.z, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.ywzx = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.w, o16.x, o16.z, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.ywzx = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.w, o32.x, o32.z, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.ywzx = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.w, o64.x, o64.z, o64.y)));
		}

		[Test]
		public static void set_zxyw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.zxyw = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.y, o8.z, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.zxyw = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.zxyw = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.y, o32.z, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.zxyw = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.x, o64.w)));
		}

		[Test]
		public static void set_zxwy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.zxwy = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.y, o8.w, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.zxwy = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.zxwy = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.y, o32.w, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.zxwy = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.x, o64.z)));
		}

		[Test]
		public static void set_zyxw()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.zyxw = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.z, o8.y, o8.x, o8.w)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.zyxw = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.x, o16.w)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.zyxw = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.z, o32.y, o32.x, o32.w)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.zyxw = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.x, o64.w)));
		}

		[Test]
		public static void set_zywx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.zywx = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.w, o8.y, o8.x, o8.z)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.zywx = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.x, o16.z)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.zywx = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.w, o32.y, o32.x, o32.z)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.zywx = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.x, o64.z)));
		}

		[Test]
		public static void set_zwxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.zwxy = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.z, o8.w, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.zwxy = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.zwxy = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.z, o32.w, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.zwxy = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.x, o64.y)));
		}

		[Test]
		public static void set_zwyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.zwyx = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.w, o8.z, o8.x, o8.y)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.zwyx = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.x, o16.y)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.zwyx = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.w, o32.z, o32.x, o32.y)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.zwyx = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.x, o64.y)));
		}

		[Test]
		public static void set_wxyz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.wxyz = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.y, o8.z, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.wxyz = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.y, o16.z, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.wxyz = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.y, o32.z, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.wxyz = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.y, o64.z, o64.w, o64.x)));
		}

		[Test]
		public static void set_wxzy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.wxzy = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.y, o8.w, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.wxzy = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.y, o16.w, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.wxzy = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.y, o32.w, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.wxzy = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.y, o64.w, o64.z, o64.x)));
		}

		[Test]
		public static void set_wyxz()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.wyxz = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.z, o8.y, o8.w, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.wyxz = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.z, o16.y, o16.w, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.wyxz = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.z, o32.y, o32.w, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.wyxz = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.z, o64.y, o64.w, o64.x)));
		}

		[Test]
		public static void set_wyzx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.wyzx = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.w, o8.y, o8.z, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.wyzx = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.w, o16.y, o16.z, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.wyzx = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.w, o32.y, o32.z, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.wyzx = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.w, o64.y, o64.z, o64.x)));
		}

		[Test]
		public static void set_wzxy()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.wzxy = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.z, o8.w, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.wzxy = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.z, o16.w, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.wzxy = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.z, o32.w, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.wzxy = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.z, o64.w, o64.y, o64.x)));
		}

		[Test]
		public static void set_wzyx()
		{
			byte4 o8 = new byte4(1, 2, 3, 4);
			Divider<byte4> s8 = new Divider<byte4>((byte4)byte.MaxValue);
			s8.wzyx = new Divider<byte4>(o8);
			Assert.AreEqual(s8, new Divider<byte4>(new byte4(o8.w, o8.z, o8.y, o8.x)));
			ushort4 o16 = new ushort4(1, 2, 3, 4);
			Divider<ushort4> s16 = new Divider<ushort4>((ushort4)ushort.MaxValue);
			s16.wzyx = new Divider<ushort4>(o16);
			Assert.AreEqual(s16, new Divider<ushort4>(new ushort4(o16.w, o16.z, o16.y, o16.x)));
			uint4 o32 = new uint4(1, 2, 3, 4);
			Divider<uint4> s32 = new Divider<uint4>((uint4)uint.MaxValue);
			s32.wzyx = new Divider<uint4>(o32);
			Assert.AreEqual(s32, new Divider<uint4>(new uint4(o32.w, o32.z, o32.y, o32.x)));
			ulong4 o64 = new ulong4(1, 2, 3, 4);
			Divider<ulong4> s64 = new Divider<ulong4>((ulong4)ulong.MaxValue);
			s64.wzyx = new Divider<ulong4>(o64);
			Assert.AreEqual(s64, new Divider<ulong4>(new ulong4(o64.w, o64.z, o64.y, o64.x)));
		}

		[Test]
		public static void set_xzy()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Divider<byte3> s8 = new Divider<byte3>((byte3)byte.MaxValue);
			s8.xzy = new Divider<byte3>(o8);
			Assert.AreEqual(s8, new Divider<byte3>(new byte3(o8.x, o8.z, o8.y)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Divider<ushort3> s16 = new Divider<ushort3>((ushort3)ushort.MaxValue);
			s16.xzy = new Divider<ushort3>(o16);
			Assert.AreEqual(s16, new Divider<ushort3>(new ushort3(o16.x, o16.z, o16.y)));
			uint3 o32 = new uint3(1, 2, 3);
			Divider<uint3> s32 = new Divider<uint3>((uint3)uint.MaxValue);
			s32.xzy = new Divider<uint3>(o32);
			Assert.AreEqual(s32, new Divider<uint3>(new uint3(o32.x, o32.z, o32.y)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Divider<ulong3> s64 = new Divider<ulong3>((ulong3)ulong.MaxValue);
			s64.xzy = new Divider<ulong3>(o64);
			Assert.AreEqual(s64, new Divider<ulong3>(new ulong3(o64.x, o64.z, o64.y)));
		}

		[Test]
		public static void set_yxz()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Divider<byte3> s8 = new Divider<byte3>((byte3)byte.MaxValue);
			s8.yxz = new Divider<byte3>(o8);
			Assert.AreEqual(s8, new Divider<byte3>(new byte3(o8.y, o8.x, o8.z)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Divider<ushort3> s16 = new Divider<ushort3>((ushort3)ushort.MaxValue);
			s16.yxz = new Divider<ushort3>(o16);
			Assert.AreEqual(s16, new Divider<ushort3>(new ushort3(o16.y, o16.x, o16.z)));
			uint3 o32 = new uint3(1, 2, 3);
			Divider<uint3> s32 = new Divider<uint3>((uint3)uint.MaxValue);
			s32.yxz = new Divider<uint3>(o32);
			Assert.AreEqual(s32, new Divider<uint3>(new uint3(o32.y, o32.x, o32.z)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Divider<ulong3> s64 = new Divider<ulong3>((ulong3)ulong.MaxValue);
			s64.yxz = new Divider<ulong3>(o64);
			Assert.AreEqual(s64, new Divider<ulong3>(new ulong3(o64.y, o64.x, o64.z)));
		}

		[Test]
		public static void set_yzx()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Divider<byte3> s8 = new Divider<byte3>((byte3)byte.MaxValue);
			s8.yzx = new Divider<byte3>(o8);
			Assert.AreEqual(s8, new Divider<byte3>(new byte3(o8.z, o8.x, o8.y)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Divider<ushort3> s16 = new Divider<ushort3>((ushort3)ushort.MaxValue);
			s16.yzx = new Divider<ushort3>(o16);
			Assert.AreEqual(s16, new Divider<ushort3>(new ushort3(o16.z, o16.x, o16.y)));
			uint3 o32 = new uint3(1, 2, 3);
			Divider<uint3> s32 = new Divider<uint3>((uint3)uint.MaxValue);
			s32.yzx = new Divider<uint3>(o32);
			Assert.AreEqual(s32, new Divider<uint3>(new uint3(o32.z, o32.x, o32.y)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Divider<ulong3> s64 = new Divider<ulong3>((ulong3)ulong.MaxValue);
			s64.yzx = new Divider<ulong3>(o64);
			Assert.AreEqual(s64, new Divider<ulong3>(new ulong3(o64.z, o64.x, o64.y)));
		}

		[Test]
		public static void set_zxy()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Divider<byte3> s8 = new Divider<byte3>((byte3)byte.MaxValue);
			s8.zxy = new Divider<byte3>(o8);
			Assert.AreEqual(s8, new Divider<byte3>(new byte3(o8.y, o8.z, o8.x)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Divider<ushort3> s16 = new Divider<ushort3>((ushort3)ushort.MaxValue);
			s16.zxy = new Divider<ushort3>(o16);
			Assert.AreEqual(s16, new Divider<ushort3>(new ushort3(o16.y, o16.z, o16.x)));
			uint3 o32 = new uint3(1, 2, 3);
			Divider<uint3> s32 = new Divider<uint3>((uint3)uint.MaxValue);
			s32.zxy = new Divider<uint3>(o32);
			Assert.AreEqual(s32, new Divider<uint3>(new uint3(o32.y, o32.z, o32.x)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Divider<ulong3> s64 = new Divider<ulong3>((ulong3)ulong.MaxValue);
			s64.zxy = new Divider<ulong3>(o64);
			Assert.AreEqual(s64, new Divider<ulong3>(new ulong3(o64.y, o64.z, o64.x)));
		}

		[Test]
		public static void set_zyx()
		{
			byte3 o8 = new byte3(1, 2, 3);
			Divider<byte3> s8 = new Divider<byte3>((byte3)byte.MaxValue);
			s8.zyx = new Divider<byte3>(o8);
			Assert.AreEqual(s8, new Divider<byte3>(new byte3(o8.z, o8.y, o8.x)));
			ushort3 o16 = new ushort3(1, 2, 3);
			Divider<ushort3> s16 = new Divider<ushort3>((ushort3)ushort.MaxValue);
			s16.zyx = new Divider<ushort3>(o16);
			Assert.AreEqual(s16, new Divider<ushort3>(new ushort3(o16.z, o16.y, o16.x)));
			uint3 o32 = new uint3(1, 2, 3);
			Divider<uint3> s32 = new Divider<uint3>((uint3)uint.MaxValue);
			s32.zyx = new Divider<uint3>(o32);
			Assert.AreEqual(s32, new Divider<uint3>(new uint3(o32.z, o32.y, o32.x)));
			ulong3 o64 = new ulong3(1, 2, 3);
			Divider<ulong3> s64 = new Divider<ulong3>((ulong3)ulong.MaxValue);
			s64.zyx = new Divider<ulong3>(o64);
			Assert.AreEqual(s64, new Divider<ulong3>(new ulong3(o64.z, o64.y, o64.x)));
		}

		[Test]
		public static void set_yx()
		{
			byte2 o8 = new byte2(1, 2);
			Divider<byte2> s8 = new Divider<byte2>((byte2)byte.MaxValue);
			s8.yx = new Divider<byte2>(o8);
			Assert.AreEqual(s8, new Divider<byte2>(new byte2(o8.y, o8.x)));
			ushort2 o16 = new ushort2(1, 2);
			Divider<ushort2> s16 = new Divider<ushort2>((ushort2)ushort.MaxValue);
			s16.yx = new Divider<ushort2>(o16);
			Assert.AreEqual(s16, new Divider<ushort2>(new ushort2(o16.y, o16.x)));
			uint2 o32 = new uint2(1, 2);
			Divider<uint2> s32 = new Divider<uint2>((uint2)uint.MaxValue);
			s32.yx = new Divider<uint2>(o32);
			Assert.AreEqual(s32, new Divider<uint2>(new uint2(o32.y, o32.x)));
			ulong2 o64 = new ulong2(1, 2);
			Divider<ulong2> s64 = new Divider<ulong2>((ulong2)ulong.MaxValue);
			s64.yx = new Divider<ulong2>(o64);
			Assert.AreEqual(s64, new Divider<ulong2>(new ulong2(o64.y, o64.x)));
		}
	}
}
