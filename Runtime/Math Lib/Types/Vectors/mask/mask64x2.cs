using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using DevTools;
using MaxMath.Intrinsics;

using static MaxMath.Intrinsics.Xse;
using static MaxMath.math;

#pragma warning disable CS0660

namespace MaxMath
{
#if DEBUG
	internal sealed class mask64x2DebuggerProxy
	{
		public bool x;
		public bool y;
	
		public mask64x2DebuggerProxy(mask64x2 v)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				x = ((v128)v.mask).ULong0 != 0;
				y = ((v128)v.mask).ULong1 != 0;
			}
			else
			{
				x = ((v128)v.mask).Byte0 != 0;
				y = ((v128)v.mask).Byte1 != 0;
			}
		}
	}

	[System.Diagnostics.DebuggerTypeProxy(typeof(mask64x2DebuggerProxy))]
#endif
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	unsafe public ref struct mask64x2
	{
		internal ulong2 mask;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal mask64x2(v128 mask)
		{
			this.mask = mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(bool x, bool y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = (v128)new ulong2((ulong)-tolong(x), (ulong)-tolong(y));
			}
			else
			{
				this = (v128)new byte2(tobyte(x), tobyte(y));
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(bool2 xy) => this = (mask64x2)xy;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(bool v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(byte v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(byte2 v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(sbyte v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(sbyte2 v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(ushort v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(ushort2 v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(short v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(short2 v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(uint v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(uint2 v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(int v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(int2 v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(ulong v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(ulong2 v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(long v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(long2 v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(UInt128 v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(Int128 v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(quarter v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(quarter2 v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(half v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(half2 v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(float v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(float2 v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(double v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(double2 v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(quadruple v) => this = (mask64x2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(Unity.Mathematics.bool2 v) => this = (mask64x2)(bool2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(Unity.Mathematics.uint2 v) => this = (mask64x2)(uint2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(Unity.Mathematics.int2 v) => this = (mask64x2)(int2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(Unity.Mathematics.half v) => this = (mask64x2)(half)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(Unity.Mathematics.half2 v) => this = (mask64x2)(half2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(Unity.Mathematics.float2 v) => this = (mask64x2)(float2)v;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public mask64x2(Unity.Mathematics.double2 v) => this = (mask64x2)(double2)v;



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


		public readonly mask64x4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					return (v256)(((ulong2)stack).xxxx);
				}
				else
				{
					return ((bool2)this).xxxx;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).xxxy);
				}
				else
				{
					return ((bool2)this).xxxy;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).xxyx);
				}
				else
				{
					return ((bool2)this).xxyx;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).xxyy);
				}
				else
				{
					return ((bool2)this).xxyy;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).xyxx);
				}
				else
				{
					return ((bool2)this).xyxx;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).xyxy);
				}
				else
				{
					return ((bool2)this).xyxy;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).xyyx);
				}
				else
				{
					return ((bool2)this).xyyx;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).xyyy);
				}
				else
				{
					return ((bool2)this).xyyy;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).yxxx);
				}
				else
				{
					return ((bool2)this).yxxx;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).yxxy);
				}
				else
				{
					return ((bool2)this).yxxy;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).yxyx);
				}
				else
				{
					return ((bool2)this).yxyx;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).yxyy);
				}
				else
				{
					return ((bool2)this).yxyy;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).yyxx);
				}
				else
				{
					return ((bool2)this).yyxx;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).yyxy);
				}
				else
				{
					return ((bool2)this).yyxy;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).yyyx);
				}
				else
				{
					return ((bool2)this).yyyx;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).yyyy);
				}
				else
				{
					return ((bool2)this).yyyy;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).xxx);
				}
				else
				{
					return ((bool2)this).xxx;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).xxy);
				}
				else
				{
					return ((bool2)this).xxy;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).xyx);
				}
				else
				{
					return ((bool2)this).xyx;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).xyy);
				}
				else
				{
					return ((bool2)this).xyy;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).yxx);
				}
				else
				{
					return ((bool2)this).yxx;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).yxy);
				}
				else
				{
					return ((bool2)this).yxy;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).yyx);
				}
				else
				{
					return ((bool2)this).yyx;
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
					v128 stack = this;
					return (v256)(((ulong2)stack).yyy);
				}
				else
				{
					return ((bool2)this).yyy;
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
					v128 stack = this;
					return (v128)(((ulong2)stack).xx);
				}
				else
				{
					return ((bool2)this).xx;
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
					v128 stack = this;
					return (v128)(((ulong2)stack).xy);
				}
				else
				{
					return ((bool2)this).xy;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					ulong2 slice = (ulong2)stack;
					slice.xy = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool2 stack = this;
					stack.xy = value;
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
					v128 stack = this;
					return (v128)(((ulong2)stack).yx);
				}
				else
				{
					return ((bool2)this).yx;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 stack = this;
					ulong2 slice = (ulong2)stack;
					slice.yx = (v128)value;
					this = (v128)slice;
				}
				else
				{
					bool2 stack = this;
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
					v128 stack = this;
					return (v128)(((ulong2)stack).yy);
				}
				else
				{
					return ((bool2)this).yy;
				}
			}
		}


		public bool this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
Assert.IsWithinArrayBounds(index, 2);

				if (BurstArchitecture.IsSIMDSupported)
				{
					return mask.Reinterpret<ulong2, ulong2>()[index] != 0;
				}
				else
				{
					return ((bool2)this)[index];
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
Assert.IsWithinArrayBounds(index, 2);

				if (BurstArchitecture.IsSIMDSupported)
				{
					ulong2 reinterpret = mask.Reinterpret<ulong2, ulong2>();
					reinterpret[index] = (ulong)-tolong(value);
					mask = reinterpret.Reinterpret<ulong2, ulong2>();
				}
				else
				{
					bool2 reinterpret = this;
					reinterpret[index] = value;
					this = reinterpret;
				}
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator v128(mask64x2 input)
		{
			return input.mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask64x2(v128 input)
		{
			return new mask64x2 { mask = input };
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool2(mask64x2 input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.cvtepi64_epi8(Xse.neg_epi64(input));
			}
			else
			{
				return *(bool2*)&input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask64x2(bool2 input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return neg_epi64(cvtepu8_epi64(input));
			}
			else
			{
				mask64x2 result = default(mask64x2);
				*(bool2*)&result = input;
				return result;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Unity.Mathematics.bool2(mask64x2 input) => (bool2)input;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask64x2(Unity.Mathematics.bool2 input) => (bool2)input;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator mask64x2(bool input)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return set1_epi64x(-tolong(input));
			}
			else
			{
				return (bool2)input;
			}
		}
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(byte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(ushort v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(uint v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(ulong v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(UInt128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(sbyte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(short v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(int v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(long v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(Int128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(quarter v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(half v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(float v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(double v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(quadruple v) => math.andnot(v != 0, math.isnan(v));


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator ! (mask64x2 value)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return not_si128(value);
			}
			else
			{
				return !(bool2)value;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator & (mask64x2 left, mask64x2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return and_si128(left, right);
			}
			else
			{
				return (bool2)left & (bool2)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator & (mask64x2 left, bool right) => left & (mask64x2)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator & (bool left, mask64x2 right) => (mask64x2)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator & (mask64x2 left, bool2 right) => left & (mask64x2)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator & (bool2 left, mask64x2 right) => (mask64x2)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator & (mask64x2 left, Unity.Mathematics.bool2 right) => left & (mask64x2)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator & (Unity.Mathematics.bool2 left, mask64x2 right) => (mask64x2)left & right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator | (mask64x2 left, mask64x2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return or_si128(left, right);
			}
			else
			{
				return (bool2)left | (bool2)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator | (mask64x2 left, bool right) => left | (mask64x2)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator | (bool left, mask64x2 right) => (mask64x2)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator | (mask64x2 left, bool2 right) => left | (mask64x2)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator | (bool2 left, mask64x2 right) => (mask64x2)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator | (mask64x2 left, Unity.Mathematics.bool2 right) => left | (mask64x2)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator | (Unity.Mathematics.bool2 left, mask64x2 right) => (mask64x2)left | right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator ^ (mask64x2 left, mask64x2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return xor_si128(left, right);
			}
			else
			{
				return (bool2)left ^ (bool2)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator ^ (mask64x2 left, bool right) => left ^ (mask64x2)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator ^ (bool left, mask64x2 right) => (mask64x2)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator ^ (mask64x2 left, bool2 right) => left ^ (mask64x2)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator ^ (bool2 left, mask64x2 right) => (mask64x2)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator ^ (mask64x2 left, Unity.Mathematics.bool2 right) => left ^ (mask64x2)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator ^ (Unity.Mathematics.bool2 left, mask64x2 right) => (mask64x2)left ^ right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator != (mask64x2 left, mask64x2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return xor_si128(left, right);
			}
			else
			{
				return (bool2)left != (bool2)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator != (mask64x2 left, bool right) => left != (mask64x2)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator != (bool left, mask64x2 right) => (mask64x2)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator != (mask64x2 left, bool2 right) => left != (mask64x2)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator != (bool2 left, mask64x2 right) => (mask64x2)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator != (mask64x2 left, Unity.Mathematics.bool2 right) => left != (mask64x2)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator != (Unity.Mathematics.bool2 left, mask64x2 right) => (mask64x2)left != right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator == (mask64x2 left, mask64x2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return cmpeq_epi64(left, right);
			}
			else
			{
				return (bool2)left == (bool2)right;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator == (mask64x2 left, bool right) => left == (mask64x2)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator == (bool left, mask64x2 right) => (mask64x2)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator == (mask64x2 left, bool2 right) => left == (mask64x2)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator == (bool2 left, mask64x2 right) => (mask64x2)left == right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator == (mask64x2 left, Unity.Mathematics.bool2 right) => left == (mask64x2)right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static mask64x2 operator == (Unity.Mathematics.bool2 left, mask64x2 right) => (mask64x2)left == right;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool Equals(mask64x2 other)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return alltrue_epi128<ulong>(cmpeq_epi64(this, other));
			}
			else
			{
				return ((bool2)this).Equals((bool2)other);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override readonly int GetHashCode()
		{
			return bitmask(this);
		}

		public override readonly string ToString()
		{
			return ((bool2)this).ToString();
		}

        
        /// <summary>       Returns a <see cref="bool2"/> from the first 2 bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 FromBitmask(int bitmask)
        {
            mask64x2 result;
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.broadcastmask_epi64(bitmask, MaskType.AllOnes);
            }
            else
            {
                result = bool2.FromBitmask(bitmask);
            }

            constexpr.ASSUME(math.bitmask(result) == (bitmask & 0b0011));
            return result;
        }
	}
}
#pragma warning restore CS0660
