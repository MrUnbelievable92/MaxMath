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
	internal sealed class mask8x16DebuggerProxy
	{
		public bool x0;
		public bool x1;
		public bool x2;
		public bool x3;
		public bool x4;
		public bool x5;
		public bool x6;
		public bool x7;
		public bool x8;
		public bool x9;
		public bool x10;
		public bool x11;
		public bool x12;
		public bool x13;
		public bool x14;
		public bool x15;
		
		public mask8x16DebuggerProxy(mask8x16 v)
		{
			x0 = ((v128)v.mask).Byte0 != 0;
			x1 = ((v128)v.mask).Byte1 != 0;
			x2 = ((v128)v.mask).Byte2 != 0;
			x3 = ((v128)v.mask).Byte3 != 0;
			x4 = ((v128)v.mask).Byte4 != 0;
			x5 = ((v128)v.mask).Byte5 != 0;
			x6 = ((v128)v.mask).Byte6 != 0;
			x7 = ((v128)v.mask).Byte7 != 0;
			x8 = ((v128)v.mask).Byte8 != 0;
			x9 = ((v128)v.mask).Byte9 != 0;
			x10 = ((v128)v.mask).Byte10 != 0;
			x11 = ((v128)v.mask).Byte11 != 0;
			x12 = ((v128)v.mask).Byte12 != 0;
			x13 = ((v128)v.mask).Byte13 != 0;
			x14 = ((v128)v.mask).Byte14 != 0;
			x15 = ((v128)v.mask).Byte15 != 0;
		}
	}
	
	[System.Diagnostics.DebuggerTypeProxy(typeof(mask8x16DebuggerProxy))]
#endif
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	unsafe public ref struct mask8x16
	{
		internal ulong2 mask;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal mask8x16(v128 mask)
		{
			this.mask = mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal mask8x16(v128 maskLo, v128 maskHi)
		{
			this.mask = (v128)new byte16((byte8)maskLo, (byte8)maskHi);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7, bool x8, bool x9, bool x10, bool x11, bool x12, bool x13, bool x14, bool x15)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v128)new byte16((byte)-tobyte(x0), (byte)-tobyte(x1), (byte)-tobyte(x2), (byte)-tobyte(x3), (byte)-tobyte(x4), (byte)-tobyte(x5), (byte)-tobyte(x6), (byte)-tobyte(x7), (byte)-tobyte(x8), (byte)-tobyte(x9), (byte)-tobyte(x10), (byte)-tobyte(x11), (byte)-tobyte(x12), (byte)-tobyte(x13), (byte)-tobyte(x14), (byte)-tobyte(x15));
			}
			else
			{
				this = (v128)new byte16(tobyte(x0), tobyte(x1), tobyte(x2), tobyte(x3), tobyte(x4), tobyte(x5), tobyte(x6), tobyte(x7), tobyte(x8), tobyte(x9), tobyte(x10), tobyte(x11), tobyte(x12), tobyte(x13), tobyte(x14), tobyte(x15));
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(bool x0x16) => this = (mask8x16)x0x16;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(mask8x2 x01, mask8x2 x23, mask8x2 x45, mask8x2 x67, mask8x2 x89, mask8x2 x10_11, mask8x2 x12_13, mask8x2 x14_15) => this = (v128)new byte16((byte2)(v128)x01, (byte2)(v128)x23, (byte2)(v128)x45, (byte2)(v128)x67, (byte2)(v128)x89, (byte2)(v128)x10_11, (byte2)(v128)x12_13, (byte2)(v128)x14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(mask8x4 x0123, mask8x4 x4567, mask8x4 x8_9_10_11, mask8x4 x12_13_14_15) => this = (v128)new byte16((byte4)(v128)x0123, (byte4)(v128)x4567, (byte4)(v128)x8_9_10_11, (byte4)(v128)x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(mask8x4 x0123, mask8x3 x456, mask8x3 x789, mask8x3 x10_11_12, mask8x3 x13_14_15) => this = (v128)new byte16((byte4)(v128)x0123, (byte3)(v128)x456, (byte3)(v128)x789, (byte3)(v128)x10_11_12, (byte3)(v128)x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(mask8x3 x012, mask8x4 x3456, mask8x3 x789, mask8x3 x10_11_12, mask8x3 x13_14_15) => this = (v128)new byte16((byte3)(v128)x012, (byte4)(v128)x3456, (byte3)(v128)x789, (byte3)(v128)x10_11_12, (byte3)(v128)x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(mask8x3 x012, mask8x3 x345, mask8x4 x6789, mask8x3 x10_11_12, mask8x3 x13_14_15) => this = (v128)new byte16((byte3)(v128)x012, (byte3)(v128)x345, (byte4)(v128)x6789, (byte3)(v128)x10_11_12, (byte3)(v128)x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(mask8x3 x012, mask8x3 x345, mask8x3 x678, mask8x4 x9_10_11_12, mask8x3 x13_14_15) => this = (v128)new byte16((byte3)(v128)x012, (byte3)(v128)x345, (byte3)(v128)x678, (byte4)(v128)x9_10_11_12, (byte3)(v128)x13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(mask8x3 x012, mask8x3 x345, mask8x3 x678, mask8x3 x9_10_11, mask8x4 x12_13_14_15) => this = (v128)new byte16((byte3)(v128)x012, (byte3)(v128)x345, (byte3)(v128)x678, (byte3)(v128)x9_10_11, (byte4)(v128)x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(mask8x8 x01234567, mask8x4 x8_9_10_11, mask8x4 x12_13_14_15) => this = (v128)new byte16((byte8)(v128)x01234567, (byte4)(v128)x8_9_10_11, (byte4)(v128)x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(mask8x4 x0123, mask8x8 x4_5_6_7_8_9_10_11, mask8x4 x12_13_14_15) => this = (v128)new byte16((byte4)(v128)x0123, (byte8)(v128)x4_5_6_7_8_9_10_11, (byte4)(v128)x12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(mask8x4 x0123, mask8x4 x4567, mask8x8 x8_9_10_11_12_13_14_15) => this = (v128)new byte16((byte4)(v128)x0123, (byte4)(v128)x4567, (byte8)(v128)x8_9_10_11_12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(mask8x8 x01234567, mask8x8 x8_9_10_11_12_13_14_15) => this = (v128)new byte16((byte8)(v128)x01234567, (byte8)(v128)x8_9_10_11_12_13_14_15);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(bool16 v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(byte v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(byte16 v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(sbyte v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(sbyte16 v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(ushort v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(ushort16 v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(short v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(short16 v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(uint v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(int v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(ulong v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(long v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(UInt128 v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(Int128 v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(quarter v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(quarter16 v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(half v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(half16 v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(float v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(double v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(quadruple v) => this = (mask8x16)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x16(Unity.Mathematics.half v) => this = (mask8x16)(half)v;



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
		public bool x8
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[8];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[8] = value;
		}
		public bool x9
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[9];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[9] = value;
		}
		public bool x10
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[10];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[10] = value;
		}
		public bool x11
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[11];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[11] = value;
		}
		public bool x12
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[12];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[12] = value;
		}
		public bool x13
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[13];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[13] = value;
		}
		public bool x14
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[14];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[14] = value;
		}
		public bool x15
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[15];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[15] = value;
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
					return ((bool16)this).v2_0;
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
					bool16 stack = this;
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
					return ((bool16)this).v2_1;
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
					bool16 stack = this;
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
					return ((bool16)this).v2_2;
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
					bool16 stack = this;
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
					return ((bool16)this).v2_3;
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
					bool16 stack = this;
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
					return ((bool16)this).v2_4;
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
					bool16 stack = this;
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
					return ((bool16)this).v2_5;
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
					bool16 stack = this;
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
					return ((bool16)this).v2_6;
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
					bool16 stack = this;
					stack.v2_6 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_7
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v2_7;
				}
				else
				{
					return ((bool16)this).v2_7;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v2_7 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v2_7 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_8
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v2_8;
				}
				else
				{
					return ((bool16)this).v2_8;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v2_8 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v2_8 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_9
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v2_9;
				}
				else
				{
					return ((bool16)this).v2_9;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v2_9 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v2_9 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_10
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v2_10;
				}
				else
				{
					return ((bool16)this).v2_10;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v2_10 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v2_10 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_11
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v2_11;
				}
				else
				{
					return ((bool16)this).v2_11;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v2_11 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v2_11 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_12
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v2_12;
				}
				else
				{
					return ((bool16)this).v2_12;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v2_12 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v2_12 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_13
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v2_13;
				}
				else
				{
					return ((bool16)this).v2_13;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v2_13 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v2_13 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_14
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v2_14;
				}
				else
				{
					return ((bool16)this).v2_14;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v2_14 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v2_14 = value;
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
					return ((bool16)this).v3_0;
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
					bool16 stack = this;
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
					return ((bool16)this).v3_1;
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
					bool16 stack = this;
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
					return ((bool16)this).v3_2;
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
					bool16 stack = this;
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
					return ((bool16)this).v3_3;
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
					bool16 stack = this;
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
					return ((bool16)this).v3_4;
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
					bool16 stack = this;
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
					return ((bool16)this).v3_5;
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
					bool16 stack = this;
					stack.v3_5 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_6
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v3_6;
				}
				else
				{
					return ((bool16)this).v3_6;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v3_6 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v3_6 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_7
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v3_7;
				}
				else
				{
					return ((bool16)this).v3_7;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v3_7 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v3_7 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_8
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v3_8;
				}
				else
				{
					return ((bool16)this).v3_8;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v3_8 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v3_8 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_9
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v3_9;
				}
				else
				{
					return ((bool16)this).v3_9;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v3_9 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v3_9 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_10
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v3_10;
				}
				else
				{
					return ((bool16)this).v3_10;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v3_10 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v3_10 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_11
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v3_11;
				}
				else
				{
					return ((bool16)this).v3_11;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v3_11 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v3_11 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_12
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v3_12;
				}
				else
				{
					return ((bool16)this).v3_12;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v3_12 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v3_12 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_13
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v3_13;
				}
				else
				{
					return ((bool16)this).v3_13;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v3_13 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v3_13 = value;
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
					return ((bool16)this).v4_0;
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
					bool16 stack = this;
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
					return ((bool16)this).v4_1;
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
					bool16 stack = this;
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
					return ((bool16)this).v4_2;
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
					bool16 stack = this;
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
					return ((bool16)this).v4_3;
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
					bool16 stack = this;
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
					return ((bool16)this).v4_4;
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
					bool16 stack = this;
					stack.v4_4 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_5
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v4_5;
				}
				else
				{
					return ((bool16)this).v4_5;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v4_5 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v4_5 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_6
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v4_6;
				}
				else
				{
					return ((bool16)this).v4_6;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v4_6 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v4_6 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_7
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v4_7;
				}
				else
				{
					return ((bool16)this).v4_7;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v4_7 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v4_7 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_8
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v4_8;
				}
				else
				{
					return ((bool16)this).v4_8;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v4_8 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v4_8 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_9
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v4_9;
				}
				else
				{
					return ((bool16)this).v4_9;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v4_9 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v4_9 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_10
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v4_10;
				}
				else
				{
					return ((bool16)this).v4_10;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v4_10 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v4_10 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_11
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v4_11;
				}
				else
				{
					return ((bool16)this).v4_11;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v4_11 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v4_11 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_12
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v4_12;
				}
				else
				{
					return ((bool16)this).v4_12;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v4_12 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v4_12 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v8_0;
				}
				else
				{
					return ((bool16)this).v8_0;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v8_0 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v8_0 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v8_1;
				}
				else
				{
					return ((bool16)this).v8_1;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v8_1 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v8_1 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v8_2;
				}
				else
				{
					return ((bool16)this).v8_2;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v8_2 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v8_2 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v8_3;
				}
				else
				{
					return ((bool16)this).v8_3;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v8_3 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v8_3 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_4
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v8_4;
				}
				else
				{
					return ((bool16)this).v8_4;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v8_4 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v8_4 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_5
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v8_5;
				}
				else
				{
					return ((bool16)this).v8_5;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v8_5 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v8_5 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_6
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v8_6;
				}
				else
				{
					return ((bool16)this).v8_6;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v8_6 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v8_6 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_7
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v8_7;
				}
				else
				{
					return ((bool16)this).v8_7;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v8_7 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v8_7 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_8
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte16)(v128)mask).v8_8;
				}
				else
				{
					return ((bool16)this).v8_8;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = ((byte16)(v128)mask);
					reinterpret.v8_8 = (v128)value;
					this = (v128)reinterpret;
				}
				else
				{
					bool16 stack = this;
					stack.v8_8 = value;
					this = stack;
				}
			}
		}


		public bool this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
Assert.IsWithinArrayBounds(index, 16);

				if (BurstArchitecture.IsSIMDSupported)
				{
					return mask.Reinterpret<ulong2, byte16>()[index] != 0;
				}
				else
				{
					return ((bool16)this)[index];
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
Assert.IsWithinArrayBounds(index, 16);

				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = mask.Reinterpret<ulong2, byte16>();
					reinterpret[index] = (byte)-tolong(value);
					mask = reinterpret.Reinterpret<byte16, ulong2>();
				}
				else
				{
					bool16 reinterpret = this;
					reinterpret[index] = value;
					this = reinterpret;
				}
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator v128(mask8x16 input)
		{
			return input.mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x16(v128 input)
		{
			return new mask8x16 { mask = input };
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x16(mask16x16 input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return packs_epi16(input.mask.xy, input.mask.zw);
			}
			else
			{
				return (bool16)input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask16x16(mask8x16 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_cvtepi8_epi16(input);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				v128 lo = cvt2x2epi8_epi16(input, out v128 hi);
				return new mask16x16(lo, hi);
			}
			else
			{
				return (bool16)input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool16(mask8x16 input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.neg_epi8(input);
			}
			else
			{
				return *(bool16*)&input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x16(bool16 input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return neg_epi8(input);
			}
			else
			{
				mask8x16 result = default(mask8x16);
				*(bool16*)&result = input;
				return result;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x16(bool input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return set1_epi64x(-tolong(input));
			}
			else
			{
				return (bool16)input;
			}
		}
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x16(byte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x16(ushort v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x16(uint v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x16(ulong v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x16(UInt128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x16(sbyte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x16(short v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x16(int v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x16(long v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x16(Int128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x16(quarter v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x16(half v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x16(float v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x16(double v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x16(quadruple v) => math.andnot(v != 0, math.isnan(v));


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator ! (mask8x16 value)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return not_si128(value);
			}
			else
			{
				return !(bool16)value;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator & (mask8x16 left, mask8x16 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return and_si128(left, right);
			}
			else
			{
				return (bool16)left & (bool16)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator & (mask8x16 left, bool right) => left & (mask8x16)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator & (bool left, mask8x16 right) => (mask8x16)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator & (mask8x16 left, bool16 right) => left & (mask8x16)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator & (bool16 left, mask8x16 right) => (mask8x16)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x16 operator & (mask8x16 left, mask16x16 right) => (mask16x16)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x16 operator & (mask16x16 left, mask8x16 right) => left & (mask16x16)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator | (mask8x16 left, mask8x16 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return or_si128(left, right);
			}
			else
			{
				return (bool16)left | (bool16)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator | (mask8x16 left, bool right) => left | (mask8x16)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator | (bool left, mask8x16 right) => (mask8x16)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator | (mask8x16 left, bool16 right) => left | (mask8x16)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator | (bool16 left, mask8x16 right) => (mask8x16)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x16 operator | (mask8x16 left, mask16x16 right) => (mask16x16)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x16 operator | (mask16x16 left, mask8x16 right) => left | (mask16x16)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator ^ (mask8x16 left, mask8x16 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return xor_si128(left, right);
			}
			else
			{
				return (bool16)left ^ (bool16)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator ^ (mask8x16 left, bool right) => left ^ (mask8x16)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator ^ (bool left, mask8x16 right) => (mask8x16)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator ^ (mask8x16 left, bool16 right) => left ^ (mask8x16)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator ^ (bool16 left, mask8x16 right) => (mask8x16)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x16 operator ^ (mask8x16 left, mask16x16 right) => (mask16x16)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x16 operator ^ (mask16x16 left, mask8x16 right) => left ^ (mask16x16)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator != (mask8x16 left, mask8x16 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return xor_si128(left, right);
			}
			else
			{
				return (bool16)left != (bool16)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator != (mask8x16 left, bool right) => left != (mask8x16)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator != (bool left, mask8x16 right) => (mask8x16)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator != (mask8x16 left, bool16 right) => left != (mask8x16)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator != (bool16 left, mask8x16 right) => (mask8x16)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x16 operator != (mask8x16 left, mask16x16 right) => (mask16x16)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x16 operator != (mask16x16 left, mask8x16 right) => left != (mask16x16)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator == (mask8x16 left, mask8x16 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return cmpeq_epi8(left, right);
			}
			else
			{
				return (bool16)left == (bool16)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator == (mask8x16 left, bool right) => left == (mask8x16)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator == (bool left, mask8x16 right) => (mask8x16)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator == (mask8x16 left, bool16 right) => left == (mask8x16)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x16 operator == (bool16 left, mask8x16 right) => (mask8x16)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x16 operator == (mask8x16 left, mask16x16 right) => (mask16x16)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x16 operator == (mask16x16 left, mask8x16 right) => left == (mask16x16)right;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool Equals(mask8x16 other)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return alltrue_epi128<byte>(cmpeq_epi8(this, other), 16);
			}
			else
			{
				return ((bool16)this).Equals((bool16)other);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override readonly int GetHashCode()
		{
			return bitmask(this);
		}

		public override readonly string ToString()
		{
			return ((bool16)this).ToString();
		}

        
        /// <summary>       Returns a <see cref="bool16"/> from the first 16 bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 FromBitmask(int bitmask)
        {
            mask8x16 result;
            if (BurstArchitecture.IsSIMDSupported)
            {
                result = Xse.broadcastmask_epi8(bitmask, MaskType.AllOnes, 16);
            }
            else
            {
                result = bool16.FromBitmask(bitmask);
            }

            constexpr.ASSUME(math.bitmask(result) == (bitmask & 0b1111_1111_1111_1111));
            return result;
        }
	}
}
#pragma warning restore CS0660
