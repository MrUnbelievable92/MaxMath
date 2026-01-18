using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 shuffle(bool2 x, long2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 shuffle(bool3 x, long3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 shuffle(bool4 x, long4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 shuffle(bool2 x, ulong2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 shuffle(bool3 x, ulong3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 shuffle(bool4 x, ulong4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 shuffle(bool2 x, int2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 shuffle(bool3 x, int3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 shuffle(bool4 x, int4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool8 shuffle(bool8 x, int8 idx)
		{
			return shuffle(x, (sbyte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 shuffle(bool2 x, uint2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 shuffle(bool3 x, uint3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 shuffle(bool4 x, uint4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool8 shuffle(bool8 x, uint8 idx)
		{
			return shuffle(x, (sbyte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 shuffle(bool2 x, short2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 shuffle(bool3 x, short3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 shuffle(bool4 x, short4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool8 shuffle(bool8 x, short8 idx)
		{
			return shuffle(x, (sbyte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool16 shuffle(bool16 x, short16 idx)
		{
			return shuffle(x, (sbyte16)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 shuffle(bool2 x, ushort2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 shuffle(bool3 x, ushort3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 shuffle(bool4 x, ushort4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool8 shuffle(bool8 x, ushort8 idx)
		{
			return shuffle(x, (sbyte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool16 shuffle(bool16 x, ushort16 idx)
		{
			return shuffle(x, (sbyte16)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 shuffle(bool2 x, sbyte2 idx)
		{
			return tobool(shuffle(tosbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 shuffle(bool3 x, sbyte3 idx)
		{
			return tobool(shuffle(tosbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 shuffle(bool4 x, sbyte4 idx)
		{
			return tobool(shuffle(tosbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool8 shuffle(bool8 x, sbyte8 idx)
		{
			return tobool(shuffle(tosbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool16 shuffle(bool16 x, sbyte16 idx)
		{
			return tobool(shuffle(tosbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool32 shuffle(bool32 x, sbyte32 idx)
		{
			return tobool(shuffle(tosbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 shuffle(bool2 x, byte2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 shuffle(bool3 x, byte3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 shuffle(bool4 x, byte4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool8 shuffle(bool8 x, byte8 idx)
		{
			return shuffle(x, (sbyte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool16 shuffle(bool16 x, byte16 idx)
		{
			return shuffle(x, (sbyte16)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool32 shuffle(bool32 x, byte32 idx)
		{
			return shuffle(x, (sbyte32)idx);
		}


		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2 shuffle(sbyte2 x, long2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3 shuffle(sbyte3 x, long3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 shuffle(sbyte4 x, long4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2 shuffle(sbyte2 x, ulong2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3 shuffle(sbyte3 x, ulong3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 shuffle(sbyte4 x, ulong4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2 shuffle(sbyte2 x, int2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3 shuffle(sbyte3 x, int3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 shuffle(sbyte4 x, int4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 shuffle(sbyte8 x, int8 idx)
		{
			return shuffle(x, (sbyte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2 shuffle(sbyte2 x, uint2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3 shuffle(sbyte3 x, uint3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 shuffle(sbyte4 x, uint4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 shuffle(sbyte8 x, uint8 idx)
		{
			return shuffle(x, (sbyte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2 shuffle(sbyte2 x, short2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3 shuffle(sbyte3 x, short3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 shuffle(sbyte4 x, short4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 shuffle(sbyte8 x, short8 idx)
		{
			return shuffle(x, (sbyte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 shuffle(sbyte16 x, short16 idx)
		{
			return shuffle(x, (sbyte16)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2 shuffle(sbyte2 x, ushort2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3 shuffle(sbyte3 x, ushort3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 shuffle(sbyte4 x, ushort4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 shuffle(sbyte8 x, ushort8 idx)
		{
			return shuffle(x, (sbyte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 shuffle(sbyte16 x, ushort16 idx)
		{
			return shuffle(x, (sbyte16)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2 shuffle(sbyte2 x, sbyte2 idx)
		{
			return (sbyte2)shuffle((byte2)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3 shuffle(sbyte3 x, sbyte3 idx)
		{
			return (sbyte3)shuffle((byte3)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 shuffle(sbyte4 x, sbyte4 idx)
		{
			return (sbyte4)shuffle((byte4)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 shuffle(sbyte8 x, sbyte8 idx)
		{
			return (sbyte8)shuffle((byte8)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 shuffle(sbyte16 x, sbyte16 idx)
		{
			return (sbyte16)shuffle((byte16)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte32 shuffle(sbyte32 x, sbyte32 idx)
		{
			return (sbyte32)shuffle((byte32)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2 shuffle(sbyte2 x, byte2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3 shuffle(sbyte3 x, byte3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 shuffle(sbyte4 x, byte4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 shuffle(sbyte8 x, byte8 idx)
		{
			return shuffle(x, (sbyte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 shuffle(sbyte16 x, byte16 idx)
		{
			return shuffle(x, (sbyte16)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte32 shuffle(sbyte32 x, byte32 idx)
		{
			return shuffle(x, (sbyte32)idx);
		}


		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2 shuffle(byte2 x, long2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3 shuffle(byte3 x, long3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 shuffle(byte4 x, long4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2 shuffle(byte2 x, ulong2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3 shuffle(byte3 x, ulong3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 shuffle(byte4 x, ulong4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2 shuffle(byte2 x, int2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3 shuffle(byte3 x, int3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 shuffle(byte4 x, int4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 shuffle(byte8 x, int8 idx)
		{
			return shuffle(x, (sbyte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2 shuffle(byte2 x, uint2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3 shuffle(byte3 x, uint3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 shuffle(byte4 x, uint4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 shuffle(byte8 x, uint8 idx)
		{
			return shuffle(x, (sbyte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2 shuffle(byte2 x, short2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3 shuffle(byte3 x, short3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 shuffle(byte4 x, short4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 shuffle(byte8 x, short8 idx)
		{
			return shuffle(x, (sbyte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 shuffle(byte16 x, short16 idx)
		{
			return shuffle(x, (sbyte16)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2 shuffle(byte2 x, ushort2 idx)
		{
			return shuffle(x, (sbyte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3 shuffle(byte3 x, ushort3 idx)
		{
			return shuffle(x, (sbyte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 shuffle(byte4 x, ushort4 idx)
		{
			return shuffle(x, (sbyte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 shuffle(byte8 x, ushort8 idx)
		{
			return shuffle(x, (sbyte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 shuffle(byte16 x, ushort16 idx)
		{
			return shuffle(x, (sbyte16)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2 shuffle(byte2 x, sbyte2 idx)
		{
			return shuffle(x, (byte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3 shuffle(byte3 x, sbyte3 idx)
		{
			return shuffle(x, (byte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 shuffle(byte4 x, sbyte4 idx)
		{
			return shuffle(x, (byte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 shuffle(byte8 x, sbyte8 idx)
		{
			return shuffle(x, (byte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 shuffle(byte16 x, sbyte16 idx)
		{
			return shuffle(x, (byte16)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte32 shuffle(byte32 x, sbyte32 idx)
		{
			return shuffle(x, (byte32)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2 shuffle(byte2 x, byte2 idx)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.shuffle_epi8(x, idx);
			}
			else
			{
				return new byte2(x[idx.x], x[idx.y]);
			}
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3 shuffle(byte3 x, byte3 idx)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.shuffle_epi8(x, idx);
			}
			else
			{
				return new byte3(x[idx.x], x[idx.y], x[idx.z]);
			}
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 shuffle(byte4 x, byte4 idx)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.shuffle_epi8(x, idx);
			}
			else
			{
				return new byte4(x[idx.x], x[idx.y], x[idx.z], x[idx.w]);
			}
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 shuffle(byte8 x, byte8 idx)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.shuffle_epi8(x, idx);
			}
			else
			{
				return new byte8(x[idx.x0], x[idx.x1], x[idx.x2], x[idx.x3], x[idx.x4], x[idx.x5], x[idx.x6], x[idx.x7]);
			}
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 shuffle(byte16 x, byte16 idx)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.shuffle_epi8(x, idx);
			}
			else
			{
				return new byte16(x[idx.x0], x[idx.x1], x[idx.x2], x[idx.x3], x[idx.x4], x[idx.x5], x[idx.x6], x[idx.x7], x[idx.x8], x[idx.x9], x[idx.x10], x[idx.x11], x[idx.x12], x[idx.x13], x[idx.x14], x[idx.x15]);
			}
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte32 shuffle(byte32 x, byte32 idx)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_permutevar_epi8(x, idx);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				Xse.dshuffle_epi8(x.v16_0, x.v16_16, idx.v16_0, idx.v16_16, out v128 lo, out v128 hi);
				return new byte32(lo, hi);
			}
			else
			{
				return new byte32(x[idx.x0], x[idx.x1], x[idx.x2], x[idx.x3], x[idx.x4], x[idx.x5], x[idx.x6], x[idx.x7], x[idx.x8], x[idx.x9], x[idx.x10], x[idx.x11], x[idx.x12], x[idx.x13], x[idx.x14], x[idx.x15], x[idx.x16], x[idx.x17], x[idx.x18], x[idx.x19], x[idx.x20], x[idx.x21], x[idx.x22], x[idx.x23], x[idx.x24], x[idx.x25], x[idx.x26], x[idx.x27], x[idx.x28], x[idx.x29], x[idx.x30], x[idx.x31]);
			}
		}


		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2 shuffle(short2 x, long2 idx)
		{
			return shuffle(x, (short2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3 shuffle(short3 x, long3 idx)
		{
			return shuffle(x, (short3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 shuffle(short4 x, long4 idx)
		{
			return shuffle(x, (short4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2 shuffle(short2 x, ulong2 idx)
		{
			return shuffle(x, (short2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3 shuffle(short3 x, ulong3 idx)
		{
			return shuffle(x, (short3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 shuffle(short4 x, ulong4 idx)
		{
			return shuffle(x, (short4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2 shuffle(short2 x, int2 idx)
		{
			return shuffle(x, (short2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3 shuffle(short3 x, int3 idx)
		{
			return shuffle(x, (short3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 shuffle(short4 x, int4 idx)
		{
			return shuffle(x, (short4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 shuffle(short8 x, int8 idx)
		{
			return shuffle(x, (short8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2 shuffle(short2 x, uint2 idx)
		{
			return shuffle(x, (short2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3 shuffle(short3 x, uint3 idx)
		{
			return shuffle(x, (short3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 shuffle(short4 x, uint4 idx)
		{
			return shuffle(x, (short4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 shuffle(short8 x, uint8 idx)
		{
			return shuffle(x, (short8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2 shuffle(short2 x, short2 idx)
		{
			return (short2)shuffle((ushort2)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3 shuffle(short3 x, short3 idx)
		{
			return (short3)shuffle((ushort3)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 shuffle(short4 x, short4 idx)
		{
			return (short4)shuffle((ushort4)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 shuffle(short8 x, short8 idx)
		{
			return (short8)shuffle((ushort8)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 shuffle(short16 x, short16 idx)
		{
			return (short16)shuffle((ushort16)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2 shuffle(short2 x, ushort2 idx)
		{
			return shuffle(x, (short2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3 shuffle(short3 x, ushort3 idx)
		{
			return shuffle(x, (short3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 shuffle(short4 x, ushort4 idx)
		{
			return shuffle(x, (short4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 shuffle(short8 x, ushort8 idx)
		{
			return shuffle(x, (short8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 shuffle(short16 x, ushort16 idx)
		{
			return shuffle(x, (short16)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2 shuffle(short2 x, sbyte2 idx)
		{
			return shuffle(x, (byte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3 shuffle(short3 x, sbyte3 idx)
		{
			return shuffle(x, (byte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 shuffle(short4 x, sbyte4 idx)
		{
			return shuffle(x, (byte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 shuffle(short8 x, sbyte8 idx)
		{
			return shuffle(x, (byte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 shuffle(short16 x, sbyte16 idx)
		{
			return shuffle(x, (byte16)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2 shuffle(short2 x, byte2 idx)
		{
			return shuffle(x, (short2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3 shuffle(short3 x, byte3 idx)
		{
			return shuffle(x, (short3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 shuffle(short4 x, byte4 idx)
		{
			return shuffle(x, (short4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 shuffle(short8 x, byte8 idx)
		{
			return shuffle(x, (short8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 shuffle(short16 x, byte16 idx)
		{
			return shuffle(x, (short16)idx);
		}


		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2 shuffle(ushort2 x, long2 idx)
		{
			return shuffle(x, (short2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3 shuffle(ushort3 x, long3 idx)
		{
			return shuffle(x, (short3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 shuffle(ushort4 x, long4 idx)
		{
			return shuffle(x, (short4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2 shuffle(ushort2 x, ulong2 idx)
		{
			return shuffle(x, (short2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3 shuffle(ushort3 x, ulong3 idx)
		{
			return shuffle(x, (short3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 shuffle(ushort4 x, ulong4 idx)
		{
			return shuffle(x, (short4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2 shuffle(ushort2 x, int2 idx)
		{
			return shuffle(x, (short2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3 shuffle(ushort3 x, int3 idx)
		{
			return shuffle(x, (short3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 shuffle(ushort4 x, int4 idx)
		{
			return shuffle(x, (short4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 shuffle(ushort8 x, int8 idx)
		{
			return shuffle(x, (short8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2 shuffle(ushort2 x, uint2 idx)
		{
			return shuffle(x, (short2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3 shuffle(ushort3 x, uint3 idx)
		{
			return shuffle(x, (short3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 shuffle(ushort4 x, uint4 idx)
		{
			return shuffle(x, (short4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 shuffle(ushort8 x, uint8 idx)
		{
			return shuffle(x, (short8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2 shuffle(ushort2 x, short2 idx)
		{
			return shuffle(x, (ushort2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3 shuffle(ushort3 x, short3 idx)
		{
			return shuffle(x, (ushort3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 shuffle(ushort4 x, short4 idx)
		{
			return shuffle(x, (ushort4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 shuffle(ushort8 x, short8 idx)
		{
			return shuffle(x, (ushort8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 shuffle(ushort16 x, short16 idx)
		{
			return shuffle(x, (ushort16)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2 shuffle(ushort2 x, ushort2 idx)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.shuffle_epi16(x, idx);
			}
			else
			{
				return new ushort2(x[idx.x], x[idx.y]);
			}
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3 shuffle(ushort3 x, ushort3 idx)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.shuffle_epi16(x, idx);
			}
			else
			{
				return new ushort3(x[idx.x], x[idx.y], x[idx.z]);
			}
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 shuffle(ushort4 x, ushort4 idx)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.shuffle_epi16(x, idx);
			}
			else
			{
				return new ushort4(x[idx.x], x[idx.y], x[idx.z], x[idx.w]);
			}
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 shuffle(ushort8 x, ushort8 idx)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.shuffle_epi16(x, idx);
			}
			else
			{
				return new ushort8(x[idx.x0], x[idx.x1], x[idx.x2], x[idx.x3], x[idx.x4], x[idx.x5], x[idx.x6], x[idx.x7]);
			}
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 shuffle(ushort16 x, ushort16 idx)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_permutevar_epi16(x, idx);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				Xse.dshuffle_epi16(x.v8_0, x.v8_8, idx.v8_0, idx.v8_8, out v128 lo, out v128 hi);
				return new ushort16(lo, hi);
			}
			else
			{
				return new ushort16(x[idx.x0], x[idx.x1], x[idx.x2], x[idx.x3], x[idx.x4], x[idx.x5], x[idx.x6], x[idx.x7], x[idx.x8], x[idx.x9], x[idx.x10], x[idx.x11], x[idx.x12], x[idx.x13], x[idx.x14], x[idx.x15]);
			}
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2 shuffle(ushort2 x, sbyte2 idx)
		{
			return shuffle(x, (byte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3 shuffle(ushort3 x, sbyte3 idx)
		{
			return shuffle(x, (byte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 shuffle(ushort4 x, sbyte4 idx)
		{
			return shuffle(x, (byte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 shuffle(ushort8 x, sbyte8 idx)
		{
			return shuffle(x, (byte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 shuffle(ushort16 x, sbyte16 idx)
		{
			return shuffle(x, (byte16)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2 shuffle(ushort2 x, byte2 idx)
		{
			return shuffle(x, (short2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3 shuffle(ushort3 x, byte3 idx)
		{
			return shuffle(x, (short3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 shuffle(ushort4 x, byte4 idx)
		{
			return shuffle(x, (short4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 shuffle(ushort8 x, byte8 idx)
		{
			return shuffle(x, (short8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 shuffle(ushort16 x, byte16 idx)
		{
			return shuffle(x, (short16)idx);
		}


		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 shuffle(int2 x, long2 idx)
		{
			return shuffle(x, (int2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 shuffle(int3 x, long3 idx)
		{
			return shuffle(x, (int3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 shuffle(int4 x, long4 idx)
		{
			return shuffle(x, (int4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 shuffle(int2 x, ulong2 idx)
		{
			return shuffle(x, (int2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 shuffle(int3 x, ulong3 idx)
		{
			return shuffle(x, (int3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 shuffle(int4 x, ulong4 idx)
		{
			return shuffle(x, (int4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 shuffle(int2 x, int2 idx)
		{
			return (int2)shuffle((uint2)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 shuffle(int3 x, int3 idx)
		{
			return (int3)shuffle((uint3)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 shuffle(int4 x, int4 idx)
		{
			return (int4)shuffle((uint4)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 shuffle(int8 x, int8 idx)
		{
			return (int8)shuffle((uint8)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 shuffle(int2 x, uint2 idx)
		{
			return shuffle(x, (int2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 shuffle(int3 x, uint3 idx)
		{
			return shuffle(x, (int3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 shuffle(int4 x, uint4 idx)
		{
			return shuffle(x, (int4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 shuffle(int8 x, uint8 idx)
		{
			return shuffle(x, (int8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 shuffle(int2 x, short2 idx)
		{
			return shuffle(x, (ushort2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 shuffle(int3 x, short3 idx)
		{
			return shuffle(x, (ushort3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 shuffle(int4 x, short4 idx)
		{
			return shuffle(x, (ushort4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 shuffle(int8 x, short8 idx)
		{
			return shuffle(x, (ushort8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 shuffle(int2 x, ushort2 idx)
		{
			return shuffle(x, (int2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 shuffle(int3 x, ushort3 idx)
		{
			return shuffle(x, (int3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 shuffle(int4 x, ushort4 idx)
		{
			return shuffle(x, (int4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 shuffle(int8 x, ushort8 idx)
		{
			return shuffle(x, (int8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 shuffle(int2 x, sbyte2 idx)
		{
			return shuffle(x, (byte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 shuffle(int3 x, sbyte3 idx)
		{
			return shuffle(x, (byte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 shuffle(int4 x, sbyte4 idx)
		{
			return shuffle(x, (byte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 shuffle(int8 x, sbyte8 idx)
		{
			return shuffle(x, (byte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 shuffle(int2 x, byte2 idx)
		{
			return shuffle(x, (int2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 shuffle(int3 x, byte3 idx)
		{
			return shuffle(x, (int3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 shuffle(int4 x, byte4 idx)
		{
			return shuffle(x, (int4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 shuffle(int8 x, byte8 idx)
		{
			return shuffle(x, (int8)idx);
		}


		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 shuffle(uint2 x, long2 idx)
		{
			return shuffle(x, (int2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 shuffle(uint3 x, long3 idx)
		{
			return shuffle(x, (int3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 shuffle(uint4 x, long4 idx)
		{
			return shuffle(x, (int4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 shuffle(uint2 x, ulong2 idx)
		{
			return shuffle(x, (int2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 shuffle(uint3 x, ulong3 idx)
		{
			return shuffle(x, (int3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 shuffle(uint4 x, ulong4 idx)
		{
			return shuffle(x, (int4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 shuffle(uint2 x, int2 idx)
		{
			return shuffle(x, (uint2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 shuffle(uint3 x, int3 idx)
		{
			return shuffle(x, (uint3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 shuffle(uint4 x, int4 idx)
		{
			return shuffle(x, (uint4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 shuffle(uint8 x, int8 idx)
		{
			return shuffle(x, (uint8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 shuffle(uint2 x, uint2 idx)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return RegisterConversion.ToUInt2(Xse.permutevar_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(idx)));
			}
			else
			{
				return new uint2(x[(int)idx.x], x[(int)idx.y]);
			}
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 shuffle(uint3 x, uint3 idx)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return RegisterConversion.ToUInt3(Xse.permutevar_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(idx)));
			}
			else
			{
				return new uint3(x[(int)idx.x], x[(int)idx.y], x[(int)idx.z]);
			}
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 shuffle(uint4 x, uint4 idx)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return RegisterConversion.ToUInt4(Xse.permutevar_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(idx)));
			}
			else
			{
				return new uint4(x[(int)idx.x], x[(int)idx.y], x[(int)idx.z], x[(int)idx.w]);
			}
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 shuffle(uint8 x, uint8 idx)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_permutevar8x32_epi32(x, idx);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				Xse.dshuffle_epi32(RegisterConversion.ToV128(x.v4_0), RegisterConversion.ToV128(x.v4_4), RegisterConversion.ToV128(idx.v4_0), RegisterConversion.ToV128(idx.v4_4), out v128 lo, out v128 hi);
				return new uint8(RegisterConversion.ToUInt4(lo), RegisterConversion.ToUInt4(hi));
			}
			else
			{
				return new uint8(x[(int)idx.x0], x[(int)idx.x1], x[(int)idx.x2], x[(int)idx.x3], x[(int)idx.x4], x[(int)idx.x5], x[(int)idx.x6], x[(int)idx.x7]);
			}
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 shuffle(uint2 x, short2 idx)
		{
			return shuffle(x, (ushort2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 shuffle(uint3 x, short3 idx)
		{
			return shuffle(x, (ushort3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 shuffle(uint4 x, short4 idx)
		{
			return shuffle(x, (ushort4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 shuffle(uint8 x, short8 idx)
		{
			return shuffle(x, (ushort8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 shuffle(uint2 x, ushort2 idx)
		{
			return shuffle(x, (uint2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 shuffle(uint3 x, ushort3 idx)
		{
			return shuffle(x, (uint3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 shuffle(uint4 x, ushort4 idx)
		{
			return shuffle(x, (uint4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 shuffle(uint8 x, ushort8 idx)
		{
			return shuffle(x, (uint8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 shuffle(uint2 x, sbyte2 idx)
		{
			return shuffle(x, (byte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 shuffle(uint3 x, sbyte3 idx)
		{
			return shuffle(x, (byte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 shuffle(uint4 x, sbyte4 idx)
		{
			return shuffle(x, (byte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 shuffle(uint8 x, sbyte8 idx)
		{
			return shuffle(x, (byte8)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 shuffle(uint2 x, byte2 idx)
		{
			return shuffle(x, (int2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 shuffle(uint3 x, byte3 idx)
		{
			return shuffle(x, (int3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 shuffle(uint4 x, byte4 idx)
		{
			return shuffle(x, (int4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 shuffle(uint8 x, byte8 idx)
		{
			return shuffle(x, (int8)idx);
		}


		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2 shuffle(long2 x, long2 idx)
		{
			return (long2)shuffle((ulong2)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 shuffle(long3 x, long3 idx)
		{
			return (long3)shuffle((ulong3)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 shuffle(long4 x, long4 idx)
		{
			return (long4)shuffle((ulong4)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2 shuffle(long2 x, ulong2 idx)
		{
			return (long2)shuffle((ulong2)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 shuffle(long3 x, ulong3 idx)
		{
			return (long3)shuffle((ulong3)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 shuffle(long4 x, ulong4 idx)
		{
			return (long4)shuffle((ulong4)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2 shuffle(long2 x, int2 idx)
		{
			return (long2)shuffle((ulong2)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 shuffle(long3 x, int3 idx)
		{
			return (long3)shuffle((ulong3)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 shuffle(long4 x, int4 idx)
		{
			return (long4)shuffle((ulong4)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2 shuffle(long2 x, uint2 idx)
		{
			return (long2)shuffle((ulong2)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 shuffle(long3 x, uint3 idx)
		{
			return (long3)shuffle((ulong3)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 shuffle(long4 x, uint4 idx)
		{
			return (long4)shuffle((ulong4)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2 shuffle(long2 x, short2 idx)
		{
			return (long2)shuffle((ulong2)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 shuffle(long3 x, short3 idx)
		{
			return (long3)shuffle((ulong3)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 shuffle(long4 x, short4 idx)
		{
			return (long4)shuffle((ulong4)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2 shuffle(long2 x, ushort2 idx)
		{
			return (long2)shuffle((ulong2)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 shuffle(long3 x, ushort3 idx)
		{
			return (long3)shuffle((ulong3)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 shuffle(long4 x, ushort4 idx)
		{
			return (long4)shuffle((ulong4)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2 shuffle(long2 x, sbyte2 idx)
		{
			return (long2)shuffle((ulong2)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 shuffle(long3 x, sbyte3 idx)
		{
			return (long3)shuffle((ulong3)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 shuffle(long4 x, sbyte4 idx)
		{
			return (long4)shuffle((ulong4)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2 shuffle(long2 x, byte2 idx)
		{
			return (long2)shuffle((ulong2)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 shuffle(long3 x, byte3 idx)
		{
			return (long3)shuffle((ulong3)x, idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 shuffle(long4 x, byte4 idx)
		{
			return (long4)shuffle((ulong4)x, idx);
		}


		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 shuffle(ulong2 x, long2 idx)
		{
			return shuffle(x, (ulong2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 shuffle(ulong3 x, long3 idx)
		{
			return shuffle(x, (ulong3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 shuffle(ulong4 x, long4 idx)
		{
			return shuffle(x, (ulong4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 shuffle(ulong2 x, ulong2 idx)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.permutevar_epi64(x, idx);
			}
			else
			{
				return new ulong2(x[(int)idx.x], x[(int)idx.y]);
			}
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 shuffle(ulong3 x, ulong3 idx)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_permutevar_epi64(x, idx);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				Xse.dshuffle_epi64(x.xy, x.zz, idx.xy, idx.zz, out v128 lo, out v128 hi);
				return new ulong3(lo, hi.ULong0);
			}
			else
			{
				return new ulong3(x[(int)idx.x], x[(int)idx.y], x[(int)idx.z]);
			}
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 shuffle(ulong4 x, ulong4 idx)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_permutevar_epi64(x, idx);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				Xse.dshuffle_epi64(x.xy, x.zw, idx.xy, idx.zw, out v128 lo, out v128 hi);
				return new ulong4(lo, hi);
			}
			else
			{
				return new ulong4(x[(int)idx.x], x[(int)idx.y], x[(int)idx.z], x[(int)idx.w]);
			}
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 shuffle(ulong2 x, int2 idx)
		{
			return shuffle(x, (uint2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 shuffle(ulong3 x, int3 idx)
		{
			return shuffle(x, (uint3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 shuffle(ulong4 x, int4 idx)
		{
			return shuffle(x, (uint4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 shuffle(ulong2 x, uint2 idx)
		{
			return shuffle(x, (ulong2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 shuffle(ulong3 x, uint3 idx)
		{
			return shuffle(x, (ulong3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 shuffle(ulong4 x, uint4 idx)
		{
			return shuffle(x, (ulong4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 shuffle(ulong2 x, short2 idx)
		{
			return shuffle(x, (ushort2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 shuffle(ulong3 x, short3 idx)
		{
			return shuffle(x, (ushort3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 shuffle(ulong4 x, short4 idx)
		{
			return shuffle(x, (ushort4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 shuffle(ulong2 x, ushort2 idx)
		{
			return shuffle(x, (ulong2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 shuffle(ulong3 x, ushort3 idx)
		{
			return shuffle(x, (ulong3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 shuffle(ulong4 x, ushort4 idx)
		{
			return shuffle(x, (ulong4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 shuffle(ulong2 x, sbyte2 idx)
		{
			return shuffle(x, (byte2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 shuffle(ulong3 x, sbyte3 idx)
		{
			return shuffle(x, (byte3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 shuffle(ulong4 x, sbyte4 idx)
		{
			return shuffle(x, (byte4)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 shuffle(ulong2 x, byte2 idx)
		{
			return shuffle(x, (ulong2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 shuffle(ulong3 x, byte3 idx)
		{
			return shuffle(x, (ulong3)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 shuffle(ulong4 x, byte4 idx)
		{
			return shuffle(x, (ulong4)idx);
		}


		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter2 shuffle(quarter2 x, long2 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter3 shuffle(quarter3 x, long3 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter4 shuffle(quarter4 x, long4 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter2 shuffle(quarter2 x, ulong2 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter3 shuffle(quarter3 x, ulong3 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter4 shuffle(quarter4 x, ulong4 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter2 shuffle(quarter2 x, int2 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter3 shuffle(quarter3 x, int3 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter4 shuffle(quarter4 x, int4 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter8 shuffle(quarter8 x, int8 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter2 shuffle(quarter2 x, uint2 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter3 shuffle(quarter3 x, uint3 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter4 shuffle(quarter4 x, uint4 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter8 shuffle(quarter8 x, uint8 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter2 shuffle(quarter2 x, short2 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter3 shuffle(quarter3 x, short3 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter4 shuffle(quarter4 x, short4 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter8 shuffle(quarter8 x, short8 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter16 shuffle(quarter16 x, short16 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter2 shuffle(quarter2 x, ushort2 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter3 shuffle(quarter3 x, ushort3 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter4 shuffle(quarter4 x, ushort4 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter8 shuffle(quarter8 x, ushort8 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter16 shuffle(quarter16 x, ushort16 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter2 shuffle(quarter2 x, sbyte2 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter3 shuffle(quarter3 x, sbyte3 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter4 shuffle(quarter4 x, sbyte4 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter8 shuffle(quarter8 x, sbyte8 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter16 shuffle(quarter16 x, sbyte16 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter32 shuffle(quarter32 x, sbyte32 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter2 shuffle(quarter2 x, byte2 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter3 shuffle(quarter3 x, byte3 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter4 shuffle(quarter4 x, byte4 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter8 shuffle(quarter8 x, byte8 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter16 shuffle(quarter16 x, byte16 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quarter32 shuffle(quarter32 x, byte32 idx)
		{
			return asquarter(shuffle(asbyte(x), idx));
		}


		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half2 shuffle(half2 x, long2 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half3 shuffle(half3 x, long3 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 shuffle(half4 x, long4 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half2 shuffle(half2 x, ulong2 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half3 shuffle(half3 x, ulong3 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 shuffle(half4 x, ulong4 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half2 shuffle(half2 x, int2 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half3 shuffle(half3 x, int3 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 shuffle(half4 x, int4 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half8 shuffle(half8 x, int8 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half2 shuffle(half2 x, uint2 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half3 shuffle(half3 x, uint3 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 shuffle(half4 x, uint4 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half8 shuffle(half8 x, uint8 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half2 shuffle(half2 x, short2 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half3 shuffle(half3 x, short3 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 shuffle(half4 x, short4 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half8 shuffle(half8 x, short8 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half16 shuffle(half16 x, short16 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half2 shuffle(half2 x, ushort2 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half3 shuffle(half3 x, ushort3 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 shuffle(half4 x, ushort4 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half8 shuffle(half8 x, ushort8 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half16 shuffle(half16 x, ushort16 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half2 shuffle(half2 x, sbyte2 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half3 shuffle(half3 x, sbyte3 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 shuffle(half4 x, sbyte4 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half8 shuffle(half8 x, sbyte8 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half16 shuffle(half16 x, sbyte16 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half2 shuffle(half2 x, byte2 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half3 shuffle(half3 x, byte3 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 shuffle(half4 x, byte4 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half8 shuffle(half8 x, byte8 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half16 shuffle(half16 x, byte16 idx)
		{
			return ashalf(shuffle(asushort(x), idx));
		}


		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 shuffle(float2 x, long2 idx)
		{
			return shuffle(x, (int2)idx);
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 shuffle(float3 x, long3 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 shuffle(float4 x, long4 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 shuffle(float2 x, ulong2 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 shuffle(float3 x, ulong3 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 shuffle(float4 x, ulong4 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 shuffle(float2 x, int2 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 shuffle(float3 x, int3 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 shuffle(float4 x, int4 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 shuffle(float8 x, int8 idx)
		{
			return asfloat(shuffle(asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 shuffle(float2 x, uint2 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 shuffle(float3 x, uint3 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 shuffle(float4 x, uint4 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 shuffle(float8 x, uint8 idx)
		{
			return asfloat(shuffle(asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 shuffle(float2 x, short2 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 shuffle(float3 x, short3 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 shuffle(float4 x, short4 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 shuffle(float8 x, short8 idx)
		{
			return asfloat(shuffle(asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 shuffle(float2 x, ushort2 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 shuffle(float3 x, ushort3 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 shuffle(float4 x, ushort4 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 shuffle(float8 x, ushort8 idx)
		{
			return asfloat(shuffle(asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 shuffle(float2 x, sbyte2 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 shuffle(float3 x, sbyte3 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 shuffle(float4 x, sbyte4 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 shuffle(float8 x, sbyte8 idx)
		{
			return asfloat(shuffle(asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 shuffle(float2 x, byte2 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 shuffle(float3 x, byte3 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 shuffle(float4 x, byte4 idx)
		{
			return math.asfloat(shuffle(math.asuint(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 shuffle(float8 x, byte8 idx)
		{
			return asfloat(shuffle(asuint(x), idx));
		}


		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 shuffle(double2 x, long2 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 shuffle(double3 x, long3 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 shuffle(double4 x, long4 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 shuffle(double2 x, ulong2 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 shuffle(double3 x, ulong3 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 shuffle(double4 x, ulong4 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 shuffle(double2 x, int2 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 shuffle(double3 x, int3 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 shuffle(double4 x, int4 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 shuffle(double2 x, uint2 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 shuffle(double3 x, uint3 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 shuffle(double4 x, uint4 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 shuffle(double2 x, short2 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 shuffle(double3 x, short3 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 shuffle(double4 x, short4 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 shuffle(double2 x, ushort2 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 shuffle(double3 x, ushort3 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 shuffle(double4 x, ushort4 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 shuffle(double2 x, sbyte2 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 shuffle(double3 x, sbyte3 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 shuffle(double4 x, sbyte4 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 shuffle(double2 x, byte2 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 shuffle(double3 x, byte3 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}

		/// <summary>	Returns a permutation of the vector <paramref name="x"/> according to the order of indices stored in <paramref name="idx"/>. Each compononent in the result corresponds to the n-th component in <paramref name="x"/>, where n is the corresponding component in <paramref name="idx"/>.	 </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 shuffle(double4 x, byte4 idx)
		{
			return asdouble(shuffle(asulong(x), idx));
		}
    }
}