using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using DevTools;
using MaxMath.Intrinsics;

using static MaxMath.Intrinsics.Xse;
using static Unity.Burst.Intrinsics.X86;
using static MaxMath.math;

#pragma warning disable CS0660

namespace MaxMath
{
#if DEBUG
	internal sealed class mask32x8DebuggerProxy
	{
		public bool x0;
		public bool x1;
		public bool x2;
		public bool x3;
		public bool x4;
		public bool x5;
		public bool x6;
		public bool x7;
		
		public mask32x8DebuggerProxy(mask32x8 v)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				x0 = ((v256)v.mask).UInt0 != 0;
				x1 = ((v256)v.mask).UInt1 != 0;
				x2 = ((v256)v.mask).UInt2 != 0;
				x3 = ((v256)v.mask).UInt3 != 0;
				x4 = ((v256)v.mask).UInt4 != 0;
				x5 = ((v256)v.mask).UInt5 != 0;
				x6 = ((v256)v.mask).UInt6 != 0;
				x7 = ((v256)v.mask).UInt7 != 0;
			}
			else
			{
				x0 = ((v256)v.mask).Byte0 != 0;
				x1 = ((v256)v.mask).Byte1 != 0;
				x2 = ((v256)v.mask).Byte2 != 0;
				x3 = ((v256)v.mask).Byte3 != 0;
				x4 = ((v256)v.mask).Byte4 != 0;
				x5 = ((v256)v.mask).Byte5 != 0;
				x6 = ((v256)v.mask).Byte6 != 0;
				x7 = ((v256)v.mask).Byte7 != 0;
			}
		}
	}

	[System.Diagnostics.DebuggerTypeProxy(typeof(mask32x8DebuggerProxy))]
#endif
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	unsafe public ref struct mask32x8
	{
		internal ulong4 mask;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal mask32x8(v256 mask)
		{
			this.mask = mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal mask32x8(v128 maskLo, v128 maskHi)
		{
			this.mask = new ulong4(maskLo, maskHi);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v256)new uint8((uint)-tobyte(x0), (uint)-tobyte(x1), (uint)-tobyte(x2), (uint)-tobyte(x3), (uint)-tobyte(x4), (uint)-tobyte(x5), (uint)-tobyte(x6), (uint)-tobyte(x7));
			}
			else
			{
				this = new v256((v128)new byte8(tobyte(x0), tobyte(x1), tobyte(x2), tobyte(x3), tobyte(x4), tobyte(x5), tobyte(x6), tobyte(x7)), default(v128));
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(bool x0x8) => this = (mask32x8)x0x8;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(mask32x2 x01, mask32x2 x23, mask32x2 x45, mask32x2 x67)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v256)new uint8((uint2)(v128)x01, (uint2)(v128)x23, (uint2)(v128)x45, (uint2)(v128)x67);
			}
			else
			{
				this = new bool8((bool2)x01, (bool2)x23, (bool2)x45, (bool2)x67);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(mask32x2 x01, mask32x3 x234, mask32x3 x567)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v256)new uint8((uint2)(v128)x01, (uint3)(v128)x234, (uint3)(v128)x567);
			}
			else
			{
				this = new bool8((bool2)x01, (bool3)x234, (bool3)x567);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(mask32x3 x012, mask32x2 x34, mask32x3 x567)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v256)new uint8((uint3)(v128)x012, (uint2)(v128)x34, (uint3)(v128)x567);
			}
			else
			{
				this = new bool8((bool3)x012, (bool2)x34, (bool3)x567);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(mask32x3 x012, mask32x3 x345, mask32x2 x67)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v256)new uint8((uint3)(v128)x012, (uint3)(v128)x345, (uint2)(v128)x67);
			}
			else
			{
				this = new bool8((bool3)x012, (bool3)x345, (bool2)x67);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(mask32x4 x0123, mask32x2 x45, mask32x2 x67)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v256)new uint8((uint4)(v128)x0123, (uint2)(v128)x45, (uint2)(v128)x67);
			}
			else
			{
				this = new bool8((bool4)x0123, (bool2)x45, (bool2)x67);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(mask32x2 x01, mask32x4 x2345, mask32x2 x67)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v256)new uint8((uint2)(v128)x01, (uint4)(v128)x2345, (uint2)(v128)x67);
			}
			else
			{
				this = new bool8((bool2)x01, (bool4)x2345, (bool2)x67);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(mask32x2 x01, mask32x2 x23, mask32x4 x4567)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v256)new uint8((uint2)(v128)x01, (uint2)(v128)x23, (uint4)(v128)x4567);
			}
			else
			{
				this = new bool8((bool2)x01, (bool2)x23, (bool4)x4567);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(mask32x4 x0123, mask32x4 x4567)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v256)new uint8((uint4)(v128)x0123, (uint4)(v128)x4567);
			}
			else
			{
				this = new bool8((bool4)x0123, (bool4)x4567);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(bool8 v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(byte v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(byte8 v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(sbyte v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(sbyte8 v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(ushort v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(ushort8 v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(short v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(short8 v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(uint v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(uint8 v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(int v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(int8 v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(ulong v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(long v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(UInt128 v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(Int128 v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(quarter v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(quarter8 v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(half v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(half8 v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(float v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(float8 v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(double v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(quadruple v) => this = (mask32x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask32x8(Unity.Mathematics.half v) => this = (mask32x8)(half)v;



		public bool x0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[0];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[0] = value;
		}
		public bool x1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[1];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[1] = value;
		}
		public bool x2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[2];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[2] = value;
		}
		public bool x3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[3];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[3] = value;
		}
		public bool x4
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[4];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[4] = value;
		}
		public bool x5
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[5];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[5] = value;
		}
		public bool x6
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[6];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[6] = value;
		}
		public bool x7
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[7];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[7] = value;
		}


		public mask32x2 v2_0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v2_0;
				}
				else
				{
					return ((bool8)this).v2_0;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v2_0 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v2_0 = value;
					this = stack;
				}
			}
		}
		public mask32x2 v2_1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v2_1;
				}
				else
				{
					return ((bool8)this).v2_1;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v2_1 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v2_1 = value;
					this = stack;
				}
			}
		}
		public mask32x2 v2_2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v2_2;
				}
				else
				{
					return ((bool8)this).v2_2;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v2_2 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v2_2 = value;
					this = stack;
				}
			}
		}
		public mask32x2 v2_3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v2_3;
				}
				else
				{
					return ((bool8)this).v2_3;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v2_3 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v2_3 = value;
					this = stack;
				}
			}
		}
		public mask32x2 v2_4
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v2_4;
				}
				else
				{
					return ((bool8)this).v2_4;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v2_4 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v2_4 = value;
					this = stack;
				}
			}
		}
		public mask32x2 v2_5
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v2_5;
				}
				else
				{
					return ((bool8)this).v2_5;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v2_5 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v2_5 = value;
					this = stack;
				}
			}
		}
		public mask32x2 v2_6
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v2_6;
				}
				else
				{
					return ((bool8)this).v2_6;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v2_6 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v2_6 = value;
					this = stack;
				}
			}
		}
		public mask32x3 v3_0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v3_0;
				}
				else
				{
					return ((bool8)this).v3_0;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v3_0 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v3_0 = value;
					this = stack;
				}
			}
		}
		public mask32x3 v3_1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v3_1;
				}
				else
				{
					return ((bool8)this).v3_1;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v3_1 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v3_1 = value;
					this = stack;
				}
			}
		}
		public mask32x3 v3_2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v3_2;
				}
				else
				{
					return ((bool8)this).v3_2;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v3_2 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v3_2 = value;
					this = stack;
				}
			}
		}
		public mask32x3 v3_3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v3_3;
				}
				else
				{
					return ((bool8)this).v3_3;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v3_3 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v3_3 = value;
					this = stack;
				}
			}
		}
		public mask32x3 v3_4
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v3_4;
				}
				else
				{
					return ((bool8)this).v3_4;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v3_4 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v3_4 = value;
					this = stack;
				}
			}
		}
		public mask32x3 v3_5
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v3_5;
				}
				else
				{
					return ((bool8)this).v3_5;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v3_5 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v3_5 = value;
					this = stack;
				}
			}
		}
		public mask32x4 v4_0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v4_0;
				}
				else
				{
					return ((bool8)this).v4_0;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v4_0 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v4_0 = value;
					this = stack;
				}
			}
		}
		public mask32x4 v4_1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v4_1;
				}
				else
				{
					return ((bool8)this).v4_1;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v4_1 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v4_1 = value;
					this = stack;
				}
			}
		}
		public mask32x4 v4_2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v4_2;
				}
				else
				{
					return ((bool8)this).v4_2;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v4_2 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v4_2 = value;
					this = stack;
				}
			}
		}
		public mask32x4 v4_3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v4_3;
				}
				else
				{
					return ((bool8)this).v4_3;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v4_3 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v4_3 = value;
					this = stack;
				}
			}
		}
		public mask32x4 v4_4
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((uint8)(v256)mask).v4_4;
				}
				else
				{
					return ((bool8)this).v4_4;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = ((uint8)(v256)mask);
					reinterpret.v4_4 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v4_4 = value;
					this = stack;
				}
			}
		}


		public bool this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
Assert.IsWithinArrayBounds(index, 8);

				if (BurstArchitecture.IsSIMDSupported)
				{
					return mask.Reinterpret<ulong4, uint8>()[index] != 0;
				}
				else
				{
					return ((bool8)this)[index];
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
Assert.IsWithinArrayBounds(index, 8);

				if (BurstArchitecture.IsSIMDSupported)
				{
					uint8 reinterpret = mask.Reinterpret<ulong4, uint8>();
					reinterpret[index] = (uint)-tolong(value);
					mask = reinterpret.Reinterpret<uint8, ulong4>();
				}
				else
				{
					bool8 reinterpret = this;
					reinterpret[index] = value;
					this = reinterpret;
				}
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator v256(mask32x8 input)
		{
			return input.mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask32x8(v256 input)
		{
			return new mask32x8 { mask = input };
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool8(mask32x8 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_cvtepi32_epi8(Xse.mm256_neg_epi32(input));
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				v128 lo = Xse.cvtepi32_epi8(input.v4_0);
				v128 hi = Xse.cvtepi32_epi8(input.v4_4);

				return Xse.neg_epi8(unpacklo_epi32(lo, hi));
			}
			else
			{
				return *(bool8*)&input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask32x8(bool8 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				return mm256_neg_epi32(Avx2.mm256_cvtepu8_epi32(input));
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask32x8(neg_epi32(cvtepu8_epi32(input.v4_0)), neg_epi32(cvtepu8_epi32(input.v4_4)));
			}
			else
			{
				mask32x8 result = default(mask32x8);
				*(bool8*)&result = input;
				return result;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask32x8(bool input)
		{
			if (Avx.IsAvxSupported)
			{
				return mm256_set1_epi64x(-tolong(input));
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask32x8(set1_epi64x(-tolong(input)), set1_epi64x(-tolong(input)));
			}
			else
			{
				return (bool8)input;
			}
		}
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(byte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(ushort v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(uint v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(ulong v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(UInt128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(sbyte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(short v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(int v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(long v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(Int128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(quarter v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(half v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(float v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(double v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(quadruple v) => math.andnot(v != 0, math.isnan(v));


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator ! (mask32x8 value)
		{
			if (Avx.IsAvxSupported)
			{
				return mm256_not_si256(value);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask32x8(not_si128(value.mask.xy), not_si128(value.mask.zw));
			}
			else
			{
				return !(bool8)value;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator & (mask32x8 left, mask32x8 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_and_ps(left, right);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask32x8(and_si128(left.mask.xy, right.mask.xy), and_si128(left.mask.zw, right.mask.zw));
			}
			else
			{
				return (bool8)left & (bool8)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator & (mask32x8 left, bool right) => left & (mask32x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator & (bool left, mask32x8 right) => (mask32x8)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator & (mask32x8 left, bool8 right) => left & (mask32x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator & (bool8 left, mask32x8 right) => (mask32x8)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator | (mask32x8 left, mask32x8 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_or_ps(left, right);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask32x8(or_si128(left.mask.xy, right.mask.xy), or_si128(left.mask.zw, right.mask.zw));
			}
			else
			{
				return (bool8)left | (bool8)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator | (mask32x8 left, bool right) => left | (mask32x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator | (bool left, mask32x8 right) => (mask32x8)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator | (mask32x8 left, bool8 right) => left | (mask32x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator | (bool8 left, mask32x8 right) => (mask32x8)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator ^ (mask32x8 left, mask32x8 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_xor_ps(left, right);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask32x8(xor_si128(left.mask.xy, right.mask.xy), xor_si128(left.mask.zw, right.mask.zw));
			}
			else
			{
				return (bool8)left ^ (bool8)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator ^ (mask32x8 left, bool right) => left ^ (mask32x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator ^ (bool left, mask32x8 right) => (mask32x8)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator ^ (mask32x8 left, bool8 right) => left ^ (mask32x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator ^ (bool8 left, mask32x8 right) => (mask32x8)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator != (mask32x8 left, mask32x8 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_xor_ps(left, right);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask32x8(xor_si128(left.v4_0, right.v4_0), xor_si128(left.v4_4, right.v4_4));
			}
			else
			{
				return (bool8)left != (bool8)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator != (mask32x8 left, bool right) => left != (mask32x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator != (bool left, mask32x8 right) => (mask32x8)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator != (mask32x8 left, bool8 right) => left != (mask32x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator != (bool8 left, mask32x8 right) => (mask32x8)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator == (mask32x8 left, mask32x8 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_cmpeq_epi32(left, right);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask32x8(cmpeq_epi32(left.v4_0, right.v4_0), cmpeq_epi32(left.v4_4, right.v4_4));
			}
			else
			{
				return (bool8)left == (bool8)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator == (mask32x8 left, bool right) => left == (mask32x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator == (bool left, mask32x8 right) => (mask32x8)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator == (mask32x8 left, bool8 right) => left == (mask32x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator == (bool8 left, mask32x8 right) => (mask32x8)left == right;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool Equals(mask32x8 other)
		{
			if (Avx2.IsAvx2Supported)
			{
				return mm256_alltrue_epi256<uint>(Avx2.mm256_cmpeq_epi32(this, other), 8);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				bool lo = alltrue_epi128<uint>(cmpeq_epi32(this.mask.xy, other.mask.xy));
				bool hi = alltrue_epi128<uint>(cmpeq_epi32(this.mask.zw, other.mask.zw));
				return lo & hi;
			}
			else
			{
				return ((bool8)this).Equals((bool8)other);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override readonly int GetHashCode()
		{
			return bitmask(this);
		}

		public override readonly string ToString()
		{
			return ((bool8)this).ToString();
		}

        
        /// <summary>       Returns a <see cref="bool4"/> from the first 8 bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 FromBitmask(int bitmask)
        {
            mask32x8 result;
            if (Avx2.IsAvx2Supported)
            {
                result = Xse.mm256_broadcastmask_epi32(bitmask, MaskType.AllOnes);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                result = new mask32x8(Xse.broadcastmask_epi32(bitmask, MaskType.AllOnes), Xse.broadcastmask_epi32(bitmask >> 4, MaskType.AllOnes));
            }
            else
            {
                result = bool8.FromBitmask(bitmask);
            }

            constexpr.ASSUME(math.bitmask(result) == (bitmask & 0b1111_1111));
            return result;
        }
	}
}
#pragma warning restore CS0660
