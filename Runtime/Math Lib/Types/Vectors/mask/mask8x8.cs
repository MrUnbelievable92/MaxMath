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
	internal sealed class mask8x8DebuggerProxy
	{
		public bool x0;
		public bool x1;
		public bool x2;
		public bool x3;
		public bool x4;
		public bool x5;
		public bool x6;
		public bool x7;

		public mask8x8DebuggerProxy(mask8x8 v)
		{
			x0 = ((v128)v.mask).Byte0 != 0;
			x1 = ((v128)v.mask).Byte1 != 0;
			x2 = ((v128)v.mask).Byte2 != 0;
			x3 = ((v128)v.mask).Byte3 != 0;
			x4 = ((v128)v.mask).Byte4 != 0;
			x5 = ((v128)v.mask).Byte5 != 0;
			x6 = ((v128)v.mask).Byte6 != 0;
			x7 = ((v128)v.mask).Byte7 != 0;
		}
	}
	
	[System.Diagnostics.DebuggerTypeProxy(typeof(mask8x8DebuggerProxy))]
#endif
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	unsafe public ref struct mask8x8
	{
		internal ulong2 mask;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal mask8x8(v128 mask)
		{
			this.mask = mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal mask8x8(v128 maskLo, v128 maskHi)
		{
			this.mask = (v128)new byte8((byte4)maskLo, (byte4)maskHi);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v128)new byte8((byte)-tobyte(x0), (byte)-tobyte(x1), (byte)-tobyte(x2), (byte)-tobyte(x3), (byte)-tobyte(x4), (byte)-tobyte(x5), (byte)-tobyte(x6), (byte)-tobyte(x7));
			}
			else
			{
				this = (v128)new byte8(tobyte(x0), tobyte(x1), tobyte(x2), tobyte(x3), tobyte(x4), tobyte(x5), tobyte(x6), tobyte(x7));
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(bool x0x8) => this = (mask8x8)x0x8;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(mask8x2 x01, mask8x2 x23, mask8x2 x45, mask8x2 x67) => this = (v128)new byte8((byte2)(v128)x01, (byte2)(v128)x23, (byte2)(v128)x45, (byte2)(v128)x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(mask8x2 x01, mask8x3 x234, mask8x3 x567) => this = (v128)new byte8((byte2)(v128)x01, (byte3)(v128)x234, (byte3)(v128)x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(mask8x3 x012, mask8x2 x34, mask8x3 x567) => this = (v128)new byte8((byte3)(v128)x012, (byte2)(v128)x34, (byte3)(v128)x567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(mask8x3 x012, mask8x3 x345, mask8x2 x67) => this = (v128)new byte8((byte3)(v128)x012, (byte3)(v128)x345, (byte2)(v128)x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(mask8x4 x0123, mask8x2 x45, mask8x2 x67) => this = (v128)new byte8((byte4)(v128)x0123, (byte2)(v128)x45, (byte2)(v128)x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(mask8x2 x01, mask8x4 x2345, mask8x2 x67) => this = (v128)new byte8((byte2)(v128)x01, (byte4)(v128)x2345, (byte2)(v128)x67);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(mask8x2 x01, mask8x2 x23, mask8x4 x4567) => this = (v128)new byte8((byte2)(v128)x01, (byte2)(v128)x23, (byte4)(v128)x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(mask8x4 x0123, mask8x4 x4567) => this = (v128)new byte8((byte4)(v128)x0123, (byte4)(v128)x4567);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(bool8 v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(byte v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(byte8 v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(sbyte v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(sbyte8 v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(ushort v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(ushort8 v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(short v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(short8 v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(uint v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(uint8 v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(int v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(int8 v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(ulong v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(long v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(UInt128 v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(Int128 v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(quarter v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(quarter8 v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(half v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(half8 v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(float v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(float8 v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(double v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(quadruple v) => this = (mask8x8)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x8(Unity.Mathematics.half v) => this = (mask8x8)(half)v;



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


		public mask8x2 v2_0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v2_0;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v2_0 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v2_0 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v2_1;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v2_1 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v2_1 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v2_2;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v2_2 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v2_2 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v2_3;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v2_3 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v2_3 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_4
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v2_4;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v2_4 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v2_4 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_5
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v2_5;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v2_5 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v2_5 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_6
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v2_6;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v2_6 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v2_6 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v3_0;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v3_0 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v3_0 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v3_1;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v3_1 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v3_1 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v3_2;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v3_2 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v3_2 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v3_3;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v3_3 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v3_3 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_4
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v3_4;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v3_4 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v3_4 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_5
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v3_5;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v3_5 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v3_5 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v4_0;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v4_0 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v4_0 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v4_1;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v4_1 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v4_1 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v4_2;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v4_2 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v4_2 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v4_3;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v4_3 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool8 stack = this;
					stack.v4_3 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_4
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v4_4;
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
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v4_4 = (v128)value;
					this = (v128)reinterpret;
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
					return mask.Reinterpret<ulong2, byte16>()[index] != 0;
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
					byte16 reinterpret = mask.Reinterpret<ulong2, byte16>();
					reinterpret[index] = (byte)-tolong(value);
					mask = reinterpret.Reinterpret<byte16, ulong2>();
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
		public static implicit operator v128(mask8x8 input)
		{
			return input.mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x8(v128 input)
		{
			return new mask8x8 { mask = input };
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x8(mask16x8 input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return packs_epi16(input, input);
			}
			else
			{
				return *(mask8x8*)&input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x8(mask32x8 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				return mm256_cvtepi32_epi8(input);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask8x8(cvtepi32_epi8(input.mask.xy), cvtepi32_epi8(input.mask.zw));
			}
			else
			{
				return (bool8)input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask16x8(mask8x8 input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return cvtepi8_epi16(input);
			}
			else
			{
				return *(mask16x8*)&input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask32x8(mask8x8 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_cvtepi8_epi32(input);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask32x8(cvtepi8_epi32(input), cvtepi8_epi32(bsrli_si128(input, 4 * sizeof(byte))));
			}
			else
			{
				return (bool8)input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool8(mask8x8 input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.neg_epi8(input);
			}
			else
			{
				return *(bool8*)&input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x8(bool8 input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return neg_epi8(input);
			}
			else
			{
				mask8x8 result = default(mask8x8);
				*(bool8*)&result = input;
				return result;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x8(bool input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return set1_epi64x(-tolong(input));
			}
			else
			{
				return (bool8)input;
			}
		}
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(byte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(ushort v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(uint v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(ulong v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(UInt128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(sbyte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(short v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(int v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(long v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(Int128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(quarter v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(half v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(float v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(double v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(quadruple v) => math.andnot(v != 0, math.isnan(v));


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator ! (mask8x8 value)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return not_si128(value);
			}
			else
			{
				return !(bool8)value;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator & (mask8x8 left, mask8x8 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return and_si128(left, right);
			}
			else
			{
				return (bool8)left & (bool8)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator & (mask8x8 left, bool right) => left & (mask8x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator & (bool left, mask8x8 right) => (mask8x8)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator & (mask8x8 left, bool8 right) => left & (mask8x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator & (bool8 left, mask8x8 right) => (mask8x8)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x8 operator & (mask8x8 left, mask16x8 right) => (mask16x8)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x8 operator & (mask16x8 left, mask8x8 right) => left & (mask16x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator & (mask8x8 left, mask32x8 right) => (mask32x8)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator & (mask32x8 left, mask8x8 right) => left & (mask32x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator | (mask8x8 left, mask8x8 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return or_si128(left, right);
			}
			else
			{
				return (bool8)left | (bool8)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator | (mask8x8 left, bool right) => left | (mask8x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator | (bool left, mask8x8 right) => (mask8x8)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator | (mask8x8 left, bool8 right) => left | (mask8x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator | (bool8 left, mask8x8 right) => (mask8x8)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x8 operator | (mask8x8 left, mask16x8 right) => (mask16x8)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x8 operator | (mask16x8 left, mask8x8 right) => left | (mask16x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator | (mask8x8 left, mask32x8 right) => (mask32x8)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator | (mask32x8 left, mask8x8 right) => left | (mask32x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator ^ (mask8x8 left, mask8x8 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return xor_si128(left, right);
			}
			else
			{
				return (bool8)left ^ (bool8)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator ^ (mask8x8 left, bool right) => left ^ (mask8x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator ^ (bool left, mask8x8 right) => (mask8x8)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator ^ (mask8x8 left, bool8 right) => left ^ (mask8x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator ^ (bool8 left, mask8x8 right) => (mask8x8)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x8 operator ^ (mask8x8 left, mask16x8 right) => (mask16x8)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x8 operator ^ (mask16x8 left, mask8x8 right) => left ^ (mask16x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator ^ (mask8x8 left, mask32x8 right) => (mask32x8)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator ^ (mask32x8 left, mask8x8 right) => left ^ (mask32x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator != (mask8x8 left, mask8x8 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return xor_si128(left, right);
			}
			else
			{
				return (bool8)left != (bool8)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator != (mask8x8 left, bool right) => left != (mask8x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator != (bool left, mask8x8 right) => (mask8x8)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator != (mask8x8 left, bool8 right) => left != (mask8x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator != (bool8 left, mask8x8 right) => (mask8x8)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x8 operator != (mask8x8 left, mask16x8 right) => (mask16x8)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x8 operator != (mask16x8 left, mask8x8 right) => left != (mask16x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator != (mask8x8 left, mask32x8 right) => (mask32x8)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator != (mask32x8 left, mask8x8 right) => left != (mask32x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator == (mask8x8 left, mask8x8 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return cmpeq_epi8(left, right);
			}
			else
			{
				return (bool8)left == (bool8)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator == (mask8x8 left, bool right) => left == (mask8x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator == (bool left, mask8x8 right) => (mask8x8)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator == (mask8x8 left, bool8 right) => left == (mask8x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x8 operator == (bool8 left, mask8x8 right) => (mask8x8)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x8 operator == (mask8x8 left, mask16x8 right) => (mask16x8)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x8 operator == (mask16x8 left, mask8x8 right) => left == (mask16x8)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator == (mask8x8 left, mask32x8 right) => (mask32x8)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x8 operator == (mask32x8 left, mask8x8 right) => left == (mask32x8)right;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool Equals(mask8x8 other)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return alltrue_epi128<byte>(cmpeq_epi8(this, other), 8);
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
        public static mask8x8 FromBitmask(int bitmask)
        {
            mask8x8 result;
            if (BurstArchitecture.IsSIMDSupported)
            {
                result = Xse.broadcastmask_epi8(bitmask, MaskType.AllOnes, 8);
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
