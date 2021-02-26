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
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 4 * sizeof(byte))]  [DebuggerTypeProxy(typeof(byte4.DebuggerProxy))]
    unsafe public struct byte4 : IEquatable<byte4>, IFormattable
	{
		internal sealed class DebuggerProxy
		{
			public byte x;
			public byte y;
			public byte z;
			public byte w;

			public DebuggerProxy(byte4 v)
			{
				x = v.x;
				y = v.y;
				z = v.z;
				w = v.w;
			}
		}


		[FieldOffset(0)] private fixed byte asArray[4];

        [FieldOffset(0)] public byte x;
        [FieldOffset(1)] public byte y;
        [FieldOffset(2)] public byte z;
        [FieldOffset(3)] public byte w;


        public static byte4 zero => default;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte x, byte y, byte z, byte w)
        {
            if (Sse2.IsSse2Supported)
			{
				this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (sbyte)w, (sbyte)z, (sbyte)y, (sbyte)x);
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
        public byte4(byte xyzw)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.set1_epi8((sbyte)xyzw);
			}
			else
			{
				this.x = this.y = this.z = this.w = xyzw;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte2 xy, byte z, byte w)
        {
            if (Sse2.IsSse2Supported)
            {
				this = Sse2.unpacklo_epi16(xy, new byte2(z, w));
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
        public byte4(byte x, byte2 yz, byte w)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (sbyte)w, (sbyte)yz.y, (sbyte)yz.x, (sbyte)x);
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
        public byte4(byte x, byte y, byte2 zw)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.unpacklo_epi16(new byte2(x, y), zw);
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
        public byte4(byte2 xy, byte2 zw)
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
        public byte4(byte3 xyz, byte w)
        {
			if (Sse4_1.IsSse41Supported)
			{
				this = Sse4_1.insert_epi8(xyz, w, 3);
			}
			else if (Sse2.IsSse2Supported)
			{
				this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (sbyte)w, (sbyte)xyz.z, (sbyte)xyz.y, (sbyte)xyz.x);
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
        public byte4(byte x, byte3 yzw)
        {
			if (Sse4_1.IsSse41Supported)
			{
				this = Sse4_1.insert_epi8(Sse2.bslli_si128(yzw, sizeof(byte)), x, 0);
			}
			else if (Sse2.IsSse2Supported)
			{
				this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (sbyte)yzw.z, (sbyte)yzw.y, (sbyte)yzw.x, (sbyte)x);
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
        public  byte4 xxxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 0, 0));
				}
				else
				{
					return new byte4(x, x, x, x);
				}
			}
		}
        public  byte4 xxxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 0, 1));
				}
				else
				{
					return new byte4(x, x, x, y);
				}
			}
		}
        public  byte4 xxxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 0, 2));
				}
				else
				{
					return new byte4(x, x, x, z);
				}
			}
		}
        public  byte4 xxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 0, 3));
				}
				else
				{
					return new byte4(x, x, x, w);
				}
			}
		}
        public  byte4 xxyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 1, 0));
				}
				else
				{
					return new byte4(x, x, y, x);
				}
			}
		}
        public  byte4 xxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 1, 1));
				}
				else
				{
					return new byte4(x, x, y, y);
				}
			}
		}
        public  byte4 xxyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 1, 2));
				}
				else
				{
					return new byte4(x, x, y, z);
				}
			}
		}
        public  byte4 xxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 1, 3));
				}
				else
				{
					return new byte4(x, x, y, w);
				}
			}
		}
        public  byte4 xxzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 2, 0));
				}
				else
				{
					return new byte4(x, x, z, x);
				}
			}
		}
        public  byte4 xxzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 2, 1));
				}
				else
				{
					return new byte4(x, x, z, y);
				}
			}
		}
        public  byte4 xxzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 2, 2));
				}
				else
				{
					return new byte4(x, x, z, z);
				}
			}
		}
        public  byte4 xxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 2, 3));
				}
				else
				{
					return new byte4(x, x, z, w);
				}
			}
		}
        public  byte4 xxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 3, 0));
				}
				else
				{
					return new byte4(x, x, w, x);
				}
			}
		}
        public  byte4 xxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 3, 1));
				}
				else
				{
					return new byte4(x, x, w, y);
				}
			}
		}
        public  byte4 xxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 3, 2));
				}
				else
				{
					return new byte4(x, x, w, z);
				}
			}
		}
        public  byte4 xxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 3, 3));
				}
				else
				{
					return new byte4(x, x, w, w);
				}
			}
		}
        public  byte4 xyxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 1, 0, 0));
				}
				else
				{
					return new byte4(x, y, x, x);
				}
			}
		}
        public  byte4 xyxy
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
					return new byte4(x, y, x, y);
				}
			}
		}
        public  byte4 xyxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 1, 0, 2));
				}
				else
				{
					return new byte4(x, y, x, z);
				}
			}
		}
        public  byte4 xyxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 1, 0, 3));
				}
				else
				{
					return new byte4(x, y, x, w);
				}
			}
		}
        public  byte4 xyyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 1, 1, 0));
				}
				else
				{
					return new byte4(x, y, y, x);
				}
			}
		}
        public  byte4 xyyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 1, 1, 1));
				}
				else
				{
					return new byte4(x, y, y, y);
				}
			}
		}
        public  byte4 xyyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 1, 1, 2));
				}
				else
				{
					return new byte4(x, y, y, z);
				}
			}
		}
        public  byte4 xyyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 1, 1, 3));
				}
				else
				{
					return new byte4(x, y, y, w);
				}
			}
		}
        public  byte4 xyzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 1, 2, 0));
				}
				else
				{
					return new byte4(x, y, z, x);
				}
			}
		}
        public  byte4 xyzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 1, 2, 1));
				}
				else
				{
					return new byte4(x, y, z, y);
				}
			}
		}
        public  byte4 xyzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 1, 2, 2));
				}
				else
				{
					return new byte4(x, y, z, z);
				}
			}
		}
        public  byte4 xywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 1, 3, 0));
				}
				else
				{
					return new byte4(x, y, w, x);
				}
			}
		}
        public  byte4 xywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 1, 3, 1));
				}
				else
				{
					return new byte4(x, y, w, y);
				}
			}
		}
        public          byte4 xywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 1, 3, 2));
				}
				else
				{
					return new byte4(x, y, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xywz;
			}
		}
        public  byte4 xyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 1, 3, 3));
				}
				else
				{
					return new byte4(x, y, w, w);
				}
			}
		}
        public  byte4 xzxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 0, 0));
				}
				else
				{
					return new byte4(x, z, x, x);
				}
			}
		}
        public  byte4 xzxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 0, 1));
				}
				else
				{
					return new byte4(x, z, x, y);
				}
			}
		}
        public  byte4 xzxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 0, 2));
				}
				else
				{
					return new byte4(x, z, x, z);
				}
			}
		}
        public  byte4 xzxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 0, 3));
				}
				else
				{
					return new byte4(x, z, x, w);
				}
			}
		}
        public  byte4 xzyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 1, 0));
				}
				else
				{
					return new byte4(x, z, y, x);
				}
			}
		}
        public  byte4 xzyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 1, 1));
				}
				else
				{
					return new byte4(x, z, y, y);
				}
			}
		}
        public  byte4 xzyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 1, 2));
				}
				else
				{
					return new byte4(x, z, y, z);
				}
			}
		}
        public          byte4 xzyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 1, 3));
				}
				else
				{
					return new byte4(x, z, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xzyw;
			}
		}
        public  byte4 xzzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 2, 0));
				}
				else
				{
					return new byte4(x, z, z, x);
				}
			}
		}
        public  byte4 xzzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 2, 1));
				}
				else
				{
					return new byte4(x, z, z, y);
				}
			}
		}
        public  byte4 xzzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 2, 2));
				}
				else
				{
					return new byte4(x, z, z, z);
				}
			}
		}
        public  byte4 xzzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 2, 3));
				}
				else
				{
					return new byte4(x, z, z, w);
				}
			}
		}
        public  byte4 xzwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 3, 0));
				}
				else
				{
					return new byte4(x, z, w, x);
				}
			}
		}
        public          byte4 xzwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 3, 1));
				}
				else
				{
					return new byte4(x, z, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xwyz;
			}
		}
        public  byte4 xzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 3, 2));
				}
				else
				{
					return new byte4(x, z, w, z);
				}
			}
		}
        public  byte4 xzww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 3, 3));
				}
				else
				{
					return new byte4(x, z, w, w);
				}
			}
		}
        public  byte4 xwxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 0, 0));
				}
				else
				{
					return new byte4(x, w, x, x);
				}
			}
		}
        public  byte4 xwxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 0, 1));
				}
				else
				{
					return new byte4(x, w, x, y);
				}
			}
		}
        public  byte4 xwxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 0, 2));
				}
				else
				{
					return new byte4(x, w, x, z);
				}
			}
		}
        public  byte4 xwxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 0, 3));
				}
				else
				{
					return new byte4(x, w, x, w);
				}
			}
		}
        public  byte4 xwyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 1, 0));
				}
				else
				{
					return new byte4(x, w, y, x);
				}
			}
		}
        public  byte4 xwyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 1, 1));
				}
				else
				{
					return new byte4(x, w, y, y);
				}
			}
		}
        public          byte4 xwyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 1, 2));
				}
				else
				{
					return new byte4(x, w, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xzwy;
			}
		}
        public  byte4 xwyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 1, 3));
				}
				else
				{
					return new byte4(x, w, y, w);
				}
			}
		}
        public  byte4 xwzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 2, 0));
				}
				else
				{
					return new byte4(x, w, z, x);
				}
			}
		}
        public          byte4 xwzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 2, 1));
				}
				else
				{
					return new byte4(x, w, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xwzy;
			}
		}
        public  byte4 xwzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 2, 2));
				}
				else
				{
					return new byte4(x, w, z, z);
				}
			}
		}
        public  byte4 xwzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 2, 3));
				}
				else
				{
					return new byte4(x, w, z, w);
				}
			}
		}
        public  byte4 xwwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 3, 0));
				}
				else
				{
					return new byte4(x, w, w, x);
				}
			}
		}
        public  byte4 xwwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 3, 1));
				}
				else
				{
					return new byte4(x, w, w, y);
				}
			}
		}
        public  byte4 xwwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 3, 2));
				}
				else
				{
					return new byte4(x, w, w, z);
				}
			}
		}
        public  byte4 xwww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 3, 3));
				}
				else
				{
					return new byte4(x, w, w, w);
				}
			}
		}
        public  byte4 yxxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 0, 0));
				}
				else
				{
					return new byte4(y, x, x, x);
				}
			}
		}
        public  byte4 yxxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 0, 1));
				}
				else
				{
					return new byte4(y, x, x, y);
				}
			}
		}
        public  byte4 yxxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 0, 2));
				}
				else
				{
					return new byte4(y, x, x, z);
				}
			}
		}
        public  byte4 yxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 0, 3));
				}
				else
				{
					return new byte4(y, x, x, w);
				}
			}
		}
        public  byte4 yxyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 1, 0));
				}
				else
				{
					return new byte4(y, x, y, x);
				}
			}
		}
        public  byte4 yxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 1, 1));
				}
				else
				{
					return new byte4(y, x, y, y);
				}
			}
		}
        public  byte4 yxyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 1, 2));
				}
				else
				{
					return new byte4(y, x, y, z);
				}
			}
		}
        public  byte4 yxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 1, 3));
				}
				else
				{
					return new byte4(y, x, y, w);
				}
			}
		}
        public  byte4 yxzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 2, 0));
				}
				else
				{
					return new byte4(y, x, z, x);
				}
			}
		}
        public  byte4 yxzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 2, 1));
				}
				else
				{
					return new byte4(y, x, z, y);
				}
			}
		}
        public  byte4 yxzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 2, 2));
				}
				else
				{
					return new byte4(y, x, z, z);
				}
			}
		}
        public          byte4 yxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 2, 3));
				}
				else
				{
					return new byte4(y, x, z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yxzw;
			}
		}
        public  byte4 yxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 3, 0));
				}
				else
				{
					return new byte4(y, x, w, x);
				}
			}
		}
        public  byte4 yxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 3, 1));
				}
				else
				{
					return new byte4(y, x, w, y);
				}
			}
		}
        public          byte4 yxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 3, 2));
				}
				else
				{
					return new byte4(y, x, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yxwz;
			}
		}
        public  byte4 yxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 3, 3));
				}
				else
				{
					return new byte4(y, x, w, w);
				}
			}
		}
        public  byte4 yyxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 0, 0));
				}
				else
				{
					return new byte4(y, y, x, x);
				}
			}
		}
        public  byte4 yyxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 0, 1));
				}
				else
				{
					return new byte4(y, y, x, y);
				}
			}
		}
        public  byte4 yyxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 0, 2));
				}
				else
				{
					return new byte4(y, y, x, z);
				}
			}
		}
        public  byte4 yyxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 0, 3));
				}
				else
				{
					return new byte4(y, y, x, w);
				}
			}
		}
        public  byte4 yyyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 1, 0));
				}
				else
				{
					return new byte4(y, y, y, x);
				}
			}
		}
        public  byte4 yyyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 1, 1));
				}
				else
				{
					return new byte4(y, y, y, y);
				}
			}
		}
        public  byte4 yyyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 1, 2));
				}
				else
				{
					return new byte4(y, y, y, z);
				}
			}
		}
        public  byte4 yyyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 1, 3));
				}
				else
				{
					return new byte4(y, y, y, w);
				}
			}
		}
        public  byte4 yyzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 2, 0));
				}
				else
				{
					return new byte4(y, y, z, x);
				}
			}
		}
        public  byte4 yyzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 2, 1));
				}
				else
				{
					return new byte4(y, y, z, y);
				}
			}
		}
        public  byte4 yyzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 2, 2));
				}
				else
				{
					return new byte4(y, y, z, z);
				}
			}
		}
        public  byte4 yyzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 2, 3));
				}
				else
				{
					return new byte4(y, y, z, w);
				}
			}
		}
        public  byte4 yywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 3, 0));
				}
				else
				{
					return new byte4(y, y, w, x);
				}
			}
		}
        public  byte4 yywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 3, 1));
				}
				else
				{
					return new byte4(y, y, w, y);
				}
			}
		}
        public  byte4 yywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 3, 2));
				}
				else
				{
					return new byte4(y, y, w, z);
				}
			}
		}
        public  byte4 yyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 3, 3));
				}
				else
				{
					return new byte4(y, y, w, w);
				}
			}
		}
        public  byte4 yzxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 0, 0));
				}
				else
				{
					return new byte4(y, z, x, x);
				}
			}
		}
        public  byte4 yzxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 0, 1));
				}
				else
				{
					return new byte4(y, z, x, y);
				}
			}
		}
        public  byte4 yzxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 0, 2));
				}
				else
				{
					return new byte4(y, z, x, z);
				}
			}
		}
        public          byte4 yzxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 0, 3));
				}
				else
				{
					return new byte4(y, z, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zxyw;
			}
		}
        public  byte4 yzyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 1, 0));
				}
				else
				{
					return new byte4(y, z, y, x);
				}
			}
		}
        public  byte4 yzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 1, 1));
				}
				else
				{
					return new byte4(y, z, y, y);
				}
			}
		}
        public  byte4 yzyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 1, 2));
				}
				else
				{
					return new byte4(y, z, y, z);
				}
			}
		}
        public  byte4 yzyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 1, 3));
				}
				else
				{
					return new byte4(y, z, y, w);
				}
			}
		}
        public  byte4 yzzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 2, 0));
				}
				else
				{
					return new byte4(y, z, z, x);
				}
			}
		}
        public  byte4 yzzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 2, 1));
				}
				else
				{
					return new byte4(y, z, z, y);
				}
			}
		}
        public  byte4 yzzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 2, 2));
				}
				else
				{
					return new byte4(y, z, z, z);
				}
			}
		}
        public  byte4 yzzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 2, 3));
				}
				else
				{
					return new byte4(y, z, z, w);
				}
			}
		}
        public          byte4 yzwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 3, 0));
				}
				else
				{
					return new byte4(y, z, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wxyz;
			}
		}
        public  byte4 yzwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 3, 1));
				}
				else
				{
					return new byte4(y, z, w, y);
				}
			}
		}
        public  byte4 yzwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 3, 2));
				}
				else
				{
					return new byte4(y, z, w, z);
				}
			}
		}
        public  byte4 yzww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 3, 3));
				}
				else
				{
					return new byte4(y, z, w, w);
				}
			}
		}
        public  byte4 ywxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 0, 0));
				}
				else
				{
					return new byte4(y, w, x, x);
				}
			}
		}
        public  byte4 ywxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 0, 1));
				}
				else
				{
					return new byte4(y, w, x, y);
				}
			}
		}
        public          byte4 ywxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 0, 2));
				}
				else
				{
					return new byte4(y, w, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zxwy;
			}
		}
        public  byte4 ywxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 0, 3));
				}
				else
				{
					return new byte4(y, w, x, w);
				}
			}
		}
        public  byte4 ywyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 1, 0));
				}
				else
				{
					return new byte4(y, w, y, x);
				}
			}
		}
        public  byte4 ywyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 1, 1));
				}
				else
				{
					return new byte4(y, w, y, y);
				}
			}
		}
        public  byte4 ywyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 1, 2));
				}
				else
				{
					return new byte4(y, w, y, z);
				}
			}
		}
        public  byte4 ywyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 1, 3));
				}
				else
				{
					return new byte4(y, w, y, w);
				}
			}
		}
        public          byte4 ywzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 2, 0));
				}
				else
				{
					return new byte4(y, w, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wxzy;
			}
		}
        public  byte4 ywzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 2, 1));
				}
				else
				{
					return new byte4(y, w, z, y);
				}
			}
		}
        public  byte4 ywzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 2, 2));
				}
				else
				{
					return new byte4(y, w, z, z);
				}
			}
		}
        public  byte4 ywzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 2, 3));
				}
				else
				{
					return new byte4(y, w, z, w);
				}
			}
		}
        public  byte4 ywwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 3, 0));
				}
				else
				{
					return new byte4(y, w, w, x);
				}
			}
		}
        public  byte4 ywwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 3, 1));
				}
				else
				{
					return new byte4(y, w, w, y);
				}
			}
		}
        public  byte4 ywwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 3, 2));
				}
				else
				{
					return new byte4(y, w, w, z);
				}
			}
		}
        public  byte4 ywww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 3, 3));
				}
				else
				{
					return new byte4(y, w, w, w);
				}
			}
		}
        public  byte4 zxxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 0, 0));
				}
				else
				{
					return new byte4(z, x, x, x);
				}
			}
		}
        public  byte4 zxxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 0, 1));
				}
				else
				{
					return new byte4(z, x, x, y);
				}
			}
		}
        public  byte4 zxxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 0, 2));
				}
				else
				{
					return new byte4(z, x, x, z);
				}
			}
		}
        public  byte4 zxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 0, 3));
				}
				else
				{
					return new byte4(z, x, x, w);
				}
			}
		}
        public  byte4 zxyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 1, 0));
				}
				else
				{
					return new byte4(z, x, y, x);
				}
			}
		}
        public  byte4 zxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 1, 1));
				}
				else
				{
					return new byte4(z, x, y, y);
				}
			}
		}
        public  byte4 zxyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 1, 2));
				}
				else
				{
					return new byte4(z, x, y, z);
				}
			}
		}
        public          byte4 zxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 1, 3));
				}
				else
				{
					return new byte4(z, x, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yzxw;
			}
		}
        public  byte4 zxzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 2, 0));
				}
				else
				{
					return new byte4(z, x, z, x);
				}
			}
		}
        public  byte4 zxzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 2, 1));
				}
				else
				{
					return new byte4(z, x, z, y);
				}
			}
		}
        public  byte4 zxzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 2, 2));
				}
				else
				{
					return new byte4(z, x, z, z);
				}
			}
		}
        public  byte4 zxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 2, 3));
				}
				else
				{
					return new byte4(z, x, z, w);
				}
			}
		}
        public  byte4 zxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 3, 0));
				}
				else
				{
					return new byte4(z, x, w, x);
				}
			}
		}
        public          byte4 zxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 3, 1));
				}
				else
				{
					return new byte4(z, x, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.ywxz;
			}
		}
        public  byte4 zxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 3, 2));
				}
				else
				{
					return new byte4(z, x, w, z);
				}
			}
		}
        public  byte4 zxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 3, 3));
				}
				else
				{
					return new byte4(z, x, w, w);
				}
			}
		}
        public  byte4 zyxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 0, 0));
				}
				else
				{
					return new byte4(z, y, x, x);
				}
			}
		}
        public  byte4 zyxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 0, 1));
				}
				else
				{
					return new byte4(z, y, x, y);
				}
			}
		}
        public  byte4 zyxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 0, 2));
				}
				else
				{
					return new byte4(z, y, x, z);
				}
			}
		}
        public          byte4 zyxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 0, 3));
				}
				else
				{
					return new byte4(z, y, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zyxw;
			}
		}
        public  byte4 zyyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 1, 0));
				}
				else
				{
					return new byte4(z, y, y, x);
				}
			}
		}
        public  byte4 zyyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 1, 1));
				}
				else
				{
					return new byte4(z, y, y, y);
				}
			}
		}
        public  byte4 zyyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 1, 2));
				}
				else
				{
					return new byte4(z, y, y, z);
				}
			}
		}
        public  byte4 zyyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 1, 3));
				}
				else
				{
					return new byte4(z, y, y, w);
				}
			}
		}
        public  byte4 zyzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 2, 0));
				}
				else
				{
					return new byte4(z, y, z, x);
				}
			}
		}
        public  byte4 zyzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 2, 1));
				}
				else
				{
					return new byte4(z, y, z, y);
				}
			}
		}
        public  byte4 zyzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 2, 2));
				}
				else
				{
					return new byte4(z, y, z, z);
				}
			}
		}
        public  byte4 zyzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 2, 3));
				}
				else
				{
					return new byte4(z, y, z, w);
				}
			}
		}
        public          byte4 zywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 3, 0));
				}
				else
				{
					return new byte4(z, y, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wyxz;
			}
		}
        public  byte4 zywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 3, 1));
				}
				else
				{
					return new byte4(z, y, w, y);
				}
			}
		}
        public  byte4 zywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 3, 2));
				}
				else
				{
					return new byte4(z, y, w, z);
				}
			}
		}
        public  byte4 zyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 3, 3));
				}
				else
				{
					return new byte4(z, y, w, w);
				}
			}
		}
        public  byte4 zzxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 0, 0));
				}
				else
				{
					return new byte4(z, z, x, x);
				}
			}
		}
        public  byte4 zzxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 0, 1));
				}
				else
				{
					return new byte4(z, z, x, y);
				}
			}
		}
        public  byte4 zzxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 0, 2));
				}
				else
				{
					return new byte4(z, z, x, z);
				}
			}
		}
        public  byte4 zzxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 0, 3));
				}
				else
				{
					return new byte4(z, z, x, w);
				}
			}
		}
        public  byte4 zzyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 1, 0));
				}
				else
				{
					return new byte4(z, z, y, x);
				}
			}
		}
        public  byte4 zzyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 1, 1));
				}
				else
				{
					return new byte4(z, z, y, y);
				}
			}
		}
        public  byte4 zzyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 1, 2));
				}
				else
				{
					return new byte4(z, z, y, z);
				}
			}
		}
        public  byte4 zzyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 1, 3));
				}
				else
				{
					return new byte4(z, z, y, w);
				}
			}
		}
        public  byte4 zzzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 2, 0));
				}
				else
				{
					return new byte4(z, z, z, x);
				}
			}
		}
        public  byte4 zzzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 2, 1));
				}
				else
				{
					return new byte4(z, z, z, y);
				}
			}
		}
        public  byte4 zzzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 2, 2));
				}
				else
				{
					return new byte4(z, z, z, z);
				}
			}
		}
        public  byte4 zzzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 2, 3));
				}
				else
				{
					return new byte4(z, z, z, w);
				}
			}
		}
        public  byte4 zzwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 3, 0));
				}
				else
				{
					return new byte4(z, z, w, x);
				}
			}
		}
        public  byte4 zzwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 3, 1));
				}
				else
				{
					return new byte4(z, z, w, y);
				}
			}
		}
        public  byte4 zzwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 3, 2));
				}
				else
				{
					return new byte4(z, z, w, z);
				}
			}
		}
        public  byte4 zzww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 3, 3));
				}
				else
				{
					return new byte4(z, z, w, w);
				}
			}
		}
        public  byte4 zwxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 3, 0, 0));
				}
				else
				{
					return new byte4(z, w, x, x);
				}
			}
		}
        public          byte4 zwxy
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
					return new byte4(z, w, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zwxy;
			}
		}
        public  byte4 zwxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 3, 0, 2));
				}
				else
				{
					return new byte4(z, w, x, z);
				}
			}
		}
        public  byte4 zwxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 3, 0, 3));
				}
				else
				{
					return new byte4(z, w, xw);
				}
			}
		}
        public          byte4 zwyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 3, 1, 0));
				}
				else
				{
					return new byte4(z, w, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wzxy;
			}
		}
        public  byte4 zwyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 3, 1, 1));
				}
				else
				{
					return new byte4(z, w, y, y);
				}
			}
		}
        public  byte4 zwyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 3, 1, 2));
				}
				else
				{
					return new byte4(z, w, y, z);
				}
			}
		}
        public  byte4 zwyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 3, 1, 3));
				}
				else
				{
					return new byte4(z, w, y, w);
				}
			}
		}
        public  byte4 zwzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 3, 2, 0));
				}
				else
				{
					return new byte4(z, w, z, x);
				}
			}
		}
        public  byte4 zwzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 3, 2, 1));
				}
				else
				{
					return new byte4(z, w, z, y);
				}
			}
		}
        public  byte4 zwzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 3, 2, 2));
				}
				else
				{
					return new byte4(z, w, z, z);
				}
			}
		}
        public  byte4 zwzw
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
					return new byte4(z, w, z, w);
				}
			}
		}
        public  byte4 zwwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 3, 3, 0));
				}
				else
				{
					return new byte4(z, w, w, x);
				}
			}
		}
        public  byte4 zwwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 3, 3, 1));
				}
				else
				{
					return new byte4(z, w, w, y);
				}
			}
		}
        public  byte4 zwwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 3, 3, 2));
				}
				else
				{
					return new byte4(z, w, w, z);
				}
			}
		}
        public  byte4 zwww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 3, 3, 3));
				}
				else
				{
					return new byte4(z, w, ww);
				}
			}
		}
        public  byte4 wxxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 0, 0));
				}
				else
				{
					return new byte4(w, x, x, x);
				}
			}
		}
        public  byte4 wxxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 0, 1));
				}
				else
				{
					return new byte4(w, x, x, y);
				}
			}
		}
        public  byte4 wxxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 0, 2));
				}
				else
				{
					return new byte4(w, x, x, z);
				}
			}
		}
        public  byte4 wxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 0, 3));
				}
				else
				{
					return new byte4(w, x, x, w);
				}
			}
		}
        public  byte4 wxyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 1, 0));
				}
				else
				{
					return new byte4(w, x, y, x);
				}
			}
		}
        public  byte4 wxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 1, 1));
				}
				else
				{
					return new byte4(w, x, y, y);
				}
			}
		}
        public          byte4 wxyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 1, 2));
				}
				else
				{
					return new byte4(w, x, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yzwx;
			}
		}
        public  byte4 wxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 1, 3));
				}
				else
				{
					return new byte4(w, x, y, w);
				}
			}
		}
        public  byte4 wxzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 2, 0));
				}
				else
				{
					return new byte4(w, x, z, x);
				}
			}
		}
        public          byte4 wxzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 2, 1));
				}
				else
				{
					return new byte4(w, x, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.ywzx;
			}
		}
        public  byte4 wxzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 2, 2));
				}
				else
				{
					return new byte4(w, x, z, z);
				}
			}
		}
        public  byte4 wxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 2, 3));
				}
				else
				{
					return new byte4(w, x, z, w);
				}
			}
		}
        public  byte4 wxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 3, 0));
				}
				else
				{
					return new byte4(w, x, w, x);
				}
			}
		}
        public  byte4 wxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 3, 1));
				}
				else
				{
					return new byte4(w, x, w, y);
				}
			}
		}
        public  byte4 wxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 3, 2));
				}
				else
				{
					return new byte4(w, x, w, z);
				}
			}
		}
        public  byte4 wxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 3, 3));
				}
				else
				{
					return new byte4(w, x, w, w);
				}
			}
		}
        public  byte4 wyxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 0, 0));
				}
				else
				{
					return new byte4(w, y, x, x);
				}
			}
		}
        public  byte4 wyxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 0, 1));
				}
				else
				{
					return new byte4(w, y, x, y);
				}
			}
		}
        public          byte4 wyxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 0, 2));
				}
				else
				{
					return new byte4(w, y, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zywx;
			}
		}
        public  byte4 wyxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 0, 3));
				}
				else
				{
					return new byte4(w, y, x, w);
				}
			}
		}
        public  byte4 wyyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 1, 0));
				}
				else
				{
					return new byte4(w, y, y, x);
				}
			}
		}
        public  byte4 wyyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 1, 1));
				}
				else
				{
					return new byte4(w, y, y, y);
				}
			}
		}
        public  byte4 wyyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 1, 2));
				}
				else
				{
					return new byte4(w, y, y, z);
				}
			}
		}
        public  byte4 wyyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 1, 3));
				}
				else
				{
					return new byte4(w, y, y, w);
				}
			}
		}
        public          byte4 wyzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 2, 0));
				}
				else
				{
					return new byte4(w, y, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wyzx;
			}
		}
        public  byte4 wyzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 2, 1));
				}
				else
				{
					return new byte4(w, y, z, y);
				}
			}
		}
        public  byte4 wyzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 2, 2));
				}
				else
				{
					return new byte4(w, y, z, z);
				}
			}
		}
        public  byte4 wyzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 2, 3));
				}
				else
				{
					return new byte4(w, y, z, w);
				}
			}
		}
        public  byte4 wywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 3, 0));
				}
				else
				{
					return new byte4(w, y, w, x);
				}
			}
		}
        public  byte4 wywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 3, 1));
				}
				else
				{
					return new byte4(w, y, w, y);
				}
			}
		}
        public  byte4 wywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 3, 2));
				}
				else
				{
					return new byte4(w, y, w, z);
				}
			}
		}
        public  byte4 wyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 3, 3));
				}
				else
				{
					return new byte4(w, y, w, w);
				}
			}
		}
        public  byte4 wzxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 0, 0));
				}
				else
				{
					return new byte4(w, z, x, x);
				}
			}
		}
        public          byte4 wzxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 0, 1));
				}
				else
				{
					return new byte4(w, z, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zwyx;
			}
		}
        public  byte4 wzxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 0, 2));
				}
				else
				{
					return new byte4(w, z, x, z);
				}
			}
		}
        public  byte4 wzxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 0, 3));
				}
				else
				{
					return new byte4(w, z, x, w);
				}
			}
		}
        public          byte4 wzyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 1, 0));
				}
				else
				{
					return new byte4(w, z, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wzyx;
			}
		}
        public  byte4 wzyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 1, 1));
				}
				else
				{
					return new byte4(w, z, y, y);
				}
			}
		}
        public  byte4 wzyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 1, 2));
				}
				else
				{
					return new byte4(w, z, y, z);
				}
			}
		}
        public  byte4 wzyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 1, 3));
				}
				else
				{
					return new byte4(w, z, y, w);
				}
			}
		}
        public  byte4 wzzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 2, 0));
				}
				else
				{
					return new byte4(w, z, z, x);
				}
			}
		}
        public  byte4 wzzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 2, 1));
				}
				else
				{
					return new byte4(w, z, z, y);
				}
			}
		}
        public  byte4 wzzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 2, 2));
				}
				else
				{
					return new byte4(w, z, z, z);
				}
			}
		}
        public  byte4 wzzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 2, 3));
				}
				else
				{
					return new byte4(w, z, z, w);
				}
			}
		}
        public  byte4 wzwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 3, 0));
				}
				else
				{
					return new byte4(w, z, w, x);
				}
			}
		}
        public  byte4 wzwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 3, 1));
				}
				else
				{
					return new byte4(w, z, w, y);
				}
			}
		}
        public  byte4 wzwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 3, 2));
				}
				else
				{
					return new byte4(w, z, w, z);
				}
			}
		}
        public  byte4 wzww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 3, 3));
				}
				else
				{
					return new byte4(w, z, w, w);
				}
			}
		}
        public  byte4 wwxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 0, 0));
				}
				else
				{
					return new byte4(w, w, x, x);
				}
			}
		}
        public  byte4 wwxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 0, 1));
				}
				else
				{
					return new byte4(w, w, x, y);
				}
			}
		}
        public  byte4 wwxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 0, 2));
				}
				else
				{
					return new byte4(w, w, x, z);
				}
			}
		}
        public  byte4 wwxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 0, 3));
				}
				else
				{
					return new byte4(w, w, x, w);
				}
			}
		}
        public  byte4 wwyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 1, 0));
				}
				else
				{
					return new byte4(w, w, y, x);
				}
			}
		}
        public  byte4 wwyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 1, 1));
				}
				else
				{
					return new byte4(w, w, y, y);
				}
			}
		}
        public  byte4 wwyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 1, 2));
				}
				else
				{
					return new byte4(w, w, y, z);
				}
			}
		}
        public  byte4 wwyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 1, 3));
				}
				else
				{
					return new byte4(w, w, y, w);
				}
			}
		}
        public  byte4 wwzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 2, 0));
				}
				else
				{
					return new byte4(w, w, z, x);
				}
			}
		}
        public  byte4 wwzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 2, 1));
				}
				else
				{
					return new byte4(w, w, z, y);
				}
			}
		}
        public  byte4 wwzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 2, 2));
				}
				else
				{
					return new byte4(w, w, z, z);
				}
			}
		}
        public  byte4 wwzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 2, 3));
				}
				else
				{
					return new byte4(w, w, z, w);
				}
			}
		}
        public  byte4 wwwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 3, 0));
				}
				else
				{
					return new byte4(w, w, w, x);
				}
			}
		}
        public  byte4 wwwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 3, 1));
				}
				else
				{
					return new byte4(w, w, w, y);
				}
			}
		}
        public  byte4 wwwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 3, 2));
				}
				else
				{
					return new byte4(w, w, w, z);
				}
			}
		}
        public  byte4 wwww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 3, 3));
				}
				else
				{
					return new byte4(w, w, w, w);
				}
			}
		}

        public  byte3 xxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 0, 0));
				}
				else
				{
					return new byte3(x, x, x);
				}
			}
		}
        public  byte3 xxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 1, 3));
				}
				else
				{
					return new byte3(x, x, y);
				}
			}
		}
        public  byte3 xxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 2, 3));
				}
				else
				{
					return new byte3(x, x, z);
				}
			}
		}
        public  byte3 xxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 3, 3));
				}
				else
				{
					return new byte3(x, x, w);
				}
			}
		}
        public  byte3 xyx
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
					return new byte3(x, y, x);
				}
			}
		}
        public  byte3 xyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 1, 1, 3));
				}
				else
				{
					return new byte3(x, y, y);
				}
			}
		}
        public          byte3 xyz
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
					return new byte3(x, y, z);
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
        public          byte3 xyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 1, 3, 3));
				}
				else
				{
					return new byte3(x, y, w);
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
        public  byte3 xzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 0, 3));
				}
				else
				{
					return new byte3(x, z, x);
				}
			}
		}
        public          byte3 xzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 1, 3));
				}
				else
				{
					return new byte3(x, z, y);
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
        public  byte3 xzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 2, 3));
				}
				else
				{
					return new byte3(x, z, z);
				}
			}
		}
        public          byte3 xzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 3, 3));
				}
				else
				{
					return new byte3(x, z, w);
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
        public  byte3 xwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 0, 3));
				}
				else
				{
					return new byte3(x, w, x);
				}
			}
		}
        public          byte3 xwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 1, 3));
				}
				else
				{
					return new byte3(x, w, y);
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
        public          byte3 xwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 2, 3));
				}
				else
				{
					return new byte3(x, w, z);
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
        public  byte3 xww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 3, 3));
				}
				else
				{
					return new byte3(x, w, w);
				}
			}
		}
        public  byte3 yxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 0, 3));
				}
				else
				{
					return new byte3(y, x, x);
				}
			}
		}
        public  byte3 yxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 1, 3));
				}
				else
				{
					return new byte3(y, x, y);
				}
			}
		}
        public          byte3 yxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 2, 3));
				}
				else
				{
					return new byte3(y, x, z);
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
        public          byte3 yxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 3, 3));
				}
				else
				{
					return new byte3(y, x, w);
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
        public  byte3 yyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 0, 3));
				}
				else
				{
					return new byte3(y, y, x);
				}
			}
		}
        public  byte3 yyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 1, 3));
				}
				else
				{
					return new byte3(y, y, y);
				}
			}
		}
        public  byte3 yyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 2, 3));
				}
				else
				{
					return new byte3(y, y, z);
				}
			}
		}
        public  byte3 yyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 3, 3));
				}
				else
				{
					return new byte3(y, y, w);
				}
			}
		}
        public          byte3 yzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 0, 3));
				}
				else
				{
					return new byte3(y, z, x);
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
        public  byte3 yzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 1, 3));
				}
				else
				{
					return new byte3(y, z, y);
				}
			}
		}
        public  byte3 yzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 2, 2, 3));
				}
				else
				{
					return new byte3(y, z, z);
				}
			}
		}
        public          byte3 yzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.bsrli_si128(this, sizeof(byte));
				}
				else
				{
					return new byte3(y, z, w);
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
        public          byte3 ywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 0, 3));
				}
				else
				{
					return new byte3(y, w, x);
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
        public  byte3 ywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 1, 3));
				}
				else
				{
					return new byte3(y, w, y);
				}
			}
		}
        public          byte3 ywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 2, 3));
				}
				else
				{
					return new byte3(y, w, z);
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
        public  byte3 yww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 3, 3));
				}
				else
				{
					return new byte3(y, w, w);
				}
			}
		}
        public  byte3 zxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 0, 3));
				}
				else
				{
					return new byte3(z, x, x);
				}
			}
		}
        public          byte3 zxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 1, 3));
				}
				else
				{
					return new byte3(z, x, y);
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
        public  byte3 zxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 2, 3));
				}
				else
				{
					return new byte3(z, x, z);
				}
			}
		}
        public          byte3 zxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 3, 3));
				}
				else
				{
					return new byte3(z, x, w);
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
        public          byte3 zyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 0, 3));
				}
				else
				{
					return new byte3(z, y, x);
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
        public  byte3 zyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 1, 3));
				}
				else
				{
					return new byte3(z, y, y);
				}
			}
		}
        public  byte3 zyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 2, 3));
				}
				else
				{
					return new byte3(z, y, z);
				}
			}
		}
        public          byte3 zyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 3, 3));
				}
				else
				{
					return new byte3(z, y, w);
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
        public  byte3 zzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 0, 3));
				}
				else
				{
					return new byte3(z, z, x);
				}
			}
		}
        public  byte3 zzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 1, 3));
				}
				else
				{
					return new byte3(z, z, y);
				}
			}
		}
        public  byte3 zzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 2, 3));
				}
				else
				{
					return new byte3(z, z, z);
				}
			}
		}
        public  byte3 zzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 3, 3));
				}
				else
				{
					return new byte3(z, z, w);
				}
			}
		}
        public          byte3 zwx
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
					return new byte3(z, w, x);
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
        public          byte3 zwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 3, 1, 3));
				}
				else
				{
					return new byte3(z, w, y);
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
        public  byte3 zwz
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
					return new byte3(z, w, z);
				}
			}
		}
        public  byte3 zww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 3, 3, 3));
				}
				else
				{
					return new byte3(z, w, w);
				}
			}
		}
        public  byte3 wxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 0, 3));
				}
				else
				{
					return new byte3(w, x, x);
				}
			}
		}
        public          byte3 wxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 1, 3));
				}
				else
				{
					return new byte3(w, x, y);
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
        public          byte3 wxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 2, 3));
				}
				else
				{
					return new byte3(w, x, z);
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
        public  byte3 wxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 3, 3));
				}
				else
				{
					return new byte3(w, x, w);
				}
			}
		}
        public          byte3 wyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 0, 3));
				}
				else
				{
					return new byte3(w, y, x);
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
        public  byte3 wyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 1, 3));
				}
				else
				{
					return new byte3(w, y, y);
				}
			}
        }
        public          byte3 wyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 2, 3));
				}
				else
				{
					return new byte3(w, y, z);
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
        public  byte3 wyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 3, 3));
				}
				else
				{
					return new byte3(w, y, w);
				}
			}
        }
        public          byte3 wzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 0, 3));
				}
				else
				{
					return new byte3(w, z, x);
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
        public          byte3 wzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 1, 3));
				}
				else
				{
					return new byte3(w, z, y);
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
        public  byte3 wzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 2, 3));
				}
				else
				{
					return new byte3(w, z, z);
				}
			}
        }
        public  byte3 wzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 3, 3));
				}
				else
				{
					return new byte3(w, z, w);
				}
			}
        }
        public  byte3 wwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 0, 3));
				}
				else
				{
					return new byte3(w, w, x);
				}
			}
        }
        public  byte3 wwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 1, 3));
				}
				else
				{
					return new byte3(w, w, y);
				}
			}
        }
        public  byte3 wwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 2, 3));
				}
				else
				{
					return new byte3(w, w, z);
				}
			}
        }
        public  byte3 www
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 3, 3));
				}
				else
				{
					return new byte3(w, w, w);
				}
			}
        }

        public  byte2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 0, 0, 0));
				}
				else
				{
					return new byte2(x, x);
				}
			}
		}
        public          byte2 xy
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
					return new byte2(x, y);
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
        public          byte2 xz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 2, 3, 3));
				}
				else
				{
					return new byte2(x, z);
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
        public          byte2 xw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(0, 3, 3, 3));
				}
				else
				{
					return new byte2(x, w);
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
        public          byte2 yx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 0, 3, 3));
				}
				else
				{
					return new byte2(y, x);
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
        public  byte2 yy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 1, 3, 3));
				}
				else
				{
					return new byte2(y, y);
				}
			}
        }
        public          byte2 yz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.bsrli_si128(this, sizeof(byte));
				}
				else
				{
					return new byte2(y, z);
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
        public          byte2 yw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(1, 3, 3, 3));
				}
				else
				{
					return new byte2(y, w);
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
        public          byte2 zx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 0, 3, 3));
				}
				else
				{
					return new byte2(z, x);
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
        public          byte2 zy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 1, 3, 3));
				}
				else
				{
					return new byte2(z, y);
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
        public  byte2 zz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(2, 2, 3, 3));
				}
				else
				{
					return new byte2(z, z);
				}
			}
        }
        public          byte2 zw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Sse2.IsSse2Supported)
				{
					return Sse2.bsrli_si128(this, 2 * sizeof(byte));
				}
				else
				{
					return new byte2(z, w);
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
        public          byte2 wx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 0, 3, 3));
				}
				else
				{
					return new byte2(w, x);
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
        public          byte2 wy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 1, 3, 3));
				}
				else
				{
					return new byte2(w, y);
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
        public          byte2 wz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 2, 3, 3));
				}
				else
				{
					return new byte2(w, z);
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
        public  byte2 ww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Ssse3.IsSsse3Supported)
				{
					return Ssse3.shuffle_epi8(this, new byte4(3, 3, 3, 3));
				}
				else
                {
					return new byte2(w, w);
                }
			}
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(byte4 input) => new v128(*(int*)&input, 0, 0, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte4(v128 input) { int x = input.SInt0; return *(byte4*)&x; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte4(byte input) => new byte4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(sbyte4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(byte4*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(short4 input)
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
                return new byte4((byte)input.x, (byte)input.y, (byte)input.z, (byte)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(ushort4 input)
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
				return new byte4((byte)input.x, (byte)input.y, (byte)input.z, (byte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(int4 input)
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
				return new byte4((byte)input.x, (byte)input.y, (byte)input.z, (byte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(uint4 input)
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
				return new byte4((byte)input.x, (byte)input.y, (byte)input.z, (byte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(long4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Cast.Long4ToByte4(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new byte4(Cast.Long2ToByte2(input._xy), Cast.Long2ToByte2(input._zw));
            }
            else
			{
				return new byte4((byte)input.x, (byte)input.y, (byte)input.z, (byte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(ulong4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Cast.Long4ToByte4(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new byte4(Cast.Long2ToByte2(input._xy), Cast.Long2ToByte2(input._zw));
            }
            else
			{
				return new byte4((byte)input.x, (byte)input.y, (byte)input.z, (byte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(half4 input) => (byte4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(float4 input) => (byte4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(double4 input) => (byte4)(int4)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4(byte4 input)
        {
			if (Sse2.IsSse2Supported)
			{
				return Cast.ByteToShort(input);
			}
            else
            {
                return new short4((short)input.x, (short)input.y, (short)input.z, (short)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort4(byte4 input)
        {
			if (Sse2.IsSse2Supported)
			{
				return Cast.ByteToShort(input);
			}
            else
            {
                return new ushort4((ushort)input.x, (ushort)input.y, (ushort)input.z, (ushort)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4(byte4 input)
        {
			if (Sse2.IsSse2Supported)
			{
				v128 temp = Cast.ByteToInt(input);

				return *(int4*)&temp;
            }
            else
            {
                return new int4((int)input.x, (int)input.y, (int)input.z, (int)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4(byte4 input)
        {
			if (Sse2.IsSse2Supported)
			{
				v128 temp = Cast.ByteToInt(input);

				return *(uint4*)&temp;
            }
            else
            {
                return new uint4((uint)input.x, (uint)input.y, (uint)input.z, (uint)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(byte4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu8_epi64(input);
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
        public static implicit operator ulong4(byte4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu8_epi64(input);
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
        public static implicit operator half4(byte4 input) => (half4)(float4)input;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4(byte4 input)
		{
			if (Sse4_1.IsSse41Supported)
			{
				v128 temp = Cast.ByteToFloat(input);

				return *(float4*)&temp;
			}
			else
			{
				return (float4)(int4)input;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(byte4 input) => (double4)(int4)input;


        public byte this[int index]
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
        public static byte4 operator + (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(left, right);
            }
            else
            {
                return new byte4((byte)(left.x + right.x), (byte)(left.y + right.y), (byte)(left.z + right.z), (byte)(left.w + right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator - (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(left, right);
            }
            else
            {
                return new byte4((byte)(left.x - right.x), (byte)(left.y - right.y), (byte)(left.z - right.z), (byte)(left.w - right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator * (byte4 left, byte4 right)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return (byte4)((ushort4)left * (ushort4)right);
            }
            else
            {
                return new byte4((byte)(left.x * right.x), (byte)(left.y * right.y), (byte)(left.z * right.z), (byte)(left.w * right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator / (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vdiv_byte(left, right);
            }
            else
            {
                return new byte4((byte)(left.x / right.x), (byte)(left.y / right.y), (byte)(left.z / right.z), (byte)(left.w / right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator % (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vrem_byte(left, right);
            }
            else
            {
                return new byte4((byte)(left.x % right.x), (byte)(left.y % right.y), (byte)(left.z % right.z), (byte)(left.w % right.w));
            }
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator * (byte left, byte4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator * (byte4 left, byte right)
        {
            return new byte4((byte)(left.x * right), (byte)(left.y * right), (byte)(left.z * right), (byte)(left.w * right));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator / (byte4 left, byte right)
        {
            return new byte4((byte)(left.x / right), (byte)(left.y / right), (byte)(left.z / right), (byte)(left.w / right));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator % (byte4 left, byte right)
        {
            return new byte4((byte)(left.x % right), (byte)(left.y % right), (byte)(left.z % right), (byte)(left.w % right));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator & (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new byte4((byte)(left.x & right.x), (byte)(left.y & right.y), (byte)(left.z & right.z), (byte)(left.w & right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator | (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new byte4((byte)(left.x | right.x), (byte)(left.y | right.y), (byte)(left.z | right.z), (byte)(left.w | right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator ^ (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new byte4((byte)(left.x ^ right.x), (byte)(left.y ^ right.y), (byte)(left.z ^ right.z), (byte)(left.w ^ right.w));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator ++ (byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(x, new byte4(1));
            }
            else
            {
                return new byte4((byte)(x.x + 1), (byte)(x.y + 1), (byte)(x.z + 1), (byte)(x.w + 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator -- (byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(x, new byte4(1));
            }
            else
            {
                return new byte4((byte)(x.x - 1), (byte)(x.y - 1), (byte)(x.z - 1), (byte)(x.w - 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator ~ (byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(x, new sbyte4(-1));
            }
            else
            {
                return new byte4((byte)(~x.x), (byte)(~x.y), (byte)(~x.z), (byte)(~x.w));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator << (byte4 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shl_byte(x, n);
            }
            else
            {
                return new byte4((byte)(x.x << n), (byte)(x.y << n), (byte)(x.z << n), (byte)(x.w << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator >> (byte4 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shrl_byte(x, n);
            }
            else
            {
                return new byte4((byte)(x.x >> n), (byte)(x.y >> n), (byte)(x.z >> n), (byte)(x.w >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (byte4 left, byte4 right)
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
        public static bool4 operator < (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Operator.greater_mask_byte(right, left));
            }
            else
            {
                return new bool4(left.x < right.x, left.y < right.y, left.z < right.z, left.w < right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Operator.greater_mask_byte(left, right));
            }
            else
            {
                return new bool4(left.x > right.x, left.y > right.y, left.z > right.z, left.w > right.w);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (byte4 left, byte4 right)
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
        public static bool4 operator <= (byte4 left, byte4 right)
        {
			if (Sse2.IsSse2Supported)
			{
				return TestIsTrue(Sse2.cmpeq_epi8(Sse2.min_epu8(left, right), left));
			}
			else
            {
                return new bool4(left.x <= right.x, left.y <= right.y, left.z <= right.z, left.w <= right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Sse2.cmpeq_epi8(Sse2.max_epu8(left, right), left));
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
		public  bool Equals(byte4 other)
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

		public override  bool Equals(object obj) => Equals((byte4)obj);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override  int GetHashCode()
		{
			if (Sse2.IsSse2Supported)
			{
				return ((v128)this).SInt0;
			}
			else
			{
				byte4 temp = this;

				return *(int*)&temp;
			}
		}


		public override  string ToString() => $"byte4({x}, {y}, {z}, {w})";
        public  string ToString(string format, IFormatProvider formatProvider) => $"byte4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}