using Unity.Burst.Intrinsics;

namespace MaxMath
{
	unsafe internal static partial class Operator
	{
		internal static partial class Constant
		{
			internal static v128 vdiv_byte(v128 vector, byte divisor)
			{
				return new v128((byte)(vector.Byte0 / divisor), (byte)(vector.Byte1 / divisor), (byte)(vector.Byte2 / divisor), (byte)(vector.Byte3 / divisor), (byte)(vector.Byte4 / divisor), (byte)(vector.Byte5 / divisor), (byte)(vector.Byte6 / divisor), (byte)(vector.Byte7 / divisor), (byte)(vector.Byte8 / divisor), (byte)(vector.Byte9 / divisor), (byte)(vector.Byte10 / divisor), (byte)(vector.Byte11 / divisor), (byte)(vector.Byte12 / divisor), (byte)(vector.Byte13 / divisor), (byte)(vector.Byte14 / divisor), (byte)(vector.Byte15 / divisor));
			}

			internal static v256 vdiv_byte(v256 vector, byte divisor)
			{
				return new v256((byte)(vector.Byte0 / divisor), (byte)(vector.Byte1 / divisor), (byte)(vector.Byte2 / divisor), (byte)(vector.Byte3 / divisor), (byte)(vector.Byte4 / divisor), (byte)(vector.Byte5 / divisor), (byte)(vector.Byte6 / divisor), (byte)(vector.Byte7 / divisor), (byte)(vector.Byte8 / divisor), (byte)(vector.Byte9 / divisor), (byte)(vector.Byte10 / divisor), (byte)(vector.Byte11 / divisor), (byte)(vector.Byte12 / divisor), (byte)(vector.Byte13 / divisor), (byte)(vector.Byte14 / divisor), (byte)(vector.Byte15 / divisor), (byte)(vector.Byte16 / divisor), (byte)(vector.Byte17 / divisor), (byte)(vector.Byte18 / divisor), (byte)(vector.Byte19 / divisor), (byte)(vector.Byte20 / divisor), (byte)(vector.Byte21 / divisor), (byte)(vector.Byte22 / divisor), (byte)(vector.Byte23 / divisor), (byte)(vector.Byte24 / divisor), (byte)(vector.Byte25 / divisor), (byte)(vector.Byte26 / divisor), (byte)(vector.Byte27 / divisor), (byte)(vector.Byte28 / divisor), (byte)(vector.Byte29 / divisor), (byte)(vector.Byte30 / divisor), (byte)(vector.Byte31 / divisor));
			}
		}
	}
}