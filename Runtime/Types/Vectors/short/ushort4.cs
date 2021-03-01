using DevTools;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 4 * sizeof(ushort))]  [DebuggerTypeProxy(typeof(ushort4.DebuggerProxy))]
    unsafe public struct ushort4 : IEquatable<ushort4>, IFormattable
	{
		internal sealed class DebuggerProxy
		{
			public ushort x;
			public ushort y;
			public ushort z;
			public ushort w;

			public DebuggerProxy(ushort4 v)
			{
				x = v.x;
				y = v.y;
				z = v.z;
				w = v.w;
			}
		}


		[FieldOffset(0)] private fixed ushort asArray[4];

        // otherhwise LLVM/Burst goes crazy with bitshifts and masks etc. -.-
        [FieldOffset(0)] internal long alias_long;

        [FieldOffset(0)] public ushort x;
        [FieldOffset(2)] public ushort y;
        [FieldOffset(4)] public ushort z;
        [FieldOffset(6)] public ushort w;


        public static ushort4 zero => default;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort x, ushort y, ushort z, ushort w)
        {
            if (Sse2.IsSse2Supported)
			{
				this = Sse2.set_epi16(0, 0, 0, 0, (short)w, (short)z, (short)y, (short)x);
			}
			else
            {
				this = new ushort4
				{
					x = x,
					y = y,
					z = z,
					w = w
				};
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort xyzw)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.set1_epi16((short)xyzw);
			}
			else
			{
				this = new ushort4
				{
					x = xyzw,
					y = xyzw,
					z = xyzw,
					w = xyzw
				};
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort2 xy, ushort z, ushort w)
        {
            if (Sse2.IsSse2Supported)
			{
				this = Sse2.insert_epi16(Sse2.insert_epi16(xy, z, 2), w, 3);
			}
			else
            {
				this = new ushort4
				{
					x = xy.x,
					y = xy.y,
					z = z,
					w = w
				};
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort x, ushort2 yz, ushort w)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.insert_epi16(Sse2.insert_epi16(Sse2.bslli_si128(yz, sizeof(ushort)), x, 0), w, 3);
			}
			else
			{
				this = new ushort4
				{
					x = x,
					y = yz.x,
					z = yz.y,
					w = w
				};
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort x, ushort y, ushort2 zw)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.unpacklo_epi32(new ushort2(x, y), zw);
			}
			else
			{
				this = new ushort4
				{
					x = x,
					y = y,
					z = zw.x,
					w = zw.y,
				};
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort2 xy, ushort2 zw)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.unpacklo_epi32(xy, zw);
			}
			else
			{
				this = new ushort4
				{
					x = xy.x,
					y = xy.y,
					z = zw.x,
					w = zw.y
				};
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort3 xyz, ushort w)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.insert_epi16(xyz, w, 3);
			}
			else
			{
				this = new ushort4
				{
					x = xyz.x,
					y = xyz.y,
					z = xyz.z,
					w = w
				};
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort x, ushort3 yzw)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.insert_epi16(Sse2.bslli_si128(yzw, sizeof(ushort)), x, 0);
			}
			else
			{
				this = new ushort4
				{
					x = x,
					y = yzw.x,
					z = yzw.y,
					w = yzw.z
				};
			}
        }

		
        #region Shuffle
        public  ushort4 xxxx
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
					return new ushort4(x, x, x, x);
				}
			}
		}
		public  ushort4 xxxy
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
					return new ushort4(x, x, x, y);
				}
			}
		}
		public  ushort4 xxxz
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
					return new ushort4(x, x, x, z);
				}
			}
		}
		public  ushort4 xxxw
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
					return new ushort4(x, x, x, w);
				}
			}
		}
		public  ushort4 xxyx
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
					return new ushort4(x, x, y, x);
				}
			}
		}
		public  ushort4 xxyy
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
					return new ushort4(x, x, y, y);
				}
			}
		}
		public  ushort4 xxyz
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
					return new ushort4(x, x, y, z);
				}
			}
		}
		public  ushort4 xxyw
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
					return new ushort4(x, x, y, w);
				}
			}
		}
		public  ushort4 xxzx
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
					return new ushort4(x, x, z, x);
				}
			}
		}
		public  ushort4 xxzy
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
					return new ushort4(x, x, z, y);
				}
			}
		}
		public  ushort4 xxzz
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
					return new ushort4(x, x, z, z);
				}
			}
		}
		public  ushort4 xxzw
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
					return new ushort4(x, x, z, w);
				}
			}
		}
		public  ushort4 xxwx
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
					return new ushort4(x, x, w, x);
				}
			}
		}
		public  ushort4 xxwy
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
					return new ushort4(x, x, w, y);
				}
			}
		}
		public  ushort4 xxwz
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
					return new ushort4(x, x, w, z);
				}
			}
		}
		public  ushort4 xxww
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
					return new ushort4(x, x, w, w);
				}
			}
		}
		public  ushort4 xyxx
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
					return new ushort4(x, y, x, x);
				}
			}
		}
		public  ushort4 xyxy
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
					return new ushort4(x, y, x, y);
				}
			}
		}
		public  ushort4 xyxz
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
					return new ushort4(x, y, x, z);
				}
			}
		}
		public  ushort4 xyxw
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
					return new ushort4(x, y, x, w);
				}
			}
		}
		public  ushort4 xyyx
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
					return new ushort4(x, y, y, x);
				}
			}
		}
		public  ushort4 xyyy
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
					return new ushort4(x, y, y, y);
				}
			}
		}
		public  ushort4 xyyz
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
					return new ushort4(x, y, y, z);
				}
			}
		}
		public  ushort4 xyyw
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
					return new ushort4(x, y, y, w);
				}
			}
		}
		public  ushort4 xyzx
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
					return new ushort4(x, y, z, x);
				}
			}
		}
		public  ushort4 xyzy
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
					return new ushort4(x, y, z, y);
				}
			}
		}
		public  ushort4 xyzz
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
					return new ushort4(x, y, z, z);
				}
			}
		}
		public  ushort4 xywx
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
					return new ushort4(x, y, w, x);
				}
			}
		}
		public  ushort4 xywy
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
					return new ushort4(x, y, w, y);
				}
			}
		}
		public			ushort4 xywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 1, 0));
				}
				else
				{
					return new ushort4(x, y, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xywz;
			}
		}
		public  ushort4 xyww
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
					return new ushort4(x, y, w, w);
				}
			}
		}
		public  ushort4 xzxx
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
					return new ushort4(x, z, x, x);
				}
			}
		}
		public  ushort4 xzxy
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
					return new ushort4(x, z, x, y);
				}
			}
		}
		public  ushort4 xzxz
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
					return new ushort4(x, z, x, z);
				}
			}
		}
		public  ushort4 xzxw
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
					return new ushort4(x, z, x, w);
				}
			}
		}
		public  ushort4 xzyx
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
					return new ushort4(x, z, y, x);
				}
			}
		}
		public  ushort4 xzyy
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
					return new ushort4(x, z, y, y);
				}
			}
		}
		public  ushort4 xzyz
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
					return new ushort4(x, z, y, z);
				}
			}
		}
		public			ushort4 xzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 0));
				}
				else
				{
					return new ushort4(x, z, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xzyw;
			}
		}
		public  ushort4 xzzx
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
					return new ushort4(x, z, z, x);
				}
			}
		}
		public  ushort4 xzzy
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
					return new ushort4(x, z, z, y);
				}
			}
		}
		public  ushort4 xzzz
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
					return new ushort4(x, z, z, z);
				}
			}
		}
		public  ushort4 xzzw
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
					return new ushort4(x, z, z, w);
				}
			}
		}
		public  ushort4 xzwx
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
					return new ushort4(x, z, w, x);
				}
			}
		}
		public			ushort4 xzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 2, 0));
				}
				else
				{
					return new ushort4(x, z, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xwyz;
			}
		}
		public  ushort4 xzwz
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
					return new ushort4(x, z, w, z);
				}
			}
		}
		public  ushort4 xzww
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
					return new ushort4(x, z, w, w);
				}
			}
		}
		public  ushort4 xwxx
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
					return new ushort4(x, w, x, x);
				}
			}
		}
		public  ushort4 xwxy
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
					return new ushort4(x, w, x, y);
				}
			}
		}
		public  ushort4 xwxz
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
					return new ushort4(x, w, x, z);
				}
			}
		}
		public  ushort4 xwxw
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
					return new ushort4(x, w, x, w);
				}
			}
		}
		public  ushort4 xwyx
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
					return new ushort4(x, w, y, x);
				}
			}
		}
		public  ushort4 xwyy
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
					return new ushort4(x, w, y, y);
				}
			}
		}
		public			ushort4 xwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 3, 0));
				}
				else
				{
					return new ushort4(x, w, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xzwy;
			}
		}
		public  ushort4 xwyw
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
					return new ushort4(x, w, y, w);
				}
			}
		}
		public  ushort4 xwzx
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
					return new ushort4(x, w, z, x);
				}
			}
		}
		public			ushort4 xwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 3, 0));
				}
				else
				{
					return new ushort4(x, w, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xwzy;
			}
		}
		public  ushort4 xwzz
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
					return new ushort4(x, w, z, z);
				}
			}
		}
		public  ushort4 xwzw
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
					return new ushort4(x, w, z, w);
				}
			}
		}
		public  ushort4 xwwx
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
					return new ushort4(x, w, w, x);
				}
			}
		}
		public  ushort4 xwwy
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
					return new ushort4(x, w, w, y);
				}
			}
		}
		public  ushort4 xwwz
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
					return new ushort4(x, w, w, z);
				}
			}
		}
		public  ushort4 xwww
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
					return new ushort4(x, w, w, w);
				}
			}
		}
		public  ushort4 yxxx
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
					return new ushort4(y, x, x, x);
				}
			}
		}
        public  ushort4 yxxy
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
					return new ushort4(y, x, x, y);
				}
			}
		}
        public  ushort4 yxxz
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
					return new ushort4(y, x, x, z);
				}
			}
		}
        public  ushort4 yxxw
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
					return new ushort4(y, x, x, w);
				}
			}
		}
        public  ushort4 yxyx
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
					return new ushort4(y, x, y, x);
				}
			}
		}
        public  ushort4 yxyy
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
					return new ushort4(y, x, y, y);
				}
			}
		}
        public  ushort4 yxyz
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
					return new ushort4(y, x, y, z);
				}
			}
		}
        public  ushort4 yxyw
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
					return new ushort4(y, x, y, w);
				}
			}
		}
        public  ushort4 yxzx
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
					return new ushort4(y, x, z, x);
				}
			}
		}
        public  ushort4 yxzy
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
					return new ushort4(y, x, z, y);
				}
			}
		}
        public  ushort4 yxzz
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
					return new ushort4(y, x, z, z);
				}
			}
		}
        public			ushort4 yxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 1));
				}
				else
				{
					return new ushort4(y, x, z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yxzw;
			}
		}
        public  ushort4 yxwx
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
					return new ushort4(y, x, w, x);
				}
			}
		}
        public  ushort4 yxwy
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
					return new ushort4(y, x, w, y);
				}
			}
		}
        public			ushort4 yxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 0, 1));
				}
				else
				{
					return new ushort4(y, x, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yxwz;
			}
		}
        public  ushort4 yxww
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
					return new ushort4(y, x, w, w);
				}
			}
		}
        public  ushort4 yyxx
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
					return new ushort4(y, y, x, x);
				}
			}
		}
        public  ushort4 yyxy
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
					return new ushort4(y, y, x, y);
				}
			}
		}
        public  ushort4 yyxz
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
					return new ushort4(y, y, x, z);
				}
			}
		}
        public  ushort4 yyxw
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
					return new ushort4(y, y, x, w);
				}
			}
		}
        public  ushort4 yyyx
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
					return new ushort4(y, y, y, x);
				}
			}
		}
        public  ushort4 yyyy
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
					return new ushort4(y, y, y, y);
				}
			}
		}
        public  ushort4 yyyz
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
					return new ushort4(y, y, y, z);
				}
			}
		}
        public  ushort4 yyyw
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
					return new ushort4(y, y, y, w);
				}
			}
		}
        public  ushort4 yyzx
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
					return new ushort4(y, y, z, x);
				}
			}
		}
        public  ushort4 yyzy
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
					return new ushort4(y, y, z, y);
				}
			}
		}
        public  ushort4 yyzz
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
					return new ushort4(y, y, z, z);
				}
			}
		}
        public  ushort4 yyzw
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
					return new ushort4(y, y, z, w);
				}
			}
		}
        public  ushort4 yywx
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
					return new ushort4(y, y, w, x);
				}
			}
		}
        public  ushort4 yywy
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
					return new ushort4(y, y, w, y);
				}
			}
		}
        public  ushort4 yywz
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
					return new ushort4(y, y, w, z);
				}
			}
		}
        public  ushort4 yyww
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
					return new ushort4(y, y, w, w);
				}
			}
		}
        public  ushort4 yzxx
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
					return new ushort4(y, z, x, x);
				}
			}
		}
        public  ushort4 yzxy
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
					return new ushort4(y, z, x, y);
				}
			}
		}
        public  ushort4 yzxz
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
					return new ushort4(y, z, x, z);
				}
			}
		}
        public			ushort4 yzxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 1));
				}
				else
				{
					return new ushort4(y, z, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zxyw;
			}
		}
        public  ushort4 yzyx
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
					return new ushort4(y, z, y, x);
				}
			}
		}
        public  ushort4 yzyy
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
					return new ushort4(y, z, y, y);
				}
			}
		}
        public  ushort4 yzyz
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
					return new ushort4(y, z, y, z);
				}
			}
		}
        public  ushort4 yzyw
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
					return new ushort4(y, z, y, w);
				}
			}
		}
        public  ushort4 yzzx
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
					return new ushort4(y, z, z, x);
				}
			}
		}
        public  ushort4 yzzy
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
					return new ushort4(y, z, z, y);
				}
			}
		}
        public  ushort4 yzzz
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
					return new ushort4(y, z, z, z);
				}
			}
		}
        public  ushort4 yzzw
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
					return new ushort4(y, z, z, w);
				}
			}
		}
        public			ushort4 yzwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 2, 1)); ;
				}
				else
				{
					return new ushort4(y, z, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wxyz;
			}
		}
        public  ushort4 yzwy
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
					return new ushort4(y, z, w, y);
				}
			}
		}
        public  ushort4 yzwz
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
					return new ushort4(y, z, w, z);
				}
			}
		}
        public  ushort4 yzww
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
					return new ushort4(y, z, w, w);
				}
			}
		}
        public  ushort4 ywxx
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
					return new ushort4(y, w, x, x);
				}
			}
		}
        public  ushort4 ywxy
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
					return new ushort4(y, w, x, y);
				}
			}
		}
        public			ushort4 ywxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 3, 1));
				}
				else
				{
					return new ushort4(y, w, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zxwy;
			}
		}
        public  ushort4 ywxw
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
					return new ushort4(y, w, x, w);
				}
			}
		}
        public  ushort4 ywyx
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
					return new ushort4(y, w, y, x);
				}
			}
		}
        public  ushort4 ywyy
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
					return new ushort4(y, w, y, y);
				}
			}
		}
        public  ushort4 ywyz
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
					return new ushort4(y, w, y, z);
				}
			}
		}
        public  ushort4 ywyw
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
					return new ushort4(y, w, y, w);
				}
			}
		}
        public			ushort4 ywzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 3, 1));
				}
				else
				{
					return new ushort4(y, w, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wxzy;
			}
		}
        public  ushort4 ywzy
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
					return new ushort4(y, w, z, y);
				}
			}
		}
        public  ushort4 ywzz
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
					return new ushort4(y, w, z, z);
				}
			}
		}
        public  ushort4 ywzw
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
					return new ushort4(y, w, z, w);
				}
			}
		}
        public  ushort4 ywwx
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
					return new ushort4(y, w, w, x);
				}
			}
		}
        public  ushort4 ywwy
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
					return new ushort4(y, w, w, y);
				}
			}
		}
        public  ushort4 ywwz
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
					return new ushort4(y, w, w, z);
				}
			}
		}
        public  ushort4 ywww
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
					return new ushort4(y, w, w, w);
				}
			}
		}
        public  ushort4 zxxx
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
					return new ushort4(z, x, x, x);
				}
			}
		}
        public  ushort4 zxxy
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
					return new ushort4(z, x, x, y);
				}
			}
		}
        public  ushort4 zxxz
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
					return new ushort4(z, x, x, z);
				}
			}
		}
        public  ushort4 zxxw
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
					return new ushort4(z, x, x, w);
				}
			}
		}
        public  ushort4 zxyx
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
					return new ushort4(z, x, y, x);
				}
			}
		}
        public  ushort4 zxyy
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
					return new ushort4(z, x, y, y);
				}
			}
		}
		public  ushort4 zxyz
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
					return new ushort4(z, x, y, z);
				}
			}
		}
        public			ushort4 zxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 2));
				}
				else
				{
					return new ushort4(z, x, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yzxw;
			}
		}
        public  ushort4 zxzx
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
					return new ushort4(z, x, z, x);
				}
			}
		}
        public  ushort4 zxzy
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
					return new ushort4(z, x, z, y);
				}
			}
		}
        public  ushort4 zxzz
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
					return new ushort4(z, x, z, z);
				}
			}
		}
        public  ushort4 zxzw
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
					return new ushort4(z, x, z, w);
				}
			}
		}
        public  ushort4 zxwx
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
					return new ushort4(z, x, w, x);
				}
			}
		}
        public			ushort4 zxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 0, 2));
				}
				else
				{
					return new ushort4(z, x, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.ywxz;
			}
		}
        public  ushort4 zxwz
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
					return new ushort4(z, x, w, z);
				}
			}
		}
        public  ushort4 zxww
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
					return new ushort4(z, x, w, w);
				}
			}
		}
        public  ushort4 zyxx
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
					return new ushort4(z, y, x, x);
				}
			}
		}
        public  ushort4 zyxy
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
					return new ushort4(z, y, x, y);
				}
			}
		}
        public  ushort4 zyxz
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
					return new ushort4(z, y, x, z);
				}
			}
		}
        public			ushort4 zyxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 2));
				}
				else
				{
					return new ushort4(z, y, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zyxw;
			}
		}
        public  ushort4 zyyx
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
					return new ushort4(z, y, y, x);
				}
			}
		}
        public  ushort4 zyyy
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
					return new ushort4(z, y, y, y);
				}
			}
		}
        public  ushort4 zyyz
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
					return new ushort4(z, y, y, z);
				}
			}
		}
        public  ushort4 zyyw
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
					return new ushort4(z, y, y, w);
				}
			}
		}
        public  ushort4 zyzx
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
					return new ushort4(z, y, z, x);
				}
			}
		}
        public  ushort4 zyzy
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
					return new ushort4(z, y, z, y);
				}
			}
		}
        public  ushort4 zyzz
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
					return new ushort4(z, y, z, z);
				}
			}
		}
        public  ushort4 zyzw
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
					return new ushort4(z, y, z, w);
				}
			}
		}
        public			ushort4 zywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 1, 2));
				}
				else
				{
					return new ushort4(z, y, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wyxz;
			}
		}
        public  ushort4 zywy
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
					return new ushort4(z, y, w, y);
				}
			}
		}
        public  ushort4 zywz
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
					return new ushort4(z, y, w, z);
				}
			}
		}
        public  ushort4 zyww
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
					return new ushort4(z, y, w, w);
				}
			}
		}
        public  ushort4 zzxx
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
					return new ushort4(z, z, x, x);
				}
			}
		}
        public  ushort4 zzxy
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
					return new ushort4(z, z, x, y);
				}
			}
		}
        public  ushort4 zzxz
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
					return new ushort4(z, z, x, z);
				}
			}
		}
        public  ushort4 zzxw
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
					return new ushort4(z, z, x, w);
				}
			}
		}
        public  ushort4 zzyx
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
					return new ushort4(z, z, y, x);
				}
			}
		}
        public  ushort4 zzyy
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
					return new ushort4(z, z, y, y);
				}
			}
		}
        public  ushort4 zzyz
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
					return new ushort4(z, z, y, z);
				}
			}
		}
        public  ushort4 zzyw
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
					return new ushort4(z, z, y, w);
				}
			}
		}
        public  ushort4 zzzx
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
					return new ushort4(z, z, z, x);
				}
			}
		}
        public  ushort4 zzzy
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
					return new ushort4(z, z, z, y);
				}
			}
		}
        public  ushort4 zzzz
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
					return new ushort4(z, z, z, z);
				}
			}
		}
        public  ushort4 zzzw
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
					return new ushort4(z, z, z, w);
				}
			}
		}
        public  ushort4 zzwx
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
					return new ushort4(z, z, w, x);
				}
			}
		}
        public  ushort4 zzwy
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
					return new ushort4(z, z, w, y);
				}
			}
		}
        public  ushort4 zzwz
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
					return new ushort4(z, z, w, z);
				}
			}
		}
        public  ushort4 zzww
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
					return new ushort4(z, z, w, w);
				}
			}
		}
        public  ushort4 zwxx
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
					return new ushort4(z, w, x, x);
				}
			}
		}
        public			ushort4 zwxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 3, 2));
				}
				else
				{
					return new ushort4(z, w, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zwxy;
			}
		}
        public  ushort4 zwxz
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
					return new ushort4(z, w, x, z);
				}
			}
		}
        public  ushort4 zwxw
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
					return new ushort4(z, w, x, w);
				}
			}
		}
        public			ushort4 zwyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 3, 2));
				}
				else
				{
					return new ushort4(z, w, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wzxy;
			}
		}
        public  ushort4 zwyy
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
					return new ushort4(z, w, y, y);
				}
			}
		}
        public  ushort4 zwyz
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
					return new ushort4(z, w, y, z);
				}
			}
		}
        public  ushort4 zwyw
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
					return new ushort4(z, w, y, w);
				}
			}
		}
        public  ushort4 zwzx
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
					return new ushort4(z, w, z, x);
				}
			}
		}
        public  ushort4 zwzy
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
					return new ushort4(z, w, z, y);
				}
			}
		}
        public  ushort4 zwzz
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
					return new ushort4(z, w, z, z);
				}
			}
		}
        public  ushort4 zwzw
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
					return new ushort4(z, w, z, w);
				}
			}
		}
        public  ushort4 zwwx
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
					return new ushort4(z, w, w, x);
				}
			}
		}
        public  ushort4 zwwy
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
					return new ushort4(z, w, w, y);
				}
			}
		}
        public  ushort4 zwwz
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
					return new ushort4(z, w, w, z);
				}
			}
		}
        public  ushort4 zwww
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
					return new ushort4(z, w, w, w);
				}
			}
		}
        public  ushort4 wxxx
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
					return new ushort4(w, x, x, x);
				}
			}
		}
        public  ushort4 wxxy
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
					return new ushort4(w, x, x, y);
				}
			}
		}
        public  ushort4 wxxz
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
					return new ushort4(w, x, x, z);
				}
			}
		}
        public  ushort4 wxxw
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
					return new ushort4(w, x, x, w);
				}
			}
		}
        public  ushort4 wxyx
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
					return new ushort4(w, x, y, x);
				}
			}
		}
        public  ushort4 wxyy
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
					return new ushort4(w, x, y, y);
				}
			}
		}
        public          ushort4 wxyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 3));
				}
				else
				{
					return new ushort4(w, x, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yzwx;
			}
		}
        public  ushort4 wxyw
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
					return new ushort4(w, x, y, w);
				}
			}
		}
        public  ushort4 wxzx
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
					return new ushort4(w, x, z, x);
				}
			}
		}
        public          ushort4 wxzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 3));
				}
				else
				{
					return new ushort4(w, x, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.ywzx;
			}
		}
        public  ushort4 wxzz
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
					return new ushort4(w, x, z, z);
				}
			}
		}
        public  ushort4 wxzw
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
					return new ushort4(w, x, z, w);
				}
			}
		}
        public  ushort4 wxwx
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
					return new ushort4(w, x, w, x);
				}
			}
		}
        public  ushort4 wxwy
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
					return new ushort4(w, x, w, y);
				}
			}
		}
        public  ushort4 wxwz
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
					return new ushort4(w, x, w, z);
				}
			}
		}
        public  ushort4 wxww
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
					return new ushort4(w, x, w, w);
				}
			}
		}
        public  ushort4 wyxx
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
					return new ushort4(w, y, x, x);
				}
			}
		}
        public  ushort4 wyxy
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
					return new ushort4(w, y, x, y);
				}
			}
		}
        public          ushort4 wyxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 3));
				}
				else
				{
					return new ushort4(w, y, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zywx;
			}
		}
        public  ushort4 wyxw
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
					return new ushort4(w, y, x, w);
				}
			}
		}
        public  ushort4 wyyx
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
					return new ushort4(w, y, y, x);
				}
			}
		}
        public  ushort4 wyyy
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
					return new ushort4(w, y, y, y);
				}
			}
		}
        public  ushort4 wyyz
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
					return new ushort4(w, y, y, z);
				}
			}
		}
        public  ushort4 wyyw
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
					return new ushort4(w, y, y, w);
				}
			}
		}
        public          ushort4 wyzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 3));
				}
				else
				{
					return new ushort4(w, y, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wyzx;
			}
		}
        public  ushort4 wyzy
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
					return new ushort4(w, y, z, y);
				}
			}
		}
        public  ushort4 wyzz
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
					return new ushort4(w, y, z, z);
				}
			}
		}
        public  ushort4 wyzw
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
					return new ushort4(w, y, z, w);
				}
			}
		}
        public  ushort4 wywx
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
					return new ushort4(w, y, w, x);
				}
			}
		}
        public  ushort4 wywy
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
					return new ushort4(w, y, w, y);
				}
			}
		}
        public  ushort4 wywz
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
					return new ushort4(w, y, w, z);
				}
			}
		}
        public  ushort4 wyww
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
					return new ushort4(w, y, w, w);
				}
			}
		}
        public  ushort4 wzxx
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
					return new ushort4(w, z, x, x);
				}
			}
		}
        public          ushort4 wzxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 3));
				}
				else
				{
					return new ushort4(w, z, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zwyx;
			}
		}
        public  ushort4 wzxz
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
					return new ushort4(w, z, x, z);
				}
			}
		}
        public  ushort4 wzxw
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
					return new ushort4(w, z, x, w);
				}
			}
		}
        public          ushort4 wzyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 3));
				}
				else
				{
					return new ushort4(w, z, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wzyx;
			}
		}
        public  ushort4 wzyy
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
					return new ushort4(w, z, y, y);
				}
			}
		}
        public  ushort4 wzyz
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
					return new ushort4(w, z, y, z);
				}
			}
		}
        public  ushort4 wzyw
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
					return new ushort4(w, z, y, w);
				}
			}
		}
        public  ushort4 wzzx
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
					return new ushort4(w, z, z, x);
				}
			}
		}
        public  ushort4 wzzy
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
					return new ushort4(w, z, z, y);
				}
			}
		}
        public  ushort4 wzzz
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
					return new ushort4(w, z, z, z);
				}
			}
		}
        public  ushort4 wzzw
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
					return new ushort4(w, z, z, w);
				}
			}
		}
        public  ushort4 wzwx
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
					return new ushort4(w, z, w, x);
				}
			}
		}
        public  ushort4 wzwy
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
					return new ushort4(w, z, w, y);
				}
			}
		}
        public  ushort4 wzwz
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
					return new ushort4(w, z, w, z);
				}
			}
		}
        public  ushort4 wzww
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
					return new ushort4(w, z, w, w);
				}
			}
		}
        public  ushort4 wwxx
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
					return new ushort4(w, w, x, x);
				}
			}
		}
        public  ushort4 wwxy
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
					return new ushort4(w, w, x, y);
				}
			}
		}
        public  ushort4 wwxz
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
					return new ushort4(w, w, x, z);
				}
			}
		}
        public  ushort4 wwxw
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
					return new ushort4(w, w, x, w);
				}
			}
		}
        public  ushort4 wwyx
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
					return new ushort4(w, w, y, x);
				}
			}
		}
        public  ushort4 wwyy
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
					return new ushort4(w, w, y, y);
				}
			}
		}
        public  ushort4 wwyz
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
					return new ushort4(w, w, y, z);
				}
			}
		}
        public  ushort4 wwyw
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
					return new ushort4(w, w, y, w);
				}
			}
		}
        public  ushort4 wwzx
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
					return new ushort4(w, w, z, x);
				}
			}
		}
        public  ushort4 wwzy
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
					return new ushort4(w, w, z, y);
				}
			}
		}
        public  ushort4 wwzz
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
					return new ushort4(w, w, z, z);
				}
			}
		}
        public  ushort4 wwzw
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
					return new ushort4(w, w, z, w);
				}
			}
		}
        public  ushort4 wwwx
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
					return new ushort4(w, w, w, x);
				}
			}
		}
        public  ushort4 wwwy
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
					return new ushort4(w, w, w, y);
				}
			}
		}
        public  ushort4 wwwz
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
					return new ushort4(w, w, w, z);
				}
			}
		}
        public  ushort4 wwww
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
					return new ushort4(w, w, w, w);
				}
			}
		}

        public  ushort3 xxx
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
					return new ushort3(x, x, x);
				}
			}
		}
        public  ushort3 xxy
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
					return new ushort3(x, x, y);
				}
			}
		}
        public  ushort3 xxz
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
					return new ushort3(x, x, z);
				}
			}
		}
        public  ushort3 xxw
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
					return new ushort3(x, x, w);
				}
			}
		}
        public  ushort3 xyx
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
					return new ushort3(x, y, x);
				}
			}
		}
        public  ushort3 xyy
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
					return new ushort3(x, y, y);
				}
			}
		}
        public          ushort3 xyz
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return (v128)this;
				}
				else
				{
					return new ushort3(x, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value, 0b0111);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value, 0b0111);
					}
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
					this.z = value.z;
				}
			}
		}
        public          ushort3 xyw
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
					return new ushort3(x, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.xyzz, 0b1011);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.xyzz, 0b1011);
					}
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
					this.w = value.z;
				}
			}
		}
        public  ushort3 xzx
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
					return new ushort3(x, z, x);
				}
			}
		}
        public          ushort3 xzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 0));
				}
				else
				{
					return new ushort3(x, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.xzyy, 0b0111);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.xzyy, 0b0111);
					}
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
					this.y = value.z;
				}
			}
		}
        public  ushort3 xzz
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
					return new ushort3(x, z, z);
				}
			}
		}
        public          ushort3 xzw
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
					return new ushort3(x, z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.xxyz, 0b1101);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.xxyz, 0b1101);
					}
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
					this.w = value.z;
				}
			}
		}
        public  ushort3 xwx
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
					return new ushort3(x, w, x);
				}
			}
		}
        public          ushort3 xwy
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
					return new ushort3(x, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.xzzy, 0b1011);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.xzzy, 0b1011);
					}
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
					this.y = value.z;
				}
			}
		}
        public          ushort3 xwz
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
					return new ushort3(x, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.xxzy, 0b1101);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.xxzy, 0b1101);
					}
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
					this.z = value.z;
				}
			}
		}
        public  ushort3 xww
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
					return new ushort3(x, w, w);
				}
			}
		}
        public  ushort3 yxx
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
					return new ushort3(y, x, x);
				}
			}
		}
        public  ushort3 yxy
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
					return new ushort3(y, x, y);
				}
			}
		}
        public          ushort3 yxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 1));
				}
				else
				{
					return new ushort3(y, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.yxzz, 0b0111);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.yxzz, 0b0111);
					}
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
					this.z = value.z;
				}
			}
		}
        public          ushort3 yxw
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
					return new ushort3(y, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.yxzz, 0b1011);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.yxzz, 0b1011);
					}
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
					this.w = value.z;
				}
			}
		}
        public  ushort3 yyx
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
					return new ushort3(y, y, x);
				}
			}
		}
        public  ushort3 yyy
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
					return new ushort3(y, y, y);
				}
			}
		}
        public  ushort3 yyz
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
					return new ushort3(y, y, z);
				}
			}
		}
        public  ushort3 yyw
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
					return new ushort3(y, y, w);
				}
			}
		}
        public          ushort3 yzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 1));
				}
				else
				{
					return new ushort3(y, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.zxyy, 0b0111);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.zxyy, 0b0111);
					}
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
					this.x = value.z;
				}
			}
		}
        public  ushort3 yzy
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
					return new ushort3(y, z, y);
				}
			}
		}
        public  ushort3 yzz
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
					return new ushort3(y, z, z);
				}
			}
		}
        public          ushort3 yzw
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
					return new ushort3(y, z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.xxyz, 0b1110);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.xxyz, 0b1110);
					}
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
					this.w = value.z;
				}
			}
		}
        public          ushort3 ywx
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
					return new ushort3(y, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.zxxy, 0b1011);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.zxxy, 0b1011);
					}
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
					this.x = value.z;
				}
			}
		}
        public  ushort3 ywy
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
					return new ushort3(y, w, y);
				}
			}
		}
        public          ushort3 ywz
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
					return new ushort3(y, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.xxzy, 0b1110);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.xxzy, 0b1110);
					}
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
					this.z = value.z;
				}
			}
		}
        public  ushort3 yww
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
					return new ushort3(y, w, w);
				}
			}
		}
        public  ushort3 zxx
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
					return new ushort3(z, x, x);
				}
			}
		}
        public          ushort3 zxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 2));
				}
				else
				{
					return new ushort3(z, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.yzxx, 0b0111);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.yzxx, 0b0111);
					}
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
					this.y = value.z;
				}
			}
		}
        public  ushort3 zxz
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
					return new ushort3(z, x, z);
				}
			}
		}
        public          ushort3 zxw
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
					return new ushort3(z, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.yyxz, 0b1101);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.yyxz, 0b1101);
					}
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
					this.w = value.z;
				}
			}
		}
        public          ushort3 zyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 2));
				}
				else
				{
					return new ushort3(z, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.zyxx, 0b0111);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.zyxx, 0b0111);
					}
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
					this.x = value.z;
				}
			}
		}
        public  ushort3 zyy
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
					return new ushort3(z, y, y);
				}
			}
		}
        public  ushort3 zyz
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
					return new ushort3(z, y, z);
				}
			}
		}
        public          ushort3 zyw
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
					return new ushort3(z, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.yyxz, 0b1110);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.yyxz, 0b1110);
					}
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
					this.w = value.z;
				}
			}
		}
        public  ushort3 zzx
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
					return new ushort3(z, z, x);
				}
			}
		}
        public  ushort3 zzy
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
					return new ushort3(z, z, y);
				}
			}
		}
        public  ushort3 zzz
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
					return new ushort3(z, z, z);
				}
			}
		}
        public  ushort3 zzw
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
					return new ushort3(z, z, w);
				}
			}
		}
        public          ushort3 zwx
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
					return new ushort3(z, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.zzxy, 0b1101);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.zzxy, 0b1101);
					}
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
					this.x = value.z;
				}
			}
		}
        public          ushort3 zwy
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
					return new ushort3(z, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.zzxy, 0b1110);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.zzxy, 0b1110);
					}
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
					this.y = value.z;
				}
			}
		}
        public  ushort3 zwz
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
					return new ushort3(z, w, z);
				}
			}
		}
        public  ushort3 zww
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
					return new ushort3(z, w, w);
				}
			}
		}
        public  ushort3 wxx
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
					return new ushort3(w, x, x);
				}
			}
		}
        public          ushort3 wxy
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
					return new ushort3(w, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.yzzx, 0b1011);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.yzzx, 0b1011);
					}
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
					this.y = value.z;
				}
			}
		}
        public          ushort3 wxz
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
					return new ushort3(w, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.yyzx, 0b1101);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.yyzx, 0b1101);
					}
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
					this.z = value.z;
				}
			}
		}
        public  ushort3 wxw
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
					return new ushort3(w, x, w);
				}
			}
		}
        public          ushort3 wyx
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
					return new ushort3(w, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.zyyx, 0b1011);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.zyyx, 0b1011);
					}
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
					this.x = value.z;
				}
			}
		}
        public  ushort3 wyy
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
					return new ushort3(w, y, y);
				}
			}
        }
        public          ushort3 wyz
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
					return new ushort3(w, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.yyzx, 0b1110);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.yyzx, 0b1110);
					}
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
					this.z = value.z;
				}
			}
        }
        public  ushort3 wyw
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
					return new ushort3(w, y, w);
				}
			}
        }
        public          ushort3 wzx
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
					return new ushort3(w, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.zzyx, 0b1101);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.zzyx, 0b1101);
					}
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
					this.x = value.z;
				}
			}
        }
        public          ushort3 wzy
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
					return new ushort3(w, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.zzyx, 0b1110);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.zzyx, 0b1110);
					}
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
					this.y = value.z;
				}
			}
        }
        public  ushort3 wzz
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
					return new ushort3(w, z, z);
				}
			}
        }
        public  ushort3 wzw
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
					return new ushort3(w, z, w);
				}
			}
        }
        public  ushort3 wwx
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
					return new ushort3(w, w, x);
				}
			}
        }
        public  ushort3 wwy
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
					return new ushort3(w, w, y);
				}
			}
        }
        public  ushort3 wwz
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
					return new ushort3(w, w, z);
				}
			}
        }
        public  ushort3 www
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
					return new ushort3(w, w, w);
				}
			}
        }

        public  ushort2 xx
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
					return new ushort2(x, x);
				}
			}
		}
        public          ushort2 xy
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return (v128)this;
				}
				else
				{
					return new ushort2(x, y);
				}
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value, 0b0011);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value, 0b0011);
					}
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
				}
			}
        }
        public          ushort2 xz
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
					return new ushort2(x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.xxyy, 0b0101);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.xxyy, 0b0101);
					}
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
				}
			}
        }
        public          ushort2 xw
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
					return new ushort2(x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.xxyy, 0b1001);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.xxyy, 0b1001);
					}
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
				}
			}
        }
        public          ushort2 yx
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
					return new ushort2(y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.yx, 0b0011);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.yx, 0b0011);
					}
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
				}
			}
        }
        public  ushort2 yy
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
					return new ushort2(y, y);
				}
			}
        }
        public          ushort2 yz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.bsrli_si128(this, sizeof(ushort));
				}
				else
				{
					return new ushort2(y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.xxyy, 0b0110);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.xxyy, 0b0110);
					}
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
				}
			}
        }
        public          ushort2 yw
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
					return new ushort2(y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.xxyy, 0b1010);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.xxyy, 0b1010);
					}
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
				}
			}
        }
        public          ushort2 zx
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
					return new ushort2(z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.yyxx, 0b0101);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.yyxx, 0b0101);
					}
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
				}
			}
        }
        public          ushort2 zy
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
					return new ushort2(z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.yyxx, 0b0110);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.yyxx, 0b0110);
					}
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
				}
			}
        }
        public  ushort2 zz
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
					return new ushort2(z, z);
				}
			}
        }
        public          ushort2 zw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.bsrli_si128(this, 2 * sizeof(ushort));
				}
				else
				{
					return new ushort2(z, w);
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
        public          ushort2 wx
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
					return new ushort2(w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.yyxx, 0b1001);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.yyxx, 0b1001);
					}
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
				}
			}
        }
        public          ushort2 wy
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
					return new ushort2(w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.yyxx, 0b1010);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.yyxx, 0b1010);
					}
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
				}
			}
        }
        public          ushort2 wz
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
					return new ushort2(w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.yxyx, 0b1100);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.yxyx, 0b1100);
					}
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
				}
			}
        }
        public  ushort2 ww
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
					return new ushort2(w, w);
                }
			}
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(ushort4 input) => new v128(input.alias_long, 0L);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static implicit operator ushort4(v128 input) => new ushort4 { alias_long = input.SLong0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort4(ushort input) => new ushort4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(short4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(ushort4*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(int4 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Int4ToShort4(*(v128*)&input);
			}
			else if (Sse2.IsSse2Supported)
			{
				return Cast.Int4To_U_Short4_SSE2(*(v128*)&input);
			}
			else
            {
                return new ushort4((ushort)input.x, (ushort)input.y, (ushort)input.z, (ushort)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(uint4 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Int4ToShort4(*(v128*)&input);
			}
			else if (Sse2.IsSse2Supported)
			{
				return Cast.Int4To_U_Short4_SSE2(*(v128*)&input);
			}
			else
            {
                return new ushort4((ushort)input.x, (ushort)input.y, (ushort)input.z, (ushort)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(long4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Cast.Long4ToShort4(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new ushort4(Cast.Long2ToShort2(input._xy), Cast.Long2ToShort2(input._zw));
			}
            else
            {
                return new ushort4((ushort)input.x, (ushort)input.y, (ushort)input.z, (ushort)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(ulong4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Cast.Long4ToShort4(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new ushort4(Cast.Long2ToShort2(input._xy), Cast.Long2ToShort2(input._zw));
            }
            else
            {
                return new ushort4((ushort)input.x, (ushort)input.y, (ushort)input.z, (ushort)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(half4 input) => (ushort4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(float4 input) => (ushort4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(double4 input) => (ushort4)(int4)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4(ushort4 input)
        {
			if (Sse2.IsSse2Supported)
			{
				v128 temp = Cast.UShortToInt(input);

				return *(int4*)&temp;
            }
            else
            {
                return new int4((int)input.x, (int)input.y, (int)input.z, (int)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4(ushort4 input)
        {
			if (Sse2.IsSse2Supported)
			{
				v128 temp = Cast.UShortToInt(input);

				return *(uint4*)&temp;
            }
            else
            {
                return new uint4((uint)input.x, (uint)input.y, (uint)input.z, (uint)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(ushort4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu16_epi64(input);
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
        public static implicit operator ulong4(ushort4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu16_epi64(input);
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
        public static explicit operator half4(ushort4 input) => (half4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(ushort4 input) 
        {
            if (Sse2.IsSse2Supported)
            {
                v128 temp = Cast.UShortToFloat(input); 
                
                return *(float4*)&temp;
            }
            else
            {
                return new float4((float)input.x, (float)input.y, (float)input.z, (float)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(ushort4 input) => (double4)(int4)input;


        public ushort this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get
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
        public static ushort4 operator + (ushort4 left, ushort4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi16(left, right);
            }
            else
            {
                return new ushort4((ushort)(left.x + right.x), (ushort)(left.y + right.y), (ushort)(left.z + right.z), (ushort)(left.w + right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator - (ushort4 left, ushort4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(left, right);
            }
            else
            {
                return new ushort4((ushort)(left.x - right.x), (ushort)(left.y - right.y), (ushort)(left.z - right.z), (ushort)(left.w - right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator * (ushort4 left, ushort4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.mullo_epi16(left, right);
            }
            else
            {
                return new ushort4((ushort)(left.x * right.x), (ushort)(left.y * right.y), (ushort)(left.z * right.z), (ushort)(left.w * right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator / (ushort4 left, ushort4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vdiv_ushort(left, right);
            }
            else
            {
                return new ushort4((ushort)(left.x / right.x), (ushort)(left.y / right.y), (ushort)(left.z / right.z), (ushort)(left.w / right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator % (ushort4 left, ushort4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vrem_ushort(left, right);
            }
            else
            {
                return new ushort4((ushort)(left.x % right.x), (ushort)(left.y % right.y), (ushort)(left.z % right.z), (ushort)(left.w % right.w));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator * (ushort left, ushort4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator * (ushort4 left, ushort right)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)((ushort8)((v128)left) * right);
            }
            else
            {
                return new ushort4((ushort)(left.x * right), (ushort)(left.y * right), (ushort)(left.z * right), (ushort)(left.w * right));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator / (ushort4 left, ushort right)
        {
            if (Sse.IsSseSupported)
            {
                return (v128)((ushort8)((v128)left) / right);
            }
            else
            {
                return new ushort4((ushort)(left.x / right), (ushort)(left.y / right), (ushort)(left.z / right), (ushort)(left.w / right));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator % (ushort4 left, ushort right)
        {
            if (Sse.IsSseSupported)
            {
                return (v128)((ushort8)((v128)left) % right);
            }
            else
            {
                return new ushort4((ushort)(left.x % right), (ushort)(left.y % right), (ushort)(left.z % right), (ushort)(left.w % right));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator & (ushort4 left, ushort4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new ushort4((ushort)(left.x & right.x), (ushort)(left.y & right.y), (ushort)(left.z & right.z), (ushort)(left.w & right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator | (ushort4 left, ushort4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new ushort4((ushort)(left.x | right.x), (ushort)(left.y | right.y), (ushort)(left.z | right.z), (ushort)(left.w | right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator ^ (ushort4 left, ushort4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new ushort4((ushort)(left.x ^ right.x), (ushort)(left.y ^ right.y), (ushort)(left.z ^ right.z), (ushort)(left.w ^ right.w));
            }
        }
    

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator ++ (ushort4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
			}
            else
            {
                return new ushort4((ushort)(x.x + 1), (ushort)(x.y + 1), (ushort)(x.z + 1), (ushort)(x.w + 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator -- (ushort4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi16(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
			}
            else
            {
                return new ushort4((ushort)(x.x - 1), (ushort)(x.y - 1), (ushort)(x.z - 1), (ushort)(x.w - 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator ~ (ushort4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
			}
            else
            {
                return new ushort4((ushort)(~x.x), (ushort)(~x.y), (ushort)(~x.z), (ushort)(~x.w));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator << (ushort4 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shl_short(x, n);
            }
            else
            {
                return new ushort4((ushort)(x.x << n), (ushort)(x.y << n), (ushort)(x.z << n), (ushort)(x.w << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator >> (ushort4 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shrl_short(x, n);
            }
            else
            {
                return new ushort4((ushort)(x.x >> n), (ushort)(x.y >> n), (ushort)(x.z >> n), (ushort)(x.w >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (ushort4 left, ushort4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Sse2.cmpeq_epi16(left, right));
            }
            else
            {
                return new bool4(left.x == right.x, left.y == right.y, left.z == right.z, left.w == right.w);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (ushort4 left, ushort4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Operator.greater_mask_ushort(right, left));
            }
            else
            {
                return new bool4(left.x < right.x, left.y < right.y, left.z < right.z, left.w < right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (ushort4 left, ushort4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Operator.greater_mask_ushort(left, right));
            }
            else
            {
                return new bool4(left.x > right.x, left.y > right.y, left.z > right.z, left.w > right.w);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (ushort4 left, ushort4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsFalse(Sse2.cmpeq_epi16(left, right));
            }
            else
            {
                return new bool4(left.x != right.x, left.y != right.y, left.z != right.z, left.w != right.w);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (ushort4 left, ushort4 right)
        {
			if (Sse4_1.IsSse41Supported)
			{
				return TestIsTrue(Sse2.cmpeq_epi16(Sse4_1.min_epu16(left, right), left));
			}
			else if (Sse2.IsSse2Supported)
            {
                return TestIsFalse(Operator.greater_mask_ushort(left, right));
            }
            else
            {
                return new bool4(left.x <= right.x, left.y <= right.y, left.z <= right.z, left.w <= right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (ushort4 left, ushort4 right)
        {
			if (Sse4_1.IsSse41Supported)
			{
				return TestIsTrue(Sse2.cmpeq_epi16(Sse4_1.max_epu16(left, right), left));
			}
			else if (Sse2.IsSse2Supported)
            {
                return TestIsFalse(Operator.greater_mask_ushort(right, left));
            }
            else
            {
                return new bool4(left.x >= right.x, left.y >= right.y, left.z >= right.z, left.w >= right.w);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsTrue(v128 input)
        {
            input = (v128)((byte8)(-(short8)input));

			return *(bool4*)&input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsFalse(v128 input)
        {
			if (Sse2.IsSse2Supported)
			{
				input = Sse2.andnot_si128((byte4)(ushort4)input, new ushort4(0x0101));

				return *(bool4*)&input;
			}
			else throw new CPUFeatureCheckException();
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public  bool Equals(ushort4 other)
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

		public override  bool Equals(object obj) => Equals((ushort4)obj);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override  int GetHashCode()
		{
			if (Sse2.IsSse2Supported)
			{
				return Hash.v64(this);
			}
			else
			{
				ushort4 temp = this;

				return (*(ulong*)&temp).GetHashCode();
			}
		}


		public override  string ToString() => $"ushort4({x}, {y}, {z}, {w})";
        public  string ToString(string format, IFormatProvider formatProvider) => $"ushort4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}