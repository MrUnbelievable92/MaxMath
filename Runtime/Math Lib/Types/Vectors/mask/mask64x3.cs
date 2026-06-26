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
	internal sealed class mask64x3DebuggerProxy
	{
		public bool x;
		public bool y;
		public bool z;
		
		public mask64x3DebuggerProxy(mask64x3 v)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				x = ((v256)v.mask).ULong0 != 0;
				y = ((v256)v.mask).ULong1 != 0;
				z = ((v256)v.mask).ULong2 != 0;
			}
			else
			{
				x = ((v256)v.mask).Byte0 != 0;
				y = ((v256)v.mask).Byte1 != 0;
				z = ((v256)v.mask).Byte2 != 0;
			}
		}
	}
	
	[System.Diagnostics.DebuggerTypeProxy(typeof(mask64x3DebuggerProxy))]
#endif
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	unsafe public ref struct mask64x3
	{
		internal ulong4 mask;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal mask64x3(v256 mask)
		{
			this.mask = mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal mask64x3(v128 maskLo, v128 maskHi)
		{
			this.mask = new ulong4(maskLo, maskHi);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(bool x, bool y, bool z)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v256)new ulong3((ulong)-tolong(x), (ulong)-tolong(y), (ulong)-tolong(z));
			}
			else
			{
				this = new bool3(x, y, z);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(bool x, mask64x2 yz)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v256)new ulong3((ulong)-tolong(x), (ulong2)(v128)yz);
			}
			else
			{
				this = new bool3(x, (bool2)yz);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(mask64x2 xy, bool z)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v256)new ulong3((ulong2)(v128)xy, (ulong)-tolong(z));
			}
			else
			{
				this = new bool3((bool2)xy, z);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(bool v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(bool3 v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(byte v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(byte3 v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(sbyte v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(sbyte3 v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(ushort v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(ushort3 v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(short v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(short3 v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(uint v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(uint3 v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(int v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(int3 v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(ulong v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(ulong3 v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(long v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(long3 v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(UInt128 v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(Int128 v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(quarter v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(quarter3 v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(half v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(half3 v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(float v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(float3 v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(double v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(double3 v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(quadruple v) => this = (mask64x3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(Unity.Mathematics.bool3 v) => this = (mask64x3)(bool3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(Unity.Mathematics.uint3 v) => this = (mask64x3)(uint3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(Unity.Mathematics.int3 v) => this = (mask64x3)(int3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(Unity.Mathematics.half v) => this = (mask64x3)(half)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(Unity.Mathematics.half3 v) => this = (mask64x3)(half3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(Unity.Mathematics.float3 v) => this = (mask64x3)(float3)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x3(Unity.Mathematics.double3 v) => this = (mask64x3)(double3)v;



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


		public readonly mask64x4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xxxx);
				}
				else
				{
					return ((bool3)this).xxxx;
				}
			}
		}
		public readonly mask64x4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xxxy);
				}
				else
				{
					return ((bool3)this).xxxy;
				}
			}
		}
		public readonly mask64x4 xxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xxxz);
				}
				else
				{
					return ((bool3)this).xxxz;
				}
			}
		}
		public readonly mask64x4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xxyx);
				}
				else
				{
					return ((bool3)this).xxyx;
				}
			}
		}
		public readonly mask64x4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xxyy);
				}
				else
				{
					return ((bool3)this).xxyy;
				}
			}
		}
		public readonly mask64x4 xxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xxyz);
				}
				else
				{
					return ((bool3)this).xxyz;
				}
			}
		}
		public readonly mask64x4 xxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xxzx);
				}
				else
				{
					return ((bool3)this).xxzx;
				}
			}
		}
		public readonly mask64x4 xxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xxzy);
				}
				else
				{
					return ((bool3)this).xxzy;
				}
			}
		}
		public readonly mask64x4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xxzz);
				}
				else
				{
					return ((bool3)this).xxzz;
				}
			}
		}
		public readonly mask64x4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xyxx);
				}
				else
				{
					return ((bool3)this).xyxx;
				}
			}
		}
		public readonly mask64x4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xyxy);
				}
				else
				{
					return ((bool3)this).xyxy;
				}
			}
		}
		public readonly mask64x4 xyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xyxz);
				}
				else
				{
					return ((bool3)this).xyxz;
				}
			}
		}
		public readonly mask64x4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xyyx);
				}
				else
				{
					return ((bool3)this).xyyx;
				}
			}
		}
		public readonly mask64x4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xyyy);
				}
				else
				{
					return ((bool3)this).xyyy;
				}
			}
		}
		public readonly mask64x4 xyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xyyz);
				}
				else
				{
					return ((bool3)this).xyyz;
				}
			}
		}
		public readonly mask64x4 xyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xyzx);
				}
				else
				{
					return ((bool3)this).xyzx;
				}
			}
		}
		public readonly mask64x4 xyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xyzy);
				}
				else
				{
					return ((bool3)this).xyzy;
				}
			}
		}
		public readonly mask64x4 xyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xyzz);
				}
				else
				{
					return ((bool3)this).xyzz;
				}
			}
		}
		public readonly mask64x4 xzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xzxx);
				}
				else
				{
					return ((bool3)this).xzxx;
				}
			}
		}
		public readonly mask64x4 xzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xzxy);
				}
				else
				{
					return ((bool3)this).xzxy;
				}
			}
		}
		public readonly mask64x4 xzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xzxz);
				}
				else
				{
					return ((bool3)this).xzxz;
				}
			}
		}
		public readonly mask64x4 xzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xzyx);
				}
				else
				{
					return ((bool3)this).xzyx;
				}
			}
		}
		public readonly mask64x4 xzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xzyy);
				}
				else
				{
					return ((bool3)this).xzyy;
				}
			}
		}
		public readonly mask64x4 xzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xzyz);
				}
				else
				{
					return ((bool3)this).xzyz;
				}
			}
		}
		public readonly mask64x4 xzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xzzx);
				}
				else
				{
					return ((bool3)this).xzzx;
				}
			}
		}
		public readonly mask64x4 xzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xzzy);
				}
				else
				{
					return ((bool3)this).xzzy;
				}
			}
		}
		public readonly mask64x4 xzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xzzz);
				}
				else
				{
					return ((bool3)this).xzzz;
				}
			}
		}
		public readonly mask64x4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yxxx);
				}
				else
				{
					return ((bool3)this).yxxx;
				}
			}
		}
		public readonly mask64x4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yxxy);
				}
				else
				{
					return ((bool3)this).yxxy;
				}
			}
		}
		public readonly mask64x4 yxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yxxz);
				}
				else
				{
					return ((bool3)this).yxxz;
				}
			}
		}
		public readonly mask64x4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yxyx);
				}
				else
				{
					return ((bool3)this).yxyx;
				}
			}
		}
		public readonly mask64x4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yxyy);
				}
				else
				{
					return ((bool3)this).yxyy;
				}
			}
		}
		public readonly mask64x4 yxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yxyz);
				}
				else
				{
					return ((bool3)this).yxyz;
				}
			}
		}
		public readonly mask64x4 yxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yxzx);
				}
				else
				{
					return ((bool3)this).yxzx;
				}
			}
		}
		public readonly mask64x4 yxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yxzy);
				}
				else
				{
					return ((bool3)this).yxzy;
				}
			}
		}
		public readonly mask64x4 yxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yxzz);
				}
				else
				{
					return ((bool3)this).yxzz;
				}
			}
		}
		public readonly mask64x4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yyxx);
				}
				else
				{
					return ((bool3)this).yyxx;
				}
			}
		}
		public readonly mask64x4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yyxy);
				}
				else
				{
					return ((bool3)this).yyxy;
				}
			}
		}
		public readonly mask64x4 yyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yyxz);
				}
				else
				{
					return ((bool3)this).yyxz;
				}
			}
		}
		public readonly mask64x4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yyyx);
				}
				else
				{
					return ((bool3)this).yyyx;
				}
			}
		}
		public readonly mask64x4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yyyy);
				}
				else
				{
					return ((bool3)this).yyyy;
				}
			}
		}
		public readonly mask64x4 yyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yyyz);
				}
				else
				{
					return ((bool3)this).yyyz;
				}
			}
		}
		public readonly mask64x4 yyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yyzx);
				}
				else
				{
					return ((bool3)this).yyzx;
				}
			}
		}
		public readonly mask64x4 yyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yyzy);
				}
				else
				{
					return ((bool3)this).yyzy;
				}
			}
		}
		public readonly mask64x4 yyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yyzz);
				}
				else
				{
					return ((bool3)this).yyzz;
				}
			}
		}
		public readonly mask64x4 yzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yzxx);
				}
				else
				{
					return ((bool3)this).yzxx;
				}
			}
		}
		public readonly mask64x4 yzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yzxy);
				}
				else
				{
					return ((bool3)this).yzxy;
				}
			}
		}
		public readonly mask64x4 yzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yzxz);
				}
				else
				{
					return ((bool3)this).yzxz;
				}
			}
		}
		public readonly mask64x4 yzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yzyx);
				}
				else
				{
					return ((bool3)this).yzyx;
				}
			}
		}
		public readonly mask64x4 yzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yzyy);
				}
				else
				{
					return ((bool3)this).yzyy;
				}
			}
		}
		public readonly mask64x4 yzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yzyz);
				}
				else
				{
					return ((bool3)this).yzyz;
				}
			}
		}
		public readonly mask64x4 yzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yzzx);
				}
				else
				{
					return ((bool3)this).yzzx;
				}
			}
		}
		public readonly mask64x4 yzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yzzy);
				}
				else
				{
					return ((bool3)this).yzzy;
				}
			}
		}
		public readonly mask64x4 yzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yzzz);
				}
				else
				{
					return ((bool3)this).yzzz;
				}
			}
		}
		public readonly mask64x4 zxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zxxx);
				}
				else
				{
					return ((bool3)this).zxxx;
				}
			}
		}
		public readonly mask64x4 zxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zxxy);
				}
				else
				{
					return ((bool3)this).zxxy;
				}
			}
		}
		public readonly mask64x4 zxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zxxz);
				}
				else
				{
					return ((bool3)this).zxxz;
				}
			}
		}
		public readonly mask64x4 zxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zxyx);
				}
				else
				{
					return ((bool3)this).zxyx;
				}
			}
		}
		public readonly mask64x4 zxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zxyy);
				}
				else
				{
					return ((bool3)this).zxyy;
				}
			}
		}
		public readonly mask64x4 zxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zxyz);
				}
				else
				{
					return ((bool3)this).zxyz;
				}
			}
		}
		public readonly mask64x4 zxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zxzx);
				}
				else
				{
					return ((bool3)this).zxzx;
				}
			}
		}
		public readonly mask64x4 zxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zxzy);
				}
				else
				{
					return ((bool3)this).zxzy;
				}
			}
		}
		public readonly mask64x4 zxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zxzz);
				}
				else
				{
					return ((bool3)this).zxzz;
				}
			}
		}
		public readonly mask64x4 zyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zyxx);
				}
				else
				{
					return ((bool3)this).zyxx;
				}
			}
		}
		public readonly mask64x4 zyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zyxy);
				}
				else
				{
					return ((bool3)this).zyxy;
				}
			}
		}
		public readonly mask64x4 zyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zyxz);
				}
				else
				{
					return ((bool3)this).zyxz;
				}
			}
		}
		public readonly mask64x4 zyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zyyx);
				}
				else
				{
					return ((bool3)this).zyyx;
				}
			}
		}
		public readonly mask64x4 zyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zyyy);
				}
				else
				{
					return ((bool3)this).zyyy;
				}
			}
		}
		public readonly mask64x4 zyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zyyz);
				}
				else
				{
					return ((bool3)this).zyyz;
				}
			}
		}
		public readonly mask64x4 zyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zyzx);
				}
				else
				{
					return ((bool3)this).zyzx;
				}
			}
		}
		public readonly mask64x4 zyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zyzy);
				}
				else
				{
					return ((bool3)this).zyzy;
				}
			}
		}
		public readonly mask64x4 zyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zyzz);
				}
				else
				{
					return ((bool3)this).zyzz;
				}
			}
		}
		public readonly mask64x4 zzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zzxx);
				}
				else
				{
					return ((bool3)this).zzxx;
				}
			}
		}
		public readonly mask64x4 zzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zzxy);
				}
				else
				{
					return ((bool3)this).zzxy;
				}
			}
		}
		public readonly mask64x4 zzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zzxz);
				}
				else
				{
					return ((bool3)this).zzxz;
				}
			}
		}
		public readonly mask64x4 zzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zzyx);
				}
				else
				{
					return ((bool3)this).zzyx;
				}
			}
		}
		public readonly mask64x4 zzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zzyy);
				}
				else
				{
					return ((bool3)this).zzyy;
				}
			}
		}
		public readonly mask64x4 zzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zzyz);
				}
				else
				{
					return ((bool3)this).zzyz;
				}
			}
		}
		public readonly mask64x4 zzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zzzx);
				}
				else
				{
					return ((bool3)this).zzzx;
				}
			}
		}
		public readonly mask64x4 zzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zzzy);
				}
				else
				{
					return ((bool3)this).zzzy;
				}
			}
		}
		public readonly mask64x4 zzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zzzz);
				}
				else
				{
					return ((bool3)this).zzzz;
				}
			}
		}
		public readonly mask64x3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xxx);
				}
				else
				{
					return ((bool3)this).xxx;
				}
			}
		}
		public readonly mask64x3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xxy);
				}
				else
				{
					return ((bool3)this).xxy;
				}
			}
		}
		public readonly mask64x3 xxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xxz);
				}
				else
				{
					return ((bool3)this).xxz;
				}
			}
		}
		public readonly mask64x3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xyx);
				}
				else
				{
					return ((bool3)this).xyx;
				}
			}
		}
		public readonly mask64x3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xyy);
				}
				else
				{
					return ((bool3)this).xyy;
				}
			}
		}
		public mask64x3 xyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xyz);
				}
				else
				{
					return ((bool3)this).xyz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					ulong4 slice = (ulong4)stack;
					slice.xyz = (v256)value;
					this = (v256)slice;
				}
				else
				{
					bool3 stack = this;
					stack.xyz = value;
					this = stack;
				}
			}
		}
		public readonly mask64x3 xzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xzx);
				}
				else
				{
					return ((bool3)this).xzx;
				}
			}
		}
		public mask64x3 xzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xzy);
				}
				else
				{
					return ((bool3)this).xzy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					ulong4 slice = (ulong4)stack;
					slice.xzy = (v256)value;
					this = (v256)slice;
				}
				else
				{
					bool3 stack = this;
					stack.xzy = value;
					this = stack;
				}
			}
		}
		public readonly mask64x3 xzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).xzz);
				}
				else
				{
					return ((bool3)this).xzz;
				}
			}
		}
		public readonly mask64x3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yxx);
				}
				else
				{
					return ((bool3)this).yxx;
				}
			}
		}
		public readonly mask64x3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yxy);
				}
				else
				{
					return ((bool3)this).yxy;
				}
			}
		}
		public mask64x3 yxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yxz);
				}
				else
				{
					return ((bool3)this).yxz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					ulong4 slice = (ulong4)stack;
					slice.yxz = (v256)value;
					this = (v256)slice;
				}
				else
				{
					bool3 stack = this;
					stack.yxz = value;
					this = stack;
				}
			}
		}
		public readonly mask64x3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yyx);
				}
				else
				{
					return ((bool3)this).yyx;
				}
			}
		}
		public readonly mask64x3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yyy);
				}
				else
				{
					return ((bool3)this).yyy;
				}
			}
		}
		public readonly mask64x3 yyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yyz);
				}
				else
				{
					return ((bool3)this).yyz;
				}
			}
		}
		public mask64x3 yzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yzx);
				}
				else
				{
					return ((bool3)this).yzx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					ulong4 slice = (ulong4)stack;
					slice.yzx = (v256)value;
					this = (v256)slice;
				}
				else
				{
					bool3 stack = this;
					stack.yzx = value;
					this = stack;
				}
			}
		}
		public readonly mask64x3 yzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yzy);
				}
				else
				{
					return ((bool3)this).yzy;
				}
			}
		}
		public readonly mask64x3 yzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).yzz);
				}
				else
				{
					return ((bool3)this).yzz;
				}
			}
		}
		public readonly mask64x3 zxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zxx);
				}
				else
				{
					return ((bool3)this).zxx;
				}
			}
		}
		public mask64x3 zxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zxy);
				}
				else
				{
					return ((bool3)this).zxy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					ulong4 slice = (ulong4)stack;
					slice.zxy = (v256)value;
					this = (v256)slice;
				}
				else
				{
					bool3 stack = this;
					stack.zxy = value;
					this = stack;
				}
			}
		}
		public readonly mask64x3 zxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zxz);
				}
				else
				{
					return ((bool3)this).zxz;
				}
			}
		}
		public mask64x3 zyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zyx);
				}
				else
				{
					return ((bool3)this).zyx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					ulong4 slice = (ulong4)stack;
					slice.zyx = (v256)value;
					this = (v256)slice;
				}
				else
				{
					bool3 stack = this;
					stack.zyx = value;
					this = stack;
				}
			}
		}
		public readonly mask64x3 zyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zyy);
				}
				else
				{
					return ((bool3)this).zyy;
				}
			}
		}
		public readonly mask64x3 zyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zyz);
				}
				else
				{
					return ((bool3)this).zyz;
				}
			}
		}
		public readonly mask64x3 zzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zzx);
				}
				else
				{
					return ((bool3)this).zzx;
				}
			}
		}
		public readonly mask64x3 zzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zzy);
				}
				else
				{
					return ((bool3)this).zzy;
				}
			}
		}
		public readonly mask64x3 zzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v256)(((ulong4)stack).zzz);
				}
				else
				{
					return ((bool3)this).zzz;
				}
			}
		}
		public readonly mask64x2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v128)(((ulong4)stack).xx);
				}
				else
				{
					return ((bool3)this).xx;
				}
			}
		}
		public mask64x2 xy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v128)(((ulong4)stack).xy);
				}
				else
				{
					return ((bool3)this).xy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					ulong4 slice = (ulong4)stack;
					slice.xy = (v128)value;
					this = (v256)slice;
				}
				else
				{
					bool3 stack = this;
					stack.xy = value;
					this = stack;
				}
			}
		}
		public mask64x2 xz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v128)(((ulong4)stack).xz);
				}
				else
				{
					return ((bool3)this).xz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					ulong4 slice = (ulong4)stack;
					slice.xz = (v128)value;
					this = (v256)slice;
				}
				else
				{
					bool3 stack = this;
					stack.xz = value;
					this = stack;
				}
			}
		}
		public mask64x2 yx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v128)(((ulong4)stack).yx);
				}
				else
				{
					return ((bool3)this).yx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					ulong4 slice = (ulong4)stack;
					slice.yx = (v128)value;
					this = (v256)slice;
				}
				else
				{
					bool3 stack = this;
					stack.yx = value;
					this = stack;
				}
			}
		}
		public readonly mask64x2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v128)(((ulong4)stack).yy);
				}
				else
				{
					return ((bool3)this).yy;
				}
			}
		}
		public mask64x2 yz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v128)(((ulong4)stack).yz);
				}
				else
				{
					return ((bool3)this).yz;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					ulong4 slice = (ulong4)stack;
					slice.yz = (v128)value;
					this = (v256)slice;
				}
				else
				{
					bool3 stack = this;
					stack.yz = value;
					this = stack;
				}
			}
		}
		public mask64x2 zx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v128)(((ulong4)stack).zx);
				}
				else
				{
					return ((bool3)this).zx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					ulong4 slice = (ulong4)stack;
					slice.zx = (v128)value;
					this = (v256)slice;
				}
				else
				{
					bool3 stack = this;
					stack.zx = value;
					this = stack;
				}
			}
		}
		public mask64x2 zy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v128)(((ulong4)stack).zy);
				}
				else
				{
					return ((bool3)this).zy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					ulong4 slice = (ulong4)stack;
					slice.zy = (v128)value;
					this = (v256)slice;
				}
				else
				{
					bool3 stack = this;
					stack.zy = value;
					this = stack;
				}
			}
		}
		public readonly mask64x2 zz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v256 stack = this;
					return (v128)(((ulong4)stack).zz);
				}
				else
				{
					return ((bool3)this).zz;
				}
			}
		}


		public bool this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
Assert.IsWithinArrayBounds(index, 3);

				if (BurstArchitecture.IsSIMDSupported)
				{
					return mask.Reinterpret<ulong4, ulong4>()[index] != 0;
				}
				else
				{
					return ((bool3)this)[index];
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
Assert.IsWithinArrayBounds(index, 3);

				if (BurstArchitecture.IsSIMDSupported)
				{
					ulong4 reinterpret = mask.Reinterpret<ulong4, ulong4>();
					reinterpret[index] = (ulong)-tolong(value);
					mask = reinterpret.Reinterpret<ulong4, ulong4>();
				}
				else
				{
					bool3 reinterpret = this;
					reinterpret[index] = value;
					this = reinterpret;
				}
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator v256(mask64x3 input)
		{
			return input.mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask64x3(v256 input)
		{
			return new mask64x3 { mask = input };
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool3(mask64x3 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_cvtepi64_epi8(Xse.mm256_neg_epi64(input));
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				v128 lo = Xse.cvtepi64_epi8(input.mask.xy);
				v128 hi = Xse.cvtepi64_epi8(input.mask.zw);

				return Xse.neg_epi8(unpacklo_epi16(lo, hi));
			}
			else
			{
				return *(bool3*)&input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask64x3(bool3 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				return mm256_neg_epi64(Avx2.mm256_cvtepu8_epi64(input));
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask64x3(neg_epi64(cvtepu8_epi64(input.xy)), neg_epi64(cvtsi64x_si128(tobyte(input.z))));
			}
			else
			{
				mask64x3 result = default(mask64x3);
				*(bool3*)&result = input;
				return result;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Unity.Mathematics.bool3(mask64x3 input) => (bool3)input;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask64x3(Unity.Mathematics.bool3 input) => (bool3)input;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask64x3(bool input)
		{
			if (Avx.IsAvxSupported)
			{
				return mm256_set1_epi64x(-tolong(input));
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask64x3(set1_epi64x(-tolong(input)), set1_epi64x(-tolong(input)));
			}
			else
			{
				return (bool3)input;
			}
		}
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(byte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(ushort v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(uint v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(ulong v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(UInt128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(sbyte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(short v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(int v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(long v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(Int128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(quarter v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(half v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(float v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(double v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(quadruple v) => math.andnot(v != 0, math.isnan(v));


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator ! (mask64x3 value)
		{
			if (Avx.IsAvxSupported)
			{
				return mm256_not_si256(value);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask64x3(not_si128(value.mask.xy), not_si128(value.mask.zw));
			}
			else
			{
				return !(bool3)value;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator & (mask64x3 left, mask64x3 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_and_ps(left, right);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask64x3(and_si128(left.mask.xy, right.mask.xy), and_si128(left.mask.zw, right.mask.zw));
			}
			else
			{
				return (bool3)left & (bool3)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator & (mask64x3 left, bool right) => left & (mask64x3)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator & (bool left, mask64x3 right) => (mask64x3)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator & (mask64x3 left, bool3 right) => left & (mask64x3)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator & (bool3 left, mask64x3 right) => (mask64x3)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator & (mask64x3 left, Unity.Mathematics.bool3 right) => left & (mask64x3)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator & (Unity.Mathematics.bool3 left, mask64x3 right) => (mask64x3)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator | (mask64x3 left, mask64x3 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_or_ps(left, right);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask64x3(or_si128(left.mask.xy, right.mask.xy), or_si128(left.mask.zw, right.mask.zw));
			}
			else
			{
				return (bool3)left | (bool3)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator | (mask64x3 left, bool right) => left | (mask64x3)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator | (bool left, mask64x3 right) => (mask64x3)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator | (mask64x3 left, bool3 right) => left | (mask64x3)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator | (bool3 left, mask64x3 right) => (mask64x3)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator | (mask64x3 left, Unity.Mathematics.bool3 right) => left | (mask64x3)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator | (Unity.Mathematics.bool3 left, mask64x3 right) => (mask64x3)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator ^ (mask64x3 left, mask64x3 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_xor_ps(left, right);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask64x3(xor_si128(left.mask.xy, right.mask.xy), xor_si128(left.mask.zw, right.mask.zw));
			}
			else
			{
				return (bool3)left ^ (bool3)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator ^ (mask64x3 left, bool right) => left ^ (mask64x3)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator ^ (bool left, mask64x3 right) => (mask64x3)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator ^ (mask64x3 left, bool3 right) => left ^ (mask64x3)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator ^ (bool3 left, mask64x3 right) => (mask64x3)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator ^ (mask64x3 left, Unity.Mathematics.bool3 right) => left ^ (mask64x3)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator ^ (Unity.Mathematics.bool3 left, mask64x3 right) => (mask64x3)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator != (mask64x3 left, mask64x3 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_xor_ps(left, right);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask64x3(xor_si128(left.mask.xy, right.mask.xy), xor_si128(left.mask.zw, right.mask.zw));
			}
			else
			{
				return (bool3)left != (bool3)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator != (mask64x3 left, bool right) => left != (mask64x3)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator != (bool left, mask64x3 right) => (mask64x3)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator != (mask64x3 left, bool3 right) => left != (mask64x3)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator != (bool3 left, mask64x3 right) => (mask64x3)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator != (mask64x3 left, Unity.Mathematics.bool3 right) => left != (mask64x3)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator != (Unity.Mathematics.bool3 left, mask64x3 right) => (mask64x3)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator == (mask64x3 left, mask64x3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_cmpeq_epi64(left, right);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new mask64x3(cmpeq_epi64(left.mask.xy, right.mask.xy), cmpeq_epi64(left.mask.zw, right.mask.zw));
			}
			else
			{
				return (bool3)left == (bool3)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator == (mask64x3 left, bool right) => left == (mask64x3)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator == (bool left, mask64x3 right) => (mask64x3)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator == (mask64x3 left, bool3 right) => left == (mask64x3)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator == (bool3 left, mask64x3 right) => (mask64x3)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator == (mask64x3 left, Unity.Mathematics.bool3 right) => left == (mask64x3)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x3 operator == (Unity.Mathematics.bool3 left, mask64x3 right) => (mask64x3)left == right;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool Equals(mask64x3 other)
		{
			if (Avx2.IsAvx2Supported)
			{
				return mm256_alltrue_epi256<ulong>(Avx2.mm256_cmpeq_epi64(this, other));
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				bool lo = alltrue_epi128<ulong>(cmpeq_epi64(this.mask.xy, other.mask.xy));
				bool hi = this.mask.z == other.mask.z;
				return lo & hi;
			}
			else
			{
				return ((bool3)this).Equals((bool3)other);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override readonly int GetHashCode()
		{
			return bitmask(this);
		}

		public override readonly string ToString()
		{
			return ((bool3)this).ToString();
		}

        
        /// <summary>       Returns a <see cref="bool3"/> from the first 3 bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 FromBitmask(int bitmask)
        {
            mask64x3 result;
            if (Avx2.IsAvx2Supported)
            {
                result = Xse.mm256_broadcastmask_epi64(bitmask, MaskType.AllOnes, 3);
            }
			else if (BurstArchitecture.IsSIMDSupported)
			{
				result = new mask64x3(Xse.broadcastmask_epi64(bitmask), math.tobool((bitmask >> 2) & 1));
			}
            else
            {
                result = bool3.FromBitmask(bitmask);
            }

            constexpr.ASSUME(math.bitmask(result) == (bitmask & 0b0111));
            return result;
        }
	}
}
#pragma warning restore CS0660
