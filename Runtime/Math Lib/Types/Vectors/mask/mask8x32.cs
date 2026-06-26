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
	internal sealed class mask8x32DebuggerProxy
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
		public bool x16;
		public bool x17;
		public bool x18;
		public bool x19;
		public bool x20;
		public bool x21;
		public bool x22;
		public bool x23;
		public bool x24;
		public bool x25;
		public bool x26;
		public bool x27;
		public bool x28;
		public bool x29;
		public bool x30;
		public bool x31;
		
		public mask8x32DebuggerProxy(mask8x32 v)
		{
			x0 =  ((v256)v.mask).Byte0 != 0;
			x1 =  ((v256)v.mask).Byte1 != 0;
			x2 =  ((v256)v.mask).Byte2 != 0;
			x3 =  ((v256)v.mask).Byte3 != 0;
			x4 =  ((v256)v.mask).Byte4 != 0;
			x5 =  ((v256)v.mask).Byte5 != 0;
			x6 =  ((v256)v.mask).Byte6 != 0;
			x7 =  ((v256)v.mask).Byte7 != 0;
			x8 =  ((v256)v.mask).Byte8 != 0;
			x9 =  ((v256)v.mask).Byte9 != 0;
			x10 = ((v256)v.mask).Byte10 != 0;
			x11 = ((v256)v.mask).Byte11 != 0;
			x12 = ((v256)v.mask).Byte12 != 0;
			x13 = ((v256)v.mask).Byte13 != 0;
			x14 = ((v256)v.mask).Byte14 != 0;
			x15 = ((v256)v.mask).Byte15 != 0;
			x16 = ((v256)v.mask).Byte16 != 0;
			x17 = ((v256)v.mask).Byte17 != 0;
			x18 = ((v256)v.mask).Byte18 != 0;
			x19 = ((v256)v.mask).Byte19 != 0;
			x20 = ((v256)v.mask).Byte20 != 0;
			x21 = ((v256)v.mask).Byte21 != 0;
			x22 = ((v256)v.mask).Byte22 != 0;
			x23 = ((v256)v.mask).Byte23 != 0;
			x24 = ((v256)v.mask).Byte24 != 0;
			x25 = ((v256)v.mask).Byte25 != 0;
			x26 = ((v256)v.mask).Byte26 != 0;
			x27 = ((v256)v.mask).Byte27 != 0;
			x28 = ((v256)v.mask).Byte28 != 0;
			x29 = ((v256)v.mask).Byte29 != 0;
			x30 = ((v256)v.mask).Byte30 != 0;
			x31 = ((v256)v.mask).Byte31 != 0;
		}
	}
	
	[System.Diagnostics.DebuggerTypeProxy(typeof(mask8x32DebuggerProxy))]
#endif
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	unsafe public ref struct mask8x32
	{
		internal ulong4 mask;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal mask8x32(v256 mask)
		{
			this.mask = mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal mask8x32(v128 maskLo, v128 maskHi)
		{
			this.mask = new ulong4(maskLo, maskHi);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7, bool x8, bool x9, bool x10, bool x11, bool x12, bool x13, bool x14, bool x15, bool x16, bool x17, bool x18, bool x19, bool x20, bool x21, bool x22, bool x23, bool x24, bool x25, bool x26, bool x27, bool x28, bool x29, bool x30, bool x31)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v256)new byte32((byte)-tobyte(x0), (byte)-tobyte(x1), (byte)-tobyte(x2), (byte)-tobyte(x3), (byte)-tobyte(x4), (byte)-tobyte(x5), (byte)-tobyte(x6), (byte)-tobyte(x7), (byte)-tobyte(x8), (byte)-tobyte(x9), (byte)-tobyte(x10), (byte)-tobyte(x11), (byte)-tobyte(x12), (byte)-tobyte(x13), (byte)-tobyte(x14), (byte)-tobyte(x15), (byte)-tobyte(x16), (byte)-tobyte(x17), (byte)-tobyte(x18), (byte)-tobyte(x19), (byte)-tobyte(x20), (byte)-tobyte(x21), (byte)-tobyte(x22), (byte)-tobyte(x23), (byte)-tobyte(x24), (byte)-tobyte(x25), (byte)-tobyte(x26), (byte)-tobyte(x27), (byte)-tobyte(x28), (byte)-tobyte(x29), (byte)-tobyte(x30), (byte)-tobyte(x31));
			}
			else
			{
				this = (v256)new byte32(tobyte(x0), tobyte(x1), tobyte(x2), tobyte(x3), tobyte(x4), tobyte(x5), tobyte(x6), tobyte(x7), tobyte(x8), tobyte(x9), tobyte(x10), tobyte(x11), tobyte(x12), tobyte(x13), tobyte(x14), tobyte(x15), tobyte(x16), tobyte(x17), tobyte(x18), tobyte(x19), tobyte(x20), tobyte(x21), tobyte(x22), tobyte(x23), tobyte(x24), tobyte(x25), tobyte(x26), tobyte(x27), tobyte(x28), tobyte(x29), tobyte(x30), tobyte(x31));
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(bool x0x32) => this = (mask8x32)x0x32;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(mask8x4 x0_3, mask8x4 x4_7, mask8x4 x8_11, mask8x4 x12_15, mask8x4 x16_19, mask8x4 x20_23, mask8x4 x24_27, mask8x4 x28_31) => this = (v256)new byte32((byte4)(v128)x0_3, (byte4)(v128)x4_7, (byte4)(v128)x8_11, (byte4)(v128)x12_15, (byte4)(v128)x16_19, (byte4)(v128)x20_23, (byte4)(v128)x24_27, (byte4)(v128)x28_31);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(mask8x8 v8_0, mask8x8 v8_8, mask8x8 v8_16, mask8x8 v8_24) => this = (v256)new byte32((byte8)(v128)v8_0, (byte8)(v128)v8_8, (byte8)(v128)v8_16, (byte8)(v128)v8_24);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(mask8x16 v16_0, mask8x8 v8_16, mask8x8 v8_24) => this = (v256)new byte32((byte16)(v128)v16_0, (byte8)(v128)v8_16, (byte8)(v128)v8_24);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(mask8x8 v8_0, mask8x16 v16_8, mask8x8 v8_24) => this = (v256)new byte32((byte8)(v128)v8_0, (byte16)(v128)v16_8, (byte8)(v128)v8_24);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(mask8x8 v8_0, mask8x8 v8_8, mask8x16 v16_16) => this = (v256)new byte32((byte8)(v128)v8_0, (byte8)(v128)v8_8, (byte16)(v128)v16_16);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(mask8x16 v16_0, mask8x16 v16_1) => this = (v256)new byte32((byte16)(v128)v16_0, (byte16)(v128)v16_1);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(bool32 v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(byte v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(byte32 v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(sbyte v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(sbyte32 v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(ushort v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(short v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(uint v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(int v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(ulong v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(long v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(UInt128 v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(Int128 v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(quarter v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(quarter32 v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(half v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(float v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(double v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(quadruple v) => this = (mask8x32)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x32(Unity.Mathematics.half v) => this = (mask8x32)(half)v;



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
		public bool x16
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[16];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[16] = value;
		}
		public bool x17
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[17];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[17] = value;
		}
		public bool x18
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[18];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[18] = value;
		}
		public bool x19
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[19];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[19] = value;
		}
		public bool x20
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[20];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[20] = value;
		}
		public bool x21
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[21];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[21] = value;
		}
		public bool x22
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[22];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[22] = value;
		}
		public bool x23
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[23];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[23] = value;
		}
		public bool x24
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[24];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[24] = value;
		}
		public bool x25
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[25];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[25] = value;
		}
		public bool x26
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[26];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[26] = value;
		}
		public bool x27
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[27];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[27] = value;
		}
		public bool x28
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[28];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[28] = value;
		}
		public bool x29
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[29];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[29] = value;
		}
		public bool x30
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[30];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[30] = value;
		}
		public bool x31
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[31];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[31] = value;
		}


		public mask8x2 v2_0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v2_0;
				}
				else
				{
					return ((bool32)this).v2_0;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_0 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v2_1;
				}
				else
				{
					return ((bool32)this).v2_1;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_1 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v2_2;
				}
				else
				{
					return ((bool32)this).v2_2;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_2 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v2_3;
				}
				else
				{
					return ((bool32)this).v2_3;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_3 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v2_4;
				}
				else
				{
					return ((bool32)this).v2_4;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_4 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v2_5;
				}
				else
				{
					return ((bool32)this).v2_5;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_5 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v2_6;
				}
				else
				{
					return ((bool32)this).v2_6;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_6 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v2_7;
				}
				else
				{
					return ((bool32)this).v2_7;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_7 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v2_8;
				}
				else
				{
					return ((bool32)this).v2_8;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_8 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v2_9;
				}
				else
				{
					return ((bool32)this).v2_9;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_9 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v2_10;
				}
				else
				{
					return ((bool32)this).v2_10;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_10 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v2_11;
				}
				else
				{
					return ((bool32)this).v2_11;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_11 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v2_12;
				}
				else
				{
					return ((bool32)this).v2_12;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_12 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v2_13;
				}
				else
				{
					return ((bool32)this).v2_13;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_13 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v2_14;
				}
				else
				{
					return ((bool32)this).v2_14;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_14 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v2_14 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_15
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v2_15;
				}
				else
				{
					return ((bool32)this).v2_15;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_15 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v2_15 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_16
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v2_16;
				}
				else
				{
					return ((bool32)this).v2_16;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_16 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v2_16 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_17
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v2_17;
				}
				else
				{
					return ((bool32)this).v2_17;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_17 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v2_17 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_18
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v2_18;
				}
				else
				{
					return ((bool32)this).v2_18;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_18 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v2_18 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_19
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v2_19;
				}
				else
				{
					return ((bool32)this).v2_19;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_19 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v2_19 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_20
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v2_20;
				}
				else
				{
					return ((bool32)this).v2_20;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_20 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v2_20 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_21
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v2_21;
				}
				else
				{
					return ((bool32)this).v2_21;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_21 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v2_21 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_22
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v2_22;
				}
				else
				{
					return ((bool32)this).v2_22;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_22 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v2_22 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_23
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v2_23;
				}
				else
				{
					return ((bool32)this).v2_23;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_23 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v2_23 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_24
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v2_24;
				}
				else
				{
					return ((bool32)this).v2_24;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_24 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v2_24 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_25
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v2_25;
				}
				else
				{
					return ((bool32)this).v2_25;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_25 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v2_25 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_26
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v2_26;
				}
				else
				{
					return ((bool32)this).v2_26;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_26 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v2_26 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_27
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v2_27;
				}
				else
				{
					return ((bool32)this).v2_27;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_27 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v2_27 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_28
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v2_28;
				}
				else
				{
					return ((bool32)this).v2_28;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_28 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v2_28 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_29
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v2_29;
				}
				else
				{
					return ((bool32)this).v2_29;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_29 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v2_29 = value;
					this = stack;
				}
			}
		}
		public mask8x2 v2_30
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v2_30;
				}
				else
				{
					return ((bool32)this).v2_30;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v2_30 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v2_30 = value;
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
					return (v128)((byte32)(v256)mask).v3_0;
				}
				else
				{
					return ((bool32)this).v3_0;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_0 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v3_1;
				}
				else
				{
					return ((bool32)this).v3_1;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_1 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v3_2;
				}
				else
				{
					return ((bool32)this).v3_2;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_2 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v3_3;
				}
				else
				{
					return ((bool32)this).v3_3;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_3 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v3_4;
				}
				else
				{
					return ((bool32)this).v3_4;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_4 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v3_5;
				}
				else
				{
					return ((bool32)this).v3_5;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_5 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v3_6;
				}
				else
				{
					return ((bool32)this).v3_6;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_6 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v3_7;
				}
				else
				{
					return ((bool32)this).v3_7;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_7 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v3_8;
				}
				else
				{
					return ((bool32)this).v3_8;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_8 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v3_9;
				}
				else
				{
					return ((bool32)this).v3_9;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_9 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v3_10;
				}
				else
				{
					return ((bool32)this).v3_10;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_10 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v3_11;
				}
				else
				{
					return ((bool32)this).v3_11;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_11 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v3_12;
				}
				else
				{
					return ((bool32)this).v3_12;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_12 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v3_13;
				}
				else
				{
					return ((bool32)this).v3_13;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_13 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v3_13 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_14
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v3_14;
				}
				else
				{
					return ((bool32)this).v3_14;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_14 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v3_14 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_15
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v3_15;
				}
				else
				{
					return ((bool32)this).v3_15;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_15 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v3_15 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_16
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v3_16;
				}
				else
				{
					return ((bool32)this).v3_16;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_16 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v3_16 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_17
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v3_17;
				}
				else
				{
					return ((bool32)this).v3_17;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_17 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v3_17 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_18
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v3_18;
				}
				else
				{
					return ((bool32)this).v3_18;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_18 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v3_18 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_19
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v3_19;
				}
				else
				{
					return ((bool32)this).v3_19;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_19 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v3_19 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_20
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v3_20;
				}
				else
				{
					return ((bool32)this).v3_20;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_20 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v3_20 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_21
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v3_21;
				}
				else
				{
					return ((bool32)this).v3_21;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_21 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v3_21 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_22
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v3_22;
				}
				else
				{
					return ((bool32)this).v3_22;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_22 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v3_22 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_23
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v3_23;
				}
				else
				{
					return ((bool32)this).v3_23;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_23 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v3_23 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_24
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v3_24;
				}
				else
				{
					return ((bool32)this).v3_24;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_24 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v3_24 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_25
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v3_25;
				}
				else
				{
					return ((bool32)this).v3_25;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_25 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v3_25 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_26
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v3_26;
				}
				else
				{
					return ((bool32)this).v3_26;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_26 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v3_26 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_27
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v3_27;
				}
				else
				{
					return ((bool32)this).v3_27;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_27 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v3_27 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_28
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v3_28;
				}
				else
				{
					return ((bool32)this).v3_28;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_28 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v3_28 = value;
					this = stack;
				}
			}
		}
		public mask8x3 v3_29
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v3_29;
				}
				else
				{
					return ((bool32)this).v3_29;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v3_29 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v3_29 = value;
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
					return (v128)((byte32)(v256)mask).v4_0;
				}
				else
				{
					return ((bool32)this).v4_0;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_0 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v4_1;
				}
				else
				{
					return ((bool32)this).v4_1;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_1 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v4_2;
				}
				else
				{
					return ((bool32)this).v4_2;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_2 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v4_3;
				}
				else
				{
					return ((bool32)this).v4_3;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_3 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v4_4;
				}
				else
				{
					return ((bool32)this).v4_4;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_4 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v4_5;
				}
				else
				{
					return ((bool32)this).v4_5;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_5 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v4_6;
				}
				else
				{
					return ((bool32)this).v4_6;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_6 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v4_7;
				}
				else
				{
					return ((bool32)this).v4_7;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_7 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v4_8;
				}
				else
				{
					return ((bool32)this).v4_8;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_8 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v4_9;
				}
				else
				{
					return ((bool32)this).v4_9;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_9 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v4_10;
				}
				else
				{
					return ((bool32)this).v4_10;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_10 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v4_11;
				}
				else
				{
					return ((bool32)this).v4_11;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_11 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v4_12;
				}
				else
				{
					return ((bool32)this).v4_12;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_12 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v4_12 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_13
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v4_13;
				}
				else
				{
					return ((bool32)this).v4_13;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_13 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v4_13 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_14
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v4_14;
				}
				else
				{
					return ((bool32)this).v4_14;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_14 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v4_14 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_15
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v4_15;
				}
				else
				{
					return ((bool32)this).v4_15;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_15 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v4_15 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_16
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v4_16;
				}
				else
				{
					return ((bool32)this).v4_16;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_16 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v4_16 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_17
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v4_17;
				}
				else
				{
					return ((bool32)this).v4_17;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_17 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v4_17 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_18
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v4_18;
				}
				else
				{
					return ((bool32)this).v4_18;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_18 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v4_18 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_19
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v4_19;
				}
				else
				{
					return ((bool32)this).v4_19;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_19 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v4_19 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_20
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v4_20;
				}
				else
				{
					return ((bool32)this).v4_20;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_20 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v4_20 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_21
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v4_21;
				}
				else
				{
					return ((bool32)this).v4_21;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_21 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v4_21 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_22
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v4_22;
				}
				else
				{
					return ((bool32)this).v4_22;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_22 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v4_22 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_23
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v4_23;
				}
				else
				{
					return ((bool32)this).v4_23;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_23 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v4_23 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_24
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v4_24;
				}
				else
				{
					return ((bool32)this).v4_24;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_24 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v4_24 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_25
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v4_25;
				}
				else
				{
					return ((bool32)this).v4_25;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_25 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v4_25 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_26
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v4_26;
				}
				else
				{
					return ((bool32)this).v4_26;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_26 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v4_26 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_27
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v4_27;
				}
				else
				{
					return ((bool32)this).v4_27;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_27 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v4_27 = value;
					this = stack;
				}
			}
		}
		public mask8x4 v4_28
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v4_28;
				}
				else
				{
					return ((bool32)this).v4_28;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v4_28 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v4_28 = value;
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
					return (v128)((byte32)(v256)mask).v8_0;
				}
				else
				{
					return ((bool32)this).v8_0;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_0 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v8_1;
				}
				else
				{
					return ((bool32)this).v8_1;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_1 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v8_2;
				}
				else
				{
					return ((bool32)this).v8_2;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_2 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v8_3;
				}
				else
				{
					return ((bool32)this).v8_3;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_3 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v8_4;
				}
				else
				{
					return ((bool32)this).v8_4;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_4 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v8_5;
				}
				else
				{
					return ((bool32)this).v8_5;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_5 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v8_6;
				}
				else
				{
					return ((bool32)this).v8_6;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_6 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v8_7;
				}
				else
				{
					return ((bool32)this).v8_7;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_7 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
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
					return (v128)((byte32)(v256)mask).v8_8;
				}
				else
				{
					return ((bool32)this).v8_8;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_8 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v8_8 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_9
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v8_9;
				}
				else
				{
					return ((bool32)this).v8_9;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_9 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v8_9 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_10
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v8_10;
				}
				else
				{
					return ((bool32)this).v8_10;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_10 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v8_10 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_11
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v8_11;
				}
				else
				{
					return ((bool32)this).v8_11;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_11 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v8_11 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_12
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v8_12;
				}
				else
				{
					return ((bool32)this).v8_12;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_12 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v8_12 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_13
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v8_13;
				}
				else
				{
					return ((bool32)this).v8_13;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_13 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v8_13 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_14
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v8_14;
				}
				else
				{
					return ((bool32)this).v8_14;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_14 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v8_14 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_15
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v8_15;
				}
				else
				{
					return ((bool32)this).v8_15;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_15 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v8_15 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_16
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v8_16;
				}
				else
				{
					return ((bool32)this).v8_16;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_16 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v8_16 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_17
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v8_17;
				}
				else
				{
					return ((bool32)this).v8_17;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_17 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v8_17 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_18
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v8_18;
				}
				else
				{
					return ((bool32)this).v8_18;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_18 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v8_18 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_19
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v8_19;
				}
				else
				{
					return ((bool32)this).v8_19;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_19 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v8_19 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_20
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v8_20;
				}
				else
				{
					return ((bool32)this).v8_20;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_20 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v8_20 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_21
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v8_21;
				}
				else
				{
					return ((bool32)this).v8_21;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_21 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v8_21 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_22
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v8_22;
				}
				else
				{
					return ((bool32)this).v8_22;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_22 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v8_22 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_23
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v8_23;
				}
				else
				{
					return ((bool32)this).v8_23;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_23 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v8_23 = value;
					this = stack;
				}
			}
		}
		public mask8x8 v8_24
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v8_24;
				}
				else
				{
					return ((bool32)this).v8_24;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v8_24 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v8_24 = value;
					this = stack;
				}
			}
		}
		public mask8x16 v16_0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v16_0;
				}
				else
				{
					return ((bool32)this).v16_0;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v16_0 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v16_0 = value;
					this = stack;
				}
			}
		}
		public mask8x16 v16_1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v16_1;
				}
				else
				{
					return ((bool32)this).v16_1;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v16_1 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v16_1 = value;
					this = stack;
				}
			}
		}
		public mask8x16 v16_2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v16_2;
				}
				else
				{
					return ((bool32)this).v16_2;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v16_2 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v16_2 = value;
					this = stack;
				}
			}
		}
		public mask8x16 v16_3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v16_3;
				}
				else
				{
					return ((bool32)this).v16_3;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v16_3 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v16_3 = value;
					this = stack;
				}
			}
		}
		public mask8x16 v16_4
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v16_4;
				}
				else
				{
					return ((bool32)this).v16_4;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v16_4 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v16_4 = value;
					this = stack;
				}
			}
		}
		public mask8x16 v16_5
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v16_5;
				}
				else
				{
					return ((bool32)this).v16_5;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v16_5 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v16_5 = value;
					this = stack;
				}
			}
		}
		public mask8x16 v16_6
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v16_6;
				}
				else
				{
					return ((bool32)this).v16_6;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v16_6 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v16_6 = value;
					this = stack;
				}
			}
		}
		public mask8x16 v16_7
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v16_7;
				}
				else
				{
					return ((bool32)this).v16_7;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v16_7 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v16_7 = value;
					this = stack;
				}
			}
		}
		public mask8x16 v16_8
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v16_8;
				}
				else
				{
					return ((bool32)this).v16_8;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v16_8 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v16_8 = value;
					this = stack;
				}
			}
		}
		public mask8x16 v16_9
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v16_9;
				}
				else
				{
					return ((bool32)this).v16_9;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v16_9 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v16_9 = value;
					this = stack;
				}
			}
		}
		public mask8x16 v16_10
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v16_10;
				}
				else
				{
					return ((bool32)this).v16_10;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v16_10 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v16_10 = value;
					this = stack;
				}
			}
		}
		public mask8x16 v16_11
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v16_11;
				}
				else
				{
					return ((bool32)this).v16_11;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v16_11 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v16_11 = value;
					this = stack;
				}
			}
		}
		public mask8x16 v16_12
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v16_12;
				}
				else
				{
					return ((bool32)this).v16_12;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v16_12 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v16_12 = value;
					this = stack;
				}
			}
		}
		public mask8x16 v16_13
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v16_13;
				}
				else
				{
					return ((bool32)this).v16_13;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v16_13 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v16_13 = value;
					this = stack;
				}
			}
		}
		public mask8x16 v16_14
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v16_14;
				}
				else
				{
					return ((bool32)this).v16_14;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v16_14 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v16_14 = value;
					this = stack;
				}
			}
		}
		public mask8x16 v16_15
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v16_15;
				}
				else
				{
					return ((bool32)this).v16_15;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v16_15 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v16_15 = value;
					this = stack;
				}
			}
		}
		public mask8x16 v16_16
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return (v128)((byte32)(v256)mask).v16_16;
				}
				else
				{
					return ((bool32)this).v16_16;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = ((byte32)(v256)mask);
					reinterpret.v16_16 = (v128)value;
					this = (v256)reinterpret;
				}
				else
				{
					bool32 stack = this;
					stack.v16_16 = value;
					this = stack;
				}
			}
		}


		public bool this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
Assert.IsWithinArrayBounds(index, 32);

				if (BurstArchitecture.IsSIMDSupported)
				{
					return mask.Reinterpret<ulong4, byte32>()[index] != 0;
				}
				else
				{
					return ((bool32)this)[index];
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
Assert.IsWithinArrayBounds(index, 32);

				if (BurstArchitecture.IsSIMDSupported)
				{
					byte32 reinterpret = mask.Reinterpret<ulong4, byte32>();
					reinterpret[index] = (byte)-tolong(value);
					mask = reinterpret.Reinterpret<byte32, ulong4>();
				}
				else
				{
					bool32 reinterpret = this;
					reinterpret[index] = value;
					this = reinterpret;
				}
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator v256(mask8x32 input)
		{
			return input.mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x32(v256 input)
		{
			return new mask8x32 { mask = input };
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool32(mask8x32 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_neg_epi8(input);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				v128 lo = Xse.neg_epi8(input.v16_0);
				v128 hi = Xse.neg_epi8(input.v16_16);

				return new bool32 {__x0 = lo, __x16 = hi };
			}
			else
			{
				return *(bool32*)&input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x32(bool32 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				return mm256_neg_epi8(input);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask8x32(neg_epi8(input.v16_0), neg_epi8(input.v16_16));
			}
			else
			{
				mask8x32 result = default(mask8x32);
				*(bool32*)&result = input;
				return result;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x32(bool input)
		{
			if (Avx.IsAvxSupported)
			{
				return mm256_set1_epi64x(-tolong(input));
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask8x32(set1_epi64x(-tolong(input)), set1_epi64x(-tolong(input)));
			}
			else
			{
				return (bool32)input;
			}
		}
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x32(byte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x32(ushort v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x32(uint v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x32(ulong v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x32(UInt128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x32(sbyte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x32(short v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x32(int v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x32(long v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x32(Int128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x32(quarter v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x32(half v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x32(float v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x32(double v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x32(quadruple v) => math.andnot(v != 0, math.isnan(v));


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator ! (mask8x32 value)
		{
			if (Avx.IsAvxSupported)
			{
				return mm256_not_si256(value);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask8x32(not_si128(value.mask.xy), not_si128(value.mask.zw));
			}
			else
			{
				return !(bool32)value;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator & (mask8x32 left, mask8x32 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_and_ps(left, right);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask8x32(and_si128(left.mask.xy, right.mask.xy), and_si128(left.mask.zw, right.mask.zw));
			}
			else
			{
				return (bool32)left & (bool32)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator & (mask8x32 left, bool right) => left & (mask8x32)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator & (bool left, mask8x32 right) => (mask8x32)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator & (mask8x32 left, bool32 right) => left & (mask8x32)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator & (bool32 left, mask8x32 right) => (mask8x32)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator | (mask8x32 left, mask8x32 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_or_ps(left, right);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask8x32(or_si128(left.mask.xy, right.mask.xy), or_si128(left.mask.zw, right.mask.zw));
			}
			else
			{
				return (bool32)left | (bool32)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator | (mask8x32 left, bool right) => left | (mask8x32)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator | (bool left, mask8x32 right) => (mask8x32)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator | (mask8x32 left, bool32 right) => left | (mask8x32)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator | (bool32 left, mask8x32 right) => (mask8x32)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator ^ (mask8x32 left, mask8x32 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_xor_ps(left, right);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask8x32(xor_si128(left.mask.xy, right.mask.xy), xor_si128(left.mask.zw, right.mask.zw));
			}
			else
			{
				return (bool32)left ^ (bool32)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator ^ (mask8x32 left, bool right) => left ^ (mask8x32)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator ^ (bool left, mask8x32 right) => (mask8x32)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator ^ (mask8x32 left, bool32 right) => left ^ (mask8x32)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator ^ (bool32 left, mask8x32 right) => (mask8x32)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator != (mask8x32 left, mask8x32 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_xor_ps(left, right);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask8x32(xor_si128(left.v16_0, right.v16_0), xor_si128(left.v16_16, right.v16_16));
			}
			else
			{
				return (bool32)left != (bool32)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator != (mask8x32 left, bool right) => left != (mask8x32)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator != (bool left, mask8x32 right) => (mask8x32)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator != (mask8x32 left, bool32 right) => left != (mask8x32)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator != (bool32 left, mask8x32 right) => (mask8x32)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator == (mask8x32 left, mask8x32 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_cmpeq_epi8(left, right);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask8x32(cmpeq_epi8(left.v16_0, right.v16_0), cmpeq_epi8(left.v16_16, right.v16_16));
			}
			else
			{
				return (bool32)left == (bool32)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator == (mask8x32 left, bool right) => left == (mask8x32)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator == (bool left, mask8x32 right) => (mask8x32)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator == (mask8x32 left, bool32 right) => left == (mask8x32)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x32 operator == (bool32 left, mask8x32 right) => (mask8x32)left == right;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool Equals(mask8x32 other)
		{
			if (Avx2.IsAvx2Supported)
			{
				return mm256_alltrue_epi256<byte>(Avx2.mm256_cmpeq_epi8(this, other), 32);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				bool lo = alltrue_epi128<byte>(cmpeq_epi8(this.mask.xy, other.mask.xy));
				bool hi = alltrue_epi128<byte>(cmpeq_epi8(this.mask.zw, other.mask.zw));
				return lo & hi;
			}
			else
			{
				return ((bool32)this).Equals((bool32)other);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override readonly int GetHashCode()
		{
			return bitmask(this);
		}

		public override readonly string ToString()
		{
			return ((bool32)this).ToString();
		}

        
        /// <summary>       Returns a <see cref="bool32"/> from the bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 FromBitmask(int bitmask)
        {
            mask8x32 result;
            if (Avx2.IsAvx2Supported)
            {
                result = Xse.mm256_broadcastmask_epi8(bitmask, MaskType.AllOnes);
            }
            else
            {
                result = bool32.FromBitmask(bitmask);
            }

            constexpr.ASSUME(math.bitmask(result) == bitmask);
            return result;
        }
	}
}
#pragma warning restore CS0660
