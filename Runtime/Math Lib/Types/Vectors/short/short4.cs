using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MaxMath.Intrinsics;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable] 
	[StructLayout(LayoutKind.Explicit, Size = 4 * sizeof(short))]  
	[DebuggerTypeProxy(typeof(short4.DebuggerProxy))]
    unsafe public struct short4 : IEquatable<short4>, IFormattable
	{
		internal sealed class DebuggerProxy
		{
			public short x;
			public short y;
			public short z;
			public short w;

			public DebuggerProxy(short4 v)
			{
				x = v.x;
				y = v.y;
				z = v.z;
				w = v.w;
			}
		}


		[FieldOffset(0)] private fixed short asArray[4];

        // otherhwise LLVM/Burst goes crazy with bitshifts and masks etc. -.-
        [FieldOffset(0)] internal long alias_long;

        [FieldOffset(0)] public short x;
        [FieldOffset(2)] public short y;
        [FieldOffset(4)] public short z;
        [FieldOffset(6)] public short w;


        public static short4 zero => default;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short x, short y, short z, short w)
        {
            if (Sse2.IsSse2Supported)
			{
                if (Constant.IsConstantExpression(x) && Constant.IsConstantExpression(y) && Constant.IsConstantExpression(z) && Constant.IsConstantExpression(w))
                {
                    this = Sse2.cvtsi64x_si128((long)bitfield(x, y, z, w));
                }
                else
                {
					this = Sse2.set_epi16(0, 0, 0, 0, w, z, y, x);
                }
			}
			else
            {
				this = new short4
				{
					x = x,
					y = y,
					z = z,
					w = w
				};
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short xyzw)
        {
			if (Sse2.IsSse2Supported)
			{
                if (Constant.IsConstantExpression(xyzw))
                {
					this = Sse2.cvtsi64x_si128((long)bitfield(xyzw, xyzw, xyzw, xyzw));
                }
				else
				{
					this = Sse2.shufflelo_epi16(Sse2.cvtsi32_si128((ushort)xyzw), Sse.SHUFFLE(0, 0, 0, 0));
				}
			}
			else
			{
				this = new short4
				{
					x = xyzw,
					y = xyzw,
					z = xyzw,
					w = xyzw
				};
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short2 xy, short z, short w)
        {
            if (Sse2.IsSse2Supported)
			{
				this = Sse2.insert_epi16(Sse2.insert_epi16(xy, z, 2), w, 3);
			}
			else
            {
				this = new short4
				{
					x = xy.x,
					y = xy.y,
					z = z,
					w = w
				};
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short x, short2 yz, short w)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.insert_epi16(Sse2.insert_epi16(Sse2.bslli_si128(yz, sizeof(short)), x, 0), w, 3);
			}
			else
			{
				this = new short4
				{
					x = x,
					y = yz.x,
					z = yz.y,
					w = w
				};
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short x, short y, short2 zw)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.unpacklo_epi32(new short2(x, y), zw);
			}
			else
			{
				this = new short4
				{
					x = x,
					y = y,
					z = zw.x,
					w = zw.y,
				};
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short2 xy, short2 zw)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.unpacklo_epi32(xy, zw);
			}
			else
			{
				this = new short4
				{
					x = xy.x,
					y = xy.y,
					z = zw.x,
					w = zw.y
				};
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short3 xyz, short w)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.insert_epi16(xyz, w, 3);
			}
			else
			{
				this = new short4
				{
					x = xyz.x,
					y = xyz.y,
					z = xyz.z,
					w = w
				};
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short x, short3 yzw)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.insert_epi16(Sse2.bslli_si128(yzw, sizeof(short)), x, 0);
			}
			else
			{
				this = new short4
				{
					x = x,
					y = yzw.x,
					z = yzw.y,
					w = yzw.z
				};
			}
        }


        #region Shuffle
        public readonly short4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 0));
				}
				else
				{
					return new short4(x, x, x, x);
				}
			}
		}
		public readonly short4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 0));
				}
				else
				{
					return new short4(x, x, x, y);
				}
			}
		}
		public readonly short4 xxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 0));
				}
				else
				{
					return new short4(x, x, x, z);
				}
			}
		}
		public readonly short4 xxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 0));
				}
				else
				{
					return new short4(x, x, x, w);
				}
			}
		}
		public readonly short4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 0));
				}
				else
				{
					return new short4(x, x, y, x);
				}
			}
		}
		public readonly short4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 0));
				}
				else
				{
					return new short4(x, x, y, y);
				}
			}
		}
		public readonly short4 xxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 0));
				}
				else
				{
					return new short4(x, x, y, z);
				}
			}
		}
		public readonly short4 xxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 0));
				}
				else
				{
					return new short4(x, x, y, w);
				}
			}
		}
		public readonly short4 xxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 0));
				}
				else
				{
					return new short4(x, x, z, x);
				}
			}
		}
		public readonly short4 xxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 0));
				}
				else
				{
					return new short4(x, x, z, y);
				}
			}
		}
		public readonly short4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 0));
				}
				else
				{
					return new short4(x, x, z, z);
				}
			}
		}
		public readonly short4 xxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 0));
				}
				else
				{
					return new short4(x, x, z, w);
				}
			}
		}
		public readonly short4 xxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 0, 0));
				}
				else
				{
					return new short4(x, x, w, x);
				}
			}
		}
		public readonly short4 xxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 0, 0));
				}
				else
				{
					return new short4(x, x, w, y);
				}
			}
		}
		public readonly short4 xxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 0, 0));
				}
				else
				{
					return new short4(x, x, w, z);
				}
			}
		}
		public readonly short4 xxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 0));
				}
				else
				{
					return new short4(x, x, w, w);
				}
			}
		}
		public readonly short4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 0));
				}
				else
				{
					return new short4(x, y, x, x);
				}
			}
		}
		public readonly short4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 0));
				}
				else
				{
					return new short4(x, y, x, y);
				}
			}
		}
		public readonly short4 xyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 0));
				}
				else
				{
					return new short4(x, y, x, z);
				}
			}
		}
		public readonly short4 xyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 0));
				}
				else
				{
					return new short4(x, y, x, w);
				}
			}
		}
		public readonly short4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 0));
				}
				else
				{
					return new short4(x, y, y, x);
				}
			}
		}
		public readonly short4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 0));
				}
				else
				{
					return new short4(x, y, y, y);
				}
			}
		}
		public readonly short4 xyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 0));
				}
				else
				{
					return new short4(x, y, y, z);
				}
			}
		}
		public readonly short4 xyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 0));
				}
				else
				{
					return new short4(x, y, y, w);
				}
			}
		}
		public readonly short4 xyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 0));
				}
				else
				{
					return new short4(x, y, z, x);
				}
			}
		}
		public readonly short4 xyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 0));
				}
				else
				{
					return new short4(x, y, z, y);
				}
			}
		}
		public readonly short4 xyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 0));
				}
				else
				{
					return new short4(x, y, z, z);
				}
			}
		}
		public readonly short4 xywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 1, 0));
				}
				else
				{
					return new short4(x, y, w, x);
				}
			}
		}
		public readonly short4 xywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 1, 0));
				}
				else
				{
					return new short4(x, y, w, y);
				}
			}
		}
		public			short4 xywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 1, 0));
				}
				else
				{
					return new short4(x, y, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xywz;
			}
		}
		public readonly short4 xyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 0));
				}
				else
				{
					return new short4(x, y, w, w);
				}
			}
		}
		public readonly short4 xzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 0));
				}
				else
				{
					return new short4(x, z, x, x);
				}
			}
		}
		public readonly short4 xzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 0));
				}
				else
				{
					return new short4(x, z, x, y);
				}
			}
		}
		public readonly short4 xzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 0));
				}
				else
				{
					return new short4(x, z, x, z);
				}
			}
		}
		public readonly short4 xzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 0));
				}
				else
				{
					return new short4(x, z, x, w);
				}
			}
		}
		public readonly short4 xzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 0));
				}
				else
				{
					return new short4(x, z, y, x);
				}
			}
		}
		public readonly short4 xzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 0));
				}
				else
				{
					return new short4(x, z, y, y);
				}
			}
		}
		public readonly short4 xzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 0));
				}
				else
				{
					return new short4(x, z, y, z);
				}
			}
		}
		public			short4 xzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 0));
				}
				else
				{
					return new short4(x, z, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xzyw;
			}
		}
		public readonly short4 xzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 0));
				}
				else
				{
					return new short4(x, z, z, x);
				}
			}
		}
		public readonly short4 xzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 0));
				}
				else
				{
					return new short4(x, z, z, y);
				}
			}
		}
		public readonly short4 xzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 0));
				}
				else
				{
					return new short4(x, z, z, z);
				}
			}
		}
		public readonly short4 xzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 0));
				}
				else
				{
					return new short4(x, z, z, w);
				}
			}
		}
		public readonly short4 xzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 2, 0)); ;
				}
				else
				{
					return new short4(x, z, w, x);
				}
			}
		}
		public			short4 xzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 2, 0));
				}
				else
				{
					return new short4(x, z, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xwyz;
			}
		}
		public readonly short4 xzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 2, 0));
				}
				else
				{
					return new short4(x, z, w, z);
				}
			}
		}
		public readonly short4 xzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 0));
				}
				else
				{
					return new short4(x, z, w, w);
				}
			}
		}
		public readonly short4 xwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 0));
				}
				else
				{
					return new short4(x, w, x, x);
				}
			}
		}
		public readonly short4 xwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 3, 0));
				}
				else
				{
					return new short4(x, w, x, y);
				}
			}
		}
		public readonly short4 xwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 3, 0));
				}
				else
				{
					return new short4(x, w, x, z);
				}
			}
		}
		public readonly short4 xwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 0));
				}
				else
				{
					return new short4(x, w, x, w);
				}
			}
		}
		public readonly short4 xwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 3, 0));
				}
				else
				{
					return new short4(x, w, y, x);
				}
			}
		}
		public readonly short4 xwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 3, 0));
				}
				else
				{
					return new short4(x, w, y, y);
				}
			}
		}
		public			short4 xwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 3, 0));
				}
				else
				{
					return new short4(x, w, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xzwy;
			}
		}
		public readonly short4 xwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 0));
				}
				else
				{
					return new short4(x, w, y, w);
				}
			}
		}
		public readonly short4 xwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 3, 0));
				}
				else
				{
					return new short4(x, w, z, x);
				}
			}
		}
		public			short4 xwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 3, 0));
				}
				else
				{
					return new short4(x, w, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xwzy;
			}
		}
		public readonly short4 xwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 3, 0));
				}
				else
				{
					return new short4(x, w, z, z);
				}
			}
		}
		public readonly short4 xwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 0));
				}
				else
				{
					return new short4(x, w, z, w);
				}
			}
		}
		public readonly short4 xwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 3, 0));
				}
				else
				{
					return new short4(x, w, w, x);
				}
			}
		}
		public readonly short4 xwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 3, 0));
				}
				else
				{
					return new short4(x, w, w, y);
				}
			}
		}
		public readonly short4 xwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 3, 0));
				}
				else
				{
					return new short4(x, w, w, z);
				}
			}
		}
		public readonly short4 xwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 0));
				}
				else
				{
					return new short4(x, w, w, w);
				}
			}
		}
		public readonly short4 yxxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 1));
				}
				else
				{
					return new short4(y, x, x, x);
				}
			}
		}
        public readonly short4 yxxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 1));
				}
				else
				{
					return new short4(y, x, x, y);
				}
			}
		}
        public readonly short4 yxxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 1));
				}
				else
				{
					return new short4(y, x, x, z);
				}
			}
		}
        public readonly short4 yxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 1));
				}
				else
				{
					return new short4(y, x, x, w);
				}
			}
		}
        public readonly short4 yxyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 1));
				}
				else
				{
					return new short4(y, x, y, x);
				}
			}
		}
        public readonly short4 yxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 1));
				}
				else
				{
					return new short4(y, x, y, y);
				}
			}
		}
        public readonly short4 yxyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 1));
				}
				else
				{
					return new short4(y, x, y, z);
				}
			}
		}
        public readonly short4 yxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 1));
				}
				else
				{
					return new short4(y, x, y, w);
				}
			}
		}
        public readonly short4 yxzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 1));
				}
				else
				{
					return new short4(y, x, z, x);
				}
			}
		}
        public readonly short4 yxzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 1));
				}
				else
				{
					return new short4(y, x, z, y);
				}
			}
		}
        public readonly short4 yxzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 1));
				}
				else
				{
					return new short4(y, x, z, z);
				}
			}
		}
        public			short4 yxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 1));
				}
				else
				{
					return new short4(y, x, z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yxzw;
			}
		}
        public readonly short4 yxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 0, 1));
				}
				else
				{
					return new short4(y, x, w, x);
				}
			}
		}
        public readonly short4 yxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 0, 1));
				}
				else
				{
					return new short4(y, x, w, y);
				}
			}
		}
        public			short4 yxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 0, 1));
				}
				else
				{
					return new short4(y, x, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yxwz;
			}
		}
        public readonly short4 yxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1));
				}
				else
				{
					return new short4(y, x, w, w);
				}
			}
		}
        public readonly short4 yyxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 1));
				}
				else
				{
					return new short4(y, y, x, x);
				}
			}
		}
        public readonly short4 yyxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 1));
				}
				else
				{
					return new short4(y, y, x, y);
				}
			}
		}
        public readonly short4 yyxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 1));
				}
				else
				{
					return new short4(y, y, x, z);
				}
			}
		}
        public readonly short4 yyxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 1));
				}
				else
				{
					return new short4(y, y, x, w);
				}
			}
		}
        public readonly short4 yyyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 1));
				}
				else
				{
					return new short4(y, y, y, x);
				}
			}
		}
        public readonly short4 yyyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 1));
				}
				else
				{
					return new short4(y, y, y, y);
				}
			}
		}
        public readonly short4 yyyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 1));
				}
				else
				{
					return new short4(y, y, y, z);
				}
			}
		}
        public readonly short4 yyyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 1));
				}
				else
				{
					return new short4(y, y, y, w);
				}
			}
		}
        public readonly short4 yyzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 1));
				}
				else
				{
					return new short4(y, y, z, x);
				}
			}
		}
        public readonly short4 yyzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 1));
				}
				else
				{
					return new short4(y, y, z, y);
				}
			}
		}
        public readonly short4 yyzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 1));
				}
				else
				{
					return new short4(y, y, z, z);
				}
			}
		}
        public readonly short4 yyzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 1));
				}
				else
				{
					return new short4(y, y, z, w);
				}
			}
		}
        public readonly short4 yywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 1, 1));
				}
				else
				{
					return new short4(y, y, w, x);
				}
			}
		}
        public readonly short4 yywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 1, 1));
				}
				else
				{
					return new short4(y, y, w, y);
				}
			}
		}
        public readonly short4 yywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 1, 1));
				}
				else
				{
					return new short4(y, y, w, z);
				}
			}
		}
        public readonly short4 yyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1));
				}
				else
				{
					return new short4(y, y, w, w);
				}
			}
		}
        public readonly short4 yzxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 1));
				}
				else
				{
					return new short4(y, z, x, x);
				}
			}
		}
        public readonly short4 yzxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 1));
				}
				else
				{
					return new short4(y, z, x, y);
				}
			}
		}
        public readonly short4 yzxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 1));
				}
				else
				{
					return new short4(y, z, x, z);
				}
			}
		}
        public			short4 yzxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 1));
				}
				else
				{
					return new short4(y, z, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zxyw;
			}
		}
        public readonly short4 yzyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 1));
				}
				else
				{
					return new short4(y, z, y, x);
				}
			}
		}
        public readonly short4 yzyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 1));
				}
				else
				{
					return new short4(y, z, y, y);
				}
			}
		}
        public readonly short4 yzyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 1));
				}
				else
				{
					return new short4(y, z, y, z);
				}
			}
		}
        public readonly short4 yzyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 1));
				}
				else
				{
					return new short4(y, z, y, w);
				}
			}
		}
        public readonly short4 yzzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 1));
				}
				else
				{
					return new short4(y, z, z, x);
				}
			}
		}
        public readonly short4 yzzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 1));
				}
				else
				{
					return new short4(y, z, z, y);
				}
			}
		}
        public readonly short4 yzzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 1));
				}
				else
				{
					return new short4(y, z, z, z);
				}
			}
		}
        public readonly short4 yzzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 1));
				}
				else
				{
					return new short4(y, z, z, w);
				}
			}
		}
        public			short4 yzwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 2, 1)); ;
				}
				else
				{
					return new short4(y, z, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wxyz;
			}
		}
        public readonly short4 yzwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 2, 1));
				}
				else
				{
					return new short4(y, z, w, y);
				}
			}
		}
        public readonly short4 yzwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 2, 1));
				}
				else
				{
					return new short4(y, z, w, z);
				}
			}
		}
        public readonly short4 yzww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 1));
				}
				else
				{
					return new short4(y, z, w, w);
				}
			}
		}
        public readonly short4 ywxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 1));
				}
				else
				{
					return new short4(y, w, x, x);
				}
			}
		}
        public readonly short4 ywxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 3, 1));
				}
				else
				{
					return new short4(y, w, x, y);
				}
			}
		}
        public			short4 ywxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 3, 1));
				}
				else
				{
					return new short4(y, w, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zxwy;
			}
		}
        public readonly short4 ywxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 1));
				}
				else
				{
					return new short4(y, w, x, w);
				}
			}
		}
        public readonly short4 ywyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 3, 1));
				}
				else
				{
					return new short4(y, w, y, x);
				}
			}
		}
        public readonly short4 ywyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 3, 1));
				}
				else
				{
					return new short4(y, w, y, y);
				}
			}
		}
        public readonly short4 ywyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 3, 1));
				}
				else
				{
					return new short4(y, w, y, z);
				}
			}
		}
        public readonly short4 ywyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 1));
				}
				else
				{
					return new short4(y, w, y, w);
				}
			}
		}
        public			short4 ywzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 3, 1));
				}
				else
				{
					return new short4(y, w, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wxzy;
			}
		}
        public readonly short4 ywzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 3, 1));
				}
				else
				{
					return new short4(y, w, z, y);
				}
			}
		}
        public readonly short4 ywzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 3, 1));
				}
				else
				{
					return new short4(y, w, z, z);
				}
			}
		}
        public readonly short4 ywzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 1));
				}
				else
				{
					return new short4(y, w, z, w);
				}
			}
		}
        public readonly short4 ywwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 3, 1));
				}
				else
				{
					return new short4(y, w, w, x);
				}
			}
		}
        public readonly short4 ywwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 3, 1));
				}
				else
				{
					return new short4(y, w, w, y);
				}
			}
		}
        public readonly short4 ywwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 3, 1));
				}
				else
				{
					return new short4(y, w, w, z);
				}
			}
		}
        public readonly short4 ywww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 1));
				}
				else
				{
					return new short4(y, w, w, w);
				}
			}
		}
        public readonly short4 zxxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 2));
				}
				else
				{
					return new short4(z, x, x, x);
				}
			}
		}
        public readonly short4 zxxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 2));
				}
				else
				{
					return new short4(z, x, x, y);
				}
			}
		}
        public readonly short4 zxxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 2));
				}
				else
				{
					return new short4(z, x, x, z);
				}
			}
		}
        public readonly short4 zxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 2));
				}
				else
				{
					return new short4(z, x, x, w);
				}
			}
		}
        public readonly short4 zxyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 2));
				}
				else
				{
					return new short4(z, x, y, x);
				}
			}
		}
        public readonly short4 zxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 2));
				}
				else
				{
					return new short4(z, x, y, y);
				}
			}
		}
		public readonly short4 zxyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 2));
				}
				else
				{
					return new short4(z, x, y, z);
				}
			}
		}
        public			short4 zxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 2));
				}
				else
				{
					return new short4(z, x, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yzxw;
			}
		}
        public readonly short4 zxzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 2));
				}
				else
				{
					return new short4(z, x, z, x);
				}
			}
		}
        public readonly short4 zxzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 2));
				}
				else
				{
					return new short4(z, x, z, y);
				}
			}
		}
        public readonly short4 zxzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 2));
				}
				else
				{
					return new short4(z, x, z, z);
				}
			}
		}
        public readonly short4 zxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 2));
				}
				else
				{
					return new short4(z, x, z, w);
				}
			}
		}
        public readonly short4 zxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 0, 2));
				}
				else
				{
					return new short4(z, x, w, x);
				}
			}
		}
        public			short4 zxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 0, 2));
				}
				else
				{
					return new short4(z, x, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.ywxz;
			}
		}
        public readonly short4 zxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 0, 2));
				}
				else
				{
					return new short4(z, x, w, z);
				}
			}
		}
        public readonly short4 zxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 2));
				}
				else
				{
					return new short4(z, x, w, w);
				}
			}
		}
        public readonly short4 zyxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 2));
				}
				else
				{
					return new short4(z, y, x, x);
				}
			}
		}
        public readonly short4 zyxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 2));
				}
				else
				{
					return new short4(z, y, x, y);
				}
			}
		}
        public readonly short4 zyxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 2));
				}
				else
				{
					return new short4(z, y, x, z);
				}
			}
		}
        public			short4 zyxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 2));
				}
				else
				{
					return new short4(z, y, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zyxw;
			}
		}
        public readonly short4 zyyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 2));
				}
				else
				{
					return new short4(z, y, y, x);
				}
			}
		}
        public readonly short4 zyyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 2));
				}
				else
				{
					return new short4(z, y, y, y);
				}
			}
		}
        public readonly short4 zyyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 2));
				}
				else
				{
					return new short4(z, y, y, z);
				}
			}
		}
        public readonly short4 zyyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 2));
				}
				else
				{
					return new short4(z, y, y, w);
				}
			}
		}
        public readonly short4 zyzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 2));
				}
				else
				{
					return new short4(z, y, z, x);
				}
			}
		}
        public readonly short4 zyzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 2));
				}
				else
				{
					return new short4(z, y, z, y);
				}
			}
		}
        public readonly short4 zyzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 2));
				}
				else
				{
					return new short4(z, y, z, z);
				}
			}
		}
        public readonly short4 zyzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 2));
				}
				else
				{
					return new short4(z, y, z, w);
				}
			}
		}
        public			short4 zywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 1, 2));
				}
				else
				{
					return new short4(z, y, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wyxz;
			}
		}
        public readonly short4 zywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 1, 2));
				}
				else
				{
					return new short4(z, y, w, y);
				}
			}
		}
        public readonly short4 zywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 1, 2));
				}
				else
				{
					return new short4(z, y, w, z);
				}
			}
		}
        public readonly short4 zyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 2));
				}
				else
				{
					return new short4(z, y, w, w);
				}
			}
		}
        public readonly short4 zzxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 2));
				}
				else
				{
					return new short4(z, z, x, x);
				}
			}
		}
        public readonly short4 zzxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 2));
				}
				else
				{
					return new short4(z, z, x, y);
				}
			}
		}
        public readonly short4 zzxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 2));
				}
				else
				{
					return new short4(z, z, x, z);
				}
			}
		}
        public readonly short4 zzxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 2));
				}
				else
				{
					return new short4(z, z, x, w);
				}
			}
		}
        public readonly short4 zzyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 2));
				}
				else
				{
					return new short4(z, z, y, x);
				}
			}
		}
        public readonly short4 zzyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 2));
				}
				else
				{
					return new short4(z, z, y, y);
				}
			}
		}
        public readonly short4 zzyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 2));
				}
				else
				{
					return new short4(z, z, y, z);
				}
			}
		}
        public readonly short4 zzyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 2));
				}
				else
				{
					return new short4(z, z, y, w);
				}
			}
		}
        public readonly short4 zzzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 2));
				}
				else
				{
					return new short4(z, z, z, x);
				}
			}
		}
        public readonly short4 zzzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 2));
				}
				else
				{
					return new short4(z, z, z, y);
				}
			}
		}
        public readonly short4 zzzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 2));
				}
				else
				{
					return new short4(z, z, z, z);
				}
			}
		}
        public readonly short4 zzzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 2));
				}
				else
				{
					return new short4(z, z, z, w);
				}
			}
		}
        public readonly short4 zzwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 2, 2)); ;
				}
				else
				{
					return new short4(z, z, w, x);
				}
			}
		}
        public readonly short4 zzwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 2, 2));
				}
				else
				{
					return new short4(z, z, w, y);
				}
			}
		}
        public readonly short4 zzwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 2, 2));
				}
				else
				{
					return new short4(z, z, w, z);
				}
			}
		}
        public readonly short4 zzww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 2));
				}
				else
				{
					return new short4(z, z, w, w);
				}
			}
		}
        public readonly short4 zwxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 2));
				}
				else
				{
					return new short4(z, w, x, x);
				}
			}
		}
        public			short4 zwxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 3, 2));
				}
				else
				{
					return new short4(z, w, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zwxy;
			}
		}
        public readonly short4 zwxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 3, 2));
				}
				else
				{
					return new short4(z, w, x, z);
				}
			}
		}
        public readonly short4 zwxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 2));
				}
				else
				{
					return new short4(z, w, x, w);
				}
			}
		}
        public			short4 zwyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 3, 2));
				}
				else
				{
					return new short4(z, w, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wzxy;
			}
		}
        public readonly short4 zwyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 3, 2));
				}
				else
				{
					return new short4(z, w, y, y);
				}
			}
		}
        public readonly short4 zwyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 3, 2));
				}
				else
				{
					return new short4(z, w, y, z);
				}
			}
		}
        public readonly short4 zwyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 2));
				}
				else
				{
					return new short4(z, w, y, w);
				}
			}
		}
        public readonly short4 zwzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 3, 2));
				}
				else
				{
					return new short4(z, w, z, x);
				}
			}
		}
        public readonly short4 zwzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 3, 2));
				}
				else
				{
					return new short4(z, w, z, y);
				}
			}
		}
        public readonly short4 zwzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 3, 2));
				}
				else
				{
					return new short4(z, w, z, z);
				}
			}
		}
        public readonly short4 zwzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 2));
				}
				else
				{
					return new short4(z, w, z, w);
				}
			}
		}
        public readonly short4 zwwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 3, 2));
				}
				else
				{
					return new short4(z, w, w, x);
				}
			}
		}
        public readonly short4 zwwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 3, 2));
				}
				else
				{
					return new short4(z, w, w, y);
				}
			}
		}
        public readonly short4 zwwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 3, 2));
				}
				else
				{
					return new short4(z, w, w, z);
				}
			}
		}
        public readonly short4 zwww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 2));
				}
				else
				{
					return new short4(z, w, w, w);
				}
			}
		}
        public readonly short4 wxxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 3));
				}
				else
				{
					return new short4(w, x, x, x);
				}
			}
		}
        public readonly short4 wxxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 3));
				}
				else
				{
					return new short4(w, x, x, y);
				}
			}
		}
        public readonly short4 wxxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 3));
				}
				else
				{
					return new short4(w, x, x, z);
				}
			}
		}
        public readonly short4 wxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 3));
				}
				else
				{
					return new short4(w, x, x, w);
				}
			}
		}
        public readonly short4 wxyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 3));
				}
				else
				{
					return new short4(w, x, y, x);
				}
			}
		}
        public readonly short4 wxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 3));
				}
				else
				{
					return new short4(w, x, y, y);
				}
			}
		}
        public          short4 wxyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 3));
				}
				else
				{
					return new short4(w, x, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yzwx;
			}
		}
        public readonly short4 wxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 3));
				}
				else
				{
					return new short4(w, x, y, w);
				}
			}
		}
        public readonly short4 wxzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 3));
				}
				else
				{
					return new short4(w, x, z, x);
				}
			}
		}
        public          short4 wxzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 3));
				}
				else
				{
					return new short4(w, x, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.ywzx;
			}
		}
        public readonly short4 wxzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 3));
				}
				else
				{
					return new short4(w, x, z, z);
				}
			}
		}
        public readonly short4 wxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 3));
				}
				else
				{
					return new short4(w, x, z, w);
				}
			}
		}
        public readonly short4 wxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 0, 3));
				}
				else
				{
					return new short4(w, x, w, x);
				}
			}
		}
        public readonly short4 wxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 0, 3));
				}
				else
				{
					return new short4(w, x, w, y);
				}
			}
		}
        public readonly short4 wxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 0, 3));
				}
				else
				{
					return new short4(w, x, w, z);
				}
			}
		}
        public readonly short4 wxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 3));
				}
				else
				{
					return new short4(w, x, w, w);
				}
			}
		}
        public readonly short4 wyxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 3));
				}
				else
				{
					return new short4(w, y, x, x);
				}
			}
		}
        public readonly short4 wyxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 3));
				}
				else
				{
					return new short4(w, y, x, y);
				}
			}
		}
        public          short4 wyxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 3));
				}
				else
				{
					return new short4(w, y, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zywx;
			}
		}
        public readonly short4 wyxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 3));
				}
				else
				{
					return new short4(w, y, x, w);
				}
			}
		}
        public readonly short4 wyyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 3));
				}
				else
				{
					return new short4(w, y, y, x);
				}
			}
		}
        public readonly short4 wyyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 3));
				}
				else
				{
					return new short4(w, y, y, y);
				}
			}
		}
        public readonly short4 wyyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 3));
				}
				else
				{
					return new short4(w, y, y, z);
				}
			}
		}
        public readonly short4 wyyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 3));
				}
				else
				{
					return new short4(w, y, y, w);
				}
			}
		}
        public          short4 wyzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 3));
				}
				else
				{
					return new short4(w, y, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wyzx;
			}
		}
        public readonly short4 wyzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 3));
				}
				else
				{
					return new short4(w, y, z, y);
				}
			}
		}
        public readonly short4 wyzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 3));
				}
				else
				{
					return new short4(w, y, z, z);
				}
			}
		}
        public readonly short4 wyzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 3));
				}
				else
				{
					return new short4(w, y, z, w);
				}
			}
		}
        public readonly short4 wywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 1, 3));
				}
				else
				{
					return new short4(w, y, w, x);
				}
			}
		}
        public readonly short4 wywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 1, 3));
				}
				else
				{
					return new short4(w, y, w, y);
				}
			}
		}
        public readonly short4 wywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 1, 3));
				}
				else
				{
					return new short4(w, y, w, z);
				}
			}
		}
        public readonly short4 wyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 3));
				}
				else
				{
					return new short4(w, y, w, w);
				}
			}
		}
        public readonly short4 wzxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 3));
				}
				else
				{
					return new short4(w, z, x, x);
				}
			}
		}
        public          short4 wzxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 3));
				}
				else
				{
					return new short4(w, z, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zwyx;
			}
		}
        public readonly short4 wzxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 3));
				}
				else
				{
					return new short4(w, z, x, z);
				}
			}
		}
        public readonly short4 wzxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 3));
				}
				else
				{
					return new short4(w, z, x, w);
				}
			}
		}
        public          short4 wzyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 3));
				}
				else
				{
					return new short4(w, z, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wzyx;
			}
		}
        public readonly short4 wzyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 3));
				}
				else
				{
					return new short4(w, z, y, y);
				}
			}
		}
        public readonly short4 wzyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 3));
				}
				else
				{
					return new short4(w, z, y, z);
				}
			}
		}
        public readonly short4 wzyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 3));
				}
				else
				{
					return new short4(w, z, y, w);
				}
			}
		}
        public readonly short4 wzzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 3));
				}
				else
				{
					return new short4(w, z, z, x);
				}
			}
		}
        public readonly short4 wzzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 3));
				}
				else
				{
					return new short4(w, z, z, y);
				}
			}
		}
        public readonly short4 wzzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 3));
				}
				else
				{
					return new short4(w, z, z, z);
				}
			}
		}
        public readonly short4 wzzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 3));
				}
				else
				{
					return new short4(w, z, z, w);
				}
			}
		}
        public readonly short4 wzwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 2, 3)); ;
				}
				else
				{
					return new short4(w, z, w, x);
				}
			}
		}
        public readonly short4 wzwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 2, 3));
				}
				else
				{
					return new short4(w, z, w, y);
				}
			}
		}
        public readonly short4 wzwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 2, 3));
				}
				else
				{
					return new short4(w, z, w, z);
				}
			}
		}
        public readonly short4 wzww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 3));
				}
				else
				{
					return new short4(w, z, w, w);
				}
			}
		}
        public readonly short4 wwxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 3));
				}
				else
				{
					return new short4(w, w, x, x);
				}
			}
		}
        public readonly short4 wwxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 3, 3));
				}
				else
				{
					return new short4(w, w, x, y);
				}
			}
		}
        public readonly short4 wwxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 3, 3));
				}
				else
				{
					return new short4(w, w, x, z);
				}
			}
		}
        public readonly short4 wwxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 3));
				}
				else
				{
					return new short4(w, w, x, w);
				}
			}
		}
        public readonly short4 wwyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 3, 3));
				}
				else
				{
					return new short4(w, w, y, x);
				}
			}
		}
        public readonly short4 wwyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 3, 3));
				}
				else
				{
					return new short4(w, w, y, y);
				}
			}
		}
        public readonly short4 wwyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 3, 3));
				}
				else
				{
					return new short4(w, w, y, z);
				}
			}
		}
        public readonly short4 wwyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 3));
				}
				else
				{
					return new short4(w, w, y, w);
				}
			}
		}
        public readonly short4 wwzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 3, 3));
				}
				else
				{
					return new short4(w, w, z, x);
				}
			}
		}
        public readonly short4 wwzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 3, 3));
				}
				else
				{
					return new short4(w, w, z, y);
				}
			}
		}
        public readonly short4 wwzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 3, 3));
				}
				else
				{
					return new short4(w, w, z, z);
				}
			}
		}
        public readonly short4 wwzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 3));
				}
				else
				{
					return new short4(w, w, z, w);
				}
			}
		}
        public readonly short4 wwwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 3, 3));
				}
				else
				{
					return new short4(w, w, w, x);
				}
			}
		}
        public readonly short4 wwwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 3, 3));
				}
				else
				{
					return new short4(w, w, w, y);
				}
			}
		}
        public readonly short4 wwwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 3, 3));
				}
				else
				{
					return new short4(w, w, w, z);
				}
			}
		}
        public readonly short4 wwww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 3));
				}
				else
				{
					return new short4(w, w, w, w);
				}
			}
		}

        public readonly short3 xxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 0));
				}
				else
				{
					return new short3(x, x, x);
				}
			}
		}
        public readonly short3 xxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 0));
				}
				else
				{
					return new short3(x, x, y);
				}
			}
		}
        public readonly short3 xxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 0));
				}
				else
				{
					return new short3(x, x, z);
				}
			}
		}
        public readonly short3 xxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 0));
				}
				else
				{
					return new short3(x, x, w);
				}
			}
		}
        public readonly short3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 0));
				}
				else
				{
					return new short3(x, y, x);
				}
			}
		}
        public readonly short3 xyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 0));
				}
				else
				{
					return new short3(x, y, y);
				}
			}
		}
        public          short3 xyz
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return (v128)this;
				}
				else
				{
					return new short3(x, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value, 0b0111);
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
					this.z = value.z;
				}
			}
		}
        public          short3 xyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 0));
				}
				else
				{
					return new short3(x, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.xyzz, 0b1011);
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
					this.w = value.z;
				}
			}
		}
        public readonly short3 xzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 0));
				}
				else
				{
					return new short3(x, z, x);
				}
			}
		}
        public          short3 xzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 0));
				}
				else
				{
					return new short3(x, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.xzyy, 0b0111);
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
					this.y = value.z;
				}
			}
		}
        public readonly short3 xzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 0));
				}
				else
				{
					return new short3(x, z, z);
				}
			}
		}
        public          short3 xzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 0));
				}
				else
				{
					return new short3(x, z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.xxyz, 0b1101);
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
					this.w = value.z;
				}
			}
		}
        public readonly short3 xwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 0));
				}
				else
				{
					return new short3(x, w, x);
				}
			}
		}
        public          short3 xwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 0));
				}
				else
				{
					return new short3(x, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.xzzy, 0b1011);
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
					this.y = value.z;
				}
			}
		}
        public          short3 xwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 0));
				}
				else
				{
					return new short3(x, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.xxzy, 0b1101);
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
					this.z = value.z;
				}
			}
		}
        public readonly short3 xww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 0));
				}
				else
				{
					return new short3(x, w, w);
				}
			}
		}
        public readonly short3 yxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 1));
				}
				else
				{
					return new short3(y, x, x);
				}
			}
		}
        public readonly short3 yxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 1));
				}
				else
				{
					return new short3(y, x, y);
				}
			}
		}
        public          short3 yxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 1));
				}
				else
				{
					return new short3(y, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.yxzz, 0b0111);
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
					this.z = value.z;
				}
			}
		}
        public          short3 yxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1));
				}
				else
				{
					return new short3(y, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.yxzz, 0b1011);
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
					this.w = value.z;
				}
			}
		}
        public readonly short3 yyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 1));
				}
				else
				{
					return new short3(y, y, x);
				}
			}
		}
        public readonly short3 yyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 1));
				}
				else
				{
					return new short3(y, y, y);
				}
			}
		}
        public readonly short3 yyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 1));
				}
				else
				{
					return new short3(y, y, z);
				}
			}
		}
        public readonly short3 yyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1));
				}
				else
				{
					return new short3(y, y, w);
				}
			}
		}
        public          short3 yzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 1));
				}
				else
				{
					return new short3(y, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.zxyy, 0b0111);
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
					this.x = value.z;
				}
			}
		}
        public readonly short3 yzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 1));
				}
				else
				{
					return new short3(y, z, y);
				}
			}
		}
        public readonly short3 yzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 1));
				}
				else
				{
					return new short3(y, z, z);
				}
			}
		}
        public          short3 yzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 1));
				}
				else
				{
					return new short3(y, z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.xxyz, 0b1110);
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
					this.w = value.z;
				}
			}
		}
        public          short3 ywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 1));
				}
				else
				{
					return new short3(y, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.zxxy, 0b1011);
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
					this.x = value.z;
				}
			}
		}
        public readonly short3 ywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 1));
				}
				else
				{
					return new short3(y, w, y);
				}
			}
		}
        public          short3 ywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 1));
				}
				else
				{
					return new short3(y, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.xxzy, 0b1110);
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
					this.z = value.z;
				}
			}
		}
        public readonly short3 yww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 1));
				}
				else
				{
					return new short3(y, w, w);
				}
			}
		}
        public readonly short3 zxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 2));
				}
				else
				{
					return new short3(z, x, x);
				}
			}
		}
        public          short3 zxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 2));
				}
				else
				{
					return new short3(z, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.yzxx, 0b0111);
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
					this.y = value.z;
				}
			}
		}
        public readonly short3 zxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 2));
				}
				else
				{
					return new short3(z, x, z);
				}
			}
		}
        public          short3 zxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 2));
				}
				else
				{
					return new short3(z, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.yyxz, 0b1101);
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
					this.w = value.z;
				}
			}
		}
        public          short3 zyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 2));
				}
				else
				{
					return new short3(z, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.zyxx, 0b0111);
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
					this.x = value.z;
				}
			}
		}
        public readonly short3 zyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 2));
				}
				else
				{
					return new short3(z, y, y);
				}
			}
		}
        public readonly short3 zyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 2));
				}
				else
				{
					return new short3(z, y, z);
				}
			}
		}
        public          short3 zyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 2));
				}
				else
				{
					return new short3(z, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.yyxz, 0b1110);
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
					this.w = value.z;
				}
			}
		}
        public readonly short3 zzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 2));
				}
				else
				{
					return new short3(z, z, x);
				}
			}
		}
        public readonly short3 zzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 2));
				}
				else
				{
					return new short3(z, z, y);
				}
			}
		}
        public readonly short3 zzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 2));
				}
				else
				{
					return new short3(z, z, z);
				}
			}
		}
        public readonly short3 zzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 2));
				}
				else
				{
					return new short3(z, z, w);
				}
			}
		}
        public          short3 zwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 2));
				}
				else
				{
					return new short3(z, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.zzxy, 0b1101);
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
					this.x = value.z;
				}
			}
		}
        public          short3 zwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 2));
				}
				else
				{
					return new short3(z, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.zzxy, 0b1110);
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
					this.y = value.z;
				}
			}
		}
        public readonly short3 zwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 2));
				}
				else
				{
					return new short3(z, w, z);
				}
			}
		}
        public readonly short3 zww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 2));
				}
				else
				{
					return new short3(z, w, w);
				}
			}
		}
        public readonly short3 wxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 3));
				}
				else
				{
					return new short3(w, x, x);
				}
			}
		}
        public          short3 wxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 3));
				}
				else
				{
					return new short3(w, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.yzzx, 0b1011);
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
					this.y = value.z;
				}
			}
		}
        public          short3 wxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 3));
				}
				else
				{
					return new short3(w, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.yyzx, 0b1101);
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
					this.z = value.z;
				}
			}
		}
        public readonly short3 wxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 3));
				}
				else
				{
					return new short3(w, x, w);
				}
			}
		}
        public          short3 wyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 3));
				}
				else
				{
					return new short3(w, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.zyyx, 0b1011);
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
					this.x = value.z;
				}
			}
		}
        public readonly short3 wyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 3));
				}
				else
				{
					return new short3(w, y, y);
				}
			}
        }
        public          short3 wyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 3));
				}
				else
				{
					return new short3(w, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.yyzx, 0b1110);
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
					this.z = value.z;
				}
			}
        }
        public readonly short3 wyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 3));
				}
				else
				{
					return new short3(w, y, w);
				}
			}
        }
        public          short3 wzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 3));
				}
				else
				{
					return new short3(w, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.zzyx, 0b1101);
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
					this.x = value.z;
				}
			}
        }
        public          short3 wzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 3));
				}
				else
				{
					return new short3(w, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.zzyx, 0b1110);
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
					this.y = value.z;
				}
			}
        }
        public readonly short3 wzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 3));
				}
				else
				{
					return new short3(w, z, z);
				}
			}
        }
        public readonly short3 wzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 3));
				}
				else
				{
					return new short3(w, z, w);
				}
			}
        }
        public readonly short3 wwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 3));
				}
				else
				{
					return new short3(w, w, x);
				}
			}
        }
        public readonly short3 wwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 3));
				}
				else
				{
					return new short3(w, w, y);
				}
			}
        }
        public readonly short3 wwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 3));
				}
				else
				{
					return new short3(w, w, z);
				}
			}
        }
        public readonly short3 www
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 3));
				}
				else
				{
					return new short3(w, w, w);
				}
			}
        }

        public readonly short2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 0));
				}
				else
				{
					return new short2(x, x);
				}
			}
		}
        public          short2 xy
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return (v128)this;
				}
				else
				{
					return new short2(x, y);
				}
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value, 0b0011);
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
				}
			}
        }
        public          short2 xz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 0));
				}
				else
				{
					return new short2(x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.xxyy, 0b0101);
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
				}
			}
        }
        public          short2 xw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 0));
				}
				else
				{
					return new short2(x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.xxyy, 0b1001);
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
				}
			}
        }
        public          short2 yx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1));
				}
				else
				{
					return new short2(y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.yx, 0b0011);
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
				}
			}
        }
        public readonly short2 yy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1));
				}
				else
				{
					return new short2(y, y);
				}
			}
        }
        public          short2 yz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.bsrli_si128(this, sizeof(short));
				}
				else
				{
					return new short2(y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.xxyy, 0b0110);
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
				}
			}
        }
        public          short2 yw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 1));
				}
				else
				{
					return new short2(y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.xxyy, 0b1010);
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
				}
			}
        }
        public          short2 zx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 2));
				}
				else
				{
					return new short2(z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.yyxx, 0b0101);
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
				}
			}
        }
        public          short2 zy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 2));
				}
				else
				{
					return new short2(z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.yyxx, 0b0110);
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
				}
			}
        }
        public readonly short2 zz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 2));
				}
				else
				{
					return new short2(z, z);
				}
			}
        }
        public          short2 zw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.bsrli_si128(this, 2 * sizeof(short));
				}
				else
				{
					return new short2(z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Sse2.unpacklo_epi32(this, value);
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
				}
			}
        }
        public          short2 wx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 3));
				}
				else
				{
					return new short2(w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.yyxx, 0b1001);
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
				}
			}
        }
        public          short2 wy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 3));
				}
				else
				{
					return new short2(w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.yyxx, 0b1010);
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
				}
			}
        }
        public          short2 wz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 3));
				}
				else
				{
					return new short2(w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.yxyx, 0b1100);
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
				}
			}
        }
        public readonly short2 ww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 3));
				}
				else
                {
					return new short2(w, w);
                }
			}
        }
        #endregion
		

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(short4 input) => RegisterConversion.ToV128(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4(v128 input) => RegisterConversion.ToType<short4>(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4(short input) => new short4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(ushort4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(short4*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(int4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi32_epi16(RegisterConversion.ToV128(input), 4);
			}
			else
            {
                return new short4((short)input.x, (short)input.y, (short)input.z, (short)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(uint4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi32_epi16(RegisterConversion.ToV128(input), 4);
			}
			else
            {
                return new short4((short)input.x, (short)input.y, (short)input.z, (short)input.w);
            }
        }
		 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(long4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_epi16(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new short4(Xse.cvtepi64_epi16(input._xy), Xse.cvtepi64_epi16(input._zw));
            }
            else
            {
                return new short4((short)input.x, (short)input.y, (short)input.z, (short)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(ulong4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_epi16(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new short4(Xse.cvtepi64_epi16(input._xy), Xse.cvtepi64_epi16(input._zw));
            }
            else
            {
                return new short4((short)input.x, (short)input.y, (short)input.z, (short)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(half4 input) => (short4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(float4 input) => (short4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(double4 input) => (short4)(int4)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4(short4 input)
        {
			if (Sse2.IsSse2Supported)
			{
				return RegisterConversion.ToType<int4>(Xse.cvtepi16_epi32(input));
            }
            else
            {
                return new int4((int)input.x, (int)input.y, (int)input.z, (int)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(short4 input)
        {
			if (Sse2.IsSse2Supported)
			{
				return RegisterConversion.ToType<uint4>(Xse.cvtepi16_epi32(input));
            }
            else
            {
                return new uint4((uint)input.x, (uint)input.y, (uint)input.z, (uint)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(short4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi16_epi64(input);
            }
            else if (Sse2.IsSse2Supported)
			{
                return new long4((long2)input.xy, (long2)input.zw);
            }
            else
            {
                return new long4((long)input.x, (long)input.y, (long)input.z, (long)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(short4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi16_epi64(input);
            }
            else if (Sse2.IsSse2Supported)
			{
                return new ulong4((ulong2)input.xy, (ulong2)input.zw);
            }
            else
            {
                return new ulong4((ulong)input.x, (ulong)input.y, (ulong)input.z, (ulong)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half4(short4 input) => (half4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(short4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<float4>(Xse.cvtepi16_ps(input));
            }
            else
            {
                return (float4)(int4)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(short4 input) => (double4)(int4)input;


        public short this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 4);

                return asArray[index];
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 4);

                asArray[index] = value;
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator + (short4 left, short4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi16(left, right);
            }
            else
            {
                return new short4((short)(left.x + right.x), (short)(left.y + right.y), (short)(left.z + right.z), (short)(left.w + right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator - (short4 left, short4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(left, right);
            }
            else
            {
                return new short4((short)(left.x - right.x), (short)(left.y - right.y), (short)(left.z - right.z), (short)(left.w - right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator * (short4 left, short4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.mullo_epi16(left, right);
            }
            else
            {
                return new short4((short)(left.x * right.x), (short)(left.y * right.y), (short)(left.z * right.z), (short)(left.w * right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator / (short4 left, short4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.div_epi16(left, right, false, 4);
            }
            else
            {
                return new short4((short)(left.x / right.x), (short)(left.y / right.y), (short)(left.z / right.z), (short)(left.w / right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator % (short4 left, short4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rem_epi16(left, right, 4);
            }
            else
            {
                return new short4((short)(left.x % right.x), (short)(left.y % right.y), (short)(left.z % right.z), (short)(left.w % right.w));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator * (short left, short4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator * (short4 left, short right)
        {
			if (Sse2.IsSse2Supported)
			{
				if (Constant.IsConstantExpression(right))
				{
					return (v128)((short8)((v128)left) * right);
				}
			}

			return left * (short4)right;
		}
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator / (short4 left, short right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.div_epi16(left, right, 4);
                }
            }
                
            return left / (short4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator % (short4 left, short right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.rem_epi16(left, right, 2);
                }
            }
                
            return left % (short4)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator & (short4 left, short4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new short4((short)(left.x & right.x), (short)(left.y & right.y), (short)(left.z & right.z), (short)(left.w & right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator | (short4 left, short4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new short4((short)(left.x | right.x), (short)(left.y | right.y), (short)(left.z | right.z), (short)(left.w | right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator ^ (short4 left, short4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new short4((short)(left.x ^ right.x), (short)(left.y ^ right.y), (short)(left.z ^ right.z), (short)(left.w ^ right.w));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator - (short4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return new short4((short)-x.x, (short)-x.y, (short)-x.z, (short)-x.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator ++ (short4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.inc_epi16(x);
			}
            else
            {
                return new short4((short)(x.x + 1), (short)(x.y + 1), (short)(x.z + 1), (short)(x.w + 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator -- (short4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.dec_epi16(x);
			}
            else
            {
                return new short4((short)(x.x - 1), (short)(x.y - 1), (short)(x.z - 1), (short)(x.w - 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator ~ (short4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.not_si128(x);
			}
            else
            {
                return new short4((short)(~x.x), (short)(~x.y), (short)(~x.z), (short)(~x.w));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator << (short4 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.slli_epi16(x, n);
            }
            else
            {
                return new short4((short)(x.x << n), (short)(x.y << n), (short)(x.z << n), (short)(x.w << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator >> (short4 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srai_epi16(x, n);
            }
            else
            {
                return new short4((short)(x.x >> n), (short)(x.y >> n), (short)(x.z >> n), (short)(x.w >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (short4 left, short4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue16<bool4>(Sse2.cmpeq_epi16(left, right));
            }
            else
            {
                return new bool4(left.x == right.x, left.y == right.y, left.z == right.z, left.w == right.w);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (short4 left, short4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue16<bool4>(Xse.cmplt_epi16(left, right));
            }
            else
            {
                return new bool4(left.x < right.x, left.y < right.y, left.z < right.z, left.w < right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (short4 left, short4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue16<bool4>(Sse2.cmpgt_epi16(left, right));
            }
            else
            {
                return new bool4(left.x > right.x, left.y > right.y, left.z > right.z, left.w > right.w);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (short4 left, short4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsFalse16<bool4>(Sse2.cmpeq_epi16(left, right));
            }
            else
            {
                return new bool4(left.x != right.x, left.y != right.y, left.z != right.z, left.w != right.w);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (short4 left, short4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsFalse16<bool4>(Sse2.cmpgt_epi16(left, right));
            }
            else
            {
                return new bool4(left.x <= right.x, left.y <= right.y, left.z <= right.z, left.w <= right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (short4 left, short4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsFalse16<bool4>(Xse.cmplt_epi16(left, right));
			}
            else
            {
                return new bool4(left.x >= right.x, left.y >= right.y, left.z >= right.z, left.w >= right.w);
            }
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool Equals(short4 other)
		{
			if (Sse2.IsSse2Supported)
			{
				return ulong.MaxValue == Sse2.cmpeq_epi16(this, other).ULong0;
			}
			else
			{
				return (this.x == other.x & this.y == other.y) & (this.z == other.z & this.w == other.w);
			}
		}

        public override readonly bool Equals(object obj) => obj is short4 converted && this.Equals(converted);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override readonly int GetHashCode()
		{
			if (Sse2.IsSse2Supported)
			{
				return Hash.v64(this);
			}
			else
			{
				short4 temp = this;

				return (*(ulong*)&temp).GetHashCode();
			}
		}


        public override readonly string ToString() => $"short4({x}, {y}, {z}, {w})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"short4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}