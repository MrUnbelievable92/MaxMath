using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
	unsafe public static partial class maxmath	
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool16 bool16(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7, bool x8, bool x9, bool x10, bool x11, bool x12, bool x13, bool x14, bool x15) => new bool16(x0, x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool16 bool16(bool x0x16) => new bool16(x0x16);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool16 bool16(bool2 x01, bool2 x23, bool2 x45, bool2 x67, bool2 x89, bool2 x10_11, bool2 x12_13, bool2 x14_15) => new bool16(x01, x23, x45, x67, x89, x10_11, x12_13, x14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool16 bool16(bool4 x0123, bool4 x4567, bool4 x8_9_10_11, bool4 x12_13_14_15) => new bool16(x0123, x4567, x8_9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool16 bool16(bool4 x0123, bool3 x456, bool3 x789, bool3 x10_11_12, bool3 x13_14_15) => new bool16(x0123, x456, x789, x10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool16 bool16(bool3 x012, bool4 x3456, bool3 x789, bool3 x10_11_12, bool3 x13_14_15) => new bool16(x012, x3456, x789, x10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool16 bool16(bool3 x012, bool3 x345, bool4 x6789, bool3 x10_11_12, bool3 x13_14_15) => new bool16(x012, x345, x6789, x10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool16 bool16(bool3 x012, bool3 x345, bool3 x678, bool4 x9_10_11_12, bool3 x13_14_15) => new bool16(x012, x345, x678, x9_10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool16 bool16(bool3 x012, bool3 x345, bool3 x678, bool3 x9_10_11, bool4 x12_13_14_15) => new bool16(x012, x345, x678, x9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool16 bool16(bool8 x01234567, bool4 x8_9_10_11, bool4 x12_13_14_15) => new bool16(x01234567, x8_9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool16 bool16(bool4 x0123, bool8 x4_5_6_7_8_9_10_11, bool4 x12_13_14_15) => new bool16(x0123, x4_5_6_7_8_9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool16 bool16(bool4 x0123, bool4 x4567, bool8 x8_9_10_11_12_13_14_15) => new bool16(x0123, x4567, x8_9_10_11_12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool16 bool16(bool8 x01234567, bool8 x8_9_10_11_12_13_14_15) => new bool16(x01234567, x8_9_10_11_12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool32 bool32(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7, bool x8, bool x9, bool x10, bool x11, bool x12, bool x13, bool x14, bool x15, bool x16, bool x17, bool x18, bool x19, bool x20, bool x21, bool x22, bool x23, bool x24, bool x25, bool x26, bool x27, bool x28, bool x29, bool x30, bool x31) => new bool32(x0, x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15, x16, x17, x18, x19, x20, x21, x22, x23, x24, x25, x26, x27, x28, x29, x30, x31);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool32 bool32(bool x0x32) => new bool32(x0x32);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool32 bool32(bool4 x0_3, bool4 x4_7, bool4 x8_11, bool4 x12_15, bool4 x16_19, bool4 x20_23, bool4 x24_27, bool4 x28_31) => new bool32(x0_3, x4_7, x8_11, x12_15, x16_19, x20_23, x24_27, x28_31);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool32 bool32(bool8 v8_0, bool8 v8_8, bool8 v8_16, bool8 v8_24) => new bool32(v8_0, v8_8, v8_16, v8_24);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool32 bool32(bool16 v16_0, bool8 v8_16, bool8 v8_24) => new bool32(v16_0, v8_16, v8_24);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool32 bool32(bool8 v8_0, bool16 v16_8, bool8 v8_24) => new bool32(v8_0, v16_8, v8_24);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool32 bool32(bool8 v8_0, bool8 v8_8, bool16 v16_16) => new bool32(v8_0, v8_8, v16_16);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool32 bool32(bool16 v16_0, bool16 v16_1) => new bool32(v16_0, v16_1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool8 bool8(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7) => new bool8(x0, x1, x2, x3, x4, x5, x6, x7);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool8 bool8(bool x0x8) => new bool8(x0x8);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool8 bool8(bool2 x01, bool2 x23, bool2 x45, bool2 x67) => new bool8(x01, x23, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool8 bool8(bool2 x01, bool3 x234, bool3 x567) => new bool8(x01, x234, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool8 bool8(bool3 x012, bool2 x34, bool3 x567) => new bool8(x012, x34, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool8 bool8(bool3 x012, bool3 x345, bool2 x67) => new bool8(x012, x345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool8 bool8(bool4 x0123, bool2 x45, bool2 x67) => new bool8(x0123, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool8 bool8(bool2 x01, bool4 x2345, bool2 x67) => new bool8(x01, x2345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool8 bool8(bool2 x01, bool2 x23, bool4 x4567) => new bool8(x01, x23, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool8 bool8(bool4 x0123, bool4 x4567) => new bool8(x0123, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 byte16(byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7, byte x8, byte x9, byte x10, byte x11, byte x12, byte x13, byte x14, byte x15) => new byte16(x0, x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 byte16(byte x0x16) => new byte16(x0x16);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 byte16(byte2 x01, byte2 x23, byte2 x45, byte2 x67, byte2 x89, byte2 x10_11, byte2 x12_13, byte2 x14_15) => new byte16(x01, x23, x45, x67, x89, x10_11, x12_13, x14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 byte16(byte4 x0123, byte4 x4567, byte4 x8_9_10_11, byte4 x12_13_14_15) => new byte16(x0123, x4567, x8_9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 byte16(byte4 x0123, byte3 x456, byte3 x789, byte3 x10_11_12, byte3 x13_14_15) => new byte16(x0123, x456, x789, x10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 byte16(byte3 x012, byte4 x3456, byte3 x789, byte3 x10_11_12, byte3 x13_14_15) => new byte16(x012, x3456, x789, x10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 byte16(byte3 x012, byte3 x345, byte4 x6789, byte3 x10_11_12, byte3 x13_14_15) => new byte16(x012, x345, x6789, x10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 byte16(byte3 x012, byte3 x345, byte3 x678, byte4 x9_10_11_12, byte3 x13_14_15) => new byte16(x012, x345, x678, x9_10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 byte16(byte3 x012, byte3 x345, byte3 x678, byte3 x9_10_11, byte4 x12_13_14_15) => new byte16(x012, x345, x678, x9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 byte16(byte8 x01234567, byte4 x8_9_10_11, byte4 x12_13_14_15) => new byte16(x01234567, x8_9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 byte16(byte4 x0123, byte8 x4_5_6_7_8_9_10_11, byte4 x12_13_14_15) => new byte16(x0123, x4_5_6_7_8_9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 byte16(byte4 x0123, byte4 x4567, byte8 x8_9_10_11_12_13_14_15) => new byte16(x0123, x4567, x8_9_10_11_12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 byte16(byte8 x01234567, byte8 x8_9_10_11_12_13_14_15) => new byte16(x01234567, x8_9_10_11_12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2 byte2(byte x, byte y) => new byte2(x, y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2 byte2(byte xy) => new byte2(xy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3 byte3(byte x, byte y, byte z) => new byte3(x, y, z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3 byte3(byte xyz) => new byte3(xyz);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3 byte3(byte2 xy, byte z) => new byte3(xy, z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3 byte3(byte x, byte2 yz) => new byte3(x, yz);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte32 byte32(byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7, byte x8, byte x9, byte x10, byte x11, byte x12, byte x13, byte x14, byte x15, byte x16, byte x17, byte x18, byte x19, byte x20, byte x21, byte x22, byte x23, byte x24, byte x25, byte x26, byte x27, byte x28, byte x29, byte x30, byte x31) => new byte32(x0, x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15, x16, x17, x18, x19, x20, x21, x22, x23, x24, x25, x26, x27, x28, x29, x30, x31);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte32 byte32(byte x0x32) => new byte32(x0x32);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte32 byte32(byte4 x0_3, byte4 x4_7, byte4 x8_11, byte4 x12_15, byte4 x16_19, byte4 x20_23, byte4 x24_27, byte4 x28_31) => new byte32(x0_3, x4_7, x8_11, x12_15, x16_19, x20_23, x24_27, x28_31);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte32 byte32(byte8 v8_0, byte8 v8_8, byte8 v8_16, byte8 v8_24) => new byte32(v8_0, v8_8, v8_16, v8_24);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte32 byte32(byte16 v16_0, byte8 v8_16, byte8 v8_24) => new byte32(v16_0, v8_16, v8_24);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte32 byte32(byte8 v8_0, byte16 v16_8, byte8 v8_24) => new byte32(v8_0, v16_8, v8_24);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte32 byte32(byte8 v8_0, byte8 v8_8, byte16 v16_16) => new byte32(v8_0, v8_8, v16_16);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte32 byte32(byte16 v16_0, byte16 v16_16) => new byte32(v16_0, v16_16);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 byte4(byte x, byte y, byte z, byte w) => new byte4(x, y, z, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 byte4(byte xyzw) => new byte4(xyzw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 byte4(byte2 xy, byte z, byte w) => new byte4(xy, z, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 byte4(byte x, byte2 yz, byte w) => new byte4(x, yz, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 byte4(byte x, byte y, byte2 zw) => new byte4(x, y, zw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 byte4(byte2 xy, byte2 zw) => new byte4(xy, zw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 byte4(byte3 xyz, byte w) => new byte4(xyz, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 byte4(byte x, byte3 yzw) => new byte4(x, yzw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 byte8(byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7) => new byte8(x0, x1, x2, x3, x4, x5, x6, x7);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 byte8(byte x0x8) => new byte8(x0x8);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 byte8(byte2 x01, byte2 x23, byte2 x45, byte2 x67) => new byte8(x01, x23, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 byte8(byte2 x01, byte3 x234, byte3 x567) => new byte8(x01, x234, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 byte8(byte3 x012, byte2 x34, byte3 x567) => new byte8(x012, x34, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 byte8(byte3 x012, byte3 x345, byte2 x67) => new byte8(x012, x345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 byte8(byte4 x0123, byte2 x45, byte2 x67) => new byte8(x0123, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 byte8(byte2 x01, byte4 x2345, byte2 x67) => new byte8(x01, x2345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 byte8(byte2 x01, byte2 x23, byte4 x4567) => new byte8(x01, x23, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 byte8(byte4 x0123, byte4 x4567) => new byte8(x0123, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 sbyte16(sbyte x0, sbyte x1, sbyte x2, sbyte x3, sbyte x4, sbyte x5, sbyte x6, sbyte x7, sbyte x8, sbyte x9, sbyte x10, sbyte x11, sbyte x12, sbyte x13, sbyte x14, sbyte x15) => new sbyte16(x0, x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 sbyte16(sbyte x0x16) => new sbyte16(x0x16);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 sbyte16(sbyte2 x01, sbyte2 x23, sbyte2 x45, sbyte2 x67, sbyte2 x89, sbyte2 x10_11, sbyte2 x12_13, sbyte2 x14_15) => new sbyte16(x01, x23, x45, x67, x89, x10_11, x12_13, x14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 sbyte16(sbyte4 x0123, sbyte4 x4567, sbyte4 x8_9_10_11, sbyte4 x12_13_14_15) => new sbyte16(x0123, x4567, x8_9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 sbyte16(sbyte4 x0123, sbyte3 x456, sbyte3 x789, sbyte3 x10_11_12, sbyte3 x13_14_15) => new sbyte16(x0123, x456, x789, x10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 sbyte16(sbyte3 x012, sbyte4 x3456, sbyte3 x789, sbyte3 x10_11_12, sbyte3 x13_14_15) => new sbyte16(x012, x3456, x789, x10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 sbyte16(sbyte3 x012, sbyte3 x345, sbyte4 x6789, sbyte3 x10_11_12, sbyte3 x13_14_15) => new sbyte16(x012, x345, x6789, x10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 sbyte16(sbyte3 x012, sbyte3 x345, sbyte3 x678, sbyte4 x9_10_11_12, sbyte3 x13_14_15) => new sbyte16(x012, x345, x678, x9_10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 sbyte16(sbyte3 x012, sbyte3 x345, sbyte3 x678, sbyte3 x9_10_11, sbyte4 x12_13_14_15) => new sbyte16(x012, x345, x678, x9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 sbyte16(sbyte8 x01234567, sbyte4 x8_9_10_11, sbyte4 x12_13_14_15) => new sbyte16(x01234567, x8_9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 sbyte16(sbyte4 x0123, sbyte8 x4_5_6_7_8_9_10_11, sbyte4 x12_13_14_15) => new sbyte16(x0123, x4_5_6_7_8_9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 sbyte16(sbyte4 x0123, sbyte4 x4567, sbyte8 x8_9_10_11_12_13_14_15) => new sbyte16(x0123, x4567, x8_9_10_11_12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 sbyte16(sbyte8 x01234567, sbyte8 x8_9_10_11_12_13_14_15) => new sbyte16(x01234567, x8_9_10_11_12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2 sbyte2(sbyte x, sbyte y) => new sbyte2(x, y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2 sbyte2(sbyte xy) => new sbyte2(xy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3 sbyte3(sbyte x, sbyte y, sbyte z) => new sbyte3(x, y, z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3 sbyte3(sbyte xyz) => new sbyte3(xyz);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3 sbyte3(sbyte2 xy, sbyte z) => new sbyte3(xy, z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3 sbyte3(sbyte x, sbyte2 yz) => new sbyte3(x, yz);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte32 sbyte32(sbyte x0, sbyte x1, sbyte x2, sbyte x3, sbyte x4, sbyte x5, sbyte x6, sbyte x7, sbyte x8, sbyte x9, sbyte x10, sbyte x11, sbyte x12, sbyte x13, sbyte x14, sbyte x15, sbyte x16, sbyte x17, sbyte x18, sbyte x19, sbyte x20, sbyte x21, sbyte x22, sbyte x23, sbyte x24, sbyte x25, sbyte x26, sbyte x27, sbyte x28, sbyte x29, sbyte x30, sbyte x31) => new sbyte32(x0, x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15, x16, x17, x18, x19, x20, x21, x22, x23, x24, x25, x26, x27, x28, x29, x30, x31);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte32 sbyte32(sbyte x0x32) => new sbyte32(x0x32);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte32 sbyte32(sbyte4 x0_3, sbyte4 x4_7, sbyte4 x8_11, sbyte4 x12_15, sbyte4 x16_19, sbyte4 x20_23, sbyte4 x24_27, sbyte4 x28_31) => new sbyte32(x0_3, x4_7, x8_11, x12_15, x16_19, x20_23, x24_27, x28_31);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte32 sbyte32(sbyte8 v8_0, sbyte8 v8_8, sbyte8 v8_16, sbyte8 v8_24) => new sbyte32(v8_0, v8_8, v8_16, v8_24);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte32 sbyte32(sbyte16 v16_0, sbyte8 v8_16, sbyte8 v8_24) => new sbyte32(v16_0, v8_16, v8_24);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte32 sbyte32(sbyte8 v8_0, sbyte16 v16_8, sbyte8 v8_24) => new sbyte32(v8_0, v16_8, v8_24);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte32 sbyte32(sbyte8 v8_0, sbyte8 v8_8, sbyte16 v16_16) => new sbyte32(v8_0, v8_8, v16_16);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte32 sbyte32(sbyte16 v16_0, sbyte16 v16_16) => new sbyte32(v16_0, v16_16);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 sbyte4(sbyte x, sbyte y, sbyte z, sbyte w) => new sbyte4(x, y, z, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 sbyte4(sbyte xyzw) => new sbyte4(xyzw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 sbyte4(sbyte2 xy, sbyte z, sbyte w) => new sbyte4(xy, z, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 sbyte4(sbyte x, sbyte2 yz, sbyte w) => new sbyte4(x, yz, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 sbyte4(sbyte x, sbyte y, sbyte2 zw) => new sbyte4(x, y, zw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 sbyte4(sbyte2 xy, sbyte2 zw) => new sbyte4(xy, zw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 sbyte4(sbyte3 xyz, sbyte w) => new sbyte4(xyz, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 sbyte4(sbyte x, sbyte3 yzw) => new sbyte4(x, yzw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 sbyte8(sbyte x0, sbyte x1, sbyte x2, sbyte x3, sbyte x4, sbyte x5, sbyte x6, sbyte x7) => new sbyte8(x0, x1, x2, x3, x4, x5, x6, x7);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 sbyte8(sbyte x0x8) => new sbyte8(x0x8);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 sbyte8(sbyte2 x01, sbyte2 x23, sbyte2 x45, sbyte2 x67) => new sbyte8(x01, x23, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 sbyte8(sbyte2 x01, sbyte3 x234, sbyte3 x567) => new sbyte8(x01, x234, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 sbyte8(sbyte3 x012, sbyte2 x34, sbyte3 x567) => new sbyte8(x012, x34, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 sbyte8(sbyte3 x012, sbyte3 x345, sbyte2 x67) => new sbyte8(x012, x345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 sbyte8(sbyte4 x0123, sbyte2 x45, sbyte2 x67) => new sbyte8(x0123, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 sbyte8(sbyte2 x01, sbyte4 x2345, sbyte2 x67) => new sbyte8(x01, x2345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 sbyte8(sbyte2 x01, sbyte2 x23, sbyte4 x4567) => new sbyte8(x01, x23, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 sbyte8(sbyte4 x0123, sbyte4 x4567) => new sbyte8(x0123, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 float8(float x0, float x1, float x2, float x3, float x4, float x5, float x6, float x7) => new float8(x0, x1, x2, x3, x4, x5, x6, x7);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 float8(float x0x8) => new float8(x0x8);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 float8(float2 x01, float2 x23, float2 x45, float2 x67) => new float8(x01, x23, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 float8(float2 x01, float3 x234, float3 x567) => new float8(x01, x234, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 float8(float3 x012, float2 x34, float3 x567) => new float8(x012, x34, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 float8(float3 x012, float3 x345, float2 x67) => new float8(x012, x345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 float8(float4 x0123, float2 x45, float2 x67) => new float8(x0123, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 float8(float2 x01, float4 x2345, float2 x67) => new float8(x01, x2345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 float8(float2 x01, float2 x23, float4 x4567) => new float8(x01, x23, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 float8(float4 x0123, float4 x4567) => new float8(x0123, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half8 half8(half x0, half x1, half x2, half x3, half x4, half x5, half x6, half x7) => new half8(x0, x1, x2, x3, x4, x5, x6, x7);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half8 half8(half x0x8) => new half8(x0x8);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half8 half8(half2 x01, half2 x23, half2 x45, half2 x67) => new half8(x01, x23, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half8 half8(half2 x01, half3 x234, half3 x567) => new half8(x01, x234, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half8 half8(half3 x012, half2 x34, half3 x567) => new half8(x012, x34, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half8 half8(half3 x012, half3 x345, half2 x67) => new half8(x012, x345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half8 half8(half4 x0123, half2 x45, half2 x67) => new half8(x0123, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half8 half8(half2 x01, half4 x2345, half2 x67) => new half8(x01, x2345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half8 half8(half2 x01, half2 x23, half4 x4567) => new half8(x01, x23, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half8 half8(half4 x0123, half4 x4567) => new half8(x0123, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 int8(int x0, int x1, int x2, int x3, int x4, int x5, int x6, int x7) => new int8(x0, x1, x2, x3, x4, x5, x6, x7);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 int8(int x0x8) => new int8(x0x8);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 int8(int2 x01, int2 x23, int2 x45, int2 x67) => new int8(x01, x23, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 int8(int2 x01, int3 x234, int3 x567) => new int8(x01, x234, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 int8(int3 x012, int2 x34, int3 x567) => new int8(x012, x34, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 int8(int3 x012, int3 x345, int2 x67) => new int8(x012, x345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 int8(int4 x0123, int2 x45, int2 x67) => new int8(x0123, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 int8(int2 x01, int4 x2345, int2 x67) => new int8(x01, x2345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 int8(int2 x01, int2 x23, int4 x4567) => new int8(x01, x23, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 int8(int4 x0123, int4 x4567) => new int8(x0123, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 uint8(uint x0, uint x1, uint x2, uint x3, uint x4, uint x5, uint x6, uint x7) => new uint8(x0, x1, x2, x3, x4, x5, x6, x7);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 uint8(uint x0x8) => new uint8(x0x8);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 uint8(uint2 x01, uint2 x23, uint2 x45, uint2 x67) => new uint8(x01, x23, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 uint8(uint2 x01, uint3 x234, uint3 x567) => new uint8(x01, x234, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 uint8(uint3 x012, uint2 x34, uint3 x567) => new uint8(x012, x34, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 uint8(uint3 x012, uint3 x345, uint2 x67) => new uint8(x012, x345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 uint8(uint4 x0123, uint2 x45, uint2 x67) => new uint8(x0123, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 uint8(uint2 x01, uint4 x2345, uint2 x67) => new uint8(x01, x2345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 uint8(uint2 x01, uint2 x23, uint4 x4567) => new uint8(x01, x23, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 uint8(uint4 x0123, uint4 x4567) => new uint8(x0123, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2 long2(long x, long y) => new long2(x, y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2 long2(long xy) => new long2(xy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 long3(long x, long y, long z) => new long3(x, y, z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 long3(long xyz) => new long3(xyz);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 long3(long2 xy, long z) => new long3(xy, z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 long3(long x, long2 yz) => new long3(x, yz);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 long4(long x, long y, long z, long w) => new long4(x, y, z, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 long4(long xyzw) => new long4(xyzw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 long4(long2 xy, long z, long w) => new long4(xy, z, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 long4(long x, long2 yz, long w) => new long4(x, yz, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 long4(long x, long y, long2 zw) => new long4(x, y, zw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 long4(long2 xy, long2 zw) => new long4(xy, zw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 long4(long3 xyz, long w) => new long4(xyz, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 long4(long x, long3 yzw) => new long4(x, yzw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 ulong2(ulong x, ulong y) => new ulong2(x, y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 ulong2(ulong xy) => new ulong2(xy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 ulong3(ulong x, ulong y, ulong z) => new ulong3(x, y, z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 ulong3(ulong xyz) => new ulong3(xyz);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 ulong3(ulong2 xy, ulong z) => new ulong3(xy, z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 ulong3(ulong x, ulong2 yz) => new ulong3(x, yz);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 ulong4(ulong x, ulong y, ulong z, ulong w) => new ulong4(x, y, z, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 ulong4(ulong xyzw) => new ulong4(xyzw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 ulong4(ulong2 xy, ulong z, ulong w) => new ulong4(xy, z, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 ulong4(ulong x, ulong2 yz, ulong w) => new ulong4(x, yz, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 ulong4(ulong x, ulong y, ulong2 zw) => new ulong4(x, y, zw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 ulong4(ulong2 xy, ulong2 zw) => new ulong4(xy, zw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 ulong4(ulong3 xyz, ulong w) => new ulong4(xyz, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 ulong4(ulong x, ulong3 yzw) => new ulong4(x, yzw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter2 quarter2(quarter x, quarter y) => new quarter2(x, y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter2 quarter2(quarter xy) => new quarter2(xy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter3 quarter3(quarter x, quarter y, quarter z) => new quarter3(x, y, z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter3 quarter3(quarter xyz) => new quarter3(xyz);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter3 quarter3(quarter2 xy, quarter z) => new quarter3(xy, z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter3 quarter3(quarter x, quarter2 yz) => new quarter3(x, yz);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter4 quarter4(quarter x, quarter y, quarter z, quarter w) => new quarter4(x, y, z, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter4 quarter4(quarter xyzw) => new quarter4(xyzw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter4 quarter4(quarter2 xy, quarter z, quarter w) => new quarter4(xy, z, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter4 quarter4(quarter x, quarter2 yz, quarter w) => new quarter4(x, yz, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter4 quarter4(quarter x, quarter y, quarter2 zw) => new quarter4(x, y, zw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter4 quarter4(quarter2 xy, quarter2 zw) => new quarter4(xy, zw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter4 quarter4(quarter3 xyz, quarter w) => new quarter4(xyz, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter4 quarter4(quarter x, quarter3 yzw) => new quarter4(x, yzw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter8 quarter8(quarter x0, quarter x1, quarter x2, quarter x3, quarter x4, quarter x5, quarter x6, quarter x7) => new quarter8(x0, x1, x2, x3, x4, x5, x6, x7);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter8 quarter8(quarter x0x8) => new quarter8(x0x8);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter8 quarter8(quarter2 x01, quarter2 x23, quarter2 x45, quarter2 x67) => new quarter8(x01, x23, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter8 quarter8(quarter2 x01, quarter3 x234, quarter3 x567) => new quarter8(x01, x234, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter8 quarter8(quarter3 x012, quarter2 x34, quarter3 x567) => new quarter8(x012, x34, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter8 quarter8(quarter3 x012, quarter3 x345, quarter2 x67) => new quarter8(x012, x345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter8 quarter8(quarter4 x0123, quarter2 x45, quarter2 x67) => new quarter8(x0123, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter8 quarter8(quarter2 x01, quarter4 x2345, quarter2 x67) => new quarter8(x01, x2345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter8 quarter8(quarter2 x01, quarter2 x23, quarter4 x4567) => new quarter8(x01, x23, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter8 quarter8(quarter4 x0123, quarter4 x4567) => new quarter8(x0123, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 short16(short x0, short x1, short x2, short x3, short x4, short x5, short x6, short x7, short x8, short x9, short x10, short x11, short x12, short x13, short x14, short x15) => new short16(x0, x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 short16(short x0x16) => new short16(x0x16);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 short16(short2 x01, short2 x23, short2 x45, short2 x67, short2 x89, short2 x10_11, short2 x12_13, short2 x14_15) => new short16(x01, x23, x45, x67, x89, x10_11, x12_13, x14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 short16(short4 x0123, short4 x4567, short4 x8_9_10_11, short4 x12_13_14_15) => new short16(x0123, x4567, x8_9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 short16(short4 x0123, short3 x456, short3 x789, short3 x10_11_12, short3 x13_14_15) => new short16(x0123, x456, x789, x10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 short16(short3 x012, short4 x3456, short3 x789, short3 x10_11_12, short3 x13_14_15) => new short16(x012, x3456, x789, x10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 short16(short3 x012, short3 x345, short4 x6789, short3 x10_11_12, short3 x13_14_15) => new short16(x012, x345, x6789, x10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 short16(short3 x012, short3 x345, short3 x678, short4 x9_10_11_12, short3 x13_14_15) => new short16(x012, x345, x678, x9_10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 short16(short3 x012, short3 x345, short3 x678, short3 x9_10_11, short4 x12_13_14_15) => new short16(x012, x345, x678, x9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 short16(short8 x01234567, short4 x8_9_10_11, short4 x12_13_14_15) => new short16(x01234567, x8_9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 short16(short4 x0123, short8 x4_5_6_7_8_9_10_11, short4 x12_13_14_15) => new short16(x0123, x4_5_6_7_8_9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 short16(short4 x0123, short4 x4567, short8 x8_9_10_11_12_13_14_15) => new short16(x0123, x4567, x8_9_10_11_12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 short16(short8 x01234567, short8 x8_9_10_11_12_13_14_15) => new short16(x01234567, x8_9_10_11_12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2 short2(short x, short y) => new short2(x, y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2 short2(short xy) => new short2(xy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3 short3(short x, short y, short z) => new short3(x, y, z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3 short3(short xyz) => new short3(xyz);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3 short3(short2 xy, short z) => new short3(xy, z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3 short3(short x, short2 yz) => new short3(x, yz);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 short4(short x, short y, short z, short w) => new short4(x, y, z, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 short4(short xyzw) => new short4(xyzw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 short4(short2 xy, short z, short w) => new short4(xy, z, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 short4(short x, short2 yz, short w) => new short4(x, yz, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 short4(short x, short y, short2 zw) => new short4(x, y, zw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 short4(short2 xy, short2 zw) => new short4(xy, zw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 short4(short3 xyz, short w) => new short4(xyz, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 short4(short x, short3 yzw) => new short4(x, yzw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 short8(short x0, short x1, short x2, short x3, short x4, short x5, short x6, short x7) => new short8(x0, x1, x2, x3, x4, x5, x6, x7);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 short8(short x0x8) => new short8(x0x8);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 short8(short2 x01, short2 x23, short2 x45, short2 x67) => new short8(x01, x23, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 short8(short2 x01, short3 x234, short3 x567) => new short8(x01, x234, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 short8(short3 x012, short2 x34, short3 x567) => new short8(x012, x34, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 short8(short3 x012, short3 x345, short2 x67) => new short8(x012, x345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 short8(short4 x0123, short2 x45, short2 x67) => new short8(x0123, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 short8(short2 x01, short4 x2345, short2 x67) => new short8(x01, x2345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 short8(short2 x01, short2 x23, short4 x4567) => new short8(x01, x23, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 short8(short4 x0123, short4 x4567) => new short8(x0123, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 ushort16(ushort x0, ushort x1, ushort x2, ushort x3, ushort x4, ushort x5, ushort x6, ushort x7, ushort x8, ushort x9, ushort x10, ushort x11, ushort x12, ushort x13, ushort x14, ushort x15) => new ushort16(x0, x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 ushort16(ushort x0x16) => new ushort16(x0x16);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 ushort16(ushort2 x01, ushort2 x23, ushort2 x45, ushort2 x67, ushort2 x89, ushort2 x10_11, ushort2 x12_13, ushort2 x14_15) => new ushort16(x01, x23, x45, x67, x89, x10_11, x12_13, x14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 ushort16(ushort4 x0123, ushort4 x4567, ushort4 x8_9_10_11, ushort4 x12_13_14_15) => new ushort16(x0123, x4567, x8_9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 ushort16(ushort4 x0123, ushort3 x456, ushort3 x789, ushort3 x10_11_12, ushort3 x13_14_15) => new ushort16(x0123, x456, x789, x10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 ushort16(ushort3 x012, ushort4 x3456, ushort3 x789, ushort3 x10_11_12, ushort3 x13_14_15) => new ushort16(x012, x3456, x789, x10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 ushort16(ushort3 x012, ushort3 x345, ushort4 x6789, ushort3 x10_11_12, ushort3 x13_14_15) => new ushort16(x012, x345, x6789, x10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 ushort16(ushort3 x012, ushort3 x345, ushort3 x678, ushort4 x9_10_11_12, ushort3 x13_14_15) => new ushort16(x012, x345, x678, x9_10_11_12, x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 ushort16(ushort3 x012, ushort3 x345, ushort3 x678, ushort3 x9_10_11, ushort4 x12_13_14_15) => new ushort16(x012, x345, x678, x9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 ushort16(ushort8 x01234567, ushort4 x8_9_10_11, ushort4 x12_13_14_15) => new ushort16(x01234567, x8_9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 ushort16(ushort4 x0123, ushort8 x4_5_6_7_8_9_10_11, ushort4 x12_13_14_15) => new ushort16(x0123, x4_5_6_7_8_9_10_11, x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 ushort16(ushort4 x0123, ushort4 x4567, ushort8 x8_9_10_11_12_13_14_15) => new ushort16(x0123, x4567, x8_9_10_11_12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 ushort16(ushort8 x01234567, ushort8 x8_9_10_11_12_13_14_15) => new ushort16(x01234567, x8_9_10_11_12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2 ushort2(ushort x, ushort y) => new ushort2(x, y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2 ushort2(ushort xy) => new ushort2(xy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3 ushort3(ushort x, ushort y, ushort z) => new ushort3(x, y, z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3 ushort3(ushort xyz) => new ushort3(xyz);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3 ushort3(ushort2 xy, ushort z) => new ushort3(xy, z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3 ushort3(ushort x, ushort2 yz) => new ushort3(x, yz);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 ushort4(ushort x, ushort y, ushort z, ushort w) => new ushort4(x, y, z, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 ushort4(ushort xyzw) => new ushort4(xyzw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 ushort4(ushort2 xy, ushort z, ushort w) => new ushort4(xy, z, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 ushort4(ushort x, ushort2 yz, ushort w) => new ushort4(x, yz, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 ushort4(ushort x, ushort y, ushort2 zw) => new ushort4(x, y, zw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 ushort4(ushort2 xy, ushort2 zw) => new ushort4(xy, zw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 ushort4(ushort3 xyz, ushort w) => new ushort4(xyz, w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 ushort4(ushort x, ushort3 yzw) => new ushort4(x, yzw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 ushort8(ushort x0, ushort x1, ushort x2, ushort x3, ushort x4, ushort x5, ushort x6, ushort x7) => new ushort8(x0, x1, x2, x3, x4, x5, x6, x7);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 ushort8(ushort x0x8) => new ushort8(x0x8);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 ushort8(ushort2 x01, ushort2 x23, ushort2 x45, ushort2 x67) => new ushort8(x01, x23, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 ushort8(ushort2 x01, ushort3 x234, ushort3 x567) => new ushort8(x01, x234, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 ushort8(ushort3 x012, ushort2 x34, ushort3 x567) => new ushort8(x012, x34, x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 ushort8(ushort3 x012, ushort3 x345, ushort2 x67) => new ushort8(x012, x345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 ushort8(ushort4 x0123, ushort2 x45, ushort2 x67) => new ushort8(x0123, x45, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 ushort8(ushort2 x01, ushort4 x2345, ushort2 x67) => new ushort8(x01, x2345, x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 ushort8(ushort2 x01, ushort2 x23, ushort4 x4567) => new ushort8(x01, x23, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 ushort8(ushort4 x0123, ushort4 x4567) => new ushort8(x0123, x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2x2 byte2x2(byte2 c0, byte2 c1) => new byte2x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2x2 byte2x2(byte m00, byte m01,
									  byte m10, byte m11) => new byte2x2(m00, m01,
																		 m10, m11);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2x2 byte2x2(byte v) => new byte2x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2x3 byte2x3(byte2 c0, byte2 c1, byte2 c2) => new byte2x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2x3 byte2x3(byte m00, byte m01, byte m02,
									  byte m10, byte m11, byte m12) => new byte2x3(m00, m01, m02,
																				   m10, m11, m12);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2x3 byte2x3(byte v) => new byte2x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2x4 byte2x4(byte2 c0, byte2 c1, byte2 c2, byte2 c3) => new byte2x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2x4 byte2x4(byte m00, byte m01, byte m02, byte m03,
									  byte m10, byte m11, byte m12, byte m13) => new byte2x4(m00, m01, m02, m03,
																							 m10, m11, m12, m13);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2x4 byte2x4(byte v) => new byte2x4(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3x2 byte3x2(byte3 c0, byte3 c1) => new byte3x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3x2 byte3x2(byte m00, byte m01,
									  byte m10, byte m11,
									  byte m20, byte m21) => new byte3x2(m00, m01,
																		 m10, m11,
																		 m20, m21);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3x2 byte3x2(byte v) => new byte3x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3x3 byte3x3(byte3 c0, byte3 c1, byte3 c2) => new byte3x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3x3 byte3x3(byte m00, byte m01, byte m02,
									  byte m10, byte m11, byte m12,
									  byte m20, byte m21, byte m22) => new byte3x3(m00, m01, m02,
																				   m10, m11, m12,
																				   m20, m21, m22);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3x3 byte3x3(byte v) => new byte3x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3x4 byte3x4(byte3 c0, byte3 c1, byte3 c2, byte3 c3) => new byte3x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3x4 byte3x4(byte m00, byte m01, byte m02, byte m03,
									  byte m10, byte m11, byte m12, byte m13,
									  byte m20, byte m21, byte m22, byte m23) => new byte3x4(m00, m01, m02, m03,
																						     m10, m11, m12, m13,
																						     m20, m21, m22, m23);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3x4 byte3x4(byte v) => new byte3x4(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4x2 byte4x2(byte4 c0, byte4 c1) => new byte4x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4x2 byte4x2(byte m00, byte m01,
									  byte m10, byte m11,
									  byte m20, byte m21,
									  byte m30, byte m31) => new byte4x2(m00, m01,
																		 m10, m11,
																		 m20, m21,
																		 m30, m31);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4x2 byte4x2(byte v) => new byte4x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4x3 byte4x3(byte4 c0, byte4 c1, byte4 c2) => new byte4x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4x3 byte4x3(byte m00, byte m01, byte m02,
									  byte m10, byte m11, byte m12,
									  byte m20, byte m21, byte m22,
									  byte m30, byte m31, byte m32) => new byte4x3(m00, m01, m02,
																				   m10, m11, m12,
																				   m20, m21, m22,
																				   m30, m31, m32);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4x3 byte4x3(byte v) => new byte4x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4x4 byte4x4(byte4 c0, byte4 c1, byte4 c2, byte4 c3) => new byte4x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4x4 byte4x4(byte m00, byte m01, byte m02, byte m03,
									  byte m10, byte m11, byte m12, byte m13,
									  byte m20, byte m21, byte m22, byte m23,
									  byte m30, byte m31, byte m32, byte m33) => new byte4x4(m00, m01, m02, m03,
																							 m10, m11, m12, m13,
																							 m20, m21, m22, m23,
																							 m30, m31, m32, m33);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4x4 byte4x4(byte v) => new byte4x4(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2x2 sbyte2x2(sbyte2 c0, sbyte2 c1) => new sbyte2x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2x2 sbyte2x2(sbyte m00, sbyte m01,
									    sbyte m10, sbyte m11) => new sbyte2x2(m00, m01,
																		      m10, m11);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2x2 sbyte2x2(sbyte v) => new sbyte2x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2x3 sbyte2x3(sbyte2 c0, sbyte2 c1, sbyte2 c2) => new sbyte2x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2x3 sbyte2x3(sbyte m00, sbyte m01, sbyte m02,
									    sbyte m10, sbyte m11, sbyte m12) => new sbyte2x3(m00, m01, m02,
																				         m10, m11, m12);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2x3 sbyte2x3(sbyte v) => new sbyte2x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2x4 sbyte2x4(sbyte2 c0, sbyte2 c1, sbyte2 c2, sbyte2 c3) => new sbyte2x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2x4 sbyte2x4(sbyte m00, sbyte m01, sbyte m02, sbyte m03,
									    sbyte m10, sbyte m11, sbyte m12, sbyte m13) => new sbyte2x4(m00, m01, m02, m03,
																							        m10, m11, m12, m13);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2x4 sbyte2x4(sbyte v) => new sbyte2x4(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3x2 sbyte3x2(sbyte3 c0, sbyte3 c1) => new sbyte3x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3x2 sbyte3x2(sbyte m00, sbyte m01,
									    sbyte m10, sbyte m11,
									    sbyte m20, sbyte m21) => new sbyte3x2(m00, m01,
																		      m10, m11,
																		      m20, m21);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3x2 sbyte3x2(sbyte v) => new sbyte3x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3x3 sbyte3x3(sbyte3 c0, sbyte3 c1, sbyte3 c2) => new sbyte3x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3x3 sbyte3x3(sbyte m00, sbyte m01, sbyte m02,
									    sbyte m10, sbyte m11, sbyte m12,
									    sbyte m20, sbyte m21, sbyte m22) => new sbyte3x3(m00, m01, m02,
																				         m10, m11, m12,
																				         m20, m21, m22);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3x3 sbyte3x3(sbyte v) => new sbyte3x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3x4 sbyte3x4(sbyte3 c0, sbyte3 c1, sbyte3 c2, sbyte3 c3) => new sbyte3x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3x4 sbyte3x4(sbyte m00, sbyte m01, sbyte m02, sbyte m03,
									    sbyte m10, sbyte m11, sbyte m12, sbyte m13,
									    sbyte m20, sbyte m21, sbyte m22, sbyte m23) => new sbyte3x4(m00, m01, m02, m03,
																						            m10, m11, m12, m13,
																						            m20, m21, m22, m23);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3x4 sbyte3x4(sbyte v) => new sbyte3x4(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4x2 sbyte4x2(sbyte4 c0, sbyte4 c1) => new sbyte4x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4x2 sbyte4x2(sbyte m00, sbyte m01,
									    sbyte m10, sbyte m11,
									    sbyte m20, sbyte m21,
									    sbyte m30, sbyte m31) => new sbyte4x2(m00, m01,
																		      m10, m11,
																		      m20, m21,
																		      m30, m31);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4x2 sbyte4x2(sbyte v) => new sbyte4x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4x3 sbyte4x3(sbyte4 c0, sbyte4 c1, sbyte4 c2) => new sbyte4x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4x3 sbyte4x3(sbyte m00, sbyte m01, sbyte m02,
									    sbyte m10, sbyte m11, sbyte m12,
									    sbyte m20, sbyte m21, sbyte m22,
									    sbyte m30, sbyte m31, sbyte m32) => new sbyte4x3(m00, m01, m02,
																				         m10, m11, m12,
																				         m20, m21, m22,
																				         m30, m31, m32);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4x3 sbyte4x3(sbyte v) => new sbyte4x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4x4 sbyte4x4(sbyte4 c0, sbyte4 c1, sbyte4 c2, sbyte4 c3) => new sbyte4x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4x4 sbyte4x4(sbyte m00, sbyte m01, sbyte m02, sbyte m03,
									    sbyte m10, sbyte m11, sbyte m12, sbyte m13,
									    sbyte m20, sbyte m21, sbyte m22, sbyte m23,
									    sbyte m30, sbyte m31, sbyte m32, sbyte m33) => new sbyte4x4(m00, m01, m02, m03,
																							        m10, m11, m12, m13,
																							        m20, m21, m22, m23,
																							        m30, m31, m32, m33);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4x4 sbyte4x4(sbyte v) => new sbyte4x4(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2x2 long2x2(long2 c0, long2 c1) => new long2x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2x2 long2x2(long m00, long m01,
									  long m10, long m11) => new long2x2(m00, m01,
																		 m10, m11);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2x2 long2x2(long v) => new long2x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2x3 long2x3(long2 c0, long2 c1, long2 c2) => new long2x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2x3 long2x3(long m00, long m01, long m02,
									  long m10, long m11, long m12) => new long2x3(m00, m01, m02,
																				   m10, m11, m12);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2x3 long2x3(long v) => new long2x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2x4 long2x4(long2 c0, long2 c1, long2 c2, long2 c3) => new long2x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2x4 long2x4(long m00, long m01, long m02, long m03,
									  long m10, long m11, long m12, long m13) => new long2x4(m00, m01, m02, m03,
																							 m10, m11, m12, m13);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2x4 long2x4(long v) => new long2x4(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3x2 long3x2(long3 c0, long3 c1) => new long3x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3x2 long3x2(long m00, long m01,
									  long m10, long m11,
									  long m20, long m21) => new long3x2(m00, m01,
																		 m10, m11,
																		 m20, m21);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3x2 long3x2(long v) => new long3x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3x3 long3x3(long3 c0, long3 c1, long3 c2) => new long3x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3x3 long3x3(long m00, long m01, long m02,
									  long m10, long m11, long m12,
									  long m20, long m21, long m22) => new long3x3(m00, m01, m02,
																				   m10, m11, m12,
																				   m20, m21, m22);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3x3 long3x3(long v) => new long3x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3x4 long3x4(long3 c0, long3 c1, long3 c2, long3 c3) => new long3x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3x4 long3x4(long m00, long m01, long m02, long m03,
									  long m10, long m11, long m12, long m13,
									  long m20, long m21, long m22, long m23) => new long3x4(m00, m01, m02, m03,
																						     m10, m11, m12, m13,
																						     m20, m21, m22, m23);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3x4 long3x4(long v) => new long3x4(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4x2 long4x2(long4 c0, long4 c1) => new long4x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4x2 long4x2(long m00, long m01,
									  long m10, long m11,
									  long m20, long m21,
									  long m30, long m31) => new long4x2(m00, m01,
																		 m10, m11,
																		 m20, m21,
																		 m30, m31);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4x2 long4x2(long v) => new long4x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4x3 long4x3(long4 c0, long4 c1, long4 c2) => new long4x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4x3 long4x3(long m00, long m01, long m02,
									  long m10, long m11, long m12,
									  long m20, long m21, long m22,
									  long m30, long m31, long m32) => new long4x3(m00, m01, m02,
																				   m10, m11, m12,
																				   m20, m21, m22,
																				   m30, m31, m32);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4x3 long4x3(long v) => new long4x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4x4 long4x4(long4 c0, long4 c1, long4 c2, long4 c3) => new long4x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4x4 long4x4(long m00, long m01, long m02, long m03,
									  long m10, long m11, long m12, long m13,
									  long m20, long m21, long m22, long m23,
									  long m30, long m31, long m32, long m33) => new long4x4(m00, m01, m02, m03,
																							 m10, m11, m12, m13,
																							 m20, m21, m22, m23,
																							 m30, m31, m32, m33);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4x4 long4x4(long v) => new long4x4(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2x2 ulong2x2(ulong2 c0, ulong2 c1) => new ulong2x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2x2 ulong2x2(ulong m00, ulong m01,
									    ulong m10, ulong m11) => new ulong2x2(m00, m01,
																		      m10, m11);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2x2 ulong2x2(ulong v) => new ulong2x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2x3 ulong2x3(ulong2 c0, ulong2 c1, ulong2 c2) => new ulong2x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2x3 ulong2x3(ulong m00, ulong m01, ulong m02,
									    ulong m10, ulong m11, ulong m12) => new ulong2x3(m00, m01, m02,
																				         m10, m11, m12);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2x3 ulong2x3(ulong v) => new ulong2x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2x4 ulong2x4(ulong2 c0, ulong2 c1, ulong2 c2, ulong2 c3) => new ulong2x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2x4 ulong2x4(ulong m00, ulong m01, ulong m02, ulong m03,
									    ulong m10, ulong m11, ulong m12, ulong m13) => new ulong2x4(m00, m01, m02, m03,
																					       		    m10, m11, m12, m13);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2x4 ulong2x4(ulong v) => new ulong2x4(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3x2 ulong3x2(ulong3 c0, ulong3 c1) => new ulong3x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3x2 ulong3x2(ulong m00, ulong m01,
									    ulong m10, ulong m11,
									    ulong m20, ulong m21) => new ulong3x2(m00, m01,
																		      m10, m11,
																		      m20, m21);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3x2 ulong3x2(ulong v) => new ulong3x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3x3 ulong3x3(ulong3 c0, ulong3 c1, ulong3 c2) => new ulong3x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3x3 ulong3x3(ulong m00, ulong m01, ulong m02,
									    ulong m10, ulong m11, ulong m12,
									    ulong m20, ulong m21, ulong m22) => new ulong3x3(m00, m01, m02,
																				         m10, m11, m12,
																				         m20, m21, m22);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3x3 ulong3x3(ulong v) => new ulong3x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3x4 ulong3x4(ulong3 c0, ulong3 c1, ulong3 c2, ulong3 c3) => new ulong3x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3x4 ulong3x4(ulong m00, ulong m01, ulong m02, ulong m03,
									    ulong m10, ulong m11, ulong m12, ulong m13,
									    ulong m20, ulong m21, ulong m22, ulong m23) => new ulong3x4(m00, m01, m02, m03,
																						            m10, m11, m12, m13,
																						            m20, m21, m22, m23);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3x4 ulong3x4(ulong v) => new ulong3x4(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4x2 ulong4x2(ulong4 c0, ulong4 c1) => new ulong4x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4x2 ulong4x2(ulong m00, ulong m01,
									    ulong m10, ulong m11,
									    ulong m20, ulong m21,
									    ulong m30, ulong m31) => new ulong4x2(m00, m01,
																		      m10, m11,
																		      m20, m21,
																		      m30, m31);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4x2 ulong4x2(ulong v) => new ulong4x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4x3 ulong4x3(ulong4 c0, ulong4 c1, ulong4 c2) => new ulong4x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4x3 ulong4x3(ulong m00, ulong m01, ulong m02,
									    ulong m10, ulong m11, ulong m12,
									    ulong m20, ulong m21, ulong m22,
									    ulong m30, ulong m31, ulong m32) => new ulong4x3(m00, m01, m02,
																				         m10, m11, m12,
																				         m20, m21, m22,
																				         m30, m31, m32);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4x3 ulong4x3(ulong v) => new ulong4x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4x4 ulong4x4(ulong4 c0, ulong4 c1, ulong4 c2, ulong4 c3) => new ulong4x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4x4 ulong4x4(ulong m00, ulong m01, ulong m02, ulong m03,
									    ulong m10, ulong m11, ulong m12, ulong m13,
									    ulong m20, ulong m21, ulong m22, ulong m23,
									    ulong m30, ulong m31, ulong m32, ulong m33) => new ulong4x4(m00, m01, m02, m03,
																							        m10, m11, m12, m13,
																							        m20, m21, m22, m23,
																							        m30, m31, m32, m33);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4x4 ulong4x4(ulong v) => new ulong4x4(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2x2 short2x2(short2 c0, short2 c1) => new short2x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2x2 short2x2(short m00, short m01,
									    short m10, short m11) => new short2x2(m00, m01,
										   								      m10, m11);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2x2 short2x2(short v) => new short2x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2x3 short2x3(short2 c0, short2 c1, short2 c2) => new short2x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2x3 short2x3(short m00, short m01, short m02,
									    short m10, short m11, short m12) => new short2x3(m00, m01, m02,
																				         m10, m11, m12);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2x3 short2x3(short v) => new short2x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2x4 short2x4(short2 c0, short2 c1, short2 c2, short2 c3) => new short2x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2x4 short2x4(short m00, short m01, short m02, short m03,
									    short m10, short m11, short m12, short m13) => new short2x4(m00, m01, m02, m03,
																							        m10, m11, m12, m13);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2x4 short2x4(short v) => new short2x4(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3x2 short3x2(short3 c0, short3 c1) => new short3x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3x2 short3x2(short m00, short m01,
									    short m10, short m11,
									    short m20, short m21) => new short3x2(m00, m01,
																		      m10, m11,
																		      m20, m21);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3x2 short3x2(short v) => new short3x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3x3 short3x3(short3 c0, short3 c1, short3 c2) => new short3x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3x3 short3x3(short m00, short m01, short m02,
								   	    short m10, short m11, short m12,
									    short m20, short m21, short m22) => new short3x3(m00, m01, m02,
																				         m10, m11, m12,
																				         m20, m21, m22);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3x3 short3x3(short v) => new short3x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3x4 short3x4(short3 c0, short3 c1, short3 c2, short3 c3) => new short3x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3x4 short3x4(short m00, short m01, short m02, short m03,
									    short m10, short m11, short m12, short m13,
									    short m20, short m21, short m22, short m23) => new short3x4(m00, m01, m02, m03,
																						            m10, m11, m12, m13,
																						            m20, m21, m22, m23);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3x4 short3x4(short v) => new short3x4(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4x2 short4x2(short4 c0, short4 c1) => new short4x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4x2 short4x2(short m00, short m01,
									    short m10, short m11,
									    short m20, short m21,
									    short m30, short m31) => new short4x2(m00, m01,
																		      m10, m11,
																		      m20, m21,
																		      m30, m31);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4x2 short4x2(short v) => new short4x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4x3 short4x3(short4 c0, short4 c1, short4 c2) => new short4x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4x3 short4x3(short m00, short m01, short m02,
									    short m10, short m11, short m12,
									    short m20, short m21, short m22,
									    short m30, short m31, short m32) => new short4x3(m00, m01, m02,
																				         m10, m11, m12,
																				         m20, m21, m22,
																				         m30, m31, m32);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4x3 short4x3(short v) => new short4x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4x4 short4x4(short4 c0, short4 c1, short4 c2, short4 c3) => new short4x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4x4 short4x4(short m00, short m01, short m02, short m03,
									    short m10, short m11, short m12, short m13,
									    short m20, short m21, short m22, short m23,
									    short m30, short m31, short m32, short m33) => new short4x4(m00, m01, m02, m03,
																							        m10, m11, m12, m13,
																							        m20, m21, m22, m23,
																							        m30, m31, m32, m33);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4x4 short4x4(short v) => new short4x4(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2x2 ushort2x2(ushort2 c0, ushort2 c1) => new ushort2x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2x2 ushort2x2(ushort m00, ushort m01,
									      ushort m10, ushort m11) => new ushort2x2(m00, m01,
																		           m10, m11);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2x2 ushort2x2(ushort v) => new ushort2x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2x3 ushort2x3(ushort2 c0, ushort2 c1, ushort2 c2) => new ushort2x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2x3 ushort2x3(ushort m00, ushort m01, ushort m02,
									      ushort m10, ushort m11, ushort m12) => new ushort2x3(m00, m01, m02,
											            									   m10, m11, m12);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2x3 ushort2x3(ushort v) => new ushort2x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2x4 ushort2x4(ushort2 c0, ushort2 c1, ushort2 c2, ushort2 c3) => new ushort2x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2x4 ushort2x4(ushort m00, ushort m01, ushort m02, ushort m03,
									      ushort m10, ushort m11, ushort m12, ushort m13) => new ushort2x4(m00, m01, m02, m03,
										               													   m10, m11, m12, m13);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2x4 ushort2x4(ushort v) => new ushort2x4(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3x2 ushort3x2(ushort3 c0, ushort3 c1) => new ushort3x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3x2 ushort3x2(ushort m00, ushort m01,
									      ushort m10, ushort m11,
									      ushort m20, ushort m21) => new ushort3x2(m00, m01,
											           							   m10, m11,
																		           m20, m21);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3x2 ushort3x2(ushort v) => new ushort3x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3x3 ushort3x3(ushort3 c0, ushort3 c1, ushort3 c2) => new ushort3x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3x3 ushort3x3(ushort m00, ushort m01, ushort m02,
									      ushort m10, ushort m11, ushort m12,
									      ushort m20, ushort m21, ushort m22) => new ushort3x3(m00, m01, m02,
																				               m10, m11, m12,
																				               m20, m21, m22);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3x3 ushort3x3(ushort v) => new ushort3x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3x4 ushort3x4(ushort3 c0, ushort3 c1, ushort3 c2, ushort3 c3) => new ushort3x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3x4 ushort3x4(ushort m00, ushort m01, ushort m02, ushort m03,
									      ushort m10, ushort m11, ushort m12, ushort m13,
									      ushort m20, ushort m21, ushort m22, ushort m23) => new ushort3x4(m00, m01, m02, m03,
																						                   m10, m11, m12, m13,
																						                   m20, m21, m22, m23);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3x4 ushort3x4(ushort v) => new ushort3x4(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4x2 ushort4x2(ushort4 c0, ushort4 c1) => new ushort4x2(c0, c1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4x2 ushort4x2(ushort m00, ushort m01,
									      ushort m10, ushort m11,
									      ushort m20, ushort m21,
									      ushort m30, ushort m31) => new ushort4x2(m00, m01,
																		           m10, m11,
																		           m20, m21,
																		           m30, m31);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4x2 ushort4x2(ushort v) => new ushort4x2(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4x3 ushort4x3(ushort4 c0, ushort4 c1, ushort4 c2) => new ushort4x3(c0, c1, c2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4x3 ushort4x3(ushort m00, ushort m01, ushort m02,
									      ushort m10, ushort m11, ushort m12,
									      ushort m20, ushort m21, ushort m22,
									      ushort m30, ushort m31, ushort m32) => new ushort4x3(m00, m01, m02,
																				               m10, m11, m12,
																				               m20, m21, m22,
																				               m30, m31, m32);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4x3 ushort4x3(ushort v) => new ushort4x3(v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4x4 ushort4x4(ushort4 c0, ushort4 c1, ushort4 c2, ushort4 c3) => new ushort4x4(c0, c1, c2, c3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4x4 ushort4x4(ushort m00, ushort m01, ushort m02, ushort m03,
									      ushort m10, ushort m11, ushort m12, ushort m13,
									      ushort m20, ushort m21, ushort m22, ushort m23,
									      ushort m30, ushort m31, ushort m32, ushort m33) => new ushort4x4(m00, m01, m02, m03,
																							               m10, m11, m12, m13,
																							               m20, m21, m22, m23,
																							               m30, m31, m32, m33);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4x4 ushort4x4(ushort v) => new ushort4x4(v);
	}
}