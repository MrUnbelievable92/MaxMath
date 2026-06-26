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
	internal sealed class mask8x4DebuggerProxy
	{
		public bool x;
		public bool y;
		public bool z;
		public bool w;
		
		public mask8x4DebuggerProxy(mask8x4 v)
		{
			x = ((v128)v.mask).Byte0 != 0;
			y = ((v128)v.mask).Byte1 != 0;
			z = ((v128)v.mask).Byte2 != 0;
			w = ((v128)v.mask).Byte3 != 0;
		}
	}
	
	[System.Diagnostics.DebuggerTypeProxy(typeof(mask8x4DebuggerProxy))]
#endif
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	unsafe public ref struct mask8x4
	{
		internal ulong2 mask;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal mask8x4(v128 mask)
		{
			this.mask = mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal mask8x4(v128 maskLo, v128 maskHi)
		{
			this.mask = (v128)new byte4((byte2)maskLo, (byte2)maskHi);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(bool x, bool y, bool z, bool w)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v128)new byte4((byte)-tobyte(x), (byte)-tobyte(y), (byte)-tobyte(z), (byte)-tobyte(w));
			}
			else
			{
				this = (v128)new byte4(tobyte(x), tobyte(y), tobyte(z), tobyte(w));
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(bool x, bool y, mask8x2 zw)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v128)new byte4((byte)-tobyte(x), (byte)-tobyte(y), (byte2)(v128)zw);
			}
			else
			{
				this = (v128)new byte4(tobyte(x), tobyte(y), tobyte(zw));
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(bool x, mask8x2 yz, bool w)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v128)new byte4((byte)-tobyte(x), (byte2)(v128)yz, (byte)-tobyte(w));
			}
			else
			{
				this = (v128)new byte4(tobyte(x), tobyte(yz), tobyte(w));
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(bool x, mask8x3 yzw)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v128)new byte4((byte)-tobyte(x), (byte3)(v128)yzw);
			}
			else
			{
				this = (v128)new byte4(tobyte(x), tobyte(yzw));
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(mask8x2 xy, bool z, bool w)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v128)new byte4((byte2)(v128)xy, (byte)-tobyte(z), (byte)-tobyte(w));
			}
			else
			{
				this = (v128)new byte4(tobyte(xy), tobyte(z), tobyte(w));
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(mask8x2 xy, mask8x2 zw) => this = (v128)new byte4((byte2)(v128)xy, (byte2)(v128)zw);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(mask8x3 xyz, bool w)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v128)new byte4((byte3)(v128)xyz, (byte)-tobyte(w));
			}
			else
			{
				this = (v128)new byte4(tobyte(xyz), tobyte(w));
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(bool v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(bool4 v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(byte v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(byte4 v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(sbyte v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(sbyte4 v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(ushort v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(ushort4 v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(short v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(short4 v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(uint v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(uint4 v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(int v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(int4 v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(ulong v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(ulong4 v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(long v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(long4 v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(UInt128 v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(Int128 v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(quarter v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(quarter4 v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(half v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(half4 v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(float v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(float4 v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(double v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(double4 v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(quadruple v) => this = (mask8x4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(Unity.Mathematics.bool4 v) => this = (mask8x4)(bool4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(Unity.Mathematics.uint4 v) => this = (mask8x4)(uint4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(Unity.Mathematics.int4 v) => this = (mask8x4)(int4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(Unity.Mathematics.half v) => this = (mask8x4)(half)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(Unity.Mathematics.half4 v) => this = (mask8x4)(half4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(Unity.Mathematics.float4 v) => this = (mask8x4)(float4)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask8x4(Unity.Mathematics.double4 v) => this = (mask8x4)(double4)v;



		public bool x
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[0];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[0] = value;
		}
		public bool y
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[1];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[1] = value;
		}
		public bool z
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[2];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[2] = value;
		}
		public bool w
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get => this[3];

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => this[3] = value;
		}


		public readonly mask8x4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxxx);
				}
				else
				{
					return ((bool4)this).xxxx;
				}
			}
		}
		public readonly mask8x4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxxy);
				}
				else
				{
					return ((bool4)this).xxxy;
				}
			}
		}
		public readonly mask8x4 xxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxxz);
				}
				else
				{
					return ((bool4)this).xxxz;
				}
			}
		}
		public readonly mask8x4 xxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxxw);
				}
				else
				{
					return ((bool4)this).xxxw;
				}
			}
		}
		public readonly mask8x4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxyx);
				}
				else
				{
					return ((bool4)this).xxyx;
				}
			}
		}
		public readonly mask8x4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxyy);
				}
				else
				{
					return ((bool4)this).xxyy;
				}
			}
		}
		public readonly mask8x4 xxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxyz);
				}
				else
				{
					return ((bool4)this).xxyz;
				}
			}
		}
		public readonly mask8x4 xxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxyw);
				}
				else
				{
					return ((bool4)this).xxyw;
				}
			}
		}
		public readonly mask8x4 xxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxzx);
				}
				else
				{
					return ((bool4)this).xxzx;
				}
			}
		}
		public readonly mask8x4 xxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxzy);
				}
				else
				{
					return ((bool4)this).xxzy;
				}
			}
		}
		public readonly mask8x4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxzz);
				}
				else
				{
					return ((bool4)this).xxzz;
				}
			}
		}
		public readonly mask8x4 xxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxzw);
				}
				else
				{
					return ((bool4)this).xxzw;
				}
			}
		}
		public readonly mask8x4 xxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxwx);
				}
				else
				{
					return ((bool4)this).xxwx;
				}
			}
		}
		public readonly mask8x4 xxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxwy);
				}
				else
				{
					return ((bool4)this).xxwy;
				}
			}
		}
		public readonly mask8x4 xxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxwz);
				}
				else
				{
					return ((bool4)this).xxwz;
				}
			}
		}
		public readonly mask8x4 xxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxww);
				}
				else
				{
					return ((bool4)this).xxww;
				}
			}
		}
		public readonly mask8x4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xyxx);
				}
				else
				{
					return ((bool4)this).xyxx;
				}
			}
		}
		public readonly mask8x4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xyxy);
				}
				else
				{
					return ((bool4)this).xyxy;
				}
			}
		}
		public readonly mask8x4 xyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xyxz);
				}
				else
				{
					return ((bool4)this).xyxz;
				}
			}
		}
		public readonly mask8x4 xyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xyxw);
				}
				else
				{
					return ((bool4)this).xyxw;
				}
			}
		}
		public readonly mask8x4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xyyx);
				}
				else
				{
					return ((bool4)this).xyyx;
				}
			}
		}
		public readonly mask8x4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xyyy);
				}
				else
				{
					return ((bool4)this).xyyy;
				}
			}
		}
		public readonly mask8x4 xyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xyyz);
				}
				else
				{
					return ((bool4)this).xyyz;
				}
			}
		}
		public readonly mask8x4 xyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xyyw);
				}
				else
				{
					return ((bool4)this).xyyw;
				}
			}
		}
		public readonly mask8x4 xyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xyzx);
				}
				else
				{
					return ((bool4)this).xyzx;
				}
			}
		}
		public readonly mask8x4 xyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xyzy);
				}
				else
				{
					return ((bool4)this).xyzy;
				}
			}
		}
		public readonly mask8x4 xyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xyzz);
				}
				else
				{
					return ((bool4)this).xyzz;
				}
			}
		}
		public mask8x4 xyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xyzw);
				}
				else
				{
					return ((bool4)this).xyzw;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.xyzw = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.xyzw = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 xywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xywx);
				}
				else
				{
					return ((bool4)this).xywx;
				}
			}
		}
		public readonly mask8x4 xywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xywy);
				}
				else
				{
					return ((bool4)this).xywy;
				}
			}
		}
		public mask8x4 xywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xywz);
				}
				else
				{
					return ((bool4)this).xywz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.xywz = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.xywz = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 xyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xyww);
				}
				else
				{
					return ((bool4)this).xyww;
				}
			}
		}
		public readonly mask8x4 xzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzxx);
				}
				else
				{
					return ((bool4)this).xzxx;
				}
			}
		}
		public readonly mask8x4 xzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzxy);
				}
				else
				{
					return ((bool4)this).xzxy;
				}
			}
		}
		public readonly mask8x4 xzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzxz);
				}
				else
				{
					return ((bool4)this).xzxz;
				}
			}
		}
		public readonly mask8x4 xzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzxw);
				}
				else
				{
					return ((bool4)this).xzxw;
				}
			}
		}
		public readonly mask8x4 xzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzyx);
				}
				else
				{
					return ((bool4)this).xzyx;
				}
			}
		}
		public readonly mask8x4 xzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzyy);
				}
				else
				{
					return ((bool4)this).xzyy;
				}
			}
		}
		public readonly mask8x4 xzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzyz);
				}
				else
				{
					return ((bool4)this).xzyz;
				}
			}
		}
		public mask8x4 xzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzyw);
				}
				else
				{
					return ((bool4)this).xzyw;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.xzyw = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.xzyw = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 xzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzzx);
				}
				else
				{
					return ((bool4)this).xzzx;
				}
			}
		}
		public readonly mask8x4 xzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzzy);
				}
				else
				{
					return ((bool4)this).xzzy;
				}
			}
		}
		public readonly mask8x4 xzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzzz);
				}
				else
				{
					return ((bool4)this).xzzz;
				}
			}
		}
		public readonly mask8x4 xzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzzw);
				}
				else
				{
					return ((bool4)this).xzzw;
				}
			}
		}
		public readonly mask8x4 xzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzwx);
				}
				else
				{
					return ((bool4)this).xzwx;
				}
			}
		}
		public mask8x4 xzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzwy);
				}
				else
				{
					return ((bool4)this).xzwy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.xzwy = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.xzwy = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 xzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzwz);
				}
				else
				{
					return ((bool4)this).xzwz;
				}
			}
		}
		public readonly mask8x4 xzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzww);
				}
				else
				{
					return ((bool4)this).xzww;
				}
			}
		}
		public readonly mask8x4 xwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwxx);
				}
				else
				{
					return ((bool4)this).xwxx;
				}
			}
		}
		public readonly mask8x4 xwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwxy);
				}
				else
				{
					return ((bool4)this).xwxy;
				}
			}
		}
		public readonly mask8x4 xwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwxz);
				}
				else
				{
					return ((bool4)this).xwxz;
				}
			}
		}
		public readonly mask8x4 xwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwxw);
				}
				else
				{
					return ((bool4)this).xwxw;
				}
			}
		}
		public readonly mask8x4 xwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwyx);
				}
				else
				{
					return ((bool4)this).xwyx;
				}
			}
		}
		public readonly mask8x4 xwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwyy);
				}
				else
				{
					return ((bool4)this).xwyy;
				}
			}
		}
		public mask8x4 xwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwyz);
				}
				else
				{
					return ((bool4)this).xwyz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.xwyz = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.xwyz = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 xwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwyw);
				}
				else
				{
					return ((bool4)this).xwyw;
				}
			}
		}
		public readonly mask8x4 xwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwzx);
				}
				else
				{
					return ((bool4)this).xwzx;
				}
			}
		}
		public mask8x4 xwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwzy);
				}
				else
				{
					return ((bool4)this).xwzy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.xwzy = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.xwzy = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 xwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwzz);
				}
				else
				{
					return ((bool4)this).xwzz;
				}
			}
		}
		public readonly mask8x4 xwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwzw);
				}
				else
				{
					return ((bool4)this).xwzw;
				}
			}
		}
		public readonly mask8x4 xwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwwx);
				}
				else
				{
					return ((bool4)this).xwwx;
				}
			}
		}
		public readonly mask8x4 xwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwwy);
				}
				else
				{
					return ((bool4)this).xwwy;
				}
			}
		}
		public readonly mask8x4 xwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwwz);
				}
				else
				{
					return ((bool4)this).xwwz;
				}
			}
		}
		public readonly mask8x4 xwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwww);
				}
				else
				{
					return ((bool4)this).xwww;
				}
			}
		}
		public readonly mask8x4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxxx);
				}
				else
				{
					return ((bool4)this).yxxx;
				}
			}
		}
		public readonly mask8x4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxxy);
				}
				else
				{
					return ((bool4)this).yxxy;
				}
			}
		}
		public readonly mask8x4 yxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxxz);
				}
				else
				{
					return ((bool4)this).yxxz;
				}
			}
		}
		public readonly mask8x4 yxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxxw);
				}
				else
				{
					return ((bool4)this).yxxw;
				}
			}
		}
		public readonly mask8x4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxyx);
				}
				else
				{
					return ((bool4)this).yxyx;
				}
			}
		}
		public readonly mask8x4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxyy);
				}
				else
				{
					return ((bool4)this).yxyy;
				}
			}
		}
		public readonly mask8x4 yxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxyz);
				}
				else
				{
					return ((bool4)this).yxyz;
				}
			}
		}
		public readonly mask8x4 yxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxyw);
				}
				else
				{
					return ((bool4)this).yxyw;
				}
			}
		}
		public readonly mask8x4 yxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxzx);
				}
				else
				{
					return ((bool4)this).yxzx;
				}
			}
		}
		public readonly mask8x4 yxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxzy);
				}
				else
				{
					return ((bool4)this).yxzy;
				}
			}
		}
		public readonly mask8x4 yxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxzz);
				}
				else
				{
					return ((bool4)this).yxzz;
				}
			}
		}
		public mask8x4 yxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxzw);
				}
				else
				{
					return ((bool4)this).yxzw;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.yxzw = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.yxzw = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 yxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxwx);
				}
				else
				{
					return ((bool4)this).yxwx;
				}
			}
		}
		public readonly mask8x4 yxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxwy);
				}
				else
				{
					return ((bool4)this).yxwy;
				}
			}
		}
		public mask8x4 yxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxwz);
				}
				else
				{
					return ((bool4)this).yxwz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.yxwz = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.yxwz = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 yxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxww);
				}
				else
				{
					return ((bool4)this).yxww;
				}
			}
		}
		public readonly mask8x4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yyxx);
				}
				else
				{
					return ((bool4)this).yyxx;
				}
			}
		}
		public readonly mask8x4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yyxy);
				}
				else
				{
					return ((bool4)this).yyxy;
				}
			}
		}
		public readonly mask8x4 yyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yyxz);
				}
				else
				{
					return ((bool4)this).yyxz;
				}
			}
		}
		public readonly mask8x4 yyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yyxw);
				}
				else
				{
					return ((bool4)this).yyxw;
				}
			}
		}
		public readonly mask8x4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yyyx);
				}
				else
				{
					return ((bool4)this).yyyx;
				}
			}
		}
		public readonly mask8x4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yyyy);
				}
				else
				{
					return ((bool4)this).yyyy;
				}
			}
		}
		public readonly mask8x4 yyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yyyz);
				}
				else
				{
					return ((bool4)this).yyyz;
				}
			}
		}
		public readonly mask8x4 yyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yyyw);
				}
				else
				{
					return ((bool4)this).yyyw;
				}
			}
		}
		public readonly mask8x4 yyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yyzx);
				}
				else
				{
					return ((bool4)this).yyzx;
				}
			}
		}
		public readonly mask8x4 yyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yyzy);
				}
				else
				{
					return ((bool4)this).yyzy;
				}
			}
		}
		public readonly mask8x4 yyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yyzz);
				}
				else
				{
					return ((bool4)this).yyzz;
				}
			}
		}
		public readonly mask8x4 yyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yyzw);
				}
				else
				{
					return ((bool4)this).yyzw;
				}
			}
		}
		public readonly mask8x4 yywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yywx);
				}
				else
				{
					return ((bool4)this).yywx;
				}
			}
		}
		public readonly mask8x4 yywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yywy);
				}
				else
				{
					return ((bool4)this).yywy;
				}
			}
		}
		public readonly mask8x4 yywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yywz);
				}
				else
				{
					return ((bool4)this).yywz;
				}
			}
		}
		public readonly mask8x4 yyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yyww);
				}
				else
				{
					return ((bool4)this).yyww;
				}
			}
		}
		public readonly mask8x4 yzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzxx);
				}
				else
				{
					return ((bool4)this).yzxx;
				}
			}
		}
		public readonly mask8x4 yzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzxy);
				}
				else
				{
					return ((bool4)this).yzxy;
				}
			}
		}
		public readonly mask8x4 yzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzxz);
				}
				else
				{
					return ((bool4)this).yzxz;
				}
			}
		}
		public mask8x4 yzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzxw);
				}
				else
				{
					return ((bool4)this).yzxw;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.yzxw = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.yzxw = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 yzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzyx);
				}
				else
				{
					return ((bool4)this).yzyx;
				}
			}
		}
		public readonly mask8x4 yzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzyy);
				}
				else
				{
					return ((bool4)this).yzyy;
				}
			}
		}
		public readonly mask8x4 yzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzyz);
				}
				else
				{
					return ((bool4)this).yzyz;
				}
			}
		}
		public readonly mask8x4 yzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzyw);
				}
				else
				{
					return ((bool4)this).yzyw;
				}
			}
		}
		public readonly mask8x4 yzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzzx);
				}
				else
				{
					return ((bool4)this).yzzx;
				}
			}
		}
		public readonly mask8x4 yzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzzy);
				}
				else
				{
					return ((bool4)this).yzzy;
				}
			}
		}
		public readonly mask8x4 yzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzzz);
				}
				else
				{
					return ((bool4)this).yzzz;
				}
			}
		}
		public readonly mask8x4 yzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzzw);
				}
				else
				{
					return ((bool4)this).yzzw;
				}
			}
		}
		public mask8x4 yzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzwx);
				}
				else
				{
					return ((bool4)this).yzwx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.yzwx = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.yzwx = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 yzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzwy);
				}
				else
				{
					return ((bool4)this).yzwy;
				}
			}
		}
		public readonly mask8x4 yzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzwz);
				}
				else
				{
					return ((bool4)this).yzwz;
				}
			}
		}
		public readonly mask8x4 yzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzww);
				}
				else
				{
					return ((bool4)this).yzww;
				}
			}
		}
		public readonly mask8x4 ywxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywxx);
				}
				else
				{
					return ((bool4)this).ywxx;
				}
			}
		}
		public readonly mask8x4 ywxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywxy);
				}
				else
				{
					return ((bool4)this).ywxy;
				}
			}
		}
		public mask8x4 ywxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywxz);
				}
				else
				{
					return ((bool4)this).ywxz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.ywxz = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.ywxz = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 ywxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywxw);
				}
				else
				{
					return ((bool4)this).ywxw;
				}
			}
		}
		public readonly mask8x4 ywyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywyx);
				}
				else
				{
					return ((bool4)this).ywyx;
				}
			}
		}
		public readonly mask8x4 ywyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywyy);
				}
				else
				{
					return ((bool4)this).ywyy;
				}
			}
		}
		public readonly mask8x4 ywyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywyz);
				}
				else
				{
					return ((bool4)this).ywyz;
				}
			}
		}
		public readonly mask8x4 ywyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywyw);
				}
				else
				{
					return ((bool4)this).ywyw;
				}
			}
		}
		public mask8x4 ywzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywzx);
				}
				else
				{
					return ((bool4)this).ywzx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.ywzx = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.ywzx = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 ywzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywzy);
				}
				else
				{
					return ((bool4)this).ywzy;
				}
			}
		}
		public readonly mask8x4 ywzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywzz);
				}
				else
				{
					return ((bool4)this).ywzz;
				}
			}
		}
		public readonly mask8x4 ywzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywzw);
				}
				else
				{
					return ((bool4)this).ywzw;
				}
			}
		}
		public readonly mask8x4 ywwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywwx);
				}
				else
				{
					return ((bool4)this).ywwx;
				}
			}
		}
		public readonly mask8x4 ywwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywwy);
				}
				else
				{
					return ((bool4)this).ywwy;
				}
			}
		}
		public readonly mask8x4 ywwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywwz);
				}
				else
				{
					return ((bool4)this).ywwz;
				}
			}
		}
		public readonly mask8x4 ywww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywww);
				}
				else
				{
					return ((bool4)this).ywww;
				}
			}
		}
		public readonly mask8x4 zxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxxx);
				}
				else
				{
					return ((bool4)this).zxxx;
				}
			}
		}
		public readonly mask8x4 zxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxxy);
				}
				else
				{
					return ((bool4)this).zxxy;
				}
			}
		}
		public readonly mask8x4 zxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxxz);
				}
				else
				{
					return ((bool4)this).zxxz;
				}
			}
		}
		public readonly mask8x4 zxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxxw);
				}
				else
				{
					return ((bool4)this).zxxw;
				}
			}
		}
		public readonly mask8x4 zxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxyx);
				}
				else
				{
					return ((bool4)this).zxyx;
				}
			}
		}
		public readonly mask8x4 zxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxyy);
				}
				else
				{
					return ((bool4)this).zxyy;
				}
			}
		}
		public readonly mask8x4 zxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxyz);
				}
				else
				{
					return ((bool4)this).zxyz;
				}
			}
		}
		public mask8x4 zxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxyw);
				}
				else
				{
					return ((bool4)this).zxyw;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.zxyw = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.zxyw = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 zxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxzx);
				}
				else
				{
					return ((bool4)this).zxzx;
				}
			}
		}
		public readonly mask8x4 zxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxzy);
				}
				else
				{
					return ((bool4)this).zxzy;
				}
			}
		}
		public readonly mask8x4 zxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxzz);
				}
				else
				{
					return ((bool4)this).zxzz;
				}
			}
		}
		public readonly mask8x4 zxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxzw);
				}
				else
				{
					return ((bool4)this).zxzw;
				}
			}
		}
		public readonly mask8x4 zxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxwx);
				}
				else
				{
					return ((bool4)this).zxwx;
				}
			}
		}
		public mask8x4 zxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxwy);
				}
				else
				{
					return ((bool4)this).zxwy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.zxwy = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.zxwy = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 zxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxwz);
				}
				else
				{
					return ((bool4)this).zxwz;
				}
			}
		}
		public readonly mask8x4 zxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxww);
				}
				else
				{
					return ((bool4)this).zxww;
				}
			}
		}
		public readonly mask8x4 zyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zyxx);
				}
				else
				{
					return ((bool4)this).zyxx;
				}
			}
		}
		public readonly mask8x4 zyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zyxy);
				}
				else
				{
					return ((bool4)this).zyxy;
				}
			}
		}
		public readonly mask8x4 zyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zyxz);
				}
				else
				{
					return ((bool4)this).zyxz;
				}
			}
		}
		public mask8x4 zyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zyxw);
				}
				else
				{
					return ((bool4)this).zyxw;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.zyxw = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.zyxw = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 zyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zyyx);
				}
				else
				{
					return ((bool4)this).zyyx;
				}
			}
		}
		public readonly mask8x4 zyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zyyy);
				}
				else
				{
					return ((bool4)this).zyyy;
				}
			}
		}
		public readonly mask8x4 zyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zyyz);
				}
				else
				{
					return ((bool4)this).zyyz;
				}
			}
		}
		public readonly mask8x4 zyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zyyw);
				}
				else
				{
					return ((bool4)this).zyyw;
				}
			}
		}
		public readonly mask8x4 zyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zyzx);
				}
				else
				{
					return ((bool4)this).zyzx;
				}
			}
		}
		public readonly mask8x4 zyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zyzy);
				}
				else
				{
					return ((bool4)this).zyzy;
				}
			}
		}
		public readonly mask8x4 zyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zyzz);
				}
				else
				{
					return ((bool4)this).zyzz;
				}
			}
		}
		public readonly mask8x4 zyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zyzw);
				}
				else
				{
					return ((bool4)this).zyzw;
				}
			}
		}
		public mask8x4 zywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zywx);
				}
				else
				{
					return ((bool4)this).zywx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.zywx = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.zywx = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 zywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zywy);
				}
				else
				{
					return ((bool4)this).zywy;
				}
			}
		}
		public readonly mask8x4 zywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zywz);
				}
				else
				{
					return ((bool4)this).zywz;
				}
			}
		}
		public readonly mask8x4 zyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zyww);
				}
				else
				{
					return ((bool4)this).zyww;
				}
			}
		}
		public readonly mask8x4 zzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzxx);
				}
				else
				{
					return ((bool4)this).zzxx;
				}
			}
		}
		public readonly mask8x4 zzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzxy);
				}
				else
				{
					return ((bool4)this).zzxy;
				}
			}
		}
		public readonly mask8x4 zzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzxz);
				}
				else
				{
					return ((bool4)this).zzxz;
				}
			}
		}
		public readonly mask8x4 zzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzxw);
				}
				else
				{
					return ((bool4)this).zzxw;
				}
			}
		}
		public readonly mask8x4 zzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzyx);
				}
				else
				{
					return ((bool4)this).zzyx;
				}
			}
		}
		public readonly mask8x4 zzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzyy);
				}
				else
				{
					return ((bool4)this).zzyy;
				}
			}
		}
		public readonly mask8x4 zzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzyz);
				}
				else
				{
					return ((bool4)this).zzyz;
				}
			}
		}
		public readonly mask8x4 zzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzyw);
				}
				else
				{
					return ((bool4)this).zzyw;
				}
			}
		}
		public readonly mask8x4 zzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzzx);
				}
				else
				{
					return ((bool4)this).zzzx;
				}
			}
		}
		public readonly mask8x4 zzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzzy);
				}
				else
				{
					return ((bool4)this).zzzy;
				}
			}
		}
		public readonly mask8x4 zzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzzz);
				}
				else
				{
					return ((bool4)this).zzzz;
				}
			}
		}
		public readonly mask8x4 zzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzzw);
				}
				else
				{
					return ((bool4)this).zzzw;
				}
			}
		}
		public readonly mask8x4 zzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzwx);
				}
				else
				{
					return ((bool4)this).zzwx;
				}
			}
		}
		public readonly mask8x4 zzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzwy);
				}
				else
				{
					return ((bool4)this).zzwy;
				}
			}
		}
		public readonly mask8x4 zzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzwz);
				}
				else
				{
					return ((bool4)this).zzwz;
				}
			}
		}
		public readonly mask8x4 zzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzww);
				}
				else
				{
					return ((bool4)this).zzww;
				}
			}
		}
		public readonly mask8x4 zwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwxx);
				}
				else
				{
					return ((bool4)this).zwxx;
				}
			}
		}
		public mask8x4 zwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwxy);
				}
				else
				{
					return ((bool4)this).zwxy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.zwxy = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.zwxy = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 zwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwxz);
				}
				else
				{
					return ((bool4)this).zwxz;
				}
			}
		}
		public readonly mask8x4 zwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwxw);
				}
				else
				{
					return ((bool4)this).zwxw;
				}
			}
		}
		public mask8x4 zwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwyx);
				}
				else
				{
					return ((bool4)this).zwyx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.zwyx = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.zwyx = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 zwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwyy);
				}
				else
				{
					return ((bool4)this).zwyy;
				}
			}
		}
		public readonly mask8x4 zwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwyz);
				}
				else
				{
					return ((bool4)this).zwyz;
				}
			}
		}
		public readonly mask8x4 zwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwyw);
				}
				else
				{
					return ((bool4)this).zwyw;
				}
			}
		}
		public readonly mask8x4 zwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwzx);
				}
				else
				{
					return ((bool4)this).zwzx;
				}
			}
		}
		public readonly mask8x4 zwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwzy);
				}
				else
				{
					return ((bool4)this).zwzy;
				}
			}
		}
		public readonly mask8x4 zwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwzz);
				}
				else
				{
					return ((bool4)this).zwzz;
				}
			}
		}
		public readonly mask8x4 zwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwzw);
				}
				else
				{
					return ((bool4)this).zwzw;
				}
			}
		}
		public readonly mask8x4 zwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwwx);
				}
				else
				{
					return ((bool4)this).zwwx;
				}
			}
		}
		public readonly mask8x4 zwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwwy);
				}
				else
				{
					return ((bool4)this).zwwy;
				}
			}
		}
		public readonly mask8x4 zwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwwz);
				}
				else
				{
					return ((bool4)this).zwwz;
				}
			}
		}
		public readonly mask8x4 zwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwww);
				}
				else
				{
					return ((bool4)this).zwww;
				}
			}
		}
		public readonly mask8x4 wxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxxx);
				}
				else
				{
					return ((bool4)this).wxxx;
				}
			}
		}
		public readonly mask8x4 wxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxxy);
				}
				else
				{
					return ((bool4)this).wxxy;
				}
			}
		}
		public readonly mask8x4 wxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxxz);
				}
				else
				{
					return ((bool4)this).wxxz;
				}
			}
		}
		public readonly mask8x4 wxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxxw);
				}
				else
				{
					return ((bool4)this).wxxw;
				}
			}
		}
		public readonly mask8x4 wxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxyx);
				}
				else
				{
					return ((bool4)this).wxyx;
				}
			}
		}
		public readonly mask8x4 wxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxyy);
				}
				else
				{
					return ((bool4)this).wxyy;
				}
			}
		}
		public mask8x4 wxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxyz);
				}
				else
				{
					return ((bool4)this).wxyz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.wxyz = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.wxyz = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 wxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxyw);
				}
				else
				{
					return ((bool4)this).wxyw;
				}
			}
		}
		public readonly mask8x4 wxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxzx);
				}
				else
				{
					return ((bool4)this).wxzx;
				}
			}
		}
		public mask8x4 wxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxzy);
				}
				else
				{
					return ((bool4)this).wxzy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.wxzy = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.wxzy = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 wxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxzz);
				}
				else
				{
					return ((bool4)this).wxzz;
				}
			}
		}
		public readonly mask8x4 wxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxzw);
				}
				else
				{
					return ((bool4)this).wxzw;
				}
			}
		}
		public readonly mask8x4 wxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxwx);
				}
				else
				{
					return ((bool4)this).wxwx;
				}
			}
		}
		public readonly mask8x4 wxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxwy);
				}
				else
				{
					return ((bool4)this).wxwy;
				}
			}
		}
		public readonly mask8x4 wxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxwz);
				}
				else
				{
					return ((bool4)this).wxwz;
				}
			}
		}
		public readonly mask8x4 wxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxww);
				}
				else
				{
					return ((bool4)this).wxww;
				}
			}
		}
		public readonly mask8x4 wyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wyxx);
				}
				else
				{
					return ((bool4)this).wyxx;
				}
			}
		}
		public readonly mask8x4 wyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wyxy);
				}
				else
				{
					return ((bool4)this).wyxy;
				}
			}
		}
		public mask8x4 wyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wyxz);
				}
				else
				{
					return ((bool4)this).wyxz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.wyxz = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.wyxz = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 wyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wyxw);
				}
				else
				{
					return ((bool4)this).wyxw;
				}
			}
		}
		public readonly mask8x4 wyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wyyx);
				}
				else
				{
					return ((bool4)this).wyyx;
				}
			}
		}
		public readonly mask8x4 wyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wyyy);
				}
				else
				{
					return ((bool4)this).wyyy;
				}
			}
		}
		public readonly mask8x4 wyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wyyz);
				}
				else
				{
					return ((bool4)this).wyyz;
				}
			}
		}
		public readonly mask8x4 wyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wyyw);
				}
				else
				{
					return ((bool4)this).wyyw;
				}
			}
		}
		public mask8x4 wyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wyzx);
				}
				else
				{
					return ((bool4)this).wyzx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.wyzx = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.wyzx = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 wyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wyzy);
				}
				else
				{
					return ((bool4)this).wyzy;
				}
			}
		}
		public readonly mask8x4 wyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wyzz);
				}
				else
				{
					return ((bool4)this).wyzz;
				}
			}
		}
		public readonly mask8x4 wyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wyzw);
				}
				else
				{
					return ((bool4)this).wyzw;
				}
			}
		}
		public readonly mask8x4 wywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wywx);
				}
				else
				{
					return ((bool4)this).wywx;
				}
			}
		}
		public readonly mask8x4 wywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wywy);
				}
				else
				{
					return ((bool4)this).wywy;
				}
			}
		}
		public readonly mask8x4 wywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wywz);
				}
				else
				{
					return ((bool4)this).wywz;
				}
			}
		}
		public readonly mask8x4 wyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wyww);
				}
				else
				{
					return ((bool4)this).wyww;
				}
			}
		}
		public readonly mask8x4 wzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzxx);
				}
				else
				{
					return ((bool4)this).wzxx;
				}
			}
		}
		public mask8x4 wzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzxy);
				}
				else
				{
					return ((bool4)this).wzxy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.wzxy = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.wzxy = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 wzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzxz);
				}
				else
				{
					return ((bool4)this).wzxz;
				}
			}
		}
		public readonly mask8x4 wzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzxw);
				}
				else
				{
					return ((bool4)this).wzxw;
				}
			}
		}
		public mask8x4 wzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzyx);
				}
				else
				{
					return ((bool4)this).wzyx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.wzyx = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.wzyx = value;
					this = stack;
				}
			}
		}
		public readonly mask8x4 wzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzyy);
				}
				else
				{
					return ((bool4)this).wzyy;
				}
			}
		}
		public readonly mask8x4 wzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzyz);
				}
				else
				{
					return ((bool4)this).wzyz;
				}
			}
		}
		public readonly mask8x4 wzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzyw);
				}
				else
				{
					return ((bool4)this).wzyw;
				}
			}
		}
		public readonly mask8x4 wzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzzx);
				}
				else
				{
					return ((bool4)this).wzzx;
				}
			}
		}
		public readonly mask8x4 wzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzzy);
				}
				else
				{
					return ((bool4)this).wzzy;
				}
			}
		}
		public readonly mask8x4 wzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzzz);
				}
				else
				{
					return ((bool4)this).wzzz;
				}
			}
		}
		public readonly mask8x4 wzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzzw);
				}
				else
				{
					return ((bool4)this).wzzw;
				}
			}
		}
		public readonly mask8x4 wzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzwx);
				}
				else
				{
					return ((bool4)this).wzwx;
				}
			}
		}
		public readonly mask8x4 wzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzwy);
				}
				else
				{
					return ((bool4)this).wzwy;
				}
			}
		}
		public readonly mask8x4 wzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzwz);
				}
				else
				{
					return ((bool4)this).wzwz;
				}
			}
		}
		public readonly mask8x4 wzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzww);
				}
				else
				{
					return ((bool4)this).wzww;
				}
			}
		}
		public readonly mask8x4 wwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwxx);
				}
				else
				{
					return ((bool4)this).wwxx;
				}
			}
		}
		public readonly mask8x4 wwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwxy);
				}
				else
				{
					return ((bool4)this).wwxy;
				}
			}
		}
		public readonly mask8x4 wwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwxz);
				}
				else
				{
					return ((bool4)this).wwxz;
				}
			}
		}
		public readonly mask8x4 wwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwxw);
				}
				else
				{
					return ((bool4)this).wwxw;
				}
			}
		}
		public readonly mask8x4 wwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwyx);
				}
				else
				{
					return ((bool4)this).wwyx;
				}
			}
		}
		public readonly mask8x4 wwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwyy);
				}
				else
				{
					return ((bool4)this).wwyy;
				}
			}
		}
		public readonly mask8x4 wwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwyz);
				}
				else
				{
					return ((bool4)this).wwyz;
				}
			}
		}
		public readonly mask8x4 wwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwyw);
				}
				else
				{
					return ((bool4)this).wwyw;
				}
			}
		}
		public readonly mask8x4 wwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwzx);
				}
				else
				{
					return ((bool4)this).wwzx;
				}
			}
		}
		public readonly mask8x4 wwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwzy);
				}
				else
				{
					return ((bool4)this).wwzy;
				}
			}
		}
		public readonly mask8x4 wwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwzz);
				}
				else
				{
					return ((bool4)this).wwzz;
				}
			}
		}
		public readonly mask8x4 wwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwzw);
				}
				else
				{
					return ((bool4)this).wwzw;
				}
			}
		}
		public readonly mask8x4 wwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwwx);
				}
				else
				{
					return ((bool4)this).wwwx;
				}
			}
		}
		public readonly mask8x4 wwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwwy);
				}
				else
				{
					return ((bool4)this).wwwy;
				}
			}
		}
		public readonly mask8x4 wwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwwz);
				}
				else
				{
					return ((bool4)this).wwwz;
				}
			}
		}
		public readonly mask8x4 wwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwww);
				}
				else
				{
					return ((bool4)this).wwww;
				}
			}
		}
		public readonly mask8x3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxx);
				}
				else
				{
					return ((bool4)this).xxx;
				}
			}
		}
		public readonly mask8x3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxy);
				}
				else
				{
					return ((bool4)this).xxy;
				}
			}
		}
		public readonly mask8x3 xxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxz);
				}
				else
				{
					return ((bool4)this).xxz;
				}
			}
		}
		public readonly mask8x3 xxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xxw);
				}
				else
				{
					return ((bool4)this).xxw;
				}
			}
		}
		public readonly mask8x3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xyx);
				}
				else
				{
					return ((bool4)this).xyx;
				}
			}
		}
		public readonly mask8x3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xyy);
				}
				else
				{
					return ((bool4)this).xyy;
				}
			}
		}
		public mask8x3 xyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xyz);
				}
				else
				{
					return ((bool4)this).xyz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.xyz = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.xyz = value;
					this = stack;
				}
			}
		}
		public mask8x3 xyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xyw);
				}
				else
				{
					return ((bool4)this).xyw;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.xyw = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.xyw = value;
					this = stack;
				}
			}
		}
		public readonly mask8x3 xzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzx);
				}
				else
				{
					return ((bool4)this).xzx;
				}
			}
		}
		public mask8x3 xzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzy);
				}
				else
				{
					return ((bool4)this).xzy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.xzy = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.xzy = value;
					this = stack;
				}
			}
		}
		public readonly mask8x3 xzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzz);
				}
				else
				{
					return ((bool4)this).xzz;
				}
			}
		}
		public mask8x3 xzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xzw);
				}
				else
				{
					return ((bool4)this).xzw;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.xzw = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.xzw = value;
					this = stack;
				}
			}
		}
		public readonly mask8x3 xwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwx);
				}
				else
				{
					return ((bool4)this).xwx;
				}
			}
		}
		public mask8x3 xwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwy);
				}
				else
				{
					return ((bool4)this).xwy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.xwy = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.xwy = value;
					this = stack;
				}
			}
		}
		public mask8x3 xwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xwz);
				}
				else
				{
					return ((bool4)this).xwz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.xwz = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.xwz = value;
					this = stack;
				}
			}
		}
		public readonly mask8x3 xww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xww);
				}
				else
				{
					return ((bool4)this).xww;
				}
			}
		}
		public readonly mask8x3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxx);
				}
				else
				{
					return ((bool4)this).yxx;
				}
			}
		}
		public readonly mask8x3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxy);
				}
				else
				{
					return ((bool4)this).yxy;
				}
			}
		}
		public mask8x3 yxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxz);
				}
				else
				{
					return ((bool4)this).yxz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.yxz = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.yxz = value;
					this = stack;
				}
			}
		}
		public mask8x3 yxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yxw);
				}
				else
				{
					return ((bool4)this).yxw;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.yxw = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.yxw = value;
					this = stack;
				}
			}
		}
		public readonly mask8x3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yyx);
				}
				else
				{
					return ((bool4)this).yyx;
				}
			}
		}
		public readonly mask8x3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yyy);
				}
				else
				{
					return ((bool4)this).yyy;
				}
			}
		}
		public readonly mask8x3 yyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yyz);
				}
				else
				{
					return ((bool4)this).yyz;
				}
			}
		}
		public readonly mask8x3 yyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yyw);
				}
				else
				{
					return ((bool4)this).yyw;
				}
			}
		}
		public mask8x3 yzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzx);
				}
				else
				{
					return ((bool4)this).yzx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.yzx = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.yzx = value;
					this = stack;
				}
			}
		}
		public readonly mask8x3 yzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzy);
				}
				else
				{
					return ((bool4)this).yzy;
				}
			}
		}
		public readonly mask8x3 yzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzz);
				}
				else
				{
					return ((bool4)this).yzz;
				}
			}
		}
		public mask8x3 yzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yzw);
				}
				else
				{
					return ((bool4)this).yzw;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.yzw = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.yzw = value;
					this = stack;
				}
			}
		}
		public mask8x3 ywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywx);
				}
				else
				{
					return ((bool4)this).ywx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.ywx = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.ywx = value;
					this = stack;
				}
			}
		}
		public readonly mask8x3 ywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywy);
				}
				else
				{
					return ((bool4)this).ywy;
				}
			}
		}
		public mask8x3 ywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ywz);
				}
				else
				{
					return ((bool4)this).ywz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.ywz = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.ywz = value;
					this = stack;
				}
			}
		}
		public readonly mask8x3 yww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yww);
				}
				else
				{
					return ((bool4)this).yww;
				}
			}
		}
		public readonly mask8x3 zxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxx);
				}
				else
				{
					return ((bool4)this).zxx;
				}
			}
		}
		public mask8x3 zxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxy);
				}
				else
				{
					return ((bool4)this).zxy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.zxy = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.zxy = value;
					this = stack;
				}
			}
		}
		public readonly mask8x3 zxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxz);
				}
				else
				{
					return ((bool4)this).zxz;
				}
			}
		}
		public mask8x3 zxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zxw);
				}
				else
				{
					return ((bool4)this).zxw;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.zxw = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.zxw = value;
					this = stack;
				}
			}
		}
		public mask8x3 zyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zyx);
				}
				else
				{
					return ((bool4)this).zyx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.zyx = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.zyx = value;
					this = stack;
				}
			}
		}
		public readonly mask8x3 zyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zyy);
				}
				else
				{
					return ((bool4)this).zyy;
				}
			}
		}
		public readonly mask8x3 zyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zyz);
				}
				else
				{
					return ((bool4)this).zyz;
				}
			}
		}
		public mask8x3 zyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zyw);
				}
				else
				{
					return ((bool4)this).zyw;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.zyw = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.zyw = value;
					this = stack;
				}
			}
		}
		public readonly mask8x3 zzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzx);
				}
				else
				{
					return ((bool4)this).zzx;
				}
			}
		}
		public readonly mask8x3 zzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzy);
				}
				else
				{
					return ((bool4)this).zzy;
				}
			}
		}
		public readonly mask8x3 zzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzz);
				}
				else
				{
					return ((bool4)this).zzz;
				}
			}
		}
		public readonly mask8x3 zzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zzw);
				}
				else
				{
					return ((bool4)this).zzw;
				}
			}
		}
		public mask8x3 zwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwx);
				}
				else
				{
					return ((bool4)this).zwx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.zwx = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.zwx = value;
					this = stack;
				}
			}
		}
		public mask8x3 zwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwy);
				}
				else
				{
					return ((bool4)this).zwy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.zwy = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.zwy = value;
					this = stack;
				}
			}
		}
		public readonly mask8x3 zwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zwz);
				}
				else
				{
					return ((bool4)this).zwz;
				}
			}
		}
		public readonly mask8x3 zww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zww);
				}
				else
				{
					return ((bool4)this).zww;
				}
			}
		}
		public readonly mask8x3 wxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxx);
				}
				else
				{
					return ((bool4)this).wxx;
				}
			}
		}
		public mask8x3 wxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxy);
				}
				else
				{
					return ((bool4)this).wxy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.wxy = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.wxy = value;
					this = stack;
				}
			}
		}
		public mask8x3 wxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxz);
				}
				else
				{
					return ((bool4)this).wxz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.wxz = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.wxz = value;
					this = stack;
				}
			}
		}
		public readonly mask8x3 wxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wxw);
				}
				else
				{
					return ((bool4)this).wxw;
				}
			}
		}
		public mask8x3 wyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wyx);
				}
				else
				{
					return ((bool4)this).wyx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.wyx = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.wyx = value;
					this = stack;
				}
			}
		}
		public readonly mask8x3 wyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wyy);
				}
				else
				{
					return ((bool4)this).wyy;
				}
			}
		}
		public mask8x3 wyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wyz);
				}
				else
				{
					return ((bool4)this).wyz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.wyz = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.wyz = value;
					this = stack;
				}
			}
		}
		public readonly mask8x3 wyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wyw);
				}
				else
				{
					return ((bool4)this).wyw;
				}
			}
		}
		public mask8x3 wzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzx);
				}
				else
				{
					return ((bool4)this).wzx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.wzx = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.wzx = value;
					this = stack;
				}
			}
		}
		public mask8x3 wzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzy);
				}
				else
				{
					return ((bool4)this).wzy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.wzy = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.wzy = value;
					this = stack;
				}
			}
		}
		public readonly mask8x3 wzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzz);
				}
				else
				{
					return ((bool4)this).wzz;
				}
			}
		}
		public readonly mask8x3 wzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wzw);
				}
				else
				{
					return ((bool4)this).wzw;
				}
			}
		}
		public readonly mask8x3 wwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwx);
				}
				else
				{
					return ((bool4)this).wwx;
				}
			}
		}
		public readonly mask8x3 wwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwy);
				}
				else
				{
					return ((bool4)this).wwy;
				}
			}
		}
		public readonly mask8x3 wwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wwz);
				}
				else
				{
					return ((bool4)this).wwz;
				}
			}
		}
		public readonly mask8x3 www
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).www);
				}
				else
				{
					return ((bool4)this).www;
				}
			}
		}
		public readonly mask8x2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xx);
				}
				else
				{
					return ((bool4)this).xx;
				}
			}
		}
		public mask8x2 xy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xy);
				}
				else
				{
					return ((bool4)this).xy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.xy = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.xy = value;
					this = stack;
				}
			}
		}
		public mask8x2 xz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xz);
				}
				else
				{
					return ((bool4)this).xz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.xz = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.xz = value;
					this = stack;
				}
			}
		}
		public mask8x2 xw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).xw);
				}
				else
				{
					return ((bool4)this).xw;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.xw = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.xw = value;
					this = stack;
				}
			}
		}
		public mask8x2 yx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yx);
				}
				else
				{
					return ((bool4)this).yx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.yx = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.yx = value;
					this = stack;
				}
			}
		}
		public readonly mask8x2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yy);
				}
				else
				{
					return ((bool4)this).yy;
				}
			}
		}
		public mask8x2 yz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yz);
				}
				else
				{
					return ((bool4)this).yz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.yz = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.yz = value;
					this = stack;
				}
			}
		}
		public mask8x2 yw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).yw);
				}
				else
				{
					return ((bool4)this).yw;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.yw = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.yw = value;
					this = stack;
				}
			}
		}
		public mask8x2 zx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zx);
				}
				else
				{
					return ((bool4)this).zx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.zx = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.zx = value;
					this = stack;
				}
			}
		}
		public mask8x2 zy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zy);
				}
				else
				{
					return ((bool4)this).zy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.zy = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.zy = value;
					this = stack;
				}
			}
		}
		public readonly mask8x2 zz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zz);
				}
				else
				{
					return ((bool4)this).zz;
				}
			}
		}
		public mask8x2 zw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).zw);
				}
				else
				{
					return ((bool4)this).zw;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.zw = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.zw = value;
					this = stack;
				}
			}
		}
		public mask8x2 wx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wx);
				}
				else
				{
					return ((bool4)this).wx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.wx = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.wx = value;
					this = stack;
				}
			}
		}
		public mask8x2 wy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wy);
				}
				else
				{
					return ((bool4)this).wy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.wy = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.wy = value;
					this = stack;
				}
			}
		}
		public mask8x2 wz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).wz);
				}
				else
				{
					return ((bool4)this).wz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					byte4 slice = (byte4)stack;
					slice.wz = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool4 stack = this;
					stack.wz = value;
					this = stack;
				}
			}
		}
		public readonly mask8x2 ww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v128)(((byte4)stack).ww);
				}
				else
				{
					return ((bool4)this).ww;
				}
			}
		}


		public bool this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
Assert.IsWithinArrayBounds(index, 4);

				if (BurstArchitecture.IsSIMDSupported)
				{
					return mask.Reinterpret<ulong2, byte16>()[index] != 0;
				}
				else
				{
					return ((bool4)this)[index];
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
Assert.IsWithinArrayBounds(index, 4);

				if (BurstArchitecture.IsSIMDSupported)
				{
					byte16 reinterpret = mask.Reinterpret<ulong2, byte16>();
					reinterpret[index] = (byte)-tolong(value);
					mask = reinterpret.Reinterpret<byte16, ulong2>();
				}
				else
				{
					bool4 reinterpret = this;
					reinterpret[index] = value;
					this = reinterpret;
				}
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator v128(mask8x4 input)
		{
			return input.mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x4(v128 input)
		{
			return new mask8x4 { mask = input };
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x4(mask16x4 input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return packs_epi16(input, input);
			}
			else
			{
				return *(mask8x4*)&input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x4(mask32x4 input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return cvtepi32_epi8(input);
			}
			else
			{
				return *(mask8x4*)&input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x4(mask64x4 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				return mm256_cvtepi64_epi8(input);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask8x4(cvtepi64_epi8(input.mask.xy), cvtepi64_epi8(input.mask.zw));
			}
			else
			{
				return (bool4)input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask16x4(mask8x4 input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return cvtepi8_epi16(input);
			}
			else
			{
				return *(mask16x4*)&input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask32x4(mask8x4 input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return cvtepi8_epi32(input);
			}
			else
			{
				return *(mask32x4*)&input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask64x4(mask8x4 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_cvtepi8_epi64(input);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask64x4(cvtepi8_epi64(input), cvtepi8_epi64(bsrli_si128(input, 2 * sizeof(byte))));
			}
			else
			{
				return (bool4)input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool4(mask8x4 input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.neg_epi8(input);
			}
			else
			{
				return *(bool4*)&input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x4(bool4 input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return neg_epi8(input);
			}
			else
			{
				mask8x4 result = default(mask8x4);
				*(bool4*)&result = input;
				return result;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Unity.Mathematics.bool4(mask8x4 input) => (bool4)input;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x4(Unity.Mathematics.bool4 input) => (bool4)input;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask8x4(bool input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return set1_epi64x(-tolong(input));
			}
			else
			{
				return (bool4)input;
			}
		}
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(byte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(ushort v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(uint v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(ulong v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(UInt128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(sbyte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(short v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(int v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(long v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(Int128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(quarter v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(half v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(float v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(double v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(quadruple v) => math.andnot(v != 0, math.isnan(v));


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator ! (mask8x4 value)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return not_si128(value);
			}
			else
			{
				return !(bool4)value;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator & (mask8x4 left, mask8x4 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return and_si128(left, right);
			}
			else
			{
				return (bool4)left & (bool4)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator & (mask8x4 left, bool right) => left & (mask8x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator & (bool left, mask8x4 right) => (mask8x4)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator & (mask8x4 left, bool4 right) => left & (mask8x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator & (bool4 left, mask8x4 right) => (mask8x4)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator & (mask8x4 left, Unity.Mathematics.bool4 right) => left & (mask8x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator & (Unity.Mathematics.bool4 left, mask8x4 right) => (mask8x4)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x4 operator & (mask8x4 left, mask16x4 right) => (mask16x4)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x4 operator & (mask16x4 left, mask8x4 right) => left & (mask16x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x4 operator & (mask8x4 left, mask32x4 right) => (mask32x4)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x4 operator & (mask32x4 left, mask8x4 right) => left & (mask32x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x4 operator & (mask8x4 left, mask64x4 right) => (mask64x4)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x4 operator & (mask64x4 left, mask8x4 right) => left & (mask64x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator | (mask8x4 left, mask8x4 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return or_si128(left, right);
			}
			else
			{
				return (bool4)left | (bool4)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator | (mask8x4 left, bool right) => left | (mask8x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator | (bool left, mask8x4 right) => (mask8x4)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator | (mask8x4 left, bool4 right) => left | (mask8x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator | (bool4 left, mask8x4 right) => (mask8x4)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator | (mask8x4 left, Unity.Mathematics.bool4 right) => left | (mask8x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator | (Unity.Mathematics.bool4 left, mask8x4 right) => (mask8x4)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x4 operator | (mask8x4 left, mask16x4 right) => (mask16x4)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x4 operator | (mask16x4 left, mask8x4 right) => left | (mask16x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x4 operator | (mask8x4 left, mask32x4 right) => (mask32x4)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x4 operator | (mask32x4 left, mask8x4 right) => left | (mask32x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x4 operator | (mask8x4 left, mask64x4 right) => (mask64x4)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x4 operator | (mask64x4 left, mask8x4 right) => left | (mask64x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator ^ (mask8x4 left, mask8x4 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return xor_si128(left, right);
			}
			else
			{
				return (bool4)left ^ (bool4)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator ^ (mask8x4 left, bool right) => left ^ (mask8x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator ^ (bool left, mask8x4 right) => (mask8x4)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator ^ (mask8x4 left, bool4 right) => left ^ (mask8x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator ^ (bool4 left, mask8x4 right) => (mask8x4)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator ^ (mask8x4 left, Unity.Mathematics.bool4 right) => left ^ (mask8x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator ^ (Unity.Mathematics.bool4 left, mask8x4 right) => (mask8x4)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x4 operator ^ (mask8x4 left, mask16x4 right) => (mask16x4)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x4 operator ^ (mask16x4 left, mask8x4 right) => left ^ (mask16x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x4 operator ^ (mask8x4 left, mask32x4 right) => (mask32x4)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x4 operator ^ (mask32x4 left, mask8x4 right) => left ^ (mask32x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x4 operator ^ (mask8x4 left, mask64x4 right) => (mask64x4)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x4 operator ^ (mask64x4 left, mask8x4 right) => left ^ (mask64x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator != (mask8x4 left, mask8x4 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return xor_si128(left, right);
			}
			else
			{
				return (bool4)left != (bool4)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator != (mask8x4 left, bool right) => left != (mask8x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator != (bool left, mask8x4 right) => (mask8x4)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator != (mask8x4 left, bool4 right) => left != (mask8x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator != (bool4 left, mask8x4 right) => (mask8x4)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator != (mask8x4 left, Unity.Mathematics.bool4 right) => left != (mask8x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator != (Unity.Mathematics.bool4 left, mask8x4 right) => (mask8x4)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x4 operator != (mask8x4 left, mask16x4 right) => (mask16x4)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x4 operator != (mask16x4 left, mask8x4 right) => left != (mask16x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x4 operator != (mask8x4 left, mask32x4 right) => (mask32x4)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x4 operator != (mask32x4 left, mask8x4 right) => left != (mask32x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x4 operator != (mask8x4 left, mask64x4 right) => (mask64x4)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x4 operator != (mask64x4 left, mask8x4 right) => left != (mask64x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator == (mask8x4 left, mask8x4 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return cmpeq_epi8(left, right);
			}
			else
			{
				return (bool4)left == (bool4)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator == (mask8x4 left, bool right) => left == (mask8x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator == (bool left, mask8x4 right) => (mask8x4)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator == (mask8x4 left, bool4 right) => left == (mask8x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator == (bool4 left, mask8x4 right) => (mask8x4)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator == (mask8x4 left, Unity.Mathematics.bool4 right) => left == (mask8x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask8x4 operator == (Unity.Mathematics.bool4 left, mask8x4 right) => (mask8x4)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x4 operator == (mask8x4 left, mask16x4 right) => (mask16x4)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask16x4 operator == (mask16x4 left, mask8x4 right) => left == (mask16x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x4 operator == (mask8x4 left, mask32x4 right) => (mask32x4)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask32x4 operator == (mask32x4 left, mask8x4 right) => left == (mask32x4)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x4 operator == (mask8x4 left, mask64x4 right) => (mask64x4)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x4 operator == (mask64x4 left, mask8x4 right) => left == (mask64x4)right;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool Equals(mask8x4 other)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return alltrue_epi128<byte>(cmpeq_epi8(this, other), 4);
			}
			else
			{
				return ((bool4)this).Equals((bool4)other);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override readonly int GetHashCode()
		{
			return bitmask(this);
		}

		public override readonly string ToString()
		{
			return ((bool4)this).ToString();
		}

        
        /// <summary>       Returns a <see cref="bool4"/> from the first 4 bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 FromBitmask(int bitmask)
        {
            mask8x4 result;
            if (BurstArchitecture.IsSIMDSupported)
            {
                result = Xse.broadcastmask_epi8(bitmask, MaskType.AllOnes, 4);
            }
            else
            {
                result = bool4.FromBitmask(bitmask);
            }

            constexpr.ASSUME(math.bitmask(result) == (bitmask & 0b1111));
            return result;
        }
	}
}
#pragma warning restore CS0660
