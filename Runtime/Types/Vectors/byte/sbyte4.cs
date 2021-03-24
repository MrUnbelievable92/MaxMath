using DevTools;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 4 * sizeof(sbyte))]  [DebuggerTypeProxy(typeof(sbyte4.DebuggerProxy))]
    unsafe public struct sbyte4 : IEquatable<sbyte4>, IFormattable
	{
		internal sealed class DebuggerProxy
		{
			public sbyte x;
			public sbyte y;
			public sbyte z;
			public sbyte w;

			public DebuggerProxy(sbyte4 v)
			{
				x = v.x;
				y = v.y;
				z = v.z;
				w = v.w;
			}
		}


		[FieldOffset(0)] private fixed sbyte asArray[4];

        [FieldOffset(0)] public sbyte x;
        [FieldOffset(1)] public sbyte y;
        [FieldOffset(2)] public sbyte z;
        [FieldOffset(3)] public sbyte w;


        public static sbyte4 zero => default;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte x, sbyte y, sbyte z, sbyte w)
        {
            if (Sse2.IsSse2Supported)
			{
				this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, w, z, y, x);
			}
			else
            {
				this.x = x;
				this.y = y;
				this.z = z;
				this.w = w;
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte xyzw)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.set1_epi8(xyzw);
			}
			else
			{
				this.x = this.y = this.z = this.w = xyzw;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte2 xy, sbyte z, sbyte w)
        {
            if (Sse2.IsSse2Supported)
            {
				this = Sse2.unpacklo_epi16(xy, new sbyte2(z, w));
			}
			else
            {
				this.x = xy.x;
				this.y = xy.y;
				this.z = z;
				this.w = w;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte x, sbyte2 yz, sbyte w)
        {
			if (Sse4_1.IsSse41Supported)
			{
				this = Sse4_1.insert_epi8(Sse4_1.insert_epi8(Sse2.bslli_si128(yz, sizeof(sbyte)), (byte)x, 0), (byte)w, 3);
			}
			else if (Sse2.IsSse2Supported)
			{
				this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, w, yz.y, yz.x, x);
			}
			else
			{
				this.x = x;
				this.y = yz.x;
				this.z = yz.y;
				this.w = w;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte x, sbyte y, sbyte2 zw)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.unpacklo_epi16(new sbyte2(x, y), zw);
			}
			else
			{
				this.x = x;
				this.y = y;
				this.z = zw.x;
				this.w = zw.y;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte2 xy, sbyte2 zw)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.unpacklo_epi16(xy, zw);
			}
			else
			{
				this.x = xy.x;
				this.y = xy.y;
				this.z = zw.x;
				this.w = zw.y;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte3 xyz, sbyte w)
        {
			if (Sse4_1.IsSse41Supported)
			{
				this = Sse4_1.insert_epi8(xyz, (byte)w, 3);
			}
			else if (Sse2.IsSse2Supported)
			{
				this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, w, xyz.z, xyz.y, xyz.x);
			}
			else
			{
				this.x = xyz.x;
				this.y = xyz.y;
				this.z = xyz.z;
				this.w = w;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte x, sbyte3 yzw)
        {
			if (Sse4_1.IsSse41Supported)
			{
				this = Sse4_1.insert_epi8(Sse2.bslli_si128(yzw, sizeof(sbyte)), (byte)x, 0);
			}
			else if (Sse2.IsSse2Supported)
			{
				this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, yzw.z, yzw.y, yzw.x, x);
			}
			else
			{
				this.x = x;
				this.y = yzw.x;
				this.z = yzw.y;
				this.w = yzw.z;
			}
        }


		#region Shuffle
		public sbyte4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 0, 0));
				}
				else
				{
					return new sbyte4(x, x, x, x);
				}
			}
		}
		public sbyte4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 0, 1));
				}
				else
				{
					return new sbyte4(x, x, x, y);
				}
			}
		}
		public sbyte4 xxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 0, 2));
				}
				else
				{
					return new sbyte4(x, x, x, z);
				}
			}
		}
		public sbyte4 xxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 0, 3));
				}
				else
				{
					return new sbyte4(x, x, x, w);
				}
			}
		}
		public sbyte4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 1, 0));
				}
				else
				{
					return new sbyte4(x, x, y, x);
				}
			}
		}
		public sbyte4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 1, 1));
				}
				else
				{
					return new sbyte4(x, x, y, y);
				}
			}
		}
		public sbyte4 xxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 1, 2));
				}
				else
				{
					return new sbyte4(x, x, y, z);
				}
			}
		}
		public sbyte4 xxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 1, 3));
				}
				else
				{
					return new sbyte4(x, x, y, w);
				}
			}
		}
		public sbyte4 xxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 2, 0));
				}
				else
				{
					return new sbyte4(x, x, z, x);
				}
			}
		}
		public sbyte4 xxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 2, 1));
				}
				else
				{
					return new sbyte4(x, x, z, y);
				}
			}
		}
		public sbyte4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 2, 2));
				}
				else
				{
					return new sbyte4(x, x, z, z);
				}
			}
		}
		public sbyte4 xxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 2, 3));
				}
				else
				{
					return new sbyte4(x, x, z, w);
				}
			}
		}
		public sbyte4 xxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 3, 0));
				}
				else
				{
					return new sbyte4(x, x, w, x);
				}
			}
		}
		public sbyte4 xxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 3, 1));
				}
				else
				{
					return new sbyte4(x, x, w, y);
				}
			}
		}
		public sbyte4 xxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 3, 2));
				}
				else
				{
					return new sbyte4(x, x, w, z);
				}
			}
		}
		public sbyte4 xxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 3, 3));
				}
				else
				{
					return new sbyte4(x, x, w, w);
				}
			}
		}
		public sbyte4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 0, 0));
				}
				else
				{
					return new sbyte4(x, y, x, x);
				}
			}
		}
		public sbyte4 xyxy
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
					return new sbyte4(x, y, x, y);
				}
			}
		}
		public sbyte4 xyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 0, 2));
				}
				else
				{
					return new sbyte4(x, y, x, z);
				}
			}
		}
		public sbyte4 xyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 0, 3));
				}
				else
				{
					return new sbyte4(x, y, x, w);
				}
			}
		}
		public sbyte4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 1, 0));
				}
				else
				{
					return new sbyte4(x, y, y, x);
				}
			}
		}
		public sbyte4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 1, 1));
				}
				else
				{
					return new sbyte4(x, y, y, y);
				}
			}
		}
		public sbyte4 xyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 1, 2));
				}
				else
				{
					return new sbyte4(x, y, y, z);
				}
			}
		}
		public sbyte4 xyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 1, 3));
				}
				else
				{
					return new sbyte4(x, y, y, w);
				}
			}
		}
		public sbyte4 xyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 2, 0));
				}
				else
				{
					return new sbyte4(x, y, z, x);
				}
			}
		}
		public sbyte4 xyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 2, 1));
				}
				else
				{
					return new sbyte4(x, y, z, y);
				}
			}
		}
		public sbyte4 xyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 2, 2));
				}
				else
				{
					return new sbyte4(x, y, z, z);
				}
			}
		}
		public sbyte4 xywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 3, 0));
				}
				else
				{
					return new sbyte4(x, y, w, x);
				}
			}
		}
		public sbyte4 xywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 3, 1));
				}
				else
				{
					return new sbyte4(x, y, w, y);
				}
			}
		}
		public sbyte4 xywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 3, 2));
				}
				else
				{
					return new sbyte4(x, y, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xywz;
			}
		}
		public sbyte4 xyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 3, 3));
				}
				else
				{
					return new sbyte4(x, y, w, w);
				}
			}
		}
		public sbyte4 xzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 0, 0));
				}
				else
				{
					return new sbyte4(x, z, x, x);
				}
			}
		}
		public sbyte4 xzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 0, 1));
				}
				else
				{
					return new sbyte4(x, z, x, y);
				}
			}
		}
		public sbyte4 xzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 0, 2));
				}
				else
				{
					return new sbyte4(x, z, x, z);
				}
			}
		}
		public sbyte4 xzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 0, 3));
				}
				else
				{
					return new sbyte4(x, z, x, w);
				}
			}
		}
		public sbyte4 xzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 1, 0));
				}
				else
				{
					return new sbyte4(x, z, y, x);
				}
			}
		}
		public sbyte4 xzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 1, 1));
				}
				else
				{
					return new sbyte4(x, z, y, y);
				}
			}
		}
		public sbyte4 xzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 1, 2));
				}
				else
				{
					return new sbyte4(x, z, y, z);
				}
			}
		}
		public sbyte4 xzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 1, 3));
				}
				else
				{
					return new sbyte4(x, z, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xzyw;
			}
		}
		public sbyte4 xzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 2, 0));
				}
				else
				{
					return new sbyte4(x, z, z, x);
				}
			}
		}
		public sbyte4 xzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 2, 1));
				}
				else
				{
					return new sbyte4(x, z, z, y);
				}
			}
		}
		public sbyte4 xzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 2, 2));
				}
				else
				{
					return new sbyte4(x, z, z, z);
				}
			}
		}
		public sbyte4 xzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 2, 3));
				}
				else
				{
					return new sbyte4(x, z, z, w);
				}
			}
		}
		public sbyte4 xzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 3, 0));
				}
				else
				{
					return new sbyte4(x, z, w, x);
				}
			}
		}
		public sbyte4 xzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 3, 1));
				}
				else
				{
					return new sbyte4(x, z, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xwyz;
			}
		}
		public sbyte4 xzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 3, 2));
				}
				else
				{
					return new sbyte4(x, z, w, z);
				}
			}
		}
		public sbyte4 xzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 3, 3));
				}
				else
				{
					return new sbyte4(x, z, w, w);
				}
			}
		}
		public sbyte4 xwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 0, 0));
				}
				else
				{
					return new sbyte4(x, w, x, x);
				}
			}
		}
		public sbyte4 xwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 0, 1));
				}
				else
				{
					return new sbyte4(x, w, x, y);
				}
			}
		}
		public sbyte4 xwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 0, 2));
				}
				else
				{
					return new sbyte4(x, w, x, z);
				}
			}
		}
		public sbyte4 xwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 0, 3));
				}
				else
				{
					return new sbyte4(x, w, x, w);
				}
			}
		}
		public sbyte4 xwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 1, 0));
				}
				else
				{
					return new sbyte4(x, w, y, x);
				}
			}
		}
		public sbyte4 xwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 1, 1));
				}
				else
				{
					return new sbyte4(x, w, y, y);
				}
			}
		}
		public sbyte4 xwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 1, 2));
				}
				else
				{
					return new sbyte4(x, w, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xzwy;
			}
		}
		public sbyte4 xwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 1, 3));
				}
				else
				{
					return new sbyte4(x, w, y, w);
				}
			}
		}
		public sbyte4 xwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 2, 0));
				}
				else
				{
					return new sbyte4(x, w, z, x);
				}
			}
		}
		public sbyte4 xwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 2, 1));
				}
				else
				{
					return new sbyte4(x, w, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xwzy;
			}
		}
		public sbyte4 xwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 2, 2));
				}
				else
				{
					return new sbyte4(x, w, z, z);
				}
			}
		}
		public sbyte4 xwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 2, 3));
				}
				else
				{
					return new sbyte4(x, w, z, w);
				}
			}
		}
		public sbyte4 xwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 3, 0));
				}
				else
				{
					return new sbyte4(x, w, w, x);
				}
			}
		}
		public sbyte4 xwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 3, 1));
				}
				else
				{
					return new sbyte4(x, w, w, y);
				}
			}
		}
		public sbyte4 xwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 3, 2));
				}
				else
				{
					return new sbyte4(x, w, w, z);
				}
			}
		}
		public sbyte4 xwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 3, 3));
				}
				else
				{
					return new sbyte4(x, w, w, w);
				}
			}
		}
		public sbyte4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 0, 0));
				}
				else
				{
					return new sbyte4(y, x, x, x);
				}
			}
		}
		public sbyte4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 0, 1));
				}
				else
				{
					return new sbyte4(y, x, x, y);
				}
			}
		}
		public sbyte4 yxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 0, 2));
				}
				else
				{
					return new sbyte4(y, x, x, z);
				}
			}
		}
		public sbyte4 yxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 0, 3));
				}
				else
				{
					return new sbyte4(y, x, x, w);
				}
			}
		}
		public sbyte4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 1, 0));
				}
				else
				{
					return new sbyte4(y, x, y, x);
				}
			}
		}
		public sbyte4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 1, 1));
				}
				else
				{
					return new sbyte4(y, x, y, y);
				}
			}
		}
		public sbyte4 yxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 1, 2));
				}
				else
				{
					return new sbyte4(y, x, y, z);
				}
			}
		}
		public sbyte4 yxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 1, 3));
				}
				else
				{
					return new sbyte4(y, x, y, w);
				}
			}
		}
		public sbyte4 yxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 2, 0));
				}
				else
				{
					return new sbyte4(y, x, z, x);
				}
			}
		}
		public sbyte4 yxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 2, 1));
				}
				else
				{
					return new sbyte4(y, x, z, y);
				}
			}
		}
		public sbyte4 yxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 2, 2));
				}
				else
				{
					return new sbyte4(y, x, z, z);
				}
			}
		}
		public sbyte4 yxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 2, 3));
				}
				else
				{
					return new sbyte4(y, x, z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yxzw;
			}
		}
		public sbyte4 yxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 3, 0));
				}
				else
				{
					return new sbyte4(y, x, w, x);
				}
			}
		}
		public sbyte4 yxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 3, 1));
				}
				else
				{
					return new sbyte4(y, x, w, y);
				}
			}
		}
		public sbyte4 yxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 3, 2));
				}
				else
				{
					return new sbyte4(y, x, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yxwz;
			}
		}
		public sbyte4 yxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 3, 3));
				}
				else
				{
					return new sbyte4(y, x, w, w);
				}
			}
		}
		public sbyte4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 0, 0));
				}
				else
				{
					return new sbyte4(y, y, x, x);
				}
			}
		}
		public sbyte4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 0, 1));
				}
				else
				{
					return new sbyte4(y, y, x, y);
				}
			}
		}
		public sbyte4 yyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 0, 2));
				}
				else
				{
					return new sbyte4(y, y, x, z);
				}
			}
		}
		public sbyte4 yyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 0, 3));
				}
				else
				{
					return new sbyte4(y, y, x, w);
				}
			}
		}
		public sbyte4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 1, 0));
				}
				else
				{
					return new sbyte4(y, y, y, x);
				}
			}
		}
		public sbyte4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 1, 1));
				}
				else
				{
					return new sbyte4(y, y, y, y);
				}
			}
		}
		public sbyte4 yyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 1, 2));
				}
				else
				{
					return new sbyte4(y, y, y, z);
				}
			}
		}
		public sbyte4 yyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 1, 3));
				}
				else
				{
					return new sbyte4(y, y, y, w);
				}
			}
		}
		public sbyte4 yyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 2, 0));
				}
				else
				{
					return new sbyte4(y, y, z, x);
				}
			}
		}
		public sbyte4 yyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 2, 1));
				}
				else
				{
					return new sbyte4(y, y, z, y);
				}
			}
		}
		public sbyte4 yyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 2, 2));
				}
				else
				{
					return new sbyte4(y, y, z, z);
				}
			}
		}
		public sbyte4 yyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 2, 3));
				}
				else
				{
					return new sbyte4(y, y, z, w);
				}
			}
		}
		public sbyte4 yywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 3, 0));
				}
				else
				{
					return new sbyte4(y, y, w, x);
				}
			}
		}
		public sbyte4 yywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 3, 1));
				}
				else
				{
					return new sbyte4(y, y, w, y);
				}
			}
		}
		public sbyte4 yywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 3, 2));
				}
				else
				{
					return new sbyte4(y, y, w, z);
				}
			}
		}
		public sbyte4 yyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 3, 3));
				}
				else
				{
					return new sbyte4(y, y, w, w);
				}
			}
		}
		public sbyte4 yzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 0, 0));
				}
				else
				{
					return new sbyte4(y, z, x, x);
				}
			}
		}
		public sbyte4 yzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 0, 1));
				}
				else
				{
					return new sbyte4(y, z, x, y);
				}
			}
		}
		public sbyte4 yzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 0, 2));
				}
				else
				{
					return new sbyte4(y, z, x, z);
				}
			}
		}
		public sbyte4 yzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 0, 3));
				}
				else
				{
					return new sbyte4(y, z, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zxyw;
			}
		}
		public sbyte4 yzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 1, 0));
				}
				else
				{
					return new sbyte4(y, z, y, x);
				}
			}
		}
		public sbyte4 yzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 1, 1));
				}
				else
				{
					return new sbyte4(y, z, y, y);
				}
			}
		}
		public sbyte4 yzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 1, 2));
				}
				else
				{
					return new sbyte4(y, z, y, z);
				}
			}
		}
		public sbyte4 yzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 1, 3));
				}
				else
				{
					return new sbyte4(y, z, y, w);
				}
			}
		}
		public sbyte4 yzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 2, 0));
				}
				else
				{
					return new sbyte4(y, z, z, x);
				}
			}
		}
		public sbyte4 yzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 2, 1));
				}
				else
				{
					return new sbyte4(y, z, z, y);
				}
			}
		}
		public sbyte4 yzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 2, 2));
				}
				else
				{
					return new sbyte4(y, z, z, z);
				}
			}
		}
		public sbyte4 yzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 2, 3));
				}
				else
				{
					return new sbyte4(y, z, z, w);
				}
			}
		}
		public sbyte4 yzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 3, 0));
				}
				else
				{
					return new sbyte4(y, z, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wxyz;
			}
		}
		public sbyte4 yzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 3, 1));
				}
				else
				{
					return new sbyte4(y, z, w, y);
				}
			}
		}
		public sbyte4 yzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 3, 2));
				}
				else
				{
					return new sbyte4(y, z, w, z);
				}
			}
		}
		public sbyte4 yzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 3, 3));
				}
				else
				{
					return new sbyte4(y, z, w, w);
				}
			}
		}
		public sbyte4 ywxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 0, 0));
				}
				else
				{
					return new sbyte4(y, w, x, x);
				}
			}
		}
		public sbyte4 ywxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 0, 1));
				}
				else
				{
					return new sbyte4(y, w, x, y);
				}
			}
		}
		public sbyte4 ywxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 0, 2));
				}
				else
				{
					return new sbyte4(y, w, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zxwy;
			}
		}
		public sbyte4 ywxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 0, 3));
				}
				else
				{
					return new sbyte4(y, w, x, w);
				}
			}
		}
		public sbyte4 ywyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 1, 0));
				}
				else
				{
					return new sbyte4(y, w, y, x);
				}
			}
		}
		public sbyte4 ywyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 1, 1));
				}
				else
				{
					return new sbyte4(y, w, y, y);
				}
			}
		}
		public sbyte4 ywyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 1, 2));
				}
				else
				{
					return new sbyte4(y, w, y, z);
				}
			}
		}
		public sbyte4 ywyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 1, 3));
				}
				else
				{
					return new sbyte4(y, w, y, w);
				}
			}
		}
		public sbyte4 ywzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 2, 0));
				}
				else
				{
					return new sbyte4(y, w, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wxzy;
			}
		}
		public sbyte4 ywzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 2, 1));
				}
				else
				{
					return new sbyte4(y, w, z, y);
				}
			}
		}
		public sbyte4 ywzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 2, 2));
				}
				else
				{
					return new sbyte4(y, w, z, z);
				}
			}
		}
		public sbyte4 ywzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 2, 3));
				}
				else
				{
					return new sbyte4(y, w, z, w);
				}
			}
		}
		public sbyte4 ywwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 3, 0));
				}
				else
				{
					return new sbyte4(y, w, w, x);
				}
			}
		}
		public sbyte4 ywwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 3, 1));
				}
				else
				{
					return new sbyte4(y, w, w, y);
				}
			}
		}
		public sbyte4 ywwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 3, 2));
				}
				else
				{
					return new sbyte4(y, w, w, z);
				}
			}
		}
		public sbyte4 ywww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 3, 3));
				}
				else
				{
					return new sbyte4(y, w, w, w);
				}
			}
		}
		public sbyte4 zxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 0, 0));
				}
				else
				{
					return new sbyte4(z, x, x, x);
				}
			}
		}
		public sbyte4 zxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 0, 1));
				}
				else
				{
					return new sbyte4(z, x, x, y);
				}
			}
		}
		public sbyte4 zxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 0, 2));
				}
				else
				{
					return new sbyte4(z, x, x, z);
				}
			}
		}
		public sbyte4 zxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 0, 3));
				}
				else
				{
					return new sbyte4(z, x, x, w);
				}
			}
		}
		public sbyte4 zxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 1, 0));
				}
				else
				{
					return new sbyte4(z, x, y, x);
				}
			}
		}
		public sbyte4 zxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 1, 1));
				}
				else
				{
					return new sbyte4(z, x, y, y);
				}
			}
		}
		public sbyte4 zxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 1, 2));
				}
				else
				{
					return new sbyte4(z, x, y, z);
				}
			}
		}
		public sbyte4 zxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 1, 3));
				}
				else
				{
					return new sbyte4(z, x, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yzxw;
			}
		}
		public sbyte4 zxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 2, 0));
				}
				else
				{
					return new sbyte4(z, x, z, x);
				}
			}
		}
		public sbyte4 zxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 2, 1));
				}
				else
				{
					return new sbyte4(z, x, z, y);
				}
			}
		}
		public sbyte4 zxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 2, 2));
				}
				else
				{
					return new sbyte4(z, x, z, z);
				}
			}
		}
		public sbyte4 zxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 2, 3));
				}
				else
				{
					return new sbyte4(z, x, z, w);
				}
			}
		}
		public sbyte4 zxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 3, 0));
				}
				else
				{
					return new sbyte4(z, x, w, x);
				}
			}
		}
		public sbyte4 zxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 3, 1));
				}
				else
				{
					return new sbyte4(z, x, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.ywxz;
			}
		}
		public sbyte4 zxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 3, 2));
				}
				else
				{
					return new sbyte4(z, x, w, z);
				}
			}
		}
		public sbyte4 zxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 3, 3));
				}
				else
				{
					return new sbyte4(z, x, w, w);
				}
			}
		}
		public sbyte4 zyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 0, 0));
				}
				else
				{
					return new sbyte4(z, y, x, x);
				}
			}
		}
		public sbyte4 zyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 0, 1));
				}
				else
				{
					return new sbyte4(z, y, x, y);
				}
			}
		}
		public sbyte4 zyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 0, 2));
				}
				else
				{
					return new sbyte4(z, y, x, z);
				}
			}
		}
		public sbyte4 zyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 0, 3));
				}
				else
				{
					return new sbyte4(z, y, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zyxw;
			}
		}
		public sbyte4 zyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 1, 0));
				}
				else
				{
					return new sbyte4(z, y, y, x);
				}
			}
		}
		public sbyte4 zyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 1, 1));
				}
				else
				{
					return new sbyte4(z, y, y, y);
				}
			}
		}
		public sbyte4 zyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 1, 2));
				}
				else
				{
					return new sbyte4(z, y, y, z);
				}
			}
		}
		public sbyte4 zyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 1, 3));
				}
				else
				{
					return new sbyte4(z, y, y, w);
				}
			}
		}
		public sbyte4 zyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 2, 0));
				}
				else
				{
					return new sbyte4(z, y, z, x);
				}
			}
		}
		public sbyte4 zyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 2, 1));
				}
				else
				{
					return new sbyte4(z, y, z, y);
				}
			}
		}
		public sbyte4 zyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 2, 2));
				}
				else
				{
					return new sbyte4(z, y, z, z);
				}
			}
		}
		public sbyte4 zyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 2, 3));
				}
				else
				{
					return new sbyte4(z, y, z, w);
				}
			}
		}
		public sbyte4 zywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 3, 0));
				}
				else
				{
					return new sbyte4(z, y, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wyxz;
			}
		}
		public sbyte4 zywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 3, 1));
				}
				else
				{
					return new sbyte4(z, y, w, y);
				}
			}
		}
		public sbyte4 zywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 3, 2));
				}
				else
				{
					return new sbyte4(z, y, w, z);
				}
			}
		}
		public sbyte4 zyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 3, 3));
				}
				else
				{
					return new sbyte4(z, y, w, w);
				}
			}
		}
		public sbyte4 zzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 0, 0));
				}
				else
				{
					return new sbyte4(z, z, x, x);
				}
			}
		}
		public sbyte4 zzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 0, 1));
				}
				else
				{
					return new sbyte4(z, z, x, y);
				}
			}
		}
		public sbyte4 zzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 0, 2));
				}
				else
				{
					return new sbyte4(z, z, x, z);
				}
			}
		}
		public sbyte4 zzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 0, 3));
				}
				else
				{
					return new sbyte4(z, z, x, w);
				}
			}
		}
		public sbyte4 zzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 1, 0));
				}
				else
				{
					return new sbyte4(z, z, y, x);
				}
			}
		}
		public sbyte4 zzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 1, 1));
				}
				else
				{
					return new sbyte4(z, z, y, y);
				}
			}
		}
		public sbyte4 zzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 1, 2));
				}
				else
				{
					return new sbyte4(z, z, y, z);
				}
			}
		}
		public sbyte4 zzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 1, 3));
				}
				else
				{
					return new sbyte4(z, z, y, w);
				}
			}
		}
		public sbyte4 zzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 2, 0));
				}
				else
				{
					return new sbyte4(z, z, z, x);
				}
			}
		}
		public sbyte4 zzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 2, 1));
				}
				else
				{
					return new sbyte4(z, z, z, y);
				}
			}
		}
		public sbyte4 zzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 2, 2));
				}
				else
				{
					return new sbyte4(z, z, z, z);
				}
			}
		}
		public sbyte4 zzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 2, 3));
				}
				else
				{
					return new sbyte4(z, z, z, w);
				}
			}
		}
		public sbyte4 zzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 3, 0));
				}
				else
				{
					return new sbyte4(z, z, w, x);
				}
			}
		}
		public sbyte4 zzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 3, 1));
				}
				else
				{
					return new sbyte4(z, z, w, y);
				}
			}
		}
		public sbyte4 zzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 3, 2));
				}
				else
				{
					return new sbyte4(z, z, w, z);
				}
			}
		}
		public sbyte4 zzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 3, 3));
				}
				else
				{
					return new sbyte4(z, z, w, w);
				}
			}
		}
		public sbyte4 zwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 3, 0, 0));
				}
				else
				{
					return new sbyte4(z, w, x, x);
				}
			}
		}
		public sbyte4 zwxy
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
					return new sbyte4(z, w, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zwxy;
			}
		}
		public sbyte4 zwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 3, 0, 2));
				}
				else
				{
					return new sbyte4(z, w, x, z);
				}
			}
		}
		public sbyte4 zwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 3, 0, 3));
				}
				else
				{
					return new sbyte4(z, w, xw);
				}
			}
		}
		public sbyte4 zwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 3, 1, 0));
				}
				else
				{
					return new sbyte4(z, w, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wzxy;
			}
		}
		public sbyte4 zwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 3, 1, 1));
				}
				else
				{
					return new sbyte4(z, w, y, y);
				}
			}
		}
		public sbyte4 zwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 3, 1, 2));
				}
				else
				{
					return new sbyte4(z, w, y, z);
				}
			}
		}
		public sbyte4 zwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 3, 1, 3));
				}
				else
				{
					return new sbyte4(z, w, y, w);
				}
			}
		}
		public sbyte4 zwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 3, 2, 0));
				}
				else
				{
					return new sbyte4(z, w, z, x);
				}
			}
		}
		public sbyte4 zwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 3, 2, 1));
				}
				else
				{
					return new sbyte4(z, w, z, y);
				}
			}
		}
		public sbyte4 zwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 3, 2, 2));
				}
				else
				{
					return new sbyte4(z, w, z, z);
				}
			}
		}
		public sbyte4 zwzw
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
					return new sbyte4(z, w, z, w);
				}
			}
		}
		public sbyte4 zwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 3, 3, 0));
				}
				else
				{
					return new sbyte4(z, w, w, x);
				}
			}
		}
		public sbyte4 zwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 3, 3, 1));
				}
				else
				{
					return new sbyte4(z, w, w, y);
				}
			}
		}
		public sbyte4 zwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 3, 3, 2));
				}
				else
				{
					return new sbyte4(z, w, w, z);
				}
			}
		}
		public sbyte4 zwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 3, 3, 3));
				}
				else
				{
					return new sbyte4(z, w, ww);
				}
			}
		}
		public sbyte4 wxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 0, 0));
				}
				else
				{
					return new sbyte4(w, x, x, x);
				}
			}
		}
		public sbyte4 wxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 0, 1));
				}
				else
				{
					return new sbyte4(w, x, x, y);
				}
			}
		}
		public sbyte4 wxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 0, 2));
				}
				else
				{
					return new sbyte4(w, x, x, z);
				}
			}
		}
		public sbyte4 wxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 0, 3));
				}
				else
				{
					return new sbyte4(w, x, x, w);
				}
			}
		}
		public sbyte4 wxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 1, 0));
				}
				else
				{
					return new sbyte4(w, x, y, x);
				}
			}
		}
		public sbyte4 wxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 1, 1));
				}
				else
				{
					return new sbyte4(w, x, y, y);
				}
			}
		}
		public sbyte4 wxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 1, 2));
				}
				else
				{
					return new sbyte4(w, x, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yzwx;
			}
		}
		public sbyte4 wxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 1, 3));
				}
				else
				{
					return new sbyte4(w, x, y, w);
				}
			}
		}
		public sbyte4 wxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 2, 0));
				}
				else
				{
					return new sbyte4(w, x, z, x);
				}
			}
		}
		public sbyte4 wxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 2, 1));
				}
				else
				{
					return new sbyte4(w, x, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.ywzx;
			}
		}
		public sbyte4 wxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 2, 2));
				}
				else
				{
					return new sbyte4(w, x, z, z);
				}
			}
		}
		public sbyte4 wxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 2, 3));
				}
				else
				{
					return new sbyte4(w, x, z, w);
				}
			}
		}
		public sbyte4 wxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 3, 0));
				}
				else
				{
					return new sbyte4(w, x, w, x);
				}
			}
		}
		public sbyte4 wxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 3, 1));
				}
				else
				{
					return new sbyte4(w, x, w, y);
				}
			}
		}
		public sbyte4 wxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 3, 2));
				}
				else
				{
					return new sbyte4(w, x, w, z);
				}
			}
		}
		public sbyte4 wxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 3, 3));
				}
				else
				{
					return new sbyte4(w, x, w, w);
				}
			}
		}
		public sbyte4 wyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 0, 0));
				}
				else
				{
					return new sbyte4(w, y, x, x);
				}
			}
		}
		public sbyte4 wyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 0, 1));
				}
				else
				{
					return new sbyte4(w, y, x, y);
				}
			}
		}
		public sbyte4 wyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 0, 2));
				}
				else
				{
					return new sbyte4(w, y, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zywx;
			}
		}
		public sbyte4 wyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 0, 3));
				}
				else
				{
					return new sbyte4(w, y, x, w);
				}
			}
		}
		public sbyte4 wyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 1, 0));
				}
				else
				{
					return new sbyte4(w, y, y, x);
				}
			}
		}
		public sbyte4 wyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 1, 1));
				}
				else
				{
					return new sbyte4(w, y, y, y);
				}
			}
		}
		public sbyte4 wyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 1, 2));
				}
				else
				{
					return new sbyte4(w, y, y, z);
				}
			}
		}
		public sbyte4 wyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 1, 3));
				}
				else
				{
					return new sbyte4(w, y, y, w);
				}
			}
		}
		public sbyte4 wyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 2, 0));
				}
				else
				{
					return new sbyte4(w, y, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wyzx;
			}
		}
		public sbyte4 wyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 2, 1));
				}
				else
				{
					return new sbyte4(w, y, z, y);
				}
			}
		}
		public sbyte4 wyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 2, 2));
				}
				else
				{
					return new sbyte4(w, y, z, z);
				}
			}
		}
		public sbyte4 wyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 2, 3));
				}
				else
				{
					return new sbyte4(w, y, z, w);
				}
			}
		}
		public sbyte4 wywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 3, 0));
				}
				else
				{
					return new sbyte4(w, y, w, x);
				}
			}
		}
		public sbyte4 wywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 3, 1));
				}
				else
				{
					return new sbyte4(w, y, w, y);
				}
			}
		}
		public sbyte4 wywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 3, 2));
				}
				else
				{
					return new sbyte4(w, y, w, z);
				}
			}
		}
		public sbyte4 wyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 3, 3));
				}
				else
				{
					return new sbyte4(w, y, w, w);
				}
			}
		}
		public sbyte4 wzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 0, 0));
				}
				else
				{
					return new sbyte4(w, z, x, x);
				}
			}
		}
		public sbyte4 wzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 0, 1));
				}
				else
				{
					return new sbyte4(w, z, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zwyx;
			}
		}
		public sbyte4 wzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 0, 2));
				}
				else
				{
					return new sbyte4(w, z, x, z);
				}
			}
		}
		public sbyte4 wzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 0, 3));
				}
				else
				{
					return new sbyte4(w, z, x, w);
				}
			}
		}
		public sbyte4 wzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 1, 0));
				}
				else
				{
					return new sbyte4(w, z, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wzyx;
			}
		}
		public sbyte4 wzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 1, 1));
				}
				else
				{
					return new sbyte4(w, z, y, y);
				}
			}
		}
		public sbyte4 wzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 1, 2));
				}
				else
				{
					return new sbyte4(w, z, y, z);
				}
			}
		}
		public sbyte4 wzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 1, 3));
				}
				else
				{
					return new sbyte4(w, z, y, w);
				}
			}
		}
		public sbyte4 wzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 2, 0));
				}
				else
				{
					return new sbyte4(w, z, z, x);
				}
			}
		}
		public sbyte4 wzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 2, 1));
				}
				else
				{
					return new sbyte4(w, z, z, y);
				}
			}
		}
		public sbyte4 wzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 2, 2));
				}
				else
				{
					return new sbyte4(w, z, z, z);
				}
			}
		}
		public sbyte4 wzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 2, 3));
				}
				else
				{
					return new sbyte4(w, z, z, w);
				}
			}
		}
		public sbyte4 wzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 3, 0));
				}
				else
				{
					return new sbyte4(w, z, w, x);
				}
			}
		}
		public sbyte4 wzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 3, 1));
				}
				else
				{
					return new sbyte4(w, z, w, y);
				}
			}
		}
		public sbyte4 wzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 3, 2));
				}
				else
				{
					return new sbyte4(w, z, w, z);
				}
			}
		}
		public sbyte4 wzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 3, 3));
				}
				else
				{
					return new sbyte4(w, z, w, w);
				}
			}
		}
		public sbyte4 wwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 0, 0));
				}
				else
				{
					return new sbyte4(w, w, x, x);
				}
			}
		}
		public sbyte4 wwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 0, 1));
				}
				else
				{
					return new sbyte4(w, w, x, y);
				}
			}
		}
		public sbyte4 wwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 0, 2));
				}
				else
				{
					return new sbyte4(w, w, x, z);
				}
			}
		}
		public sbyte4 wwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 0, 3));
				}
				else
				{
					return new sbyte4(w, w, x, w);
				}
			}
		}
		public sbyte4 wwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 1, 0));
				}
				else
				{
					return new sbyte4(w, w, y, x);
				}
			}
		}
		public sbyte4 wwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 1, 1));
				}
				else
				{
					return new sbyte4(w, w, y, y);
				}
			}
		}
		public sbyte4 wwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 1, 2));
				}
				else
				{
					return new sbyte4(w, w, y, z);
				}
			}
		}
		public sbyte4 wwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 1, 3));
				}
				else
				{
					return new sbyte4(w, w, y, w);
				}
			}
		}
		public sbyte4 wwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 2, 0));
				}
				else
				{
					return new sbyte4(w, w, z, x);
				}
			}
		}
		public sbyte4 wwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 2, 1));
				}
				else
				{
					return new sbyte4(w, w, z, y);
				}
			}
		}
		public sbyte4 wwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 2, 2));
				}
				else
				{
					return new sbyte4(w, w, z, z);
				}
			}
		}
		public sbyte4 wwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 2, 3));
				}
				else
				{
					return new sbyte4(w, w, z, w);
				}
			}
		}
		public sbyte4 wwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 3, 0));
				}
				else
				{
					return new sbyte4(w, w, w, x);
				}
			}
		}
		public sbyte4 wwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 3, 1));
				}
				else
				{
					return new sbyte4(w, w, w, y);
				}
			}
		}
		public sbyte4 wwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 3, 2));
				}
				else
				{
					return new sbyte4(w, w, w, z);
				}
			}
		}
		public sbyte4 wwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 3, 3));
				}
				else
				{
					return new sbyte4(w, w, w, w);
				}
			}
		}

		public sbyte3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 0, 0));
				}
				else
				{
					return new sbyte3(x, x, x);
				}
			}
		}
		public sbyte3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 1, 3));
				}
				else
				{
					return new sbyte3(x, x, y);
				}
			}
		}
		public sbyte3 xxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 2, 3));
				}
				else
				{
					return new sbyte3(x, x, z);
				}
			}
		}
		public sbyte3 xxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 3, 3));
				}
				else
				{
					return new sbyte3(x, x, w);
				}
			}
		}
		public sbyte3 xyx
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
					return new sbyte3(x, y, x);
				}
			}
		}
		public sbyte3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 1, 3));
				}
				else
				{
					return new sbyte3(x, y, y);
				}
			}
		}
		public sbyte3 xyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return (v128)this;
				}
				else
				{
					return new sbyte3(x, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value, new sbyte4(-1, -1, -1, 0));
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
					this.z = value.z;
				}
			}
		}
		public sbyte3 xyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 3, 3));
				}
				else
				{
					return new sbyte3(x, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.xyzz, new sbyte4(-1, -1, 0, -1));
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
					this.w = value.z;
				}
			}
		}
		public sbyte3 xzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 0, 3));
				}
				else
				{
					return new sbyte3(x, z, x);
				}
			}
		}
		public sbyte3 xzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 1, 3));
				}
				else
				{
					return new sbyte3(x, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.xzyy, new sbyte4(-1, -1, -1, 0));
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
					this.y = value.z;
				}
			}
		}
		public sbyte3 xzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 2, 3));
				}
				else
				{
					return new sbyte3(x, z, z);
				}
			}
		}
		public sbyte3 xzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 3, 3));
				}
				else
				{
					return new sbyte3(x, z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.xxyz, new sbyte4(-1, 0, -1, -1));
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
					this.w = value.z;
				}
			}
		}
		public sbyte3 xwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 0, 3));
				}
				else
				{
					return new sbyte3(x, w, x);
				}
			}
		}
		public sbyte3 xwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 1, 3));
				}
				else
				{
					return new sbyte3(x, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.xzzy, new sbyte4(-1, -1, 0, -1));
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
					this.y = value.z;
				}
			}
		}
		public sbyte3 xwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 2, 3));
				}
				else
				{
					return new sbyte3(x, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.xxzy, new sbyte4(-1, 0, -1, -1));
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
					this.z = value.z;
				}
			}
		}
		public sbyte3 xww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 3, 3));
				}
				else
				{
					return new sbyte3(x, w, w);
				}
			}
		}
		public sbyte3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 0, 3));
				}
				else
				{
					return new sbyte3(y, x, x);
				}
			}
		}
		public sbyte3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 1, 3));
				}
				else
				{
					return new sbyte3(y, x, y);
				}
			}
		}
		public sbyte3 yxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 2, 3));
				}
				else
				{
					return new sbyte3(y, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.yxzz, new sbyte4(-1, -1, -1, 0));
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
					this.z = value.z;
				}
			}
		}
		public sbyte3 yxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 3, 3));
				}
				else
				{
					return new sbyte3(y, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.yxzz, new sbyte4(-1, -1, 0, -1));
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
					this.w = value.z;
				}
			}
		}
		public sbyte3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 0, 3));
				}
				else
				{
					return new sbyte3(y, y, x);
				}
			}
		}
		public sbyte3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 1, 3));
				}
				else
				{
					return new sbyte3(y, y, y);
				}
			}
		}
		public sbyte3 yyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 2, 3));
				}
				else
				{
					return new sbyte3(y, y, z);
				}
			}
		}
		public sbyte3 yyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 3, 3));
				}
				else
				{
					return new sbyte3(y, y, w);
				}
			}
		}
		public sbyte3 yzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 0, 3));
				}
				else
				{
					return new sbyte3(y, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.zxyy, new sbyte4(-1, -1, -1, 0));
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
					this.x = value.z;
				}
			}
		}
		public sbyte3 yzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 1, 3));
				}
				else
				{
					return new sbyte3(y, z, y);
				}
			}
		}
		public sbyte3 yzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 2, 3));
				}
				else
				{
					return new sbyte3(y, z, z);
				}
			}
		}
		public sbyte3 yzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.bsrli_si128(this, sizeof(sbyte));
				}
				else
				{
					return new sbyte3(y, z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.xxyz, new sbyte4(0, -1, -1, -1));
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
					this.w = value.z;
				}
			}
		}
		public sbyte3 ywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 0, 3));
				}
				else
				{
					return new sbyte3(y, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.zxxy, new sbyte4(-1, -1, 0, -1));
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
					this.x = value.z;
				}
			}
		}
		public sbyte3 ywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 1, 3));
				}
				else
				{
					return new sbyte3(y, w, y);
				}
			}
		}
		public sbyte3 ywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 2, 3));
				}
				else
				{
					return new sbyte3(y, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.xxzy, new sbyte4(0, -1, -1, -1));
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
					this.z = value.z;
				}
			}
		}
		public sbyte3 yww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 3, 3));
				}
				else
				{
					return new sbyte3(y, w, w);
				}
			}
		}
		public sbyte3 zxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 0, 3));
				}
				else
				{
					return new sbyte3(z, x, x);
				}
			}
		}
		public sbyte3 zxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 1, 3));
				}
				else
				{
					return new sbyte3(z, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.yzxx, new sbyte4(-1, -1, -1, 0));
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
					this.y = value.z;
				}
			}
		}
		public sbyte3 zxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 2, 3));
				}
				else
				{
					return new sbyte3(z, x, z);
				}
			}
		}
		public sbyte3 zxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 3, 3));
				}
				else
				{
					return new sbyte3(z, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.yyxz, new sbyte4(-1, 0, -1, -1));
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
					this.w = value.z;
				}
			}
		}
		public sbyte3 zyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 0, 3));
				}
				else
				{
					return new sbyte3(z, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.zyxx, new sbyte4(-1, -1, -1, 0));
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
					this.x = value.z;
				}
			}
		}
		public sbyte3 zyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 1, 3));
				}
				else
				{
					return new sbyte3(z, y, y);
				}
			}
		}
		public sbyte3 zyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 2, 3));
				}
				else
				{
					return new sbyte3(z, y, z);
				}
			}
		}
		public sbyte3 zyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 3, 3));
				}
				else
				{
					return new sbyte3(z, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.yyxz, new sbyte4(0, -1, -1, -1));
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
					this.w = value.z;
				}
			}
		}
		public sbyte3 zzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 0, 3));
				}
				else
				{
					return new sbyte3(z, z, x);
				}
			}
		}
		public sbyte3 zzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 1, 3));
				}
				else
				{
					return new sbyte3(z, z, y);
				}
			}
		}
		public sbyte3 zzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 2, 3));
				}
				else
				{
					return new sbyte3(z, z, z);
				}
			}
		}
		public sbyte3 zzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 3, 3));
				}
				else
				{
					return new sbyte3(z, z, w);
				}
			}
		}
		public sbyte3 zwx
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
					return new sbyte3(z, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.zzxy, new sbyte4(-1, 0, -1, -1));
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
					this.x = value.z;
				}
			}
		}
		public sbyte3 zwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 3, 1, 3));
				}
				else
				{
					return new sbyte3(z, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.zzxy, new sbyte4(0, -1, -1, -1));
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
					this.y = value.z;
				}
			}
		}
		public sbyte3 zwz
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
					return new sbyte3(z, w, z);
				}
			}
		}
		public sbyte3 zww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 3, 3, 3));
				}
				else
				{
					return new sbyte3(z, w, w);
				}
			}
		}
		public sbyte3 wxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 0, 3));
				}
				else
				{
					return new sbyte3(w, x, x);
				}
			}
		}
		public sbyte3 wxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 1, 3));
				}
				else
				{
					return new sbyte3(w, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.yzzx, new sbyte4(-1, -1, 0, -1));
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
					this.y = value.z;
				}
			}
		}
		public sbyte3 wxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 2, 3));
				}
				else
				{
					return new sbyte3(w, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.yyzx, new sbyte4(-1, 0, -1, -1));
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
					this.z = value.z;
				}
			}
		}
		public sbyte3 wxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 3, 3));
				}
				else
				{
					return new sbyte3(w, x, w);
				}
			}
		}
		public sbyte3 wyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 0, 3));
				}
				else
				{
					return new sbyte3(w, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.zyyx, new sbyte4(-1, -1, 0, -1));
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
					this.x = value.z;
				}
			}
		}
		public sbyte3 wyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 1, 3));
				}
				else
				{
					return new sbyte3(w, y, y);
				}
			}
		}
		public sbyte3 wyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 2, 3));
				}
				else
				{
					return new sbyte3(w, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.yyzx, new sbyte4(0, -1, -1, -1));
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
					this.z = value.z;
				}
			}
		}
		public sbyte3 wyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 3, 3));
				}
				else
				{
					return new sbyte3(w, y, w);
				}
			}
		}
		public sbyte3 wzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 0, 3));
				}
				else
				{
					return new sbyte3(w, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.zzyx, new sbyte4(-1, 0, -1, -1));
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
					this.x = value.z;
				}
			}
		}
		public sbyte3 wzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 1, 3));
				}
				else
				{
					return new sbyte3(w, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.zzyx, new sbyte4(0, -1, -1, -1));
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
					this.y = value.z;
				}
			}
		}
		public sbyte3 wzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 2, 3));
				}
				else
				{
					return new sbyte3(w, z, z);
				}
			}
		}
		public sbyte3 wzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 3, 3));
				}
				else
				{
					return new sbyte3(w, z, w);
				}
			}
		}
		public sbyte3 wwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 0, 3));
				}
				else
				{
					return new sbyte3(w, w, x);
				}
			}
		}
		public sbyte3 wwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 1, 3));
				}
				else
				{
					return new sbyte3(w, w, y);
				}
			}
		}
		public sbyte3 wwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 2, 3));
				}
				else
				{
					return new sbyte3(w, w, z);
				}
			}
		}
		public sbyte3 www
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 3, 3));
				}
				else
				{
					return new sbyte3(w, w, w);
				}
			}
		}

		public sbyte2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 0, 0));
				}
				else
				{
					return new sbyte2(x, x);
				}
			}
		}
		public sbyte2 xy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return (v128)this;
				}
				else
				{
					return new sbyte2(x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value, 0b01);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value, 0b01);
					}
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
				}
			}
		}
		public sbyte2 xz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 3, 3));
				}
				else
				{
					return new sbyte2(x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.xxyy, new sbyte4(-1, 0, -1, 0));
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
				}
			}
		}
		public sbyte2 xw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(0, 3, 3, 3));
				}
				else
				{
					return new sbyte2(x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.xxyy, new sbyte4(-1, 0, 0, -1));
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
				}
			}
		}
		public sbyte2 yx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 3, 3));
				}
				else
				{
					return new sbyte2(y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.yx, 0b01);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.yx, 0b01);
					}
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
				}
			}
		}
		public sbyte2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 3, 3));
				}
				else
				{
					return new sbyte2(y, y);
				}
			}
		}
		public sbyte2 yz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.bsrli_si128(this, sizeof(sbyte));
				}
				else
				{
					return new sbyte2(y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.xxyy, new sbyte4(0, -1, -1, 0));
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
				}
			}
		}
		public sbyte2 yw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(1, 3, 3, 3));
				}
				else
				{
					return new sbyte2(y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.xxyy, new sbyte4(0, -1, 0, -1));
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
				}
			}
		}
		public sbyte2 zx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 3, 3));
				}
				else
				{
					return new sbyte2(z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.yyxx, new sbyte4(-1, 0, -1, 0));
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
				}
			}
		}
		public sbyte2 zy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 3, 3));
				}
				else
				{
					return new sbyte2(z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.yyxx, new sbyte4(0, -1, -1, 0));
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
				}
			}
		}
		public sbyte2 zz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 3, 3));
				}
				else
				{
					return new sbyte2(z, z);
				}
			}
		}
		public sbyte2 zw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.bsrli_si128(this, 2 * sizeof(sbyte));
				}
				else
				{
					return new sbyte2(z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Sse2.unpacklo_epi16(this, value);
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
				}
			}
		}
		public sbyte2 wx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 0, 3, 3));
				}
				else
				{
					return new sbyte2(w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.yyxx, new sbyte4(-1, 0, 0, -1));
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
				}
			}
		}
		public sbyte2 wy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 1, 3, 3));
				}
				else
				{
					return new sbyte2(w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Mask.BlendV(this, value.yyxx, new sbyte4(0, -1, 0, -1));
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
				}
			}
		}
		public sbyte2 wz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 2, 3, 3));
				}
				else
				{
					return new sbyte2(w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this = Sse4_1.blend_epi16(this, value.yxyx, 0b10);
					}
					else
					{
						this = Mask.BlendEpi16_SSE2(this, value.yxyx, 0b10);
					}
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
				}
			}
		}
		public sbyte2 ww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new sbyte4(3, 3, 3, 3));
				}
				else
				{
					return new sbyte2(w, w);
				}
			}
		}
		#endregion


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(sbyte4 input) => new v128(*(int*)&input, 0, 0, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte4(v128 input) { int x = input.SInt0; return *(sbyte4*)&x; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte4(sbyte input) => new sbyte4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(byte4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(sbyte4*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(short4 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.ShortToByte(input);
			}
			if (Sse2.IsSse2Supported)
			{
				return Cast.Short4To_S_Byte4_SSE2(input);
			}
			else
            {
                return new sbyte4((sbyte)input.x, (sbyte)input.y, (sbyte)input.z, (sbyte)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(ushort4 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.ShortToByte(input);
			}
			if (Sse2.IsSse2Supported)
			{
				return Cast.Short4To_S_Byte4_SSE2(input);
			}
			else
			{
				return new sbyte4((sbyte)input.x, (sbyte)input.y, (sbyte)input.z, (sbyte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(int4 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Int4ToByte4(*(v128*)&input);
			}
			else if (Sse2.IsSse2Supported)
			{
				return Cast.Int4To_S_Byte4_SSE2(*(v128*)&input);
			}
			else
			{
				return new sbyte4((sbyte)input.x, (sbyte)input.y, (sbyte)input.z, (sbyte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(uint4 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Int4ToByte4(*(v128*)&input);
			}
			else if (Sse2.IsSse2Supported)
			{
				return Cast.Int4To_S_Byte4_SSE2(*(v128*)&input);
			}
			else
			{
				return new sbyte4((sbyte)input.x, (sbyte)input.y, (sbyte)input.z, (sbyte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(long4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Cast.Long4ToByte4(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new sbyte4(Cast.Long2ToByte2(input._xy), Cast.Long2ToByte2(input._zw));
            }
            else
			{
				return new sbyte4((sbyte)input.x, (sbyte)input.y, (sbyte)input.z, (sbyte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(ulong4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Cast.Long4ToByte4(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new sbyte4(Cast.Long2ToByte2(input._xy), Cast.Long2ToByte2(input._zw));
            }
            else
			{
				return new sbyte4((sbyte)input.x, (sbyte)input.y, (sbyte)input.z, (sbyte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(half4 input) => (sbyte4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(float4 input) => (sbyte4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(double4 input) => (sbyte4)(int4)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4(sbyte4 input)
        {
			if (Sse2.IsSse2Supported)
			{
				return Cast.SByteToShort(input);
			}
            else
            {
                return new short4((short)input.x, (short)input.y, (short)input.z, (short)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(sbyte4 input)
        {
			if (Sse2.IsSse2Supported)
			{
				return Cast.SByteToShort(input);
			}
            else
            {
                return new ushort4((ushort)input.x, (ushort)input.y, (ushort)input.z, (ushort)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4(sbyte4 input)
        {
			if (Sse2.IsSse2Supported)
			{
				v128 temp = Cast.SByteToInt(input);

				return *(int4*)&temp;
            }
            else
            {
                return new int4((int)input.x, (int)input.y, (int)input.z, (int)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(sbyte4 input)
        {
			if (Sse2.IsSse2Supported)
			{
				v128 temp = Cast.SByteToInt(input);

				return *(uint4*)&temp;
            }
            else
            {
                return new uint4((uint)input.x, (uint)input.y, (uint)input.z, (uint)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(sbyte4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi8_epi64(input);
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
        public static explicit operator ulong4(sbyte4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi8_epi64(input);
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
        public static implicit operator half4(sbyte4 input) => (half4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(sbyte4 input) => (float4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(sbyte4 input) => (double4)(int4)input;


        public sbyte this[int index]
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
        public static sbyte4 operator + (sbyte4 left, sbyte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(left, right);
            }
            else
            {
                return new sbyte4((sbyte)(left.x + right.x), (sbyte)(left.y + right.y), (sbyte)(left.z + right.z), (sbyte)(left.w + right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator - (sbyte4 left, sbyte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(left, right);
            }
            else
            {
                return new sbyte4((sbyte)(left.x - right.x), (sbyte)(left.y - right.y), (sbyte)(left.z - right.z), (sbyte)(left.w - right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator * (sbyte4 left, sbyte4 right)
        {
            if (Sse2.IsSse2Supported)
			{
                return (sbyte4)((short4)left * (short4)right);
            }
            else
            {
                return new sbyte4((sbyte)(left.x * right.x), (sbyte)(left.y * right.y), (sbyte)(left.z * right.z), (sbyte)(left.w * right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator / (sbyte4 left, sbyte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vdiv_sbyte(left, right);
            }
            else
            {
                return new sbyte4((sbyte)(left.x / right.x), (sbyte)(left.y / right.y), (sbyte)(left.z / right.z), (sbyte)(left.w / right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator % (sbyte4 left, sbyte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vrem_sbyte(left, right);
            }
            else
            {
                return new sbyte4((sbyte)(left.x % right.x), (sbyte)(left.y % right.y), (sbyte)(left.z % right.z), (sbyte)(left.w % right.w));
            }
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator * (sbyte left, sbyte4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator * (sbyte4 left, sbyte right)
        {
			if (Sse2.IsSse2Supported)
			{
				if (Constant.IsConstantExpression(right))
				{
					return (v128)((sbyte16)((v128)left) * right);
				}
			}

			return left * (sbyte4)right;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator / (sbyte4 left, sbyte right)
        {
			if (Sse2.IsSse2Supported)
			{
				if (Constant.IsConstantExpression(right))
				{
					return (v128)((sbyte16)((v128)left) / right);
				}
			}

			return left / (sbyte4)right;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator % (sbyte4 left, sbyte right)
        {
			if (Sse2.IsSse2Supported)
			{
				if (Constant.IsConstantExpression(right))
				{
					return (v128)((sbyte16)((v128)left) % right);
				}
			}

			return left % (sbyte4)right;
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator & (sbyte4 left, sbyte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new sbyte4((sbyte)(left.x & right.x), (sbyte)(left.y & right.y), (sbyte)(left.z & right.z), (sbyte)(left.w & right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator | (sbyte4 left, sbyte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new sbyte4((sbyte)(left.x | right.x), (sbyte)(left.y | right.y), (sbyte)(left.z | right.z), (sbyte)(left.w | right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator ^ (sbyte4 left, sbyte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new sbyte4((sbyte)(left.x ^ right.x), (sbyte)(left.y ^ right.y), (sbyte)(left.z ^ right.z), (sbyte)(left.w ^ right.w));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator - (sbyte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(default(v128), x);
			}
            else
            {
                return new sbyte4((sbyte)-x.x, (sbyte)-x.y, (sbyte)-x.z, (sbyte)-x.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator ++ (sbyte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
			}
            else
            {
                return new sbyte4((sbyte)(x.x + 1), (sbyte)(x.y + 1), (sbyte)(x.z + 1), (sbyte)(x.w + 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator -- (sbyte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
			}
            else
            {
                return new sbyte4((sbyte)(x.x - 1), (sbyte)(x.y - 1), (sbyte)(x.z - 1), (sbyte)(x.w - 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator ~ (sbyte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
			}
            else
            {
                return new sbyte4((sbyte)(~x.x), (sbyte)(~x.y), (sbyte)(~x.z), (sbyte)(~x.w));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator << (sbyte4 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shl_byte(x, n);
            }
            else
            {
                return new sbyte4((sbyte)(x.x << n), (sbyte)(x.y << n), (sbyte)(x.z << n), (sbyte)(x.w << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator >> (sbyte4 x, int n)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return (sbyte4)((short4)x >> n);
            }
            else
            {
                return new sbyte4((sbyte)(x.x >> n), (sbyte)(x.y >> n), (sbyte)(x.z >> n), (sbyte)(x.w >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (sbyte4 left, sbyte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Sse2.cmpeq_epi8(left, right));
            }
            else
            {
                return new bool4(left.x == right.x, left.y == right.y, left.z == right.z, left.w == right.w);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (sbyte4 left, sbyte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Sse2.cmpgt_epi8(right, left));
            }
            else
            {
                return new bool4(left.x < right.x, left.y < right.y, left.z < right.z, left.w < right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (sbyte4 left, sbyte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Sse2.cmpgt_epi8(left, right));
            }
            else
            {
                return new bool4(left.x > right.x, left.y > right.y, left.z > right.z, left.w > right.w);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (sbyte4 left, sbyte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsFalse(Sse2.cmpeq_epi8(left, right));
            }
            else
            {
                return new bool4(left.x != right.x, left.y != right.y, left.z != right.z, left.w != right.w);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (sbyte4 left, sbyte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsFalse(Sse2.cmpgt_epi8(left, right));
            }
            else
            {
                return new bool4(left.x <= right.x, left.y <= right.y, left.z <= right.z, left.w <= right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (sbyte4 left, sbyte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsFalse(Sse2.cmpgt_epi8(right, left));
            }
            else
            {
                return new bool4(left.x >= right.x, left.y >= right.y, left.z >= right.z, left.w >= right.w);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsTrue(v128 input)
        {
            input = -((sbyte16)input);

			return *(bool4*)&input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsFalse(v128 input)
        {
			if (Sse2.IsSse2Supported)
			{
				input = Sse2.andnot_si128(input, new byte4(1));

				return *(bool4*)&input;
			}
			else throw new CPUFeatureCheckException();
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(sbyte4 other)
		{
			if (Sse2.IsSse2Supported)
			{
				return uint.MaxValue == Sse2.cmpeq_epi8(this, other).UInt0;

			}
			else
			{
				return (this.x == other.x & this.y == other.y) & (this.z == other.z & this.w == other.w);
			}
		}

        public override bool Equals(object obj) => Equals((sbyte4)obj);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			if (Sse2.IsSse2Supported)
			{
				return ((v128)this).SInt0;
			}
			else
			{
				sbyte4 temp = this;

				return *(int*)&temp;
			}
		}


        public override string ToString() => $"sbyte4({x}, {y}, {z}, {w})";
        public string ToString(string format, IFormatProvider formatProvider) => $"sbyte4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}